<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLorryReceiptsD.aspx.vb" Inherits="EF_vrLorryReceiptsD" title="Display: Site Receipt" %>
<asp:Content ID="CPHvrLorryReceiptsD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceiptsD" runat="server" Text="&nbsp;Display: Site Receipt"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptsD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceiptsD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrLorryReceiptsD.aspx?pk="
    ValidationGroup = "vrLorryReceiptsD"
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
    </script>
<asp:FormView ID="FVvrLorryReceiptsD"
  runat = "server"
  DataKeyNames = "ProjectID,MRNNo"
  DataSourceID = "ODSvrLorryReceiptsD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RequestExecutionNo" runat="server" Text="Request Execution No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_RequestExecutionNo"
            CssClass = "myfktxt"
            Text='<%# Bind("RequestExecutionNo") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Request Execution No."
            onblur= "script_vrLorryReceiptsD.validate_RequestExecutionNo(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_RequestExecutionNo_Display"
            Text='<%# Eval("VR_RequestExecution6_ExecutionDescription") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACERequestExecutionNo"
            BehaviorID="B_ACERequestExecutionNo"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="RequestExecutionNoCompletionList"
            TargetControlID="F_RequestExecutionNo"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrLorryReceiptsD.ACERequestExecutionNo_Selected"
            OnClientPopulating="script_vrLorryReceiptsD.ACERequestExecutionNo_Populating"
            OnClientPopulated="script_vrLorryReceiptsD.ACERequestExecutionNo_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterName" runat="server" Text="Transporter Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_TransporterName"
            Text='<%# Bind("TransporterName") %>'
            ToolTip="Value of Transporter Name."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_MRNNo" runat="server" ForeColor="#CC6633" Text="MRN No :" />&nbsp;</b>
        </td>
        <td>
          <asp:TextBox ID="F_MRNNo"
            Text='<%# Bind("MRNNo") %>'
            ToolTip="Value of MRN No."
            Enabled = "False"
            Width="88px"
            CssClass = "dmypktxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_MRNDate" runat="server" Text="MRN Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_MRNDate"
            Text='<%# Bind("MRNDate") %>'
            ToolTip="Value of MRN Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_TransporterID"
            Width="80px"
            Text='<%# Bind("TransporterID") %>'
            Enabled = "False"
            ToolTip="Value of Transporter."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_TransporterID_Display"
            Text='<%# Eval("VR_Transporters7_TransporterName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CustomerID" runat="server" Text="Customer :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CustomerID"
            Width="80px"
            Text='<%# Bind("CustomerID") %>'
            Enabled = "False"
            ToolTip="Value of Customer."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CustomerID_Display"
            Text='<%# Eval("VR_BusinessPartner3_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <p style="line-height:10pt">
          <asp:Label ID="L_VehicleRegistrationNo" runat="server" Text="Vehicle Registration No :" /><br />
          <asp:Label ID="Label1" runat="server" ForeColor="ForestGreen" Text="OR Consignment No :" /></p>
        </td>
        <td>
          <asp:TextBox ID="F_VehicleRegistrationNo"
            Text='<%# Bind("VehicleRegistrationNo") %>'
            ToolTip="Value of Vehicle Registration No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WayBillFormNo" runat="server" Text="Way Bill Form No [Enter NA if NOT Applicable] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WayBillFormNo"
            Text='<%# Bind("WayBillFormNo") %>'
            ToolTip="Value of Way Bill Form No [Enter NA if NOT Applicable]."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_PaymentMadeAtSite" runat="server" Text="Payment Made At Site :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_PaymentMadeAtSite"
            Checked='<%# Bind("PaymentMadeAtSite") %>'
            Enabled = "False"
            CssClass = "dmychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_AmountPaid" runat="server" Text="Amount Paid :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_AmountPaid"
            Text='<%# Bind("AmountPaid") %>'
            ToolTip="Value of Amount Paid."
            Enabled = "False"
            Width="104px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VehicleInDate" runat="server" Text="Vehicle In Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleInDate"
            Text='<%# Bind("VehicleInDate") %>'
            ToolTip="Value of Vehicle In Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleOutDate" runat="server" Text="Vehicle Out Time :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleOutDate"
            Text='<%# Bind("VehicleOutDate") %>'
            ToolTip="Value of Vehicle Out Time."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DetentionAtSite" runat="server" Text="Detention At Site :" />&nbsp;
        </td>
        <td>
          <asp:DropDownList
            ID="F_DetentionAtSite"
            SelectedValue='<%# Bind("DetentionAtSite") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
          </asp:DropDownList>
         </td>
        <td class="alignright">
          <asp:Label ID="L_ReasonForDetention" runat="server" Text="Reason For Detention :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_ReasonForDetention"
            Text='<%# Bind("ReasonForDetention") %>'
            ToolTip="Value of Reason For Detention."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OverDimensionConsignment" runat="server" Text="Over Dimension Consignment [ODC] :" />&nbsp;
        </td>
        <td>
          <asp:DropDownList
            ID="F_OverDimensionConsignment"
            SelectedValue='<%# Bind("OverDimensionConsignment") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
          </asp:DropDownList>
         </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_VehicleTypeID"
            Width="88px"
            Text='<%# Bind("VehicleTypeID") %>'
            Enabled = "False"
            ToolTip="Value of Vehicle Type ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_VehicleTypeID_Display"
            Text='<%# Eval("VR_VehicleTypes8_cmba") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <p style="line-height:10pt"><asp:Label ID="L_VehicleType" runat="server" Text="Other Vehicle Type :" /><br />
          <asp:Label ID="Label2" runat="server" ForeColor="ForestGreen" Text="OR Courier :" /><br />
          <asp:Label ID="Label3" runat="server" ForeColor="ForestGreen" Text="OR By Hand :" /></p>
        </td>
        <td>
          <asp:TextBox ID="F_VehicleType"
            Text='<%# Bind("VehicleType") %>'
            ToolTip="Value of Other Vehicle Type."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleLengthInFt" runat="server" Text="Consignment Length [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleLengthInFt"
            Text='<%# Bind("VehicleLengthInFt") %>'
            ToolTip="Value of Consignment Length [ in Ft. ]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VechicleWidthInFt" runat="server" Text="Consignment Width [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VechicleWidthInFt"
            Text='<%# Bind("VechicleWidthInFt") %>'
            ToolTip="Value of Consignment Width [ in Ft. ]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_VehicleHeightInFt" runat="server" Text="Consignment Height [ in Ft. ] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_VehicleHeightInFt"
            Text='<%# Bind("VehicleHeightInFt") %>'
            ToolTip="Value of Consignment Height [ in Ft. ]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialStateID" runat="server" Text="Material State ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_MaterialStateID"
            Width="88px"
            Text='<%# Bind("MaterialStateID") %>'
            Enabled = "False"
            ToolTip="Value of Material State ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_MaterialStateID_Display"
            Text='<%# Eval("VR_MaterialStates5_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_RemarksForDamageOrShortage" runat="server" Text="Remarks For Damage Or Shortage :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_RemarksForDamageOrShortage"
            Text='<%# Bind("RemarksForDamageOrShortage") %>'
            ToolTip="Value of Remarks For Damage Or Shortage."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_OtherRemarks" runat="server" Text="Other Remarks :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_OtherRemarks"
            Text='<%# Bind("OtherRemarks") %>'
            ToolTip="Value of Other Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_DriverNameAndContactNo" runat="server" Text="Driver Name And Contact No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_DriverNameAndContactNo"
            Text='<%# Bind("DriverNameAndContactNo") %>'
            ToolTip="Value of Driver Name And Contact No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_LRStatusID" runat="server" Text="LR Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_LRStatusID"
            Width="88px"
            Text='<%# Bind("LRStatusID") %>'
            Enabled = "False"
            ToolTip="Value of LR Status."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_LRStatusID_Display"
            Text='<%# Eval("VR_LorryReceiptStatus4_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelvrLorryReceiptDetailsD" runat="server" Text="&nbsp;List: Site Receipt Details"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptDetailsD" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrLorryReceiptDetailsD"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrLorryReceiptDetailsD.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrLorryReceiptDetailsD.aspx"
      EnableExit = "false"
      ValidationGroup = "vrLorryReceiptDetailsD"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrLorryReceiptDetailsD" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceiptDetailsD" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrLorryReceiptDetailsD" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceiptDetailsD" DataKeyNames="ProjectID,MRNNo,SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="DETAIL">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Display the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle HorizontalAlign="Center" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Serial No" SortExpression="SerialNo">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GR / LR No" SortExpression="GRorLRNo">
          <ItemTemplate>
            <asp:Label ID="LabelGRorLRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRorLRNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier ID" SortExpression="VR_BusinessPartner2_BPName">
          <ItemTemplate>
             <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("VR_BusinessPartner2_BPName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier Invoice No" SortExpression="SupplierInvoiceNo">
          <ItemTemplate>
            <asp:Label ID="LabelSupplierInvoiceNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SupplierInvoiceNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Weight Received [KG]" SortExpression="WeightReceived">
          <ItemTemplate>
            <asp:Label ID="LabelWeightReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WeightReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="No. of Packages Received" SortExpression="NoOfPackagesReceived">
          <ItemTemplate>
            <asp:Label ID="LabelNoOfPackagesReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NoOfPackagesReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignright" />
          <HeaderStyle CssClass="alignright" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Cenvat Invoice Received" SortExpression="CenvatInvoiceReceived">
          <ItemTemplate>
            <asp:Label ID="LabelCenvatInvoiceReceived" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CenvatInvoiceReceived") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="" />
        <HeaderStyle CssClass="" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrLorryReceiptDetailsD"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrLorryReceiptDetailsD"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrLorryReceiptDetailsDSelectList"
      TypeName = "SIS.VR.vrLorryReceiptDetailsD"
      SelectCountMethod = "vrLorryReceiptDetailsDSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
        <asp:ControlParameter ControlID="F_MRNNo" PropertyName="Text" Name="MRNNo" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceiptDetailsD" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLorryReceiptsD"
  DataObjectTypeName = "SIS.VR.vrLorryReceiptsD"
  SelectMethod = "vrLorryReceiptsDGetByID"
  UpdateMethod="vrLorryReceiptsDUpdate"
  DeleteMethod="vrLorryReceiptsDDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceiptsD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MRNNo" Name="MRNNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
