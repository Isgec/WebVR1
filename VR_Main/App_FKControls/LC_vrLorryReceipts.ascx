<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrLorryReceipts.ascx.vb" Inherits="LC_vrLorryReceipts" %>
<asp:DropDownList 
  ID = "DDLvrLorryReceipts"
  DataSourceID = "OdsDdlvrLorryReceipts"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrLorryReceipts"
  Runat = "server" 
  ControlToValidate = "DDLvrLorryReceipts"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlvrLorryReceipts"
  TypeName = "SIS.VR.vrLorryReceipts"
  SortParameterName = "OrderBy"
  SelectMethod = "vrLorryReceiptsSelectList"
  Runat="server" />
