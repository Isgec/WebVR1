﻿Imports Microsoft.VisualBasic
Public Enum enumSPExecutionStatus
  Free = 1
  UnderSPUpdation = 2
  SPUpdated = 3
End Enum
Public Enum enumSPStatus
  Free = 1
  UnderSPRequestCreation = 2
  SPRequestCreated = 3
  UnderSPExecutionCreation = 4
  SPExecutionCreated = 5
End Enum
Public Enum enumSPEdiStatus
  Free = 1
  SPError = 2
  SPDone = 3
  'Download Execution Status
  DEError = 4
  DEDone = 5
End Enum

Public Enum RequestStates
	Cancelled = 1
	Returned = 2
	Free = 3
	UnderExecution = 4
	RequestLinked = 5
	VehicleArranged = 6
	GRLinked = 7
	ODCUnderApproval = 8
	ODCRejected = 9
	ODCApproved = 10
	UnderSelfApproval = 11
	SelfRejected = 12
	SelfApproved = 13
	VehicleNotPlacedUnderApproval = 14
	VehicleNotPlacedRejected = 15
	VehicleNotPlacedApproved = 16
	EmptyReturnRUnderApproval = 17
	EmptyReturnRejected = 18
	EmptyReturnApproved = 19
	DelayedPlacementUnderApproval = 20
	DelayedPlacementRejected = 21
	DelayedPlacementApproved = 22
	DetentionUnderApproval = 23
	DetentionRejected = 24
	DetentionApproved = 25
  RequestBlocked = 26
  SanctionApprovalRejected = 27
  UnderSanctionApproval = 28
  SanctionApproved = 29
  VehiclePlaced = 30
End Enum
Public Enum BillStatus
	Free = 1
	ExecutionLinked = 2
	ForwardedToCentralAccount = 3
	ReturnedByCentralAccount = 4
	AcceptedByCentralAccount = 5
	PaidByCentralAccount = 6
End Enum
Public Enum enumMRNStatus
  Free = 1
  SubmittedToHO = 2
End Enum
