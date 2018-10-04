<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrLorryReceiptStatus.ascx.vb" Inherits="LC_vrLorryReceiptStatus" %>
<asp:DropDownList 
  ID = "DDLvrLorryReceiptStatus"
  DataSourceID = "OdsDdlvrLorryReceiptStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrLorryReceiptStatus"
  Runat = "server" 
  ControlToValidate = "DDLvrLorryReceiptStatus"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlvrLorryReceiptStatus"
  TypeName = "SIS.VR.vrLorryReceiptStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "vrLorryReceiptStatusSelectList"
  Runat="server" />
