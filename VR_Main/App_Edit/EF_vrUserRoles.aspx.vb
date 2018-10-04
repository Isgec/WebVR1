Partial Class EF_vrUserRoles
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserRoles.Init
    DataClassName = "EvrUserRoles"
    SetFormView = FVvrUserRoles
  End Sub
  Protected Sub TBLvrUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUserRoles.Init
    SetToolBar = TBLvrUserRoles
  End Sub
  Protected Sub FVvrUserRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserRoles.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrUserRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUserRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUserRoles", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_UserRoles_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim UserID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
