<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrBillStatus.aspx.vb" Inherits="AF_vrBillStatus" title="Add: Bill Status" %>
<asp:Content ID="CPHvrBillStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrBillStatus" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrBillStatus" runat="server" Text="&nbsp;Add: Bill Status" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrBillStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrBillStatus"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrBillStatus"
	runat = "server"
	DataKeyNames = "BillStatusID"
	DataSourceID = "ODSvrBillStatus"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrBillStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatusID" ForeColor="#CC6633" runat="server" Text="Bill Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_BillStatusID"
						Text='<%# Bind("BillStatusID") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mypktxt"
						ValidationGroup="vrBillStatus"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEBillStatusID"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_BillStatusID" />
					<AJX:MaskedEditValidator 
						ID = "MEVBillStatusID"
						runat = "server"
						ControlToValidate = "F_BillStatusID"
						ControlExtender = "MEEBillStatusID"
						InvalidValueMessage = "Invalid value for Bill Status ID."
						EmptyValueMessage = "Bill Status ID is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Bill Status ID."
						EnableClientScript = "true"
						ValidationGroup = "vrBillStatus"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Bill Status ID should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrBillStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrBillStatus"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrBillStatus"
  DataObjectTypeName = "SIS.VR.vrBillStatus"
  InsertMethod="vrBillStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrBillStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
