<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrVehicleRequest.aspx.vb" Inherits="AF_vrVehicleRequest" title="Add: Vehicle Request" %>
<asp:Content ID="CPHvrVehicleRequest" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Add: Vehicle Request"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLvrVehicleRequest" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLvrVehicleRequest"
            ToolType="lgNMAdd"
            InsertAndStay="False"
            AfterInsertURL="~/VR_Main/App_Edit/EF_vrVehicleRequest.aspx"
            ValidationGroup="vrVehicleRequest"
            runat="server" />
          <asp:FormView ID="FVvrVehicleRequest"
            runat="server"
            DataKeyNames="RequestNo"
            DataSourceID="ODSvrVehicleRequest"
            DefaultMode="Insert" CssClass="sis_formview">
            <InsertItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <asp:Label ID="L_ErrMsgvrVehicleRequest" runat="server" ClientIDMode="Static" ForeColor="Red" BackColor="Yellow" BorderColor="Orange" BorderStyle="Solid" BorderWidth="1pt" Font-Bold="true"  Text=""></asp:Label>
                 <table style="margin:auto;border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_RequestNo" ForeColor="#CC6633" runat="server" Text="Request No :" /></b>
                    </td>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <asp:TextBox ID="F_RequestNo" Enabled="False" CssClass="mypktxt" Width="70px" runat="server" Text="0" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ERPPONumber" runat="server" Text="ERP PO Number :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_ERPPONumber"
                              Text='<%# Bind("ERPPONumber") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="script_vrVehicleRequest.validate_ERPPONumber(this);"
                              ToolTip="Enter value for ERP PO Number."
                              MaxLength="9"
                              Width="70px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVERPPONumber"
                              runat="server"
                              ControlToValidate="F_ERPPONumber"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="**"
                              ForeColor="red"
                              Display="Dynamic"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                            <asp:Label ID="D_ERPPONumber" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="F_BuyerInERP" runat="server" Style="display: none" Text='<%# Bind("BuyerInERP") %>'></asp:TextBox>
                          </td>
                        </tr>
                      </table>
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_RequestDescription" runat="server" Text="Request Description :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_RequestDescription"
                        Text='<%# Bind("RequestDescription") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrVehicleRequest"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Request Description."
                        MaxLength="50"
                        Width="250px"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVRequestDescription"
                        runat="server"
                        ControlToValidate="F_RequestDescription"
                        Text="<div class='errorLG'>Required!</div>"
                        ErrorMessage="[Required!]"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ForeColor="red"
                        ValidationGroup="vrVehicleRequest"
                        SetFocusOnError="true" />
                      <asp:TextBox ID="F_DeliveryTerm" runat="server" ClientIDMode="static" CssClass="dmytxt" Width="60px" Enabled="false"></asp:TextBox>
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_SupplierID"
                        CssClass="dmytxt"
                        Width="92px"
                        Text='<%# Bind("SupplierID") %>'
                        ClientIDMode="Static"
                        Enabled="False"
                        runat="Server" />
                      <asp:Label
                        ID="F_SupplierID_Display"
                        Text='<%# Eval("IDM_Vendors5_Description") %>'
                        ClientIDMode="Static"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" />
                      </b>
                    </td>
                    <td>
                      <asp:TextBox 
                        ID="F_ProjectID" 
                        runat="Server" 
                        Text='<%# Bind("ProjectID") %>'
                        Enabled="false"
                        CssClass="dmytxt" 
                        ClientIDMode="Static"
                        Width="62px" />
                      <asp:Label 
                        ID="F_ProjectID_Display" 
                        runat="Server" 
                        ClientIDMode="Static"
                        Text='<%# Eval("IDM_Projects4_Description") %>' />
                      <asp:DropDownList 
                        ID="F_ProjectType" 
                        runat="Server" 
                        CssClass="dmyddl" 
                        ClientIDMode="Static"
                        SelectedValue='<%# Bind("ProjectType") %>' 
                        ValidationGroup="vrVehicleRequest" 
                        Enabled="false"
                        Width="100px">
                        <asp:ListItem Value="Domestic">Domestic</asp:ListItem>
                        <asp:ListItem Value="Export">Export</asp:ListItem>
                      </asp:DropDownList>

                    </td>
                  </tr>
                  <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_SupplierLocation" runat="server" Text="Supplier Location :" />
                      </b>
                    </td>
                    <td>
                      <asp:TextBox 
                        ID="F_SupplierLocation" 
                        runat="server" 
                        CssClass="mytxt" 
                        ClientIDMode="Static"
                        Height="40px" 
                        MaxLength="250" 
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        onfocus="return this.select();" 
                        Text='<%# Bind("SupplierLocation") %>'
                        TextMode="MultiLine" 
                        ToolTip="Enter Loading Point Address."
                        ValidationGroup="vrVehicleRequest" 
                        Width="350px" />
                      <asp:RequiredFieldValidator 
                        ID="RFVSupplierLocation" 
                        runat="server"
                        ControlToValidate="F_SupplierLocation" 
                        Display="Dynamic"
                        EnableClientScript="true" 
                        ErrorMessage="[Required!]" 
                        SetFocusOnError="true"
                        ForeColor="red"
                        Text="<div class='errorLG'>Required!</div>" 
                        ValidationGroup="vrVehicleRequest" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_DeliveryLocation" runat="server" Text="Delivery Location :" />
                      </b>
                    </td>
                    <td>
                      <asp:TextBox 
                        ID="F_DeliveryLocation" 
                        runat="server" 
                        CssClass="mytxt" 
                        ClientIDMode="Static"
                        Height="40px" 
                        MaxLength="400" 
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        onfocus="return this.select();" 
                        Text='<%# Bind("DeliveryLocation") %>'
                        TextMode="MultiLine" 
                        ToolTip="Enter value for Delivery Location."
                        ValidationGroup="vrVehicleRequest" 
                        Width="350px" />
                      <asp:RequiredFieldValidator 
                        ID="RFVDeliveryLocation" 
                        runat="server"
                        ControlToValidate="F_DeliveryLocation" 
                        Display="Dynamic"
                        ForeColor="red"
                        EnableClientScript="true" 
                        ErrorMessage="[Required!]" 
                        SetFocusOnError="true"
                        Text="<div class='errorLG'>Required!</div>" 
                        ValidationGroup="vrVehicleRequest" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_FromLocation" runat="server" Text="From City :" /></b>
                    </td>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <asp:TextBox ID="F_FromLocation"
                              Text='<%# Bind("FromLocation") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              ToolTip="Enter value for From Location."
                              MaxLength="50"
                              Width="200px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVFromLocation"
                              runat="server"
                              ControlToValidate="F_FromLocation"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              ForeColor="red"
                              Display="Dynamic"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                          <td>
                            <b>
                              <asp:Label ID="L_fromPinCode" runat="server" Text="Pin :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_FromPinCode"
                              Text='<%# Bind("FromPinCode") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              MaxLength="6"
                              Width="72px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVFromPinCode"
                              runat="server"
                              ControlToValidate="F_FromPinCode"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              ForeColor="red"
                              Display="Dynamic"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                        </tr>
                      </table>
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ToLocation" runat="server" Text="To City :" /></b>
                    </td>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <asp:TextBox ID="F_ToLocation"
                              Text='<%# Bind("ToLocation") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              ToolTip="Enter value for To Location."
                              MaxLength="50"
                              Width="200px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVToLocation"
                              runat="server"
                              ControlToValidate="F_ToLocation"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              Display="Dynamic"
                              ForeColor="red"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                          <td>
                            <b>
                              <asp:Label ID="L_ToPinCode" runat="server" Text="Pin :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_ToPinCode"
                              Text='<%# Bind("F_ToPinCode") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              MaxLength="6"
                              Width="72px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVToPinCode"
                              runat="server"
                              ControlToValidate="F_ToPinCode"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              ForeColor="red"
                              Display="Dynamic"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" />
                      </b>
                    </td>
                    <td>
                      <asp:TextBox 
                        ID="F_ItemDescription" 
                        runat="server" 
                        CssClass="mytxt"
                        Height="40px"
                        MaxLength="500" 
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        onfocus="return this.select();" 
                        Text='<%# Bind("ItemDescription") %>'
                        TextMode="MultiLine" 
                        ToolTip="Enter value for Item Description."
                        ValidationGroup="vrVehicleRequest" 
                        Width="350px" />
                      <asp:RequiredFieldValidator 
                        ID="RFVItemDescription" 
                        runat="server"
                        ControlToValidate="F_ItemDescription" 
                        Display="Dynamic"
                        ForeColor="red"
                        EnableClientScript="true" 
                        ErrorMessage="[Required!]" 
                        SetFocusOnError="true"
                        Text="<div class='errorLG'>Required!</div>" 
                        ValidationGroup="vrVehicleRequest" />
                    </td>
                    <td></td>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="L_InvoiceValue" runat="server" Text="Supplier Invoice Value :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_InvoiceValue"
                              Text='<%# Bind("InvoiceValue") %>'
                              Style="text-align: right"
                              Width="70px"
                              CssClass="mytxt"
                              ValidationGroup="vrVehicleRequest"
                              MaxLength="15"
                              onfocus="return this.select();"
                              onblur="return dc(this,2);"
                              runat="server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
                  <tr>
                    <td style="text-align:center;">
                      <b>
                        <asp:Label ID="Label2" runat="server" Text="Cargo Dimension :" /></b>
                    </td>
                    <td>
                      <table width="100%" style="border: solid 1pt brown; background-color: gainsboro">
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="L_SizeUnit" runat="server" Text="Size Unit :" /></b>
                          </td>
                          <td>
                            <LGM:LC_vrUnits
                              ID="F_SizeUnit"
                              SelectedValue='<%# Bind("SizeUnit") %>'
                              OrderBy="Size"
                              DataTextField="DisplayField"
                              DataValueField="PrimaryKey"
                              IncludeDefault="true"
                              DefaultText="-- Select --"
                              Width="80px"
                              CssClass="myddl"
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_Length"
                              Text='<%# Bind("Length") %>'
                              Width="70px"
                              CssClass="mytxt"
                              Style="text-align: right"
                              ValidationGroup="vrVehicleRequest"
                              MaxLength="8"
                              onfocus="return this.select();"
                              onblur="return dc(this,2);"
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="L_Width" runat="server" Text="Width :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_Width"
                              Text='<%# Bind("Width") %>'
                              Width="70px"
                              CssClass="mytxt"
                              Style="text-align: right"
                              ValidationGroup="vrVehicleRequest"
                              MaxLength="8"
                              onfocus="return this.select();"
                              onblur="return dc(this,2);"
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_Height"
                              Text='<%# Bind("Height") %>'
                              Width="70px"
                              CssClass="mytxt"
                              Style="text-align: right"
                              ValidationGroup="vrVehicleRequest"
                              MaxLength="8"
                              onfocus="return this.select();"
                              onblur="return dc(this,2);"
                              runat="server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="Label1" runat="server" Text="Cargo Weight :" /></b>
                    </td>
                    <td>
                      <table width="500px" style="border: solid 1pt brown; background-color: gainsboro">
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_WeightUnit" runat="server" Text="Weight Unit :" /></b>
                          </td>
                          <td>
                            <LGM:LC_vrUnits
                              ID="F_WeightUnit"
                              SelectedValue='<%# Bind("WeightUnit") %>'
                              OrderBy="DisplayField"
                              DataTextField="DisplayField"
                              DataValueField="PrimaryKey"
                              IncludeDefault="true"
                              DefaultText="-- Select --"
                              Width="80px"
                              CssClass="myddl"
                              ValidationGroup="vrVehicleRequest"
                              RequiredFieldErrorMessage="*"
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_MaterialWeight"
                              Text='<%# Bind("MaterialWeight") %>'
                              Width="70px"
                              CssClass="mytxt"
                              Style="text-align: right"
                              MaxLength="20"
                              onfocus="return this.select();"
                              onblur="return dc(this,2);"
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="L_NoOfPackages" runat="server" Text="No. Of Packages :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_NoOfPackages"
                              Text='<%# Bind("NoOfPackages") %>'
                              Width="70px"
                              Style="text-align: right"
                              CssClass="mytxt"
                              ValidationGroup="vrVehicleRequest"
                              MaxLength="10"
                              onfocus="return this.select();"
                              onblur="return dc(this,0);"
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_VehicleRequiredOn" runat="server" Text="Vehicle Required On :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_VehicleRequiredOn"
                              Text='<%# Bind("VehicleRequiredOn") %>'
                              Width="70px"
                              CssClass="mytxt"
                              ValidationGroup="vrVehicleRequest"
                              onfocus="return this.select();"
                              runat="server" />
                            <asp:Image ID="ImageButtonVehicleRequiredOn" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                            <AJX:CalendarExtender
                              ID="CEVehicleRequiredOn"
                              TargetControlID="F_VehicleRequiredOn"
                              Format="dd/MM/yyyy"
                              runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehicleRequiredOn" />
                            <AJX:MaskedEditExtender
                              ID="MEEVehicleRequiredOn"
                              runat="server"
                              Mask="99/99/9999"
                              MaskType="Date"
                              CultureName="en-GB"
                              MessageValidatorTip="true"
                              InputDirection="LeftToRight"
                              ErrorTooltipEnabled="true"
                              TargetControlID="F_VehicleRequiredOn" />
                            <AJX:MaskedEditValidator
                              ID="MEVVehicleRequiredOn"
                              runat="server"
                              ControlToValidate="F_VehicleRequiredOn"
                              ControlExtender="MEEVehicleRequiredOn"
                              InvalidValueMessage="*"
                              EmptyValueMessage="*"
                              EmptyValueBlurredText="*"
                              Display="Dynamic"
                              TooltipMessage="*"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              IsValidEmpty="false"
                              ForeColor="red"
                              SetFocusOnError="true" />
                          </td>
                        </tr>

                      </table>
                    </td>
                  </tr>
                  <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
                    </td>
                    <td>
                      <LGM:LC_vrVehicleTypes
                        ID="F_VehicleTypeID"
                        SelectedValue='<%# Bind("VehicleTypeID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="400px"
                        CssClass="myddl"
                        ValidationGroup="vrVehicleRequest"
                        RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                        ForeColor="red"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ODCReasonID" runat="server" Text="ODC/Under Utilization Reason :" /></b>
                    </td>
                    <td>
                      <LGM:LC_vrODCReasons
                        ID="F_ODCReasonID"
                        SelectedValue='<%# Bind("ODCReasonID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="350px"
                        CssClass="myddl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_CustomInvoiceNo"
                        Text='<%# Bind("CustomInvoiceNo") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        MaxLength="100"
                        Width="350px" Height="40px" TextMode="MultiLine"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_Remarks"
                        Text='<%# Bind("Remarks") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        MaxLength="500"
                        Width="350px" Height="40px" TextMode="MultiLine"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_OverDimentionConsignement" ForeColor="#CC6633" runat="server" Text="O D C :" /></b>
                    </td>
                    <td>
                      <asp:CheckBox ID="F_OverDimentionConsignement"
                        Checked='<%# Bind("OverDimentionConsignement") %>'
                        Enabled="false"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_MaterialSize" ForeColor="#CC6633" runat="server" Text="Vehicle Utilization Status :" /></b>
                    </td>
                    <td>
                      <asp:Label ID="F_MaterialSize"
                        Text='<%# Bind("MaterialSize") %>'
                        CssClass="dmymsg"
                        Width="350px"
                        runat="server" />
                    </td>
                  </tr>
                  <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
                  <tr>
                    <td colspan="2">
                      <table>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_MICN" runat="server" Text="MICN Attended :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_MICN"
                              Checked='<%# Bind("MICN") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_CustomInvoiceIssued" runat="server" Text="Custom Invoice Attended :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_CustomInvoiceIssued"
                              Checked='<%# Bind("CustomInvoiceIssued") %>'
                              runat="server" />
                          </td>
                        </tr>
