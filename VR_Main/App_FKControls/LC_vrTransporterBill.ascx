<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrTransporterBill.ascx.vb" Inherits="LC_vrTransporterBill" %>
<asp:DropDownList 
  ID = "DDLvrTransporterBill"
  DataSourceID = "OdsDdlvrTransporterBill"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrTransporterBill"
  Runat = "server" 
  ControlToValidate = "DDLvrTransporterBill"
  Text = "IR is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrTransporterBill"
  runat = "server"
  TargetControlID = "DDLvrTransporterBill"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrTransporterBill"
  TypeName = "SIS.VR.vrTransporterBill"
  SortParameterName = "OrderBy"
  SelectMethod = "vrTransporterBillSelectList"
  Runat="server" />
