Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.VR
  Partial Public Class vrRequestExecution
		Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
			If RequestStatusID = RequestStates.ODCRejected Then
				mRet = Drawing.Color.Red
			ElseIf RequestStatusID = RequestStates.RequestLinked Then
				mRet = Drawing.Color.DarkGoldenrod
			ElseIf RequestStatusID = RequestStates.ODCUnderApproval Then
				mRet = Drawing.Color.DarkOrange
			ElseIf RequestStatusID = RequestStates.VehicleArranged Then
				mRet = Drawing.Color.Green
			ElseIf RequestStatusID = RequestStates.GRLinked Then
				mRet = Drawing.Color.DarkGoldenrod
			End If
      Return mRet
		End Function
		Public ReadOnly Property SanctionColor() As System.Drawing.Color
			Get
				If SanctionBalance < 0 Then
					Return Drawing.Color.Red
				Else
					Return GetColor()
				End If
			End Get
		End Property
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public ReadOnly Property Notification() As String
			Get
				Dim mRet As String = ""
				If SanctionExceeded And Not SanctionExceededApproved Then
					mRet = "<img alt='warning' src='../../images/Error.gif' style='height:14px; width:14px' /><b>Sanction consumed, Approval Required</b>"
				End If
				Return mRet
			End Get
		End Property

		Private _Supplier As SIS.QCM.qcmVendors = Nothing
		Private _Project As SIS.QCM.qcmProjects = Nothing
		Public ReadOnly Property Project() As SIS.QCM.qcmProjects
			Get
				If _Project Is Nothing Then
					Dim tmp As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(_SRNNo, "")
					If tmp.Count > 0 Then
						_Supplier = tmp(0).FK_VR_VehicleRequest_SupplierID
						_Project = tmp(0).FK_VR_VehicleRequest_ProjectID
					End If
				End If
				Return _Project
			End Get
		End Property
		Public ReadOnly Property SanctionBalance() As Decimal
			Get
				Return POValue - EstimatedPOBalance
			End Get
		End Property
		Public ReadOnly Property Supplier() As SIS.QCM.qcmVendors
			Get
				If _Supplier Is Nothing Then
					Dim tmp As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(_SRNNo, "")
					If tmp.Count > 0 Then
						_Supplier = tmp(0).FK_VR_VehicleRequest_SupplierID
						_Project = tmp(0).FK_VR_VehicleRequest_ProjectID
					End If
				End If
				Return _Supplier
			End Get
		End Property
		Public ReadOnly Property ForApprovalVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _Linked Then
						If _SRNNo.ToString = _LinkID Then
							Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(_SRNNo, "")
							mRet = True
							For Each le As SIS.VR.vrRequestExecution In oLEs
								If _RequestStatusID <> RequestStates.GRLinked _
								And _RequestStatusID <> RequestStates.ODCRejected _
								And _RequestStatusID <> RequestStates.VehicleNotPlacedRejected _
								And _RequestStatusID <> RequestStates.DelayedPlacementRejected _
								And _RequestStatusID <> RequestStates.EmptyReturnRejected _
								 And _RequestStatusID <> 27 _
								And _RequestStatusID <> RequestStates.DetentionRejected Then
								Else
									mRet = False
									Exit For
								End If
							Next
						End If
					Else
						If _RequestStatusID = RequestStates.GRLinked _
						Or _RequestStatusID = RequestStates.ODCRejected _
						Or _RequestStatusID = RequestStates.VehicleNotPlacedRejected _
						Or _RequestStatusID = RequestStates.DelayedPlacementRejected _
						Or _RequestStatusID = RequestStates.EmptyReturnRejected _
						Or _RequestStatusID = 27 _
						Or _RequestStatusID = RequestStates.DetentionRejected Then
							mRet = True
						End If
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property LinkVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _RequestStatusID = RequestStates.RequestLinked Then
						If _Linked Then
							If _SRNNo.ToString = _LinkID Then
								mRet = True
							End If
						Else
							mRet = True
						End If
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property InitiateWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
          If _RequestStatusID = RequestStates.RequestLinked Or _RequestStatusID = 29 Or _RequestStatusID = 27 Then 'Or _RequestStatusID = 28 Then '29=Sanction Approved
            If _Linked Then
              If _SRNNo.ToString = _LinkID Then
                mRet = True
              End If
            Else
              mRet = True
            End If
          End If
        Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
					If _RequestStatusID = RequestStates.VehicleArranged _
					Or _RequestStatusID = RequestStates.SelfRejected _
					Or _RequestStatusID = RequestStates.ODCRejected _
					Or _RequestStatusID = RequestStates.GRLinked Then
						mRet = True
					End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
		Public ReadOnly Property CancelWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _RequestStatusID = RequestStates.VehicleArranged _
					Or _RequestStatusID = RequestStates.SelfRejected _
					Or _RequestStatusID = RequestStates.VehicleNotPlacedRejected _
					Or _RequestStatusID = RequestStates.DelayedPlacementRejected _
					Or _RequestStatusID = RequestStates.EmptyReturnRejected _
					Or _RequestStatusID = RequestStates.DetentionRejected _
					Or _RequestStatusID = RequestStates.ODCRejected Then
						If _Linked Then
							If _SRNNo.ToString = _LinkID Then
								mRet = True
							End If
						Else
							mRet = True
						End If
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property CancelWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property CompleteWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _RequestStatusID = RequestStates.ODCApproved _
					Or _RequestStatusID = RequestStates.VehicleNotPlacedApproved _
					Or _RequestStatusID = RequestStates.DelayedPlacementApproved _
					Or _RequestStatusID = RequestStates.EmptyReturnApproved _
					Or _RequestStatusID = RequestStates.DetentionApproved _
					Or _RequestStatusID = RequestStates.SelfApproved Then
						'If Linked:To Be discussed with Ajay Gupta
						mRet = True
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property CompleteWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		'Confirm Vehicle
		Public Shared Function InitiateWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
			Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
			'Checking of Estimated Amount Entered or NOT is Mandatory is pending
			'===========Commented====================
			If Not Results.SanctionExceededApproved Then
				If Not Results.SanctionExceeded Then
					'Check Sanction First
					Dim SanctionExceeded As Boolean = False
					Results = SIS.VR.vrRequestExecution.ValidateSanction(SRNNo, "")
					SIS.VR.vrRequestExecution.UpdateData(Results)
					If Results.SanctionBalance < 0 Then
						SanctionExceeded = True
					Else
						For Each le As SIS.VR.vrRequestExecution In oLEs
							le = SIS.VR.vrRequestExecution.ValidateSanction(le.SRNNo, "")
							SIS.VR.vrRequestExecution.UpdateData(le)
							If le.SanctionBalance < 0 Then
								SanctionExceeded = True
							End If
						Next
					End If
					'If any exceeded found
					'Assign in all Linked
					If SanctionExceeded Then
						Results.SanctionExceeded = True
						Results.RequestStatusID = 28
						SIS.VR.vrRequestExecution.UpdateData(Results)
						For Each le As SIS.VR.vrRequestExecution In oLEs
							le.SanctionExceeded = True
							le.RequestStatusID = 28
							SIS.VR.vrRequestExecution.UpdateData(le)
						Next
					End If
					If SanctionExceeded Then
						SendEMailSanctionApproval(Results)
						Return Results
					End If
				End If
			End If
			'Checking Sanction Consumed Percent And Alert
			Dim ProjectID As String = Results.Project.ProjectID
			Dim tmpCon As Decimal = 0
			Try
				tmpCon = (Results.EstimatedPOBalance / Results.POValue) * 100
			Catch ex As Exception
				tmpCon = 100
			End Try
			Dim oSPC As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(ProjectID)
			If oSPC Is Nothing Then
				oSPC = New SIS.VR.vrSanctionAlert
				With oSPC
					.ProjectID = ProjectID
					.EMailIDs = "shatrughan.sharma@isgec.co.in,randhir@isgec.co.in,girish.belwal@isgec.co.in"
					SIS.VR.vrSanctionAlert.InsertData(oSPC)
				End With
			End If
			If tmpCon < 60 Then
			ElseIf tmpCon >= 60 And tmpCon < 70 Then
				If Not oSPC.At60 Then
					oSPC.At60 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 70 And tmpCon < 80 Then
				If Not oSPC.At70 Then
					oSPC.At70 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 80 And tmpCon < 90 Then
				If Not oSPC.At80 Then
					oSPC.At80 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 90 And tmpCon < 95 Then
				If Not oSPC.At90 Then
					oSPC.At90 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 95 And tmpCon < 96 Then
				If Not oSPC.At95 Then
					oSPC.At95 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 96 And tmpCon < 97 Then
				If Not oSPC.At96 Then
					oSPC.At96 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 97 And tmpCon < 98 Then
				If Not oSPC.At97 Then
					oSPC.At97 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 98 And tmpCon < 99 Then
				If Not oSPC.At98 Then
					oSPC.At98 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			ElseIf tmpCon >= 99 And tmpCon <= 100 Then
				If Not oSPC.At99 Then
					oSPC.At99 = True
					SIS.VR.vrSanctionAlert.UpdateData(oSPC)
					SendEMailSanctionConsumption(Results, tmpCon)
				End If
			End If
			'' ''End Consumed Alert
			'=====================
			'Main Execution
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNo, "")
			If oVRs.Count > 0 Then
				Dim ODCFound As Boolean = False
				For Each oVR As SIS.VR.vrVehicleRequest In oVRs
					If oVR.OverDimentionConsignement Then
						ODCFound = True
					End If
					oVR.RequestStatus = RequestStates.VehicleArranged
					SIS.VR.vrVehicleRequest.UpdateData(oVR)
				Next
				With Results
					.RequestStatusID = RequestStates.VehicleArranged
					.ArrangedBy = HttpContext.Current.Session("LoginID")
					.ArrangedOn = Now
					.ODCByRequest = ODCFound
				End With
				Results = SIS.VR.vrRequestExecution.UpdateData(Results)
				Try
					CT_RequestExecuted(Results)
				Catch ex As Exception
				End Try

			End If
			'Linked Executions
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = Results.SRNNo Then Continue For
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
				If oVRs.Count > 0 Then
					Dim ODCFound As Boolean = False
					For Each oVR As SIS.VR.vrVehicleRequest In oVRs
						If oVR.OverDimentionConsignement Then
							ODCFound = True
						End If
						oVR.RequestStatus = RequestStates.VehicleArranged
						SIS.VR.vrVehicleRequest.UpdateData(oVR)
					Next
					With le
						.RequestStatusID = RequestStates.VehicleArranged
						.ArrangedBy = HttpContext.Current.Session("LoginID")
						.ArrangedOn = Now
						.ODCByRequest = ODCFound
					End With
					le = SIS.VR.vrRequestExecution.UpdateData(le)
				End If
			Next
			SendEMail(Results)
			Return Results
		End Function
		Public Shared Sub CT_RequestExecuted(ByVal rE As SIS.VR.vrRequestExecution)
			Dim hndl As String = "CT_VEHICLEREQUESTPLACED"
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(rE.SRNNo, "")
			If oVRs.Count > 0 Then
				Dim ODCFound As Boolean = False
				For Each rq As SIS.VR.vrVehicleRequest In oVRs
					Dim poElements As ArrayList = SIS.CT.ctPOLChild.GetPOElements(rq.ERPPONumber)
					Dim SrNo As Integer = 0
					For Each Str As String In poElements
						SrNo += 1
						Dim ctH As New SIS.CT.ctHeader
						With ctH
							.t_trdt = rE.ArrangedOn
							.t_bohd = hndl
							.t_indv = rE.SRNNo
							.t_srno = SrNo
							.t_proj = rq.ProjectID
							.t_elem = Str
							.t_user = re.ArrangedBy
							.t_stat = ""
						End With
						ctH = SIS.CT.ctHeader.InsertData(ctH)
						Dim DSrn As Integer = 0
						Dim Chlds As ArrayList = SIS.CT.ctPOLChild.GetPODocuments(rq.ERPPONumber)
						If Chlds.Count > 0 Then
							For Each chld As String In Chlds
								DSrn += 1
								Dim ctD As New SIS.CT.ctDetail
								With ctD
									.t_trdt = rE.ArrangedOn
									.t_bohd = hndl
									.t_indv = rE.SRNNo
									.t_srno = ctH.t_srno
									.t_dsno = DSrn
									.t_dwno = chld
									.t_elem = Str
									.t_proj = rq.ProjectID
									.t_wght = 0
									.t_pitc = 0
								End With
								ctD = SIS.CT.ctDetail.InsertData(ctD)
							Next
						End If
					Next
				Next
			End If

		End Sub

		'Cancel Vehicle
		Public Shared Function CancelWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
			Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(Results.SRNNo, "")
			If oVRs.Count > 0 Then
				For Each oVR As SIS.VR.vrVehicleRequest In oVRs
					oVR.RequestStatus = RequestStates.RequestLinked
					SIS.VR.vrVehicleRequest.UpdateData(oVR)
				Next
				With Results
					.RequestStatusID = RequestStates.RequestLinked
					.ArrangedBy = HttpContext.Current.Session("LoginID")
					.ArrangedOn = Now
					.ODCByRequest = False
					'Remove GR Entry
					.VehicleNo = ""
					.GRNo = ""
					.GRDate = ""
					.LoadedAtSupplier = False
					.LoadedOn = ""
					.ReachedAtSupplierOn = ""
					.SizeUnit = ""
					.Height = 0
					.Width = 0
					.Length = 0
					.MaterialWeight = 0
					.WeightUnit = ""
					.NoOfPackages = 0
					.OverDimentionConsignement = False
					.GRRemarks = ""
				End With
				Results = SIS.VR.vrRequestExecution.UpdateData(Results)
			End If
			'Linked Executions
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(Results.SRNNo, "")
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = Results.SRNNo Then Continue For
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
				If oVRs.Count > 0 Then
					For Each oVR As SIS.VR.vrVehicleRequest In oVRs
						oVR.RequestStatus = RequestStates.RequestLinked
						SIS.VR.vrVehicleRequest.UpdateData(oVR)
					Next
					With le
						.RequestStatusID = RequestStates.RequestLinked
						.ArrangedBy = HttpContext.Current.Session("LoginID")
						.ArrangedOn = Now
						.ODCByRequest = False
						'Remove GR Entry
						.VehicleNo = ""
						.GRNo = ""
						.GRDate = ""
						.LoadedAtSupplier = False
						.LoadedOn = ""
						.ReachedAtSupplierOn = ""
						.SizeUnit = ""
						.Height = 0
						.Width = 0
						.Length = 0
						.MaterialWeight = 0
						.WeightUnit = ""
						.NoOfPackages = 0
						.OverDimentionConsignement = False
						.GRRemarks = ""
					End With
					le = SIS.VR.vrRequestExecution.UpdateData(le)
				End If
			Next
			SendEMail(Results, True)
			Return Results
		End Function
		'Old Send For Approval As soon as GR Linked and saved
		'Public Shared Function ApproveWF(ByVal oRE As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
		'	If oRE.OverDimentionConsignement Then
		'		oRE.RequestStatusID = RequestStates.ODCUnderApproval
		'	Else
		'		oRE.RequestStatusID = RequestStates.UnderSelfApproval
		'	End If
		'	oRE.ApprovalRemarks = ""
		'	oRE.ApprovedBy = ""
		'	oRE.ApprovedOn = ""
		'	Dim Results As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UpdateData(oRE)
		'	Return Results
		'End Function
		'Send For Approval
		Public Shared Function SendForApproval(ByVal SRNNo As Int32) As Boolean
			Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
			If oRE.Linked Then
				Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
				For Each le As SIS.VR.vrRequestExecution In oLEs
					With le
						If .OverDimentionConsignement Then
							.RequestStatusID = RequestStates.ODCUnderApproval
						ElseIf .DetentionAtSupplier Then
							.RequestStatusID = RequestStates.DetentionUnderApproval
						ElseIf .DelayedPlacement Then
							.RequestStatusID = RequestStates.DelayedPlacementUnderApproval
						ElseIf .EmptyReturn Then
							.RequestStatusID = RequestStates.EmptyReturnRUnderApproval
						ElseIf .VehicleNotPlaced Then
							.RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval
						Else
							.RequestStatusID = RequestStates.UnderSelfApproval
						End If
						.ApprovalRemarks = ""
						.ApprovedBy = ""
						.ApprovedOn = ""
					End With
					le = SIS.VR.vrRequestExecution.UpdateData(oRE)
					If le.VehicleNotPlaced Or le.EmptyReturn Then
						BlockExecution(le)
					End If
				Next
			Else 'Not Linked
				With oRE
					If .OverDimentionConsignement Then
						.RequestStatusID = RequestStates.ODCUnderApproval
					ElseIf .DetentionAtSupplier Then
						.RequestStatusID = RequestStates.DetentionUnderApproval
					ElseIf .DelayedPlacement Then
						.RequestStatusID = RequestStates.DelayedPlacementUnderApproval
					ElseIf .EmptyReturn Then
						.RequestStatusID = RequestStates.EmptyReturnRUnderApproval
					ElseIf .VehicleNotPlaced Then
						.RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval
					Else
						.RequestStatusID = RequestStates.UnderSelfApproval
					End If
					.ApprovalRemarks = ""
					.ApprovedBy = ""
					.ApprovedOn = ""
				End With
				oRE = SIS.VR.vrRequestExecution.UpdateData(oRE)
				If oRE.VehicleNotPlaced Or oRE.EmptyReturn Then
					DelinkRequestsOfBlockedExecution(oRE)
				End If
			End If
			'SendForApprovalEMail(oRE)
			Return True
		End Function
		Public Shared Function BlockExecution(ByVal oRE As SIS.VR.vrRequestExecution) As Boolean
			Dim LinkID As String = oRE.LinkID
			Dim IsMain As Boolean = IIf(oRE.SRNNo.ToString = oRE.LinkID, True, False)
			'Delink From Execution
			With oRE
				.Linked = False
				.LinkID = ""
			End With
			SIS.VR.vrRequestExecution.UpdateData(oRE)
			DelinkRequestsOfBlockedExecution(oRE)
			'Select Rest of the Execution in link to Check 
			'If only one execution left, then remove it from Linked status
			'If more than one left then retain Linked status
			'If Main Link is removed, Make Other Link as Main
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(LinkID, "")
			If oLEs.Count = 1 Then
				oLEs(0).Linked = False
				oLEs(0).LinkID = ""
				SIS.VR.vrRequestExecution.UpdateData(oLEs(0))
				DelinkRequestsOfBlockedExecution(oLEs(0))
			Else
				If IsMain Then
					Dim NewLinkID As String = oLEs(0).SRNNo
					For Each le As SIS.VR.vrRequestExecution In oLEs
						le.LinkID = NewLinkID
						SIS.VR.vrRequestExecution.UpdateData(le)
					Next
				End If
			End If
			Return True
		End Function
		Public Shared Function DelinkRequestsOfBlockedExecution(ByVal oRE As SIS.VR.vrRequestExecution) As Boolean
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
			For Each oVR As SIS.VR.vrVehicleRequest In oVRs
				Dim OldRequestNo As String = oVR.RequestNo
				'Create New Request By Copying
				With oVR
					.RequestDescription = "OLD Request No: " & OldRequestNo
					.RequestStatus = RequestStates.UnderExecution
					.SRNNo = ""
					.ODCAtSupplierLoading = False
				End With
				oVR = SIS.VR.vrVehicleRequest.InsertData(oVR)
				Dim NewRequestNo As String = oVR.RequestNo
				'Get Old Request to Block
				oVR = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(OldRequestNo)
				With oVR
					oVR.RequestDescription = "NEW Request No: " & NewRequestNo
					.RequestStatus = RequestStates.RequestBlocked
				End With
				oVR = SIS.VR.vrVehicleRequest.UpdateData(oVR)
			Next
			Return True
		End Function
		'Trans Shipment
		Public Shared Function CompleteWF(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
			Dim Results As SIS.VR.vrRequestExecution = vrRequestExecutionGetByID(SRNNo)
			Return Results
		End Function
		Public Shared Function UZ_vrRequestExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_RequestExecutionSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_RequestExecutionSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
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
		Public Shared Function UZ_vrDisplayRequestExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_DisplayRequestExecutionSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_DisplayRequestExecutionSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
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

		Public Shared Function UZ_vrRequestExecutionInsert(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
			Dim _Result As SIS.VR.vrRequestExecution = vrRequestExecutionInsert(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrRequestExecutionUpdate(ByVal Record As SIS.VR.vrRequestExecution) As SIS.VR.vrRequestExecution
			Dim _Result As SIS.VR.vrRequestExecution = vrRequestExecutionUpdate(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrRequestExecutionDelete(ByVal Record As SIS.VR.vrRequestExecution) As Integer
			Dim _Result As Integer = vrRequestExecutionDelete(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrRequestExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrRequestExecution
			Dim Results As SIS.VR.vrRequestExecution = vrRequestExecutionGetByID(SRNNo)
			Return Results
		End Function
		'Select By ID One Record Filtered Overloaded GetByID
		Public Shared Function UZ_vrRequestExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_TransporterID As String, ByVal Filter_VehicleTypeID As Int32) As SIS.VR.vrRequestExecution
			Return UZ_vrRequestExecutionGetByID(SRNNo)
		End Function
		'Public Shared Shadows Function SendEMail(ByVal oRq As SIS.VR.vrRequestExecution, Optional ByVal CancellationEMail As Boolean = False) As String
		'	Dim mRet As String = ""
		'	Dim First As Boolean = True
		'	Dim Cnt As Integer = 0
		'	Dim mRecipients As New StringBuilder
		'	Dim maySend As Boolean = False
		'	Dim oEmp As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(oRq.ArrangedBy)
		'	Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRq.SRNNo, "")
		'	For Each oVR As SIS.VR.vrVehicleRequest In oVRs
		'		If oVR.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
		'			maySend = True
		'			mRecipients.AppendLine(oVR.FK_VR_VehicleRequest_RequestedBy.EMailID & " [" & oVR.FK_VR_VehicleRequest_RequestedBy.UserFullName & "]")
		'		End If
		'	Next
		'	If oEmp.EMailID <> String.Empty And maySend Then
		'		Try
		'			Dim oClient As SmtpClient = New SmtpClient()

		'			Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
		'			With oMsg
		'				.From = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
		'				For Each oVR As SIS.VR.vrVehicleRequest In oVRs
		'					Dim oAD As MailAddress = Nothing
		'					Try
		'						If oVR.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
		'							oAD = New MailAddress(oVR.FK_VR_VehicleRequest_BuyerInERP.EMailID, oVR.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
		'							If Not .CC.Contains(oAD) Then
		'								.CC.Add(oAD)
		'							End If
		'						End If

		'					Catch ex As Exception

		'					End Try
		'					If oVR.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
		'						oAD = New MailAddress(oVR.FK_VR_VehicleRequest_RequestedBy.EMailID, oVR.FK_VR_VehicleRequest_RequestedBy.UserFullName)
		'						Try
		'							If Not .To.Contains(oAD) Then
		'								.To.Add(oAD)
		'							End If
		'						Catch ex As Exception

		'						End Try
		'					End If
		'					Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(oVR.RequestedBy)
		'					'Get TO Executers
		'					Dim oExec As List(Of SIS.VR.vrUserGroup)
		'					If oVR.OutOfContract Then
		'						oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
		'					Else
		'						oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
		'					End If
		'					For Each _ex As SIS.VR.vrUserGroup In oExec
		'						oAD = New MailAddress(_ex.FK_VR_UserGroup_UserID.EMailID, _ex.FK_VR_UserGroup_UserID.UserFullName)
		'						Try
		'							If Not .CC.Contains(oAD) Then
		'								.CC.Add(oAD)
		'							End If
		'						Catch ex As Exception

		'						End Try
		'					Next
		'				Next
		'				'Transporter EMailIDS
		'				If oRq.FK_VR_RequestExecution_TransporterID.EMailID <> String.Empty Then
		'					Dim aIDs() As String = oRq.FK_VR_RequestExecution_TransporterID.EMailID.Split(",".ToCharArray)
		'					For Each _id As String In aIDs
		'						Dim oAD As MailAddress = New MailAddress(_id)
		'						Try
		'							If Not .To.Contains(oAD) Then
		'								.To.Add(_id)
		'							End If
		'						Catch ex As Exception
		'						End Try
		'					Next
		'				End If
		'				.IsBodyHtml = True
		'				If CancellationEMail Then
		'					.Subject = "MEMO FOR LIFTING THE MATERIAL-CANCELLED, Exe.No: " & oRq.SRNNo
		'				Else
		'					.Subject = "MEMO FOR LIFTING THE MATERIAL, Exe.No: " & oRq.SRNNo
		'				End If
		'				Dim sb As New StringBuilder
		'				With sb
		'					.AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
		'					If CancellationEMail Then
		'						.AppendLine("<tr><td colspan=""2"" style=""color:red"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL-CANCELLED</b></h2></td></tr>")
		'					Else
		'						.AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL</b></h2></td></tr>")
		'					End If
		'					.AppendLine("<tr><td><b>Execution No.</b></td>")
		'					.AppendLine("<td>" & oRq.SRNNo & "</td></tr>")
		'					.AppendLine("<tr><td><b>Project Name &  Code</b></td>")
		'					.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")

		'					.AppendLine("<tr><td><b>Name of Shipper / Supplier with Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
		'					.AppendLine("<td>")
		'					First = True
		'					Cnt = 1
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						If Cnt > 1 Then
		'							.AppendLine("<hr/>")
		'							First = False
		'						End If
		'						.AppendLine(Cnt & ") " & _vr.FK_VR_VehicleRequest_SupplierID.Description & " [" & _vr.SupplierID & "]")
		'						.AppendLine("<br/>" & _vr.SupplierLocation)
		'						Cnt = Cnt + 1
		'					Next
		'					.AppendLine("</td></tr>")


		'					.AppendLine("<tr><td><b>Receiver Name / Site/ CHA / Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
		'					.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description)
		'					.AppendLine("<br/>" & oVRs(0).DeliveryLocation)
		'					.AppendLine("</td></tr>")

		'					.AppendLine("<tr><td><b>Name of the Material / Equipment</b></td>")
		'					.AppendLine("<td>")
		'					Cnt = 1
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						If Cnt > 1 Then
		'							.AppendLine("<hr />")
		'						End If
		'						.AppendLine("<br/>" & Cnt & ") " & _vr.ItemDescription)
		'						Cnt = Cnt + 1
		'					Next
		'					.AppendLine("</td></tr>")

		'					.AppendLine("<tr><td><b>Dimension (L x W x H ) Unit</b></td>")
		'					.AppendLine("<td>")
		'					Cnt = 1
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						If Cnt > 1 Then
		'							.AppendLine("<hr />")
		'						End If
		'						.AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " " & _vr.FK_VR_VehicleRequest_SizeUnit.Description)
		'						Cnt = Cnt + 1
		'					Next
		'					.AppendLine("</td></tr>")

		'					.AppendLine("<tr><td><b>Weight - Unit</b></td>")
		'					.AppendLine("<td>")
		'					Cnt = 1
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						If Cnt > 1 Then
		'							.AppendLine("<hr />")
		'						End If
		'						.AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " " & _vr.FK_VR_VehicleRequest_WeightUnit.Description)
		'						Cnt = Cnt + 1
		'					Next
		'					.AppendLine("</td></tr>")


		'					.AppendLine("<tr><td><b>No. Of Packages</b></td>")
		'					.AppendLine("<td>")
		'					Cnt = 1
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						If Cnt > 1 Then
		'							.AppendLine("<hr />")
		'						End If
		'						.AppendLine("<br/>" & Cnt & ") " & _vr.NoOfPackages)
		'						Cnt = Cnt + 1
		'					Next
		'					.AppendLine("</td></tr>")

		'					.AppendLine("<tr><td><b>Type of Vehicle</b></td>")
		'					.AppendLine("<td>" & oRq.FK_VR_RequestExecution_VehicleTypeID.cmba & "</td></tr>")

		'					.AppendLine("<tr><td><b>Vehicle to be placed on Date</b></td>")
		'					.AppendLine("<td>" & oRq.VehiclePlacedOn & "</td></tr>")

		'					.AppendLine("<tr><td><b>Name of Executor</b></td>")
		'					.AppendLine("<td>" & oRq.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & oRq.ArrangedBy & "]" & "</td></tr>")

		'					.AppendLine("<tr><td><b>Export Invoice No.</b></td>")
		'					.AppendLine("<td>" & IIf(oVRs(0).CustomInvoiceNo = String.Empty, "NA", oVRs(0).CustomInvoiceNo) & "</td></tr>")

		'					.AppendLine("<tr><td><b>Transporter</b></td>")
		'					.AppendLine("<td>" & oRq.FK_VR_RequestExecution_TransporterID.TransporterName & "</td></tr>")

		'					.AppendLine("<tr><td colspan=""2"">")
		'					.AppendLine("<br/><b>IMPORTANT NOTES:-</b>")
		'					.AppendLine("<br/>1) Please Hand Over Consignee Copy of Docket to Shipper/Supplier and take the signature of Shipper/Supplier on the Docket.")
		'					.AppendLine("<br/>2) Shipper Copy and POD Copy of docket must be carrying/accompany with Dispatch Documents & Material.")
		'					.AppendLine("<br/>3) Shipper Copy of docket and Dispatch Documents along with Material to be handed Over to Customer/CHA (Receiver).")
		'					.AppendLine("<br/>4) Take the Signature& Rubber Stamp of Receiver on the POD Copy of Docket at the time of delivery of material.")
		'					.AppendLine("<br/>5) It is <b>MANDATORY</b> to inform us material dimension and weight in case of ODC or Over Weight Consignment.")
		'					.AppendLine("<br/></td></tr>")

		'					.AppendLine("</table>")

		'				End With
		'				Dim Header As String = ""
		'				Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
		'				Header = Header & "<head>"
		'				Header = Header & "<title></title>"
		'				Header = Header & "<style>"
		'				Header = Header & "table{"

		'				Header = Header & "border: solid 1pt black;"
		'				Header = Header & "border-collapse:collapse;"
		'				Header = Header & "font-family: Tahoma;}"

		'				Header = Header & "td{"
		'				Header = Header & "border: solid 1pt black;"
		'				Header = Header & "font-family: Tahoma;"
		'				Header = Header & "font-size: 12px;"
		'				Header = Header & "vertical-align:top;}"

		'				Header = Header & "</style>"
		'				Header = Header & "</head>"
		'				Header = Header & "<body>"
		'				Header = Header & sb.ToString
		'				Header = Header & "</body></html>"
		'				.Body = Header

		'				If Not CancellationEMail Then
		'					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
		'						Dim oAtchs As List(Of SIS.VR.vrRequestAttachments) = SIS.VR.vrRequestAttachments.vrRequestAttachmentsSelectList(0, 99, "", False, "", _vr.RequestNo)
		'						For Each atch As SIS.VR.vrRequestAttachments In oAtchs
		'							If IO.File.Exists(atch.DiskFile) Then
		'								Dim at As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(atch.DiskFile)
		'								at.Name = atch.FileName
		'								.Attachments.Add(at)
		'							End If
		'						Next
		'					Next
		'				End If
		'			End With
		'			oClient.Send(oMsg)
		'		Catch ex As Exception
		'			mRet = ex.Message
		'		End Try
		'	End If
		'	Return mRet
		'End Function
		Public Shared Function UZ_vrLinkedExecution(ByVal SRNNo As Integer) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvr_LG_LinkedExecution"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo", SqlDbType.Int, 10, SRNNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Results = New List(Of SIS.VR.vrRequestExecution)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrRequestExecution(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UZ_vrUnLinkedExecution(ByVal SRNNo As Integer) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spvr_LG_UnLinkedExecution"
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo", SqlDbType.Int, 10, SRNNo)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					Results = New List(Of SIS.VR.vrRequestExecution)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrRequestExecution(Reader))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Shadows Function SendEMail(ByVal oRE As SIS.VR.vrRequestExecution, Optional ByVal CancellationEMail As Boolean = False) As String
			Dim mRet As String = ""
			Dim First As Boolean = True
			Dim Cnt As Integer = 0
			Dim mRecipients As New StringBuilder
			Dim maySend As Boolean = False

			Dim oClient As SmtpClient = New SmtpClient()
			Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
			Dim ad As MailAddress = Nothing
			'From EMail
			If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
				ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
				oMsg.From = ad
				oMsg.CC.Add(ad)
			End If
			'Executers of Linked Executions
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
					ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
			Next
			'Requester, Buyer and Executers of Execution
			Dim ProjectsAdded As Boolean = False
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
			For Each vr As SIS.VR.vrVehicleRequest In oVRs
				If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
					If Not ProjectsAdded Then
						Try
							If vr.FK_VR_VehicleRequest_RequestedBy.EMailID.ToLower.IndexOf("isgec.com") >= 0 Then
								oMsg.CC.Add(New MailAddress("sarvjeet_chowdhry@isgec.com", "Sarvjeet Chowdhry"))
								oMsg.CC.Add(New MailAddress("boilerprojects@isgec.co.in", "Boiler Projects"))
								oMsg.CC.Add(New MailAddress("tmdproject@isgec.com", "TMD Projects-YNR"))
								oMsg.CC.Add(New MailAddress("manoj.raghav@isgec.co.in", "Manoj Raghav"))
							End If
							ProjectsAdded = True
						Catch ex As Exception
						End Try
					End If
					ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
				'Buyers in Request, in old requests buyer may be null
				Try
					If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Catch ex As Exception
				End Try
				'Executers of the Requester's Group
				Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
				Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
				If vr.OutOfContract Then
					oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
				Else
					oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
				End If
				For Each exe As SIS.VR.vrUserGroup In oExec
					If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
						ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Next
			Next
			'Requester, Buyer and Executers of Linked Executions
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
				For Each vr As SIS.VR.vrVehicleRequest In oVRs
					If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
					'Buyers in Request, in old requests buyer may be null
					Try
						If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
							ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Catch ex As Exception
					End Try
					'Executers of the Requester's Group
					Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
					Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
					If vr.OutOfContract Then
						oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
					Else
						oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
					End If
					For Each exe As SIS.VR.vrUserGroup In oExec
						If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
							ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Next
				Next
			Next
			'Transporter EMailIDS
			If oRE.FK_VR_RequestExecution_TransporterID.EMailID <> String.Empty Then
				If oRE.FK_VR_RequestExecution_TransporterID.EMailID <> String.Empty Then
					Dim aIDs() As String = oRE.FK_VR_RequestExecution_TransporterID.EMailID.Split(",".ToCharArray)
					For Each id As String In aIDs
						ad = New MailAddress(id.Trim)
						Try
							If Not oMsg.To.Contains(ad) Then oMsg.To.Add(ad)
						Catch ex As Exception
						End Try
					Next
				End If
			End If
			oMsg.IsBodyHtml = True
			If CancellationEMail Then
				oMsg.Subject = "MEMO FOR LIFTING THE MATERIAL-CANCELLED, Exe.No: " & oRE.SRNNo
			Else
				oMsg.Subject = "MEMO FOR LIFTING THE MATERIAL, Exe.No: " & oRE.SRNNo
			End If

			Dim sb As New StringBuilder
			With sb
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
				.AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
				If CancellationEMail Then
					.AppendLine("<tr><td colspan=""2"" style=""color:red"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL-CANCELLED</b></h2></td></tr>")
				Else
					.AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>MEMO FOR LIFTING THE MATERIAL</b></h2></td></tr>")
				End If
				'Main Execution
				.AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
				.AppendLine("<td>" & oRE.SRNNo & "</td></tr>")
				.AppendLine("<tr><td><b>Project Name &  Code</b></td>")
				.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
				.AppendLine("<tr><td><b>Name of Shipper / Supplier with Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
				.AppendLine("<td>")
				First = True
				Cnt = 1
				For Each _vr As SIS.VR.vrVehicleRequest In oVRs
					If Cnt > 1 Then
						.AppendLine("<hr/>")
						First = False
					End If
					.AppendLine(Cnt & ") " & _vr.FK_VR_VehicleRequest_SupplierID.Description & " [" & _vr.SupplierID & "]")
					.AppendLine("<br/>" & _vr.SupplierLocation)
					Cnt = Cnt + 1
				Next
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>Receiver Name / Site/ CHA / Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
				.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description)
				.AppendLine("<br/>" & oVRs(0).DeliveryLocation)
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>Name of the Material / Equipment</b></td>")
				.AppendLine("<td>")
				Cnt = 1
				For Each _vr As SIS.VR.vrVehicleRequest In oVRs
					If Cnt > 1 Then
						.AppendLine("<hr />")
					End If
					.AppendLine("<br/>" & Cnt & ") " & _vr.ItemDescription)
					Cnt = Cnt + 1
				Next
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>Dimension (L x W x H ) Unit</b></td>")
				.AppendLine("<td>")
				Cnt = 1
				For Each _vr As SIS.VR.vrVehicleRequest In oVRs
					If Cnt > 1 Then
						.AppendLine("<hr />")
					End If
					Try
						.AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " " & _vr.FK_VR_VehicleRequest_SizeUnit.Description)
					Catch ex As Exception
						.AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " ***Unit Not Defined***")
					End Try
					Cnt = Cnt + 1
				Next
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>Weight - Unit</b></td>")
				.AppendLine("<td>")
				Cnt = 1
				For Each _vr As SIS.VR.vrVehicleRequest In oVRs
					If Cnt > 1 Then
						.AppendLine("<hr />")
					End If
					Try
						.AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " " & _vr.FK_VR_VehicleRequest_WeightUnit.Description)
					Catch ex As Exception
						.AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " ***Unit Not Defined***")
					End Try
					Cnt = Cnt + 1
				Next
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>No. Of Packages</b></td>")
				.AppendLine("<td>")
				Cnt = 1
				For Each _vr As SIS.VR.vrVehicleRequest In oVRs
					If Cnt > 1 Then
						.AppendLine("<hr />")
					End If
					.AppendLine("<br/>" & Cnt & ") " & _vr.NoOfPackages)
					Cnt = Cnt + 1
				Next
				.AppendLine("</td></tr>")
				.AppendLine("<tr><td><b>Type of Vehicle</b></td>")
				.AppendLine("<td>" & oRE.FK_VR_RequestExecution_VehicleTypeID.cmba & "</td></tr>")
				.AppendLine("<tr><td><b>Vehicle to be placed on Date</b></td>")
				.AppendLine("<td>" & oRE.VehiclePlacedOn & "</td></tr>")
				.AppendLine("<tr><td><b>Name of Executor</b></td>")
				.AppendLine("<td>" & oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & oRE.ArrangedBy & "]" & "</td></tr>")
				.AppendLine("<tr><td><b>Export Invoice No.</b></td>")
				.AppendLine("<td>" & IIf(oVRs(0).CustomInvoiceNo = String.Empty, "NA", oVRs(0).CustomInvoiceNo) & "</td></tr>")
				.AppendLine("<tr><td><b>Transporter</b></td>")
				.AppendLine("<td>" & oRE.FK_VR_RequestExecution_TransporterID.TransporterName & "</td></tr>")
				'Linked Executions
				For Each le As SIS.VR.vrRequestExecution In oLEs
					If le.SRNNo.ToString = oRE.SRNNo Then Continue For
					oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
					.AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
					.AppendLine("<td>" & le.SRNNo & "</td></tr>")
					.AppendLine("<tr><td><b>Project Name &  Code</b></td>")
					.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
					.AppendLine("<tr><td><b>Name of Shipper / Supplier with Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
					.AppendLine("<td>")
					First = True
					Cnt = 1
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If Cnt > 1 Then
							.AppendLine("<hr/>")
							First = False
						End If
						.AppendLine(Cnt & ") " & _vr.FK_VR_VehicleRequest_SupplierID.Description & " [" & _vr.SupplierID & "]")
						.AppendLine("<br/>" & _vr.SupplierLocation)
						Cnt = Cnt + 1
					Next
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>Receiver Name / Site/ CHA / Address and PIN CODE <br/>Name of the Contact person & Contact Number</b></td>")
					.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description)
					.AppendLine("<br/>" & oVRs(0).DeliveryLocation)
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>Name of the Material / Equipment</b></td>")
					.AppendLine("<td>")
					Cnt = 1
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If Cnt > 1 Then
							.AppendLine("<hr />")
						End If
						.AppendLine("<br/>" & Cnt & ") " & _vr.ItemDescription)
						Cnt = Cnt + 1
					Next
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>Dimension (L x W x H ) Unit</b></td>")
					.AppendLine("<td>")
					Cnt = 1
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If Cnt > 1 Then
							.AppendLine("<hr />")
						End If
						.AppendLine("<br/>" & Cnt & ") " & _vr.Length & " x " & _vr.Width & " x " & _vr.Height & " " & _vr.FK_VR_VehicleRequest_SizeUnit.Description)
						Cnt = Cnt + 1
					Next
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>Weight - Unit</b></td>")
					.AppendLine("<td>")
					Cnt = 1
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If Cnt > 1 Then
							.AppendLine("<hr />")
						End If
						.AppendLine("<br/>" & Cnt & ") " & _vr.MaterialWeight & " " & _vr.FK_VR_VehicleRequest_WeightUnit.Description)
						Cnt = Cnt + 1
					Next
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>No. Of Packages</b></td>")
					.AppendLine("<td>")
					Cnt = 1
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If Cnt > 1 Then
							.AppendLine("<hr />")
						End If
						.AppendLine("<br/>" & Cnt & ") " & _vr.NoOfPackages)
						Cnt = Cnt + 1
					Next
					.AppendLine("</td></tr>")
					.AppendLine("<tr><td><b>Type of Vehicle</b></td>")
					.AppendLine("<td>" & le.FK_VR_RequestExecution_VehicleTypeID.cmba & "</td></tr>")
					.AppendLine("<tr><td><b>Vehicle to be placed on Date</b></td>")
					.AppendLine("<td>" & le.VehiclePlacedOn & "</td></tr>")
					.AppendLine("<tr><td><b>Name of Executor</b></td>")
					.AppendLine("<td>" & le.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & le.ArrangedBy & "]" & "</td></tr>")
					.AppendLine("<tr><td><b>Export Invoice No.</b></td>")
					.AppendLine("<td>" & IIf(oVRs(0).CustomInvoiceNo = String.Empty, "NA", oVRs(0).CustomInvoiceNo) & "</td></tr>")
					.AppendLine("<tr><td><b>Transporter</b></td>")
					.AppendLine("<td>" & le.FK_VR_RequestExecution_TransporterID.TransporterName & "</td></tr>")
					.AppendLine("<tr><td><b>Tarpaulin</b></td>")
					.AppendLine("<td>")
					Dim TarpaulinRequired As String = "NO"
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						If _vr.TarpaulineRequired Then
							TarpaulinRequired = "YES"
						End If
					Next
					.AppendLine(TarpaulinRequired)
					.AppendLine("</td></tr>")
				Next 'le
				'End of Linked Executions
				.AppendLine("<tr><td colspan=""2"">")
				.AppendLine("<br/><b>IMPORTANT NOTES:-</b>")
				.AppendLine("<br/>1) Please Hand Over Consignee Copy of Docket to Shipper/Supplier and take the signature of Shipper/Supplier on the Docket.")
				.AppendLine("<br/>2) Shipper Copy and POD Copy of docket must be carrying/accompany with Dispatch Documents & Material.")
				.AppendLine("<br/>3) Shipper Copy of docket and Dispatch Documents along with Material to be handed Over to Customer/CHA (Receiver).")
				.AppendLine("<br/>4) Take the Signature& Rubber Stamp of Receiver on the POD Copy of Docket at the time of delivery of material.")
				.AppendLine("<br/>5) It is <b>MANDATORY</b> to inform us material dimension and weight in case of ODC or Over Weight Consignment.")
				.AppendLine("<br/></td></tr>")
				.AppendLine("</table>")

			End With
			Try
				Dim Header As String = ""
				Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
				Header = Header & "<head>"
				Header = Header & "<title></title>"
				Header = Header & "<style>"
				Header = Header & "table{"

				Header = Header & "border: solid 1pt black;"
				Header = Header & "border-collapse:collapse;"
				Header = Header & "font-family: Tahoma;}"

				Header = Header & "td{"
				Header = Header & "border: solid 1pt black;"
				Header = Header & "font-family: Tahoma;"
				Header = Header & "font-size: 12px;"
				Header = Header & "vertical-align:top;}"

				Header = Header & "</style>"
				Header = Header & "</head>"
				Header = Header & "<body>"
				Header = Header & sb.ToString
				Header = Header & "</body></html>"
				oMsg.Body = Header

				If Not CancellationEMail Then
					'Attachments of Main Execution Request
					oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
					For Each _vr As SIS.VR.vrVehicleRequest In oVRs
						Dim oAtchs As List(Of SIS.VR.vrRequestAttachments) = SIS.VR.vrRequestAttachments.vrRequestAttachmentsSelectList(0, 99, "", False, "", _vr.RequestNo)
						For Each atch As SIS.VR.vrRequestAttachments In oAtchs
							If IO.File.Exists(atch.DiskFile) Then
								Dim at As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(atch.DiskFile)
								at.Name = atch.FileName
								oMsg.Attachments.Add(at)
							End If
						Next
					Next
					'Attachments of Linked Executions
					For Each le As SIS.VR.vrRequestExecution In oLEs
						If le.SRNNo.ToString = oRE.SRNNo Then Continue For
						oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
						For Each _vr As SIS.VR.vrVehicleRequest In oVRs
							Dim oAtchs As List(Of SIS.VR.vrRequestAttachments) = SIS.VR.vrRequestAttachments.vrRequestAttachmentsSelectList(0, 99, "", False, "", _vr.RequestNo)
							For Each atch As SIS.VR.vrRequestAttachments In oAtchs
								If IO.File.Exists(atch.DiskFile) Then
									Dim at As System.Net.Mail.Attachment = New System.Net.Mail.Attachment(atch.DiskFile)
									at.Name = atch.FileName
									oMsg.Attachments.Add(at)
								End If
							Next
						Next
					Next
				End If
				oClient.Send(oMsg)
			Catch ex As Exception
				mRet = ex.Message
			End Try
			Return mRet
		End Function
		Public Shared Function UZ_vrRequestExecutionLinkedSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LinkID As Int32) As List(Of SIS.VR.vrRequestExecution)
			Dim Results As List(Of SIS.VR.vrRequestExecution) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_RequestExecutionLinkedSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_RequestExecutionLinkedSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LinkID", SqlDbType.Int, 10, IIf(LinkID = Nothing, 0, LinkID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
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
		Public Shared Function UZ_vrRequestExecutionLinkedSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal LinkID As Int32) As Integer
			Return _RecordCount
		End Function
		Public Shared Function ValidateSanction(ByVal SRNNO As Integer, ByRef strHTML As String) As SIS.VR.vrRequestExecution
			Dim mRet As Boolean = False
			Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNO)
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(SRNNO, "")
			If oVRs.Count > 0 Then  Else Return Nothing
			Dim ProjectID As String = oVRs(0).ProjectID
			Dim Company As String = GetProjectFinanceCompany(ProjectID)
			If ProjectID.StartsWith("BS") Then
				Company = "700"
			End If
			Dim SanctionAmount As Decimal = GetSanctionFromERPLN(ProjectID, Company)
			Dim ConsumedInMaterial As Decimal = GetConsumedInMaterial(ProjectID, Company)
			Dim StartDate As String = GetVRSystemStartDate(ProjectID)
			Dim ConsumedBeforeVRSystem As Decimal = GetConsumedBeforeVRSystem(ProjectID, StartDate)

			Dim AvailableSanction As Decimal = SanctionAmount	'- ConsumedInMaterial - ConsumedBeforeVRSystem
			Dim ConsumedInVehicleRequests As Decimal = 0
			'FOR CONSUMED IN VRs
			'1. Select Executions
			Dim oREs As List(Of vrExecutions) = GetExecutions(ProjectID)
			'2. Select IRs
			Dim oIRs As List(Of vrIRs) = GetIRs(ProjectID)
			'3. Remove Execution, If Linked IR is Picked (may be Linked to Multiple Executions)
			For Each tmp As vrIRs In oIRs
				For I As Integer = oREs.Count - 1 To 0 Step -1
					Dim tm As vrExecutions = oREs(I)
					If tmp.SRNNo = tm.SRNNo Then
						oREs.RemoveAt(I)
					End If
				Next
			Next
			'3. As oIRs contains dulicate IR, because One stransporter bill contains multiple execution 			
			oIRs = GetDistinctIRs(ProjectID)

			'4. Select PTR
			For Each tmp As vrIRs In oIRs
				'5. Update IR Bill Amount with PTR Amount, If Linked PTR is picked (1 IR = 1 PTR NO Multiple Linking)
				tmp.BillAmount = GetPTRFromERPLN(tmp.IRNo, tmp.BillAmount, Company)
			Next
			'Calculate consumed
			For Each tmp As vrIRs In oIRs
				ConsumedInVehicleRequests += tmp.BillAmount
			Next
			For Each tmp As vrExecutions In oREs
				ConsumedInVehicleRequests += tmp.Amount
			Next

			Dim TotalConsumed As Decimal = ConsumedInVehicleRequests + ConsumedInMaterial + ConsumedBeforeVRSystem
			'Update Vehicle Execution record
			With oRE
				.POValue = AvailableSanction
				.EstimatedPOBalance = TotalConsumed
			End With
			strHTML = "<table>"
			strHTML &= "<tr><td>" & ProjectID & "</td><td>" & SanctionAmount & "</td></tr>"
			strHTML &= "<tr><td> P.O. </td><td>" & ConsumedInMaterial & "</td></tr>"
			strHTML &= "<tr><td> Vehicle Requests </td><td>" & ConsumedInVehicleRequests & "</td></tr>"
			strHTML &= "<tr><td> Total Consumed </td><td>" & TotalConsumed & "</td></tr>"
			strHTML &= "<tr><td> Balance Available </td><td>" & AvailableSanction - TotalConsumed & "</td></tr>"
			strHTML &= "</table>"
			Return oRE
		End Function
		Public Shared Function GetPTRFromERPLN(ByVal IRNo As Integer, ByVal BillAmount As Decimal, ByVal Company As String) As Decimal
			Dim mRet As Decimal = BillAmount
			Dim MainCompany As String = "200"
			If Company = "700" Then
				MainCompany = "700"
			End If

			Dim Sql As String = ""
			Sql = Sql & "select "
			Sql = Sql & "isnull(pb.t_amth_1,0) as PTRAmount "
			Sql = Sql & "from ttfacp100" & MainCompany & " as ir "
			Sql = Sql & "inner join ttfacp200" & Company & " as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)   "
			Sql = Sql & "where ir.t_ctyp = 'PTR' and pb.t_tpay=1 and ir.t_ninv = " & IRNo
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Dim tmp As Decimal = Cmd.ExecuteScalar
					If tmp > 0 Then
						mRet = tmp
					End If
				End Using
			End Using
			Return mRet
		End Function

		Public Shared Function GetDistinctIRs(ByVal ProjectID As String) As List(Of vrIRs)
			Dim mRet As Decimal = 0
			Dim Sql As String = "select distinct IRNo, BillAmount from (select "
			Sql &= "re.SRNNo as SRNNo,"
			Sql &= "ir.IRNo as IRNo,"
			Sql &= "ir.BillAmount as BillAmount "
			Sql &= "from vr_TransporterBill as ir "
			Sql &= "  inner join vr_RequestExecution as re on re.IRNo=ir.IRNo "
			Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
			Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "') as tmp"
			Dim Results As List(Of vrIRs) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Results = New List(Of vrIRs)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New vrIRs(0, Reader("IRNo"), Reader("BillAmount")))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetProjectFinanceCompany(ByVal ProjectID As String) As String
			Dim mRet As Decimal = 0
			Dim Sql As String = "select t_ncmp "
			Sql &= "from ttppdm600200 "
			Sql &= "where t_cprj='" & ProjectID.ToUpper & "'"
			'Sql = "select isnull(erpcompany,'200') from idm_projects where projectid='" & ProjectID & "'"
			Dim Results As String = ""
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Results = Cmd.ExecuteScalar
				End Using
			End Using
			Return Results
		End Function

		Public Shared Function GetIRs(ByVal ProjectID As String) As List(Of vrIRs)
			Dim mRet As Decimal = 0
			Dim Sql As String = "select "
			Sql &= "re.SRNNo as SRNNo,"
			Sql &= "ir.IRNo as IRNo,"
			Sql &= "ir.BillAmount as BillAmount "
			Sql &= "from vr_TransporterBill as ir "
			Sql &= "  inner join vr_RequestExecution as re on re.IRNo=ir.IRNo "
			Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
			Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "'"
			Dim Results As List(Of vrIRs) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Results = New List(Of vrIRs)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New vrIRs(Reader("SRNNo"), Reader("IRNo"), Reader("BillAmount")))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function GetExecutions(ByVal ProjectID As String) As List(Of vrExecutions)
			Dim mRet As Decimal = 0
			Dim Sql As String = "select "
			Sql &= "re.SRNNo as SRNNo,"
			Sql &= "re.EstimatedAmount as EstimatedAmount "
			Sql &= "from vr_RequestExecution as re "
			Sql &= "  inner join vr_VehicleRequest as vr on vr.SRNNo=re.SRNNo "
			Sql &= "where UPPER(vr.ProjectID)='" & ProjectID.ToUpper & "'"
			Dim Results As List(Of vrExecutions) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Results = New List(Of vrExecutions)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New vrExecutions(Reader("SRNNo"), Reader("EstimatedAmount")))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Class vrIRs
			Public SRNNo As Integer = 0
			Public IRNo As Integer = 0
			Public BillAmount As Decimal = 0
			Sub New(ByVal sr As Integer, ByVal ir As Integer, ByVal amt As Decimal)
				SRNNo = sr
				IRNo = ir
				BillAmount = amt
			End Sub
			Sub New()
				'dummy
			End Sub
		End Class

		Public Class vrExecutions
			Public SRNNo As Integer = 0
			Public Amount As Decimal = 0
			Sub New(ByVal sr As Integer, ByVal amt As Decimal)
				SRNNo = sr
				Amount = amt
			End Sub
			Sub New()
				'dummy
			End Sub
		End Class
		Public Shared Function GetConsumedBeforeVRSystem(ByVal ProjectID As String, ByVal StartDate As String) As Decimal
			Dim mRet As Decimal = 0
			'Dim Sql As String = ""
			'Sql &= "select sum(aa.t_oamt) as Amount from ttdpur401200 as aa  "
			'Sql &= "inner join ttdpur400200 as bb on aa.t_orno=bb.t_orno "
			'Sql &= "where aa.t_cspa='99050500' "
			'Sql &= "and   bb.t_cotp='P01' "
			'Sql &= "and   aa.t_cprj = '" & ProjectID.ToUpper & "'"
			'Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
			'	Using Cmd As SqlCommand = Con.CreateCommand()
			'		Cmd.CommandType = CommandType.Text
			'		Cmd.CommandText = Sql
			'		Con.Open()
			'		Dim tmp As Decimal = Cmd.ExecuteScalar
			'		If Not Convert.IsDBNull(tmp) Then
			'			mRet = tmp
			'		End If
			'	End Using
			'End Using
			Return mRet
		End Function
		Public Shared Function GetVRSystemStartDate(ByVal ProjectID As String) As String
			Dim mRet As String = ""
			Dim Sql As String = ""
			Sql &= "select convert(nvarchar(10),min(VehicleRequiredOn),103) as tmpDT "
			Sql &= "from VR_VehicleRequest "
			Sql &= "where (RequestStatus >= 6 And RequestStatus <= 25) "
			Sql &= "and VehicleRequiredOn is not null "
			Sql &= "and UPPER(projectid)='" & ProjectID.ToUpper & "'"
			Dim Results As SIS.VR.vrVehicleRequest = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Try
						mRet = Cmd.ExecuteScalar
					Catch ex As Exception
						Dim aa As String = ex.Message
					End Try
				End Using
			End Using
			Return mRet
		End Function
		Public Shared Function GetConsumedInMaterial(ByVal ProjectID As String, ByVal Company As String) As Decimal
			Dim mRet As Decimal = 0
			Dim Sql As String = ""
			Sql &= "select ISNULL(sum(aa.t_oamt),0) as Amount from ttdpur401" & Company.Trim & " as aa  "
			Sql &= "inner join ttdpur400" & Company.Trim & " as bb on aa.t_orno=bb.t_orno "
			Sql &= "where aa.t_cspa='99050500' "
			Sql &= "and   bb.t_cotp='P01' "
			Sql &= "and   aa.t_oltp in (2,4) "
			Sql &= "and   aa.t_cprj = '" & ProjectID.ToUpper & "'"
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Dim tmp As Decimal = Cmd.ExecuteScalar
					If Not Convert.IsDBNull(tmp) Then
						mRet = tmp
					End If
				End Using
			End Using
			Return mRet
		End Function

		Public Shared Function GetSanctionFromERPLN(ByVal ProjectID As String, ByVal Company As String) As Decimal
			Dim mRet As Decimal = 0
			Dim Sql As String = ""
			'Sql = Sql & "select ir.t_ninv as IRNo,"
			'Sql = Sql & "       ir.t_ctyp as PTR,"
			'Sql = Sql & "       ir.t_cinv as PTRNo,"
			'Sql = Sql & "       pb.t_refr as PaymentReference,"
			'Sql = Sql & "       pb.t_pdat as PTRDate,"
			'Sql = Sql & "       pb.t_amnt as PTRAmount,"
			'Sql = Sql & "       pb.t_btno as Batch,"
			'Sql = Sql & "       cq.t_cheq as ChequeNo,"
			'Sql = Sql & "       cq.t_dout as ChequeDate,"
			'Sql = Sql & "       cq.t_amnt as ChequeAmount,"
			'Sql = Sql & "       cq.t_chnm as PaymentDescription,"
			'Sql = Sql & "       cq.t_drec as ReconciledOn,"
			'Sql = Sql & "       (case when cq.t_drec ='' then 0 else 1 end) as Freezed, "
			'Sql = Sql & "       bt.t_user as ProcessedBy,"
			'Sql = Sql & "       bt.t_date as ProcessedOn "
			'Sql = Sql & "from ttfacp100200 as ir "
			'Sql = Sql & "     inner join ttfcmg101200 as pb on (ir.t_ctyp = pb.t_ttyp and ir.t_cinv = pb.t_ninv)  "
			'Sql = Sql & "     inner join ttfcmg100200 as cq on pb.t_btno = cq.t_pbtn "
			'Sql = Sql & "     inner join ttfcmg109200 as bt on pb.t_btno = bt.t_btno "
			'Sql = Sql & "where ir.t_ctyp = 'PTR' and ir.t_ninv = " & IRNo
			If Company <> "700" Then Company = "200"

			Sql &= "select t_totl from ttpisg012" & Company.Trim & " where t_elem='99050500' and t_cprj='" & ProjectID.ToUpper & "'"
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Dim tmp As Decimal = Cmd.ExecuteScalar
					If Not Convert.IsDBNull(tmp) Then
						mRet = tmp
					End If
				End Using
			End Using
			Return mRet
		End Function
		Public Shared Shadows Function SendEMailSanctionApproval(ByVal oRE As SIS.VR.vrRequestExecution) As String
			Dim mRet As String = ""
			Dim First As Boolean = True
			Dim Cnt As Integer = 0
			Dim mRecipients As New StringBuilder
			Dim maySend As Boolean = False

			Dim oClient As SmtpClient = New SmtpClient()
			Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
			Dim ad As MailAddress = Nothing
			'From EMail
			If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
				ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
				oMsg.From = ad
				oMsg.CC.Add(ad)
			End If
			'Executers of Linked Executions
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
					ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
			Next
			'Requester, Buyer and Executers of Execution
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
			For Each vr As SIS.VR.vrVehicleRequest In oVRs
				If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
					ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
				Dim GroupID As Integer = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)(0).GroupID
				Select Case GroupID
					Case 1 ' boiler
						oMsg.CC.Add("boilerprojects@isgec.co.in")
					Case 2 'smd
						oMsg.CC.Add("smdprojects@isgec.co.in")
					Case 4 'EPC
						oMsg.CC.Add("epcprojects@isgec.co.in")
					Case 5 'APCE
						oMsg.CC.Add("apceprojects@isgec.co.in")
				End Select
				'Buyers in Request, in old requests buyer may be null
				Try
					If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Catch ex As Exception
				End Try
				'Executers of the Requester's Group
				Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
				Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
				If vr.OutOfContract Then
					oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
				Else
					oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
				End If
				For Each exe As SIS.VR.vrUserGroup In oExec
					If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
						ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Next
			Next
			'Requester, Buyer and Executers of Linked Executions
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
				For Each vr As SIS.VR.vrVehicleRequest In oVRs
					If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
					'Buyers in Request, in old requests buyer may be null
					Try
						If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
							ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Catch ex As Exception
					End Try
					'Executers of the Requester's Group
					Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
					Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
					If vr.OutOfContract Then
						oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
					Else
						oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
					End If
					For Each exe As SIS.VR.vrUserGroup In oExec
						If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
							ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Next
				Next
			Next
			oMsg.IsBodyHtml = True
			oMsg.Subject = "Sanction Exceeded, Approval Required, Project/Exe.No: " & oRE.Project.ProjectID & "/" & oRE.SRNNo

			Dim sb As New StringBuilder
			With sb
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
				.AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
				.AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>SANCTION EXCEEDED, APPROVAL REQUIRED</b></h2></td></tr>")
				'Main Execution
				.AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
				.AppendLine("<td>" & oRE.SRNNo & "</td></tr>")
				.AppendLine("<tr><td><b>Project Name &  Code</b></td>")
				.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
				.AppendLine("<tr><td><b>Sanction Amount</b></td>")
				.AppendLine("<td>" & (oRE.POValue).ToString("n") & "</td></tr>")
				'Consumed Amount should be picked from Linked Executions, where it is exceeded
				.AppendLine("<tr><td><b>Consumed Sanction</b></td>")
				.AppendLine("<td>" & (oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
				.AppendLine("<tr><td><b>Balance Sanction</b></td>")
				.AppendLine("<td>" & (oRE.POValue - oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
				'End of Linked Executions
				.AppendLine("<tr><td colspan=""2"">")
				.AppendLine("<br/><b>IMPORTANT NOTES:-</b>")
				.AppendLine("<br/>1) Please get it approved from Sanctioning Authority.")
				.AppendLine("<br/>2) After sanction approval, <b>CONFIRM</b> it again in Vehicle management system. To send E-Mail to transporter.")
				.AppendLine("<br/></td></tr>")
				.AppendLine("</table>")

			End With
			Try
				Dim Header As String = ""
				Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
				Header = Header & "<head>"
				Header = Header & "<title></title>"
				Header = Header & "<style>"
				Header = Header & "table{"

				Header = Header & "border: solid 1pt black;"
				Header = Header & "border-collapse:collapse;"
				Header = Header & "font-family: Tahoma;}"

				Header = Header & "td{"
				Header = Header & "border: solid 1pt black;"
				Header = Header & "font-family: Tahoma;"
				Header = Header & "font-size: 12px;"
				Header = Header & "vertical-align:top;}"

				Header = Header & "</style>"
				Header = Header & "</head>"
				Header = Header & "<body>"
				Header = Header & sb.ToString
				Header = Header & "</body></html>"
				oMsg.Body = Header

				oClient.Send(oMsg)
			Catch ex As Exception
				mRet = ex.Message
			End Try
			Return mRet
		End Function

		Public Shared Shadows Function SendEMailSanctionConsumption(ByVal oRE As SIS.VR.vrRequestExecution, ByVal ConsumedPercent As Decimal) As String
			Dim mRet As String = ""
			Dim First As Boolean = True
			Dim Cnt As Integer = 0
			Dim mRecipients As New StringBuilder
			Dim maySend As Boolean = False

			Dim oClient As SmtpClient = New SmtpClient()
			Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
			Dim ad As MailAddress = Nothing
			'From EMail
			If oRE.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
				ad = New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName)
				oMsg.From = ad
				oMsg.CC.Add(ad)
			End If
			'Executers of Linked Executions
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				If le.FK_VR_RequestExecution_ArrangedBy.EMailID <> String.Empty Then
					ad = New MailAddress(le.FK_VR_RequestExecution_ArrangedBy.EMailID, le.FK_VR_RequestExecution_ArrangedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
			Next
			'Requester, Buyer and Executers of Execution
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
			For Each vr As SIS.VR.vrVehicleRequest In oVRs
				If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
					ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
					If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
				End If
				'Contracts of Requester's division
				Dim GroupID As Integer = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)(0).GroupID
				Select Case GroupID
					Case 1 ' boiler
						oMsg.CC.Add("boilerprojects@isgec.co.in")
					Case 2 'smd
						oMsg.CC.Add("smdprojects@isgec.co.in")
					Case 4 'EPC
						oMsg.CC.Add("epcprojects@isgec.co.in")
					Case 5 'APCE
						oMsg.CC.Add("apceprojects@isgec.co.in")
				End Select
				'Buyers in Request, in old requests buyer may be null
				Try
					If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Catch ex As Exception
				End Try
				'Executers of the Requester's Group
				Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
				Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
				If vr.OutOfContract Then
					oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
				Else
					oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
				End If
				For Each exe As SIS.VR.vrUserGroup In oExec
					If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
						ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
				Next
			Next
			'Requester, Buyer and Executers of Linked Executions
			For Each le As SIS.VR.vrRequestExecution In oLEs
				If le.SRNNo.ToString = oRE.SRNNo Then Continue For
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(le.SRNNo, "")
				For Each vr As SIS.VR.vrVehicleRequest In oVRs
					If vr.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
						ad = New MailAddress(vr.FK_VR_VehicleRequest_RequestedBy.EMailID, vr.FK_VR_VehicleRequest_RequestedBy.UserFullName)
						If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
					End If
					'Buyers in Request, in old requests buyer may be null
					Try
						If vr.FK_VR_VehicleRequest_BuyerInERP.EMailID <> String.Empty Then
							ad = New MailAddress(vr.FK_VR_VehicleRequest_BuyerInERP.EMailID, vr.FK_VR_VehicleRequest_BuyerInERP.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Catch ex As Exception
					End Try
					'Executers of the Requester's Group
					Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(vr.RequestedBy)
					Dim oExec As List(Of SIS.VR.vrUserGroup) = Nothing
					If vr.OutOfContract Then
						oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
					Else
						oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
					End If
					For Each exe As SIS.VR.vrUserGroup In oExec
						If exe.FK_VR_UserGroup_UserID.EMailID <> String.Empty Then
							ad = New MailAddress(exe.FK_VR_UserGroup_UserID.EMailID, exe.FK_VR_UserGroup_UserID.UserFullName)
							If Not oMsg.CC.Contains(ad) Then oMsg.CC.Add(ad)
						End If
					Next
				Next
			Next
			'E-Mail ID from Sanction Alert Configuration
			Dim oSPC As SIS.VR.vrSanctionAlert = SIS.VR.vrSanctionAlert.vrSanctionAlertGetByID(oRE.Project.ProjectID)
			If oSPC IsNot Nothing Then
				If oSPC.EMailIDs <> String.Empty Then
					Dim aIDs() As String = oSPC.EMailIDs.Split(",".ToCharArray)
					For Each id As String In aIDs
						ad = New MailAddress(id)
						Try
							If Not oMsg.To.Contains(ad) Then oMsg.To.Add(ad)
						Catch ex As Exception
						End Try
					Next
				End If
			End If
			oMsg.IsBodyHtml = True
			oMsg.Subject = "Sanction " & ConsumedPercent.ToString("n") & " % Consumed in " & oRE.Project.ProjectID

			Dim sb As New StringBuilder
			With sb
				oVRs = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
				.AppendLine("<table style=""width:900px"" border=""1"" cellspacing=""1"" cellpadding=""1"">")
				.AppendLine("<tr><td colspan=""2"" align=""center""><h3><b>" & "SANCTION " & ConsumedPercent.ToString("n") & " % CONSUMED</b></h2></td></tr>")
				'Main Execution
				.AppendLine("<tr><td bgcolor=""lightgray""><b>Execution No.</b></td>")
				.AppendLine("<td>" & oRE.SRNNo & "</td></tr>")
				.AppendLine("<tr><td><b>Project Name &  Code</b></td>")
				.AppendLine("<td>" & oVRs(0).FK_VR_VehicleRequest_ProjectID.Description & " [" & oVRs(0).ProjectID & "]" & "</td></tr>")
				.AppendLine("<tr><td><b>Sanction Amount</b></td>")
				.AppendLine("<td>" & (oRE.POValue).ToString("n") & "</td></tr>")
				'Consumed Amount should be picked from Linked Executions, where it is exceeded
				.AppendLine("<tr><td><b>Consumed Sanction</b></td>")
				.AppendLine("<td>" & (oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
				.AppendLine("<tr><td><b>Balance Sanction</b></td>")
				.AppendLine("<td>" & (oRE.POValue - oRE.EstimatedPOBalance).ToString("n") & "</td></tr>")
				'End of Linked Executions
				.AppendLine("</table>")

			End With
			Try
				Dim Header As String = ""
				Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
				Header = Header & "<head>"
				Header = Header & "<title></title>"
				Header = Header & "<style>"
				Header = Header & "table{"

				Header = Header & "border: solid 1pt black;"
				Header = Header & "border-collapse:collapse;"
				Header = Header & "font-family: Tahoma;}"

				Header = Header & "td{"
				Header = Header & "border: solid 1pt black;"
				Header = Header & "font-family: Tahoma;"
				Header = Header & "font-size: 12px;"
				Header = Header & "vertical-align:top;}"

				Header = Header & "</style>"
				Header = Header & "</head>"
				Header = Header & "<body>"
				Header = Header & sb.ToString
				Header = Header & "</body></html>"
				oMsg.Body = Header

				oClient.Send(oMsg)
			Catch ex As Exception
				mRet = ex.Message
			End Try
			Return mRet
		End Function

	End Class
End Namespace
