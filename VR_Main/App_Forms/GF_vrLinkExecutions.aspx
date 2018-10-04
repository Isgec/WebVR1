<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrLinkExecutions.aspx.vb" Inherits="GF_vrLinkExecutions" title="Maintain List: Link Executions" %>
<asp:Content ID="CPHvrLinkExecutions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrLinkExecutions" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrLinkExecutions" runat="server" Text="&nbsp;List: Link Executions" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLinkExecutions"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLinkExecutions.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrLinkExecutions.aspx"
      ValidationGroup = "vrLinkExecutions"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLinkExecutions" runat="server" AssociatedUpdatePanelID="UPNLvrLinkExecutions" DisplayAfter="100">
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
					<b><asp:Label ID="L_SRNNo" runat="server" Text="Execution No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SRNNo"
						CssClass = "mypktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_SRNNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESRNNo"
            BehaviorID="B_ACESRNNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SRNNoCompletionList"
            TargetControlID="F_SRNNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESRNNo_Selected"
            OnClientPopulating="ACESRNNo_Populating"
            OnClientPopulated="ACESRNNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
    </table>
		</asp:Panel>
		<AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <br />
    <asp:GridView ID="GVvrLinkExecutions" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrLinkExecutions" DataKeyNames="LinkID,SRNNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Link ID" SortExpression="LinkID">
          <ItemTemplate>
            <asp:Label ID="LabelLinkID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LinkID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Execution No" SortExpression="VR_RequestExecution2_ExecutionDescription">
          <ItemTemplate>
             <asp:Label ID="L_SRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SRNNo") %>' Text='<%# Eval("VR_RequestExecution2_ExecutionDescription") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Linked By" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_LinkedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LinkedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Linked On" SortExpression="LinkedOn">
          <ItemTemplate>
            <asp:Label ID="LabelLinkedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LinkedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLinkExecutions"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLinkExecutions"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrLinkExecutionsSelectList"
      TypeName = "SIS.VR.vrLinkExecutions"
      SelectCountMethod = "vrLinkExecutionsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SRNNo" PropertyName="Text" Name="SRNNo" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLinkExecutions" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SRNNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
