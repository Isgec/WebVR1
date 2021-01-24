Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrLorryReceiptDetails
    Private Shared _RecordCount As Integer
    Private _SerialNo As Int32 = 0
    Private _GRorLRNo As String = ""
    Private _GRorLRDate As String = ""
    Private _SupplierID As String = ""
    Private _SupplierInvoiceNo As String = ""
    Private _SupplierInvoiceDate As String = ""
    Private _WeightAsPerInvoiceInKG As Int32 = 0
    Private _WeightReceived As Int32 = 0
    Private _MaterialForm As String = ""
    Private _NoOfPackagesAsPerInvoice As Int32 = 0
    Private _NoOfPackagesReceived As Int32 = 0
    Private _CenvatInvoiceReceived As String = ""
    Private _Remarks As String = ""
    Private _ProjectID As String = ""
    Private _MRNNo As Int32 = 0
    Private _SupplierName As String = ""
    Private _IDM_Projects1_Description As String = ""
    Private _VR_BusinessPartner2_BPName As String = ""
    Private _VR_LorryReceipts3_WayBillFormNo As String = ""
    Private _FK_VR_LorryReceiptDetails_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_VR_LorryReceiptDetails_SupplierID As SIS.VR.vrBusinessPartner = Nothing
    Private _FK_VR_LorryReceiptDetails_MRNNo As SIS.VR.vrLorryReceipts = Nothing
    Public Property IRNO As String = ""
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
    Public Property GRorLRNo() As String
      Get
        Return _GRorLRNo
      End Get
      Set(ByVal value As String)
        _GRorLRNo = value
      End Set
    End Property
    Public Property GRorLRDate() As String
      Get
        If Not _GRorLRDate = String.Empty Then
          Return Convert.ToDateTime(_GRorLRDate).ToString("dd/MM/yyyy")
        End If
        Return _GRorLRDate
      End Get
      Set(ByVal value As String)
         _GRorLRDate = value
      End Set
    End Property
    Public Property SupplierID() As String
      Get
        Return _SupplierID
      End Get
      Set(ByVal value As String)
        _SupplierID = value
      End Set
    End Property
    Public Property SupplierInvoiceNo() As String
      Get
        Return _SupplierInvoiceNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierInvoiceNo = ""
         Else
           _SupplierInvoiceNo = value
         End If
      End Set
    End Property
    Public Property SupplierInvoiceDate() As String
      Get
        If Not _SupplierInvoiceDate = String.Empty Then
          Return Convert.ToDateTime(_SupplierInvoiceDate).ToString("dd/MM/yyyy")
        End If
        Return _SupplierInvoiceDate
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierInvoiceDate = ""
         Else
           _SupplierInvoiceDate = value
         End If
      End Set
    End Property
    Public Property WeightAsPerInvoiceInKG() As Int32
      Get
        Return _WeightAsPerInvoiceInKG
      End Get
      Set(ByVal value As Int32)
        _WeightAsPerInvoiceInKG = value
      End Set
    End Property
    Public Property WeightReceived() As Int32
      Get
        Return _WeightReceived
      End Get
      Set(ByVal value As Int32)
        _WeightReceived = value
      End Set
    End Property
    Public Property MaterialForm() As String
      Get
        Return _MaterialForm
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _MaterialForm = ""
         Else
           _MaterialForm = value
         End If
      End Set
    End Property
    Public Property NoOfPackagesAsPerInvoice() As Int32
      Get
        Return _NoOfPackagesAsPerInvoice
      End Get
      Set(ByVal value As Int32)
        _NoOfPackagesAsPerInvoice = value
      End Set
    End Property
    Public Property NoOfPackagesReceived() As Int32
      Get
        Return _NoOfPackagesReceived
      End Get
      Set(ByVal value As Int32)
        _NoOfPackagesReceived = value
      End Set
    End Property
    Public Property CenvatInvoiceReceived() As String
      Get
        Return _CenvatInvoiceReceived
      End Get
      Set(ByVal value As String)
        _CenvatInvoiceReceived = value
      End Set
    End Property
    Public Property Remarks() As String
      Get
        Return _Remarks
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _Remarks = ""
         Else
           _Remarks = value
         End If
      End Set
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property MRNNo() As Int32
      Get
        Return _MRNNo
      End Get
      Set(ByVal value As Int32)
        _MRNNo = value
      End Set
    End Property
    Public Property SupplierName() As String
      Get
        Return _SupplierName
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _SupplierName = ""
         Else
           _SupplierName = value
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
    Public Property VR_BusinessPartner2_BPName() As String
      Get
        Return _VR_BusinessPartner2_BPName
      End Get
      Set(ByVal value As String)
        _VR_BusinessPartner2_BPName = value
      End Set
    End Property
    Public Property VR_LorryReceipts3_WayBillFormNo() As String
      Get
        Return _VR_LorryReceipts3_WayBillFormNo
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _VR_LorryReceipts3_WayBillFormNo = ""
         Else
           _VR_LorryReceipts3_WayBillFormNo = value
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
        Return _ProjectID & "|" & _MRNNo & "|" & _SerialNo
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
    Public Class PKvrLorryReceiptDetails
      Private _ProjectID As String = ""
      Private _MRNNo As Int32 = 0
      Private _SerialNo As Int32 = 0
      Public Property ProjectID() As String
        Get
          Return _ProjectID
        End Get
        Set(ByVal value As String)
          _ProjectID = value
        End Set
      End Property
      Public Property MRNNo() As Int32
        Get
          Return _MRNNo
        End Get
        Set(ByVal value As Int32)
          _MRNNo = value
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
    Public ReadOnly Property FK_VR_LorryReceiptDetails_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_LorryReceiptDetails_ProjectID Is Nothing Then
          _FK_VR_LorryReceiptDetails_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_VR_LorryReceiptDetails_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceiptDetails_SupplierID() As SIS.VR.vrBusinessPartner
      Get
        If _FK_VR_LorryReceiptDetails_SupplierID Is Nothing Then
          _FK_VR_LorryReceiptDetails_SupplierID = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(_SupplierID)
        End If
        Return _FK_VR_LorryReceiptDetails_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_VR_LorryReceiptDetails_MRNNo() As SIS.VR.vrLorryReceipts
      Get
        If _FK_VR_LorryReceiptDetails_MRNNo Is Nothing Then
          _FK_VR_LorryReceiptDetails_MRNNo = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(_ProjectID, _MRNNo)
        End If
        Return _FK_VR_LorryReceiptDetails_MRNNo
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptDetailsGetNewRecord() As SIS.VR.vrLorryReceiptDetails
      Return New SIS.VR.vrLorryReceiptDetails()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptDetailsGetByID(ByVal ProjectID As String, ByVal MRNNo As Int32, ByVal SerialNo As Int32) As SIS.VR.vrLorryReceiptDetails
      Dim Results As SIS.VR.vrLorryReceiptDetails = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLorryReceiptDetailsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,MRNNo.ToString.Length, MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrLorryReceiptDetails(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptDetailsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal MRNNo As Int32) As List(Of SIS.VR.vrLorryReceiptDetails)
      Dim Results As List(Of SIS.VR.vrLorryReceiptDetails) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrLorryReceiptDetailsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrLorryReceiptDetailsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_MRNNo",SqlDbType.Int,10, IIf(MRNNo = Nothing, 0,MRNNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrLorryReceiptDetails)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLorryReceiptDetails(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrLorryReceiptDetailsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal MRNNo As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptDetailsGetByID(ByVal ProjectID As String, ByVal MRNNo As Int32, ByVal SerialNo As Int32, ByVal Filter_ProjectID As String, ByVal Filter_MRNNo As Int32) As SIS.VR.vrLorryReceiptDetails
      Return vrLorryReceiptDetailsGetByID(ProjectID, MRNNo, SerialNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrLorryReceiptDetailsInsert(ByVal Record As SIS.VR.vrLorryReceiptDetails) As SIS.VR.vrLorryReceiptDetails
      Dim _Rec As SIS.VR.vrLorryReceiptDetails = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetNewRecord()
      With _Rec
        .GRorLRNo = Record.GRorLRNo
        .GRorLRDate = Record.GRorLRDate
        .SupplierID = Record.SupplierID
        .SupplierInvoiceNo = Record.SupplierInvoiceNo
        .SupplierInvoiceDate = Record.SupplierInvoiceDate
        .WeightAsPerInvoiceInKG = Record.WeightAsPerInvoiceInKG
        .WeightReceived = Record.WeightReceived
        .MaterialForm = Record.MaterialForm
        .NoOfPackagesAsPerInvoice = Record.NoOfPackagesAsPerInvoice
        .NoOfPackagesReceived = Record.NoOfPackagesReceived
        .CenvatInvoiceReceived = Record.CenvatInvoiceReceived
        .Remarks = Record.Remarks
        .ProjectID = Record.ProjectID
        .MRNNo = Record.MRNNo
        .SupplierName = Record.SupplierName
        .IRNO = Record.IRNO
      End With
      Return SIS.VR.vrLorryReceiptDetails.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrLorryReceiptDetails) As SIS.VR.vrLorryReceiptDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLorryReceiptDetailsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRorLRNo",SqlDbType.NVarChar,51, Record.GRorLRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRorLRDate",SqlDbType.DateTime,21, Record.GRorLRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierInvoiceNo",SqlDbType.NVarChar,51, Iif(Record.SupplierInvoiceNo= "" ,Convert.DBNull, Record.SupplierInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierInvoiceDate",SqlDbType.DateTime,21, Iif(Record.SupplierInvoiceDate= "" ,Convert.DBNull, Record.SupplierInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightAsPerInvoiceInKG",SqlDbType.Int,11, Record.WeightAsPerInvoiceInKG)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightReceived",SqlDbType.Int,11, Record.WeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialForm",SqlDbType.NVarChar,11, Iif(Record.MaterialForm= "" ,Convert.DBNull, Record.MaterialForm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackagesAsPerInvoice",SqlDbType.Int,11, Record.NoOfPackagesAsPerInvoice)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackagesReceived",SqlDbType.Int,11, Record.NoOfPackagesReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CenvatInvoiceReceived",SqlDbType.NVarChar,11, Record.CenvatInvoiceReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,151, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName", SqlDbType.NVarChar, 51, IIf(Record.SupplierName = "", Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNO", SqlDbType.NVarChar, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
          Cmd.Parameters.Add("@Return_ProjectID", SqlDbType.NVarChar, 7)
          Cmd.Parameters("@Return_ProjectID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_MRNNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_MRNNo").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.ProjectID = Cmd.Parameters("@Return_ProjectID").Value
          Record.MRNNo = Cmd.Parameters("@Return_MRNNo").Value
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrLorryReceiptDetailsUpdate(ByVal Record As SIS.VR.vrLorryReceiptDetails) As SIS.VR.vrLorryReceiptDetails
      Dim _Rec As SIS.VR.vrLorryReceiptDetails = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetByID(Record.ProjectID, Record.MRNNo, Record.SerialNo)
      With _Rec
        .GRorLRNo = Record.GRorLRNo
        .GRorLRDate = Record.GRorLRDate
        .SupplierID = Record.SupplierID
        .SupplierInvoiceNo = Record.SupplierInvoiceNo
        .SupplierInvoiceDate = Record.SupplierInvoiceDate
        .WeightAsPerInvoiceInKG = Record.WeightAsPerInvoiceInKG
        .WeightReceived = Record.WeightReceived
        .MaterialForm = Record.MaterialForm
        .NoOfPackagesAsPerInvoice = Record.NoOfPackagesAsPerInvoice
        .NoOfPackagesReceived = Record.NoOfPackagesReceived
        .CenvatInvoiceReceived = Record.CenvatInvoiceReceived
        .Remarks = Record.Remarks
        .SupplierName = Record.SupplierName
        .IRNO = Record.IRNO
      End With
      Return SIS.VR.vrLorryReceiptDetails.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrLorryReceiptDetails) As SIS.VR.vrLorryReceiptDetails
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLorryReceiptDetailsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo",SqlDbType.Int,11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRorLRNo",SqlDbType.NVarChar,51, Record.GRorLRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRorLRDate",SqlDbType.DateTime,21, Record.GRorLRDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,10, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierInvoiceNo",SqlDbType.NVarChar,51, Iif(Record.SupplierInvoiceNo= "" ,Convert.DBNull, Record.SupplierInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierInvoiceDate",SqlDbType.DateTime,21, Iif(Record.SupplierInvoiceDate= "" ,Convert.DBNull, Record.SupplierInvoiceDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightAsPerInvoiceInKG",SqlDbType.Int,11, Record.WeightAsPerInvoiceInKG)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightReceived",SqlDbType.Int,11, Record.WeightReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialForm",SqlDbType.NVarChar,11, Iif(Record.MaterialForm= "" ,Convert.DBNull, Record.MaterialForm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackagesAsPerInvoice",SqlDbType.Int,11, Record.NoOfPackagesAsPerInvoice)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackagesReceived",SqlDbType.Int,11, Record.NoOfPackagesReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CenvatInvoiceReceived",SqlDbType.NVarChar,11, Record.CenvatInvoiceReceived)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,151, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,11, Record.MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierName",SqlDbType.NVarChar,51, Iif(Record.SupplierName= "" ,Convert.DBNull, Record.SupplierName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNO", SqlDbType.NVarChar, 11, IIf(Record.IRNO = "", Convert.DBNull, Record.IRNO))
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
    Public Shared Function vrLorryReceiptDetailsDelete(ByVal Record As SIS.VR.vrLorryReceiptDetails) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLorryReceiptDetailsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_ProjectID",SqlDbType.NVarChar,Record.ProjectID.ToString.Length, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_MRNNo",SqlDbType.Int,Record.MRNNo.ToString.Length, Record.MRNNo)
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
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
