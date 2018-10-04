Partial Class GF_vrLorryReceiptStatus
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrLorryReceiptStatus.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?LRStatusID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrLorryReceiptStatus_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceiptStatus.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim LRStatusID As Int32 = GVvrLorryReceiptStatus.DataKeys(e.CommandArgument).Values("LRStatusID")  
        Dim RedirectUrl As String = TBLvrLorryReceiptStatus.EditUrl & "?LRStatusID=" & LRStatusID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceiptStatus.Init
    DataClassName = "GvrLorryReceiptStatus"
    SetGridView = GVvrLorryReceiptStatus
  End Sub
  Protected Sub TBLvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptStatus.Init
    SetToolBar = TBLvrLorryReceiptStatus
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
