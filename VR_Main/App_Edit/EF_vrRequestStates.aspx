<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrRequestStates.aspx.vb" Inherits="EF_vrRequestStates" title="Edit: Request States" %>
<asp:Content ID="CPHvrRequestStates" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrRequestStates" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrRequestStates" runat="server" Text="&nbsp;Edit: Request States" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrRequestStates"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrRequestStates.aspx?pk="
    ValidationGroup = "vrRequestStates"
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
<asp:FormView ID="FVvrRequestStates"
	runat = "server"
	DataKeyNames = "StatusID"
	DataSourceID = "ODSvrRequestStates"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_StatusID" runat="server" ForeColor="#CC6633" Text="Status ID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_StatusID"
						Text='<%# Bind("StatusID") %>'
            ToolTip="Value of Status ID."
            Enabled = "False"
						CssClass = "mypktxt"
            Width="70px"
						style="text-align: right"
						runat="server" />
				</td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_Description" runat="server" Text="Description :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_Description"
						Text='<%# Bind("Description") %>'
            Width="210px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrRequestStates"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="30"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrRequestStates"
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
  ID = "ODSvrRequestStates"
  DataObjectTypeName = "SIS.VR.vrRequestStates"
  SelectMethod = "vrRequestStatesGetByID"
  UpdateMethod="vrRequestStatesUpdate"
  DeleteMethod="vrRequestStatesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrRequestStates"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="StatusID" Name="StatusID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
