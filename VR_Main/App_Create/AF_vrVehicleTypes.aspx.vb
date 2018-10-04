Partial Class AF_vrVehicleTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleTypes.Init
    DataClassName = "AvrVehicleTypes"
    SetFormView = FVvrVehicleTypes
  End Sub
  Protected Sub TBLvrVehicleTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleTypes.Init
    SetToolBar = TBLvrVehicleTypes
  End Sub
  Protected Sub ODSvrVehicleTypes_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrVehicleTypes.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.VR.vrVehicleTypes = CType(e.ReturnValue,SIS.VR.vrVehicleTypes)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&VehicleTypeID=" & oDC.VehicleTypeID
			TBLvrVehicleTypes.AfterInsertURL &= tmpURL 
		End If
  End Sub
  Protected Sub FVvrVehicleTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleTypes.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrVehicleTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVehicleTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVehicleTypes", mStr)
    End If
    If Request.QueryString("VehicleTypeID") IsNot Nothing Then
      CType(FVvrVehicleTypes.FindControl("F_VehicleTypeID"), TextBox).Text = Request.QueryString("VehicleTypeID")
      CType(FVvrVehicleTypes.FindControl("F_VehicleTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
