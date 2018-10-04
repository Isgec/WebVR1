<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrSanctionAlert.aspx.vb" Inherits="EF_vrSanctionAlert" title="Edit: Configure Sanction Alert" %>
<asp:Content ID="CPHvrSanctionAlert" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrSanctionAlert" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrSanctionAlert" runat="server" Text="&nbsp;Edit: Configure Sanction Alert" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrSanctionAlert"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrSanctionAlert"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrSanctionAlert"
	runat = "server"
	DataKeyNames = "ProjectID"
	DataSourceID = "ODSvrSanctionAlert"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects1_Description") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At60" runat="server" Text="At 60 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At60"
					  Checked='<%# Bind("At60") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At70" runat="server" Text="At 70 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At70"
					  Checked='<%# Bind("At70") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At80" runat="server" Text="At 80 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At80"
					  Checked='<%# Bind("At80") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At90" runat="server" Text="At 90 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At90"
					  Checked='<%# Bind("At90") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At95" runat="server" Text="At 95 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At95"
					  Checked='<%# Bind("At95") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At96" runat="server" Text="At 96 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At96"
					  Checked='<%# Bind("At96") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At97" runat="server" Text="At 97 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At97"
					  Checked='<%# Bind("At97") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At98" runat="server" Text="At 98 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At98"
					  Checked='<%# Bind("At98") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_At99" runat="server" Text="At 99 % :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_At99"
					  Checked='<%# Bind("At99") %>'
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EMailIDs" runat="server" Text="E-Mail ID(s) :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EMailIDs"
						Text='<%# Bind("EMailIDs") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID(s)."
						MaxLength="250"
						runat="server" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrSanctionAlert"
  DataObjectTypeName = "SIS.VR.vrSanctionAlert"
  SelectMethod = "vrSanctionAlertGetByID"
  UpdateMethod="vrSanctionAlertUpdate"
  DeleteMethod="vrSanctionAlertDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrSanctionAlert"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
