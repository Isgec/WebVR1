<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrGroups.aspx.vb" Inherits="EF_vrGroups" title="Edit: Groups" %>
<asp:Content ID="CPHvrGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrGroups" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrGroups" runat="server" Text="&nbsp;Edit: Groups" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrGroups"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrGroups.aspx?pk="
    ValidationGroup = "vrGroups"
    Skin = "tbl_blue"
    runat = "server" />
    <script type="text/javascript">
      var pcnt = 0;
      function print_report(o) {
        pcnt = pcnt + 1;
        var nam = 'wTask' + pcnt;
        var url = self.location.href.replace('App_Forms/GF_','App_Print/RP_');
        url = url + '?pk=' + o.alt;
        url = o.alt;
        window.open(url, nam, 'left=20,top=20,width=1000,height=600,toolbar=1,resizable=1,scrollbars=1');
        return false;
      }
    </script>
<asp:FormView ID="FVvrGroups"
	runat = "server"
	DataKeyNames = "GroupID"
	DataSourceID = "ODSvrGroups"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GroupID" runat="server" ForeColor="#CC6633" Text="Group ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GroupID"
						Text='<%# Bind("GroupID") %>'
            ToolTip="Value of Group ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_GroupName" runat="server" Text="Group Name :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_GroupName"
						Text='<%# Bind("GroupName") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Group Name."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVGroupName"
						runat = "server"
						ControlToValidate = "F_GroupName"
						Text = "Group Name is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrGroups"
						SetFocusOnError="true" />
				</td>
			</tr>
		</table>
	<br />
	</EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSvrGroups"
  DataObjectTypeName = "SIS.VR.vrGroups"
  SelectMethod = "vrGroupsGetByID"
  UpdateMethod="vrGroupsUpdate"
  DeleteMethod="vrGroupsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrGroups"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
