Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.IREF
  Public Class ItemReference
    Private Shared _RecordCount As Integer
    Public Property t_orno As String = ""
    Public Property t_pono As Int32 = 0
    Public Property t_iref As String = ""
    Public Property t_cprj As String = ""
    Public Property t_cspa As String = ""
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _t_iref.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_orno & "|" & _t_pono & "|" & _t_iref
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
    Public Class PKItemReference
      Public Property t_orno As String = ""
      Public Property t_pono As Int32 = 0
      Public Property t_iref As String = ""
    End Class

    Public Shared Function ItemReferenceSelectList(ByVal t_orno As String, ByVal t_pono As Integer) As List(Of SIS.IREF.ItemReference)
      Dim Results As New List(Of SIS.IREF.ItemReference)
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")

      Dim Sql As String = ""
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Sql = " Select distinct t_iref, t_cprj, t_cspa "
        Sql &= " from tdmisg140" & Comp
        Sql &= " where t_docn in "
        Sql &= " ("
        Sql &= "   select distinct t_docn from ttdisg002" & Comp
        Sql &= "     where t_orno = '" & t_orno & "'"
        Sql &= "       and t_pono = " & t_pono
        Sql &= " )"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New ItemReference(Reader)
            With tmp
              .t_orno = t_orno
              .t_pono = t_pono
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
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
Namespace SIS.SUBI
  Public Class SubItem
    Private Shared _RecordCount As Integer
    Public Property t_orno As String = ""
    Public Property t_pono As Int32 = 0
    Public Property t_iref As String = ""
    Public Property t_sub2 As String = ""
    Public Property t_cprj As String = ""
    Public Property t_cspa As String = ""
    Public Property t_bohd As String = "" ' "CT_POAPPROVED"
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _t_sub2.ToString.PadRight(50, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _t_orno & "|" & _t_pono & "|" & _t_iref & "|" & _t_sub2
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
    Public Class PKSubItem
      Public Property t_orno As String = ""
      Public Property t_pono As Int32 = 0
      Public Property t_iref As String = ""
      Public Property t_sub2 As String = ""
    End Class

    Public Shared Function SubItemSelectList(ByVal iref As SIS.IREF.ItemReference) As List(Of SIS.SUBI.SubItem)
      Dim Results As New List(Of SIS.SUBI.SubItem)
      Dim Comp As String = HttpContext.Current.Session("FinanceCompany")

      Dim Sql As String = ""
      Dim t_cprj As String = ""

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()

        Sql = " Select distinct t_sub2 "
        Sql &= " from ttpisg220" & Comp
        Sql &= " where t_sub1 = '" & iref.t_iref & "'"
        Sql &= "   and t_cprj ='" & iref.t_cprj & "'"
        Sql &= "   and t_bohd ='CT_POAPPROVED'"

        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SubItem(Reader)
            With tmp
              .t_orno = iref.t_orno
              .t_pono = iref.t_pono
              .t_cprj = iref.t_cprj
              .t_cspa = iref.t_cspa
            End With
            Results.Add(tmp)
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
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
