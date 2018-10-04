Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrExecutionAttachments
    Private Shared _RecordCount As Integer
    Private _SRNNo As Int32 = 0
    Private _SerialNo As Int32 = 0
    Private _Description As String = ""
    Private _FileName As String = ""
    Private _DiskFile As String = ""
    Private _VR_RequestExecution1_ExecutionDescription As String = ""
    Private _FK_VR_ExecutionAttachments_SRNNo As SIS.VR.vrRequestExecution = Nothing
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
    Public Property SRNNo() As Int32
      Get
        Return _SRNNo
      End Get
      Set(ByVal value As Int32)
        _SRNNo = value
      End Set
    End Property
    Public Property SerialNo() As Int32
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As Int32)
        _SerialNo = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _Description = ""
				 Else
					 _Description = value
			   End If
      End Set
    End Property
    Public Property FileName() As String
      Get
        Return _FileName
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FileName = ""
				 Else
					 _FileName = value
			   End If
      End Set
    End Property
    Public Property DiskFile() As String
      Get
        Return _DiskFile
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _DiskFile = ""
				 Else
					 _DiskFile = value
			   End If
      End Set
    End Property
    Public Property VR_RequestExecution1_ExecutionDescription() As String
      Get
        Return _VR_RequestExecution1_ExecutionDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_RequestExecution1_ExecutionDescription = ""
				 Else
					 _VR_RequestExecution1_ExecutionDescription = value
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
        Return _SRNNo & "|" & _SerialNo
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
    Public Class PKvrExecutionAttachments
			Private _SRNNo As Int32 = 0
			Private _SerialNo As Int32 = 0
			Public Property SRNNo() As Int32
				Get
					Return _SRNNo
				End Get
				Set(ByVal value As Int32)
					_SRNNo = value
				End Set
			End Property
			Public Property SerialNo() As Int32
				Get
					Return _SerialNo
				End Get
				Set(ByVal value As Int32)
					_SerialNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_ExecutionAttachments_SRNNo() As SIS.VR.vrRequestExecution
      Get
        If _FK_VR_ExecutionAttachments_SRNNo Is Nothing Then
          _FK_VR_ExecutionAttachments_SRNNo = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(_SRNNo)
        End If
        Return _FK_VR_ExecutionAttachments_SRNNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrExecutionAttachmentsGetNewRecord() As SIS.VR.vrExecutionAttachments
      Return New SIS.VR.vrExecutionAttachments()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrExecutionAttachmentsGetByID(ByVal SRNNo As Int32, ByVal SerialNo As Int32) As SIS.VR.vrExecutionAttachments
      Dim Results As SIS.VR.vrExecutionAttachments = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrExecutionAttachmentsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrExecutionAttachments(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySRNNo(ByVal SRNNo As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrExecutionAttachments)
      Dim Results As List(Of SIS.VR.vrExecutionAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrExecutionAttachmentsSelectBySRNNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrExecutionAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrExecutionAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrExecutionAttachmentsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SRNNo As Int32) As List(Of SIS.VR.vrExecutionAttachments)
      Dim Results As List(Of SIS.VR.vrExecutionAttachments) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrExecutionAttachmentsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrExecutionAttachmentsSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SRNNo",SqlDbType.Int,10, IIf(SRNNo = Nothing, 0,SRNNo))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrExecutionAttachments)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrExecutionAttachments(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrExecutionAttachmentsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SRNNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrExecutionAttachmentsGetByID(ByVal SRNNo As Int32, ByVal SerialNo As Int32, ByVal Filter_SRNNo As Int32) As SIS.VR.vrExecutionAttachments
      Return vrExecutionAttachmentsGetByID(SRNNo, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrExecutionAttachmentsInsert(ByVal Record As SIS.VR.vrExecutionAttachments) As SIS.VR.vrExecutionAttachments
      Dim _Rec As SIS.VR.vrExecutionAttachments = SIS.VR.vrExecutionAttachments.vrExecutionAttachmentsGetNewRecord()
      With _Rec
        .SRNNo = Record.SRNNo
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.VR.vrExecutionAttachments.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrExecutionAttachments) As SIS.VR.vrExecutionAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrExecutionAttachmentsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
          Cmd.Parameters.Add("@Return_SRNNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SRNNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SRNNo = Cmd.Parameters("@Return_SRNNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrExecutionAttachmentsUpdate(ByVal Record As SIS.VR.vrExecutionAttachments) As SIS.VR.vrExecutionAttachments
      Dim _Rec As SIS.VR.vrExecutionAttachments = SIS.VR.vrExecutionAttachments.vrExecutionAttachmentsGetByID(Record.SRNNo, Record.SerialNo)
      With _Rec
        .Description = Record.Description
        .FileName = Record.FileName
        .DiskFile = Record.DiskFile
      End With
      Return SIS.VR.vrExecutionAttachments.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrExecutionAttachments) As SIS.VR.vrExecutionAttachments
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrExecutionAttachmentsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Iif(Record.Description= "" ,Convert.DBNull, Record.Description))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiskFile",SqlDbType.NVarChar,251, Iif(Record.DiskFile= "" ,Convert.DBNull, Record.DiskFile))
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
    Public Shared Function vrExecutionAttachmentsDelete(ByVal Record As SIS.VR.vrExecutionAttachments) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrExecutionAttachmentsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SRNNo",SqlDbType.Int,Record.SRNNo.ToString.Length, Record.SRNNo)
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
      _SRNNo = Ctype(Reader("SRNNo"),Int32)
      _SerialNo = Ctype(Reader("SerialNo"),Int32)
      If Convert.IsDBNull(Reader("Description")) Then
        _Description = String.Empty
      Else
        _Description = Ctype(Reader("Description"), String)
      End If
      If Convert.IsDBNull(Reader("FileName")) Then
        _FileName = String.Empty
      Else
        _FileName = Ctype(Reader("FileName"), String)
      End If
      If Convert.IsDBNull(Reader("DiskFile")) Then
        _DiskFile = String.Empty
      Else
        _DiskFile = Ctype(Reader("DiskFile"), String)
      End If
      If Convert.IsDBNull(Reader("VR_RequestExecution1_ExecutionDescription")) Then
        _VR_RequestExecution1_ExecutionDescription = String.Empty
      Else
        _VR_RequestExecution1_ExecutionDescription = Ctype(Reader("VR_RequestExecution1_ExecutionDescription"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
