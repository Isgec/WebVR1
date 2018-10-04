Imports Microsoft.VisualBasic

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
End Enum
Public Enum BillStatus
	Free = 1
	ExecutionLinked = 2
	ForwardedToCentralAccount = 3
	ReturnedByCentralAccount = 4
	AcceptedByCentralAccount = 5
	PaidByCentralAccount = 6
End Enum

