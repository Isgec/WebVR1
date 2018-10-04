<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLinkExecutions.aspx.vb" Inherits="EF_vrLinkExecutions" title="Edit: Link Executions" %>
<asp:Content ID="CPHvrLinkExecutions" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrLinkExecutions" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrLinkExecutions" runat="server" Text="&nbsp;Edit: Link Executions" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrLinkExecutions"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrLinkExecutions"
    Skin = "tbl_blue"
    runat = "server" />
<asp:FormView ID="FVvrLinkExecutions"
	runat = "server"
	DataKeyNames = "LinkID,SRNNo"
	DataSourceID = "ODSvrLinkExecutions"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LinkID" runat="server" ForeColor="#CC6633" Text="Link ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LinkID"
						Text='<%# Bind("LinkID") %>'
            ToolTip="Value of Link ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" ForeColor="#CC6633" Text="Execution No :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SRNNo"
            Width="70px"
						Text='<%# Bind("SRNNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Execution No."
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text='<%# Eval("VR_RequestExecution2_ExecutionDescription") %>'
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
						Text='<%# Bind("LinkedBy") %>'
						AutoCompleteType = "None"
            Width="56px"
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
						onfocus = "return this.select();"
						ValidationGroup="vrLinkExecutions"
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
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLinkExecutions"
  DataObjectTypeName = "SIS.VR.vrLinkExecutions"
  SelectMethod = "vrLinkExecutionsGetByID"
  UpdateMethod="vrLinkExecutionsUpdate"
  DeleteMethod="vrLinkExecutionsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLinkExecutions"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LinkID" Name="LinkID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SRNNo" Name="SRNNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
