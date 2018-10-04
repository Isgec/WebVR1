<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrVTDefault.aspx.vb" Inherits="GF_vrVTDefault" title="Maintain List: Vehicle Request Defaults" %>
<asp:Content ID="CPHvrVTDefault" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVTDefault" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrVTDefault" runat="server" Text="&nbsp;List: Vehicle Request Defaults" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrVTDefault"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrVTDefault.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrVTDefault.aspx"
      ValidationGroup = "vrVTDefault"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrVTDefault" runat="server" AssociatedUpdatePanelID="UPNLvrVTDefault" DisplayAfter="100">
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
    <asp:GridView ID="GVvrVTDefault" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrVTDefault" DataKeyNames="SerialNo">
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
        <asp:TemplateField HeaderText="SerialNo" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Minimum Capacity Percentage" SortExpression="MinimumCapacityPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMinimumCapacityPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MinimumCapacityPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Maximum Capacity Percentage" SortExpression="MaximumCapacityPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMaximumCapacityPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MaximumCapacityPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Minimum Height Percentage" SortExpression="MinimumHeightPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMinimumHeightPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MinimumHeightPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Minimum Width Percentage" SortExpression="MinimumWidthPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMinimumWidthPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MinimumWidthPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Minimum Length Percentage" SortExpression="MinimumLengthPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMinimumLengthPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MinimumLengthPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Maximum Height Percentage" SortExpression="MaximumHeightPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMaximumHeightPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MaximumHeightPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Maximum Width Percentage" SortExpression="MaximumWidthPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMaximumWidthPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MaximumWidthPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Maximum Length Percentage" SortExpression="MaximumLengthPercentage">
          <ItemTemplate>
            <asp:Label ID="LabelMaximumLengthPercentage" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MaximumLengthPercentage") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrVTDefault"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrVTDefault"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrVTDefaultSelectList"
      TypeName = "SIS.VR.vrVTDefault"
      SelectCountMethod = "vrVTDefaultSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVvrVTDefault" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
