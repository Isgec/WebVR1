<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrVehicleTypes.aspx.vb" Inherits="GF_vrVehicleTypes" title="Maintain List: Vehicle Types" %>
<asp:Content ID="CPHvrVehicleTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVehicleTypes" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrVehicleTypes" runat="server" Text="&nbsp;List: Vehicle Types" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrVehicleTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrVehicleTypes.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrVehicleTypes.aspx?skip=1"
      ValidationGroup = "vrVehicleTypes"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrVehicleTypes" runat="server" AssociatedUpdatePanelID="UPNLvrVehicleTypes" DisplayAfter="100">
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
    <asp:GridView ID="GVvrVehicleTypes" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrVehicleTypes" DataKeyNames="VehicleTypeID">
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
        <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VehicleTypeID">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleTypeID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Define Capacity" SortExpression="DefineCapacity">
          <ItemTemplate>
            <asp:Label ID="LabelDefineCapacity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DefineCapacity") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Capacity In KG" SortExpression="CapacityInKG">
          <ItemTemplate>
            <asp:Label ID="LabelCapacityInKG" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CapacityInKG") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Define Dimention" SortExpression="DefineDimention">
          <ItemTemplate>
            <asp:Label ID="LabelDefineDimention" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DefineDimention") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Height In Ft" SortExpression="HeightInFt">
          <ItemTemplate>
            <asp:Label ID="LabelHeightInFt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("HeightInFt") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Width In Ft" SortExpression="WidthInFt">
          <ItemTemplate>
            <asp:Label ID="LabelWidthInFt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WidthInFt") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Length In Ft" SortExpression="LengthInFt">
          <ItemTemplate>
            <asp:Label ID="LabelLengthInFt" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("LengthInFt") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enforce Minimum Capacity" SortExpression="EnforceMinimumCapacity">
          <ItemTemplate>
            <asp:Label ID="LabelEnforceMinimumCapacity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EnforceMinimumCapacity") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enforce Maximum Capacity" SortExpression="EnforceMaximumCapacity">
          <ItemTemplate>
            <asp:Label ID="LabelEnforceMaximumCapacity" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EnforceMaximumCapacity") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enforce Minimum Dimention" SortExpression="EnforceMinimumDimention">
          <ItemTemplate>
            <asp:Label ID="LabelEnforceMinimumDimention" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EnforceMinimumDimention") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Enforce Maximum Dimention" SortExpression="EnforceMaximumDimention">
          <ItemTemplate>
            <asp:Label ID="LabelEnforceMaximumDimention" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("EnforceMaximumDimention") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrVehicleTypes"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrVehicleTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrVehicleTypesSelectList"
      TypeName = "SIS.VR.vrVehicleTypes"
      SelectCountMethod = "vrVehicleTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVvrVehicleTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
