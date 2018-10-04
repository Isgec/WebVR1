<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrLorryReceiptStatus.aspx.vb" Inherits="GF_vrLorryReceiptStatus" title="Maintain List: Lorry Receipt Status" %>
<asp:Content ID="CPHvrLorryReceiptStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelvrLorryReceiptStatus" runat="server" Text="&nbsp;List: Lorry Receipt Status"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptStatus" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLorryReceiptStatus"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLorryReceiptStatus.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrLorryReceiptStatus.aspx"
      ValidationGroup = "vrLorryReceiptStatus"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLorryReceiptStatus" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceiptStatus" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrLorryReceiptStatus" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceiptStatus" DataKeyNames="LRStatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Lorry Receipt Status ID" SortExpression="LRStatusID">
          <ItemTemplate>
            <asp:Label ID="LabelLRStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LRStatusID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
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
      ID = "ODSvrLorryReceiptStatus"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLorryReceiptStatus"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrLorryReceiptStatusSelectList"
      TypeName = "SIS.VR.vrLorryReceiptStatus"
      SelectCountMethod = "vrLorryReceiptStatusSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceiptStatus" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
