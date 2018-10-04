<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrUnits.aspx.vb" Inherits="AF_vrUnits" title="Add: Units" %>
<asp:Content ID="CPHvrUnits" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUnits" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrUnits" runat="server" Text="&nbsp;Add: Units" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrUnits"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrUnits"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrUnits"
	runat = "server"
	DataKeyNames = "UnitID"
	DataSourceID = "ODSvrUnits"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrUnits" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UnitID" ForeColor="#CC6633" runat="server" Text="Unit ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_UnitID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="vrUnits"
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
						ValidationGroup = "vrUnits"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ConversionFactor" runat="server" Text="Conversion Factor [Base Unit KG or FT] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ConversionFactor"
						Text='<%# Bind("ConversionFactor") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						MaxLength="24"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEConversionFactor"
						runat = "server"
						mask = "999999999999999999.999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ConversionFactor" />
					<AJX:MaskedEditValidator 
						ID = "MEVConversionFactor"
						runat = "server"
						ControlToValidate = "F_ConversionFactor"
						ControlExtender = "MEEConversionFactor"
						InvalidValueMessage = "Invalid value for Conversion Factor [Base Unit KG or FT]."
						EmptyValueMessage = "Conversion Factor [Base Unit KG or FT] is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Conversion Factor [Base Unit KG or FT]."
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
  ID = "ODSvrUnits"
  DataObjectTypeName = "SIS.VR.vrUnits"
  InsertMethod="vrUnitsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrUnits"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
