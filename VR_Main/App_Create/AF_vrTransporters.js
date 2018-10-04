<script type="text/javascript"> 
var script_vrTransporters = {
		validate_TransporterID: function(sender) {
		  var Prefix = sender.id.replace('TransporterID','');
		  this.validatePK_vrTransporters(sender,Prefix);
		  },
		validatePK_vrTransporters: function(o,Prefix) {
		  var value = o.id;
		  try{$get(Prefix.replace('_F_','') + '_L_ErrMsgvrTransporters').innerHTML = '';}catch(ex){}
		  var TransporterID = $get(Prefix + 'TransporterID');
		  if(TransporterID.value=='')
		    return true;
		  value = value + ',' + TransporterID.value ;
		  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		  o.style.backgroundRepeat= 'no-repeat';
		  o.style.backgroundPosition = 'right';
		  PageMethods.validatePK_vrTransporters(value, this.validatedPK_vrTransporters);
		},
		validatedPK_vrTransporters: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    try{$get('ctl00_cph1_FVvrTransporters_L_ErrMsgvrTransporters').innerHTML = p[2];}catch(ex){}
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
