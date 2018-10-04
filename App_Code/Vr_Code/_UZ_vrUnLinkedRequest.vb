Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrUnLinkedRequest
    Public ReadOnly Property CompleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CompleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function CompleteWF(ByVal RequestNo As Int32, ByVal SRNNo As Integer) As SIS.VR.vrUnLinkedRequest
      Dim Results As SIS.VR.vrUnLinkedRequest = vrUnLinkedRequestGetByID(RequestNo)
      With Results
        .RequestStatus = RequestStates.RequestLinked
        .SRNNo = SRNNo
        Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(SRNNo)
        With oRE
          .RequestStatusID = RequestStates.RequestLinked
          .ArrangedBy = HttpContext.Current.Session("LoginID")
					.ArrangedOn = Now
					'Req.Execution LoadedAtSupplier will be used as Flag OutOfContract
					.LoadedAtSupplier = Results.OutOfContract
        End With
        SIS.VR.vrRequestExecution.UpdateData(oRE)
      End With
      Results = SIS.VR.vrUnLinkedRequest.UpdateData(Results)
      Return Results
    End Function
		Public Shared Function UZ_vrUnLinkedRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.VR.vrUnLinkedRequest)
			Dim Results As List(Of SIS.VR.vrUnLinkedRequest) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_UnLinkedRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_UnLinkedRequestSelectListFilteres"
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus", SqlDbType.Int, 10, 4)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					RecordCount = -1
					Results = New List(Of SIS.VR.vrUnLinkedRequest)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrUnLinkedRequest(Reader))
					End While
					Reader.Close()
					RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
	End Class
End Namespace
