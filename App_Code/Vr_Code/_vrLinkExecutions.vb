Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrLinkExecutions
    Private Shared _RecordCount As Integer
    Private _LinkID As Int32 = 0
    Private _SRNNo As Int32 = 0
    Private _LinkedBy As String = ""
    Private _LinkedOn As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _VR_RequestExecution2_ExecutionDescription As String = ""
    Private _FK_VR_LinkExecutions_LinkedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_LinkExecutions_SRNNo As SIS.VR.vrRequestExecution = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
					'mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					'mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					'mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property LinkID() As Int32
      Get
        Return _LinkID
      End Get
      Set(ByVal value As Int32)
        _LinkID = value
      End Set
    End Property
    Public Property SRNNo() As Int32
      Get
        Return _SRNNo
      End Get
      Set(ByVal value As Int32)
        _SRNNo = value
      End Set
    End Property
    Public Property LinkedBy() As String
      Get
        Return _LinkedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LinkedBy = ""
				 Else
					 _LinkedBy = value
			   End If
      End Set
    End Property
    Public Property LinkedOn() As String
      Get
        If Not _LinkedOn = String.Empty Then
          Return Convert.ToDateTime(_LinkedOn).ToString("dd/MM/yyyy")
        End If
        Return _LinkedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LinkedOn = ""
				 Else
					 _LinkedOn = value
			   End If
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
    Public Property VR_RequestExecution2_ExecutionDescription() As String
      Get
        Return _VR_RequestExecution2_ExecutionDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_RequestExecution2_ExecutionDescription = ""
				 Else
					 _VR_RequestExecution2_ExecutionDescription = value
			   End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _LinkID & "|" & _SRNNo
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
    Public Class PKvrLinkExecutions
			Private _LinkID As Int32 = 0
			Private _SRNNo As Int32 = 0
			Public Property LinkID() As Int32
				Get
					Return _LinkID
				End Get
				Set(ByVal value As Int32)
					_LinkID = value
				End Set
			End Property
			Public Property SRNNo() As Int32
				Get
					Return _SRNNo
				End Get
				Set(ByVal value As Int32)
					_SRNNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_LinkExecutions_LinkedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_LinkExecutions_LinkedBy Is Nothing Then
          _FK_VR_LinkExecutions_LinkedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_LinkedBy)
        End If
        Return _FK_VR_LinkExecutions_LinkedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_LinkExecutions_SRNNo() As SIS.VR.vrRequestExecution
      Get
        If _FK_VR_LinkExecutions_SRNNo Is Nothing Then
          _FK_VR_LinkExecutions_SRNNo = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(_SRNNo)
        End If
        Return _FK_VR_LinkExecutions_SRNNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkExecutionsGetNewRecord() As SIS.VR.vrLinkExecutions
      Return New SIS.VR.vrLinkExecutions()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkExecutionsGetByID(ByVal LinkID As Int32, ByVal SRNNo As Int32) As SIS.VR.vrLinkExecutions
      Dim Results As SIS.VR.vrLinkExecutions = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,LinkID.ToString.Length, LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrLinkExecutions(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByLinkID(ByVal LinkID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrLinkExecutions)
      Dim Results As List(Of SIS.VR.vrLinkExecutions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsSelectByLinkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,LinkID.ToString.Length, LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrLinkExecutions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLinkExecutions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySRNNo(ByVal SRNNo As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrLinkExecutions)
      Dim Results As List(Of SIS.VR.vrLinkExecutions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsSelectBySRNNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrLinkExecutions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLinkExecutions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkExecutionsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SRNNo As Int32) As List(Of SIS.VR.vrLinkExecutions)
      Dim Results As List(Of SIS.VR.vrLinkExecutions) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrLinkExecutionsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrLinkExecutionsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SRNNo",SqlDbType.Int,10, IIf(SRNNo = Nothing, 0,SRNNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrLinkExecutions)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLinkExecutions(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrLinkExecutionsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SRNNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkExecutionsGetByID(ByVal LinkID As Int32, ByVal SRNNo As Int32, ByVal Filter_SRNNo As Int32) As SIS.VR.vrLinkExecutions
      Return vrLinkExecutionsGetByID(LinkID, SRNNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrLinkExecutionsInsert(ByVal Record As SIS.VR.vrLinkExecutions) As SIS.VR.vrLinkExecutions
      Dim _Rec As SIS.VR.vrLinkExecutions = SIS.VR.vrLinkExecutions.vrLinkExecutionsGetNewRecord()
      With _Rec
        .LinkID = Record.LinkID
        .SRNNo = Record.SRNNo
        .LinkedBy = Record.LinkedBy
        .LinkedOn = Record.LinkedOn
      End With
      Return SIS.VR.vrLinkExecutions.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrLinkExecutions) As SIS.VR.vrLinkExecutions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,11, Record.LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkedBy",SqlDbType.NVarChar,9, Iif(Record.LinkedBy= "" ,Convert.DBNull, Record.LinkedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkedOn",SqlDbType.DateTime,21, Iif(Record.LinkedOn= "" ,Convert.DBNull, Record.LinkedOn))
          Cmd.Parameters.Add("@Return_LinkID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_LinkID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SRNNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SRNNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.LinkID = Cmd.Parameters("@Return_LinkID").Value
          Record.SRNNo = Cmd.Parameters("@Return_SRNNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrLinkExecutionsUpdate(ByVal Record As SIS.VR.vrLinkExecutions) As SIS.VR.vrLinkExecutions
      Dim _Rec As SIS.VR.vrLinkExecutions = SIS.VR.vrLinkExecutions.vrLinkExecutionsGetByID(Record.LinkID, Record.SRNNo)
      With _Rec
        .LinkedBy = Record.LinkedBy
        .LinkedOn = Record.LinkedOn
      End With
      Return SIS.VR.vrLinkExecutions.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrLinkExecutions) As SIS.VR.vrLinkExecutions
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LinkID",SqlDbType.Int,11, Record.LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,11, Record.LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkedBy",SqlDbType.NVarChar,9, Iif(Record.LinkedBy= "" ,Convert.DBNull, Record.LinkedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkedOn",SqlDbType.DateTime,21, Iif(Record.LinkedOn= "" ,Convert.DBNull, Record.LinkedOn))
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
    Public Shared Function vrLinkExecutionsDelete(ByVal Record As SIS.VR.vrLinkExecutions) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLinkExecutionsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_LinkID",SqlDbType.Int,Record.LinkID.ToString.Length, Record.LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SRNNo",SqlDbType.Int,Record.SRNNo.ToString.Length, Record.SRNNo)
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
      _LinkID = Ctype(Reader("LinkID"),Int32)
      _SRNNo = Ctype(Reader("SRNNo"),Int32)
      If Convert.IsDBNull(Reader("LinkedBy")) Then
        _LinkedBy = String.Empty
      Else
        _LinkedBy = Ctype(Reader("LinkedBy"), String)
      End If
      If Convert.IsDBNull(Reader("LinkedOn")) Then
        _LinkedOn = String.Empty
      Else
        _LinkedOn = Ctype(Reader("LinkedOn"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      If Convert.IsDBNull(Reader("VR_RequestExecution2_ExecutionDescription")) Then
        _VR_RequestExecution2_ExecutionDescription = String.Empty
      Else
        _VR_RequestExecution2_ExecutionDescription = Ctype(Reader("VR_RequestExecution2_ExecutionDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
