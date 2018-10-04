<script type="text/javascript"> 
var script_vrRequestExecution = {
		Validate_Distance: function(sender) {
		  var Prefix = sender.id.replace('EstimatedDistance','');
		  var F_EstimatedDistance = $get(sender.id);
		  var F_EstimatedRatePerKM = $get(Prefix+'EstimatedRatePerKM');
		  var F_EstimatedAmount = $get(Prefix+'EstimatedAmount');
		  var tmp=F_EstimatedDistance.value.replace(new RegExp('_', 'g'), '');
		  if(parseFloat(tmp)>0){	
		    F_EstimatedAmount.style.backgroung='gray';
		    F_EstimatedAmount.disabled=true;
		    try{F_EstimatedAmount.value=parseFloat(tmp)*parseFloat(F_EstimatedRatePerKM.value);}catch(e){F_EstimatedAmount.value='0.00';}
		  }else {
				if(parseFloat(F_EstimatedRatePerKM.value)<=0){
		    F_EstimatedAmount.style.backgroung='white';
		    F_EstimatedAmount.disabled=false;
				}
		  }
		},
		Validate_RatePerKM: function(sender) {
		  var Prefix = sender.id.replace('EstimatedRatePerKM','');
		  var F_EstimatedRatePerKM = $get(sender.id);
		  var F_EstimatedDistance = $get(Prefix+'EstimatedDistance');
		  var F_EstimatedAmount = $get(Prefix+'EstimatedAmount');
		  var tmp=F_EstimatedRatePerKM.value.replace(new RegExp('_', 'g'), '');
		  if(parseFloat(tmp)>0){
		    F_EstimatedAmount.style.backgroung='gray';
		    F_EstimatedAmount.disabled=true;
		    try{F_EstimatedAmount.value=parseFloat(tmp)*parseFloat(F_EstimatedDistance.value);}catch(e){F_EstimatedAmount.value='0.00';}
		  } else {
				if(parseFloat(F_EstimatedDistance.value)<=0){
		    F_EstimatedAmount.style.backgroung='white';
		    F_EstimatedAmount.disabled=false;
				}
		  }
		},
		ACETransporterID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('TransporterID','');
		  var F_TransporterID = $get(sender._element.id);
		  var F_TransporterID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_TransporterID.value = p[0];
		  F_TransporterID_Display.innerHTML = e.get_text();
		},
		ACETransporterID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('TransporterID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACETransporterID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_TransporterID: function(sender) {
		  var Prefix = sender.id.replace('TransporterID','');
		  this.validated_FK_VR_RequestExecution_TransporterID_main = true;
		  this.validate_FK_VR_RequestExecution_TransporterID(sender,Prefix);
		  },
		validate_FK_VR_RequestExecution_TransporterID: function(o,Prefix) {
		  var value = o.id;
		  var TransporterID = $get(Prefix + 'TransporterID');
		  if(TransporterID.value==''){
		    if(this.validated_FK_VR_RequestExecution_TransporterID_main){
		      var o_d = $get(Prefix + 'TransporterID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + TransporterID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_VR_RequestExecution_TransporterID(value, this.validated_FK_VR_RequestExecution_TransporterID);
		  },
		validated_FK_VR_RequestExecution_TransporterID_main: false,
		validated_FK_VR_RequestExecution_TransporterID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_vrRequestExecution.validated_FK_VR_RequestExecution_TransporterID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		temp: function() {
		}
		}
</script>
