<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrVehicleTypes.aspx.vb" Inherits="EF_vrVehicleTypes" title="Edit: Vehicle Types" %>
<asp:Content ID="CPHvrVehicleTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrVehicleTypes" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrVehicleTypes" runat="server" Text="&nbsp;Edit: Vehicle Types" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrVehicleTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrVehicleTypes.aspx?pk="
    ValidationGroup = "vrVehicleTypes"
    Skin = "tbl_blue"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
      var script_Enforce = {
        allow: function(o) {
        var p = $get(o);
        p.style.background = 'white';
        p.disabled = false;
      },
        deny: function(o) {
          var p = $get(o);
          p.style.background = 'gray';
          p.disabled = true;
          try { p.checked = false; } catch (ex) { };
        },
        DefineCapacity: function(o) {
          var f = o.id.replace('DefineCapacity', '');
          if (!o.checked) {
            this.deny(f + 'CapacityInKG')
            this.deny(f + 'EnforceMinimumCapacity');
            this.deny(f + 'MinimumCapacity');
            this.deny(f + 'EnforceMaximumCapacity');
            this.deny(f + 'MaximumCapacity');
          }
          else {
            this.allow(f + 'CapacityInKG')
            this.allow(f + 'EnforceMinimumCapacity');
            this.allow(f + 'EnforceMaximumCapacity');
          }
        },
        EnforceMinimumCapacity: function(o) {
          var f = o.id.replace('EnforceMinimumCapacity', '');
          if (!o.checked) {
            this.deny(f + 'MinimumCapacity');
          }
          else {
            this.allow(f + 'MinimumCapacity');
          }
        },
        EnforceMaximumCapacity: function(o) {
        var f = o.id.replace('EnforceMaximumCapacity', '');
          if (!o.checked) {
            this.deny(f + 'MaximumCapacity');
          }
          else {
            this.allow(f + 'MaximumCapacity');
          }
        },
        DefineDimention: function(o) {
          var f = o.id.replace('DefineDimention', '');
          if (!o.checked) {
            this.deny(f + 'HeightInFt')
            this.deny(f + 'WidthInFt')
            this.deny(f + 'LengthInFt')
            this.deny(f + 'EnforceMinimumDimention');
            this.deny(f + 'MinimumHeight')
            this.deny(f + 'MinimumWidth')
            this.deny(f + 'MinimumLength')
            this.deny(f + 'EnforceMaximumDimention');
            this.deny(f + 'MaximumHeight')
            this.deny(f + 'MaximumWidth')
            this.deny(f + 'MaximumLength')
          }
          else {
            this.allow(f + 'HeightInFt')
            this.allow(f + 'WidthInFt')
            this.allow(f + 'LengthInFt')
            this.allow(f + 'EnforceMinimumDimention');
            this.allow(f + 'EnforceMaximumDimention');
          }
        },
        EnforceMinimumDimention: function(o) {
          var f = o.id.replace('EnforceMinimumDimention', '');
          if (!o.checked) {
            this.deny(f + 'MinimumHeight')
            this.deny(f + 'MinimumWidth')
            this.deny(f + 'MinimumLength')
          }
          else {
            this.allow(f + 'MinimumHeight')
            this.allow(f + 'MinimumWidth')
            this.allow(f + 'MinimumLength')
          }
        },
        EnforceMaximumDimention: function(o) {
          var f = o.id.replace('EnforceMaximumDimention', '');
          if (!o.checked) {
            this.deny(f + 'MaximumHeight')
            this.deny(f + 'MaximumWidth')
            this.deny(f + 'MaximumLength')
          }
          else {
            this.allow(f + 'MaximumHeight')
            this.allow(f + 'MaximumWidth')
            this.allow(f + 'MaximumLength')
          }
        }
        
      }
    </script>
