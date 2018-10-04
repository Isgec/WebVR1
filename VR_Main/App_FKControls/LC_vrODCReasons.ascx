<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrODCReasons.ascx.vb" Inherits="LC_vrODCReasons" %>
<asp:DropDownList 
  ID = "DDLvrODCReasons"
  DataSourceID = "OdsDdlvrODCReasons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrODCReasons"
  Runat = "server" 
  ControlToValidate = "DDLvrODCReasons"
  Text = "ODC Reasons is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrODCReasons"
  runat = "server"
  TargetControlID = "DDLvrODCReasons"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrODCReasons"
  TypeName = "SIS.VR.vrODCReasons"
  SortParameterName = "OrderBy"
  SelectMethod = "vrODCReasonsSelectList"
  Runat="server" />
