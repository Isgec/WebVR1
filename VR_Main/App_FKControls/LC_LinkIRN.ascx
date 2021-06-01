<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_LinkIRN.ascx.vb" Inherits="LC_LinkIRN" %>
<style>
  .x-div{
    font-family:Tahoma;
    font-size:12px;
  }
  .x-tbl{
    width:100%;
  }
  .x-h-tbl{
      font-weight:bold;
      color:white;
      background-color:#2f77f7;
  }
  .x-d1-tbl{
      /*color:black;
      background-color:white;*/
      color:green;
  }
  .x-d2-tbl{
      /*color:black;
      background-color:#cccaca;*/
      color:crimson;
  }
</style>
<asp:UpdatePanel runat="server">
  <ContentTemplate>
    <asp:Panel ID="pnl1" runat="server" Style="background-color: white; display: none; height: 450px; border-radius: 6px;" Width='800px'>
      <asp:Panel ID="pnlHeader" runat="server" Style="width: 100%; padding-top: 8px; text-align: center; border-bottom: 1pt solid lightgray;">
        <asp:Label ID="HeaderText" runat="server" Font-Size="16px" Font-Bold="true" Text='My Modal Text'></asp:Label>
        <div id="divGRInfo" runat="server">
        </div>
        <asp:CheckBox ID="F_ShowAll" runat="server" Font-Bold="true" AutoPostBack="true" Text="Show All [Including Already Linked]: " OnCheckedChanged="F_ShowAll_CheckedChanged" TextAlign="Left" />
      </asp:Panel>
      <asp:Panel ID="modalContent" runat="server" Style="width: 98%; height: 300px; padding: 4px; overflow-y: scroll;">
        <asp:GridView ID="GVirnList" SkinID="gv_silver" Width="100%" runat="server" AllowPaging="False" AutoGenerateColumns="False" DataSourceID="ODSirnList" DataKeyNames="IRNO">
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Button ID="cmdSelect" runat="server" CssClass="nt-but-danger" ToolTip="Select IRN." Text="Select" CommandName="lgSelect" CommandArgument='<%# Container.DataItemIndex %>' />
              </ItemTemplate>
              <HeaderStyle Width="30px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IR No">
              <ItemTemplate>
                <asp:Label ID="LabelIRN" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("IRNO") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="40px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Supplier Ref">
              <ItemTemplate>
                <asp:Label ID="LabelSupplierName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("SupplierName") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignleft" />
              <HeaderStyle CssClass="alignleft" Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Transporter">
              <ItemTemplate>
                <asp:Label ID="LabelTransporterName" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# EVal("TransporterName") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignleft" />
              <HeaderStyle CssClass="alignleft" Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bill No">
              <ItemTemplate>
                <asp:Label ID="LabelBillNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("BillNo") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bill Date">
              <ItemTemplate>
                <asp:Label ID="LabelBillDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("BillDate") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GR No">
              <ItemTemplate>
                <asp:Label ID="LabelGRNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("GRNo") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="60px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GR Date">
              <ItemTemplate>
                <asp:Label ID="LabelGRDate" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# EVal("GRDate") %>'></asp:Label>
              </ItemTemplate>
              <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="60px" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
          </EmptyDataTemplate>
        </asp:GridView>
        <asp:ObjectDataSource
          ID="ODSirnList"
          runat="server"
          DataObjectTypeName="SIS.VR.irnList"
          OldValuesParameterFormatString="original_{0}"
          SelectMethod="SelectList"
          TypeName="SIS.VR.irnList"
          EnablePaging="False">
          <SelectParameters>
            <asp:ControlParameter ControlID="F_ShowAll" PropertyName="Checked" Name="ShowAll" Type="Boolean" DefaultValue="False" />
            <asp:Parameter Name="ProjectID" Type="String" Direction="Input" DefaultValue="" />
            <asp:Parameter Name="PONumber" Type="String" Direction="Input" DefaultValue="" />
            <asp:Parameter Name="SupplierID" Type="String" Direction="Input" DefaultValue="" />
            <asp:Parameter Name="TransporterID" Type="String" Direction="Input" DefaultValue="" />
            <asp:Parameter Name="BillNo" Type="String" Direction="Input" DefaultValue="" />
            <asp:Parameter Name="BillDate" Type="String" Direction="Input" DefaultValue="" />
          </SelectParameters>
        </asp:ObjectDataSource>
      </asp:Panel>
      <asp:Panel ID="pnlFooter" runat="server" Style="width: 100%; height: 33px; padding-top: 8px; text-align: right; border-top: 1pt solid lightgray;">
        <asp:Label ID="L_PrimaryKey" runat="server" Style="display: none;"></asp:Label>
        <asp:Button ID="cmdOK" runat="server" CssClass="nt-but-success" Width="70px" Text="OK" Style="text-align: center; margin-right: 30px;" />
        <asp:Button ID="cmdCancel" runat="server" CssClass="nt-but-danger" Width="70px" Text="Cancel" Style="text-align: center; margin-right: 30px;" />
      </asp:Panel>
    </asp:Panel>
    <asp:Button ID="dummy" runat="server" Style="display: none;" Text="show"></asp:Button>
    <AJX:ModalPopupExtender
      ID="mPopup"
      BehaviorID="myMPE1"
      TargetControlID="dummy"
      BackgroundCssClass="modalBackground"
      CancelControlID="cmdCancel"
      OkControlID="cmdCancel"
      PopupControlID="pnl1"
      DropShadow="true"
      runat="server">
    </AJX:ModalPopupExtender>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="cmdOK" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="F_ShowAll" EventName="CheckedChanged" />
  </Triggers>
</asp:UpdatePanel>


