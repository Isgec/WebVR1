<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrLorryReceiptStatus.aspx.vb" Inherits="AF_vrLorryReceiptStatus" title="Add: Lorry Receipt Status" %>
<asp:Content ID="CPHvrLorryReceiptStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceiptStatus" runat="server" Text="&nbsp;Add: Lorry Receipt Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptStatus" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceiptStatus"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrLorryReceiptStatus"
    runat = "server" />
<asp:FormView ID="FVvrLorryReceiptStatus"
  runat = "server"
  DataKeyNames = "LRStatusID"
  DataSourceID = "ODSvrLorryReceiptStatus"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgvrLorryReceiptStatus" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LRStatusID" ForeColor="#CC6633" runat="server" Text="Lorry Receipt Status ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_LRStatusID" Enabled="False" CssClass="mypktxt" width="70px" runat="server" Text="0" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceiptStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrLorryReceiptStatus"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLorryReceiptStatus"
  DataObjectTypeName = "SIS.VR.vrLorryReceiptStatus"
  InsertMethod="vrLorryReceiptStatusInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceiptStatus"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
