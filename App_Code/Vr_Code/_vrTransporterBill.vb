Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrTransporterBill
    Private Shared _RecordCount As Integer
    Private _IRNo As Int32 = 0
    Private _IRDescription As String = ""
    Private _ISGECPONumber As String = ""
    Private _ISGECPODate As String = ""
    Private _ISGECPOAmount As Decimal = 0
    Private _TransporterID As String = ""
    Private _TransporterBillNo As String = ""
    Private _TransporterBillDate As String = ""
    Private _BillAmount As Decimal = 0
    Private _BillReceivedOn As String = ""
    Private _BillReceivedBy As String = ""
    Private _BillReceiverDivisionID As String = ""
    Private _BillStatusID As Int32 = 0
    Private _DiscripantBill As Boolean = False
    Private _BillReturnRemarks As String = ""
    Private _BillReturnedOn As String = ""
    Private _BillReturneddBy As String = ""
    Private _ReceiptNo As String = ""
    Private _ReceiptDate As String = ""
    Private _ReceiptLine As String = ""
    Private _PassedAmount As Decimal = 0
    Private _ForwardedToAccount As Boolean = False
    Private _ForwardedOn As String = ""
    Private _ForwardedBy As String = ""
    Private _ReceiptAcknowledgement As Boolean = False
    Private _ReceiptAcknowledgedOn As String = ""
    Private _ReceiptAcknowledgedBy As String = ""
    Private _DiscripantReceipt As Boolean = False
    Private _ReceiptReturnedOn As String = ""
    Private _ReceiptReturnedBy As String = ""
    Private _ReceiptReturnRemarks As String = ""
    Private _SerialNo As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _aspnet_Users4_UserFullName As String = ""
    Private _aspnet_Users5_UserFullName As String = ""
    Private _HRM_Divisions6_Description As String = ""
    Private _VR_PaymentProcess7_PaymentDescription As String = ""
    Private _VR_BillStatus8_Description As String = ""
    Private _VR_Transporters9_TransporterName As String = ""
    Private _FK_VR_TransporterBill_BillReturnedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_TransporterBill_ForwardedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_TransporterBill_ReceiptAcknowledgeBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_TransporterBill_ReceiptReturnedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_TransporterBill_BillReceivedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_TransporterBill_BillReceiverDivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_VR_TransporterBill_SerialNo As SIS.VR.vrPaymentProcess = Nothing
    Private _FK_VR_TransporterBill_BillStatusID As SIS.VR.vrBillStatus = Nothing
    Private _FK_VR_TransporterBill_TransporterID As SIS.VR.vrTransporters = Nothing
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
    Public Property IRNo() As Int32
      Get
        Return _IRNo
      End Get
      Set(ByVal value As Int32)
        _IRNo = value
      End Set
    End Property
    Public Property IRDescription() As String
      Get
        Return _IRDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IRDescription = ""
				 Else
					 _IRDescription = value
			   End If
      End Set
    End Property
    Public Property ISGECPONumber() As String
      Get
        Return _ISGECPONumber
      End Get
      Set(ByVal value As String)
        _ISGECPONumber = value
      End Set
    End Property
    Public Property ISGECPODate() As String
      Get
        If Not _ISGECPODate = String.Empty Then
          Return Convert.ToDateTime(_ISGECPODate).ToString("dd/MM/yyyy")
        End If
        Return _ISGECPODate
      End Get
      Set(ByVal value As String)
			   _ISGECPODate = value
      End Set
    End Property
    Public Property ISGECPOAmount() As Decimal
      Get
        Return _ISGECPOAmount
      End Get
      Set(ByVal value As Decimal)
        _ISGECPOAmount = value
      End Set
    End Property
    Public Property TransporterID() As String
      Get
        Return _TransporterID
      End Get
      Set(ByVal value As String)
        _TransporterID = value
      End Set
    End Property
    Public Property TransporterBillNo() As String
      Get
        Return _TransporterBillNo
      End Get
      Set(ByVal value As String)
        _TransporterBillNo = value
      End Set
    End Property
    Public Property TransporterBillDate() As String
      Get
        If Not _TransporterBillDate = String.Empty Then
          Return Convert.ToDateTime(_TransporterBillDate).ToString("dd/MM/yyyy")
        End If
        Return _TransporterBillDate
      End Get
      Set(ByVal value As String)
			   _TransporterBillDate = value
      End Set
    End Property
    Public Property BillAmount() As Decimal
      Get
        Return _BillAmount
      End Get
      Set(ByVal value As Decimal)
        _BillAmount = value
      End Set
    End Property
    Public Property BillReceivedOn() As String
      Get
        If Not _BillReceivedOn = String.Empty Then
          Return Convert.ToDateTime(_BillReceivedOn).ToString("dd/MM/yyyy")
        End If
        Return _BillReceivedOn
      End Get
      Set(ByVal value As String)
			   _BillReceivedOn = value
      End Set
    End Property
    Public Property BillReceivedBy() As String
      Get
        Return _BillReceivedBy
      End Get
      Set(ByVal value As String)
        _BillReceivedBy = value
      End Set
    End Property
    Public Property BillReceiverDivisionID() As String
      Get
        Return _BillReceiverDivisionID
      End Get
      Set(ByVal value As String)
        _BillReceiverDivisionID = value
      End Set
    End Property
    Public Property BillStatusID() As Int32
      Get
        Return _BillStatusID
      End Get
      Set(ByVal value As Int32)
        _BillStatusID = value
      End Set
    End Property
    Public Property DiscripantBill() As Boolean
      Get
        Return _DiscripantBill
      End Get
      Set(ByVal value As Boolean)
        _DiscripantBill = value
      End Set
    End Property
    Public Property BillReturnRemarks() As String
      Get
        Return _BillReturnRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BillReturnRemarks = ""
				 Else
					 _BillReturnRemarks = value
			   End If
      End Set
    End Property
    Public Property BillReturnedOn() As String
      Get
        If Not _BillReturnedOn = String.Empty Then
          Return Convert.ToDateTime(_BillReturnedOn).ToString("dd/MM/yyyy")
        End If
        Return _BillReturnedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BillReturnedOn = ""
				 Else
					 _BillReturnedOn = value
			   End If
      End Set
    End Property
    Public Property BillReturneddBy() As String
      Get
        Return _BillReturneddBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BillReturneddBy = ""
				 Else
					 _BillReturneddBy = value
			   End If
      End Set
    End Property
    Public Property ReceiptNo() As String
      Get
        Return _ReceiptNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptNo = ""
				 Else
					 _ReceiptNo = value
			   End If
      End Set
    End Property
    Public Property ReceiptDate() As String
      Get
        If Not _ReceiptDate = String.Empty Then
          Return Convert.ToDateTime(_ReceiptDate).ToString("dd/MM/yyyy")
        End If
        Return _ReceiptDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptDate = ""
				 Else
					 _ReceiptDate = value
			   End If
      End Set
    End Property
    Public Property ReceiptLine() As String
      Get
        Return _ReceiptLine
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptLine = ""
				 Else
					 _ReceiptLine = value
			   End If
      End Set
    End Property
    Public Property PassedAmount() As Decimal
      Get
        Return _PassedAmount
      End Get
      Set(ByVal value As Decimal)
        _PassedAmount = value
      End Set
    End Property
    Public Property ForwardedToAccount() As Boolean
      Get
        Return _ForwardedToAccount
      End Get
      Set(ByVal value As Boolean)
        _ForwardedToAccount = value
      End Set
    End Property
    Public Property ForwardedOn() As String
      Get
        If Not _ForwardedOn = String.Empty Then
          Return Convert.ToDateTime(_ForwardedOn).ToString("dd/MM/yyyy")
        End If
        Return _ForwardedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ForwardedOn = ""
				 Else
					 _ForwardedOn = value
			   End If
      End Set
    End Property
    Public Property ForwardedBy() As String
      Get
        Return _ForwardedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ForwardedBy = ""
				 Else
					 _ForwardedBy = value
			   End If
      End Set
    End Property
    Public Property ReceiptAcknowledgement() As Boolean
      Get
        Return _ReceiptAcknowledgement
      End Get
      Set(ByVal value As Boolean)
        _ReceiptAcknowledgement = value
      End Set
    End Property
    Public Property ReceiptAcknowledgedOn() As String
      Get
        If Not _ReceiptAcknowledgedOn = String.Empty Then
          Return Convert.ToDateTime(_ReceiptAcknowledgedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceiptAcknowledgedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptAcknowledgedOn = ""
				 Else
					 _ReceiptAcknowledgedOn = value
			   End If
      End Set
    End Property
    Public Property ReceiptAcknowledgedBy() As String
      Get
        Return _ReceiptAcknowledgedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptAcknowledgedBy = ""
				 Else
					 _ReceiptAcknowledgedBy = value
			   End If
      End Set
    End Property
    Public Property DiscripantReceipt() As Boolean
      Get
        Return _DiscripantReceipt
      End Get
      Set(ByVal value As Boolean)
        _DiscripantReceipt = value
      End Set
    End Property
    Public Property ReceiptReturnedOn() As String
      Get
        If Not _ReceiptReturnedOn = String.Empty Then
          Return Convert.ToDateTime(_ReceiptReturnedOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceiptReturnedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptReturnedOn = ""
				 Else
					 _ReceiptReturnedOn = value
			   End If
      End Set
    End Property
    Public Property ReceiptReturnedBy() As String
      Get
        Return _ReceiptReturnedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptReturnedBy = ""
				 Else
					 _ReceiptReturnedBy = value
			   End If
      End Set
    End Property
    Public Property ReceiptReturnRemarks() As String
      Get
        Return _ReceiptReturnRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptReturnRemarks = ""
				 Else
					 _ReceiptReturnRemarks = value
			   End If
      End Set
    End Property
    Public Property SerialNo() As String
      Get
        Return _SerialNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SerialNo = ""
				 Else
					 _SerialNo = value
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
    Public Property aspnet_Users2_UserFullName() As String
      Get
        Return _aspnet_Users2_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users2_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users3_UserFullName() As String
      Get
        Return _aspnet_Users3_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users3_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users4_UserFullName() As String
      Get
        Return _aspnet_Users4_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users4_UserFullName = value
      End Set
    End Property
    Public Property aspnet_Users5_UserFullName() As String
      Get
        Return _aspnet_Users5_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users5_UserFullName = value
      End Set
    End Property
    Public Property HRM_Divisions6_Description() As String
      Get
        Return _HRM_Divisions6_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions6_Description = value
      End Set
    End Property
    Public Property VR_PaymentProcess7_PaymentDescription() As String
      Get
        Return _VR_PaymentProcess7_PaymentDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_PaymentProcess7_PaymentDescription = ""
				 Else
					 _VR_PaymentProcess7_PaymentDescription = value
			   End If
      End Set
    End Property
    Public Property VR_BillStatus8_Description() As String
      Get
        Return _VR_BillStatus8_Description
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_BillStatus8_Description = ""
				 Else
					 _VR_BillStatus8_Description = value
			   End If
      End Set
    End Property
    Public Property VR_Transporters9_TransporterName() As String
      Get
        Return _VR_Transporters9_TransporterName
      End Get
      Set(ByVal value As String)
        _VR_Transporters9_TransporterName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _IRDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _IRNo
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
    Public Class PKvrTransporterBill
			Private _IRNo As Int32 = 0
			Public Property IRNo() As Int32
				Get
					Return _IRNo
				End Get
				Set(ByVal value As Int32)
					_IRNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_TransporterBill_BillReturnedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_TransporterBill_BillReturnedBy Is Nothing Then
          _FK_VR_TransporterBill_BillReturnedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_BillReturneddBy)
        End If
        Return _FK_VR_TransporterBill_BillReturnedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_ForwardedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_TransporterBill_ForwardedBy Is Nothing Then
          _FK_VR_TransporterBill_ForwardedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ForwardedBy)
        End If
        Return _FK_VR_TransporterBill_ForwardedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_ReceiptAcknowledgeBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_TransporterBill_ReceiptAcknowledgeBy Is Nothing Then
          _FK_VR_TransporterBill_ReceiptAcknowledgeBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceiptAcknowledgedBy)
        End If
        Return _FK_VR_TransporterBill_ReceiptAcknowledgeBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_ReceiptReturnedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_TransporterBill_ReceiptReturnedBy Is Nothing Then
          _FK_VR_TransporterBill_ReceiptReturnedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceiptReturnedBy)
        End If
        Return _FK_VR_TransporterBill_ReceiptReturnedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_BillReceivedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_TransporterBill_BillReceivedBy Is Nothing Then
          _FK_VR_TransporterBill_BillReceivedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_BillReceivedBy)
        End If
        Return _FK_VR_TransporterBill_BillReceivedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_BillReceiverDivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_VR_TransporterBill_BillReceiverDivisionID Is Nothing Then
          _FK_VR_TransporterBill_BillReceiverDivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_BillReceiverDivisionID)
        End If
        Return _FK_VR_TransporterBill_BillReceiverDivisionID
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_SerialNo() As SIS.VR.vrPaymentProcess
      Get
        If _FK_VR_TransporterBill_SerialNo Is Nothing Then
          _FK_VR_TransporterBill_SerialNo = SIS.VR.vrPaymentProcess.vrPaymentProcessGetByID(_SerialNo)
        End If
        Return _FK_VR_TransporterBill_SerialNo
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_BillStatusID() As SIS.VR.vrBillStatus
      Get
        If _FK_VR_TransporterBill_BillStatusID Is Nothing Then
          _FK_VR_TransporterBill_BillStatusID = SIS.VR.vrBillStatus.vrBillStatusGetByID(_BillStatusID)
        End If
        Return _FK_VR_TransporterBill_BillStatusID
      End Get
    End Property
    Public ReadOnly Property FK_VR_TransporterBill_TransporterID() As SIS.VR.vrTransporters
      Get
        If _FK_VR_TransporterBill_TransporterID Is Nothing Then
          _FK_VR_TransporterBill_TransporterID = SIS.VR.vrTransporters.vrTransportersGetByID(_TransporterID)
        End If
        Return _FK_VR_TransporterBill_TransporterID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransporterBillSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrTransporterBill)
      Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporterBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransporterBillGetNewRecord() As SIS.VR.vrTransporterBill
      Return New SIS.VR.vrTransporterBill()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransporterBillGetByID(ByVal IRNo As Int32) As SIS.VR.vrTransporterBill
      Dim Results As SIS.VR.vrTransporterBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrTransporterBill(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByTransporterID(ByVal TransporterID As String, ByVal OrderBy as String) As List(Of SIS.VR.vrTransporterBill)
      Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectByTransporterID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,TransporterID.ToString.Length, TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporterBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByBillStatusID(ByVal BillStatusID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrTransporterBill)
      Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectByBillStatusID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,BillStatusID.ToString.Length, BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporterBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySerialNo(ByVal SerialNo As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrTransporterBill)
      Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectBySerialNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporterBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransporterBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal BillReceiverDivisionID As String, ByVal BillStatusID As Int32) As List(Of SIS.VR.vrTransporterBill)
      Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrTransporterBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrTransporterBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID",SqlDbType.NVarChar,9, IIf(TransporterID Is Nothing, String.Empty,TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillReceiverDivisionID",SqlDbType.NVarChar,6, IIf(BillReceiverDivisionID Is Nothing, String.Empty,BillReceiverDivisionID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID",SqlDbType.Int,10, IIf(BillStatusID = Nothing, 0,BillStatusID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrTransporterBill(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrTransporterBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal BillReceiverDivisionID As String, ByVal BillStatusID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrTransporterBillGetByID(ByVal IRNo As Int32, ByVal Filter_TransporterID As String, ByVal Filter_BillReceiverDivisionID As String, ByVal Filter_BillStatusID As Int32) As SIS.VR.vrTransporterBill
      Return vrTransporterBillGetByID(IRNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrTransporterBillInsert(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
      Dim _Rec As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetNewRecord()
      With _Rec
        .IRNo = Record.IRNo
        .IRDescription = Record.IRDescription
        .ISGECPONumber = Record.ISGECPONumber
        .ISGECPODate = Record.ISGECPODate
        .ISGECPOAmount = Record.ISGECPOAmount
        .TransporterID = Record.TransporterID
        .TransporterBillNo = Record.TransporterBillNo
        .TransporterBillDate = Record.TransporterBillDate
        .BillAmount = Record.BillAmount
        .BillReceivedOn = Now
        .BillReceivedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
				.BillReceiverDivisionID = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(_Rec.BillReceivedBy).C_DivisionID
        .BillStatusID = 1
      End With
      Return SIS.VR.vrTransporterBill.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDescription",SqlDbType.NVarChar,51, Iif(Record.IRDescription= "" ,Convert.DBNull, Record.IRDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPONumber",SqlDbType.NVarChar,11, Record.ISGECPONumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPODate",SqlDbType.DateTime,21, Record.ISGECPODate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPOAmount",SqlDbType.Decimal,21, Record.ISGECPOAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterBillNo",SqlDbType.NVarChar,21, Record.TransporterBillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterBillDate",SqlDbType.DateTime,21, Record.TransporterBillDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAmount",SqlDbType.Decimal,21, Record.BillAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedOn",SqlDbType.DateTime,21, Record.BillReceivedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedBy",SqlDbType.NVarChar,9, Record.BillReceivedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceiverDivisionID",SqlDbType.NVarChar,7, Record.BillReceiverDivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscripantBill",SqlDbType.Bit,3, Record.DiscripantBill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.BillReturnRemarks= "" ,Convert.DBNull, Record.BillReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturnedOn",SqlDbType.DateTime,21, Iif(Record.BillReturnedOn= "" ,Convert.DBNull, Record.BillReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturneddBy",SqlDbType.NVarChar,9, Iif(Record.BillReturneddBy= "" ,Convert.DBNull, Record.BillReturneddBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.NVarChar,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptDate",SqlDbType.DateTime,21, Iif(Record.ReceiptDate= "" ,Convert.DBNull, Record.ReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.NVarChar,5, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmount",SqlDbType.Decimal,21, Record.PassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedToAccount",SqlDbType.Bit,3, Record.ForwardedToAccount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn",SqlDbType.DateTime,21, Iif(Record.ForwardedOn= "" ,Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedBy",SqlDbType.NVarChar,9, Iif(Record.ForwardedBy= "" ,Convert.DBNull, Record.ForwardedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgement",SqlDbType.Bit,3, Record.ReceiptAcknowledgement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgedOn",SqlDbType.DateTime,21, Iif(Record.ReceiptAcknowledgedOn= "" ,Convert.DBNull, Record.ReceiptAcknowledgedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgedBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptAcknowledgedBy= "" ,Convert.DBNull, Record.ReceiptAcknowledgedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscripantReceipt",SqlDbType.Bit,3, Record.DiscripantReceipt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnedOn",SqlDbType.DateTime,21, Iif(Record.ReceiptReturnedOn= "" ,Convert.DBNull, Record.ReceiptReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnedBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptReturnedBy= "" ,Convert.DBNull, Record.ReceiptReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.ReceiptReturnRemarks= "" ,Convert.DBNull, Record.ReceiptReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
          Cmd.Parameters.Add("@Return_IRNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_IRNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.IRNo = Cmd.Parameters("@Return_IRNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrTransporterBillUpdate(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
      Dim _Rec As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(Record.IRNo)
      With _Rec
        .IRDescription = Record.IRDescription
        .ISGECPONumber = Record.ISGECPONumber
        .ISGECPODate = Record.ISGECPODate
        .ISGECPOAmount = Record.ISGECPOAmount
        .TransporterID = Record.TransporterID
        .TransporterBillNo = Record.TransporterBillNo
        .TransporterBillDate = Record.TransporterBillDate
        .BillAmount = Record.BillAmount
        .BillReceivedOn = Now
        .BillReceivedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .BillReceiverDivisionID = Record.BillReceiverDivisionID
        .BillStatusID = Record.BillStatusID
      End With
      Return SIS.VR.vrTransporterBill.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Record.IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRDescription",SqlDbType.NVarChar,51, Iif(Record.IRDescription= "" ,Convert.DBNull, Record.IRDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPONumber",SqlDbType.NVarChar,11, Record.ISGECPONumber)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPODate",SqlDbType.DateTime,21, Record.ISGECPODate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECPOAmount",SqlDbType.Decimal,21, Record.ISGECPOAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterBillNo",SqlDbType.NVarChar,21, Record.TransporterBillNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterBillDate",SqlDbType.DateTime,21, Record.TransporterBillDate)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillAmount",SqlDbType.Decimal,21, Record.BillAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedOn",SqlDbType.DateTime,21, Record.BillReceivedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceivedBy",SqlDbType.NVarChar,9, Record.BillReceivedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReceiverDivisionID",SqlDbType.NVarChar,7, Record.BillReceiverDivisionID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,11, Record.BillStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscripantBill",SqlDbType.Bit,3, Record.DiscripantBill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.BillReturnRemarks= "" ,Convert.DBNull, Record.BillReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturnedOn",SqlDbType.DateTime,21, Iif(Record.BillReturnedOn= "" ,Convert.DBNull, Record.BillReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillReturneddBy",SqlDbType.NVarChar,9, Iif(Record.BillReturneddBy= "" ,Convert.DBNull, Record.BillReturneddBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNo",SqlDbType.NVarChar,11, Iif(Record.ReceiptNo= "" ,Convert.DBNull, Record.ReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptDate",SqlDbType.DateTime,21, Iif(Record.ReceiptDate= "" ,Convert.DBNull, Record.ReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptLine",SqlDbType.NVarChar,5, Iif(Record.ReceiptLine= "" ,Convert.DBNull, Record.ReceiptLine))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PassedAmount",SqlDbType.Decimal,21, Record.PassedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedToAccount",SqlDbType.Bit,3, Record.ForwardedToAccount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedOn",SqlDbType.DateTime,21, Iif(Record.ForwardedOn= "" ,Convert.DBNull, Record.ForwardedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ForwardedBy",SqlDbType.NVarChar,9, Iif(Record.ForwardedBy= "" ,Convert.DBNull, Record.ForwardedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgement",SqlDbType.Bit,3, Record.ReceiptAcknowledgement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgedOn",SqlDbType.DateTime,21, Iif(Record.ReceiptAcknowledgedOn= "" ,Convert.DBNull, Record.ReceiptAcknowledgedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAcknowledgedBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptAcknowledgedBy= "" ,Convert.DBNull, Record.ReceiptAcknowledgedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DiscripantReceipt",SqlDbType.Bit,3, Record.DiscripantReceipt)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnedOn",SqlDbType.DateTime,21, Iif(Record.ReceiptReturnedOn= "" ,Convert.DBNull, Record.ReceiptReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnedBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptReturnedBy= "" ,Convert.DBNull, Record.ReceiptReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.ReceiptReturnRemarks= "" ,Convert.DBNull, Record.ReceiptReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo",SqlDbType.Int,11, Iif(Record.SerialNo= "" ,Convert.DBNull, Record.SerialNo))
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
    Public Shared Function vrTransporterBillDelete(ByVal Record As SIS.VR.vrTransporterBill) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_IRNo",SqlDbType.Int,Record.IRNo.ToString.Length, Record.IRNo)
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
		Public Shared Function SelectvrTransporterBillAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrTransporterBillAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.VR.vrTransporterBill = New SIS.VR.vrTransporterBill(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _IRNo = Ctype(Reader("IRNo"),Int32)
      If Convert.IsDBNull(Reader("IRDescription")) Then
        _IRDescription = String.Empty
      Else
        _IRDescription = Ctype(Reader("IRDescription"), String)
      End If
      _ISGECPONumber = Ctype(Reader("ISGECPONumber"),String)
      _ISGECPODate = Ctype(Reader("ISGECPODate"),DateTime)
      _ISGECPOAmount = Ctype(Reader("ISGECPOAmount"),Decimal)
      _TransporterID = Ctype(Reader("TransporterID"),String)
      _TransporterBillNo = Ctype(Reader("TransporterBillNo"),String)
      _TransporterBillDate = Ctype(Reader("TransporterBillDate"),DateTime)
      _BillAmount = Ctype(Reader("BillAmount"),Decimal)
      _BillReceivedOn = Ctype(Reader("BillReceivedOn"),DateTime)
      _BillReceivedBy = Ctype(Reader("BillReceivedBy"),String)
      _BillReceiverDivisionID = Ctype(Reader("BillReceiverDivisionID"),String)
      _BillStatusID = Ctype(Reader("BillStatusID"),Int32)
      _DiscripantBill = Ctype(Reader("DiscripantBill"),Boolean)
      If Convert.IsDBNull(Reader("BillReturnRemarks")) Then
        _BillReturnRemarks = String.Empty
      Else
        _BillReturnRemarks = Ctype(Reader("BillReturnRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("BillReturnedOn")) Then
        _BillReturnedOn = String.Empty
      Else
        _BillReturnedOn = Ctype(Reader("BillReturnedOn"), String)
      End If
      If Convert.IsDBNull(Reader("BillReturneddBy")) Then
        _BillReturneddBy = String.Empty
      Else
        _BillReturneddBy = Ctype(Reader("BillReturneddBy"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptNo")) Then
        _ReceiptNo = String.Empty
      Else
        _ReceiptNo = Ctype(Reader("ReceiptNo"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptDate")) Then
        _ReceiptDate = String.Empty
      Else
        _ReceiptDate = Ctype(Reader("ReceiptDate"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptLine")) Then
        _ReceiptLine = String.Empty
      Else
        _ReceiptLine = Ctype(Reader("ReceiptLine"), String)
      End If
      _PassedAmount = Ctype(Reader("PassedAmount"),Decimal)
      _ForwardedToAccount = Ctype(Reader("ForwardedToAccount"),Boolean)
      If Convert.IsDBNull(Reader("ForwardedOn")) Then
        _ForwardedOn = String.Empty
      Else
        _ForwardedOn = Ctype(Reader("ForwardedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ForwardedBy")) Then
        _ForwardedBy = String.Empty
      Else
        _ForwardedBy = Ctype(Reader("ForwardedBy"), String)
      End If
      _ReceiptAcknowledgement = Ctype(Reader("ReceiptAcknowledgement"),Boolean)
      If Convert.IsDBNull(Reader("ReceiptAcknowledgedOn")) Then
        _ReceiptAcknowledgedOn = String.Empty
      Else
        _ReceiptAcknowledgedOn = Ctype(Reader("ReceiptAcknowledgedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptAcknowledgedBy")) Then
        _ReceiptAcknowledgedBy = String.Empty
      Else
        _ReceiptAcknowledgedBy = Ctype(Reader("ReceiptAcknowledgedBy"), String)
      End If
      _DiscripantReceipt = Ctype(Reader("DiscripantReceipt"),Boolean)
      If Convert.IsDBNull(Reader("ReceiptReturnedOn")) Then
        _ReceiptReturnedOn = String.Empty
      Else
        _ReceiptReturnedOn = Ctype(Reader("ReceiptReturnedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptReturnedBy")) Then
        _ReceiptReturnedBy = String.Empty
      Else
        _ReceiptReturnedBy = Ctype(Reader("ReceiptReturnedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ReceiptReturnRemarks")) Then
        _ReceiptReturnRemarks = String.Empty
      Else
        _ReceiptReturnRemarks = Ctype(Reader("ReceiptReturnRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("SerialNo")) Then
        _SerialNo = String.Empty
      Else
        _SerialNo = Ctype(Reader("SerialNo"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _aspnet_Users2_UserFullName = Ctype(Reader("aspnet_Users2_UserFullName"),String)
      _aspnet_Users3_UserFullName = Ctype(Reader("aspnet_Users3_UserFullName"),String)
      _aspnet_Users4_UserFullName = Ctype(Reader("aspnet_Users4_UserFullName"),String)
      _aspnet_Users5_UserFullName = Ctype(Reader("aspnet_Users5_UserFullName"),String)
      _HRM_Divisions6_Description = Ctype(Reader("HRM_Divisions6_Description"),String)
      If Convert.IsDBNull(Reader("VR_PaymentProcess7_PaymentDescription")) Then
        _VR_PaymentProcess7_PaymentDescription = String.Empty
      Else
        _VR_PaymentProcess7_PaymentDescription = Ctype(Reader("VR_PaymentProcess7_PaymentDescription"), String)
      End If
      If Convert.IsDBNull(Reader("VR_BillStatus8_Description")) Then
        _VR_BillStatus8_Description = String.Empty
      Else
        _VR_BillStatus8_Description = Ctype(Reader("VR_BillStatus8_Description"), String)
      End If
      _VR_Transporters9_TransporterName = Ctype(Reader("VR_Transporters9_TransporterName"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
