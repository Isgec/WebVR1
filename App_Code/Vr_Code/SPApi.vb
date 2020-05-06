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
      url = "https://demo.superprocure.com/sp/tms/addCarrier"
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
      url = "https://demo.superprocure.com/sp/requisition/createMemo"
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


  Public Shared Function GetSPExecution(SPRequestID As String, ByRef jsonStr As String) As SPApi.SPExecution
    Dim url As String = ""
    If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
      url = "https://app.superprocure.com/sp/requisition/getAllotmentDetails?reqId=" & SPRequestID
    Else
      url = "https://demo.superprocure.com/sp/requisition/getAllotmentDetails?reqId=" & SPRequestID
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
      url = "https://demo.superprocure.com/sp/requisition/createRequisitionForISGEC"
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
      .Method = method
      .ContentType = "application/json"
      .Accept = "*/*"
      .CachePolicy = New Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
      '.Headers.Add("mode", "no-cors")
      .Headers.Add("ContentType", "application/json")
      If Convert.ToBoolean(ConfigurationManager.AppSettings("SPLive")) Then
        .Headers.Add("Authorization", "Basic ODczNjo4NmUwY2M3NTE2MjhhN2NjMTFmNDNlMDJhNjQ4ODRjZQ==")
        '.Headers.Add("Authorization", "Basic ODc0Mjo4MzE0NmIzNWNiYzhjZjRiZTRlYmM4NmE2NmZjNDkzMg==")
      Else
        .Headers.Add("Authorization", "Basic MjIyNTphYTJiNzNhNGEyY2U3YmVmOWIzMjU0OTdmNzQzODExYw==")
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
    Public Shared Function GetByID(LoadID As Integer, Optional Comp As String = "200") As SPApi.POData
      Dim mRet As SPApi.POData = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Select * from ttdisg140" & Comp & " where t_load=" & LoadID
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          If rd.Read Then
            mRet = New SPApi.POData(rd)
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UpdateGeneratePO(LoadID As Integer, Optional Comp As String = "200") As Boolean
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
        sql &= ",'" & ed.supplierLocation & "'"
        sql &= ",'" & ed.deliveryLocation & "'"
        sql &= ",'" & ed.BPID & "'"
        sql &= ", " & 2 & ""
        sql &= ",'" & "" & "'"
        sql &= ", " & ed.GeneratePO & ""
        sql &= ", " & 0 & ""
        sql &= ", " & 0 & ""
        sql &= ",'" & ed.uom & "'"
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
        sql &= "    ,t_snam = '" & ed.supplierLocation & "'"
        sql &= "    ,t_dnam = '" & ed.deliveryLocation & "'"
        sql &= "    ,t_bpid = '" & ed.BPID & "'"
        sql &= "    ,t_genp =  " & ed.GeneratePO
        sql &= "    ,t_uoms = '" & ed.uom & "'"
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
