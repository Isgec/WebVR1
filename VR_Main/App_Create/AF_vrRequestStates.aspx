<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrRequestStates.aspx.vb" Inherits="AF_vrRequestStates" title="Add: Request States" %>
<asp:Content ID="CPHvrRequestStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrRequestStates" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrRequestStates" runat="server" Text="&nbsp;Add: Request States" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrRequestStates"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrRequestStates"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrRequestStates"
	runat = "server"
	DataKeyNames = "StatusID"
	DataSourceID = "ODSvrRequestStates"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrRequestStates" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" ForeColor="#CC6633" runat="server" Text="Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="vrRequestStates"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
            Width="210px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrRequestStates"
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
  ID = "ODSvrRequestStates"
  DataObjectTypeName = "SIS.VR.vrRequestStates"
  InsertMethod="vrRequestStatesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrRequestStates"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
