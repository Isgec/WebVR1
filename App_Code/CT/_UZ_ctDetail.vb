Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class ctDetail
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_trdt"), TextBox).Text = ""
        CType(.FindControl("F_t_bohd"), TextBox).Text = ""
        CType(.FindControl("F_t_indv"), TextBox).Text = ""
        CType(.FindControl("F_t_srno"), TextBox).Text = 0
        CType(.FindControl("F_t_dsno"), TextBox).Text = 0
        CType(.FindControl("F_t_stat"), TextBox).Text = ""
        CType(.FindControl("F_t_proj"), TextBox).Text = ""
        CType(.FindControl("F_t_elem"), TextBox).Text = ""
        CType(.FindControl("F_t_dwno"), TextBox).Text = ""
        CType(.FindControl("F_t_pitc"), TextBox).Text = 0
        CType(.FindControl("F_t_wght"), TextBox).Text = 0
        CType(.FindControl("F_t_atcd"), TextBox).Text = ""
        CType(.FindControl("F_t_scup"), TextBox).Text = 0
        CType(.FindControl("F_t_acdt"), TextBox).Text = ""
        CType(.FindControl("F_t_acfh"), TextBox).Text = ""
        CType(.FindControl("F_t_pper"), TextBox).Text = 0
        CType(.FindControl("F_t_lupd"), TextBox).Text = ""
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
