Partial Class AF_vrLinkExecutions
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkExecutions.Init
    DataClassName = "AvrLinkExecutions"
    SetFormView = FVvrLinkExecutions
  End Sub
  Protected Sub TBLvrLinkExecutions_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLinkExecutions.Init
    SetToolBar = TBLvrLinkExecutions
  End Sub
  Protected Sub FVvrLinkExecutions_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLinkExecutions.PreRender
    Dim oF_SRNNo_Display As Label  = FVvrLinkExecutions.FindControl("F_SRNNo_Display")
    oF_SRNNo_Display.Text = String.Empty
    If Not Session("F_SRNNo_Display") Is Nothing Then
      If Session("F_SRNNo_Display") <> String.Empty Then
        oF_SRNNo_Display.Text = Session("F_SRNNo_Display")
      End If
    End If
    Dim oF_SRNNo As TextBox  = FVvrLinkExecutions.FindControl("F_SRNNo")
    oF_SRNNo.Enabled = True
    oF_SRNNo.Text = String.Empty
    If Not Session("F_SRNNo") Is Nothing Then
      If Session("F_SRNNo") <> String.Empty Then
        oF_SRNNo.Text = Session("F_SRNNo")
      End If
    End If
    Dim oF_LinkedBy_Display As Label  = FVvrLinkExecutions.FindControl("F_LinkedBy_Display")
    Dim oF_LinkedBy As TextBox  = FVvrLinkExecutions.FindControl("F_LinkedBy")
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrLinkExecutions.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLinkExecutions") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLinkExecutions", mStr)
    End If
    If Request.QueryString("LinkID") IsNot Nothing Then
      CType(FVvrLinkExecutions.FindControl("F_LinkID"), TextBox).Text = Request.QueryString("LinkID")
      CType(FVvrLinkExecutions.FindControl("F_LinkID"), TextBox).Enabled = False
    End If
    If Request.QueryString("SRNNo") IsNot Nothing Then
      CType(FVvrLinkExecutions.FindControl("F_SRNNo"), TextBox).Text = Request.QueryString("SRNNo")
      CType(FVvrLinkExecutions.FindControl("F_SRNNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
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
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LinkExecutions_SRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SRNNo As Int32 = CType(aVal(1),Int32)
		Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(SRNNo)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
