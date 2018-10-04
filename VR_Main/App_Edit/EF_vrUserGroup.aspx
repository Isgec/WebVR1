<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrUserGroup.aspx.vb" Inherits="EF_vrUserGroup" title="Edit: User Group" %>
<asp:Content ID="CPHvrUserGroup" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUserGroup" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrUserGroup" runat="server" Text="&nbsp;Edit: User Group" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrUserGroup"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrUserGroup.aspx?pk="
    ValidationGroup = "vrUserGroup"
    Skin = "tbl_blue"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVvrUserGroup"
	runat = "server"
	DataKeyNames = "SerialNo"
	DataSourceID = "ODSvrUserGroup"
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
					<b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UserID"
						CssClass = "myfktxt"
						Text='<%# Bind("UserID") %>'
						AutoCompleteType = "None"
            Width="56px"
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
            CssClass="myfktxt"
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
            CssClass = "myddl"
            Width="200px"
						ValidationGroup = "vrUserGroup"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrUserGroup"
  DataObjectTypeName = "SIS.VR.vrUserGroup"
  SelectMethod = "vrUserGroupGetByID"
  UpdateMethod="vrUserGroupUpdate"
  DeleteMethod="vrUserGroupDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrUserGroup"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
