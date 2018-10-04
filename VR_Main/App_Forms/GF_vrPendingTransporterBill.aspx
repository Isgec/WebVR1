<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrPendingTransporterBill.aspx.vb" Inherits="GF_vrPendingTransporterBill" title="Maintain List: Pending IR" %>
<asp:Content ID="CPHvrPendingTransporterBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrPendingTransporterBill" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrPendingTransporterBill" runat="server" Text="&nbsp;List: Pending IR" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrPendingTransporterBill"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrPendingTransporterBill.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrPendingTransporterBill.aspx?skip=1"
      ValidationGroup = "vrPendingTransporterBill"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrPendingTransporterBill" runat="server" AssociatedUpdatePanelID="UPNLvrPendingTransporterBill" DisplayAfter="100">
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
					<b><asp:Label ID="L_TransporterID" runat="server" Text="Transporter ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TransporterID"
						CssClass = "myfktxt"
            Width="63px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_TransporterID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TransporterID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETransporterID"
            BehaviorID="B_ACETransporterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TransporterIDCompletionList"
            TargetControlID="F_TransporterID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACETransporterID_Selected"
            OnClientPopulating="ACETransporterID_Populating"
            OnClientPopulated="ACETransporterID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ForwardedBy" runat="server" Text="Forwarded By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ForwardedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_ForwardedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_ForwardedBy_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEForwardedBy"
            BehaviorID="B_ACEForwardedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ForwardedByCompletionList"
            TargetControlID="F_ForwardedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEForwardedBy_Selected"
            OnClientPopulating="ACEForwardedBy_Populating"
            OnClientPopulated="ACEForwardedBy_Populated"
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
		<script type="text/javascript"> 
   var script_BillReturnRemarks = {
		temp: function() {
		}
		}
		</script>

    <asp:GridView ID="GVvrPendingTransporterBill" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrPendingTransporterBill" DataKeyNames="IRNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IRNo" SortExpression="IRNo">
          <ItemTemplate>
            <asp:Label ID="LabelIRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IRNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="IR Description" SortExpression="IRDescription">
          <ItemTemplate>
            <asp:Label ID="LabelIRDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("IRDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP PO Number" SortExpression="ISGECPONumber">
          <ItemTemplate>
            <asp:Label ID="LabelISGECPONumber" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGECPONumber") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter ID" SortExpression="VR_Transporters9_TransporterName">
          <ItemTemplate>
             <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters9_TransporterName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Bill No" SortExpression="TransporterBillNo">
          <ItemTemplate>
            <asp:Label ID="LabelTransporterBillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransporterBillNo") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Bill Date" SortExpression="TransporterBillDate">
          <ItemTemplate>
            <asp:Label ID="LabelTransporterBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransporterBillDate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Amount" SortExpression="BillAmount">
          <ItemTemplate>
            <asp:Label ID="LabelBillAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status" SortExpression="VR_BillStatus8_Description">
          <ItemTemplate>
             <asp:Label ID="L_BillStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillStatusID") %>' Text='<%# Eval("VR_BillStatus8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Return Remarks" SortExpression="BillReturnRemarks">
          <ItemTemplate>
					<asp:TextBox ID="F_BillReturnRemarks"
						Text='<%# Bind("BillReturnRemarks") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Bill Return Remarks."
						MaxLength="100"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVBillReturnRemarks"
						runat = "server"
						ControlToValidate = "F_BillReturnRemarks"
						Text = "Bill Return Remarks is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />

          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forwarded On" SortExpression="ForwardedOn">
          <ItemTemplate>
            <asp:Label ID="LabelForwardedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ForwardedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forwarded By" SortExpression="aspnet_Users2_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ForwardedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ForwardedBy") %>' Text='<%# Eval("aspnet_Users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Accept">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Accept" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Accept record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reject">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
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
      ID = "ODSvrPendingTransporterBill"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrPendingTransporterBill"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrPendingTransporterBillSelectList"
      TypeName = "SIS.VR.vrPendingTransporterBill"
      SelectCountMethod = "vrPendingTransporterBillSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_ForwardedBy" PropertyName="Text" Name="ForwardedBy" Type="String" Size="8" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrPendingTransporterBill" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
    <asp:AsyncPostBackTrigger ControlID="F_ForwardedBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
