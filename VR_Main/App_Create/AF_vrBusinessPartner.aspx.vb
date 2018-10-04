Partial Class AF_vrBusinessPartner
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBusinessPartner.Init
    DataClassName = "AvrBusinessPartner"
    SetFormView = FVvrBusinessPartner
  End Sub
  Protected Sub TBLvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBusinessPartner.Init
    SetToolBar = TBLvrBusinessPartner
  End Sub
  Protected Sub FVvrBusinessPartner_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBusinessPartner.DataBound
    SIS.VR.vrBusinessPartner.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVvrBusinessPartner_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBusinessPartner.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrBusinessPartner.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrBusinessPartner") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrBusinessPartner", mStr)
    End If
    If Request.QueryString("BPID") IsNot Nothing Then
      CType(FVvrBusinessPartner.FindControl("F_BPID"), TextBox).Text = Request.QueryString("BPID")
      CType(FVvrBusinessPartner.FindControl("F_BPID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validatePK_vrBusinessPartner(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim BPID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(BPID)
    If Not oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record allready exists." 
    End If
    Return mRet
  End Function

End Class
