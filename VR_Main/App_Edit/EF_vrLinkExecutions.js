<script type="text/javascript"> 
var script_vrLinkExecutions = {
		ACESRNNo_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('SRNNo','');
		  var F_SRNNo = $get(sender._element.id);
		  var F_SRNNo_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_SRNNo.value = p[0];
		  F_SRNNo_Display.innerHTML = e.get_text();
		},
		ACESRNNo_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('SRNNo','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACESRNNo_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		ACELinkedBy_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('LinkedBy','');
		  var F_LinkedBy = $get(sender._element.id);
		  var F_LinkedBy_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_LinkedBy_Display.innerHTML = e.get_text();
		},
		ACELinkedBy_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('LinkedBy','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACELinkedBy_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		validate_LinkedBy: function(sender) {
		  var Prefix = sender.id.replace('LinkedBy','');
		  this.validated_FK_VR_LinkExecutions_LinkedBy_main = true;
		  this.validate_FK_VR_LinkExecutions_LinkedBy(sender,Prefix);
		  },
		validate_FK_VR_LinkExecutions_LinkedBy: function(o,Prefix) {
		  var value = o.id;
		  var LinkedBy = $get(Prefix + 'LinkedBy');
		  if(LinkedBy.value==''){
		    if(this.validated_FK_VR_LinkExecutions_LinkedBy_main){
		      var o_d = $get(Prefix + 'LinkedBy' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + LinkedBy.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_VR_LinkExecutions_LinkedBy(value, this.validated_FK_VR_LinkExecutions_LinkedBy);
		  },
		validated_FK_VR_LinkExecutions_LinkedBy_main: false,
		validated_FK_VR_LinkExecutions_LinkedBy: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_vrLinkExecutions.validated_FK_VR_LinkExecutions_LinkedBy_main){
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
