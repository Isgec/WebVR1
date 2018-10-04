<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrBusinessPartner.aspx.vb" Inherits="GF_vrBusinessPartner" title="Maintain List: Business Partner" %>
<asp:Content ID="CPHvrBusinessPartner" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelvrBusinessPartner" runat="server" Text="&nbsp;List: Business Partner"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrBusinessPartner" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrBusinessPartner"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrBusinessPartner.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrBusinessPartner.aspx"
      ValidationGroup = "vrBusinessPartner"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrBusinessPartner" runat="server" AssociatedUpdatePanelID="UPNLvrBusinessPartner" DisplayAfter="100">
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
          <b><asp:Label ID="L_BPID" runat="server" Text="Business Partner ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_BPID"
            Text=""
            CssClass = "mytxt"
            onfocus = "return this.select();"
            MaxLength="9"
            Width="63px"
            runat="server" />
        </td>
        <td>
          <asp:Button runat="server" ID="cmdSync" Text="Sync. with ERP" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVvrBusinessPartner" SkinID="gv_silver" runat="server" DataSourceID="ODSvrBusinessPartner" DataKeyNames="BPID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Business Partner ID" SortExpression="BPID">
          <ItemTemplate>
            <asp:Label ID="LabelBPID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BPID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Business Partner Name" SortExpression="BPName">
          <ItemTemplate>
            <asp:Label ID="LabelBPName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BPName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address Line [1]" SortExpression="Address1Line">
          <ItemTemplate>
            <asp:Label ID="LabelAddress1Line" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Address1Line") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address Line [2]" SortExpression="Address2Line">
          <ItemTemplate>
            <asp:Label ID="LabelAddress2Line" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Address2Line") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City" SortExpression="City">
          <ItemTemplate>
            <asp:Label ID="LabelCity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("City") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="E-Mail ID" SortExpression="EMailID">
          <ItemTemplate>
            <asp:Label ID="LabelEMailID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EMailID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrBusinessPartner"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrBusinessPartner"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrBusinessPartnerSelectList"
      TypeName = "SIS.VR.vrBusinessPartner"
      SelectCountMethod = "vrBusinessPartnerSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_BPID" PropertyName="Text" Name="BPID" Type="String" Size="9" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrBusinessPartner" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_BPID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
