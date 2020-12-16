<script type="text/javascript"> 
var script_vrFreightBudgetProject = {
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
    ACEFreightBudgetProjectID_Selected: function(sender, e) {
      var Prefix = sender._element.id.replace('FreightBudgetProjectID','');
      var F_FreightBudgetProjectID = $get(sender._element.id);
      var F_FreightBudgetProjectID_Display = $get(sender._element.id + '_Display');
      var retval = e.get_value();
      var p = retval.split('|');
      F_FreightBudgetProjectID.value = p[0];
      F_FreightBudgetProjectID_Display.innerHTML = e.get_text();
    },
    ACEFreightBudgetProjectID_Populating: function(sender,e) {
      var p = sender.get_element();
      var Prefix = sender._element.id.replace('FreightBudgetProjectID','');
      p.style.backgroundImage  = 'url(../../images/loader.gif)';
      p.style.backgroundRepeat= 'no-repeat';
      p.style.backgroundPosition = 'right';
      sender._contextKey = '';
    },
    ACEFreightBudgetProjectID_Populated: function(sender,e) {
      var p = sender.get_element();
      p.style.backgroundImage  = 'none';
    },
    validate_ProjectID: function(sender) {
      var Prefix = sender.id.replace('ProjectID','');
      this.validated_FK_VR_FreightBudgetProject_ProjectID_main = true;
      this.validate_FK_VR_FreightBudgetProject_ProjectID(sender,Prefix);
      },
    validate_FreightBudgetProjectID: function(sender) {
      var Prefix = sender.id.replace('FreightBudgetProjectID','');
      this.validated_FK_VR_FreightBudgetProject_FrBdProjectID_main = true;
      this.validate_FK_VR_FreightBudgetProject_FrBdProjectID(sender,Prefix);
      },
    validate_FK_VR_FreightBudgetProject_ProjectID: function(o,Prefix) {
      var value = o.id;
      var ProjectID = $get(Prefix + 'ProjectID');
      if(ProjectID.value==''){
        if(this.validated_FK_VR_FreightBudgetProject_ProjectID_main){
          var o_d = $get(Prefix + 'ProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + ProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_VR_FreightBudgetProject_ProjectID(value, this.validated_FK_VR_FreightBudgetProject_ProjectID);
      },
    validated_FK_VR_FreightBudgetProject_ProjectID_main: false,
    validated_FK_VR_FreightBudgetProject_ProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_vrFreightBudgetProject.validated_FK_VR_FreightBudgetProject_ProjectID_main){
        var o_d = $get(p[1]+'_Display');
        try{o_d.innerHTML = p[2];}catch(ex){}
      }
      o.style.backgroundImage  = 'none';
      if(p[0]=='1'){
        o.value='';
        o.focus();
      }
    },
    validate_FK_VR_FreightBudgetProject_FrBdProjectID: function(o,Prefix) {
      var value = o.id;
      var FreightBudgetProjectID = $get(Prefix + 'FreightBudgetProjectID');
      if(FreightBudgetProjectID.value==''){
        if(this.validated_FK_VR_FreightBudgetProject_FrBdProjectID_main){
          var o_d = $get(Prefix + 'FreightBudgetProjectID' + '_Display');
          try{o_d.innerHTML = '';}catch(ex){}
        }
        return true;
      }
      value = value + ',' + FreightBudgetProjectID.value ;
        o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat= 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_VR_FreightBudgetProject_FrBdProjectID(value, this.validated_FK_VR_FreightBudgetProject_FrBdProjectID);
      },
    validated_FK_VR_FreightBudgetProject_FrBdProjectID_main: false,
    validated_FK_VR_FreightBudgetProject_FrBdProjectID: function(result) {
      var p = result.split('|');
      var o = $get(p[1]);
      if(script_vrFreightBudgetProject.validated_FK_VR_FreightBudgetProject_FrBdProjectID_main){
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
