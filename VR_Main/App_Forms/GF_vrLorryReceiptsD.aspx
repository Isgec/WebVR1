<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_vrLorryReceiptsD.aspx.vb" Inherits="GF_vrLorryReceiptsD" title="Display: Site Receipt" %>
<asp:Content ID="CPHvrLorryReceiptsD" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelvrLorryReceiptsD" runat="server" Text="&nbsp;List: Site Receipt"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptsD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLorryReceiptsD"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLorryReceiptsD.aspx"
      AddUrl = ""
      EnableAdd="false"
      ValidationGroup = "vrLorryReceiptsD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLorryReceiptsD" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceiptsD" DisplayAfter="100">
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
          <b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
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
        <td class="alignright">
          <b><asp:Label ID="Label1" runat="server" Text="Supplier :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_Supplier"
            CssClass = "mypktxt"
            Width="100px"
            Text=""
            AutoPostBack="true"
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransporterID"
            CssClass = "myfktxt"
            Width="80px"
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
        <td class="alignright">
          <b><asp:Label ID="Label2" runat="server" Text="GR No. :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GRNo"
            CssClass = "mypktxt"
            Width="100px"
            Text=""
            AutoPostBack="true"
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CustomerID" runat="server" Text="Customer :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CustomerID"
            CssClass = "myfktxt"
            Width="80px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CustomerID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CustomerID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECustomerID"
            BehaviorID="B_ACECustomerID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CustomerIDCompletionList"
            TargetControlID="F_CustomerID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECustomerID_Selected"
            OnClientPopulating="ACECustomerID_Populating"
            OnClientPopulated="ACECustomerID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td></td>
        <td></td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" /></b>
        </td>
        <td>
          <LGM:LC_vrVehicleTypes
            ID="F_VehicleTypeID"
            SelectedValue=""
            OrderBy="cmba"
            DataTextField="cmba"
            DataValueField="VehicleTypeID"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            AutoPostBack="true"
            RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
            CssClass="myddl"
            Runat="Server" />
          </td>
        <td></td>
        <td></td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
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
    <asp:GridView ID="GVvrLorryReceiptsD" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceiptsD" DataKeyNames="ProjectID,MRNNo">
      <Columns>
        <asp:TemplateField HeaderText="DETAIL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Display the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PRINT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects2_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MRN No" SortExpression="MRNNo">
          <ItemTemplate>
            <asp:Label ID="LabelMRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MRNNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MRN Date" SortExpression="MRNDate">
          <ItemTemplate>
            <asp:Label ID="LabelMRNDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("MRNDate") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter" SortExpression="VR_Transporters7_TransporterName">
          <ItemTemplate>
             <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters7_TransporterName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Registration No" SortExpression="VehicleRegistrationNo">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleRegistrationNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRegistrationNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VR_VehicleTypes8_cmba">
          <ItemTemplate>
             <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes8_cmba") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="LR Status" SortExpression="VR_LorryReceiptStatus4_Description">
          <ItemTemplate>
             <asp:Label ID="L_LRStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("LRStatusID") %>' Text='<%# Eval("VR_LorryReceiptStatus4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLorryReceiptsD"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLorryReceiptsD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrLorryReceiptsDSelectList"
      TypeName = "SIS.VR.vrLorryReceiptsD"
      SelectCountMethod = "vrLorryReceiptsDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_VehicleTypeID" PropertyName="SelectedValue" Name="VehicleTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CustomerID" PropertyName="Text" Name="CustomerID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_Supplier" PropertyName="Text" Name="Supplier" Type="String" Size="50" />
        <asp:ControlParameter ControlID="F_GRNo" PropertyName="Text" Name="GRNo" Type="String" Size="50" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceiptsD" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
    <asp:AsyncPostBackTrigger ControlID="F_VehicleTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_CustomerID" />
    <asp:AsyncPostBackTrigger ControlID="F_Supplier" />
    <asp:AsyncPostBackTrigger ControlID="F_GRNo" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
