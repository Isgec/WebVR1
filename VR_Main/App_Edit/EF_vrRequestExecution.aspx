<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrRequestExecution.aspx.vb" Inherits="EF_vrRequestExecution" title="Edit: Request Execution" %>
<asp:Content ID="CPHvrRequestExecution" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabeltaBDLodging" runat="server" Text="&nbsp;Edit: Request Execution"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLvrRequestExecution" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLvrRequestExecution"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            EnablePrint="True"
            PrintUrl="../App_Print/RP_vrRequestExecution.aspx?pk="
            ValidationGroup="vrRequestExecution"
            runat="server" />
          <script type="text/javascript">
            var pcnt = 0;
            function print_report(o) {
              pcnt = pcnt + 1;
              var nam = 'wTask' + pcnt;
              var url = self.location.href.replace('App_Forms/GF_', 'App_Print/RP_');
              url = url + '?pk=' + o.alt;
              url = o.alt;
              window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
            function script_download(id, id1, typ) {
              pcnt = pcnt + 1;
              var nam = 'wdwd' + pcnt;
              var url = self.location.href.replace('App_Edit/EF_vrRequestExecution.aspx', 'App_Downloads/filedownload.aspx');
              url = url + '&id=' + id + '&typ=' + typ + '&id1=' + id1;
              window.open(url, nam, 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
              return false;
            }
          </script>
          <asp:FormView ID="FVvrRequestExecution"
            runat="server"
            DataKeyNames="SRNNo"
            DataSourceID="ODSvrRequestExecution"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="width: 100%">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_SRNNo" runat="server" ForeColor="#CC6633" Text="Request Execution No :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_SRNNo"
                        Text='<%# Bind("SRNNo") %>'
                        ToolTip="Value of Request Execution No."
                        Enabled="False"
                        CssClass="mypktxt"
                        Width="70px"
                        Style="text-align: right"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ExecutionDescription" runat="server" Text="Execution Description :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_ExecutionDescription"
                        Text='<%# Bind("ExecutionDescription") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrRequestExecution"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Execution Description."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVExecutionDescription"
                        runat="server"
                        ControlToValidate="F_ExecutionDescription"
                        Text="Execution Description is required."
                        ErrorMessage="[Required!]"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrRequestExecution"
                        SetFocusOnError="true" />
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
                        Text='<%# Bind("TransporterID") %>'
                        AutoCompleteType="None"
                        Width="63px"
                        onfocus="return this.select();"
                        ToolTip="Enter value for Transporter."
                        ValidationGroup="vrRequestExecution"
                        onblur="script_vrRequestExecution.validate_TransporterID(this);"
                        runat="Server" />
                      <asp:Label
                        ID="F_TransporterID_Display"
                        Text='<%# Eval("VR_Transporters10_TransporterName") %>'
                        runat="Server" />
                      <asp:RequiredFieldValidator
                        ID="RFVTransporterID"
                        runat="server"
                        ControlToValidate="F_TransporterID"
                        Text="Transporter is required."
                        ErrorMessage="[Required!]"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrRequestExecution"
                        SetFocusOnError="true" />
                      <AJX:AutoCompleteExtender
                        ID="ACETransporterID"
                        BehaviorID="B_ACETransporterID"
                        ContextKey=""
                        UseContextKey="true"
                        ServiceMethod="TransporterIDCompletionList"
                        TargetControlID="F_TransporterID"
                        EnableCaching="false"
                        CompletionInterval="100"
                        FirstRowSelected="true"
                        MinimumPrefixLength="1"
                        OnClientItemSelected="script_vrRequestExecution.ACETransporterID_Selected"
                        OnClientPopulating="script_vrRequestExecution.ACETransporterID_Populating"
                        OnClientPopulated="script_vrRequestExecution.ACETransporterID_Populated"
                        CompletionSetCount="10"
                        CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_VehiclePlacedOn" runat="server" Text="Vehicle Placed On :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehiclePlacedOn"
                        Text='<%# Bind("VehiclePlacedOn") %>'
                        Width="70px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrRequestExecution"
                        runat="server" />
                      <asp:Image ID="ImageButtonVehiclePlacedOn" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CEVehiclePlacedOn"
                        TargetControlID="F_VehiclePlacedOn"
                        Format="dd/MM/yyyy"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonVehiclePlacedOn" />
                      <AJX:MaskedEditExtender
                        ID="MEEVehiclePlacedOn"
                        runat="server"
                        Mask="99/99/9999"
                        MaskType="Date"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_VehiclePlacedOn" />
                      <AJX:MaskedEditValidator
                        ID="MEVVehiclePlacedOn"
                        runat="server"
                        ControlToValidate="F_VehiclePlacedOn"
                        ControlExtender="MEEVehiclePlacedOn"
                        InvalidValueMessage="Invalid value for Vehicle Placed On."
                        EmptyValueMessage="Vehicle Placed On is required."
                        EmptyValueBlurredText="[Required!]"
                        Display="Dynamic"
                        TooltipMessage="Enter value for Vehicle Placed On."
                        EnableClientScript="true"
                        ValidationGroup="vrRequestExecution"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
                    </td>
                    <td>
                      <LGM:LC_vrVehicleTypes
                        ID="F_VehicleTypeID"
                        SelectedValue='<%# Bind("VehicleTypeID") %>'
                        OrderBy="DisplayField"
                        DataTextField="DisplayField"
                        DataValueField="PrimaryKey"
                        IncludeDefault="true"
                        DefaultText="-- Select --"
                        Width="400px"
                        CssClass="myfktxt"
                        ValidationGroup="vrRequestExecution"
                        RequiredFieldErrorMessage="Vehicle Type is required."
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_VehicleNo" runat="server" Text="Vehicle No :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_VehicleNo"
                        Text='<%# Bind("VehicleNo") %>'
                        Width="140px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrRequestExecution"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Vehicle No."
                        MaxLength="20"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_EstimatedDistance" runat="server" Text="Weight :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_EstimatedDistance"
                        Text='<%# Bind("EstimatedDistance") %>'
                        Width="100px"
                        CssClass="mytxt"
                        Style="text-align: right"
                        ValidationGroup="vrRequestExecution"
                        MaxLength="12"
                        onblur="return script_vrRequestExecution.Validate_Distance(this); dc(this,2);"
                        onfocus="return this.select();"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_EstimatedRatePerKM" runat="server" Text="Rate Per Kg :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_EstimatedRatePerKM"
                        Text='<%# Bind("EstimatedRatePerKM") %>'
                        Width="100px"
                        CssClass="mytxt"
                        Style="text-align: right"
                        ValidationGroup="vrRequestExecution"
                        MaxLength="10"
                        onblur="return script_vrRequestExecution.Validate_RatePerKM(this); dc(this,2);"
                        onfocus="return this.select();"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_EstimatedAmount" runat="server" Text="Amount :" /></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_EstimatedAmount"
                        Text='<%# Bind("EstimatedAmount") %>'
                        Width="100px"
                        CssClass="mytxt"
                        Style="text-align: right"
                        ValidationGroup="vrRequestExecution"
                        MaxLength="14"
                        onfocus="return this.select();"
                        runat="server" />
                      <AJX:MaskedEditExtender
                        ID="MEEEstimatedAmount"
                        runat="server"
                        Mask="999999999999.99"
                        AcceptNegative="Left"
                        MaskType="Number"
                        MessageValidatorTip="true"
                        InputDirection="RightToLeft"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_EstimatedAmount" />
                      <AJX:MaskedEditValidator
                        ID="MEVEstimatedAmount"
                        runat="server"
                        ControlToValidate="F_EstimatedAmount"
                        ControlExtender="MEEEstimatedAmount"
                        InvalidValueMessage="!!!"
                        EmptyValueMessage="*"
                        EmptyValueBlurredText="[Required!]"
                        Display="Dynamic"
                        TooltipMessage="Enter value for Amount."
                        EnableClientScript="true"
                        ValidationGroup="vrRequestExecution"
                        IsValidEmpty="false"
                        MinimumValue="0.01"
                        MinimumValueBlurredText="[Required]"
                        MinimumValueMessage="*"
                        SetFocusOnError="true" />
                      <input type="button" id='<%# Eval("SRNNo") %>' value=". . ." onclick="return script_vrRequestExecution.Validate_Balance(this);" />
                      <span id="lblBal" class="dmymsg" style="z-index: 1000; position: absolute"></span>
                    </td>
                    <td colspan="2"></td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <table width="100%">
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" /></b>
                          </td>
                          <td colspan="3">
                            <asp:TextBox ID="F_Remarks"
                              Text='<%# Bind("Remarks") %>'
                              Width="350px" Height="40px" TextMode="MultiLine"
                              CssClass="mytxt"
                              onfocus="return this.select();"
                              ValidationGroup="vrRequestExecution"
                              onblur="this.value=this.value.replace(/\'/g,'');"
                              ToolTip="Enter value for Remarks."
                              MaxLength="500"
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ArrangedBy" runat="server" Text="Arranged By :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_ArrangedBy"
                              Width="56px"
                              Text='<%# Bind("ArrangedBy") %>'
                              Enabled="False"
                              ToolTip="Value of Arranged By."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_ArrangedBy_Display"
                              Text='<%# Eval("aspnet_Users1_UserFullName") %>'
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_ArrangedOn" runat="server" Text="Arranged On :" /></b>
                          </td>
                          <td>
                            <asp:TextBox ID="F_ArrangedOn"
                              Text='<%# Bind("ArrangedOn") %>'
                              ToolTip="Value of Arranged On."
                              Enabled="False"
                              Width="140px"
                              CssClass="dmytxt"
                              runat="server" />
                          </td>
                        </tr>
                        <tr>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_TraficOfficerDivisionID" runat="server" Text="Trafic Officer Division :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_TraficOfficerDivisionID"
                              Width="42px"
                              Text='<%# Bind("TraficOfficerDivisionID") %>'
                              Enabled="False"
                              ToolTip="Value of Trafic Officer Division."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_TraficOfficerDivisionID_Display"
                              Text='<%# Eval("HRM_Divisions4_Description") %>'
                              runat="Server" />
                          </td>
                          <td class="alignright">
                            <b>
                              <asp:Label ID="L_RequestStatusID" runat="server" Text="Request Status :" /></b>
                          </td>
                          <td>
                            <asp:TextBox
                              ID="F_RequestStatusID"
                              Width="70px"
                              Text='<%# Bind("RequestStatusID") %>'
                              Enabled="False"
                              ToolTip="Value of Request Status."
                              CssClass="dmyfktxt"
                              runat="Server" />
                            <asp:Label
                              ID="F_RequestStatusID_Display"
                              Text='<%# Eval("VR_RequestStates6_Description") %>'
                              runat="Server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                    <td colspan="2">
                      <table width="100%">
                        <tr>
                          <td>
                            <asp:UpdatePanel ID="UPNLvrExecutionAttachments" runat="server">
                              <ContentTemplate>
                                <table width="500px">
                                  <tr>
                                    <td class="sis_formview">
                                      <table id="F_Upload" runat="server" visible="<%# Editable %>">
                                        <tr>
                                          <td>
                                            <asp:Label ID="L_FileUpload" runat="server" Font-Bold="true" Text="Attatch File :"></asp:Label>
                                          </td>
                                          <td>
                                            <asp:FileUpload ID="F_FileUpload" runat="server" Width="200px" ToolTip="Attatch File" />
                                          </td>
                                          <td>
                                            <asp:Button ID="cmdFileUpload" Text="Upload File" runat="server" ToolTip="Click to attatch file." CommandName="Upload" CommandArgument="" />
                                          </td>
                                        </tr>
                                      </table>
                                      <LGM:AttachmentBar
                                        ID="TBLvrExecutionAttachments"
                                        ToolType="lgNMGrid"
                                        EditUrl="~/VR_Main/App_Edit/EF_vrExecutionAttachments.aspx"
                                        AddPostBack="True"
                                        EnableExit="false"
                                        ValidationGroup="vrExecutionAttachments"
                                        AttachVisible="false"
                                        Skin="tbl_blue"
                                        runat="server" />
                                      <asp:UpdateProgress ID="UPGSvrExecutionAttachments" runat="server" AssociatedUpdatePanelID="UPNLvrExecutionAttachments" DisplayAfter="100">
                                        <ProgressTemplate>
                                          <span style="color: #ff0033">Loading...</span>
                                        </ProgressTemplate>
                                      </asp:UpdateProgress>
                                      <asp:GridView ID="GVvrExecutionAttachments" SkinID="gv_silver" BorderColor="#A9A9A9" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrExecutionAttachments" DataKeyNames="SRNNo,SerialNo">
                                        <Columns>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                              <table>
                                                <tr>
                                                  <td>
                                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
                                                </tr>
                                              </table>
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="SerialNo" SortExpression="SerialNo">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="alignright" />
                                            <ItemStyle CssClass="alignright" />
                                            <HeaderStyle Width="40px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                            <ItemTemplate>
                                              <asp:LinkButton ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>' OnClientClick='<%# Eval("GetLink") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="400px" />
                                          </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                                        </EmptyDataTemplate>
                                      </asp:GridView>
                                      <asp:ObjectDataSource
                                        ID="ODSvrExecutionAttachments"
                                        runat="server"
                                        DataObjectTypeName="SIS.VR.vrExecutionAttachments"
                                        OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="vrExecutionAttachmentsSelectList"
                                        TypeName="SIS.VR.vrExecutionAttachments"
                                        SelectCountMethod="vrExecutionAttachmentsSelectCount"
                                        SortParameterName="OrderBy" EnablePaging="True">
                                        <SelectParameters>
                                          <asp:ControlParameter ControlID="F_SRNNo" PropertyName="Text" Name="SRNNo" Type="Int32" Size="10" />
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
                                <asp:AsyncPostBackTrigger ControlID="GVvrExecutionAttachments" EventName="PageIndexChanged" />
                                <asp:PostBackTrigger ControlID="cmdFileUpload" />
                              </Triggers>
                            </asp:UpdatePanel>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="text-align: center">
                      <br />
                      <table style="width: 96%">
                        <tr>
                          <td>
                            <asp:UpdatePanel ID="UPNLvrLinkedRequest" runat="server">
                              <ContentTemplate>
                                <table width="100%">
                                  <tr>
                                    <td>
                                      <LGM:PageSearchBar
                                        ID="TBLvrLinkedRequest"
                                        EditUrl="~/VR_Main/App_Edit/EF_vrLinkedRequest.aspx"
                                        BarText="Selected Vehicle Requests"
                                        SearchValidationGroup="linked"
                                        runat="server" />
                                      <asp:UpdateProgress ID="UPGSvrLinkedRequest" runat="server" AssociatedUpdatePanelID="UPNLvrLinkedRequest" DisplayAfter="100">
                                        <ProgressTemplate>
                                          <span style="color: #ff0033">Loading...</span>
                                        </ProgressTemplate>
                                      </asp:UpdateProgress>
                                      <asp:GridView ID="GVvrLinkedRequest" SkinID="gv_silver" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrLinkedRequest" DataKeyNames="RequestNo">
                                        <Columns>
                                          <asp:TemplateField HeaderText="EDIT">
                                            <ItemTemplate>
                                               <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="30px" CssClass="alignCenter" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Req.No" SortExpression="RequestNo">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
                                              <asp:Label ID="Label1" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("ERPPONumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="alignCenter" Width="40px" />
                                            <ItemStyle CssClass="alignCenter" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Request Description" SortExpression="RequestDescription">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelRequestDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Supplier ID" SortExpression="IDM_Vendors5_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects4_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Project Type" SortExpression="ProjectType">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelProjectType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VR_VehicleTypes9_cmba">
                                            <ItemTemplate>
                                              <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes9_cmba") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vehicle Required On" SortExpression="VehicleRequiredOn">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelVehicleRequiredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRequiredOn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="80px" />
                                          </asp:TemplateField>
<%--                                          <asp:TemplateField HeaderText="Request Status" SortExpression="VR_RequestStates7_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_RequestStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatus") %>' Text='<%# Eval("VR_RequestStates7_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Delink Request">
                                            <ItemTemplate>
                                              <asp:ImageButton ID="cmdRejectWF" ValidationGroup='<%# "Reject" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("RejectWFVisible") %>' Enabled='<%# EVal("RejectWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delink Request" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Reject" & Container.DataItemIndex & """) && confirm(""Delink Request record ?"");" %>' CommandName="RejectWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="30px" CssClass="alignCenter" />
                                          </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                                        </EmptyDataTemplate>
                                      </asp:GridView>
                                      <asp:ObjectDataSource
                                        ID="ODSvrLinkedRequest"
                                        runat="server"
                                        DataObjectTypeName="SIS.VR.vrLinkedRequest"
                                        OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="vrLinkedRequestSelectList"
                                        TypeName="SIS.VR.vrLinkedRequest"
                                        SelectCountMethod="vrLinkedRequestSelectCount"
                                        SortParameterName="OrderBy" EnablePaging="True">
                                        <SelectParameters>
                                          <asp:ControlParameter ControlID="F_SRNNo" PropertyName="Text" Name="SRNNo" Type="Int32" Size="10" />
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
                                <asp:AsyncPostBackTrigger ControlID="GVvrLinkedRequest" EventName="PageIndexChanged" />
                              </Triggers>
                            </asp:UpdatePanel>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <br />
                            <br />
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <asp:UpdatePanel ID="UPNLvrUnLinkedRequest" runat="server">
                              <ContentTemplate>
                                <table width="100%">
                                  <tr>
                                    <td>
                                      <LGM:PageSearchBar
                                        ID="TBLvrUnLinkedRequest"
                                        EditUrl="~/VR_Main/App_Edit/EF_vrUnLinkedRequest.aspx"
                                        BarText="Pending Vehicle Request"
                                        Skin="tbl_blue"
                                        SearchValidationGroup="unlinked"
                                        runat="server" />
                                      <asp:UpdateProgress ID="UPGSvrUnLinkedRequest" runat="server" AssociatedUpdatePanelID="UPNLvrUnLinkedRequest" DisplayAfter="100">
                                        <ProgressTemplate>
                                          <span style="color: #ff0033">Loading...</span>
                                        </ProgressTemplate>
                                      </asp:UpdateProgress>
                                      <asp:GridView ID="GVvrUnLinkedRequest" SkinID="gv_silver" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrUnLinkedRequest" DataKeyNames="RequestNo">
                                        <Columns>
                                          <asp:TemplateField HeaderText="EDIT">
                                            <ItemTemplate>
                                              <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="30px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Req.No" SortExpression="RequestNo">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelRequestNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestNo") %>'></asp:Label>
                                              <asp:Label ID="Label1" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("ERPPONumber") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="alignCenter" Width="40px" />
                                            <ItemStyle CssClass="alignCenter" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Request Description" SortExpression="RequestDescription">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelRequestDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequestDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Supplier ID" SortExpression="IDM_Vendors5_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_SupplierID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SupplierID") %>' Text='<%# Eval("IDM_Vendors5_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Project ID" SortExpression="IDM_Projects4_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_ProjectID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ProjectID") %>' Text='<%# Eval("IDM_Projects4_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Project Type" SortExpression="ProjectType">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelProjectType" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ProjectType") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Item Description" SortExpression="ItemDescription">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelItemDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vehicle Type ID" SortExpression="VR_VehicleTypes9_cmba">
                                            <ItemTemplate>
                                              <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes9_cmba") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="200px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Vehicle Required On" SortExpression="VehicleRequiredOn">
                                            <ItemTemplate>
                                              <asp:Label ID="LabelVehicleRequiredOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehicleRequiredOn") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="80px" />
                                          </asp:TemplateField>
