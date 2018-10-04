Partial Class PageSearchBar
  Inherits IpsBar
  Private _SearchUrl As String = ""
  Private _SearchContext As String = ""
  Private _EditUrl As String = ""
  Private _BarText As String = ""
  Public Sub SetUniqueID(ByVal prefix As String)
    MaskedEditExtenderPageSize.ID = prefix & MaskedEditExtenderPageSize.ID
    MaskedEditValidatorPageSize.ID = prefix & MaskedEditValidatorPageSize.ID
    MaskedEditValidatorPageSize.ControlExtender = MaskedEditExtenderPageSize.ID
    MaskedEditExtenderCurrentPage.ID = prefix & MaskedEditExtenderCurrentPage.ID
  End Sub
  Public Property BarText() As String
    Get
      Return _BarText
    End Get
    Set(ByVal value As String)
      _BarText = value
      txtBar.Text = value
    End Set
  End Property
  Public Property SearchState() As Boolean
    Get
      Return DisableSearch.Checked
    End Get
    Set(ByVal value As Boolean)
      DisableSearch.Checked = value
    End Set
  End Property
  Public Property EnableSearch() As Boolean
    Get
      Return CmdSearch.Enabled
    End Get
    Set(ByVal value As Boolean)
      CmdSearch.Enabled = value
      With CmdSearch
        If .Enabled Then .ImageUrl = .ImageUrl.Replace("1", "0") Else .ImageUrl = .ImageUrl.Replace("0", "1")
      End With
    End Set
  End Property
  Public Property TotalRecords() As Integer
    Get
      Return _PageSizeButton.Text
    End Get
    Set(ByVal value As Integer)
      _PageSizeButton.Text = value
    End Set
  End Property
  Public Overrides Property RecordsPerPage() As Integer
    Get
      Return _PageSize.Text
    End Get
    Set(ByVal value As Integer)
      _PageSize.Text = value
    End Set
  End Property
  Public Overrides Property TotalPages() As Integer
    Get
      Return _TotalPages.Text
    End Get
    Set(ByVal value As Integer)
      _TotalPages.Text = value
    End Set
  End Property
  Public Overrides Property CurrentPage() As Integer
    Get
      Return _CurrentPage.Text
    End Get
    Set(ByVal value As Integer)
      _CurrentPage.Text = value + 1
    End Set
  End Property
  Public Property SearchContext() As String
    Get
      Return _SearchContext
    End Get
    Set(ByVal value As String)
      _SearchContext = value
    End Set
  End Property
  Private _SearchValidationGroup As String = ""
  Public Property SearchValidationGroup() As String
    Get
      Return _SearchValidationGroup
    End Get
    Set(ByVal value As String)
      _SearchValidationGroup = value
      CmdSearch.ValidationGroup = value
      rfvst.ValidationGroup = value
      SearchTextBox.ValidationGroup = value
    End Set
  End Property
  Public Property EditUrl() As String
    Get
      Return _EditUrl
    End Get
    Set(ByVal value As String)
      _EditUrl = value
    End Set
  End Property
  Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdSearch.Click
    If Not SearchTextBox.Text = String.Empty Then
      DisableSearch.Enabled = True
      DisableSearch.Checked = True
      RaiseSearchClicked(SearchTextBox.Text, True)
    End If
  End Sub
  Protected Sub DisableSearch_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DisableSearch.CheckedChanged
    DisableSearch.Enabled = False
    DisableSearch.Checked = False
    RaiseSearchClicked(SearchTextBox.Text, False)
  End Sub
  Protected Sub _CurrentPage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _CurrentPage.TextChanged
    RaisePageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub navFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navFirst.Click
    RaisePageChanged(0, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub navPrev_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navPrev.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    If cp - 1 >= 1 Then
      RaisePageChanged(cp - 2, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navNext.Click
    Dim cp As Integer = Convert.ToInt32(_CurrentPage.Text)
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    If cp + 1 <= lp Then
      RaisePageChanged(cp, Convert.ToInt32(_PageSize.Text))
    End If
  End Sub
  Protected Sub navLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles navLast.Click
    Dim lp As Integer = Convert.ToInt32(_TotalPages.Text)
    RaisePageChanged(lp - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub _PageSizeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _PageSizeButton.Click
    RaisePageChanged(Convert.ToInt32(_CurrentPage.Text) - 1, Convert.ToInt32(_PageSize.Text))
  End Sub
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If Not Page.IsPostBack And Not Page.IsCallback Then
      Try
        SIS.SYS.Utilities.SessionManager.PushNavBar(System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.Url.AbsolutePath), Request.UrlReferrer.AbsoluteUri)
      Catch ex As Exception
        SIS.SYS.Utilities.SessionManager.DestroySessionEnvironement()
        Response.Redirect("~/SISError.aspx")
      End Try
    End If
  End Sub
End Class
