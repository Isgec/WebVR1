Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrUserGroup
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _UserID As String = ""
    Private _GroupID As String = ""
    Private _RoleID As String = ""
    Private _OutOfContractApprover As Boolean = False
    Private _aspnet_Users1_UserFullName As String = ""
    Private _VR_Groups2_GroupName As String = ""
    Private _FK_VR_UserGroup_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_UserGroup_GroupID As SIS.VR.vrGroups = Nothing
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
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property UserID() As String
      Get
        Return _UserID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UserID = ""
				 Else
					 _UserID = value
			   End If
      End Set
    End Property
    Public Property GroupID() As String
      Get
        Return _GroupID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _GroupID = ""
				 Else
					 _GroupID = value
			   End If
      End Set
    End Property
    Public Property RoleID() As String
      Get
        Return _RoleID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RoleID = ""
				 Else
					 _RoleID = value
			   End If
      End Set
    End Property
    Public Property OutOfContractApprover() As Boolean
      Get
        Return _OutOfContractApprover
      End Get
      Set(ByVal value As Boolean)
        _OutOfContractApprover = value
      End Set
    End Property
    Public Property aspnet_Users1_UserFullName() As String
      Get
        Return _aspnet_Users1_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users1_UserFullName = value
      End Set
    End Property
    Public Property VR_Groups2_GroupName() As String
      Get
        Return _VR_Groups2_GroupName
      End Get
      Set(ByVal value As String)
        _VR_Groups2_GroupName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKvrUserGroup
			Private _SerialNo As Int32 = 0
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_UserGroup_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_UserGroup_UserID Is Nothing Then
          _FK_VR_UserGroup_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_VR_UserGroup_UserID
      End Get
    End Property
    Public ReadOnly Property FK_VR_UserGroup_GroupID() As SIS.VR.vrGroups
      Get
        If _FK_VR_UserGroup_GroupID Is Nothing Then
          _FK_VR_UserGroup_GroupID = SIS.VR.vrGroups.vrGroupsGetByID(_GroupID)
        End If
        Return _FK_VR_UserGroup_GroupID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUserGroupGetNewRecord() As SIS.VR.vrUserGroup
      Return New SIS.VR.vrUserGroup()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUserGroupGetByID(ByVal SerialNo As Int32) As SIS.VR.vrUserGroup
      Dim Results As SIS.VR.vrUserGroup = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrUserGroupSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrUserGroup(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUserGroupSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal GroupID As Int32, ByVal RoleID As String) As List(Of SIS.VR.vrUserGroup)
      Dim Results As List(Of SIS.VR.vrUserGroup) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrUserGroupSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrUserGroupSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID",SqlDbType.Int,10, IIf(GroupID = Nothing, 0,GroupID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RoleID",SqlDbType.NVarChar,20, IIf(RoleID Is Nothing, String.Empty,RoleID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrUserGroup)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrUserGroup(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrUserGroupSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal GroupID As Int32, ByVal RoleID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUserGroupGetByID(ByVal SerialNo As Int32, ByVal Filter_UserID As String, ByVal Filter_GroupID As Int32, ByVal Filter_RoleID As String) As SIS.VR.vrUserGroup
      Return vrUserGroupGetByID(SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrUserGroupInsert(ByVal Record As SIS.VR.vrUserGroup) As SIS.VR.vrUserGroup
      Dim _Rec As SIS.VR.vrUserGroup = SIS.VR.vrUserGroup.vrUserGroupGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .RoleID = Record.RoleID
        .OutOfContractApprover = Record.OutOfContractApprover
      End With
      Return SIS.VR.vrUserGroup.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrUserGroup) As SIS.VR.vrUserGroup
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrUserGroupInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoleID",SqlDbType.NVarChar,21, Iif(Record.RoleID= "" ,Convert.DBNull, Record.RoleID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OutOfContractApprover",SqlDbType.Bit,3, Record.OutOfContractApprover)
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrUserGroupUpdate(ByVal Record As SIS.VR.vrUserGroup) As SIS.VR.vrUserGroup
      Dim _Rec As SIS.VR.vrUserGroup = SIS.VR.vrUserGroup.vrUserGroupGetByID(Record.SerialNo)
      With _Rec
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .RoleID = Record.RoleID
        .OutOfContractApprover = Record.OutOfContractApprover
      End With
      Return SIS.VR.vrUserGroup.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrUserGroup) As SIS.VR.vrUserGroup
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrUserGroupUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RoleID",SqlDbType.NVarChar,21, Iif(Record.RoleID= "" ,Convert.DBNull, Record.RoleID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OutOfContractApprover",SqlDbType.Bit,3, Record.OutOfContractApprover)
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
    Public Shared Function vrUserGroupDelete(ByVal Record As SIS.VR.vrUserGroup) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrUserGroupDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,Record.SerialNo.ToString.Length, Record.SerialNo)
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
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("UserID")) Then
        _UserID = String.Empty
      Else
        _UserID = Ctype(Reader("UserID"), String)
      End If
      If Convert.IsDBNull(Reader("GroupID")) Then
        _GroupID = String.Empty
      Else
        _GroupID = Ctype(Reader("GroupID"), String)
      End If
      If Convert.IsDBNull(Reader("RoleID")) Then
        _RoleID = String.Empty
      Else
        _RoleID = Ctype(Reader("RoleID"), String)
      End If
      _OutOfContractApprover = Ctype(Reader("OutOfContractApprover"),Boolean)
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _VR_Groups2_GroupName = Ctype(Reader("VR_Groups2_GroupName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
