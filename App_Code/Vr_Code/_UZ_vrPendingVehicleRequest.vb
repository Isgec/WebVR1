Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Imports System.Web.Script.Serialization
Namespace SIS.VR
  Partial Public Class vrPendingVehicleRequest
    Public Shadows ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Return GetColor()
      End Get
    End Property
    Public Shadows Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Return mRet
    End Function
    Public ReadOnly Property EnableInput() As Boolean
      Get
        Dim mRet As Boolean = False
        If RequestStatus = RequestStates.UnderExecution Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Me.RequestStatus = RequestStates.RequestLinked Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
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
          If Me.RequestStatus = RequestStates.UnderExecution Or Me.RequestStatus = RequestStates.RequestLinked Then
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
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Me.RequestStatus = RequestStates.UnderExecution And SPStatus = enumSPStatus.Free Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ShowSPEdiMessage() As String
      Get
        Dim mRet As String = ""
        If SPEdiStatus = enumSPEdiStatus.SPError Then
          mRet = "<img alt='warning' src='../../images/warning.gif' style='height:12px; width:12px' /><i>" & SPEdiMessage & "</i>"
        End If
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SPRequestVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Me.RequestStatus = RequestStates.UnderExecution And SPStatus = enumSPStatus.Free Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SPReqIDVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case SPStatus
            Case enumSPStatus.SPRequestCreated, enumSPStatus.UnderSPExecutionCreation, enumSPStatus.SPExecutionCreated
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SPExecutionVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If SPStatus = enumSPStatus.SPRequestCreated Or SPStatus = enumSPStatus.SPExecutionCreated Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CreateTestSPRequest(RequestNo As Int32) As String
      Dim SPR As SPApi.SPRequest = GetSPR(Nothing, True)
      Dim mRet As Boolean = True
      Dim jsonStr As String = New JavaScriptSerializer().Serialize(SPR)
      Dim SPEdiMessage As String = jsonStr
      Dim tmp As SPApi.SPResponse = Nothing
      Dim tmpStr As String = ""
      tmp = SPApi.CreateSPRequest(SPR)
      tmpStr = New JavaScriptSerializer().Serialize(tmp)
      Return jsonStr & "<br/>" & tmpStr
    End Function
    Public Shared Function GetSPExecution(RequestNo As Int32, ByRef SPLoadData As String) As String
      Dim Results As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
      With Results
        '.SPStatus = enumSPStatus.UnderSPExecutionCreation
        .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
        .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        .SPEdiStatus = enumSPEdiStatus.Free
        .SPEdiMessage = ""
      End With
      Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      Dim tmp As SPApi.SPExecution = SPApi.GetSPExecution(Results.SPRequestID, SPLoadData)

      If tmp.IsError Then
        With Results
          .SPStatus = enumSPStatus.SPRequestCreated
          .SPEdiStatus = enumSPEdiStatus.SPError
          .SPEdiMessage = tmp.Message
          .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
          .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        End With
        Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      Else
        With Results
          .SPStatus = enumSPStatus.SPExecutionCreated
          .SPEdiStatus = enumSPEdiStatus.SPDone
          .SPEdiMessage = ""
          .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
          .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
          .SPLoadData = SPLoadData
        End With
        Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      End If

      If Not tmp.IsError Then
        For Each x As SPApi.ExecutionData In tmp.resultSet
          '1. Create Execution
          'Update Data Not Available in Load Data
          With x
            .RequestNo = Results.RequestNo
            .BPID = Results.SupplierID
            .Size = "Cargo L:" & Results.Length & ", W:" & Results.Width & ", H:" & Results.Height
            .VehicleTypeDescription = Results.FK_VR_VehicleRequest_VehicleTypeID.cmba
            .GeneratePO = 2 'YES
          End With
          'check already created execution to update
          Dim Found As Boolean = True
          Dim re As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetSPLoadByID(x.loadId)
          If re Is Nothing Then
            Found = False
            re = New SIS.VR.vrRequestExecution
          End If
          With re
            .VehicleTypeID = x.vehicleType
            .TransporterID = x.transporterCode
            .VehiclePlacedOn = x.loadingDate
            .ExecutionDescription = Results.ProjectID & "/"
            '.VehicleNo = ""
            '.EstimatedDistance = 0
            '.EstimatedRatePerKM = 0
            .EstimatedAmount = x.totalAmount
            .Remarks = "System created"
            '===============================
            .ArrangedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
            .ArrangedOn = Now.ToString("dd/MM/yyyy HH:mm")
            .RequestStatusID = 4
            '====================
            .RequestNo = Results.RequestNo
            .SPRequestID = Results.SPRequestID
            .SPLoadID = x.loadId
            .SPExecutionStatus = enumSPExecutionStatus.Free
          End With
          If Found Then
            re = SIS.VR.vrRequestExecution.UpdateData(re)
          Else
            re = SIS.VR.vrRequestExecution.InsertData(re)
          End If
          'Link Vehicle request with execution
          SIS.VR.vrUnLinkedRequest.CompleteWF(Results.RequestNo, re.SRNNo)
          'Push in ERP for PO
          Try
            SIS.VR.vrPendingVehicleRequest.PushPOData(x, "200")
          Catch ex As Exception
            Dim xx As String = ""
          End Try
        Next
      End If
      Return SPLoadData
    End Function

    Public Shared Function CreateSPRequest(RequestNo As Int32) As String
      Dim Results As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
      With Results
        '.SPStatus = enumSPStatus.UnderSPRequestCreation
        .SPRequestCreatedBy = HttpContext.Current.Session("LoginID")
        .SPRequestCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        .SPEdiStatus = enumSPEdiStatus.Free
        .SPEdiMessage = ""
      End With
      Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      Dim SPR As SPApi.SPRequest = GetSPR(Results)
      Dim mRet As Boolean = True
      Dim jsonStr As String = New JavaScriptSerializer().Serialize(SPR)
      Results.SPEdiMessage = jsonStr
      Dim tmp As SPApi.SPResponse = SPApi.CreateSPRequest(SPR)

      If tmp.IsError Then
        With Results
          .SPStatus = enumSPStatus.Free
          .SPEdiStatus = enumSPEdiStatus.SPError
          .SPEdiMessage = tmp.Message
          .SPRequestCreatedBy = HttpContext.Current.Session("LoginID")
          .SPRequestCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        End With
        Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      Else
        If SIS.VR.vrVehicleRequest.SPRequestIDExists(tmp.ReqId) Then
          With Results
            .SPStatus = enumSPStatus.Free
            .SPEdiStatus = enumSPEdiStatus.SPError
            .SPEdiMessage = "SP Request ID already exists. CANNOT Insert Duplicate Key."
            .SPRequestID = ""
            .SPRequestCreatedBy = HttpContext.Current.Session("LoginID")
            .SPRequestCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
            .SPLoadData = jsonStr
          End With
          Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
          Throw New Exception(Results.SPEdiMessage)
        Else
          With Results
            .SPStatus = enumSPStatus.SPRequestCreated
            .SPEdiStatus = enumSPEdiStatus.SPDone
            .SPEdiMessage = ""
            .SPRequestID = tmp.ReqId
            .SPRequestCreatedBy = HttpContext.Current.Session("LoginID")
            .SPRequestCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
          End With
          Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
        End If
      End If
      Return jsonStr
    End Function
    Private Shared Function GetSPR(r As SIS.VR.vrVehicleRequest, Optional Test As Boolean = False) As SPApi.SPRequest
      Dim t As New SPApi.SPRequest
      If Not Test Then
        With t
          .RFQ = r.RequestNo
          .loadingDate = Convert.ToDateTime(r.VehicleRequiredOn).ToString("dd-MM-yyyy")
          .projectCode = r.ProjectID
          .projectName = r.IDM_Projects4_Description
          .vehicleType = r.VehicleTypeID
          .supplierCode = r.SupplierID
          .supplierName = r.FK_VR_VehicleRequest_SupplierID.Description
          .supplierLoadingPoint = r.FromLocation
          .deliveryUnloadingPoint = r.ToLocation
          .loadingPoint = r.SupplierLocation
          .unloadingPoint = r.DeliveryLocation
          .noOfVehicles = 1
          .product = r.ItemDescription
          .length = r.Length
          .breadth = r.Width
          .height = r.Height
          .notes = r.Remarks
          .branchCode = "EU200"
          .deliveryCode = "NONE"
          .materialWt = r.MaterialWeight
          .projectLocation = r.ToLocation
          .uom = r.VR_Units2_Description
          .loadingPointPincode = r.FromPinCode
          .unloadingPointPincode = r.ToPinCode
        End With
      Else
        With t
          .RFQ = "LG" & GetNextID()
          .loadingDate = "20-03-2020"
          .projectCode = "ABD18"
          .projectName = "Test Project"
          .vehicleType = "Daala Body"
          .supplierCode = "ERTY"
          .supplierName = "Test Supplier Name"
          .supplierLoadingPoint = "Supplier Loading Point Address"
          .deliveryUnloadingPoint = "Delivery Point Address"
          .loadingPoint = "Kolkata"
          .unloadingPoint = "Dhanbad"
          .noOfVehicles = 1
          .product = "Fuel"
          .length = 20
          .breadth = 10
          .height = 10
          .notes = ""
          .branchCode = "drew"
          .deliveryCode = "SSFF"
          .materialWt = 2000
          .projectLocation = "howrah"
          .uom = "MT"
        End With
      End If
      Return t
    End Function
    Public Shared Function GetNextID() As String
      Dim mRet As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim mSql As String = ""
        mSql &= " Update VR_TestSeries set id=id+1 "
        mSql &= " Select top 1 isnull(id,0) as FileName from vr_testSeries"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = mSql
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet.Trim
    End Function
    Public Shared Function PushPOData(ed As SPApi.ExecutionData, Optional Comp As String = "200") As Boolean
      Dim mRet As Boolean = False
      Dim tmpPO As SPApi.POData = SPApi.POData.GetByID(ed.loadId)
      Dim Found As Boolean = False
      If tmpPO IsNot Nothing Then Found = True
      If Found Then
        SPApi.POData.UpdateData(ed, Comp)
      Else
        SPApi.POData.InsertData(ed, Comp)
      End If
      Return mRet
    End Function

    Public Shared Function RejectWF(ByVal RequestNo As Int32, ByVal ReturnRemarks As String) As SIS.VR.vrPendingVehicleRequest
      Dim Results As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
      With Results
        .RequestStatus = RequestStates.Returned
        .ReturnRemarks = ReturnRemarks
        .ReturnedBy = HttpContext.Current.Session("LoginID")
        .ReturnedOn = Now
        'To Delete
        'If .SRNNo <> String.Empty Then
        '  Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(.SRNNo)
        '  With oRE
        '    .RequestStatusID = RequestStates.UnderExecution
        '    .ArrangedBy = HttpContext.Current.Session("LoginID")
        '    .ArrangedOn = Now
        '  End With
        '  SIS.VR.vrRequestExecution.UpdateData(oRE)
        '  .SRNNo = ""
        'End If
        'End to delete
      End With
      Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      SendEMail(Results)
      Return Results
    End Function
    Public Shared Function UZ_vrPendingVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestedBy As String) As List(Of SIS.VR.vrPendingVehicleRequest)
      Dim Results As List(Of SIS.VR.vrPendingVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_PendingVehicleRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_PendingVehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy", SqlDbType.NVarChar, 8, IIf(RequestedBy Is Nothing, String.Empty, RequestedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus", SqlDbType.Int, 10, RequestStates.UnderExecution)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrPendingVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPendingVehicleRequest(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrPendingVehicleRequestUpdate(ByVal Record As SIS.VR.vrPendingVehicleRequest) As SIS.VR.vrPendingVehicleRequest
      Dim _Result As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestUpdate(Record)
      Return _Result
    End Function
    Public Shared Shadows Function SendEMail(ByVal oRq As SIS.VR.vrPendingVehicleRequest) As String
      Dim mRet As String = ""
      'Get Requester
      Dim oEmp As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(oRq.ReturnedBy)
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
            Try
              .From = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
              .To.Add(New MailAddress(oRq.FK_VR_VehicleRequest_RequestedBy.EMailID, oRq.FK_VR_VehicleRequest_RequestedBy.UserFullName))
            Catch ex As Exception
            End Try
            For Each _ug As SIS.VR.vrUserGroup In oExec
              Try
                Dim oAD As MailAddress = New MailAddress(_ug.FK_VR_UserGroup_UserID.EMailID, _ug.FK_VR_UserGroup_UserID.UserFullName)
                If Not .CC.Contains(oAD) Then
                  .CC.Add(oAD)
                End If
              Catch ex As Exception

              End Try
            Next
            .IsBodyHtml = True
            .Subject = "Returned: Vehicle Required On: " & oRq.VehicleRequiredOn & " @ Vendor: " & oRq.IDM_Vendors5_Description & " Project: " & oRq.IDM_Projects4_Description
            Dim sb As New StringBuilder
            With sb
              .AppendLine("<br/><b>Request is returned with following reason.</b>")
              .AppendLine("<br/>" & oRq.ReturnRemarks)
              .AppendLine("<br/>-------------------------------------------------------")
              .AppendLine("<br/>You are requested to arrange the vehicle as per following details.")
              .AppendLine("<br/><br/> ")
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
End Namespace
