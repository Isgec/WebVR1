<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrPaymentProcess.ascx.vb" Inherits="LC_vrPaymentProcess" %>
<asp:DropDownList 
  ID = "DDLvrPaymentProcess"
  DataSourceID = "OdsDdlvrPaymentProcess"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrPaymentProcess"
  Runat = "server" 
  ControlToValidate = "DDLvrPaymentProcess"
  Text = "Payment Process is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrPaymentProcess"
  runat = "server"
  TargetControlID = "DDLvrPaymentProcess"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrPaymentProcess"
  TypeName = "SIS.VR.vrPaymentProcess"
  SortParameterName = "OrderBy"
  SelectMethod = "UZ_vrPaymentProcessSelectList"
  Runat="server" />
