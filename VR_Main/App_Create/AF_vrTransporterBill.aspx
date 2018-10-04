<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrTransporterBill.aspx.vb" Inherits="AF_vrTransporterBill" title="Add: IR" %>
<asp:Content ID="CPHvrTransporterBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrTransporterBill" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrTransporterBill" runat="server" Text="&nbsp;Add: IR" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrTransporterBill"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/VR_Main/App_Edit/EF_vrTransporterBill.aspx"
    ValidationGroup = "vrTransporterBill"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrTransporterBill"
	runat = "server"
	DataKeyNames = "IRNo"
	DataSourceID = "ODSvrTransporterBill"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrTransporterBill" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IRNo" ForeColor="#CC6633" runat="server" Text="IRNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IRNo"
						Text='<%# Bind("IRNo") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mypktxt"
            onblur= "script_vrTransporterBill.validate_IRNo(this);"
						ValidationGroup="vrTransporterBill"
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
						ValidationGroup = "vrTransporterBill"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "IRNo should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
			<td></td>
			<td style="height:200px; width:400px; background-color:Aqua" id="divIR">
			</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrTransporterBill"
  DataObjectTypeName = "SIS.VR.vrTransporterBill"
  InsertMethod="UZ_vrTransporterBillInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrTransporterBill"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
