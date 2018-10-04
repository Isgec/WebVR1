<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrLorryReceiptDetails.aspx.vb" Inherits="AF_vrLorryReceiptDetails" title="Add: Site Receipt Details" %>
<asp:Content ID="CPHvrLorryReceiptDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceiptDetails" runat="server" Text="&nbsp;Add: Site Receipt Details"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptDetails" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceiptDetails"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrLorryReceiptDetails"
    runat = "server" />
<asp:FormView ID="FVvrLorryReceiptDetails"
  runat = "server"
  DataKeyNames = "ProjectID,MRNNo,SerialNo"
  DataSourceID = "ODSvrLorryReceiptDetails"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgvrLorryReceiptDetails" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox runat="server" ID="F_TransporterID" style="display:none;"></asp:TextBox>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="60px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "vrLorryReceiptDetails"
            onblur= "script_vrLorryReceiptDetails.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
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
            OnClientItemSelected="script_vrLorryReceiptDetails.ACEProjectID_Selected"
            OnClientPopulating="script_vrLorryReceiptDetails.ACEProjectID_Populating"
            OnClientPopulated="script_vrLorryReceiptDetails.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_MRNNo" ForeColor="#CC6633" runat="server" Text="MRN No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_MRNNo"
            CssClass = "mypktxt"
            Width="70px"
            Text='<%# Bind("MRNNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for MRN No."
            ValidationGroup = "vrLorryReceiptDetails"
            onblur= "script_vrLorryReceiptDetails.validate_MRNNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVMRNNo"
            runat = "server"
            ControlToValidate = "F_MRNNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_MRNNo_Display"
            Text='<%# Eval("VR_LorryReceipts3_WayBillFormNo") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEMRNNo"
            BehaviorID="B_ACEMRNNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="MRNNoCompletionList"
            TargetControlID="F_MRNNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLorryReceiptDetails.ACEMRNNo_Selected"
            OnClientPopulating="script_vrLorryReceiptDetails.ACEMRNNo_Populating"
            OnClientPopulated="script_vrLorryReceiptDetails.ACEMRNNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_GRorLRNo" runat="server" Text="GR / LR No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GRorLRNo"
            CssClass = "myfktxt"
            Width="350px"
            Text='<%# Bind("GRorLRNo") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GR / LR No."
            ValidationGroup = "vrLorryReceiptDetails"
            onblur= "script_vrLorryReceiptDetails.validate_GRorLRNo(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGRorLRNo"
            runat = "server"
            ControlToValidate = "F_GRorLRNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_GRorLRNo_Display"
            Text='<%# Eval("ttfisg0032004_t_bpid") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEGRorLRNo"
            BehaviorID="B_ACEGRorLRNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="GRorLRNoCompletionList"
            TargetControlID="F_GRorLRNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLorryReceiptDetails.ACEGRorLRNo_Selected"
            OnClientPopulating="script_vrLorryReceiptDetails.ACEGRorLRNo_Populating"
            OnClientPopulated="script_vrLorryReceiptDetails.ACEGRorLRNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GRorLRDate" runat="server" Text="GR / LR Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_GRorLRDate"
            Text='<%# Bind("GRorLRDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="vrLorryReceiptDetails"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonGRorLRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEGRorLRDate"
            TargetControlID="F_GRorLRDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonGRorLRDate" />
          <AJX:MaskedEditExtender 
            ID = "MEEGRorLRDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_GRorLRDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVGRorLRDate"
            runat = "server"
            ControlToValidate = "F_GRorLRDate"
            ControlExtender = "MEEGRorLRDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" />
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            CssClass = "myfktxt"
            Width="63px"
            Text='<%# Bind("SupplierID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Supplier ID."
            ValidationGroup = "vrLorryReceiptDetails"
            onblur= "script_vrLorryReceiptDetails.validate_SupplierID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner2_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLorryReceiptDetails.ACESupplierID_Selected"
            OnClientPopulating="script_vrLorryReceiptDetails.ACESupplierID_Populating"
            OnClientPopulated="script_vrLorryReceiptDetails.ACESupplierID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Name."
            MaxLength="50"
            Width="350px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierInvoiceNo" runat="server" Text="Supplier Invoice No :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierInvoiceNo"
            Text='<%# Bind("SupplierInvoiceNo") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceiptDetails"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Supplier Invoice No."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSupplierInvoiceNo"
            runat = "server"
            ControlToValidate = "F_SupplierInvoiceNo"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierInvoiceDate" runat="server" Text="Supplier Invoice Date :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SupplierInvoiceDate"
            Text='<%# Bind("SupplierInvoiceDate") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="vrLorryReceiptDetails"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonSupplierInvoiceDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CESupplierInvoiceDate"
            TargetControlID="F_SupplierInvoiceDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonSupplierInvoiceDate" />
          <AJX:MaskedEditExtender 
            ID = "MEESupplierInvoiceDate"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_SupplierInvoiceDate" />
          <AJX:MaskedEditValidator 
            ID = "MEVSupplierInvoiceDate"
            runat = "server"
            ControlToValidate = "F_SupplierInvoiceDate"
            ControlExtender = "MEESupplierInvoiceDate"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WeightAsPerInvoiceInKG" runat="server" Text="Weight as per Invoice [KG] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightAsPerInvoiceInKG"
            Text='<%# Bind("WeightAsPerInvoiceInKG") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWeightAsPerInvoiceInKG"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WeightAsPerInvoiceInKG" />
          <AJX:MaskedEditValidator 
            ID = "MEVWeightAsPerInvoiceInKG"
            runat = "server"
            ControlToValidate = "F_WeightAsPerInvoiceInKG"
            ControlExtender = "MEEWeightAsPerInvoiceInKG"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WeightReceived" runat="server" Text="Weight Received [KG] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightReceived"
            Text='<%# Bind("WeightReceived") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEWeightReceived"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_WeightReceived" />
          <AJX:MaskedEditValidator 
            ID = "MEVWeightReceived"
            runat = "server"
            ControlToValidate = "F_WeightReceived"
            ControlExtender = "MEEWeightReceived"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialForm" runat="server" Text="MaterialForm :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_MaterialForm"
            SelectedValue='<%# Bind("MaterialForm") %>'
            Width="200px"
            ValidationGroup = "vrLorryReceiptDetails"
            CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="Package">PACKAGE</asp:ListItem>
            <asp:ListItem Value="Loose">LOOSE</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVMaterialForm"
            runat = "server"
            ControlToValidate = "F_MaterialForm"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
         </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NoOfPackagesAsPerInvoice" runat="server" Text="No. of Packages as per Invoice :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NoOfPackagesAsPerInvoice"
            Text='<%# Bind("NoOfPackagesAsPerInvoice") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEENoOfPackagesAsPerInvoice"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_NoOfPackagesAsPerInvoice" />
          <AJX:MaskedEditValidator 
            ID = "MEVNoOfPackagesAsPerInvoice"
            runat = "server"
            ControlToValidate = "F_NoOfPackagesAsPerInvoice"
            ControlExtender = "MEENoOfPackagesAsPerInvoice"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NoOfPackagesReceived" runat="server" Text="No. of Packages Received :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NoOfPackagesReceived"
            Text='<%# Bind("NoOfPackagesReceived") %>'
            Width="70px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEENoOfPackagesReceived"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_NoOfPackagesReceived" />
          <AJX:MaskedEditValidator 
            ID = "MEVNoOfPackagesReceived"
            runat = "server"
            ControlToValidate = "F_NoOfPackagesReceived"
            ControlExtender = "MEENoOfPackagesReceived"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CenvatInvoiceReceived" runat="server" Text="Cenvat Invoice Received :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_CenvatInvoiceReceived"
            SelectedValue='<%# Bind("CenvatInvoiceReceived") %>'
            Width="200px"
            ValidationGroup = "vrLorryReceiptDetails"
            CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
            <asp:ListItem Value="NA">NA</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVCenvatInvoiceReceived"
            runat = "server"
            ControlToValidate = "F_CenvatInvoiceReceived"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptDetails"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
            MaxLength="150"
            Width="350px" Height="40px" TextMode="MultiLine"
            runat="server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLorryReceiptDetails"
  DataObjectTypeName = "SIS.VR.vrLorryReceiptDetails"
  InsertMethod="vrLorryReceiptDetailsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceiptDetails"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
