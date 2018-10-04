<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrRequestStates.ascx.vb" Inherits="LC_vrRequestStates" %>
<asp:DropDownList 
  ID = "DDLvrRequestStates"
  DataSourceID = "OdsDdlvrRequestStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrRequestStates"
  Runat = "server" 
  ControlToValidate = "DDLvrRequestStates"
  Text = "Request States is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrRequestStates"
  runat = "server"
  TargetControlID = "DDLvrRequestStates"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrRequestStates"
  TypeName = "SIS.VR.vrRequestStates"
  SortParameterName = "OrderBy"
  SelectMethod = "vrRequestStatesSelectList"
  Runat="server" />
