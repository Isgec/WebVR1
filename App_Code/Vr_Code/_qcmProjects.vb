Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.QCM
  <DataObject()> _
  Partial Public Class qcmProjects
    Private Shared _RecordCount As Integer
    Private _ProjectID As String = ""
    Private _Description As String = ""
    Private _ContactPerson As String = ""
    Private _EmailID As String = ""
    Private _ContactNo As String = ""
    Private _Address1 As String = ""
    Private _Address2 As String = ""
    Private _Address3 As String = ""
    Private _Address4 As String = ""
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Property ProjectID() As String
      Get
        Return _ProjectID
      End Get
      Set(ByVal value As String)
        _ProjectID = value
      End Set
    End Property
    Public Property Description() As String
      Get
        Return _Description
      End Get
      Set(ByVal value As String)
        _Description = value
      End Set
    End Property
    Public Property ContactPerson() As String
      Get
        Return _ContactPerson
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _ContactPerson = ""
        Else
          _ContactPerson = value
        End If
      End Set
    End Property
    Public Property EmailID() As String
      Get
        Return _EmailID
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _EmailID = ""
        Else
          _EmailID = value
        End If
      End Set
    End Property
    Public Property ContactNo() As String
      Get
        Return _ContactNo
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _ContactNo = ""
        Else
          _ContactNo = value
        End If
      End Set
    End Property
    Public Property Address1() As String
      Get
        Return _Address1
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _Address1 = ""
        Else
          _Address1 = value
        End If
      End Set
    End Property
    Public Property Address2() As String
      Get
        Return _Address2
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _Address2 = ""
        Else
          _Address2 = value
        End If
      End Set
    End Property
    Public Property Address3() As String
      Get
        Return _Address3
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _Address3 = ""
        Else
          _Address3 = value
        End If
      End Set
    End Property
    Public Property Address4() As String
      Get
        Return _Address4
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(Value) Then
          _Address4 = ""
        Else
          _Address4 = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _Description.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _ProjectID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKqcmProjects
			Private _ProjectID As String = ""
			Public Property ProjectID() As String
				Get
					Return _ProjectID
				End Get
				Set(ByVal value As String)
					_ProjectID = value
				End Set
			End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmProjectsSelectList(ByVal OrderBy As String) As List(Of SIS.QCM.qcmProjects)
      Dim Results As List(Of SIS.QCM.qcmProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmProjectsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmProjectsGetNewRecord() As SIS.QCM.qcmProjects
      Return New SIS.QCM.qcmProjects()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmProjectsGetByID(ByVal ProjectID As String) As SIS.QCM.qcmProjects
      Dim Results As SIS.QCM.qcmProjects = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spqcmProjectsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID",SqlDbType.NVarChar,ProjectID.ToString.Length, ProjectID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.QCM.qcmProjects(Reader)
					End If
					Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function qcmProjectsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.QCM.qcmProjects)
      Dim Results As List(Of SIS.QCM.qcmProjects) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spqcmProjectsSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spqcmProjectsSelectListFilteres"
					End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.QCM.qcmProjects)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.QCM.qcmProjects(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function qcmProjectsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
'		Autocomplete Method
		Public Shared Function SelectqcmProjectsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
			Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					Cmd.CommandText = "spqcmProjectsAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
					Results = New List(Of String)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Not Reader.HasRows Then
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
					End If
					While (Reader.Read())
            Dim Tmp As SIS.QCM.qcmProjects = New SIS.QCM.qcmProjects(Reader)
					  Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
					End While
					Reader.Close()
				End Using
			End Using
			Return Results.ToArray
		End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      On Error Resume Next
      _ProjectID = Ctype(Reader("ProjectID"),String)
      _Description = Ctype(Reader("Description"),String)
      If Convert.IsDBNull(Reader("ContactPerson")) Then
        _ContactPerson = String.Empty
      Else
        _ContactPerson = CType(Reader("ContactPerson"), String)
      End If
      If Convert.IsDBNull(Reader("EmailID")) Then
        _EmailID = String.Empty
      Else
        _EmailID = CType(Reader("EmailID"), String)
      End If
      If Convert.IsDBNull(Reader("ContactNo")) Then
        _ContactNo = String.Empty
      Else
        _ContactNo = CType(Reader("ContactNo"), String)
      End If
      If Convert.IsDBNull(Reader("Address1")) Then
        _Address1 = String.Empty
      Else
        _Address1 = CType(Reader("Address1"), String)
      End If
      If Convert.IsDBNull(Reader("Address2")) Then
        _Address2 = String.Empty
      Else
        _Address2 = CType(Reader("Address2"), String)
      End If
      If Convert.IsDBNull(Reader("Address3")) Then
        _Address3 = String.Empty
      Else
        _Address3 = CType(Reader("Address3"), String)
      End If
      If Convert.IsDBNull(Reader("Address4")) Then
        _Address4 = String.Empty
      Else
        _Address4 = CType(Reader("Address4"), String)
      End If
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
