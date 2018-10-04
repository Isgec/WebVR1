<script type="text/javascript"> 
var script_vrLorryReceiptsD = {
    ACEProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('ProjectID','');
      var F_ProjectID = $get(sender._element.id);
      var F_ProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_ProjectID.value = p[0];
      F_ProjectID_Display.innerHTML = e.get_text();
    },
    ACEProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('ProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    ACERequestExecutionNo_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('RequestExecutionNo','');
      var F_RequestExecutionNo = $get(sender._element.id);
      var F_RequestExecutionNo_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_RequestExecutionNo.value = p[0];
      F_RequestExecutionNo_Display.innerHTML = e.get_text();
    },
    ACERequestExecutionNo_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('RequestExecutionNo','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACERequestExecutionNo_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_RequestExecutionNo: function(sender) {
      var Prefix = sender.id.replace('RequestExecutionNo','');
      this.validated_FK_VR_LorryReceipts_ExecutionNo_main = true;
      this.validate_FK_VR_LorryReceipts_ExecutionNo(sender,Prefix);
      },
    validate_FK_VR_LorryReceipts_ExecutionNo: function(o,Prefix) {
      var value = o.id;
      var RequestExecutionNo = $get(Prefix + 'RequestExecutionNo');
      if(RequestExecutionNo.value==''){
        if(this.validated_FK_VR_LorryReceipts_ExecutionNo_main){
          var o_d = $get(Prefix + 'RequestExecutionNo' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + RequestExecutionNo.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_VR_LorryReceipts_ExecutionNo(value, this.validated_FK_VR_LorryReceipts_ExecutionNo);
      },
    validated_FK_VR_LorryReceipts_ExecutionNo_main: false,
    validated_FK_VR_LorryReceipts_ExecutionNo: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_vrLorryReceiptsD.validated_FK_VR_LorryReceipts_ExecutionNo_main){
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
