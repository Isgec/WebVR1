<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrTransporters.aspx.vb" Inherits="GF_vrTransporters" title="Maintain List: Transporters" %>
<asp:Content ID="CPHvrTransporters" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrTransporters" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrTransporters" runat="server" Text="&nbsp;List: Transporters" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrTransporters"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrTransporters.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrTransporters.aspx"
      ValidationGroup = "vrTransporters"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrTransporters" runat="server" AssociatedUpdatePanelID="UPNLvrTransporters" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
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
    <asp:GridView ID="GVvrTransporters" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrTransporters" DataKeyNames="TransporterID">
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
        <asp:TemplateField HeaderText="Transporter ID" SortExpression="TransporterID">
          <ItemTemplate>
            <asp:Label ID="LabelTransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransporterID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter Name" SortExpression="TransporterName">
          <ItemTemplate>
            <asp:Label ID="LabelTransporterName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransporterName") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address Line [1]" SortExpression="Address1Line">
          <ItemTemplate>
            <asp:Label ID="LabelAddress1Line" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Address1Line") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Address Line [2]" SortExpression="Address2Line">
          <ItemTemplate>
            <asp:Label ID="LabelAddress2Line" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Address2Line") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="City" SortExpression="City">
          <ItemTemplate>
            <asp:Label ID="LabelCity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("City") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EMail ID" SortExpression="EMailID">
          <ItemTemplate>
            <asp:Label ID="LabelEMailID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EMailID") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send To SuperProcure">
          <ItemTemplate>
             <asp:ImageButton ID="cmdSPRequest" runat="server" AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Send to Super Procure" SkinID="forward"  CommandName="SPRequest" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrTransporters"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrTransporters"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrTransportersSelectList"
      TypeName = "SIS.VR.vrTransporters"
      SelectCountMethod = "vrTransportersSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVvrTransporters" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
