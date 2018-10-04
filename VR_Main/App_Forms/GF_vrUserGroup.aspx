<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrUserGroup.aspx.vb" Inherits="GF_vrUserGroup" title="Maintain List: User Group" %>
<asp:Content ID="CPHvrUserGroup" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrUserGroup" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrUserGroup" runat="server" Text="&nbsp;List: User Group" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrUserGroup"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrUserGroup.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrUserGroup.aspx"
      ValidationGroup = "vrUserGroup"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrUserGroup" runat="server" AssociatedUpdatePanelID="UPNLvrUserGroup" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
		<asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
			<div style="padding: 5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left;">Filter Records </div>
				<div style="float: left; margin-left: 20px;">
					<asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
				</div>
				<div style="float: right; vertical-align: middle;">
					<asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
				</div>
			</div>
		</asp:Panel>
		<asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_UserID"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_UserID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_UserID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUserID_Selected"
            OnClientPopulating="ACEUserID_Populating"
            OnClientPopulated="ACEUserID_Populated"
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
            SelectedValue=""
            OrderBy="GroupName"
            DataTextField="GroupName"
            DataValueField="GroupID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
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
            AutoPostBack="true"
            Width="200px"
            Runat="Server" >
            <asp:ListItem Selected="True" Value="">----Select----</asp:ListItem>
            <asp:ListItem Value="Requester">Requester</asp:ListItem>
            <asp:ListItem Value="Executer">Executer</asp:ListItem>
            <asp:ListItem Value="Approver">Approver</asp:ListItem>
          </asp:DropDownList>
         </td>
			</tr>
    </table>
		</asp:Panel>
		<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <br />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
    <asp:GridView ID="GVvrUserGroup" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrUserGroup" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
              <td><asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User ID" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Group ID" SortExpression="VR_Groups2_GroupName">
          <ItemTemplate>
             <asp:Label ID="L_GroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GroupID") %>' Text='<%# Eval("VR_Groups2_GroupName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Role ID" SortExpression="RoleID">
          <ItemTemplate>
            <asp:Label ID="LabelRoleID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RoleID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Out Of Contract" SortExpression="OutOfContractApprover">
          <ItemTemplate>
            <asp:Label ID="LabelOutOfContractApprover" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("OutOfContractApprover") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrUserGroup"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrUserGroup"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrUserGroupSelectList"
      TypeName = "SIS.VR.vrUserGroup"
      SelectCountMethod = "vrUserGroupSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_GroupID" PropertyName="SelectedValue" Name="GroupID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RoleID" PropertyName="Text" Name="RoleID" Type="String" Size="20" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrUserGroup" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
    <asp:AsyncPostBackTrigger ControlID="F_GroupID" />
    <asp:AsyncPostBackTrigger ControlID="F_RoleID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
