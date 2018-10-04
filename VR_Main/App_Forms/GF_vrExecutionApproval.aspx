<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrExecutionApproval.aspx.vb" Inherits="GF_vrExecutionApproval" title="Maintain List: Request Execution Approval" %>
<asp:Content ID="CPHvrExecutionApproval" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrExecutionApproval" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrExecutionApproval" runat="server" Text="&nbsp;List: Request Execution Approval" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrExecutionApproval"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrExecutionApproval.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrExecutionApproval.aspx"
      ValidationGroup = "vrExecutionApproval"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrExecutionApproval" runat="server" AssociatedUpdatePanelID="UPNLvrExecutionApproval" DisplayAfter="100">
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
					<b><asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" /></b>
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
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
				</td>
        <td>
          <LGM:LC_vrVehicleTypes
            ID="F_VehicleTypeID"
            SelectedValue=""
            OrderBy="Description"
            DataTextField="Description"
            DataValueField="VehicleTypeID"
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
   var script_ApprovalRemarks = {
		temp: function() {
		}
		}
		</script>

    <asp:GridView ID="GVvrExecutionApproval" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrExecutionApproval" DataKeyNames="SRNNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></table>
          </ItemTemplate>
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EXE.NO" SortExpression="SRNNo">
          <ItemTemplate>
            <asp:Label ID="LabelSRNNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SRNNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EXECUTION DESCRIPTION" SortExpression="ExecutionDescription">
          <ItemTemplate>
            <asp:Label ID="LabelExecutionDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ExecutionDescription") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="TRANSPORTER" SortExpression="VR_Transporters10_TransporterName">
          <ItemTemplate>
             <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters10_TransporterName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VEHICLE" SortExpression="VR_VehicleTypes13_cmba">
          <ItemTemplate>
             <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes13_cmba") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="150px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="PLACED ON" SortExpression="VehiclePlacedOn">
          <ItemTemplate>
            <asp:Label ID="LabelVehiclePlacedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehiclePlacedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EXECUTED BY" SortExpression="aspnet_Users1_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ArrangedBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ArrangedBy") %>' Text='<%# Eval("aspnet_Users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle VerticalAlign="Top" />
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REMARKS" SortExpression="ApprovalRemarks">
          <ItemTemplate>
					<asp:TextBox ID="F_ApprovalRemarks"
						Text='<%# Bind("ApprovalRemarks") %>'
            Width="250px" Height="30px" TextMode="MultiLine"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Approval Remarks."
						MaxLength="200"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVApprovalRemarks"
						runat = "server"
						ControlToValidate = "F_ApprovalRemarks"
						Text = "*"
						ErrorMessage = "*"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = '<%# "Reject" & Container.DataItemIndex %>'
						SetFocusOnError="true" />

          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="APPROVE">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Approve" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Approve record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="REJECT">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Reject" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Reject record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrExecutionApproval"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrExecutionApproval"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrExecutionApprovalSelectList"
      TypeName = "SIS.VR.vrExecutionApproval"
      SelectCountMethod = "vrExecutionApprovalSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
        <asp:ControlParameter ControlID="F_VehicleTypeID" PropertyName="SelectedValue" Name="VehicleTypeID" Type="Int32" Size="10" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrExecutionApproval" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
    <asp:AsyncPostBackTrigger ControlID="F_VehicleTypeID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
