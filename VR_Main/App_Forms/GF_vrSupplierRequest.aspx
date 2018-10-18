<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_vrSupplierRequest.aspx.vb" Inherits="GF_vrSupplierRequest" title="List: Vehicle Request Raised By Supplier" %>
<asp:Content ID="CPHpakPkgListH" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelpakPkgListH" runat="server" Text="&nbsp;List: Vehicle Request Raised By Supplier"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLpakPkgListH" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLpakPkgListH"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_pakHPending.aspx"
      EnableAdd = "False"
      ValidationGroup = "pakPkgListH"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSpakPkgListH" runat="server" AssociatedUpdatePanelID="UPNLpakPkgListH" DisplayAfter="100">
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
          <b><asp:Label ID="L_SerialNo" runat="server" Text="Serial No :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_SerialNo"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_SerialNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_SerialNo_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESerialNo"
            BehaviorID="B_ACESerialNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SerialNoCompletionList"
            TargetControlID="F_SerialNo"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESerialNo_Selected"
            OnClientPopulating="ACESerialNo_Populating"
            OnClientPopulated="ACESerialNo_Populated"
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
    <asp:GridView ID="GVpakPkgListH" SkinID="gv_silver" runat="server" DataSourceID="ODSpakPkgListH" DataKeyNames="SerialNo,PkgNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Pkg. No" SortExpression="PkgNo">
          <ItemTemplate>
            <asp:Label ID="LabelPkgNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("PkgNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PO Number" SortExpression="PONumber">
          <ItemTemplate>
            <asp:Label ID="LabelPONumber" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("PONumber") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="VR_BusinessPartner9_BPName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("VR_BusinessPartner9_BPName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("POProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total Weight" SortExpression="TotalWeight">
          <ItemTemplate>
            <asp:Label ID="LabelTotalWeight" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("TotalWeight") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Convert To Vehicle Request">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Convert to Vehicle Request ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Return To Supplier">
          <ItemTemplate>
            <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return to supplier ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VR Request No" SortExpression="VRRequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelVRRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Eval("VRRequestNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSpakPkgListH"
      runat = "server"
      DataObjectTypeName = "SIS.PAK.pakPkgListH"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_pakPkgListHSelectList"
      TypeName = "SIS.PAK.pakPkgListH"
      SelectCountMethod = "pakPkgListHSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SerialNo" PropertyName="Text" Name="SerialNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVpakPkgListH" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SerialNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
