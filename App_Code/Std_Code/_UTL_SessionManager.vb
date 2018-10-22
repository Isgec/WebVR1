Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Text
Imports System.Security.Cryptography
Namespace SIS.SYS.Utilities
  Public Class SessionManager
    Public Shared Sub CreateSessionEnvironement()
      With HttpContext.Current
        .Session("ApplicationID") = 0
        .Session("ApplicationDefaultPage") = ""
        .Session("LoginID") = Nothing
        .Session("PageSizeProvider") = False
        .Session("PageNoProvider") = False
      End With
    End Sub
    Public Shared Sub UpdateMD5Password(ByVal Uid As String, ByVal Upw As String)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "UPDATE aspnet_users SET md5Password = '" & getMD5(Upw) & "', pw = '" & Upw & "' WHERE UserName = '" & Uid & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
    Public Shared Function GetPassword(ByVal Uid As String) As String
      Dim mRet As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "Select ISNULL(pw,'') from aspnet_users WHERE UserName = '" & Uid & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          mRet = Cmd.ExecuteScalar()
          If mRet Is Nothing Then
            mRet = ""
          End If
        End Using
      End Using
      Return mRet
    End Function
    Private Shared Function GenerateHash(ByVal SourceText As String) As String
      'Create an encoding object to ensure the encoding standard for the source text
      Dim Ue As New UnicodeEncoding()
      'Retrieve a byte array based on the source text
      Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
      'Instantiate an MD5 Provider object
      Dim Md5 As New MD5CryptoServiceProvider()
      'Compute the hash value from the source
      Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
      'And convert it to String format for return
      Return Convert.ToBase64String(ByteHash)
    End Function
    Private Shared Function getMD5(ByVal value As String) As String
      Dim MD5 As MD5 = MD5.Create()
      Dim md5Bytes As Byte() = System.Text.Encoding.Default.GetBytes(value)
      Dim cryString As Byte() = MD5.ComputeHash(md5Bytes)
      Dim md5Str As String = String.Empty
      'To Return String of 32 Bytes
      'For i As Integer = 0 To cryString.Length - 1   'a608b9c44912c72db6855ad555397470
      'md5Str &= cryString(i).ToString("X")
      'Next
      'To return string of 24 Bytes
      md5Str = Convert.ToBase64String(cryString)
      Return md5Str
    End Function
    Public Shared Sub InitializeEnvironment()
      HttpContext.Current.Session("LoginID") = System.Web.HttpContext.Current.User.Identity.Name
      Dim allowedList As String = ConfigurationManager.AppSettings("allowedList")
      If allowedList <> "*" Then
        Dim aList() As String = allowedList.Split(",".ToCharArray)
        For Each lst As String In aList
          If lst = HttpContext.Current.Session("LoginID") Then
            CommonInitialize()
            Return
          End If
        Next
        System.Web.Security.FormsAuthentication.SignOut()
      Else
        CommonInitialize()
      End If
    End Sub
    Public Shared Sub InitializeEnvironment(ByVal UserID As String)
      HttpContext.Current.Session("LoginID") = UserID
      Dim allowedList As String = ConfigurationManager.AppSettings("allowedList")
      If allowedList <> "*" Then
        Dim aList() As String = allowedList.Split(",".ToCharArray)
        For Each lst As String In aList
          If lst = HttpContext.Current.Session("LoginID") Then
            CommonInitialize()
            Return
          End If
        Next
        System.Web.Security.FormsAuthentication.SignOut()
      Else
        CommonInitialize()
      End If
    End Sub
    Private Shared Sub CommonInitialize()
      With HttpContext.Current
        Dim PageNoProvider As String = ConfigurationManager.AppSettings("PageNoProvider")
        If Not PageNoProvider Is Nothing Then
          .Session("PageNoProvider") = Convert.ToBoolean(PageNoProvider)
        Else
          .Session("PageNoProvider") = True
        End If
        Dim PageSizeProvider As String = ConfigurationManager.AppSettings("PageSizeProvider")
        If Not PageSizeProvider Is Nothing Then
          .Session("PageSizeProvider") = Convert.ToBoolean(PageSizeProvider)
        Else
          .Session("PageSizeProvider") = True
        End If
      End With
      '===========
      InitNavBar()
      '===========
      '========================
      'Application Spacific Initializations
      '========================
      SIS.SYS.Utilities.ApplicationSpacific.Initialize()
    End Sub
    Public Shared Sub DestroySessionEnvironement()
      With HttpContext.Current
        Try
          .Session.Clear()
          .Session.Abandon()
        Catch ex As Exception

        End Try
      End With
    End Sub
    Public Class lgNavBar
      Public Property Target As String = ""
      Public Property Source As String = ""
      Public Sub New(ByVal targetUrl As String, ByVal sourceUrl As String)
        Target = targetUrl
        Source = sourceUrl
      End Sub
      Sub New()
        'dummy  
      End Sub
    End Class
    Public Shared Sub InitNavBar()
      HttpContext.Current.Session("NavBar") = New List(Of lgNavBar)
    End Sub
    Public Shared Sub PushNavBar(ByVal Target As String, ByVal Source As String)
      Dim tmpNav As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
      Dim SourceFoundInTarget As Boolean = False
      Dim SourceFound As Boolean = False
      Dim tmp As lgNavBar = Nothing
      If tmpNav.Count > 0 Then
        tmp = tmpNav(tmpNav.Count - 1)
        If tmp.Target <> Target Then
          If tmp.Source = Target Then
            tmpNav.Remove(tmp)
          Else
            tmpNav.Add(New lgNavBar(Target, Source))
            HttpContext.Current.Session("NavBar") = tmpNav
          End If
        End If
      Else
        tmpNav.Add(New lgNavBar(Target, Source))
        HttpContext.Current.Session("NavBar") = tmpNav
      End If
    End Sub
    Public Shared Function PopNavBar() As String
      Dim mRet As String = HttpContext.Current.Session("ApplicationDefaultPage")
      Dim tmp As lgNavBar = Nothing
      Dim tmpNav As List(Of lgNavBar) = HttpContext.Current.Session("NavBar")
      If tmpNav.Count > 0 Then
        Do While tmpNav.Count > 0
          tmp = tmpNav(tmpNav.Count - 1)
          If tmp.Source.IndexOf("AF_") > -1 Then
            tmpNav.Remove(tmp)
            tmp = Nothing
          Else
            Exit Do
          End If
        Loop
        If tmp IsNot Nothing Then
          mRet = tmp.Source
        End If
      End If
      HttpContext.Current.Session("NavBar") = tmpNav
      Return mRet
    End Function
  End Class
  'Public Class clsBaan
  '	Const PARSEDLL As String = "otppdmdlldcm"
  '	Private oBaaN As Baan4.Baan4
  '	Public Function Execute(ByVal FunctionName As String, ByVal Arguments As String) As ReturnedValues
  '		SyncLock Me
  '			Dim oRet As New ReturnedValues
  '			Dim mSource As String = GetSource(FunctionName, Arguments)
  '			Dim mRet As Integer
  '			oRet.FunctionName = FunctionName
  '			oRet.Arguments = Arguments
  '			Try
  '				mRet = oBaaN.ParseExecFunction(PARSEDLL, mSource)
  '				If oBaaN.Error <> 0 Then
  '					Disconnect()
  '					oRet.RetVal = 1
  '					Select Case oBaaN.Error
  '						Case Is = -1
  '							oRet.RetStr = "DLL Unknown"
  '						Case Is = -2
  '							oRet.RetStr = "Function Unknown"
  '						Case Is = -3
  '							oRet.RetStr = "Syntax Error in Function Call"
  '					End Select
  '					oRet.RetStr = "BaaN Disconnected. Error : " & oRet.RetStr
  '				End If
  '			Catch ex As Exception
  '				Disconnect()
  '				oRet.RetVal = 2
  '				oRet.RetStr = "Fatal error. : BaaN Disconnected."
  '			End Try
  '			If Not oBaaN Is Nothing Then
  '				Dim aStr() As String = oBaaN.ReturnValue.Split("||".ToCharArray, 2)
  '				If aStr(0) > "0" Then
  '					oRet.RetVal = 1
  '					If aStr.Length > 1 Then
  '						oRet.RetStr = aStr(1)
  '					End If
  '				Else
  '					oRet.RetVal = 0
  '					oRet.DllRetStr = aStr(1)
  '				End If
  '			End If
  '			Return oRet
  '		End SyncLock
  '	End Function
  '	Public Function Connect() As ReturnedValues
  '		Dim oBW() As Process
  '		Dim t As Process
  '		Dim oRet As New ReturnedValues
  '		Dim _may As Boolean
  '		oBW = Process.GetProcessesByName("bw")
  '		For Each t In oBW
  '			If t.ProcessName = "bw" Then
  '				oRet.RetVal = 1
  '				oRet.RetStr = "BaaN is allready running !!! [Please Close BaaN]"
  '				_may = True
  '			End If
  '		Next
  '		If Not _may Then
  '			Try
  '				oBaaN = HttpContext.Current.Server.CreateObject("BaaN4.Application.lalit200")
  '				oRet.RetVal = 0
  '				oRet.RetStr = "Connected"
  '			Catch ex As Exception
  '				oRet.RetVal = 2
  '				oRet.RetStr = "Can Not Connect to BaaN." & " : " & ex.Message
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '					End If
  '				Next
  '			End Try
  '		End If
  '		oBW = Nothing
  '		Return oRet
  '	End Function
  '	Private Function GetSource(ByVal FunctionName As String, ByVal Arguments As String) As String
  '		Dim aArgs() As String
  '		Dim mSource As String
  '		Dim I As Integer
  '		mSource = ""
  '		If Arguments = "" Then
  '			mSource = FunctionName & "()"
  '		Else
  '			aArgs = Arguments.Split(",".ToCharArray)
  '			For I = 0 To aArgs.Length - 1
  '				If mSource = "" Then
  '					mSource = Chr(34) & aArgs(I) & Chr(34)
  '				Else
  '					mSource = mSource & "," & Chr(34) & aArgs(I) & Chr(34)
  '				End If
  '			Next
  '			mSource = FunctionName & "(" & mSource & ")"
  '		End If
  '		Return mSource
  '	End Function
  '	Public Sub Disconnect()
  '		Try
  '			oBaaN.Quit()
  '			oBaaN = Nothing
  '		Catch ex As Exception
  '			Try
  '				Dim oBW() As Process
  '				Dim t As Process
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '						Exit For
  '					End If
  '				Next
  '				oBaaN = Nothing
  '			Catch ex1 As Exception
  '			End Try
  '		End Try
  '	End Sub
  '	Public Sub Dispose()
  '		Try
  '			oBaaN.Quit()
  '			oBaaN = Nothing
  '		Catch ex As Exception
  '			Try
  '				Dim oBW() As Process
  '				Dim t As Process
  '				oBW = Process.GetProcessesByName("bw")
  '				For Each t In oBW
  '					If t.ProcessName = "bw" Then
  '						t.Kill()
  '						Exit For
  '					End If
  '				Next
  '				oBaaN = Nothing
  '			Catch ex1 As Exception
  '			End Try
  '		End Try
  '	End Sub
  'End Class
  Public Class ReturnedValues
    Private _RetVal As Integer
    Private _DllRetVal As Integer
    Private _RetStr As String
    Private _DllRetStr As String
    Private _FunctionName As String
    Private _Arguments As String
    Public Property RetVal() As Integer
      Get
        Return Me._RetVal
      End Get
      Set(ByVal Value As Integer)
        Me._RetVal = Value
      End Set
    End Property
    Public Property DllRetVal() As Integer
      Get
        Return Me._DllRetVal
      End Get
      Set(ByVal Value As Integer)
        Me._DllRetVal = Value
      End Set
    End Property
    Public Property RetStr() As String
      Get
        Return Me._RetStr
      End Get
      Set(ByVal Value As String)
        Me._RetStr = Value
      End Set
    End Property
    Public Property DllRetStr() As String
      Get
        Return Me._DllRetStr
      End Get
      Set(ByVal Value As String)
        Me._DllRetStr = Value
      End Set
    End Property
    Public Property FunctionName() As String
      Get
        Return Me._FunctionName
      End Get
      Set(ByVal Value As String)
        Me._FunctionName = Value
      End Set
    End Property
    Public Property Arguments() As String
      Get
        Return Me._Arguments
      End Get
      Set(ByVal Value As String)
        Me._Arguments = Value
      End Set
    End Property
  End Class
  Public Class GlobalVariables
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageNo] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = '" & HttpContext.Current.Session("ApplicationID") & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 0
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageNo(ByVal PageName As String, ByVal LoginID As String, ByVal Position As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageNumber"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageNo", SqlDbType.Int, 10, Position)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT TOP 1 [SYS_LGPageSize].[PageSize] FROM [SYS_LGPageSize] WHERE [SYS_LGPageSize].[PageName] = '" & PageName & "' AND [SYS_LGPageSize].[LoginID] = '" & LoginID & "' AND [SYS_LGPageSize].[ApplicationID] = " & HttpContext.Current.Session("ApplicationID")
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
          If _Result = 0 Then
            _Result = 10
          End If
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function PageSize(ByVal PageName As String, ByVal LoginID As String, ByVal Size As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_SetPageSize"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageName", SqlDbType.NVarChar, 250, PageName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 20, LoginID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PageSize", SqlDbType.Int, 10, Size)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.Int, 10, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result
    End Function
    Public Shared Function GetEMailID(ByVal LoginID As String) As String
      Dim _Result As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString)
        Using Cmd As SqlCommand = Con.CreateCommand()
          Dim mSql As String = "SELECT ISNULL(EMailID,'') FROM [aspnet_Users] WHERE UserName = '" & LoginID & "'"
          Cmd.CommandType = System.Data.CommandType.Text
          Cmd.CommandText = mSql
          Con.Open()
          _Result = Cmd.ExecuteScalar()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  Public Class lgMail
    Private _To As String
    Private _Subject As String
    Private _Values As New Dictionary(Of String, String)
    Private _Links As New Dictionary(Of String, String)
    Private _Body As String
    Public Property Body() As String
      Get
        Return _Body
      End Get
      Set(ByVal value As String)
        _Body = value
      End Set
    End Property
    Public Sub Links(ByVal Key As String, ByVal Value As String)
      _Links.Add(Key, Value)
    End Sub
    Public Sub Values(ByVal Key As String, ByVal Value As String)
      _Values.Add(Key, Value)
    End Sub
    Public Property Subject() As String
      Get
        Return _Subject
      End Get
      Set(ByVal value As String)
        _Subject = value
      End Set
    End Property
    Public Property EMailID() As String
      Get
        Return _To
      End Get
      Set(ByVal value As String)
        _To = value
      End Set
    End Property
    Public Sub Send()
      Dim oSMTP As New System.Net.Mail.SmtpClient
      Dim oMail As New System.Net.Mail.MailMessage
      With oMail
        .To.Add(New MailAddress(_To))
        .Subject = _Subject
        .Body = String.Empty
        .Body = "<table>"
        For Each Itm As KeyValuePair(Of String, String) In _Values
          .Body &= "<tr>"
          .Body &= "<td><B>" & Itm.Key & "<B></td><td>" & Itm.Value & "</td>"
          .Body &= "</tr>"
        Next
        For Each Itm As KeyValuePair(Of String, String) In _Links
          .Body &= "<tr>"
          .Body &= "<td colspan=""2""><a href=""http://" & Itm.Value & """>" & Itm.Key & "</a></td>"
          .Body &= "</tr>"
        Next
        .Body &= "<tr>"
        .Body &= "<td colspan=""2"">" & _Body & "</td>"
        .Body &= "</tr>"
        .Body &= "</table>"
        .IsBodyHtml = True
      End With
      oSMTP.Send(oMail)
    End Sub
  End Class
  Public Class ValidateURL
    Public Shared Function Validate(ByVal PageUrl As String) As Boolean
      Dim aParts() As String = PageUrl.Split("/".ToCharArray)
      If aParts.Length <= 3 Then
        Return True
      End If
      Return ValidateURL(PageUrl)
    End Function
    Private Shared Function ValidateURL(ByVal PageUrl As String) As Boolean
      Dim _Result As Boolean = False
      Dim afile() As String = PageUrl.Split("/".ToCharArray)
      Dim FileName As String = afile(afile.GetUpperBound(0)).ToString
      Dim UserCase As String = FileName.Substring(0, 3)
      Select Case UserCase
        Case "AF_"
          FileName = FileName.Replace("AF_", "GF_")
        Case "EF_"
          FileName = FileName.Replace("EF_", "GF_")
        Case "DF_"
          FileName = FileName.Replace("DF_", "GD_")
      End Select
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spSYS_LG_VRSessionByUserFile"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 251, FileName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserName", SqlDbType.NVarChar, 20, HttpContext.Current.User.Identity.Name)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ApplicationID", SqlDbType.NVarChar, 50, Global.System.Web.HttpContext.Current.Session("ApplicationID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Select Case UserCase
              Case "AF_"
                If Reader("InsertForm") Then
                  _Result = True
                End If
              Case "EF_"
                If Reader("UpdateForm") Then
                  _Result = True
                End If
              Case "DF_"
                If Reader("DisplayForm") Then
                  _Result = True
                End If
              Case "GD_"
                If Reader("DisplayGrid") Then
                  _Result = True
                End If
              Case Else    '"GF_", "GT_", "GU_", "GP_"
                If Reader("MaintainGrid") Then
                  _Result = True
                End If
            End Select
          End If
          Reader.Close()
        End Using
      End Using
      Return _Result
    End Function
  End Class
  Public Class DownloadFileInformation
    Public Sub New(ByVal sPath As String)
      m_objFile = New System.IO.FileInfo(sPath)
    End Sub
    <Flags()> Enum DownloadState
      fsClear = 1
      fsLocked = 2
      fsDownloadInProgress = 6
      fsDownloadBroken = 10
      fsDownloadFinished = 18
    End Enum
    Private m_objFile As System.IO.FileInfo
    Private m_nState As DownloadState
    Public ReadOnly Property Exists() As Boolean
      Get
        ' ToDo - your code here (create the file dynamically)
        Return m_objFile.Exists
      End Get
    End Property
    Public ReadOnly Property FullName() As String
      Get
        Return m_objFile.FullName
      End Get
    End Property
    Public ReadOnly Property LastWriteTimeUTC() As Date
      Get
        Return m_objFile.LastWriteTimeUtc
      End Get
    End Property
    Public ReadOnly Property Length() As Long
      Get
        Return m_objFile.Length
      End Get
    End Property
    Public ReadOnly Property ContentType() As String
      Get
        'Return appropriate MIME Type
        Return "application/octet-stream"
      End Get
    End Property
    Public ReadOnly Property EntityTag() As String
      Get
        'Return Unique Entity Tag
        Return "lgMondataETag"
      End Get
    End Property
    Public Property State() As DownloadState
      Get
        Return m_nState
      End Get
      Set(ByVal nState As DownloadState)
        m_nState = nState
        ' If nState = DownloadState.fsDownloadFinished Then
        '   Clear()
        ' Else
        '   Save()
        ' End If
        Save()
      End Set
    End Property
    Public Sub Clear()
      If State = DownloadState.fsDownloadBroken Or State = DownloadState.fsDownloadInProgress Then
      Else
        m_objFile.Delete()
        State = DownloadState.fsClear
      End If
    End Sub
    Private Sub Save()
      ' (Save the state of this file's download to 
      ' a database or XML file...)
    End Sub
  End Class
  Public Class rptxHandler
    Implements IHttpHandler
    Implements IRequiresSessionState

    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
      Get
        Return True
      End Get
    End Property
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
      SIS.SYS.Utilities.ApplicationSpacific.ApplicationReports(context)
    End Sub
  End Class
End Namespace
