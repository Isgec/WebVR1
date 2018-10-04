Partial Class AF_vrSanctionAlert
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrSanctionAlert_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrSanctionAlert.Init
    DataClassName = "AvrSanctionAlert"
    SetFormView = FVvrSanctionAlert
  End Sub
  Protected Sub TBLvrSanctionAlert_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrSanctionAlert.Init
    SetToolBar = TBLvrSanctionAlert
  End Sub
  Protected Sub FVvrSanctionAlert_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrSanctionAlert.PreRender
    Dim oF_ProjectID_Display As Label  = FVvrSanctionAlert.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVvrSanctionAlert.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrSanctionAlert.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrSanctionAlert") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrSanctionAlert", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVvrSanctionAlert.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVvrSanctionAlert.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_SanctionAlert_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
