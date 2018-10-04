<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrUserRoles.aspx.vb" Inherits="EF_vrUserRoles" title="Edit: User Roles" %>
<asp:Content ID="CPHvrUserRoles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUserRoles" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrUserRoles" runat="server" Text="&nbsp;Edit: User Roles" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrUserRoles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrUserRoles"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrUserRoles"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrUserRoles"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UserID" runat="server" Text="User :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UserID"
						CssClass = "myfktxt"
						Text='<%# Bind("UserID") %>'
						AutoCompleteType = "None"
            Width="56px"
						onfocus = "return this.select();"
            ToolTip="Enter value for User."
						ValidationGroup = "vrUserRoles"
            onblur= "script_vrUserRoles.validate_UserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_UserID_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVUserID"
						runat = "server"
						ControlToValidate = "F_UserID"
						Text = "User is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrUserRoles"
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
            OnClientItemSelected="script_vrUserRoles.ACEUserID_Selected"
            OnClientPopulating="script_vrUserRoles.ACEUserID_Populating"
            OnClientPopulated="script_vrUserRoles.ACEUserID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DivisionID" runat="server" Text="Division :" /></b>
				</td>
        <td>
          <LGM:LC_qcmDivisions
            ID="F_DivisionID"
            SelectedValue='<%# Bind("DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myfktxt"
						ValidationGroup = "vrUserRoles"
            RequiredFieldErrorMessage = "Division is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RoleID" runat="server" Text="Role :" /></b>
				</td>
        <td>
          <asp:DropDownList
            ID="F_RoleID"
            SelectedValue='<%# Bind("RoleID") %>'
            CssClass = "myddl"
            Width="200px"
						ValidationGroup = "vrUserRoles"
            Runat="Server" >
            <asp:ListItem Value="Requester">Requester</asp:ListItem>
            <asp:ListItem Value="Executer">Executer</asp:ListItem>
            <asp:ListItem Value="Approver">Approver</asp:ListItem>
          </asp:DropDownList>
         </td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrUserRoles"
  DataObjectTypeName = "SIS.VR.vrUserRoles"
  SelectMethod = "vrUserRolesGetByID"
  UpdateMethod="vrUserRolesUpdate"
  DeleteMethod="vrUserRolesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrUserRoles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
