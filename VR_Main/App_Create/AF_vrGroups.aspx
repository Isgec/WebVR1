<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrGroups.aspx.vb" Inherits="AF_vrGroups" title="Add: Groups" %>
<asp:Content ID="CPHvrGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrGroups" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrGroups" runat="server" Text="&nbsp;Add: Groups" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrGroups"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrGroups"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrGroups"
	runat = "server"
	DataKeyNames = "GroupID"
	DataSourceID = "ODSvrGroups"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrGroups" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GroupID" ForeColor="#CC6633" runat="server" Text="Group ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GroupID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GroupName" runat="server" Text="Group Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GroupName"
						Text='<%# Bind("GroupName") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Group Name."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVGroupName"
						runat = "server"
						ControlToValidate = "F_GroupName"
						Text = "Group Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrGroups"
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
  ID = "ODSvrGroups"
  DataObjectTypeName = "SIS.VR.vrGroups"
  InsertMethod="vrGroupsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
