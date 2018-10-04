<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrPendingTransporterBill.aspx.vb" Inherits="EF_vrPendingTransporterBill" title="Edit: Pending IR" %>
<asp:Content ID="CPHvrPendingTransporterBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPendingTransporterBill" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrPendingTransporterBill" runat="server" Text="&nbsp;Edit: Pending IR" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrPendingTransporterBill"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrPendingTransporterBill" 
    EnableSave="false"
    EnableDelete="false"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrPendingTransporterBill"
	runat = "server"
	DataKeyNames = "IRNo"
	DataSourceID = "ODSvrPendingTransporterBill"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
    <table>
			<tr>
				<td>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IRNo" runat="server" ForeColor="#CC6633" Text="IRNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_IRNo"
						Text='<%# Bind("IRNo") %>'
            ToolTip="Value of IRNo."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_IRDescription" runat="server" Text="IR Description :" /></b>
				</td>
				<td>
					<asp:Label ID="F_IRDescription"
						Text='<%# Bind("IRDescription") %>'
            Width="350px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ISGECPONumber" runat="server" Text="ERP PO Number :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ISGECPONumber"
						Text='<%# Bind("ISGECPONumber") %>'
            Width="70px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterID" runat="server" Text="Transporter ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_TransporterID"
            Width="63px"
						Text='<%# Bind("TransporterID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_TransporterID_Display"
						Text='<%# Eval("VR_Transporters9_TransporterName") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterBillNo" runat="server" Text="Transporter Bill No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_TransporterBillNo"
						Text='<%# Bind("TransporterBillNo") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterBillDate" runat="server" Text="Transporter Bill Date :" /></b>
				</td>
				<td>
					<asp:Label ID="F_TransporterBillDate"
						Text='<%# Bind("TransporterBillDate") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillAmount" runat="server" Text="Bill Amount :" /></b>
				</td>
				<td>
					<asp:Label ID="F_BillAmount"
						Text='<%# Bind("BillAmount") %>'
            Width="126px"
						CssClass = "mytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReceivedOn" runat="server" Text="Bill Received On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_BillReceivedOn"
						Text='<%# Bind("BillReceivedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReceivedBy" runat="server" Text="Bill Received By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_BillReceivedBy"
            Width="56px"
						Text='<%# Bind("BillReceivedBy") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BillReceivedBy_Display"
						Text='<%# Eval("aspnet_Users5_UserFullName") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReceiverDivisionID" runat="server" Text="Bill Receiver Division ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_BillReceiverDivisionID"
            Width="42px"
						Text='<%# Bind("BillReceiverDivisionID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BillReceiverDivisionID_Display"
						Text='<%# Eval("HRM_Divisions6_Description") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_BillStatusID"
            Width="70px"
						Text='<%# Bind("BillStatusID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BillStatusID_Display"
						Text='<%# Eval("VR_BillStatus8_Description") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
    </table>
				</td>
				<td>
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ForwardedToAccount" runat="server" Text="Forwarded To Account :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ForwardedToAccount"
					  Checked='<%# Bind("ForwardedToAccount") %>'
            Enabled = "False"
						CssClass = "mytxt"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ForwardedOn" runat="server" Text="Forwarded On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ForwardedOn"
						Text='<%# Bind("ForwardedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ForwardedBy" runat="server" Text="Forwarded By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ForwardedBy"
            Width="56px"
						Text='<%# Bind("ForwardedBy") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ForwardedBy_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
		<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DiscripantBill" runat="server" Text="Discripant Bill :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DiscripantBill"
					  Checked='<%# Bind("DiscripantBill") %>'
            Enabled = "False"
						CssClass = "mytxt"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReturnRemarks" runat="server" Text="Bill Return Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_BillReturnRemarks"
						Text='<%# Bind("BillReturnRemarks") %>'
            Width="350px" Height="40px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReturnedOn" runat="server" Text="Bill Accepted / Returned On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_BillReturnedOn"
						Text='<%# Bind("BillReturnedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillReturneddBy" runat="server" Text="Bill Accepted / Returnedd By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_BillReturneddBy"
            Width="56px"
						Text='<%# Bind("BillReturneddBy") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BillReturneddBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						CssClass = "mytxt"
						Runat="Server" />
        </td>
			</tr>
			
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" Text="Payment Serial No :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_SerialNo"
            Width="70px"
						Text='<%# Bind("SerialNo") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SerialNo_Display"
						Text='<%# Eval("VR_PaymentProcess7_PaymentDescription") %>'
						Runat="Server" />
        </td>
			</tr>
		</table>
		</td>
		</tr>
		</table>
<asp:UpdatePanel ID="UPNLvrLinkedExecution" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrLinkedExecution" runat="server" Text="&nbsp;List: Linked Execution" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLinkedExecution"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLinkedExecution.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "vrLinkedExecution"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLinkedExecution" runat="server" AssociatedUpdatePanelID="UPNLvrLinkedExecution" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrLinkedExecution" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrLinkedExecution" DataKeyNames="SRNNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Execution No" SortExpression="SRNNo">
          <ItemTemplate>
            <asp:Label ID="LabelSRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SRNNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter" SortExpression="VR_Transporters10_TransporterName">
          <ItemTemplate>
             <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters10_TransporterName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Placed On" SortExpression="VehiclePlacedOn">
          <ItemTemplate>
            <asp:Label ID="LabelVehiclePlacedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehiclePlacedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Type" SortExpression="VR_VehicleTypes13_cmba">
          <ItemTemplate>
             <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes13_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle No" SortExpression="VehicleNo">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GR No" SortExpression="GRNo">
          <ItemTemplate>
            <asp:Label ID="LabelGRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GR Date" SortExpression="GRDate">
          <ItemTemplate>
            <asp:Label ID="LabelGRDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLinkedExecution"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLinkedExecution"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrLinkedExecutionSelectList"
      TypeName = "SIS.VR.vrLinkedExecution"
      SelectCountMethod = "vrLinkedExecutionSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_IRNo" PropertyName="Text" Name="IRNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLinkedExecution" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrPendingTransporterBill"
  DataObjectTypeName = "SIS.VR.vrPendingTransporterBill"
  SelectMethod = "vrPendingTransporterBillGetByID"
  UpdateMethod="UZ_vrPendingTransporterBillUpdate"
  DeleteMethod="vrPendingTransporterBillDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrPendingTransporterBill"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="IRNo" Name="IRNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
