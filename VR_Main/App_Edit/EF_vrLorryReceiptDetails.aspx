<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLorryReceiptDetails.aspx.vb" Inherits="EF_vrLorryReceiptDetails" title="Edit: Site Receipt Details" %>
<asp:Content ID="CPHvrLorryReceiptDetails" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelvrLorryReceiptDetails" runat="server" Text="&nbsp;Edit: Site Receipt Details"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLvrLorryReceiptDetails" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLvrLorryReceiptDetails"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            ValidationGroup="vrLorryReceiptDetails"
            runat="server" />
          <asp:FormView ID="FVvrLorryReceiptDetails"
            runat="server"
            DataKeyNames="ProjectID,MRNNo,SerialNo"
            DataSourceID="ODSvrLorryReceiptDetails"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="margin: auto; border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color: red">*</span></b>
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_ProjectID"
                        Width="70px"
                        Text='<%# Bind("ProjectID") %>'
                        CssClass="mypktxt"
                        Enabled="False"
                        ToolTip="Value of Project ID."
                        runat="Server" />
                      <asp:Label
                        ID="F_ProjectID_Display"
                        Text='<%# Eval("IDM_Projects1_Description") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_MRNNo" runat="server" ForeColor="#CC6633" Text="MRN No :" /><span style="color: red">*</span></b>
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_MRNNo"
                        Width="70px"
                        Text='<%# Bind("MRNNo") %>'
                        CssClass="mypktxt"
                        Enabled="False"
                        ToolTip="Value of MRN No."
                        runat="Server" />
                      <asp:Label
                        ID="F_MRNNo_Display"
                        Text='<%# Eval("VR_LorryReceipts3_WayBillFormNo") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color: red">*</span></b>
                    </td>
                    <td>
                      <asp:TextBox ID="F_SerialNo"
                        Text='<%# Bind("SerialNo") %>'
                        ToolTip="Value of Serial No."
                        Enabled="False"
                        CssClass="mypktxt"
                        Width="70px"
                        Style="text-align: right"
                        runat="server" />
                    </td>
                    <td class="alignright">
                    </td>
                    <td>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="Label2" ForeColor="#CC6633" runat="server" Text="PO Number :" /><span style="color: red">*</span></b>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_PONumber"
                        Text='<%# Bind("PONumber") %>'
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        OnTextChanged="F_PONumber_TextChanged"
                        AutoPostBack="true"
                        ToolTip="Enter PO Number."
                        MaxLength="9"
                        Width="78px"
                        ClientIDMode="Static"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVPONumber"
                        runat="server"
                        ControlToValidate="F_PONumber"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" />
                    </td>
                    <td>
                      <asp:TextBox
                        ID="F_SupplierID"
                        CssClass="myfktxt"
                        Text='<%# Bind("SupplierID") %>'
                        AutoCompleteType="None"
                        Width="78px"
                        onfocus="return this.select();"
                        ToolTip="Enter value for Supplier ID."
                        ValidationGroup="vrLorryReceiptDetails"
                        onblur="script_vrLorryReceiptDetails.validate_SupplierID(this);"
                        runat="Server" />
                      <asp:Label
                        ID="F_SupplierID_Display"
                        Text='<%# Eval("VR_BusinessPartner2_BPName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                      <AJX:AutoCompleteExtender
                        ID="ACESupplierID"
                        BehaviorID="B_ACESupplierID"
                        ContextKey=""
                        UseContextKey="true"
                        ServiceMethod="SupplierIDCompletionList"
                        TargetControlID="F_SupplierID"
                        EnableCaching="false"
                        CompletionInterval="100"
                        FirstRowSelected="true"
                        MinimumPrefixLength="1"
                        OnClientItemSelected="script_vrLorryReceiptDetails.ACESupplierID_Selected"
                        OnClientPopulating="script_vrLorryReceiptDetails.ACESupplierID_Populating"
                        OnClientPopulated="script_vrLorryReceiptDetails.ACESupplierID_Populated"
                        CompletionSetCount="10"
                        CompletionListCssClass="autocomplete_completionListElement"
                        CompletionListItemCssClass="autocomplete_listItem"
                        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                        runat="Server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_SupplierName"
                        Text='<%# Bind("SupplierName") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Supplier Name."
                        MaxLength="50"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="Label1" runat="server" Text="Link ERP IRN :" /><span style="color: red">*</span></b>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_IRNO"
                        Text='<%# Bind("IRNO") %>'
                        ToolTip="Select IR No from List."
                        Enabled="False"
                        CssClass="dmytxt"
                        Width="78px"
                        ClientIDMode="Static"
                        Style="text-align: right"
                        runat="server" />
                      <asp:Button ID="cmdShowIRN" runat="server" CssClass="nt-but-danger" Text="Show IRN List" OnClick="cmdShowIRN_Click" />
                      <asp:Button ID="cmdDelink" runat="server" CssClass="nt-but-primary" Text="Delink IRN" OnClientClick="$get('F_IRNO').value='';false;" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierInvoiceNo" runat="server" Text="Supplier Invoice No :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_SupplierInvoiceNo"
                        Text='<%# Bind("SupplierInvoiceNo") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceiptDetails"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Supplier Invoice No."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVSupplierInvoiceNo"
                        runat="server"
                        ControlToValidate="F_SupplierInvoiceNo"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_SupplierInvoiceDate" runat="server" Text="Supplier Invoice Date :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_SupplierInvoiceDate"
                        Text='<%# Bind("SupplierInvoiceDate") %>'
                        Width="80px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceiptDetails"
                        runat="server" />
                      <asp:Image ID="ImageButtonSupplierInvoiceDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CESupplierInvoiceDate"
                        TargetControlID="F_SupplierInvoiceDate"
                        Format="dd/MM/yyyy"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonSupplierInvoiceDate" />
                      <AJX:MaskedEditExtender
                        ID="MEESupplierInvoiceDate"
                        runat="server"
                        Mask="99/99/9999"
                        MaskType="Date"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_SupplierInvoiceDate" />
                      <AJX:MaskedEditValidator
                        ID="MEVSupplierInvoiceDate"
                        runat="server"
                        ControlToValidate="F_SupplierInvoiceDate"
                        ControlExtender="MEESupplierInvoiceDate"
                        EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_GRorLRNo" runat="server" Text="GR / LR No :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_GRorLRNo"
                        Text='<%# Bind("GRorLRNo") %>'
                        Width="350px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceiptDetails"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for GR / LR No."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVGRorLRNo"
                        runat="server"
                        ControlToValidate="F_GRorLRNo"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        SetFocusOnError="true" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_GRorLRDate" runat="server" Text="GR / LR Date :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:TextBox ID="F_GRorLRDate"
                        Text='<%# Bind("GRorLRDate") %>'
                        Width="80px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="vrLorryReceiptDetails"
                        runat="server" />
                      <asp:Image ID="ImageButtonGRorLRDate" runat="server" ToolTip="Click to open calendar" Style="cursor: pointer; vertical-align: bottom" ImageUrl="~/Images/cal.png" />
                      <AJX:CalendarExtender
                        ID="CEGRorLRDate"
                        TargetControlID="F_GRorLRDate"
                        Format="dd/MM/yyyy"
                        runat="server" CssClass="MyCalendar" PopupButtonID="ImageButtonGRorLRDate" />
                      <AJX:MaskedEditExtender
                        ID="MEEGRorLRDate"
                        runat="server"
                        Mask="99/99/9999"
                        MaskType="Date"
                        CultureName="en-GB"
                        MessageValidatorTip="true"
                        InputDirection="LeftToRight"
                        ErrorTooltipEnabled="true"
                        TargetControlID="F_GRorLRDate" />
                      <AJX:MaskedEditValidator
                        ID="MEVGRorLRDate"
                        runat="server"
                        ControlToValidate="F_GRorLRDate"
                        ControlExtender="MEEGRorLRDate"
                        EmptyValueBlurredText="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        IsValidEmpty="false"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_WeightAsPerInvoiceInKG" runat="server" Text="Weight as per Invoice [KG] :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_WeightAsPerInvoiceInKG"
                        Text='<%# Bind("WeightAsPerInvoiceInKG") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,0);"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_WeightReceived" runat="server" Text="Weight Received [KG] :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_WeightReceived"
                        Text='<%# Bind("WeightReceived") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,0);"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_MaterialForm" runat="server" Text="MaterialForm :" /><span style="color: red">*</span>
                    </td>
                    <td>
                      <asp:DropDownList
                        ID="F_MaterialForm"
                        SelectedValue='<%# Bind("MaterialForm") %>'
                        CssClass="myddl"
                        Width="200px"
                        ValidationGroup="vrLorryReceiptDetails"
                        runat="Server">
                        <asp:ListItem Value="">---Select---</asp:ListItem>
                        <asp:ListItem Value="Package">PACKAGE</asp:ListItem>
                        <asp:ListItem Value="Loose">LOOSE</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator
                        ID="RFVMaterialForm"
                        runat="server"
                        ControlToValidate="F_MaterialForm"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        SetFocusOnError="true" />
                    </td>
                    <td></td>
                    <td></td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_NoOfPackagesAsPerInvoice" runat="server" Text="No. of Packages as per Invoice :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_NoOfPackagesAsPerInvoice"
                        Text='<%# Bind("NoOfPackagesAsPerInvoice") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,0);"
                        runat="server" />
                    </td>
                    <td class="alignright">
                      <asp:Label ID="L_NoOfPackagesReceived" runat="server" Text="No. of Packages Received :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_NoOfPackagesReceived"
                        Text='<%# Bind("NoOfPackagesReceived") %>'
                        Style="text-align: right"
                        Width="70px"
                        CssClass="mytxt"
                        MaxLength="10"
                        onfocus="return this.select();"
                        onblur="return dc(this,0);"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CenvatInvoiceReceived" runat="server" Text="Cenvat Invoice Received :" /><span style="color: red">*</span>
                    </td>
                    <td colspan="3">
                      <asp:DropDownList
                        ID="F_CenvatInvoiceReceived"
                        SelectedValue='<%# Bind("CenvatInvoiceReceived") %>'
                        CssClass="myddl"
                        Width="200px"
                        ValidationGroup="vrLorryReceiptDetails"
                        runat="Server">
                        <asp:ListItem Value="">---Select---</asp:ListItem>
                        <asp:ListItem Value="YES">YES</asp:ListItem>
                        <asp:ListItem Value="NO">NO</asp:ListItem>
                        <asp:ListItem Value="NA">NA</asp:ListItem>
                      </asp:DropDownList>
                      <asp:RequiredFieldValidator
                        ID="RFVCenvatInvoiceReceived"
                        runat="server"
                        ControlToValidate="F_CenvatInvoiceReceived"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="vrLorryReceiptDetails"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
                    </td>
                    <td>
                      <asp:TextBox ID="F_Remarks"
                        Text='<%# Bind("Remarks") %>'
                        Width="350px" Height="40px" TextMode="MultiLine"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Remarks."
                        MaxLength="150"
                        runat="server" />
                    </td>
                    <td></td>
                    <td>
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                </table>
              </div>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSvrLorryReceiptDetails"
        DataObjectTypeName="SIS.VR.vrLorryReceiptDetails"
        SelectMethod="vrLorryReceiptDetailsGetByID"
        UpdateMethod="vrLorryReceiptDetailsUpdate"
        DeleteMethod="vrLorryReceiptDetailsDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.VR.vrLorryReceiptDetails"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="MRNNo" Name="MRNNo" Type="Int32" />
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
  <LGM:LC_LinkIRN ID="test" runat="server" />
</asp:Content>
