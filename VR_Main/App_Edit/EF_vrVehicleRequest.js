<script type="text/javascript"> 
var script_vrVehicleRequest = {
		ACESupplierID_Selected: function(sender, e) {
		  var Prefix = sender._element.id.replace('SupplierID','');
		  var F_SupplierID = $get(sender._element.id);
		  var F_SupplierID_Display = $get(sender._element.id + '_Display');
		  var retval = e.get_value();
		  var p = retval.split('|');
		  F_SupplierID.value = p[0];
		  F_SupplierID_Display.innerHTML = e.get_text();
		},
		ACESupplierID_Populating: function(sender,e) {
		  var p = sender.get_element();
		  var Prefix = sender._element.id.replace('SupplierID','');
		  p.style.backgroundImage  = 'url(../../images/loader.gif)';
		  p.style.backgroundRepeat= 'no-repeat';
		  p.style.backgroundPosition = 'right';
		  sender._contextKey = '';
		},
		ACESupplierID_Populated: function(sender,e) {
		  var p = sender.get_element();
		  p.style.backgroundImage  = 'none';
		},
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
		validate_SupplierID: function(sender) {
		  var Prefix = sender.id.replace('SupplierID','');
		  this.validated_FK_VR_VehicleRequest_SupplierID_main = true;
		  this.validate_FK_VR_VehicleRequest_SupplierID(sender,Prefix);
		  },
		validate_ProjectID: function(sender) {
		  var Prefix = sender.id.replace('ProjectID','');
		  this.validated_FK_VR_VehicleRequest_ProjectID_main = true;
		  this.validate_FK_VR_VehicleRequest_ProjectID(sender,Prefix);
		  },
		validate_FK_VR_VehicleRequest_ProjectID: function(o,Prefix) {
		  var value = o.id;
		  var ProjectID = $get(Prefix + 'ProjectID');
		  if(ProjectID.value==''){
		    if(this.validated_FK_VR_VehicleRequest_ProjectID_main){
		      var o_d = $get(Prefix + 'ProjectID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		      var o_a = $get(Prefix +'F_DeliveryLocation');
		      try{o_a.value = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + ProjectID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_VR_VehicleRequest_ProjectID(value, this.validated_FK_VR_VehicleRequest_ProjectID);
		  },
		validated_FK_VR_VehicleRequest_ProjectID_main: false,
		validated_FK_VR_VehicleRequest_ProjectID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_vrVehicleRequest.validated_FK_VR_VehicleRequest_ProjectID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		    var o_a = $get(p[1].replace('F_ProjectID','F_DeliveryLocation'));
		    try{o_a.value = p[3];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_FK_VR_VehicleRequest_SupplierID: function(o,Prefix) {
		  var value = o.id;
		  var SupplierID = $get(Prefix + 'SupplierID');
		  if(SupplierID.value==''){
		    if(this.validated_FK_VR_VehicleRequest_SupplierID_main){
		      var o_d = $get(Prefix + 'SupplierID' + '_Display');
		      try{o_d.innerHTML = '';}catch(ex){}
		      var o_a = $get(Prefix +'F_SupplierLocation');
		      try{o_a.value = '';}catch(ex){}
		    }
		    return true;
		  }
		  value = value + ',' + SupplierID.value ;
		    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';
		    o.style.backgroundRepeat= 'no-repeat';
		    o.style.backgroundPosition = 'right';
		    PageMethods.validate_FK_VR_VehicleRequest_SupplierID(value, this.validated_FK_VR_VehicleRequest_SupplierID);
		  },
		validated_FK_VR_VehicleRequest_SupplierID_main: false,
		validated_FK_VR_VehicleRequest_SupplierID: function(result) {
		  var p = result.split('|');
		  var o = $get(p[1]);
		  if(script_vrVehicleRequest.validated_FK_VR_VehicleRequest_SupplierID_main){
		    var o_d = $get(p[1]+'_Display');
		    try{o_d.innerHTML = p[2];}catch(ex){}
		    var o_a = $get(p[1].replace('F_SupplierID','F_SupplierLocation'));
		    try{o_a.value = p[3];}catch(ex){}
		  }
		  o.style.backgroundImage  = 'none';
		  if(p[0]=='1'){
		    o.value='';
		    o.focus();
		  }
		},
		validate_ERPPONumber: function(o) {                                                                     
			var value = o.id;                                                                                         
			try{$get('ctl00_cph1_FVvrVehicleRequest_L_ErrMsgvrVehicleRequest').innerHTML = '';}catch(ex){}   
			if(o=='')                                                                                
				return true;                                                                                            
			value = value + ',' + o.value ;                                                                
			o.style.backgroundImage  = 'url(../../images/pkloader.gif)';                                              
			o.style.backgroundRepeat= 'no-repeat';                                                                    
			o.style.backgroundPosition = 'right';                                                                     
			PageMethods.validate_ERPPONumber(value, this.validated_ERPPONumber);                              
		},                                                                                                          
		validated_ERPPONumber: function(result) {                                                               
			var p = result.split('|');                                                                                
			var o = $get(p[1]);                                                                                       
			o.style.backgroundImage  = 'none';                                                                        
			if(p[0]=='1'){                                                                                            
				try{$get('ctl00_cph1_FVvrVehicleRequest_L_ErrMsgvrVehicleRequest').innerHTML = p[2];}catch(ex){}
				o.value='';                                                                                             
				o.focus();                                                                                              
			}
			else{
				var y = $get(o.id.replace('F_ERPPONumber','F_BuyerInERP'));
				var z = $get(o.id.replace('F_ERPPONumber','F_BuyerInERP_Display'));
				y.value=p[2];
				z.innerHTML=p[3];
			}                                                                                                         
		},        
		temp: function() {
		}
		}
</script>
