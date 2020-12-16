<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_vrFreightBudgetProject.aspx.vb" Inherits="AF_vrFreightBudgetProject" title="Add: Freight Budget Project" %>
<asp:Content ID="CPHvrFreightBudgetProject" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelvrFreightBudgetProject" runat="server" Text="&nbsp;Add: Freight Budget Project"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLvrFreightBudgetProject" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLvrFreightBudgetProject"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "vrFreightBudgetProject"
    runat = "server" />
<asp:FormView ID="FVvrFreightBudgetProject"
  runat = "server"
  DataKeyNames = "ProjectID"
  DataSourceID = "ODSvrFreightBudgetProject"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage" style="min-height:250px;">
    <asp:Label ID="L_ErrMsgvrFreightBudgetProject" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ProjectID" ForeColor="#CC6633" runat="server" Text="Project ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ProjectID"
            CssClass = "mypktxt"
            Width="56px"
            Text='<%# Bind("ProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Project ID."
            ValidationGroup = "vrFreightBudgetProject"
            onblur= "script_vrFreightBudgetProject.validate_ProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVProjectID"
            runat = "server"
            ControlToValidate = "F_ProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrFreightBudgetProject"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ProjectID_Display"
            Text='<%# Eval("IDM_Projects2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEProjectID"
            BehaviorID="B_ACEProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ProjectIDCompletionList"
            TargetControlID="F_ProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrFreightBudgetProject.ACEProjectID_Selected"
            OnClientPopulating="script_vrFreightBudgetProject.ACEProjectID_Populating"
            OnClientPopulated="script_vrFreightBudgetProject.ACEProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FreightBudgetProjectID" runat="server" Text="Freight Budget From Project :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FreightBudgetProjectID"
            CssClass = "myfktxt"
            Width="56px"
            Text='<%# Bind("FreightBudgetProjectID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Freight Budget From Project."
            ValidationGroup = "vrFreightBudgetProject"
            onblur= "script_vrFreightBudgetProject.validate_FreightBudgetProjectID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFreightBudgetProjectID"
            runat = "server"
            ControlToValidate = "F_FreightBudgetProjectID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "vrFreightBudgetProject"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FreightBudgetProjectID_Display"
            Text='<%# Eval("IDM_Projects3_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFreightBudgetProjectID"
            BehaviorID="B_ACEFreightBudgetProjectID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FreightBudgetProjectIDCompletionList"
            TargetControlID="F_FreightBudgetProjectID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_vrFreightBudgetProject.ACEFreightBudgetProjectID_Selected"
            OnClientPopulating="script_vrFreightBudgetProject.ACEFreightBudgetProjectID_Populating"
            OnClientPopulated="script_vrFreightBudgetProject.ACEFreightBudgetProjectID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrFreightBudgetProject"
  DataObjectTypeName = "SIS.VR.vrFreightBudgetProject"
  InsertMethod="vrFreightBudgetProjectInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrFreightBudgetProject"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
