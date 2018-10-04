<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_vrGetGR.ascx.vb" Inherits="SIS.VR.LC_vrGetGR" %>
<script type="text/javascript">
	var lc_getGR = {
		activeEle: '',
		Context: '',
		SRNNo: '',
		Description: '',
		VehicleNo: '',
		GRNO: '',
		GRDate: '',
		LoadedOn: '',
		ReachedAtSupplierOn: '',
		SizeUnit: '',
		Height: '',
		Width: '',
		Length: '',
		MaterialWeight: '',
		WeightUnit: '',
		NoOfPackages: '',
		OverDimentionConsignement: '',
		GRRemarks: '',
		VehicleNotPlaced: '',
		DelayedPlacement: '',
		DebitToTransporter: '',
		EmptyReturn: '',
		DetentionAtSupplier: '',
		PayableToTransporter: '',
		BorneByISGEC: '',
		BorneBySupplier: '',
		EmptyReturnRemarks: '',
		ODCReasonID: '',
		Linked: '',
		IsMain: '',
		showErr: '',
		getGR: function(SRNNo, o) {
			showProcessingMPV();
			this.Context = $get('<%= F_Context.ClientID %>');
			this.SRNNo = $get('<%= F_SRNNo.ClientID %>');
			this.Description = $get('<%= F_Description.ClientID %>');
			this.VehicleNo = $get('<%= F_VehicleNo.ClientID %>');
			this.GRNO = $get('<%= F_GRNO.ClientID %>');
			this.GRDate = $get('<%= F_GRDate.ClientID %>');
			this.LoadedOn = $get('<%= F_LoadedOn.ClientID %>');
			this.ReachedAtSupplierOn = $get('<%= F_ReachedAtSupplierOn.ClientID %>');
			this.SizeUnit = $get('<%= F_SizeUnit.LCClientID %>');
			this.Height = $get('<%= F_Height.ClientID %>');
			this.Width = $get('<%= F_Width.ClientID %>');
			this.Length = $get('<%= F_Length.ClientID %>');
			this.MaterialWeight = $get('<%= F_MaterialWeight.ClientID %>');
			this.WeightUnit = $get('<%= F_WeightUnit.LCClientID %>');
			this.NoOfPackages = $get('<%= F_NoOfPackages.ClientID %>');
			this.OverDimentionConsignement = $get('<%= F_OverDimentionConsignement.ClientID %>');
			this.GRRemarks = $get('<%= F_GRRemarks.ClientID %>');
			this.VehicleNotPlaced = $get('<%= F_VehicleNotPlaced.ClientID %>');
			this.DelayedPlacement = $get('<%= F_DelayedPlacement.ClientID %>');
			this.DebitToTransporter = $get('<%= F_DebitToTransporter.ClientID %>');
			this.EmptyReturn = $get('<%= F_EmptyReturn.ClientID %>');
			this.DetentionAtSupplier = $get('<%= F_DetentionAtSupplier.ClientID %>');
			this.PayableToTransporter = $get('<%= F_PayableToTransporter.ClientID %>');
			this.BorneByISGEC = $get('<%= F_BorneByISGEC.ClientID %>');
			this.BorneBySupplier = $get('<%= F_BorneBySupplier.ClientID %>');
			this.EmptyReturnRemarks = $get('<%= F_EmptyReturnRemarks.ClientID %>');
			this.ODCReasonID = $get('<%= F_ODCReasonID.LCClientID %>');
			this.showErr = $get('<%= F_ErrMsg.ClientID %>');
			this.activeEle = o;
			this.Linked = false;
			this.IsMain = false;
			try {
				$get('<%= F_ErrMsg.ClientID %>').innerHTML = '';
				PageMethods.GetGRDetails(SRNNo, this.grDetailsReceived, this.grDetailsError);
			} catch (e) {
				hideProcessingMPV();
				$find('mpegetgr').show();
			}
			return false;
		},
		grDetailsReceived: function(r) {
			var aVal = r.split('|');
			try {
				$get('<%= F_Context.ClientID %>').innerHTML = aVal[0];
				$get('<%= F_SRNNo.ClientID %>').innerHTML = aVal[0];
				$get('<%= F_Description.ClientID %>').innerHTML = aVal[1];
				$get('<%= F_VehicleNo.ClientID %>').value = aVal[2];
				$get('<%= F_GRNO.ClientID %>').value = aVal[3];
				$get('<%= F_GRDate.ClientID %>').value = aVal[4];
				$get('<%= F_LoadedOn.ClientID %>').value = aVal[6];
				$get('<%= F_ReachedAtSupplierOn.ClientID %>').value = aVal[7];
				$get('<%= F_SizeUnit.LCClientID %>').value = aVal[8];
				$get('<%= F_Height.ClientID %>').value = aVal[9];
				$get('<%= F_Width.ClientID %>').value = aVal[10];
				$get('<%= F_Length.ClientID %>').value = aVal[11];
				$get('<%= F_MaterialWeight.ClientID %>').value = aVal[12];
				$get('<%= F_WeightUnit.LCClientID %>').value = aVal[13];
				$get('<%= F_NoOfPackages.ClientID %>').value = aVal[14];
				$get('<%= F_OverDimentionConsignement.ClientID %>').value = aVal[15];
				$get('<%= F_GRRemarks.ClientID %>').value = aVal[16];
				$get('<%= F_VehicleNotPlaced.ClientID %>').value = aVal[17];
				$get('<%= F_DelayedPlacement.ClientID %>').value = aVal[18];
				$get('<%= F_DebitToTransporter.ClientID %>').value = aVal[19];
				$get('<%= F_EmptyReturn.ClientID %>').value = aVal[20];
				$get('<%= F_DetentionAtSupplier.ClientID %>').value = aVal[21];
				$get('<%= F_PayableToTransporter.ClientID %>').value = aVal[22];
				$get('<%= F_BorneByISGEC.ClientID %>').value = aVal[23];
				$get('<%= F_BorneBySupplier.ClientID %>').value = aVal[24];
				$get('<%= F_EmptyReturnRemarks.ClientID %>').value = aVal[25];
				$get('<%= F_ODCReasonID.LCClientID %>').value = aVal[26];
				lc_getGR.Linked = (aVal[27] === 'true');
				lc_getGR.IsMain = (aVal[28] === 'true');
			} catch (e) { }
			if (lc_getGR.VehicleNotPlaced.checked)
				script_Enforce.DefineVNP(lc_getGR.VehicleNotPlaced);
			else
				script_Enforce.DefineER(lc_getGR.EmptyReturn);
			script_Enforce.DefineODC(lc_getGR.OverDimentionConsignement);
			hideProcessingMPV();
			$find('mpegetgr').show();
		},
		grDetailsError: function(r) {
			$get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
			hideProcessingMPV();
		},
		msg: function(o) {
			if (o == '') {
				this.showErr.innerHTML = '';
			} else {
				this.showErr.innerHTML = '<input src="../../App_Themes/Default/Images/Error.gif" type="image" style="height:16px; width:16px" alt="Error" />' + o;
			}
		},
		saveGR: function(o) {
			if (this.VehicleNotPlaced.checked) {
				if (this.GRRemarks.value == '') {
					this.msg('Enter Remarks for Vehicle Not Placed.');
					this.GRRemarks.focus();
					return;
				}
			} else {
				if (this.EmptyReturn.checked) {
					if (this.EmptyReturnRemarks.value == '') {
						this.msg('Please Enter Remarks for Empty Return.');
						this.EmptyReturnRemarks.focus();
						return;
					}
				}
				if (this.DetentionAtSupplier.checked) {
					if (this.EmptyReturnRemarks.value == '') {
						this.msg('Please Enter Remarks for Detension At Supplier.');
						this.EmptyReturnRemarks.focus();
						return;
					}
				}
				if (this.PayableToTransporter.checked) {
					if (!this.BorneByISGEC.checked && !this.BorneBySupplier.checked) {
						this.msg('Please select Payment to transporter will be BORNE BY.');
						this.PayableToTransporter.focus();
						return;
					}
				}
				if (!this.EmptyReturn.checked) {
					if (this.VehicleNo.value == '') {
						if (this.Linked) {
							if (this.IsMain) {
								this.msg('Enter Vehicle No.');
								this.VehicleNo.focus();
								return;
							}
						} else {
							this.msg('Enter Vehicle No.');
							this.VehicleNo.focus();
							return;
						}
					}
					if (this.GRNO.value == '') {
						this.msg('Enter GR No.');
						this.GRNO.focus();
						return;
					}
					if (this.GRDate.value == '') {
						this.msg('Enter GR Date.');
						this.GRDate.focus();
						return;
					}
					if (this.ReachedAtSupplierOn.value == '') {
						this.msg('Enter Date & Time when Vehicle reached at supplier.');
						this.ReachedAtSupplierOn.focus();
						return;
					}
					if (this.LoadedOn.value == '') {
						this.msg('Enter Date & Time when Vehicle left from supplier.');
						this.LoadedOn.focus();
						return;
					}
					if (this.OverDimentionConsignement.checked) {
						if (this.ODCReasonID.value == '') {
							this.msg('Select ODC Reason.');
							this.ODCReasonID.focus();
							return;
						}
						if (this.SizeUnit.value == '') {
							this.msg('Select SIZE Unit.');
							this.SizeUnit.focus();
							return;
						}
						if (Number(this.Length.value) <= 0) {
							this.msg('Enter Length.');
							this.Length.focus();
							return;
						}
						if (Number(this.Width.value) <= 0) {
							this.msg('Enter Width.');
							this.Width.focus();
							return;
						}
						if (Number(this.Height.value) <= 0) {
							this.msg('Enter Height.');
							this.Height.focus();
							return;
						}
						if (this.WeightUnit.value == '') {
							this.msg('Select WEIGHT Unit.');
							this.WeightUnit.focus();
							return;
						}
						if (Number(this.MaterialWeight.value) <= 0) {
							this.msg('Enter Weight.');
							this.MaterialWeight.focus();
							return;
						}
						if (Number(this.NoOfPackages.value) <= 0) {
							this.msg('Enter No. of Packages.');
							this.NoOfPackages.focus();
							return;
						}
					}
				}
			}
			showProcessingMPV();
			PageMethods.SaveGR(
        this.SRNNo.innerHTML + '|' +
        this.VehicleNo.value + '|' +
        this.GRNO.value + '|' +
        this.GRDate.value + '|' +
        this.LoadedOn.value + '|' +
        this.ReachedAtSupplierOn.value + '|' +
        this.SizeUnit.value + '|' +
        this.Height.value + '|' +
        this.Width.value + '|' +
        this.Length.value + '|' +
        this.MaterialWeight.value + '|' +
        this.WeightUnit.value + '|' +
        this.NoOfPackages.value + '|' +
        this.OverDimentionConsignement.checked + '|' +
        this.GRRemarks.value + '|' +
				this.VehicleNotPlaced.checked + '|' +
				this.DelayedPlacement.checked + '|' +
				this.DebitToTransporter.checked + '|' +
				this.EmptyReturn.checked + '|' +
				this.DetentionAtSupplier.checked + '|' +
				this.PayableToTransporter.checked + '|' +
				this.BorneByISGEC.checked + '|' +
				this.BorneBySupplier.checked + '|' +
				this.EmptyReturnRemarks.value + '|' +
				this.ODCReasonID.value
      , this.GRSaved, this.saveGRError);
		},
		GRSaved: function(r) {
			$find('mpegetgr').hide();
			javasceipt:__doPostBack(lc_getGR.activeEle.id, 'click');
			//hideProcessingMPV();
		},
		saveGRError: function(r) {
			$get('<%= F_ErrMsg.ClientID %>').innerHTML = r._message;
			hideProcessingMPV();
		},
		showPop: function() {
			var mPop = $find('mpegetgr');
			mPop.show();
		},
		hidePop: function() {
			var mPop = $find('mpegetgr');
			mPop.hide();
		}
	}
