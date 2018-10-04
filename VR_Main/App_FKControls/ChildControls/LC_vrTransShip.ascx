<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrTransShip.ascx.vb" Inherits="SIS.VR.LC_vrTransShip" %>
<script type="text/javascript">
  var lc_getTransShip = {
    activeEle: '',
    getTransShip: function(SRNNo, o) {
      showProcessingMPV();
      this.activeEle = o;
      try {
        $get('<%= F_ErrMsg.ClientID %>').innerHTML = '';
        PageMethods.GetTransShip(SRNNo, this.tsDetailsReceived, this.tsDetailsError);
      } catch (e) {
        hideProcessingMPV();
        $find('mpegetts').show();
      }
      return false;
    },
    tsDetailsReceived: function(r) {
      var aVal = r.split('|');
      try {
        $get('<%= F_Context.ClientID %>').innerHTML = aVal[0];
        $get('<%= F_SRNNo.ClientID %>').innerHTML = aVal[0];
        $get('<%= F_Description.ClientID %>').innerHTML = aVal[1];
        $get('<%= F_TransTransporterID.ClientID %>').value = aVal[2];
        $get('<%= F_TransTransporterID_Display.ClientID %>').value = aVal[3];
        $get('<%= F_TransVehicleNo.ClientID %>').value = aVal[4];
        $get('<%= F_TransGRNO.ClientID %>').value = aVal[5];
        $get('<%= F_TransGRDate.ClientID %>').value = aVal[6];
        $get('<%= F_TransVehicleTypeID.ClientID %>').value = aVal[7];
        $get('<%= F_TransRemarks.ClientID %>').value = aVal(8);
      } catch (e) { }
      hideProcessingMPV();
      $find('mpegetts').show();
    },
    tsDetailsError: function(r) {
      $get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
      hideProcessingMPV();
    },
    saveTransShip: function(o) {
      if ($get('<%= F_SRNNo.ClientID %>').value != '0') {
      }
      showProcessingMPV();
      PageMethods.SaveTransShip(
        $get('<%= F_SRNNo.ClientID %>').innerHTML + '|' +
        $get('<%= F_TransTransporterID.ClientID %>').value + '|' +
        $get('<%= F_TransVehicleNo.ClientID %>').value + '|' +
        $get('<%= F_TransGRNO.ClientID %>').value + '|' +
        $get('<%= F_TransGRDate.ClientID %>').value + '|' +
        $get('<%= F_TransVehicleTypeID.LCClientID %>').value + '|' +
        $get('<%= F_TransRemarks.ClientID %>').value
      , this.TSSaved, this.saveTSError);
    },
    TSSaved: function(r) {
      javasceipt: __doPostBack(lc_getTransShip.activeEle.name, '');
      //No need to hide, because full post back for gridview
      //hideProcessingMPV();
      $find('mpegetts').hide();
    },
    saveTSError: function(r) {
      $get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
      hideProcessingMPV();
    },
    showPop: function() {
      var mPop = $find('mpegetts');
      mPop.show();
    },
    hidePop: function() {
      var mPop = $find('mpegetts');
      mPop.hide();
    }
  }
</script>
<script type="text/javascript">
  var script_vrTransShip = {
    ACETransTransporterID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('TransTransporterID', '');
      var F_TransTransporterID = $get(sender._element.id);
      var F_TransTransporterID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_TransTransporterID.value = p[0];
      F_TransTransporterID_Display.innerHTML = e.get_text();
    },
    ACETransTransporterID_Populating: function(sender, e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('TransTransporterID', '');
      p.style.backgroundImage = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat = 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACETransTransporterID_Populated: function(sender, e) {
      var p = sender.get_element();
      p.style.backgroundImage = 'none';
    },
    validate_TransTransporterID: function(sender) {
      var Prefix = sender.id.replace('TransTransporterID', '');
      this.validated_FK_VR_RequestExecution_TransTransporterID_main = true;
      this.validate_FK_VR_RequestExecution_TransTransporterID(sender, Prefix);
    },
    validate_FK_VR_RequestExecution_TransTransporterID: function(o, Prefix) {
      var value = o.id;
      var TransTransporterID = $get(Prefix + 'TransTransporterID');
      if (TransTransporterID.value == '') {
        if (this.validated_FK_VR_RequestExecution_TransTransporterID_main) {
          var o_d = $get(Prefix + 'TransTransporterID' + '_Display');
          try { o_d.innerHTML = ''; } catch (ex) { }
        }
        return true;
      }
      value = value + ',' + TransTransporterID.value;
      o.style.backgroundImage = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat = 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validate_FK_VR_RequestExecution_TransTransporterID(value, this.validated_FK_VR_RequestExecution_TransTransporterID);
    },
    validated_FK_VR_RequestExecution_TransTransporterID_main: false,
    validated_FK_VR_RequestExecution_TransTransporterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if (script_vrTransShip.validated_FK_VR_RequestExecution_TransTransporterID_main) {
        var o_d = $get(p[1] + '_Display');
        try { o_d.innerHTML = p[2]; } catch (ex) { }
      }
      o.style.backgroundImage = 'none';
      if (p[0] == '1') {
        o.value = '';
        o.focus();
      }
    },
    temp: function() {
    }
  }
