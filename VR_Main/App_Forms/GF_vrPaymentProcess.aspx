<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrPaymentProcess.aspx.vb" Inherits="GF_vrPaymentProcess" title="Maintain List: Payment Process" %>
<asp:Content ID="CPHvrPaymentProcess" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPaymentProcess" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrPaymentProcess" runat="server" Text="&nbsp;List: Payment Process" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrPaymentProcess"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrPaymentProcess.aspx"
      EnableAdd = "False"
      ValidationGroup = "vrPaymentProcess"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrPaymentProcess" runat="server" AssociatedUpdatePanelID="UPNLvrPaymentProcess" DisplayAfter="100">
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
					<b><asp:Label ID="L_ProcessedBy" runat="server" Text="Processed By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProcessedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_ProcessedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ProcessedBy_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProcessedBy"
            BehaviorID="B_ACEProcessedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProcessedByCompletionList"
            TargetControlID="F_ProcessedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEProcessedBy_Selected"
            OnClientPopulating="ACEProcessedBy_Populating"
            OnClientPopulated="ACEProcessedBy_Populated"
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
    <asp:GridView ID="GVvrPaymentProcess" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrPaymentProcess" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
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
        <asp:TemplateField HeaderText="PTR No" SortExpression="PTRNo">
          <ItemTemplate>
            <asp:Label ID="LabelPTRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PTRNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PTR Date" SortExpression="PTRDate">
          <ItemTemplate>
            <asp:Label ID="LabelPTRDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PTRDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PTR Amount" SortExpression="PTRAmount">
          <ItemTemplate>
            <asp:Label ID="LabelPTRAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PTRAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Payment Reference" SortExpression="PaymentReference">
          <ItemTemplate>
            <asp:Label ID="LabelPaymentReference" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PaymentReference") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cheque No" SortExpression="ChequeNo">
          <ItemTemplate>
            <asp:Label ID="LabelChequeNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChequeNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cheque Date" SortExpression="ChequeDate">
          <ItemTemplate>
            <asp:Label ID="LabelChequeDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChequeDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cheque Amount" SortExpression="ChequeAmount">
          <ItemTemplate>
            <asp:Label ID="LabelChequeAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ChequeAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Paid To" SortExpression="PaymentDescription">
          <ItemTemplate>
            <asp:Label ID="LabelPaymentDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("PaymentDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Processed By" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ProcessedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProcessedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Processed On" SortExpression="ProcessedOn">
          <ItemTemplate>
            <asp:Label ID="LabelProcessedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProcessedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cheque Reconciled" SortExpression="Freezed">
          <ItemTemplate>
            <asp:Label ID="LabelFreezed" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Freezed") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IRNo" SortExpression="IRNo">
          <ItemTemplate>
            <asp:Label ID="LabelIRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IRNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Complete">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Complete" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Complete record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrPaymentProcess"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrPaymentProcess"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrPaymentProcessSelectList"
      TypeName = "SIS.VR.vrPaymentProcess"
      SelectCountMethod = "vrPaymentProcessSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProcessedBy" PropertyName="Text" Name="ProcessedBy" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrPaymentProcess" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProcessedBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
