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
      Select Case RequestStatus
        Case RequestStates.Free
          mRet = Drawing.Color.Black
        Case RequestStates.Returned
          mRet = Drawing.Color.Red
        Case RequestStates.VehicleArranged, RequestStates.VehiclePlaced
          mRet = Drawing.Color.Green
        Case RequestStates.RequestLinked
          mRet = Drawing.Color.DarkGoldenrod
        Case Else
          mRet = Drawing.Color.DarkOrchid
      End Select
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
        If RequestStatus = RequestStates.Returned Then
          mRet = "<li><b><u></u></b></li>" & Me.ReturnRemarks
        ElseIf RequestStatus >= RequestStates.Free Then
          If OverDimentionConsignement Then
            If ODCReasonID = String.Empty Then
              mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>Specify Reason for ODC/Under Utilization</b>"
            Else
              mRet = "<img alt='warning' src='../../images/warning.gif' style='height:14px; width:14px' /><b>ODC/Under Utilization Vehicle Request</b"
            End If
          ElseIf ODCAtSupplierLoading Then
            mRet = "<img alt='warning' src='../../images/warn-blink.gif' style='height:14px; width:14px' /><b>ODC/Under Utilization Vehicle Request</b"
          ElseIf RequestDescription = "" OrElse SupplierLocation = "" OrElse DeliveryLocation = "" OrElse FromLocation = "" OrElse ToLocation = "" OrElse ItemDescription = "" OrElse VehicleRequiredOn = "" OrElse VehicleTypeID = "" Then
            mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>Incomplete Vehicle Request.</b>"
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
          If _ProjectID = "" Or _SupplierID = "" Or _VehicleTypeID = "" Then
            mRet = False
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
        If .RequestDescription = "" OrElse .SupplierLocation = "" OrElse .DeliveryLocation = "" OrElse .FromLocation = "" OrElse .ToLocation = "" OrElse .ItemDescription = "" OrElse .VehicleRequiredOn = "" OrElse .VehicleTypeID = "" Then
          Throw New Exception("Incomplete Vehicle Request, Can Not Forward.")
        End If
      End With
      'Check Progress Percent
      Dim NoProgress As Boolean = True
      Dim POIrefs As List(Of SIS.VR.vrctVehicleRequest) = SIS.VR.vrctVehicleRequest.vrctVehicleRequestSelectList(0, 999, "", False, "", Results.RequestNo)
      For Each iref As SIS.VR.vrctVehicleRequest In POIrefs
        If Convert.ToDecimal(iref.ProgressPercent) > 0 Or Convert.ToDecimal(iref.ProgressWeight) > 0 Then
          NoProgress = False
          Exit For
        End If
      Next
      If POIrefs.Count > 0 Then
        If NoProgress Then
          Throw New Exception("Can not forward, Please enter Progress Percent.")
        End If
      End If
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
        SIS.CT.ctUpdates.CT_ManualVRRequest(Results)
      Catch ex As Exception
        Throw New Exception(ex.Message)
      End Try
      Return Results
    End Function
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
      Record = vrVehicleRequestInsert(Record)
      Record = LG_UpdateODConsignment(Record)
      CreateItemReference(Record)
      Return Record
    End Function
    Public Shared Sub CreateItemReference(ByVal Record As SIS.VR.vrVehicleRequest)
      Dim tmpCTs As List(Of SIS.VR.vrctVehicleRequest) = SIS.VR.vrctVehicleRequest.GetERPItemReference(Record.ProjectID, Record.ERPPONumber, "CT_VEHICLEREQUESTRAISED")
      Dim cnt As Integer = 0
      For Each tmp As SIS.VR.vrctVehicleRequest In tmpCTs
        cnt += 1
        With tmp
          .VRRequestNo = Record.RequestNo
          .SerialNo = cnt
          .Project = Record.ProjectID
          .PONumber = Record.ERPPONumber
          .Handle = "CT_VEHICLEREQUESTRAISED"
          .PartialOrFull = "PARTIAL"
          .ProgressWeight = 0.0000
          .ProgressPercent = 0.0000
          .GridLineStatus = 0
        End With
        tmp = SIS.VR.vrctVehicleRequest.InsertData(tmp)
      Next
    End Sub

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
      If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then Return ""
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
            If oEmp.EMailID.ToLower.IndexOf("isgec.com") >= 0 Then
              .CC.Add(New MailAddress("sarvjeet_chowdhry@isgec.com", "Sarvjeet Chowdhry"))
            End If
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
    Public Property ERPPoNumber As String = ""
    Public Property SupplierID As String = ""
    Public Property SupplierName As String = ""
    Public Property SupplierAddress As String = ""
    Public Property ProjectAddress As String = ""
    Private _BuyerID As String = ""
    Public Property BuyerID As String
      Get
        Return _BuyerID
      End Get
      Set(value As String)
        If value.Length > 4 Then
          _BuyerID = value
        Else
          _BuyerID = Right("0000" & value, 4)
        End If

      End Set
    End Property
    Public Property BuyerName As String = ""
    Public Property BuyerEMailID As String = ""
    Public Property DeliveryTerm As String = ""
    Public Property ProjectType As String = ""
    Public Property ProjectID As String = ""
    Public Property ProjectName As String = ""
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
      mSql = mSql & "ordh.t_cdec as DeliveryTerm,    "
      mSql = mSql & " lpo.t_cprj as ProjectID,"
      mSql = mSql & "  (select top 1 (case when xx.t_bptc='IN' then 'Domestic' else 'Export' end) as tmp from ttppdm740" & mComp & " as xx where xx.t_cprj = lpo.t_cprj ) As ProjectType,"
      mSql = mSql & "emp3.t_nama as BuyerName,"
      mSql = mSql & "bpe3.t_mail as BuyerEMailID, "
      mSql = mSql & "bp01.t_nama as SupplierName "
      mSql = mSql & "from ttdpur400" & mComp & " as ordh "
      mSql = mSql & "  cross apply (select top 1 tmp.t_cprj from ttdpur401" & mComp & " tmp where tmp.t_orno=ordh.t_orno   "
      mSql = mSql & "              ) lpo "
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
      If Results IsNot Nothing Then
        If Results.BuyerID.Length < 4 Then Results.BuyerID = Results.BuyerID.PadLeft(4, "0")
        Dim tmpSupplierID As String = Results.SupplierID
        'If mComp <> "200" Then Results.SupplierID = "S" & mComp & Right(Results.SupplierID, 5)
        If mComp <> "200" Then Results.SupplierID = "" & mComp & Right(Results.SupplierID, 6)
        Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(Results.SupplierID)
        If oVar Is Nothing Then oVar = SIS.QCM.qcmVendors.GetBPFromERP(tmpSupplierID, mComp)
        Results.SupplierAddress = oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
        Dim oPVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(Results.ProjectID)
        If oPVar Is Nothing Then oPVar = SIS.QCM.qcmProjects.GetProjectFromERP(Results.ProjectID, mComp)
        Results.ProjectName = oPVar.Description
        Results.ProjectAddress = oPVar.Address1.Trim & " " & oPVar.Address2 & " " & oPVar.Address3 & " " & oPVar.Address4
      End If
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub

    'Sub New(ByVal Reader As SqlDataReader)
    '  If Convert.IsDBNull(Reader("ERPPoNumber")) Then ERPPoNumber = String.Empty Else ERPPoNumber = CType(Reader("ERPPoNumber"), String)
    '  If Convert.IsDBNull(Reader("SupplierID")) Then SupplierID = String.Empty Else SupplierID = CType(Reader("SupplierID"), String)
    '  If Convert.IsDBNull(Reader("SupplierName")) Then SupplierName = String.Empty Else SupplierName = CType(Reader("SupplierName"), String)
    '  If Convert.IsDBNull(Reader("SupplierAddress")) Then SupplierAddress = String.Empty Else SupplierAddress = CType(Reader("SupplierAddress"), String)
    '  If Convert.IsDBNull(Reader("BuyerID")) Then
    '    BuyerID = String.Empty
    '  Else
    '    Dim X As String = Reader("BuyerID")
    '    If X.Length > 4 Then
    '      BuyerID = X
    '    Else
    '      BuyerID = Right("0000" & X, 4)
    '    End If
    '  End If
    '  If Convert.IsDBNull(Reader("BuyerName")) Then BuyerName = String.Empty Else BuyerName = CType(Reader("BuyerName"), String)
    '  If Convert.IsDBNull(Reader("BuyerEMailID")) Then BuyerEMailID = String.Empty Else BuyerEMailID = CType(Reader("BuyerEMailID"), String)
    'End Sub
    Sub New()
      'dummy
    End Sub
  End Class
End Namespace