//	with (lc_getGR) {
//		Context.innerHTML = aVal[0];
//		SRNNo.innerHTML = aVal[0];
//		Description.innerHTML = aVal[1];
//		VehicleNo.value = aVal[2];
//		GRNO.value = aVal[3];
//		GRDate.value = aVal[4];
//		LoadedOn.value = aVal[6];
//		ReachedAtSupplierOn.value = aVal[7];
//		SizeUnit.value = aVal[8];
//		Height.value = aVal[9];
//		Width.value = aVal[10];
//		Length.value = aVal[11];
//		MaterialWeight.value = aVal[12];
//		WeightUnit.value = aVal[13];
//		NoOfPackages.value = aVal[14];
//		OverDimentionConsignement.value = aVal[15];
//		GRRemarks.value = aVal[16];
//		VehicleNotPlaced.value = aVal[17];
//		DelayedPlacement.value = aVal[18];
//		DebitToTransporter.value = aVal[19];
//		EmptyReturn.value = aVal[20];
//		DetentionAtSupplier.value = aVal[21];
//		PayableToTransporter.value = aVal[22];
//		BorneByISGEC.value = aVal[23];
//		BorneBySupplier.value = aVal[24];
//		EmptyReturnRemarks.value = aVal[25];
//		ODCReasonID.value = aVal[26];
//	}
//		this.Context.innerHTML = aVal[0];
//				this.SRNNo.innerHTML = aVal[0];
//				this.Description.innerHTML = aVal[1];
//				this.VehicleNo.value = aVal[2];
//				this.GRNO.value = aVal[3];
//				this.GRDate.value = aVal[4];
//				this.LoadedOn.value = aVal[6];
//				this.ReachedAtSupplierOn.value = aVal[7];
//				this.SizeUnit.value = aVal[8];
//				this.Height.value = aVal[9];
//				this.Width.value = aVal[10];
//				this.Length.value = aVal[11];
//				this.MaterialWeight.value = aVal[12];
//				this.WeightUnit.value = aVal[13];
//				this.NoOfPackages.value = aVal[14];
//				this.OverDimentionConsignement.value = aVal[15];
//				this.GRRemarks.value = aVal[16];
//				this.VehicleNotPlaced.value = aVal[17];
//				this.DelayedPlacement.value = aVal[18];
//				this.DebitToTransporter.value = aVal[19];
//				this.EmptyReturn.value = aVal[20];
//				this.DetentionAtSupplier.value = aVal[21];
//				this.PayableToTransporter.value = aVal[22];
//				this.BorneByISGEC.value = aVal[23];
//				this.BorneBySupplier.value = aVal[24];
//				this.EmptyReturnRemarks.value = aVal[25];
//				this.ODCReasonID.value = aVal[26];

