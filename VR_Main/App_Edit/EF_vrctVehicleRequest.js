<script type="text/javascript"> 
var script_vrctVehicleRequest = {
    ACEVRRequestNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('VRRequestNo','');
      var F_VRRequestNo = $get(sender._element.id);
      var F_VRRequestNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_VRRequestNo.value = p[0];
      F_VRRequestNo_Display.innerHTML = e.get_text();
    },
    ACEVRRequestNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('VRRequestNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEVRRequestNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    temp: function() {
    }
    }
</script>
