<script type="text/javascript"> 
var script_vrRequestAttachments = {
		ACERequestNo_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('RequestNo','');
		  var F_RequestNo = $get(sender._element.id);
		  var F_RequestNo_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_RequestNo.value = p[0];
		  F_RequestNo_Display.innerHTML = e.get_text();
		},
		ACERequestNo_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('RequestNo','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACERequestNo_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
		temp: function() {
		}
		}
</script>
