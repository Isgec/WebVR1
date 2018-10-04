Partial Class AF_vrRequestExecution
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestExecution.Init
    DataClassName = "AvrRequestExecution"
    SetFormView = FVvrRequestExecution
  End Sub
  Protected Sub TBLvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestExecution.Init
    SetToolBar = TBLvrRequestExecution
  End Sub
  Protected Sub ODSvrRequestExecution_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrRequestExecution.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.VR.vrRequestExecution = CType(e.ReturnValue,SIS.VR.vrRequestExecution)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&SRNNo=" & oDC.SRNNo
			TBLvrRequestExecution.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVvrRequestExecution_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrRequestExecution.PreRender
    Dim oF_TransporterID_Display As Label  = FVvrRequestExecution.FindControl("F_TransporterID_Display")
    oF_TransporterID_Display.Text = String.Empty
    If Not Session("F_TransporterID_Display") Is Nothing Then
      If Session("F_TransporterID_Display") <> String.Empty Then
        oF_TransporterID_Display.Text = Session("F_TransporterID_Display")
      End If
    End If
    Dim oF_TransporterID As TextBox  = FVvrRequestExecution.FindControl("F_TransporterID")
    oF_TransporterID.Enabled = True
    oF_TransporterID.Text = String.Empty
    If Not Session("F_TransporterID") Is Nothing Then
      If Session("F_TransporterID") <> String.Empty Then
        oF_TransporterID.Text = Session("F_TransporterID")
      End If
    End If
    Dim oF_VehicleTypeID As LC_vrVehicleTypes = FVvrRequestExecution.FindControl("F_VehicleTypeID")
    oF_VehicleTypeID.Enabled = True
    oF_VehicleTypeID.SelectedValue = String.Empty
    If Not Session("F_VehicleTypeID") Is Nothing Then
      If Session("F_VehicleTypeID") <> String.Empty Then
        oF_VehicleTypeID.SelectedValue = Session("F_VehicleTypeID")
      End If
    End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrRequestExecution.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrRequestExecution") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrRequestExecution", mStr)
		End If
		CType(FVvrRequestExecution.FindControl("F_EstimatedDistance"), TextBox).Text = "0.00"
		CType(FVvrRequestExecution.FindControl("F_EstimatedRatePerKM"), TextBox).Text = "0.00"
		CType(FVvrRequestExecution.FindControl("F_EstimatedAmount"), TextBox).Text = "0.00"
		If Request.QueryString("SRNNo") IsNot Nothing Then
			CType(FVvrRequestExecution.FindControl("F_SRNNo"), TextBox).Text = Request.QueryString("SRNNo")
			CType(FVvrRequestExecution.FindControl("F_SRNNo"), TextBox).Enabled = False
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
