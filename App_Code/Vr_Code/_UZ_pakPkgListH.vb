Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Namespace SIS.PAK
  Partial Public Class pakPkgListH

    Public ReadOnly Property PONumber As String
      Get
        Return FK_PAK_PkgListH_SerialNo.PONumber
      End Get
    End Property
    Public ReadOnly Property SupplierID As String
      Get
        Return FK_PAK_PkgListH_SerialNo.SupplierID
      End Get
    End Property
    Public ReadOnly Property VR_BusinessPartner9_BPName() As String
      Get
        Return FK_PAK_PkgListH_SerialNo.VR_BusinessPartner9_BPName
      End Get
    End Property
    Public ReadOnly Property BuyerID As String
      Get
        Return FK_PAK_PkgListH_SerialNo.BuyerID
      End Get
    End Property
    Public ReadOnly Property aspnet_Users2_UserFullName As String
      Get
        Return FK_PAK_PkgListH_SerialNo.aspnet_Users2_UserFullName
      End Get
    End Property
    Public ReadOnly Property aspnet_Users3_UserFullName As String
      Get
        Return FK_PAK_PkgListH_SerialNo.aspnet_Users3_UserFullName
      End Get
    End Property
    Public ReadOnly Property POProjectID As String
      Get
        Return FK_PAK_PkgListH_SerialNo.ProjectID
      End Get
    End Property
    Public ReadOnly Property IDM_Projects4_Description As String
      Get
        Return FK_PAK_PkgListH_SerialNo.IDM_Projects4_Description
      End Get
    End Property
    Public ReadOnly Property PAK_Divisions5_Description As String
      Get
        Return FK_PAK_PkgListH_SerialNo.PAK_Divisions5_Description
      End Get
    End Property
    Public ReadOnly Property PAK_POStatus6_Description As String
      Get
        Return FK_PAK_PkgListH_SerialNo.PAK_POStatus6_Description
      End Get
    End Property
    Public ReadOnly Property PAK_POTypes7_Description As String
      Get
        Return FK_PAK_PkgListH_SerialNo.PAK_POTypes7_Description
      End Get
    End Property

    'Public ReadOnly Property GetDownloadLink() As String
    '  Get
    '    Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/PAK_Main/App_Downloads/pkgdownload.aspx?pkg=" & PrimaryKey & "', 'win" & PkgNo & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
    '  End Get
    'End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      If StatusID = 1 Then
        mRet = Drawing.Color.Green
      End If
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          If Not VRConverted Then
            mRet = True
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property ApproveWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RejectWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        If Not VRConverted Then
          mRet = True
        End If
        Return mRet
      End Get
    End Property
    Public Shared Function RejectWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = pakPkgListHGetByID(SerialNo, PkgNo)
      Results.VRRaised = False
      Results.VRRaisedOn = ""
      Results.StatusID = 1
      Results = SIS.PAK.pakPkgListH.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function ApproveWF(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      'Convert to Vehicle request
      Dim pkgH As SIS.PAK.pakPkgListH = pakPkgListHGetByID(SerialNo, PkgNo)
      Dim oPO As SIS.VR.vrERPPo = SIS.VR.vrERPPo.vrERPPoGetByID(pkgH.FK_PAK_PkgListH_SerialNo.PONumber)

      Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(pkgH.SupplierID)
      If oVar Is Nothing Then oVar = SIS.QCM.qcmVendors.GetBPFromERP(pkgH.SupplierID)
      Dim oPVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(pkgH.ProjectID)
      If oPVar Is Nothing Then oPVar = SIS.QCM.qcmProjects.GetProjectFromERP(pkgH.ProjectID)

      Dim newVR As New SIS.VR.vrVehicleRequest
      With newVR
        .RequestNo = 0
        .RequestDescription = pkgH.FK_PAK_PkgListH_SerialNo.ProjectID
        .SupplierID = pkgH.SupplierID
        .SupplierLocation = oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
        .ProjectID = pkgH.FK_PAK_PkgListH_SerialNo.ProjectID
        .ProjectType = IIf(pkgH.FK_PAK_PkgListH_SerialNo.PortRequired, "Export", "Domestic")
        .DeliveryLocation = oPVar.Address1.Trim & " " & oPVar.Address2 & " " & oPVar.Address3 & " " & oPVar.Address4 ' IIf(pkgH.FK_PAK_PkgListH_SerialNo.PortRequired, pkgH.ELOG_Ports8_Description, "")
        .ItemDescription = ""
        .MaterialSize = ""
        .SizeUnit = ""
        .Height = 0
        .Width = 0
        .Length = 0
        .MaterialWeight = pkgH.TotalWeight
        .WeightUnit = ""
        .NoOfPackages = 0
        .VehicleTypeID = ""
        .VehicleRequiredOn = ""
        .OverDimentionConsignement = False
        .ODCReasonID = ""
        .MICN = False
        .CustomInvoiceNo = ""
        .Remarks = ""
        .RequestedBy = HttpContext.Current.Session("LoginID")
        .RequestedOn = Now
        .RequesterDivisionID = "" 'Division will be updated Internally
        .RequestStatus = 3
        .ReturnedOn = ""
        .ReturnedBy = ""
        .ReturnRemarks = ""
        .SRNNo = ""
        .ValidRequest = True
        .ODCAtSupplierLoading = False
        .FromLocation = ""
        .ToLocation = ""
        .CustomInvoiceIssued = False
        .CT1Issued = False
        .ARE1Issued = False
        .DIIssued = False
        .PaymentChecked = False
        .GoodsPacked = False
        .POApproved = False
        .WayBill = False
        .MarkingDetails = False
        .TarpaulineRequired = False
        .PackageStckable = False
        .InvoiceValue = 0
        .OutOfContract = False
        .ERPPONumber = pkgH.FK_PAK_PkgListH_SerialNo.PONumber
        .BuyerInERP = pkgH.FK_PAK_PkgListH_SerialNo.BuyerID
        .DeliveryTerm = oPO.DeliveryTerm
        '.ExecuterReasonID = ""
        '.ExecuterID = ""
        '.ReasonEneteredOn = ""
      End With
      newVR = SIS.VR.vrVehicleRequest.vrVehicleRequestInsert(newVR)
      'CT Data in NON Editable Mode,Insert Item ref found in Packing List
      Dim tmpCTs As List(Of SIS.VR.vrctVehicleRequest) = SIS.VR.vrctVehicleRequest.GetPkgListHIref(SerialNo, PkgNo)
      Dim cnt As Integer = 0
      For Each tmp As SIS.VR.vrctVehicleRequest In tmpCTs
        cnt += 1
        With tmp
          .VRRequestNo = newVR.RequestNo
          .SerialNo = cnt
          .Project = newVR.ProjectID
          .PONumber = newVR.ERPPONumber
          .Handle = "CT_VEHICLEREQUESTRAISED"
          .PartialOrFull = "PARTIAL"
          .GridLineStatus = 1
          .SelectedList = "Coverted from Packing List No.: " & PkgNo
        End With
        tmp = SIS.VR.vrctVehicleRequest.InsertData(tmp)
      Next
      With pkgH
        .VRConverted = True
        .VRConvertedBy = HttpContext.Current.Session("LoginID")
        .VRConvertedOn = Now
        .VRRequestNo = newVR.RequestNo
      End With
      pkgH = SIS.PAK.pakPkgListH.UpdateData(pkgH)
      Return pkgH
    End Function
    Public Shared Function pakPkgPortHGetByID(ByVal SerialNo As Int32, ByVal PkgNo As Int32) As SIS.PAK.pakPkgListH
      Dim Results As SIS.PAK.pakPkgListH = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_PkgPortHSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PkgNo", SqlDbType.Int, PkgNo.ToString.Length, PkgNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPkgListH(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPkgListHSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListH)
      Dim Results As List(Of SIS.PAK.pakPkgListH) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_VRBySupplierSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_VRBySupplierSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListH)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListH(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