<%--                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_CT1Issued" runat="server" Text="CT-1 Attended :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_CT1Issued"
                              Checked='<%# Bind("CT1Issued") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ARE1Issued" runat="server" Text="ARE-1 Attended :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_ARE1Issued"
                              Checked='<%# Bind("ARE1Issued") %>'
                              runat="server" />
                          </td>
                        </tr>--%>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_DIIssued" runat="server" Text="DI-Attended :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_DIIssued"
                              Checked='<%# Bind("DIIssued") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_PaymentChecked" runat="server" Text="Payment Checked :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_PaymentChecked"
                              Checked='<%# Bind("PaymentChecked") %>'
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_GoodsPacked" runat="server" Text="Goods Packed :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_GoodsPacked"
                              Checked='<%# Bind("GoodsPacked") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_POApproved" runat="server" Text="PO Approved :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_POApproved"
                              Checked='<%# Bind("POApproved") %>'
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_WayBill" runat="server" Text="Way Bill :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_WayBill"
                              Checked='<%# Bind("WayBill") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_MarkingDetails" runat="server" Text="Marking Details :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_MarkingDetails"
                              Checked='<%# Bind("MarkingDetails") %>'
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_TarpaulineRequired" runat="server" Text="Tarpauline Required :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_TarpaulineRequired"
                              Checked='<%# Bind("TarpaulineRequired") %>'
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_PackageStckable" runat="server" Text="Package Stckable :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_PackageStckable"
                              Checked='<%# Bind("PackageStckable") %>'
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_OutOfContract" runat="server" ForeColor="Red" Text="Out Of Contract :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_OutOfContract"
                              Checked='<%# Bind("OutOfContract") %>'
                              runat="server" />
                          </td>
                          <td></td>
                          <td></td>
                        </tr>
                      </table>
                    </td>
                    <td style="vertical-align:top;">
                      <b>
                        <asp:Label ID="Label3" ForeColor="#CC6633" runat="server" Text="Site Person :" /></b>
                    </td>
                    <td style="vertical-align:top;" >
                      <table>
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="Label4" ForeColor="#CC6633" runat="server" Text="Name :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_SitePersonName"
                              Text='<%# Bind("SitePersonName") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              MaxLength="50"
                              Width="200px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVSitePersonName"
                              runat="server"
                              ControlToValidate="F_SitePersonName"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              Display="Dynamic"
                              ForeColor="red"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <b>
                              <asp:Label ID="Label5" ForeColor="#CC6633" runat="server" Text="Contact No :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_SitePersonContact"
                              Text='<%# Bind("SitePersonContact") %>'
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrVehicleRequest"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              MaxLength="50"
                              Width="200px"
                              runat="server" />
                            <asp:RequiredFieldValidator
                              ID="RFVSitePersonContact"
                              runat="server"
                              ControlToValidate="F_SitePersonContact"
                              Text="<div class='errorLG'>Required!</div>"
                              ErrorMessage="[Required!]"
                              Display="Dynamic"
                              ForeColor="red"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              SetFocusOnError="true" />
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  </table>
              </div>
            </InsertItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSvrVehicleRequest"
        DataObjectTypeName="SIS.VR.vrVehicleRequest"
        InsertMethod="UZ_vrVehicleRequestInsert"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.VR.vrVehicleRequest"
        SelectMethod="GetNewRecord"
        runat="server"></asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
