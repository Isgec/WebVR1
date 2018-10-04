Partial Class AF_vrTransporters
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporters.Init
    DataClassName = "AvrTransporters"
    SetFormView = FVvrTransporters
  End Sub
  Protected Sub TBLvrTransporters_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrTransporters.Init
    SetToolBar = TBLvrTransporters
  End Sub
  Protected Sub FVvrTransporters_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrTransporters.PreRender
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrTransporters.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrTransporters") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrTransporters", mStr)
    End If
    If Request.QueryString("TransporterID") IsNot Nothing Then
      CType(FVvrTransporters.FindControl("F_TransporterID"), TextBox).Text = Request.QueryString("TransporterID")
      CType(FVvrTransporters.FindControl("F_TransporterID"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_vrTransporters(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim TransporterID As String = CType(aVal(1),String)
		Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
    If Not oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
