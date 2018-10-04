Partial Class AF_vrLorryReceiptStatus
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptStatus.Init
    DataClassName = "AvrLorryReceiptStatus"
    SetFormView = FVvrLorryReceiptStatus
  End Sub
  Protected Sub TBLvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptStatus.Init
    SetToolBar = TBLvrLorryReceiptStatus
  End Sub
  Protected Sub FVvrLorryReceiptStatus_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptStatus.DataBound
    SIS.VR.vrLorryReceiptStatus.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVvrLorryReceiptStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptStatus.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrLorryReceiptStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptStatus", mStr)
    End If
    If Request.QueryString("LRStatusID") IsNot Nothing Then
      CType(FVvrLorryReceiptStatus.FindControl("F_LRStatusID"), TextBox).Text = Request.QueryString("LRStatusID")
      CType(FVvrLorryReceiptStatus.FindControl("F_LRStatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
