<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrReqReasonByExecuter.aspx.vb" Inherits="EF_vrReqReasonByExecuter" title="Edit: Req. Reason By Executer" %>
<asp:Content ID="CPHvrReqReasonByExecuter" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrReqReasonByExecuter" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrReqReasonByExecuter" runat="server" Text="&nbsp;Edit: Req. Reason By Executer" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrReqReasonByExecuter"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "vrReqReasonByExecuter"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrReqReasonByExecuter"
	runat = "server"
	DataKeyNames = "RequestNo"
	DataSourceID = "ODSvrReqReasonByExecuter"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
    <table>
			<tr>
				<td valign="top">
			<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestNo" runat="server" ForeColor="#CC6633" Text="Request No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestNo"
						Text='<%# Bind("RequestNo") %>'
            ToolTip="Value of Request No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestDescription" runat="server" Text="Request Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestDescription"
						Text='<%# Bind("RequestDescription") %>'
            ToolTip="Value of Request Description."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
            Width="42px"
						Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("IDM_Vendors5_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierLocation" runat="server" Text="Supplier Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierLocation"
						Text='<%# Bind("SupplierLocation") %>'
            ToolTip="Value of Supplier Location."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects4_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectType" runat="server" Text="Project Type :" /></b>
				</td>
        <td>
          <asp:DropDownList
            ID="F_ProjectType"
            SelectedValue='<%# Bind("ProjectType") %>'
            Width="200px"
            Enabled = "False"
						CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="Domestic">Domestic</asp:ListItem>
            <asp:ListItem Value="Export">Export</asp:ListItem>
          </asp:DropDownList>
         </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DeliveryLocation" runat="server" Text="Delivery Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DeliveryLocation"
						Text='<%# Bind("DeliveryLocation") %>'
            ToolTip="Value of Delivery Location."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ItemDescription"
						Text='<%# Bind("ItemDescription") %>'
            ToolTip="Value of Item Description."
            Enabled = "False"
            Width="350px" 
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialSize" runat="server" Text="Material Size :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaterialSize"
						Text='<%# Bind("MaterialSize") %>'
            ToolTip="Value of Material Size."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SizeUnit" runat="server" Text="Size Unit :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SizeUnit"
            Width="70px"
						Text='<%# Bind("SizeUnit") %>'
            Enabled = "False"
            ToolTip="Value of Size Unit."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SizeUnit_Display"
						Text='<%# Eval("VR_Units8_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Height"
						Text='<%# Bind("Height") %>'
            ToolTip="Value of Height."
            Enabled = "False"
            Width="42px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Width" runat="server" Text="Width :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Width"
						Text='<%# Bind("Width") %>'
            ToolTip="Value of Width."
            Enabled = "False"
            Width="42px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Length"
						Text='<%# Bind("Length") %>'
            ToolTip="Value of Length."
            Enabled = "False"
            Width="42px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaterialWeight"
						Text='<%# Bind("MaterialWeight") %>'
            ToolTip="Value of Material Weight."
            Enabled = "False"
            Width="126px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WeightUnit" runat="server" Text="Weight Unit :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_WeightUnit"
            Width="70px"
						Text='<%# Bind("WeightUnit") %>'
            Enabled = "False"
            ToolTip="Value of Weight Unit."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_WeightUnit_Display"
						Text='<%# Eval("VR_Units2_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_NoOfPackages" runat="server" Text="No. Of Packages :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_NoOfPackages"
						Text='<%# Bind("NoOfPackages") %>'
            ToolTip="Value of No. Of Packages."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_VehicleTypeID"
            Width="70px"
						Text='<%# Bind("VehicleTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Vehicle Type."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_VehicleTypeID_Display"
						Text='<%# Eval("VR_VehicleTypes9_cmba") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleRequiredOn" runat="server" Text="Vehicle Required On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehicleRequiredOn"
						Text='<%# Bind("VehicleRequiredOn") %>'
            ToolTip="Value of Vehicle Required On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OverDimentionConsignement" runat="server" Text="Over Dimention Consignement :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_OverDimentionConsignement"
					  Checked='<%# Bind("OverDimentionConsignement") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC Reason :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ODCReasonID"
            Width="70px"
						Text='<%# Bind("ODCReasonID") %>'
            Enabled = "False"
            ToolTip="Value of ODC Reason."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ODCReasonID_Display"
						Text='<%# Eval("VR_ODCReasons1_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" 
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CustomInvoiceNo"
						Text='<%# Bind("CustomInvoiceNo") %>'
            ToolTip="Value of Custom Invoice No."
            Enabled = "False"
            Width="350px" 
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestedBy"
            Width="56px"
						Text='<%# Bind("RequestedBy") %>'
            Enabled = "False"
            ToolTip="Value of Requested By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_RequestedOn"
						Text='<%# Bind("RequestedOn") %>'
            ToolTip="Value of Requested On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequesterDivisionID" runat="server" Text="Requester Division ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequesterDivisionID"
            Width="42px"
						Text='<%# Bind("RequesterDivisionID") %>'
            Enabled = "False"
            ToolTip="Value of Requester Division ID."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequesterDivisionID_Display"
						Text='<%# Eval("HRM_Divisions3_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			</table>
				</td>
				<td valign="top">
			<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ExecuterReasonID" runat="server" Text="Executer Reason :" /></b>
				</td>
        <td>
          <LGM:LC_vrRequestReasons
            ID="F_ExecuterReasonID"
            SelectedValue='<%# Bind("ExecuterReasonID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="400px"
            CssClass="myfktxt"
						ValidationGroup = "vrReqReasonByExecuter"
            RequiredFieldErrorMessage = "Executer Reason is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ExecuterID" runat="server" Text="Executer :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ExecuterID"
            Width="56px"
						Text='<%# Bind("ExecuterID") %>'
            Enabled = "False"
            ToolTip="Value of Executer."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ExecuterID_Display"
						Text='<%# Eval("aspnet_Users11_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonEneteredOn" runat="server" Text="Reason Enetered On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonEneteredOn"
						Text='<%# Bind("ReasonEneteredOn") %>'
            ToolTip="Value of Reason Enetered On."
            Enabled = "False"
            Width="140px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestStatus" runat="server" Text="Request Status :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestStatus"
            Width="70px"
						Text='<%# Bind("RequestStatus") %>'
            Enabled = "False"
            ToolTip="Value of Request Status."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestStatus_Display"
						Text='<%# Eval("VR_RequestStates7_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FromLocation" runat="server" Text="From Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FromLocation"
						Text='<%# Bind("FromLocation") %>'
            ToolTip="Value of From Location."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ToLocation" runat="server" Text="To Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ToLocation"
						Text='<%# Bind("ToLocation") %>'
            ToolTip="Value of To Location."
            Enabled = "False"
            Width="350px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MICN" runat="server" Text="MICN Attended :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_MICN"
					  Checked='<%# Bind("MICN") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CustomInvoiceIssued" runat="server" Text="Custom Invoice Attended :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_CustomInvoiceIssued"
					  Checked='<%# Bind("CustomInvoiceIssued") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CT1Issued" runat="server" Text="CT-1 Attended :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_CT1Issued"
					  Checked='<%# Bind("CT1Issued") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ARE1Issued" runat="server" Text="ARE-1 Attended :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ARE1Issued"
					  Checked='<%# Bind("ARE1Issued") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DIIssued" runat="server" Text="DI-Attended :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DIIssued"
					  Checked='<%# Bind("DIIssued") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PaymentChecked" runat="server" Text="Payment Checked :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_PaymentChecked"
					  Checked='<%# Bind("PaymentChecked") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GoodsPacked" runat="server" Text="Goods Packed :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_GoodsPacked"
					  Checked='<%# Bind("GoodsPacked") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_POApproved" runat="server" Text="PO Approved :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_POApproved"
					  Checked='<%# Bind("POApproved") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WayBill" runat="server" Text="Way Bill :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_WayBill"
					  Checked='<%# Bind("WayBill") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MarkingDetails" runat="server" Text="Marking Details :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_MarkingDetails"
					  Checked='<%# Bind("MarkingDetails") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TarpaulineRequired" runat="server" Text="Tarpauline Required :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_TarpaulineRequired"
					  Checked='<%# Bind("TarpaulineRequired") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_PackageStckable" runat="server" Text="Package Stckable :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_PackageStckable"
					  Checked='<%# Bind("PackageStckable") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_InvoiceValue" runat="server" Text="InvoiceValue :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_InvoiceValue"
						Text='<%# Bind("InvoiceValue") %>'
            ToolTip="Value of InvoiceValue."
            Enabled = "False"
            Width="91px"
						CssClass = "dmytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OutOfContract" runat="server" Text="Out Of Contract :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_OutOfContract"
					  Checked='<%# Bind("OutOfContract") %>'
            Enabled = "False"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ERPPONumber" runat="server" Text="ERP PO Number :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ERPPONumber"
						Text='<%# Bind("ERPPONumber") %>'
            ToolTip="Value of ERP PO Number."
            Enabled = "False"
            Width="70px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BuyerInERP" runat="server" Text="Buyer In ERP :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BuyerInERP"
            Width="56px"
						Text='<%# Bind("BuyerInERP") %>'
            Enabled = "False"
            ToolTip="Value of Buyer In ERP."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_BuyerInERP_Display"
						Text='<%# Eval("aspnet_Users10_UserFullName") %>'
						Runat="Server" />
        </td>
			</tr>
		</table>
				</td>
			</tr>
    </table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrReqReasonByExecuter"
  DataObjectTypeName = "SIS.VR.vrReqReasonByExecuter"
  SelectMethod = "vrReqReasonByExecuterGetByID"
  UpdateMethod="UZ_vrReqReasonByExecuterUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrReqReasonByExecuter"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestNo" Name="RequestNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
