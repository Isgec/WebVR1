Partial Class GF_vrVehicleTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrVehicleTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?VehicleTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrVehicleTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrVehicleTypes.RowCommand
		If e.CommandName.ToLower = "lgedit".ToLower Then
			Try
				Dim VehicleTypeID As Int32 = GVvrVehicleTypes.DataKeys(e.CommandArgument).Values("VehicleTypeID")  
				Dim RedirectUrl As String = TBLvrVehicleTypes.EditUrl & "?VehicleTypeID=" & VehicleTypeID
				Response.Redirect(RedirectUrl)
			Catch ex As Exception
			End Try
		End If
  End Sub
  Protected Sub GVvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrVehicleTypes.Init
    DataClassName = "GvrVehicleTypes"
    SetGridView = GVvrVehicleTypes
  End Sub
  Protected Sub TBLvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleTypes.Init
    SetToolBar = TBLvrVehicleTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
