<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrPaymentProcess.aspx.vb" Inherits="AF_vrPaymentProcess" title="Add: Payment Process" %>
<asp:Content ID="CPHvrPaymentProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPaymentProcess" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrPaymentProcess" runat="server" Text="&nbsp;Add: Payment Process" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrPaymentProcess"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrPaymentProcess"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrPaymentProcess"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrPaymentProcess"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrPaymentProcess" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PaymentDescription" runat="server" Text="Payment Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PaymentDescription"
						Text='<%# Bind("PaymentDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrPaymentProcess"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Payment Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVPaymentDescription"
						runat = "server"
						ControlToValidate = "F_PaymentDescription"
						Text = "Payment Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRNo" runat="server" Text="PTR No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRNo"
						Text='<%# Bind("PTRNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrPaymentProcess"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for PTR No."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVPTRNo"
						runat = "server"
						ControlToValidate = "F_PTRNo"
						Text = "PTR No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRDate" runat="server" Text="PTR Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRDate"
						Text='<%# Bind("PTRDate") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrPaymentProcess"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonPTRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEPTRDate"
            TargetControlID="F_PTRDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonPTRDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEPTRDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_PTRDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVPTRDate"
						runat = "server"
						ControlToValidate = "F_PTRDate"
						ControlExtender = "MEEPTRDate"
						InvalidValueMessage = "Invalid value for PTR Date."
						EmptyValueMessage = "PTR Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for PTR Date."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRAmount" runat="server" Text="PTR Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRAmount"
						Text='<%# Bind("PTRAmount") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrPaymentProcess"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEPTRAmount"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_PTRAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVPTRAmount"
						runat = "server"
						ControlToValidate = "F_PTRAmount"
						ControlExtender = "MEEPTRAmount"
						InvalidValueMessage = "Invalid value for PTR Amount."
						EmptyValueMessage = "PTR Amount is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for PTR Amount."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "PTR Amount should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeNo" runat="server" Text="Cheque No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeNo"
						Text='<%# Bind("ChequeNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrPaymentProcess"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Cheque No."
						MaxLength="10"
            Width="70px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVChequeNo"
						runat = "server"
						ControlToValidate = "F_ChequeNo"
						Text = "Cheque No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeDate" runat="server" Text="Cheque Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeDate"
						Text='<%# Bind("ChequeDate") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrPaymentProcess"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonChequeDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEChequeDate"
            TargetControlID="F_ChequeDate"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonChequeDate" />
					<AJX:MaskedEditExtender 
						ID = "MEEChequeDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ChequeDate" />
					<AJX:MaskedEditValidator 
						ID = "MEVChequeDate"
						runat = "server"
						ControlToValidate = "F_ChequeDate"
						ControlExtender = "MEEChequeDate"
						InvalidValueMessage = "Invalid value for Cheque Date."
						EmptyValueMessage = "Cheque Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Cheque Date."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeAmount" runat="server" Text="Cheque Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeAmount"
						Text='<%# Bind("ChequeAmount") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrPaymentProcess"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEChequeAmount"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ChequeAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVChequeAmount"
						runat = "server"
						ControlToValidate = "F_ChequeAmount"
						ControlExtender = "MEEChequeAmount"
						InvalidValueMessage = "Invalid value for Cheque Amount."
						EmptyValueMessage = "Cheque Amount is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Cheque Amount."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Cheque Amount should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProcessedBy" runat="server" Text="Processed By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProcessedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("ProcessedBy") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Processed By."
						ValidationGroup = "vrPaymentProcess"
            onblur= "script_vrPaymentProcess.validate_ProcessedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProcessedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProcessedBy"
						runat = "server"
						ControlToValidate = "F_ProcessedBy"
						Text = "Processed By is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEProcessedBy"
            BehaviorID="B_ACEProcessedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProcessedByCompletionList"
            TargetControlID="F_ProcessedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrPaymentProcess.ACEProcessedBy_Selected"
            OnClientPopulating="script_vrPaymentProcess.ACEProcessedBy_Populating"
            OnClientPopulated="script_vrPaymentProcess.ACEProcessedBy_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProcessedOn" runat="server" Text="Processed On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ProcessedOn"
						Text='<%# Bind("ProcessedOn") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrPaymentProcess"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonProcessedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEProcessedOn"
            TargetControlID="F_ProcessedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonProcessedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEProcessedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ProcessedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVProcessedOn"
						runat = "server"
						ControlToValidate = "F_ProcessedOn"
						ControlExtender = "MEEProcessedOn"
						InvalidValueMessage = "Invalid value for Processed On."
						EmptyValueMessage = "Processed On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Processed On."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Freezed" runat="server" Text="Freezed :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Freezed"
					 Checked='<%# Bind("Freezed") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestStatusID" runat="server" Text="Request Status ID :" /></b>
				</td>
        <td>
          <LGM:LC_vrRequestStates
            ID="F_RequestStatusID"
            SelectedValue='<%# Bind("RequestStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "vrPaymentProcess"
            RequiredFieldErrorMessage = "Request Status ID is required."
            Runat="Server" />
          </td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrPaymentProcess"
  DataObjectTypeName = "SIS.VR.vrPaymentProcess"
  InsertMethod="vrPaymentProcessInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrPaymentProcess"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
