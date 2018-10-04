Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()> _
  Partial Public Class vrPendingTransporterBill
    Inherits SIS.VR.vrTransporterBill
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingTransporterBillGetNewRecord() As SIS.VR.vrPendingTransporterBill
      Return New SIS.VR.vrPendingTransporterBill()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingTransporterBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal ForwardedBy As String) As List(Of SIS.VR.vrPendingTransporterBill)
      Dim Results As List(Of SIS.VR.vrPendingTransporterBill) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvrPendingTransporterBillSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvrPendingTransporterBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID",SqlDbType.NVarChar,9, IIf(TransporterID Is Nothing, String.Empty,TransporterID))
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
    Public Shared Function vrPendingTransporterBillSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal ForwardedBy As String) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingTransporterBillGetByID(ByVal IRNo As Int32) As SIS.VR.vrPendingTransporterBill
      Dim Results As SIS.VR.vrPendingTransporterBill = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spvrTransporterBillSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IRNo",SqlDbType.Int,IRNo.ToString.Length, IRNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrPendingTransporterBill(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function vrPendingTransporterBillGetByID(ByVal IRNo As Int32, ByVal Filter_TransporterID As String, ByVal Filter_ForwardedBy As String) As SIS.VR.vrPendingTransporterBill
      Dim Results As SIS.VR.vrPendingTransporterBill = SIS.VR.vrPendingTransporterBill.vrPendingTransporterBillGetByID(IRNo)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function vrPendingTransporterBillUpdate(ByVal Record As SIS.VR.vrPendingTransporterBill) As SIS.VR.vrPendingTransporterBill
      Dim _Rec As SIS.VR.vrPendingTransporterBill = SIS.VR.vrPendingTransporterBill.vrPendingTransporterBillGetByID(Record.IRNo)
      With _Rec
        .BillStatusID = Record.BillStatusID
        .DiscripantBill = Record.DiscripantBill
        .BillReturnRemarks = Record.BillReturnRemarks
        .BillReturnedOn = Now
        .BillReturneddBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .ForwardedToAccount = Record.ForwardedToAccount
      End With
      Return SIS.VR.vrPendingTransporterBill.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