</script>
<script type="text/javascript">
	var script_Enforce = {
		allow: function(o) {
			var p = $get(o);
			try {
				p.style.background = 'white';
				p.disabled = false;
			} catch (ex) { }
		},
		deny: function(o) {
			var p = $get(o);
			try {
				p.style.background = 'gray';
				p.disabled = true;
			} catch (ex) { }
			//try { p.checked = false; } catch (ex) { };
		},
		DefineBI: function() {
			if (lc_getGR.BorneByISGEC.checked)
				lc_getGR.BorneBySupplier.checked = false;
		},
		DefineBS: function() {
			if (lc_getGR.BorneBySupplier.checked)
				lc_getGR.BorneByISGEC.checked = false;
		},
		DefineDD: function() {
			if (lc_getGR.DetentionAtSupplier.checked || lc_getGR.DelayedPlacement.checked) {
				this.deny(lc_getGR.VehicleNotPlaced.id);
				this.deny(lc_getGR.EmptyReturn.id);
			} else {
				if (!lc_getGR.EmptyReturn.checked)
					this.allow(lc_getGR.VehicleNotPlaced.id);
				if (!lc_getGR.VehicleNotPlaced.checked)
					this.allow(lc_getGR.EmptyReturn.id);
			}
		},
		DefineBORNE: function() {
			if (lc_getGR.PayableToTransporter.checked) {
				this.allow(lc_getGR.BorneByISGEC.id);
				this.allow(lc_getGR.BorneBySupplier.id);
			} else {
				lc_getGR.BorneByISGEC.checked = false;
				lc_getGR.BorneBySupplier.checked = false;
				this.deny(lc_getGR.BorneByISGEC.id);
				this.deny(lc_getGR.BorneBySupplier.id);
			}
		},
		DefinePT: function() {
			if (lc_getGR.EmptyReturn.checked || lc_getGR.DetentionAtSupplier.checked) {
				this.allow(lc_getGR.PayableToTransporter.id);
				this.allow(lc_getGR.EmptyReturnRemarks.id);
			} else {
				lc_getGR.PayableToTransporter.checked = false;
				this.deny(lc_getGR.PayableToTransporter.id);
				this.deny(lc_getGR.EmptyReturnRemarks.id);
			}
			this.DefineDD();
			this.DefineBORNE();
		},
		DefineDT: function() {
			if (lc_getGR.VehicleNotPlaced.checked || lc_getGR.DelayedPlacement.checked) {
				this.allow(lc_getGR.DebitToTransporter.id);
			} else {
				lc_getGR.DebitToTransporter.checked = false;
				this.deny(lc_getGR.DebitToTransporter.id);
			}
			this.DefineDD();
		},
		DefineER: function(o) {
			var f = o.id.replace('EmptyReturn', '');
			if (o.checked) {
				lc_getGR.DelayedPlacement.checked = false;
				lc_getGR.VehicleNotPlaced.checked = false;
				lc_getGR.DetentionAtSupplier.checked = false;
				lc_getGR.OverDimentionConsignement.checked = false;
				this.deny(f + 'DelayedPlacement');
				this.deny(f + 'VehicleNotPlaced');
				this.deny(f + 'DetentionAtSupplier');
				this.deny(f + 'OverDimentionConsignement');
				this.deny(f + 'VehicleNo');
				this.deny(f + 'GRNO');
				this.deny(f + 'GRDate');
				this.deny(f + 'ReachedAtSupplierOn');
				this.deny(f + 'LoadedOn');
				this.DefineDT();
				this.DefinePT();
				this.DefineODC(lc_getGR.OverDimentionConsignement);
			}
			else {
				this.allow(f + 'DelayedPlacement');
				this.allow(f + 'VehicleNotPlaced');
				this.allow(f + 'DetentionAtSupplier');
				this.allow(f + 'OverDimentionConsignement');
				if (lc_getGR.Linked) {
					if (lc_getGR.IsMain)
						this.allow(f + 'VehicleNo');
					else
						this.deny(f + 'VehicleNo');
				} else {
					this.allow(f + 'VehicleNo');
				}
				this.allow(f + 'GRNO');
				this.allow(f + 'GRDate');
				this.allow(f + 'ReachedAtSupplierOn');
				this.allow(f + 'LoadedOn');
				this.DefineDT();
				this.DefinePT();
				this.DefineODC(lc_getGR.OverDimentionConsignement);
			}
		},
		DefineVNP: function(o) {
			var f = o.id.replace('VehicleNotPlaced', '');
			if (o.checked) {
				lc_getGR.DelayedPlacement.checked = false;
				lc_getGR.EmptyReturn.checked = false;
				lc_getGR.DetentionAtSupplier.checked = false;
				lc_getGR.OverDimentionConsignement.checked = false;
				this.deny(f + 'DelayedPlacement');
				this.deny(f + 'EmptyReturn');
				this.deny(f + 'DetentionAtSupplier');
				this.deny(f + 'OverDimentionConsignement');
				this.deny(f + 'VehicleNo');
				this.deny(f + 'GRNO');
				this.deny(f + 'GRDate');
				this.deny(f + 'ReachedAtSupplierOn');
				this.deny(f + 'LoadedOn');
				this.deny(f + 'EmptyReturnRemarks');
				this.DefineDT();
				this.DefinePT();
				this.DefineODC(lc_getGR.OverDimentionConsignement);
			}
			else {
				lc_getGR.DebitToTransporter.checked = false;
				this.allow(f + 'DelayedPlacement');
				this.allow(f + 'EmptyReturn');
				this.allow(f + 'DetentionAtSupplier');
				this.allow(f + 'OverDimentionConsignement');
				if (lc_getGR.Linked) {
					if (lc_getGR.IsMain)
						this.allow(f + 'VehicleNo');
					else
						this.deny(f + 'VehicleNo');
				} else {
					this.allow(f + 'VehicleNo');
				}
				this.allow(f + 'GRNO');
				this.allow(f + 'GRDate');
				this.allow(f + 'ReachedAtSupplierOn');
				this.allow(f + 'LoadedOn');
				this.deny(f + 'EmptyReturnRemarks');
				this.DefineDT();
				this.DefinePT();
				this.DefineODC(lc_getGR.OverDimentionConsignement);
			}
		},
		DefineODC: function(o) {
			var f = o.id.replace('OverDimentionConsignement', '');
			if (!o.checked) {
				this.deny(f + 'Height');
				this.deny(f + 'Width');
				this.deny(f + 'Length');
				this.deny(f + 'SizeUnit_DDLvrUnits');
				this.deny(f + 'WeightUnit_DDLvrUnits');
				this.deny(f + 'MaterialWeight');
				this.deny(f + 'NoOfPackages');
				this.deny(f + 'ODCReasonID_DDLvrODCReasons');
			}
			else {
				this.allow(f + 'Height');
				this.allow(f + 'Width');
				this.allow(f + 'Length');
				this.allow(f + 'SizeUnit_DDLvrUnits');
				this.allow(f + 'WeightUnit_DDLvrUnits');
				this.allow(f + 'MaterialWeight');
				this.allow(f + 'NoOfPackages');
				this.allow(f + 'ODCReasonID_DDLvrODCReasons');
			}
		}
	}
    </script>
    <asp:Label ID="dummy" runat="server" Text="dummy" style="display:none" ></asp:Label>
    <asp:Panel ID="pnlsrem" runat="server" Style="display:none; width: 800px" CssClass="modalPopup">
      <table style="width: 100%">
        <tr>
          <td style="background-color: Navy">
            <asp:Image ID="Image2" runat="server" AlternateText="Task" ToolTip="Task" ImageUrl="~/App_Themes/Default/Images/application.png" />
          </td>
          <td id="dragsrem" runat="server" style="background-color: Navy; cursor: move; text-align: left; width: 100%; font-weight: bold; color: White; height: 24px">
            Vehicle Request Execution: GR Details
          </td>
          <td style="background-color: Navy; text-align: right">
            <asp:ImageButton ID="closesrem" runat="server" Height="20px" Width="20px" AlternateText="Close" ToolTip="Close" ImageUrl="~/App_Themes/Default/Images/closeWindow.png" />
            <asp:Button runat="server" ID="cmdOK" BackColor="Lime" Text="" style="display:none"  />
          </td>
        </tr>
      </table>
		<asp:Label ID="F_Context" ForeColor="#CC6633" style="display:none" runat="server" Text="" />
		<table style="text-align:left; border: solid 1pt black" width="100%" >
		  <tr style="background-color:Black; text-align:right">
				<td class="alignleft" colspan="4">
      		<asp:Label ID="F_ErrMsg" ForeColor="#00FF00" Font-Bold="true" Font-Size="14px" style="display:block" runat="server" Text="." />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" ForeColor="#FFFF00" runat="server" Text="REQUEST EXECUTION NO :" /></b>
				</td>
				<td>
					<asp:Label ID="F_SRNNo" Enabled="False" CssClass="mypktxt" width="70px" runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Description" ForeColor="#FFFF00" runat="server" Text="DESCRIPTION :" /></b>
				</td>
        <td>
          <asp:Label ID="F_Description" runat="server" />
        </td>
      </tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_VehicleNotPlaced" ForeColor="Yellow" runat="server" Text="VEHICLE NOT PLACED :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_VehicleNotPlaced"
					  Checked='<%# Bind("VehicleNotPlaced") %>'
    				onclick="return script_Enforce.DefineVNP(this);"
            runat="server" />
				</td>
				<td class="alignright" rowspan="2">
					<b><asp:Label ID="L_DebitToTransporter" runat="server" Text="Debit To Transporter :" /></b>
				</td>
				<td rowspan="2">
          <asp:CheckBox ID="F_DebitToTransporter"
					  Checked='<%# Bind("DebitToTransporter") %>'
            runat="server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_DelayedPlacement" runat="server" Text="Delayed Placement :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DelayedPlacement"
					  Checked='<%# Bind("DelayedPlacement") %>'
    				onclick="return script_Enforce.DefineDT();"
            runat="server" />
				</td>
			</tr>
			
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturn" ForeColor="Yellow" runat="server" Text="EMPTY RETURN :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EmptyReturn"
					  Checked='<%# Bind("EmptyReturn") %>'
    				onclick="return script_Enforce.DefineER(this);"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_PayableToTransporter" runat="server" Text="Payable To Transporter :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_PayableToTransporter"
					  Checked='<%# Bind("PayableToTransporter") %>'
    				onclick="return script_Enforce.DefineBORNE();"
            runat="server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_DetentionAtSupplier" runat="server" Text="Detention At Supplier :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DetentionAtSupplier"
					  Checked='<%# Bind("DetentionAtSupplier") %>'
    				onclick="return script_Enforce.DefinePT();"
            runat="server" />
				</td>
				<td colspan="2">
					<table>
						<tr>
							<td class="alignright">
								<b><asp:Label ID="L_BorneByISGEC" runat="server" Text="Borne By ISGEC :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_BorneByISGEC"
									Checked='<%# Bind("BorneByISGEC") %>'
    				      onclick="return script_Enforce.DefineBI();"
									runat="server" />
							</td>
							<td class="alignright">
								<b><asp:Label ID="L_BorneBySupplier" runat="server" Text="Borne By Supplier :" /></b>
							</td>
							<td>
								<asp:CheckBox ID="F_BorneBySupplier"
									Checked='<%# Bind("BorneBySupplier") %>'
    				      onclick="return script_Enforce.DefineBS();"
									runat="server" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_EmptyReturnRemarks" runat="server" Text="Empty Return/Detention Remarks :" /></b>
				</td>
				<td colspan="3">
					<asp:TextBox ID="F_EmptyReturnRemarks"
						Text='<%# Bind("EmptyReturnRemarks") %>'
            Width="400px" 
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Empty Return Remarks."
						MaxLength="250"
						runat="server" />
				</td>
			</tr>
		  <tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="Label3" ForeColor="Black" runat="server" Text="Vehicle No :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehicleNo" CssClass="mytxt" width="100px" runat="server" Text="" />
				</td>
				<td></td>
				<td></td>
			</tr>
		  <tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="Label1" ForeColor="Black" runat="server" Text="GR NO :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GRNO" MaxLength="20" CssClass="mytxt" width="100px" runat="server" Text="" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="Label2" ForeColor="Black" runat="server" Text="GR DATE :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GRDate" Text='<%# Bind("GRDate") %>' Width="70px" CssClass="mytxt" onfocus="return this.select();" runat="server" />
					<asp:Image ID="ImageButtonGRDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
					<AJX:CalendarExtender ID="CEGRDate" TargetControlID="F_GRDate" Format="dd/MM/yyyy" runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonGRDate" OnClientShown="ShownCalendar" />
					<AJX:MaskedEditExtender ID="MEEGRDate" runat="server" Mask="99/99/9999" MaskType="Date" CultureName="en-GB" MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true" TargetControlID="F_GRDate" />
				</td>
		  </tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_ReachedAtSupplierOn" runat="server" Text="Reached To Supplier On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReachedAtSupplierOn"
						Text='<%# Bind("ReachedAtSupplierOn") %>'
            Width="110px"
						CssClass = "mytxt"
						ValidationGroup="vrLinkGR"
						onfocus = "return this.select();"
						runat="server" />
					<asp:Image ID="ImageButtonReachedAtSupplierOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEReachedAtSupplierOn"
            TargetControlID="F_ReachedAtSupplierOn"
            Format="dd/MM/yyyy HH:mm"
            OnClientShown="ShownCalendar"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonReachedAtSupplierOn" />
					<AJX:MaskedEditExtender 
						ID = "MEEReachedAtSupplierOn"
						runat = "server"
						mask = "99/99/9999 99:99"
						MaskType="DateTime"
            CultureName = "en-GB"
						MessageValidatorTip="true"
						InputDirection="LeftToRight"
						ErrorTooltipEnabled="true"
						TargetControlID="F_ReachedAtSupplierOn" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_LoadedOn" ForeColor="Black" runat="server" Text="Left From Supplier On :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LoadedOn" Text='<%# Bind("LoadedOn") %>' Width="110px" CssClass="mytxt" onfocus="return this.select();" runat="server" />
					<asp:Image ID="ImageButtonLoadedOn" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
					<AJX:CalendarExtender ID="CELoadedOn" TargetControlID="F_LoadedOn" Format="dd/MM/yyyy HH:mm" runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonLoadedOn" OnClientShown="ShownCalendar" />
					<AJX:MaskedEditExtender ID="MEELoadedOn" runat="server" mask = "99/99/9999 99:99" MaskType="DateTime" CultureName="en-GB" MessageValidatorTip="true" InputDirection="LeftToRight" ErrorTooltipEnabled="true" TargetControlID="F_LoadedOn" />
				</td>
			</tr>
			<tr>
			<td colspan="4" style="text-align:center; background-color:#FF3300" align="center">
			<b><asp:Label ID="Label4" ForeColor="Yellow" runat="server" Text="-----ODC WHILE LOADED AT SUPPLIER-----" /></b>
			</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_OverDimentionConsignement" runat="server" Text="ODC :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_OverDimentionConsignement"
					 Checked='<%# Bind("OverDimentionConsignement") %>'
    				onclick="return script_Enforce.DefineODC(this);"
           runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_ODCReasonID" runat="server" Text="ODC Reason :" /></b>
				</td>
				<td>
          <LGM:LC_vrODCReasons
            ID="F_ODCReasonID"
            SelectedValue='<%# Bind("ODCReasonID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="350px"
            CssClass="myddl"
            Runat="Server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_SizeUnit" runat="server" Text="Size Unit :" /></b>
				</td>
        <td>
          <LGM:LC_vrUnits
            ID="F_SizeUnit"
            SelectedValue='<%# Bind("SizeUnit") %>'
            OrderBy="Size"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="80px"
            CssClass="myddl"
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_Length" runat="server" Text="Length :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Length"
						Text='<%# Bind("Length") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
					  MaxLength="8"
						onfocus = "return this.select();"
            onblur ="return dc(this,2);"
						runat="server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_Width" runat="server" Text="Width :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Width"
						Text='<%# Bind("Width") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrLinkGR"
						MaxLength="8"
						onfocus = "return this.select();"
            onblur ="return dc(this,2);"
						runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_Height" runat="server" Text="Height :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Height"
						Text='<%# Bind("Height") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrLinkGR"
						MaxLength="8"
						onfocus = "return this.select();"
            onblur ="return dc(this,2);"
						runat="server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_WeightUnit" runat="server" Text="Weight Unit :" /></b>
				</td>
        <td>
          <LGM:LC_vrUnits
            ID="F_WeightUnit"
            SelectedValue='<%# Bind("WeightUnit") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="80px"
            CssClass="myddl"
            Runat="Server" />
          </td>
				<td class="alignright">
					<b><asp:Label ID="L_MaterialWeight" runat="server" Text="Material Weight :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaterialWeight"
						Text='<%# Bind("MaterialWeight") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						ValidationGroup="vrLinkGR"
						MaxLength="20"
						onfocus = "return this.select();"
            onblur ="return dc(this,2);"
					  BackColor="Gray"
					  Enabled="false"
						runat="server" />
				</td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_NoOfPackages" runat="server" Text="No Of Packages :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_NoOfPackages"
						Text='<%# Bind("NoOfPackages") %>'
            Width="70px"
						style="text-align: right"
						CssClass = "mytxt"
						ValidationGroup="vrLinkGR"
						MaxLength="10"
						onfocus = "return this.select();"
            onblur ="return dc(this,0);"
					  BackColor="Gray"
					  Enabled="false"
						runat="server" />
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr style="background-color:silver">
				<td class="alignright">
					<b><asp:Label ID="L_GRRemarks" runat="server" Text="GR Remarks :" /></b>
				</td>
				<td colspan="3">
					<asp:TextBox ID="F_GRRemarks"
						Text='<%# Bind("GRRemarks") %>'
						CssClass = "mytxt"
						onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for GR Remarks."
						MaxLength="500"
            Width="450px" Height="40px" TextMode="MultiLine"
						runat="server" />
				</td>
			</tr>
		</table>
    <table width="100%">
      <tr style="background-color:silver">
        <td style="text-align:center">
          <input type="button" value="Cancel" onclick="lc_getGR.hidePop();" style="background-color:silver; color: Red" />
        </td>
        <td style="text-align:center">
          <input type="button" value=" Save " onclick="lc_getGR.saveGR();" style="background: green;color: Lime" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:ModalPopupExtender BehaviorID="mpegetgr" PopupControlID="pnlsrem" OkControlID="cmdOK" CancelControlID="closesrem" PopupDragHandleControlID="dragsrem" ID="ModalPopupExtender2" runat="server" TargetControlID="dummy" BackgroundCssClass="modalBackground" DropShadow="true" />

