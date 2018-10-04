Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrRequestAttachments
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
		Public ReadOnly Property GetLink() As String
			Get
				Return "return script_download('" & _RequestNo & "','" & _SerialNo & "','request');"
			End Get
		End Property
		Public Shared Function UZ_vrRequestAttachmentsInsert(ByVal Record As SIS.VR.vrRequestAttachments) As SIS.VR.vrRequestAttachments
			Dim _Result As SIS.VR.vrRequestAttachments = vrRequestAttachmentsInsert(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrRequestAttachmentsDelete(ByVal Record As SIS.VR.vrRequestAttachments) As Integer
			Dim _Result As Integer = vrRequestAttachmentsDelete(Record)
			If _Result > 0 Then
				Dim tmpPath As String = ConfigurationManager.AppSettings("ActiveAttachmentPath")
				Try
					IO.File.Delete(tmpPath & "\" & Record.DiskFile)
				Catch ex As Exception
				End Try
			End If
			Return _Result
		End Function
	End Class
End Namespace
