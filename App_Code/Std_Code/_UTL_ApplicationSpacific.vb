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
        .Session("FinYear") = ReadActiveFinYear

      End With
    End Sub
    Public Shared ReadOnly Property FinYearStartDate() As String
      Get
        Dim _Result As DateTime
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[StartDate] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result.ToString("dd/MM/yyyy")
      End Get
    End Property
    Public Shared ReadOnly Property FinYearEndDate() As String
      Get
        Dim _Result As DateTime
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[EndDate] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result.ToString("dd/MM/yyyy")
      End Get
    End Property
    Public Shared ReadOnly Property ReadActiveFinYear() As Integer
      Get
        Dim _Result As Integer = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
          Using Cmd As SqlCommand = Con.CreateCommand()
            Dim mSql As String = "SELECT TOP 1 [ATN_FinYear].[FinYear] FROM [ATN_FinYear] WHERE [ATN_FinYear].[Active] = 1"
            Cmd.CommandType = System.Data.CommandType.Text
            Cmd.CommandText = mSql
            Con.Open()
            _Result = Cmd.ExecuteScalar()
          End Using
        End Using
        Return _Result
      End Get
    End Property
    Public Shared ReadOnly Property ActiveFinYear() As Integer
      Get
        Return Convert.ToInt32(HttpContext.Current.Session("FinYear"))
      End Get
    End Property
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
