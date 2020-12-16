Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrFreightBudgetProject
    Private Shared _RecordCount As Integer
    Public Property ProjectID As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property Active As Boolean = False
    Public Property FreightBudgetProjectID As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property IDM_Projects2_Description As String = ""
    Public Property IDM_Projects3_Description As String = ""
    Private _FK_VR_FreightBudgetProject_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_FreightBudgetProject_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_VR_FreightBudgetProject_FrBdProjectID As SIS.QCM.qcmProjects = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         _CreatedOn = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKvrFreightBudgetProject
      Private _ProjectID As String = ""
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_VR_FreightBudgetProject_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_FreightBudgetProject_CreatedBy Is Nothing Then
          _FK_VR_FreightBudgetProject_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_VR_FreightBudgetProject_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_FreightBudgetProject_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_FreightBudgetProject_ProjectID Is Nothing Then
          _FK_VR_FreightBudgetProject_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_VR_FreightBudgetProject_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_VR_FreightBudgetProject_FrBdProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_FreightBudgetProject_FrBdProjectID Is Nothing Then
          _FK_VR_FreightBudgetProject_FrBdProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_FreightBudgetProjectID)
        End If
        Return _FK_VR_FreightBudgetProject_FrBdProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrFreightBudgetProjectGetNewRecord() As SIS.VR.vrFreightBudgetProject
      Return New SIS.VR.vrFreightBudgetProject()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrFreightBudgetProjectGetByID(ByVal ProjectID As String) As SIS.VR.vrFreightBudgetProject
      Dim Results As SIS.VR.vrFreightBudgetProject = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrFreightBudgetProjectSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrFreightBudgetProject(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrFreightBudgetProjectSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String, ByVal FreightBudgetProjectID As String) As List(Of SIS.VR.vrFreightBudgetProject)
      Dim Results As List(Of SIS.VR.vrFreightBudgetProject) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "ProjectID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrFreightBudgetProjectSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrFreightBudgetProjectSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FreightBudgetProjectID",SqlDbType.NVarChar,6, IIf(FreightBudgetProjectID Is Nothing, String.Empty,FreightBudgetProjectID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
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
    Public Shared Function vrFreightBudgetProjectSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal CreatedBy As String, ByVal FreightBudgetProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrFreightBudgetProjectGetByID(ByVal ProjectID As String, ByVal Filter_ProjectID As String, ByVal Filter_CreatedBy As String, ByVal Filter_FreightBudgetProjectID As String) As SIS.VR.vrFreightBudgetProject
      Return vrFreightBudgetProjectGetByID(ProjectID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrFreightBudgetProjectInsert(ByVal Record As SIS.VR.vrFreightBudgetProject) As SIS.VR.vrFreightBudgetProject
      Dim _Rec As SIS.VR.vrFreightBudgetProject = SIS.VR.vrFreightBudgetProject.vrFreightBudgetProjectGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .CreatedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .Active = Record.Active
        .FreightBudgetProjectID = Record.FreightBudgetProjectID
      End With
      Return SIS.VR.vrFreightBudgetProject.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrFreightBudgetProject) As SIS.VR.vrFreightBudgetProject
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrFreightBudgetProjectInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreightBudgetProjectID",SqlDbType.NVarChar,7, Record.FreightBudgetProjectID)
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrFreightBudgetProjectUpdate(ByVal Record As SIS.VR.vrFreightBudgetProject) As SIS.VR.vrFreightBudgetProject
      Dim _Rec As SIS.VR.vrFreightBudgetProject = SIS.VR.vrFreightBudgetProject.vrFreightBudgetProjectGetByID(Record.ProjectID)
      With _Rec
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
        .Active = Record.Active
        .FreightBudgetProjectID = Record.FreightBudgetProjectID
      End With
      Return SIS.VR.vrFreightBudgetProject.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrFreightBudgetProject) As SIS.VR.vrFreightBudgetProject
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrFreightBudgetProjectUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FreightBudgetProjectID",SqlDbType.NVarChar,7, Record.FreightBudgetProjectID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function vrFreightBudgetProjectDelete(ByVal Record As SIS.VR.vrFreightBudgetProject) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrFreightBudgetProjectDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
