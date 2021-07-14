Imports System.Reflection
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.Drawing
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Public Class SPApi

  Public Shared Function CreateTransporter(TransP As SPApi.Transporter, ByRef jsonStr As String) As SPApi.SPResponse
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/tms/addCarrier"
    Else
      url = "https://test.superprocure.com/sp/tms/addCarrier"
    End If
    Dim xResponse As SPApi.SPResponse = Nothing
    Dim xWebRequest As HttpWebRequest = GetWebRequest(url, "POST")
    jsonStr = New JavaScriptSerializer().Serialize(TransP)
    Dim jsonByte() As Byte = System.Text.Encoding.ASCII.GetBytes(jsonStr)
    xWebRequest.ContentLength = jsonByte.Count
    xWebRequest.GetRequestStream().Write(jsonByte, 0, jsonByte.Count)
    'Try
    Dim rs As WebResponse = xWebRequest.GetResponse()
    Dim st As IO.Stream = rs.GetResponseStream
    Dim sr As IO.StreamReader = New IO.StreamReader(st)
    Dim strResponse As String = sr.ReadToEnd
    sr.Close()
    xResponse = New JavaScriptSerializer().Deserialize(strResponse, GetType(SPApi.SPResponse))
    'Catch ex As Exception
    'Throw New Exception(ex.Message)
    'End Try
    Return xResponse
  End Function

  Public Shared Function PushISGECExecution(isgExecution As SPApi.ISGECExecution, ByRef jsonStr As String) As SPApi.SPResponse
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/requisition/createMemo"
    Else
      url = "https://test.superprocure.com/sp/requisition/createMemo"
    End If
    Dim xResponse As SPApi.SPResponse = Nothing
    Dim xWebRequest As HttpWebRequest = GetWebRequest(url, "POST")
    jsonStr = New JavaScriptSerializer().Serialize(isgExecution)
    Dim jsonByte() As Byte = System.Text.Encoding.ASCII.GetBytes(jsonStr)
    xWebRequest.ContentLength = jsonByte.Count
    xWebRequest.GetRequestStream().Write(jsonByte, 0, jsonByte.Count)
    'Try
    Dim rs As WebResponse = xWebRequest.GetResponse()
    Dim st As IO.Stream = rs.GetResponseStream
    Dim sr As IO.StreamReader = New IO.StreamReader(st)
    Dim strResponse As String = sr.ReadToEnd
    sr.Close()
    xResponse = New JavaScriptSerializer().Deserialize(strResponse, GetType(SPApi.SPResponse))
    'Catch ex As Exception
    'Throw New Exception(ex.Message)
    'End Try
    Return xResponse
  End Function

  Public Shared Function CancelSPRequest(SPRequestID As String, Remarks As String) As SPApi.SPResponse
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/requisition/cancelRequisition"
    Else
      url = "https://test.superprocure.com/sp/requisition/cancelRequisition"
    End If
    Dim xResponse As SPApi.SPResponse = Nothing
    Dim xWebRequest As HttpWebRequest = GetWebRequest(url, "POST")
    Dim jsonStr As String = New JavaScriptSerializer().Serialize(New With {
         .reqId = SPRequestID,
         .notes = Remarks
     })
    Dim jsonByte() As Byte = System.Text.Encoding.ASCII.GetBytes(jsonStr)
    xWebRequest.ContentLength = jsonByte.Count
    xWebRequest.GetRequestStream().Write(jsonByte, 0, jsonByte.Count)
    Try
      Dim rs As WebResponse = xWebRequest.GetResponse()
      Dim st As IO.Stream = rs.GetResponseStream
      Dim sr As IO.StreamReader = New IO.StreamReader(st)
      Dim strResponse As String = sr.ReadToEnd
      sr.Close()
      jsonStr = strResponse
      xResponse = New JavaScriptSerializer().Deserialize(strResponse, GetType(SPApi.SPResponse))
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
    Return xResponse
  End Function

  Public Shared Function GetSPExecution(SPRequestID As String, ByRef jsonStr As String) As SPApi.SPExecution
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/requisition/getAllotmentDetails?reqId=" & SPRequestID
    Else
      url = "https://test.superprocure.com/sp/requisition/getAllotmentDetails?reqId=" & SPRequestID
    End If
    Dim xResponse As SPApi.SPExecution = Nothing
    Dim xWebRequest As HttpWebRequest = GetWebRequest(url, "GET")
    Try
      Dim rs As WebResponse = xWebRequest.GetResponse()
      Dim st As IO.Stream = rs.GetResponseStream
      Dim sr As IO.StreamReader = New IO.StreamReader(st)
      Dim strResponse As String = sr.ReadToEnd
      sr.Close()
      jsonStr = strResponse
      xResponse = New JavaScriptSerializer().Deserialize(strResponse, GetType(SPApi.SPExecution))
      'Catch ex As webException
      'Console.WriteLine(ex.Status)
      'If ex.Response IsNot Nothing Then
      '  '' can use ex.Response.Status, .StatusDescription
      '  If ex.Response.ContentLength <> 0 Then
      '    Using stream = ex.Response.GetResponseStream()
      '      Using reader = New StreamReader(stream)
      '        Console.WriteLine(reader.ReadToEnd())
      '      End Using
      '    End Using
      '  End If
      'End If
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
    Return xResponse
  End Function

  Public Shared Function CreateSPRequest(spr As SPApi.SPRequest) As SPApi.SPResponse
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/requisition/createRequisitionForISGEC"
    Else
      url = "https://test.superprocure.com/sp/requisition/createRequisitionForISGEC"
    End If
    Dim xResponse As SPApi.SPResponse = Nothing
    Dim xWebRequest As HttpWebRequest = GetWebRequest(url, "POST")
    Dim jsonStr As String = New JavaScriptSerializer().Serialize(spr)
    Dim jsonByte() As Byte = System.Text.Encoding.ASCII.GetBytes(jsonStr)
    xWebRequest.ContentLength = jsonByte.Count
    xWebRequest.GetRequestStream().Write(jsonByte, 0, jsonByte.Count)
    Try
      Dim rs As WebResponse = xWebRequest.GetResponse()
      Dim st As IO.Stream = rs.GetResponseStream
      Dim sr As IO.StreamReader = New IO.StreamReader(st)
      Dim strResponse As String = sr.ReadToEnd
      sr.Close()
      xResponse = New JavaScriptSerializer().Deserialize(strResponse, GetType(SPApi.SPResponse))
    Catch ex As Exception
      Throw New Exception(ex.Message)
    End Try
    Return xResponse
  End Function

  Private Shared Function GetWebRequest(url As String, Optional method As String = "POST") As HttpWebRequest
    Dim Uri As Uri = New Uri(url)
    Dim xWebRequest As HttpWebRequest = WebRequest.Create(Uri)
    With xWebRequest
      If Convert.ToBoolean(ConfigurationManager.AppSettings("UseProxy")) Then
        .Proxy = New WebProxy(Convert.ToString(ConfigurationManager.AppSettings("Proxy")))
      End If
      .Method = method
      .ContentType = "application/json"
      .Accept = "*/*"
      .CachePolicy = New Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
      .Headers.Add("ContentType", "application/json")
      If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
        .Headers.Add("Authorization", "Basic ODczNjo4NmUwY2M3NTE2MjhhN2NjMTFmNDNlMDJhNjQ4ODRjZQ==")
      Else
        .Headers.Add("Authorization", "Basic MjIyNTo2MDg3MTI4OTI3NjlhYzEyM2FkYmVjMTY2Mzk5Njc5MA==")
      End If
      .KeepAlive = True
    End With
    Return xWebRequest
  End Function
