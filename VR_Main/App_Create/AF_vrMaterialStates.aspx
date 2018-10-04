<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrMaterialStates.aspx.vb" Inherits="AF_vrMaterialStates" title="Add: Material States" %>
<asp:Content ID="CPHvrMaterialStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrMaterialStates" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrMaterialStates" runat="server" Text="&nbsp;Add: Material States" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrMaterialStates"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrMaterialStates"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrMaterialStates"
	runat = "server"
	DataKeyNames = "MaterialStateID"
	DataSourceID = "ODSvrMaterialStates"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrMaterialStates" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialStateID" ForeColor="#CC6633" runat="server" Text="Material State ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaterialStateID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="vrMaterialStates"
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
						ValidationGroup = "vrMaterialStates"
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
  ID = "ODSvrMaterialStates"
  DataObjectTypeName = "SIS.VR.vrMaterialStates"
  InsertMethod="vrMaterialStatesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrMaterialStates"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
