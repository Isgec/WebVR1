<script type="text/javascript"> 
var script_vrExecutionAttachments = {
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
		temp: function() {
		}
		}
</script>
