Partial Class EF_vrBusinessPartner
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSvrBusinessPartner_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrBusinessPartner.Selected
    Dim tmp As SIS.VR.vrBusinessPartner = CType(e.ReturnValue, SIS.VR.vrBusinessPartner)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBusinessPartner.Init
    DataClassName = "EvrBusinessPartner"
    SetFormView = FVvrBusinessPartner
  End Sub
  Protected Sub TBLvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBusinessPartner.Init
    SetToolBar = TBLvrBusinessPartner
  End Sub
  Protected Sub FVvrBusinessPartner_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrBusinessPartner.PreRender
    TBLvrBusinessPartner.EnableSave = Editable
    TBLvrBusinessPartner.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrBusinessPartner.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrBusinessPartner") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrBusinessPartner", mStr)
    End If
  End Sub

End Class
