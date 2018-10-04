Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrLinkedExecution
    Inherits SIS.VR.vrRequestExecution
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkedExecutionGetNewRecord() As SIS.VR.vrLinkedExecution
      Return New SIS.VR.vrLinkedExecution()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkedExecutionSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IRNo As Int32) As List(Of SIS.VR.vrLinkedExecution)
      Dim Results As List(Of SIS.VR.vrLinkedExecution) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrLinkedExecutionSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrLinkedExecutionSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_IRNo",SqlDbType.Int,10, IIf(IRNo = Nothing, 0,IRNo))
          End If
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
    Public Shared Function vrLinkedExecutionSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal IRNo As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkedExecutionGetByID(ByVal SRNNo As Int32) As SIS.VR.vrLinkedExecution
      Dim Results As SIS.VR.vrLinkedExecution = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrRequestExecutionSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SRNNo",SqlDbType.Int,SRNNo.ToString.Length, SRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrLinkedExecution(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLinkedExecutionGetByID(ByVal SRNNo As Int32, ByVal Filter_IRNo As Int32) As SIS.VR.vrLinkedExecution
      Dim Results As SIS.VR.vrLinkedExecution = SIS.VR.vrLinkedExecution.UZ_vrLinkedExecutionGetByID(SRNNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrLinkedExecutionUpdate(ByVal Record As SIS.VR.vrLinkedExecution) As SIS.VR.vrLinkedExecution
      Dim _Rec As SIS.VR.vrLinkedExecution = SIS.VR.vrLinkedExecution.UZ_vrLinkedExecutionGetByID(Record.SRNNo)
      With _Rec
        .RequestStatusID = Record.RequestStatusID
        .IRNo = Record.IRNo
      End With
      Return SIS.VR.vrLinkedExecution.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
