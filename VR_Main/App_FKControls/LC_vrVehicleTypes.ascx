<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrVehicleTypes.ascx.vb" Inherits="LC_vrVehicleTypes" %>
<tt>
<asp:DropDownList 
  ID = "DDLvrVehicleTypes"
  DataSourceID = "OdsDdlvrVehicleTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="400px"
  CssClass = "myddl"
  Font-Names="Courier"
  Runat="server" /></tt>
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrVehicleTypes"
  Runat = "server" 
  ControlToValidate = "DDLvrVehicleTypes"
  Text = "Vehicle Types is required."
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<AJX:ListSearchExtender
  ID="DDSEvrVehicleTypes"
  runat = "server"
  TargetControlID = "DDLvrVehicleTypes"
  PromptCssClass="ddsearchprompt">
</AJX:ListSearchExtender>
<asp:ObjectDataSource 
  ID = "OdsDdlvrVehicleTypes"
  TypeName = "SIS.VR.vrVehicleTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "vrVehicleTypesSelectList"
  Runat="server" />