<asp:FormView ID="FVvrVehicleTypes"
	runat = "server"
	DataKeyNames = "VehicleTypeID"
	DataSourceID = "ODSvrVehicleTypes"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_VehicleTypeID" runat="server" ForeColor="#CC6633" Text="Vehicle Type ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_VehicleTypeID"
						Text='<%# Bind("VehicleTypeID") %>'
            ToolTip="Value of Vehicle Type ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrVehicleTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DailyRunning" runat="server" Text="Daily Avg. Running :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_DailyRunning"
						Text='<%# Bind("DailyRunning") %>'
            Width="70px"
						CssClass = "mytxt"
						style="text-align: right"
						MaxLength="5"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEDailyRunning"
						runat = "server"
						mask = "99999"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_DailyRunning" />
					<AJX:MaskedEditValidator 
						ID = "MEVDailyRunning"
						runat = "server"
						ControlToValidate = "F_DailyRunning"
						ControlExtender = "MEEDailyRunning"
						InvalidValueMessage = "Invalid value for Daily Avg. Running."
						EmptyValueMessage = "Daily Avg. Running is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Daily Avg. Running."
						EnableClientScript = "true"
						IsValidEmpty = "True"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DefineCapacity" runat="server" Text="Define Capacity :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DefineCapacity"
					  Checked='<%# Bind("DefineCapacity") %>'
					  onclick="return script_Enforce.DefineCapacity(this);"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_CapacityInKG" runat="server" Text="Capacity In KG :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_CapacityInKG"
						Text='<%# Bind("CapacityInKG") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEECapacityInKG"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_CapacityInKG" />
					<AJX:MaskedEditValidator 
						ID = "MEVCapacityInKG"
						runat = "server"
						ControlToValidate = "F_CapacityInKG"
						ControlExtender = "MEECapacityInKG"
						InvalidValueMessage = "Invalid value for Capacity In KG."
						EmptyValueMessage = "Capacity In KG is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Capacity In KG."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Capacity In KG should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EnforceMinimumCapacity" runat="server" Text="Enforce Minimum Capacity :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EnforceMinimumCapacity"
					  Checked='<%# Bind("EnforceMinimumCapacity") %>'
					  onclick="return script_Enforce.EnforceMinimumCapacity(this);"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumCapacity" runat="server" Text="Minimum Capacity :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumCapacity"
						Text='<%# Bind("MinimumCapacity") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumCapacity"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumCapacity" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumCapacity"
						runat = "server"
						ControlToValidate = "F_MinimumCapacity"
						ControlExtender = "MEEMinimumCapacity"
						InvalidValueMessage = "Invalid value for Minimum Capacity."
						EmptyValueMessage = "Minimum Capacity is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Capacity."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Capacity should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EnforceMaximumCapacity" runat="server" Text="Enforce Maximum Capacity :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EnforceMaximumCapacity"
					  Checked='<%# Bind("EnforceMaximumCapacity") %>'
					  onclick="return script_Enforce.EnforceMaximumCapacity(this);"
            runat="server" />
				</td>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumCapacity" runat="server" Text="Maximum Capacity :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumCapacity"
						Text='<%# Bind("MaximumCapacity") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="20"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumCapacity"
						runat = "server"
						mask = "999999999999999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumCapacity" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumCapacity"
						runat = "server"
						ControlToValidate = "F_MaximumCapacity"
						ControlExtender = "MEEMaximumCapacity"
						InvalidValueMessage = "Invalid value for Maximum Capacity."
						EmptyValueMessage = "Maximum Capacity is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Capacity."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Capacity should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_DefineDimention" runat="server" Text="Define Dimention :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_DefineDimention"
					  Checked='<%# Bind("DefineDimention") %>'
					  onclick="return script_Enforce.DefineDimention(this);"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_HeightInFt" runat="server" Text="Height In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_HeightInFt"
						Text='<%# Bind("HeightInFt") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEHeightInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_HeightInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVHeightInFt"
						runat = "server"
						ControlToValidate = "F_HeightInFt"
						ControlExtender = "MEEHeightInFt"
						InvalidValueMessage = "Invalid value for Height In Ft."
						EmptyValueMessage = "Height In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Height In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Height In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_WidthInFt" runat="server" Text="Width In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_WidthInFt"
						Text='<%# Bind("WidthInFt") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEWidthInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_WidthInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVWidthInFt"
						runat = "server"
						ControlToValidate = "F_WidthInFt"
						ControlExtender = "MEEWidthInFt"
						InvalidValueMessage = "Invalid value for Width In Ft."
						EmptyValueMessage = "Width In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Width In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Width In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_LengthInFt" runat="server" Text="Length In Ft :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_LengthInFt"
						Text='<%# Bind("LengthInFt") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEELengthInFt"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_LengthInFt" />
					<AJX:MaskedEditValidator 
						ID = "MEVLengthInFt"
						runat = "server"
						ControlToValidate = "F_LengthInFt"
						ControlExtender = "MEELengthInFt"
						InvalidValueMessage = "Invalid value for Length In Ft."
						EmptyValueMessage = "Length In Ft is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Length In Ft."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Length In Ft should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EnforceMinimumDimention" runat="server" Text="Enforce Minimum Dimention :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EnforceMinimumDimention"
					  Checked='<%# Bind("EnforceMinimumDimention") %>'
					  onclick="return script_Enforce.EnforceMinimumDimention(this);"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumHeight" runat="server" Text="Minimum Height :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumHeight"
						Text='<%# Bind("MinimumHeight") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumHeight"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumHeight" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumHeight"
						runat = "server"
						ControlToValidate = "F_MinimumHeight"
						ControlExtender = "MEEMinimumHeight"
						InvalidValueMessage = "Invalid value for Minimum Height."
						EmptyValueMessage = "Minimum Height is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Height."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Height should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumWidth" runat="server" Text="Minimum Width :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumWidth"
						Text='<%# Bind("MinimumWidth") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumWidth"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumWidth" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumWidth"
						runat = "server"
						ControlToValidate = "F_MinimumWidth"
						ControlExtender = "MEEMinimumWidth"
						InvalidValueMessage = "Invalid value for Minimum Width."
						EmptyValueMessage = "Minimum Width is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Width."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Width should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MinimumLength" runat="server" Text="Minimum Length :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MinimumLength"
						Text='<%# Bind("MinimumLength") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMinimumLength"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MinimumLength" />
					<AJX:MaskedEditValidator 
						ID = "MEVMinimumLength"
						runat = "server"
						ControlToValidate = "F_MinimumLength"
						ControlExtender = "MEEMinimumLength"
						InvalidValueMessage = "Invalid value for Minimum Length."
						EmptyValueMessage = "Minimum Length is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Minimum Length."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Minimum Length should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_EnforceMaximumDimention" runat="server" Text="Enforce Maximum Dimention :" /></b>
				</td>
				<td>
          <asp:CheckBox ID="F_EnforceMaximumDimention"
					  Checked='<%# Bind("EnforceMaximumDimention") %>'
					  onclick="return script_Enforce.EnforceMaximumDimention(this);"
            runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumHeight" runat="server" Text="Maximum Height :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumHeight"
						Text='<%# Bind("MaximumHeight") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumHeight"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumHeight" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumHeight"
						runat = "server"
						ControlToValidate = "F_MaximumHeight"
						ControlExtender = "MEEMaximumHeight"
						InvalidValueMessage = "Invalid value for Maximum Height."
						EmptyValueMessage = "Maximum Height is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Height."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Height should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumWidth" runat="server" Text="Maximum Width :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumWidth"
						Text='<%# Bind("MaximumWidth") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumWidth"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumWidth" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumWidth"
						runat = "server"
						ControlToValidate = "F_MaximumWidth"
						ControlExtender = "MEEMaximumWidth"
						InvalidValueMessage = "Invalid value for Maximum Width."
						EmptyValueMessage = "Maximum Width is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Width."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Width should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_MaximumLength" runat="server" Text="Maximum Length :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_MaximumLength"
						Text='<%# Bind("MaximumLength") %>'
						style="text-align: right"
            Width="70px"
						CssClass = "mytxt"
						ValidationGroup="vrVehicleTypes"
						MaxLength="8"
						onfocus = "return this.select();"
						runat="server" />
					<AJX:MaskedEditExtender 
						ID = "MEEMaximumLength"
						runat = "server"
						mask = "999999.99"
						AcceptNegative = "Left"
						MaskType="Number"
						MessageValidatorTip="true"
						InputDirection="RightToLeft"
						ErrorTooltipEnabled="true"
						TargetControlID="F_MaximumLength" />
					<AJX:MaskedEditValidator 
						ID = "MEVMaximumLength"
						runat = "server"
						ControlToValidate = "F_MaximumLength"
						ControlExtender = "MEEMaximumLength"
						InvalidValueMessage = "Invalid value for Maximum Length."
						EmptyValueMessage = "Maximum Length is required."
						EmptyValueBlurredText = "[Required!]"
						Display = "Dynamic"
						TooltipMessage = "Enter value for Maximum Length."
						EnableClientScript = "true"
						ValidationGroup = "vrVehicleTypes"
						IsValidEmpty = "false"
						MinimumValue = "0.01"
						MinimumValueBlurredText = "Maximum Length should be greater than zero."
						MinimumValueMessage = "*"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrVehicleTypes"
  DataObjectTypeName = "SIS.VR.vrVehicleTypes"
  SelectMethod = "vrVehicleTypesGetByID"
  UpdateMethod="vrVehicleTypesUpdate"
  DeleteMethod="vrVehicleTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrVehicleTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="VehicleTypeID" Name="VehicleTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
