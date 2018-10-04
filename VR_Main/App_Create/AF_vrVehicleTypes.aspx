<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrVehicleTypes.aspx.vb" Inherits="AF_vrVehicleTypes" title="Add: Vehicle Types" %>
<asp:Content ID="CPHvrVehicleTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVehicleTypes" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrVehicleTypes" runat="server" Text="&nbsp;Add: Vehicle Types" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrVehicleTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/VR_Main/App_Edit/EF_vrVehicleTypes.aspx"
    ValidationGroup = "vrVehicleTypes"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrVehicleTypes"
	runat = "server"
	DataKeyNames = "VehicleTypeID"
	DataSourceID = "ODSvrVehicleTypes"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrVehicleTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" ForeColor="#CC6633" runat="server" Text="Vehicle Type ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehicleTypeID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="vrVehicleTypes"
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
						ValidationGroup = "vrVehicleTypes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DefineCapacity" runat="server" Text="Define Capacity :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DefineCapacity"
					 Checked='<%# Bind("DefineCapacity") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_CapacityInKG" runat="server" Text="Capacity In KG :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CapacityInKG"
						Text='<%# Bind("CapacityInKG") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVehicleTypes"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEECapacityInKG"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_CapacityInKG" />
					<AJX:MaskedEditValidator 
						ID = "MEVCapacityInKG"
						runat = "server"
						ControlToValidate = "F_CapacityInKG"
						ControlExtender = "MEECapacityInKG"
						InvalidValueMessage = "Invalid value for Capacity In KG."
						EmptyValueMessage = "Capacity In KG is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Capacity In KG."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Capacity In KG should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DefineDimention" runat="server" Text="Define Dimention :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DefineDimention"
					 Checked='<%# Bind("DefineDimention") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_HeightInFt" runat="server" Text="Height In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_HeightInFt"
						Text='<%# Bind("HeightInFt") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEHeightInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_HeightInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVHeightInFt"
						runat = "server"
						ControlToValidate = "F_HeightInFt"
						ControlExtender = "MEEHeightInFt"
						InvalidValueMessage = "Invalid value for Height In Ft."
						EmptyValueMessage = "Height In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Height In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Height In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WidthInFt" runat="server" Text="Width In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_WidthInFt"
						Text='<%# Bind("WidthInFt") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEWidthInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_WidthInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVWidthInFt"
						runat = "server"
						ControlToValidate = "F_WidthInFt"
						ControlExtender = "MEEWidthInFt"
						InvalidValueMessage = "Invalid value for Width In Ft."
						EmptyValueMessage = "Width In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Width In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Width In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LengthInFt" runat="server" Text="Length In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LengthInFt"
						Text='<%# Bind("LengthInFt") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEELengthInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_LengthInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVLengthInFt"
						runat = "server"
						ControlToValidate = "F_LengthInFt"
						ControlExtender = "MEELengthInFt"
						InvalidValueMessage = "Invalid value for Length In Ft."
						EmptyValueMessage = "Length In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Length In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Length In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DailyRunning" runat="server" Text="Daily Avg. Running :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DailyRunning"
						Text='<%# Bind("DailyRunning") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						MaxLength="5"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDailyRunning"
						runat = "server"
						mask = "99999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DailyRunning" />
					<AJX:MaskedEditValidator 
						ID = "MEVDailyRunning"
						runat = "server"
						ControlToValidate = "F_DailyRunning"
						ControlExtender = "MEEDailyRunning"
						InvalidValueMessage = "Invalid value for Daily Avg. Running."
						EmptyValueMessage = "Daily Avg. Running is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Daily Avg. Running."
						EnableClientScript = "true"
						IsValidEmpty = "True"
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
  ID = "ODSvrVehicleTypes"
  DataObjectTypeName = "SIS.VR.vrVehicleTypes"
  InsertMethod="UZ_vrVehicleTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrVehicleTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
