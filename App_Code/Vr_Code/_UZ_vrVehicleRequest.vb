Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Namespace SIS.VR
  Partial Public Class vrVehicleRequest
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If RequestStatus = RequestStates.Returned Then
        mRet = Drawing.Color.Red
      ElseIf RequestStatus >= RequestStates.UnderExecution And RequestStatus < RequestStates.VehicleArranged Then
        mRet = Drawing.Color.DarkOrchid
      ElseIf RequestStatus = RequestStates.VehicleArranged Then
        mRet = Drawing.Color.Green
      End If
      Return mRet
    End Function
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
        '<li><b><u>Material Size</u></b></li>
        If RequestStatus = RequestStates.Returned Then
          mRet = "<li><b><u></u></b></li>" & Me.ReturnRemarks
        ElseIf RequestStatus >= RequestStates.Free Then
          If OverDimentionConsignement Then
            'If ODCReasonID = String.Empty And Remarks = String.Empty Then
            If ODCReasonID = String.Empty Then
              mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>Specify Reason for ODC/Under Utilization</b>"
            Else
              mRet = "<img alt='warning' src='../../images/warning.gif' style='height:14px; width:14px' /><b>ODC/Under Utilization Vehicle Request</b"
            End If
          ElseIf ODCAtSupplierLoading Then
            mRet = "<img alt='warning' src='../../images/warn-blink.gif' style='height:14px; width:14px' /><b>ODC/Under Utilization Vehicle Request</b"
          End If
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If OverDimentionConsignement Then
            'If ODCReasonID = String.Empty And Remarks = String.Empty Then
            If ODCReasonID = String.Empty Then
            Else
              If _RequestStatus = RequestStates.Returned Or _RequestStatus = RequestStates.Free Then
                mRet = True
              End If
            End If
          Else
            If _RequestStatus = RequestStates.Returned Or _RequestStatus = RequestStates.Free Then
              mRet = True
            End If
          End If
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
    Public Shared Function InitiateWF(ByVal RequestNo As Int32) As SIS.VR.vrVehicleRequest
      Dim Results As SIS.VR.vrVehicleRequest = vrVehicleRequestGetByID(RequestNo)
      With Results
        .RequestStatus = RequestStates.UnderExecution
        .RequestedBy = HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .ReturnRemarks = ""
        .ReturnedBy = ""
        .ReturnedOn = ""
      End With
      Results = SIS.VR.vrVehicleRequest.UpdateData(Results)
      SendEMail(Results)
      Try
        CT_VehicleRequested(Results)
      Catch ex As Exception
      End Try
      Return Results
    End Function
    Public Shared Sub CT_VehicleRequested(ByVal rq As SIS.VR.vrVehicleRequest)
      Dim hndl As String = "CT_VEHICLEREQUESTRAISED"
      Dim poElements As ArrayList = SIS.CT.ctPOLChild.GetPOElements(rq.ERPPONumber)
      Dim SrNo As Integer = 0
      For Each Str As String In poElements
        SrNo += 1
        Dim ctH As New SIS.CT.ctHeader
        With ctH
          .t_trdt = rq.RequestedOn
          .t_bohd = hndl
          .t_indv = rq.RequestNo
          .t_srno = SrNo
          .t_proj = rq.ProjectID
          .t_elem = Str
          .t_user = rq.RequestedBy
          .t_stat = ""
        End With
        ctH = SIS.CT.ctHeader.InsertData(ctH)
        Dim DSrn As Integer = 0
        Dim Chlds As ArrayList = SIS.CT.ctPOLChild.GetPODocuments(rq.ERPPONumber)
        If Chlds.Count > 0 Then
          For Each chld As String In Chlds
            DSrn += 1
            Dim ctD As New SIS.CT.ctDetail
            With ctD
              .t_trdt = rq.RequestedOn
              .t_bohd = hndl
              .t_indv = rq.RequestNo
              .t_srno = ctH.t_srno
              .t_dsno = DSrn
              .t_dwno = chld
              .t_elem = Str
              .t_proj = rq.ProjectID
              .t_wght = 0
              .t_pitc = 0
            End With
            ctD = SIS.CT.ctDetail.InsertData(ctD)
          Next
        End If
      Next
    End Sub
    Public Shared Function UZ_vrVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestStatus As Int32) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_VehicleRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_VehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestStatus", SqlDbType.Int, 10, IIf(RequestStatus = Nothing, 0, RequestStatus))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function LG_UpdateODConsignment(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Dim ODC As Boolean = False
      Dim strODC As String = ""
      Dim oVT As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(Record.VehicleTypeID)
      '1. Capacity
      If oVT.DefineCapacity AndAlso oVT.CapacityInKG > 0 Then
        '1.1. Calculate Total Material Weight
        Dim oUnit As SIS.VR.vrUnits = SIS.VR.vrUnits.vrUnitsGetByID(Record.WeightUnit)
        Dim _mw As Decimal = 0
        _mw = Record.MaterialWeight
        If oUnit.ConversionFactor > 0 Then
          _mw = _mw * oUnit.ConversionFactor
        End If
        '=================================================
        'Commented on 27-10-2017, As it was decided that 
        'user will enter gross weight not unit weight
        '=================================================
        '_mw = _mw * Record.NoOfPackages
        '=================================================
        '1.2. Validate Max Capacity
        If oVT.EnforceMaximumCapacity AndAlso oVT.MaximumCapacity > 0 Then
          If _mw > oVT.MaximumCapacity Then
            strODC = "Exceeds Max.Capacity"
            ODC = True
          End If
        End If
        '1.3 Validate Min Capacity
        If oVT.EnforceMinimumCapacity AndAlso oVT.MinimumCapacity > 0 Then
          If _mw < oVT.MinimumCapacity Then
            oUnit = SIS.VR.vrUnits.vrUnitsGetByID(Record.SizeUnit)
            Dim _ml As Decimal = 0
            _ml = Record.Length
            If oUnit.ConversionFactor > 0 Then
              _ml = _ml * oUnit.ConversionFactor
            End If
            If _ml < oVT.MinimumLength Then
              strODC = "Vehicle Under Utilization"
              ODC = True
            End If
            'strODC = "Below Min.Capacity"
            'ODC = True
          End If
        End If
      End If
      '2. Dimension
      If Record.SizeUnit <> String.Empty AndAlso oVT.DefineDimention AndAlso oVT.HeightInFt > 0 AndAlso oVT.WidthInFt > 0 AndAlso oVT.LengthInFt > 0 Then
        '2.1. Calculate Total Material Dimension
        Dim oUnit As SIS.VR.vrUnits = SIS.VR.vrUnits.vrUnitsGetByID(Record.SizeUnit)
        Dim _mh As Decimal = 0
        Dim _mw As Decimal = 0
        Dim _ml As Decimal = 0
        _mh = Record.Height
        _mw = Record.Width
        _ml = Record.Length
        If oUnit.ConversionFactor > 0 Then
          _mh = _mh * oUnit.ConversionFactor
          _mw = _mw * oUnit.ConversionFactor
          _ml = _ml * oUnit.ConversionFactor
        End If
        '2.2 Validate Max. dimension
        If oVT.EnforceMaximumDimention AndAlso oVT.MaximumHeight > 0 AndAlso oVT.MaximumWidth > 0 AndAlso oVT.MaximumLength > 0 Then
          If _mh > oVT.MaximumHeight Or _mw > oVT.MaximumWidth Or _ml > oVT.MaximumLength Then
            strODC = "Exceeds Max.Dim"
            ODC = True
          End If
        End If
        '2.3 Validate Min. dimension
        'If oVT.EnforceMinimumDimention AndAlso oVT.MinimumHeight > 0 AndAlso oVT.MinimumWidth > 0 AndAlso oVT.MinimumLength > 0 Then
        '	If _mh < oVT.MinimumHeight Or _mw < oVT.MinimumWidth Or _ml < oVT.MinimumLength Then
        '		strODC = "Below Min.Dim"
        '		ODC = True
        '	End If
        'End If
      End If
      With Record
        If ODC Then
          .MaterialSize = strODC
          .OverDimentionConsignement = True
        Else
          .MaterialSize = "H: " & .Height.ToString.Trim & " W: " & .Width.ToString.Trim & " L: " & .Length.ToString.Trim & " Wt: " & .MaterialWeight.ToString.Trim
          .OverDimentionConsignement = False
        End If
      End With
      Record = SIS.VR.vrVehicleRequest.UpdateData(Record)
      Return Record
    End Function
    Public Shared Function UZ_vrVehicleRequestInsert(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Dim _Result As SIS.VR.vrVehicleRequest = vrVehicleRequestInsert(Record)
      Return LG_UpdateODConsignment(_Result)
    End Function
    Public Shared Function UZ_vrVehicleRequestUpdate(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Dim _Result As SIS.VR.vrVehicleRequest = vrVehicleRequestUpdate(Record)
      Return LG_UpdateODConsignment(_Result)
    End Function
    Public Shared Function UZ_vrVehicleRequestDelete(ByVal Record As SIS.VR.vrVehicleRequest) As Integer
      Dim _Result As Integer = vrVehicleRequestDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrVehicleRequestGetByID(ByVal RequestNo As Int32) As SIS.VR.vrVehicleRequest
      Dim Results As SIS.VR.vrVehicleRequest = vrVehicleRequestGetByID(RequestNo)
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function UZ_vrVehicleRequestGetByID(ByVal RequestNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_RequestStatus As Int32) As SIS.VR.vrVehicleRequest
      Return UZ_vrVehicleRequestGetByID(RequestNo)
    End Function
    Public Shared Function SendEMail(ByVal oRq As SIS.VR.vrVehicleRequest) As String
      Dim oAD As MailAddress = Nothing
      Dim mRet As String = ""
      'Get Requester
      Dim oEmp As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(oRq.RequestedBy)
      Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(oRq.RequestedBy)
      'Get TO Executers
      Dim oExec As List(Of SIS.VR.vrUserGroup)
      If oRq.OutOfContract Then
        oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
      Else
        oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
      End If
      If oEmp.EMailID <> String.Empty And oExec.Count > 0 Then
        Try
          Dim oClient As SmtpClient = New SmtpClient()

          Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
          With oMsg
            .From = New MailAddress(oEmp.EMailID, oEmp.UserFullName)
            For Each _ex As SIS.VR.vrUserGroup In oExec
              Try
                oAD = New MailAddress(_ex.FK_VR_UserGroup_UserID.EMailID, _ex.FK_VR_UserGroup_UserID.UserFullName)
                If Not .To.Contains(oAD) Then
                  .To.Add(oAD)
                End If
              Catch ex As Exception
              End Try
            Next
            Try
              .CC.Add(New MailAddress(oRq.FK_VR_VehicleRequest_BuyerInERP.EMailID, oRq.FK_VR_VehicleRequest_BuyerInERP.UserFullName))
            Catch ex As Exception
            End Try
            Try
              .CC.Add(New MailAddress(oEmp.EMailID, oEmp.UserFullName))
            Catch ex As Exception
            End Try
            .IsBodyHtml = True
            .Subject = "Vehicle Required On: " & oRq.VehicleRequiredOn & " @ Vendor: " & oRq.IDM_Vendors5_Description & " Project: " & oRq.IDM_Projects4_Description
            Dim sb As New StringBuilder
            With sb
              .AppendLine("<br/>You are requested to arrange the vehicle as per following details.")
              .AppendLine("<br/><br/> ")
              .AppendLine("<br/><b>Request No: </b>" & oRq.RequestNo)
              .AppendLine("<br/><b>Supplier: </b>" & oRq.IDM_Vendors5_Description)
              .AppendLine("<br/>         " & oRq.SupplierLocation)
              .AppendLine("<br/><b>Project: </b>[" & oRq.ProjectID & "] " & oRq.IDM_Projects4_Description)
              .AppendLine("<br/><b>Delivery at: </b>" & oRq.DeliveryLocation)
              .AppendLine("<br/><br/> ")
              .AppendLine("<br/><b>Vehicle Type: </b>" & IIf(oRq.VR_VehicleTypes9_cmba = String.Empty, "***NOT SPECIFIED***", oRq.VR_VehicleTypes9_cmba))
              .AppendLine("<br/><b>Item Description: </b>" & oRq.ItemDescription)
            End With
            .Body = sb.ToString
            'Dim oAtchs As List(Of SIS.QCM.qcmRequestFiles) = SIS.QCM.qcmRequestFiles.qcmRequestFilesSelectList(0, 99, "", False, "", oRq.RequestID)
            'For Each atch As SIS.QCM.qcmRequestFiles In oAtchs
            '  IO.File.Copy(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("RequestDir")) & "/" & atch.DiskFIleName, HttpContext.Current.Server.MapPath("~/App_Data/" & atch.FileName), True)
            '  .Attachments.Add(New System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath("~/App_Data/" & atch.FileName)))
            'Next
          End With
          oClient.Send(oMsg)
        Catch ex As Exception
          mRet = ex.Message
        End Try
      End If
      Return mRet
    End Function
  End Class
  Public Class vrERPPo
    Public ERPPoNumber As String = ""
    Public SupplierID As String = ""
    Public SupplierName As String = ""
    Public SupplierAddress As String = ""
    Public BuyerID As String = ""
    Public BuyerName As String = ""
    Public BuyerEMailID As String = ""
    Public Shared Function vrERPPoGetByID(ByVal PONumber As String) As SIS.VR.vrERPPo
      Dim mSql As String = ""
      Dim mComp As String = "200"
      If PONumber.StartsWith("P701") Then
        mComp = "700"
      End If
      mSql = mSql & "select distinct "
      mSql = mSql & "ordh.t_orno as ERPPoNumber,"
      mSql = mSql & "ordh.t_otbp as SupplierID,"
      mSql = mSql & "ordh.t_ccon as BuyerID,    "
      mSql = mSql & "'' as SupplierAddress,    "
      mSql = mSql & "emp3.t_nama as BuyerName,"
      mSql = mSql & "bpe3.t_mail as BuyerEMailID, "
      mSql = mSql & "bp01.t_nama as SupplierName "
      mSql = mSql & "from ttdpur400" & mComp & " as ordh "
      mSql = mSql & "left outer join ttccom001" & mComp & " as emp3 on ordh.t_ccon=emp3.t_emno "
      mSql = mSql & "left outer join tbpmdm001" & mComp & " as bpe3 on ordh.t_ccon=bpe3.t_emno "
      mSql = mSql & "left outer join ttccom100" & mComp & " as bp01 on ordh.t_otbp=bp01.t_bpid "
      mSql = mSql & "where ordh.t_orno = '" & PONumber & "'"
      Dim Results As SIS.VR.vrERPPo = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New SIS.VR.vrERPPo(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Sub New(ByVal Reader As SqlDataReader)
      If Convert.IsDBNull(Reader("ERPPoNumber")) Then ERPPoNumber = String.Empty Else ERPPoNumber = CType(Reader("ERPPoNumber"), String)
      If Convert.IsDBNull(Reader("SupplierID")) Then SupplierID = String.Empty Else SupplierID = CType(Reader("SupplierID"), String)
      If Convert.IsDBNull(Reader("SupplierName")) Then SupplierName = String.Empty Else SupplierName = CType(Reader("SupplierName"), String)
      If Convert.IsDBNull(Reader("SupplierAddress")) Then SupplierAddress = String.Empty Else SupplierAddress = CType(Reader("SupplierAddress"), String)
      If Convert.IsDBNull(Reader("BuyerID")) Then
        BuyerID = String.Empty
      Else
        Dim X As String = Reader("BuyerID")
        If X.Length > 4 Then
          BuyerID = X
        Else
          BuyerID = Right("0000" & X, 4)
        End If
      End If
      If Convert.IsDBNull(Reader("BuyerName")) Then BuyerName = String.Empty Else BuyerName = CType(Reader("BuyerName"), String)
      If Convert.IsDBNull(Reader("BuyerEMailID")) Then BuyerEMailID = String.Empty Else BuyerEMailID = CType(Reader("BuyerEMailID"), String)
    End Sub
    Sub New()
      'dummy
    End Sub
  End Class
End Namespace
