<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_DisplayLinkedRequest.aspx.vb" Inherits="EF_DisplayLinkedRequest" title="Display: Linked Request" %>
<asp:Content ID="CPHvrLinkedRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrLinkedRequest" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrLinkedRequest" runat="server" Text="&nbsp;Display: Linked Request" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrLinkedRequest"
    ToolType = "lgNDEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "vrLinkedRequest"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrLinkedRequest"
	runat = "server"
	DataKeyNames = "RequestNo"
	DataSourceID = "ODSvrLinkedRequest"
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
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_RequestDescription" runat="server" Text="Request Description :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_RequestDescription"
						Text='<%# Bind("RequestDescription") %>'
            Width="350px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_SupplierID"
            Width="42px"
						Text='<%# Bind("SupplierID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text='<%# Eval("IDM_Vendors5_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ProjectID"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects4_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SupplierLocation" runat="server" Text="Supplier Location :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_SupplierLocation"
						Text='<%# Bind("SupplierLocation") %>'
            Width="350px" Height="60px"
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_DeliveryLocation" runat="server" Text="Delivery Location :" /></b>
				</td>
				<td>
					<asp:Label ID="F_DeliveryLocation"
						Text='<%# Bind("DeliveryLocation") %>'
            Width="350px" Height="60px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ItemDescription" runat="server" Text="Item Description :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ItemDescription"
						Text='<%# Bind("ItemDescription") %>'
            Width="350px" Height="40px"
					  CssClass="mytxt"
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
					  CssClass="mytxt"
            Runat="Server" >
            <asp:ListItem Value="Domestic">Domestic</asp:ListItem>
            <asp:ListItem Value="Export">Export</asp:ListItem>
          </asp:DropDownList>
         </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SizeUnit" runat="server" Text="Size Unit :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_SizeUnit"
            Width="70px"
						Text='<%# Bind("SizeUnit") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SizeUnit_Display"
						Text='<%# Eval("VR_Units8_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Height"
						Text='<%# Bind("Height") %>'
            Width="42px"
					  CssClass="mytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Width" runat="server" Text="Width :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Width"
						Text='<%# Bind("Width") %>'
            Width="42px"
					  CssClass="mytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Length"
						Text='<%# Bind("Length") %>'
            Width="42px"
					  CssClass="mytxt"
						style="text-align: right"
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
					  CssClass="mytxt"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC/Under Utilization Reason :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ODCReasonID"
            Width="70px"
						Text='<%# Bind("ODCReasonID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ODCReasonID_Display"
						Text='<%# Eval("VR_ODCReasons1_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialSize" runat="server" Text="Vehicle Utilization Status :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MaterialSize"
						Text='<%# Bind("MaterialSize") %>'
            Width="350px"
            BackColor="Black"
            ForeColor="Yellow"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WeightUnit" runat="server" Text="Weight Unit :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_WeightUnit"
            Width="70px"
						Text='<%# Bind("WeightUnit") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_WeightUnit_Display"
						Text='<%# Eval("VR_Units2_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MaterialWeight"
						Text='<%# Bind("MaterialWeight") %>'
            Width="126px"
					  CssClass="mytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_NoOfPackages" runat="server" Text="No. Of Packages :" /></b>
				</td>
				<td>
					<asp:Label ID="F_NoOfPackages"
						Text='<%# Bind("NoOfPackages") %>'
            Width="70px"
					  CssClass="mytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_VehicleTypeID"
            Width="70px"
						Text='<%# Bind("VehicleTypeID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_VehicleTypeID_Display"
						Text='<%# Eval("VR_VehicleTypes9_cmba") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleRequiredOn" runat="server" Text="Vehicle Required On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_VehicleRequiredOn"
						Text='<%# Bind("VehicleRequiredOn") %>'
            Width="140px"
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_MICN" runat="server" Text="MICN :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_MICN"
					  Checked='<%# Bind("MICN") %>'
            Enabled = "False"
					  CssClass="mytxt"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CustomInvoiceNo" runat="server" Text="Custom Invoice No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_CustomInvoiceNo"
						Text='<%# Bind("CustomInvoiceNo") %>'
            Width="350px" 
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            Width="350px" Height="40px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_RequestedBy"
            Width="56px"
						Text='<%# Bind("RequestedBy") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedOn" runat="server" Text="Requested On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_RequestedOn"
						Text='<%# Bind("RequestedOn") %>'
            Width="140px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequesterDivisionID" runat="server" Text="Requester Division ID :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_RequesterDivisionID"
            Width="42px"
						Text='<%# Bind("RequesterDivisionID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequesterDivisionID_Display"
						Text='<%# Eval("HRM_Divisions3_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_RequestStatus" runat="server" Text="Request Status :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_RequestStatus"
            Width="70px"
						Text='<%# Bind("RequestStatus") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestStatus_Display"
						Text='<%# Eval("VR_RequestStates7_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" Text="Request Execution No :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_SRNNo"
            Width="70px"
						Text='<%# Bind("SRNNo") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text='<%# Eval("VR_RequestExecution6_ExecutionDescription") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
        <td></td>
        <td>
          <script type="text/javascript">
						var pcnt = 0;
						function script_download(id, id1, typ) {
      				pcnt = pcnt + 1;
      				var nam = 'wdwd' + pcnt;
      				var url = self.location.href.replace('App_Edit/EF_vrLinkedRequest.aspx', 'App_Downloads/filedownload.aspx');
      				url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
      				window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
      				return false;
						}
					</script>

					<table>
						<tr>
							<td width="300px">
								<asp:UpdatePanel ID="UPNLvrRequestAttachments"  runat="server">
									<ContentTemplate>
										<table width="300px"><tr><td class="sis_formview"> 
										<asp:GridView ID="GVvrRequestAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestAttachments" DataKeyNames="RequestNo,SerialNo">
											<Columns>
												<asp:TemplateField HeaderText="Attachments" SortExpression="Description">
													<ItemTemplate>
														<asp:LinkButton ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>' OnClientClick='<%# Eval("GetLink") %>'></asp:LinkButton>
													</ItemTemplate>
												<HeaderStyle Width="300px" />
												</asp:TemplateField>
											</Columns>
											<EmptyDataTemplate>
												<asp:Label ID="LabelEmpty" runat="server" Font-Size="10px" ForeColor="Red" Text="No Attachment found !!!"></asp:Label>
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
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLinkedRequest"
  DataObjectTypeName = "SIS.VR.vrLinkedRequest"
  SelectMethod = "vrLinkedRequestGetByID"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLinkedRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="RequestNo" Name="RequestNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
