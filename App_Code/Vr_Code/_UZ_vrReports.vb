Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
	Partial Public Class vrReports
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
		Private _DivisionID As String = ""
		Private _OutOfContract As Boolean = False
		Public Property OutOfContract() As Boolean
			Get
				Return _OutOfContract
			End Get
			Set(ByVal value As Boolean)
				_OutOfContract = value
			End Set
		End Property
		Public Property DivisionID() As String
			Get
				Return _DivisionID
			End Get
			Set(ByVal value As String)
				_DivisionID = value
			End Set
		End Property
	End Class
End Namespace
