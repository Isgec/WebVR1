Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Services
Imports System.IO
Imports System.Web.Security
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Web.ApplicationServices
Imports System.Security.Principal

Partial Class LGDefault
  Inherits System.Web.UI.Page
  Public Property abcd As String = ""
  Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
    If Page.User.Identity.IsAuthenticated Then
      abcd = "<fieldset class='ui-widget-content wp_page'>"
      abcd &= "<legend>"
      abcd &= "    <span>&nbsp;TODAY's Punch Time</span>"
      abcd &= "</legend>"
      abcd &= "<div class='wp_pagedata'>"
      Try
      Catch ex As Exception
      End Try
      abcd &= "</div>"
      abcd &= "</fieldset>"

      Dim str As String = ""
      str &= "|~/ATN_Main/App_View/GD_atnAttendanceStatus.aspx|Attendance Status"
      str &= "|~/ATN_Main/App_Forms/GT_atnNewRegularizeAttendance.aspx|Regularize Attendance"
      str &= "|~/ATN_Main/App_Forms/GT_atnNewAdvanceApplication.aspx|Advance Application"
      str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeFPAttendance.aspx|Regularize FP"
      str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeODAttendance.aspx|Regularize OD"
      str &= "|~/ATN_Main/App_Forms/GT_atnRegularizeTSAttendance.aspx|Regularize TS"
      str &= "|~/ATN_Main/App_View/GD_atnTimeShort.aspx|Time Short"
      str &= "|~/ATN_Main/App_View/GD_atnAppliedApplications.aspx|My Application"
      str &= "|~/ATN_Main/App_Forms/GF_atnApproverChangeRequest.aspx|Change Approver"
      str &= "|~/ATN_Main/App_Reports/GP_atnPrintLeavecard.aspx|Leave Card"
      str &= "|~/ATN_Main/App_View/GD_atnRules.aspx|Leave Rules"

      str = str.Replace("~", HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath)
      Dim astr() As String = str.Split("|".ToCharArray)

      abcd &= "<ul class='dashboardIcons'>"
      For i As Integer = 1 To astr.Length - 1 Step 2
        abcd &= "<fieldset id='fs" & i & "' class='ui-widget-content wp_page'>"
        abcd &= "<div class='wp_pagedata'>"
        abcd &= "  <li title='" & astr(i + 1) & "'>"
        abcd &= "    <div class='frame'>"
        abcd &= "      <a href='" & astr(i) & "'>"
        abcd &= "        <img src='Images/mnu_" & i & ".jpg' width='50' height='50' alt=''>"
        abcd &= "        <span>" & astr(i + 1) & "</span>"
        abcd &= "      </a>"
        abcd &= "     </div>"
        abcd &= "  </li>"
        abcd &= "</div>"
        abcd &= "</fieldset>"
      Next
      abcd &= "</ul>"
    End If
  End Sub
End Class
