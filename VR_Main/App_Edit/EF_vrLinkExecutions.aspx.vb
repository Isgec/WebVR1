Partial Class EF_vrLinkExecutions
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkExecutions.Init
    DataClassName = "EvrLinkExecutions"
    SetFormView = FVvrLinkExecutions
  End Sub
  Protected Sub TBLvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkExecutions.Init
    SetToolBar = TBLvrLinkExecutions
  End Sub
  Protected Sub FVvrLinkExecutions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkExecutions.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLinkExecutions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLinkExecutions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLinkExecutions", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function LinkedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LinkExecutions_LinkedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim LinkedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(LinkedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
