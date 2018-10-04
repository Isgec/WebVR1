<script type="text/javascript"> 
var script_vrBusinessPartner = {
    validate_BPID: function(sender) {
      var Prefix = sender.id.replace('BPID','');
      this.validatePK_vrBusinessPartner(sender,Prefix);
      },
    validatePK_vrBusinessPartner: function(o,Prefix) {
      var value = o.id;
      try{$get(Prefix.replace('_F_','') + '_L_ErrMsgvrBusinessPartner').innerHTML = '';}catch(ex){}
      var BPID = $get(Prefix + 'BPID');
      if(BPID.value=='')
        return true;
      value = value + ',' + BPID.value ;
      o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
      o.style.backgroundRepeat= 'no-repeat';
      o.style.backgroundPosition = 'right';
      PageMethods.validatePK_vrBusinessPartner(value, this.validatedPK_vrBusinessPartner);
    },
    validatedPK_vrBusinessPartner: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        try{$get('cph1_FVvrBusinessPartner_L_ErrMsgvrBusinessPartner').innerHTML = p[2];}catch(ex){}
        o.value='';
        o.focus();
      }
    },
    temp: function() {
    }
    }
</script>
