Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Imports OfficeOpenXml
Partial Class GF_rpRequestList
	Inherits SIS.SYS.InsertBase
	Protected Sub FVvrReports_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrReports.Init
		DataClassName = "AvrReports"
		SetFormView = FVvrReports
	End Sub
	Protected Sub TBLvrReports_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrReports.Init
		SetToolBar = TBLvrReports
	End Sub
	Protected Sub FVvrReports_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrReports.PreRender
		Dim oF_FProject_Display As Label = FVvrReports.FindControl("F_FProject_Display")
		Dim oF_FProject As TextBox = FVvrReports.FindControl("F_FProject")
		Dim oF_TProject_Display As Label = FVvrReports.FindControl("F_TProject_Display")
		Dim oF_TProject As TextBox = FVvrReports.FindControl("F_TProject")
		Dim oF_FSupplier_Display As Label = FVvrReports.FindControl("F_FSupplier_Display")
		Dim oF_FSupplier As TextBox = FVvrReports.FindControl("F_FSupplier")
		Dim oF_TSupplier_Display As Label = FVvrReports.FindControl("F_TSupplier_Display")
		Dim oF_TSupplier As TextBox = FVvrReports.FindControl("F_TSupplier")
		Dim oF_FUser_Display As Label = FVvrReports.FindControl("F_FUser_Display")
		Dim oF_FUser As TextBox = FVvrReports.FindControl("F_FUser")
		Dim oF_TUser_Display As Label = FVvrReports.FindControl("F_TUser_Display")
		Dim oF_TUser As TextBox = FVvrReports.FindControl("F_TUser")
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Forms") & "/GF_rpRequestList.js")
		mStr = oTR.ReadToEnd
		oTR.Close()
		oTR.Dispose()
		If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrReports") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrReports", mStr)
		End If
		If Request.QueryString("FProject") IsNot Nothing Then
			CType(FVvrReports.FindControl("F_FProject"), TextBox).Text = Request.QueryString("FProject")
			CType(FVvrReports.FindControl("F_FProject"), TextBox).Enabled = False
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function FProjectCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function TProjectCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function FSupplierCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function TSupplierCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function FUserCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function TUserCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_Reports_FUser(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim FUser As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(FUser)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_Reports_TUser(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim TUser As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(TUser)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_Reports_FProjectID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim FProject As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(FProject)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_Reports_S_F_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TProject As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(TProject)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_Reports_TProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TProject As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(TProject)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_Reports_FSupplier(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FSupplier As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(FSupplier)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_Reports_TSupplier(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim TSupplier As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TSupplier)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function

	Protected Sub ODSvrReports_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles ODSvrReports.Inserting
		Dim oRec As SIS.VR.vrReports = e.InputParameters.Item(0)
		Dim FilePath As String = CreateFile(oRec)
		Dim FileNameForUser As String = "RequestList_" & Convert.ToDateTime(oRec.FReqDt).ToString("dd-MM-yyyy") & ".xlsx"
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
		IO.File.Copy(Server.MapPath("~/App_Templates") & "\RequestListTemplate.xlsx", FileName)
		Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
		Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)
		Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Report")

		Dim oRqs As List(Of SIS.VR.vrReqReasonByExecuter) = SIS.VR.vrReqReasonByExecuter.RP_ReqReasonByExecuterList(oRec)

		Dim r As Integer = 3
		Dim c As Integer = 1
		Dim tc As Integer = 28
		With xlWS
			For Each rq As SIS.VR.vrReqReasonByExecuter In oRqs
				On Error Resume Next
				If r > 3 Then xlWS.InsertRow(r, 1, r + 1)
				'For c = 1 To tc
				'	.cells(r, c).StyleID = .cells(r + 1, c).StyleID
				'Next
				c = 1
				.Cells(r, c).Value = rq.ProjectID
				c += 1
				.Cells(r, c).Value = rq.IDM_Projects4_Description
				c += 1
				.Cells(r, c).Value = rq.RequestNo
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_RequestedBy.UserFullName
				c += 1
				.Cells(r, c).Value = rq.RequesterDivisionID
				c += 1
				.Cells(r, c).Value = rq.ItemDescription
				c += 1
				.Cells(r, c).Value = rq.IDM_Vendors5_Description
				c += 1
				.Cells(r, c).Value = rq.SupplierLocation
				c += 1
				.Cells(r, c).Value = rq.VR_VehicleTypes9_cmba
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SizeUnit.Description
				c += 1
				.Cells(r, c).Value = rq.Length & " x " & rq.Width & " x " & rq.Height
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_WeightUnit.Description
				c += 1
				.Cells(r, c).Value = rq.MaterialWeight & rq.NoOfPackages
				c += 1
				.Cells(r, c).Value = rq.InvoiceValue
				c += 1
				.Cells(r, c).Value = IIf(rq.OutOfContract, "YES", "NO")
				c += 1
				.Cells(r, c).Value = IIf(rq.MICN, "YES", "NO")
				c += 1
				.Cells(r, c).Value = rq.CustomInvoiceNo
				c += 1
				.Cells(r, c).Value = rq.RequestedOn
				c += 1
				.Cells(r, c).Value = rq.VehicleRequiredOn
				c += 1
				.Cells(r, c).Value = rq.VR_RequestStates7_Description
				c += 1
				.Cells(r, c).Value = rq.SRNNo
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.FK_VR_RequestExecution_ArrangedBy.UserFullName
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.FK_VR_RequestExecution_TransporterID.TransporterName
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.GRNo
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.GRDate
				c += 1
				.Cells(r, c).Value = rq.FK_VR_VehicleRequest_SRNNo.VehicleNo
				c += 1
				.Cells(r, c).Value = rq.VR_RequestReasons12_Description
				c += 1
				.Cells(r, c).Value = rq.ReasonEneteredOn
				c += 1
				.Cells(r, c).Value = IIf(rq.OverDimentionConsignement, "YES", "NO")
				c += 1
				.Cells(r, c).Value = rq.VR_ODCReasons1_Description
				c += 1
				.Cells(r, c).Value = rq.MaterialSize
				Dim ExeAmt As Decimal = 0
				Dim ExeType As String = ""
				ExeType = "Execution" & "-" & rq.FK_VR_VehicleRequest_SRNNo.SRNNo
				ExeAmt = rq.FK_VR_VehicleRequest_SRNNo.EstimatedAmount
				Dim tmpAmt As Decimal = 0
				If rq.FK_VR_VehicleRequest_SRNNo.IRNo <> String.Empty Then
					tmpAmt = GetIRAmount(rq.FK_VR_VehicleRequest_SRNNo.IRNo)
					If tmpAmt > 0 Then
						ExeAmt = tmpAmt
						ExeType = "IR" & "-" & rq.FK_VR_VehicleRequest_SRNNo.IRNo
					End If
					tmpAmt = 0
					Dim tmpComp As String = GetProjectFinanceCompany(rq.ProjectID)
					Dim tmpPTR As lgPTR = GetPTRAmount(rq.FK_VR_VehicleRequest_SRNNo.IRNo, tmpComp)
					If tmpPTR IsNot Nothing Then
						If tmpPTR.PTRAmount > 0 Then
							ExeAmt = tmpAmt
							ExeType = "PTR"
						End If
					End If
				End If
				c += 1
				.Cells(r, c).Value = ExeType
				c += 1
				.Cells(r, c).Value = ExeAmt
				r += 1
			Next
		End With
		xlPk.Save()
		xlPk.Dispose()
		Return FileName
	End Function
	Public Shared Function GetIRAmount(ByVal IRNo As Integer) As Decimal
		Dim mRet As Decimal = 0
		Dim Sql As String = ""
		Sql = Sql & "select "
		Sql = Sql & "isnull(ir.t_amth_1,0) as IRAmount "
		Sql = Sql & "from ttfacp100200 as ir "
		Sql = Sql & "where ir.t_ninv = " & IRNo
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
	Public Class lgPTR
		Public PTRNo As String = ""
		Public PTRAmount As Decimal = 0
		Sub New()
			'dummy
		End Sub
	End Class
	Public Shared Function GetPTRAmount(ByVal IRNo As Integer, ByVal Company As String) As lgPTR
		Dim mRet As lgPTR = Nothing

		Dim Sql As String = ""
		Sql = Sql & "select "
		Sql = Sql & "pb.t_ninv as PTRNo, "
		Sql = Sql & "isnull(pb.t_amth_1,0) as PTRAmount "
		Sql = Sql & "from ttfacp100200 as ir "
		Sql = Sql & "inner join ttfacp200" & Company & " as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)   "
		Sql = Sql & "where ir.t_ctyp = 'PTR' and pb.t_tpay=1 and ir.t_ninv = " & IRNo
		Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
			Using Cmd As SqlCommand = Con.CreateCommand()
				Cmd.CommandType = CommandType.Text
				Cmd.CommandText = Sql
				Con.Open()
				Dim tmp As SqlDataReader = Cmd.ExecuteReader
				If tmp.Read Then
					mRet = New lgPTR
					With mRet
						.PTRNo = tmp("PTRNo")
						.PTRAmount = tmp("PTRAmount")
					End With
				End If
			End Using
		End Using
		Return mRet
	End Function
	Public Shared Function GetProjectFinanceCompany(ByVal ProjectID As String) As String
		Dim mRet As Decimal = 0
		Dim Sql As String = "select t_ncmp "
		Sql &= "from ttppdm600200 "
		Sql &= "where t_cprj='" & ProjectID.ToUpper & "'"
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

  Private Sub FVvrReports_ItemCommand(sender As Object, e As FormViewCommandEventArgs) Handles FVvrReports.ItemCommand
    If e.CommandName.ToLower = "showbalance" Then
      Dim ProjectID As String = CType(FVvrReports.FindControl("S_F_ProjectID"), TextBox).Text
      If ProjectID = "" Then Return
      ProjectID = ProjectID.ToUpper
      CType(FVvrReports.FindControl("pBal"), HtmlTableCell).InnerHtml = SIS.VR.vrRequestExecution.GetHTMLForProjectID(ProjectID)
    End If
  End Sub
End Class
