<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrFreightBudgetProject.aspx.vb" Inherits="EF_vrFreightBudgetProject" title="Edit: Freight Budget Project" %>
<asp:Content ID="CPHvrFreightBudgetProject" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrFreightBudgetProject" runat="server" Text="&nbsp;Edit: Freight Budget Project"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrFreightBudgetProject" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrFreightBudgetProject"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "vrFreightBudgetProject"
    runat = "server" />
<asp:FormView ID="FVvrFreightBudgetProject"
  runat = "server"
  DataKeyNames = "ProjectID"
  DataSourceID = "ODSvrFreightBudgetProject"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" runat="server" ForeColor="#CC6633" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
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
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FreightBudgetProjectID" runat="server" Text="Freight Budget From Project :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FreightBudgetProjectID"
            Width="56px"
            Text='<%# Bind("FreightBudgetProjectID") %>'
            Enabled = "False"
            ToolTip="Value of Freight Budget From Project."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_FreightBudgetProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td colspan="3">
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
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            Enabled = "False"
            CssClass = "dmychk"
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
  ID = "ODSvrFreightBudgetProject"
  DataObjectTypeName = "SIS.VR.vrFreightBudgetProject"
  SelectMethod = "vrFreightBudgetProjectGetByID"
  UpdateMethod="vrFreightBudgetProjectUpdate"
  DeleteMethod="vrFreightBudgetProjectDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrFreightBudgetProject"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ProjectID" Name="ProjectID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
