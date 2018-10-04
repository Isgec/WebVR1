<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrTransporters.aspx.vb" Inherits="EF_vrTransporters" title="Edit: Transporters" %>
<asp:Content ID="CPHvrTransporters" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrTransporters" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrTransporters" runat="server" Text="&nbsp;Edit: Transporters" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrTransporters"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrTransporters.aspx?pk="
    ValidationGroup = "vrTransporters"
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
<asp:FormView ID="FVvrTransporters"
	runat = "server"
	DataKeyNames = "TransporterID"
	DataSourceID = "ODSvrTransporters"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterID" runat="server" ForeColor="#CC6633" Text="Transporter ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransporterID"
						Text='<%# Bind("TransporterID") %>'
            ToolTip="Value of Transporter ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="63px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransporterName"
						Text='<%# Bind("TransporterName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Name."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTransporterName"
						runat = "server"
						ControlToValidate = "F_TransporterName"
						Text = "Transporter Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrTransporters"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address1Line" runat="server" Text="Address Line [1] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address1Line"
						Text='<%# Bind("Address1Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [1]."
						MaxLength="100"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Address2Line" runat="server" Text="Address Line [2] :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Address2Line"
						Text='<%# Bind("Address2Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [2]."
						MaxLength="100"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_City" runat="server" Text="City :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_City"
						Text='<%# Bind("City") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailID" runat="server" Text="EMail ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EMailID"
						Text='<%# Bind("EMailID") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for EMail ID."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVEMailID"
						runat = "server"
						ControlToValidate = "F_EMailID"
						Text = "EMail ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrTransporters"
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
  ID = "ODSvrTransporters"
  DataObjectTypeName = "SIS.VR.vrTransporters"
  SelectMethod = "vrTransportersGetByID"
  UpdateMethod="vrTransportersUpdate"
  DeleteMethod="vrTransportersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrTransporters"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TransporterID" Name="TransporterID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
