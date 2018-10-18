<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrRequestExecution.aspx.vb" Inherits="GF_vrRequestExecution" title="Maintain List: Request Execution" %>
<asp:Content ID="CPHvrRequestExecution" ContentPlaceHolderID="cph1" runat="Server">
  <div class="ui-widget-content page">
    <div class="caption">
      <asp:Label ID="LabeltaApprovalWFTypes" runat="server" Text="&nbsp;List: Request Execution"></asp:Label>
    </div>
    <div class="pagedata">
      <asp:UpdatePanel ID="UPNLvrRequestExecution" runat="server">
        <ContentTemplate>
          <table width="100%">
            <tr>
              <td class="sis_formview">
                <LGM:ToolBar0
                  ID="TBLvrRequestExecution"
                  ToolType="lgNMGrid"
                  EditUrl="~/VR_Main/App_Edit/EF_vrRequestExecution.aspx"
                  AddUrl="~/VR_Main/App_Create/AF_vrRequestExecution.aspx?skip=1"
                  runat="server" />
                <asp:UpdateProgress ID="UPGSvrRequestExecution" runat="server" AssociatedUpdatePanelID="UPNLvrRequestExecution" DisplayAfter="100">
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
                          <asp:Label ID="L_TransporterID" runat="server" Text="Transporter :" /></b>
                      </td>
                      <td>
                        <asp:TextBox
                          ID="F_TransporterID"
                          CssClass="myfktxt"
                          Width="63px"
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
                          <asp:Label ID="L_VehicleTypeID" runat="server" Text="Vehicle Type :" /></b>
                      </td>
                      <td>
                        <LGM:LC_vrVehicleTypes
                          ID="F_VehicleTypeID"
                          SelectedValue=""
                          OrderBy="Description"
                          DataTextField="Description"
                          DataValueField="VehicleTypeID"
                          IncludeDefault="true"
                          DefaultText="-- Select --"
                          Width="200px"
                          AutoPostBack="true"
                          RequiredFieldErrorMessage=""
                          CssClass="myddl"
                          runat="Server" />
                      </td>
                    </tr>
                  </table>
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
                <asp:GridView ID="GVvrRequestExecution" SkinID="gv_silver" Width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestExecution" DataKeyNames="SRNNo">
                  <Columns>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle cssClass="alignCenter" />
                      <HeaderStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdPrintPage" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Print the record." SkinID="Print" OnClientClick="return print_report(this);" />
                      </ItemTemplate>
                      <ItemStyle cssClass="alignCenter" />
                      <HeaderStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SR.NO" SortExpression="SRNNo">
                      <ItemTemplate>
                        <asp:Label ID="LabelSRNNo" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("SRNNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TRANSPORTER" SortExpression="VR_Transporters10_TransporterName">
                      <ItemTemplate>
                        <asp:Label ID="L_TransporterID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransporterID") %>' Text='<%# Eval("VR_Transporters10_TransporterName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VEHICLE" SortExpression="VR_VehicleTypes13_cmba">
                      <ItemTemplate>
                        <asp:Label ID="L_VehicleTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("VehicleTypeID") %>' Text='<%# Eval("VR_VehicleTypes13_cmba") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PLACED ON" SortExpression="VehiclePlacedOn">
                      <ItemTemplate>
                        <asp:Label ID="LabelVehiclePlacedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VehiclePlacedOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>
