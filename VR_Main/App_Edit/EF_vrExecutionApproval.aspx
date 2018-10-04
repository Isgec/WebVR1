<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrExecutionApproval.aspx.vb" Inherits="EF_vrExecutionApproval" title="Edit: Request Execution Approval" %>
<asp:Content ID="CPHvrExecutionApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrExecutionApproval" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrExecutionApproval" runat="server" Text="&nbsp;Edit: Request Execution Approval" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrExecutionApproval"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrExecutionApproval"
    EnableSave="false"
    Skin = "tbl_blue"
    EnableDelete="false"
    runat = "server" />
<asp:FormView ID="FVvrExecutionApproval"
	runat = "server"
	DataKeyNames = "SRNNo"
	DataSourceID = "ODSvrExecutionApproval"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
    <script type="text/javascript">
    	var pcnt = 0;
    	function script_download(id, id1, typ) {
    		pcnt = pcnt + 1;
    		var nam = 'wdwd' + pcnt;
    		var url = self.location.href.replace('App_Edit/EF_vrExecutionApproval.aspx', 'App_Downloads/filedownload.aspx');
    		url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
    		window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
    		return false;
    	}
    </script>
		<table width="100%">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" ForeColor="#CC6633" Text="Request Execution No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SRNNo"
						Text='<%# Bind("SRNNo") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutionDescription" runat="server" Text="Execution Description :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ExecutionDescription"
						Text='<%# Bind("ExecutionDescription") %>'
            Width="350px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" /></b>
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
						Text='<%# Eval("VR_Transporters10_TransporterName") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_VehiclePlacedOn" runat="server" Text="Vehicle Placed On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_VehiclePlacedOn"
						Text='<%# Bind("VehiclePlacedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_VehicleTypeID"
            Width="70px"
						Text='<%# Bind("VehicleTypeID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_VehicleTypeID_Display"
						Text='<%# Eval("VR_VehicleTypes13_cmba") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_VehicleNo"
						Text='<%# Bind("VehicleNo") %>'
            Width="140px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td colspan="3">
					<asp:Label ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            Width="400px" 
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ArrangedBy" runat="server" Text="Executed By :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_ArrangedBy"
            Width="56px"
						Text='<%# Bind("ArrangedBy") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ArrangedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_ArrangedOn" runat="server" Text="Executed On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ArrangedOn"
						Text='<%# Bind("ArrangedOn") %>'
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TraficOfficerDivisionID" runat="server" Text="Trafic Officer Division :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_TraficOfficerDivisionID"
            Width="42px"
						Text='<%# Bind("TraficOfficerDivisionID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_TraficOfficerDivisionID_Display"
						Text='<%# Eval("HRM_Divisions4_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_RequestStatusID" runat="server" Text="Request Status :" /></b>
				</td>
        <td>
					<asp:Label
						ID = "F_RequestStatusID"
            Width="70px"
						Text='<%# Bind("RequestStatusID") %>'
					  CssClass="mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestStatusID_Display"
						Text='<%# Eval("VR_RequestStates6_Description") %>'
					  CssClass="mytxt"
						Runat="Server" />
        </td>
			</tr>
			<tr>
			<td colspan="4" style="background-color:Gray; color:Blue; text-align:center">
			<b><asp:Label ID="Label4" runat="server" Text="-----DETAILS WHILE LOADED AT SUPPLIER WORKS-----" /></b>
			</td>
			</tr>
			<tr >
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNotPlaced" ForeColor="Red" runat="server" Text="VEHICLE NOT PLACED :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_VehicleNotPlaced"
					  Checked='<%# Bind("VehicleNotPlaced") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
				<td class="alignright" rowspan="2">
					<b><asp:Label ID="L_DebitToTransporter" runat="server" Text="Debit To Transporter :" /></b>
				</td>
				<td rowspan="2">
          <asp:CheckBox ID="F_DebitToTransporter"
					  Checked='<%# Bind("DebitToTransporter") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
			</tr>
			<tr >
				<td class="alignright">
					<b><asp:Label ID="L_DelayedPlacement" runat="server" Text="Delayed Placement :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DelayedPlacement"
					  Checked='<%# Bind("DelayedPlacement") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
			</tr>
			
			<tr >
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturn" ForeColor="Red" runat="server" Text="EMPTY RETURN :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EmptyReturn"
					  Checked='<%# Bind("EmptyReturn") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_PayableToTransporter" runat="server" Text="Payable To Transporter :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_PayableToTransporter"
					  Checked='<%# Bind("PayableToTransporter") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
			</tr>
			<tr >
				<td class="alignright">
					<b><asp:Label ID="L_DetentionAtSupplier" runat="server" Text="Detention At Supplier :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DetentionAtSupplier"
					  Checked='<%# Bind("DetentionAtSupplier") %>'
					  Enabled="false"
					  CssClass="mytxt"
            runat="server" />
				</td>
				<td colspan="2">
					<table>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_BorneByISGEC" runat="server" Text="Borne By ISGEC :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_BorneByISGEC"
									Checked='<%# Bind("BorneByISGEC") %>'
					  Enabled="false"
					  CssClass="mytxt"
									runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_BorneBySupplier" runat="server" Text="Borne By Supplier :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_BorneBySupplier"
									Checked='<%# Bind("BorneBySupplier") %>'
					  Enabled="false"
					  CssClass="mytxt"
									runat="server" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr >
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturnRemarks" runat="server" Text="Empty Return/Detention Remarks :" /></b>
				</td>
				<td colspan="3">
					<asp:Label ID="F_EmptyReturnRemarks"
						Text='<%# Bind("EmptyReturnRemarks") %>'
            Width="400px" 
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
		  <tr>
				<td class="alignright">
					<b><asp:Label ID="Label1" ForeColor="Black" runat="server" Text="GR NO :" /></b>
				</td>
				<td>
					<asp:Label ID="F_GRNO" 
					  CssClass="mytxt"
						width="100px" 
						runat="server" 
						Text='<%# Bind("GRNo") %>' />
				</td>
				<td class="alignright">
					<b><asp:Label ID="Label2" ForeColor="Black" runat="server" Text="GR DATE :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_GRDate" 
					  Text='<%# Bind("GRDate") %>' 
					  Width="70px" 
					  CssClass="mytxt"
  					runat="server" />
				</td>
		  </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReachedAtSupplierOn" runat="server" Text="Reached To Supplier On :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_ReachedAtSupplierOn"
						Text='<%# Bind("ReachedAtSupplierOn") %>'
            Width="110px"
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_LoadedOn" ForeColor="Black" runat="server" Text="Left From Supplier On :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_LoadedOn" 
					  Text='<%# Bind("LoadedOn") %>' 
					  Width="110px" 
					  CssClass="mytxt"
  					runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OverDimentionConsignement" runat="server" Text="ODC :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_OverDimentionConsignement"
					 Checked='<%# Bind("OverDimentionConsignement") %>'
            Enabled = "False"
					  CssClass="mytxt"
           runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC Reason :" /></b>
				</td>
				<td>
          <asp:Label 
            ID="F_ODCReasonID"
            Text='<%# Eval("VR_ODCReasons16_Description") %>'
            Width="350px"
					  CssClass="mytxt"
            Runat="Server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SizeUnit" runat="server" Text="Size Unit :" /></b>
				</td>
        <td>
          <LGM:LC_vrUnits
            ID="F_SizeUnit"
            SelectedValue='<%# Bind("SizeUnit") %>'
            OrderBy="Size"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="80px"
					  CssClass="mytxt"
					  enabled="false"
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_Length"
						Text='<%# Bind("Length") %>'
            Width="70px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Width" runat="server" Text="Width :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_Width"
						Text='<%# Bind("Width") %>'
            Width="70px"
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_Height"
						Text='<%# Bind("Height") %>'
            Width="70px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WeightUnit" runat="server" Text="Weight Unit :" /></b>
				</td>
        <td>
          <LGM:LC_vrUnits
            ID="F_WeightUnit"
            SelectedValue='<%# Bind("WeightUnit") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="80px"
					  CssClass="mytxt"
					  Enabled="false"
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_MaterialWeight"
						Text='<%# Bind("MaterialWeight") %>'
            Width="70px"
					  CssClass="mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_NoOfPackages" runat="server" Text="No Of Packages :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_NoOfPackages"
						Text='<%# Bind("NoOfPackages") %>'
            Width="70px"
					  CssClass="mytxt"
						runat="server" />
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GRRemarks" runat="server" Text="GR Remarks :" /></b>
				</td>
				<td>
					<asp:Label 
					  ID="F_GRRemarks"
						Text='<%# Bind("GRRemarks") %>'
					  CssClass="mytxt"
            Width="400px" 
						runat="server" />
				</td>
				<td></td>
				<td>
					<table width="100%">
						<tr>
							<td>
									<asp:UpdatePanel ID="UPNLvrExecutionAttachments" runat="server">
										<ContentTemplate>
											<table width="300px"><tr><td class="sis_formview"> 
											<asp:UpdateProgress ID="UPGSvrExecutionAttachments" runat="server" AssociatedUpdatePanelID="UPNLvrExecutionAttachments" DisplayAfter="100">
												<ProgressTemplate>
													<span style="color: #ff0033">Loading...</span>
												</ProgressTemplate>
											</asp:UpdateProgress>
											<asp:GridView ID="GVvrExecutionAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrExecutionAttachments" DataKeyNames="SRNNo,SerialNo">
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
												ID = "ODSvrExecutionAttachments"
												runat = "server"
												DataObjectTypeName = "SIS.VR.vrExecutionAttachments"
												OldValuesParameterFormatString = "original_{0}"
												SelectMethod = "vrExecutionAttachmentsSelectList"
												TypeName = "SIS.VR.vrExecutionAttachments"
												SelectCountMethod = "vrExecutionAttachmentsSelectCount"
												SortParameterName="OrderBy" EnablePaging="True">
												<SelectParameters >
													<asp:ControlParameter ControlID="F_SRNNo" PropertyName="Text" Name="SRNNo" Type="Int32" Size="10" />
													<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
													<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
												</SelectParameters>
											</asp:ObjectDataSource>
											<br />
										</td></tr></table>
										</ContentTemplate>
										<Triggers>
											<asp:AsyncPostBackTrigger ControlID="GVvrExecutionAttachments" EventName="PageIndexChanged" />
										</Triggers>
									</asp:UpdatePanel>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			
		</table>
