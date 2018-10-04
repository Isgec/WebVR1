<script type="text/javascript"> 
var script_vrLorryReceipts = {
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
    ACECustomerID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('CustomerID','');
      var F_CustomerID = $get(sender._element.id);
      var F_CustomerID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_CustomerID.value = p[0];
      F_CustomerID_Display.innerHTML = e.get_text();
    },
    ACECustomerID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('CustomerID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACECustomerID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_RequestExecutionNo: function(sender) {
      var Prefix = sender.id.replace('RequestExecutionNo','');
      this.validated_FK_VR_LorryReceipts_ExecutionNo_main = true;
      this.validate_FK_VR_LorryReceipts_ExecutionNo(sender,Prefix);
      },
    validate_TransporterID: function(sender) {
      var Prefix = sender.id.replace('TransporterID','');
      this.validated_FK_VR_LorryReceipts_TransporterID_main = true;
      this.validate_FK_VR_LorryReceipts_TransporterID(sender,Prefix);
      },
    validate_CustomerID: function(sender) {
      var Prefix = sender.id.replace('CustomerID','');
      this.validated_FK_VR_LorryReceipts_CustomerID_main = true;
      this.validate_FK_VR_LorryReceipts_CustomerID(sender,Prefix);
      },
    validate_FK_VR_LorryReceipts_CustomerID: function(o,Prefix) {
      var value = o.id;
      var CustomerID = $get(Prefix + 'CustomerID');
      if(CustomerID.value==''){
        if(this.validated_FK_VR_LorryReceipts_CustomerID_main){
          var o_d = $get(Prefix + 'CustomerID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + CustomerID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_VR_LorryReceipts_CustomerID(value, this.validated_FK_VR_LorryReceipts_CustomerID);
      },
    validated_FK_VR_LorryReceipts_CustomerID_main: false,
    validated_FK_VR_LorryReceipts_CustomerID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_vrLorryReceipts.validated_FK_VR_LorryReceipts_CustomerID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
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
      if(script_vrLorryReceipts.validated_FK_VR_LorryReceipts_ExecutionNo_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_VR_LorryReceipts_TransporterID: function(o,Prefix) {
      var value = o.id;
      var TransporterID = $get(Prefix + 'TransporterID');
      if(TransporterID.value==''){
        if(this.validated_FK_VR_LorryReceipts_TransporterID_main){
          var o_d = $get(Prefix + 'TransporterID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + TransporterID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_VR_LorryReceipts_TransporterID(value, this.validated_FK_VR_LorryReceipts_TransporterID);
      },
    validated_FK_VR_LorryReceipts_TransporterID_main: false,
    validated_FK_VR_LorryReceipts_TransporterID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_vrLorryReceipts.validated_FK_VR_LorryReceipts_TransporterID_main){
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
