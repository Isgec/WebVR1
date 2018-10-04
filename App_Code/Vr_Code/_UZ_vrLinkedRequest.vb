Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrLinkedRequest
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
					If Me.FK_VR_VehicleRequest_SRNNo.RequestStatusID = RequestStates.UnderExecution _
					Or Me.FK_VR_VehicleRequest_SRNNo.RequestStatusID = RequestStates.RequestLinked _
					Or Me.FK_VR_VehicleRequest_SRNNo.RequestStatusID = RequestStates.ODCRejected Then
						mRet = True
					End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function RejectWF(ByVal RequestNo As Int32) As SIS.VR.vrLinkedRequest
      Dim Results As SIS.VR.vrLinkedRequest = vrLinkedRequestGetByID(RequestNo)
      'Delink 
      Dim DelinkedSRNNo As Integer = 0
      With Results
        DelinkedSRNNo = .SRNNo
        .RequestStatus = RequestStates.UnderExecution
        .SRNNo = ""
        Results = SIS.VR.vrLinkedRequest.UpdateData(Results)
        'Check if SRNO is not linked with other request
        Dim RELinkFound As Boolean = False
        Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(DelinkedSRNNo, "")
        If oVRs.Count > 0 Then
          RELinkFound = True
        End If
        If Not RELinkFound Then
          Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(DelinkedSRNNo)
          With oRE
            .RequestStatusID = RequestStates.UnderExecution
            .ArrangedBy = HttpContext.Current.Session("LoginID")
            .ArrangedOn = Now
          End With
          SIS.VR.vrRequestExecution.UpdateData(oRE)
        End If
      End With
      Return Results
    End Function
  End Class
End Namespace
