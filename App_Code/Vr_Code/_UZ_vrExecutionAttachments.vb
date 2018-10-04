Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrExecutionAttachments
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
				Return "return script_download('" & _SRNNo & "','" & _SerialNo & "','execution');"
			End Get
		End Property
    Public Shared Function UZ_vrExecutionAttachmentsInsert(ByVal Record As SIS.VR.vrExecutionAttachments) As SIS.VR.vrExecutionAttachments
      Dim _Result As SIS.VR.vrExecutionAttachments = vrExecutionAttachmentsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrExecutionAttachmentsDelete(ByVal Record As SIS.VR.vrExecutionAttachments) As Integer
      Dim _Result as Integer = vrExecutionAttachmentsDelete(Record)
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
