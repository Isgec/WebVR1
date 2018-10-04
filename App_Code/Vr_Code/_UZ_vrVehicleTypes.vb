Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrVehicleTypes
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Blue
			Return mRet
		End Function
		Public Function GetVisible() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
    Public Shared Function UZ_vrVehicleTypesInsert(ByVal Record As SIS.VR.vrVehicleTypes) As SIS.VR.vrVehicleTypes
      Dim oVTD As SIS.VR.vrVTDefault = SIS.VR.vrVTDefault.vrVTDefaultGetByID(1)
      With Record
        If .CapacityInKG > 0 Then
          .MinimumCapacity = .CapacityInKG * oVTD.MinimumCapacityPercentage / 100
          .MaximumCapacity = .CapacityInKG * oVTD.MaximumCapacityPercentage / 100
        End If
        If .HeightInFt > 0 Then
          .MinimumHeight = .HeightInFt * oVTD.MinimumHeightPercentage / 100
          .MaximumHeight = .HeightInFt * oVTD.MaximumHeightPercentage / 100
        End If
        If .WidthInFt > 0 Then
          .MinimumWidth = .WidthInFt * oVTD.MinimumWidthPercentage / 100
          .MaximumWidth = .WidthInFt * oVTD.MaximumWidthPercentage / 100
        End If
        If .LengthInFt > 0 Then
          .MinimumLength = .LengthInFt * oVTD.MinimumLengthPercentage / 100
          .MaximumLength = .LengthInFt * oVTD.MaximumLengthPercentage / 100
        End If
      End With
      Dim _Result As SIS.VR.vrVehicleTypes = SIS.VR.vrVehicleTypes.InsertData(Record)
      Return _Result
    End Function
  End Class
End Namespace
