Partial Class EF_vrUserGroup
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrUserGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserGroup.Init
    DataClassName = "EvrUserGroup"
    SetFormView = FVvrUserGroup
  End Sub
  Protected Sub TBLvrUserGroup_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUserGroup.Init
    SetToolBar = TBLvrUserGroup
  End Sub
  Protected Sub FVvrUserGroup_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserGroup.PreRender
		TBLvrUserGroup.PrintUrl &= Request.QueryString("SerialNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrUserGroup.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUserGroup") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUserGroup", mStr)
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_UserGroup_UserID(ByVal value As String) As String
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
