<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrBusinessPartner.ascx.vb" Inherits="LC_vrBusinessPartner" %>
<asp:DropDownList 
  ID = "DDLvrBusinessPartner"
  DataSourceID = "OdsDdlvrBusinessPartner"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrBusinessPartner"
  Runat = "server" 
  ControlToValidate = "DDLvrBusinessPartner"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlvrBusinessPartner"
  TypeName = "SIS.VR.vrBusinessPartner"
  SortParameterName = "OrderBy"
  SelectMethod = "vrBusinessPartnerSelectList"
  Runat="server" />
