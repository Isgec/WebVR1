<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrLorryReceipts.aspx.vb" Inherits="AF_vrLorryReceipts" title="Add: Site Receipts" %>
<asp:Content ID="CPHvrLorryReceipts" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceipts" runat="server" Text="&nbsp;Add: Site Receipts"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceipts" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceipts"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/VR_Main/App_Edit/EF_vrLorryReceipts.aspx"
    ValidationGroup = "vrLorryReceipts"
    runat = "server" />
<asp:FormView ID="FVvrLorryReceipts"
  runat = "server"
  DataKeyNames = "ProjectID,MRNNo"
  DataSourceID = "ODSvrLorryReceipts"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgvrLorryReceipts" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="42px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project."
            ValidationGroup = "vrLorryReceipts"
            onblur= "script_vrLorryReceipts.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLorryReceipts.ACEProjectID_Selected"
            OnClientPopulating="script_vrLorryReceipts.ACEProjectID_Populating"
            OnClientPopulated="script_vrLorryReceipts.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestExecutionNo" runat="server" Text="Request Execution No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestExecutionNo"
            CssClass = "myfktxt"
            Width="70px"
            Text='<%# Bind("RequestExecutionNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Request Execution No."
            onblur= "script_vrLorryReceipts.validate_RequestExecutionNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestExecutionNo_Display"
            Text='<%# Eval("VR_RequestExecution6_ExecutionDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MRNNo" ForeColor="#CC6633" runat="server" Text="MRN No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_MRNNo"
            Text='<%# Bind("MRNNo") %>'
            Enabled = "False"
            ToolTip="Value of MRN No."
            Width="70px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MRNDate" runat="server" Text="MRN Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_MRNDate"
            Text='<%# Bind("MRNDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="vrLorryReceipts"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonMRNDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEMRNDate"
            TargetControlID="F_MRNDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonMRNDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEMRNDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_MRNDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVMRNDate"
            runat = "server"
            ControlToValidate = "F_MRNDate"
            ControlExtender = "MEEMRNDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransporterID"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("TransporterID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Transporter."
            ValidationGroup = "vrLorryReceipts"
            onblur= "script_vrLorryReceipts.validate_TransporterID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_TransporterID_Display"
            Text='<%# Eval("VR_Transporters7_TransporterName") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TransporterName"
            Text='<%# Bind("TransporterName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Name."
            MaxLength="50"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CustomerID" runat="server" Text="Customer :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CustomerID"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("CustomerID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Customer."
            onblur= "script_vrLorryReceipts.validate_CustomerID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CustomerID_Display"
            Text='<%# Eval("VR_BusinessPartner3_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
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
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleRegistrationNo" runat="server" Text="Vehicle Registration No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VehicleRegistrationNo"
            Text='<%# Bind("VehicleRegistrationNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceipts"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vehicle Registration No."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVehicleRegistrationNo"
            runat = "server"
            ControlToValidate = "F_VehicleRegistrationNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WayBillFormNo" runat="server" Text="Way Bill Form No [Enter NA if NOT Applicable] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_WayBillFormNo"
            Text='<%# Bind("WayBillFormNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceipts"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Way Bill Form No [Enter NA if NOT Applicable]."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWayBillFormNo"
            runat = "server"
            ControlToValidate = "F_WayBillFormNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PaymentMadeAtSite" runat="server" Text="Payment Made At Site :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_PaymentMadeAtSite"
           Checked='<%# Bind("PaymentMadeAtSite") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_AmountPaid" runat="server" Text="Amount Paid :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountPaid"
            Text='<%# Bind("AmountPaid") %>'
            Width="70px"
            CssClass = "mytxt"
            style="text-align: right"
            MaxLength="12"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEAmountPaid"
            runat = "server"
            mask = "9999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_AmountPaid" />
          <AJX:MaskedEditValidator 
            ID = "MEVAmountPaid"
            runat = "server"
            ControlToValidate = "F_AmountPaid"
            ControlExtender = "MEEAmountPaid"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleInDate" runat="server" Text="Vehicle In Time :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VehicleInDate"
            Text='<%# Bind("VehicleInDate") %>'
            Width="110px"
            CssClass = "mytxt"
            ValidationGroup="vrLorryReceipts"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonVehicleInDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEVehicleInDate"
            TargetControlID="F_VehicleInDate"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehicleInDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEVehicleInDate"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VehicleInDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVVehicleInDate"
            runat = "server"
            ControlToValidate = "F_VehicleInDate"
            ControlExtender = "MEEVehicleInDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleOutDate" runat="server" Text="Vehicle Out Time :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VehicleOutDate"
            Text='<%# Bind("VehicleOutDate") %>'
            Width="110px"
            CssClass = "mytxt"
            ValidationGroup="vrLorryReceipts"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonVehicleOutDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEVehicleOutDate"
            TargetControlID="F_VehicleOutDate"
            Format="dd/MM/yyyy HH:mm"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehicleOutDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEVehicleOutDate"
            runat = "server"
            mask = "99/99/9999 99:99"
            MaskType="DateTime"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VehicleOutDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVVehicleOutDate"
            runat = "server"
            ControlToValidate = "F_VehicleOutDate"
            ControlExtender = "MEEVehicleOutDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DetentionAtSite" runat="server" Text="Detention At Site :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_DetentionAtSite"
            SelectedValue='<%# Bind("DetentionAtSite") %>'
            Width="200px"
            ValidationGroup = "vrLorryReceipts"
            CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVDetentionAtSite"
            runat = "server"
            ControlToValidate = "F_DetentionAtSite"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
         </td>
        <td class="alignright">
          <asp:Label ID="L_ReasonForDetention" runat="server" Text="Reason For Detention :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReasonForDetention"
            Text='<%# Bind("ReasonForDetention") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Reason For Detention."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
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
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleType" runat="server" Text="Other Vehicle Type :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleType"
            Text='<%# Bind("VehicleType") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Vehicle Type."
            MaxLength="50"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OverDimensionConsignment" runat="server" Text="Over Dimension Consignment [ODC] :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_OverDimensionConsignment"
            SelectedValue='<%# Bind("OverDimensionConsignment") %>'
            Width="200px"
            ValidationGroup = "vrLorryReceipts"
            CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVOverDimensionConsignment"
            runat = "server"
            ControlToValidate = "F_OverDimensionConsignment"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
         </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleLengthInFt" runat="server" Text="Consignment Length [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleLengthInFt"
            Text='<%# Bind("VehicleLengthInFt") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVehicleLengthInFt"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VehicleLengthInFt" />
          <AJX:MaskedEditValidator 
            ID = "MEVVehicleLengthInFt"
            runat = "server"
            ControlToValidate = "F_VehicleLengthInFt"
            ControlExtender = "MEEVehicleLengthInFt"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VechicleWidthInFt" runat="server" Text="Consignment Width [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VechicleWidthInFt"
            Text='<%# Bind("VechicleWidthInFt") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVechicleWidthInFt"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VechicleWidthInFt" />
          <AJX:MaskedEditValidator 
            ID = "MEVVechicleWidthInFt"
            runat = "server"
            ControlToValidate = "F_VechicleWidthInFt"
            ControlExtender = "MEEVechicleWidthInFt"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleHeightInFt" runat="server" Text="Consignment Height [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleHeightInFt"
            Text='<%# Bind("VehicleHeightInFt") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEVehicleHeightInFt"
            runat = "server"
            mask = "999.99"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_VehicleHeightInFt" />
          <AJX:MaskedEditValidator 
            ID = "MEVVehicleHeightInFt"
            runat = "server"
            ControlToValidate = "F_VehicleHeightInFt"
            ControlExtender = "MEEVehicleHeightInFt"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialStateID" runat="server" Text="Material State ID :" /><span style="color:red">*</span>
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
            ValidationGroup = "vrLorryReceipts"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
        <td class="alignright">
          <asp:Label ID="L_RemarksForDamageOrShortage" runat="server" Text="Remarks For Damage Or Shortage :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RemarksForDamageOrShortage"
            Text='<%# Bind("RemarksForDamageOrShortage") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks For Damage Or Shortage."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OtherRemarks" runat="server" Text="Other Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherRemarks"
            Text='<%# Bind("OtherRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Other Remarks."
            MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DriverNameAndContactNo" runat="server" Text="Driver Name And Contact No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_DriverNameAndContactNo"
            Text='<%# Bind("DriverNameAndContactNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceipts"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Driver Name And Contact No."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDriverNameAndContactNo"
            runat = "server"
            ControlToValidate = "F_DriverNameAndContactNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceipts"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLorryReceipts"
  DataObjectTypeName = "SIS.VR.vrLorryReceipts"
  InsertMethod="UZ_vrLorryReceiptsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceipts"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
