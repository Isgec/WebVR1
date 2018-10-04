<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrPendingVehicleRequest.ascx.vb" Inherits="LC_vrPendingVehicleRequest" %>
<asp:DropDownList 
  ID = "DDLvrPendingVehicleRequest"
  DataSourceID = "OdsDdlvrPendingVehicleRequest"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrPendingVehicleRequest"
  Runat = "server" 
  ControlToValidate = "DDLvrPendingVehicleRequest"
  Text = "Pending Vehicle Request is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrPendingVehicleRequest"
  runat = "server"
  TargetControlID = "DDLvrPendingVehicleRequest"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrPendingVehicleRequest"
  TypeName = "SIS.VR.vrPendingVehicleRequest"
  SortParameterName = "OrderBy"
  SelectMethod = "vrPendingVehicleRequestSelectList"
  Runat="server" />
