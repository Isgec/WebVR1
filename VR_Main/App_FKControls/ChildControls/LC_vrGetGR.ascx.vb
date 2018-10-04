Namespace SIS.VR
  Partial Class LC_vrGetGR
    Inherits System.Web.UI.UserControl
    Public Shared Function GetGRDetails(ByVal SRNNo As Integer) As String
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim mStr As String = ""
      With oRE
        mStr = .SRNNo
        mStr = mStr & "|" & .ExecutionDescription
        mStr = mStr & "|" & .VehicleNo
        mStr = mStr & "|" & .GRNo
        mStr = mStr & "|" & .GRDate
				mStr = mStr & "|" & .LoadedAtSupplier
        mStr = mStr & "|" & .LoadedOn
        mStr = mStr & "|" & .ReachedAtSupplierOn
        mStr = mStr & "|" & .SizeUnit
        mStr = mStr & "|" & .Height
        mStr = mStr & "|" & .Width
        mStr = mStr & "|" & .Length
        mStr = mStr & "|" & .MaterialWeight
        mStr = mStr & "|" & .WeightUnit
        mStr = mStr & "|" & .NoOfPackages
        mStr = mStr & "|" & .OverDimentionConsignement
        mStr = mStr & "|" & .GRRemarks

				mStr = mStr & "|" & .VehicleNotPlaced
				mStr = mStr & "|" & .DelayedPlacement
				mStr = mStr & "|" & .DebitToTransporter
				mStr = mStr & "|" & .EmptyReturn
				mStr = mStr & "|" & .DetentionAtSupplier
				mStr = mStr & "|" & .PayableToTransporter
				mStr = mStr & "|" & .BorneByISGEC
				mStr = mStr & "|" & .BorneBySupplier
				mStr = mStr & "|" & .EmptyReturnRemarks
				mStr = mStr & "|" & .ODCReasonID
				If oRE.Linked Then
					mStr = mStr & "|" & "true"
					If oRE.SRNNo.ToString = oRE.LinkID Then
						mStr = mStr & "|" & "true"
					Else
						mStr = mStr & "|" & "false"
					End If
				Else
					mStr = mStr & "|" & "false"
					mStr = mStr & "|" & "false"
				End If
			End With
      Return mStr
    End Function
    Public Shared Function SaveGR(ByVal Context As String) As String
      Dim aVal() As String = Context.Split("|".ToCharArray)
      Dim SRNNo As String = aVal(0)
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      With oRE
        .VehicleNo = aVal(1)
        .GRNo = aVal(2)
        .GRDate = aVal(3)
				.LoadedOn = aVal(4)
				.ReachedAtSupplierOn = aVal(5)
				.SizeUnit = aVal(6)
				.Height = aVal(7)
				.Width = aVal(8)
				.Length = aVal(9)
				.MaterialWeight = aVal(10)
				.WeightUnit = aVal(11)
				.NoOfPackages = aVal(12)
				.OverDimentionConsignement = aVal(13)
				.GRRemarks = aVal(14)
				.VehicleNotPlaced = aVal(15)
				.DelayedPlacement = aVal(16)
				.DebitToTransporter = aVal(17)
				.EmptyReturn = aVal(18)
				.DetentionAtSupplier = aVal(19)
				.PayableToTransporter = aVal(20)
				.BorneByISGEC = aVal(21)
				.BorneBySupplier = aVal(22)
				.EmptyReturnRemarks = aVal(23)
				.ODCReasonID = aVal(24)
				.RequestStatusID = RequestStates.GRLinked
			End With
			oRE = SIS.VR.vrRequestExecution.UpdateData(oRE)
			'If Linked  and Main then update Vehicle No in all Linked REs
			'Not Main Update Current ODC Info in all Linked Executions
			If oRE.Linked Then
				Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.LinkID, "")
				For Each le As SIS.VR.vrRequestExecution In oLEs
					If oRE.SRNNo.ToString = oRE.LinkID Then
						le.VehicleNo = oRE.VehicleNo
					End If
					le.OverDimentionConsignement = oRE.OverDimentionConsignement
					le.ODCReasonID = oRE.ODCReasonID
					le.SizeUnit = oRE.SizeUnit
					le.Height = oRE.Height
					le.Width = oRE.Width
					le.Length = oRE.Length
					le.WeightUnit = oRE.WeightUnit
					le.MaterialWeight = oRE.MaterialWeight
					le.NoOfPackages = oRE.NoOfPackages
					SIS.VR.vrRequestExecution.UpdateData(le)
				Next
			End If
      Return Context
    End Function
    Public WriteOnly Property Hide() As String
      Set(ByVal value As String)
        pnlsrem.Style("display") = "none"
      End Set
    End Property
  End Class
End Namespace
