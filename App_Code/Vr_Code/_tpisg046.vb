Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.TPISG
  <DataObject()>
  Partial Public Class tpisg046
    Public Property ProjectID As String = ""
    Public Property UserID As String = ""
    Public Property UserName As String = ""
    Public Property EMailID As String = ""
    Public Shared Function GetUsersEMailIDs(ProjectID As String, Optional ByVal Comp As String = "200") As List(Of SIS.TPISG.tpisg046)
      Dim mRet As New List(Of SIS.TPISG.tpisg046)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Con.Open()
        Dim Sql As String = ""
        Sql &= " Select "
        Sql &= "  pr.t_cprj as ProjectID"
        Sql &= " ,pr.t_user as UserID"
        Sql &= " ,em.t_nama as UserName"
        Sql &= " ,eb.t_mail as EMailID"
        Sql &= " from ttpisg046" & Comp & " as pr "
        Sql &= " inner join ttccom001" & Comp & " as em on en.t_emno=pr.t_user "
        Sql &= " inner join tbpmdm001" & Comp & " as eb on en.t_emno=eb.t_emno "
        Sql &= " where t_cprj='" & ProjectID & "'"
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            mRet.Add(New SIS.TPISG.tpisg046(Reader))
          End If
          Reader.Close()
        End Using
      End Using
      Return mRet
    End Function
    '    Autocomplete Method
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
