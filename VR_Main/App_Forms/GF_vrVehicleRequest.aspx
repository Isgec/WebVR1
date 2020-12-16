<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrVehicleRequest.aspx.vb" Inherits="GF_vrVehicleRequest" title="Maintain List: Vehicle Request" %>
<asp:Content ID="CPHvrVehicleRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Vehicle Request"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrVehicleRequest" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrVehicleRequest"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrVehicleRequest.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrVehicleRequest.aspx"
      ValidationGroup = "vrVehicleRequest"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrVehicleRequest" runat="server" AssociatedUpdatePanelID="UPNLvrVehicleRequest" DisplayAfter="100">
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
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
						CssClass = "myfktxt"
            Width="92px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_SupplierID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SupplierID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACESupplierID"
            BehaviorID="B_ACESupplierID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SupplierIDCompletionList"
            TargetControlID="F_SupplierID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACESupplierID_Selected"
            OnClientPopulating="ACESupplierID_Populating"
            OnClientPopulated="ACESupplierID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
            Width="62px"
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
					<b><asp:Label ID="L_RequestStatus" runat="server" Text="Request Status :" /></b>
				</td>
        <td>
          <LGM:LC_vrRequestStates
            ID="F_RequestStatus"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="StatusID"
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
      function validate_Request(o) {
        var p=$get('<%= LabelErrMsg.ClientID %>');
        p.innerText='';
        return true;
      }
        var status = 0;
        function xxvalidate_Request(o) {
          $.ajax({
            type: "POST",
            async: false,
            url: "GF_vrVehicleRequest.aspx/validate_Request",
            data: "{" + o.alt + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(r) {
            var p = r.split('|');
            if (p[0] == '1') {
              alert(p[2]);
              status = 1;
            }
            else {
              if (confirm('Forward Record'))
                status = 2;
              else
                status = 1;
            }
          }
          });
        }
        function oovalidate_Request(o) {
          status = 0;
          PageMethods.validate_Request(o.alt, validate_Result);
          var i = 0;
          while (status == 0) {
            i = i + 1;
            i = i - 1;
          }
          if (status == 1)
            return false;
          else
            return true;
        }
        function validate_Result(r) {
          var p = r.split('|');
          if (p[0] == '1') {
            alert(p[2]);
            status = 1;
          }
          else {
            if (confirm('Forward Record'))
              status = 2;
            else
              status = 1;
          }
        }
      
    </script>
    <asp:Label ID="LabelErrMsg" runat="server" Font-Bold="true" ForeColor="Red" Font-Size="Larger" Text="" ></asp:Label>
    <asp:GridView ID="GVvrVehicleRequest" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrVehicleRequest" DataKeyNames="RequestNo">
      <Columns>
        <asp:TemplateField  HeaderText="EDIT">
          <ItemTemplate>
              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="PRNT">
          <ItemTemplate>
              <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField  HeaderText="COPY">
          <ItemTemplate>
              <asp:ImageButton ID="cmdCopy" runat="server"  AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Copy to a new record." SkinID="copy" OnClientClick="return confirm('Copy to new request ?');" CommandName="lgCopy" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REQ.NO" SortExpression="RequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REQUESTER" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_RequestedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignleft" />
          <HeaderStyle Width="125px"  />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SUPPLIER" SortExpression="IDM_Vendors5_Description">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="150px"  />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PROJECT" SortExpression="IDM_Projects4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="200px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ITEM" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VEHICLE" SortExpression="VR_VehicleTypes9_cmba">
          <ItemTemplate>
             <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes9_cmba") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="375px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REQUIRED ON" SortExpression="VehicleRequiredOn">
          <ItemTemplate>
            <asp:Label ID="LabelVehicleRequiredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRequiredOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="STATUS" SortExpression="VR_RequestStates7_Description">
          <ItemTemplate>
             <asp:Label ID="L_RequestStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatus") %>' Text='<%# Eval("VR_RequestStates7_Description") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" HorizontalAlign="Right" />
          <HeaderStyle Width="100px"  HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FWD">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" Height="16px" Width="16px" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && validate_Request(this);" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
<%--        <asp:ImageButton ID="ImageButton1" Height="16px" Width="16px" runat="server" AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Update CT" SkinID="complete" CommandName="UpdateCT" CommandArgument='<%# Container.DataItemIndex %>' />--%>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px"  />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EXE.NO" SortExpression="SRNNo">
          <ItemTemplate>
            <asp:Label ID="LabelSRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("SRNNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
        </asp:TemplateField>
        <asp:TemplateField >
          <ItemTemplate>
						</td></tr>
						<tr style="background-color:AntiqueWhite; color:DeepPink">
              <td colspan="5"></td>
              <td colspan="4">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TransporterName") %>'></asp:Label>
              </td>
              <td colspan="5">
                <asp:Label ID="LabelNotification" runat="server" Text='<%# Eval("Notification") %>'></asp:Label>
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
      ID = "ODSvrVehicleRequest"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrVehicleRequest"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrVehicleRequestSelectList"
      TypeName = "SIS.VR.vrVehicleRequest"
      SelectCountMethod = "vrVehicleRequestSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_RequestStatus" PropertyName="SelectedValue" Name="RequestStatus" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrVehicleRequest" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestStatus" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
