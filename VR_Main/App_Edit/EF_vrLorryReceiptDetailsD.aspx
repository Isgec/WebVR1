<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLorryReceiptDetailsD.aspx.vb" Inherits="EF_vrLorryReceiptDetailsD" title="Display: Site Receipt Details" %>
<asp:Content ID="CPHvrLorryReceiptDetailsD" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceiptDetailsD" runat="server" Text="&nbsp;Display: Site Receipt Details"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptDetailsD" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceiptDetailsD"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrLorryReceiptDetailsD"
    runat = "server" />
<asp:FormView ID="FVvrLorryReceiptDetailsD"
  runat = "server"
  DataKeyNames = "ProjectID,MRNNo,SerialNo"
  DataSourceID = "ODSvrLorryReceiptDetailsD"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ProjectID"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Project ID."
            Runat="Server" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects1_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_MRNNo" runat="server" ForeColor="#CC6633" Text="MRN No :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_MRNNo"
            Width="88px"
            Text='<%# Bind("MRNNo") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of MRN No."
            Runat="Server" />
          <asp:Label
            ID = "F_MRNNo_Display"
            Text='<%# Eval("VR_LorryReceipts3_WayBillFormNo") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Serial No :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
          <asp:Label ID="L_GRorLRNo" runat="server" Text="GR / LR No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRorLRNo"
            Text='<%# Bind("GRorLRNo") %>'
            ToolTip="Value of GR / LR No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GRorLRDate" runat="server" Text="GR / LR Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_GRorLRDate"
            Text='<%# Bind("GRorLRDate") %>'
            ToolTip="Value of GR / LR Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierID" runat="server" Text="Supplier ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_SupplierID"
            Width="80px"
            Text='<%# Bind("SupplierID") %>'
            Enabled = "False"
            ToolTip="Value of Supplier ID."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_SupplierID_Display"
            Text='<%# Eval("VR_BusinessPartner2_BPName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierName" runat="server" Text="Supplier Name :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierName"
            Text='<%# Bind("SupplierName") %>'
            ToolTip="Value of Supplier Name."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SupplierInvoiceNo" runat="server" Text="Supplier Invoice No :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierInvoiceNo"
            Text='<%# Bind("SupplierInvoiceNo") %>'
            ToolTip="Value of Supplier Invoice No."
            Enabled = "False"
            Width="408px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_SupplierInvoiceDate" runat="server" Text="Supplier Invoice Date :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_SupplierInvoiceDate"
            Text='<%# Bind("SupplierInvoiceDate") %>'
            ToolTip="Value of Supplier Invoice Date."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WeightAsPerInvoiceInKG" runat="server" Text="Weight as per Invoice [KG] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightAsPerInvoiceInKG"
            Text='<%# Bind("WeightAsPerInvoiceInKG") %>'
            ToolTip="Value of Weight as per Invoice [KG]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WeightReceived" runat="server" Text="Weight Received [KG] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_WeightReceived"
            Text='<%# Bind("WeightReceived") %>'
            ToolTip="Value of Weight Received [KG]."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_MaterialForm" runat="server" Text="MaterialForm :" />&nbsp;
        </td>
        <td>
          <asp:DropDownList
            ID="F_MaterialForm"
            SelectedValue='<%# Bind("MaterialForm") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="Package">PACKAGE</asp:ListItem>
            <asp:ListItem Value="Loose">LOOSE</asp:ListItem>
          </asp:DropDownList>
         </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NoOfPackagesAsPerInvoice" runat="server" Text="No. of Packages as per Invoice :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NoOfPackagesAsPerInvoice"
            Text='<%# Bind("NoOfPackagesAsPerInvoice") %>'
            ToolTip="Value of No. of Packages as per Invoice."
            Enabled = "False"
            Width="88px"
            CssClass = "dmytxt"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_NoOfPackagesReceived" runat="server" Text="No. of Packages Received :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_NoOfPackagesReceived"
            Text='<%# Bind("NoOfPackagesReceived") %>'
            ToolTip="Value of No. of Packages Received."
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
          <asp:Label ID="L_CenvatInvoiceReceived" runat="server" Text="Cenvat Invoice Received :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:DropDownList
            ID="F_CenvatInvoiceReceived"
            SelectedValue='<%# Bind("CenvatInvoiceReceived") %>'
            Width="200px"
            Enabled = "False"
            CssClass = "dmyddl"
            Runat="Server" >
            <asp:ListItem Value="">---Select---</asp:ListItem>
            <asp:ListItem Value="YES">YES</asp:ListItem>
            <asp:ListItem Value="NO">NO</asp:ListItem>
            <asp:ListItem Value="NA">NA</asp:ListItem>
          </asp:DropDownList>
         </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Remarks" runat="server" Text="Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Remarks"
            Text='<%# Bind("Remarks") %>'
            ToolTip="Value of Remarks."
            Enabled = "False"
            Width="350px" Height="40px"
            CssClass = "dmytxt"
            runat="server" />
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
  ID = "ODSvrLorryReceiptDetailsD"
  DataObjectTypeName = "SIS.VR.vrLorryReceiptDetailsD"
  SelectMethod = "vrLorryReceiptDetailsDGetByID"
  UpdateMethod="vrLorryReceiptDetailsDUpdate"
  DeleteMethod="vrLorryReceiptDetailsDDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceiptDetailsD"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="MRNNo" Name="MRNNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
