<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrVehicleTypes.ascx.vb" Inherits="LC_vrVehicleTypes" %>
<asp:DropDownList 
  ID = "DDLvrVehicleTypes"
  DataSourceID = "OdsDdlvrVehicleTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="400px"
  CssClass = "myddl"
  Font-Names="Courier"
  OnDataBound="DDLvrVehicleTypes_DataBound"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorvrVehicleTypes"
  Runat = "server" 
  ControlToValidate = "DDLvrVehicleTypes"
  Text = "<div class='errorLG'>Required!</div>"
  ErrorMessage = "[Required!]"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlvrVehicleTypes"
  TypeName = "SIS.VR.vrVehicleTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "vrVehicleTypesSelectList"
  Runat="server" />
