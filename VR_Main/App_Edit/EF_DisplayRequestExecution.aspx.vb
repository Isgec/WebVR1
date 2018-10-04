Partial Class EF_DisplayRequestExecution
	Inherits SIS.SYS.UpdateBase
	Protected Sub FVvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestExecution.Init
		DataClassName = "EvrRequestExecution"
		SetFormView = FVvrRequestExecution
	End Sub
	Protected Sub TBLvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestExecution.Init
		SetToolBar = TBLvrRequestExecution
	End Sub
	Protected Sub FVvrRequestExecution_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestExecution.PreRender
		TBLvrRequestExecution.PrintUrl &= Request.QueryString("SRNNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrRequestExecution.js")
		mStr = oTR.ReadToEnd
		oTR.Close()
		oTR.Dispose()
		If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestExecution") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestExecution", mStr)
		End If
	End Sub
	'Protected Sub cmdAttach_Clicked(ByVal sender As Object, ByVal e As UploaderEventArgs) Handles TBLvrExecutionAttachments.AttachClicked
	'	Dim tmpPath As String = ConfigurationManager.AppSettings("ActiveAttachmentPath")
	'	Dim tmpName As String = IO.Path.GetRandomFileName()
	'	e.MoveTo(tmpPath & "\\" & tmpName)
	'	Dim SRNNo As Int32 = CType(FVvrRequestExecution.FindControl("F_SRNNo"), TextBox).Text
	'	Dim oReq As SIS.VR.vrExecutionAttachments = New SIS.VR.vrExecutionAttachments()
	'	With oReq
	'		.SRNNo = SRNNo
	'		.Description = e.FileName
	'		.FileName = e.FileName
	'		.DiskFile = tmpPath & "\" & tmpName
	'	End With
	'	SIS.VR.vrExecutionAttachments.InsertData(oReq)
	'	GVvrExecutionAttachments.DataBind()
	'End Sub
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
	'Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
	'	With F_FileUpload
	'		If .HasFile Then
	'			Dim tmpPath As String = ConfigurationManager.AppSettings("ActiveAttachmentPath")
	'			Dim tmpName As String = IO.Path.GetRandomFileName()
	'			.SaveAs(tmpPath & "\\" & tmpName)
	'			Dim SRNNo As Int32 = CType(FVvrRequestExecution.FindControl("F_SRNNo"), TextBox).Text
	'			Dim oReq As SIS.VR.vrExecutionAttachments = New SIS.VR.vrExecutionAttachments()
	'			oReq.SRNNo = SRNNo
	'			oReq.Description = .FileName
	'			oReq.FileName = .FileName
	'			oReq.DiskFile = tmpPath & "\" & tmpName
	'			SIS.VR.vrExecutionAttachments.InsertData(oReq)
	'			GVvrExecutionAttachments.DataBind()
	'		End If
	'	End With
	'End Sub
	Partial Class gvaBase
		Inherits SIS.SYS.attachGridBase
	End Class
	Partial Class gvBase
		Inherits SIS.SYS.psGridBase
	End Class
	Private WithEvents gvvrLinkedRequestCC As New gvBase
	Protected Sub GVvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLinkedRequest.Init
		gvvrLinkedRequestCC.DataClassName = "GvrLinkedRequest"
		gvvrLinkedRequestCC.SetGridView = GVvrLinkedRequest
	End Sub
	Protected Sub TBLvrLinkedRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkedRequest.Init
		gvvrLinkedRequestCC.SetToolBar = TBLvrLinkedRequest
	End Sub
	Protected Sub GVvrLinkedRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLinkedRequest.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim RequestNo As Int32 = GVvrLinkedRequest.DataKeys(e.CommandArgument).Values("RequestNo")
				Dim RedirectUrl As String = TBLvrLinkedRequest.EditUrl & "?RequestNo=" & RequestNo
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
		Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
	End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_FK_VR_RequestExecution_TransporterID(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim TransporterID As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
		End If
		Return mRet
	End Function
	Protected Sub ODSvrRequestExecution_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrRequestExecution.Selected
		Dim oVR As SIS.VR.vrRequestExecution = DirectCast(e.ReturnValue, SIS.VR.vrRequestExecution)
		If oVR.RequestStatusID >= RequestStates.RequestLinked Then
			With TBLvrRequestExecution
				.EnableSave = False
				.EnableDelete = False
			End With
			Me.RequestStatusID = oVR.RequestStatusID
		End If
	End Sub
	Public Property RequestStatusID() As Integer
		Get
      If ViewState("RequestStatusID") IsNot Nothing Then
        Return CType(ViewState("RequestStatusID"), Integer)
      End If
      Return 0
    End Get
		Set(ByVal value As Integer)
			ViewState.Add("RequestStatusID", value)
		End Set
	End Property
End Class
