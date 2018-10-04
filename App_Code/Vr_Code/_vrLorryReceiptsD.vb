Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrLorryReceiptsD
    Inherits SIS.VR.vrLorryReceipts
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptsDGetNewRecord() As SIS.VR.vrLorryReceiptsD
      Return New SIS.VR.vrLorryReceiptsD()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptsDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal TransporterID As String, ByVal CustomerID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrLorryReceiptsD)
      Dim Results As List(Of SIS.VR.vrLorryReceiptsD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrLorryReceiptsDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrLorryReceiptsDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID",SqlDbType.NVarChar,6, IIf(ProjectID Is Nothing, String.Empty,ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID",SqlDbType.NVarChar,9, IIf(TransporterID Is Nothing, String.Empty,TransporterID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomerID",SqlDbType.NVarChar,9, IIf(CustomerID Is Nothing, String.Empty,CustomerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID",SqlDbType.Int,10, IIf(VehicleTypeID = Nothing, 0,VehicleTypeID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LRStatusID",SqlDbType.Int,10, 2)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.VR.vrLorryReceiptsD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLorryReceiptsD(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function vrLorryReceiptsDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal TransporterID As String, ByVal CustomerID As String, ByVal VehicleTypeID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptsDGetByID(ByVal ProjectID As String, ByVal MRNNo As Int32) As SIS.VR.vrLorryReceiptsD
      Dim Results As SIS.VR.vrLorryReceiptsD = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrLorryReceiptsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MRNNo",SqlDbType.Int,MRNNo.ToString.Length, MRNNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrLorryReceiptsD(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrLorryReceiptsDGetByID(ByVal ProjectID As String, ByVal MRNNo As Int32, ByVal Filter_ProjectID As String, ByVal Filter_TransporterID As String, ByVal Filter_CustomerID As String, ByVal Filter_VehicleTypeID As Int32) As SIS.VR.vrLorryReceiptsD
      Dim Results As SIS.VR.vrLorryReceiptsD = SIS.VR.vrLorryReceiptsD.vrLorryReceiptsDGetByID(ProjectID, MRNNo)
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
