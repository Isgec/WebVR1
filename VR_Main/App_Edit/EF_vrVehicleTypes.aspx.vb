Partial Class EF_vrVehicleTypes
  Inherits SIS.SYS.UpdateBase
  Protected Sub FVvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleTypes.Init
    DataClassName = "EvrVehicleTypes"
    SetFormView = FVvrVehicleTypes
  End Sub
  Protected Sub TBLvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleTypes.Init
    SetToolBar = TBLvrVehicleTypes
  End Sub
  Protected Sub FVvrVehicleTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleTypes.PreRender
		TBLvrVehicleTypes.PrintUrl &= Request.QueryString("VehicleTypeID") & "|"
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrVehicleTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVehicleTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVehicleTypes", mStr)
    End If
  End Sub
  Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete
    With FVvrVehicleTypes
      Dim oDC As CheckBox = .FindControl("F_DefineCapacity")
      Dim oDD As CheckBox = .FindControl("F_DefineDimention")
      Dim oEMiC As CheckBox = .FindControl("F_EnforceMinimumCapacity")
      Dim oEMaC As CheckBox = .FindControl("F_EnforceMaximumCapacity")
      Dim oEMiD As CheckBox = .FindControl("F_EnforceMinimumDimention")
      Dim oEMaD As CheckBox = .FindControl("F_EnforceMaximumDimention")
      Dim sb As New StringBuilder
      With sb
        .AppendLine("<script type=""text/javascript"">")
        .AppendLine("  script_Enforce.DefineCapacity($get('" & oDC.ClientID & "'));")
        .AppendLine("  script_Enforce.DefineDimention($get('" & oDD.ClientID & "'));")
        .AppendLine("  script_Enforce.EnforceMinimumCapacity($get('" & oEMiC.ClientID & "'));")
        .AppendLine("  script_Enforce.EnforceMaximumCapacity($get('" & oEMaC.ClientID & "'));")
        .AppendLine("  script_Enforce.EnforceMinimumDimention($get('" & oEMiD.ClientID & "'));")
        .AppendLine("  script_Enforce.EnforceMaximumDimention($get('" & oEMaD.ClientID & "'));")
        .AppendLine("</script>")
      End With
      If Not Page.ClientScript.IsStartupScriptRegistered("scriptEnf") Then
        Page.ClientScript.RegisterStartupScript(GetType(System.String), "scriptEnf", sb.ToString)
      End If
    End With

  End Sub
End Class
