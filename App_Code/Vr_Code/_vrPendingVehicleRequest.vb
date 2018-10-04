Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrPendingVehicleRequest
    Inherits SIS.VR.vrVehicleRequest
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingVehicleRequestGetNewRecord() As SIS.VR.vrPendingVehicleRequest
      Return New SIS.VR.vrPendingVehicleRequest()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestedBy As String) As List(Of SIS.VR.vrPendingVehicleRequest)
      Dim Results As List(Of SIS.VR.vrPendingVehicleRequest) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrPendingVehicleRequestSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrPendingVehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy",SqlDbType.NVarChar,8, IIf(RequestedBy Is Nothing, String.Empty,RequestedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus",SqlDbType.Int,10, 4)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrPendingVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrPendingVehicleRequest(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrPendingVehicleRequestSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingVehicleRequestGetByID(ByVal RequestNo As Int32) As SIS.VR.vrPendingVehicleRequest
      Dim Results As SIS.VR.vrPendingVehicleRequest = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrVehicleRequestSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestNo",SqlDbType.Int,RequestNo.ToString.Length, RequestNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrPendingVehicleRequest(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingVehicleRequestGetByID(ByVal RequestNo As Int32, ByVal Filter_SupplierID As String, ByVal Filter_ProjectID As String, ByVal Filter_RequestedBy As String) As SIS.VR.vrPendingVehicleRequest
      Dim Results As SIS.VR.vrPendingVehicleRequest = SIS.VR.vrPendingVehicleRequest.vrPendingVehicleRequestGetByID(RequestNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrPendingVehicleRequestUpdate(ByVal Record As SIS.VR.vrPendingVehicleRequest) As SIS.VR.vrPendingVehicleRequest
      Dim _Rec As SIS.VR.vrPendingVehicleRequest = SIS.VR.vrPendingVehicleRequest.vrPendingVehicleRequestGetByID(Record.RequestNo)
      With _Rec
        .RequestStatus = Record.RequestStatus
        .ReturnedOn = Now
        .ReturnedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ReturnRemarks = Record.ReturnRemarks
        .SRNNo = Record.SRNNo
      End With
      Return SIS.VR.vrPendingVehicleRequest.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
