Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrUnlinkedExecution
    Inherits SIS.VR.vrRequestExecution
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUnlinkedExecutionGetNewRecord() As SIS.VR.vrUnlinkedExecution
      Return New SIS.VR.vrUnlinkedExecution()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUnlinkedExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String) As List(Of SIS.VR.vrUnlinkedExecution)
      Dim Results As List(Of SIS.VR.vrUnlinkedExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrUnlinkedExecutionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrUnlinkedExecutionSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID",SqlDbType.NVarChar,9, IIf(TransporterID Is Nothing, String.Empty,TransporterID))
          End If
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
    Public Shared Function vrUnlinkedExecutionSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUnlinkedExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrUnlinkedExecution
      Dim Results As SIS.VR.vrUnlinkedExecution = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrUnlinkedExecution(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrUnlinkedExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_TransporterID As String) As SIS.VR.vrUnlinkedExecution
      Dim Results As SIS.VR.vrUnlinkedExecution = SIS.VR.vrUnlinkedExecution.UZ_vrUnlinkedExecutionGetByID(SRNNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrUnlinkedExecutionUpdate(ByVal Record As SIS.VR.vrUnlinkedExecution) As SIS.VR.vrUnlinkedExecution
      Dim _Rec As SIS.VR.vrUnlinkedExecution = SIS.VR.vrUnlinkedExecution.UZ_vrUnlinkedExecutionGetByID(Record.SRNNo)
      With _Rec
        .RequestStatusID = Record.RequestStatusID
        .IRNo = Record.IRNo
      End With
      Return SIS.VR.vrUnlinkedExecution.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