</script>
    <asp:Label ID="dummy" runat="server" Text="dummy" style="display:none" ></asp:Label>
    <asp:Panel ID="pnlsrem" runat="server" Style="display:none; width: 600px" CssClass="modalPopup">
      <table style="width: 100%">
        <tr>
          <td style="background-color: Navy">
            <asp:Image ID="Image2" runat="server" AlternateText="Task" ToolTip="Task" ImageUrl="~/App_Themes/Default/Images/application.png" />
          </td>
          <td id="dragsrem" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White; height: 24px">
            Vehicle Request Execution: Trans Shipment Details
          </td>
          <td style="background-color: Navy; text-align: right">
            <asp:ImageButton ID="closesrem" runat="server" Height="20px" Width="20px" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
          </td>
        </tr>
      </table>
		<asp:Label ID="F_Context" ForeColor="#CC6633" style="display:none" runat="server" Text="" />
		<table width="100%" style="text-align: left" >
		  <tr>
				<td class="alignleft" colspan="4">
      		<asp:Label ID="F_ErrMsg" ForeColor="Red" Font-Size="10px" style="display:block" runat="server" Text="" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" ForeColor="#CC6633" runat="server" Text="Request Execution No :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SRNNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" ForeColor="#CC6633" runat="server" Text="Description :" /></b>
				</td>
        <td>
          <asp:Label ID="F_Description" runat="server" />
        </td>
      </tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransGRNO" runat="server" Text="Trans Shipment GR No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransGRNO"
						Text='<%# Bind("TransGRNO") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransShip"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Trans Shipment GR No."
						MaxLength="50"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransGRDate" runat="server" Text="Trans Shipment GR Date :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransGRDate"
						Text='<%# Bind("TransGRDate") %>'
            Width="70px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransShip"
						runat="server" />
					<asp:Image ID="ImageButtonTransGRDate" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CETransGRDate"
            TargetControlID="F_TransGRDate"
            Format="dd/MM/yyyy"
            OnClientShown="ShownCalendar"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonTransGRDate" />
					<AJX:MaskedEditExtender 
						ID = "MEETransGRDate"
						runat = "server"
						mask = "99/99/9999"
						MaskType="Date"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_TransGRDate" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransVehicleNo" runat="server" Text="Trans Shipment Vehicle No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransVehicleNo"
						Text='<%# Bind("TransVehicleNo") %>'
            Width="140px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrTransShip"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Trans Shipment Vehicle No."
						MaxLength="20"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransVehicleTypeID" runat="server" Text="Trans Shipment Vehicle Type ID :" /></b>
				</td>
        <td>
          <LGM:LC_vrVehicleTypes
            ID="F_TransVehicleTypeID"
            SelectedValue='<%# Bind("TransVehicleTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="400px"
            CssClass="myfktxt"
						ValidationGroup = "vrTransShip"
            RequiredFieldErrorMessage = "Trans Shipment Vehicle Type ID is required."
            Runat="Server" />
          </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransTransporterID" runat="server" Text="Trans Shipment Transporter ID :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_TransTransporterID"
						CssClass = "myfktxt"
						Text='<%# Bind("TransTransporterID") %>'
						AutoCompleteType = "None"
            Width="63px"
						onfocus = "return this.select();"
            ToolTip="Enter value for Trans Shipment Transporter ID."
						ValidationGroup = "vrTransShip"
            onblur= "script_vrTransShip.validate_TransTransporterID(this);"
						Runat="Server" />
					<asp:Label
						ID = "F_TransTransporterID_Display"
						Text='<%# Eval("VR_Transporters8_TransporterName") %>'
						Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACETransTransporterID"
            BehaviorID="B_ACETransTransporterID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="TransTransporterIDCompletionList"
            TargetControlID="F_TransTransporterID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientShown="ShownOptions"
            OnClientItemSelected="script_vrTransShip.ACETransTransporterID_Selected"
            OnClientPopulating="script_vrTransShip.ACETransTransporterID_Populating"
            OnClientPopulated="script_vrTransShip.ACETransTransporterID_Populated"
            CompletionSetCount="10"
						CompletionListCssClass = "autocomplete_completionListElement"
						CompletionListItemCssClass = "autocomplete_listItem"
						CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_TransRemarks" runat="server" Text="Trans Shipment Remarks :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_TransRemarks"
						Text='<%# Bind("TransRemarks") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestExecution"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Trans Shipment Remarks."
						MaxLength="500"
            Width="350px" Height="40px" TextMode="MultiLine"
						runat="server" />
				</td>
			</tr>
		</table>
		<br />
    <table width="100%">
      <tr>
        <td style="text-align:center">
          <input type="button" value="Cancel" onclick="lc_getTransShip.hidePop();" style="background-color:silver; color: Red" />
        </td>
        <td style="text-align:center">
          <asp:Button runat="server" ID="cmdSave" ValidationGroup = "vrTransShip" causesvalidation="true" Text=" Save " onClientclick="lc_getTransShip.saveTransShip();" style="background: green;color: Lime" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpegetts" PopupControlID="pnlsrem" OkControlID="closesrem" CancelControlID="closesrem" PopupDragHandleControlID="dragsrem" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />

