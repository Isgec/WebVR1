Partial Class AF_vrTransporterBill
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporterBill.Init
    DataClassName = "AvrTransporterBill"
    SetFormView = FVvrTransporterBill
  End Sub
  Protected Sub TBLvrTransporterBill_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporterBill.Init
    SetToolBar = TBLvrTransporterBill
  End Sub
  Protected Sub ODSvrTransporterBill_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrTransporterBill.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.VR.vrTransporterBill = CType(e.ReturnValue,SIS.VR.vrTransporterBill)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&IRNo=" & oDC.IRNo
			TBLvrTransporterBill.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVvrTransporterBill_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporterBill.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrTransporterBill.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrTransporterBill") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrTransporterBill", mStr)
    End If
    If Request.QueryString("IRNo") IsNot Nothing Then
      CType(FVvrTransporterBill.FindControl("F_IRNo"), TextBox).Text = Request.QueryString("IRNo")
      CType(FVvrTransporterBill.FindControl("F_IRNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validatePK_vrTransporterBill(ByVal value As String) As String
		Return SIS.VR.vrTransporterBill.UZ_validatePK_vrTransporterBill(value)
	End Function

End Class
