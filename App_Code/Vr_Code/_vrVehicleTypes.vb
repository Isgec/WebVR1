Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrVehicleTypes
    Private Shared _RecordCount As Integer
    Private _VehicleTypeID As Int32 = 0
    Private _Description As String = ""
    Private _DefineCapacity As Boolean = False
    Private _CapacityInKG As Decimal = 0
    Private _DefineDimention As Boolean = False
    Private _HeightInFt As Decimal = 0
    Private _WidthInFt As Decimal = 0
    Private _LengthInFt As Decimal = 0
    Private _EnforceMinimumCapacity As Boolean = False
    Private _MinimumCapacity As Decimal = 0
    Private _EnforceMaximumCapacity As Boolean = False
    Private _MaximumCapacity As Decimal = 0
    Private _EnforceMinimumDimention As Boolean = False
    Private _MinimumHeight As Decimal = 0
    Private _MinimumWidth As Decimal = 0
    Private _MinimumLength As Decimal = 0
    Private _EnforceMaximumDimention As Boolean = False
    Private _MaximumHeight As Decimal = 0
    Private _MaximumWidth As Decimal = 0
    Private _MaximumLength As Decimal = 0
    Private _cmba As String = ""
    Private _DailyRunning As Decimal = 0
    Public Property Active As Boolean = False
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
    Public Property VehicleTypeID() As Int32
      Get
        Return _VehicleTypeID
      End Get
      Set(ByVal value As Int32)
        _VehicleTypeID = value
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
    Public Property DefineCapacity() As Boolean
      Get
        Return _DefineCapacity
      End Get
      Set(ByVal value As Boolean)
        _DefineCapacity = value
      End Set
    End Property
    Public Property CapacityInKG() As Decimal
      Get
        Return _CapacityInKG
      End Get
      Set(ByVal value As Decimal)
        _CapacityInKG = value
      End Set
    End Property
    Public Property DefineDimention() As Boolean
      Get
        Return _DefineDimention
      End Get
      Set(ByVal value As Boolean)
        _DefineDimention = value
      End Set
    End Property
    Public Property HeightInFt() As Decimal
      Get
        Return _HeightInFt
      End Get
      Set(ByVal value As Decimal)
        _HeightInFt = value
      End Set
    End Property
    Public Property WidthInFt() As Decimal
      Get
        Return _WidthInFt
      End Get
      Set(ByVal value As Decimal)
        _WidthInFt = value
      End Set
    End Property
    Public Property LengthInFt() As Decimal
      Get
        Return _LengthInFt
      End Get
      Set(ByVal value As Decimal)
        _LengthInFt = value
      End Set
    End Property
    Public Property EnforceMinimumCapacity() As Boolean
      Get
        Return _EnforceMinimumCapacity
      End Get
      Set(ByVal value As Boolean)
        _EnforceMinimumCapacity = value
      End Set
    End Property
    Public Property MinimumCapacity() As Decimal
      Get
        Return _MinimumCapacity
      End Get
      Set(ByVal value As Decimal)
        _MinimumCapacity = value
      End Set
    End Property
    Public Property EnforceMaximumCapacity() As Boolean
      Get
        Return _EnforceMaximumCapacity
      End Get
      Set(ByVal value As Boolean)
        _EnforceMaximumCapacity = value
      End Set
    End Property
    Public Property MaximumCapacity() As Decimal
      Get
        Return _MaximumCapacity
      End Get
      Set(ByVal value As Decimal)
        _MaximumCapacity = value
      End Set
    End Property
    Public Property EnforceMinimumDimention() As Boolean
      Get
        Return _EnforceMinimumDimention
      End Get
      Set(ByVal value As Boolean)
        _EnforceMinimumDimention = value
      End Set
    End Property
    Public Property MinimumHeight() As Decimal
      Get
        Return _MinimumHeight
      End Get
      Set(ByVal value As Decimal)
        _MinimumHeight = value
      End Set
    End Property
    Public Property MinimumWidth() As Decimal
      Get
        Return _MinimumWidth
      End Get
      Set(ByVal value As Decimal)
        _MinimumWidth = value
      End Set
    End Property
    Public Property MinimumLength() As Decimal
      Get
        Return _MinimumLength
      End Get
      Set(ByVal value As Decimal)
        _MinimumLength = value
      End Set
    End Property
    Public Property EnforceMaximumDimention() As Boolean
      Get
        Return _EnforceMaximumDimention
      End Get
      Set(ByVal value As Boolean)
        _EnforceMaximumDimention = value
      End Set
    End Property
    Public Property MaximumHeight() As Decimal
      Get
        Return _MaximumHeight
      End Get
      Set(ByVal value As Decimal)
        _MaximumHeight = value
      End Set
    End Property
    Public Property MaximumWidth() As Decimal
      Get
        Return _MaximumWidth
      End Get
      Set(ByVal value As Decimal)
        _MaximumWidth = value
      End Set
    End Property
    Public Property MaximumLength() As Decimal
      Get
        Return _MaximumLength
      End Get
      Set(ByVal value As Decimal)
        _MaximumLength = value
      End Set
    End Property
    Public Property cmba() As String
      Get
        Return _cmba
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _cmba = ""
				 Else
					 _cmba = value
			   End If
      End Set
    End Property
    Public Property DailyRunning() As Decimal
      Get
        Return _DailyRunning
      End Get
      Set(ByVal value As Decimal)
        _DailyRunning = value
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _cmba.ToString   '.PadRight(63, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _VehicleTypeID
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
    Public Class PKvrVehicleTypes
			Private _VehicleTypeID As Int32 = 0
			Public Property VehicleTypeID() As Int32
				Get
					Return _VehicleTypeID
				End Get
				Set(ByVal value As Int32)
					_VehicleTypeID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleTypesSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrVehicleTypes)
      Dim Results As List(Of SIS.VR.vrVehicleTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleTypesGetNewRecord() As SIS.VR.vrVehicleTypes
      Return New SIS.VR.vrVehicleTypes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleTypesGetByID(ByVal VehicleTypeID As Int32) As SIS.VR.vrVehicleTypes
      Dim Results As SIS.VR.vrVehicleTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,VehicleTypeID.ToString.Length, VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrVehicleTypes(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.VR.vrVehicleTypes)
      Dim Results As List(Of SIS.VR.vrVehicleTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrVehicleTypesSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrVehicleTypesSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrVehicleTypesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrVehicleTypesInsert(ByVal Record As SIS.VR.vrVehicleTypes) As SIS.VR.vrVehicleTypes
      Dim _Rec As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.vrVehicleTypesGetNewRecord()
      With _Rec
        .Description = Record.Description
        .DefineCapacity = Record.DefineCapacity
        .CapacityInKG = Record.CapacityInKG
        .DefineDimention = Record.DefineDimention
        .HeightInFt = Record.HeightInFt
        .WidthInFt = Record.WidthInFt
        .LengthInFt = Record.LengthInFt
        .DailyRunning = Record.DailyRunning
        .Active = True
      End With
      Return SIS.VR.vrVehicleTypes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrVehicleTypes) As SIS.VR.vrVehicleTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefineCapacity",SqlDbType.Bit,3, Record.DefineCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CapacityInKG",SqlDbType.Decimal,21, Record.CapacityInKG)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefineDimention",SqlDbType.Bit,3, Record.DefineDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HeightInFt",SqlDbType.Decimal,9, Record.HeightInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WidthInFt",SqlDbType.Decimal,9, Record.WidthInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LengthInFt",SqlDbType.Decimal,9, Record.LengthInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMinimumCapacity",SqlDbType.Bit,3, Record.EnforceMinimumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumCapacity",SqlDbType.Decimal,21, Record.MinimumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMaximumCapacity",SqlDbType.Bit,3, Record.EnforceMaximumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumCapacity",SqlDbType.Decimal,21, Record.MaximumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMinimumDimention",SqlDbType.Bit,3, Record.EnforceMinimumDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumHeight",SqlDbType.Decimal,9, Record.MinimumHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumWidth",SqlDbType.Decimal,9, Record.MinimumWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumLength",SqlDbType.Decimal,9, Record.MinimumLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMaximumDimention",SqlDbType.Bit,3, Record.EnforceMaximumDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumHeight",SqlDbType.Decimal,9, Record.MaximumHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumWidth",SqlDbType.Decimal,9, Record.MaximumWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumLength",SqlDbType.Decimal,9, Record.MaximumLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DailyRunning", SqlDbType.Decimal, 6, Record.DailyRunning)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          Cmd.Parameters.Add("@Return_VehicleTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_VehicleTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.VehicleTypeID = Cmd.Parameters("@Return_VehicleTypeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrVehicleTypesUpdate(ByVal Record As SIS.VR.vrVehicleTypes) As SIS.VR.vrVehicleTypes
      Dim _Rec As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(Record.VehicleTypeID)
      With _Rec
        .Description = Record.Description
        .DefineCapacity = Record.DefineCapacity
        .CapacityInKG = Record.CapacityInKG
        .DefineDimention = Record.DefineDimention
        .HeightInFt = Record.HeightInFt
        .WidthInFt = Record.WidthInFt
        .LengthInFt = Record.LengthInFt
        .EnforceMinimumCapacity = Record.EnforceMinimumCapacity
        .MinimumCapacity = Record.MinimumCapacity
        .EnforceMaximumCapacity = Record.EnforceMaximumCapacity
        .MaximumCapacity = Record.MaximumCapacity
        .EnforceMinimumDimention = Record.EnforceMinimumDimention
        .MinimumHeight = Record.MinimumHeight
        .MinimumWidth = Record.MinimumWidth
        .MinimumLength = Record.MinimumLength
        .EnforceMaximumDimention = Record.EnforceMaximumDimention
        .MaximumHeight = Record.MaximumHeight
        .MaximumWidth = Record.MaximumWidth
        .MaximumLength = Record.MaximumLength
        .DailyRunning = Record.DailyRunning
        .Active = Record.Active
      End With
      Return SIS.VR.vrVehicleTypes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrVehicleTypes) As SIS.VR.vrVehicleTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VehicleTypeID",SqlDbType.Int,11, Record.VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description",SqlDbType.NVarChar,51, Record.Description)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefineCapacity",SqlDbType.Bit,3, Record.DefineCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CapacityInKG",SqlDbType.Decimal,21, Record.CapacityInKG)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DefineDimention",SqlDbType.Bit,3, Record.DefineDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HeightInFt",SqlDbType.Decimal,9, Record.HeightInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WidthInFt",SqlDbType.Decimal,9, Record.WidthInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LengthInFt",SqlDbType.Decimal,9, Record.LengthInFt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMinimumCapacity",SqlDbType.Bit,3, Record.EnforceMinimumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumCapacity",SqlDbType.Decimal,21, Record.MinimumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMaximumCapacity",SqlDbType.Bit,3, Record.EnforceMaximumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumCapacity",SqlDbType.Decimal,21, Record.MaximumCapacity)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMinimumDimention",SqlDbType.Bit,3, Record.EnforceMinimumDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumHeight",SqlDbType.Decimal,9, Record.MinimumHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumWidth",SqlDbType.Decimal,9, Record.MinimumWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MinimumLength",SqlDbType.Decimal,9, Record.MinimumLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EnforceMaximumDimention",SqlDbType.Bit,3, Record.EnforceMaximumDimention)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumHeight",SqlDbType.Decimal,9, Record.MaximumHeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumWidth",SqlDbType.Decimal,9, Record.MaximumWidth)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumLength",SqlDbType.Decimal,9, Record.MaximumLength)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DailyRunning", SqlDbType.Decimal, 6, Record.DailyRunning)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
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
    Public Shared Function vrVehicleTypesDelete(ByVal Record As SIS.VR.vrVehicleTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VehicleTypeID",SqlDbType.Int,Record.VehicleTypeID.ToString.Length, Record.VehicleTypeID)
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
    Public Shared Function SelectvrVehicleTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleTypesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(63, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.VR.vrVehicleTypes = New SIS.VR.vrVehicleTypes(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
