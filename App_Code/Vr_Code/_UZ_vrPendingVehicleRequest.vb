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
          If Me.RequestStatus = RequestStates.UnderExecution And (SPStatus = enumSPStatus.Free Or SPStatus = enumSPStatus.SPRequestCreated) Then
            'If Me.RequestStatus = RequestStates.UnderExecution And (SPStatus = enumSPStatus.Free) Then
            mRet = True
            'Else
            '  Dim Login As String = HttpContext.Current.Session("LoginID")
            '  If Login = "0340" Or Login = "9866" Then
            '    mRet = True
            '  End If
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
      'Set Flag that Process is started
      With Results
        '.SPStatus = enumSPStatus.UnderSPExecutionCreation
        .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
        .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        .SPEdiStatus = enumSPEdiStatus.Free
        .SPEdiMessage = ""
      End With
      Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      Dim tmp As SPApi.SPExecution = SPApi.GetSPExecution(Results.SPRequestID, SPLoadData)
      'It is insured that tmp will NOT Nothing
      'We have to check only error flag
      If tmp.IsError Then
        'Re set Flag that Process is finished with error
        With Results
          .SPStatus = enumSPStatus.SPRequestCreated
          .SPEdiStatus = enumSPEdiStatus.SPError
          .SPEdiMessage = tmp.Message
          .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
          .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
        End With
        Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      End If
      'Various updates when process is finished with success
      If Not tmp.IsError Then
        '1. Reset Flag
        With Results
          .SPStatus = enumSPStatus.SPExecutionCreated
          .SPEdiStatus = enumSPEdiStatus.SPDone
          .SPEdiMessage = ""
          .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
          .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
          .SPLoadData = SPLoadData
        End With
        Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
        'NOTE: It was supposed that execution Data of all clubbed Requests are returned in Array
        '      But it returns only one Object in Array i.e. Only Requested Data NOT including All Clubbed
        '      Though code is written to handle all
        For Each x As SPApi.ExecutionData In tmp.resultSet
          '2. Update required Data Not Available in Load Data from Vehicle Request
          With x
            .RequestNo = Results.RequestNo
            .BPID = Results.SupplierID
            .Size = "Cargo L:" & Results.Length & ", W:" & Results.Width & ", H:" & Results.Height
            .VehicleTypeDescription = Results.FK_VR_VehicleRequest_VehicleTypeID.cmba
            .wuom = Results.FK_VR_VehicleRequest_WeightUnit.Description
            .GeneratePO = 2 'NO
          End With
          '2. Create/Update Execution
          '   Insure if Execution Is NOT Created From Load Data 
          '   If Requests are clubbed LoadID will be same, but RequestID/SPRequestID will be different 
          '   We Have to create separate execution for each Request
          Dim Found As Boolean = True
          Dim re As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetSPLoadByID(x.loadId, x.RequestNo)
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
            .RequestStatusID = RequestStates.UnderExecution
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
          '3. Link Vehicle request with execution
          '   CompleteWF handles UPD/INS
          SIS.VR.vrUnLinkedRequest.CompleteWF(Results.RequestNo, re.SRNNo)
          '4. Push in ERP for PO
          '   Does Not Hadles Clubbed Requests in SP
          Try
            'PushData Handles UPD/INS
            SIS.VR.vrPendingVehicleRequest.PushPOData(x)
          Catch ex As Exception
            Dim xx As String = ""
          End Try
        Next
      End If
      Return SPLoadData
    End Function
    Public Shared Function PushPOData(ed As SPApi.ExecutionData) As Boolean
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim mRet As Boolean = False
      Dim tmpPO As SPApi.POData = SPApi.POData.GetByID(ed.loadId, Comp)
      Dim Found As Boolean = False
      If tmpPO IsNot Nothing Then Found = True
      If Found Then
        SPApi.POData.UpdateData(ed, Comp)
      Else
        SPApi.POData.InsertData(ed, Comp)
      End If
      Return mRet
    End Function
