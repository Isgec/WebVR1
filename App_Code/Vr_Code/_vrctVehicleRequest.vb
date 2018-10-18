Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrctVehicleRequest
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _ItemReference As String = ""
    Private _ActivityID As String = ""
    Private _Quantity As String = "0.00"
    Private _IrefWeight As String = "0.00"
    Private _PartialOrFull As String = ""
    Private _ProgressPercent As String = "0.00"
    Private _ProgressWeight As String = "0.00"
    Private _Project As String = ""
    Private _Product As String = ""
    Private _SelectedList As String = ""
    Private _VRRequestNo As Int32 = 0
    Private _PONumber As String = ""
    Private _GridLineStatus As String = ""
    Private _NotSelectedList As String = ""
    Private _Activity3Desc As String = ""
    Private _Handle As String = ""
    Private _Activity4Desc As String = ""
    Private _ItemUnit As String = ""
    Private _PercentOfQuantity As String = "0.00"
    Private _Activity2Desc As String = ""
    Private _VR_VehicleRequest1_RequestDescription As String = ""
    Private _FK_VR_CT_VehicleRequest_VRRequestNo As SIS.VR.vrVehicleRequest = Nothing
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
    Public Property ItemReference() As String
      Get
        Return _ItemReference
      End Get
      Set(ByVal value As String)
        _ItemReference = value
      End Set
    End Property
    Public Property ActivityID() As String
      Get
        Return _ActivityID
      End Get
      Set(ByVal value As String)
        _ActivityID = value
      End Set
    End Property
    Public Property Quantity() As String
      Get
        Return _Quantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Quantity = "0.00"
         Else
           _Quantity = value
         End If
      End Set
    End Property
    Public Property IrefWeight() As String
      Get
        Return _IrefWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _IrefWeight = "0.00"
         Else
           _IrefWeight = value
         End If
      End Set
    End Property
    Public Property PartialOrFull() As String
      Get
        Return _PartialOrFull
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PartialOrFull = ""
         Else
           _PartialOrFull = value
         End If
      End Set
    End Property
    Public Property ProgressPercent() As String
      Get
        Return _ProgressPercent
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProgressPercent = "0.00"
         Else
           _ProgressPercent = value
         End If
      End Set
    End Property
    Public Property ProgressWeight() As String
      Get
        Return _ProgressWeight
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ProgressWeight = "0.00"
         Else
           _ProgressWeight = value
         End If
      End Set
    End Property
    Public Property Project() As String
      Get
        Return _Project
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Project = ""
         Else
           _Project = value
         End If
      End Set
    End Property
    Public Property Product() As String
      Get
        Return _Product
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Product = ""
         Else
           _Product = value
         End If
      End Set
    End Property
    Public Property SelectedList() As String
      Get
        Return _SelectedList
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SelectedList = ""
         Else
           _SelectedList = value
         End If
      End Set
    End Property
    Public Property VRRequestNo() As Int32
      Get
        Return _VRRequestNo
      End Get
      Set(ByVal value As Int32)
        _VRRequestNo = value
      End Set
    End Property
    Public Property PONumber() As String
      Get
        Return _PONumber
      End Get
      Set(ByVal value As String)
        _PONumber = value
      End Set
    End Property
    Public Property GridLineStatus() As String
      Get
        Return _GridLineStatus
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _GridLineStatus = ""
         Else
           _GridLineStatus = value
         End If
      End Set
    End Property
    Public Property NotSelectedList() As String
      Get
        Return _NotSelectedList
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _NotSelectedList = ""
         Else
           _NotSelectedList = value
         End If
      End Set
    End Property
    Public Property Activity3Desc() As String
      Get
        Return _Activity3Desc
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Activity3Desc = ""
         Else
           _Activity3Desc = value
         End If
      End Set
    End Property
    Public Property Handle() As String
      Get
        Return _Handle
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Handle = ""
         Else
           _Handle = value
         End If
      End Set
    End Property
    Public Property Activity4Desc() As String
      Get
        Return _Activity4Desc
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Activity4Desc = ""
         Else
           _Activity4Desc = value
         End If
      End Set
    End Property
    Public Property ItemUnit() As String
      Get
        Return _ItemUnit
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _ItemUnit = ""
         Else
           _ItemUnit = value
         End If
      End Set
    End Property
    Public Property PercentOfQuantity() As String
      Get
        Return _PercentOfQuantity
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _PercentOfQuantity = "0.00"
         Else
           _PercentOfQuantity = value
         End If
      End Set
    End Property
    Public Property Activity2Desc() As String
      Get
        Return _Activity2Desc
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Activity2Desc = ""
         Else
           _Activity2Desc = value
         End If
      End Set
    End Property
    Public Property VR_VehicleRequest1_RequestDescription() As String
      Get
        Return _VR_VehicleRequest1_RequestDescription
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VR_VehicleRequest1_RequestDescription = ""
         Else
           _VR_VehicleRequest1_RequestDescription = value
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
        Return _VRRequestNo & "|" & _SerialNo
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
    Public Class PKvrctVehicleRequest
      Private _VRRequestNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property VRRequestNo() As Int32
        Get
          Return _VRRequestNo
        End Get
        Set(ByVal value As Int32)
          _VRRequestNo = value
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
    Public ReadOnly Property FK_VR_CT_VehicleRequest_VRRequestNo() As SIS.VR.vrVehicleRequest
      Get
        If _FK_VR_CT_VehicleRequest_VRRequestNo Is Nothing Then
          _FK_VR_CT_VehicleRequest_VRRequestNo = SIS.VR.vrVehicleRequest.UZ_vrVehicleRequestGetByID(_VRRequestNo)
        End If
        Return _FK_VR_CT_VehicleRequest_VRRequestNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrctVehicleRequestGetNewRecord() As SIS.VR.vrctVehicleRequest
      Return New SIS.VR.vrctVehicleRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrctVehicleRequestGetByID(ByVal VRRequestNo As Int32, ByVal SerialNo As Int32) As SIS.VR.vrctVehicleRequest
      Dim Results As SIS.VR.vrctVehicleRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrctVehicleRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRequestNo",SqlDbType.Int,VRRequestNo.ToString.Length, VRRequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrctVehicleRequest(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrctVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRequestNo As Int32) As List(Of SIS.VR.vrctVehicleRequest)
      Dim Results As List(Of SIS.VR.vrctVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrctVehicleRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrctVehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VRRequestNo",SqlDbType.Int,10, IIf(VRRequestNo = Nothing, 0,VRRequestNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrctVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrctVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrctVehicleRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal VRRequestNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrctVehicleRequestGetByID(ByVal VRRequestNo As Int32, ByVal SerialNo As Int32, ByVal Filter_VRRequestNo As Int32) As SIS.VR.vrctVehicleRequest
      Return vrctVehicleRequestGetByID(VRRequestNo, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrctVehicleRequestInsert(ByVal Record As SIS.VR.vrctVehicleRequest) As SIS.VR.vrctVehicleRequest
      Dim _Rec As SIS.VR.vrctVehicleRequest = SIS.VR.vrctVehicleRequest.vrctVehicleRequestGetNewRecord()
      With _Rec
        .SerialNo = Record.SerialNo
        .ItemReference = Record.ItemReference
        .ActivityID = Record.ActivityID
        .Quantity = Record.Quantity
        .IrefWeight = Record.IrefWeight
        .PartialOrFull = Record.PartialOrFull
        .ProgressPercent = Record.ProgressPercent
        .ProgressWeight = Record.ProgressWeight
        .Project = Record.Project
        .Product = Record.Product
        .SelectedList = Record.SelectedList
        .VRRequestNo = Record.VRRequestNo
        .PONumber = Record.PONumber
        .GridLineStatus = Record.GridLineStatus
        .NotSelectedList = Record.NotSelectedList
        .Activity3Desc = Record.Activity3Desc
        .Handle = Record.Handle
        .Activity4Desc = Record.Activity4Desc
        .ItemUnit = Record.ItemUnit
        .PercentOfQuantity = Record.PercentOfQuantity
        .Activity2Desc = Record.Activity2Desc
      End With
      Return SIS.VR.vrctVehicleRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrctVehicleRequest) As SIS.VR.vrctVehicleRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrctVehicleRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemReference",SqlDbType.VarChar,201, Record.ItemReference)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActivityID",SqlDbType.VarChar,10, Record.ActivityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IrefWeight",SqlDbType.Decimal,23, Iif(Record.IrefWeight= "" ,Convert.DBNull, Record.IrefWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartialOrFull",SqlDbType.VarChar,11, Iif(Record.PartialOrFull= "" ,Convert.DBNull, Record.PartialOrFull))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProgressPercent", SqlDbType.Decimal, 23, IIf(Record.ProgressPercent = "", Convert.DBNull, Record.ProgressPercent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProgressWeight",SqlDbType.Decimal,23, Iif(Record.ProgressWeight= "" ,Convert.DBNull, Record.ProgressWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Project",SqlDbType.VarChar,10, Iif(Record.Project= "" ,Convert.DBNull, Record.Project))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Product",SqlDbType.VarChar,10, Iif(Record.Product= "" ,Convert.DBNull, Record.Product))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SelectedList",SqlDbType.VarChar,501, Iif(Record.SelectedList= "" ,Convert.DBNull, Record.SelectedList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRequestNo",SqlDbType.Int,11, Record.VRRequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Record.PONumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GridLineStatus",SqlDbType.Int,11, Iif(Record.GridLineStatus= "" ,Convert.DBNull, Record.GridLineStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotSelectedList",SqlDbType.VarChar,501, Iif(Record.NotSelectedList= "" ,Convert.DBNull, Record.NotSelectedList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity3Desc",SqlDbType.VarChar,151, Iif(Record.Activity3Desc= "" ,Convert.DBNull, Record.Activity3Desc))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Handle",SqlDbType.VarChar,51, Iif(Record.Handle= "" ,Convert.DBNull, Record.Handle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity4Desc",SqlDbType.VarChar,151, Iif(Record.Activity4Desc= "" ,Convert.DBNull, Record.Activity4Desc))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemUnit",SqlDbType.VarChar,21, Iif(Record.ItemUnit= "" ,Convert.DBNull, Record.ItemUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PercentOfQuantity",SqlDbType.Decimal,23, Iif(Record.PercentOfQuantity= "" ,Convert.DBNull, Record.PercentOfQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity2Desc",SqlDbType.VarChar,151, Iif(Record.Activity2Desc= "" ,Convert.DBNull, Record.Activity2Desc))
          Cmd.Parameters.Add("@Return_VRRequestNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_VRRequestNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.VRRequestNo = Cmd.Parameters("@Return_VRRequestNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrctVehicleRequestUpdate(ByVal Record As SIS.VR.vrctVehicleRequest) As SIS.VR.vrctVehicleRequest
      Dim _Rec As SIS.VR.vrctVehicleRequest = SIS.VR.vrctVehicleRequest.vrctVehicleRequestGetByID(Record.VRRequestNo, Record.SerialNo)
      With _Rec
        .ItemReference = Record.ItemReference
        .ActivityID = Record.ActivityID
        .Quantity = Record.Quantity
        .IrefWeight = Record.IrefWeight
        .PartialOrFull = Record.PartialOrFull
        .ProgressPercent = Record.ProgressPercent
        .ProgressWeight = Record.ProgressWeight
        .Project = Record.Project
        .Product = Record.Product
        .SelectedList = Record.SelectedList
        .PONumber = Record.PONumber
        .GridLineStatus = Record.GridLineStatus
        .NotSelectedList = Record.NotSelectedList
        .Activity3Desc = Record.Activity3Desc
        .Handle = Record.Handle
        .Activity4Desc = Record.Activity4Desc
        .ItemUnit = Record.ItemUnit
        .PercentOfQuantity = Record.PercentOfQuantity
        .Activity2Desc = Record.Activity2Desc
      End With
      Return SIS.VR.vrctVehicleRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrctVehicleRequest) As SIS.VR.vrctVehicleRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrctVehicleRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRRequestNo",SqlDbType.Int,11, Record.VRRequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemReference",SqlDbType.VarChar,201, Record.ItemReference)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ActivityID",SqlDbType.VarChar,10, Record.ActivityID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Quantity",SqlDbType.Decimal,23, Iif(Record.Quantity= "" ,Convert.DBNull, Record.Quantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IrefWeight",SqlDbType.Decimal,23, Iif(Record.IrefWeight= "" ,Convert.DBNull, Record.IrefWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PartialOrFull",SqlDbType.VarChar,11, Iif(Record.PartialOrFull= "" ,Convert.DBNull, Record.PartialOrFull))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProgressPercent", SqlDbType.Decimal, 23, IIf(Record.ProgressPercent = "", Convert.DBNull, Record.ProgressPercent))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProgressWeight",SqlDbType.Decimal,23, Iif(Record.ProgressWeight= "" ,Convert.DBNull, Record.ProgressWeight))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Project",SqlDbType.VarChar,10, Iif(Record.Project= "" ,Convert.DBNull, Record.Project))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Product",SqlDbType.VarChar,10, Iif(Record.Product= "" ,Convert.DBNull, Record.Product))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SelectedList",SqlDbType.VarChar,501, Iif(Record.SelectedList= "" ,Convert.DBNull, Record.SelectedList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VRRequestNo",SqlDbType.Int,11, Record.VRRequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONumber",SqlDbType.NVarChar,10, Record.PONumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GridLineStatus",SqlDbType.Int,11, Iif(Record.GridLineStatus= "" ,Convert.DBNull, Record.GridLineStatus))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NotSelectedList",SqlDbType.VarChar,501, Iif(Record.NotSelectedList= "" ,Convert.DBNull, Record.NotSelectedList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity3Desc",SqlDbType.VarChar,151, Iif(Record.Activity3Desc= "" ,Convert.DBNull, Record.Activity3Desc))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Handle",SqlDbType.VarChar,51, Iif(Record.Handle= "" ,Convert.DBNull, Record.Handle))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity4Desc",SqlDbType.VarChar,151, Iif(Record.Activity4Desc= "" ,Convert.DBNull, Record.Activity4Desc))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemUnit",SqlDbType.VarChar,21, Iif(Record.ItemUnit= "" ,Convert.DBNull, Record.ItemUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PercentOfQuantity",SqlDbType.Decimal,23, Iif(Record.PercentOfQuantity= "" ,Convert.DBNull, Record.PercentOfQuantity))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Activity2Desc",SqlDbType.VarChar,151, Iif(Record.Activity2Desc= "" ,Convert.DBNull, Record.Activity2Desc))
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
    Public Shared Function vrctVehicleRequestDelete(ByVal Record As SIS.VR.vrctVehicleRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrctVehicleRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_VRRequestNo",SqlDbType.Int,Record.VRRequestNo.ToString.Length, Record.VRRequestNo)
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
      Try
        For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
          If pi.MemberType = Reflection.MemberTypes.Property Then
            Try
              Dim Found As Boolean = False
              For I As Integer = 0 To Reader.FieldCount - 1
                If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                  Found = True
                  Exit For
                End If
              Next
              If Found Then
                If Convert.IsDBNull(Reader(pi.Name)) Then
                  Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                    Case "decimal"
                      CallByName(Me, pi.Name, CallType.Let, "0.00")
                    Case "bit"
                      CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                    Case Else
                      CallByName(Me, pi.Name, CallType.Let, String.Empty)
                  End Select
                Else
                  CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
                End If
              End If
            Catch ex As Exception
            End Try
          End If
        Next
      Catch ex As Exception
      End Try
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
