Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  <DataObject()>
  Partial Public Class irnList
    Public Property IRNO As String = ""
    Public Property SupplierID As String = ""
    Public Property SupplierName As String = ""
    Public Property TransporterID As String = ""
    Public Property TransporterName As String = ""
    Public Property BillNo As String = ""
    Public Property BillDate As String = ""
    Public Property GRNo As String = ""
    Public Property GRDate As String = ""
    Public Property PONumber As String = ""
    Public Property ProjectID As String = ""
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Black
        Try
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function GetByID(IRNo As String, Optional ProjectID As String = "") As SIS.VR.irnList
      Dim Results As SIS.VR.irnList = Nothing
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      If ProjectID <> "" Then
        Dim cmp = GetProjectCompany(ProjectID)
        If cmp <> "" Then
          Comp = cmp
        End If
      End If
      Dim Sql As String = ""
      Sql &= " select  "
      Sql &= "  ir.t_ninv as IRNo, "
      Sql &= "  ir.t_ifbp as SupplierID, "
      Sql &= "  ir.t_refr as SupplierName, "
      Sql &= "  ir.t_isup as BillNo, "
      Sql &= "  ir.t_invd as BillDate, "
      Sql &= "  lgr.t_grno as GRNo, "
      Sql &= "  lgr.t_grdt as GRDate, "
      Sql &= "  lgr.t_grbp as TransporterID, "
      Sql &= "  gbp.t_nama as TransporterName, "
      Sql &= " 	ir.t_cdf_pono as PONumber, "
      Sql &= " 	ir.t_cdf_cprj as ProjectID "
      Sql &= " from ttfacp100" & Comp & " as ir "
      Sql &= " inner join ttfisg002" & Comp & " as lgr on ir.t_ninv = lgr.t_irno "
      Sql &= " left outer join ttccom100" & Comp & " as gbp on gbp.t_bpid = lgr.t_grbp "
      Sql &= " where ir.t_ninv = " & IRNo
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.VR.irnList(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetProjectCompany(ByVal ProjectID As String) As String
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim aComp() As String = ConfigurationManager.AppSettings("ERPComps").Split(",".ToCharArray)
      Dim mRet As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        For Each cmp As String In aComp
          Dim Sql As String = "select top 1 isnull(t_cprj,'') from ttppdm600" & cmp & " where t_cprj='" & ProjectID.ToUpper & "'"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Dim Results As String = Cmd.ExecuteScalar
            If Results <> "" Then
              mRet = cmp
              Exit For
            End If
          End Using
        Next
      End Using
      Return mRet
    End Function

    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function SelectList(ProjectID As String, PONumber As String, SupplierID As String, TransporterID As String, BillNo As String, BillDate As String, ShowAll As Boolean) As List(Of SIS.VR.irnList)
      Dim Results As New List(Of SIS.VR.irnList)
      If ProjectID Is Nothing Then
        Return Results
      End If
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
      Dim cmp As String = GetProjectCompany(ProjectID)
      If cmp <> "" Then
        Comp = cmp
      End If
      Dim Sql As String = ""
      Sql &= " select  "
      Sql &= "  ir.t_ninv as IRNo, "
      Sql &= "  ir.t_ifbp as SupplierID, "
      Sql &= "  ir.t_refr as SupplierName, "
      Sql &= "  ir.t_isup as BillNo, "
      Sql &= "  ir.t_invd as BillDate, "
      Sql &= "  lgr.t_grno as GRNo, "
      Sql &= "  lgr.t_grdt as GRDate, "
      Sql &= "  lgr.t_grbp as TransporterID, "
      Sql &= "  gbp.t_nama as TransporterName, "
      Sql &= " 	ir.t_cdf_pono as PONumber, "
      Sql &= " 	ir.t_cdf_cprj as ProjectID "
      Sql &= " from ttfacp100" & Comp & " as ir "
      Sql &= " inner join ttfisg002" & Comp & " as lgr on ir.t_ninv = lgr.t_irno "
      Sql &= " left outer join ttccom100" & Comp & " as gbp on gbp.t_bpid = lgr.t_grbp "
      Sql &= " where 1 = 1 "
      If PONumber <> "" Then
        Sql &= " 	and ir.t_cdf_pono='" & PONumber & "' "
      Else
        Sql &= "  and ir.t_cdf_irdt >= dateadd(d,-365,getdate()) "
        Sql &= " 	and ir.t_cdf_cprj='" & ProjectID & "' "
        If cmp = HttpContext.Current.Session("FinanceCompany") Then
          If SupplierID <> "" AndAlso SupplierID.Substring(0, 3) <> "CUS" Then
            Sql &= "  and ir.t_ifbp='" & SupplierID & "' "
          End If
          If TransporterID <> "" Then
            'Sql &= " 	and lgr.t_grbp = '" & TransporterID & "' "
          End If
        End If
        If BillNo <> "" Then
          Sql &= " 	and ir.t_isup = '" & BillNo & "' "
        End If
        If BillDate <> "" Then
          Sql &= " 	and ir.t_invd = convert(datetime,'" & BillDate & "',103) "
        End If
      End If
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.irnList(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      If Not ShowAll Then
        Sql = ""
        Sql &= " select IRNO from VR_LorryReceiptDetails where ProjectID='" & ProjectID & "' "
        Sql &= " and SupplierID='" & SupplierID & "'"
        Sql &= " and IRNO is not NULL "
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Dim irno As String = Reader("irno")
              For Each x As SIS.VR.irnList In Results
                If x.IRNO = irno Then
                  Results.Remove(x)
                  Exit For
                End If
              Next
            End While
            Reader.Close()
          End Using
        End Using
      End If
      Return Results
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
