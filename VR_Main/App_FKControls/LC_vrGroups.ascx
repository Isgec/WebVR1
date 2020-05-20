<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrGroups.ascx.vb" Inherits="LC_vrGroups" %>
<asp:DropDownList 
  ID = "DDLvrGroups"
  DataSourceID = "OdsDdlvrGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrGroups"
  Runat = "server" 
  ControlToValidate = "DDLvrGroups"
  Text = "Groups is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlvrGroups"
  TypeName = "SIS.VR.vrGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "vrGroupsSelectList"
  Runat="server" />
