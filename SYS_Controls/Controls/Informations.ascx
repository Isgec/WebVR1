<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Informations.ascx.vb" Inherits="Informations" %>
<table id="TblEmp" runat="server">
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Name:"></asp:Label>
    </td>
    <td>
      <asp:Label ID="F_EmployeeName" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
    <td style="text-align: right;">
      <asp:Label ID="Label1" runat="server" Font-Bold="true" Text=""></asp:Label>
    </td>
    <td>
    </td>
  </tr>
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label3" runat="server" Font-Bold="true" Text=""></asp:Label>
    </td>
    <td colspan="3">
      <asp:Label ID="F_Verifier" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
  </tr>
  <tr>
    <td style="text-align: right;">
      <asp:Label ID="Label5" runat="server" Font-Bold="true" Text=""></asp:Label>
    </td>
    <td colspan="3">
      <asp:Label ID="F_Approver" runat="server" Font-Bold="False" Font-Size="10px"></asp:Label>
    </td>
  </tr>
</table>
