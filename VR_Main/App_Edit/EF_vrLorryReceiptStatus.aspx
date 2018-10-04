<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrLorryReceiptStatus.aspx.vb" Inherits="EF_vrLorryReceiptStatus" title="Edit: Lorry Receipt Status" %>
<asp:Content ID="CPHvrLorryReceiptStatus" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrLorryReceiptStatus" runat="server" Text="&nbsp;Edit: Lorry Receipt Status"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrLorryReceiptStatus" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrLorryReceiptStatus"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrLorryReceiptStatus"
    runat = "server" />
<asp:FormView ID="FVvrLorryReceiptStatus"
  runat = "server"
  DataKeyNames = "LRStatusID"
  DataSourceID = "ODSvrLorryReceiptStatus"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_LRStatusID" runat="server" ForeColor="#CC6633" Text="Lorry Receipt Status ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_LRStatusID"
            Text='<%# Bind("LRStatusID") %>'
            ToolTip="Value of Lorry Receipt Status ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="70px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrLorryReceiptStatus"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrLorryReceiptStatus"
  DataObjectTypeName = "SIS.VR.vrLorryReceiptStatus"
  SelectMethod = "vrLorryReceiptStatusGetByID"
  UpdateMethod="vrLorryReceiptStatusUpdate"
  DeleteMethod="vrLorryReceiptStatusDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrLorryReceiptStatus"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="LRStatusID" Name="LRStatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
