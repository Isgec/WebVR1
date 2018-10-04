Namespace SIS.VR
  Partial Class LC_vrTransShip
    Inherits System.Web.UI.UserControl
    Public Shared Function GetTransShip(ByVal SRNNo As Integer) As String
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim mStr As String = ""
      With oRE
        mStr = .SRNNo
        mStr = mStr & "|" & .ExecutionDescription
        mStr = mStr & "|" & .TransTransporterID
        mStr = mStr & "|" & .VR_Transporters8_TransporterName
        mStr = mStr & "|" & .TransVehicleNo
        mStr = mStr & "|" & .TransGRNO
        mStr = mStr & "|" & .TransGRDate
        mStr = mStr & "|" & .TransVehicleTypeID
        mStr = mStr & "|" & .TransRemarks
      End With
      Return mStr
    End Function
    Public Shared Function SaveTransShip(ByVal Context As String) As String
      Dim aVal() As String = Context.Split("|".ToCharArray)
      Dim SRNNo As String = aVal(0)
      Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      With oRE
        .TransShipment = True
        .TransTransporterID = aVal(1)
        .TransVehicleNo = aVal(2)
        .TransGRNO = aVal(3)
        .TransGRDate = aVal(4)
        .TransVehicleTypeID = aVal(5)
        .TransRemarks = aVal(6)
      End With
      SIS.VR.vrRequestExecution.UpdateData(oRE)
      Return Context
    End Function
  End Class
End Namespace
