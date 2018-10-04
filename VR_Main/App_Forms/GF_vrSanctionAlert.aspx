<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrSanctionAlert.aspx.vb" Inherits="GF_vrSanctionAlert" title="Maintain List: Configure Sanction Alert" %>
<asp:Content ID="CPHvrSanctionAlert" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrSanctionAlert" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrSanctionAlert" runat="server" Text="&nbsp;List: Configure Sanction Alert" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrSanctionAlert"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrSanctionAlert.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrSanctionAlert.aspx"
      ValidationGroup = "vrSanctionAlert"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrSanctionAlert" runat="server" AssociatedUpdatePanelID="UPNLvrSanctionAlert" DisplayAfter="100">
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
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "mypktxt"
            Width="42px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_ProjectID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProjectID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProjectID_Selected"
            OnClientPopulating="ACEProjectID_Populating"
            OnClientPopulated="ACEProjectID_Populated"
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
    <asp:GridView ID="GVvrSanctionAlert" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrSanctionAlert" DataKeyNames="ProjectID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects1_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects1_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 60 %" SortExpression="At60">
          <ItemTemplate>
            <asp:Label ID="LabelAt60" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At60") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 70 %" SortExpression="At70">
          <ItemTemplate>
            <asp:Label ID="LabelAt70" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At70") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 80 %" SortExpression="At80">
          <ItemTemplate>
            <asp:Label ID="LabelAt80" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At80") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 90 %" SortExpression="At90">
          <ItemTemplate>
            <asp:Label ID="LabelAt90" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At90") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 95 %" SortExpression="At95">
          <ItemTemplate>
            <asp:Label ID="LabelAt95" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At95") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 96 %" SortExpression="At96">
          <ItemTemplate>
            <asp:Label ID="LabelAt96" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At96") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 97 %" SortExpression="At97">
          <ItemTemplate>
            <asp:Label ID="LabelAt97" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At97") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 98 %" SortExpression="At98">
          <ItemTemplate>
            <asp:Label ID="LabelAt98" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At98") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="At 99 %" SortExpression="At99">
          <ItemTemplate>
            <asp:Label ID="LabelAt99" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("At99") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="E-Mail ID(s)" SortExpression="EMailIDs">
          <ItemTemplate>
            <asp:Label ID="LabelEMailIDs" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EMailIDs") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrSanctionAlert"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrSanctionAlert"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrSanctionAlertSelectList"
      TypeName = "SIS.VR.vrSanctionAlert"
      SelectCountMethod = "vrSanctionAlertSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrSanctionAlert" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
