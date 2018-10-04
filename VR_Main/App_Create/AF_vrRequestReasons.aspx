<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrRequestReasons.aspx.vb" Inherits="AF_vrRequestReasons" title="Add: Executer Reason" %>
<asp:Content ID="CPHvrRequestReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrRequestReasons" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrRequestReasons" runat="server" Text="&nbsp;Add: Executer Reason" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrRequestReasons"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrRequestReasons"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrRequestReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSvrRequestReasons"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrRequestReasons" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" ForeColor="#CC6633" runat="server" Text="Reason ID :" /></b>
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
						ValidationGroup="vrRequestReasons"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrRequestReasons"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Transporter" runat="server" Text="Transporter :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Transporter"
					 Checked='<%# Bind("Transporter") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ISGEC" runat="server" Text="ISGEC :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_ISGEC"
					 Checked='<%# Bind("ISGEC") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Supplier" runat="server" Text="Supplier :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Supplier"
					 Checked='<%# Bind("Supplier") %>'
           runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Other" runat="server" Text="Other :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_Other"
					 Checked='<%# Bind("Other") %>'
           runat="server" />
				</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrRequestReasons"
  DataObjectTypeName = "SIS.VR.vrRequestReasons"
  InsertMethod="vrRequestReasonsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrRequestReasons"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
