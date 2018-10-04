Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrPendingTransporterBill
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
    Public Shared Function ApproveWF(ByVal IRNo As Int32) As SIS.VR.vrPendingTransporterBill
			Dim Results As SIS.VR.vrPendingTransporterBill = vrPendingTransporterBillGetByID(IRNo)
			With Results
				.BillReturneddBy = HttpContext.Current.Session("LoginID")
				.BillReturnedOn = Now
				.BillStatusID = BillStatus.AcceptedByCentralAccount
			End With
			Results = SIS.VR.vrPendingTransporterBill.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function RejectWF(ByVal IRNo As Int32, ByVal BillReturnRemarks As String) As SIS.VR.vrPendingTransporterBill
      Dim Results As SIS.VR.vrPendingTransporterBill = vrPendingTransporterBillGetByID(IRNo)
			With Results
				.ForwardedBy = ""
				.ForwardedOn = ""
				.ForwardedToAccount = False
				.DiscripantBill = True
				.BillReturnRemarks = BillReturnRemarks
				.BillReturneddBy = HttpContext.Current.Session("LoginID")
				.BillReturnedOn = Now
				.BillStatusID = BillStatus.ReturnedByCentralAccount
			End With
			Results = SIS.VR.vrPendingTransporterBill.UpdateData(Results)
			Return Results
    End Function
    Public Shared Function UZ_vrPendingTransporterBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal ForwardedBy As String) As List(Of SIS.VR.vrPendingTransporterBill)
      Dim Results As List(Of SIS.VR.vrPendingTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_PendingTransporterBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_PendingTransporterBillSelectListFilteres"
						Cmd.CommandText = "spvrPendingTransporterBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ForwardedBy",SqlDbType.NVarChar,8, IIf(ForwardedBy Is Nothing, String.Empty,ForwardedBy))
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BillStatusID",SqlDbType.Int,10, "3")
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrPendingTransporterBill)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPendingTransporterBill(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrPendingTransporterBillUpdate(ByVal Record As SIS.VR.vrPendingTransporterBill) As SIS.VR.vrPendingTransporterBill
      Dim _Result As SIS.VR.vrPendingTransporterBill = vrPendingTransporterBillUpdate(Record)
      Return _Result
    End Function
  End Class
End Namespace
