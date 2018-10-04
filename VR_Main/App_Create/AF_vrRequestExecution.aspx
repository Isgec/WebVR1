<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrRequestExecution.aspx.vb" Inherits="AF_vrRequestExecution" title="Add: Request Execution" %>
<asp:Content ID="CPHvrRequestExecution" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;Add: Request Execution"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrRequestExecution" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrRequestExecution"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/VR_Main/App_Edit/EF_vrRequestExecution.aspx"
    ValidationGroup = "vrRequestExecution"
    runat = "server" />
<asp:FormView ID="FVvrRequestExecution"
	runat = "server"
	DataKeyNames = "SRNNo"
	DataSourceID = "ODSvrRequestExecution"
	DefaultMode = "Insert" CssClass="sis_formview">
	<InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgvrRequestExecution" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" ForeColor="#CC6633" runat="server" Text="Request Execution No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SRNNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ExecutionDescription" runat="server" Text="Execution Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ExecutionDescription"
						Text='<%# Bind("ExecutionDescription") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestExecution"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Execution Description."
						MaxLength="50"
            Width="350px"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVExecutionDescription"
						runat = "server"
						ControlToValidate = "F_ExecutionDescription"
						Text = "Execution Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrRequestExecution"
						SetFocusOnError="true" />
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
            Width="63px"
						Text='<%# Bind("TransporterID") %>'
						AutoCompleteType = "None"
						onfocus = "return this.select();"
            ToolTip="Enter value for Transporter."
						ValidationGroup = "vrRequestExecution"
            onblur= "script_vrRequestExecution.validate_TransporterID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TransporterID_Display"
						Text='<%# Eval("VR_Transporters10_TransporterName") %>'
						Runat="Server" />
					<asp:RequiredFieldValidator 
						ID = "RFVTransporterID"
						runat = "server"
						ControlToValidate = "F_TransporterID"
						Text = "Transporter is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrRequestExecution"
						SetFocusOnError="true" />
          <AJX:AutoCompleteExtender
            ID="ACETransporterID"
            BehaviorID="B_ACETransporterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TransporterIDCompletionList"
            TargetControlID="F_TransporterID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrRequestExecution.ACETransporterID_Selected"
            OnClientPopulating="script_vrRequestExecution.ACETransporterID_Populating"
            OnClientPopulated="script_vrRequestExecution.ACETransporterID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
				<td class="alignright">
					<b><asp:Label ID="L_VehiclePlacedOn" runat="server" Text="Vehicle Placed On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehiclePlacedOn"
						Text='<%# Bind("VehiclePlacedOn") %>'
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrRequestExecution"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonVehiclePlacedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEVehiclePlacedOn"
            TargetControlID="F_VehiclePlacedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehiclePlacedOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEVehiclePlacedOn"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_VehiclePlacedOn" />
					<AJX:MaskedEditValidator 
						ID = "MEVVehiclePlacedOn"
						runat = "server"
						ControlToValidate = "F_VehiclePlacedOn"
						ControlExtender = "MEEVehiclePlacedOn"
						InvalidValueMessage = "Invalid value for Vehicle Placed On."
						EmptyValueMessage = "Vehicle Placed On is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Vehicle Placed On."
						EnableClientScript = "true"
						ValidationGroup = "vrRequestExecution"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
				</td>
        <td>
          <LGM:LC_vrVehicleTypes
            ID="F_VehicleTypeID"
            SelectedValue='<%# Bind("VehicleTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="400px"
            CssClass="myddl"
						ValidationGroup = "vrRequestExecution"
            RequiredFieldErrorMessage = "Vehicle Type is required."
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehicleNo"
						Text='<%# Bind("VehicleNo") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestExecution"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vehicle No."
						MaxLength="20"
            Width="140px"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EstimatedDistance" runat="server" Text="Weight :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EstimatedDistance"
						Text='<%# Bind("EstimatedDistance") %>'
            Width="100px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrRequestExecution"
						MaxLength="12"
						onfocus = "return this.select();"
					  onblur="return  script_vrRequestExecution.Validate_Distance(this);dc(this,2);"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_EstimatedRatePerKM" runat="server" Text="Rate Per Kg :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EstimatedRatePerKM"
						Text='<%# Bind("EstimatedRatePerKM") %>'
            Width="100px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrRequestExecution"
						MaxLength="10"
					  onblur="return script_vrRequestExecution.Validate_RatePerKM(this); dc(this,2); "
						onfocus = "return this.select();"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EstimatedAmount" runat="server" Text="Amount :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_EstimatedAmount"
						Text='<%# Bind("EstimatedAmount") %>'
            Width="100px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrRequestExecution"
						MaxLength="14"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEEstimatedAmount"
						runat = "server"
						mask = "999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_EstimatedAmount" />
					<AJX:MaskedEditValidator 
						ID = "MEVEstimatedAmount"
						runat = "server"
						ControlToValidate = "F_EstimatedAmount"
						ControlExtender = "MEEEstimatedAmount"
						InvalidValueMessage = "!!!"
						EmptyValueMessage = "*"
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Amount."
						EnableClientScript = "true"
						ValidationGroup = "vrRequestExecution"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "[Required]"
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Remarks"
						Text='<%# Bind("Remarks") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestExecution"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Remarks."
						MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
				</td>
				<td></td>
				<td></td>
			</tr>
			
		</table>
		</div>
	</InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrRequestExecution"
  DataObjectTypeName = "SIS.VR.vrRequestExecution"
  InsertMethod="UZ_vrRequestExecutionInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrRequestExecution"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
  </div>
</asp:Content>
