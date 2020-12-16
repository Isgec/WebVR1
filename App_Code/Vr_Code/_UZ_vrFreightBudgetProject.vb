Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrFreightBudgetProject
    Public Property AthHandle As String = "J_FREIGHTBUDGET_" & HttpContext.Current.Session("FinanceCompany")
    Public Property AthIndex As String = HttpContext.Current.Session("FinanceCompany") & "_" & ProjectID
    Public ReadOnly Property IsAttached() As Boolean
      Get
        Dim mRet As Boolean = False
        Dim cnt As Integer = 0
        Dim Sql As String = ""
        Sql &= " select isnull(count(t_indx),0) "
        Sql &= " from ttcisg132200"
        Sql &= " where t_hndl='" & AthHandle & "' "
        Sql &= " and t_indx='" & AthIndex & "'"
        Sql &= ""
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            cnt = Cmd.ExecuteScalar
          End Using
        End Using
        If cnt > 0 Then mRet = True
        Return mRet
      End Get
    End Property
    Public ReadOnly Property GetAttachLink() As String
      Get
        Dim UrlAuthority As String = HttpContext.Current.Request.Url.Authority
        If UrlAuthority.ToLower <> "cloud.isgec.co.in" Then
          UrlAuthority = "192.9.200.146"
        End If
        Dim mRet As String = HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & UrlAuthority
        mRet &= "/Attachment/Attachment.aspx?AthHandle=" & AthHandle
        Dim Index As String = AthIndex
        Dim User As String = HttpContext.Current.Session("LoginID")
        Dim canEdit As String = "n"
        If Editable Then
          canEdit = "y"
        End If
        mRet &= "&Index=" & Index & "&AttachedBy=" & User & "&ed=" & canEdit
        mRet = "javascript:window.open('" & mRet & "', 'win_" & ProjectID & "', 'left=20,top=20,width=600,height=400,toolbar=0,resizable=1,scrollbars=1'); return false;"
        Return mRet
      End Get
    End Property
    Public Shared Function GetBudgetProject(ByVal ProjectID As String) As SIS.VR.vrFreightBudgetProject
      Dim Results As SIS.VR.vrFreightBudgetProject = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrFreightBudgetProjectSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrFreightBudgetProject(Reader)
          End If
          Reader.Close()
          If Results IsNot Nothing Then
            If Not Results.Active Then Results = Nothing
          End If
        End Using
        If Results Is Nothing Then
          Results = New SIS.VR.vrFreightBudgetProject
          With Results
            .ProjectID = ProjectID
            .FreightBudgetProjectID = ProjectID
            .IDM_Projects2_Description = .FK_VR_FreightBudgetProject_ProjectID.Description
            .IDM_Projects3_Description = .IDM_Projects2_Description
            .Active = True
          End With
        End If
      End Using
      Return Results
    End Function

    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      If Active Then mRet = Drawing.Color.Green
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = Not Active
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = Not Active
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = Not Active
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal ProjectID As String) As SIS.VR.vrFreightBudgetProject
      Dim Results As SIS.VR.vrFreightBudgetProject = vrFreightBudgetProjectGetByID(ProjectID)
      vrFreightBudgetProjectDelete(Results)
      Return Results
    End Function
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal ProjectID As String) As SIS.VR.vrFreightBudgetProject
      Dim Results As SIS.VR.vrFreightBudgetProject = vrFreightBudgetProjectGetByID(ProjectID)
      If Results.IsAttached Then
        Results.Active = True
        Results.CreatedBy = HttpContext.Current.Session("LoginID")
        Results.CreatedOn = Now
        SIS.VR.vrFreightBudgetProject.UpdateData(Results)
      Else
        Throw New Exception("Please attach Agenda Paper for freight budget utilization from other project.")
      End If
      Return Results
    End Function
    Public Shared Function UZ_vrFreightBudgetProjectSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String, ByVal FreightBudgetProjectID As String) As List(Of SIS.VR.vrFreightBudgetProject)
      Dim Results As List(Of SIS.VR.vrFreightBudgetProject) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ProjectID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_FreightBudgetProjectSelectListSearch"
            Cmd.CommandText = "spvrFreightBudgetProjectSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_FreightBudgetProjectSelectListFilteres"
            Cmd.CommandText = "spvrFreightBudgetProjectSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FreightBudgetProjectID", SqlDbType.NVarChar, 6, IIf(FreightBudgetProjectID Is Nothing, String.Empty, FreightBudgetProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrFreightBudgetProject)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrFreightBudgetProject(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_FreightBudgetProjectID"), TextBox).Text = ""
          CType(.FindControl("F_FreightBudgetProjectID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
