<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrUserGroup.aspx.vb" Inherits="AF_vrUserGroup" title="Add: User Group" %>
<asp:Content ID="CPHvrUserGroup" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUserGroup" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrUserGroup" runat="server" Text="&nbsp;Add: User Group" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrUserGroup"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrUserGroup"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrUserGroup"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrUserGroup"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrUserGroup" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" ForeColor="#CC6633" runat="server" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UserID"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("UserID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for User ID."
						ValidationGroup = "vrUserGroup"
            onblur= "script_vrUserGroup.validate_UserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_UserID_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUserID"
						runat = "server"
						ControlToValidate = "F_UserID"
						Text = "User ID is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrUserGroup"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrUserGroup.ACEUserID_Selected"
            OnClientPopulating="script_vrUserGroup.ACEUserID_Populating"
            OnClientPopulated="script_vrUserGroup.ACEUserID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GroupID" runat="server" Text="Group ID :" /></b>
				</td>
        <td>
          <LGM:LC_vrGroups
            ID="F_GroupID"
            SelectedValue='<%# Bind("GroupID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
						ValidationGroup = "vrUserGroup"
            RequiredFieldErrorMessage = "Group ID is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RoleID" runat="server" Text="Role ID :" /></b>
				</td>
        <td>
          <asp:DropDownList
            ID="F_RoleID"
            SelectedValue='<%# Bind("RoleID") %>'
            Width="200px"
						ValidationGroup = "vrUserGroup"
						CssClass = "myddl"
            Runat="Server" >
            <asp:ListItem Value="Requester">Requester</asp:ListItem>
            <asp:ListItem Value="Executer">Executer</asp:ListItem>
            <asp:ListItem Value="Approver">Approver</asp:ListItem>
          </asp:DropDownList>
         </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_OutOfContractApprover" runat="server" Text="Out Of Contract :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_OutOfContractApprover"
					 Checked='<%# Bind("OutOfContractApprover") %>'
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
  ID = "ODSvrUserGroup"
  DataObjectTypeName = "SIS.VR.vrUserGroup"
  InsertMethod="vrUserGroupInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrUserGroup"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
