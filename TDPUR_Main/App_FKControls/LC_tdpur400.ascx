<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tdpur400.ascx.vb" Inherits="LC_tdpur400" %>
<asp:DropDownList 
  ID = "DDLtdpur400"
  DataSourceID = "OdsDdltdpur400"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortdpur400"
  Runat = "server" 
  ControlToValidate = "DDLtdpur400"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltdpur400"
  TypeName = "SIS.TDPUR.tdpur400"
  SortParameterName = "OrderBy"
  SelectMethod = "tdpur400SelectList"
  Runat="server" />
