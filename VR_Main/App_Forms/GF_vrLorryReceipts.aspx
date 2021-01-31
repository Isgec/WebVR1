<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrLorryReceipts.aspx.vb" Inherits="GF_vrLorryReceipts" title="Maintain List: Site Receipts" %>
<asp:Content ID="CPHvrLorryReceipts" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabelvrLorryReceipts" runat="server" Text="&nbsp;List: Site Receipts"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLvrLorryReceipts" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLvrLorryReceipts"
                  ToolType="lgNMGrid"
                  EditUrl="~/VR_Main/App_Edit/EF_vrLorryReceipts.aspx"
                  AddUrl="~/VR_Main/App_Create/AF_vrLorryReceipts.aspx?skip=1"
                  ValidationGroup="vrLorryReceipts"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSvrLorryReceipts" runat="server" AssociatedUpdatePanelID="UPNLvrLorryReceipts" DisplayAfter="100">
                  <ProgressTemplate>
                    <span style="color: #ff0033">Loading...</span>
                  </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
                  <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left;">Filter Records </div>
                    <div style="float: left; margin-left: 20px;">
                      <asp:Label ID="lblH" runat="server">(Show Filters...[Download / Upload EXCEL Template])</asp:Label>
                    </div>
                    <div style="float: right; vertical-align: middle;">
                      <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...[Download / Upload EXCEL Template])" />
                    </div>
                  </div>
                </asp:Panel>
                <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
                  <div style="display: flex; flex-direction: row; justify-content: space-around;">
                    <div style="border: 1pt solid black; border-radius: 6px;">
                      <div class="caption" style="padding: 2px; background-image: unset; background: unset; background-color: gainsboro;">
                        Filter Record
                      </div>
                      <table>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ProjectID" runat="server" Text="Project :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_ProjectID"
                              CssClass="mypktxt"
                              Width="70px"
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
                              <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_TransporterID"
                              CssClass="myfktxt"
                              Width="80px"
                              Text=""
                              onfocus="return this.select();"
                              AutoCompleteType="None"
                              onblur="validate_TransporterID(this);"
                              runat="Server" />
                            <asp:Label
                              ID="F_TransporterID_Display"
                              Text=""
                              runat="Server" />
                            <AJX:AutoCompleteExtender
                              ID="ACETransporterID"
                              BehaviorID="B_ACETransporterID"
                              ContextKey=""
                              UseContextKey="true"
                              ServiceMethod="TransporterIDCompletionList"
                              TargetControlID="F_TransporterID"
                              CompletionInterval="100"
                              FirstRowSelected="true"
                              MinimumPrefixLength="1"
                              OnClientItemSelected="ACETransporterID_Selected"
                              OnClientPopulating="ACETransporterID_Populating"
                              OnClientPopulated="ACETransporterID_Populated"
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
                              <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type ID :" /></b>
                          </td>
                          <td>
                            <LGM:LC_vrVehicleTypes
                              ID="F_VehicleTypeID"
                              SelectedValue=""
                              OrderBy="cmba"
                              DataTextField="cmba"
                              DataValueField="VehicleTypeID"
                              IncludeDefault="true"
                              DefaultText="-- Select --"
                              Width="200px"
                              AutoPostBack="true"
                              RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                              CssClass="myddl"
                              runat="Server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_LRStatusID" runat="server" Text="LR Status :" /></b>
                          </td>
                          <td>
                            <LGM:LC_vrLorryReceiptStatus
                              ID="F_LRStatusID"
                              SelectedValue=""
                              OrderBy="Description"
                              DataTextField="Description"
                              DataValueField="LRStatusID"
                              IncludeDefault="true"
                              DefaultText="-- Select --"
                              Width="200px"
                              AutoPostBack="true"
                              RequiredFieldErrorMessage="<div class='errorLG'>Required!</div>"
                              CssClass="myddl"
                              runat="Server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_CustomerID" runat="server" Text="Customer :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_CustomerID"
                              CssClass="myfktxt"
                              Width="63px"
                              Text=""
                              onfocus="return this.select();"
                              AutoCompleteType="None"
                              onblur="validate_CustomerID(this);"
                              runat="Server" />
                            <asp:Label
                              ID="F_CustomerID_Display"
                              Text=""
                              runat="Server" />
                            <AJX:AutoCompleteExtender
                              ID="ACECustomerID"
                              BehaviorID="B_ACECustomerID"
                              ContextKey=""
                              UseContextKey="true"
                              ServiceMethod="CustomerIDCompletionList"
                              TargetControlID="F_CustomerID"
                              CompletionInterval="100"
                              FirstRowSelected="true"
                              MinimumPrefixLength="1"
                              OnClientItemSelected="ACECustomerID_Selected"
                              OnClientPopulating="ACECustomerID_Populating"
                              OnClientPopulated="ACECustomerID_Populated"
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
                              <asp:Label ID="Label1" runat="server" Text="Pending to Submit:" /></b>
                          </td>
                          <td>
                            <asp:CheckBox ID="F_Pending" runat="server" CssClass="mychk" AutoPostBack="true" />
                          </td>
                        </tr>
                      </table>
                    </div>
                    <div style="border: 1pt solid black; border-radius: 6px;">
                      <div class="caption" style="padding: 2px; background-image: unset; background: unset; background-color: gainsboro;">
                        Download EXCEL Template to work offline
                      </div>
                      <table>
                        <tr>
                          <td><b>
                            <asp:Label ID="lblTemplate" runat="server" Text="Project ID" />
                          </b>
                          </td>
                          <td>
                            <script type="text/javascript">
                              var script_vrLorryReceipts = {
                                ACEDownloadPrjID_Selected: function (sender, e) {
                                  var Prefix = sender._element.id.replace('DownloadPrjID', '');
                                  var F_DownloadPrjID = $get(sender._element.id);
                                  var F_DownloadPrjID_Display = $get(sender._element.id + '_Display');
                                  var retval = e.get_value();
                                  var p = retval.split('|');
                                  F_DownloadPrjID.value = p[0];
                                  try { F_DownloadPrjID_Display.innerHTML = e.get_text(); } catch (ex) { }
                                },
                                ACEDownloadPrjID_Populating: function (sender, e) {
                                  var p = sender.get_element();
                                  var Prefix = sender._element.id.replace('DownloadPrjID', '');
                                  p.style.backgroundImage = 'url(../../images/loader.gif)';
                                  p.style.backgroundRepeat = 'no-repeat';
                                  p.style.backgroundPosition = 'right';
                                  sender._contextKey = '';
                                },
                                ACEDownloadPrjID_Populated: function (sender, e) {
                                  var p = sender.get_element();
                                  p.style.backgroundImage = 'none';
                                },
                                validate_DownloadPrjID: function (sender) {
                                  var Prefix = sender.id.replace('DownloadPrjID', '');
                                  this.validated_FK_VR_LorryReceipts_DownloadPrjID_main = true;
                                  this.validate_FK_VR_LorryReceipts_DownloadPrjID(sender, Prefix);
                                },
                                validate_FK_VR_LorryReceipts_DownloadPrjID: function (o, Prefix) {
                                  var value = o.id;
                                  var DownloadPrjID = $get(Prefix + 'DownloadPrjID');
                                  if (DownloadPrjID.value == '') {
                                    if (this.validated_FK_VR_LorryReceipts_DownloadPrjID_main) {
                                      var o_d = $get(Prefix + 'DownloadPrjID' + '_Display');
                                      try { o_d.innerHTML = ''; } catch (ex) { }
                                    }
                                    return true;
                                  }
                                  value = value + ',' + DownloadPrjID.value;
                                  o.style.backgroundImage = 'url(../../images/pkloader.gif)';
                                  o.style.backgroundRepeat = 'no-repeat';
                                  o.style.backgroundPosition = 'right';
                                  PageMethods.validate_FK_VR_LorryReceipts_ProjectID(value, this.validated_FK_VR_LorryReceipts_DownloadPrjID);
                                },
                                validated_FK_VR_LorryReceipts_DownloadPrjID_main: false,
                                validated_FK_VR_LorryReceipts_DownloadPrjID: function (result) {
                                  var p = result.split('|');
                                  var o = $get(p[1]);
                                  if (script_vrLorryReceipts.validated_FK_VR_LorryReceipts_DownloadPrjID_main) {
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
                            <asp:TextBox
                              ID="F_DownloadPrjID"
                              CssClass="mypktxt"
                              Width="80px"
                              Text=""
                              onfocus="return this.select();"
                              AutoCompleteType="None"
                              onblur="script_vrLorryReceipts.validate_DownloadPrjID(this);"
                              runat="Server" />
                            <%--<asp:Label
                              ID = "F_DownloadPrjID_Display"
                              Text=""
                              Runat="Server" />--%>
                            <AJX:AutoCompleteExtender
                              ID="ACEDownloadPrjID"
                              BehaviorID="B_ACEDownloadPrjID"
                              ContextKey=""
                              UseContextKey="true"
                              ServiceMethod="ProjectIDCompletionList"
                              TargetControlID="F_DownloadPrjID"
                              CompletionInterval="100"
                              FirstRowSelected="true"
                              MinimumPrefixLength="1"
                              OnClientItemSelected="script_vrLorryReceipts.ACEDownloadPrjID_Selected"
                              OnClientPopulating="script_vrLorryReceipts.ACEDownloadPrjID_Populating"
                              OnClientPopulated="script_vrLorryReceipts.ACEDownloadPrjID_Populated"
                              CompletionSetCount="10"
                              CompletionListCssClass="autocomplete_completionListElement"
                              CompletionListItemCssClass="autocomplete_listItem"
                              CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                              runat="Server" />
                          </td>
                          <td>
                            <asp:Button ID="cmdDownload" CssClass="file_upload_button" Text="Download" runat="server" ToolTip="Click to download template file." CommandName="Download" CommandArgument="" />
                          </td>
                        </tr>
                      </table>
                      <asp:Label runat="server" ID="errMsg" ForeColor="Red" Text="" />
                    </div>
                    <div style="border: 1pt solid black; border-radius: 6px;">
                      <div class="caption" style="padding: 2px; background-image: unset; background: unset; background-color: gainsboro;">
                        Upload template to submit offline data to HO
                      </div>
                      <table>
                        <tr>
                          <td>
                            <input type="text" id="fileName" style="width: 185px" class="file_input_textbox" readonly="readonly">
                          </td>
                          <td>
                            <div class="file_input_div">
                              <input type="button" value="Search" class="file_input_button" />
                              <asp:FileUpload ID="F_FileUpload" runat="server" Width="80px" class="file_input_hidden" onchange="document.getElementById('fileName').value = this.value;" ToolTip="Upload Item Template" />
                            </div>
                          </td>
                          <td>
                            <asp:Button ID="cmdFileUpload" CssClass="file_upload_button" OnClientClick="return this.style.display='none';showProcessingMPV(); true;" Text="Upload" runat="server" ToolTip="Click to upload & process template file." CommandName="Upload" CommandArgument="" />
                          </td>
                        </tr>
                      </table>
                      <div style="margin-left: 20px;">

                        <span style="font-weight: bold; font-size: 10px; color: black; font-style: italic;">You have to:
                        </span>
                        <br />
                        <span style="font-weight: bold; font-size: 14px; color: red; background-color: wheat; border-radius: 6px;">Link IRN
                        </span>
                        <br />
                        <span style="font-weight: bold; font-size: 10px; color: black; font-style: italic;">and
                        </span>
                        <br />
                        <span style="font-weight: bold; font-size: 14px; color: red; background-color: wheat; border-radius: 6px;">Forward to HO
                        </span>
                        <br />
                        <span style="font-weight: bold; font-size: 10px; color: black; font-style: italic;">after upload.
                        </span>
                      </div>
                    </div>
                  </div>
                </asp:Panel>
                <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...[Download / Upload EXCEL Template])" CollapsedText="(Show Filters...[Download / Upload EXCEL Template])" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
                <script type="text/javascript">
                  var pcnt = 0;
                  function print_report(o) {
                    pcnt = pcnt + 1;
                    var nam = 'wTask' + pcnt;
                    var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
                    url = url + '?pk=' + o.alt;
                    window.open(url, nam, 'left=20,top=20,width=1050,height=600,toolbar=1,resizable=1,scrollbars=1');
                    return false;
                  }
                </script>
                <asp:GridView ID="GVvrLorryReceipts" SkinID="gv_silver" runat="server" DataSourceID="ODSvrLorryReceipts" DataKeyNames="ProjectID,MRNNo">
                  <Columns>
                    <asp:TemplateField HeaderText="EDIT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRINT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Project" SortExpression="IDM_Projects2_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects2_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRN No" SortExpression="MRNNo">
                      <ItemTemplate>
                        <asp:Label ID="LabelMRNNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("MRNNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignright" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MRN Date" SortExpression="MRNDate">
                      <ItemTemplate>
                        <asp:Label ID="LabelMRNDate" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("MRNDate") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transporter" SortExpression="VR_Transporters7_TransporterName">
                      <ItemTemplate>
                        <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters7_TransporterName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vehicle No" SortExpression="VehicleRegistrationNo">
                      <ItemTemplate>
                        <asp:Label ID="LabelVehicleRegistrationNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("VehicleRegistrationNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VR_VehicleTypes8_cmba">
                      <ItemTemplate>
                        <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes8_cmba") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LR Status" SortExpression="VR_LorryReceiptStatus4_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_LRStatusID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("LRStatusID") %>' Text='<%# Eval("VR_LorryReceiptStatus4_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Link Status">
                      <ItemTemplate>
                        <asp:Label ID="L_LinkStatus" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("IRLinkStatus") %>' Text='<%# Eval("IRLinkStatus") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Forward">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Please link IRN (if NOT linked), then submit MRN to HO ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSvrLorryReceipts"
                  runat="server"
                  DataObjectTypeName="SIS.VR.vrLorryReceipts"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_vrLorryReceiptsSelectList"
                  TypeName="SIS.VR.vrLorryReceipts"
                  SelectCountMethod="vrLorryReceiptsSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_ProjectID" PropertyName="Text" Name="ProjectID" Type="String" Size="6" />
                    <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
                    <asp:ControlParameter ControlID="F_VehicleTypeID" PropertyName="SelectedValue" Name="VehicleTypeID" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_LRStatusID" PropertyName="SelectedValue" Name="LRStatusID" Type="Int32" Size="10" />
                    <asp:ControlParameter ControlID="F_CustomerID" PropertyName="Text" Name="CustomerID" Type="String" Size="9" />
                    <asp:ControlParameter ControlID="F_Pending" PropertyName="Checked" Name="Pending" Type="Boolean" Size="3" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
                <br />
              </td>
            </tr>
          </table>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="GVvrLorryReceipts" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_ProjectID" />
          <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
          <asp:AsyncPostBackTrigger ControlID="F_VehicleTypeID" />
          <asp:AsyncPostBackTrigger ControlID="F_LRStatusID" />
          <asp:AsyncPostBackTrigger ControlID="F_CustomerID" />
          <asp:AsyncPostBackTrigger ControlID="F_Pending" />
          <asp:PostBackTrigger ControlID="cmdFileUpload" />
          <asp:PostBackTrigger ControlID="cmdDownload" />

        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
  <div id="ready" runat="server">

  </div>
</asp:Content>
