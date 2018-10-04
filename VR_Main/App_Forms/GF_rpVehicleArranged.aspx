<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_rpVehicleArranged.aspx.vb" Inherits="GF_rpVehicleArranged" title="Report: Vehicle Arranged" %>
<asp:Content ID="CPHvrReports" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
  <asp:Label ID="LabelvrReports" runat="server" Text="&nbsp;Print: Vehicle Arranged" Width="100%" CssClass="sis_formheading"></asp:Label>
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
						InvalidValueMessage = "Invalid Date."
						EmptyValueMessage = "Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter Date."
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
						InvalidValueMessage = "Invalid Date."
						EmptyValueMessage = "Date is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter Date."
						EnableClientScript = "true"
						ValidationGroup = "vrReports"
						IsValidEmpty = "false"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DivisionID" runat="server" Text="For Division :" /></b>
				</td>
        <td>
          <LGM:LC_qcmDivisions
            ID="F_DivisionID"
            SelectedValue='<%# Bind("DivisionID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
					<td class="alignright">
						<b><asp:Label ID="L_OutOfContract" runat="server" ForeColor="Red" Text="Only Out Of Contract :" /></b>
					</td>
					<td>
						<asp:CheckBox ID="F_OutOfContract"
						 Checked='<%# Bind("OutOfContract") %>'
						 runat="server" />
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
<asp:ObjectDataSource 
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
