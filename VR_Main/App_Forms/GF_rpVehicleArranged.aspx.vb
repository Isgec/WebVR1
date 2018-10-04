Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports OfficeOpenXml
Partial Class GF_rpVehicleArranged
	Inherits SIS.SYS.InsertBase
	Protected Sub FVvrReports_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrReports.Init
		DataClassName = "AvrReports"
		SetFormView = FVvrReports
	End Sub
	Protected Sub TBLvrReports_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrReports.Init
		SetToolBar = TBLvrReports
	End Sub
	Protected Sub ODSvrReports_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ODSvrReports.Inserting
		Dim oRec As SIS.VR.vrReports = e.InputParameters.Item(0)
		Dim FilePath As String = CreateFile(oRec)
		Dim FileNameForUser As String = "MIS_" & Convert.ToDateTime(oRec.FReqDt).ToString("dd-MM-yyyy") & ".xlsx"
		If IO.File.Exists(FilePath) Then
			Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
			Response.WriteFile(FilePath)
			Response.End()
			Try
				IO.File.Delete(FilePath)
			Catch ex As Exception
			End Try
		End If
		e.Cancel = True
	End Sub
	Private Function CreateFile(ByVal oRec As SIS.VR.vrReports) As String
		Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\MISTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

		Dim PendingRequestTillLastDate As Integer = Me.PendingRequestTillLastDate(oRec)
		Dim RequestRaisedOnLastDate As Integer = Me.RequestRaisedOnLastDate(oRec)
		Dim VehicleArrangedOnLastDate As Integer = Me.VehicleArrangedOnLastDate(oRec)

		With xlWS
			.Cells(3, 3).Value = Convert.ToDateTime(oRec.FReqDt).ToString("dd/MM/yyyy")
			.Cells(4, 3).Value = Convert.ToDateTime(oRec.TReqDt).ToString("dd/MM/yyyy")
			.Cells(5, 3).Value = IIf(oRec.DivisionID = String.Empty, "ALL Division", oRec.DivisionID)
			.Cells(6, 3).Value = IIf(oRec.OutOfContract, "YES", "ALL REQUEST")
			.Cells(9, 6).Value = PendingRequestTillLastDate
			.Cells(10, 6).Value = RequestRaisedOnLastDate
			.Cells(12, 6).Value = VehicleArrangedOnLastDate

		End With
		Dim RowsAdded As Integer = 0
		Dim oRqs As List(Of SIS.VR.vrReqReasonByExecuter) = Nothing

		oRqs = Me.VehicleNotPlacedOAT48(oRec, True)
		xlWS.Cells(20, 6).Value = oRqs.Count
		PrintIt(oRqs, 36, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		oRqs = Me.VehicleNotPlacedOAT24To48(oRec, True)
		xlWS.Cells(21, 6).Value = oRqs.Count
		PrintIt(oRqs, 40 + RowsAdded, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		oRqs = Me.VehicleNotPlacedOAT24(oRec, True)
		xlWS.Cells(22, 6).Value = oRqs.Count
		PrintIt(oRqs, 44 + RowsAdded, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		oRqs = Me.VehicleNotPlacedOAT48(oRec, False)
		xlWS.Cells(27, 6).Value = oRqs.Count
		PrintIt(oRqs, 51, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		oRqs = Me.VehicleNotPlacedOAT24To48(oRec, False)
		xlWS.Cells(28, 6).Value = oRqs.Count
		PrintIt(oRqs, 55 + RowsAdded, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		oRqs = Me.VehicleNotPlacedOAT24(oRec, False)
		xlWS.Cells(29, 6).Value = oRqs.Count
		PrintIt(oRqs, 59 + RowsAdded, xlWS)
		RowsAdded = RowsAdded + oRqs.Count - 1

		xlPk.Save()
		xlPk.Dispose()
		Return FileName
	End Function
	Private Sub PrintIt(ByVal oRqs As List(Of SIS.VR.vrReqReasonByExecuter), ByVal StartRow As Integer, ByVal xlWS As ExcelWorksheet)
		Dim r As Integer = StartRow
		Dim c As Integer = 1
		Dim tc As Integer = 6
		Dim I As Integer = 0
		With xlWS
			For Each rq As SIS.VR.vrReqReasonByExecuter In oRqs
				On Error Resume Next
				If r > StartRow Then xlWS.InsertRow(r, 1, r + 1)
				I = I + 1
				c = 1
				.Cells(r, c).Value = I.ToString
				c += 1
				.Cells(r, c).Value = rq.IDM_Projects4_Description
				c += 1
				.Cells(r, c).Value = rq.IDM_Vendors5_Description
				c += 1
				.Cells(r, c).Value = rq.SRNNo
				c += 1
				.Cells(r, c).Value = Convert.ToDateTime(rq.VehicleRequiredOn).ToString("dd/MM/yyyy")
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.FK_VR_RequestExecution_TransporterID.TransporterName
				r += 1
			Next
		End With
	End Sub
	Private Function VehicleNotPlacedOAT24(ByVal oRP As SIS.VR.vrReports, ByVal OAT As Boolean) As List(Of SIS.VR.vrReqReasonByExecuter)
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
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & " AND  [VR_VehicleRequest].[RequestStatus] > 3"
		Sql = Sql & " AND  ([VR_VehicleRequest].[VehicleRequiredOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[VehicleRequiredOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		Sql = Sql & " AND  [VR_RequestExecution6].[ReachedAtSupplierOn] is null "
		Sql = Sql & " AND  DateDiff(hh, [VR_VehicleRequest].[VehicleRequiredOn], GetDate()) < 24"
		If OAT Then
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is null) OR ([VR_RequestReasons12].[Transporter]=1))"
		Else
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is not null) and ([VR_RequestReasons12].[Transporter]=0))"
		End If
		Sql = Sql & "  ORDER BY"
		Sql = Sql & "  RequestNo "
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results
	End Function
	Private Function VehicleNotPlacedOAT24To48(ByVal oRP As SIS.VR.vrReports, ByVal OAT As Boolean) As List(Of SIS.VR.vrReqReasonByExecuter)
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
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & " AND  [VR_VehicleRequest].[RequestStatus] > 3"
		Sql = Sql & " AND  ([VR_VehicleRequest].[VehicleRequiredOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[VehicleRequiredOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		Sql = Sql & " AND  [VR_RequestExecution6].[ReachedAtSupplierOn] is null "
		Sql = Sql & " AND  (DateDiff(hh, [VR_VehicleRequest].[VehicleRequiredOn], GetDate()) >= 24 AND DateDiff(hh, [VR_VehicleRequest].[VehicleRequiredOn], GetDate()) <= 48)"
		If OAT Then
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is null) OR ([VR_RequestReasons12].[Transporter]=1))"
		Else
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is not null) and ([VR_RequestReasons12].[Transporter]=0))"
		End If
		Sql = Sql & "  ORDER BY"
		Sql = Sql & "  RequestNo "
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results
	End Function

	Private Function VehicleNotPlacedOAT48(ByVal oRP As SIS.VR.vrReports, ByVal OAT As Boolean) As List(Of SIS.VR.vrReqReasonByExecuter)
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
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & " AND  [VR_VehicleRequest].[RequestStatus] > 3"
		Sql = Sql & " AND  ([VR_VehicleRequest].[VehicleRequiredOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[VehicleRequiredOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		Sql = Sql & " AND  [VR_RequestExecution6].[ReachedAtSupplierOn] is null "
		Sql = Sql & " AND  DateDiff(hh, [VR_VehicleRequest].[VehicleRequiredOn], GetDate()) > 48"
		If OAT Then
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is null) OR ([VR_RequestReasons12].[Transporter]=1))"
		Else
			Sql = Sql & " AND (([VR_VehicleRequest].[ExecuterReasonID] is not null) and ([VR_RequestReasons12].[Transporter]=0))"
		End If
		Sql = Sql & "  ORDER BY"
		Sql = Sql & "  RequestNo "
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
				Dim Reader As SqlDataReader = Cmd.ExecuteReader()
				While (Reader.Read())
					Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
				End While
				Reader.Close()
			End Using
		End Using
		Return Results
	End Function
	Private Function VehicleArrangedOnLastDate(ByVal oRP As SIS.VR.vrReports) As Integer
		Dim Results As Integer = 0
		Dim Sql As String = ""
		Sql = Sql & "  SELECT"
		Sql = Sql & "		Count(*) As Cnt "
		Sql = Sql & "  FROM [VR_VehicleRequest] "
		Sql = Sql & "  INNER JOIN [VR_RequestExecution] "
		Sql = Sql & "    ON [VR_VehicleRequest].[SRNNo] = [VR_RequestExecution].[SRNNo]"
		Sql = Sql & "  WHERE 1 = 1 "
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & "  AND  [VR_VehicleRequest].[RequestStatus] > 6"
		If oRP.TReqDt <> String.Empty Then
			Sql = Sql & "  AND  ([VR_VehicleRequest].[RequestedOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[RequestedOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		End If
		If oRP.TReqDt <> String.Empty Then
			Sql = Sql & "  AND  ([VR_RequestExecution].[ArrangedOn] >='" & Convert.ToDateTime(oRP.TReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_RequestExecution].[ArrangedOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		End If
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Try
					Results = Cmd.ExecuteScalar
				Catch ex As Exception
					Results = 0
				End Try
			End Using
		End Using
		Return Results
	End Function
	Private Function RequestRaisedOnLastDate(ByVal oRP As SIS.VR.vrReports) As Integer
		Dim Results As Integer = 0
		Dim Sql As String = ""
		Sql = Sql & "  SELECT"
		Sql = Sql & "		Count(*) As Cnt "
		Sql = Sql & "  FROM [VR_VehicleRequest] "
		Sql = Sql & "  WHERE 1 = 1 "
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] =1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & "  AND  [VR_VehicleRequest].[RequestStatus] IN (4,5)"
		If oRP.TReqDt <> String.Empty Then
			Sql = Sql & "  AND  ([VR_VehicleRequest].[RequestedOn] >='" & Convert.ToDateTime(oRP.TReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[RequestedOn] <'" & Convert.ToDateTime(oRP.TReqDt).AddDays(1).ToString("yyyy-MM-dd") & "') "
		End If
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Try
					Results = Cmd.ExecuteScalar
				Catch ex As Exception
					Results = 0
				End Try
			End Using
		End Using
		Return Results
	End Function
	Private Function PendingRequestTillLastDate(ByVal oRP As SIS.VR.vrReports) As Integer
		Dim Results As Integer = 0
		Dim Sql As String = ""
		Sql = Sql & "  SELECT"
		Sql = Sql & "		Count(*) As Cnt "
		Sql = Sql & "  FROM [VR_VehicleRequest] "
		Sql = Sql & "  WHERE 1 = 1 "
		If oRP.DivisionID <> String.Empty Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[RequesterDivisionID] ='" & oRP.DivisionID & "'"
		End If
		If oRP.OutOfContract Then
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] =1"
		Else
			Sql = Sql & "  AND  [VR_VehicleRequest].[OutOfContract] = 0"
		End If
		Sql = Sql & "  AND  [VR_VehicleRequest].[RequestStatus] IN (4,5)"
		If oRP.FReqDt <> String.Empty And oRP.TReqDt <> String.Empty Then
			'Less 1 Day in ToDate
			Sql = Sql & "  AND  ([VR_VehicleRequest].[RequestedOn] >='" & Convert.ToDateTime(oRP.FReqDt).ToString("yyyy-MM-dd") & "'  AND [VR_VehicleRequest].[RequestedOn] <'" & Convert.ToDateTime(oRP.TReqDt).ToString("yyyy-MM-dd") & "') "
		End If
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Try
					Results = Cmd.ExecuteScalar
				Catch ex As Exception
					Results = 0
				End Try
			End Using
		End Using
		Return Results
	End Function
End Class


