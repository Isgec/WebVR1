Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrReqReasonByExecuter
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
    Public Shared Function InitiateWF(ByVal RequestNo As Int32) As SIS.VR.vrReqReasonByExecuter
      Dim Results As SIS.VR.vrReqReasonByExecuter = vrReqReasonByExecuterGetByID(RequestNo)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal RequestNo As Int32) As SIS.VR.vrReqReasonByExecuter
      Dim Results As SIS.VR.vrReqReasonByExecuter = vrReqReasonByExecuterGetByID(RequestNo)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal RequestNo As Int32) As SIS.VR.vrReqReasonByExecuter
      Dim Results As SIS.VR.vrReqReasonByExecuter = vrReqReasonByExecuterGetByID(RequestNo)
      Return Results
    End Function
    Public Shared Function UZ_vrReqReasonByExecuterSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal VehicleTypeID As Int32, ByVal RequestedBy As String, ByVal RequestStatus As Int32) As List(Of SIS.VR.vrReqReasonByExecuter)
      Dim Results As List(Of SIS.VR.vrReqReasonByExecuter) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_ReqReasonByExecuterSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_ReqReasonByExecuterSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID",SqlDbType.Int,10, IIf(VehicleTypeID = Nothing, 0,VehicleTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestStatus",SqlDbType.Int,10, IIf(RequestStatus = Nothing, 0,RequestStatus))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus",SqlDbType.Int,10, "4")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrReqReasonByExecuterUpdate(ByVal Record As SIS.VR.vrReqReasonByExecuter) As SIS.VR.vrReqReasonByExecuter
      Dim _Result As SIS.VR.vrReqReasonByExecuter = vrReqReasonByExecuterUpdate(Record)
      Return _Result
		End Function
		Public Shared Function RP_ReqReasonByExecuterList(ByVal oRP As SIS.VR.vrReports) As List(Of SIS.VR.vrReqReasonByExecuter)
			Dim Results As List(Of SIS.VR.vrReqReasonByExecuter) = Nothing
			Dim Sql As String = ""
			Sql = Sql & "  SELECT"
			Sql = Sql & "		[VR_VehicleRequest].[RequestNo] ,"
			Sql = Sql & "		[VR_VehicleRequest].[SupplierID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[RequestDescription] ,"
			Sql = Sql & "		[VR_VehicleRequest].[SupplierLocation] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ProjectID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ProjectType] ,"
			Sql = Sql & "		[VR_VehicleRequest].[DeliveryLocation] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ItemDescription] ,"
			Sql = Sql & "		[VR_VehicleRequest].[MaterialSize] ,"
			Sql = Sql & "		[VR_VehicleRequest].[SizeUnit] ,"
			Sql = Sql & "		[VR_VehicleRequest].[Height] ,"
			Sql = Sql & "		[VR_VehicleRequest].[Width] ,"
			Sql = Sql & "		[VR_VehicleRequest].[Length] ,"
			Sql = Sql & "		[VR_VehicleRequest].[MaterialWeight] ,"
			Sql = Sql & "		[VR_VehicleRequest].[WeightUnit] ,"
			Sql = Sql & "		[VR_VehicleRequest].[NoOfPackages] ,"
			Sql = Sql & "		[VR_VehicleRequest].[VehicleTypeID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[VehicleRequiredOn] ,"
			Sql = Sql & "		[VR_VehicleRequest].[OverDimentionConsignement] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ODCReasonID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[Remarks] ,"
			Sql = Sql & "		[VR_VehicleRequest].[MICN] ,"
			Sql = Sql & "		[VR_VehicleRequest].[CustomInvoiceNo] ,"
			Sql = Sql & "		[VR_VehicleRequest].[RequestedBy] ,"
			Sql = Sql & "		[VR_VehicleRequest].[RequestedOn] ,"
			Sql = Sql & "		[VR_VehicleRequest].[RequesterDivisionID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[RequestStatus] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ReturnedOn] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ReturnedBy] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ReturnRemarks] ,"
			Sql = Sql & "		[VR_VehicleRequest].[SRNNo] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ValidRequest] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ODCAtSupplierLoading] ,"
			Sql = Sql & "		[VR_VehicleRequest].[FromLocation] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ToLocation] ,"
			Sql = Sql & "		[VR_VehicleRequest].[CustomInvoiceIssued] ,"
			Sql = Sql & "		[VR_VehicleRequest].[CT1Issued] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ARE1Issued] ,"
			Sql = Sql & "		[VR_VehicleRequest].[DIIssued] ,"
			Sql = Sql & "		[VR_VehicleRequest].[PaymentChecked] ,"
			Sql = Sql & "		[VR_VehicleRequest].[GoodsPacked] ,"
			Sql = Sql & "		[VR_VehicleRequest].[POApproved] ,"
			Sql = Sql & "		[VR_VehicleRequest].[WayBill] ,"
			Sql = Sql & "		[VR_VehicleRequest].[MarkingDetails] ,"
			Sql = Sql & "		[VR_VehicleRequest].[TarpaulineRequired] ,"
			Sql = Sql & "		[VR_VehicleRequest].[PackageStckable] ,"
			Sql = Sql & "		[VR_VehicleRequest].[InvoiceValue] ,"
			Sql = Sql & "		[VR_VehicleRequest].[OutOfContract] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ERPPONumber] ,"
			Sql = Sql & "		[VR_VehicleRequest].[BuyerInERP] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ExecuterReasonID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ExecuterID] ,"
			Sql = Sql & "		[VR_VehicleRequest].[ReasonEneteredOn] ,"
			Sql = Sql & "		[aspnet_Users1].[UserFullName] AS aspnet_Users1_UserFullName,"
			Sql = Sql & "		[aspnet_Users2].[UserFullName] AS aspnet_Users2_UserFullName,"
			Sql = Sql & "		[HRM_Divisions3].[Description] AS HRM_Divisions3_Description,"
			Sql = Sql & "		[IDM_Projects4].[Description] AS IDM_Projects4_Description,"
			Sql = Sql & "		[IDM_Vendors5].[Description] AS IDM_Vendors5_Description,"
			Sql = Sql & "		[VR_RequestExecution6].[ExecutionDescription] AS VR_RequestExecution6_ExecutionDescription,"
			Sql = Sql & "		[VR_RequestStates7].[Description] AS VR_RequestStates7_Description,"
			Sql = Sql & "		[VR_Units8].[Description] AS VR_Units8_Description,"
			Sql = Sql & "		[VR_VehicleTypes9].[cmba] AS VR_VehicleTypes9_cmba,"
			Sql = Sql & "		[VR_ODCReasons1].[Description] AS VR_ODCReasons1_Description,"
			Sql = Sql & "		[VR_Units2].[Description] AS VR_Units2_Description,"
			Sql = Sql & "		[aspnet_Users10].[UserFullName] AS aspnet_Users10_UserFullName,"
			Sql = Sql & "		[aspnet_Users11].[UserFullName] AS aspnet_Users11_UserFullName,"
			Sql = Sql & "		[VR_RequestReasons12].[Description] AS VR_RequestReasons12_Description "
			Sql = Sql & "  FROM [VR_VehicleRequest] "
			Sql = Sql & "  INNER JOIN [aspnet_Users] AS [aspnet_Users1]"
			Sql = Sql & "    ON [VR_VehicleRequest].[RequestedBy] = [aspnet_Users1].[LoginID]"
			Sql = Sql & "  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users2]"
			Sql = Sql & "    ON [VR_VehicleRequest].[ReturnedBy] = [aspnet_Users2].[LoginID]"
			Sql = Sql & "  LEFT OUTER JOIN [HRM_Divisions] AS [HRM_Divisions3]"
			Sql = Sql & "    ON [VR_VehicleRequest].[RequesterDivisionID] = [HRM_Divisions3].[DivisionID]"
			Sql = Sql & "  INNER JOIN [IDM_Projects] AS [IDM_Projects4]"
			Sql = Sql & "    ON [VR_VehicleRequest].[ProjectID] = [IDM_Projects4].[ProjectID]"
			Sql = Sql & "  INNER JOIN [IDM_Vendors] AS [IDM_Vendors5]"
			Sql = Sql & "    ON [VR_VehicleRequest].[SupplierID] = [IDM_Vendors5].[VendorID]"
			Sql = Sql & "  LEFT OUTER JOIN [VR_RequestExecution] AS [VR_RequestExecution6]"
			Sql = Sql & "    ON [VR_VehicleRequest].[SRNNo] = [VR_RequestExecution6].[SRNNo]"
			Sql = Sql & "  INNER JOIN [VR_RequestStates] AS [VR_RequestStates7]"
			Sql = Sql & "    ON [VR_VehicleRequest].[RequestStatus] = [VR_RequestStates7].[StatusID]"
			Sql = Sql & "  LEFT OUTER JOIN [VR_Units] AS [VR_Units8]"
			Sql = Sql & "    ON [VR_VehicleRequest].[SizeUnit] = [VR_Units8].[UnitID]"
			Sql = Sql & "  INNER JOIN [VR_VehicleTypes] AS [VR_VehicleTypes9]"
			Sql = Sql & "    ON [VR_VehicleRequest].[VehicleTypeID] = [VR_VehicleTypes9].[VehicleTypeID]"
			Sql = Sql & "  LEFT OUTER JOIN [VR_ODCReasons] AS [VR_ODCReasons1]"
			Sql = Sql & "    ON [VR_VehicleRequest].[ODCReasonID] = [VR_ODCReasons1].[ReasonID]"
			Sql = Sql & "  LEFT OUTER JOIN [VR_Units] AS [VR_Units2]"
			Sql = Sql & "    ON [VR_VehicleRequest].[WeightUnit] = [VR_Units2].[UnitID]"
			Sql = Sql & "  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users10]"
			Sql = Sql & "    ON [VR_VehicleRequest].[BuyerInERP] = [aspnet_Users10].[LoginID]"
			Sql = Sql & "  LEFT OUTER JOIN [aspnet_Users] AS [aspnet_Users11]"
			Sql = Sql & "    ON [VR_VehicleRequest].[ExecuterID] = [aspnet_Users11].[LoginID]"
			Sql = Sql & "  LEFT OUTER JOIN [VR_RequestReasons] AS [VR_RequestReasons12]"
			Sql = Sql & "    ON [VR_VehicleRequest].[ExecuterReasonID] = [VR_RequestReasons12].[ReasonID]"
			Sql = Sql & "  WHERE 1 = 1 "
			If oRP.FProject <> String.Empty And oRP.TProject <> String.Empty Then
				Sql = Sql & "  AND  ([VR_VehicleRequest].[ProjectID] >='" & oRP.FProject & "'  AND [VR_VehicleRequest].[ProjectID] <='" & oRP.TProject & "') "
			End If
			If oRP.FSupplier <> String.Empty And oRP.TSupplier <> String.Empty Then
				Sql = Sql & "  AND  ([VR_RequestExecution6].[TransporterID] >='" & oRP.FSupplier & "'  AND [VR_RequestExecution6].[TRansporterID] <='" & oRP.TSupplier & "') "
			End If
			If oRP.FUser <> String.Empty And oRP.TUser <> String.Empty Then
				Sql = Sql & "  AND  ([VR_VehicleRequest].[RequestedBy] >='" & oRP.FUser & "'  AND [VR_VehicleRequest].[RequestedBy] <='" & oRP.TUser & "') "
			End If
			If oRP.FReqDt <> String.Empty And oRP.TReqDt <> String.Empty Then
				Sql = Sql & "  AND  ([VR_VehicleRequest].[RequestedOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[RequestedOn] <='" & Convert.ToDateTime(oRP.TReqDt).ToString("yyyy-MM-dd") & "') "
			End If
			Sql = Sql & "  ORDER BY"
			Sql = Sql & "    RequestNo "
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function

  End Class
End Namespace
