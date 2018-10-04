Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrSanctionAlert
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _At60 As Boolean = False
    Private _At70 As Boolean = False
    Private _At80 As Boolean = False
    Private _At90 As Boolean = False
    Private _At95 As Boolean = False
    Private _At96 As Boolean = False
    Private _At97 As Boolean = False
    Private _At98 As Boolean = False
    Private _At99 As Boolean = False
    Private _EMailIDs As String = ""
    Private _IDM_Projects1_Description As String = ""
    Private _FK_VR_SanctionAlert_ProjectID As SIS.QCM.qcmProjects = Nothing
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
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property At60() As Boolean
      Get
        Return _At60
      End Get
      Set(ByVal value As Boolean)
        _At60 = value
      End Set
    End Property
    Public Property At70() As Boolean
      Get
        Return _At70
      End Get
      Set(ByVal value As Boolean)
        _At70 = value
      End Set
    End Property
    Public Property At80() As Boolean
      Get
        Return _At80
      End Get
      Set(ByVal value As Boolean)
        _At80 = value
      End Set
    End Property
    Public Property At90() As Boolean
      Get
        Return _At90
      End Get
      Set(ByVal value As Boolean)
        _At90 = value
      End Set
    End Property
    Public Property At95() As Boolean
      Get
        Return _At95
      End Get
      Set(ByVal value As Boolean)
        _At95 = value
      End Set
    End Property
    Public Property At96() As Boolean
      Get
        Return _At96
      End Get
      Set(ByVal value As Boolean)
        _At96 = value
      End Set
    End Property
    Public Property At97() As Boolean
      Get
        Return _At97
      End Get
      Set(ByVal value As Boolean)
        _At97 = value
      End Set
    End Property
    Public Property At98() As Boolean
      Get
        Return _At98
      End Get
      Set(ByVal value As Boolean)
        _At98 = value
      End Set
    End Property
    Public Property At99() As Boolean
      Get
        Return _At99
      End Get
      Set(ByVal value As Boolean)
        _At99 = value
      End Set
    End Property
    Public Property EMailIDs() As String
      Get
        Return _EMailIDs
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EMailIDs = ""
				 Else
					 _EMailIDs = value
			   End If
      End Set
    End Property
    Public Property IDM_Projects1_Description() As String
      Get
        Return _IDM_Projects1_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects1_Description = value
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
    Public Class PKvrSanctionAlert
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
    Public ReadOnly Property FK_VR_SanctionAlert_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_SanctionAlert_ProjectID Is Nothing Then
          _FK_VR_SanctionAlert_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_VR_SanctionAlert_ProjectID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrSanctionAlertGetNewRecord() As SIS.VR.vrSanctionAlert
      Return New SIS.VR.vrSanctionAlert()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrSanctionAlertGetByID(ByVal ProjectID As String) As SIS.VR.vrSanctionAlert
      Dim Results As SIS.VR.vrSanctionAlert = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrSanctionAlertSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrSanctionAlert(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrSanctionAlertSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As List(Of SIS.VR.vrSanctionAlert)
      Dim Results As List(Of SIS.VR.vrSanctionAlert) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrSanctionAlertSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrSanctionAlertSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrSanctionAlert)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrSanctionAlert(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrSanctionAlertSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrSanctionAlertGetByID(ByVal ProjectID As String, ByVal Filter_ProjectID As String) As SIS.VR.vrSanctionAlert
      Return vrSanctionAlertGetByID(ProjectID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrSanctionAlertInsert(ByVal Record As SIS.VR.vrSanctionAlert) As SIS.VR.vrSanctionAlert
      Dim _Rec As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetNewRecord()
      With _Rec
        .ProjectID = Record.ProjectID
        .At60 = Record.At60
        .At70 = Record.At70
        .At80 = Record.At80
        .At90 = Record.At90
        .At95 = Record.At95
        .At96 = Record.At96
        .At97 = Record.At97
        .At98 = Record.At98
        .At99 = Record.At99
        .EMailIDs = Record.EMailIDs
      End With
      Return SIS.VR.vrSanctionAlert.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrSanctionAlert) As SIS.VR.vrSanctionAlert
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrSanctionAlertInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At60",SqlDbType.Bit,3, Record.At60)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At70",SqlDbType.Bit,3, Record.At70)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At80",SqlDbType.Bit,3, Record.At80)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At90",SqlDbType.Bit,3, Record.At90)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At95",SqlDbType.Bit,3, Record.At95)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At96",SqlDbType.Bit,3, Record.At96)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At97",SqlDbType.Bit,3, Record.At97)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At98",SqlDbType.Bit,3, Record.At98)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At99",SqlDbType.Bit,3, Record.At99)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailIDs",SqlDbType.NVarChar,251, Iif(Record.EMailIDs= "" ,Convert.DBNull, Record.EMailIDs))
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
    Public Shared Function vrSanctionAlertUpdate(ByVal Record As SIS.VR.vrSanctionAlert) As SIS.VR.vrSanctionAlert
      Dim _Rec As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(Record.ProjectID)
      With _Rec
        .At60 = Record.At60
        .At70 = Record.At70
        .At80 = Record.At80
        .At90 = Record.At90
        .At95 = Record.At95
        .At96 = Record.At96
        .At97 = Record.At97
        .At98 = Record.At98
        .At99 = Record.At99
        .EMailIDs = Record.EMailIDs
      End With
      Return SIS.VR.vrSanctionAlert.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrSanctionAlert) As SIS.VR.vrSanctionAlert
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrSanctionAlertUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At60",SqlDbType.Bit,3, Record.At60)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At70",SqlDbType.Bit,3, Record.At70)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At80",SqlDbType.Bit,3, Record.At80)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At90",SqlDbType.Bit,3, Record.At90)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At95",SqlDbType.Bit,3, Record.At95)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At96",SqlDbType.Bit,3, Record.At96)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At97",SqlDbType.Bit,3, Record.At97)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At98",SqlDbType.Bit,3, Record.At98)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@At99",SqlDbType.Bit,3, Record.At99)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EMailIDs",SqlDbType.NVarChar,251, Iif(Record.EMailIDs= "" ,Convert.DBNull, Record.EMailIDs))
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
    Public Shared Function vrSanctionAlertDelete(ByVal Record As SIS.VR.vrSanctionAlert) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrSanctionAlertDelete"
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
      On Error Resume Next
      _ProjectID = Ctype(Reader("ProjectID"),String)
      _At60 = Ctype(Reader("At60"),Boolean)
      _At70 = Ctype(Reader("At70"),Boolean)
      _At80 = Ctype(Reader("At80"),Boolean)
      _At90 = Ctype(Reader("At90"),Boolean)
      _At95 = Ctype(Reader("At95"),Boolean)
      _At96 = Ctype(Reader("At96"),Boolean)
      _At97 = Ctype(Reader("At97"),Boolean)
      _At98 = Ctype(Reader("At98"),Boolean)
      _At99 = Ctype(Reader("At99"),Boolean)
      If Convert.IsDBNull(Reader("EMailIDs")) Then
        _EMailIDs = String.Empty
      Else
        _EMailIDs = Ctype(Reader("EMailIDs"), String)
      End If
      _IDM_Projects1_Description = Ctype(Reader("IDM_Projects1_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
