<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrLinkExecutions.aspx.vb" Inherits="AF_vrLinkExecutions" title="Add: Link Executions" %>
<asp:Content ID="CPHvrLinkExecutions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrLinkExecutions" runat="server" >
  <ContentTemplate>
  <asp:Label ID="LabelvrLinkExecutions" runat="server" Text="&nbsp;Add: Link Executions" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrLinkExecutions"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrLinkExecutions"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrLinkExecutions"
	runat = "server"
	DataKeyNames = "LinkID,SRNNo"
	DataSourceID = "ODSvrLinkExecutions"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <br />
    <asp:Label ID="L_ErrMsgvrLinkExecutions" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LinkID" ForeColor="#CC6633" runat="server" Text="Link ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LinkID"
						Text='<%# Bind("LinkID") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mypktxt"
						ValidationGroup="vrLinkExecutions"
						MaxLength="10"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEELinkID"
						runat = "server"
						mask = "9999999999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_LinkID" />
					<AJX:MaskedEditValidator 
						ID = "MEVLinkID"
						runat = "server"
						ControlToValidate = "F_LinkID"
						ControlExtender = "MEELinkID"
						InvalidValueMessage = "Invalid value for Link ID."
						EmptyValueMessage = "Link ID is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Link ID."
						EnableClientScript = "true"
						ValidationGroup = "vrLinkExecutions"
						IsValidEmpty = "false"
						MinimumValue = "1"
						MinimumValueBlurredText = "Link ID should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" ForeColor="#CC6633" runat="server" Text="Execution No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SRNNo"
						CssClass = "mypktxt"
            Width="70px"
						Text='<%# Bind("SRNNo") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Execution No."
						ValidationGroup = "vrLinkExecutions"
            onblur= "script_vrLinkExecutions.validate_SRNNo(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text='<%# Eval("VR_RequestExecution2_ExecutionDescription") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVSRNNo"
						runat = "server"
						ControlToValidate = "F_SRNNo"
						Text = "Execution No is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrLinkExecutions"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACESRNNo"
            BehaviorID="B_ACESRNNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="SRNNoCompletionList"
            TargetControlID="F_SRNNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLinkExecutions.ACESRNNo_Selected"
            OnClientPopulating="script_vrLinkExecutions.ACESRNNo_Populating"
            OnClientPopulated="script_vrLinkExecutions.ACESRNNo_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LinkedBy" runat="server" Text="Linked By :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_LinkedBy"
						CssClass = "myfktxt"
            Width="56px"
						Text='<%# Bind("LinkedBy") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Linked By."
						ValidationGroup = "vrLinkExecutions"
            onblur= "script_vrLinkExecutions.validate_LinkedBy(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_LinkedBy_Display"
						Text='<%# Eval("aspnet_Users1_UserFullName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVLinkedBy"
						runat = "server"
						ControlToValidate = "F_LinkedBy"
						Text = "Linked By is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrLinkExecutions"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACELinkedBy"
            BehaviorID="B_ACELinkedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="LinkedByCompletionList"
            TargetControlID="F_LinkedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLinkExecutions.ACELinkedBy_Selected"
            OnClientPopulating="script_vrLinkExecutions.ACELinkedBy_Populating"
            OnClientPopulated="script_vrLinkExecutions.ACELinkedBy_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LinkedOn" runat="server" Text="Linked On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LinkedOn"
						Text='<%# Bind("LinkedOn") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrLinkExecutions"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonLinkedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CELinkedOn"
            TargetControlID="F_LinkedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonLinkedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEELinkedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_LinkedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVLinkedOn"
						runat = "server"
						ControlToValidate = "F_LinkedOn"
						ControlExtender = "MEELinkedOn"
						InvalidValueMessage = "Invalid value for Linked On."
						EmptyValueMessage = "Linked On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Linked On."
						EnableClientScript = "true"
						ValidationGroup = "vrLinkExecutions"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
		<br />
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLinkExecutions"
  DataObjectTypeName = "SIS.VR.vrLinkExecutions"
  InsertMethod="vrLinkExecutionsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLinkExecutions"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</asp:Content>
