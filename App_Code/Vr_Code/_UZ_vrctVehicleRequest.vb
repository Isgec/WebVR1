Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrctVehicleRequest
    Public ReadOnly Property RowProgressPercent As Boolean
      Get
        Return Not RowProgressWeight
      End Get
    End Property

    Public ReadOnly Property RowProgressWeight As Boolean
      Get
        Dim Sql As String = ""
        Sql &= " select t_icls "
        Sql &= " from ttpisg239200 "
        Sql &= " where  "
        Sql &= " t_cprj='" & Project & "'"
        Sql &= " and t_iref='" & ItemReference & "'"
        Dim mRet As Boolean = False
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            Dim tmpX As String = Cmd.ExecuteScalar
            Try
              Select Case tmpX
                Case "1", "3" '1=>Bought Out, 3=>Package
                  mRet = False
                Case "4" 'Self Engineered
                  mRet = True
              End Select
            Catch ex As Exception
              Throw New Exception("Item Reference Type B/S/P not defined in tpisg239")
            End Try
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public ReadOnly Property QCClearedWt As Decimal
      Get
        Dim Sql As String = ""
        Sql &= " select isnull(sum(qcd.QualityClearedWt),0) As ClearedWt "
        Sql &= " from pak_qclistd as qcd "
        Sql &= " inner join PAK_POBItems as itm on qcd.serialno = itm.serialno and qcd.bomno=itm.bomno and qcd.ItemNo=itm.itemno "
        Sql &= " inner join Pak_po as po on qcd.serialno = po.serialno "
        Sql &= " where po.POFOR='PK' "
        Sql &= " and po.PONumber='" & PONumber & "'"
        Sql &= " and itm.ItemReference='" & ItemReference & "'"
        If ActivityID = "" Then
          Sql &= " and itm.subitem is null "
        Else
          Sql &= " and itm.subitem='" & ActivityID & "'"
        End If
        Dim mRet As Decimal = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public ReadOnly Property QCClearedQty As Decimal
      Get
        Dim Sql As String = ""
        Sql &= " select isnull(sum(qcd.QualityClearedQty),0) As ClearedQty "
        Sql &= " from pak_qclistd as qcd "
        Sql &= " inner join PAK_POBItems as itm on qcd.serialno = itm.serialno and qcd.bomno=itm.bomno and qcd.ItemNo=itm.itemno "
        Sql &= " inner join Pak_po as po on qcd.serialno = po.serialno "
        Sql &= " where po.POFOR='PK' "
        Sql &= " and po.PONumber='" & PONumber & "'"
        Sql &= " and itm.ItemReference='" & ItemReference & "'"
        If ActivityID = "" Then
          Sql &= " and itm.subitem is null "
        Else
          Sql &= " and itm.subitem='" & ActivityID & "'"
        End If
        Dim mRet As Decimal = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property

    Public ReadOnly Property DespatchedWt As Decimal
      Get
        Dim Sql As String = ""
        Sql &= " select isnull(sum(pkg.TotalWeight),0) As DespWt "
        Sql &= " from pak_pkglistd as pkg "
        Sql &= " inner join PAK_POBItems as itm on pkg.serialno = itm.serialno and pkg.bomno = itm.bomno and pkg.ItemNo=itm.itemno "
        Sql &= " inner join Pak_pkglistH as pkgH on pkgH.serialno = pkg.serialno and pkgH.pkgno=pkg.pkgno "
        Sql &= " inner join Pak_po as po on pkg.serialno = po.serialno "
        Sql &= " where po.POFOR='PK' "
        Sql &= " and pkgh.statusid <> 1 "
        Sql &= " and po.PONumber='" & PONumber & "'"
        Sql &= " and itm.ItemReference='" & ItemReference & "'"
        If ActivityID = "" Then
          Sql &= " and itm.subitem is null "
        Else
          Sql &= " and itm.subitem='" & ActivityID & "'"
        End If
        Dim mRet As Decimal = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DespatchedQty As Decimal
      Get
        Dim Sql As String = ""
        Sql &= " select isnull(sum(pkg.Quantity),0) As DespQty "
        Sql &= " from pak_pkglistd as pkg "
        Sql &= " inner join PAK_POBItems as itm on pkg.serialno = itm.serialno and pkg.bomno = itm.bomno and pkg.ItemNo=itm.itemno "
        Sql &= " inner join Pak_pkglistH as pkgH on pkgH.serialno = pkg.serialno and pkgH.pkgno=pkg.pkgno "
        Sql &= " inner join Pak_po as po on pkg.serialno = po.serialno "
        Sql &= " where po.POFOR='PK' "
        Sql &= " and pkgh.statusid <> 1 "
        Sql &= " and po.PONumber='" & PONumber & "'"
        Sql &= " and itm.ItemReference='" & ItemReference & "'"
        If ActivityID = "" Then
          Sql &= " and itm.subitem is null "
        Else
          Sql &= " and itm.subitem='" & ActivityID & "'"
        End If
        Dim mRet As Decimal = 0
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = Sql
            Con.Open()
            mRet = Cmd.ExecuteScalar
          End Using
        End Using
        Return mRet
      End Get
    End Property
    Public ReadOnly Property SubItemDesc As String
      Get
        Dim mRet As String = ""
        mRet = Activity2Desc
        If Activity3Desc <> "" Then
          mRet &= "=>" & Activity3Desc
        End If
        If Activity4Desc <> "" Then
          mRet &= "=>" & Activity4Desc
        End If
        Return mRet
      End Get
    End Property

    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Red
      If Convert.ToDecimal(ProgressPercent) > 0 Then
        mRet = Drawing.Color.Green
      End If
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
      Select Case FK_VR_CT_VehicleRequest_VRRequestNo.RequestStatus
        Case RequestStates.Free, RequestStates.Returned
          If GridLineStatus = 0 Then
            mRet = True
          End If
      End Select
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
    Public Shared Function UZ_vrctVehicleRequestUpdate(ByVal Record As SIS.VR.vrctVehicleRequest) As SIS.VR.vrctVehicleRequest
      Dim _Rec As SIS.VR.vrctVehicleRequest = SIS.VR.vrctVehicleRequest.vrctVehicleRequestGetByID(Record.VRRequestNo, Record.SerialNo)
      With _Rec
        .Quantity = Record.Quantity
        .ProgressPercent = Record.ProgressPercent
        .PartialOrFull = Record.PartialOrFull
        .NotSelectedList = Record.NotSelectedList
        .SelectedList = Record.SelectedList
        If Record.ProgressPercent = "" Then Record.ProgressPercent = "0.0000"
        If Record.ProgressWeight = "" Then Record.ProgressWeight = "0.0000"
        If _Rec.RowProgressPercent Then
          .ProgressWeight = _Rec.IrefWeight * Record.ProgressPercent * 0.01
          .ProgressPercent = Record.ProgressPercent
        Else
          Try
            .ProgressPercent = (Convert.ToDecimal(Record.ProgressWeight) / Convert.ToDecimal(_Rec.IrefWeight)) * 100
          Catch ex As Exception
            .ProgressPercent = "0.0000"
          End Try
          .ProgressWeight = Record.ProgressWeight
        End If
      End With
      Return SIS.VR.vrctVehicleRequest.UpdateData(_Rec)
    End Function
    Public Shared Function GetPkgListHIref(ByVal SerialNo As Integer, ByVal pkgNo As Integer) As List(Of SIS.VR.vrctVehicleRequest)
      Dim pkgH As SIS.PAK.pakPkgListH = SIS.PAK.pakPkgListH.pakPkgListHGetByID(SerialNo, pkgNo)
      Dim Results As New List(Of SIS.VR.vrctVehicleRequest)
      Dim Sql As String = ""
      Sql &= " select "
      Sql &= "   pkg.SerialNo As SelectedList, "
      Sql &= "   pkg.PKGNo As Product, "
      Sql &= "   sum(pkg.TotalWeight) as ProgressWeight, "
      Sql &= "   sum(pkg.Quantity) as Quantity, "
      Sql &= "   (select sum(isnull(aa.TotalWeight,0)) from pak_pobitems as aa where aa.serialno=pkg.serialno and aa.ItemReference=itm.ItemReference and 1 = case when itm.subitem is null then case when aa.subitem is null then 1 else 0 end else case when aa.subitem=itm.subitem then 1 else 0 end end) as IrefWeight, "
      Sql &= "   (select sum(isnull(aa.Quantity,0)) from pak_pobitems as aa where aa.serialno=pkg.serialno and aa.ItemReference=itm.ItemReference and 1 = case when itm.subitem is null then case when aa.subitem is null then 1 else 0 end else case when aa.subitem=itm.subitem then 1 else 0 end end) as PercentOfQuantity, "
      Sql &= "   itm.ItemReference, "
      Sql &= "   itm.SubItem As ActivityID, "
      Sql &= "   itm.SubItem2 As Activity2Desc, "
      Sql &= "   itm.SubItem3 As Activity3Desc, "
      Sql &= "   itm.SubItem4 As Activity4Desc "
      Sql &= " from PAK_PkgListD as pkg "
      Sql &= "   inner join PAK_POBItems as itm "
      Sql &= "      on pkg.SerialNo = itm.SerialNo "
      Sql &= " 	   and pkg.BOMNo = itm.BOMNo "
      Sql &= " 	   and pkg.ItemNo = itm.ItemNo "
      Sql &= " where "
      Sql &= "       pkg.SerialNo = " & SerialNo
      Sql &= "   and pkg.PKGNo = " & pkgNo
      Sql &= " group by "
      Sql &= "   pkg.SerialNo, "
      Sql &= "   pkg.PKGNo, "
      Sql &= "   itm.ItemReference, "
      Sql &= "   itm.SubItem, "
      Sql &= "   itm.SubItem2, "
      Sql &= "   itm.SubItem3, "
      Sql &= "   itm.SubItem4 "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim tmp As New SIS.VR.vrctVehicleRequest(Reader)
            Try
              tmp.ProgressPercent = "0"
              Try
                tmp.ProgressPercent = (Convert.ToDecimal(tmp.ProgressWeight) / Convert.ToDecimal(tmp.IrefWeight)) * 100
              Catch ex As Exception
                tmp.ProgressPercent = "0"
              End Try
              If tmp.ProgressPercent = "0" Then
                Try
                  tmp.ProgressPercent = (Convert.ToDecimal(tmp.Quantity) / Convert.ToDecimal(tmp.PercentOfQuantity)) * 100
                Catch ex As Exception
                  tmp.ProgressPercent = "0"
                End Try
              End If
            Catch ex As Exception
            End Try
            Results.Add(tmp)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetERPItemReference(ByVal ProjectID As String, ByVal OrNo As String, ByVal Handle As String) As List(Of SIS.VR.vrctVehicleRequest)
      Dim Results As List(Of SIS.VR.vrctVehicleRequest) = Nothing
      Dim Sql As String = ""

      Sql &= " select distinct    "
      Sql &= " tp2.t_pcod As Product,    "
      Sql &= " tp3.t_sub2 As Activity2Desc,    "
      Sql &= " tp3.t_sub3 As Activity3Desc,    "
      Sql &= " tp3.t_sub4 As Activity4Desc,    "
      Sql &= " tp2.t_sub1 As ItemReference,    "
      Sql &= " tp2.t_sitm As ActivityID,    "
      Sql &= " sum(td2.t_wght) As IrefWeight,      "
      Sql &= " sum(td2.t_qnty) As PercentOfQuantity      "
      Sql &= " from ttdisg002200 as td2    "
      Sql &= " inner join tdmisg002200 as dm2 on td2.t_docn = dm2.t_docn and td2.t_revi = dm2.t_revn and td2.t_item = dm2.t_item    "
      Sql &= " inner join tdmisg140200 as dm4 on td2.t_docn = dm4.t_docn    "
      Sql &= " inner join ttpisg220200 as tp2 on dm4.t_iref = tp2.t_sub1 and dm4.t_cprj = tp2.t_cprj and tp2.t_sitm = case when dm2.t_sitm = '' then tp2.t_sitm else  dm2.t_sitm end  "
      Sql &= " left outer join ttpisg243200 as tp3 on tp2.t_sub1 = tp3.t_iref and tp2.t_sitm = tp3.t_sitm and tp2.t_pcod = tp3.t_cprd    "
      Sql &= " where td2.t_orno = '" & OrNo & "'"
      Sql &= "   and tp2.t_bohd = '" & Handle & "'"
      Sql &= " group by tp2.t_pcod,tp3.t_sub2, tp3.t_sub3,tp3.t_sub4, tp2.t_sub1, tp2.t_sitm  "

      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Results = New List(Of SIS.VR.vrctVehicleRequest)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrctVehicleRequest(Reader))
          End While
          Reader.Close()
          _RecordCount = Results.Count
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_SerialNo"), TextBox).Text = 0
          CType(.FindControl("F_ItemReference"), TextBox).Text = ""
          CType(.FindControl("F_ActivityID"), TextBox).Text = ""
          CType(.FindControl("F_Quantity"), TextBox).Text = 0
          CType(.FindControl("F_IrefWeight"), TextBox).Text = 0
          CType(.FindControl("F_PartialOrFull"), DropDownList).SelectedValue = ""
          CType(.FindControl("F_ProgressPercent"), TextBox).Text = 0
          CType(.FindControl("F_ProgressWeight"), TextBox).Text = 0
          CType(.FindControl("F_Project"), TextBox).Text = ""
          CType(.FindControl("F_Product"), TextBox).Text = ""
          CType(.FindControl("F_SelectedList"), TextBox).Text = ""
          CType(.FindControl("F_VRRequestNo"), TextBox).Text = ""
          CType(.FindControl("F_VRRequestNo_Display"), Label).Text = ""
          CType(.FindControl("F_PONumber"), TextBox).Text = ""
          CType(.FindControl("F_GridLineStatus"), TextBox).Text = 0
          CType(.FindControl("F_NotSelectedList"), TextBox).Text = ""
          CType(.FindControl("F_Activity3Desc"), TextBox).Text = ""
          CType(.FindControl("F_Handle"), TextBox).Text = ""
          CType(.FindControl("F_Activity4Desc"), TextBox).Text = ""
          CType(.FindControl("F_ItemUnit"), TextBox).Text = ""
          CType(.FindControl("F_PercentOfQuantity"), TextBox).Text = 0
          CType(.FindControl("F_Activity2Desc"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
