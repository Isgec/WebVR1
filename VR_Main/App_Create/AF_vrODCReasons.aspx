<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrODCReasons.aspx.vb" Inherits="AF_vrODCReasons" title="Add: ODC Reasons" %>
<asp:Content ID="CPHvrODCReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrODCReasons" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrODCReasons" runat="server" Text="&nbsp;Add: ODC Reasons" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrODCReasons"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrODCReasons"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrODCReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSvrODCReasons"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrODCReasons" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" ForeColor="#CC6633" runat="server" Text="ReasonID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
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
						ValidationGroup="vrODCReasons"
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
						ValidationGroup = "vrODCReasons"
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
  ID = "ODSvrODCReasons"
  DataObjectTypeName = "SIS.VR.vrODCReasons"
  InsertMethod="vrODCReasonsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrODCReasons"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
