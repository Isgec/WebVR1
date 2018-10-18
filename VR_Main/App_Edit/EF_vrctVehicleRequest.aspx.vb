Imports System.Web.Script.Serialization
Partial Class EF_vrctVehicleRequest
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
  Protected Sub ODSvrctVehicleRequest_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrctVehicleRequest.Selected
    Dim tmp As SIS.VR.vrctVehicleRequest = CType(e.ReturnValue, SIS.VR.vrctVehicleRequest)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrctVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrctVehicleRequest.Init
    DataClassName = "EvrctVehicleRequest"
    SetFormView = FVvrctVehicleRequest
  End Sub
  Protected Sub TBLvrctVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrctVehicleRequest.Init
    SetToolBar = TBLvrctVehicleRequest
  End Sub
  Protected Sub FVvrctVehicleRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrctVehicleRequest.PreRender
    TBLvrctVehicleRequest.EnableSave = Editable
    TBLvrctVehicleRequest.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrctVehicleRequest.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrctVehicleRequest") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrctVehicleRequest", mStr)
    End If
  End Sub

End Class
