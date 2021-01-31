<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLorryReceipts.aspx.vb" Inherits="EF_vrLorryReceipts" title="Edit: Site Receipts" %>
<asp:Content ID="CPHvrLorryReceipts" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelvrLorryReceipts" runat="server" Text="&nbsp;Edit: Site Receipts"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLvrLorryReceipts" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLvrLorryReceipts"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnablePrint="True"
            PrintUrl="../App_Print/RP_vrLorryReceipts.aspx?pk="
            ValidationGroup="vrLorryReceipts"
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
          </script>
          <asp:FormView ID="FVvrLorryReceipts"
            runat="server"
            DataKeyNames="ProjectID,MRNNo"
            DataSourceID="ODSvrLorryReceipts"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="margin: auto; border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color: red">*</span></b>
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ProjectID"
                        Width="70px"
                        Text='<%# Bind("ProjectID") %>'
                        CssClass="mypktxt"
                        Enabled="False"
                        ToolTip="Value of Project."
                        runat="Server" />
                      <asp:Label
                        ID="F_ProjectID_Display"
                        Text='<%# Eval("IDM_Projects2_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_RequestExecutionNo" runat="server" Text="Request Execution No :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_RequestExecutionNo"
                        CssClass="myfktxt"
                        Text='<%# Bind("RequestExecutionNo") %>'
                        AutoCompleteType="None"
                        Width="70px"
                        onfocus="return this.select();"
                        ToolTip="Enter value for Request Execution No."
                        onblur="script_vrLorryReceipts.validate_RequestExecutionNo(this);"
                        runat="Server" />
                      <asp:Label
                        ID="F_RequestExecutionNo_Display"
                        Text='<%# Eval("VR_RequestExecution6_ExecutionDescription") %>'
                        CssClass="myLbl"
                        runat="Server" />
                      <AJX:AutoCompleteExtender
                        ID="ACERequestExecutionNo"
                        BehaviorID="B_ACERequestExecutionNo"
                        ContextKey=""
                        UseContextKey="true"
                        ServiceMethod="RequestExecutionNoCompletionList"
                        TargetControlID="F_RequestExecutionNo"
                        EnableCaching="false"
                        CompletionInterval="100"
                        FirstRowSelected="true"
                        MinimumPrefixLength="1"
                        OnClientItemSelected="script_vrLorryReceipts.ACERequestExecutionNo_Selected"
                        OnClientPopulating="script_vrLorryReceipts.ACERequestExecutionNo_Populating"
                        OnClientPopulated="script_vrLorryReceipts.ACERequestExecutionNo_Populated"
                        CompletionSetCount="10"
                        CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_MRNNo" runat="server" ForeColor="#CC6633" Text="MRN No :" /><span style="color: red">*</span></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_MRNNo"
                        Text='<%# Bind("MRNNo") %>'
                        ToolTip="Value of MRN No."
                        Enabled="False"
                        CssClass="mypktxt"
                        Width="70px"
                        Style="text-align: right"
                        runat="server" />
                    </td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_TransporterID"
                        CssClass="myfktxt"
                        Text='<%# Bind("TransporterID") %>'
                        AutoCompleteType="None"
                        Width="72px"
                        onfocus="return this.select();"
                        ToolTip="Enter value for Transporter."
                        ValidationGroup="vrLorryReceipts"
                        onblur="script_vrLorryReceipts.validate_TransporterID(this);"
                        runat="Server" />
                      <asp:Label
                        ID="F_TransporterID_Display"
                        Text='<%# Eval("VR_Transporters7_TransporterName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                      <AJX:AutoCompleteExtender
                        ID="ACETransporterID"
                        BehaviorID="B_ACETransporterID"
                        ContextKey=""
                        UseContextKey="true"
                        ServiceMethod="TransporterIDCompletionList"
                        TargetControlID="F_TransporterID"
                        EnableCaching="false"
                        CompletionInterval="100"
                        FirstRowSelected="true"
                        MinimumPrefixLength="1"
                        OnClientItemSelected="script_vrLorryReceipts.ACETransporterID_Selected"
                        OnClientPopulating="script_vrLorryReceipts.ACETransporterID_Populating"
                        OnClientPopulated="script_vrLorryReceipts.ACETransporterID_Populated"
                        CompletionSetCount="10"
                        CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_MRNDate" runat="server" Text="MRN Date :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_MRNDate"
                        Text='<%# Bind("MRNDate") %>'
                        Width="80px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        runat="server" />
                      <asp:Image ID="ImageButtonMRNDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CEMRNDate"
                        TargetControlID="F_MRNDate"
                        Format="dd/MM/yyyy"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonMRNDate" />
                      <AJX:MaskedEditExtender
                        ID="MEEMRNDate"
                        runat="server"
                        Mask="99/99/9999"
                        MaskType="Date"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_MRNDate" />
                      <AJX:MaskedEditValidator
                        ID="MEVMRNDate"
                        runat="server"
                        ControlToValidate="F_MRNDate"
                        ControlExtender="MEEMRNDate"
                        EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_TransporterName"
                        Text='<%# Bind("TransporterName") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Transporter Name."
                        MaxLength="50"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_CustomerID" runat="server" Text="Customer :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_CustomerID"
                        CssClass="myfktxt"
                        Text='<%# Bind("CustomerID") %>'
                        AutoCompleteType="None"
                        Width="72px"
                        onfocus="return this.select();"
                        ToolTip="Enter value for Customer."
                        onblur="script_vrLorryReceipts.validate_CustomerID(this);"
                        runat="Server" />
                      <asp:Label
                        ID="F_CustomerID_Display"
                        Text='<%# Eval("VR_BusinessPartner3_BPName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                      <AJX:AutoCompleteExtender
                        ID="ACECustomerID"
                        BehaviorID="B_ACECustomerID"
                        ContextKey=""
                        UseContextKey="true"
                        ServiceMethod="CustomerIDCompletionList"
                        TargetControlID="F_CustomerID"
                        EnableCaching="false"
                        CompletionInterval="100"
                        FirstRowSelected="true"
                        MinimumPrefixLength="1"
                        OnClientItemSelected="script_vrLorryReceipts.ACECustomerID_Selected"
                        OnClientPopulating="script_vrLorryReceipts.ACECustomerID_Populating"
                        OnClientPopulated="script_vrLorryReceipts.ACECustomerID_Populated"
                        CompletionSetCount="10"
                        CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <p style="line-height: 10pt">
                        <asp:Label ID="Label1" runat="server" Text="Vehicle Registration No :" /><span style="color: red">*</span><br />
                        <asp:Label ID="Label4" runat="server" ForeColor="ForestGreen" Text="OR Consignment No :" />
                      </p>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleRegistrationNo"
                        Text='<%# Bind("VehicleRegistrationNo") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Vehicle Registration No."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVVehicleRegistrationNo"
                        runat="server"
                        ControlToValidate="F_VehicleRegistrationNo"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_WayBillFormNo" runat="server" Text="Way Bill Form No [Enter NA if NOT Applicable] :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_WayBillFormNo"
                        Text='<%# Bind("WayBillFormNo") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Way Bill Form No [Enter NA if NOT Applicable]."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVWayBillFormNo"
                        runat="server"
                        ControlToValidate="F_WayBillFormNo"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_PaymentMadeAtSite" runat="server" Text="Payment Made At Site :" />&nbsp;
                    </td>
                    <td>
                      <asp:CheckBox ID="F_PaymentMadeAtSite"
                        Checked='<%# Bind("PaymentMadeAtSite") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_AmountPaid" runat="server" Text="Amount Paid :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_AmountPaid"
                        Text='<%# Bind("AmountPaid") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="12"
                        onfocus="return this.select();"
                        onblur="return dc(this,0);"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_VehicleInDate" runat="server" Text="Vehicle In Time :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleInDate"
                        Text='<%# Bind("VehicleInDate") %>'
                        Width="110px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        runat="server" />
                      <asp:Image ID="ImageButtonVehicleInDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CEVehicleInDate"
                        TargetControlID="F_VehicleInDate"
                        Format="dd/MM/yyyy HH:mm"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehicleInDate" />
                      <AJX:MaskedEditExtender
                        ID="MEEVehicleInDate"
                        runat="server"
                        Mask="99/99/9999 99:99"
                        MaskType="DateTime"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_VehicleInDate" />
                      <AJX:MaskedEditValidator
                        ID="MEVVehicleInDate"
                        runat="server"
                        ControlToValidate="F_VehicleInDate"
                        ControlExtender="MEEVehicleInDate"
                        EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_VehicleOutDate" runat="server" Text="Vehicle Out Time :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleOutDate"
                        Text='<%# Bind("VehicleOutDate") %>'
                        Width="110px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        runat="server" />
                      <asp:Image ID="ImageButtonVehicleOutDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CEVehicleOutDate"
                        TargetControlID="F_VehicleOutDate"
                        Format="dd/MM/yyyy HH:mm"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehicleOutDate" />
                      <AJX:MaskedEditExtender
                        ID="MEEVehicleOutDate"
                        runat="server"
                        Mask="99/99/9999 99:99"
                        MaskType="DateTime"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_VehicleOutDate" />
                      <AJX:MaskedEditValidator
                        ID="MEVVehicleOutDate"
                        runat="server"
                        ControlToValidate="F_VehicleOutDate"
                        ControlExtender="MEEVehicleOutDate"
                        EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_DetentionAtSite" runat="server" Text="Detention At Site :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:DropDownList
                        ID="F_DetentionAtSite"
                        SelectedValue='<%# Bind("DetentionAtSite") %>'
                        CssClass="myddl"
                        Width="200px"
                        ValidationGroup="vrLorryReceipts"
                        runat="Server">
                        <asp:ListItem Value="">---Select---</asp:ListItem>
                        <asp:ListItem Value="YES">YES</asp:ListItem>
                        <asp:ListItem Value="NO">NO</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator
                        ID="RFVDetentionAtSite"
                        runat="server"
                        ControlToValidate="F_DetentionAtSite"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_ReasonForDetention" runat="server" Text="Reason For Detention :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_ReasonForDetention"
                        Text='<%# Bind("ReasonForDetention") %>'
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Reason For Detention."
                        MaxLength="500"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" />&nbsp;
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
                        Width="200px"
                        CssClass="myddl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <p style="line-height: 10pt">
                        <asp:Label ID="L_VehicleType" runat="server" Text="Other Vehicle Type :" /><br />
                        <asp:Label ID="Label2" runat="server" ForeColor="ForestGreen" Text="OR Courier :" /><br />
                        <asp:Label ID="Label3" runat="server" ForeColor="ForestGreen" Text="OR By Hand :" />
                      </p>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleType"
                        Text='<%# Bind("VehicleType") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Other Vehicle Type."
                        MaxLength="50"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_OverDimensionConsignment" runat="server" Text="Over Dimension Consignment [ODC] :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:DropDownList
                        ID="F_OverDimensionConsignment"
                        SelectedValue='<%# Bind("OverDimensionConsignment") %>'
                        CssClass="myddl"
                        Width="200px"
                        ValidationGroup="vrLorryReceipts"
                        runat="Server">
                        <asp:ListItem Value="">---Select---</asp:ListItem>
                        <asp:ListItem Value="YES">YES</asp:ListItem>
                        <asp:ListItem Value="NO">NO</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator
                        ID="RFVOverDimensionConsignment"
                        runat="server"
                        ControlToValidate="F_OverDimensionConsignment"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_VehicleLengthInFt" runat="server" Text="Consignment Length [ in Ft. ] :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleLengthInFt"
                        Text='<%# Bind("VehicleLengthInFt") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,2);"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_VechicleWidthInFt" runat="server" Text="Consignment Width [ in Ft. ] :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_VechicleWidthInFt"
                        Text='<%# Bind("VechicleWidthInFt") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,2);"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_VehicleHeightInFt" runat="server" Text="Consignment Height [ in Ft. ] :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleHeightInFt"
                        Text='<%# Bind("VehicleHeightInFt") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,2);"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_MaterialStateID" runat="server" Text="Material State ID :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <LGM:LC_vrMaterialStates
                        ID="F_MaterialStateID"
                        SelectedValue='<%# Bind("MaterialStateID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="200px"
                        CssClass="myddl"
                        ValidationGroup="vrLorryReceipts"
                        RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_RemarksForDamageOrShortage" runat="server" Text="Remarks For Damage Or Shortage :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_RemarksForDamageOrShortage"
                        Text='<%# Bind("RemarksForDamageOrShortage") %>'
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Remarks For Damage Or Shortage."
                        MaxLength="500"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_OtherRemarks" runat="server" Text="Other Remarks :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_OtherRemarks"
                        Text='<%# Bind("OtherRemarks") %>'
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Other Remarks."
                        MaxLength="500"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_DriverNameAndContactNo" runat="server" Text="Driver Name And Contact No :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_DriverNameAndContactNo"
                        Text='<%# Bind("DriverNameAndContactNo") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceipts"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Driver Name And Contact No."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVDriverNameAndContactNo"
                        runat="server"
                        ControlToValidate="F_DriverNameAndContactNo"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceipts"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_CreatedBy"
                        Width="56px"
                        Text='<%# Bind("CreatedBy") %>'
                        Enabled="False"
                        ToolTip="Value of Created By."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_CreatedBy_Display"
                        Text='<%# Eval("aspnet_users1_UserFullName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_CreatedOn"
                        Text='<%# Bind("CreatedOn") %>'
                        ToolTip="Value of Created On."
                        Enabled="False"
                        Width="140px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_LRStatusID" runat="server" Text="LR Status :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_LRStatusID"
                        Width="70px"
                        Text='<%# Bind("LRStatusID") %>'
                        Enabled="False"
                        ToolTip="Value of LR Status."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_LRStatusID_Display"
                        Text='<%# Eval("VR_LorryReceiptStatus4_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                </table>
              </div>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelvrLorryReceiptDetails" runat="server" Text="&nbsp;List: Site Receipt Details"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLvrLorryReceiptDetails" runat="server">
                    <ContentTemplate>
                      <table style="width:100%;">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLvrLorryReceiptDetails"
                              ToolType="lgNMGrid"
                              EditUrl="~/VR_Main/App_Edit/EF_vrLorryReceiptDetails.aspx"
                              AddUrl="~/VR_Main/App_Create/AF_vrLorryReceiptDetails.aspx"
                              AddPostBack="True"
                              EnableExit="false"
                              ValidationGroup="vrLorryReceiptDetails"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSvrLorryReceiptDetails" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceiptDetails" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVvrLorryReceiptDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceiptDetails" DataKeyNames="ProjectID,MRNNo,SerialNo">
                              <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier" SortExpression="VR_BusinessPartner2_BPName">
                                  <ItemTemplate>
                                    <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("VR_BusinessPartner2_BPName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill No" SortExpression="SupplierInvoiceNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelSupplierInvoiceNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SupplierInvoiceNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill Date" SortExpression="SupplierInvoiceDate">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelSupplierInvoiceDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SupplierInvoiceDate") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GR No" SortExpression="GRorLRNo">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelGRorLRNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("GRorLRNo") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GR Date" SortExpression="GRorLRDate">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelGRorLRDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("GRorLRDate") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IR No" SortExpression="IRNO">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelIRNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("IRNO") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LINK">
                                  <ItemTemplate>
                                    <asp:Button ID="cmdShowIRN" runat="server" CssClass="nt-but-danger" Visible='<%# Eval("ShowIRNVisible") %>' Text="Show IRN" CommandName="lgLinkIR" CommandArgument='<%# Container.DataItemIndex %>' />
                                    <asp:Button ID="cmdDelink" runat="server" CssClass="nt-but-primary" Visible='<%# Eval("DelinkIRNVisible") %>' Text="Delink IRN" CommandName="lgDeLinkIR" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>
                                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                              </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource
                              ID="ODSvrLorryReceiptDetails"
                              runat="server"
                              DataObjectTypeName="SIS.VR.vrLorryReceiptDetails"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="vrLorryReceiptDetailsSelectList"
                              TypeName="SIS.VR.vrLorryReceiptDetails"
                              SelectCountMethod="vrLorryReceiptDetailsSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
                                <asp:ControlParameter ControlID="F_MRNNo" PropertyName="Text" Name="MRNNo" Type="Int32" Size="10" />
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
                      <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceiptDetails" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSvrLorryReceipts"
        DataObjectTypeName="SIS.VR.vrLorryReceipts"
        SelectMethod="vrLorryReceiptsGetByID"
        UpdateMethod="UZ_vrLorryReceiptsUpdate"
        DeleteMethod="UZ_vrLorryReceiptsDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.VR.vrLorryReceipts"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="MRNNo" Name="MRNNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
  <LGM:LC_LinkIRN ID="test" runat="server" />
</asp:Content>