<%--                    <asp:TemplateField HeaderText="GR NO" SortExpression="GRNo">
                      <ItemTemplate>
                        <asp:Label ID="LabelGRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRNo") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="GR DATE" SortExpression="GRDate">
                      <ItemTemplate>
                        <asp:Label ID="LabelGRDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("GRDate") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="80px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Sanction Balance" SortExpression="">
                      <ItemTemplate>
                        <asp:Label ID="L_SanctionBalance" runat="server" ForeColor='<%# EVal("SanctionColor") %>' Title='<%# EVal("POValue") %>' Text='<%# Eval("SanctionBalance") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="STATUS" SortExpression="VR_RequestStates6_Description">
                      <ItemTemplate>
                        <asp:Label ID="L_RequestStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("RequestStatusID") %>' Text='<%# Eval("VR_RequestStates6_Description") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle VerticalAlign="Top" />
                      <HeaderStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LINK EXECUTIONS">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdLink" runat="server" Visible='<%# EVal("LinkVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to Link Executions." SkinID="link" OnClientClick='<%# "return lc_getLink.getLink(""" & EVal("SRNNo") & """,this);" %>' CommandName="LinkExecution" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle cssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CONFIRM VEHICLE">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send Confirmation by E-Mail" SkinID="forward" OnClientClick='<%# "return confirm(""Vehicle Requester and Transporter will be notified through E-Mail. Continue ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VEHICLE PLACED">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdVehiclePlacedWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("VehiclePlacedWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Click to update CT, when Vehicle is arrived at Supplier's Location." SkinID="revise" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && confirm(""Update CT for Vehicle Placed Activity ?"");" %>' CommandName="VehiclePlacedWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter"/>
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CANCEL VEHICLE">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdCancleWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CancelWFVisible") %>' Enabled='<%# EVal("CancelWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="It will cancel Vehicle Arrangement & Send Cancillation Noficationirmation by E-Mail" SkinID="reject" OnClientClick='<%# "return Page_ClientValidate(""Cancel" & Container.DataItemIndex & """) && confirm(""GR entry will be cleared and Vehicle Requester and Transporter will be notified through E-Mail. Continue ?"");" %>' CommandName="CancelWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter"/>
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LINK GR">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdApproveWF" ValidationGroup='<%# "Approve" & Container.DataItemIndex %>' CausesValidation="false" runat="server" Visible='<%# EVal("ApproveWFVisible") %>' Enabled='<%# EVal("ApproveWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Link GR" SkinID="approve" OnClientClick='<%# "return Page_ClientValidate(""Approve" & Container.DataItemIndex & """) && lc_getGR.getGR(""" & EVal("SRNNo") & """,this);" %>' CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FOR APPROVAL">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdForApproval" runat="server" Visible='<%# EVal("ForApprovalVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Send for approval" SkinID="forapproval" CommandName="ForApproval" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TRANS SHIPMENT">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdCompleteWF" ValidationGroup='<%# "Complete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("CompleteWFVisible") %>' Enabled='<%# EVal("CompleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Trans Shipment" SkinID="complete" OnClientClick='<%# "return Page_ClientValidate(""Complete" & Container.DataItemIndex & """) && lc_getTransShip.getTransShip(""" & EVal("SRNNo") & """,this);" %>' CommandName="CompleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter"/>
                      <HeaderStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        </td></tr>
						            <tr style="background-color: AntiqueWhite; color: DeepPink">
                          <td colspan="8"></td>
                          <td colspan="8">
                            <asp:Label ID="LabelNotification" runat="server" Text='<%# Eval("Notification") %>'></asp:Label>
                          </td>
                        </tr>
                      </ItemTemplate>
                      <HeaderStyle Width="10px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSvrRequestExecution"
                  runat="server"
                  DataObjectTypeName="SIS.VR.vrRequestExecution"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_vrRequestExecutionSelectList"
                  TypeName="SIS.VR.vrRequestExecution"
                  SelectCountMethod="vrRequestExecutionSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="F_TransporterID" PropertyName="Text" Name="TransporterID" Type="String" Size="9" />
                    <asp:ControlParameter ControlID="F_VehicleTypeID" PropertyName="SelectedValue" Name="VehicleTypeID" Type="Int32" Size="10" />
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
          <%--
		<asp:AsyncPostBackTrigger ControlID="winGetGR" />
		<asp:AsyncPostBackTrigger ControlID="winGetTS" />
		<asp:AsyncPostBackTrigger ControlID="LC_LinkExecution1" />

          --%>
          <asp:AsyncPostBackTrigger ControlID="GVvrRequestExecution" EventName="PageIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="F_TransporterID" />
          <asp:AsyncPostBackTrigger ControlID="F_VehicleTypeID" />
        </Triggers>
      </asp:UpdatePanel>
    </div>
  </div>
  <LGM:LC_vrGetGR ID="winGetGR" runat="server" />
  <LGM:LC_vrTransShip ID="winGetTS" runat="server" />
  <LGM:LC_LinkExecution ID="LC_LinkExecution1" runat="server" />

</asp:Content>
