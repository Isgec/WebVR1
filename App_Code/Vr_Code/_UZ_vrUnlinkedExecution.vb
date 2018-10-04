Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrUnlinkedExecution
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
		Public Shared Shadows Function ApproveWF(ByVal SRNNo As Int32, ByVal IRNo As Int32) As SIS.VR.vrUnlinkedExecution
			Dim oRE As SIS.VR.vrUnlinkedExecution = vrUnlinkedExecutionGetByID(SRNNo)
			If oRE.Linked Then
				oRE.IRNo = IRNo
				Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.LinkID, "")
				For Each le As SIS.VR.vrRequestExecution In oLEs
					le.IRNo = IRNo
					le = SIS.VR.vrRequestExecution.UpdateData(le)
				Next
			Else
				oRE.IRNo = IRNo
				oRE = SIS.VR.vrUnlinkedExecution.UpdateData(oRE)
			End If

			Dim oTB As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(IRNo)
			oTB.BillStatusID = BillStatus.ExecutionLinked
			SIS.VR.vrTransporterBill.UpdateData(oTB)
			Return oRE
		End Function
    Public Shared Function UZ_vrUnlinkedExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String) As List(Of SIS.VR.vrUnlinkedExecution)
      Dim Results As List(Of SIS.VR.vrUnlinkedExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_UnlinkedExecutionSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_UnlinkedExecutionSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrUnlinkedExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrUnlinkedExecution(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrUnlinkedExecutionUpdate(ByVal Record As SIS.VR.vrUnlinkedExecution) As SIS.VR.vrUnlinkedExecution
      Dim _Result As SIS.VR.vrUnlinkedExecution = vrUnlinkedExecutionUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrUnlinkedExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrUnlinkedExecution
			Dim Results As SIS.VR.vrUnlinkedExecution = vrUnlinkedExecutionGetByID(SRNNo)
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function UZ_vrUnlinkedExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_TransporterID As String) As SIS.VR.vrUnlinkedExecution
      Return UZ_vrUnlinkedExecutionGetByID(SRNNo)
    End Function
  End Class
End Namespace
