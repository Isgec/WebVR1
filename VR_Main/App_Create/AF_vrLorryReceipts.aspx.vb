Partial Class AF_vrLorryReceipts
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceipts.Init
    DataClassName = "AvrLorryReceipts"
    SetFormView = FVvrLorryReceipts
  End Sub
  Protected Sub TBLvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceipts.Init
    SetToolBar = TBLvrLorryReceipts
  End Sub
  Protected Sub ODSvrLorryReceipts_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceipts.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.VR.vrLorryReceipts = CType(e.ReturnValue,SIS.VR.vrLorryReceipts)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&ProjectID=" & oDC.ProjectID
      tmpURL &= "&MRNNo=" & oDC.MRNNo
      TBLvrLorryReceipts.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVvrLorryReceipts_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceipts.DataBound
    SIS.VR.vrLorryReceipts.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVvrLorryReceipts_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceipts.PreRender
    Dim oF_ProjectID_Display As Label  = FVvrLorryReceipts.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVvrLorryReceipts.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_RequestExecutionNo_Display As Label  = FVvrLorryReceipts.FindControl("F_RequestExecutionNo_Display")
    Dim oF_RequestExecutionNo As TextBox  = FVvrLorryReceipts.FindControl("F_RequestExecutionNo")
    Dim oF_TransporterID_Display As Label  = FVvrLorryReceipts.FindControl("F_TransporterID_Display")
    oF_TransporterID_Display.Text = String.Empty
    If Not Session("F_TransporterID_Display") Is Nothing Then
      If Session("F_TransporterID_Display") <> String.Empty Then
        oF_TransporterID_Display.Text = Session("F_TransporterID_Display")
      End If
    End If
    Dim oF_TransporterID As TextBox  = FVvrLorryReceipts.FindControl("F_TransporterID")
    oF_TransporterID.Enabled = True
    oF_TransporterID.Text = String.Empty
    If Not Session("F_TransporterID") Is Nothing Then
      If Session("F_TransporterID") <> String.Empty Then
        oF_TransporterID.Text = Session("F_TransporterID")
      End If
    End If
    Dim oF_CustomerID_Display As Label  = FVvrLorryReceipts.FindControl("F_CustomerID_Display")
    oF_CustomerID_Display.Text = String.Empty
    If Not Session("F_CustomerID_Display") Is Nothing Then
      If Session("F_CustomerID_Display") <> String.Empty Then
        oF_CustomerID_Display.Text = Session("F_CustomerID_Display")
      End If
    End If
    Dim oF_CustomerID As TextBox  = FVvrLorryReceipts.FindControl("F_CustomerID")
    oF_CustomerID.Enabled = True
    oF_CustomerID.Text = String.Empty
    If Not Session("F_CustomerID") Is Nothing Then
      If Session("F_CustomerID") <> String.Empty Then
        oF_CustomerID.Text = Session("F_CustomerID")
      End If
    End If
    Dim oF_VehicleTypeID As LC_vrVehicleTypes = FVvrLorryReceipts.FindControl("F_VehicleTypeID")
    oF_VehicleTypeID.Enabled = True
    oF_VehicleTypeID.SelectedValue = String.Empty
    If Not Session("F_VehicleTypeID") Is Nothing Then
      If Session("F_VehicleTypeID") <> String.Empty Then
        oF_VehicleTypeID.SelectedValue = Session("F_VehicleTypeID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrLorryReceipts.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceipts") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceipts", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVvrLorryReceipts.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVvrLorryReceipts.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("MRNNo") IsNot Nothing Then
      CType(FVvrLorryReceipts.FindControl("F_MRNNo"), TextBox).Text = Request.QueryString("MRNNo")
      CType(FVvrLorryReceipts.FindControl("F_MRNNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CustomerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceipts_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_VR_LorryReceipts_CustomerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CustomerID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(CustomerID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceipts_ExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RequestExecutionNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(RequestExecutionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceipts_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim TransporterID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
