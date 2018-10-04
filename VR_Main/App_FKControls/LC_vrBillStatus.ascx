<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrBillStatus.ascx.vb" Inherits="LC_vrBillStatus" %>
<asp:DropDownList 
  ID = "DDLvrBillStatus"
  DataSourceID = "OdsDdlvrBillStatus"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrBillStatus"
  Runat = "server" 
  ControlToValidate = "DDLvrBillStatus"
  Text = "Bill Status is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrBillStatus"
  runat = "server"
  TargetControlID = "DDLvrBillStatus"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrBillStatus"
  TypeName = "SIS.VR.vrBillStatus"
  SortParameterName = "OrderBy"
  SelectMethod = "vrBillStatusSelectList"
  Runat="server" />
