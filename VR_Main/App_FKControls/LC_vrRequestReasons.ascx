<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrRequestReasons.ascx.vb" Inherits="LC_vrRequestReasons" %>
<asp:DropDownList 
  ID = "DDLvrRequestReasons"
  DataSourceID = "OdsDdlvrRequestReasons"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrRequestReasons"
  Runat = "server" 
  ControlToValidate = "DDLvrRequestReasons"
  Text = "Executer Reason is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrRequestReasons"
  runat = "server"
  TargetControlID = "DDLvrRequestReasons"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrRequestReasons"
  TypeName = "SIS.VR.vrRequestReasons"
  SortParameterName = "OrderBy"
  SelectMethod = "vrRequestReasonsSelectList"
  Runat="server" />
