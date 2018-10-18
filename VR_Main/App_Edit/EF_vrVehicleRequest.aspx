<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrVehicleRequest.aspx.vb" Inherits="EF_vrVehicleRequest" title="Edit: Vehicle Request" %>
<asp:Content ID="CPHvrVehicleRequest" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabeltaBDLodging" runat="server" Text="&nbsp;Edit: Vehicle Request"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLvrVehicleRequest" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLvrVehicleRequest"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnablePrint="True"
            PrintUrl="../App_Print/RP_vrVehicleRequest.aspx?pk="
            ValidationGroup="vrVehicleRequest"
            runat="server" />
          <script type="text/javascript">
            var pcnt = 0;
            function print_report(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
              url = url + '?pk=' + o.alt;
              url = o.alt;
              window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
            function script_download(id, id1, typ) {
              pcnt = pcnt + 1;
              var nam = 'wdwd' + pcnt;
              var url = self.location.href.replace('App_Edit/EF_vrVehicleRequest.aspx', 'App_Downloads/filedownload.aspx');
              url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
              window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
          <asp:FormView ID="FVvrVehicleRequest"
            runat="server"
            DataKeyNames="RequestNo"
            DataSourceID="ODSvrVehicleRequest"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <asp:Label ID="L_ErrMsgvrVehicleRequest" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
                 <table style="margin:auto;border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_RequestNo" runat="server" ForeColor="#CC6633" Text="Request No :" /></b>
                    </td>
                    <td>
                      <table>
                        <tr>
                          <td>
                            <asp:TextBox ID="F_RequestNo"
                              Text='<%# Bind("RequestNo") %>'
                              ToolTip="Value of Request No."
                              Enabled="False"
                              CssClass="mypktxt"
                              Width="70px"
                              Style="text-align: right"
                              runat="server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ERPPONumber" runat="server" Text="ERP PO Number :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_ERPPONumber"
                              Text='<%# Bind("ERPPONumber") %>'
                              CssClass="dmytxt"
                              Enabled="False"
                              Width="70px"
                              runat="server" />
                            <asp:TextBox
                              ID="F_BuyerInERP"
                              Width="56px"
                              Text='<%# Bind("BuyerInERP") %>'
                              Enabled="False"
                              ToolTip='<%# Eval("aspnet_Users10_UserFullName") %>'
                              CssClass="dmytxt"
                              runat="Server" />
<%--                            <asp:Label
                              ID="F_BuyerInERP_Display"
                              CssClass="dmytxt"
                              Text='<%# Eval("aspnet_Users10_UserFullName") %>'
                              runat="Server" />--%>
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
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrVehicleRequest"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVRequestDescription"
                        runat="server"
                        ControlToValidate="F_RequestDescription"
                        Text="<div class='errorLG'>Required!</div>"
                        ErrorMessage="[Required!]"
                        ForeColor="red"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrVehicleRequest"
                        SetFocusOnError="true" />
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
                        Enabled="false"
                        runat="Server" />
                      <asp:Label
                        ID="F_SupplierID_Display"
                        Text='<%# Eval("IDM_Vendors5_Description") %>'
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
                        CssClass="dmytxt" 
                        Enabled="False"
                        Text='<%# Bind("ProjectID") %>'
                        Width="62px" />
                      <asp:Label 
                        ID="F_ProjectID_Display" 
                        runat="Server"
                        Text='<%# Eval("IDM_Projects4_Description") %>' />
                      <asp:DropDownList 
                        ID="F_ProjectType" 
                        runat="Server" 
                        CssClass="dmyddl"
                        SelectedValue='<%# Bind("ProjectType") %>' 
                        Enabled="False"
                        Width="80px">
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
                        ForeColor="red"
                        ErrorMessage="[Required!]" 
                        SetFocusOnError="true"
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
                        Height="40px" 
                        MaxLength="400" 
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        onfocus="return this.select();" 
                        Text='<%# Bind("DeliveryLocation") %>'
                        TextMode="MultiLine" 
                        ToolTip="Enter Delivery Point Address."
                        ValidationGroup="vrVehicleRequest" 
                        Width="350px" />
                      <asp:RequiredFieldValidator 
                        ID="RFVDeliveryLocation" 
                        runat="server"
                        ControlToValidate="F_DeliveryLocation" 
                        Display="Dynamic"
                        EnableClientScript="true" 
                        ForeColor="red"
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
                      <asp:TextBox ID="F_FromLocation"
                        Text='<%# Bind("FromLocation") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrVehicleRequest"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        MaxLength="50"
                        Width="350px"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVFromLocation"
                        runat="server"
                        ControlToValidate="F_FromLocation"
                        Text="<div class='errorLG'>Required!</div>"
                        ErrorMessage="[Required!]"
                        Display="Dynamic"
                        ForeColor="red"
                        EnableClientScript="true"
                        ValidationGroup="vrVehicleRequest"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ToLocation" runat="server" Text="To City :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_ToLocation"
                        Text='<%# Bind("ToLocation") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrVehicleRequest"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        MaxLength="50"
                        Width="350px"
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
                        ToolTip="Enter Item Description."
                        ValidationGroup="vrVehicleRequest" 
                        Width="350px" />
                      <asp:RequiredFieldValidator 
                        ID="RFVItemDescription" 
                        runat="server"
                        ControlToValidate="F_ItemDescription" 
                        Display="Dynamic"
                        EnableClientScript="true" 
                        ForeColor="red"
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
                    <td style="text-align:right;">
                      <b>
                        <asp:Label ID="Label2" runat="server" Text="Cargo Dimension :" /></b>
                    </td>
                    <td>
                      <table width="100%" style="border: solid 1pt brown; background-color:gainsboro">
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
                      <table width="500px" style="border: solid 1pt brown; background-color:gainsboro">
                        <tr>
                          <td>
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
                              RequiredFieldErrorMessage="Weight Unit is required."
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
                              InvalidValueMessage="Invalid Date"
                              EmptyValueMessage="<div class='errorLG'>Required!</div>"
                              EmptyValueBlurredText="[Required!]"
                              Display="Dynamic"
                              TooltipMessage="<div class='errorLG'>Required!</div>"
                              EnableClientScript="true"
                              ValidationGroup="vrVehicleRequest"
                              IsValidEmpty="false"
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
                        ToolTip="Custom Invoice No."
                        MaxLength="100"
                        Width="350px" 
                        Height="40px" 
                        TextMode="MultiLine"
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
                        ToolTip="Enter Remarks."
                        MaxLength="500"
                        Width="350px" 
                        Height="40px" 
                        TextMode="MultiLine"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label 
                          ID="L_OverDimentionConsignement" 
                          ForeColor="#CC6633" 
                          runat="server" 
                          Text="O D C :" /></b>
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
                        <tr>
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
                        </tr>
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
                              <asp:Label ID="L_OutOfContract" runat="server" ForeColor="Brown" Text="Out Of Contract :" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_OutOfContract"
                              Checked='<%# Bind("OutOfContract") %>'
                              runat="server" />
                          </td>
                          <td></td>
                          <td></td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_RequestedBy"
                              Width="56px"
                              Text='<%# Bind("RequestedBy") %>'
                              Enabled="False"
                              ToolTip="Value of Requested By."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_RequestedBy_Display"
                              Text='<%# Eval("aspnet_Users1_UserFullName") %>'
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_RequestedOn"
                              Text='<%# Bind("RequestedOn") %>'
                              ToolTip="Value of Requested On."
                              Enabled="False"
                              Width="100px"
                              CssClass="dmytxt"
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_RequesterDivisionID" runat="server" Text="Requester Division ID :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_RequesterDivisionID"
                              Width="42px"
                              Text='<%# Bind("RequesterDivisionID") %>'
                              Enabled="False"
                              ToolTip="Value of Requester Division ID."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_RequesterDivisionID_Display"
                              Text='<%# Eval("HRM_Divisions3_Description") %>'
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_RequestStatus" runat="server" Text="Request Status :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_RequestStatus"
                              Width="70px"
                              Text='<%# Bind("RequestStatus") %>'
                              Enabled="False"
                              ToolTip="Value of Request Status."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_RequestStatus_Display"
                              Text='<%# Eval("VR_RequestStates7_Description") %>'
                              runat="Server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                    <td></td>
                    <td>
                      <table>
                        <tr>
                          <td >
                            <asp:UpdatePanel ID="UPNLvrRequestAttachments" runat="server">
                              <ContentTemplate>
                                <table >
                                  <tr>
                                    <td class="sis_formview">
                                      <table id="F_Upload" runat="server" visible="<%# Editable %>">
                                        <tr>
                                          <td colspan="2" class="alignCenter">
                                            <asp:Label ID="L_FileUpload" runat="server" Font-Bold="true" Text="Attatch File"></asp:Label>
                                          </td>
                                        </tr>
                                        <tr>
                                          <td>
                                            <asp:FileUpload ID="F_FileUpload" runat="server" Width="150px" ToolTip="Attatch File" />
                                          </td>
                                          <td>
                                            <asp:Button ID="cmdFileUpload" Text="Upload File" runat="server" ToolTip="Click to upload file." CommandName="Upload" CommandArgument="" />
                                          </td>
                                        </tr>
                                      </table>
                                      <LGM:AttachmentBar
                                        ID="TBLvrRequestAttachments"
                                        ToolType="lgNMGrid"
                                        EditUrl="~/VR_Main/App_Edit/EF_vrRequestAttachments.aspx"
                                        AddPostBack="True"
                                        EnableExit="false"
                                        ValidationGroup="vrRequestAttachments"
                                        Skin="tbl_blue"
                                        Visible="false"
                                        AttachVisible="false" 
                                        runat="server" />
                                      <asp:UpdateProgress ID="UPGSvrRequestAttachments" runat="server" AssociatedUpdatePanelID="UPNLvrRequestAttachments" DisplayAfter="100">
                                        <ProgressTemplate>
                                          <span style="color: #ff0033">Loading...</span>
                                        </ProgressTemplate>
                                      </asp:UpdateProgress>
                                      <asp:GridView ID="GVvrRequestAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" Width="250px" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestAttachments" DataKeyNames="RequestNo,SerialNo">
                                        <Columns>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Delete" ToolTip="Delete Attachment." SkinID="delete" CommandName="lgDelete" CommandArgument='<%# Container.DataItemIndex %>' />
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                          </asp:TemplateField>
<%--                                          <asp:TemplateField HeaderText="SerialNo" SortExpression="SerialNo">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="alignright" />
                                            <ItemStyle CssClass="alignright" />
                                            <HeaderStyle Width="40px" />
                                          </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                            <ItemTemplate>
                                              <asp:LinkButton ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>' OnClientClick='<%# Eval("GetLink") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px" />
                                          </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                                        </EmptyDataTemplate>
                                      </asp:GridView>
                                      <asp:ObjectDataSource
                                        ID="ODSvrRequestAttachments"
                                        runat="server"
                                        DataObjectTypeName="SIS.VR.vrRequestAttachments"
                                        OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="vrRequestAttachmentsSelectList"
                                        TypeName="SIS.VR.vrRequestAttachments"
                                        SelectCountMethod="vrRequestAttachmentsSelectCount"
                                        SortParameterName="OrderBy" EnablePaging="True">
                                        <SelectParameters>
                                          <asp:ControlParameter ControlID="F_RequestNo" PropertyName="Text" Name="RequestNo" Type="Int32" Size="10" />
                                          <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                          <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                                        </SelectParameters>
                                      </asp:ObjectDataSource>
                                      <br />
                                    </td>
                                  </tr>
                                </table>
                              </ContentTemplate>
                              <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GVvrRequestAttachments" EventName="PageIndexChanged" />
                                <asp:PostBackTrigger ControlID="cmdFileUpload" />
                              </Triggers>
                            </asp:UpdatePanel>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
              </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelvrctVehicleRequest" runat="server" Text="&nbsp;List: CT-Vehicle Request"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrctVehicleRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrctVehicleRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrctVehicleRequest.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "vrctVehicleRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrctVehicleRequest" runat="server" AssociatedUpdatePanelID="UPNLvrctVehicleRequest" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrctVehicleRequest" SkinID="gv_silver" runat="server" DataSourceID="ODSvrctVehicleRequest" DataKeyNames="VRRequestNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
          <ItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("PONumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Reference" SortExpression="ItemReference">
          <ItemTemplate>
            <asp:Label ID="LabelItemReference" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemReference") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sub Item" SortExpression="ActivityID">
          <ItemTemplate>
            <asp:Label ID="LabelActivityID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ActivityID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle CssClass="alignCenter" Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
          <ItemTemplate>
            <asp:Label ID="LabelQuantity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Quantity") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Iref. Weight [Kg]" SortExpression="IrefWeight">
          <ItemTemplate>
            <asp:Label ID="LabelIrefWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IrefWeight") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Partial Or Full" SortExpression="PartialOrFull">
          <ItemTemplate>
            <asp:Label ID="LabelPartialOrFull" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PartialOrFull") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="% Progress" SortExpression="ProgressPercent">
          <ItemTemplate>
            <asp:Label ID="LabelProgressPercent" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProgressPercent") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Progress Weight [Kg]" SortExpression="ProgressWeight">
          <ItemTemplate>
            <asp:Label ID="LabelProgressWeight" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProgressWeight") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrctVehicleRequest"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrctVehicleRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrctVehicleRequestSelectList"
      TypeName = "SIS.VR.vrctVehicleRequest"
      SelectCountMethod = "vrctVehicleRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_RequestNo" PropertyName="Text" Name="VRRequestNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrctVehicleRequest" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>

            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSvrVehicleRequest"
        DataObjectTypeName="SIS.VR.vrVehicleRequest"
        SelectMethod="UZ_vrVehicleRequestGetByID"
        UpdateMethod="UZ_vrVehicleRequestUpdate"
        DeleteMethod="UZ_vrVehicleRequestDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.VR.vrVehicleRequest"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestNo" Name="RequestNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
