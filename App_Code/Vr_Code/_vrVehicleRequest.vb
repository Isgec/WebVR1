Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrVehicleRequest
    Private Shared _RecordCount As Integer
    Private _RequestNo As Int32 = 0
    Private _RequestDescription As String = ""
    Private _SupplierID As String = ""
    Private _SupplierLocation As String = ""
    Private _ProjectID As String = ""
    Private _ProjectType As String = ""
    Private _DeliveryLocation As String = ""
    Private _ItemDescription As String = ""
    Private _MaterialSize As String = ""
    Private _SizeUnit As String = ""
    Private _Height As Decimal = 0
    Private _Width As Decimal = 0
    Private _Length As Decimal = 0
    Private _MaterialWeight As Decimal = 0
    Private _WeightUnit As String = ""
    Private _NoOfPackages As Int32 = 0
    Private _VehicleTypeID As String = ""
    Private _VehicleRequiredOn As String = ""
    Private _OverDimentionConsignement As Boolean = False
    Private _ODCReasonID As String = ""
    Private _Remarks As String = ""
    Private _MICN As Boolean = False
    Private _CustomInvoiceNo As String = ""
    Private _RequestedBy As String = ""
    Private _RequestedOn As String = ""
    Private _RequesterDivisionID As String = ""
    Private _RequestStatus As Int32 = 0
    Private _ReturnedOn As String = ""
    Private _ReturnedBy As String = ""
    Private _ReturnRemarks As String = ""
    Private _SRNNo As String = ""
    Private _ValidRequest As Boolean = False
    Private _ODCAtSupplierLoading As Boolean = False
    Private _FromLocation As String = ""
    Private _ToLocation As String = ""
    Private _CustomInvoiceIssued As Boolean = False
    Private _CT1Issued As Boolean = False
    Private _ARE1Issued As Boolean = False
    Private _DIIssued As Boolean = False
    Private _PaymentChecked As Boolean = False
    Private _GoodsPacked As Boolean = False
    Private _POApproved As Boolean = False
    Private _WayBill As Boolean = False
    Private _MarkingDetails As Boolean = False
    Private _TarpaulineRequired As Boolean = False
    Private _PackageStckable As Boolean = False
    Private _InvoiceValue As Decimal = 0
    Private _OutOfContract As Boolean = False
    Private _ERPPONumber As String = ""
    Private _BuyerInERP As String = ""
    Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _HRM_Divisions3_Description As String = ""
    Private _IDM_Projects4_Description As String = ""
    Private _IDM_Vendors5_Description As String = ""
    Private _VR_RequestExecution6_ExecutionDescription As String = ""
    Private _VR_RequestStates7_Description As String = ""
    Private _VR_Units8_Description As String = ""
    Private _VR_VehicleTypes9_cmba As String = ""
    Private _VR_ODCReasons1_Description As String = ""
    Private _VR_Units2_Description As String = ""
    Private _aspnet_Users10_UserFullName As String = ""
    Private _FK_VR_VehicleRequest_RequestedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_VehicleRequest_ReturnedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_VehicleRequest_RequesterDivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_VR_VehicleRequest_ProjectID As SIS.QCM.qcmProjects = Nothing
    Private _FK_VR_VehicleRequest_SupplierID As SIS.QCM.qcmVendors = Nothing
    Private _FK_VR_VehicleRequest_SRNNo As SIS.VR.vrRequestExecution = Nothing
    Private _FK_VR_VehicleRequest_RequestState As SIS.VR.vrRequestStates = Nothing
    Private _FK_VR_VehicleRequest_SizeUnit As SIS.VR.vrUnits = Nothing
    Private _FK_VR_VehicleRequest_VehicleTypeID As SIS.VR.vrVehicleTypes = Nothing
    Private _FK_VR_VehicleRequest_ODCReasonID As SIS.VR.vrODCReasons = Nothing
    Private _FK_VR_VehicleRequest_WeightUnit As SIS.VR.vrUnits = Nothing
    Private _FK_VR_VehicleRequest_BuyerInERP As SIS.QCM.qcmUsers = Nothing
    Public Property DeliveryTerm As String = ""
    Public Property FromPinCode As String = ""
    Public Property ToPinCode As String = ""
    Public Property SitePersonName As String = ""
    Public Property SitePersonContact As String = ""
    '======================SP=====================
    Public Property SPStatus As Integer = 0
    Public Property SPEdiStatus As Integer = 0
    Public Property SPEdiMessage As String = ""
    Public Property SPRequestCreatedOn As String = ""
    Public Property SPRequestCreatedBy As String = ""
    Public Property SPExecutionCreatedOn As String = ""
    Public Property SPExecutionCreatedBy As String = ""
    Public Property SPOrderCreatedOn As String = ""
    Public Property SPOrderCreatedBy As String = ""
    Public Property SPRequestID As String = ""
    Public Property SPLoadData As String = ""
    '==============================================
    Public ReadOnly Property SPStatusName As String
      Get
        Return System.Enum.GetName(GetType(enumSPStatus), SPStatus)
      End Get
    End Property
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
    Public Property RequestNo() As Int32
      Get
        Return _RequestNo
      End Get
      Set(ByVal value As Int32)
        _RequestNo = value
      End Set
    End Property
    Public Property RequestDescription() As String
      Get
        Return _RequestDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RequestDescription = ""
				 Else
					 _RequestDescription = value
			   End If
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
    Public Property SupplierLocation() As String
      Get
        Return _SupplierLocation
      End Get
      Set(ByVal value As String)
        _SupplierLocation = value
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
    Public Property ProjectType() As String
      Get
        Return _ProjectType
      End Get
      Set(ByVal value As String)
        _ProjectType = value
      End Set
    End Property
    Public Property DeliveryLocation() As String
      Get
        Return _DeliveryLocation
      End Get
      Set(ByVal value As String)
        _DeliveryLocation = value
      End Set
    End Property
    Public Property ItemDescription() As String
      Get
        Return _ItemDescription
      End Get
      Set(ByVal value As String)
        _ItemDescription = value
      End Set
    End Property
    Public Property MaterialSize() As String
      Get
        Return _MaterialSize
      End Get
      Set(ByVal value As String)
        _MaterialSize = value
      End Set
    End Property
    Public Property SizeUnit() As String
      Get
        Return _SizeUnit
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SizeUnit = ""
				 Else
					 _SizeUnit = value
			   End If
      End Set
    End Property
    Public Property Height() As Decimal
      Get
        Return _Height
      End Get
      Set(ByVal value As Decimal)
        _Height = value
      End Set
    End Property
    Public Property Width() As Decimal
      Get
        Return _Width
      End Get
      Set(ByVal value As Decimal)
        _Width = value
      End Set
    End Property
    Public Property Length() As Decimal
      Get
        Return _Length
      End Get
      Set(ByVal value As Decimal)
        _Length = value
      End Set
    End Property
    Public Property MaterialWeight() As Decimal
      Get
        Return _MaterialWeight
      End Get
      Set(ByVal value As Decimal)
        _MaterialWeight = value
      End Set
    End Property
    Public Property WeightUnit() As String
      Get
        Return _WeightUnit
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _WeightUnit = ""
				 Else
					 _WeightUnit = value
			   End If
      End Set
    End Property
    Public Property NoOfPackages() As Int32
      Get
        Return _NoOfPackages
      End Get
      Set(ByVal value As Int32)
        _NoOfPackages = value
      End Set
    End Property
    Public Property VehicleTypeID() As String
      Get
        Return _VehicleTypeID
      End Get
      Set(ByVal value As String)
        _VehicleTypeID = value
      End Set
    End Property
    Public Property VehicleRequiredOn() As String
      Get
        If Not _VehicleRequiredOn = String.Empty Then
          Return Convert.ToDateTime(_VehicleRequiredOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _VehicleRequiredOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VehicleRequiredOn = ""
				 Else
					 _VehicleRequiredOn = value
			   End If
      End Set
    End Property
    Public Property OverDimentionConsignement() As Boolean
      Get
        Return _OverDimentionConsignement
      End Get
      Set(ByVal value As Boolean)
        _OverDimentionConsignement = value
      End Set
    End Property
    Public Property ODCReasonID() As String
      Get
        Return _ODCReasonID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ODCReasonID = ""
				 Else
					 _ODCReasonID = value
			   End If
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
    Public Property MICN() As Boolean
      Get
        Return _MICN
      End Get
      Set(ByVal value As Boolean)
        _MICN = value
      End Set
    End Property
    Public Property CustomInvoiceNo() As String
      Get
        Return _CustomInvoiceNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _CustomInvoiceNo = ""
				 Else
					 _CustomInvoiceNo = value
			   End If
      End Set
    End Property
    Public Property RequestedBy() As String
      Get
        Return _RequestedBy
      End Get
      Set(ByVal value As String)
        _RequestedBy = value
      End Set
    End Property
    Public Property RequestedOn() As String
      Get
        If Not _RequestedOn = String.Empty Then
          Return Convert.ToDateTime(_RequestedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _RequestedOn
      End Get
      Set(ByVal value As String)
			   _RequestedOn = value
      End Set
    End Property
    Public Property RequesterDivisionID() As String
      Get
        Return _RequesterDivisionID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _RequesterDivisionID = ""
				 Else
					 _RequesterDivisionID = value
			   End If
      End Set
    End Property
    Public Property RequestStatus() As Int32
      Get
        Return _RequestStatus
      End Get
      Set(ByVal value As Int32)
        _RequestStatus = value
      End Set
    End Property
    Public Property ReturnedOn() As String
      Get
        If Not _ReturnedOn = String.Empty Then
          Return Convert.ToDateTime(_ReturnedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ReturnedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReturnedOn = ""
				 Else
					 _ReturnedOn = value
			   End If
      End Set
    End Property
    Public Property ReturnedBy() As String
      Get
        Return _ReturnedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReturnedBy = ""
				 Else
					 _ReturnedBy = value
			   End If
      End Set
    End Property
    Public Property ReturnRemarks() As String
      Get
        Return _ReturnRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReturnRemarks = ""
				 Else
					 _ReturnRemarks = value
			   End If
      End Set
    End Property
    Public Property SRNNo() As String
      Get
        Return _SRNNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SRNNo = ""
				 Else
					 _SRNNo = value
			   End If
      End Set
    End Property
    Public Property ValidRequest() As Boolean
      Get
        Return _ValidRequest
      End Get
      Set(ByVal value As Boolean)
        _ValidRequest = value
      End Set
    End Property
    Public Property ODCAtSupplierLoading() As Boolean
      Get
        Return _ODCAtSupplierLoading
      End Get
      Set(ByVal value As Boolean)
        _ODCAtSupplierLoading = value
      End Set
    End Property
    Public Property FromLocation() As String
      Get
        Return _FromLocation
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _FromLocation = ""
				 Else
					 _FromLocation = value
			   End If
      End Set
    End Property
    Public Property ToLocation() As String
      Get
        Return _ToLocation
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ToLocation = ""
				 Else
					 _ToLocation = value
			   End If
      End Set
    End Property
    Public Property CustomInvoiceIssued() As Boolean
      Get
        Return _CustomInvoiceIssued
      End Get
      Set(ByVal value As Boolean)
        _CustomInvoiceIssued = value
      End Set
    End Property
    Public Property CT1Issued() As Boolean
      Get
        Return _CT1Issued
      End Get
      Set(ByVal value As Boolean)
        _CT1Issued = value
      End Set
    End Property
    Public Property ARE1Issued() As Boolean
      Get
        Return _ARE1Issued
      End Get
      Set(ByVal value As Boolean)
        _ARE1Issued = value
      End Set
    End Property
    Public Property DIIssued() As Boolean
      Get
        Return _DIIssued
      End Get
      Set(ByVal value As Boolean)
        _DIIssued = value
      End Set
    End Property
    Public Property PaymentChecked() As Boolean
      Get
        Return _PaymentChecked
      End Get
      Set(ByVal value As Boolean)
        _PaymentChecked = value
      End Set
    End Property
    Public Property GoodsPacked() As Boolean
      Get
        Return _GoodsPacked
      End Get
      Set(ByVal value As Boolean)
        _GoodsPacked = value
      End Set
    End Property
    Public Property POApproved() As Boolean
      Get
        Return _POApproved
      End Get
      Set(ByVal value As Boolean)
        _POApproved = value
      End Set
    End Property
    Public Property WayBill() As Boolean
      Get
        Return _WayBill
      End Get
      Set(ByVal value As Boolean)
        _WayBill = value
      End Set
    End Property
    Public Property MarkingDetails() As Boolean
      Get
        Return _MarkingDetails
      End Get
      Set(ByVal value As Boolean)
        _MarkingDetails = value
      End Set
    End Property
    Public Property TarpaulineRequired() As Boolean
      Get
        Return _TarpaulineRequired
      End Get
      Set(ByVal value As Boolean)
        _TarpaulineRequired = value
      End Set
    End Property
    Public Property PackageStckable() As Boolean
      Get
        Return _PackageStckable
      End Get
      Set(ByVal value As Boolean)
        _PackageStckable = value
      End Set
    End Property
    Public Property InvoiceValue() As Decimal
      Get
        Return _InvoiceValue
      End Get
      Set(ByVal value As Decimal)
        _InvoiceValue = value
      End Set
    End Property
    Public Property OutOfContract() As Boolean
      Get
        Return _OutOfContract
      End Get
      Set(ByVal value As Boolean)
        _OutOfContract = value
      End Set
    End Property
    Public Property ERPPONumber() As String
      Get
        Return _ERPPONumber
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ERPPONumber = ""
				 Else
					 _ERPPONumber = value
			   End If
      End Set
    End Property
    Public Property BuyerInERP() As String
      Get
        Return _BuyerInERP
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _BuyerInERP = ""
				 Else
					 _BuyerInERP = value
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
    Public Property HRM_Divisions3_Description() As String
      Get
        Return _HRM_Divisions3_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions3_Description = value
      End Set
    End Property
    Public Property IDM_Projects4_Description() As String
      Get
        Return _IDM_Projects4_Description
      End Get
      Set(ByVal value As String)
        _IDM_Projects4_Description = value
      End Set
    End Property
    Public Property IDM_Vendors5_Description() As String
      Get
        Return _IDM_Vendors5_Description
      End Get
      Set(ByVal value As String)
        _IDM_Vendors5_Description = value
      End Set
    End Property
    Public Property VR_RequestExecution6_ExecutionDescription() As String
      Get
        Return _VR_RequestExecution6_ExecutionDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_RequestExecution6_ExecutionDescription = ""
				 Else
					 _VR_RequestExecution6_ExecutionDescription = value
			   End If
      End Set
    End Property
    Public Property VR_RequestStates7_Description() As String
      Get
        Return _VR_RequestStates7_Description
      End Get
      Set(ByVal value As String)
        _VR_RequestStates7_Description = value
      End Set
    End Property
    Public Property VR_Units8_Description() As String
      Get
        Return _VR_Units8_Description
      End Get
      Set(ByVal value As String)
        _VR_Units8_Description = value
      End Set
    End Property
    Public Property VR_VehicleTypes9_cmba() As String
      Get
        Return _VR_VehicleTypes9_cmba
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_VehicleTypes9_cmba = ""
				 Else
					 _VR_VehicleTypes9_cmba = value
			   End If
      End Set
    End Property
    Public Property VR_ODCReasons1_Description() As String
      Get
        Return _VR_ODCReasons1_Description
      End Get
      Set(ByVal value As String)
        _VR_ODCReasons1_Description = value
      End Set
    End Property
    Public Property VR_Units2_Description() As String
      Get
        Return _VR_Units2_Description
      End Get
      Set(ByVal value As String)
        _VR_Units2_Description = value
      End Set
    End Property
    Public Property aspnet_Users10_UserFullName() As String
      Get
        Return _aspnet_Users10_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users10_UserFullName = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _RequestDescription.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _RequestNo
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
    Public Class PKvrVehicleRequest
			Private _RequestNo As Int32 = 0
			Public Property RequestNo() As Int32
				Get
					Return _RequestNo
				End Get
				Set(ByVal value As Int32)
					_RequestNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_VehicleRequest_RequestedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_VehicleRequest_RequestedBy Is Nothing Then
          _FK_VR_VehicleRequest_RequestedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_RequestedBy)
        End If
        Return _FK_VR_VehicleRequest_RequestedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_ReturnedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_VehicleRequest_ReturnedBy Is Nothing Then
          _FK_VR_VehicleRequest_ReturnedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReturnedBy)
        End If
        Return _FK_VR_VehicleRequest_ReturnedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_RequesterDivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_VR_VehicleRequest_RequesterDivisionID Is Nothing Then
          _FK_VR_VehicleRequest_RequesterDivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_RequesterDivisionID)
        End If
        Return _FK_VR_VehicleRequest_RequesterDivisionID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_ProjectID() As SIS.QCM.qcmProjects
      Get
        If _FK_VR_VehicleRequest_ProjectID Is Nothing Then
          _FK_VR_VehicleRequest_ProjectID = SIS.QCM.qcmProjects.qcmProjectsGetByID(_ProjectID)
        End If
        Return _FK_VR_VehicleRequest_ProjectID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_SupplierID() As SIS.QCM.qcmVendors
      Get
        If _FK_VR_VehicleRequest_SupplierID Is Nothing Then
          _FK_VR_VehicleRequest_SupplierID = SIS.QCM.qcmVendors.qcmVendorsGetByID(_SupplierID)
        End If
        Return _FK_VR_VehicleRequest_SupplierID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_SRNNo() As SIS.VR.vrRequestExecution
      Get
        If _FK_VR_VehicleRequest_SRNNo Is Nothing Then
          _FK_VR_VehicleRequest_SRNNo = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(_SRNNo)
        End If
        Return _FK_VR_VehicleRequest_SRNNo
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_RequestState() As SIS.VR.vrRequestStates
      Get
        If _FK_VR_VehicleRequest_RequestState Is Nothing Then
          _FK_VR_VehicleRequest_RequestState = SIS.VR.vrRequestStates.vrRequestStatesGetByID(_RequestStatus)
        End If
        Return _FK_VR_VehicleRequest_RequestState
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_SizeUnit() As SIS.VR.vrUnits
      Get
        If _FK_VR_VehicleRequest_SizeUnit Is Nothing Then
          _FK_VR_VehicleRequest_SizeUnit = SIS.VR.vrUnits.vrUnitsGetByID(_SizeUnit)
        End If
        Return _FK_VR_VehicleRequest_SizeUnit
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_VehicleTypeID() As SIS.VR.vrVehicleTypes
      Get
        If _FK_VR_VehicleRequest_VehicleTypeID Is Nothing Then
          _FK_VR_VehicleRequest_VehicleTypeID = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(_VehicleTypeID)
        End If
        Return _FK_VR_VehicleRequest_VehicleTypeID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_ODCReasonID() As SIS.VR.vrODCReasons
      Get
        If _FK_VR_VehicleRequest_ODCReasonID Is Nothing Then
          _FK_VR_VehicleRequest_ODCReasonID = SIS.VR.vrODCReasons.vrODCReasonsGetByID(_ODCReasonID)
        End If
        Return _FK_VR_VehicleRequest_ODCReasonID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_WeightUnit() As SIS.VR.vrUnits
      Get
        If _FK_VR_VehicleRequest_WeightUnit Is Nothing Then
          _FK_VR_VehicleRequest_WeightUnit = SIS.VR.vrUnits.vrUnitsGetByID(_WeightUnit)
        End If
        Return _FK_VR_VehicleRequest_WeightUnit
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_BuyerInERP() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_VehicleRequest_BuyerInERP Is Nothing Then
          _FK_VR_VehicleRequest_BuyerInERP = SIS.QCM.qcmUsers.qcmUsersGetByID(_BuyerInERP)
        End If
        Return _FK_VR_VehicleRequest_BuyerInERP
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleRequestSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleRequestGetNewRecord() As SIS.VR.vrVehicleRequest
      Return New SIS.VR.vrVehicleRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleRequestGetByID(ByVal RequestNo As Int32) As SIS.VR.vrVehicleRequest
      Dim Results As SIS.VR.vrVehicleRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestNo",SqlDbType.Int,RequestNo.ToString.Length, RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrVehicleRequest(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySupplierID(ByVal SupplierID As String, ByVal OrderBy as String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectBySupplierID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID",SqlDbType.NVarChar,SupplierID.ToString.Length, SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByProjectID(ByVal ProjectID As String, ByVal OrderBy as String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectByProjectID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByVehicleTypeID(ByVal VehicleTypeID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectByVehicleTypeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,VehicleTypeID.ToString.Length, VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByRequestStatus(ByVal RequestStatus As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectByRequestStatus"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus",SqlDbType.Int,RequestStatus.ToString.Length, RequestStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetBySRNNo(ByVal SRNNo As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectBySRNNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestStatus As Int32) As List(Of SIS.VR.vrVehicleRequest)
      Dim Results As List(Of SIS.VR.vrVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrVehicleRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrVehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestStatus",SqlDbType.Int,10, IIf(RequestStatus = Nothing, 0,RequestStatus))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrVehicleRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestStatus As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrVehicleRequestGetByID(ByVal RequestNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_RequestStatus As Int32) As SIS.VR.vrVehicleRequest
      Return UZ_vrVehicleRequestGetByID(RequestNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrVehicleRequestInsert(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Dim _Rec As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.vrVehicleRequestGetNewRecord()
      With _Rec
        .RequestDescription = Record.RequestDescription
        .SupplierID = Record.SupplierID
        .SupplierLocation = Record.SupplierLocation
        .ProjectID = Record.ProjectID
        .ProjectType = Record.ProjectType
        .DeliveryLocation = Record.DeliveryLocation
        .ItemDescription = Record.ItemDescription
        .MaterialSize = Record.MaterialSize
        .SizeUnit = Record.SizeUnit
        .Height = Record.Height
        .Width = Record.Width
        .Length = Record.Length
        .MaterialWeight = Record.MaterialWeight
        .WeightUnit = Record.WeightUnit
        .NoOfPackages = Record.NoOfPackages
        .VehicleTypeID = Record.VehicleTypeID
        .VehicleRequiredOn = Record.VehicleRequiredOn
        .OverDimentionConsignement = Record.OverDimentionConsignement
        .ODCReasonID = Record.ODCReasonID
        .Remarks = Record.Remarks
        .MICN = Record.MICN
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .RequestedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .RequesterDivisionID = .FK_VR_VehicleRequest_RequestedBy.C_DivisionID
        .RequestStatus = 3
        .ValidRequest = Record.ValidRequest
        .ODCAtSupplierLoading = Record.ODCAtSupplierLoading
        .FromLocation = Record.FromLocation
        .ToLocation = Record.ToLocation
        .CustomInvoiceIssued = Record.CustomInvoiceIssued
        .CT1Issued = Record.CT1Issued
        .ARE1Issued = Record.ARE1Issued
        .DIIssued = Record.DIIssued
        .PaymentChecked = Record.PaymentChecked
        .GoodsPacked = Record.GoodsPacked
        .POApproved = Record.POApproved
        .WayBill = Record.WayBill
        .MarkingDetails = Record.MarkingDetails
        .TarpaulineRequired = Record.TarpaulineRequired
        .PackageStckable = Record.PackageStckable
        .InvoiceValue = Record.InvoiceValue
        .OutOfContract = Record.OutOfContract
        .ERPPONumber = Record.ERPPONumber
        .BuyerInERP = Record.BuyerInERP
        .DeliveryTerm = Record.DeliveryTerm
        .FromPinCode = Record.FromPinCode
        .ToPinCode = Record.ToPinCode
        .SitePersonContact = Record.SitePersonContact
        .SitePersonName = Record.SitePersonName
        .SPStatus = enumSPStatus.Free
        .SPEdiStatus = enumSPEdiStatus.Free
      End With
      Return SIS.VR.vrVehicleRequest.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestDescription",SqlDbType.NVarChar,51, Iif(Record.RequestDescription= "" ,Convert.DBNull, Record.RequestDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLocation", SqlDbType.NVarChar, 251, IIf(Record.SupplierLocation = "", Convert.DBNull, Record.SupplierLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectType", SqlDbType.NVarChar, 11, IIf(Record.ProjectType = "", Convert.DBNull, Record.ProjectType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryLocation", SqlDbType.NVarChar, 401, IIf(Record.DeliveryLocation = "", Convert.DBNull, Record.DeliveryLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 501, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialSize", SqlDbType.NVarChar, 51, IIf(Record.MaterialSize = "", Convert.DBNull, Record.MaterialSize))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeUnit",SqlDbType.Int,11, Iif(Record.SizeUnit= "" ,Convert.DBNull, Record.SizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Height",SqlDbType.Decimal,9, Record.Height)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Width",SqlDbType.Decimal,9, Record.Width)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Length",SqlDbType.Decimal,9, Record.Length)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialWeight",SqlDbType.Decimal,21, Record.MaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightUnit",SqlDbType.Int,11, Iif(Record.WeightUnit= "" ,Convert.DBNull, Record.WeightUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackages",SqlDbType.Int,11, Record.NoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID", SqlDbType.Int, 11, IIf(Record.VehicleTypeID = "", Convert.DBNull, Record.VehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleRequiredOn",SqlDbType.DateTime,21, Iif(Record.VehicleRequiredOn= "" ,Convert.DBNull, Record.VehicleRequiredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimentionConsignement",SqlDbType.Bit,3, Record.OverDimentionConsignement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCReasonID",SqlDbType.Int,11, Iif(Record.ODCReasonID= "" ,Convert.DBNull, Record.ODCReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MICN",SqlDbType.Bit,3, Record.MICN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo",SqlDbType.NVarChar,101, Iif(Record.CustomInvoiceNo= "" ,Convert.DBNull, Record.CustomInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy",SqlDbType.NVarChar,9, Record.RequestedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn",SqlDbType.DateTime,21, Record.RequestedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterDivisionID",SqlDbType.NVarChar,7, Iif(Record.RequesterDivisionID= "" ,Convert.DBNull, Record.RequesterDivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus",SqlDbType.Int,11, Record.RequestStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedOn",SqlDbType.DateTime,21, Iif(Record.ReturnedOn= "" ,Convert.DBNull, Record.ReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedBy",SqlDbType.NVarChar,9, Iif(Record.ReturnedBy= "" ,Convert.DBNull, Record.ReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks",SqlDbType.NVarChar,101, Iif(Record.ReturnRemarks= "" ,Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,11, Iif(Record.SRNNo= "" ,Convert.DBNull, Record.SRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidRequest",SqlDbType.Bit,3, Record.ValidRequest)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCAtSupplierLoading",SqlDbType.Bit,3, Record.ODCAtSupplierLoading)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromLocation",SqlDbType.NVarChar,51, Iif(Record.FromLocation= "" ,Convert.DBNull, Record.FromLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToLocation",SqlDbType.NVarChar,51, Iif(Record.ToLocation= "" ,Convert.DBNull, Record.ToLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceIssued",SqlDbType.Bit,3, Record.CustomInvoiceIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CT1Issued",SqlDbType.Bit,3, Record.CT1Issued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ARE1Issued",SqlDbType.Bit,3, Record.ARE1Issued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DIIssued",SqlDbType.Bit,3, Record.DIIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentChecked",SqlDbType.Bit,3, Record.PaymentChecked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GoodsPacked",SqlDbType.Bit,3, Record.GoodsPacked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POApproved",SqlDbType.Bit,3, Record.POApproved)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WayBill",SqlDbType.Bit,3, Record.WayBill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarkingDetails",SqlDbType.Bit,3, Record.MarkingDetails)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TarpaulineRequired",SqlDbType.Bit,3, Record.TarpaulineRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackageStckable",SqlDbType.Bit,3, Record.PackageStckable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceValue",SqlDbType.Decimal,16, Record.InvoiceValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OutOfContract",SqlDbType.Bit,3, Record.OutOfContract)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPPONumber",SqlDbType.NVarChar,11, Iif(Record.ERPPONumber= "" ,Convert.DBNull, Record.ERPPONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerInERP",SqlDbType.NVarChar,9, Iif(Record.BuyerInERP= "" ,Convert.DBNull, Record.BuyerInERP))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerm", SqlDbType.NVarChar, 6, IIf(Record.DeliveryTerm = "", Convert.DBNull, Record.DeliveryTerm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromPinCode", SqlDbType.NVarChar, 11, IIf(Record.FromPinCode = "", Convert.DBNull, Record.FromPinCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToPinCode", SqlDbType.NVarChar, 11, IIf(Record.ToPinCode = "", Convert.DBNull, Record.ToPinCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SitePersonName", SqlDbType.NVarChar, 51, IIf(Record.SitePersonName = "", Convert.DBNull, Record.SitePersonName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SitePersonContact", SqlDbType.NVarChar, 51, IIf(Record.SitePersonContact = "", Convert.DBNull, Record.SitePersonContact))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPStatus", SqlDbType.Int, 11, Record.SPStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEdiStatus", SqlDbType.Int, 11, Record.SPEdiStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEdiMessage", SqlDbType.NVarChar, 1001, IIf(Record.SPEdiMessage = "", Convert.DBNull, Record.SPEdiMessage))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPRequestCreatedOn = "", Convert.DBNull, Record.SPRequestCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPRequestCreatedBy = "", Convert.DBNull, Record.SPRequestCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPExecutionCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPExecutionCreatedOn = "", Convert.DBNull, Record.SPExecutionCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPExecutionCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPExecutionCreatedBy = "", Convert.DBNull, Record.SPExecutionCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPOrderCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPOrderCreatedOn = "", Convert.DBNull, Record.SPOrderCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPOrderCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPOrderCreatedBy = "", Convert.DBNull, Record.SPOrderCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestID", SqlDbType.NVarChar, 51, IIf(Record.SPRequestID = "", Convert.DBNull, Record.SPRequestID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPLoadData", SqlDbType.NVarChar, Integer.MaxValue, IIf(Record.SPLoadData = "", Convert.DBNull, Record.SPLoadData))
          Cmd.Parameters.Add("@Return_RequestNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_RequestNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.RequestNo = Cmd.Parameters("@Return_RequestNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrVehicleRequestUpdate(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Dim _Rec As SIS.VR.vrVehicleRequest = SIS.VR.vrVehicleRequest.UZ_vrVehicleRequestGetByID(Record.RequestNo)
      With _Rec
        .RequestDescription = Record.RequestDescription
        .SupplierID = Record.SupplierID
        .SupplierLocation = Record.SupplierLocation
        .ProjectID = Record.ProjectID
        .ProjectType = Record.ProjectType
        .DeliveryLocation = Record.DeliveryLocation
        .ItemDescription = Record.ItemDescription
        .MaterialSize = Record.MaterialSize
        .SizeUnit = Record.SizeUnit
        .Height = Record.Height
        .Width = Record.Width
        .Length = Record.Length
        .MaterialWeight = Record.MaterialWeight
        .WeightUnit = Record.WeightUnit
        .NoOfPackages = Record.NoOfPackages
        .VehicleTypeID = Record.VehicleTypeID
        .VehicleRequiredOn = Record.VehicleRequiredOn
        .OverDimentionConsignement = Record.OverDimentionConsignement
        .ODCReasonID = Record.ODCReasonID
        .Remarks = Record.Remarks
        .MICN = Record.MICN
        .CustomInvoiceNo = Record.CustomInvoiceNo
        .RequestedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .RequesterDivisionID = .FK_VR_VehicleRequest_RequestedBy.C_DivisionID
        .RequestStatus = 3
        .ValidRequest = Record.ValidRequest
        .ODCAtSupplierLoading = Record.ODCAtSupplierLoading
        .FromLocation = Record.FromLocation
        .ToLocation = Record.ToLocation
        .CustomInvoiceIssued = Record.CustomInvoiceIssued
        .CT1Issued = Record.CT1Issued
        .ARE1Issued = Record.ARE1Issued
        .DIIssued = Record.DIIssued
        .PaymentChecked = Record.PaymentChecked
        .GoodsPacked = Record.GoodsPacked
        .POApproved = Record.POApproved
        .WayBill = Record.WayBill
        .MarkingDetails = Record.MarkingDetails
        .TarpaulineRequired = Record.TarpaulineRequired
        .PackageStckable = Record.PackageStckable
        .InvoiceValue = Record.InvoiceValue
        .OutOfContract = Record.OutOfContract
        .ERPPONumber = Record.ERPPONumber
        .BuyerInERP = Record.BuyerInERP
        .FromPinCode = Record.FromPinCode
        .ToPinCode = Record.ToPinCode
        .SitePersonContact = Record.SitePersonContact
        .SitePersonName = Record.SitePersonName
      End With
      Return SIS.VR.vrVehicleRequest.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrVehicleRequest) As SIS.VR.vrVehicleRequest
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestNo",SqlDbType.Int,11, Record.RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestDescription", SqlDbType.NVarChar, 51, IIf(Record.RequestDescription = "", Convert.DBNull, Record.RequestDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, IIf(Record.SupplierID = "", Convert.DBNull, Record.SupplierID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLocation", SqlDbType.NVarChar, 251, IIf(Record.SupplierLocation = "", Convert.DBNull, Record.SupplierLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectType", SqlDbType.NVarChar, 11, IIf(Record.ProjectType = "", Convert.DBNull, Record.ProjectType))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryLocation", SqlDbType.NVarChar, 401, IIf(Record.DeliveryLocation = "", Convert.DBNull, Record.DeliveryLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription", SqlDbType.NVarChar, 501, IIf(Record.ItemDescription = "", Convert.DBNull, Record.ItemDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialSize", SqlDbType.NVarChar, 51, IIf(Record.MaterialSize = "", Convert.DBNull, Record.MaterialSize))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeUnit", SqlDbType.Int, 11, IIf(Record.SizeUnit = "", Convert.DBNull, Record.SizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Height", SqlDbType.Decimal, 9, Record.Height)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Width", SqlDbType.Decimal, 9, Record.Width)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Length", SqlDbType.Decimal, 9, Record.Length)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialWeight", SqlDbType.Decimal, 21, Record.MaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightUnit", SqlDbType.Int, 11, IIf(Record.WeightUnit = "", Convert.DBNull, Record.WeightUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackages", SqlDbType.Int, 11, Record.NoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID", SqlDbType.Int, 11, IIf(Record.VehicleTypeID = "", Convert.DBNull, Record.VehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleRequiredOn", SqlDbType.DateTime, 21, IIf(Record.VehicleRequiredOn = "", Convert.DBNull, Record.VehicleRequiredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimentionConsignement", SqlDbType.Bit, 3, Record.OverDimentionConsignement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCReasonID", SqlDbType.Int, 11, IIf(Record.ODCReasonID = "", Convert.DBNull, Record.ODCReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks", SqlDbType.NVarChar, 501, IIf(Record.Remarks = "", Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MICN", SqlDbType.Bit, 3, Record.MICN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceNo", SqlDbType.NVarChar, 101, IIf(Record.CustomInvoiceNo = "", Convert.DBNull, Record.CustomInvoiceNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedBy", SqlDbType.NVarChar, 9, Record.RequestedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestedOn", SqlDbType.DateTime, 21, Record.RequestedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequesterDivisionID", SqlDbType.NVarChar, 7, IIf(Record.RequesterDivisionID = "", Convert.DBNull, Record.RequesterDivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus", SqlDbType.Int, 11, Record.RequestStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedOn", SqlDbType.DateTime, 21, IIf(Record.ReturnedOn = "", Convert.DBNull, Record.ReturnedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnedBy", SqlDbType.NVarChar, 9, IIf(Record.ReturnedBy = "", Convert.DBNull, Record.ReturnedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnRemarks", SqlDbType.NVarChar, 101, IIf(Record.ReturnRemarks = "", Convert.DBNull, Record.ReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo", SqlDbType.Int, 11, IIf(Record.SRNNo = "", Convert.DBNull, Record.SRNNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ValidRequest", SqlDbType.Bit, 3, Record.ValidRequest)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCAtSupplierLoading", SqlDbType.Bit, 3, Record.ODCAtSupplierLoading)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromLocation", SqlDbType.NVarChar, 51, IIf(Record.FromLocation = "", Convert.DBNull, Record.FromLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToLocation", SqlDbType.NVarChar, 51, IIf(Record.ToLocation = "", Convert.DBNull, Record.ToLocation))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CustomInvoiceIssued", SqlDbType.Bit, 3, Record.CustomInvoiceIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CT1Issued", SqlDbType.Bit, 3, Record.CT1Issued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ARE1Issued", SqlDbType.Bit, 3, Record.ARE1Issued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DIIssued", SqlDbType.Bit, 3, Record.DIIssued)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PaymentChecked", SqlDbType.Bit, 3, Record.PaymentChecked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GoodsPacked", SqlDbType.Bit, 3, Record.GoodsPacked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POApproved", SqlDbType.Bit, 3, Record.POApproved)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WayBill", SqlDbType.Bit, 3, Record.WayBill)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MarkingDetails", SqlDbType.Bit, 3, Record.MarkingDetails)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TarpaulineRequired", SqlDbType.Bit, 3, Record.TarpaulineRequired)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PackageStckable", SqlDbType.Bit, 3, Record.PackageStckable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InvoiceValue", SqlDbType.Decimal, 16, Record.InvoiceValue)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OutOfContract", SqlDbType.Bit, 3, Record.OutOfContract)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPPONumber", SqlDbType.NVarChar, 11, IIf(Record.ERPPONumber = "", Convert.DBNull, Record.ERPPONumber))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BuyerInERP", SqlDbType.NVarChar, 9, IIf(Record.BuyerInERP = "", Convert.DBNull, Record.BuyerInERP))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryTerm", SqlDbType.NVarChar, 6, IIf(Record.DeliveryTerm = "", Convert.DBNull, Record.DeliveryTerm))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FromPinCode", SqlDbType.NVarChar, 11, IIf(Record.FromPinCode = "", Convert.DBNull, Record.FromPinCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToPinCode", SqlDbType.NVarChar, 11, IIf(Record.ToPinCode = "", Convert.DBNull, Record.ToPinCode))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SitePersonName", SqlDbType.NVarChar, 51, IIf(Record.SitePersonName = "", Convert.DBNull, Record.SitePersonName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SitePersonContact", SqlDbType.NVarChar, 51, IIf(Record.SitePersonContact = "", Convert.DBNull, Record.SitePersonContact))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPStatus", SqlDbType.Int, 11, Record.SPStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEdiStatus", SqlDbType.Int, 11, Record.SPEdiStatus)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPEdiMessage", SqlDbType.NVarChar, 1001, IIf(Record.SPEdiMessage = "", Convert.DBNull, Record.SPEdiMessage))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPRequestCreatedOn = "", Convert.DBNull, Record.SPRequestCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPRequestCreatedBy = "", Convert.DBNull, Record.SPRequestCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPExecutionCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPExecutionCreatedOn = "", Convert.DBNull, Record.SPExecutionCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPExecutionCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPExecutionCreatedBy = "", Convert.DBNull, Record.SPExecutionCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPOrderCreatedOn", SqlDbType.DateTime, 21, IIf(Record.SPOrderCreatedOn = "", Convert.DBNull, Record.SPOrderCreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPOrderCreatedBy", SqlDbType.NVarChar, 9, IIf(Record.SPOrderCreatedBy = "", Convert.DBNull, Record.SPOrderCreatedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPRequestID", SqlDbType.NVarChar, 51, IIf(Record.SPRequestID = "", Convert.DBNull, Record.SPRequestID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SPLoadData", SqlDbType.NVarChar, Integer.MaxValue, IIf(Record.SPLoadData = "", Convert.DBNull, Record.SPLoadData))
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
    Public Shared Function vrVehicleRequestDelete(ByVal Record As SIS.VR.vrVehicleRequest) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestNo",SqlDbType.Int,Record.RequestNo.ToString.Length, Record.RequestNo)
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
		Public Shared Function SelectvrVehicleRequestAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrVehicleRequestAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.VR.vrVehicleRequest = New SIS.VR.vrVehicleRequest(Reader)
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
