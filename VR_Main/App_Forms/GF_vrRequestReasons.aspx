<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_vrRequestReasons.aspx.vb" Inherits="GF_vrRequestReasons" title="Maintain List: Executer Reason" %>
<asp:Content ID="CPHvrRequestReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrRequestReasons" runat="server">
  <ContentTemplate>
    <asp:Label ID="LabelvrRequestReasons" runat="server" Text="&nbsp;List: Executer Reason" Width="100%" CssClass="sis_formheading"></asp:Label>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLvrRequestReasons"
      ToolType = "lgNMGrid"
      EditUrl = "~/VR_Main/App_Edit/EF_vrRequestReasons.aspx"
      AddUrl = "~/VR_Main/App_Create/AF_vrRequestReasons.aspx"
      ValidationGroup = "vrRequestReasons"
      Skin = "tbl_blue"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSvrRequestReasons" runat="server" AssociatedUpdatePanelID="UPNLvrRequestReasons" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVvrRequestReasons" SkinID="gv_silver" BorderColor="#A9A9A9" width="100%" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="ODSvrRequestReasons" DataKeyNames="ReasonID">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
						<Table><tr>
              <td><asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' /></td>
						</tr></Table>
          </ItemTemplate>
          <HeaderStyle Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reason ID" SortExpression="ReasonID">
          <ItemTemplate>
            <asp:Label ID="LabelReasonID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ReasonID") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle CssClass="alignright" />
          <ItemStyle CssClass="alignright" />
          <HeaderStyle Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Description" SortExpression="Description">
          <ItemTemplate>
            <asp:Label ID="LabelDescription" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Description") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transporter" SortExpression="Transporter">
          <ItemTemplate>
            <asp:Label ID="LabelTransporter" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Transporter") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ISGEC" SortExpression="ISGEC">
          <ItemTemplate>
            <asp:Label ID="LabelISGEC" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ISGEC") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Supplier" SortExpression="Supplier">
          <ItemTemplate>
            <asp:Label ID="LabelSupplier" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Supplier") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Other" SortExpression="Other">
          <ItemTemplate>
            <asp:Label ID="LabelOther" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Other") %>'></asp:Label>
          </ItemTemplate>
        <HeaderStyle Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSvrRequestReasons"
      runat = "server"
      DataObjectTypeName = "SIS.VR.vrRequestReasons"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "vrRequestReasonsSelectList"
      TypeName = "SIS.VR.vrRequestReasons"
      SelectCountMethod = "vrRequestReasonsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
				<asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
				<asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVvrRequestReasons" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</asp:Content>
