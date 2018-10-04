Partial Class EF_vrLorryReceiptStatus
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
  Protected Sub ODSvrLorryReceiptStatus_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceiptStatus.Selected
    Dim tmp As SIS.VR.vrLorryReceiptStatus = CType(e.ReturnValue, SIS.VR.vrLorryReceiptStatus)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptStatus.Init
    DataClassName = "EvrLorryReceiptStatus"
    SetFormView = FVvrLorryReceiptStatus
  End Sub
  Protected Sub TBLvrLorryReceiptStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptStatus.Init
    SetToolBar = TBLvrLorryReceiptStatus
  End Sub
  Protected Sub FVvrLorryReceiptStatus_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptStatus.PreRender
    TBLvrLorryReceiptStatus.EnableSave = Editable
    TBLvrLorryReceiptStatus.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLorryReceiptStatus.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptStatus") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptStatus", mStr)
    End If
  End Sub

End Class
