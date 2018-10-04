Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrVTDefault
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _MinimumCapacityPercentage As Decimal = 0
    Private _MaximumCapacityPercentage As Decimal = 0
    Private _MinimumHeightPercentage As Decimal = 0
    Private _MinimumWidthPercentage As Decimal = 0
    Private _MinimumLengthPercentage As Decimal = 0
    Private _MaximumHeightPercentage As Decimal = 0
    Private _MaximumWidthPercentage As Decimal = 0
    Private _MaximumLengthPercentage As Decimal = 0
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
    Public Property MinimumCapacityPercentage() As Decimal
      Get
        Return _MinimumCapacityPercentage
      End Get
      Set(ByVal value As Decimal)
        _MinimumCapacityPercentage = value
      End Set
    End Property
    Public Property MaximumCapacityPercentage() As Decimal
      Get
        Return _MaximumCapacityPercentage
      End Get
      Set(ByVal value As Decimal)
        _MaximumCapacityPercentage = value
      End Set
    End Property
    Public Property MinimumHeightPercentage() As Decimal
      Get
        Return _MinimumHeightPercentage
      End Get
      Set(ByVal value As Decimal)
        _MinimumHeightPercentage = value
      End Set
    End Property
    Public Property MinimumWidthPercentage() As Decimal
      Get
        Return _MinimumWidthPercentage
      End Get
      Set(ByVal value As Decimal)
        _MinimumWidthPercentage = value
      End Set
    End Property
    Public Property MinimumLengthPercentage() As Decimal
      Get
        Return _MinimumLengthPercentage
      End Get
      Set(ByVal value As Decimal)
        _MinimumLengthPercentage = value
      End Set
    End Property
    Public Property MaximumHeightPercentage() As Decimal
      Get
        Return _MaximumHeightPercentage
      End Get
      Set(ByVal value As Decimal)
        _MaximumHeightPercentage = value
      End Set
    End Property
    Public Property MaximumWidthPercentage() As Decimal
      Get
        Return _MaximumWidthPercentage
      End Get
      Set(ByVal value As Decimal)
        _MaximumWidthPercentage = value
      End Set
    End Property
    Public Property MaximumLengthPercentage() As Decimal
      Get
        Return _MaximumLengthPercentage
      End Get
      Set(ByVal value As Decimal)
        _MaximumLengthPercentage = value
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
    Public Class PKvrVTDefault
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
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVTDefaultGetNewRecord() As SIS.VR.vrVTDefault
      Return New SIS.VR.vrVTDefault()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVTDefaultGetByID(ByVal SerialNo As Int32) As SIS.VR.vrVTDefault
      Dim Results As SIS.VR.vrVTDefault = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVTDefaultSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrVTDefault(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVTDefaultSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.VR.vrVTDefault)
      Dim Results As List(Of SIS.VR.vrVTDefault) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrVTDefaultSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrVTDefaultSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVTDefault)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVTDefault(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrVTDefaultSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrVTDefaultInsert(ByVal Record As SIS.VR.vrVTDefault) As SIS.VR.vrVTDefault
      Dim _Rec As SIS.VR.vrVTDefault = SIS.VR.vrVTDefault.vrVTDefaultGetNewRecord()
      With _Rec
        .MinimumCapacityPercentage = Record.MinimumCapacityPercentage
        .MaximumCapacityPercentage = Record.MaximumCapacityPercentage
        .MinimumHeightPercentage = Record.MinimumHeightPercentage
        .MinimumWidthPercentage = Record.MinimumWidthPercentage
        .MinimumLengthPercentage = Record.MinimumLengthPercentage
        .MaximumHeightPercentage = Record.MaximumHeightPercentage
        .MaximumWidthPercentage = Record.MaximumWidthPercentage
        .MaximumLengthPercentage = Record.MaximumLengthPercentage
      End With
      Return SIS.VR.vrVTDefault.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrVTDefault) As SIS.VR.vrVTDefault
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVTDefaultInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumCapacityPercentage",SqlDbType.Decimal,9, Record.MinimumCapacityPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumCapacityPercentage",SqlDbType.Decimal,9, Record.MaximumCapacityPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumHeightPercentage",SqlDbType.Decimal,9, Record.MinimumHeightPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumWidthPercentage",SqlDbType.Decimal,9, Record.MinimumWidthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumLengthPercentage",SqlDbType.Decimal,9, Record.MinimumLengthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumHeightPercentage",SqlDbType.Decimal,9, Record.MaximumHeightPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumWidthPercentage",SqlDbType.Decimal,9, Record.MaximumWidthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumLengthPercentage",SqlDbType.Decimal,9, Record.MaximumLengthPercentage)
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
    Public Shared Function vrVTDefaultUpdate(ByVal Record As SIS.VR.vrVTDefault) As SIS.VR.vrVTDefault
      Dim _Rec As SIS.VR.vrVTDefault = SIS.VR.vrVTDefault.vrVTDefaultGetByID(Record.SerialNo)
      With _Rec
        .MinimumCapacityPercentage = Record.MinimumCapacityPercentage
        .MaximumCapacityPercentage = Record.MaximumCapacityPercentage
        .MinimumHeightPercentage = Record.MinimumHeightPercentage
        .MinimumWidthPercentage = Record.MinimumWidthPercentage
        .MinimumLengthPercentage = Record.MinimumLengthPercentage
        .MaximumHeightPercentage = Record.MaximumHeightPercentage
        .MaximumWidthPercentage = Record.MaximumWidthPercentage
        .MaximumLengthPercentage = Record.MaximumLengthPercentage
      End With
      Return SIS.VR.vrVTDefault.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrVTDefault) As SIS.VR.vrVTDefault
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVTDefaultUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumCapacityPercentage",SqlDbType.Decimal,9, Record.MinimumCapacityPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumCapacityPercentage",SqlDbType.Decimal,9, Record.MaximumCapacityPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumHeightPercentage",SqlDbType.Decimal,9, Record.MinimumHeightPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumWidthPercentage",SqlDbType.Decimal,9, Record.MinimumWidthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumLengthPercentage",SqlDbType.Decimal,9, Record.MinimumLengthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumHeightPercentage",SqlDbType.Decimal,9, Record.MaximumHeightPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumWidthPercentage",SqlDbType.Decimal,9, Record.MaximumWidthPercentage)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumLengthPercentage",SqlDbType.Decimal,9, Record.MaximumLengthPercentage)
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
    Public Shared Function vrVTDefaultDelete(ByVal Record As SIS.VR.vrVTDefault) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVTDefaultDelete"
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
      _MinimumCapacityPercentage = Ctype(Reader("MinimumCapacityPercentage"),Decimal)
      _MaximumCapacityPercentage = Ctype(Reader("MaximumCapacityPercentage"),Decimal)
      _MinimumHeightPercentage = Ctype(Reader("MinimumHeightPercentage"),Decimal)
      _MinimumWidthPercentage = Ctype(Reader("MinimumWidthPercentage"),Decimal)
      _MinimumLengthPercentage = Ctype(Reader("MinimumLengthPercentage"),Decimal)
      _MaximumHeightPercentage = Ctype(Reader("MaximumHeightPercentage"),Decimal)
      _MaximumWidthPercentage = Ctype(Reader("MaximumWidthPercentage"),Decimal)
      _MaximumLengthPercentage = Ctype(Reader("MaximumLengthPercentage"),Decimal)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
