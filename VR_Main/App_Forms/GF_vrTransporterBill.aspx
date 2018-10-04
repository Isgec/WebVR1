<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrTransporterBill.aspx.vb" Inherits="GF_vrTransporterBill" title="Maintain List: IR" %>
<asp:Content ID="CPHvrTransporterBill" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrTransporterBill" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrTransporterBill" runat="server" Text="&nbsp;List: IR" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrTransporterBill"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrTransporterBill.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrTransporterBill.aspx?skip=1"
      ValidationGroup = "vrTransporterBill"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrTransporterBill" runat="server" AssociatedUpdatePanelID="UPNLvrTransporterBill" DisplayAfter="100">
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
					<b><asp:Label ID="L_BillReceiverDivisionID" runat="server" Text="Bill Receiver Division ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_BillReceiverDivisionID"
						CssClass = "myfktxt"
            Width="42px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_BillReceiverDivisionID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_BillReceiverDivisionID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEBillReceiverDivisionID"
            BehaviorID="B_ACEBillReceiverDivisionID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="BillReceiverDivisionIDCompletionList"
            TargetControlID="F_BillReceiverDivisionID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEBillReceiverDivisionID_Selected"
            OnClientPopulating="ACEBillReceiverDivisionID_Populating"
            OnClientPopulated="ACEBillReceiverDivisionID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_BillStatusID" runat="server" Text="Bill Status :" /></b>
				</td>
        <td>
          <LGM:LC_vrBillStatus
            ID="F_BillStatusID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="BillStatusID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage=""
            CssClass="myddl"
            Runat="Server" />
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
    <asp:GridView ID="GVvrTransporterBill" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrTransporterBill" DataKeyNames="IRNo">
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
        <asp:TemplateField HeaderText="ERP PO Date" SortExpression="ISGECPODate">
          <ItemTemplate>
            <asp:Label ID="LabelISGECPODate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGECPODate") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ERP PO Amount" SortExpression="ISGECPOAmount">
          <ItemTemplate>
            <asp:Label ID="LabelISGECPOAmount" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGECPOAmount") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
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
        <asp:TemplateField HeaderText="Bill Received On" SortExpression="BillReceivedOn">
          <ItemTemplate>
            <asp:Label ID="LabelBillReceivedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BillReceivedOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Received By" SortExpression="aspnet_Users5_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_BillReceivedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillReceivedBy") %>' Text='<%# Eval("aspnet_Users5_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Receiver Division ID" SortExpression="HRM_Divisions6_Description">
          <ItemTemplate>
             <asp:Label ID="L_BillReceiverDivisionID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillReceiverDivisionID") %>' Text='<%# Eval("HRM_Divisions6_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Bill Status" SortExpression="VR_BillStatus8_Description">
          <ItemTemplate>
             <asp:Label ID="L_BillStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("BillStatusID") %>' Text='<%# Eval("VR_BillStatus8_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Update Payment">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update Payment Details" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Update Payment Details From BaaN ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText=" ">
          <ItemTemplate>
						</tr>
						<tr>
						<td>
						</td>
							<td colspan="15" style="background-color:#FDD7E4; color:#7D0552">
								<asp:Label runat="server" ID="L_PaymentDetails" Text='<%# Eval("PaymentDetails") %>'></asp:Label>
							</td>
							<td>
							</td>
						</tr>
          </ItemTemplate>
          <HeaderStyle Width="5px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrTransporterBill"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrTransporterBill"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrTransporterBillSelectList"
      TypeName = "SIS.VR.vrTransporterBill"
      SelectCountMethod = "vrTransporterBillSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_BillReceiverDivisionID" PropertyName="Text" Name="BillReceiverDivisionID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_BillStatusID" PropertyName="SelectedValue" Name="BillStatusID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrTransporterBill" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillReceiverDivisionID" />
    <asp:AsyncPostBackTrigger ControlID="F_BillStatusID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
