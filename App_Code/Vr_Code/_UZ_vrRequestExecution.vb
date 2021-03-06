Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.VR
  Public Class ErpPOResult
    Public Property SPLoadID As String = ""
    Public Property ErpOrderNo As String = ""
    Public Property ErpOrderVN As String = ""
    Public Property SentForApproval As Boolean = False
    Public Property POApproved As Boolean = False
    Public ReadOnly Property VehicleCanBePlaced As Boolean
      Get
        If SentForApproval Or POApproved Then Return True Else Return False
      End Get
    End Property
    Public Shared Function GetPOStatus(epr As SIS.VR.ErpPOResult, ProjectID As String) As SIS.VR.ErpPOResult
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim ePO As SPApi.POData = SPApi.POData.GetByID(epr.SPLoadID, ProjectID, Comp)
      epr.ErpOrderNo = ePO.t_orno
      If ePO.t_orno <> "" Then
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select * from ttdmsl400" & Comp & " where t_orno='" & epr.ErpOrderNo & "' and t_vrsn = (select max(t_vrsn) from ttdmsl400" & Comp & " where t_orno='" & epr.ErpOrderNo & "') "
            Dim Rd As SqlDataReader = Cmd.ExecuteReader
            If Rd.Read() Then
              epr.POApproved = IIf(Rd("t_stat") = 1, True, False)
              epr.SentForApproval = IIf(Rd("t_work") = 1, True, False)
              epr.ErpOrderVN = Rd("t_vrsn")
            End If
          End Using
        End Using
      End If
      Return epr
    End Function
  End Class
  Partial Public Class vrRequestExecution
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If RequestStatusID = RequestStates.ODCRejected Then
        mRet = Drawing.Color.Red
      ElseIf RequestStatusID = RequestStates.RequestLinked Then
        mRet = Drawing.Color.DarkGoldenrod
      ElseIf RequestStatusID = RequestStates.ODCUnderApproval Then
        mRet = Drawing.Color.DarkOrange
      ElseIf RequestStatusID = RequestStates.VehicleArranged Then
        mRet = Drawing.Color.Tomato
      ElseIf RequestStatusID = RequestStates.VehiclePlaced Then
        mRet = Drawing.Color.Green
      ElseIf RequestStatusID = RequestStates.GRLinked Then
        mRet = Drawing.Color.DarkGoldenrod
      End If
      Return mRet
    End Function
    Public ReadOnly Property SanctionColor() As System.Drawing.Color
      Get
        If SanctionBalance < 0 Then
          Return Drawing.Color.Red
        Else
          Return GetColor()
        End If
      End Get
    End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Notification() As String
      Get
        Dim mRet As String = ""
        If SanctionExceeded And Not SanctionExceededApproved Then
          mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>Sanction consumed, Approval Required</b>"
        End If
        Return mRet
      End Get
    End Property

    Private _Supplier As SIS.QCM.qcmVendors = Nothing
    Private _Project As SIS.QCM.qcmProjects = Nothing
    Public ReadOnly Property Project() As SIS.QCM.qcmProjects
      Get
        If _Project Is Nothing Then
          Dim tmp As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(_SRNNo, "")
          If tmp.Count > 0 Then
            _Supplier = tmp(0).FK_VR_VehicleRequest_SupplierID
            _Project = tmp(0).FK_VR_VehicleRequest_ProjectID
          End If
        End If
        Return _Project
      End Get
    End Property
    Public ReadOnly Property SanctionBalance() As Decimal
      Get
        Return POValue - EstimatedPOBalance
      End Get
    End Property
    Public ReadOnly Property Supplier() As SIS.QCM.qcmVendors
      Get
        If _Supplier Is Nothing Then
          Dim tmp As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(_SRNNo, "")
          If tmp.Count > 0 Then
            _Supplier = tmp(0).FK_VR_VehicleRequest_SupplierID
            _Project = tmp(0).FK_VR_VehicleRequest_ProjectID
          End If
        End If
        Return _Supplier
      End Get
    End Property
    Public ReadOnly Property ProjectList() As List(Of String)
      Get
        Dim Results As New List(Of String)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select distinct ProjectID from vr_vehicleRequest where SRNNo=" & _SRNNo
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results.Add(Reader("ProjectID"))
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Get
    End Property
    Public ReadOnly Property ERPPO As String
      Get
        Dim mret As String = ""
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        For Each prj As String In ProjectList
          Dim ePO As SPApi.POData = SPApi.POData.GetByID(ISGECLoadID, prj, Comp)
          If ePO IsNot Nothing Then
            If mret = "" Then
              If ePO.t_orno = "" Then
                mret = "PO Data Pushed"
                Exit For
              Else
                mret = ePO.t_orno
              End If
            Else
              mret &= ", " & ePO.t_orno
            End If
          End If
        Next
        Return mret
      End Get
    End Property
    Public ReadOnly Property ForApprovalVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          If _Linked Then
            If _SRNNo.ToString = _LinkID Then
              Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(_SRNNo, "")
              For Each le As SIS.VR.vrRequestExecution In oLEs
                Select Case _RequestStatusID
                  Case RequestStates.GRLinked, RequestStates.ODCRejected, RequestStates.VehicleNotPlacedRejected
                  Case RequestStates.DelayedPlacementRejected, RequestStates.EmptyReturnRejected, RequestStates.DetentionRejected
                  Case RequestStates.SelfRejected
                  Case Else
                    mRet = False
                    Exit For
                End Select
              Next
            End If
          Else
            Select Case _RequestStatusID
              Case RequestStates.GRLinked, RequestStates.ODCRejected, RequestStates.VehicleNotPlacedRejected
              Case RequestStates.DelayedPlacementRejected, RequestStates.EmptyReturnRejected, RequestStates.DetentionRejected
              Case RequestStates.SelfRejected
              Case Else
                mRet = False
            End Select
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property LinkVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _RequestStatusID = RequestStates.RequestLinked Then
            If _Linked Then
              If _SRNNo.ToString = _LinkID Then
                mRet = True
              End If
            Else
              mRet = True
            End If
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _RequestStatusID
            Case RequestStates.RequestLinked, RequestStates.SanctionApprovalRejected, RequestStates.SanctionApproved
              If _Linked Then
                If _SRNNo.ToString = _LinkID Then
                  mRet = True
                End If
              Else
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ResendWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case _RequestStatusID
            Case RequestStates.VehicleArranged
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _RequestStatusID = RequestStates.VehicleArranged _
          Or _RequestStatusID = RequestStates.SelfRejected _
          Or _RequestStatusID = RequestStates.ODCRejected _
          Or _RequestStatusID = RequestStates.VehiclePlaced _
          Or _RequestStatusID = RequestStates.GRLinked Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CancelWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _RequestStatusID = RequestStates.VehicleArranged _
          Or _RequestStatusID = RequestStates.SelfRejected _
          Or _RequestStatusID = RequestStates.VehicleNotPlacedRejected _
          Or _RequestStatusID = RequestStates.DelayedPlacementRejected _
          Or _RequestStatusID = RequestStates.EmptyReturnRejected _
          Or _RequestStatusID = RequestStates.DetentionRejected _
          Or _RequestStatusID = RequestStates.VehiclePlaced _
          Or _RequestStatusID = RequestStates.ODCRejected Then
            If _Linked Then
              If _SRNNo.ToString = _LinkID Then
                mRet = True
              End If
            Else
              mRet = True
            End If
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CancelWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property VehiclePlacedWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _RequestStatusID = RequestStates.VehicleArranged Then
            If _Linked Then
              If _SRNNo.ToString = _LinkID Then
                mRet = True
              End If
            Else
              mRet = True
            End If
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If _RequestStatusID = RequestStates.ODCApproved _
          Or _RequestStatusID = RequestStates.VehicleNotPlacedApproved _
          Or _RequestStatusID = RequestStates.DelayedPlacementApproved _
          Or _RequestStatusID = RequestStates.EmptyReturnApproved _
          Or _RequestStatusID = RequestStates.DetentionApproved _
          Or _RequestStatusID = RequestStates.SelfApproved Then
            'If Linked:To Be discussed with Ajay Gupta
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property PushPODataVisible As Boolean
      Get
        If HttpContext.Current.Session("LoginID") = "0340" Then
          Return True
        End If
        Return False
      End Get
    End Property

    'Confirm Vehicle
    Public Shared Function NewLogicInitiateWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim Re As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      If Re.FK_VR_RequestExecution_TransporterID.EMailID = "" Then
        Throw New Exception("Transporter E-Mail ID is blank. Can Not Issue Memo.")
      End If
      Dim epr As New SIS.VR.ErpPOResult
      'If Re.SPLoadID = "" Then
      Dim prjList As List(Of String) = Re.ProjectList
        Dim isErr As Boolean = False
        Dim erStr As String = ""
        For Each prj As String In prjList
          Dim ePO As SPApi.POData = SPApi.POData.GetByID(Re.ISGECLoadID, prj, Comp)
          If ePO Is Nothing Then
            SPApi.POData.NewInsertData(Re, prj, Comp)
          End If
          epr.SPLoadID = Re.ISGECLoadID
          epr = SIS.VR.ErpPOResult.GetPOStatus(epr, prj)
          If Not epr.VehicleCanBePlaced Then
            If erStr <> "" Then erStr &= vbCrLf
            erStr &= "ERP PO: " & epr.ErpOrderNo & " -NOT Sent for approval or approved."
            isErr = True
          Else
            If erStr <> "" Then erStr &= vbCrLf
            erStr &= "ERP PO: " & epr.ErpOrderNo & " -OK"
          End If
        Next
        If isErr Then
          Throw New Exception(erStr)
        End If
      'Else
      '  epr.SPLoadID = Re.SPLoadID
      '  If Not epr.VehicleCanBePlaced Then
      '    Throw New Exception("ERP PO: " & epr.ErpOrderNo & " is NOT sent for approval or approved.")
      '  End If
      'End If
      'Linked Execution:Get PO Status is to be updated
      'Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Re.SRNNo, "")
      'For Each le As SIS.VR.vrRequestExecution In oLEs
      '  If le.SRNNo.ToString = Re.SRNNo Then Continue For
      '  Dim lpr As New SIS.VR.ErpPOResult
      '  lpr.SPLoadID = le.SPLoadID
      '  lpr = SIS.VR.ErpPOResult.GetPOStatus(lpr)
      '  If Not lpr.VehicleCanBePlaced Then
      '    Throw New Exception("Linked VE ERP PO: " & lpr.ErpOrderNo & " is NOT sent for approval or approved.")
      '  End If
      'Next
      'Main Execution
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNo, "")
      If oVRs.Count > 0 Then
        Dim ODCFound As Boolean = False
        For Each oVR As SIS.VR.vrVehicleRequest In oVRs
          If oVR.OverDimentionConsignement Then
            ODCFound = True
          End If
          oVR.RequestStatus = RequestStates.VehicleArranged
          SIS.VR.vrVehicleRequest.UpdateData(oVR)
        Next
        With Re
          .RequestStatusID = RequestStates.VehicleArranged
          .ArrangedBy = HttpContext.Current.Session("LoginID")
          .ArrangedOn = Now
          .ODCByRequest = ODCFound
        End With
        Re = SIS.VR.vrRequestExecution.UpdateData(Re)
      End If
      'Linked Executions
      'Is Pending
      'For Each le As SIS.VR.vrRequestExecution In oLEs
      '  If le.SRNNo.ToString = Re.SRNNo Then Continue For
      '  oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
      '  If oVRs.Count > 0 Then
      '    Dim ODCFound As Boolean = False
      '    For Each oVR As SIS.VR.vrVehicleRequest In oVRs
      '      If oVR.OverDimentionConsignement Then
      '        ODCFound = True
      '      End If
      '      oVR.RequestStatus = RequestStates.VehicleArranged
      '      SIS.VR.vrVehicleRequest.UpdateData(oVR)
      '    Next
      '    With le
      '      .RequestStatusID = RequestStates.VehicleArranged
      '      .ArrangedBy = HttpContext.Current.Session("LoginID")
      '      .ArrangedOn = Now
      '      .ODCByRequest = ODCFound
      '    End With
      '    le = SIS.VR.vrRequestExecution.UpdateData(le)
      '  End If
      'Next
      SendEMail(Re)
      Try
        CloseSPExecution(Re)
      Catch ex As Exception
      End Try
      'Linked Execution
      'For Each le As SIS.VR.vrRequestExecution In oLEs
      '  If le.SRNNo.ToString = Re.SRNNo Then Continue For
      '  SendEMail(le)
      '  Try
      '    CloseSPExecution(le)
      '  Catch ex As Exception
      '  End Try
      'Next

      Return Re
    End Function

    Public Shared Function InitiateWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      If Results.FK_VR_RequestExecution_TransporterID.EMailID = "" Then
        Throw New Exception("Transporter E-Mail ID is blank.")
      End If
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
      'Checking of Estimated Amount Entered or NOT is Mandatory
      '===========Commented====================
      If Convert.ToBoolean(ConfigurationManager.AppSettings("CheckSanction")) Then
        'Check Sanction First
        Dim SanctionExceeded As Boolean = False
        Results.SanctionExceeded = False
        Results = SIS.VR.vrRequestExecution.ValidateSanction(SRNNo, "")
        If Results.SanctionBalance < 0 Then
          Results.SanctionExceeded = True
          SanctionExceeded = True
        End If
        For Each le As SIS.VR.vrRequestExecution In oLEs
          le.SanctionExceeded = False
          le = SIS.VR.vrRequestExecution.ValidateSanction(le.SRNNo, "")
          If le.SanctionBalance < 0 Then
            le.SanctionExceeded = True
            SanctionExceeded = True
          End If
          SIS.VR.vrRequestExecution.UpdateData(le)
        Next
        Results.SanctionExceeded = SanctionExceeded
        SIS.VR.vrRequestExecution.UpdateData(Results)
        'Any exceeded found, Assign in all Linked
        If SanctionExceeded Then
          If Not Results.SanctionExceededApproved Then
            Results.RequestStatusID = RequestStates.UnderSanctionApproval
            SIS.VR.vrRequestExecution.UpdateData(Results)
            For Each le As SIS.VR.vrRequestExecution In oLEs
              le.SanctionExceeded = True
              le.RequestStatusID = RequestStates.UnderSanctionApproval
              SIS.VR.vrRequestExecution.UpdateData(le)
            Next
            SendEMailSanctionApproval(Results)
            Return Results
          End If
        End If
      End If
      'Checking Sanction Consumed Percent And Alert
      Dim ProjectID As String = Results.Project.ProjectID
      Dim tmpCon As Decimal = 0
      Try
        tmpCon = (Results.EstimatedPOBalance / Results.POValue) * 100
      Catch ex As Exception
        tmpCon = 100
      End Try
      Dim oSPC As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(ProjectID)
      If oSPC Is Nothing Then
        oSPC = New SIS.VR.vrSanctionAlert
        With oSPC
          .ProjectID = ProjectID
          .EMailIDs = "shatrughan.sharma@isgec.co.in,girish.belwal@isgec.co.in"
          SIS.VR.vrSanctionAlert.InsertData(oSPC)
        End With
      End If
      If tmpCon < 60 Then
      ElseIf tmpCon >= 60 And tmpCon < 70 Then
        If Not oSPC.At60 Then
          oSPC.At60 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 70 And tmpCon < 80 Then
        If Not oSPC.At70 Then
          oSPC.At70 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 80 And tmpCon < 90 Then
        If Not oSPC.At80 Then
          oSPC.At80 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 90 And tmpCon < 95 Then
        If Not oSPC.At90 Then
          oSPC.At90 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 95 And tmpCon < 96 Then
        If Not oSPC.At95 Then
          oSPC.At95 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 96 And tmpCon < 97 Then
        If Not oSPC.At96 Then
          oSPC.At96 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 97 And tmpCon < 98 Then
        If Not oSPC.At97 Then
          oSPC.At97 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 98 And tmpCon < 99 Then
        If Not oSPC.At98 Then
          oSPC.At98 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      ElseIf tmpCon >= 99 And tmpCon <= 100 Then
        If Not oSPC.At99 Then
          oSPC.At99 = True
          SIS.VR.vrSanctionAlert.UpdateData(oSPC)
          SendEMailSanctionConsumption(Results, tmpCon)
        End If
      End If
      '' ''End Consumed Alert
      '=====================
      'Main Execution
      If Not Results.SanctionExceeded OrElse Results.SanctionExceededApproved Then

        Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNo, "")
        If oVRs.Count > 0 Then
          Dim ODCFound As Boolean = False
          For Each oVR As SIS.VR.vrVehicleRequest In oVRs
            If oVR.OverDimentionConsignement Then
              ODCFound = True
            End If
            oVR.RequestStatus = RequestStates.VehicleArranged
            SIS.VR.vrVehicleRequest.UpdateData(oVR)
          Next
          With Results
            .RequestStatusID = RequestStates.VehicleArranged
            .ArrangedBy = HttpContext.Current.Session("LoginID")
            .ArrangedOn = Now
            .ODCByRequest = ODCFound
          End With
          Results = SIS.VR.vrRequestExecution.UpdateData(Results)
        End If
        'Linked Executions
        For Each le As SIS.VR.vrRequestExecution In oLEs
          If le.SRNNo.ToString = Results.SRNNo Then Continue For
          oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
          If oVRs.Count > 0 Then
            Dim ODCFound As Boolean = False
            For Each oVR As SIS.VR.vrVehicleRequest In oVRs
              If oVR.OverDimentionConsignement Then
                ODCFound = True
              End If
              oVR.RequestStatus = RequestStates.VehicleArranged
              SIS.VR.vrVehicleRequest.UpdateData(oVR)
            Next
            With le
              .RequestStatusID = RequestStates.VehicleArranged
              .ArrangedBy = HttpContext.Current.Session("LoginID")
              .ArrangedOn = Now
              .ODCByRequest = ODCFound
            End With
            le = SIS.VR.vrRequestExecution.UpdateData(le)
          End If
        Next
        SendEMail(Results)
        Try
          CloseSPExecution(Results)
        Catch ex As Exception
        End Try
      End If
      Return Results
    End Function
    Public Shared Sub CloseSPExecution(Results As SIS.VR.vrRequestExecution)
      'Update SuperProcure
      Dim isgE As New SPApi.ISGECExecution
      With isgE
        .loadId = Results.SPLoadID
        .reqId = Results.SPRequestID
        .memoNumber = Results.SRNNo
        .transporterCode = Results.TransporterID
        .placementDate = Results.VehiclePlacedOn
        .vehicleCode = Results.VehicleTypeID
        .materialWeight = Results.MaterialWeight
      End With
      SPApi.PushISGECExecution(isgE, "")
      'Update ERP-PO
      SPApi.POData.UpdateGeneratePO(Results.SPLoadID)

    End Sub

    'Cancel Vehicle
    Public Shared Function CancelWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(Results.SRNNo, "")
      If oVRs.Count > 0 Then
        For Each oVR As SIS.VR.vrVehicleRequest In oVRs
          oVR.RequestStatus = RequestStates.RequestLinked
          SIS.VR.vrVehicleRequest.UpdateData(oVR)
        Next
        With Results
          .RequestStatusID = RequestStates.RequestLinked
          .ArrangedBy = HttpContext.Current.Session("LoginID")
          .ArrangedOn = Now
          .ODCByRequest = False
          'Remove GR Entry
          .VehicleNo = ""
          .GRNo = ""
          .GRDate = ""
          .LoadedAtSupplier = False
          .LoadedOn = ""
          .ReachedAtSupplierOn = ""
          .SizeUnit = ""
          .Height = 0
          .Width = 0
          .Length = 0
          .MaterialWeight = 0
          .WeightUnit = ""
          .NoOfPackages = 0
          .OverDimentionConsignement = False
          .GRRemarks = ""
        End With
        Results = SIS.VR.vrRequestExecution.UpdateData(Results)
      End If
      'Linked Executions
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = Results.SRNNo Then Continue For
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
        If oVRs.Count > 0 Then
          For Each oVR As SIS.VR.vrVehicleRequest In oVRs
            oVR.RequestStatus = RequestStates.RequestLinked
            SIS.VR.vrVehicleRequest.UpdateData(oVR)
          Next
          With le
            .RequestStatusID = RequestStates.RequestLinked
            .ArrangedBy = HttpContext.Current.Session("LoginID")
            .ArrangedOn = Now
            .ODCByRequest = False
            'Remove GR Entry
            .VehicleNo = ""
            .GRNo = ""
            .GRDate = ""
            .LoadedAtSupplier = False
            .LoadedOn = ""
            .ReachedAtSupplierOn = ""
            .SizeUnit = ""
            .Height = 0
            .Width = 0
            .Length = 0
            .MaterialWeight = 0
            .WeightUnit = ""
            .NoOfPackages = 0
            .OverDimentionConsignement = False
            .GRRemarks = ""
          End With
          le = SIS.VR.vrRequestExecution.UpdateData(le)
        End If
      Next
      SendEMail(Results, True)
      Return Results
    End Function

    'Vehicle Placed
    Public Shared Function VehiclePlacedWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
      '=====================
      'Main Execution
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNo, "")
      If oVRs.Count > 0 Then
        For Each oVR As SIS.VR.vrVehicleRequest In oVRs
          oVR.RequestStatus = RequestStates.VehiclePlaced
          SIS.VR.vrVehicleRequest.UpdateData(oVR)
          Try
            SIS.CT.ctUpdates.CT_VehiclePlaced(oVR)
          Catch ex As Exception
          End Try
        Next
        With Results
          .RequestStatusID = RequestStates.VehiclePlaced
        End With
        Results = SIS.VR.vrRequestExecution.UpdateData(Results)
      End If
      'Linked Executions
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = Results.SRNNo Then Continue For
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
        If oVRs.Count > 0 Then
          For Each oVR As SIS.VR.vrVehicleRequest In oVRs
            oVR.RequestStatus = RequestStates.VehiclePlaced
            SIS.VR.vrVehicleRequest.UpdateData(oVR)
            Try
              SIS.CT.ctUpdates.CT_VehiclePlaced(oVR)
            Catch ex As Exception
            End Try
          Next
          With le
            .RequestStatusID = RequestStates.VehiclePlaced
          End With
          le = SIS.VR.vrRequestExecution.UpdateData(le)
        End If
      Next
      Return Results
    End Function

    Public Shared Function SendForApproval(ByVal SRNNo As Int32) As Boolean
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      If oRE.Linked Then
        Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
        For Each le As SIS.VR.vrRequestExecution In oLEs
          With le
            If .OverDimentionConsignement Then
              .RequestStatusID = RequestStates.ODCUnderApproval
            ElseIf .DetentionAtSupplier Then
              .RequestStatusID = RequestStates.DetentionUnderApproval
            ElseIf .DelayedPlacement Then
              .RequestStatusID = RequestStates.DelayedPlacementUnderApproval
            ElseIf .EmptyReturn Then
              .RequestStatusID = RequestStates.EmptyReturnRUnderApproval
            ElseIf .VehicleNotPlaced Then
              .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval
            Else
              .RequestStatusID = RequestStates.UnderSelfApproval
            End If
            .ApprovalRemarks = ""
            .ApprovedBy = ""
            .ApprovedOn = ""
          End With
          le = SIS.VR.vrRequestExecution.UpdateData(oRE)
          If le.VehicleNotPlaced Or le.EmptyReturn Then
            BlockExecution(le)
          End If
        Next
      Else 'Not Linked
        With oRE
          If .OverDimentionConsignement Then
            .RequestStatusID = RequestStates.ODCUnderApproval
          ElseIf .DetentionAtSupplier Then
            .RequestStatusID = RequestStates.DetentionUnderApproval
          ElseIf .DelayedPlacement Then
            .RequestStatusID = RequestStates.DelayedPlacementUnderApproval
          ElseIf .EmptyReturn Then
            .RequestStatusID = RequestStates.EmptyReturnRUnderApproval
          ElseIf .VehicleNotPlaced Then
            .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval
          Else
            .RequestStatusID = RequestStates.UnderSelfApproval
          End If
          .ApprovalRemarks = ""
          .ApprovedBy = ""
          .ApprovedOn = ""
        End With
        oRE = SIS.VR.vrRequestExecution.UpdateData(oRE)
        If oRE.VehicleNotPlaced Or oRE.EmptyReturn Then
          DelinkRequestsOfBlockedExecution(oRE)
        End If
      End If
      'SendForApprovalEMail(oRE)
      Return True
    End Function
    Public Shared Function BlockExecution(ByVal oRE As SIS.VR.vrRequestExecution) As Boolean
      Dim LinkID As String = oRE.LinkID
      Dim IsMain As Boolean = IIf(oRE.SRNNo.ToString = oRE.LinkID, True, False)
      'Delink From Execution
      With oRE
        .Linked = False
        .LinkID = ""
      End With
      SIS.VR.vrRequestExecution.UpdateData(oRE)
      DelinkRequestsOfBlockedExecution(oRE)
      'Select Rest of the Execution in link to Check 
      'If only one execution left, then remove it from Linked status
      'If more than one left then retain Linked status
      'If Main Link is removed, Make Other Link as Main
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(LinkID, "")
      If oLEs.Count = 1 Then
        oLEs(0).Linked = False
        oLEs(0).LinkID = ""
        SIS.VR.vrRequestExecution.UpdateData(oLEs(0))
        DelinkRequestsOfBlockedExecution(oLEs(0))
      Else
        If IsMain Then
          Dim NewLinkID As String = oLEs(0).SRNNo
          For Each le As SIS.VR.vrRequestExecution In oLEs
            le.LinkID = NewLinkID
            SIS.VR.vrRequestExecution.UpdateData(le)
          Next
        End If
      End If
      Return True
    End Function
    Public Shared Function DelinkRequestsOfBlockedExecution(ByVal oRE As SIS.VR.vrRequestExecution) As Boolean
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
      For Each oVR As SIS.VR.vrVehicleRequest In oVRs
        Dim OldRequestNo As String = oVR.RequestNo
        'Create New Request By Copying
        With oVR
          .RequestDescription = "OLD Request No: " & OldRequestNo
          .RequestStatus = RequestStates.UnderExecution
          .SRNNo = ""
          .ODCAtSupplierLoading = False
        End With
        oVR = SIS.VR.vrVehicleRequest.InsertData(oVR)
        Dim NewRequestNo As String = oVR.RequestNo
        'Get Old Request to Block
        oVR = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(OldRequestNo)
        With oVR
          oVR.RequestDescription = "NEW Request No: " & NewRequestNo
          .RequestStatus = RequestStates.RequestBlocked
        End With
        oVR = SIS.VR.vrVehicleRequest.UpdateData(oVR)
      Next
      Return True
    End Function
    'Trans Shipment
    Public Shared Function CompleteWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = vrRequestExecutionGetByID(SRNNo)
      Return Results
    End Function
    Public Shared Function UZ_vrRequestExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_RequestExecutionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_RequestExecutionSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrDisplayRequestExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_DisplayRequestExecutionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_DisplayRequestExecutionSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function UZ_vrRequestExecutionInsert(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Dim _Result As SIS.VR.vrRequestExecution = vrRequestExecutionInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrRequestExecutionUpdate(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Dim _Result As SIS.VR.vrRequestExecution = vrRequestExecutionUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrRequestExecutionDelete(ByVal Record As SIS.VR.vrRequestExecution) As Integer
      Dim _Result As Integer = vrRequestExecutionDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrRequestExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = vrRequestExecutionGetByID(SRNNo)
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function UZ_vrRequestExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_TransporterID As String, ByVal Filter_VehicleTypeID As Int32) As SIS.VR.vrRequestExecution
      Return UZ_vrRequestExecutionGetByID(SRNNo)
    End Function
    Public Shared Function UZ_vrLinkedExecution(ByVal SRNNo As Integer) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_LinkedExecution"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo", SqlDbType.Int, 10, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrUnLinkedExecution(ByVal SRNNo As Integer) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_UnLinkedExecution"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo", SqlDbType.Int, 10, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Shadows Function SendEMail(ByVal oRE As SIS.VR.vrRequestExecution, Optional ByVal CancellationEMail As Boolean = False) As String
      If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then Return ""
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      'Executers of Linked Executions
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
          ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
      Next
      'Requester, Buyer and Executers of Execution
      Dim ProjectsAdded As Boolean = False
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
      For Each vr As SIS.VR.vrVehicleRequest In oVRs
        If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
          If Not ProjectsAdded Then
            Try
              If vr.FK_VR_VehicleRequest_RequestedBy.EMailID.ToLower.IndexOf("isgec.com") >= 0 Then
                oMsg.CC.Add(New MailAddress("sarvjeet@isgec.co.in", "Sarvjeet Chowdhry"))
                oMsg.CC.Add(New MailAddress("tmdproject@isgec.com", "TMD Projects-YNR"))
                oMsg.CC.Add(New MailAddress("manoj.raghav@isgec.co.in", "Manoj Raghav"))
              End If

              'Projects Employees Mapping
              Dim prUsers As List(Of SIS.TPISG.tpisg046) = SIS.TPISG.tpisg046.GetUsersEMailIDs(vr.ProjectID)
              Dim IDsFound As Boolean = False

              For Each pu As SIS.TPISG.tpisg046 In prUsers
                If pu.EMailID.Trim <> "" Then
                  IDsFound = True
                  ad = New MailAddress(pu.EMailID.Trim, pu.UserName)
                  If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
                End If
              Next
              If Not IDsFound Then
                Dim GroupID As Integer = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)(0).GroupID
                Select Case GroupID
                  Case 1 ' boiler
                    oMsg.CC.Add("boilerprojects@isgec.co.in")
                  Case 2 'smd
                    oMsg.CC.Add("smdprojects@isgec.co.in")
                  Case 4 'EPC
                    oMsg.CC.Add("epcprojects@isgec.co.in")
                  Case 5 'APCE
                    oMsg.CC.Add("apceprojects@isgec.co.in")
                End Select
              End If
              ProjectsAdded = True
            Catch ex As Exception
            End Try
          End If
          ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
        'Buyers in Request, in old requests buyer may be null
        Try
          If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Catch ex As Exception
        End Try
        'Executers of the Requester's Group
        Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
        Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
        If vr.OutOfContract Then
          oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
        Else
          oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
        End If
        For Each exe As SIS.VR.vrUserGroup In oExec
          If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
            ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Next
      Next
      'Requester, Buyer and Executers of Linked Executions
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
        For Each vr As SIS.VR.vrVehicleRequest In oVRs
          If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
          'Buyers in Request, in old requests buyer may be null
          Try
            If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
              ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Catch ex As Exception
          End Try
          'Executers of the Requester's Group
          Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
          Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
          If vr.OutOfContract Then
            oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
          Else
            oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
          End If
          For Each exe As SIS.VR.vrUserGroup In oExec
            If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
              ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Next
        Next
      Next
      'Transporter EMailIDS
      If oRE.FK_VR_RequestExecution_TransporterID.EMailID <> String.Empty Then
        If oRE.FK_VR_RequestExecution_TransporterID.EMailID <> String.Empty Then
          Dim aIDs() As String = oRE.FK_VR_RequestExecution_TransporterID.EMailID.Split(",".ToCharArray)
          For Each id As String In aIDs
            ad = New MailAddress(id.Trim)
            Try
              If Not oMsg.To.Contains(ad) Then oMsg.To.Add(ad)
            Catch ex As Exception
            End Try
          Next
        End If
      End If
      oMsg.IsBodyHtml = True
      If CancellationEMail Then
        oMsg.Subject = "MEMO FOR LIFTING THE MATERIAL-CANCELLED, Exe.No: " & oRE.SRNNo
      Else
        oMsg.Subject = "MEMO FOR LIFTING THE MATERIAL, Exe.No: " & oRE.SRNNo
      End If

      Dim sb As New StringBuilder
      With sb
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan='2' style='font-style:italic;text-align:right;font;font-size:10px;'>Format:Rev-1,Date:15-01-2021</td></tr>")
        If CancellationEMail Then
          .AppendLine("<tr><td colspan=""2"" style=""color:red"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL-CANCELLED</b></h2></td></tr>")
        Else
          .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL</b></h2></td></tr>")
        End If
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim CompName As String = ""
        Dim CompAdd1 As String = ""
        Dim CompAdd2 As String = ""
        Dim CompGSTIN As String = ""
        CompName = "ISGEC HEAVY ENGINEERING LIMITED"
        CompAdd1 = "Saraswati Corporate Center, A-4, Sector-24"
        CompAdd2 = "Noida, Gautam Buddha Nagar, UP-201301"
        CompGSTIN = "09AAACT5540K2Z4"
        Select Case Comp
          Case "200"
            CompName = "ISGEC HEAVY ENGINEERING LIMITED"
            CompAdd1 = "Saraswati Corporate Center, A-4, Sector-24"
            CompAdd2 = "Noida, Gautam Buddha Nagar, UP-201301"
            CompGSTIN = "09AAACT5540K2Z4"
          Case "700"
            CompName = "Isgec Redecam Enviro Solutions Private Limited"
            CompAdd1 = "A-5, Sector-63"
            CompAdd2 = "Noida, Gautam Buddha Nagar, UP-201301"
            CompGSTIN = "09AAECI3897A2ZG"
          Case "651"
            CompName = "ISGEC COVEMA LTD."
            CompAdd1 = "Saraswati Corporate Center, A-4, Sector-24"
            CompAdd2 = "Noida, Gautam Buddha Nagar, UP-201301"
            CompGSTIN = "09AAACI1229C2Z2"
        End Select
        .AppendLine("<tr><td style='background-color:lightgray'><b>Company Name</b></td>")
        .AppendLine("<td style='font-size:14px;font-weight:bold;'>" & CompName & "</td></tr>")
        .AppendLine("<tr><td style='background-color:lightgray'><b>Address</b></td>")
        .AppendLine("<td style='font-size:12px;font-weight:bold;'>" & CompAdd1 & "<br/>" & CompAdd2 & "</td></tr>")
        .AppendLine("<tr><td style='background-color:lightgray'><b>ERP Code</b></td>")
        .AppendLine("<td style='font-size:12px;font-weight:bold;'>" & Comp & "</td></tr>")
        .AppendLine("<tr><td style='background-color:lightgray'><b>GSTIN</b></td>")
        .AppendLine("<td style='font-size:12px;font-weight:bold;'>" & CompGSTIN & "</td></tr>")
        'Main Execution
        .AppendLine("<tr><td style='background-color:lightgray'><b>Execution No.</b></td>")
        .AppendLine("<td style='font-size:14px;font-weight:bold;'>" & oRE.SRNNo & "</td></tr>")
        .AppendLine("<tr><td style='background-color:lightgray'><b>ERP PO Number</b></td>")
        .AppendLine("<td style='font-size:12px;font-weight:bold;'>" & oRE.ERPPO & "</td></tr>")
        .AppendLine("<tr><td><b>Project Name &  Code</b></td>")
        .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
        .AppendLine("<tr><td><b>Name of Shipper / Supplier with Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
        .AppendLine("<td>")
        First = True
        Cnt = 1
        For Each _vr As SIS.VR.vrVehicleRequest In oVRs
          If Cnt > 1 Then
            .AppendLine("<hr/>")
            First = False
          End If
          .AppendLine(Cnt & ") " & _vr.FK_VR_VehicleRequest_SupplierID.Description & " [" & _vr.SupplierID & "]")
          .AppendLine("<br/>" & _vr.SupplierLocation)
          .AppendLine("<br/>" & _vr.FromPinCode)
          Cnt = Cnt + 1
        Next
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td><b>Receiver Name / Site/ CHA / Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
        .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description)
        .AppendLine("<br/>" & oVRs(0).DeliveryLocation)
        .AppendLine("<br/>" & oVRs(0).ToPinCode)
        .AppendLine("<br/><b>" & oVRs(0).SitePersonName)
        .AppendLine("<br/>" & oVRs(0).SitePersonContact)
        .AppendLine("</b></td></tr>")
        .AppendLine("<tr><td><b>Name of the Material / Equipment</b></td>")
        .AppendLine("<td>")
        Cnt = 1
        For Each _vr As SIS.VR.vrVehicleRequest In oVRs
          If Cnt > 1 Then
            .AppendLine("<hr />")
          End If
          .AppendLine("<br/>" & Cnt & ") " & _vr.ItemDescription)
          Cnt = Cnt + 1
        Next
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td><b>Dimension (L x W x H ) Unit</b></td>")
        .AppendLine("<td>")
        Cnt = 1
        For Each _vr As SIS.VR.vrVehicleRequest In oVRs
          If Cnt > 1 Then
            .AppendLine("<hr />")
          End If
          Try
            .AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " " & _vr.FK_VR_VehicleRequest_SizeUnit.Description)
          Catch ex As Exception
            .AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " ***Unit Not Defined***")
          End Try
          Cnt = Cnt + 1
        Next
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td><b>Weight - Unit</b></td>")
        .AppendLine("<td>")
        Cnt = 1
        For Each _vr As SIS.VR.vrVehicleRequest In oVRs
          If Cnt > 1 Then
            .AppendLine("<hr />")
          End If
          Try
            .AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " " & _vr.FK_VR_VehicleRequest_WeightUnit.Description)
          Catch ex As Exception
            .AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " ***Unit Not Defined***")
          End Try
          Cnt = Cnt + 1
        Next
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td><b>No. Of Packages</b></td>")
        .AppendLine("<td>")
        Cnt = 1
        For Each _vr As SIS.VR.vrVehicleRequest In oVRs
          If Cnt > 1 Then
            .AppendLine("<hr />")
          End If
          .AppendLine("<br/>" & Cnt & ") " & _vr.NoOfPackages)
          Cnt = Cnt + 1
        Next
        .AppendLine("</td></tr>")
        .AppendLine("<tr><td><b>Type of Vehicle</b></td>")
        .AppendLine("<td>" & oRE.FK_VR_RequestExecution_VehicleTypeID.cmba & "</td></tr>")
        .AppendLine("<tr><td><b>Vehicle to be placed on Date</b></td>")
        .AppendLine("<td>" & oRE.VehiclePlacedOn & "</td></tr>")
        .AppendLine("<tr><td><b>Name of Executor</b></td>")
        .AppendLine("<td>" & oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & oRE.ArrangedBy & "]" & "</td></tr>")
        .AppendLine("<tr><td><b>Export Invoice No.</b></td>")
        .AppendLine("<td>" & IIf(oVRs(0).CustomInvoiceNo = String.Empty, "NA", oVRs(0).CustomInvoiceNo) & "</td></tr>")
        .AppendLine("<tr><td><b>Transporter</b></td>")
        .AppendLine("<td>" & oRE.FK_VR_RequestExecution_TransporterID.TransporterName & "</td></tr>")
        'Linked Executions
        For Each le As SIS.VR.vrRequestExecution In oLEs
          If le.SRNNo.ToString = oRE.SRNNo Then Continue For
          oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
          .AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
          .AppendLine("<td>" & le.SRNNo & "</td></tr>")
          .AppendLine("<tr><td><b>Project Name &  Code</b></td>")
          .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
          .AppendLine("<tr><td><b>Name of Shipper / Supplier with Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
          .AppendLine("<td>")
          First = True
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr/>")
              First = False
            End If
            .AppendLine(Cnt & ") " & _vr.FK_VR_VehicleRequest_SupplierID.Description & " [" & _vr.SupplierID & "]")
            .AppendLine("<br/>" & _vr.SupplierLocation)
            .AppendLine("<br/>" & _vr.FromPinCode)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>Receiver Name / Site/ CHA / Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
          .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description)
          .AppendLine("<br/>" & oVRs(0).DeliveryLocation)
          .AppendLine("<br/>" & oVRs(0).ToPinCode)
          .AppendLine("<br/><b>" & oVRs(0).SitePersonName)
          .AppendLine("<br/>" & oVRs(0).SitePersonContact)
          .AppendLine("</b></td></tr>")
          .AppendLine("<tr><td><b>Name of the Material / Equipment</b></td>")
          .AppendLine("<td>")
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr />")
            End If
            .AppendLine("<br/>" & Cnt & ") " & _vr.ItemDescription)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>Dimension (L x W x H ) Unit</b></td>")
          .AppendLine("<td>")
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr />")
            End If
            .AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " " & _vr.FK_VR_VehicleRequest_SizeUnit.Description)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>Weight - Unit</b></td>")
          .AppendLine("<td>")
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr />")
            End If
            .AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " " & _vr.FK_VR_VehicleRequest_WeightUnit.Description)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>No. Of Packages</b></td>")
          .AppendLine("<td>")
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr />")
            End If
            .AppendLine("<br/>" & Cnt & ") " & _vr.NoOfPackages)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>Type of Vehicle</b></td>")
          .AppendLine("<td>" & le.FK_VR_RequestExecution_VehicleTypeID.cmba & "</td></tr>")
          .AppendLine("<tr><td><b>Vehicle to be placed on Date</b></td>")
          .AppendLine("<td>" & le.VehiclePlacedOn & "</td></tr>")
          .AppendLine("<tr><td><b>Name of Executer</b></td>")
          .AppendLine("<td>" & le.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & le.ArrangedBy & "]" & "</td></tr>")
          .AppendLine("<tr><td><b>Export Invoice No.</b></td>")
          .AppendLine("<td>" & IIf(oVRs(0).CustomInvoiceNo = String.Empty, "NA", oVRs(0).CustomInvoiceNo) & "</td></tr>")
          .AppendLine("<tr><td><b>Transporter</b></td>")
          .AppendLine("<td>" & le.FK_VR_RequestExecution_TransporterID.TransporterName & "</td></tr>")
          .AppendLine("<tr><td><b>Tarpaulin</b></td>")
          .AppendLine("<td>")
          Dim TarpaulinRequired As String = "NO"
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If _vr.TarpaulineRequired Then
              TarpaulinRequired = "YES"
            End If
          Next
          .AppendLine(TarpaulinRequired)
          .AppendLine("</td></tr>")
          .AppendLine("<tr><td><b>Vehicle Requester</b></td>")
          .AppendLine("<td>")
          Cnt = 1
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            If Cnt > 1 Then
              .AppendLine("<hr />")
            End If
            .AppendLine("<br/>" & Cnt & ") " & _vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
            Cnt = Cnt + 1
          Next
          .AppendLine("</td></tr>")
        Next 'le
        'End of Linked Executions
        .AppendLine("<tr><td colspan=""2"">")
        .AppendLine("<br/><b>IMPORTANT NOTES:-</b>")
        .AppendLine("<br/>1) Please Hand Over Consignee Copy of Docket to Shipper/Supplier and take the signature of Shipper/Supplier on the Docket.")
        .AppendLine("<br/>2) Shipper Copy and POD Copy of docket must be carrying/accompany with Dispatch Documents & Material.")
        .AppendLine("<br/>3) Shipper Copy of docket and Dispatch Documents along with Material to be handed Over to Customer/CHA (Receiver).")
        .AppendLine("<br/>4) Take the Signature & Rubber Stamp of Receiver on the POD Copy of Docket at the time of delivery of material.")
        .AppendLine("<br/>5) It is <b>MANDATORY</b> to inform us material dimension and weight in case of ODC or Over Weight Consignment.")
        .AppendLine("<br/></td></tr>")
        .AppendLine("</table>")
      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header

        If Not CancellationEMail Then
          'Attachments of Main Execution Request
          oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
          For Each _vr As SIS.VR.vrVehicleRequest In oVRs
            Dim oAtchs As List(Of SIS.VR.vrRequestAttachments) = SIS.VR.vrRequestAttachments.vrRequestAttachmentsSelectList(0, 99, "", False, "", _vr.RequestNo)
            For Each atch As SIS.VR.vrRequestAttachments In oAtchs
              If IO.File.Exists(atch.DiskFile) Then
                Dim at As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(atch.DiskFile)
                at.Name = atch.FileName
                oMsg.Attachments.Add(at)
              End If
            Next
          Next
          'Attachments of Linked Executions
          For Each le As SIS.VR.vrRequestExecution In oLEs
            If le.SRNNo.ToString = oRE.SRNNo Then Continue For
            oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
            For Each _vr As SIS.VR.vrVehicleRequest In oVRs
              Dim oAtchs As List(Of SIS.VR.vrRequestAttachments) = SIS.VR.vrRequestAttachments.vrRequestAttachmentsSelectList(0, 99, "", False, "", _vr.RequestNo)
              For Each atch As SIS.VR.vrRequestAttachments In oAtchs
                If IO.File.Exists(atch.DiskFile) Then
                  Dim at As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(atch.DiskFile)
                  at.Name = atch.FileName
                  oMsg.Attachments.Add(at)
                End If
              Next
            Next
          Next
        End If
        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function
    Public Shared Function UZ_vrRequestExecutionLinkedSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LinkID As Int32) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_RequestExecutionLinkedSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_RequestExecutionLinkedSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LinkID", SqlDbType.Int, 10, IIf(LinkID = Nothing, 0, LinkID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrRequestExecutionLinkedSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LinkID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function ValidateSanction(ByVal SRNNO As Integer, ByRef strHTML As String) As SIS.VR.vrRequestExecution
      Dim mRet As Boolean = False
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNO)
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNO, "")
      If oVRs.Count > 0 Then Else Return Nothing
      Dim ProjectID As String = oVRs(0).ProjectID
      Dim Company As String = GetProjectFinanceCompany(ProjectID)
      If ProjectID.StartsWith("BS") Or ProjectID.StartsWith("DS") Then
        Company = "700"
      End If
      Dim SanctionAmount As Decimal = GetSanctionFromERPLN(ProjectID, Company)
      Dim ConsumedInMaterial As Decimal = GetConsumedInMaterial(ProjectID, Company)
      Dim StartDate As String = GetVRSystemStartDate(ProjectID)
      Dim ConsumedBeforeVRSystem As Decimal = GetConsumedBeforeVRSystem(ProjectID, StartDate)

      Dim AvailableSanction As Decimal = SanctionAmount  '- ConsumedInMaterial - ConsumedBeforeVRSystem
      Dim ConsumedInVehicleRequests As Decimal = 0
      'FOR CONSUMED IN VRs
      '1. Select Executions
      Dim oREs As List(Of vrExecutions) = GetExecutions(ProjectID)
      '2. Select IRs
      Dim oIRs As List(Of vrIRs) = GetIRs(ProjectID)
      '3. Remove Execution, If Linked IR is Picked (may be Linked to Multiple Executions)
      For Each tmp As vrIRs In oIRs
        For I As Integer = oREs.Count - 1 To 0 Step -1
          Dim tm As vrExecutions = oREs(I)
          If tmp.SRNNo = tm.SRNNo Then
            oREs.RemoveAt(I)
          End If
        Next
      Next
      '3. As oIRs contains dulicate IR, because One stransporter bill contains multiple execution       
      oIRs = GetDistinctIRs(ProjectID)

      '4. Select PTR
      For Each tmp As vrIRs In oIRs
        '5. Update IR Bill Amount with PTR Amount, If Linked PTR is picked (1 IR = 1 PTR NO Multiple Linking)
        tmp.BillAmount = GetPTRFromERPLN(tmp.IRNo, tmp.BillAmount, Company)
      Next
      'Calculate consumed
      For Each tmp As vrIRs In oIRs
        ConsumedInVehicleRequests += tmp.BillAmount
      Next
      For Each tmp As vrExecutions In oREs
        ConsumedInVehicleRequests += tmp.Amount
      Next

      Dim TotalConsumed As Decimal = ConsumedInVehicleRequests + ConsumedInMaterial + ConsumedBeforeVRSystem
      'Update Vehicle Execution record
      With oRE
        .POValue = AvailableSanction
        .EstimatedPOBalance = TotalConsumed
      End With
      strHTML = "<table>"
      strHTML &= "<tr><td>" & ProjectID & "</td><td>" & SanctionAmount & "</td></tr>"
      strHTML &= "<tr><td> P.O. </td><td>" & ConsumedInMaterial & "</td></tr>"
      strHTML &= "<tr><td> Vehicle Requests </td><td>" & ConsumedInVehicleRequests & "</td></tr>"
      strHTML &= "<tr><td> Total Consumed </td><td>" & TotalConsumed & "</td></tr>"
      strHTML &= "<tr><td> Balance Available </td><td>" & AvailableSanction - TotalConsumed & "</td></tr>"
      strHTML &= "</table>"
      Return oRE
    End Function
    Public Shared Function GetPTRFromERPLN(ByVal IRNo As Integer, ByVal BillAmount As Decimal, ByVal Company As String) As Decimal
      Dim mRet As Decimal = BillAmount
      Dim MainCompany As String = "200"
      If Company = "700" Then MainCompany = "700"
      If Company = "651" Then MainCompany = "651"

      Dim Sql As String = ""
      Sql = Sql & "select "
      Sql = Sql & "isnull(pb.t_amth_1,0) as PTRAmount "
      Sql = Sql & "from ttfacp100" & MainCompany & " as ir "
      Sql = Sql & "inner join ttfacp200" & Company & " as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)   "
      Sql = Sql & "where ir.t_ctyp = 'PTR' and pb.t_tpay=1 and ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim tmp As Decimal = Cmd.ExecuteScalar
          If tmp > 0 Then
            mRet = tmp
          End If
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetDistinctIRs(ByVal ProjectID As String) As List(Of vrIRs)
      Dim mRet As Decimal = 0
      Dim Sql As String = "select distinct IRNo, BillAmount from (select "
      Sql &= "re.SRNNo as SRNNo,"
      Sql &= "ir.IRNo as IRNo,"
      Sql &= "ir.BillAmount as BillAmount "
      Sql &= "from vr_TransporterBill as ir "
      Sql &= "  inner join vr_RequestExecution as re on re.IRNo=ir.IRNo "
      Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
      Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "') as tmp"
      Dim Results As List(Of vrIRs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of vrIRs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New vrIRs(0, Reader("IRNo"), Reader("BillAmount")))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetProjectFinanceCompany(ByVal ProjectID As String) As String
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim mRet As Decimal = 0
      Dim Sql As String = "select t_ncmp "
      Sql &= " from ttppdm600" & Comp
      Sql &= " where t_cprj='" & ProjectID.ToUpper & "'"
      Dim Results As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetIRs(ByVal ProjectID As String) As List(Of vrIRs)
      Dim mRet As Decimal = 0
      Dim Sql As String = "select "
      Sql &= "re.SRNNo as SRNNo,"
      Sql &= "ir.IRNo as IRNo,"
      Sql &= "ir.BillAmount as BillAmount "
      Sql &= "from vr_TransporterBill as ir "
      Sql &= "  inner join vr_RequestExecution as re on re.IRNo=ir.IRNo "
      Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
      Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "'"
      Dim Results As List(Of vrIRs) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of vrIRs)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New vrIRs(Reader("SRNNo"), Reader("IRNo"), Reader("BillAmount")))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetExecutions(ByVal ProjectID As String) As List(Of vrExecutions)
      Dim mRet As Decimal = 0
      Dim Sql As String = "select "
      Sql &= "re.SRNNo as SRNNo,"
      Sql &= "re.EstimatedAmount as EstimatedAmount "
      Sql &= "from vr_RequestExecution as re "
      Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
      Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "'"
      Dim Results As List(Of vrExecutions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of vrExecutions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New vrExecutions(Reader("SRNNo"), Reader("EstimatedAmount")))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Class vrIRs
      Public SRNNo As Integer = 0
      Public IRNo As Integer = 0
      Public BillAmount As Decimal = 0
      Sub New(ByVal sr As Integer, ByVal ir As Integer, ByVal amt As Decimal)
        SRNNo = sr
        IRNo = ir
        BillAmount = amt
      End Sub
      Sub New()
        'dummy
      End Sub
    End Class

    Public Class vrExecutions
      Public SRNNo As Integer = 0
      Public Amount As Decimal = 0
      Sub New(ByVal sr As Integer, ByVal amt As Decimal)
        SRNNo = sr
        Amount = amt
      End Sub
      Sub New()
        'dummy
      End Sub
    End Class
    Public Shared Function GetConsumedBeforeVRSystem(ByVal ProjectID As String, ByVal StartDate As String) As Decimal
      Dim mRet As Decimal = 0
      'Dim Sql As String = ""
      'Sql &= "select sum(aa.t_oamt) as Amount from ttdpur401200 as aa  "
      'Sql &= "inner join ttdpur400200 as bb on aa.t_orno=bb.t_orno "
      'Sql &= "where aa.t_cspa='99050500' "
      'Sql &= "and   bb.t_cotp='P01' "
      'Sql &= "and   aa.t_cprj = '" & ProjectID.ToUpper & "'"
      'Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      '  Using Cmd As SqlCommand = Con.CreateCommand()
      '    Cmd.CommandType = CommandType.Text
      '    Cmd.CommandText = Sql
      '    Con.Open()
      '    Dim tmp As Decimal = Cmd.ExecuteScalar
      '    If Not Convert.IsDBNull(tmp) Then
      '      mRet = tmp
      '    End If
      '  End Using
      'End Using
      Return mRet
    End Function
    Public Shared Function GetVRSystemStartDate(ByVal ProjectID As String) As String
      Dim mRet As String = ""
      Dim Sql As String = ""
      Sql &= "select convert(nvarchar(10),min(VehicleRequiredOn),103) as tmpDT "
      Sql &= "from VR_VehicleRequest "
      Sql &= "where (RequestStatus >= 6 And RequestStatus <= 25) "
      Sql &= "and VehicleRequiredOn is not null "
      Sql &= "and UPPER(projectid)='" & ProjectID.ToUpper & "'"
      Dim Results As SIS.VR.vrVehicleRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Try
            mRet = Cmd.ExecuteScalar
          Catch ex As Exception
            Dim aa As String = ex.Message
          End Try
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function GetConsumedInMaterial(ByVal ProjectID As String, ByVal Company As String) As Decimal
      If Company = "700" Then
      ElseIf Company = "651" Then
      Else
        Company = "200"
      End If
      Dim mRet As Decimal = 0
      Dim Sql As String = ""
      Sql &= "select ISNULL(sum(aa.t_oamt),0) as Amount from ttdpur401" & Company.Trim & " as aa  "
      Sql &= "inner join ttdpur400" & Company.Trim & " as bb on aa.t_orno=bb.t_orno "
      Sql &= "where aa.t_cspa='99050500' "
      Sql &= "and   bb.t_cotp IN ('P01','C01','RC0','RC1') "
      Sql &= "and   Left(bb.t_orno,4) <> 'P601' "
      Sql &= "and   aa.t_oltp in (2,4) "
      Sql &= "and   aa.t_cprj = '" & ProjectID.ToUpper & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim tmp As Decimal = Cmd.ExecuteScalar
          If Not Convert.IsDBNull(tmp) Then
            mRet = tmp
          End If
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetSanctionFromERPLN(ByVal ProjectID As String, ByVal Company As String) As Decimal
      Dim mRet As Decimal = 0
      Dim Sql As String = ""
      'Sql = Sql & "select ir.t_ninv as IRNo,"
      'Sql = Sql & "       ir.t_ctyp as PTR,"
      'Sql = Sql & "       ir.t_cinv as PTRNo,"
      'Sql = Sql & "       pb.t_refr as PaymentReference,"
      'Sql = Sql & "       pb.t_pdat as PTRDate,"
      'Sql = Sql & "       pb.t_amnt as PTRAmount,"
      'Sql = Sql & "       pb.t_btno as Batch,"
      'Sql = Sql & "       cq.t_cheq as ChequeNo,"
      'Sql = Sql & "       cq.t_dout as ChequeDate,"
      'Sql = Sql & "       cq.t_amnt as ChequeAmount,"
      'Sql = Sql & "       cq.t_chnm as PaymentDescription,"
      'Sql = Sql & "       cq.t_drec as ReconciledOn,"
      'Sql = Sql & "       (case when cq.t_drec ='' then 0 else 1 end) as Freezed, "
      'Sql = Sql & "       bt.t_user as ProcessedBy,"
      'Sql = Sql & "       bt.t_date as ProcessedOn "
      'Sql = Sql & "from ttfacp100200 as ir "
      'Sql = Sql & "     inner join ttfcmg101200 as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)  "
      'Sql = Sql & "     inner join ttfcmg100200 as cq on pb.t_btno = cq.t_pbtn "
      'Sql = Sql & "     inner join ttfcmg109200 as bt on pb.t_btno = bt.t_btno "
      'Sql = Sql & "where ir.t_ctyp = 'PTR' and ir.t_ninv = " & IRNo
      If Company = "700" Then
      ElseIf Company = "651" Then
      Else
        Company = "200"
      End If

      Sql &= "select t_totl from ttpisg012" & Company.Trim & " where t_elem='99050500' and t_cprj='" & ProjectID.ToUpper & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim tmp As Decimal = Cmd.ExecuteScalar
          If Not Convert.IsDBNull(tmp) Then
            mRet = tmp
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Shadows Function SendEMailSanctionApproval(ByVal oRE As SIS.VR.vrRequestExecution) As String
      If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then Return ""
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      'Executers of Linked Executions
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
          ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
      Next
      'Requester, Buyer and Executers of Execution
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
      For Each vr As SIS.VR.vrVehicleRequest In oVRs
        If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
          ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
        'Projects Employees Mapping
        Dim prUsers As List(Of SIS.TPISG.tpisg046) = SIS.TPISG.tpisg046.GetUsersEMailIDs(vr.ProjectID)
        Dim IDsFound As Boolean = False
        For Each pu As SIS.TPISG.tpisg046 In prUsers
          If pu.EMailID.Trim <> "" Then
            IDsFound = True
            ad = New MailAddress(pu.EMailID.Trim, pu.UserName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Next
        If Not IDsFound Then
          Dim GroupID As Integer = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)(0).GroupID
          Select Case GroupID
            Case 1 ' boiler
              oMsg.CC.Add("boilerprojects@isgec.co.in")
            Case 2 'smd
              oMsg.CC.Add("smdprojects@isgec.co.in")
            Case 4 'EPC
              oMsg.CC.Add("epcprojects@isgec.co.in")
            Case 5 'APCE
              oMsg.CC.Add("apceprojects@isgec.co.in")
          End Select
        End If
        'Buyers in Request, in old requests buyer may be null
        Try
          If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Catch ex As Exception
        End Try
        'Executers of the Requester's Group
        Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
        Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
        If vr.OutOfContract Then
          oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
        Else
          oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
        End If
        For Each exe As SIS.VR.vrUserGroup In oExec
          If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
            ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Next
      Next
      'Requester, Buyer and Executers of Linked Executions
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
        For Each vr As SIS.VR.vrVehicleRequest In oVRs
          If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
          'Buyers in Request, in old requests buyer may be null
          Try
            If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
              ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Catch ex As Exception
          End Try
          'Executers of the Requester's Group
          Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
          Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
          If vr.OutOfContract Then
            oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
          Else
            oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
          End If
          For Each exe As SIS.VR.vrUserGroup In oExec
            If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
              ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Next
        Next
      Next
      oMsg.IsBodyHtml = True
      oMsg.Subject = "Sanction Exceeded, Approval Required, Project/Exe.No: " & oRE.Project.ProjectID & "/" & oRE.SRNNo

      Dim sb As New StringBuilder
      With sb
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>SANCTION EXCEEDED, APPROVAL REQUIRED</b></h2></td></tr>")
        'Main Execution
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
        .AppendLine("<td>" & oRE.SRNNo & "</td></tr>")
        .AppendLine("<tr><td><b>Project Name &  Code</b></td>")
        .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
        .AppendLine("<tr><td><b>Sanction Amount</b></td>")
        .AppendLine("<td>" & (oRE.POValue).ToString("n") & "</td></tr>")
        'Consumed Amount should be picked from Linked Executions, where it is exceeded
        .AppendLine("<tr><td><b>Consumed Sanction</b></td>")
        .AppendLine("<td>" & (oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
        .AppendLine("<tr><td><b>Balance Sanction</b></td>")
        .AppendLine("<td>" & (oRE.POValue - oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
        'End of Linked Executions
        .AppendLine("<tr><td colspan=""2"">")
        .AppendLine("<br/><b>IMPORTANT NOTES:-</b>")
        .AppendLine("<br/>1) Please get it approved from Sanctioning Authority.")
        .AppendLine("<br/>2) After sanction approval, <b>CONFIRM</b> it again in Vehicle management system. To send E-Mail to transporter.")
        .AppendLine("<br/></td></tr>")
        .AppendLine("</table>")

      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header

        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function

    Public Shared Shadows Function SendEMailSanctionConsumption(ByVal oRE As SIS.VR.vrRequestExecution, ByVal ConsumedPercent As Decimal) As String
      If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then Return ""
      Dim mRet As String = ""
      Dim First As Boolean = True
      Dim Cnt As Integer = 0
      Dim mRecipients As New StringBuilder
      Dim maySend As Boolean = False

      Dim oClient As SmtpClient = New SmtpClient()
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      Dim ad As MailAddress = Nothing
      'From EMail
      If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
        ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
        oMsg.From = ad
        oMsg.CC.Add(ad)
      End If
      'Executers of Linked Executions
      Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
          ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
      Next
      'Requester, Buyer and Executers of Execution
      Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
      For Each vr As SIS.VR.vrVehicleRequest In oVRs
        If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
          ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
          If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
        End If
        'Projects Employees Mapping
        Dim prUsers As List(Of SIS.TPISG.tpisg046) = SIS.TPISG.tpisg046.GetUsersEMailIDs(vr.ProjectID)
        Dim IDsFound As Boolean = False
        For Each pu As SIS.TPISG.tpisg046 In prUsers
          If pu.EMailID.Trim <> "" Then
            IDsFound = True
            ad = New MailAddress(pu.EMailID.Trim, pu.UserName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Next
        If Not IDsFound Then
          Dim GroupID As Integer = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)(0).GroupID
          Select Case GroupID
            Case 1 ' boiler
              oMsg.CC.Add("boilerprojects@isgec.co.in")
            Case 2 'smd
              oMsg.CC.Add("smdprojects@isgec.co.in")
            Case 4 'EPC
              oMsg.CC.Add("epcprojects@isgec.co.in")
            Case 5 'APCE
              oMsg.CC.Add("apceprojects@isgec.co.in")
          End Select
        End If
        'Buyers in Request, in old requests buyer may be null
        Try
          If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Catch ex As Exception
        End Try
        'Executers of the Requester's Group
        Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
        Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
        If vr.OutOfContract Then
          oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
        Else
          oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
        End If
        For Each exe As SIS.VR.vrUserGroup In oExec
          If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
            ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
        Next
      Next
      'Requester, Buyer and Executers of Linked Executions
      For Each le As SIS.VR.vrRequestExecution In oLEs
        If le.SRNNo.ToString = oRE.SRNNo Then Continue For
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
        For Each vr As SIS.VR.vrVehicleRequest In oVRs
          If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
            ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
            If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
          End If
          'Buyers in Request, in old requests buyer may be null
          Try
            If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
              ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Catch ex As Exception
          End Try
          'Executers of the Requester's Group
          Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
          Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
          If vr.OutOfContract Then
            oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
          Else
            oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
          End If
          For Each exe As SIS.VR.vrUserGroup In oExec
            If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
              ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
              If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
            End If
          Next
        Next
      Next
      'E-Mail ID from Sanction Alert Configuration
      Dim oSPC As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(oRE.Project.ProjectID)
      If oSPC IsNot Nothing Then
        If oSPC.EMailIDs <> String.Empty Then
          Dim aIDs() As String = oSPC.EMailIDs.Split(",".ToCharArray)
          For Each id As String In aIDs
            ad = New MailAddress(id)
            Try
              If Not oMsg.To.Contains(ad) Then oMsg.To.Add(ad)
            Catch ex As Exception
            End Try
          Next
        End If
      End If
      oMsg.IsBodyHtml = True
      oMsg.Subject = "Sanction " & ConsumedPercent.ToString("n") & " % Consumed in " & oRE.Project.ProjectID

      Dim sb As New StringBuilder
      With sb
        oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
        .AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
        .AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>" & "SANCTION " & ConsumedPercent.ToString("n") & " % CONSUMED</b></h2></td></tr>")
        'Main Execution
        .AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
        .AppendLine("<td>" & oRE.SRNNo & "</td></tr>")
        .AppendLine("<tr><td><b>Project Name &  Code</b></td>")
        .AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
        .AppendLine("<tr><td><b>Sanction Amount</b></td>")
        .AppendLine("<td>" & (oRE.POValue).ToString("n") & "</td></tr>")
        'Consumed Amount should be picked from Linked Executions, where it is exceeded
        .AppendLine("<tr><td><b>Consumed Sanction</b></td>")
        .AppendLine("<td>" & (oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
        .AppendLine("<tr><td><b>Balance Sanction</b></td>")
        .AppendLine("<td>" & (oRE.POValue - oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
        'End of Linked Executions
        .AppendLine("</table>")

      End With
      Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "table{"

        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 12px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        oMsg.Body = Header

        oClient.Send(oMsg)
      Catch ex As Exception
        mRet = ex.Message
      End Try
      Return mRet
    End Function
    Public Shared Function vrRequestExecutionAllGetSPLoadByIDProjectID(ByVal SPLoadID As String, ProjectID As String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As New List(Of SIS.VR.vrRequestExecution)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_RequestExecutionAllSelectBySPLoadIDProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPLoadID", SqlDbType.NVarChar, 51, SPLoadID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 6, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function vrRequestExecutionAllGetSPLoadByID(ByVal SPLoadID As String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As New List(Of SIS.VR.vrRequestExecution)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_RequestExecutionAllSelectBySPLoadID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPLoadID", SqlDbType.NVarChar, 51, SPLoadID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function vrRequestExecutionGetSPLoadByID(ByVal SPLoadID As String, RequestNo As Integer) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvr_LG_RequestExecutionSelectBySPLoadID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPLoadID", SqlDbType.NVarChar, 51, SPLoadID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestNo", SqlDbType.Int, 11, RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrRequestExecution(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetExecutionNoByLoadID(ByVal SPLoadID As String) As Integer
      Dim Results As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 isnull(SRNNo,0) from VR_RequestExecution where sploadid='" & SPLoadID & "'"
          Con.Open()
          Results = Cmd.ExecuteScalar
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
'Public Shared Function InitiateWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
'  Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
'  Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
'  'Checking of Estimated Amount Entered or NOT is Mandatory is pending
'  '===========Commented====================
'  If Convert.ToBoolean(ConfigurationManager.AppSettings("CheckSanction")) Then
'    If Not Results.SanctionExceededApproved Then
'      If Not Results.SanctionExceeded Then
'        'Check Sanction First
'        Dim SanctionExceeded As Boolean = False
'        Results = SIS.VR.vrRequestExecution.ValidateSanction(SRNNo, "")
'        SIS.VR.vrRequestExecution.UpdateData(Results)
'        If Results.SanctionBalance < 0 Then
'          SanctionExceeded = True
'        Else
'          For Each le As SIS.VR.vrRequestExecution In oLEs
'            le = SIS.VR.vrRequestExecution.ValidateSanction(le.SRNNo, "")
'            SIS.VR.vrRequestExecution.UpdateData(le)
'            If le.SanctionBalance < 0 Then
'              SanctionExceeded = True
'            End If
'          Next
'        End If
'        'If any exceeded found
'        'Assign in all Linked
'        If SanctionExceeded Then
'          Results.SanctionExceeded = True
'          Results.RequestStatusID = 28
'          SIS.VR.vrRequestExecution.UpdateData(Results)
'          For Each le As SIS.VR.vrRequestExecution In oLEs
'            le.SanctionExceeded = True
'            le.RequestStatusID = 28
'            SIS.VR.vrRequestExecution.UpdateData(le)
'          Next
'        End If
'        If SanctionExceeded Then
'          SendEMailSanctionApproval(Results)
'          Return Results
'        End If
'      End If
'    End If
'  End If
'  'Checking Sanction Consumed Percent And Alert
'  Dim ProjectID As String = Results.Project.ProjectID
'  Dim tmpCon As Decimal = 0
'  Try
'    tmpCon = (Results.EstimatedPOBalance / Results.POValue) * 100
'  Catch ex As Exception
'    tmpCon = 100
'  End Try
'  Dim oSPC As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(ProjectID)
'  If oSPC Is Nothing Then
'    oSPC = New SIS.VR.vrSanctionAlert
'    With oSPC
'      .ProjectID = ProjectID
'      .EMailIDs = "shatrughan.sharma@isgec.co.in,randhir@isgec.co.in,girish.belwal@isgec.co.in"
'      SIS.VR.vrSanctionAlert.InsertData(oSPC)
'    End With
'  End If
'  If tmpCon < 60 Then
'  ElseIf tmpCon >= 60 And tmpCon < 70 Then
'    If Not oSPC.At60 Then
'      oSPC.At60 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 70 And tmpCon < 80 Then
'    If Not oSPC.At70 Then
'      oSPC.At70 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 80 And tmpCon < 90 Then
'    If Not oSPC.At80 Then
'      oSPC.At80 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 90 And tmpCon < 95 Then
'    If Not oSPC.At90 Then
'      oSPC.At90 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 95 And tmpCon < 96 Then
'    If Not oSPC.At95 Then
'      oSPC.At95 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 96 And tmpCon < 97 Then
'    If Not oSPC.At96 Then
'      oSPC.At96 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 97 And tmpCon < 98 Then
'    If Not oSPC.At97 Then
'      oSPC.At97 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 98 And tmpCon < 99 Then
'    If Not oSPC.At98 Then
'      oSPC.At98 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  ElseIf tmpCon >= 99 And tmpCon <= 100 Then
'    If Not oSPC.At99 Then
'      oSPC.At99 = True
'      SIS.VR.vrSanctionAlert.UpdateData(oSPC)
'      SendEMailSanctionConsumption(Results, tmpCon)
'    End If
'  End If
'  '' ''End Consumed Alert
'  '=====================
'  'Main Execution
'  Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNo, "")
'  If oVRs.Count > 0 Then
'    Dim ODCFound As Boolean = False
'    For Each oVR As SIS.VR.vrVehicleRequest In oVRs
'      If oVR.OverDimentionConsignement Then
'        ODCFound = True
'      End If
'      oVR.RequestStatus = RequestStates.VehicleArranged
'      SIS.VR.vrVehicleRequest.UpdateData(oVR)
'    Next
'    With Results
'      .RequestStatusID = RequestStates.VehicleArranged
'      .ArrangedBy = HttpContext.Current.Session("LoginID")
'      .ArrangedOn = Now
'      .ODCByRequest = ODCFound
'    End With
'    Results = SIS.VR.vrRequestExecution.UpdateData(Results)
'  End If
'  'Linked Executions
'  For Each le As SIS.VR.vrRequestExecution In oLEs
'    If le.SRNNo.ToString = Results.SRNNo Then Continue For
'    oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
'    If oVRs.Count > 0 Then
'      Dim ODCFound As Boolean = False
'      For Each oVR As SIS.VR.vrVehicleRequest In oVRs
'        If oVR.OverDimentionConsignement Then
'          ODCFound = True
'        End If
'        oVR.RequestStatus = RequestStates.VehicleArranged
'        SIS.VR.vrVehicleRequest.UpdateData(oVR)
'      Next
'      With le
'        .RequestStatusID = RequestStates.VehicleArranged
'        .ArrangedBy = HttpContext.Current.Session("LoginID")
'        .ArrangedOn = Now
'        .ODCByRequest = ODCFound
'      End With
'      le = SIS.VR.vrRequestExecution.UpdateData(le)
'    End If
'  Next
'  SendEMail(Results)
'  Try
'    CloseSPExecution(Results)
'  Catch ex As Exception
'  End Try
'  Return Results
'End Function
