<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrVTDefault.aspx.vb" Inherits="AF_vrVTDefault" title="Add: Vehicle Request Defaults" %>
<asp:Content ID="CPHvrVTDefault" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVTDefault" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrVTDefault" runat="server" Text="&nbsp;Add: Vehicle Request Defaults" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrVTDefault"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrVTDefault"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrVTDefault"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrVTDefault"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrVTDefault" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="SerialNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumCapacityPercentage" runat="server" Text="Minimum Capacity Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumCapacityPercentage"
						Text='<%# Bind("MinimumCapacityPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumCapacityPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumCapacityPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumCapacityPercentage"
						runat = "server"
						ControlToValidate = "F_MinimumCapacityPercentage"
						ControlExtender = "MEEMinimumCapacityPercentage"
						InvalidValueMessage = "Invalid value for Minimum Capacity Percentage."
						EmptyValueMessage = "Minimum Capacity Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Capacity Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Capacity Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumCapacityPercentage" runat="server" Text="Maximum Capacity Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumCapacityPercentage"
						Text='<%# Bind("MaximumCapacityPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumCapacityPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumCapacityPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumCapacityPercentage"
						runat = "server"
						ControlToValidate = "F_MaximumCapacityPercentage"
						ControlExtender = "MEEMaximumCapacityPercentage"
						InvalidValueMessage = "Invalid value for Maximum Capacity Percentage."
						EmptyValueMessage = "Maximum Capacity Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Capacity Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Capacity Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumHeightPercentage" runat="server" Text="Minimum Height Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumHeightPercentage"
						Text='<%# Bind("MinimumHeightPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumHeightPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumHeightPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumHeightPercentage"
						runat = "server"
						ControlToValidate = "F_MinimumHeightPercentage"
						ControlExtender = "MEEMinimumHeightPercentage"
						InvalidValueMessage = "Invalid value for Minimum Height Percentage."
						EmptyValueMessage = "Minimum Height Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Height Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Height Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumWidthPercentage" runat="server" Text="Minimum Width Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumWidthPercentage"
						Text='<%# Bind("MinimumWidthPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumWidthPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumWidthPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumWidthPercentage"
						runat = "server"
						ControlToValidate = "F_MinimumWidthPercentage"
						ControlExtender = "MEEMinimumWidthPercentage"
						InvalidValueMessage = "Invalid value for Minimum Width Percentage."
						EmptyValueMessage = "Minimum Width Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Width Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Width Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumLengthPercentage" runat="server" Text="Minimum Length Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumLengthPercentage"
						Text='<%# Bind("MinimumLengthPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumLengthPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumLengthPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumLengthPercentage"
						runat = "server"
						ControlToValidate = "F_MinimumLengthPercentage"
						ControlExtender = "MEEMinimumLengthPercentage"
						InvalidValueMessage = "Invalid value for Minimum Length Percentage."
						EmptyValueMessage = "Minimum Length Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Length Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Length Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumHeightPercentage" runat="server" Text="Maximum Height Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumHeightPercentage"
						Text='<%# Bind("MaximumHeightPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumHeightPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumHeightPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumHeightPercentage"
						runat = "server"
						ControlToValidate = "F_MaximumHeightPercentage"
						ControlExtender = "MEEMaximumHeightPercentage"
						InvalidValueMessage = "Invalid value for Maximum Height Percentage."
						EmptyValueMessage = "Maximum Height Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Height Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Height Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumWidthPercentage" runat="server" Text="Maximum Width Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumWidthPercentage"
						Text='<%# Bind("MaximumWidthPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumWidthPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumWidthPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumWidthPercentage"
						runat = "server"
						ControlToValidate = "F_MaximumWidthPercentage"
						ControlExtender = "MEEMaximumWidthPercentage"
						InvalidValueMessage = "Invalid value for Maximum Width Percentage."
						EmptyValueMessage = "Maximum Width Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Width Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Width Percentage should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumLengthPercentage" runat="server" Text="Maximum Length Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumLengthPercentage"
						Text='<%# Bind("MaximumLengthPercentage") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrVTDefault"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumLengthPercentage"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumLengthPercentage" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumLengthPercentage"
						runat = "server"
						ControlToValidate = "F_MaximumLengthPercentage"
						ControlExtender = "MEEMaximumLengthPercentage"
						InvalidValueMessage = "Invalid value for Maximum Length Percentage."
						EmptyValueMessage = "Maximum Length Percentage is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Length Percentage."
						EnableClientScript = "true"
						ValidationGroup = "vrVTDefault"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Length Percentage should be greater than zero."
						MinimumValueMessage = "*"
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
  ID = "ODSvrVTDefault"
  DataObjectTypeName = "SIS.VR.vrVTDefault"
  InsertMethod="vrVTDefaultInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrVTDefault"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
