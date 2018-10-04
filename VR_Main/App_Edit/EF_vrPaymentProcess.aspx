<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrPaymentProcess.aspx.vb" Inherits="EF_vrPaymentProcess" title="Edit: Payment Process" %>
<asp:Content ID="CPHvrPaymentProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPaymentProcess" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrPaymentProcess" runat="server" Text="&nbsp;Edit: Payment Process" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrPaymentProcess"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "vrPaymentProcess"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrPaymentProcess"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrPaymentProcess"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRNo" runat="server" Text="PTR No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRNo"
						Text='<%# Bind("PTRNo") %>'
            ToolTip="Value of PTR No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRDate" runat="server" Text="PTR Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRDate"
						Text='<%# Bind("PTRDate") %>'
            ToolTip="Value of PTR Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PTRAmount" runat="server" Text="PTR Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PTRAmount"
						Text='<%# Bind("PTRAmount") %>'
            ToolTip="Value of PTR Amount."
            Enabled = "False"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PaymentReference" runat="server" Text="Payment Reference :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PaymentReference"
						Text='<%# Bind("PaymentReference") %>'
            ToolTip="Value of Payment Reference."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeNo" runat="server" Text="Cheque No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeNo"
						Text='<%# Bind("ChequeNo") %>'
            ToolTip="Value of Cheque No."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeDate" runat="server" Text="Cheque Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeDate"
						Text='<%# Bind("ChequeDate") %>'
            ToolTip="Value of Cheque Date."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ChequeAmount" runat="server" Text="Cheque Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ChequeAmount"
						Text='<%# Bind("ChequeAmount") %>'
            ToolTip="Value of Cheque Amount."
            Enabled = "False"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PaymentDescription" runat="server" Text="Paid To :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_PaymentDescription"
						Text='<%# Bind("PaymentDescription") %>'
            ToolTip="Value of Paid To."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProcessedBy" runat="server" Text="Processed By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProcessedBy"
            Width="56px"
						Text='<%# Bind("ProcessedBy") %>'
            Enabled = "False"
            ToolTip="Value of Processed By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ProcessedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
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
            ToolTip="Value of Processed On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Freezed" runat="server" Text="Cheque Reconciled :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Freezed"
					  Checked='<%# Bind("Freezed") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IRNo" runat="server" Text="IRNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IRNo"
						Text='<%# Bind("IRNo") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrPaymentProcess"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEIRNo"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_IRNo" />
					<AJX:MaskedEditValidator 
						ID = "MEVIRNo"
						runat = "server"
						ControlToValidate = "F_IRNo"
						ControlExtender = "MEEIRNo"
						InvalidValueMessage = "Invalid value for IRNo."
						EmptyValueMessage = "IRNo is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for IRNo."
						EnableClientScript = "true"
						ValidationGroup = "vrPaymentProcess"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "IRNo should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrPaymentProcess"
  DataObjectTypeName = "SIS.VR.vrPaymentProcess"
  SelectMethod = "vrPaymentProcessGetByID"
  UpdateMethod="UZ_vrPaymentProcessUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrPaymentProcess"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
