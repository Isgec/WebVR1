<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLinkedExecution.aspx.vb" Inherits="EF_vrLinkedExecution" title="Edit: Linked Execution" %>
<asp:Content ID="CPHvrLinkedExecution" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrLinkedExecution" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrLinkedExecution" runat="server" Text="&nbsp;Edit: Linked Execution" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrLinkedExecution"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "vrLinkedExecution"
    EnableSave="false"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrLinkedExecution"
	runat = "server"
	DataKeyNames = "SRNNo"
	DataSourceID = "ODSvrLinkedExecution"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table width="100%">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" ForeColor="#CC6633" Text="Request Execution No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SRNNo"
						Text='<%# Bind("SRNNo") %>'
            Width="70px"
            Enabled="false"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
						<b><asp:Label ID="Label1" runat="server" ForeColor="#CC6633" Text="Link ID :" /></b>
					<asp:TextBox ID="F_LinkID"
						Text='<%# Bind("LinkID") %>'
            Width="70px"
            Enabled="false"
						CssClass = "dmypktxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_ArrangedBy" runat="server" Text="Arranged By :" /></b>
				</td>
				<td>
					<asp:Label
						ID = "F_ArrangedBy"
            Width="56px"
						Text='<%# Bind("ArrangedBy") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ArrangedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutionDescription" runat="server" Text="Execution Description :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ExecutionDescription"
						Text='<%# Bind("ExecutionDescription") %>'
            Width="300px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_ArrangedOn" runat="server" Text="Arranged On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ArrangedOn"
						Text='<%# Bind("ArrangedOn") %>'
            Width="140px"
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
						Runat="Server" CssClass="mytxt" />
        </td>
        <td>
					<b><asp:Label ID="L_ApprovedBy" runat="server" Text="Approved By :" /></b>
        </td>
        <td>
					<asp:Label
						ID = "F_ApprovedBy"
            Width="56px"
						Text='<%# Bind("ApprovedBy") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ApprovedBy_Display"
						Text='<%# Eval("aspnet_Users3_UserFullName") %>'
						Runat="Server" CssClass="mytxt" />
        </td>
			</tr>
			<tr>
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
				<td>
					<b><asp:Label ID="L_ApprovedOn" runat="server" Text="Approved On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ApprovedOn"
						Text='<%# Bind("ApprovedOn") %>'
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
						Runat="Server" CssClass="mytxt" />
        </td>
        <td>
					<b><asp:Label ID="L_TraficOfficerDivisionID" runat="server" Text="Trafic Officer Division :" /></b>
        </td>
        <td>
					<asp:Label
						ID = "F_TraficOfficerDivisionID"
            Width="42px"
						Text='<%# Bind("TraficOfficerDivisionID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_TraficOfficerDivisionID_Display"
						Text='<%# Eval("HRM_Divisions4_Description") %>'
						Runat="Server" CssClass="mytxt" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_VehicleNo"
						Text='<%# Bind("VehicleNo") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_RequestStatusID" runat="server" Text="Request Status :" /></b>
				</td>
				<td>
					<asp:Label
						ID = "F_RequestStatusID"
            Width="70px"
						Text='<%# Bind("RequestStatusID") %>'
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestStatusID_Display"
						Text='<%# Eval("VR_RequestStates6_Description") %>'
						Runat="Server" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
            Width="300px" Height="40px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_ApprovalRemarks" runat="server" Text="Approval Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ApprovalRemarks"
						Text='<%# Bind("ApprovalRemarks") %>'
            Width="300px" Height="40px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNotPlaced" runat="server" Text="Vehicle Not Placed :" /></b>
				</td>
        <td>
          <asp:CheckBox ID="F_VehicleNotPlaced"
					  Checked='<%# Bind("VehicleNotPlaced") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
        <td rowspan="2">
					<b><asp:Label ID="L_DebitToTransporter" runat="server" Text="Debit To Transporter :" /></b>
				</td>
        <td rowspan="2">
          <asp:CheckBox ID="F_DebitToTransporter"
					  Checked='<%# Bind("DebitToTransporter") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DelayedPlacement" runat="server" Text="Delayed Placement :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DelayedPlacement"
					  Checked='<%# Bind("DelayedPlacement") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturn" runat="server" Text="Empty Return :" /></b>
				</td>
        <td>
          <asp:CheckBox ID="F_EmptyReturn"
					  Checked='<%# Bind("EmptyReturn") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
        <td>
					<b><asp:Label ID="L_PayableToTransporter" runat="server" Text="Payable To Transporter :" /></b>
				</td>
        <td>
          <asp:CheckBox ID="F_PayableToTransporter"
					  Checked='<%# Bind("PayableToTransporter") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DetentionAtSupplier" runat="server" Text="Detention At Supplier :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DetentionAtSupplier"
					  Checked='<%# Bind("DetentionAtSupplier") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
				</td>
				<td>
					<b><asp:Label ID="L_BorneByISGEC" runat="server" Text="Borne By ISGEC :" />
          <asp:CheckBox ID="F_BorneByISGEC"
					  Checked='<%# Bind("BorneByISGEC") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
					</b>
				</td>
				<td>
					<b><asp:Label ID="L_BorneBySupplier" runat="server" Text="Borne By Supplier :" />
          <asp:CheckBox ID="F_BorneBySupplier"
					  Checked='<%# Bind("BorneBySupplier") %>'
            Enabled = "False"
            runat="server" CssClass="mytxt" />
					</b>
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturnRemarks" runat="server" Text="Empty Return/Detention Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_EmptyReturnRemarks"
						Text='<%# Bind("EmptyReturnRemarks") %>'
            Width="300px" Height="40px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_GRRemarks" runat="server" Text="GR Remarks :" /></b>
				</td>
				<td>
					<asp:Label ID="F_GRRemarks"
						Text='<%# Bind("GRRemarks") %>'
            Width="300px" Height="40px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GRNo" runat="server" Text="GR No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_GRNo"
						Text='<%# Bind("GRNo") %>'
            Width="300px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_GRDate" runat="server" Text="GR Date :" /></b>
				</td>
				<td>
					<asp:Label ID="F_GRDate"
						Text='<%# Bind("GRDate") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReachedAtSupplierOn" runat="server" Text="Reached At Supplier On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_ReachedAtSupplierOn"
						Text='<%# Bind("ReachedAtSupplierOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_LoadedOn" runat="server" Text="Loaded On :" /></b>
				</td>
				<td>
					<asp:Label ID="F_LoadedOn"
						Text='<%# Bind("LoadedOn") %>'
            Width="140px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align:center">
					<asp:UpdatePanel ID="UPNLvrLinkedExecution" runat="server">
						<ContentTemplate>
							<table width="94%"><tr><td> 
							<LGM:PageSearchBar 
								ID = "TBLvruLinkedExecution"
								EditUrl = "~/VR_Main/App_Edit/EF_vrLinkedExecution.aspx"
								BarText="Clubbed Executions in Vehicle"
								ValidationGroup = "vrLinkedExecution"
								Skin = "tbl_blue"
								runat = "server" />
							<asp:UpdateProgress ID="UPGSvrLinkedExecution" runat="server" AssociatedUpdatePanelID="UPNLvrLinkedExecution" DisplayAfter="100">
								<ProgressTemplate>
									<span style="color: #ff0033">Loading...</span>
								</ProgressTemplate>
							</asp:UpdateProgress>
							<asp:GridView ID="GVvrLinkedExecution" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestExecution" DataKeyNames="SRNNo">
								<Columns>
									<asp:TemplateField HeaderText="EXE.No" SortExpression="SRNNo">
										<ItemTemplate>
											<asp:Label ID="LabelSRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SRNNo") %>'></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="40px" CssClass="alignright" />
										<ItemStyle CssClass="alignright" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="SUPPLIER">
										<ItemTemplate>
											 <asp:Label ID="L_Supplier" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("Supplier.VendorID") %>' Text='<%# EVal("Supplier.Description") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="100px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="REACHED AT SUPPLIER" SortExpression="ReachedAtSupplierOn">
										<ItemTemplate>
											 <asp:Label ID="L_ReachedAtSupplierOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("ReachedAtSupplierOn") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="MOVED FROM SUPPLIER" SortExpression="LoadedOn">
										<ItemTemplate>
											<asp:Label ID="L_LoadedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LoadedOn") %>'></asp:Label>
										</ItemTemplate>
									<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="DELAYED PLACEMENT" SortExpression="DelayedPlacement">
										<ItemTemplate>
											 <asp:Label ID="L_DelayedPlacement" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("DelayedPlacement") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="DEBIT TO TRANSPORTER" SortExpression="DebitToTransporter">
										<ItemTemplate>
											 <asp:Label ID="L_DebitToTransporter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("DebitToTransporter") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="DETENTION AT SUPPLIER" SortExpression="DetentionAtSupplier">
										<ItemTemplate>
											 <asp:Label ID="L_DetentionAtSupplier" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("DetentionAtSupplier") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="PAYABLE TO TRANSPORTER" SortExpression="PayableToTransporter">
										<ItemTemplate>
											 <asp:Label ID="L_PayableToTransporter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("PayableToTransporter") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="BORNE BY ISGEC" SortExpression="BorneByISGEC">
										<ItemTemplate>
											 <asp:Label ID="L_BorneByISGEC" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("BorneByISGEC") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="BORNE BY SUPPLIER" SortExpression="BorneBySupplier">
										<ItemTemplate>
											 <asp:Label ID="L_BorneBySupplier" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("BorneBySupplier") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="EXECUTER REMARKS" SortExpression="EmptyReturnRemarks">
										<ItemTemplate>
											 <asp:Label ID="L_EmptyReturnRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("EmptyReturnRemarks") %>' ></asp:Label>
										</ItemTemplate>
										<HeaderStyle Width="200px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="GR NO" SortExpression="GRNo">
										<ItemTemplate>
											<asp:Label ID="LabelGRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRNo") %>'></asp:Label>
										</ItemTemplate>
									<HeaderStyle Width="80px" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="GR DATE" SortExpression="GRDate">
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
								ID = "ODSvrRequestExecution"
								runat = "server"
								DataObjectTypeName = "SIS.VR.vrRequestExecution"
								OldValuesParameterFormatString = "original_{0}"
								SelectMethod = "UZ_vrRequestExecutionLinkedSelectList"
								TypeName = "SIS.VR.vrRequestExecution"
								SelectCountMethod = "UZ_vrRequestExecutionLinkedSelectCount"
								SortParameterName="OrderBy" EnablePaging="True">
								<SelectParameters >
									<asp:ControlParameter ControlID="F_LinkID" PropertyName="Text" Name="LinkID" Type="Int32" Size="10" />
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
            runat="server" CssClass="mytxt" />
				</td>
				<td>
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC Reason :" /></b>
				</td>
				<td>
					<asp:Label
						ID = "F_ODCReasonID"
            Width="70px"
						Text='<%# Bind("ODCReasonID") %>'
            Enabled = "False"
            ToolTip="Value of ODC Reason."
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_ODCReasonID_Display"
						Text='<%# Eval("VR_ODCReasons16_Description") %>'
						Runat="Server" CssClass="mytxt" />
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
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_SizeUnit_Display"
						Text='<%# Eval("VR_Units1_Description") %>'
						Runat="Server" CssClass="mytxt" />
        </td>
				<td>
					<b><asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Height"
						Text='<%# Bind("Height") %>'
            Width="42px"
						CssClass = "mytxt"
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
						CssClass = "mytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
				</td>
				<td>
					<asp:Label ID="F_Length"
						Text='<%# Bind("Length") %>'
            Width="42px"
						CssClass = "mytxt"
						style="text-align: right"
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
						CssClass = "mytxt"
						Runat="Server" />
					<asp:Label
						ID = "F_WeightUnit_Display"
						Text='<%# Eval("VR_Units2_Description") %>'
						Runat="Server" CssClass="mytxt" />
        </td>
				<td>
					<b><asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MaterialWeight"
						Text='<%# Bind("MaterialWeight") %>'
            Width="126px"
						CssClass = "mytxt"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_NoOfPackages" runat="server" Text="No Of Packages :" /></b>
				</td>
				<td>
					<asp:Label ID="F_NoOfPackages"
						Text='<%# Bind("NoOfPackages") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						runat="server" />
				</td>
				<td>
					<b><asp:Label ID="L_MaterialSize" runat="server" Text="Vehicle Utilization :" /></b>
				</td>
				<td>
					<asp:Label ID="F_MaterialSize"
						Text='<%# Bind("MaterialSize") %>'
            Width="300px"
						CssClass = "mytxt"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align:center">
				<asp:Panel ID="pnlH" runat="server" CssClass="cph_filter" style="width:93%">
					<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
						<div style="float: left;">Filter Records </div>
						<div style="float: left; margin-left: 20px;">
							<asp:Label ID="lblH" runat="server">(Show Trans Shipment...)</asp:Label>
						</div>
						<div style="float: right; vertical-align: middle;">
							<asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Trans Shipment...)" />
						</div>
					</div>
				</asp:Panel>
				<asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0" style="width:96%">
					<table width="94%" style="text-align:left">
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_TransShipment" runat="server" Text="Trans Shipment :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_TransShipment"
									Checked='<%# Bind("TransShipment") %>'
									Enabled = "False"
									runat="server" CssClass="mytxt" />
							</td>
							<td>
								<b><asp:Label ID="L_TransTransporterID" runat="server" Text="Trans Shipment Transporter ID :" /></b>
							</td>
							<td>
								<asp:Label
									ID = "F_TransTransporterID"
									Width="63px"
									Text='<%# Bind("TransTransporterID") %>'
									CssClass = "mytxt"
									Runat="Server" />
								<asp:Label
									ID = "F_TransTransporterID_Display"
									Text='<%# Eval("VR_Transporters8_TransporterName") %>'
									Runat="Server" CssClass="mytxt" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_TransGRNO" runat="server" Text="Trans Shipment GR No :" /></b>
							</td>
							<td>
								<asp:Label ID="F_TransGRNO"
									Text='<%# Bind("TransGRNO") %>'
									Width="300px"
									CssClass = "mytxt"
									runat="server" />
							</td>
							<td>
								<b><asp:Label ID="L_TransGRDate" runat="server" Text="Trans Shipment GR Date :" /></b>
							</td>
							<td>
								<asp:Label ID="F_TransGRDate"
									Text='<%# Bind("TransGRDate") %>'
									Width="140px"
									CssClass = "mytxt"
									runat="server" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_TransVehicleNo" runat="server" Text="Trans Shipment Vehicle No :" /></b>
							</td>
							<td>
								<asp:Label ID="F_TransVehicleNo"
									Text='<%# Bind("TransVehicleNo") %>'
									Width="140px"
									CssClass = "mytxt"
									runat="server" />
							</td>
							<td>
								<b><asp:Label ID="L_TransVehicleTypeID" runat="server" Text="Trans Shipment Vehicle Type ID :" /></b>
							</td>
							<td>
								<asp:Label
									ID = "F_TransVehicleTypeID"
									Width="70px"
									Text='<%# Bind("TransVehicleTypeID") %>'
									CssClass = "mytxt"
									Runat="Server" />
								<asp:Label
									ID = "F_TransVehicleTypeID_Display"
									Text='<%# Eval("VR_VehicleTypes14_cmba") %>'
									Runat="Server" CssClass="mytxt" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_TransRemarks" runat="server" Text="Trans Shipment Remarks :" /></b>
							</td>
							<td colspan="3">
								<asp:Label ID="F_TransRemarks"
									Text='<%# Bind("TransRemarks") %>'
									Width="600px"
									CssClass = "mytxt"
									runat="server" />
							</td>
						</tr>
					</table>
				</asp:Panel>
				<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Trans Shipment...)" CollapsedText="(Show Trans Shipment...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align:center">
					<asp:Panel ID="pnlHrs" runat="server" CssClass="cph_filter" style="width:93%">
					<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
						<div style="float: left;">Filter Records </div>
						<div style="float: left; margin-left: 20px;">
							<asp:Label ID="lblHrs" runat="server">(Show Site Receipt...)</asp:Label>
						</div>
						<div style="float: right; vertical-align: middle;">
							<asp:ImageButton ID="imgHrs" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Trans Shipment...)" />
						</div>
  					</div>
	  			</asp:Panel>
		  		<asp:Panel ID="pnlDrs" runat="server" CssClass="cp_filter" Height="0" style="width:96%">
			  		<table width="94%" style="text-align:left">
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReceiptAtSite" runat="server" Text="Receipt At Site :" /></b>
								</td>
								<td>
									<asp:CheckBox ID="F_ReceiptAtSite"
										Checked='<%# Bind("ReceiptAtSite") %>'
										Enabled = "False"
										runat="server" CssClass="mytxt" />
								</td>
								<td>
									&nbsp;</td>
								<td>
									&nbsp;</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReceiptBy" runat="server" Text="Receipt By :" /></b>
								</td>
								<td>
									<asp:Label
										ID = "F_ReceiptBy"
										Width="56px"
										Text='<%# Bind("ReceiptBy") %>'
										CssClass = "mytxt"
										Runat="Server" />
									<asp:Label
										ID = "F_ReceiptBy_Display"
										Text='<%# Eval("aspnet_Users2_UserFullName") %>'
										Runat="Server" CssClass="mytxt" />
								</td>
								<td>
									<b><asp:Label ID="L_ReceiptOn" runat="server" Text="Receipt On :" /></b>
								</td>
								<td>
									<asp:Label ID="F_ReceiptOn"
										Text='<%# Bind("ReceiptOn") %>'
										Width="140px"
										CssClass = "mytxt"
										runat="server" />
								</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_MaterialStateID" runat="server" Text="Material State ID :" /></b>
								</td>
								<td>
									<asp:Label
										ID = "F_MaterialStateID"
										Width="70px"
										Text='<%# Bind("MaterialStateID") %>'
										CssClass = "mytxt"
										Runat="Server" />
									<asp:Label
										ID = "F_MaterialStateID_Display"
										Text='<%# Eval("VR_MaterialStates5_Description") %>'
										Runat="Server" CssClass="mytxt" />
								</td>
								<td>
									<b><asp:Label ID="L_ReceiptMaterialSize" runat="server" Text="Receipt Material Size :" /></b>
								</td>
								<td>
									<asp:Label ID="F_ReceiptMaterialSize"
										Text='<%# Bind("ReceiptMaterialSize") %>'
										Width="300px"
										CssClass = "mytxt"
										runat="server" />
								</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReceiptSizeUnit" runat="server" Text="Receipt Weight Unit :" /></b>
								</td>
								<td>
									<asp:Label
										ID = "F_ReceiptSizeUnit"
										Width="70px"
										Text='<%# Bind("ReceiptSizeUnit") %>'
										CssClass = "mytxt"
										Runat="Server" />
									<asp:Label
										ID = "F_ReceiptSizeUnit_Display"
										Text='<%# Eval("VR_Units11_Description") %>'
										Runat="Server" CssClass="mytxt" />
								</td>
								<td>
									<b><asp:Label ID="L_ReceiptMaterialWeight" runat="server" Text="Receipt Material Weight :" /></b>
								</td>
								<td>
									<asp:Label ID="F_ReceiptMaterialWeight"
										Text='<%# Bind("ReceiptMaterialWeight") %>'
										Width="126px"
										CssClass = "mytxt"
										style="text-align: right"
										runat="server" />
								</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReceiptNoOfPackages" runat="server" Text="Receipt No. Of Packages :" /></b>
								</td>
								<td>
									<asp:Label ID="F_ReceiptNoOfPackages"
										Text='<%# Bind("ReceiptNoOfPackages") %>'
										Width="70px"
										CssClass = "mytxt"
										style="text-align: right"
										runat="server" />
								</td>
								<td>
									&nbsp;</td>
								<td>
									&nbsp;</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReachedOn" runat="server" Text="Reached At Site On :" /></b>
								</td>
								<td>
									<asp:Label ID="F_ReachedOn"
										Text='<%# Bind("ReachedOn") %>'
										Width="140px"
										CssClass = "mytxt"
										runat="server" />
								</td>
								<td>
									<b><asp:Label ID="L_UnloadedOn" runat="server" Text="Unloaded On :" /></b>
								</td>
								<td>
									<asp:Label ID="F_UnloadedOn"
										Text='<%# Bind("UnloadedOn") %>'
										Width="140px"
										CssClass = "mytxt"
										runat="server" />
								</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_SiteReceiptNo" runat="server" Text="Site Receipt No :" /></b>
								</td>
								<td>
									<asp:Label ID="F_SiteReceiptNo"
										Text='<%# Bind("SiteReceiptNo") %>'
										Width="300px"
										CssClass = "mytxt"
										runat="server" />
								</td>
								<td>
									<b><asp:Label ID="L_SiteReceiptDate" runat="server" Text="Site Receipt Date :" /></b>
								</td>
								<td>
									<asp:Label ID="F_SiteReceiptDate"
										Text='<%# Bind("SiteReceiptDate") %>'
										Width="140px"
										CssClass = "mytxt"
										runat="server" />
								</td>
							</tr>
							<tr>
								<td class="alignright">
									<b><asp:Label ID="L_ReceiptRemarks" runat="server" Text="Receipt Remarks :" /></b>
								</td>
								<td colspan="3">
									<asp:Label ID="F_ReceiptRemarks"
										Text='<%# Bind("ReceiptRemarks") %>'
										ToolTip="Value of Receipt Remarks."
										Enabled = "False"
										Width="600px"
										CssClass = "mytxt"
										runat="server" />
								</td>
							</tr>
				  	</table>
				  </asp:Panel>
				  <AJX:CollapsiblePanelExtender ID="cpers1" runat="Server" TargetControlID="pnlDrs" ExpandControlID="pnlHrs" CollapseControlID="pnlHrs" Collapsed="True" TextLabelID="lblHrs" ImageControlID="imgHrs" ExpandedText="(Hide Site Receipt...)" CollapsedText="(Show Site Receipt...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
				</td>
			</tr>
			<tr>
				<td colspan="4" style="text-align:center">
				<asp:Panel ID="pnlHsr" runat="server" CssClass="cph_filter" style="width:93%">
					<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
						<div style="float: left;">Filter Records </div>
						<div style="float: left; margin-left: 20px;">
							<asp:Label ID="lblHsr" runat="server">(Show Trans Shipment at Site...)</asp:Label>
						</div>
						<div style="float: right; vertical-align: middle;">
							<asp:ImageButton ID="imgHsr" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Trans Shipment...)" />
						</div>
					</div>
				</asp:Panel>
				<asp:Panel ID="pnlDsr" runat="server" CssClass="cp_filter" Height="0" style="width:96%">
					<table width="94%" style="text-align:left">
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_TransShipmentAtSite" runat="server" Text="Trans Shipment At Site :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_TransShipmentAtSite"
									Checked='<%# Bind("TransShipmentAtSite") %>'
									Enabled = "False"
									runat="server" CssClass="mytxt" />
							</td>
							<td>
								<b><asp:Label ID="L_SiteTransporterID" runat="server" Text="Site Transporter ID :" /></b>
							</td>
							<td>
								<asp:Label
									ID = "F_SiteTransporterID"
									Width="63px"
									Text='<%# Bind("SiteTransporterID") %>'
									CssClass = "mytxt"
									Runat="Server" />
								<asp:Label
									ID = "F_SiteTransporterID_Display"
									Text='<%# Eval("VR_Transporters9_TransporterName") %>'
									Runat="Server" CssClass="mytxt" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_SiteGRNO" runat="server" Text="Site GR No :" /></b>
							</td>
							<td>
								<asp:Label ID="F_SiteGRNO"
									Text='<%# Bind("SiteGRNO") %>'
									Width="300px"
									CssClass = "mytxt"
									runat="server" />
							</td>
							<td>
								<b><asp:Label ID="L_SiteGRDate" runat="server" Text="Site GR Date :" /></b>
							</td>
							<td>
								<asp:Label ID="F_SiteGRDate"
									Text='<%# Bind("SiteGRDate") %>'
									Width="140px"
									CssClass = "mytxt"
									runat="server" />
							</td>
						</tr>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_SiteVehicleNo" runat="server" Text="Site Vehicle No :" /></b>
							</td>
							<td>
								<asp:Label ID="F_SiteVehicleNo"
									Text='<%# Bind("SiteVehicleNo") %>'
									Width="140px"
									CssClass = "mytxt"
									runat="server" />
							</td>
							<td>
								<b><asp:Label ID="L_SiteVehicleTypeID" runat="server" Text="Site Vehicle Type ID :" /></b>
							</td>
							<td>
								<asp:Label
									ID = "F_SiteVehicleTypeID"
									Width="70px"
									Text='<%# Bind("SiteVehicleTypeID") %>'
									CssClass = "mytxt"
									Runat="Server" />
								<asp:Label
									ID = "F_SiteVehicleTypeID_Display"
									Text='<%# Eval("VR_VehicleTypes12_cmba") %>'
									Runat="Server" CssClass="mytxt" />
							</td>
						</tr>
					</table>
				</asp:Panel>
				<AJX:CollapsiblePanelExtender ID="cpesr1" runat="Server" TargetControlID="pnlDsr" ExpandControlID="pnlHsr" CollapseControlID="pnlHsr" Collapsed="True" TextLabelID="lblHsr" ImageControlID="imgHsr" ExpandedText="(Hide Trans Shipment at site...)" CollapsedText="(Show Trans Shipment at site...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
				</td>
			</tr>
			
			</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLinkedExecution"
  DataObjectTypeName = "SIS.VR.vrLinkedExecution"
  SelectMethod = "UZ_vrLinkedExecutionGetByID"
  UpdateMethod="UZ_vrLinkedExecutionUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLinkedExecution"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SRNNo" Name="SRNNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
