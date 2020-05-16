<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrPendingVehicleRequest.aspx.vb" Inherits="GF_vrPendingVehicleRequest" title="Maintain List: Pending Vehicle Request" %>
<asp:Content ID="CPHvrPendingVehicleRequest" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Pending Vehicle Request"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLvrPendingVehicleRequest" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLvrPendingVehicleRequest"
                  ToolType="lgNMGrid"
                  EditUrl="~/VR_Main/App_Edit/EF_vrPendingVehicleRequest.aspx"
                  EnableAdd="False"
                  ValidationGroup="vrPendingVehicleRequest"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSvrPendingVehicleRequest" runat="server" AssociatedUpdatePanelID="UPNLvrPendingVehicleRequest" DisplayAfter="100">
                  <ProgressTemplate>
                    <span style="color: #ff0033">Loading...</span>
                  </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
                  <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left;">Filter Records </div>
                    <div style="float: left; margin-left: 20px;">
                      <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
                    </div>
                    <div style="float: right; vertical-align: middle;">
                      <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
                    </div>
                  </div>
                </asp:Panel>
                <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
                  <table>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_SupplierID"
                          CssClass="myfktxt"
                          Width="92px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_SupplierID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_SupplierID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACESupplierID"
                          BehaviorID="B_ACESupplierID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="SupplierIDCompletionList"
                          TargetControlID="F_SupplierID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACESupplierID_Selected"
                          OnClientPopulating="ACESupplierID_Populating"
                          OnClientPopulated="ACESupplierID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_ProjectID" runat="server" Text="Project ID :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_ProjectID"
                          CssClass="myfktxt"
                          Width="62px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_ProjectID(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_ProjectID_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACEProjectID"
                          BehaviorID="B_ACEProjectID"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="ProjectIDCompletionList"
                          TargetControlID="F_ProjectID"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACEProjectID_Selected"
                          OnClientPopulating="ACEProjectID_Populating"
                          OnClientPopulated="ACEProjectID_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="alignright">
                        <b>
                          <asp:Label ID="L_RequestedBy" runat="server" Text="Requested By :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_RequestedBy"
                          CssClass="myfktxt"
                          Width="56px"
                          Text=""
                          onfocus="return this.select();"
                          AutoCompleteType="None"
                          onblur="validate_RequestedBy(this);"
                          runat="Server" />
                        <asp:Label
                          ID="F_RequestedBy_Display"
                          Text=""
                          runat="Server" />
                        <AJX:AutoCompleteExtender
                          ID="ACERequestedBy"
                          BehaviorID="B_ACERequestedBy"
                          ContextKey=""
                          UseContextKey="true"
                          ServiceMethod="RequestedByCompletionList"
                          TargetControlID="F_RequestedBy"
                          CompletionInterval="100"
                          FirstRowSelected="true"
                          MinimumPrefixLength="1"
                          OnClientItemSelected="ACERequestedBy_Selected"
                          OnClientPopulating="ACERequestedBy_Populating"
                          OnClientPopulated="ACERequestedBy_Populated"
                          CompletionSetCount="10"
                          CompletionListCssClass="autocomplete_completionListElement"
                          CompletionListItemCssClass="autocomplete_listItem"
                          CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                          runat="Server" />
                      </td>
                    </tr>
                  </table>
                  <asp:Panel ID="myData" runat="server" Height="80px" Width="100%" Style="overflow-y: scroll;"></asp:Panel>
                  <asp:Button ID="cmdTest" runat="server" Text="Push Test Data" OnClick="cmdTest_Click" />
                </asp:Panel>
                <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
                <script type="text/javascript">
                  var pcnt = 0;
                  function print_report(o) {
                    pcnt = pcnt + 1;
                    var nam = 'wTask' + pcnt;
                    var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
                    url = url + '?pk=' + o.alt;
                    window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
                    return false;
                  }
                </script>
                <script type="text/javascript">
                  var script_ReturnRemarks = {
                    temp: function () {
                    }
                  }
                </script>

                <script type="text/javascript">
                  var script_SRNNo = {
                    ACESRNNo_Selected: function (sender, e) {
                      var Prefix = sender._element.id.replace('SRNNo', '');
                      var F_SRNNo = $get(sender._element.id);
                      var F_SRNNo_Display = $get(sender._element.id + '_Display');
                      var retval = e.get_value();
                      var p = retval.split('|');
                      F_SRNNo.value = p[0];
                      F_SRNNo_Display.innerHTML = e.get_text();
                    },
                    ACESRNNo_Populating: function (sender, e) {
                      var p = sender.get_element();
                      var Prefix = sender._element.id.replace('SRNNo', '');
                      p.style.backgroundImage = 'url(../../images/loader.gif)';
                      p.style.backgroundRepeat = 'no-repeat';
                      p.style.backgroundPosition = 'right';
                      sender._contextKey = '';
                    },
                    ACESRNNo_Populated: function (sender, e) {
                      var p = sender.get_element();
                      p.style.backgroundImage = 'none';
                    },
                    validate_SRNNo: function (sender) {
                      var Prefix = sender.id.replace('SRNNo', '');
                      this.validated_FK_VR_VehicleRequest_SRNNo_main = true;
                      this.validate_FK_VR_VehicleRequest_SRNNo(sender, Prefix);
                    },
                    validate_FK_VR_VehicleRequest_SRNNo: function (o, Prefix) {
                      var value = o.id;
                      var SRNNo = $get(o.id);
                      if (SRNNo.value == '') {
                        if (this.validated_FK_VR_VehicleRequest_SRNNo_main) {
                          var o_d = $get(Prefix + 'SRNNo' + '_Display');
                          try { o_d.innerHTML = ''; } catch (ex) { }
                        }
                        return true;
                      }
                      value = value + ',' + SRNNo.value;
                      o.style.backgroundImage = 'url(../../images/pkloader.gif)';
                      o.style.backgroundRepeat = 'no-repeat';
                      o.style.backgroundPosition = 'right';
                      PageMethods.validate_FK_VR_VehicleRequest_SRNNo(value, this.validated_FK_VR_VehicleRequest_SRNNo);
                    },
                    validated_FK_VR_VehicleRequest_SRNNo_main: false,
                    validated_FK_VR_VehicleRequest_SRNNo: function (result) {
                      var p = result.split('|');
                      var o = $get(p[1]);
                      if (script_SRNNo.validated_FK_VR_VehicleRequest_SRNNo_main) {
                        var o_d = $get(p[1] + '_Display');
                        try { o_d.innerHTML = p[2]; } catch (ex) { }
                      }
                      o.style.backgroundImage = 'none';
                      if (p[0] == '1') {
                        o.value = '';
                        o.focus();
                      }
                    },
                    temp: function () {
                    }
                  }
                </script>
                <style type="text/css">
                  .lg_tb_n{
                    border:1pt solid silver;
                    background-color:gainsboro;
                    color:gray;
                  }
                  lg_tb_n:hover{
                    background-color:white;
                    color:black;
                  }
                  .lg_pb_w, 
                  .lg_pb_p{
                    border-radius:5px;
                    padding:2px;
                    color:darkgray;
                    background-color:gainsboro;
                    border: 1pt solid silver;
                    width:100%;
                  }
                  .lg_pb_w:hover{
                    color:white;
                    background-color:crimson;
                  }
                  .lg_pb_p:hover{
                    color:white;
                    background-color:royalblue;
                  }
                </style>
                <asp:GridView ID="GVvrPendingVehicleRequest" SkinID="gv_silver" BorderColor="#A9A9A9" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrPendingVehicleRequest" DataKeyNames="RequestNo">
                  <Columns>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <table>
                          <tr>
                            <td style="vertical-align: top">
                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
                            <td style="vertical-align: top">
                              <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" /></td>
                          </tr>
                        </table>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REQ.No" SortExpression="RequestNo">
                      <ItemTemplate>
                        <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                      <HeaderStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SUPPLIER" SortExpression="IDM_Vendors5_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PROJECT" SortExpression="IDM_Projects4_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VEHICLE" SortExpression="VR_VehicleTypes9_cmba">
                      <ItemTemplate>
                        <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes9_cmba") %>'></asp:Label>
                        <hr /><asp:Label ID="LabelNotification" runat="server" Text='<%# Eval("Notification") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REQUIRED ON" SortExpression="VehicleRequiredOn">
                      <ItemTemplate>
                        <asp:Label ID="LabelVehicleRequiredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRequiredOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REQUESTED ON" SortExpression="RequestedOn">
                      <ItemTemplate>
                        <asp:Label ID="LabelRequestedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestedOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SP Status">
                      <ItemTemplate>
                        <asp:Button ID="L_spstatus" runat="server" ToolTip="Click to change Cities" BorderStyle="None" BackColor="Transparent" style="cursor:pointer;" Font-Underline="true" Text='<%# Eval("SpStatusName") %>' CommandName="Cities" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SP Request">
                      <ItemTemplate>
                        <asp:Label ID="L_SPRequestID" runat="server" Visible='<%# Eval("SPReqIDVisible") %>' ForeColor="Green" Font-Bold="true" Text='<%# "Req.:" & Eval("SPRequestID") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION">
                      <ItemTemplate>
                        <div style="display:flex;flex-direction:column;">
                          <div runat="server" Visible='<%# Eval("RejectWFVisible") %>'>
                            <div style="display:flex; flex-direction:row;">
                              <div>
                                <asp:TextBox ID="F_ReturnRemarks"
                                  Text='<%# Bind("ReturnRemarks") %>'
                                  Width="200px"
                                  CssClass="lg_tb_n"
                                  onfocus="return this.select();"
                                  ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
                                  onblur="this.value=this.value.replace(/\'/g,'');"
                                  ToolTip="Remarks is mandatory if returning."
                                  MaxLength="100"
                                  Enabled='<%# Eval("EnableInput") %>'
                                  placeholder="Reason for returning"
                                  runat="server" />
                                <asp:RequiredFieldValidator
                                  ID="RFVReturnRemarks"
                                  runat="server"
                                  ControlToValidate="F_ReturnRemarks"
                                  Text="Return Remarks is required."
                                  ErrorMessage="[Required!]"
                                  Display="Dynamic"
                                  EnableClientScript="true"
                                  ValidationGroup='<%# "Reject" & Container.DataItemIndex %>'
                                  SetFocusOnError="true" />
                              </div>
                              <div style="padding-left:2px;">
                                <asp:Button ID="cmdRejectWF" CssClass="lg_pb_w" Text="Return" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return"  OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
                              </div>
                            </div>
                          </div>
                          <div>
                            <asp:Button ID="cmdSPRequest" CssClass="lg_pb_p" Text="Send to Super Procure" runat="server" Visible='<%# Eval("SPRequestVisible") %>' AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Send to Super Procure" CommandName="SPRequest" CommandArgument='<%# Container.DataItemIndex %>' />
                          </div>
                          <div>
                            <asp:Button ID="cmdSPExecution" CssClass="lg_pb_p" Text="Download Execution" runat="server" Visible='<%# Eval("SPExecutionVisible") %>' AlternateText='<%# Eval("SPRequestID") %>' ToolTip="Click to download Execution Data" CommandName="SPExecution" CommandArgument='<%# Container.DataItemIndex %>'></asp:Button>
                          </div>
                          <div>
                            <asp:Label ID="L_SPEdiMessage" runat="server" Text='<%# Eval("ShowSPEdiMessage") %>'></asp:Label>
                          </div>
                        </div>
                      </ItemTemplate>
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSvrPendingVehicleRequest"
                  runat="server"
                  DataObjectTypeName="SIS.VR.vrPendingVehicleRequest"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_vrPendingVehicleRequestSelectList"
                  TypeName="SIS.VR.vrPendingVehicleRequest"
                  SelectCountMethod="vrPendingVehicleRequestSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_SupplierID" PropertyName="Text" Name="SupplierID" Type="String" Size="6" />
                    <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
                    <asp:ControlParameter ControlID="F_RequestedBy" PropertyName="Text" Name="RequestedBy" Type="String" Size="8" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </td>
            </tr>
          </table>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GVvrPendingVehicleRequest" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_SupplierID" />
          <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
          <asp:AsyncPostBackTrigger ControlID="F_RequestedBy" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>

  <asp:UpdatePanel runat="server">
    <ContentTemplate>
  <asp:Panel ID="pnl1" runat="server" Style="background-color:white;display: none;height:226px;border-radius:5px;" Width='400px'   >
    <asp:Panel ID="pnlHeader" runat="server" style="width:100%;height:33px;padding-top:8px;text-align:center;border-bottom:1pt solid lightgray;" >
      <asp:Label ID="HeaderText" runat="server" Font-Size="16px" Font-Bold="true" Text='My Modal Text'></asp:Label>
    </asp:Panel>
    <asp:Panel ID="modalContent" runat="server" style="width:100%;height:136px;padding:4px;">
      <div style="display:flex;flex-direction:column;">
        <div style="flex-direction:row;padding-top:10px;">
          <div>
            <asp:Label ID="L_FromCity" runat="server" Text="From City:" Font-Bold="true" Width="392px"></asp:Label>

          </div>
          <div>
            <asp:TextBox ID="F_FromCity" runat="server" Width="386px" onfocus="this.select();"></asp:TextBox>
          </div>
        </div>
        <div style="flex-direction:row;padding-top:20px;">
          <div>
            <asp:Label ID="L_ToCity" runat="server" Text="To City:" Font-Bold="true" Width="392px"></asp:Label>

          </div>
          <div>
            <asp:TextBox ID="F_ToCity" runat="server" Width="386px" onfocus="this.select();"></asp:TextBox>

          </div>
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlFooter" runat="server" style="width:100%;height:33px;padding-top:8px;text-align:right;border-top:1pt solid lightgray;">
      <asp:Label ID="L_PrimaryKey" runat="server" style="display:none;"></asp:Label>
      <asp:Button ID="cmdOK" runat="server" Width="70px" Text="OK" style="text-align:center;margin-right:30px;" />
      <asp:Button ID="cmdCancel" runat="server" Width="70px" Text="Cancle" style="text-align:center;margin-right:30px;" />
    </asp:Panel>
  </asp:Panel>
<asp:Button ID="dummy" runat="server" style="display:none;" Text="show"></asp:Button>
<AJX:ModalPopupExtender 
  ID="mPopup" 
  BehaviorID="myMPE1"
  TargetControlID="dummy" 
  BackgroundCssClass="modalBackground" 
  CancelControlID="cmdCancel" 
  OkControlID="cmdCancel" 
  PopupControlID="pnl1" 
  PopupDragHandleControlID="pnlHeader" 
  DropShadow="true"
  runat="server">
</AJX:ModalPopupExtender>
    </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="cmdOK" EventName="Click" />
  </Triggers>
  </asp:UpdatePanel>
</asp:Content>
