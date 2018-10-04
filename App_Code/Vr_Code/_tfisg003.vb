Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TFISG
  <DataObject()> _
  Partial Public Class tfisg003
    Private Shared _RecordCount As Integer
    Private _t_grno As String = ""
    Private _t_grdt As String = ""
    Private _t_cprj As String = ""
    Private _t_bpid As String = ""
    Private _t_vhno As String = ""
    Public Property SupplierID As String = ""
    Public Property t_grno() As String
      Get
        Return _t_grno
      End Get
      Set(ByVal value As String)
        _t_grno = value
      End Set
    End Property
    Public Property t_grdt() As String
      Get
        If Not _t_grdt = String.Empty Then
          Return Convert.ToDateTime(_t_grdt).ToString("dd/MM/yyyy")
        End If
        Return _t_grdt
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _t_grdt = ""
         Else
           _t_grdt = value
         End If
      End Set
    End Property
    Public Property t_cprj() As String
      Get
        Return _t_cprj
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _t_cprj = ""
         Else
           _t_cprj = value
         End If
      End Set
    End Property
    Public Property t_bpid() As String
      Get
        Return _t_bpid
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _t_bpid = ""
         Else
           _t_bpid = value
         End If
      End Set
    End Property
    Public Property t_vhno() As String
      Get
        Return _t_vhno
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _t_vhno = ""
         Else
           _t_vhno = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _t_bpid.ToString.PadRight(9, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_grno
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
    Public Class PKtfisg003
      Private _t_grno As String = ""
      Public Property t_grno() As String
        Get
          Return _t_grno
        End Get
        Set(ByVal value As String)
          _t_grno = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function tfisg003GetByID(ByVal t_grno As String) As SIS.TFISG.tfisg003
      Dim Comp As String = "200"
      Dim Results As SIS.TFISG.tfisg003 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptfisg003" & Comp & "SelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@t_grno", SqlDbType.NVarChar, t_grno.ToString.Length, t_grno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.TFISG.tfisg003(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    '    Autocomplete Method
    Public Shared Function Selecttfisg003AutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Comp As String = "200"
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sptfisg003" & Comp & "AutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.VarChar, 10, aVal(0))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransporterID", SqlDbType.VarChar, 10, aVal(1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(9, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.TFISG.tfisg003 = New SIS.TFISG.tfisg003(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
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
  End Class
End Namespace
