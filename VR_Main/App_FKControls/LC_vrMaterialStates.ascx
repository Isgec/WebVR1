<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrMaterialStates.ascx.vb" Inherits="LC_vrMaterialStates" %>
<asp:DropDownList 
  ID = "DDLvrMaterialStates"
  DataSourceID = "OdsDdlvrMaterialStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrMaterialStates"
  Runat = "server" 
  ControlToValidate = "DDLvrMaterialStates"
  Text = "Material States is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrMaterialStates"
  runat = "server"
  TargetControlID = "DDLvrMaterialStates"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrMaterialStates"
  TypeName = "SIS.VR.vrMaterialStates"
  SortParameterName = "OrderBy"
  SelectMethod = "vrMaterialStatesSelectList"
  Runat="server" />
