Imports System.Web.Script.Serialization
Imports System.Net

Partial Class GF_vrTransporters
  Inherits SIS.SYS.GridBase
  Protected Sub GVvrTransporters_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrTransporters.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TransporterID As String = GVvrTransporters.DataKeys(e.CommandArgument).Values("TransporterID")
        Dim RedirectUrl As String = TBLvrTransporters.EditUrl & "?TransporterID=" & TransporterID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "sprequest".ToLower Then
      Try
        Dim TransporterID As String = GVvrTransporters.DataKeys(e.CommandArgument).Values("TransporterID")
        Dim jsonStr As String = ""
        Dim otr As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
        Dim x As New SPApi.Transporter
        With x
          .carrierBranchName = otr.Address1Line & " " & otr.Address2Line
          .carrierLocation = otr.City
          .carrierName = otr.TransporterName
          .carrierUsername = otr.TransporterName
          .email = otr.EMailID
          .erpCode = otr.TransporterID
          .phone = ""
        End With
        Dim tmp As SPApi.SPResponse = SPApi.CreateTransporter(x, jsonStr)
      Catch ex As WebException
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", New JavaScriptSerializer().Serialize(ex.Message)), True)
      End Try
    End If
  End Sub
  Protected Sub GVvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrTransporters.Init
    DataClassName = "GvrTransporters"
    SetGridView = GVvrTransporters
  End Sub
  Protected Sub TBLvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporters.Init
    SetToolBar = TBLvrTransporters
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
