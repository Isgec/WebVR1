<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrSanctionAlert.aspx.vb" Inherits="AF_vrSanctionAlert" title="Add: Configure Sanction Alert" %>
<asp:Content ID="CPHvrSanctionAlert" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrSanctionAlert" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrSanctionAlert" runat="server" Text="&nbsp;Add: Configure Sanction Alert" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrSanctionAlert"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrSanctionAlert"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrSanctionAlert"
	runat = "server"
	DataKeyNames = "ProjectID"
	DataSourceID = "ODSvrSanctionAlert"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrSanctionAlert" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "mypktxt"
            Width="42px"
						Text='<%# Bind("ProjectID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
						ValidationGroup = "vrSanctionAlert"
            onblur= "script_vrSanctionAlert.validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text='<%# Eval("IDM_Projects1_Description") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVProjectID"
						runat = "server"
						ControlToValidate = "F_ProjectID"
						Text = "Project ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrSanctionAlert"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrSanctionAlert.ACEProjectID_Selected"
            OnClientPopulating="script_vrSanctionAlert.ACEProjectID_Populating"
            OnClientPopulated="script_vrSanctionAlert.ACEProjectID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
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
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID(s)."
						MaxLength="250"
            Width="350px" Height="40px" TextMode="MultiLine"
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
  ID = "ODSvrSanctionAlert"
  DataObjectTypeName = "SIS.VR.vrSanctionAlert"
  InsertMethod="vrSanctionAlertInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrSanctionAlert"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
