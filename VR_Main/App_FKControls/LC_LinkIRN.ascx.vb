﻿
Partial Class LC_LinkIRN
  Inherits System.Web.UI.UserControl
  Public Event Cancelled()
  Public Event Execute(IRNo As String)
  Public Property Project As String
    Get
      If ViewState("Project") IsNot Nothing Then
        Return Convert.ToString(ViewState("Project"))
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("Project", value)
    End Set
  End Property
  Public Property Supplier As String
    Get
      If ViewState("Supplier") IsNot Nothing Then
        Return Convert.ToString(ViewState("Supplier"))
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("Supplier", value)
    End Set
  End Property
  Public Sub Show(ProjectID As String, SupplierID As String, Optional BillNo As String = "", Optional BillDate As String = "")
    Project = ProjectID
    Supplier = SupplierID
    HeaderText.Text = "IRN List: " & SupplierID
    ODSirnList.SelectParameters("ShowAll").DefaultValue = F_ShowAll.Checked
    ODSirnList.SelectParameters("ProjectID").DefaultValue = ProjectID
    ODSirnList.SelectParameters("SupplierID").DefaultValue = SupplierID
    ODSirnList.SelectParameters("BillNo").DefaultValue = BillNo
    ODSirnList.SelectParameters("BillDate").DefaultValue = BillDate
    GVirnList.DataBind()
    mPopup.Show()
  End Sub
  Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
    Try
      Dim IRNo As String = ""
      'Get From Grid
      RaiseEvent Execute(IRNo)
      mPopup.Hide()
    Catch ex As Exception
      'Raise error
    End Try
  End Sub

  Private Sub GVirnList_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVirnList.RowCommand
    If e.CommandName.ToLower() = "LgSelect".ToLower Then
      Dim IRNO As String = GVirnList.DataKeys(e.CommandArgument).Values("IRNO")
      RaiseEvent Execute(IRNO)
      mPopup.Hide()
    End If
  End Sub

  Public Property DisplayContent As Panel
    Get
      Return modalContent
    End Get
    Set(value As Panel)
      modalContent = value
    End Set
  End Property
  Protected Sub F_ShowAll_CheckedChanged(sender As Object, e As EventArgs)
    ODSirnList.SelectParameters("ShowAll").DefaultValue = F_ShowAll.Checked
    ODSirnList.SelectParameters("ProjectID").DefaultValue = Project
    ODSirnList.SelectParameters("SupplierID").DefaultValue = Supplier
    ODSirnList.SelectParameters("BillNo").DefaultValue = ""
    ODSirnList.SelectParameters("BillDate").DefaultValue = ""
    GVirnList.DataBind()
    mPopup.Show()
  End Sub
End Class
