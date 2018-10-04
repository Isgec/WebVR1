<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_LinkExecution.ascx.vb" Inherits="SIS.VR.LC_LinkExecution" %>
<script type="text/javascript">
	var lc_getLink = {
		activeEle: '',
		getLink: function(SRNNo, o) {
			showProcessingMPV();
			this.activeEle = o;
			try {
				$get('<%= F_ErrMsg.ClientID %>').innerHTML = '';
				PageMethods.GetLink(SRNNo, this.linkReceived, this.linkError);
			} catch (e) {
				hideProcessingMPV();
				$find('mpegetLink').show();
			}
			return false;
		},
		linkReceived: function(r) {
		  var aVal = r.split('▒');
			try {
				$get('<%= F_Context.ClientID %>').innerHTML = aVal[0];
				$get('<%= F_MainSRNNo.ClientID %>').innerHTML = aVal[0];
				$get('LinkData').innerHTML = aVal[1];
			} catch (e) { }
			hideProcessingMPV();
			$find('mpegetLink').show();
		},
		linkError: function(r) {
			$get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
			hideProcessingMPV();
		},
		selectLink: function(o) {
			showProcessingMPV();
			PageMethods.SelectLink(o, this.linkReceived, this.linkError);
		},
		removeLink: function(o) {
			showProcessingMPV();
			PageMethods.RemoveLink(o, this.linkReceived, this.linkError);
		},
		showPop: function() {
			var mPop = $find('mpegetLink');
			mPop.show();
		},
		hidePop: function() {
			var mPop = $find('mpegetLink');
			mPop.hide();
			javasceipt: __doPostBack(lc_getLink.activeEle.id, 'click');
		}
	}
</script>
    <asp:Label ID="dummy" runat="server" Text="dummy" style="display:none" ></asp:Label>
    <asp:Panel ID="pllLink" runat="server" Style="display:none; width: 600px" CssClass="modalPopup">
      <table style="width: 100%">
        <tr>
          <td style="background-color: Navy">
            <asp:Image ID="Image2" runat="server" AlternateText="Task" ToolTip="Task" ImageUrl="~/App_Themes/Default/Images/application.png" />
          </td>
          <td id="dragsrem" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White; height: 24px">
            Link Executions
          </td>
          <td style="background-color: Navy; text-align: right">
            <asp:ImageButton ID="closeLink" runat="server" Height="20px" Width="20px" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
          </td>
        </tr>
      </table>
		<asp:Label ID="F_Context" ForeColor="#CC6633" style="display:none" runat="server" Text="" />
		<table style="text-align:left" width="100%">
		  <tr>
				<td class="alignleft" colspan="4">
      		<asp:Label ID="F_ErrMsg" ForeColor="Red" Font-Size="10px" style="display:block" runat="server" Text="" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" ForeColor="#CC6633" runat="server" Text="Execution No :" /></b>
				</td>
				<td colspan="3">
					<asp:Label ID="F_MainSRNNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" />
				</td>
      </tr>
      <tr>
				<td colspan="4" id="LinkData">
				</td>
      </tr>
		</table>
		<br />
    <table width="100%">
      <tr>
        <td style="text-align:center">
          <asp:Button ID="cmdOK" runat="server" BackColor="Lime" ForeColor="DarkGreen" Text="  OK  " />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpegetLink" PopupControlID="pllLink" OkControlID="cmdOK" CancelControlID="closeLink" PopupDragHandleControlID="dragsrem" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />

