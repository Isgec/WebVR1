<script type="text/javascript"> 
var script_vrTransporterBill = {
		validate_IRNo: function(sender) {
		  var Prefix = sender.id.replace('IRNo','');
		  this.validatePK_vrTransporterBill(sender,Prefix);
		  },
		validatePK_vrTransporterBill: function(o,Prefix) {
		  var value = o.id;
		  try{$get(Prefix.replace('_F_','') + '_L_ErrMsgvrTransporterBill').innerHTML = '';}catch(ex){}
		  var IRNo = $get(Prefix + 'IRNo');
		  if(IRNo.value=='')
		    return true;
		  value = value + ',' + IRNo.value ;
		  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  o.style.backgroundRepeat= 'no-repeat';
		  o.style.backgroundPosition = 'right';
	    try{$get('divIR').innerHTML = '';}catch(ex){}
		  PageMethods.validatePK_vrTransporterBill(value, this.validatedPK_vrTransporterBill);
		},
		validatedPK_vrTransporterBill: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    try{$get('ctl00_cph1_FVvrTransporterBill_L_ErrMsgvrTransporterBill').innerHTML = p[2];}catch(ex){}
		    o.value='';
		    o.focus();
		  }else{
		    try{$get('divIR').innerHTML = p[2];}catch(ex){}
		  }
		},
		temp: function() {
		}
		}
</script>