#Region " After Testing with SP "
    Public Shared Function NewGetSPExecution(RequestNo As Int32) As String
      Dim spJSON As String = ""
      '1. Get SP Execution to Know Clubbed Requests
      Dim rq As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
      Dim sp As SPApi.SPExecution = SPApi.GetSPExecution(rq.SPRequestID, spJSON)
      If sp.IsError Then
        Throw New Exception(sp.Message)
      End If
      Dim cvReq As New List(Of SIS.VR.vrPendingVehicleRequest)
      '2. DownLoad Execution for each Clubbed Request and Update Request Data
      For Each rqno As String In sp.ClubbedRequests
        Dim vReq As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(rqno)
        If vReq.SPEdiStatus <> enumSPEdiStatus.SPDone Then
          'Set Flag that Process is started
          With vReq
            '.SPStatus = enumSPStatus.UnderSPExecutionCreation
            .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
            .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
            .SPEdiStatus = enumSPEdiStatus.Free
            .SPEdiMessage = ""
          End With
          spJSON = ""
          vReq = SIS.VR.vrPendingVehicleRequest.UpdateData(vReq)
          Dim spExe As SPApi.SPExecution = SPApi.GetSPExecution(vReq.SPRequestID, spJSON)
          'It is insured that spExe will NOT Nothing, We have to check only error flag
          If spExe.IsError Then
            'Set Flag that Process is finished with error
            With vReq
              .SPStatus = enumSPStatus.SPRequestCreated
              .SPEdiStatus = enumSPEdiStatus.SPError
              .SPEdiMessage = spExe.Message
              .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
              .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
            End With
            vReq = SIS.VR.vrPendingVehicleRequest.UpdateData(vReq)
            Throw New Exception(spExe.Message)
          End If
          If Not spExe.IsError Then
            'Reset Flag
            With vReq
              .SPStatus = enumSPStatus.SPExecutionCreated
              .SPEdiStatus = enumSPEdiStatus.SPDone
              .SPEdiMessage = ""
              .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
              .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
              .SPLoadData = spJSON
            End With
            vReq = SIS.VR.vrPendingVehicleRequest.UpdateData(vReq)
            cvReq.Add(vReq)
          End If
        Else
          cvReq.Add(vReq)
        End If
      Next
      '3. Create Separate Vehicle Execution from each spExecution
      For Each vReq As SIS.VR.vrPendingVehicleRequest In cvReq
        Dim spExe As SPApi.SPExecution = New JavaScriptSerializer().Deserialize(vReq.SPLoadData, GetType(SPApi.SPExecution))
        Dim x As SPApi.ExecutionData = spExe.resultSet(0)
        Dim Found As Boolean = True
        Dim re As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetSPLoadByID(x.loadId, vReq.RequestNo)
        If re Is Nothing Then
          Found = False
          re = New SIS.VR.vrRequestExecution
          re.RequestStatusID = RequestStates.UnderExecution
        End If
        '2. Update required Data Not Available in Load Data from Vehicle Request
        With x
          .RequestNo = vReq.RequestNo
          .BPID = vReq.SupplierID
          .Size = "Cargo L:" & vReq.Length & ", W:" & vReq.Width & ", H:" & vReq.Height
          .VehicleTypeDescription = vReq.FK_VR_VehicleRequest_VehicleTypeID.cmba
          .wuom = vReq.FK_VR_VehicleRequest_WeightUnit.Description
          If Convert.ToBoolean(ConfigurationManager.AppSettings("NewLogicSanctionCheck")) Then
            .GeneratePO = 1 'YES
          Else
            .GeneratePO = 2 'NO
          End If
        End With
        With re
          .VehicleTypeID = x.vehicleType
          .TransporterID = x.transporterCode
          .VehiclePlacedOn = x.loadingDate
          .ExecutionDescription = vReq.ProjectID & "/"
          '.VehicleNo = ""
          '.EstimatedDistance = 0
          '.EstimatedRatePerKM = 0
          .EstimatedAmount = x.totalAmount
          .Remarks = "System created"
          '===============================
          .ArrangedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
          .ArrangedOn = Now.ToString("dd/MM/yyyy HH:mm")
          '====================
          .RequestNo = vReq.RequestNo
          .SPRequestID = vReq.SPRequestID
          .SPLoadID = x.loadId
          .SPExecutionStatus = enumSPExecutionStatus.Free
        End With
        If Found Then
          If re.RequestStatusID = RequestStates.UnderExecution Then
            re = SIS.VR.vrRequestExecution.UpdateData(re)
          End If
        Else
          re = SIS.VR.vrRequestExecution.InsertData(re)
        End If
        '3. Link Vehicle request with execution
        '   CompleteWF handles UPD/INS
        If re.RequestStatusID = RequestStates.UnderExecution Then
          SIS.VR.vrUnLinkedRequest.CompleteWF(re.RequestNo, re.SRNNo)
        End If
      Next
      rq = vrPendingVehicleRequestGetByID(rq.RequestNo)
      Try
        'PushData Handles UPD/INS
        SIS.VR.vrPendingVehicleRequest.PushPODataByExecution(rq.SRNNo)
      Catch ex As Exception
        Dim xx As String = "Error During PO Creation in ERP"
      End Try

      Return ""
    End Function
    Public Shared Function PushPODataByExecution(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim Re As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim ePO As SPApi.POData = SPApi.POData.GetByID(Re.ISGECLoadID, Comp)
      If ePO Is Nothing Then
        SPApi.POData.NewInsertData(Re, Comp)
      Else
        'To Write
        'SPApi.POData.NewUpdateData(Re, Comp)
      End If
      Return Re
    End Function

#End Region

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
          If Convert.ToInt32(tmp.RFQ) <> Results.RequestNo Then
            With Results
              .SPStatus = enumSPStatus.Free
              .SPEdiStatus = enumSPEdiStatus.SPError
              .SPEdiMessage = "Wrong RFQ No returned from SP RequestNo:" & Results.RequestNo & ", Returned RFQ:" & tmp.RFQ
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
      End If
      Return jsonStr
    End Function
    Private Shared Function GetSPR(r As SIS.VR.vrVehicleRequest, Optional Test As Boolean = False) As SPApi.SPRequest
      Dim t As New SPApi.SPRequest
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      If Not Test Then
        With t
          If Comp <> "200" Then
            .RFQ = Comp & "_" & r.RequestNo
          Else
            .RFQ = r.RequestNo
          End If
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
          .branchCode = "EU" & Comp
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
    Public Shared Function RejectWF(ByVal RequestNo As Int32, ByVal ReturnRemarks As String) As SIS.VR.vrPendingVehicleRequest
      Dim Results As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
      Dim mayReturn As Boolean = True
      If Results.SPRequestID <> "" Then
        mayReturn = False
        Dim tmp As SPApi.SPResponse = SPApi.CancelSPRequest(Results.SPRequestID, ReturnRemarks)
        If tmp.IsError Then
          With Results
            .SPEdiStatus = enumSPEdiStatus.SPError
            .SPEdiMessage = tmp.Message
          End With
          Throw New Exception(tmp.Message)
        Else
          mayReturn = True
          With Results
            .SPStatus = enumSPStatus.Free
            .SPEdiStatus = enumSPEdiStatus.Free
            .SPEdiMessage = "Cancelled in Superprocure:" & .SPRequestID
            .SPExecutionCreatedBy = HttpContext.Current.Session("LoginID")
            .SPExecutionCreatedOn = Now.ToString("dd/MM/yyyy HH:mm")
            .SPRequestID = ""
            .SPLoadData = ""
          End With
        End If
      End If
      If mayReturn Then
        With Results
          .RequestStatus = RequestStates.Returned
          .ReturnRemarks = ReturnRemarks
          .ReturnedBy = HttpContext.Current.Session("LoginID")
          .ReturnedOn = Now
        End With
      End If
      Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
      If mayReturn Then
        SendEMail(Results)
      End If
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
