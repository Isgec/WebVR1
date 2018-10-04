Partial Class AF_vrUserRoles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserRoles.Init
    DataClassName = "AvrUserRoles"
    SetFormView = FVvrUserRoles
  End Sub
  Protected Sub TBLvrUserRoles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrUserRoles.Init
    SetToolBar = TBLvrUserRoles
  End Sub
  Protected Sub FVvrUserRoles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrUserRoles.PreRender
    Dim oF_UserID_Display As Label  = FVvrUserRoles.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVvrUserRoles.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim oF_DivisionID As LC_qcmDivisions = FVvrUserRoles.FindControl("F_DivisionID")
    oF_DivisionID.Enabled = True
    oF_DivisionID.SelectedValue = String.Empty
    If Not Session("F_DivisionID") Is Nothing Then
      If Session("F_DivisionID") <> String.Empty Then
        oF_DivisionID.SelectedValue = Session("F_DivisionID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrUserRoles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrUserRoles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrUserRoles", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVvrUserRoles.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVvrUserRoles.FindControl("F_SerialNo"), TextBox).Enabled = False
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