<%--                                          <asp:TemplateField HeaderText="Request Status" SortExpression="VR_RequestStates7_Description">
                                            <ItemTemplate>
                                              <asp:Label ID="L_RequestStatus" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatus") %>' Text='<%# Eval("VR_RequestStates7_Description") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="100px" />
                                          </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Link Request">
                                            <ItemTemplate>
                                              <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Link Request" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && confirm(""Link Request record ?"");" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                            </ItemTemplate>
                                            <ItemStyle CssClass="alignCenter" />
                                            <HeaderStyle Width="30px" CssClass="alignCenter" />
                                          </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                          <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                                        </EmptyDataTemplate>
                                      </asp:GridView>
                                      <asp:ObjectDataSource
                                        ID="ODSvrUnLinkedRequest"
                                        runat="server"
                                        DataObjectTypeName="SIS.VR.vrUnLinkedRequest"
                                        OldValuesParameterFormatString="original_{0}"
                                        SelectMethod="UZ_vrUnLinkedRequestSelectList"
                                        TypeName="SIS.VR.vrUnLinkedRequest"
                                        SelectCountMethod="vrUnLinkedRequestSelectCount"
                                        SortParameterName="OrderBy" EnablePaging="True">
                                        <SelectParameters>
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
                                <asp:AsyncPostBackTrigger ControlID="GVvrUnLinkedRequest" EventName="PageIndexChanged" />
                              </Triggers>
                            </asp:UpdatePanel>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
              </div>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSvrRequestExecution"
        DataObjectTypeName="SIS.VR.vrRequestExecution"
        SelectMethod="UZ_vrRequestExecutionGetByID"
        UpdateMethod="UZ_vrRequestExecutionUpdate"
        DeleteMethod="UZ_vrRequestExecutionDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.VR.vrRequestExecution"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="SRNNo" Name="SRNNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
