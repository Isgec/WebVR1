<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrExecutionAttachments.aspx.vb" Inherits="EF_vrExecutionAttachments" title="Edit: Execution Attachments" %>
<asp:Content ID="CPHvrExecutionAttachments" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrExecutionAttachments" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrExecutionAttachments" runat="server" Text="&nbsp;Edit: Execution Attachments" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrExecutionAttachments"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrExecutionAttachments.aspx?pk="
    ValidationGroup = "vrExecutionAttachments"
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
<asp:FormView ID="FVvrExecutionAttachments"
	runat = "server"
	DataKeyNames = "SRNNo,SerialNo"
	DataSourceID = "ODSvrExecutionAttachments"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SRNNo" runat="server" ForeColor="#CC6633" Text="SRNNo :" /></b>
				</td>
        <td>
					<asp:TextBox
						ID = "F_SRNNo"
            Width="70px"
						Text='<%# Bind("SRNNo") %>'
						CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of SRNNo."
						Runat="Server" />
					<asp:Label
						ID = "F_SRNNo_Display"
						Text='<%# Eval("VR_RequestExecution1_ExecutionDescription") %>'
						Runat="Server" />
        </td>
			</tr>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="SerialNo :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_SerialNo"
						Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of SerialNo."
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
            Width="350px"
						CssClass = "mytxt"
						onfocus = "return this.select();"
						ValidationGroup="vrExecutionAttachments"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
						MaxLength="50"
						runat="server" />
					<asp:RequiredFieldValidator 
						ID = "RFVDescription"
						runat = "server"
						ControlToValidate = "F_Description"
						Text = "Description is required."
						ErrorMessage = "[Required!]"
						Display = "Dynamic"
						EnableClientScript = "true"
						ValidationGroup = "vrExecutionAttachments"
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
  ID = "ODSvrExecutionAttachments"
  DataObjectTypeName = "SIS.VR.vrExecutionAttachments"
  SelectMethod = "vrExecutionAttachmentsGetByID"
  UpdateMethod="vrExecutionAttachmentsUpdate"
  DeleteMethod="UZ_vrExecutionAttachmentsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrExecutionAttachments"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SRNNo" Name="SRNNo" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
