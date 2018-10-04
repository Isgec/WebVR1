Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrRequestReasons
    Private Shared _RecordCount As Integer
    Private _ReasonID As Int32 = 0
    Private _Description As String = ""
    Private _Transporter As Boolean = False
    Private _ISGEC As Boolean = False
    Private _Supplier As Boolean = False
    Private _Other As Boolean = False
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
    Public Property ReasonID() As Int32
      Get
        Return _ReasonID
      End Get
      Set(ByVal value As Int32)
        _ReasonID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property Transporter() As Boolean
      Get
        Return _Transporter
      End Get
      Set(ByVal value As Boolean)
        _Transporter = value
      End Set
    End Property
    Public Property ISGEC() As Boolean
      Get
        Return _ISGEC
      End Get
      Set(ByVal value As Boolean)
        _ISGEC = value
      End Set
    End Property
    Public Property Supplier() As Boolean
      Get
        Return _Supplier
      End Get
      Set(ByVal value As Boolean)
        _Supplier = value
      End Set
    End Property
    Public Property Other() As Boolean
      Get
        Return _Other
      End Get
      Set(ByVal value As Boolean)
        _Other = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(100, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ReasonID
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
    Public Class PKvrRequestReasons
			Private _ReasonID As Int32 = 0
			Public Property ReasonID() As Int32
				Get
					Return _ReasonID
				End Get
				Set(ByVal value As Int32)
					_ReasonID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestReasonsSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrRequestReasons)
      Dim Results As List(Of SIS.VR.vrRequestReasons) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestReasonsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestReasons)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestReasons(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestReasonsGetNewRecord() As SIS.VR.vrRequestReasons
      Return New SIS.VR.vrRequestReasons()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestReasonsGetByID(ByVal ReasonID As Int32) As SIS.VR.vrRequestReasons
      Dim Results As SIS.VR.vrRequestReasons = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestReasonsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonID",SqlDbType.Int,ReasonID.ToString.Length, ReasonID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrRequestReasons(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestReasonsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.VR.vrRequestReasons)
      Dim Results As List(Of SIS.VR.vrRequestReasons) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrRequestReasonsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrRequestReasonsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestReasons)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestReasons(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrRequestReasonsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrRequestReasonsInsert(ByVal Record As SIS.VR.vrRequestReasons) As SIS.VR.vrRequestReasons
      Dim _Rec As SIS.VR.vrRequestReasons = SIS.VR.vrRequestReasons.vrRequestReasonsGetNewRecord()
      With _Rec
        .Description = Record.Description
        .Transporter = Record.Transporter
        .ISGEC = Record.ISGEC
        .Supplier = Record.Supplier
        .Other = Record.Other
      End With
      Return SIS.VR.vrRequestReasons.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrRequestReasons) As SIS.VR.vrRequestReasons
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestReasonsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Transporter",SqlDbType.Bit,3, Record.Transporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGEC",SqlDbType.Bit,3, Record.ISGEC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Supplier",SqlDbType.Bit,3, Record.Supplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Other",SqlDbType.Bit,3, Record.Other)
          Cmd.Parameters.Add("@Return_ReasonID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_ReasonID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ReasonID = Cmd.Parameters("@Return_ReasonID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrRequestReasonsUpdate(ByVal Record As SIS.VR.vrRequestReasons) As SIS.VR.vrRequestReasons
      Dim _Rec As SIS.VR.vrRequestReasons = SIS.VR.vrRequestReasons.vrRequestReasonsGetByID(Record.ReasonID)
      With _Rec
        .Description = Record.Description
        .Transporter = Record.Transporter
        .ISGEC = Record.ISGEC
        .Supplier = Record.Supplier
        .Other = Record.Other
      End With
      Return SIS.VR.vrRequestReasons.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrRequestReasons) As SIS.VR.vrRequestReasons
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestReasonsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReasonID",SqlDbType.Int,11, Record.ReasonID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,101, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Transporter",SqlDbType.Bit,3, Record.Transporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGEC",SqlDbType.Bit,3, Record.ISGEC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Supplier",SqlDbType.Bit,3, Record.Supplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Other",SqlDbType.Bit,3, Record.Other)
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
    Public Shared Function vrRequestReasonsDelete(ByVal Record As SIS.VR.vrRequestReasons) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestReasonsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ReasonID",SqlDbType.Int,Record.ReasonID.ToString.Length, Record.ReasonID)
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
'		Autocomplete Method
		Public Shared Function SelectvrRequestReasonsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrRequestReasonsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(100, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.VR.vrRequestReasons = New SIS.VR.vrRequestReasons(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ReasonID = Ctype(Reader("ReasonID"),Int32)
      _Description = Ctype(Reader("Description"),String)
      _Transporter = Ctype(Reader("Transporter"),Boolean)
      _ISGEC = Ctype(Reader("ISGEC"),Boolean)
      _Supplier = Ctype(Reader("Supplier"),Boolean)
      _Other = Ctype(Reader("Other"),Boolean)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
