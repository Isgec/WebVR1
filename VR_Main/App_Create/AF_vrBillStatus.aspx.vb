Partial Class AF_vrBillStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBillStatus.Init
    DataClassName = "AvrBillStatus"
    SetFormView = FVvrBillStatus
  End Sub
  Protected Sub TBLvrBillStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBillStatus.Init
    SetToolBar = TBLvrBillStatus
  End Sub
  Protected Sub FVvrBillStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBillStatus.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrBillStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrBillStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrBillStatus", mStr)
    End If
    If Request.QueryString("BillStatusID") IsNot Nothing Then
      CType(FVvrBillStatus.FindControl("F_BillStatusID"), TextBox).Text = Request.QueryString("BillStatusID")
      CType(FVvrBillStatus.FindControl("F_BillStatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
