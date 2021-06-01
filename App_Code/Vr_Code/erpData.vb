Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK

#Region " ERP Components Classes "
  Public Class erpData
    Private Shared Sub CreatePOMasters(oePO As SIS.PAK.pakPO)
      '1. Check Supplier
      Dim oSup As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(oePO.SupplierID)
      If oSup Is Nothing Then
        oSup = SIS.PAK.erpData.erpSupplier.GetFromERP(oePO.SupplierID)
        SIS.VR.vrBusinessPartner.InsertData(oSup)
      End If
      '2. Check Project
      Dim oPrj As SIS.PAK.erpData.erpProject = SIS.QCM.qcmProjects.qcmProjectsGetByID(oePO.ProjectID)
      If oPrj Is Nothing Then
        'Create Project
        oPrj = SIS.PAK.erpData.erpProject.GetFromERP(oePO.ProjectID)
        '2.1 Check Project Customer
        Dim oCus As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(oPrj.BusinessPartnerID)
        If oCus Is Nothing Then
          'Create Customer
          oCus = SIS.PAK.erpData.erpSupplier.GetFromERP(oPrj.BusinessPartnerID)
          SIS.VR.vrBusinessPartner.InsertData(oCus)
        End If
        'After Customer Create Project
        SIS.QCM.qcmProjects.InsertData(oPrj)
      End If
    End Sub
    Public Class erpPO
      'Main Function PO Import
      Public Shared Function ImportFromERP(PONumber As String) As SIS.PAK.pakPO
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim oPO As SIS.PAK.pakPO = Nothing
        Try
          oPO = SIS.PAK.erpData.erpPO.GetFromERP(PONumber)
        Catch ex As Exception
          Throw New Exception("Error when fetching PO from ERP: " & ex.Message)
        End Try
        If oPO Is Nothing Then
          Throw New Exception("PO Not found in ERP Company : " & Comp)
        End If
        'CreatePOMasters(oPO)
        Return oPO
      End Function

      Public Shared Function GetFromERP(ByVal PONumber As String) As SIS.PAK.pakPO
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim Sql As String = ""
        Sql &= " select TOP 1 "
        Sql &= "  apo.t_orno as PONumber,"
        Sql &= "  lpo.t_cprj as ProjectID,"
        Sql &= "  apo.t_otbp as SupplierID"
        Sql &= "  FROM ttdpur400" & Comp & " apo "
        Sql &= "  cross apply (select top 1 tmp.t_cprj from ttdpur401" & Comp & " tmp where tmp.t_orno=apo.t_orno   "
        Sql &= "              ) lpo "
        Sql &= "  WHERE apo.t_orno='" & PONumber & "'"
        Dim Results As SIS.PAK.pakPO = Nothing
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While (Reader.Read())
              Results = New SIS.PAK.pakPO(Reader)
            End While
            Reader.Close()
          End Using
        End Using
        Return Results
      End Function
      Sub New()
        'dummy
      End Sub
    End Class
    Public Class erpProject
      Inherits SIS.QCM.qcmProjects
      Public Property BusinessPartnerID As String = ""
      Public Shared Function GetFromERP(ByVal ProjectID As String) As SIS.PAK.erpData.erpProject
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim Ret As SIS.PAK.erpData.erpProject = Nothing
        Dim Sql As String = ""
        Sql &= "select top 1  "
        Sql &= "  prh.t_cprj as ProjectID,  "
        Sql &= "  prd.t_dsca as Description, "
        Sql &= "  prb.t_ofbp as BusinessPartnerID "
        Sql &= "  from ttppdm600" & Comp & " as prh  "
        Sql &= "  right outer join ttcmcs052" & Comp & " as prd on prd.t_cprj=prh.t_cprj"
        Sql &= "  right outer join ttppdm740" & Comp & " as prb on prb.t_cprj=prh.t_cprj"
        Sql &= "  where prh.t_cprj ='" & ProjectID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.PAK.erpData.erpProject(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function

      Public Shared Function GetEnterpriseUnit(ByVal ProjectID As String) As String
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim Ret As String = ""
        Dim Sql As String = ""
        Sql &= "select isnull(t_cdf_divs,'')  "
        Sql &= "  from ttppdm600" & Comp
        Sql &= "  where t_cprj ='" & ProjectID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Ret = Cmd.ExecuteScalar
          End Using
        End Using
        Return Ret
      End Function

      Sub New(ByVal rd As SqlDataReader)
        MyBase.New(rd)
      End Sub
      Sub New()
        MyBase.New()
      End Sub
    End Class
    Public Class erpSupplier
      Public Shared Function GetFromERP(ByVal SupplierID As String) As SIS.VR.vrBusinessPartner
        Dim Comp As String = HttpContext.Current.Session("FinanceCompany")
        Dim Ret As SIS.VR.vrBusinessPartner = Nothing
        Dim Sql As String = ""
        Sql &= "select                                                           "
        Sql &= "  suh.t_bpid as BPID,                                      "
        Sql &= "  suh.t_nama as BPName,                                    "
        Sql &= "  adh.t_ln01 as Address1Line,                                        "
        Sql &= "  adh.t_ln02 as Address2Line,                                        "
        Sql &= "  adh.t_ln03 as Address3,                                        "
        Sql &= "  adh.t_ln04 as Address4,                                        "
        Sql &= "  adh.t_ln05 as City,                                            "
        Sql &= "  adh.t_ln06 as State,                                           "
        Sql &= "  adh.t_pstc as Zip,                                             "
        Sql &= "  adh.t_ccty as Country,                                         "
        Sql &= "  cnh.t_fuln as ContactPerson,                                   "
        Sql &= "  cnh.t_telp as ContactNo,                                       "
        Sql &= "  cnh.t_info as EMailID                                          "
        Sql &= "  from ttccom100" & Comp & " as suh                                       "
        Sql &= "  left outer join ttccom130" & Comp & " as adh on suh.t_cadr = adh.t_cadr "
        Sql &= "  left outer join ttccom140" & Comp & " as cnh on suh.t_ccnt = cnh.t_ccnt "
        Sql &= "  where suh.t_bpid ='" & SupplierID & "'"
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If (Reader.Read()) Then
              Ret = New SIS.VR.vrBusinessPartner(Reader)
            End If
            Reader.Close()
          End Using
        End Using
        Return Ret
      End Function
    End Class

  End Class

#End Region
End Namespace
