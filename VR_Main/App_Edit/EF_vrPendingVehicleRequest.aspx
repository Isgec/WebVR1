<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrPendingVehicleRequest.aspx.vb" Inherits="EF_vrPendingVehicleRequest" title="View: Pending Vehicle Request" %>
<asp:Content ID="CPHvrPendingVehicleRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPendingVehicleRequest" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrPendingVehicleRequest" runat="server" Text="&nbsp;View: Pending Vehicle Request" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrPendingVehicleRequest"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    EnablePrint = "True"
    EnableSave="false"
    PrintUrl = "../App_Print/RP_vrPendingVehicleRequest.aspx?pk="
    ValidationGroup = "vrPendingVehicleRequest"
    Skin = "tbl_blue"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVvrPendingVehicleRequest"
	runat = "server"
	DataKeyNames = "RequestNo"
	DataSourceID = "ODSvrPendingVehicleRequest"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
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
            Width="70px"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
				</td>
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
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
            Width="42px"
						Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier ID."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("IDM_Vendors5_Description") %>'
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Project ID."
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
					<b><asp:Label ID="L_SupplierLocation" runat="server" Text="Supplier Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SupplierLocation"
						Text='<%# Bind("SupplierLocation") %>'
            ToolTip="Value of Supplier Location."
            TextMode="MultiLine"
            Enabled = "False"
            Width="350px" Height="60px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DeliveryLocation" runat="server" Text="Delivery Location :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DeliveryLocation"
						Text='<%# Bind("DeliveryLocation") %>'
            ToolTip="Value of Delivery Location."
            TextMode="MultiLine"
            Enabled = "False"
            Width="350px" Height="60px"
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
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
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
					<b><asp:Label ID="L_MaterialSize" runat="server" Text="Vehicle Utilization Status :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MaterialSize"
						Text='<%# Bind("MaterialSize") %>'
            ToolTip="Value of Material Size."
            Width="126px"
						CssClass = "dmymsg"
						style="text-align: right"
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
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_VehicleTypeID"
            Width="70px"
						Text='<%# Bind("VehicleTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Vehicle Type ID."
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
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC/Under Utilization Reason :" /></b>
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
				<td class="alignright">
					<b><asp:Label ID="L_MICN" runat="server" Text="MICN :" /></b>
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
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
						CssClass = "dmytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Customer Invoice No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CustomInvoiceNo"
						Text='<%# Bind("CustomInvoiceNo") %>'
            ToolTip="Value of Customer Invoice No."
            Enabled = "False"
            Width="350px" Height="40px"
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
				<td class="alignright">
					<b><asp:Label ID="L_ReturnedBy" runat="server" Text="Returned By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ReturnedBy"
            Width="56px"
						Text='<%# Bind("ReturnedBy") %>'
            Enabled = "False"
            ToolTip="Value of Returned By."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ReturnedBy_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
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
				<td class="alignright">
					<b><asp:Label ID="L_ReturnedOn" runat="server" Text="Returned On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReturnedOn"
						Text='<%# Bind("ReturnedOn") %>'
            ToolTip="Value of Returned On."
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
				<td class="alignright">
					<b><asp:Label ID="L_ReturnRemarks" runat="server" Text="Return Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReturnRemarks"
						Text='<%# Bind("ReturnRemarks") %>'
            ToolTip="Value of Return Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
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
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" Text="Req.Execution No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SRNNo"
            Width="70px"
						Text='<%# Bind("SRNNo") %>'
            Enabled = "False"
            ToolTip="Value of Linked SRN."
						CssClass = "dmyfktxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text='<%# Eval("VR_RequestExecution6_ExecutionDescription") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
        <td colspan="2">
          <script type="text/javascript">
          	var pcnt = 0;
          	function script_download(id, id1, typ) {
          		pcnt = pcnt + 1;
          		var nam = 'wdwd' + pcnt;
          		var url = self.location.href.replace('App_Edit/EF_vrPendingVehicleRequest.aspx', 'App_Downloads/filedownload.aspx');
          		url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
          		window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
          		return false;
          	}
					</script>
					<table>
						<tr>
							<td width="500px">
								<asp:UpdatePanel ID="UPNLvrRequestAttachments"  runat="server">
									<ContentTemplate>
										<table width="500px"><tr><td class="sis_formview"> 
										<LGM:AttachmentBar
											ID = "TBLvrRequestAttachments"
											ToolType = "lgNMGrid"
											EditUrl = "~/VR_Main/App_Edit/EF_vrRequestAttachments.aspx"
											AddPostBack = "True"
											EnableExit = "false"
											ValidationGroup = "vrRequestAttachments"
											Skin = "tbl_blue"
										  AttachVisible="false"
											runat = "server" />
										<asp:UpdateProgress ID="UPGSvrRequestAttachments" runat="server" AssociatedUpdatePanelID="UPNLvrRequestAttachments" DisplayAfter="100">
											<ProgressTemplate>
												<span style="color: #ff0033">Loading...</span>
											</ProgressTemplate>
										</asp:UpdateProgress>
										<asp:GridView ID="GVvrRequestAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestAttachments" DataKeyNames="RequestNo,SerialNo">
											<Columns>
												<asp:TemplateField HeaderText="SerialNo" SortExpression="SerialNo">
													<ItemTemplate>
														<asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
													</ItemTemplate>
													<HeaderStyle CssClass="alignright" />
													<ItemStyle CssClass="alignright" />
													<HeaderStyle Width="40px" />
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Description" SortExpression="Description">
													<ItemTemplate>
														<asp:LinkButton ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>' OnClientClick='<%# Eval("GetLink") %>'></asp:LinkButton>
													</ItemTemplate>
												<HeaderStyle Width="400px" />
												</asp:TemplateField>
											</Columns>
											<EmptyDataTemplate>
												<asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
											</EmptyDataTemplate>
										</asp:GridView>
										<asp:ObjectDataSource 
											ID = "ODSvrRequestAttachments"
											runat = "server"
											DataObjectTypeName = "SIS.VR.vrRequestAttachments"
											OldValuesParameterFormatString = "original_{0}"
											SelectMethod = "vrRequestAttachmentsSelectList"
											TypeName = "SIS.VR.vrRequestAttachments"
											SelectCountMethod = "vrRequestAttachmentsSelectCount"
											SortParameterName="OrderBy" EnablePaging="True">
											<SelectParameters >
												<asp:ControlParameter ControlID="F_RequestNo" PropertyName="Text" Name="RequestNo" Type="Int32" Size="10" />
												<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
												<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
											</SelectParameters>
										</asp:ObjectDataSource>
										<br />
									</td></tr></table>
									</ContentTemplate>
									<Triggers>
										<asp:AsyncPostBackTrigger ControlID="GVvrRequestAttachments" EventName="PageIndexChanged" />
									</Triggers>
								</asp:UpdatePanel>
							</td>
						</tr>
					</table>
        
        </td>
        <td colspan="2">
        	<table>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="Label1" runat="server" Text="MICN Attended :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="CheckBox1"
								 Checked='<%# Bind("MICN") %>'
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_CustomInvoiceIssued" runat="server" Text="Custom Invoice Attended :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_CustomInvoiceIssued"
								 Checked='<%# Bind("CustomInvoiceIssued") %>'
								 enabled="false"
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
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_ARE1Issued" runat="server" Text="ARE-1 Attended :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_ARE1Issued"
								 Checked='<%# Bind("ARE1Issued") %>'
								 enabled="false"
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
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_PaymentChecked" runat="server" Text="Payment Checked :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_PaymentChecked"
								 Checked='<%# Bind("PaymentChecked") %>'
								 enabled="false"
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
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_POApproved" runat="server" Text="PO Approved :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_POApproved"
								 Checked='<%# Bind("POApproved") %>'
								 enabled="false"
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
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_MarkingDetails" runat="server" Text="Marking Details :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_MarkingDetails"
								 Checked='<%# Bind("MarkingDetails") %>'
								 enabled="false"
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
								 enabled="false"
								 runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_PackageStckable" runat="server" Text="Package Stckable :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_PackageStckable"
								 Checked='<%# Bind("PackageStckable") %>'
								 enabled="false"
								 runat="server" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_OutOfContract" runat="server" ForeColor="Brown" Text="Out Of Contract :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_OutOfContract"
								 Checked='<%# Bind("OutOfContract") %>'
								 enabled="false"
								 runat="server" />
							</td>
							<td></td>						
							<td></td>
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
  ID = "ODSvrPendingVehicleRequest"
  DataObjectTypeName = "SIS.VR.vrPendingVehicleRequest"
  SelectMethod = "vrPendingVehicleRequestGetByID"
  UpdateMethod="UZ_vrPendingVehicleRequestUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrPendingVehicleRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestNo" Name="RequestNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
