<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrBusinessPartner.aspx.vb" Inherits="EF_vrBusinessPartner" title="Edit: Business Partner" %>
<asp:Content ID="CPHvrBusinessPartner" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrBusinessPartner" runat="server" Text="&nbsp;Edit: Business Partner"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrBusinessPartner" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrBusinessPartner"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrBusinessPartner"
    runat = "server" />
<asp:FormView ID="FVvrBusinessPartner"
  runat = "server"
  DataKeyNames = "BPID"
  DataSourceID = "ODSvrBusinessPartner"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_BPID" runat="server" ForeColor="#CC6633" Text="Business Partner ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_BPID"
            Text='<%# Bind("BPID") %>'
            ToolTip="Value of Business Partner ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="63px"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_BPName" runat="server" Text="Business Partner Name :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_BPName"
            Text='<%# Bind("BPName") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="vrBusinessPartner"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Business Partner Name."
            MaxLength="100"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBPName"
            runat = "server"
            ControlToValidate = "F_BPName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrBusinessPartner"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Address1Line" runat="server" Text="Address Line [1] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Address1Line"
            Text='<%# Bind("Address1Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [1]."
            MaxLength="100"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Address2Line" runat="server" Text="Address Line [2] :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_Address2Line"
            Text='<%# Bind("Address2Line") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Address Line [2]."
            MaxLength="100"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_City" runat="server" Text="City :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_City"
            Text='<%# Bind("City") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for City."
            MaxLength="50"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_EMailID" runat="server" Text="E-Mail ID :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_EMailID"
            Text='<%# Bind("EMailID") %>'
            Width="350px" Height="40px" TextMode="MultiLine"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for E-Mail ID."
            MaxLength="200"
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
  ID = "ODSvrBusinessPartner"
  DataObjectTypeName = "SIS.VR.vrBusinessPartner"
  SelectMethod = "vrBusinessPartnerGetByID"
  UpdateMethod="UZ_vrBusinessPartnerUpdate"
  DeleteMethod="UZ_vrBusinessPartnerDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrBusinessPartner"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="BPID" Name="BPID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
