Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()>
  Partial Public Class vrBPGSTIN
    Private Shared _RecordCount As Integer
    Public Property BPID As String = ""
    Public Property GSTIN As Int32 = 0
    Public Property Description As String = ""
    Public Property VR_BusinessPartner1_BPName As String = ""
    Public Shared Function GetBPGSTINFromERP(ByVal BPID As String) As List(Of SIS.VR.vrBPGSTIN)
      Dim Results As New List(Of SIS.VR.vrBPGSTIN)
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim Sql As String = ""
      Sql &= "select                           "
      Sql &= "  t_bpid as BPID,                     "
      Sql &= "  t_fovn as Description,              "
      Sql &= "  t_seqn_l as GSTIN                   "
      Sql &= "  from ttctax400" & Comp
      Sql &= "  where t_bpid ='" & BPID & "'"
      Sql &= "  and t_catg_l = 9 "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.VR.vrBPGSTIN(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      If Results.Count > 0 Then
        For Each tmp As SIS.VR.vrBPGSTIN In Results
          Try
            SIS.VR.vrBPGSTIN.InsertData(tmp)
          Catch ex As Exception
          End Try
        Next
      End If
      Return Results
    End Function


    Public Shared Function spmtBPGSTINGetByID(ByVal BPID As String) As SIS.VR.vrBPGSTIN
      Dim Results As SIS.VR.vrBPGSTIN = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from VR_BPGSTIN where BPID='" & BPID & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.vrBPGSTIN(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      If Results Is Nothing Then
        Dim x As List(Of SIS.VR.vrBPGSTIN) = GetBPGSTINFromERP(BPID)
        If x.Count > 0 Then
          Return x(0)
        Else
          Return Nothing
        End If
      End If
      Return Results
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.VR.vrBPGSTIN) As SIS.VR.vrBPGSTIN
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spspmtBPGSTINInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, Record.BPID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GSTIN", SqlDbType.Int, 11, Record.GSTIN)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Description", SqlDbType.NVarChar, 51, IIf(Record.Description = "", Convert.DBNull, Record.Description))
          Cmd.Parameters.Add("@Return_BPID", SqlDbType.NVarChar, 10)
          Cmd.Parameters("@Return_BPID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_GSTIN", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GSTIN").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.BPID = Cmd.Parameters("@Return_BPID").Value
          Record.GSTIN = Cmd.Parameters("@Return_GSTIN").Value
        End Using
      End Using
      Return Record
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
