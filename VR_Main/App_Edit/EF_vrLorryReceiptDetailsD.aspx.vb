Partial Class EF_vrLorryReceiptDetailsD
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
  Protected Sub ODSvrLorryReceiptDetailsD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceiptDetailsD.Selected
    Dim tmp As SIS.VR.vrLorryReceiptDetailsD = CType(e.ReturnValue, SIS.VR.vrLorryReceiptDetailsD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetailsD.Init
    DataClassName = "EvrLorryReceiptDetailsD"
    SetFormView = FVvrLorryReceiptDetailsD
  End Sub
  Protected Sub TBLvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetailsD.Init
    SetToolBar = TBLvrLorryReceiptDetailsD
  End Sub
  Protected Sub FVvrLorryReceiptDetailsD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetailsD.PreRender
    TBLvrLorryReceiptDetailsD.EnableSave = Editable
    TBLvrLorryReceiptDetailsD.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLorryReceiptDetailsD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptDetailsD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptDetailsD", mStr)
    End If
  End Sub

End Class
