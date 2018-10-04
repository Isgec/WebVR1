Partial Class EF_vrBillStatus
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBillStatus.Init
    DataClassName = "EvrBillStatus"
    SetFormView = FVvrBillStatus
  End Sub
  Protected Sub TBLvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBillStatus.Init
    SetToolBar = TBLvrBillStatus
  End Sub
  Protected Sub FVvrBillStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBillStatus.PreRender
		TBLvrBillStatus.PrintUrl &= Request.QueryString("BillStatusID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrBillStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrBillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrBillStatus", mStr)
    End If
  End Sub

End Class