<asp:UpdatePanel ID="UPNLvrLinkedRequest" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrLinkedRequest" runat="server" Text="&nbsp;List: Linked Request" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLinkedRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLinkedRequest.aspx"
      EnableAdd = "False"
      EnableExit = "false"
      ValidationGroup = "vrLinkedRequest"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLinkedRequest" runat="server" AssociatedUpdatePanelID="UPNLvrLinkedRequest" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrLinkedRequest" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrLinkedRequest" DataKeyNames="RequestNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request No" SortExpression="RequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Description" SortExpression="RequestDescription">
          <ItemTemplate>
            <asp:Label ID="LabelRequestDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier ID" SortExpression="IDM_Vendors5_Description">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Type" SortExpression="ProjectType">
          <ItemTemplate>
            <asp:Label ID="LabelProjectType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectType") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VR_VehicleTypes9_cmba">
          <ItemTemplate>
             <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes9_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Required On" SortExpression="VehicleRequiredOn">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleRequiredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRequiredOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Status" SortExpression="VR_RequestStates7_Description">
          <ItemTemplate>
             <asp:Label ID="L_RequestStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatus") %>' Text='<%# Eval("VR_RequestStates7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delink Request">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delink Request" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Delink Request record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLinkedRequest"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLinkedRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrLinkedRequestSelectList"
      TypeName = "SIS.VR.vrLinkedRequest"
      SelectCountMethod = "vrLinkedRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SRNNo" PropertyName="Text" Name="SRNNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLinkedRequest" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrExecutionApproval"
  DataObjectTypeName = "SIS.VR.vrExecutionApproval"
  SelectMethod = "vrExecutionApprovalGetByID"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrExecutionApproval"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SRNNo" Name="SRNNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
