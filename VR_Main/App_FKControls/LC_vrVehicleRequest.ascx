<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrVehicleRequest.ascx.vb" Inherits="LC_vrVehicleRequest" %>
<asp:DropDownList 
  ID = "DDLvrVehicleRequest"
  DataSourceID = "OdsDdlvrVehicleRequest"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrVehicleRequest"
  Runat = "server" 
  ControlToValidate = "DDLvrVehicleRequest"
  Text = "Vehicle Request is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrVehicleRequest"
  runat = "server"
  TargetControlID = "DDLvrVehicleRequest"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrVehicleRequest"
  TypeName = "SIS.VR.vrVehicleRequest"
  SortParameterName = "OrderBy"
  SelectMethod = "vrVehicleRequestSelectList"
  Runat="server" />
