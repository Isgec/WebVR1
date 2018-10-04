<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrRequestExecution.ascx.vb" Inherits="LC_vrRequestExecution" %>
<asp:DropDownList 
  ID = "DDLvrRequestExecution"
  DataSourceID = "OdsDdlvrRequestExecution"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrRequestExecution"
  Runat = "server" 
  ControlToValidate = "DDLvrRequestExecution"
  Text = "Request Execution is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrRequestExecution"
  runat = "server"
  TargetControlID = "DDLvrRequestExecution"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrRequestExecution"
  TypeName = "SIS.VR.vrRequestExecution"
  SortParameterName = "OrderBy"
  SelectMethod = "vrRequestExecutionSelectList"
  Runat="server" />
