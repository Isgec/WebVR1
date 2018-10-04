<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrUnits.aspx.vb" Inherits="EF_vrUnits" title="Edit: Units" %>
<asp:Content ID="CPHvrUnits" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUnits" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrUnits" runat="server" Text="&nbsp;Edit: Units" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrUnits"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrUnits.aspx?pk="
    ValidationGroup = "vrUnits"
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
<asp:FormView ID="FVvrUnits"
	runat = "server"
	DataKeyNames = "UnitID"
	DataSourceID = "ODSvrUnits"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UnitID" runat="server" ForeColor="#CC6633" Text="Unit ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_UnitID"
						Text='<%# Bind("UnitID") %>'
            ToolTip="Value of Unit ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrUnits"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
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
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrUnits"
  DataObjectTypeName = "SIS.VR.vrUnits"
  SelectMethod = "vrUnitsGetByID"
  UpdateMethod="vrUnitsUpdate"
  DeleteMethod="vrUnitsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrUnits"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UnitID" Name="UnitID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
