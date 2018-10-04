<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrTransporters.ascx.vb" Inherits="LC_vrTransporters" %>
<asp:DropDownList 
  ID = "DDLvrTransporters"
  DataSourceID = "OdsDdlvrTransporters"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrTransporters"
  Runat = "server" 
  ControlToValidate = "DDLvrTransporters"
  Text = "Transporters is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrTransporters"
  runat = "server"
  TargetControlID = "DDLvrTransporters"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrTransporters"
  TypeName = "SIS.VR.vrTransporters"
  SortParameterName = "OrderBy"
  SelectMethod = "vrTransportersSelectList"
  Runat="server" />
