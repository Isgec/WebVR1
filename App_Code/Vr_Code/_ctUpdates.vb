Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Public Class ctUpdates
    Public Shared Sub CT_ManualVRRequest(ByVal pp As SIS.VR.vrVehicleRequest)
      Dim hndl As String = "CT_VEHICLEREQUESTRAISED"
      Dim trdt As String = Now.ToString("dd/MM/yyyy HH:mm:ss")
      Dim POIrefs As List(Of SIS.VR.vrctVehicleRequest) = SIS.VR.vrctVehicleRequest.vrctVehicleRequestSelectList(0, 99999, "", False, "", pp.RequestNo)
      For Each iref As SIS.VR.vrctVehicleRequest In POIrefs
        Dim tmp As New SIS.TPISG.tpisg207
        With tmp
          .t_bohd = hndl
          .t_date = trdt
          .t_inid = pp.RequestNo
          .t_iref = iref.ItemReference
          .t_mode = 1  '=>Manual, 2=>Packing List
          .t_pono = pp.ERPPONumber
          .t_prpo = iref.ProgressPercent
          .t_powt = iref.ProgressWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.ProjectID
          .t_sitm = iref.ActivityID
        End With
        SIS.TPISG.tpisg207.InsertData(tmp)
      Next
    End Sub

    Public Shared Sub CT_VehiclePlaced(ByVal pp As SIS.VR.vrVehicleRequest)
      Dim hndl As String = "CT_VEHICLEPLACED"
      Dim trdt As String = Now.ToString("dd/MM/yyyy HH:mm:ss")
      Dim POIrefs As List(Of SIS.VR.vrctVehicleRequest) = SIS.VR.vrctVehicleRequest.vrctVehicleRequestSelectList(0, 99999, "", False, "", pp.RequestNo)
      For Each iref As SIS.VR.vrctVehicleRequest In POIrefs
        Dim tmp As New SIS.TPISG.tpisg207
        With tmp
          .t_bohd = hndl
          .t_date = trdt
          .t_inid = pp.RequestNo
          .t_iref = iref.ItemReference
          .t_mode = 1  '=>Manual, 2=>Packing List
          .t_pono = pp.ERPPONumber
          .t_prpo = iref.ProgressPercent
          .t_powt = iref.ProgressWeight
          .t_Refcntd = 0
          .t_Refcntu = 0
          .t_cprj = pp.ProjectID
          .t_sitm = iref.ActivityID
        End With
        SIS.TPISG.tpisg207.InsertData(tmp)
      Next
    End Sub
  End Class
End Namespace
