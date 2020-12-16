Partial Class AF_vrFreightBudgetProject
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrFreightBudgetProject.Init
    DataClassName = "AvrFreightBudgetProject"
    SetFormView = FVvrFreightBudgetProject
  End Sub
  Protected Sub TBLvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrFreightBudgetProject.Init
    SetToolBar = TBLvrFreightBudgetProject
  End Sub
  Protected Sub FVvrFreightBudgetProject_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrFreightBudgetProject.DataBound
    SIS.VR.vrFreightBudgetProject.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVvrFreightBudgetProject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrFreightBudgetProject.PreRender
    Dim oF_ProjectID_Display As Label  = FVvrFreightBudgetProject.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVvrFreightBudgetProject.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_FreightBudgetProjectID_Display As Label  = FVvrFreightBudgetProject.FindControl("F_FreightBudgetProjectID_Display")
    oF_FreightBudgetProjectID_Display.Text = String.Empty
    If Not Session("F_FreightBudgetProjectID_Display") Is Nothing Then
      If Session("F_FreightBudgetProjectID_Display") <> String.Empty Then
        oF_FreightBudgetProjectID_Display.Text = Session("F_FreightBudgetProjectID_Display")
      End If
    End If
    Dim oF_FreightBudgetProjectID As TextBox  = FVvrFreightBudgetProject.FindControl("F_FreightBudgetProjectID")
    oF_FreightBudgetProjectID.Enabled = True
    oF_FreightBudgetProjectID.Text = String.Empty
    If Not Session("F_FreightBudgetProjectID") Is Nothing Then
      If Session("F_FreightBudgetProjectID") <> String.Empty Then
        oF_FreightBudgetProjectID.Text = Session("F_FreightBudgetProjectID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrFreightBudgetProject.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrFreightBudgetProject") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrFreightBudgetProject", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVvrFreightBudgetProject.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVvrFreightBudgetProject.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FreightBudgetProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_FreightBudgetProject_ProjectID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_FreightBudgetProject_FrBdProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FreightBudgetProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(FreightBudgetProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
