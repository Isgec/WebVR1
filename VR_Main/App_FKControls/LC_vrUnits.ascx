<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrUnits.ascx.vb" Inherits="LC_vrUnits" %>
<asp:DropDownList 
  ID = "DDLvrUnits"
  DataSourceID = "OdsDdlvrUnits"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrUnits"
  Runat = "server" 
  ControlToValidate = "DDLvrUnits"
  Text = "Units is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrUnits"
  runat = "server"
  TargetControlID = "DDLvrUnits"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrUnits"
  TypeName = "SIS.VR.vrUnits"
  SortParameterName = "OrderBy"
  SelectMethod = "vrUnitsSelectList"
  Runat="server" />
