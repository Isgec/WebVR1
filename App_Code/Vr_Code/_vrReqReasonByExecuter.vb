Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrReqReasonByExecuter
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
    Private _VehicleTypeID As Int32 = 0
    Private _VehicleRequiredOn As String = ""
    Private _OverDimentionConsignement As Boolean = False
    Private _ODCReasonID As String = ""
    Private _Remarks As String = ""
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
    Private _MICN As Boolean = False
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
    Private _ExecuterReasonID As String = ""
    Private _ExecuterID As String = ""
    Private _ReasonEneteredOn As String = ""
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
    Private _aspnet_Users11_UserFullName As String = ""
    Private _VR_RequestReasons12_Description As String = ""
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
    Private _FK_VR_VehicleRequest_ExecuterID As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_VehicleRequest_ExecuterReasonID As SIS.VR.vrRequestReasons = Nothing
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
    Public Property VehicleTypeID() As Int32
      Get
        Return _VehicleTypeID
      End Get
      Set(ByVal value As Int32)
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
    Public Property MICN() As Boolean
      Get
        Return _MICN
      End Get
      Set(ByVal value As Boolean)
        _MICN = value
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
    Public Property ExecuterReasonID() As String
      Get
        Return _ExecuterReasonID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecuterReasonID = ""
				 Else
					 _ExecuterReasonID = value
			   End If
      End Set
    End Property
    Public Property ExecuterID() As String
      Get
        Return _ExecuterID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecuterID = ""
				 Else
					 _ExecuterID = value
			   End If
      End Set
    End Property
    Public Property ReasonEneteredOn() As String
      Get
        If Not _ReasonEneteredOn = String.Empty Then
          Return Convert.ToDateTime(_ReasonEneteredOn).ToString("dd/MM/yyyy")
        End If
        Return _ReasonEneteredOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReasonEneteredOn = ""
				 Else
					 _ReasonEneteredOn = value
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
    Public Property aspnet_Users11_UserFullName() As String
      Get
        Return _aspnet_Users11_UserFullName
      End Get
      Set(ByVal value As String)
        _aspnet_Users11_UserFullName = value
      End Set
    End Property
    Public Property VR_RequestReasons12_Description() As String
      Get
        Return _VR_RequestReasons12_Description
      End Get
      Set(ByVal value As String)
        _VR_RequestReasons12_Description = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
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
    Public Class PKvrReqReasonByExecuter
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
    Public ReadOnly Property FK_VR_VehicleRequest_ExecuterID() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_VehicleRequest_ExecuterID Is Nothing Then
          _FK_VR_VehicleRequest_ExecuterID = SIS.QCM.qcmUsers.qcmUsersGetByID(_ExecuterID)
        End If
        Return _FK_VR_VehicleRequest_ExecuterID
      End Get
    End Property
    Public ReadOnly Property FK_VR_VehicleRequest_ExecuterReasonID() As SIS.VR.vrRequestReasons
      Get
        If _FK_VR_VehicleRequest_ExecuterReasonID Is Nothing Then
          _FK_VR_VehicleRequest_ExecuterReasonID = SIS.VR.vrRequestReasons.vrRequestReasonsGetByID(_ExecuterReasonID)
        End If
        Return _FK_VR_VehicleRequest_ExecuterReasonID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrReqReasonByExecuterGetNewRecord() As SIS.VR.vrReqReasonByExecuter
      Return New SIS.VR.vrReqReasonByExecuter()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrReqReasonByExecuterGetByID(ByVal RequestNo As Int32) As SIS.VR.vrReqReasonByExecuter
      Dim Results As SIS.VR.vrReqReasonByExecuter = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrReqReasonByExecuterSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestNo",SqlDbType.Int,RequestNo.ToString.Length, RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrReqReasonByExecuter(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrReqReasonByExecuterSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal VehicleTypeID As Int32, ByVal RequestedBy As String, ByVal RequestStatus As Int32) As List(Of SIS.VR.vrReqReasonByExecuter)
      Dim Results As List(Of SIS.VR.vrReqReasonByExecuter) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrReqReasonByExecuterSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrReqReasonByExecuterSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID",SqlDbType.Int,10, IIf(VehicleTypeID = Nothing, 0,VehicleTypeID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestStatus",SqlDbType.Int,10, IIf(RequestStatus = Nothing, 0,RequestStatus))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus",SqlDbType.Int,10, "4")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrReqReasonByExecuter)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrReqReasonByExecuter(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrReqReasonByExecuterSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal VehicleTypeID As Int32, ByVal RequestedBy As String, ByVal RequestStatus As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrReqReasonByExecuterGetByID(ByVal RequestNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_VehicleTypeID As Int32, ByVal Filter_RequestedBy As String, ByVal Filter_RequestStatus As Int32) As SIS.VR.vrReqReasonByExecuter
      Return vrReqReasonByExecuterGetByID(RequestNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrReqReasonByExecuterUpdate(ByVal Record As SIS.VR.vrReqReasonByExecuter) As SIS.VR.vrReqReasonByExecuter
      Dim _Rec As SIS.VR.vrReqReasonByExecuter = SIS.VR.vrReqReasonByExecuter.vrReqReasonByExecuterGetByID(Record.RequestNo)
      With _Rec
        .ExecuterReasonID = Record.ExecuterReasonID
        .ExecuterID = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ReasonEneteredOn = Now
      End With
      Return SIS.VR.vrReqReasonByExecuter.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrReqReasonByExecuter) As SIS.VR.vrReqReasonByExecuter
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrReqReasonByExecuterUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_RequestNo",SqlDbType.Int,11, Record.RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestDescription",SqlDbType.NVarChar,51, Iif(Record.RequestDescription= "" ,Convert.DBNull, Record.RequestDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierID", SqlDbType.NVarChar, 9, Record.SupplierID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierLocation",SqlDbType.NVarChar,251, Record.SupplierLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,7, Record.ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectType",SqlDbType.NVarChar,11, Record.ProjectType)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeliveryLocation",SqlDbType.NVarChar,401, Record.DeliveryLocation)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemDescription",SqlDbType.NVarChar,501, Record.ItemDescription)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialSize",SqlDbType.NVarChar,51, Record.MaterialSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeUnit",SqlDbType.Int,11, Iif(Record.SizeUnit= "" ,Convert.DBNull, Record.SizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Height",SqlDbType.Decimal,9, Record.Height)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Width",SqlDbType.Decimal,9, Record.Width)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Length",SqlDbType.Decimal,9, Record.Length)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialWeight",SqlDbType.Decimal,21, Record.MaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightUnit",SqlDbType.Int,11, Iif(Record.WeightUnit= "" ,Convert.DBNull, Record.WeightUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackages",SqlDbType.Int,11, Record.NoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,11, Record.VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleRequiredOn",SqlDbType.DateTime,21, Iif(Record.VehicleRequiredOn= "" ,Convert.DBNull, Record.VehicleRequiredOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimentionConsignement",SqlDbType.Bit,3, Record.OverDimentionConsignement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCReasonID",SqlDbType.Int,11, Iif(Record.ODCReasonID= "" ,Convert.DBNull, Record.ODCReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
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
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MICN",SqlDbType.Bit,3, Record.MICN)
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
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecuterReasonID",SqlDbType.Int,11, Iif(Record.ExecuterReasonID= "" ,Convert.DBNull, Record.ExecuterReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecuterID",SqlDbType.NVarChar,9, Iif(Record.ExecuterID= "" ,Convert.DBNull, Record.ExecuterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReasonEneteredOn",SqlDbType.DateTime,21, Iif(Record.ReasonEneteredOn= "" ,Convert.DBNull, Record.ReasonEneteredOn))
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
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _RequestNo = Ctype(Reader("RequestNo"),Int32)
      If Convert.IsDBNull(Reader("RequestDescription")) Then
        _RequestDescription = String.Empty
      Else
        _RequestDescription = Ctype(Reader("RequestDescription"), String)
      End If
      _SupplierID = Ctype(Reader("SupplierID"),String)
      _SupplierLocation = Ctype(Reader("SupplierLocation"),String)
      _ProjectID = Ctype(Reader("ProjectID"),String)
      _ProjectType = Ctype(Reader("ProjectType"),String)
      _DeliveryLocation = Ctype(Reader("DeliveryLocation"),String)
      _ItemDescription = Ctype(Reader("ItemDescription"),String)
      _MaterialSize = Ctype(Reader("MaterialSize"),String)
      If Convert.IsDBNull(Reader("SizeUnit")) Then
        _SizeUnit = String.Empty
      Else
        _SizeUnit = Ctype(Reader("SizeUnit"), String)
      End If
      _Height = Ctype(Reader("Height"),Decimal)
      _Width = Ctype(Reader("Width"),Decimal)
      _Length = Ctype(Reader("Length"),Decimal)
      _MaterialWeight = Ctype(Reader("MaterialWeight"),Decimal)
      If Convert.IsDBNull(Reader("WeightUnit")) Then
        _WeightUnit = String.Empty
      Else
        _WeightUnit = Ctype(Reader("WeightUnit"), String)
      End If
      _NoOfPackages = Ctype(Reader("NoOfPackages"),Int32)
      _VehicleTypeID = Ctype(Reader("VehicleTypeID"),Int32)
      If Convert.IsDBNull(Reader("VehicleRequiredOn")) Then
        _VehicleRequiredOn = String.Empty
      Else
        _VehicleRequiredOn = Ctype(Reader("VehicleRequiredOn"), String)
      End If
      _OverDimentionConsignement = Ctype(Reader("OverDimentionConsignement"),Boolean)
      If Convert.IsDBNull(Reader("ODCReasonID")) Then
        _ODCReasonID = String.Empty
      Else
        _ODCReasonID = Ctype(Reader("ODCReasonID"), String)
      End If
      If Convert.IsDBNull(Reader("Remarks")) Then
        _Remarks = String.Empty
      Else
        _Remarks = Ctype(Reader("Remarks"), String)
      End If
      If Convert.IsDBNull(Reader("CustomInvoiceNo")) Then
        _CustomInvoiceNo = String.Empty
      Else
        _CustomInvoiceNo = Ctype(Reader("CustomInvoiceNo"), String)
      End If
      _RequestedBy = Ctype(Reader("RequestedBy"),String)
      _RequestedOn = Ctype(Reader("RequestedOn"),DateTime)
      If Convert.IsDBNull(Reader("RequesterDivisionID")) Then
        _RequesterDivisionID = String.Empty
      Else
        _RequesterDivisionID = Ctype(Reader("RequesterDivisionID"), String)
      End If
      _RequestStatus = Ctype(Reader("RequestStatus"),Int32)
      If Convert.IsDBNull(Reader("ReturnedOn")) Then
        _ReturnedOn = String.Empty
      Else
        _ReturnedOn = Ctype(Reader("ReturnedOn"), String)
      End If
      If Convert.IsDBNull(Reader("ReturnedBy")) Then
        _ReturnedBy = String.Empty
      Else
        _ReturnedBy = Ctype(Reader("ReturnedBy"), String)
      End If
      If Convert.IsDBNull(Reader("ReturnRemarks")) Then
        _ReturnRemarks = String.Empty
      Else
        _ReturnRemarks = Ctype(Reader("ReturnRemarks"), String)
      End If
      If Convert.IsDBNull(Reader("SRNNo")) Then
        _SRNNo = String.Empty
      Else
        _SRNNo = Ctype(Reader("SRNNo"), String)
      End If
      _ValidRequest = Ctype(Reader("ValidRequest"),Boolean)
      _ODCAtSupplierLoading = Ctype(Reader("ODCAtSupplierLoading"),Boolean)
      If Convert.IsDBNull(Reader("FromLocation")) Then
        _FromLocation = String.Empty
      Else
        _FromLocation = Ctype(Reader("FromLocation"), String)
      End If
      If Convert.IsDBNull(Reader("ToLocation")) Then
        _ToLocation = String.Empty
      Else
        _ToLocation = Ctype(Reader("ToLocation"), String)
      End If
      _MICN = Ctype(Reader("MICN"),Boolean)
      _CustomInvoiceIssued = Ctype(Reader("CustomInvoiceIssued"),Boolean)
      _CT1Issued = Ctype(Reader("CT1Issued"),Boolean)
      _ARE1Issued = Ctype(Reader("ARE1Issued"),Boolean)
      _DIIssued = Ctype(Reader("DIIssued"),Boolean)
      _PaymentChecked = Ctype(Reader("PaymentChecked"),Boolean)
      _GoodsPacked = Ctype(Reader("GoodsPacked"),Boolean)
      _POApproved = Ctype(Reader("POApproved"),Boolean)
      _WayBill = Ctype(Reader("WayBill"),Boolean)
      _MarkingDetails = Ctype(Reader("MarkingDetails"),Boolean)
      _TarpaulineRequired = Ctype(Reader("TarpaulineRequired"),Boolean)
      _PackageStckable = Ctype(Reader("PackageStckable"),Boolean)
      _InvoiceValue = Ctype(Reader("InvoiceValue"),Decimal)
      _OutOfContract = Ctype(Reader("OutOfContract"),Boolean)
      If Convert.IsDBNull(Reader("ERPPONumber")) Then
        _ERPPONumber = String.Empty
      Else
        _ERPPONumber = Ctype(Reader("ERPPONumber"), String)
      End If
      If Convert.IsDBNull(Reader("BuyerInERP")) Then
        _BuyerInERP = String.Empty
      Else
        _BuyerInERP = Ctype(Reader("BuyerInERP"), String)
      End If
      If Convert.IsDBNull(Reader("ExecuterReasonID")) Then
        _ExecuterReasonID = String.Empty
      Else
        _ExecuterReasonID = Ctype(Reader("ExecuterReasonID"), String)
      End If
      If Convert.IsDBNull(Reader("ExecuterID")) Then
        _ExecuterID = String.Empty
      Else
        _ExecuterID = Ctype(Reader("ExecuterID"), String)
      End If
      If Convert.IsDBNull(Reader("ReasonEneteredOn")) Then
        _ReasonEneteredOn = String.Empty
      Else
        _ReasonEneteredOn = Ctype(Reader("ReasonEneteredOn"), String)
      End If
      _aspnet_Users1_UserFullName = Ctype(Reader("aspnet_Users1_UserFullName"),String)
      _aspnet_Users2_UserFullName = Ctype(Reader("aspnet_Users2_UserFullName"),String)
      _HRM_Divisions3_Description = Ctype(Reader("HRM_Divisions3_Description"),String)
      _IDM_Projects4_Description = Ctype(Reader("IDM_Projects4_Description"),String)
      _IDM_Vendors5_Description = Ctype(Reader("IDM_Vendors5_Description"),String)
      If Convert.IsDBNull(Reader("VR_RequestExecution6_ExecutionDescription")) Then
        _VR_RequestExecution6_ExecutionDescription = String.Empty
      Else
        _VR_RequestExecution6_ExecutionDescription = Ctype(Reader("VR_RequestExecution6_ExecutionDescription"), String)
      End If
      _VR_RequestStates7_Description = Ctype(Reader("VR_RequestStates7_Description"),String)
      _VR_Units8_Description = Ctype(Reader("VR_Units8_Description"),String)
      If Convert.IsDBNull(Reader("VR_VehicleTypes9_cmba")) Then
        _VR_VehicleTypes9_cmba = String.Empty
      Else
        _VR_VehicleTypes9_cmba = Ctype(Reader("VR_VehicleTypes9_cmba"), String)
      End If
      _VR_ODCReasons1_Description = Ctype(Reader("VR_ODCReasons1_Description"),String)
      _VR_Units2_Description = Ctype(Reader("VR_Units2_Description"),String)
      _aspnet_Users10_UserFullName = Ctype(Reader("aspnet_Users10_UserFullName"),String)
      _aspnet_Users11_UserFullName = Ctype(Reader("aspnet_Users11_UserFullName"),String)
      _VR_RequestReasons12_Description = Ctype(Reader("VR_RequestReasons12_Description"),String)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
