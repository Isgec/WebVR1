Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrRequestExecution
    Private Shared _RecordCount As Integer
    Private _SRNNo As Int32 = 0
    Private _ExecutionDescription As String = ""
    Private _TransporterID As String = ""
    Private _VehiclePlacedOn As String = ""
    Private _VehicleTypeID As Int32 = 0
    Private _VehicleNo As String = ""
    Private _Remarks As String = ""
    Private _ArrangedBy As String = ""
    Private _ArrangedOn As String = ""
    Private _TraficOfficerDivisionID As String = ""
    Private _RequestStatusID As Int32 = 0
    Private _ApprovalRemarks As String = ""
    Private _ApprovedBy As String = ""
    Private _ApprovedOn As String = ""
    Private _GRNo As String = ""
    Private _GRDate As String = ""
    Private _LoadedAtSupplier As Boolean = False
    Private _LoadedOn As String = ""
    Private _TransShipment As Boolean = False
    Private _TransGRNO As String = ""
    Private _TransGRDate As String = ""
    Private _TransVehicleNo As String = ""
    Private _TransVehicleTypeID As String = ""
    Private _TransTransporterID As String = ""
    Private _ReceiptAtSite As Boolean = False
    Private _ReceiptBy As String = ""
    Private _ReceiptOn As String = ""
    Private _MaterialStateID As String = ""
    Private _ReceiptMaterialSize As String = ""
    Private _ReceiptMaterialWeight As Decimal = 0
    Private _ReceiptSizeUnit As String = ""
    Private _ReceiptNoOfPackages As Int32 = 0
    Private _ReachedAtSite As Boolean = False
    Private _ReachedOn As String = ""
    Private _UnloadedAtSite As Boolean = False
    Private _UnloadedOn As String = ""
    Private _SiteReceiptNo As String = ""
    Private _SiteReceiptDate As String = ""
    Private _ReceiptRemarks As String = ""
    Private _TransShipmentAtSite As Boolean = False
    Private _SiteGRNO As String = ""
    Private _SiteGRDate As String = ""
    Private _SiteVehicleNo As String = ""
    Private _SiteVehicleTypeID As String = ""
    Private _SiteTransporterID As String = ""
    Private _IRNo As String = ""
    Private _MaterialSize As String = ""
    Private _SizeUnit As String = ""
    Private _Height As Decimal = 0
    Private _Width As Decimal = 0
    Private _Length As Decimal = 0
    Private _MaterialWeight As Decimal = 0
    Private _WeightUnit As String = ""
    Private _NoOfPackages As Int32 = 0
    Private _OverDimentionConsignement As Boolean = False
    Private _GRRemarks As String = ""
    Private _TransRemarks As String = ""
    Private _ReachedAtSupplierOn As String = ""
    Private _ODCByRequest As Boolean = False
    Private _Linked As Boolean = False
    Private _LinkID As String = ""
    Private _VehicleNotPlaced As Boolean = False
    Private _DelayedPlacement As Boolean = False
    Private _EmptyReturn As Boolean = False
    Private _DetentionAtSupplier As Boolean = False
    Private _DebitToTransporter As Boolean = False
    Private _PayableToTransporter As Boolean = False
    Private _BorneByISGEC As Boolean = False
    Private _BorneBySupplier As Boolean = False
    Private _DebitAmount As Decimal = 0
    Private _PayableAmount As Decimal = 0
    Private _ISGECAmount As Decimal = 0
    Private _SupplierAmount As Decimal = 0
    Private _EmptyReturnRemarks As String = ""
    Private _ODCReasonID As String = ""
    Private _EstimatedDistance As Decimal = 0
    Private _EstimatedRatePerKM As Decimal = 0
    Private _EstimatedAmount As Decimal = 0
    Private _EstimatedPOBalance As Decimal = 0
		Private _POValue As Decimal = 0
		Private _SanctionExceeded As Boolean = False
		Private _SanctionExceededApproved As Boolean = False
		Private _SanctionApprovalRemarks As String = ""
		Private _SanctionApprovedBy As String = ""
		Private _SanctionApprovedOn As String = ""
		Private _aspnet_Users1_UserFullName As String = ""
    Private _aspnet_Users2_UserFullName As String = ""
    Private _aspnet_Users3_UserFullName As String = ""
    Private _HRM_Divisions4_Description As String = ""
    Private _VR_MaterialStates5_Description As String = ""
    Private _VR_RequestStates6_Description As String = ""
    Private _VR_TransporterBill7_IRDescription As String = ""
    Private _VR_Transporters8_TransporterName As String = ""
    Private _VR_Transporters9_TransporterName As String = ""
    Private _VR_Transporters10_TransporterName As String = ""
    Private _VR_Units11_Description As String = ""
    Private _VR_VehicleTypes12_cmba As String = ""
    Private _VR_VehicleTypes13_cmba As String = ""
    Private _VR_VehicleTypes14_cmba As String = ""
    Private _VR_Units1_Description As String = ""
    Private _VR_Units2_Description As String = ""
    Private _VR_ODCReasons16_Description As String = ""
		Private _aspnet_Users17_UserFullName As String = ""
		Private _FK_VR_RequestExecution_ArrangedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_RequestExecution_ReceiptBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_RequestExecution_ApprovedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_VR_RequestExecution_TraficOfficerDivisionID As SIS.QCM.qcmDivisions = Nothing
    Private _FK_VR_RequestExecution_MaterialStateID As SIS.VR.vrMaterialStates = Nothing
    Private _FK_VR_RequestExecution_RequestStatusID As SIS.VR.vrRequestStates = Nothing
    Private _FK_VR_RequestExecution_IRNo As SIS.VR.vrTransporterBill = Nothing
    Private _FK_VR_RequestExecution_TransTransporterID As SIS.VR.vrTransporters = Nothing
    Private _FK_VR_RequestExecution_SiteTransporterID As SIS.VR.vrTransporters = Nothing
    Private _FK_VR_RequestExecution_TransporterID As SIS.VR.vrTransporters = Nothing
    Private _FK_VR_RequestExecution_ReceiptSizeUnit As SIS.VR.vrUnits = Nothing
    Private _FK_VR_RequestExecution_SiteVehicleTypeID As SIS.VR.vrVehicleTypes = Nothing
    Private _FK_VR_RequestExecution_VehicleTypeID As SIS.VR.vrVehicleTypes = Nothing
    Private _FK_VR_RequestExecution_TransVehicleTypeID As SIS.VR.vrVehicleTypes = Nothing
    Private _FK_VR_RequestExecution_SizeUnit As SIS.VR.vrUnits = Nothing
    Private _FK_VR_RequestExecution_WeightUnit As SIS.VR.vrUnits = Nothing
    Private _FK_VR_RequestExecution_LinkID As SIS.VR.vrLinkExecutions = Nothing
    Private _FK_VR_RequestExecution_ODCReasonID As SIS.VR.vrODCReasons = Nothing
		Private _FK_VR_RequestExecution_SanctionApprovedBy As SIS.QCM.qcmUsers = Nothing
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
    Public Property ExecutionDescription() As String
      Get
        Return _ExecutionDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ExecutionDescription = ""
				 Else
					 _ExecutionDescription = value
			   End If
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
    Public Property VehiclePlacedOn() As String
      Get
        If Not _VehiclePlacedOn = String.Empty Then
          Return Convert.ToDateTime(_VehiclePlacedOn).ToString("dd/MM/yyyy")
        End If
        Return _VehiclePlacedOn
      End Get
      Set(ByVal value As String)
			   _VehiclePlacedOn = value
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
    Public Property VehicleNo() As String
      Get
        Return _VehicleNo
      End Get
      Set(ByVal value As String)
        _VehicleNo = value
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
    Public Property ArrangedBy() As String
      Get
        Return _ArrangedBy
      End Get
      Set(ByVal value As String)
        _ArrangedBy = value
      End Set
    End Property
    Public Property ArrangedOn() As String
      Get
        If Not _ArrangedOn = String.Empty Then
          Return Convert.ToDateTime(_ArrangedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ArrangedOn
      End Get
      Set(ByVal value As String)
			   _ArrangedOn = value
      End Set
    End Property
    Public Property TraficOfficerDivisionID() As String
      Get
        Return _TraficOfficerDivisionID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TraficOfficerDivisionID = ""
				 Else
					 _TraficOfficerDivisionID = value
			   End If
      End Set
    End Property
    Public Property RequestStatusID() As Int32
      Get
        Return _RequestStatusID
      End Get
      Set(ByVal value As Int32)
        _RequestStatusID = value
      End Set
    End Property
    Public Property ApprovalRemarks() As String
      Get
        Return _ApprovalRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApprovalRemarks = ""
				 Else
					 _ApprovalRemarks = value
			   End If
      End Set
    End Property
    Public Property ApprovedBy() As String
      Get
        Return _ApprovedBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApprovedBy = ""
				 Else
					 _ApprovedBy = value
			   End If
      End Set
    End Property
    Public Property ApprovedOn() As String
      Get
        If Not _ApprovedOn = String.Empty Then
          Return Convert.ToDateTime(_ApprovedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ApprovedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ApprovedOn = ""
				 Else
					 _ApprovedOn = value
			   End If
      End Set
    End Property
    Public Property GRNo() As String
      Get
        Return _GRNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _GRNo = ""
				 Else
					 _GRNo = value
			   End If
      End Set
    End Property
    Public Property GRDate() As String
      Get
        If Not _GRDate = String.Empty Then
          Return Convert.ToDateTime(_GRDate).ToString("dd/MM/yyyy")
        End If
        Return _GRDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _GRDate = ""
				 Else
					 _GRDate = value
			   End If
      End Set
    End Property
    Public Property LoadedAtSupplier() As Boolean
      Get
        Return _LoadedAtSupplier
      End Get
      Set(ByVal value As Boolean)
        _LoadedAtSupplier = value
      End Set
    End Property
    Public Property LoadedOn() As String
      Get
        If Not _LoadedOn = String.Empty Then
          Return Convert.ToDateTime(_LoadedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _LoadedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LoadedOn = ""
				 Else
					 _LoadedOn = value
			   End If
      End Set
    End Property
    Public Property TransShipment() As Boolean
      Get
        Return _TransShipment
      End Get
      Set(ByVal value As Boolean)
        _TransShipment = value
      End Set
    End Property
    Public Property TransGRNO() As String
      Get
        Return _TransGRNO
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransGRNO = ""
				 Else
					 _TransGRNO = value
			   End If
      End Set
    End Property
    Public Property TransGRDate() As String
      Get
        If Not _TransGRDate = String.Empty Then
          Return Convert.ToDateTime(_TransGRDate).ToString("dd/MM/yyyy")
        End If
        Return _TransGRDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransGRDate = ""
				 Else
					 _TransGRDate = value
			   End If
      End Set
    End Property
    Public Property TransVehicleNo() As String
      Get
        Return _TransVehicleNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransVehicleNo = ""
				 Else
					 _TransVehicleNo = value
			   End If
      End Set
    End Property
    Public Property TransVehicleTypeID() As String
      Get
        Return _TransVehicleTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransVehicleTypeID = ""
				 Else
					 _TransVehicleTypeID = value
			   End If
      End Set
    End Property
    Public Property TransTransporterID() As String
      Get
        Return _TransTransporterID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransTransporterID = ""
				 Else
					 _TransTransporterID = value
			   End If
      End Set
    End Property
    Public Property ReceiptAtSite() As Boolean
      Get
        Return _ReceiptAtSite
      End Get
      Set(ByVal value As Boolean)
        _ReceiptAtSite = value
      End Set
    End Property
    Public Property ReceiptBy() As String
      Get
        Return _ReceiptBy
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptBy = ""
				 Else
					 _ReceiptBy = value
			   End If
      End Set
    End Property
    Public Property ReceiptOn() As String
      Get
        If Not _ReceiptOn = String.Empty Then
          Return Convert.ToDateTime(_ReceiptOn).ToString("dd/MM/yyyy")
        End If
        Return _ReceiptOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptOn = ""
				 Else
					 _ReceiptOn = value
			   End If
      End Set
    End Property
    Public Property MaterialStateID() As String
      Get
        Return _MaterialStateID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _MaterialStateID = ""
				 Else
					 _MaterialStateID = value
			   End If
      End Set
    End Property
    Public Property ReceiptMaterialSize() As String
      Get
        Return _ReceiptMaterialSize
      End Get
      Set(ByVal value As String)
        _ReceiptMaterialSize = value
      End Set
    End Property
    Public Property ReceiptMaterialWeight() As Decimal
      Get
        Return _ReceiptMaterialWeight
      End Get
      Set(ByVal value As Decimal)
        _ReceiptMaterialWeight = value
      End Set
    End Property
    Public Property ReceiptSizeUnit() As String
      Get
        Return _ReceiptSizeUnit
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptSizeUnit = ""
				 Else
					 _ReceiptSizeUnit = value
			   End If
      End Set
    End Property
    Public Property ReceiptNoOfPackages() As Int32
      Get
        Return _ReceiptNoOfPackages
      End Get
      Set(ByVal value As Int32)
        _ReceiptNoOfPackages = value
      End Set
    End Property
    Public Property ReachedAtSite() As Boolean
      Get
        Return _ReachedAtSite
      End Get
      Set(ByVal value As Boolean)
        _ReachedAtSite = value
      End Set
    End Property
    Public Property ReachedOn() As String
      Get
        If Not _ReachedOn = String.Empty Then
          Return Convert.ToDateTime(_ReachedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ReachedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReachedOn = ""
				 Else
					 _ReachedOn = value
			   End If
      End Set
    End Property
    Public Property UnloadedAtSite() As Boolean
      Get
        Return _UnloadedAtSite
      End Get
      Set(ByVal value As Boolean)
        _UnloadedAtSite = value
      End Set
    End Property
    Public Property UnloadedOn() As String
      Get
        If Not _UnloadedOn = String.Empty Then
          Return Convert.ToDateTime(_UnloadedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _UnloadedOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _UnloadedOn = ""
				 Else
					 _UnloadedOn = value
			   End If
      End Set
    End Property
    Public Property SiteReceiptNo() As String
      Get
        Return _SiteReceiptNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteReceiptNo = ""
				 Else
					 _SiteReceiptNo = value
			   End If
      End Set
    End Property
    Public Property SiteReceiptDate() As String
      Get
        If Not _SiteReceiptDate = String.Empty Then
          Return Convert.ToDateTime(_SiteReceiptDate).ToString("dd/MM/yyyy")
        End If
        Return _SiteReceiptDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteReceiptDate = ""
				 Else
					 _SiteReceiptDate = value
			   End If
      End Set
    End Property
    Public Property ReceiptRemarks() As String
      Get
        Return _ReceiptRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReceiptRemarks = ""
				 Else
					 _ReceiptRemarks = value
			   End If
      End Set
    End Property
    Public Property TransShipmentAtSite() As Boolean
      Get
        Return _TransShipmentAtSite
      End Get
      Set(ByVal value As Boolean)
        _TransShipmentAtSite = value
      End Set
    End Property
    Public Property SiteGRNO() As String
      Get
        Return _SiteGRNO
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteGRNO = ""
				 Else
					 _SiteGRNO = value
			   End If
      End Set
    End Property
    Public Property SiteGRDate() As String
      Get
        If Not _SiteGRDate = String.Empty Then
          Return Convert.ToDateTime(_SiteGRDate).ToString("dd/MM/yyyy")
        End If
        Return _SiteGRDate
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteGRDate = ""
				 Else
					 _SiteGRDate = value
			   End If
      End Set
    End Property
    Public Property SiteVehicleNo() As String
      Get
        Return _SiteVehicleNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteVehicleNo = ""
				 Else
					 _SiteVehicleNo = value
			   End If
      End Set
    End Property
    Public Property SiteVehicleTypeID() As String
      Get
        Return _SiteVehicleTypeID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteVehicleTypeID = ""
				 Else
					 _SiteVehicleTypeID = value
			   End If
      End Set
    End Property
    Public Property SiteTransporterID() As String
      Get
        Return _SiteTransporterID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _SiteTransporterID = ""
				 Else
					 _SiteTransporterID = value
			   End If
      End Set
    End Property
    Public Property IRNo() As String
      Get
        Return _IRNo
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _IRNo = ""
				 Else
					 _IRNo = value
			   End If
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
    Public Property OverDimentionConsignement() As Boolean
      Get
        Return _OverDimentionConsignement
      End Get
      Set(ByVal value As Boolean)
        _OverDimentionConsignement = value
      End Set
    End Property
    Public Property GRRemarks() As String
      Get
        Return _GRRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _GRRemarks = ""
				 Else
					 _GRRemarks = value
			   End If
      End Set
    End Property
    Public Property TransRemarks() As String
      Get
        Return _TransRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _TransRemarks = ""
				 Else
					 _TransRemarks = value
			   End If
      End Set
    End Property
    Public Property ReachedAtSupplierOn() As String
      Get
        If Not _ReachedAtSupplierOn = String.Empty Then
          Return Convert.ToDateTime(_ReachedAtSupplierOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _ReachedAtSupplierOn
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _ReachedAtSupplierOn = ""
				 Else
					 _ReachedAtSupplierOn = value
			   End If
      End Set
    End Property
    Public Property ODCByRequest() As Boolean
      Get
        Return _ODCByRequest
      End Get
      Set(ByVal value As Boolean)
        _ODCByRequest = value
      End Set
    End Property
    Public Property Linked() As Boolean
      Get
        Return _Linked
      End Get
      Set(ByVal value As Boolean)
        _Linked = value
      End Set
    End Property
    Public Property LinkID() As String
      Get
        Return _LinkID
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _LinkID = ""
				 Else
					 _LinkID = value
			   End If
      End Set
    End Property
    Public Property VehicleNotPlaced() As Boolean
      Get
        Return _VehicleNotPlaced
      End Get
      Set(ByVal value As Boolean)
        _VehicleNotPlaced = value
      End Set
    End Property
    Public Property DelayedPlacement() As Boolean
      Get
        Return _DelayedPlacement
      End Get
      Set(ByVal value As Boolean)
        _DelayedPlacement = value
      End Set
    End Property
    Public Property EmptyReturn() As Boolean
      Get
        Return _EmptyReturn
      End Get
      Set(ByVal value As Boolean)
        _EmptyReturn = value
      End Set
    End Property
    Public Property DetentionAtSupplier() As Boolean
      Get
        Return _DetentionAtSupplier
      End Get
      Set(ByVal value As Boolean)
        _DetentionAtSupplier = value
      End Set
    End Property
    Public Property DebitToTransporter() As Boolean
      Get
        Return _DebitToTransporter
      End Get
      Set(ByVal value As Boolean)
        _DebitToTransporter = value
      End Set
    End Property
    Public Property PayableToTransporter() As Boolean
      Get
        Return _PayableToTransporter
      End Get
      Set(ByVal value As Boolean)
        _PayableToTransporter = value
      End Set
    End Property
    Public Property BorneByISGEC() As Boolean
      Get
        Return _BorneByISGEC
      End Get
      Set(ByVal value As Boolean)
        _BorneByISGEC = value
      End Set
    End Property
    Public Property BorneBySupplier() As Boolean
      Get
        Return _BorneBySupplier
      End Get
      Set(ByVal value As Boolean)
        _BorneBySupplier = value
      End Set
    End Property
    Public Property DebitAmount() As Decimal
      Get
        Return _DebitAmount
      End Get
      Set(ByVal value As Decimal)
        _DebitAmount = value
      End Set
    End Property
    Public Property PayableAmount() As Decimal
      Get
        Return _PayableAmount
      End Get
      Set(ByVal value As Decimal)
        _PayableAmount = value
      End Set
    End Property
    Public Property ISGECAmount() As Decimal
      Get
        Return _ISGECAmount
      End Get
      Set(ByVal value As Decimal)
        _ISGECAmount = value
      End Set
    End Property
    Public Property SupplierAmount() As Decimal
      Get
        Return _SupplierAmount
      End Get
      Set(ByVal value As Decimal)
        _SupplierAmount = value
      End Set
    End Property
    Public Property EmptyReturnRemarks() As String
      Get
        Return _EmptyReturnRemarks
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _EmptyReturnRemarks = ""
				 Else
					 _EmptyReturnRemarks = value
			   End If
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
    Public Property EstimatedDistance() As Decimal
      Get
        Return _EstimatedDistance
      End Get
      Set(ByVal value As Decimal)
        _EstimatedDistance = value
      End Set
    End Property
    Public Property EstimatedRatePerKM() As Decimal
      Get
        Return _EstimatedRatePerKM
      End Get
      Set(ByVal value As Decimal)
        _EstimatedRatePerKM = value
      End Set
    End Property
    Public Property EstimatedAmount() As Decimal
      Get
        Return _EstimatedAmount
      End Get
      Set(ByVal value As Decimal)
        _EstimatedAmount = value
      End Set
    End Property
    Public Property EstimatedPOBalance() As Decimal
      Get
        Return _EstimatedPOBalance
      End Get
      Set(ByVal value As Decimal)
        _EstimatedPOBalance = value
      End Set
    End Property
    Public Property POValue() As Decimal
      Get
        Return _POValue
      End Get
      Set(ByVal value As Decimal)
        _POValue = value
      End Set
    End Property
		Public Property SanctionExceeded() As Boolean
			Get
				Return _SanctionExceeded
			End Get
			Set(ByVal value As Boolean)
				_SanctionExceeded = value
			End Set
		End Property
		Public Property SanctionExceededApproved() As Boolean
			Get
				Return _SanctionExceededApproved
			End Get
			Set(ByVal value As Boolean)
				_SanctionExceededApproved = value
			End Set
		End Property
		Public Property SanctionApprovalRemarks() As String
			Get
				Return _SanctionApprovalRemarks
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_SanctionApprovalRemarks = ""
				Else
					_SanctionApprovalRemarks = value
				End If
			End Set
		End Property
		Public Property SanctionApprovedBy() As String
			Get
				Return _SanctionApprovedBy
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_SanctionApprovedBy = ""
				Else
					_SanctionApprovedBy = value
				End If
			End Set
		End Property
		Public Property SanctionApprovedOn() As String
			Get
				If Not _SanctionApprovedOn = String.Empty Then
					Return Convert.ToDateTime(_SanctionApprovedOn).ToString("dd/MM/yyyy")
				End If
				Return _SanctionApprovedOn
			End Get
			Set(ByVal value As String)
				If Convert.IsDBNull(Value) Then
					_SanctionApprovedOn = ""
				Else
					_SanctionApprovedOn = value
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
    Public Property HRM_Divisions4_Description() As String
      Get
        Return _HRM_Divisions4_Description
      End Get
      Set(ByVal value As String)
        _HRM_Divisions4_Description = value
      End Set
    End Property
    Public Property VR_MaterialStates5_Description() As String
      Get
        Return _VR_MaterialStates5_Description
      End Get
      Set(ByVal value As String)
        _VR_MaterialStates5_Description = value
      End Set
    End Property
    Public Property VR_RequestStates6_Description() As String
      Get
        Return _VR_RequestStates6_Description
      End Get
      Set(ByVal value As String)
        _VR_RequestStates6_Description = value
      End Set
    End Property
    Public Property VR_TransporterBill7_IRDescription() As String
      Get
        Return _VR_TransporterBill7_IRDescription
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_TransporterBill7_IRDescription = ""
				 Else
					 _VR_TransporterBill7_IRDescription = value
			   End If
      End Set
    End Property
    Public Property VR_Transporters8_TransporterName() As String
      Get
        Return _VR_Transporters8_TransporterName
      End Get
      Set(ByVal value As String)
        _VR_Transporters8_TransporterName = value
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
    Public Property VR_Transporters10_TransporterName() As String
      Get
        Return _VR_Transporters10_TransporterName
      End Get
      Set(ByVal value As String)
        _VR_Transporters10_TransporterName = value
      End Set
    End Property
    Public Property VR_Units11_Description() As String
      Get
        Return _VR_Units11_Description
      End Get
      Set(ByVal value As String)
        _VR_Units11_Description = value
      End Set
    End Property
    Public Property VR_VehicleTypes12_cmba() As String
      Get
        Return _VR_VehicleTypes12_cmba
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_VehicleTypes12_cmba = ""
				 Else
					 _VR_VehicleTypes12_cmba = value
			   End If
      End Set
    End Property
    Public Property VR_VehicleTypes13_cmba() As String
      Get
        Return _VR_VehicleTypes13_cmba
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_VehicleTypes13_cmba = ""
				 Else
					 _VR_VehicleTypes13_cmba = value
			   End If
      End Set
    End Property
    Public Property VR_VehicleTypes14_cmba() As String
      Get
        Return _VR_VehicleTypes14_cmba
      End Get
      Set(ByVal value As String)
				 If Convert.IsDBNull(Value) Then
					 _VR_VehicleTypes14_cmba = ""
				 Else
					 _VR_VehicleTypes14_cmba = value
			   End If
      End Set
    End Property
    Public Property VR_Units1_Description() As String
      Get
        Return _VR_Units1_Description
      End Get
      Set(ByVal value As String)
        _VR_Units1_Description = value
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
    Public Property VR_ODCReasons16_Description() As String
      Get
        Return _VR_ODCReasons16_Description
      End Get
      Set(ByVal value As String)
        _VR_ODCReasons16_Description = value
      End Set
    End Property
		Public Property aspnet_Users17_UserFullName() As String
			Get
				Return _aspnet_Users17_UserFullName
			End Get
			Set(ByVal value As String)
				_aspnet_Users17_UserFullName = value
			End Set
		End Property
		Public ReadOnly Property DisplayField() As String
			Get
				Return "" & _ExecutionDescription.ToString.PadRight(50, " ")
			End Get
		End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _SRNNo
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
    Public Class PKvrRequestExecution
			Private _SRNNo As Int32 = 0
			Public Property SRNNo() As Int32
				Get
					Return _SRNNo
				End Get
				Set(ByVal value As Int32)
					_SRNNo = value
				End Set
			End Property
    End Class
    Public ReadOnly Property FK_VR_RequestExecution_ArrangedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_RequestExecution_ArrangedBy Is Nothing Then
          _FK_VR_RequestExecution_ArrangedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ArrangedBy)
        End If
        Return _FK_VR_RequestExecution_ArrangedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_ReceiptBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_RequestExecution_ReceiptBy Is Nothing Then
          _FK_VR_RequestExecution_ReceiptBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ReceiptBy)
        End If
        Return _FK_VR_RequestExecution_ReceiptBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_ApprovedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_VR_RequestExecution_ApprovedBy Is Nothing Then
          _FK_VR_RequestExecution_ApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_ApprovedBy)
        End If
        Return _FK_VR_RequestExecution_ApprovedBy
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_TraficOfficerDivisionID() As SIS.QCM.qcmDivisions
      Get
        If _FK_VR_RequestExecution_TraficOfficerDivisionID Is Nothing Then
          _FK_VR_RequestExecution_TraficOfficerDivisionID = SIS.QCM.qcmDivisions.qcmDivisionsGetByID(_TraficOfficerDivisionID)
        End If
        Return _FK_VR_RequestExecution_TraficOfficerDivisionID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_MaterialStateID() As SIS.VR.vrMaterialStates
      Get
        If _FK_VR_RequestExecution_MaterialStateID Is Nothing Then
          _FK_VR_RequestExecution_MaterialStateID = SIS.VR.vrMaterialStates.vrMaterialStatesGetByID(_MaterialStateID)
        End If
        Return _FK_VR_RequestExecution_MaterialStateID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_RequestStatusID() As SIS.VR.vrRequestStates
      Get
        If _FK_VR_RequestExecution_RequestStatusID Is Nothing Then
          _FK_VR_RequestExecution_RequestStatusID = SIS.VR.vrRequestStates.vrRequestStatesGetByID(_RequestStatusID)
        End If
        Return _FK_VR_RequestExecution_RequestStatusID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_IRNo() As SIS.VR.vrTransporterBill
      Get
        If _FK_VR_RequestExecution_IRNo Is Nothing Then
          _FK_VR_RequestExecution_IRNo = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(_IRNo)
        End If
        Return _FK_VR_RequestExecution_IRNo
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_TransTransporterID() As SIS.VR.vrTransporters
      Get
        If _FK_VR_RequestExecution_TransTransporterID Is Nothing Then
          _FK_VR_RequestExecution_TransTransporterID = SIS.VR.vrTransporters.vrTransportersGetByID(_TransTransporterID)
        End If
        Return _FK_VR_RequestExecution_TransTransporterID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_SiteTransporterID() As SIS.VR.vrTransporters
      Get
        If _FK_VR_RequestExecution_SiteTransporterID Is Nothing Then
          _FK_VR_RequestExecution_SiteTransporterID = SIS.VR.vrTransporters.vrTransportersGetByID(_SiteTransporterID)
        End If
        Return _FK_VR_RequestExecution_SiteTransporterID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_TransporterID() As SIS.VR.vrTransporters
      Get
        If _FK_VR_RequestExecution_TransporterID Is Nothing Then
          _FK_VR_RequestExecution_TransporterID = SIS.VR.vrTransporters.vrTransportersGetByID(_TransporterID)
        End If
        Return _FK_VR_RequestExecution_TransporterID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_ReceiptSizeUnit() As SIS.VR.vrUnits
      Get
        If _FK_VR_RequestExecution_ReceiptSizeUnit Is Nothing Then
          _FK_VR_RequestExecution_ReceiptSizeUnit = SIS.VR.vrUnits.vrUnitsGetByID(_ReceiptSizeUnit)
        End If
        Return _FK_VR_RequestExecution_ReceiptSizeUnit
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_SiteVehicleTypeID() As SIS.VR.vrVehicleTypes
      Get
        If _FK_VR_RequestExecution_SiteVehicleTypeID Is Nothing Then
          _FK_VR_RequestExecution_SiteVehicleTypeID = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(_SiteVehicleTypeID)
        End If
        Return _FK_VR_RequestExecution_SiteVehicleTypeID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_VehicleTypeID() As SIS.VR.vrVehicleTypes
      Get
        If _FK_VR_RequestExecution_VehicleTypeID Is Nothing Then
          _FK_VR_RequestExecution_VehicleTypeID = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(_VehicleTypeID)
        End If
        Return _FK_VR_RequestExecution_VehicleTypeID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_TransVehicleTypeID() As SIS.VR.vrVehicleTypes
      Get
        If _FK_VR_RequestExecution_TransVehicleTypeID Is Nothing Then
          _FK_VR_RequestExecution_TransVehicleTypeID = SIS.VR.vrVehicleTypes.vrVehicleTypesGetByID(_TransVehicleTypeID)
        End If
        Return _FK_VR_RequestExecution_TransVehicleTypeID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_SizeUnit() As SIS.VR.vrUnits
      Get
        If _FK_VR_RequestExecution_SizeUnit Is Nothing Then
          _FK_VR_RequestExecution_SizeUnit = SIS.VR.vrUnits.vrUnitsGetByID(_SizeUnit)
        End If
        Return _FK_VR_RequestExecution_SizeUnit
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_WeightUnit() As SIS.VR.vrUnits
      Get
        If _FK_VR_RequestExecution_WeightUnit Is Nothing Then
          _FK_VR_RequestExecution_WeightUnit = SIS.VR.vrUnits.vrUnitsGetByID(_WeightUnit)
        End If
        Return _FK_VR_RequestExecution_WeightUnit
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_LinkID() As SIS.VR.vrLinkExecutions
      Get
        If _FK_VR_RequestExecution_LinkID Is Nothing Then
          _FK_VR_RequestExecution_LinkID = SIS.VR.vrLinkExecutions.vrLinkExecutionsGetByID(_LinkID, _SRNNo)
        End If
        Return _FK_VR_RequestExecution_LinkID
      End Get
    End Property
    Public ReadOnly Property FK_VR_RequestExecution_ODCReasonID() As SIS.VR.vrODCReasons
      Get
        If _FK_VR_RequestExecution_ODCReasonID Is Nothing Then
          _FK_VR_RequestExecution_ODCReasonID = SIS.VR.vrODCReasons.vrODCReasonsGetByID(_ODCReasonID)
        End If
        Return _FK_VR_RequestExecution_ODCReasonID
      End Get
    End Property
		Public ReadOnly Property FK_VR_RequestExecution_SanctionApprovedBy() As SIS.QCM.qcmUsers
			Get
				If _FK_VR_RequestExecution_SanctionApprovedBy Is Nothing Then
					_FK_VR_RequestExecution_SanctionApprovedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_SanctionApprovedBy)
				End If
				Return _FK_VR_RequestExecution_SanctionApprovedBy
			End Get
		End Property
		<DataObjectMethod(DataObjectMethodType.Select)> _
		Public Shared Function vrRequestExecutionSelectList(ByVal OrderBy As String) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrRequestExecutionSelectList"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.VR.vrRequestExecution)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrRequestExecution(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestExecutionGetNewRecord() As SIS.VR.vrRequestExecution
      Return New SIS.VR.vrRequestExecution()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
      Dim Results As SIS.VR.vrRequestExecution = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrRequestExecution(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByTransporterID(ByVal TransporterID As String, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByTransporterID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,TransporterID.ToString.Length, TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByVehicleTypeID(ByVal VehicleTypeID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByVehicleTypeID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,VehicleTypeID.ToString.Length, VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByRequestStatusID(ByVal RequestStatusID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByRequestStatusID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatusID",SqlDbType.Int,RequestStatusID.ToString.Length, RequestStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByApprovedBy(ByVal ApprovedBy As String, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByApprovedBy"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,ApprovedBy.ToString.Length, ApprovedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByIRNo(ByVal IRNo As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByIRNo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function GetByLinkID(ByVal LinkID As Int32, ByVal OrderBy as String) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByLinkID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,LinkID.ToString.Length, LinkID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrRequestExecution)
      Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvrRequestExecutionSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvrRequestExecutionSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID",SqlDbType.NVarChar,9, IIf(TransporterID Is Nothing, String.Empty,TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID",SqlDbType.Int,10, IIf(VehicleTypeID = Nothing, 0,VehicleTypeID))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrRequestExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrRequestExecution(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrRequestExecutionSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrRequestExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_TransporterID As String, ByVal Filter_VehicleTypeID As Int32) As SIS.VR.vrRequestExecution
      Return UZ_vrRequestExecutionGetByID(SRNNo)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function vrRequestExecutionInsert(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Dim _Rec As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetNewRecord()
      With _Rec
        .ExecutionDescription = Record.ExecutionDescription
        .TransporterID = Record.TransporterID
        .VehiclePlacedOn = Record.VehiclePlacedOn
        .VehicleTypeID = Record.VehicleTypeID
        .VehicleNo = Record.VehicleNo
        .Remarks = Record.Remarks
        .ArrangedBy =  Global.System.Web.HttpContext.Current.Session("LoginID")
        .ArrangedOn = Now
        .TraficOfficerDivisionID = Record.TraficOfficerDivisionID
        .RequestStatusID = 4
        .MaterialSize = Record.MaterialSize
        .SizeUnit = Record.SizeUnit
        .Height = Record.Height
        .Width = Record.Width
        .Length = Record.Length
        .MaterialWeight = Record.MaterialWeight
        .WeightUnit = Record.WeightUnit
        .NoOfPackages = Record.NoOfPackages
        .OverDimentionConsignement = Record.OverDimentionConsignement
        .GRRemarks = Record.GRRemarks
        .TransRemarks = Record.TransRemarks
        .ReachedAtSupplierOn = Record.ReachedAtSupplierOn
        .EstimatedDistance = Record.EstimatedDistance
        .EstimatedRatePerKM = Record.EstimatedRatePerKM
        .EstimatedAmount = Record.EstimatedAmount
        .EstimatedPOBalance = Record.EstimatedPOBalance
        .POValue = Record.POValue
				.SanctionExceeded = Record.SanctionExceeded
				.SanctionExceededApproved = Record.SanctionExceededApproved
				.SanctionApprovalRemarks = Record.SanctionApprovalRemarks
				.SanctionApprovedBy = Record.SanctionApprovedBy
				.SanctionApprovedOn = Record.SanctionApprovedOn
			End With
      Return SIS.VR.vrRequestExecution.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutionDescription",SqlDbType.NVarChar,51, Iif(Record.ExecutionDescription= "" ,Convert.DBNull, Record.ExecutionDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehiclePlacedOn",SqlDbType.DateTime,21, Record.VehiclePlacedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,11, Record.VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,21, Record.VehicleNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrangedBy",SqlDbType.NVarChar,9, Record.ArrangedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrangedOn",SqlDbType.DateTime,21, Record.ArrangedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TraficOfficerDivisionID",SqlDbType.NVarChar,7, Iif(Record.TraficOfficerDivisionID= "" ,Convert.DBNull, Record.TraficOfficerDivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatusID",SqlDbType.Int,11, Record.RequestStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks",SqlDbType.NVarChar,201, Iif(Record.ApprovalRemarks= "" ,Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadedAtSupplier",SqlDbType.Bit,3, Record.LoadedAtSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadedOn",SqlDbType.DateTime,21, Iif(Record.LoadedOn= "" ,Convert.DBNull, Record.LoadedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipment",SqlDbType.Bit,3, Record.TransShipment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransGRNO",SqlDbType.NVarChar,51, Iif(Record.TransGRNO= "" ,Convert.DBNull, Record.TransGRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransGRDate",SqlDbType.DateTime,21, Iif(Record.TransGRDate= "" ,Convert.DBNull, Record.TransGRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransVehicleNo",SqlDbType.NVarChar,21, Iif(Record.TransVehicleNo= "" ,Convert.DBNull, Record.TransVehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransVehicleTypeID",SqlDbType.Int,11, Iif(Record.TransVehicleTypeID= "" ,Convert.DBNull, Record.TransVehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransTransporterID",SqlDbType.NVarChar,10, Iif(Record.TransTransporterID= "" ,Convert.DBNull, Record.TransTransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAtSite",SqlDbType.Bit,3, Record.ReceiptAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptBy= "" ,Convert.DBNull, Record.ReceiptBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptOn",SqlDbType.DateTime,21, Iif(Record.ReceiptOn= "" ,Convert.DBNull, Record.ReceiptOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptMaterialSize",SqlDbType.NVarChar,51, Record.ReceiptMaterialSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptMaterialWeight",SqlDbType.Decimal,21, Record.ReceiptMaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptSizeUnit",SqlDbType.Int,11, Iif(Record.ReceiptSizeUnit= "" ,Convert.DBNull, Record.ReceiptSizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNoOfPackages",SqlDbType.Int,11, Record.ReceiptNoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedAtSite",SqlDbType.Bit,3, Record.ReachedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedOn",SqlDbType.DateTime,21, Iif(Record.ReachedOn= "" ,Convert.DBNull, Record.ReachedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UnloadedAtSite",SqlDbType.Bit,3, Record.UnloadedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UnloadedOn",SqlDbType.DateTime,21, Iif(Record.UnloadedOn= "" ,Convert.DBNull, Record.UnloadedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteReceiptNo",SqlDbType.NVarChar,51, Iif(Record.SiteReceiptNo= "" ,Convert.DBNull, Record.SiteReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteReceiptDate",SqlDbType.DateTime,21, Iif(Record.SiteReceiptDate= "" ,Convert.DBNull, Record.SiteReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptRemarks",SqlDbType.NVarChar,501, Iif(Record.ReceiptRemarks= "" ,Convert.DBNull, Record.ReceiptRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipmentAtSite",SqlDbType.Bit,3, Record.TransShipmentAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteGRNO",SqlDbType.NVarChar,51, Iif(Record.SiteGRNO= "" ,Convert.DBNull, Record.SiteGRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteGRDate",SqlDbType.DateTime,21, Iif(Record.SiteGRDate= "" ,Convert.DBNull, Record.SiteGRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteVehicleNo",SqlDbType.NVarChar,21, Iif(Record.SiteVehicleNo= "" ,Convert.DBNull, Record.SiteVehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteVehicleTypeID",SqlDbType.Int,11, Iif(Record.SiteVehicleTypeID= "" ,Convert.DBNull, Record.SiteVehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteTransporterID",SqlDbType.NVarChar,10, Iif(Record.SiteTransporterID= "" ,Convert.DBNull, Record.SiteTransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Iif(Record.IRNo= "" ,Convert.DBNull, Record.IRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialSize",SqlDbType.NVarChar,51, Record.MaterialSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeUnit",SqlDbType.Int,11, Iif(Record.SizeUnit= "" ,Convert.DBNull, Record.SizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Height",SqlDbType.Decimal,9, Record.Height)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Width",SqlDbType.Decimal,9, Record.Width)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Length",SqlDbType.Decimal,9, Record.Length)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialWeight",SqlDbType.Decimal,21, Record.MaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightUnit",SqlDbType.Int,11, Iif(Record.WeightUnit= "" ,Convert.DBNull, Record.WeightUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackages",SqlDbType.Int,11, Record.NoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimentionConsignement",SqlDbType.Bit,3, Record.OverDimentionConsignement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRRemarks",SqlDbType.NVarChar,501, Iif(Record.GRRemarks= "" ,Convert.DBNull, Record.GRRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransRemarks",SqlDbType.NVarChar,501, Iif(Record.TransRemarks= "" ,Convert.DBNull, Record.TransRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedAtSupplierOn",SqlDbType.DateTime,21, Iif(Record.ReachedAtSupplierOn= "" ,Convert.DBNull, Record.ReachedAtSupplierOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCByRequest",SqlDbType.Bit,3, Record.ODCByRequest)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,3, Record.Linked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,11, Iif(Record.LinkID= "" ,Convert.DBNull, Record.LinkID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNotPlaced",SqlDbType.Bit,3, Record.VehicleNotPlaced)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DelayedPlacement",SqlDbType.Bit,3, Record.DelayedPlacement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturn",SqlDbType.Bit,3, Record.EmptyReturn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionAtSupplier",SqlDbType.Bit,3, Record.DetentionAtSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DebitToTransporter",SqlDbType.Bit,3, Record.DebitToTransporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PayableToTransporter",SqlDbType.Bit,3, Record.PayableToTransporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BorneByISGEC",SqlDbType.Bit,3, Record.BorneByISGEC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BorneBySupplier",SqlDbType.Bit,3, Record.BorneBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DebitAmount",SqlDbType.Decimal,21, Record.DebitAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PayableAmount",SqlDbType.Decimal,21, Record.PayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECAmount",SqlDbType.Decimal,21, Record.ISGECAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierAmount",SqlDbType.Decimal,21, Record.SupplierAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturnRemarks",SqlDbType.NVarChar,251, Iif(Record.EmptyReturnRemarks= "" ,Convert.DBNull, Record.EmptyReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCReasonID",SqlDbType.Int,11, Iif(Record.ODCReasonID= "" ,Convert.DBNull, Record.ODCReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedDistance",SqlDbType.Decimal,13, Record.EstimatedDistance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedRatePerKM",SqlDbType.Decimal,11, Record.EstimatedRatePerKM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedAmount",SqlDbType.Decimal,15, Record.EstimatedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedPOBalance",SqlDbType.Decimal,15, Record.EstimatedPOBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POValue",SqlDbType.Decimal,15, Record.POValue)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionExceeded", SqlDbType.Bit, 3, Record.SanctionExceeded)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionExceededApproved", SqlDbType.Bit, 3, Record.SanctionExceededApproved)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovalRemarks", SqlDbType.NVarChar, 251, IIf(Record.SanctionApprovalRemarks = "", Convert.DBNull, Record.SanctionApprovalRemarks))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.SanctionApprovedBy = "", Convert.DBNull, Record.SanctionApprovedBy))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovedOn", SqlDbType.DateTime, 21, IIf(Record.SanctionApprovedOn = "", Convert.DBNull, Record.SanctionApprovedOn))
					Cmd.Parameters.Add("@Return_SRNNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SRNNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SRNNo = Cmd.Parameters("@Return_SRNNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrRequestExecutionUpdate(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Dim _Rec As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(Record.SRNNo)
      With _Rec
        .ExecutionDescription = Record.ExecutionDescription
        .TransporterID = Record.TransporterID
        .VehiclePlacedOn = Record.VehiclePlacedOn
        .VehicleTypeID = Record.VehicleTypeID
        .VehicleNo = Record.VehicleNo
        .Remarks = Record.Remarks
        .ArrangedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ArrangedOn = Now
        .TraficOfficerDivisionID = Record.TraficOfficerDivisionID
        '.RequestStatusID = 4
        .MaterialSize = Record.MaterialSize
        .SizeUnit = Record.SizeUnit
        .Height = Record.Height
        .Width = Record.Width
        .Length = Record.Length
        .MaterialWeight = Record.MaterialWeight
        .WeightUnit = Record.WeightUnit
        .NoOfPackages = Record.NoOfPackages
        .OverDimentionConsignement = Record.OverDimentionConsignement
        .GRRemarks = Record.GRRemarks
        .TransRemarks = Record.TransRemarks
        .ReachedAtSupplierOn = Record.ReachedAtSupplierOn
        .EstimatedDistance = Record.EstimatedDistance
        .EstimatedRatePerKM = Record.EstimatedRatePerKM
        .EstimatedAmount = Record.EstimatedAmount
        .EstimatedPOBalance = Record.EstimatedPOBalance
				.POValue = Record.POValue
				.SanctionExceeded = Record.SanctionExceeded
				.SanctionExceededApproved = Record.SanctionExceededApproved
				.SanctionApprovalRemarks = Record.SanctionApprovalRemarks
				.SanctionApprovedBy = Record.SanctionApprovedBy
				.SanctionApprovedOn = Record.SanctionApprovedOn
			End With
			Return SIS.VR.vrRequestExecution.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SRNNo",SqlDbType.Int,11, Record.SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ExecutionDescription",SqlDbType.NVarChar,51, Iif(Record.ExecutionDescription= "" ,Convert.DBNull, Record.ExecutionDescription))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID",SqlDbType.NVarChar,10, Record.TransporterID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehiclePlacedOn",SqlDbType.DateTime,21, Record.VehiclePlacedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleTypeID",SqlDbType.Int,11, Record.VehicleTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNo",SqlDbType.NVarChar,21, Record.VehicleNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Remarks",SqlDbType.NVarChar,501, Iif(Record.Remarks= "" ,Convert.DBNull, Record.Remarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrangedBy",SqlDbType.NVarChar,9, Record.ArrangedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ArrangedOn",SqlDbType.DateTime,21, Record.ArrangedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TraficOfficerDivisionID",SqlDbType.NVarChar,7, Iif(Record.TraficOfficerDivisionID= "" ,Convert.DBNull, Record.TraficOfficerDivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatusID",SqlDbType.Int,11, Record.RequestStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovalRemarks",SqlDbType.NVarChar,201, Iif(Record.ApprovalRemarks= "" ,Convert.DBNull, Record.ApprovalRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedBy",SqlDbType.NVarChar,9, Iif(Record.ApprovedBy= "" ,Convert.DBNull, Record.ApprovedBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApprovedOn",SqlDbType.DateTime,21, Iif(Record.ApprovedOn= "" ,Convert.DBNull, Record.ApprovedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRNo",SqlDbType.NVarChar,51, Iif(Record.GRNo= "" ,Convert.DBNull, Record.GRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRDate",SqlDbType.DateTime,21, Iif(Record.GRDate= "" ,Convert.DBNull, Record.GRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadedAtSupplier",SqlDbType.Bit,3, Record.LoadedAtSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoadedOn",SqlDbType.DateTime,21, Iif(Record.LoadedOn= "" ,Convert.DBNull, Record.LoadedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipment",SqlDbType.Bit,3, Record.TransShipment)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransGRNO",SqlDbType.NVarChar,51, Iif(Record.TransGRNO= "" ,Convert.DBNull, Record.TransGRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransGRDate",SqlDbType.DateTime,21, Iif(Record.TransGRDate= "" ,Convert.DBNull, Record.TransGRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransVehicleNo",SqlDbType.NVarChar,21, Iif(Record.TransVehicleNo= "" ,Convert.DBNull, Record.TransVehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransVehicleTypeID",SqlDbType.Int,11, Iif(Record.TransVehicleTypeID= "" ,Convert.DBNull, Record.TransVehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransTransporterID",SqlDbType.NVarChar,10, Iif(Record.TransTransporterID= "" ,Convert.DBNull, Record.TransTransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptAtSite",SqlDbType.Bit,3, Record.ReceiptAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptBy",SqlDbType.NVarChar,9, Iif(Record.ReceiptBy= "" ,Convert.DBNull, Record.ReceiptBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptOn",SqlDbType.DateTime,21, Iif(Record.ReceiptOn= "" ,Convert.DBNull, Record.ReceiptOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialStateID",SqlDbType.Int,11, Iif(Record.MaterialStateID= "" ,Convert.DBNull, Record.MaterialStateID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptMaterialSize",SqlDbType.NVarChar,51, Record.ReceiptMaterialSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptMaterialWeight",SqlDbType.Decimal,21, Record.ReceiptMaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptSizeUnit",SqlDbType.Int,11, Iif(Record.ReceiptSizeUnit= "" ,Convert.DBNull, Record.ReceiptSizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptNoOfPackages",SqlDbType.Int,11, Record.ReceiptNoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedAtSite",SqlDbType.Bit,3, Record.ReachedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedOn",SqlDbType.DateTime,21, Iif(Record.ReachedOn= "" ,Convert.DBNull, Record.ReachedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UnloadedAtSite",SqlDbType.Bit,3, Record.UnloadedAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UnloadedOn",SqlDbType.DateTime,21, Iif(Record.UnloadedOn= "" ,Convert.DBNull, Record.UnloadedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteReceiptNo",SqlDbType.NVarChar,51, Iif(Record.SiteReceiptNo= "" ,Convert.DBNull, Record.SiteReceiptNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteReceiptDate",SqlDbType.DateTime,21, Iif(Record.SiteReceiptDate= "" ,Convert.DBNull, Record.SiteReceiptDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReceiptRemarks",SqlDbType.NVarChar,501, Iif(Record.ReceiptRemarks= "" ,Convert.DBNull, Record.ReceiptRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransShipmentAtSite",SqlDbType.Bit,3, Record.TransShipmentAtSite)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteGRNO",SqlDbType.NVarChar,51, Iif(Record.SiteGRNO= "" ,Convert.DBNull, Record.SiteGRNO))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteGRDate",SqlDbType.DateTime,21, Iif(Record.SiteGRDate= "" ,Convert.DBNull, Record.SiteGRDate))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteVehicleNo",SqlDbType.NVarChar,21, Iif(Record.SiteVehicleNo= "" ,Convert.DBNull, Record.SiteVehicleNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteVehicleTypeID",SqlDbType.Int,11, Iif(Record.SiteVehicleTypeID= "" ,Convert.DBNull, Record.SiteVehicleTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SiteTransporterID",SqlDbType.NVarChar,10, Iif(Record.SiteTransporterID= "" ,Convert.DBNull, Record.SiteTransporterID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,11, Iif(Record.IRNo= "" ,Convert.DBNull, Record.IRNo))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialSize",SqlDbType.NVarChar,51, Record.MaterialSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SizeUnit",SqlDbType.Int,11, Iif(Record.SizeUnit= "" ,Convert.DBNull, Record.SizeUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Height",SqlDbType.Decimal,9, Record.Height)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Width",SqlDbType.Decimal,9, Record.Width)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Length",SqlDbType.Decimal,9, Record.Length)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaterialWeight",SqlDbType.Decimal,21, Record.MaterialWeight)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WeightUnit",SqlDbType.Int,11, Iif(Record.WeightUnit= "" ,Convert.DBNull, Record.WeightUnit))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NoOfPackages",SqlDbType.Int,11, Record.NoOfPackages)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OverDimentionConsignement",SqlDbType.Bit,3, Record.OverDimentionConsignement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GRRemarks",SqlDbType.NVarChar,501, Iif(Record.GRRemarks= "" ,Convert.DBNull, Record.GRRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransRemarks",SqlDbType.NVarChar,501, Iif(Record.TransRemarks= "" ,Convert.DBNull, Record.TransRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReachedAtSupplierOn",SqlDbType.DateTime,21, Iif(Record.ReachedAtSupplierOn= "" ,Convert.DBNull, Record.ReachedAtSupplierOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCByRequest",SqlDbType.Bit,3, Record.ODCByRequest)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Linked",SqlDbType.Bit,3, Record.Linked)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LinkID",SqlDbType.Int,11, Iif(Record.LinkID= "" ,Convert.DBNull, Record.LinkID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VehicleNotPlaced",SqlDbType.Bit,3, Record.VehicleNotPlaced)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DelayedPlacement",SqlDbType.Bit,3, Record.DelayedPlacement)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturn",SqlDbType.Bit,3, Record.EmptyReturn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DetentionAtSupplier",SqlDbType.Bit,3, Record.DetentionAtSupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DebitToTransporter",SqlDbType.Bit,3, Record.DebitToTransporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PayableToTransporter",SqlDbType.Bit,3, Record.PayableToTransporter)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BorneByISGEC",SqlDbType.Bit,3, Record.BorneByISGEC)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BorneBySupplier",SqlDbType.Bit,3, Record.BorneBySupplier)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DebitAmount",SqlDbType.Decimal,21, Record.DebitAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PayableAmount",SqlDbType.Decimal,21, Record.PayableAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ISGECAmount",SqlDbType.Decimal,21, Record.ISGECAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SupplierAmount",SqlDbType.Decimal,21, Record.SupplierAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EmptyReturnRemarks",SqlDbType.NVarChar,251, Iif(Record.EmptyReturnRemarks= "" ,Convert.DBNull, Record.EmptyReturnRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ODCReasonID",SqlDbType.Int,11, Iif(Record.ODCReasonID= "" ,Convert.DBNull, Record.ODCReasonID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedDistance",SqlDbType.Decimal,13, Record.EstimatedDistance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedRatePerKM",SqlDbType.Decimal,11, Record.EstimatedRatePerKM)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedAmount",SqlDbType.Decimal,15, Record.EstimatedAmount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@EstimatedPOBalance",SqlDbType.Decimal,15, Record.EstimatedPOBalance)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@POValue",SqlDbType.Decimal,15, Record.POValue)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionExceeded", SqlDbType.Bit, 3, Record.SanctionExceeded)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionExceededApproved", SqlDbType.Bit, 3, Record.SanctionExceededApproved)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovalRemarks", SqlDbType.NVarChar, 251, IIf(Record.SanctionApprovalRemarks = "", Convert.DBNull, Record.SanctionApprovalRemarks))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovedBy", SqlDbType.NVarChar, 9, IIf(Record.SanctionApprovedBy = "", Convert.DBNull, Record.SanctionApprovedBy))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SanctionApprovedOn", SqlDbType.DateTime, 21, IIf(Record.SanctionApprovedOn = "", Convert.DBNull, Record.SanctionApprovedOn))
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
    Public Shared Function vrRequestExecutionDelete(ByVal Record As SIS.VR.vrRequestExecution) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionDelete"
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
'		Autocomplete Method
		Public Shared Function SelectvrRequestExecutionAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvrRequestExecutionAutoCompleteList"
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
            Dim Tmp As SIS.VR.vrRequestExecution = New SIS.VR.vrRequestExecution(Reader)
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
