Imports System.Web.Script.Serialization
Partial Class EF_vrFreightBudgetProject
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
  Protected Sub ODSvrFreightBudgetProject_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrFreightBudgetProject.Selected
    Dim tmp As SIS.VR.vrFreightBudgetProject = CType(e.ReturnValue, SIS.VR.vrFreightBudgetProject)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrFreightBudgetProject.Init
    DataClassName = "EvrFreightBudgetProject"
    SetFormView = FVvrFreightBudgetProject
  End Sub
  Protected Sub TBLvrFreightBudgetProject_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrFreightBudgetProject.Init
    SetToolBar = TBLvrFreightBudgetProject
  End Sub
  Protected Sub FVvrFreightBudgetProject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrFreightBudgetProject.PreRender
    TBLvrFreightBudgetProject.EnableSave = Editable
    TBLvrFreightBudgetProject.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrFreightBudgetProject.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrFreightBudgetProject") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrFreightBudgetProject", mStr)
    End If
  End Sub

End Class
