Imports System.Collections.Generic
Partial Class Informations
  Inherits System.Web.UI.UserControl
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      Dim oEmp As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(HttpContext.Current.User.Identity.Name)
      If Not oEmp Is Nothing Then
        F_EmployeeName.Text = oEmp.UserFullName
        'F_Department.Text = oEmp.C_DepartmentID
        'F_Designation.Text = oEmp.C_DesignationIDHRM_Designations.Description
      End If
      Me.Visible = True
    End If
  End Sub


End Class
