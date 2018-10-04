Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrLinkedExecution
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
    Public Shared Function RejectWF(ByVal SRNNo As Int32) As SIS.VR.vrLinkedExecution
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = Nothing
			Dim oRE As SIS.VR.vrLinkedExecution = vrLinkedExecutionGetByID(SRNNo)
			Dim IRNo As String = oRE.IRNo
			If oRE.Linked Then
				oRE.IRNo = ""
				oLEs = SIS.VR.vrRequestExecution.GetByLinkID(oRE.LinkID, "")
				For Each le As SIS.VR.vrRequestExecution In oLEs
					oRE.IRNo = ""
					le = SIS.VR.vrRequestExecution.UpdateData(le)
				Next
			Else
				oRE.IRNo = ""
				oRE = SIS.VR.vrLinkedExecution.UpdateData(oRE)
			End If

			'Check If IR is still linked with executions
			oLEs = SIS.VR.vrRequestExecution.GetByIRNo(IRNo, "")
			If oLEs.Count <= 0 Then
				Dim oTB As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(IRNo)
				oTB.BillStatusID = BillStatus.Free
				SIS.VR.vrTransporterBill.UpdateData(oTB)
			End If
			Return oRE
    End Function
    Public Shared Function UZ_vrLinkedExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IRNo As Int32) As List(Of SIS.VR.vrLinkedExecution)
      Dim Results As List(Of SIS.VR.vrLinkedExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_LinkedExecutionSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_LinkedExecutionSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IRNo", SqlDbType.Int, 10, IIf(IRNo = Nothing, 0, IRNo))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrLinkedExecution)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLinkedExecution(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrLinkedExecutionUpdate(ByVal Record As SIS.VR.vrLinkedExecution) As SIS.VR.vrLinkedExecution
      Dim _Result As SIS.VR.vrLinkedExecution = vrLinkedExecutionUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrLinkedExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrLinkedExecution
			Dim Results As SIS.VR.vrLinkedExecution = vrLinkedExecutionGetByID(SRNNo)
      Return Results
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    Public Shared Function UZ_vrLinkedExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_IRNo As Int32) As SIS.VR.vrLinkedExecution
      Return UZ_vrLinkedExecutionGetByID(SRNNo)
    End Function
  End Class
End Namespace
