<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrRequestReasons.aspx.vb" Inherits="EF_vrRequestReasons" title="Edit: Executer Reason" %>
<asp:Content ID="CPHvrRequestReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrRequestReasons" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrRequestReasons" runat="server" Text="&nbsp;Edit: Executer Reason" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrRequestReasons"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrRequestReasons"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrRequestReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSvrRequestReasons"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" runat="server" ForeColor="#CC6633" Text="Reason ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonID"
						Text='<%# Bind("ReasonID") %>'
            ToolTip="Value of Reason ID."
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
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestReasons"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="100"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrRequestReasons"
  DataObjectTypeName = "SIS.VR.vrRequestReasons"
  SelectMethod = "vrRequestReasonsGetByID"
  UpdateMethod="vrRequestReasonsUpdate"
  DeleteMethod="vrRequestReasonsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrRequestReasons"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReasonID" Name="ReasonID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