#Region " SP Classes "
  Public Class ISGECExecution
    Public Property reqId As Integer = 0
    Public Property loadId As Integer = 0
    Public Property memoNumber As String = ""
    Public Property placementDate As String = ""
    Public Property transporterCode As String = ""
    Public Property vehicleCode As String = ""
    Public Property materialWeight As String = ""
    Public Property uom As String = ""
  End Class
  Public Class SPExecution
    Public Property resultSet As List(Of SPApi.ExecutionData) = New List(Of SPApi.ExecutionData)
    Public Property Status As String = ""
    Public Property Code As String = ""
    Public Property Message As String = ""
    Public Property taggedRequestIds As String = ""
    Public ReadOnly Property ClubbedRequests As String()
      Get
        Return taggedRequestIds.Split(",".ToCharArray)
      End Get
    End Property
    Public Property requestCount As Integer = 0
    Public ReadOnly Property IsError As Boolean
      Get
        Return (Code <> "200")
      End Get
    End Property
  End Class
  Public Class ExecutionData
    Public Property loadId As Integer = 0
    Public Property requestedDate As String = ""
    Public Property loadingDate As String = ""
    Public Property transporterCode As String = ""
    Public Property transporterGSTIN As String = ""
    Public Property projectName As String = ""
    Public Property projectCode As String = ""
    Public Property weight As Decimal = 0
    Public Property vehicleType As String = ""
    Public Property noOfVechiles As Integer = 0
    Public Property amountPerVehicle As Integer = 0
    Public Property totalAmount As Integer = 0
    Public Property supplierLocation As String = ""
    Public Property deliveryLocation As String = ""
    Public Property fromState As String = ""
    Public Property toState As String = ""
    Public Property uom As String = ""
    '============Additional===========
    Public Property RequestNo As String = ""
    Public Property BPID As String = ""
    Public Property GeneratePO As Integer = 0
    Public Property Size As String = ""
    Public Property VehicleTypeDescription As String = ""
    Public Property wuom As String = ""
  End Class
  Public Class SPRequest
    Public Property RFQ As String = "" '200
    Public Property loadingDate As String = "" '10 char, dd-MM-yyyy
    Public Property projectCode As String = "" '255
    Public Property projectName As String = "" '255
    Public Property vehicleType As String = "" '255
    Public Property supplierCode As String = "" '255
    Public Property supplierName As String = "" '255
    Public Property loadingPoint As String = "" '1000
    Public Property loadingPointPincode As String = ""

    Public Property unloadingPoint As String = "" '1000
    Public Property unloadingPointPincode As String = ""
    Public Property supplierLoadingPoint As String = "" '255
    Public Property noOfVehicles As Integer = 0
    Public Property product As String = "" '255
    Public Property length As Decimal = 0
    Public Property breadth As Decimal = 0
    Public Property height As Decimal = 0
    Public Property notes As String = "" '1000
    Public Property branchCode As String = "" '255
    Public Property deliveryCode As String = "" '255
    Public Property materialWt As Decimal = 0
    Public Property deliveryUnloadingPoint As String = "" '100
    Public Property projectLocation As String = "" '255
    Public Property uom As String = ""

  End Class
  Public Class SPResponse
    Public Property Message As String = ""
    Public Property Code As String = ""
    Public Property Status As String = ""
    Public Property ReqId As String = ""
    Public Property RFQ As String = ""
    Public ReadOnly Property IsError As Boolean
      Get
        Return (Code <> "201")
      End Get
    End Property
  End Class
  Public Class POData
    Public Property t_load As Integer = 0
    Public Property t_rqdt As String = "" 'load
    Public Property t_vrdt As String = "" 're
    Public Property t_ivrn As String = ""
    Public Property t_tran As String = ""
    Public Property t_tgst As String = ""
    Public Property t_cprj As String = ""
    Public Property t_pric As Decimal = 0
    Public Property t_amnt As Decimal = 0
    Public Property t_fcst As String = ""
    Public Property t_tcst As String = ""
    Public Property t_type As String = ""
    Public Property t_wght As Decimal = 0
    Public Property t_size As String = ""
    Public Property t_novc As Integer = 0
    Public Property t_snam As String = ""
    Public Property t_dnam As String = ""
    Public Property t_bpid As String = ""
    Public Property t_proc As Integer = 0
    Public Property t_orno As String = ""
    Public Property t_genp As Integer = 0
    Public Property t_Refcntd As Integer = 0
    Public Property t_Refcntu As Integer = 0
    Public Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Public Shared Function GetByID(LoadID As Integer, ProjectID As String, Optional Comp As String = "200") As SPApi.POData
      Dim mRet As SPApi.POData = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ttdisg140" & Comp & " where t_load=" & LoadID & " and t_cprj='" & ProjectID & "'"
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New SPApi.POData(rd)
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UpdateGeneratePO(LoadID As Integer, Optional Comp As String = "200") As Boolean
      'This function is called from old Logic, No need to add projectwise logic
      Dim mRet As Boolean = True
      Try
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "update ttdisg140" & Comp & " set t_genp = 1 where t_load=" & LoadID
            Cmd.ExecuteNonQuery()
          End Using
        End Using
      Catch ex As Exception
        mRet = False
      End Try
      Return mRet
    End Function
    '=============Without SP================
    Public Shared Sub NewInsertData(re As SIS.VR.vrRequestExecution, ProjectID As String, Optional Comp As String = "200", Optional PONumber As String = "")
      Dim throughSP As Boolean = IIf(re.SPLoadID = "", False, True)
      Dim TotalAmount As Decimal = 0
      Dim TotalWeight As Decimal = 0
      Dim xPOStr As String = ""
      Dim nlc As String = vbCrLf
      If throughSP Then
        Dim vr As SIS.VR.vrVehicleRequest = Nothing
        Dim res As New List(Of SIS.VR.vrRequestExecution)
        Dim SizeUnit As String = ""
        Dim WeightUnit As String = ""
        res = SIS.VR.vrRequestExecution.vrRequestExecutionAllGetSPLoadByIDProjectID(re.SPLoadID, ProjectID)
        For Each xre As SIS.VR.vrRequestExecution In res
          'It is Insured, if Execution is created from SP, then there will be only one Request Linked
          'As required by Logistics, there should be separate execution for each request
          vr = SIS.VR.vrVehicleRequest.vrVehicleRequestGetByID(xre.RequestNo)
          If vr Is Nothing Then
            Throw New Exception("Request NOT linked to execution: " & xre.SRNNo)
          End If
          If vr.SizeUnit <> "" Then SizeUnit = vr.FK_VR_VehicleRequest_SizeUnit.Description
          Dim spe As SPApi.SPExecution = New JavaScriptSerializer().Deserialize(vr.SPLoadData, GetType(SPApi.SPExecution))
          Dim sped As SPApi.ExecutionData = spe.resultSet(0)
          WeightUnit = sped.uom
          TotalAmount += xre.EstimatedAmount
          If WeightUnit = "MT" Then
            TotalWeight += (sped.weight * 1000)
          Else
            TotalWeight += sped.weight
          End If
          xPOStr &= nlc & ""
          xPOStr &= nlc & "Vehicle Request No.: " & vr.RequestNo
          xPOStr &= nlc & "Cargo Dimension: " & "L:" & vr.Length & ", W:" & vr.Width & ", H:" & vr.Height & " " & SizeUnit
          If WeightUnit = "MT" Then
            xPOStr &= nlc & "Cargo Weight: " & (sped.weight * 1000) & " Kg" ' & WeightUnit
          Else
            xPOStr &= nlc & "Cargo Weight: " & sped.weight & " Kg" '& WeightUnit
          End If
          xPOStr &= nlc & "From State: " & vr.FromLocation
          xPOStr &= nlc & "Loading Point: "
          xPOStr &= nlc & "=============="
          xPOStr &= nlc & "Supplier: " & vr.SupplierID & "-" & vr.FK_VR_VehicleRequest_SupplierID.Description
          xPOStr &= nlc & vr.SupplierLocation
          xPOStr &= nlc & "Pin Code: " & vr.FromPinCode
          xPOStr &= nlc & ""
          xPOStr &= nlc & ""
          xPOStr &= nlc & "To State: " & vr.ToLocation
          xPOStr &= nlc & "Delivery Location: "
          xPOStr &= nlc & "=================="
          xPOStr &= nlc & vr.DeliveryLocation
          xPOStr &= nlc & "Pin Code: " & vr.ToPinCode
          xPOStr &= nlc & ""
          xPOStr &= nlc & "Contact Details: "
          xPOStr &= nlc & "=================="
          xPOStr &= nlc & "Name: " & vr.SitePersonName
          xPOStr &= nlc & "Phone: " & vr.SitePersonContact
        Next
        'Prefix Text
        Dim tmpStr As String = ""
        tmpStr &= "LUMPSUM LOWEST RATE SETTLED WITH TRANSPORTER FOR TRANSPORTATION OF MATERIAL"
        tmpStr &= nlc & ""
        tmpStr &= nlc & "SP Load ID: " & re.SPLoadID
        tmpStr &= nlc & "Vehicle Type: " & re.FK_VR_RequestExecution_VehicleTypeID.cmba
        tmpStr &= nlc & "Total Cargo Weight: " & TotalWeight & " Kg" '& WeightUnit
        tmpStr &= nlc & "Total Amount [Rs]: " & TotalAmount
        xPOStr = tmpStr & xPOStr
        'Suffix Text
        tmpStr = ""
        tmpStr &= nlc & ""
        tmpStr &= nlc & "RATES ARE INCLUDING ALL STATES RTO PANELTY, CHALLANS, TAXES,DUTIES & WARAI ETC."
        tmpStr &= nlc & "GST SHALL BE DEPOSITED BY ISGEC IN TO GOVERNMENT ACCOUNT AS PER APPLICABLE RATE"
        tmpStr &= nlc & "TDS SHALL BE DEDUCTED AS PER APPLICABLE RATE"
        xPOStr &= tmpStr
        Dim txtNo As Long = CreateText(xPOStr, Comp)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = " delete ttdisg140" & Comp & " where t_load=" & re.ISGECLoadID & " and t_cprj='" & vr.ProjectID & "'"
            Cmd.ExecuteNonQuery()
          End Using
          Dim sql As String = ""
          sql &= " Insert InTo ttdisg140" & Comp
          sql &= " ("
          sql &= " t_load"
          sql &= " ,t_ivrn"
          sql &= " ,t_rqdt"
          sql &= " ,t_vrdt"
          sql &= " ,t_tran"
          sql &= " ,t_tgst"
          sql &= " ,t_cprj"
          sql &= " ,t_pric"
          sql &= " ,t_amnt"
          sql &= " ,t_fcst"
          sql &= " ,t_tcst"
          sql &= " ,t_type"
          sql &= " ,t_wght"
          sql &= " ,t_size"
          sql &= " ,t_novc"
          sql &= " ,t_snam"
          sql &= " ,t_dnam"
          sql &= " ,t_bpid"
          sql &= " ,t_proc"
          sql &= " ,t_orno"
          sql &= " ,t_genp"
          sql &= " ,t_Refcntd"
          sql &= " ,t_Refcntu"
          sql &= " ,t_uoms"
          sql &= " ,t_wunt"
          sql &= " ,t_txta"
          sql &= " )"
          sql &= " values ("
          sql &= "   " & re.ISGECLoadID & ""
          sql &= " ,'" & vr.RequestNo & "'"
          sql &= " ,convert(datetime,'" & re.VehiclePlacedOn & "',103)"
          sql &= " ,convert(datetime,'" & vr.RequestedOn & "',103)"
          sql &= ",'" & re.TransporterID & "'"
          Dim tmpGSTIN As SIS.VR.vrBPGSTIN = SIS.VR.vrBPGSTIN.spmtBPGSTINGetByID(re.TransporterID)
          If tmpGSTIN IsNot Nothing Then
            sql &= ",'" & tmpGSTIN.Description & "'"
          Else
            sql &= ",''"
          End If
          sql &= ",'" & vr.ProjectID & "'"
          sql &= ", " & TotalAmount & ""
          sql &= ", " & TotalAmount
          'sql &= ",'" & vr.FromLocation & "'"
          'sql &= ",'" & vr.ToLocation & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & re.FK_VR_RequestExecution_VehicleTypeID.cmba & "'"
          sql &= ", " & TotalWeight & ""
          sql &= ",'" & "Cargo L:" & vr.Length & ", W:" & vr.Width & ", H:" & vr.Height & "'"
          sql &= ", " & 1 & ""
          'sql &= ",'" & vr.SupplierLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
          'sql &= ",'" & vr.DeliveryLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & vr.SupplierID & "'"
          If PONumber = "" Then
            sql &= ", " & 2 & ""
            sql &= ",'" & "" & "'"
          Else
            sql &= ", " & 1 & ""
            sql &= ",'" & PONumber & "'"
          End If
          sql &= ", " & 1 & "" 'Generate PO=YES
          sql &= ", " & 0 & ""
          sql &= ", " & 0 & ""
          sql &= ",'" & SizeUnit & "'"
          'sql &= ",'" & WeightUnit & "'"
          sql &= ",'Kg'"
          sql &= ", " & txtNo & ""
          sql &= ")"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()
          End Using
        End Using
        '========================
      Else 'Manual NOT through SP
        '========================
        Dim vr As SIS.VR.vrLinkedRequest = Nothing
        Dim Vrs As List(Of SIS.VR.vrLinkedRequest) = SIS.VR.vrLinkedRequest.vrLinkedRequestSelectList(0, 999, "", False, "", re.SRNNo)
        If Vrs.Count <= 0 Then
          Throw New Exception("Request NOT linked to execution:" & re.SRNNo)
        End If
        Dim SizeUnit As String = ""
        Dim WeightUnit As String = ""
        TotalAmount += re.EstimatedAmount
        'PO amount will be wrong, if multiple project request are linked
        'System will create multiple PO, but amount will same in all PO
        'As we do not have request wise estimated amount
        For Each vr In Vrs
          If vr.ProjectID <> ProjectID Then Continue For
          If vr.SizeUnit <> "" Then SizeUnit = vr.FK_VR_VehicleRequest_SizeUnit.Description
          If vr.WeightUnit <> "" Then WeightUnit = vr.FK_VR_VehicleRequest_WeightUnit.Description
          If WeightUnit = "MT" Then
            TotalWeight += (vr.MaterialWeight * 1000)
          Else
            TotalWeight += vr.MaterialWeight
          End If
          xPOStr &= nlc & ""
          xPOStr &= nlc & "Vehicle Request No.: " & vr.RequestNo
          xPOStr &= nlc & "From State: " & vr.FromLocation
          xPOStr &= nlc & "Cargo Dimension: " & "L:" & vr.Length & ", W:" & vr.Width & ", H:" & vr.Height & " " & SizeUnit
          If WeightUnit = "MT" Then
            xPOStr &= nlc & "Cargo Weight: " & (vr.MaterialWeight * 1000) & " Kg" '& WeightUnit 'Weight is converted to Kg
          Else
            xPOStr &= nlc & "Cargo Weight: " & vr.MaterialWeight & " Kg" '& WeightUnit 'Weight is converted to Kg
          End If
          xPOStr &= nlc & "Loading Point: "
          xPOStr &= nlc & "=============="
          xPOStr &= nlc & "Supplier: " & vr.SupplierID & "-" & vr.FK_VR_VehicleRequest_SupplierID.Description
          xPOStr &= nlc & vr.SupplierLocation
          xPOStr &= nlc & "Pin Code: " & vr.FromPinCode
          xPOStr &= nlc & ""
          xPOStr &= nlc & "To State: " & vr.ToLocation
          xPOStr &= nlc & "Delivery Location: "
          xPOStr &= nlc & "=================="
          xPOStr &= nlc & vr.DeliveryLocation
          xPOStr &= nlc & "Pin Code: " & vr.ToPinCode
          xPOStr &= nlc & ""
          xPOStr &= nlc & "Contact Details: "
          xPOStr &= nlc & "=================="
          xPOStr &= nlc & "Name: " & vr.SitePersonName
          xPOStr &= nlc & "Phone: " & vr.SitePersonContact
        Next
        vr = Vrs(0)
        'Prefix Text
        Dim tmpStr As String = ""
        tmpStr &= "LUMPSUM LOWEST RATE SETTLED WITH TRANSPORTER FOR TRANSPORTATION OF MATERIAL"
        tmpStr &= nlc & ""
        tmpStr &= nlc & "SP Load ID: " & re.SPLoadID
        tmpStr &= nlc & "Vehicle Type: " & re.FK_VR_RequestExecution_VehicleTypeID.cmba
        tmpStr &= nlc & "Total Cargo Weight: " & TotalWeight & " Kg" '& WeightUnit
        tmpStr &= nlc & "Total Amount [Rs]: " & TotalAmount
        xPOStr = tmpStr & xPOStr
        'Suffix Text
        tmpStr = ""
        tmpStr &= nlc & ""
        tmpStr &= nlc & "RATES ARE INCLUDING ALL STATES RTO PANELTY, CHALLANS, TAXES,DUTIES & WARAI ETC."
        tmpStr &= nlc & "GST SHALL BE DEPOSITED BY ISGEC IN TO GOVERNMENT ACCOUNT AS PER APPLICABLE RATE"
        tmpStr &= nlc & "TDS SHALL BE DEDUCTED AS PER APPLICABLE RATE"
        xPOStr &= tmpStr
        Dim txtNo As Long = CreateText(xPOStr, Comp)
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Con.Open()
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = " delete ttdisg140" & Comp & " where t_load=" & re.ISGECLoadID & " and t_cprj='" & vr.ProjectID & "'"
            Cmd.ExecuteNonQuery()
          End Using
          Dim sql As String = ""
          sql &= " Insert InTo ttdisg140" & Comp
          sql &= " ("
          sql &= " t_load"
          sql &= " ,t_ivrn"
          sql &= " ,t_rqdt"
          sql &= " ,t_vrdt"
          sql &= " ,t_tran"
          sql &= " ,t_tgst"
          sql &= " ,t_cprj"
          sql &= " ,t_pric"
          sql &= " ,t_amnt"
          sql &= " ,t_fcst"
          sql &= " ,t_tcst"
          sql &= " ,t_type"
          sql &= " ,t_wght"
          sql &= " ,t_size"
          sql &= " ,t_novc"
          sql &= " ,t_snam"
          sql &= " ,t_dnam"
          sql &= " ,t_bpid"
          sql &= " ,t_proc"
          sql &= " ,t_orno"
          sql &= " ,t_genp"
          sql &= " ,t_Refcntd"
          sql &= " ,t_Refcntu"
          sql &= " ,t_uoms"
          sql &= " ,t_wunt"
          sql &= " ,t_txta"
          sql &= " )"
          sql &= " values ("
          sql &= "   " & re.ISGECLoadID & ""
          sql &= " ,'" & vr.RequestNo & "'"
          sql &= " ,convert(datetime,'" & re.VehiclePlacedOn & "',103)"
          sql &= " ,convert(datetime,'" & vr.RequestedOn & "',103)"
          sql &= ",'" & re.TransporterID & "'"
          Dim tmpGSTIN As SIS.VR.vrBPGSTIN = SIS.VR.vrBPGSTIN.spmtBPGSTINGetByID(re.TransporterID)
          If tmpGSTIN IsNot Nothing Then
            sql &= ",'" & tmpGSTIN.Description & "'"
          Else
            sql &= ",''"
          End If
          sql &= ",'" & vr.ProjectID & "'"
          sql &= ", " & TotalAmount & ""
          sql &= ", " & TotalAmount
          'sql &= ",'" & vr.FromLocation & "'"
          'sql &= ",'" & vr.ToLocation & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & re.FK_VR_RequestExecution_VehicleTypeID.cmba & "'"
          sql &= ", " & TotalWeight & ""
          sql &= ",'" & "Cargo L:" & vr.Length & ", W:" & vr.Width & ", H:" & vr.Height & "'"
          sql &= ", " & 1 & ""
          'sql &= ",'" & vr.SupplierLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
          'sql &= ",'" & vr.DeliveryLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & "" & "'"
          sql &= ",'" & vr.SupplierID & "'"
          If PONumber = "" Then
            sql &= ", " & 2 & ""
            sql &= ",'" & "" & "'"
          Else
            sql &= ", " & 1 & ""
            sql &= ",'" & PONumber & "'"
          End If
          sql &= ", " & 1 & "" 'Generate PO=YES
          sql &= ", " & 0 & ""
          sql &= ", " & 0 & ""
          sql &= ",'" & SizeUnit & "'"
          'sql &= ",'" & WeightUnit & "'"
          sql &= ",'Kg'"
          sql &= ", " & txtNo & ""
          sql &= ")"
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()
          End Using
        End Using
      End If
    End Sub
    Public Shared Function CreateText(str As String, Optional Comp As String = "200") As Long
      'Used \ for division to get only Integer part of division
      Dim nlin As Integer = 0
      If str.Length < 240 Then
        nlin = 1
      Else
        nlin = (str.Length \ 240)
        If nlin Mod 240 > 0 Then
          nlin = nlin + 1
        End If
      End If
      Dim txtNo As Long = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Dim sql As String = ""
        sql &= " declare @Return_t_srno int  "
        sql &= " declare @t_user nvarchar(12) = '0340'  "
        sql &= " declare @t_kwd1 nvarchar(20) = 'dmisg140.txta'  "
        sql &= " select @Return_t_srno=max(t_ctxt)+1 from ttttxt001" & Comp
        sql &= " INSERT [ttttxt001" & Comp & "] ([t_ctxt],[t_opwd],[t_txtg],[t_desc],[t_Refcntd],[t_Refcntu]) VALUES (@Return_t_srno,'Notepad','notepad','',0,0 ) "
        sql &= " INSERT [ttttxt002" & Comp & "] ([t_ctxt],[t_clan],[t_kwd1],[t_kwd2],[t_kwd3],[t_kwd4],[t_ludt],[t_user],[t_nlin],[t_Refcntd],[t_Refcntu]) "
        sql &= " VALUES (@Return_t_srno,2,@t_kwd1,'','','',GetDate(),@t_user," & nlin & ",0,0) "
        sql &= " SELECT @Return_t_srno "
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = sql
          txtNo = Cmd.ExecuteScalar()
        End Using
        Dim J As Integer = 0
        For I As Integer = 0 To nlin - 1
          Dim lStr As String = ""
          If I < nlin - 1 Then
            lStr = str.Substring(J, 240)
          Else
            lStr = str.Substring(J)
          End If
          sql = " INSERT [ttttxt010" & Comp & "] ([t_ctxt],[t_clan],[t_seqe],[t_text],[t_Refcntd],[t_Refcntu]) VALUES (" & txtNo & ",2," & I + 1 & ",convert(binary(240),'" & lStr & "'),0,0) "
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = sql
            Cmd.ExecuteNonQuery()
          End Using
          J = J + 240
        Next
      End Using
      Return txtNo
    End Function

    Public Shared Sub InsertData(ed As SPApi.ExecutionData, Optional Comp As String = "200")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Dim sql As String = ""
        sql &= " Insert InTo ttdisg140" & Comp
        sql &= " ("
        sql &= " t_load"
        sql &= " ,t_ivrn"
        sql &= " ,t_rqdt"
        sql &= " ,t_vrdt"
        sql &= " ,t_tran"
        sql &= " ,t_tgst"
        sql &= " ,t_cprj"
        sql &= " ,t_pric"
        sql &= " ,t_amnt"
        sql &= " ,t_fcst"
        sql &= " ,t_tcst"
        sql &= " ,t_type"
        sql &= " ,t_wght"
        sql &= " ,t_size"
        sql &= " ,t_novc"
        sql &= " ,t_snam"
        sql &= " ,t_dnam"
        sql &= " ,t_bpid"
        sql &= " ,t_proc"
        sql &= " ,t_orno"
        sql &= " ,t_genp"
        sql &= " ,t_Refcntd"
        sql &= " ,t_Refcntu"
        sql &= " ,t_uoms"
        sql &= " ,t_wunt"
        sql &= " )"
        sql &= " values ("
        sql &= "   " & ed.loadId & ""
        sql &= " ,'" & ed.RequestNo & "'"
        sql &= " ,convert(datetime,'" & ed.loadingDate & "',103)"
        sql &= " ,convert(datetime,'" & ed.requestedDate & "',103)"
        sql &= ",'" & ed.transporterCode & "'"
        sql &= ",'" & ed.transporterGSTIN & "'"
        sql &= ",'" & ed.projectCode & "'"
        sql &= ", " & ed.amountPerVehicle & ""
        sql &= ", " & ed.totalAmount
        sql &= ",'" & ed.fromState & "'"
        sql &= ",'" & ed.toState & "'"
        sql &= ",'" & ed.VehicleTypeDescription & "'"
        sql &= ", " & ed.weight & ""
        sql &= ",'" & ed.Size & "'"
        sql &= ", " & ed.noOfVechiles & ""
        sql &= ",'" & ed.supplierLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
        sql &= ",'" & ed.deliveryLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
        sql &= ",'" & ed.BPID & "'"
        sql &= ", " & 2 & ""
        sql &= ",'" & "" & "'"
        sql &= ", " & ed.GeneratePO & ""
        sql &= ", " & 0 & ""
        sql &= ", " & 0 & ""
        sql &= ",'" & ed.uom & "'"
        sql &= ",'" & ed.wuom & "'"
        sql &= ")"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = sql
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
    Public Shared Sub UpdateData(ed As SPApi.ExecutionData, Optional Comp As String = "200")
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Dim sql As String = ""
        sql &= " update ttdisg140" & Comp
        sql &= " set t_ivrn = '" & ed.RequestNo & "'"
        sql &= "    ,t_vrdt = convert(datetime,'" & ed.requestedDate & "',103)"
        sql &= "    ,t_rqdt = convert(datetime,'" & ed.loadingDate & "',103)"
        sql &= "    ,t_tran = '" & ed.transporterCode & "'"
        sql &= "    ,t_tgst = '" & ed.transporterGSTIN & "'"
        sql &= "    ,t_cprj = '" & ed.projectCode & "'"
        sql &= "    ,t_pric =  " & ed.amountPerVehicle
        sql &= "    ,t_amnt =  " & ed.totalAmount
        sql &= "    ,t_fcst = '" & ed.fromState & "'"
        sql &= "    ,t_tcst = '" & ed.toState & "'"
        sql &= "    ,t_type = '" & ed.VehicleTypeDescription & "'"
        sql &= "    ,t_wght =  " & ed.weight
        sql &= "    ,t_size = '" & ed.Size & "'"
        sql &= "    ,t_novc =  " & ed.noOfVechiles
        sql &= "    ,t_snam = '" & ed.supplierLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
        sql &= "    ,t_dnam = '" & ed.deliveryLocation.Replace(Chr(13), " ").Replace(Chr(10), " ") & "'"
        sql &= "    ,t_bpid = '" & ed.BPID & "'"
        sql &= "    ,t_genp =  " & ed.GeneratePO
        sql &= "    ,t_uoms = '" & ed.uom & "'"
        sql &= "    ,t_wunt = '" & ed.wuom & "'"
        sql &= " where t_load =" & ed.loadId
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = sql
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
  End Class
  Public Class Transporter
    Public Property carrierName As String = ""
    Public Property carrierBranchName As String = ""
    Public Property carrierLocation As String = ""
    Public Property carrierUsername As String = ""
    Public Property email As String = ""
    Public Property phone As String = ""
    Public Property erpCode As String = ""
  End Class
#End Region

End Class
