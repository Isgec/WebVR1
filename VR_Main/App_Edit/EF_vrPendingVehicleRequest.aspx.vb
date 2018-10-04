Partial Class EF_vrPendingVehicleRequest
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrPendingVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPendingVehicleRequest.Init
    DataClassName = "EvrPendingVehicleRequest"
    SetFormView = FVvrPendingVehicleRequest
  End Sub
  Protected Sub TBLvrPendingVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPendingVehicleRequest.Init
    SetToolBar = TBLvrPendingVehicleRequest
  End Sub
  Protected Sub FVvrPendingVehicleRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPendingVehicleRequest.PreRender
		TBLvrPendingVehicleRequest.PrintUrl &= Request.QueryString("RequestNo") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrPendingVehicleRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrPendingVehicleRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrPendingVehicleRequest", mStr)
    End If
  End Sub

End Class
