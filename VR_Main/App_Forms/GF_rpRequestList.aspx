<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_rpRequestList.aspx.vb" Inherits="GF_rpRequestList" title="Report: Request List" %>
<asp:Content ID="CPHvrReports" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<%--<asp:UpdatePanel ID="UPNLvrReports" runat="server"  >
  <ContentTemplate>
--%>  <asp:Label ID="LabelvrReports" runat="server" Text="&nbsp;Print: Request List" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrReports"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrReports"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrReports"
	runat = "server"
	DataKeyNames = "FProject"
	DataSourceID = "ODSvrReports"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrReports" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table width="100%">
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FProject" runat="server" Text="From Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_FProject"
						CssClass = "myfktxt"
            Width="42px"
						Text='<%# Bind("FProject") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for From Project."
            onblur= "script_vrReports.validate_FProject(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_FProject_Display"
						Text='<%# Eval("IDM_Projects3_Description") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFProject"
            BehaviorID="B_ACEFProject"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FProjectCompletionList"
            TargetControlID="F_FProject"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACEFProject_Selected"
            OnClientPopulating="script_vrReports.ACEFProject_Populating"
            OnClientPopulated="script_vrReports.ACEFProject_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_TProject" runat="server" Text="To Project :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TProject"
						CssClass = "myfktxt"
            Width="42px"
						Text='<%# Bind("TProject") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for To Project."
            onblur= "script_vrReports.validate_TProject(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TProject_Display"
						Text='<%# Eval("IDM_Projects4_Description") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETProject"
            BehaviorID="B_ACETProject"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TProjectCompletionList"
            TargetControlID="F_TProject"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACETProject_Selected"
            OnClientPopulating="script_vrReports.ACETProject_Populating"
            OnClientPopulated="script_vrReports.ACETProject_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FSupplier" runat="server" Text="From Transporter :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_FSupplier"
						CssClass = "myfktxt"
            Width="63px"
						Text='<%# Bind("FSupplier") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for From Transporter."
            onblur= "script_vrReports.validate_FSupplier(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_FSupplier_Display"
						Text='<%# Eval("VR_Transporters5_TransporterName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFSupplier"
            BehaviorID="B_ACEFSupplier"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FSupplierCompletionList"
            TargetControlID="F_FSupplier"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACEFSupplier_Selected"
            OnClientPopulating="script_vrReports.ACEFSupplier_Populating"
            OnClientPopulated="script_vrReports.ACEFSupplier_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_TSupplier" runat="server" Text="To Transporter :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TSupplier"
						CssClass = "myfktxt"
            Width="63px"
						Text='<%# Bind("TSupplier") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for To Transporter."
            onblur= "script_vrReports.validate_TSupplier(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TSupplier_Display"
						Text='<%# Eval("VR_Transporters6_TransporterName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETSupplier"
            BehaviorID="B_ACETSupplier"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TSupplierCompletionList"
            TargetControlID="F_TSupplier"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACETSupplier_Selected"
            OnClientPopulating="script_vrReports.ACETSupplier_Populating"
            OnClientPopulated="script_vrReports.ACETSupplier_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FReqDt" runat="server" Text="From Request Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_FReqDt"
						Text='<%# Bind("FReqDt") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrReports"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonFReqDt" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEFReqDt"
            TargetControlID="F_FReqDt"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonFReqDt" />
					<AJX:MaskedEditExtender 
						ID = "MEEFReqDt"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_FReqDt" />
					<AJX:MaskedEditValidator 
						ID = "MEVFReqDt"
						runat = "server"
						ControlToValidate = "F_FReqDt"
						ControlExtender = "MEEFReqDt"
						InvalidValueMessage = "Invalid value for From Request Date."
						EmptyValueMessage = "From Request Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for From Request Date."
						EnableClientScript = "true"
						ValidationGroup = "vrReports"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_TReqDt" runat="server" Text="To Request Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TReqDt"
						Text='<%# Bind("TReqDt") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrReports"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonTReqDt" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETReqDt"
            TargetControlID="F_TReqDt"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTReqDt" />
					<AJX:MaskedEditExtender 
						ID = "MEETReqDt"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_TReqDt" />
					<AJX:MaskedEditValidator 
						ID = "MEVTReqDt"
						runat = "server"
						ControlToValidate = "F_TReqDt"
						ControlExtender = "MEETReqDt"
						InvalidValueMessage = "Invalid value for To Request Date."
						EmptyValueMessage = "To Request Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for To Request Date."
						EnableClientScript = "true"
						ValidationGroup = "vrReports"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_FUser" runat="server" Text="From Requester :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_FUser"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("FUser") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for From Requester."
            onblur= "script_vrReports.validate_FUser(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_FUser_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFUser"
            BehaviorID="B_ACEFUser"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FUserCompletionList"
            TargetControlID="F_FUser"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACEFUser_Selected"
            OnClientPopulating="script_vrReports.ACEFUser_Populating"
            OnClientPopulated="script_vrReports.ACEFUser_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_TUser" runat="server" Text="To Requester :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TUser"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("TUser") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for To Requester."
            onblur= "script_vrReports.validate_TUser(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TUser_Display"
						Text='<%# Eval("aspnet_Users2_UserFullName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETUser"
            BehaviorID="B_ACETUser"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TUserCompletionList"
            TargetControlID="F_TUser"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrReports.ACETUser_Selected"
            OnClientPopulating="script_vrReports.ACETUser_Populating"
            OnClientPopulated="script_vrReports.ACETUser_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td colspan="4" style="text-align:center">
					<asp:Button runat="server" ID="cmdGenerate" Text="  PRINT  " BackColor="Aqua" CausesValidation="true" ValidationGroup="vrReports" CommandName="Insert" />
				</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
<%--  </ContentTemplate>
</asp:UpdatePanel>
--%><asp:ObjectDataSource 
  ID = "ODSvrReports"
  DataObjectTypeName = "SIS.VR.vrReports"
  InsertMethod="vrReportsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrReports"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
