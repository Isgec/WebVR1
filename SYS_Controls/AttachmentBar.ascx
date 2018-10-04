<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AttachmentBar.ascx.vb" Inherits="AttachmentBar" %>
<table width="100%" style="border: solid 1pt #66CCFF; color: #1975FF" >
	<tr class="ps_bg">
	<td style="text-align:left; width:80%">
	  <asp:Label ID="txtBar" runat="server" Font-Size="12px" Font-Names="Tahoma" Font-Bold="true" Text="" />
	</td>
		<td style="text-align:right">
			<table>
				<tr>
					<td class="mnu_but">
						<asp:ImageButton ID="navFirst" ToolTip="First" AccessKey="T" runat="server" ImageUrl="~/TblImages/first0.png" onmouseover="this.src='../../tblimages/first2.png';" onmouseout="this.src='../../tblimages/first0.png';" />
					</td>
					<td class="mnu_but">
						<asp:ImageButton ID="navPrev" ToolTip="Previous" AccessKey="P" runat="server" ImageUrl="~/TblImages/prev0.png" onmouseover="this.src='../../tblimages/prev2.png';" onmouseout="this.src='../../tblimages/prev0.png';" />
					</td>
					<td >
						<asp:Label ID="Label3" runat="server" Text="Page#" />
					</td>
					<td>
						<asp:TextBox ID="_CurrentPage" runat="server" CssClass="mnu_txt" MaxLength="5" Width="40px" Text="1" ValidationGroup="currentpage" Style="text-align: right" AutoPostBack="True" />
						<AJX:MaskedEditExtender ID="MaskedEditExtenderCurrentPage" BehaviorID="meeCP" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" InputDirection="RightToLeft" ErrorTooltipEnabled="false" TargetControlID="_CurrentPage" PromptCharacter="" />
					</td>
					<td class="mnu_but">
						<asp:Label ID="Label1" runat="server" Text="of" />
					</td>
					<td class="mnu_but">
						<asp:Label ID="_TotalPages" runat="server" Width="25px" Style="text-align: right" />
					</td>
					<td>
						<asp:Label ID="Label2" runat="server" Text="Pages" />
					</td>
					<td class="mnu_but">
						<asp:ImageButton ID="navNext" ToolTip="Next" AccessKey="N" runat="server" ImageUrl="~/TblImages/next0.png" onmouseover="this.src='../../tblimages/next2.png';" onmouseout="this.src='../../tblimages/next0.png';" />
					</td>
					<td class="mnu_but">
						<asp:ImageButton ID="navLast" ToolTip="Last" AccessKey="L" runat="server" ImageUrl="~/TblImages/last0.png" onmouseover="this.src='../../tblimages/last2.png';" onmouseout="this.src='../../tblimages/last0.png';" />
					</td>
					<td>
						<asp:Label ID="Label4" runat="server" Text="Records" />
					</td>
					<td>
						<asp:TextBox ID="_PageSize" runat="server" CssClass="mnu_txt" MaxLength="5" Width="40px" ValidationGroup="currentpage" Style="text-align: right" />
						<AJX:MaskedEditExtender ID="MaskedEditExtenderPageSize" BehaviorID="meePS" runat="server" Mask="99999" AcceptNegative="None" MaskType="Number" MessageValidatorTip="false" InputDirection="RightToLeft" ErrorTooltipEnabled="false" TargetControlID="_PageSize" PromptCharacter="" />
						<AJX:MaskedEditValidator ID="MaskedEditValidatorPageSize" runat="server" ControlToValidate="_PageSize" ControlExtender="MaskedEditExtenderPageSize" InvalidValueMessage="" EmptyValueMessage="" EmptyValueBlurredText="" Display="Dynamic" TooltipMessage="" EnableClientScript="true" ValidationGroup="currentpage" IsValidEmpty="false" MinimumValue="2" MaximumValue="99999" SetFocusOnError="true" />
					</td>
					<td class="mnu_but">
						<asp:LinkButton ID="_PageSizeButton" runat="server" CausesValidation="False" CommandName="PageSize" ValidationGroup="currentpage" Text="/Page">
						</asp:LinkButton>
					</td>
				</tr>
			</table>
		</td>
		<td style="text-align:right">
		<table>
			<tr>
				<td class="mnu_but">
					<asp:CheckBox ID="DisableSearch" runat="server" Enabled="false" AutoPostBack="true" ToolTip="Uncheck for normal view." />
				</td>
				<td>
					<asp:TextBox ID="SearchTextBox" runat="server" CssClass="mnu_txt" ToolTip="Enter keywords to search." Font-Names="vardana" ValidationGroup="searchvalidationgroup" Width="80px" Font-Size="9px" MaxLength="250" />
					<AJX:TextBoxWatermarkExtender ID="Wm1" runat="server" TargetControlID="SearchTextBox" WatermarkText="[Search]">
					</AJX:TextBoxWatermarkExtender>
					<asp:RequiredFieldValidator ID="rfvst" runat="server" ControlToValidate="SearchTextBox" Display="none" EnableClientScript="true" ValidationGroup="searchvalidationgroup" SetFocusOnError="true" />
				</td>
				<td class="mnu_but">
					<asp:ImageButton ID="CmdSearch" runat="server" ImageUrl="~/TblImages/srh0.png" AlternateText="Search" ToolTip="Click to search"  />
				</td>
			</tr>
		</table>
		</td>
	</tr>
</table>
