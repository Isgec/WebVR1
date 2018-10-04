<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrLorryReceiptDetails.aspx.vb" Inherits="GF_vrLorryReceiptDetails" title="Maintain List: Lorry Receipt Details" %>
<asp:Content ID="CPHvrLorryReceiptDetails" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelvrLorryReceiptDetails" runat="server" Text="&nbsp;List: Lorry Receipt Details"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptDetails" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLorryReceiptDetails"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLorryReceiptDetails.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrLorryReceiptDetails.aspx"
      AddPostBack = "True"
      ValidationGroup = "vrLorryReceiptDetails"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLorryReceiptDetails" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceiptDetails" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MRNNo" runat="server" Text="MRN No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_MRNNo"
            CssClass = "mypktxt"
            Width="70px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_MRNNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_MRNNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEMRNNo"
            BehaviorID="B_ACEMRNNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="MRNNoCompletionList"
            TargetControlID="F_MRNNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEMRNNo_Selected"
            OnClientPopulating="ACEMRNNo_Populating"
            OnClientPopulated="ACEMRNNo_Populated"
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
    <asp:GridView ID="GVvrLorryReceiptDetails" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceiptDetails" DataKeyNames="ProjectID,MRNNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GR / LR No" SortExpression="GRorLRNo">
          <ItemTemplate>
            <asp:Label ID="LabelGRorLRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRorLRNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier ID" SortExpression="VR_BusinessPartner2_BPName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("VR_BusinessPartner2_BPName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Invoice No" SortExpression="SupplierInvoiceNo">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierInvoiceNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Weight Received [KG]" SortExpression="WeightReceived">
          <ItemTemplate>
            <asp:Label ID="LabelWeightReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WeightReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No. of Packages Received" SortExpression="NoOfPackagesReceived">
          <ItemTemplate>
            <asp:Label ID="LabelNoOfPackagesReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NoOfPackagesReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cenvat Invoice Received" SortExpression="CenvatInvoiceReceived">
          <ItemTemplate>
            <asp:Label ID="LabelCenvatInvoiceReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CenvatInvoiceReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLorryReceiptDetails"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLorryReceiptDetails"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrLorryReceiptDetailsSelectList"
      TypeName = "SIS.VR.vrLorryReceiptDetails"
      SelectCountMethod = "vrLorryReceiptDetailsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_MRNNo" PropertyName="Text" Name="MRNNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceiptDetails" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_MRNNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
