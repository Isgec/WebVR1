<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_vrODCReasons.aspx.vb" Inherits="EF_vrODCReasons" title="Edit: ODC Reasons" %>
<asp:Content ID="CPHvrODCReasons" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="page">
<asp:UpdatePanel ID="UPNLvrODCReasons" runat="server" >
<ContentTemplate>
  <asp:Label ID="LabelvrODCReasons" runat="server" Text="&nbsp;Edit: ODC Reasons" Width="100%" CssClass="sis_formheading"></asp:Label>
  <LGM:ToolBar0 
    ID = "TBLvrODCReasons"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnablePrint = "True"
    PrintUrl = "../App_Print/RP_vrODCReasons.aspx?pk="
    ValidationGroup = "vrODCReasons"
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
<asp:FormView ID="FVvrODCReasons"
	runat = "server"
	DataKeyNames = "ReasonID"
	DataSourceID = "ODSvrODCReasons"
	DefaultMode = "Edit" CssClass="sis_formview">
	<EditItemTemplate>
    <br />
		<table>
			<tr>
				<td class="alignright">
					<b><asp:Label ID="L_ReasonID" runat="server" ForeColor="#CC6633" Text="ReasonID :" /></b>
				</td>
				<td>
					<asp:TextBox ID="F_ReasonID"
						Text='<%# Bind("ReasonID") %>'
            ToolTip="Value of ReasonID."
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
						ValidationGroup="vrODCReasons"
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
						ValidationGroup = "vrODCReasons"
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
  ID = "ODSvrODCReasons"
  DataObjectTypeName = "SIS.VR.vrODCReasons"
  SelectMethod = "vrODCReasonsGetByID"
  UpdateMethod="vrODCReasonsUpdate"
  DeleteMethod="vrODCReasonsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.VR.vrODCReasons"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ReasonID" Name="ReasonID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>
