<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_tdpur401.ascx.vb" Inherits="LC_tdpur401" %>
<asp:DropDownList 
  ID = "DDLtdpur401"
  DataSourceID = "OdsDdltdpur401"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatortdpur401"
  Runat = "server" 
  ControlToValidate = "DDLtdpur401"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdltdpur401"
  TypeName = "SIS.TDPUR.tdpur401"
  SortParameterName = "OrderBy"
  SelectMethod = "tdpur401SelectList"
  Runat="server" />
