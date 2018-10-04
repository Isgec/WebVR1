<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrTransporters.aspx.vb" Inherits="AF_vrTransporters" title="Add: Transporters" %>
<asp:Content ID="CPHvrTransporters" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrTransporters" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrTransporters" runat="server" Text="&nbsp;Add: Transporters" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrTransporters"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrTransporters"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrTransporters"
	runat = "server"
	DataKeyNames = "TransporterID"
	DataSourceID = "ODSvrTransporters"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrTransporters" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterID" ForeColor="#CC6633" runat="server" Text="Transporter ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransporterID"
						Text='<%# Bind("TransporterID") %>'
						CssClass = "mypktxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "script_vrTransporters.validate_TransporterID(this);"
            ToolTip="Enter value for Transporter ID."
						MaxLength="9"
            Width="63px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTransporterID"
						runat = "server"
						ControlToValidate = "F_TransporterID"
						Text = "Transporter ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrTransporters"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransporterName"
						Text='<%# Bind("TransporterName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transporter Name."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [1]."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [2]."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
						MaxLength="50"
            Width="350px"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransporters"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for EMail ID."
						MaxLength="200"
            Width="350px" Height="40px" TextMode="MultiLine"
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
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrTransporters"
  DataObjectTypeName = "SIS.VR.vrTransporters"
  InsertMethod="vrTransportersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrTransporters"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
