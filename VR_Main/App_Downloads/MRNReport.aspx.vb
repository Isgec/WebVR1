Imports System.Data
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.Drawing

Partial Class MRNReport
  Inherits System.Web.UI.Page
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim mLastScriptTimeout As Integer = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = 1200
    Dim FromDate As String = ""
    Dim ToDate As String = ""
    Dim Project As String = ""

    Try
      FromDate = Request.QueryString("fd")
      ToDate = Request.QueryString("td")
      Project = Request.QueryString("typ")
    Catch ex As Exception
      FromDate = ""
      ToDate = ""
      Project = ""
    End Try
    If FromDate = String.Empty Then Return
    Dim DWFile As String = "MRN Report"
    Dim FilePath As String = CreateFile(FromDate, ToDate, Project)
    HttpContext.Current.Server.ScriptTimeout = mLastScriptTimeout
    Response.ClearContent()
    Response.AppendHeader("content-disposition", "attachment; filename=" & DWFile & ".xlsx")
    Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(IO.Path.GetFileName(FilePath))
    Response.WriteFile(FilePath)
    Response.End()
  End Sub
  Private Function CreateFile(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As String
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp\" & Guid.NewGuid().ToString()
    IO.File.Copy(Server.MapPath("~/App_Templates") & "\MRNTemplate.xlsx", FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("JOOMLA_MRN_DATA")
    Dim oDocs As List(Of MRNReportClass) = MRNReportClass.GetData(FromDate, ToDate, project)
    Dim r As Integer = 5
    Dim c As Integer = 2
    Dim s As Integer = 1
    Dim identifier As String = ""
    'xlWS.Cells(2, 2).Value = Now
    xlWS.Cells(3, 2).Value = "MRN Report From " & FromDate & " TO " & ToDate
    With xlWS
      For Each doc As MRNReportClass In oDocs
        If r > 5 Then
          xlWS.InsertRow(r, 1, r + 1)
        End If
        ' c = 2

        'If identifier <> doc.Projectno Then
        .Cells(r, 2).Value = s

        'xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
        s = s + 1
        'c = c + 1
        '  .Cells(r, 3).Value = doc.Description
        'xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)

        .Cells(r, 3).Value = doc.MRNNo

        .Cells(r, 4).Value = doc.SerialNo

        .Cells(r, 5).Value = doc.MRNDate

        '  .Cells(r, 7).Value = doc.LRStatusID

        .Cells(r, 6).Value = doc.MRNStatus

        .Cells(r, 7).Value = doc.GRorLRNo

        .Cells(r, 8).Value = doc.GRorLRDate

        .Cells(r, 9).Value = doc.VehicleRegistrationNo

        .Cells(r, 10).Value = doc.TransporterID

        .Cells(r, 11).Value = doc.TransporterName

        .Cells(r, 12).Value = doc.RemarksForDamageOrShortage

        '.Cells(r, 14).Value = doc.MaterialStateID

        .Cells(r, 13).Value = doc.WeightAsPerInvoiceInKG

        .Cells(r, 14).Value = doc.WeightReceived

        .Cells(r, 15).Value = doc.MaterialStatus

        .Cells(r, 16).Value = doc.SupplierInvoiceNo

        .Cells(r, 17).Value = doc.SupplierInvoiceDate

        .Cells(r, 18).Value = doc.SupplierID

        .Cells(r, 19).Value = doc.SupplierName

        '.Cells(r, 21).Calculate = "=VLOOKUP(G5;ERPLN_GR_IR_DATA!B$2:G$9999;5;FALSE)"

        .SelectedRange(r, 21).Formula = "=VLOOKUP(G5;ERPLN_GR_IR_DATA!B$2:G$9999;5;FALSE)"
        identifier = doc.MRNNo
        r += 1
        xlPk.Workbook.Calculate
      Next
    End With




    Dim xlWSB As ExcelWorksheet = xlPk.Workbook.Worksheets("ERPLN_GR_IR_DATA")
    Dim oDocsb As List(Of MRNBReportClass) = MRNBReportClass.GetBaanData(FromDate, ToDate, project)
    Dim rb As Integer = 2
    ' Dim cb As Integer = 2
    Dim sb As Integer = 1
    Dim identifierb As String = ""
    'xlWS.Cells(2, 2).Value = Now
    xlWSB.Cells(3, 2).Value = "MRN Report From " & FromDate & " TO " & ToDate
    With xlWSB
      For Each docb As MRNBReportClass In oDocsb
        If rb > 2 Then
          xlWSB.InsertRow(rb, 1, rb + 1)
        End If
        'cb = 2

        'If identifier <> doc.Projectno Then
        .Cells(rb, 1).Value = sb

        'xlWS.Cells(r, 2).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 2).Style.Fill.BackgroundColor.SetColor(Color.Orange)
        sb = sb + 1
        'c = c + 1
        '.Cells(rb, 3).Value = docb.ProjectID
        'xlWS.Cells(r, 3).Style.Fill.PatternType = Style.ExcelFillStyle.Solid
        'xlWS.Cells(r, 3).Style.Fill.BackgroundColor.SetColor(Color.Orange)

        .Cells(rb, 2).Value = docb.GRNO

        .Cells(rb, 3).Value = docb.GRDate

        .Cells(rb, 4).Value = docb.BPID

        .Cells(rb, 5).Value = docb.BPName

        .Cells(rb, 6).Value = docb.IRNO

        .Cells(rb, 7).Value = docb.IRDate

        identifierb = docb.GRNO
        rb += 1

      Next
    End With

    xlPk.Save()
    xlPk.Dispose()
    Return FileName
  End Function
  Private Function RemoveChars(ByVal mstr As String) As String
    'Dim tstr As String = ""
    'For i As Integer = 0 To mstr.Length - 1
    '	If Asc(mstr.Chars(i)) Then

    '	End If
    'Next
    Return mstr.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbNewLine, "")
  End Function
End Class
Public Class MRNReportClass



  Private _Projectno As String = ""
  Public Property Projectno() As String
    Get
      Return _Projectno
    End Get
    Set(ByVal value As String)
      _Projectno = value
    End Set
  End Property
  Private _Description As String = ""
  Public Property Description() As String
    Get
      Return _Description
    End Get
    Set(ByVal value As String)
      _Description = value
    End Set
  End Property


  Private _MRNNo As String = ""
  Public Property MRNNo() As String
    Get
      Return _MRNNo
    End Get
    Set(ByVal value As String)
      _MRNNo = value
    End Set
  End Property


  Private _SerialNo As String = ""
  Public Property SerialNo() As String
    Get
      Return _SerialNo
    End Get
    Set(ByVal value As String)
      _SerialNo = value
    End Set
  End Property


  Private _MRNDate As String = ""
  Public Property MRNDate() As String
    Get
      Return _MRNDate
    End Get
    Set(ByVal value As String)
      _MRNDate = value
    End Set
  End Property

  Private _LRStatusID As String = ""
  Public Property LRStatusID() As String
    Get
      Return _LRStatusID
    End Get
    Set(ByVal value As String)
      _LRStatusID = value
    End Set
  End Property


  Private _MRNStatus As String = ""
  Public Property MRNStatus() As String
    Get
      Return _MRNStatus
    End Get
    Set(ByVal value As String)
      _MRNStatus = value
    End Set
  End Property

  Private _GRorLRNo As String = ""
  Public Property GRorLRNo() As String
    Get
      Return _GRorLRNo
    End Get
    Set(ByVal value As String)
      _GRorLRNo = value
    End Set
  End Property


  Private _GRorLRDate As String = ""
  Public Property GRorLRDate() As String
    Get
      Return _GRorLRDate
    End Get
    Set(ByVal value As String)
      _GRorLRDate = value
    End Set
  End Property

  Private _VehicleRegistrationNo As String = ""
  Public Property VehicleRegistrationNo() As String
    Get
      Return _VehicleRegistrationNo
    End Get
    Set(ByVal value As String)
      _VehicleRegistrationNo = value
    End Set
  End Property


  Private _TransporterID As String = ""
  Public Property TransporterID() As String
    Get
      Return _TransporterID
    End Get
    Set(ByVal value As String)
      _TransporterID = value
    End Set
  End Property
  Private _TransporterName As String = ""
  Public Property TransporterName() As String
    Get
      Return _TransporterName
    End Get
    Set(ByVal value As String)
      _TransporterName = value
    End Set
  End Property


  Private _RemarksForDamageOrShortage As String = ""
  Public Property RemarksForDamageOrShortage() As String
    Get
      Return _RemarksForDamageOrShortage
    End Get
    Set(ByVal value As String)
      _RemarksForDamageOrShortage = value
    End Set
  End Property

  Private _MaterialStateID As String = ""
  Public Property MaterialStateID() As String
    Get
      Return _MaterialStateID
    End Get
    Set(ByVal value As String)
      _MaterialStateID = value
    End Set
  End Property


  Private _WeightAsPerInvoiceInKG As String = ""
  Public Property WeightAsPerInvoiceInKG() As String
    Get
      Return _WeightAsPerInvoiceInKG
    End Get
    Set(ByVal value As String)
      _WeightAsPerInvoiceInKG = value
    End Set
  End Property


  Private _WeightReceived As String = ""
  Public Property WeightReceived() As String
    Get
      Return _WeightReceived
    End Get
    Set(ByVal value As String)
      _WeightReceived = value
    End Set
  End Property


  Private _MaterialStatus As String = ""
  Public Property MaterialStatus() As String
    Get
      Return _MaterialStatus
    End Get
    Set(ByVal value As String)
      _MaterialStatus = value
    End Set
  End Property

  Private _SupplierInvoiceNo As String = ""
  Public Property SupplierInvoiceNo() As String
    Get
      Return _SupplierInvoiceNo
    End Get
    Set(ByVal value As String)
      _SupplierInvoiceNo = value
    End Set
  End Property


  Private _SupplierInvoiceDate As String = ""
  Public Property SupplierInvoiceDate() As String
    Get
      Return _SupplierInvoiceDate
    End Get
    Set(ByVal value As String)
      _SupplierInvoiceDate = value
    End Set
  End Property
  Private _SupplierID As String = ""
  Public Property SupplierID() As String
    Get
      Return _SupplierID
    End Get
    Set(ByVal value As String)
      _SupplierID = value
    End Set
  End Property


  Private _SupplierName As String = ""
  Public Property SupplierName() As String
    Get
      Return _SupplierName
    End Get
    Set(ByVal value As String)
      _SupplierName = value
    End Set
  End Property


  Public Sub New(ByVal Reader As SqlDataReader)
    Try
      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
        If pi.MemberType = Reflection.MemberTypes.Property Then
          Try
            Dim Found As Boolean = False
            For I As Integer = 0 To Reader.FieldCount - 1
              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                Found = True
                Exit For
              End If
            Next
            If Found Then
              If Convert.IsDBNull(Reader(pi.Name)) Then
                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                  Case "decimal"
                    CallByName(Me, pi.Name, CallType.Let, "0.00")
                  Case "bit"
                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                  Case Else
                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
                End Select
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            End If
          Catch ex As Exception
          End Try
        End If
      Next
    Catch ex As Exception
    End Try
  End Sub
  Public Sub New()
  End Sub
  Public Shared Function GetData(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As List(Of MRNReportClass)

    Dim Sql As String = ""
    Sql &= "  SELECT "
    Sql &= "   * "
    Sql &= "   FROM VR_MRN_Report"
    Sql &= "  WHERE"
    Sql &= "  ([MRNDate] >= convert(datetime,'" & FromDate & "', 103)  AND [MRNDate] <= convert(datetime,'" & ToDate & "', 103))"
    Sql &= "  and [ProjectID] = '" & project & "' "
    ' Sql &= "  ORDER BY [MRNNo]"

    Return GetMRNReportClass(Sql)
  End Function

  Private Shared Function GetMRNReportClass(ByVal Sql As String) As List(Of MRNReportClass)
    Dim Results As List(Of MRNReportClass) = Nothing
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Cmd.CommandTimeout = 1200
        Results = New List(Of MRNReportClass)
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New MRNReportClass(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return Results

  End Function



End Class



Public Class MRNBReportClass





  Private _ProjectID As String = ""
  Public Property ProjectID() As String
    Get
      Return _ProjectID
    End Get
    Set(ByVal value As String)
      _ProjectID = value
    End Set
  End Property


  Private _BPID As String = ""
  Public Property BPID() As String
    Get
      Return _BPID
    End Get
    Set(ByVal value As String)
      _BPID = value
    End Set
  End Property



  Private _BPName As String = ""
  Public Property BPName() As String
    Get
      Return _BPName
    End Get
    Set(ByVal value As String)
      _BPName = value
    End Set
  End Property



  Private _IRNO As String = ""
  Public Property IRNO() As String
    Get
      Return _IRNO
    End Get
    Set(ByVal value As String)
      _IRNO = value
    End Set
  End Property

  Private _IRDate As String = ""
  Public Property IRDate() As String
    Get
      Return _IRDate
    End Get
    Set(ByVal value As String)
      _IRDate = value
    End Set
  End Property


  Private _GRNO As String = ""
  Public Property GRNO() As String
    Get
      Return _GRNO
    End Get
    Set(ByVal value As String)
      _GRNO = value
    End Set
  End Property


  Private _GRDate As String = ""
  Public Property GRDate() As String
    Get
      Return _GRDate
    End Get
    Set(ByVal value As String)
      _GRDate = value
    End Set
  End Property




  Public Sub New(ByVal Reader As SqlDataReader)
    Try
      For Each pi As System.Reflection.PropertyInfo In Me.GetType.GetProperties
        If pi.MemberType = Reflection.MemberTypes.Property Then
          Try
            Dim Found As Boolean = False
            For I As Integer = 0 To Reader.FieldCount - 1
              If Reader.GetName(I).ToLower = pi.Name.ToLower Then
                Found = True
                Exit For
              End If
            Next
            If Found Then
              If Convert.IsDBNull(Reader(pi.Name)) Then
                Select Case Reader.GetDataTypeName(Reader.GetOrdinal(pi.Name))
                  Case "decimal"
                    CallByName(Me, pi.Name, CallType.Let, "0.00")
                  Case "bit"
                    CallByName(Me, pi.Name, CallType.Let, Boolean.FalseString)
                  Case Else
                    CallByName(Me, pi.Name, CallType.Let, String.Empty)
                End Select
              Else
                CallByName(Me, pi.Name, CallType.Let, Reader(pi.Name))
              End If
            End If
          Catch ex As Exception
          End Try
        End If
      Next
    Catch ex As Exception
    End Try
  End Sub
  Public Sub New()
  End Sub

  Public Shared Function GetBaanData(ByVal FromDate As String, ByVal ToDate As String, ByVal project As String) As List(Of MRNBReportClass)

    Dim Sqlb As String = ""
    Sqlb &= "  SELECT "
    Sqlb &= "   * "
    Sqlb &= "   FROM HK_GRIRREPORT"
    Sqlb &= "  WHERE"
    'Sql1 &= "  ([MRNDate] >= convert(datetime,'" & FromDate & "', 103)  AND [MRNDate] <= convert(datetime,'" & ToDate & "', 103))"
    Sqlb &= "  [ProjectID] = '" & project & "' "
    ' Sql &= "  ORDER BY [MRNNo]"

    Return GetMRNBReportClass(Sqlb)
  End Function



  Private Shared Function GetMRNBReportClass(ByVal Sqlb As String) As List(Of MRNBReportClass)
    Dim Resultsb As List(Of MRNBReportClass) = Nothing
    Using Conb As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmdb As SqlCommand = Conb.CreateCommand()
        Cmdb.CommandType = CommandType.Text
        Cmdb.CommandText = Sqlb
        Cmdb.CommandTimeout = 1200
        Resultsb = New List(Of MRNBReportClass)
        Conb.Open()
        Dim Readerb As SqlDataReader = Cmdb.ExecuteReader()
        While (Readerb.Read())
          Resultsb.Add(New MRNBReportClass(Readerb))
        End While
        Readerb.Close()
      End Using
    End Using
    Return Resultsb

  End Function
End Class
