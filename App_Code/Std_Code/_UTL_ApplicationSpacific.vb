Imports System.Data.SqlClient
Imports System.Data
Namespace SIS.SYS.Utilities
  Public Class ApplicationSpacific
    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx", "xlxm"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function

    Public Shared cLink As Boolean = False
    Public Shared OnC As Boolean = False
    Public Shared LGMInit As Boolean = False
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 20
        .Session("Redirected") = False
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("FinanceCompany") = "200"
      End With
    End Sub
    Public Shared Sub ApplicationReports(ByVal Context As HttpContext)
      If Not Context.Request.QueryString("ReportName") Is Nothing Then
        Select Case (Context.Request.QueryString("ReportName").ToLower)
          'Case "shnotcompensated"
          '  Dim oRep As RPT_atnSHNotCompensated = New RPT_atnSHNotCompensated(Context)
          '  oRep.GenerateReport()
        End Select
      End If
    End Sub
  End Class
End Namespace
