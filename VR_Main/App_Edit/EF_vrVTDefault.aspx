<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrVTDefault.aspx.vb" Inherits="EF_vrVTDefault" title="Edit: Vehicle Request Defaults" %>
<asp:Content ID="CPHvrVTDefault" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVTDefault" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrVTDefault" runat="server" Text="&nbsp;Edit: Vehicle Request Defaults" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrVTDefault"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrVTDefault.aspx?pk="
    ValidationGroup = "vrVTDefault"
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
<asp:FormView ID="FVvrVTDefault"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrVTDefault"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SerialNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of SerialNo."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumCapacityPercentage" runat="server" Text="Minimum Capacity Percentage :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumCapacityPercentage"
						Text='<%# Bind("MinimumCapacityPercentage") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrVTDefault"
  DataObjectTypeName = "SIS.VR.vrVTDefault"
  SelectMethod = "vrVTDefaultGetByID"
  UpdateMethod="vrVTDefaultUpdate"
  DeleteMethod="vrVTDefaultDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrVTDefault"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
