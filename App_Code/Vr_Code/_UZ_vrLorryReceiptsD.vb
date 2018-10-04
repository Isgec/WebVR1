Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrLorryReceiptsD
    Public Shared Function UZ_vrLorryReceiptsDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal TransporterID As String, ByVal CustomerID As String, ByVal VehicleTypeID As Int32, ByVal Supplier As String, ByVal GRNo As String) As List(Of SIS.VR.vrLorryReceiptsD)
      Dim Results As List(Of SIS.VR.vrLorryReceiptsD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_LorryReceiptsDSelectListSearch"
            Cmd.CommandText = "spvrLorryReceiptsDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_LorryReceiptsDSelectListFilteres"
            'Cmd.CommandText = "spvrLorryReceiptsDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomerID", SqlDbType.NVarChar, 9, IIf(CustomerID Is Nothing, String.Empty, CustomerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_Supplier", SqlDbType.NVarChar, 50, IIf(Supplier Is Nothing, String.Empty, Supplier))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GRNo", SqlDbType.NVarChar, 50, IIf(GRNo Is Nothing, String.Empty, GRNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LRStatusID", SqlDbType.Int, 10, 2)
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
    Public Shared Function vrLorryReceiptsDSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal TransporterID As String, ByVal CustomerID As String, ByVal VehicleTypeID As Int32, ByVal Supplier As String, ByVal GRNo As String) As Integer
      Return RecordCount
    End Function
  End Class
End Namespace
