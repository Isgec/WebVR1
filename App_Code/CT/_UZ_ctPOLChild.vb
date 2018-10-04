Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.CT
  Partial Public Class ctPOLChild
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
    Public Shared Function UZ_ctPOLChildSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal t_orno As String) As List(Of SIS.CT.ctPOLChild)
      Dim Results As List(Of SIS.CT.ctPOLChild) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spct_LG_POLChildSelectListSearch"
						Cmd.CommandText = "spctPOLChildSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spct_LG_POLChildSelectListFilteres"
						Cmd.CommandText = "spctPOLChildSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_t_orno", SqlDbType.VarChar, 9, IIf(t_orno Is Nothing, String.Empty, t_orno))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.CT.ctPOLChild)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.CT.ctPOLChild(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_t_orno"), TextBox).Text = ""
        CType(.FindControl("F_t_vrsn"), TextBox).Text = 0
        CType(.FindControl("F_t_pono"), TextBox).Text = 0
        CType(.FindControl("F_t_item"), TextBox).Text = ""
        CType(.FindControl("F_t_desc"), TextBox).Text = ""
        CType(.FindControl("F_t_qnty"), TextBox).Text = 0
        CType(.FindControl("F_t_quom"), TextBox).Text = ""
        CType(.FindControl("F_t_wght"), TextBox).Text = 0
        CType(.FindControl("F_t_slct"), TextBox).Text = 0
        CType(.FindControl("F_t_stat"), TextBox).Text = 0
        CType(.FindControl("F_t_pric"), TextBox).Text = 0
        CType(.FindControl("F_t_amnt"), TextBox).Text = 0
        CType(.FindControl("F_t_qoor"), TextBox).Text = 0
        CType(.FindControl("F_t_acht"), TextBox).Text = 0
        CType(.FindControl("F_t_docn"), TextBox).Text = ""
        CType(.FindControl("F_t_revi"), TextBox).Text = ""
        CType(.FindControl("F_t_Refcntd"), TextBox).Text = 0
        CType(.FindControl("F_t_Refcntu"), TextBox).Text = 0
        CType(.FindControl("F_t_pldt"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
