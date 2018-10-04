Partial Class RP_vrPaymentProcess
  Inherits System.Web.UI.Page
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrPaymentProcess.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim aVal() As String = Request.QueryString("pk").Split("|".ToCharArray)
		Dim SerialNo As Int32 = CType(aVal(0),Int32)
		Dim oVar As SIS.VR.vrPaymentProcess = SIS.VR.vrPaymentProcess.vrPaymentProcessGetByID(SerialNo)
    Dim oTbl As New Table
    oTbl.Width = 1000
    Dim oCol As TableCell = Nothing
    Dim oRow As TableRow = Nothing
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Serial No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.SerialNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Payment Description"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PaymentDescription
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "PTR No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "PTR Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "PTR Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.PTRAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Cheque No"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ChequeNo
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Cheque Date"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ChequeDate
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Cheque Amount"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ChequeAmount
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Processed By"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProcessedBy
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.aspnet_Users1_UserFullName
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Processed On"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = oVar.ProcessedOn
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oTbl.Rows.Add(oRow)
    oRow = New TableRow
    oCol = New TableCell
    oCol.Text = "Freezed"
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = IIf(oVar.Freezed, "YES", "NO")
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = ""
    oRow.Cells.Add(oCol)
    oCol = New TableCell
    oCol.Text = "Request Status ID"
    oRow.Cells.Add(oCol)
		oTbl.Rows.Add(oRow)
    oRow = New TableRow
    form1.Controls.Add(oTbl)
  End Sub
End Class
