Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_tdpur401
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLtdpur401.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLtdpur401.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLtdpur401.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLtdpur401.CssClass
    End Get
    Set(ByVal value As String)
      DDLtdpur401.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLtdpur401.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLtdpur401.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatortdpur401.Text
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        RequiredFieldValidatortdpur401.Enabled = False
      Else
        RequiredFieldValidatortdpur401.Text = value
      End If
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatortdpur401.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatortdpur401.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLtdpur401.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLtdpur401.Enabled = value
      RequiredFieldValidatortdpur401.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLtdpur401.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLtdpur401.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLtdpur401.DataTextField
    End Get
    Set(ByVal value As String)
      DDLtdpur401.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLtdpur401.DataValueField
    End Get
    Set(ByVal value As String)
      DDLtdpur401.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLtdpur401.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLtdpur401.SelectedValue = String.Empty
      Else
        DDLtdpur401.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdltdpur401_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdltdpur401.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLtdpur401_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLtdpur401.DataBinding
    If _IncludeDefault Then
      DDLtdpur401.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLtdpur401_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLtdpur401.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
