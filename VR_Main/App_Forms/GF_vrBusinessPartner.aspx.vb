Partial Class GF_vrBusinessPartner
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/VR_Main/App_Display/DF_vrBusinessPartner.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl & "?BPID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVvrBusinessPartner_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrBusinessPartner.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim BPID As String = GVvrBusinessPartner.DataKeys(e.CommandArgument).Values("BPID")
        Dim RedirectUrl As String = TBLvrBusinessPartner.EditUrl & "?BPID=" & BPID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrBusinessPartner.Init
    DataClassName = "GvrBusinessPartner"
    SetGridView = GVvrBusinessPartner
  End Sub
  Protected Sub TBLvrBusinessPartner_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrBusinessPartner.Init
    SetToolBar = TBLvrBusinessPartner
  End Sub
  Protected Sub F_BPID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_BPID.TextChanged
    Session("F_BPID") = F_BPID.Text
    InitGridPage()
  End Sub

  Private Sub cmdSync_Click(sender As Object, e As EventArgs) Handles cmdSync.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim oBPs As List(Of lgBP) = lgBP.GetDataFromBaaN("SUP")
    For Each bp As lgBP In oBPs
      Dim Found As Boolean = True
      Try
        Dim tmp As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(bp.t_bpid)
        If tmp Is Nothing Then
          Found = False
          tmp = New SIS.VR.vrTransporters
        End If
        tmp.TransporterID = bp.t_bpid
        tmp.TransporterName = bp.t_nama
        If Not Found Then
          SIS.VR.vrTransporters.InsertData(tmp)
        Else
          SIS.VR.vrTransporters.UpdateData(tmp)
        End If
      Catch ex As Exception
      End Try
      Found = True
      Try
        Dim tmp As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(bp.t_bpid)
        If tmp Is Nothing Then
          Found = False
          tmp = New SIS.VR.vrBusinessPartner
        End If
        tmp.BPID = bp.t_bpid
        tmp.BPName = bp.t_nama
        If Not Found Then
          SIS.VR.vrBusinessPartner.InsertData(tmp)
        Else
          SIS.VR.vrBusinessPartner.UpdateData(tmp)
        End If
      Catch ex As Exception
      End Try
      Found = True
      Try
        Dim tmp As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(bp.t_bpid)
        If tmp Is Nothing Then
          Found = False
          tmp = New SIS.QCM.qcmVendors
        End If
        tmp.VendorID = bp.t_bpid
        tmp.Description = bp.t_nama
        If Not Found Then
          SIS.QCM.qcmVendors.InsertData(tmp)
        Else
          SIS.QCM.qcmVendors.UpdateData(tmp)
        End If
      Catch ex As Exception
      End Try
    Next
    'oBPs = lgBP.GetDataFromBaaN("CUS")
    'For Each bp As lgBP In oBPs
    '  Try
    '    Dim tmp As New SIS.VR.vrBusinessPartner
    '    tmp.BPID = bp.t_bpid
    '    tmp.BPName = bp.t_nama
    '    SIS.VR.vrBusinessPartner.InsertData(tmp)
    '  Catch ex As Exception
    '  End Try
    'Next
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub
End Class
