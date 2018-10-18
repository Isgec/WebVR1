Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.PAK
  'Public Class lgPortItems
  '  Public Property pH As SIS.PAK.pakPkgListH = Nothing
  '  Public Property pD As SIS.PAK.pakPkgListD = Nothing
  '  Public Property pT As SIS.PAK.pakPOBItems = Nothing
  '  Public Sub New(ByVal rd As SqlDataReader)
  '    pH = New SIS.PAK.pakPkgListH(rd)
  '    pD = New SIS.PAK.pakPkgListD(rd)
  '    pT = New SIS.PAK.pakPOBItems(rd)
  '  End Sub
  'End Class
  Partial Public Class pakPkgListD
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
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
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




    Public Shared Function UZ_pakPkgListDSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal PkgNo As Int32, ByVal SerialNo As Int32) As List(Of SIS.PAK.pakPkgListD)
      Dim Results As List(Of SIS.PAK.pakPkgListD) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "sppak_LG_PkgListDSelectListSearch"
            Cmd.CommandText = "sppakPkgListDSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "sppak_LG_PkgListDSelectListFilteres"
            Cmd.CommandText = "sppakPkgListDSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_PkgNo", SqlDbType.Int, 10, IIf(PkgNo = Nothing, 0, PkgNo))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SerialNo", SqlDbType.Int, 10, IIf(SerialNo = Nothing, 0, SerialNo))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.PAK.pakPkgListD)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.PAK.pakPkgListD(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_pakPkgListDInsert(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Result As SIS.PAK.pakPkgListD = pakPkgListDInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListDUpdate(ByVal Record As SIS.PAK.pakPkgListD) As SIS.PAK.pakPkgListD
      Dim _Result As SIS.PAK.pakPkgListD = pakPkgListDUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_pakPkgListDDelete(ByVal Record As SIS.PAK.pakPkgListD) As Integer
      Dim _Result As Integer = pakPkgListDDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ItemNo"), TextBox).Text = ""
          CType(.FindControl("F_ItemNo_Display"), Label).Text = ""
          CType(.FindControl("F_UOMQuantity"), Object).SelectedValue = ""
          CType(.FindControl("F_Quantity"), TextBox).Text = 0
          CType(.FindControl("F_UOMWeight"), Object).SelectedValue = ""
          CType(.FindControl("F_WeightPerUnit"), TextBox).Text = 0
          CType(.FindControl("F_UOMPack"), Object).SelectedValue = ""
          CType(.FindControl("F_PackHeight"), TextBox).Text = 0
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
          CType(.FindControl("F_BOMNo"), TextBox).Text = ""
          CType(.FindControl("F_BOMNo_Display"), Label).Text = ""
          CType(.FindControl("F_PkgNo"), TextBox).Text = ""
          CType(.FindControl("F_PkgNo_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_SerialNo_Display"), Label).Text = ""
          CType(.FindControl("F_PackTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_PackWidth"), TextBox).Text = 0
          CType(.FindControl("F_PackLength"), TextBox).Text = 0
          CType(.FindControl("F_PackingMark"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
