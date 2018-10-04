<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrReqReasonByExecuter.aspx.vb" Inherits="GF_vrReqReasonByExecuter" title="Maintain List: Req. Reason By Executer" %>
<asp:Content ID="CPHvrReqReasonByExecuter" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrReqReasonByExecuter" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrReqReasonByExecuter" runat="server" Text="&nbsp;List: Req. Reason By Executer" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrReqReasonByExecuter"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrReqReasonByExecuter.aspx"
      EnableAdd = "False"
      ValidationGroup = "vrReqReasonByExecuter"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrReqReasonByExecuter" runat="server" AssociatedUpdatePanelID="UPNLvrReqReasonByExecuter" DisplayAfter="100">
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
					<b><asp:Label ID="L_SupplierID" runat="server" Text="Supplier :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SupplierID"
						CssClass = "myfktxt"
            Width="42px"
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
					<b><asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_ProjectID"
						CssClass = "myfktxt"
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
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_VehicleTypeID"
						CssClass = "myfktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_VehicleTypeID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_VehicleTypeID_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEVehicleTypeID"
            BehaviorID="B_ACEVehicleTypeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="VehicleTypeIDCompletionList"
            TargetControlID="F_VehicleTypeID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEVehicleTypeID_Selected"
            OnClientPopulating="ACEVehicleTypeID_Populating"
            OnClientPopulated="ACEVehicleTypeID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_RequestedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_RequestedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestedBy_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestedBy"
            BehaviorID="B_ACERequestedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestedByCompletionList"
            TargetControlID="F_RequestedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERequestedBy_Selected"
            OnClientPopulating="ACERequestedBy_Populating"
            OnClientPopulated="ACERequestedBy_Populated"
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
					<asp:TextBox
						ID = "F_RequestStatus"
						CssClass = "myfktxt"
            Width="70px"
						Text=""
						onfocus = "return this.select();"
						AutoCompleteType = "None"
            onblur= "validate_RequestStatus(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_RequestStatus_Display"
						Text=""
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestStatus"
            BehaviorID="B_ACERequestStatus"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestStatusCompletionList"
            TargetControlID="F_RequestStatus"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACERequestStatus_Selected"
            OnClientPopulating="ACERequestStatus_Populating"
            OnClientPopulated="ACERequestStatus_Populated"
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
    <br />
    <asp:GridView ID="GVvrReqReasonByExecuter" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrReqReasonByExecuter" DataKeyNames="RequestNo">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request No" SortExpression="RequestNo">
          <ItemTemplate>
            <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="IDM_Vendors5_Description">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects4_Description">
          <ItemTemplate>
             <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Project Type" SortExpression="ProjectType">
          <ItemTemplate>
            <asp:Label ID="LabelProjectType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectType") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
          <ItemTemplate>
            <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Request Status" SortExpression="VR_RequestStates7_Description">
          <ItemTemplate>
             <asp:Label ID="L_RequestStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatus") %>' Text='<%# Eval("VR_RequestStates7_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executer Reason" SortExpression="VR_RequestReasons12_Description">
          <ItemTemplate>
             <asp:Label ID="L_ExecuterReasonID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ExecuterReasonID") %>' Text='<%# Eval("VR_RequestReasons12_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executer" SortExpression="aspnet_Users11_UserFullName">
          <ItemTemplate>
             <asp:Label ID="L_ExecuterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ExecuterID") %>' Text='<%# Eval("aspnet_Users11_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reason Enetered On" SortExpression="ReasonEneteredOn">
          <ItemTemplate>
            <asp:Label ID="LabelReasonEneteredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReasonEneteredOn") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="80px" />
        </asp:TemplateField>
<%--
        <asp:TemplateField HeaderText="Edit">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Edit" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Edit record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Save">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Save" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Save record ?"");" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cancel">
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Cancel" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Cancel record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
--%>
        <asp:TemplateField >
          <ItemTemplate>
						</td></tr>
						<tr style="background-color:AntiqueWhite; color:DeepPink">
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
              <td></td>
						</tr>
          </ItemTemplate>
          <HeaderStyle Width="10px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrReqReasonByExecuter"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrReqReasonByExecuter"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_vrReqReasonByExecuterSelectList"
      TypeName = "SIS.VR.vrReqReasonByExecuter"
      SelectCountMethod = "vrReqReasonByExecuterSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_VehicleTypeID" PropertyName="Text" Name="VehicleTypeID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_RequestedBy" PropertyName="Text" Name="RequestedBy" Type="String" Size="8" />
        <asp:Parameter Name="RequestStatus" Type="Int32" Size="10" DefaultValue="4" />
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrReqReasonByExecuter" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
    <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
    <asp:AsyncPostBackTrigger ControlID="F_VehicleTypeID" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestedBy" />
    <asp:AsyncPostBackTrigger ControlID="F_RequestStatus" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
