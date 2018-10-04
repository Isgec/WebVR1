Partial Class EF_vrVehicleRequest
	Inherits SIS.SYS.UpdateBase
	Public Property Editable() As Boolean
		Get
			Return True
			If ViewState("Editable") IsNot Nothing Then
				Return CType(ViewState("Editable"), Boolean)
			End If
		End Get
		Set(ByVal value As Boolean)
			ViewState.Add("Editable", value)
		End Set
	End Property
	Protected Sub FVvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleRequest.Init
		DataClassName = "EvrVehicleRequest"
		SetFormView = FVvrVehicleRequest
	End Sub
	Protected Sub TBLvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleRequest.Init
		SetToolBar = TBLvrVehicleRequest
	End Sub
	Protected Sub FVvrVehicleRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleRequest.PreRender
		TBLvrVehicleRequest.PrintUrl &= Request.QueryString("RequestNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrVehicleRequest.js")
		mStr = oTR.ReadToEnd
		oTR.Close()
		oTR.Dispose()
		If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVehicleRequest") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVehicleRequest", mStr)
		End If
	End Sub
	'Protected Sub cmdAttach_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles TBLvrRequestAttachments.AttachClicked
	'	Dim tmpPath As String = ConfigurationManager.AppSettings("ActiveAttachmentPath")
	'	Dim tmpName As String = IO.Path.GetRandomFileName()
	'	e.MoveTo(tmpPath & "\\" & tmpName)
	'	Dim RequestNo As Int32 = CType(FVvrVehicleRequest.FindControl("F_RequestNo"), TextBox).Text
	'	Dim oReq As SIS.VR.vrRequestAttachments = New SIS.VR.vrRequestAttachments()
	'	With oReq
	'		.RequestNo = RequestNo
	'		.Description = e.FileName
	'		.FileName = e.FileName
	'		.DiskFile = tmpPath & "\" & tmpName
	'	End With
	'	SIS.VR.vrRequestAttachments.InsertData(oReq)
	'	GVvrRequestAttachments.DataBind()
	'End Sub
	Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
		With F_FileUpload
			If .HasFile Then
				Dim tmpPath As String = ConfigurationManager.AppSettings("ActiveAttachmentPath")
				Dim tmpName As String = IO.Path.GetRandomFileName()
				.SaveAs(tmpPath & "\\" & tmpName)
				Dim RequestNo As Int32 = CType(FVvrVehicleRequest.FindControl("F_RequestNo"), TextBox).Text
				Dim oReq As SIS.VR.vrRequestAttachments = New SIS.VR.vrRequestAttachments()
				oReq.RequestNo = RequestNo
				oReq.Description = .FileName
				oReq.FileName = .FileName
				oReq.DiskFile = tmpPath & "\" & tmpName
				SIS.VR.vrRequestAttachments.InsertData(oReq)
				GVvrRequestAttachments.DataBind()
			End If
		End With
	End Sub

	Partial Class gvBase
		Inherits SIS.SYS.attachGridBase
	End Class
	Private WithEvents gvvrRequestAttachmentsCC As New gvBase
	Protected Sub GVvrRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrRequestAttachments.Init
		gvvrRequestAttachmentsCC.DataClassName = "GvrRequestAttachments"
		gvvrRequestAttachmentsCC.SetGridView = GVvrRequestAttachments
	End Sub
	Protected Sub TBLvrRequestAttachments_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestAttachments.Init
		gvvrRequestAttachmentsCC.SetToolBar = TBLvrRequestAttachments
	End Sub
	Protected Sub GVvrRequestAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrRequestAttachments.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrRequestAttachments.DataKeys(e.CommandArgument).Values("RequestNo")
				Dim SerialNo As Int32 = GVvrRequestAttachments.DataKeys(e.CommandArgument).Values("SerialNo")
				Dim RedirectUrl As String = TBLvrRequestAttachments.EditUrl & "?RequestNo=" & RequestNo & "&SerialNo=" & SerialNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
	End Sub
	'Protected Sub TBLvrRequestAttachments_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLvrRequestAttachments.AddClicked
	'	Dim RequestNo As Int32 = CType(FVvrVehicleRequest.FindControl("F_RequestNo"), TextBox).Text
	'	TBLvrRequestAttachments.AddUrl &= "?RequestNo=" & RequestNo
	'End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmVendors.SelectqcmVendorsAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	 Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_VehicleRequest_ProjectID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
		End If
		Return mRet
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_VehicleRequest_SupplierID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1), String)
		Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)

		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
		End If
		Return mRet
	End Function
	Protected Sub ODSvrVehicleRequest_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrVehicleRequest.Selected
		Dim oVR As SIS.VR.vrVehicleRequest = DirectCast(e.ReturnValue, SIS.VR.vrVehicleRequest)
		If oVR.RequestStatus >= RequestStates.UnderExecution Then
			With TBLvrVehicleRequest
				.EnableSave = False
				.EnableDelete = False
			End With
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_ERPPONumber(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim ERPPoNumber As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrERPPo = SIS.VR.vrERPPo.vrERPPoGetByID(ERPPoNumber)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|PO Number NOT found in ERP LN."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.BuyerID & "|" & oVar.BuyerName
		End If
		Return mRet
	End Function

End Class
