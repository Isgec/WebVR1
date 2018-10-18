<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrctVehicleRequest.aspx.vb" Inherits="EF_vrctVehicleRequest" title="Edit: CT-Vehicle Request" %>
<asp:Content ID="CPHvrctVehicleRequest" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrctVehicleRequest" runat="server" Text="&nbsp;Edit: CT-Vehicle Request"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrctVehicleRequest" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrctVehicleRequest"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "vrctVehicleRequest"
    runat = "server" />
<asp:FormView ID="FVvrctVehicleRequest"
  runat = "server"
  DataKeyNames = "VRRequestNo,SerialNo"
  DataSourceID = "ODSvrctVehicleRequest"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_VRRequestNo" runat="server" ForeColor="#CC6633" Text="VR Request No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_VRRequestNo"
            Width="88px"
            Text='<%# Bind("VRRequestNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of VR Request No."
            Runat="Server" />
          <asp:Label
            ID = "F_VRRequestNo_Display"
            Text='<%# Eval("VR_VehicleRequest1_RequestDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Serial No."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_PONumber" runat="server" ForeColor="#CC6633" Text="PO Number :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:Label ID="F_PONumber"
            Text='<%# Bind("PONumber") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemReference" runat="server" ForeColor="#CC6633" Text="Item Reference :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:Label ID="F_ItemReference"
            Text='<%# Bind("ItemReference") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ActivityID" runat="server" ForeColor="#CC6633" Text="Sub Item :" />&nbsp;</b>
        </td>
        <td>
          <asp:Label ID="F_ActivityID"
            Text='<%# Bind("ActivityID") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="Label6" runat="server" ForeColor="#CC6633" Text="Sub Item Desc :" />&nbsp;</b>
        </td>
        <td>
          <asp:Label ID="F_SubItemDesc"
            Text='<%# Eval("SubItemDesc") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_IrefWeight" runat="server" ForeColor="#CC6633" Text="Iref./Sub Item Weight [Kg] :" /></b>
        </td>
        <td>
          <asp:Label ID="F_IrefWeight"
            Text='<%# Eval("IrefWeight") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="Label3" runat="server" ForeColor="#CC6633" Text="Despatched Weight [Kg] :" />&nbsp;</b>
        </td>
        <td>
          <asp:Label ID="Label4"
            Text='<%# Eval("DespatchedWt") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="Label1" runat="server" ForeColor="#CC6633" Text="QC Cleared Weight [Kg] :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:Label ID="Label2"
            Text='<%# Eval("QCClearedWt") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="Label7" runat="server" ForeColor="#CC6633" Text="Iref./Sub Item Quantity :" /></b>
        </td>
        <td>
          <asp:Label ID="Label8"
            Text='<%# Eval("PercentOfQuantity") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="Label9" runat="server" ForeColor="#CC6633" Text="Despatched Quantity :" />&nbsp;</b>
        </td>
        <td>
          <asp:Label ID="Label10"
            Text='<%# Eval("DespatchedQty") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="Label11" runat="server" ForeColor="#CC6633" Text="QC Cleared Quantity :" />&nbsp;</b>
        </td>
        <td colspan="3">
          <asp:Label ID="Label12"
            Text='<%# Eval("QCClearedQty") %>'
            CssClass = "dmypktxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Quantity" runat="server" Text="Quantity :" />
        </td>
        <td>
          <asp:TextBox ID="F_Quantity"
            Text='<%# Bind("Quantity") %>'
            style="text-align: right"
            Width="184px"
            CssClass = "mytxt"
            ValidationGroup= "vrctVehicleRequest"
            MaxLength="22"
            onfocus = "return this.select();"
            onblur ="return dc(this,4);"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_PartialOrFull" runat="server" Text="Partial Or Full :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:DropDownList
            ID="F_PartialOrFull"
            SelectedValue='<%# Bind("PartialOrFull") %>'
            CssClass = "myddl"
            Width="200px"
            ValidationGroup = "vrctVehicleRequest"
            Runat="Server" >
            <asp:ListItem Value="PARTIAL">PARTIAL</asp:ListItem>
            <asp:ListItem Value="FULL">FULL</asp:ListItem>
          </asp:DropDownList>
          <asp:RequiredFieldValidator 
            ID = "RFVPartialOrFull"
            runat = "server"
            ControlToValidate = "F_PartialOrFull"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrctVehicleRequest"
            SetFocusOnError="true" />
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr id="RowProgressPercent" runat="server" clientIDMode="Static" visible='<%# Eval("RowProgressPercent") %>' >
        <td class="alignright">
          <asp:Label ID="L_ProgressPercent" runat="server" Text=" % Progress Percent :" />
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ProgressPercent"
            Text='<%# Bind("ProgressPercent") %>'
            style="text-align: right"
            Width="128px"
            CssClass = "mytxt"
            ValidationGroup= "vrctVehicleRequest"
            MaxLength="8"
            onfocus = "return this.select();"
            onblur="return dc(this,4);"
            runat="server" />
        </td>
      </tr>
        <tr id="RowProgressWeight" runat="server" clientIDMode="Static" visible='<%# Eval("RowProgressWeight") %>' >
          <td class="alignright">
            <asp:Label ID="Label5" runat="server" Text="Progress Weight [Kg] :" />
          </td>
          <td colspan="3">
            <asp:TextBox ID="F_ProgressWeight"
              Text='<%# Bind("ProgressWeight") %>'
              style="text-align: right"
              Width="184px"
              CssClass = "mytxt"
              ValidationGroup = "vrctVehicleRequest"
              MaxLength="18"
              onfocus = "return this.select();"
              onblur ="return dc(this,4);"
              runat="server" />
            </td>
        </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NotSelectedList" runat="server" Text="Items NOT Despatch :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_NotSelectedList"
            Text='<%# Bind("NotSelectedList") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrctVehicleRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Items NOT Despatch."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVNotSelectedList"
            runat = "server"
            ControlToValidate = "F_NotSelectedList"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrctVehicleRequest"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SelectedList" runat="server" Text="Items Despatched :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SelectedList"
            Text='<%# Bind("SelectedList") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrctVehicleRequest"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Items Despatched."
            MaxLength="500"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSelectedList"
            runat = "server"
            ControlToValidate = "F_SelectedList"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrctVehicleRequest"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrctVehicleRequest"
  DataObjectTypeName = "SIS.VR.vrctVehicleRequest"
  SelectMethod = "vrctVehicleRequestGetByID"
  UpdateMethod="UZ_vrctVehicleRequestUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrctVehicleRequest"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="VRRequestNo" Name="VRRequestNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
