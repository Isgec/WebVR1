Imports System.Web.Script.Serialization
Partial Class GF_vrRequestExecution
  Inherits SIS.SYS.GridBase
  Public Property SRNNo As Int32
    Get
      If ViewState("SRNNo") IsNot Nothing Then
        Return Convert.ToInt32(ViewState("SRNNo"))
      End If
      Return False
    End Get
    Set(value As Int32)
      ViewState.Add("SRNNo", value)
    End Set
  End Property
  Private ShowPopup As Boolean = False
  Protected Sub GVvrRequestExecution_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrRequestExecution.RowCommand
    If e.CommandName.ToLower = "PushPOData".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        'It is available in PendingVehicleRequest
        SIS.VR.vrPendingVehicleRequest.PushPODataByExecution(SRNNo, True)
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        Dim RedirectUrl As String = TBLvrRequestExecution.EditUrl & "?SRNNo=" & SRNNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        If ConfigurationManager.AppSettings("NewLogicSanctionCheck") Then
          SIS.VR.vrRequestExecution.NewLogicInitiateWF(SRNNo)
        Else
          SIS.VR.vrRequestExecution.InitiateWF(SRNNo)
        End If
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "cancelwf".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        SIS.VR.vrRequestExecution.CancelWF(SRNNo)
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "VehiclePlacedwf".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        SIS.VR.vrRequestExecution.VehiclePlacedWF(SRNNo)
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message)
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    'For Approval
    If e.CommandName.ToLower = "forapproval".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        SIS.VR.vrRequestExecution.SendForApproval(SRNNo)
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "completewf".ToLower Then
      Try
        Dim SRNNo As Int32 = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        SIS.VR.vrRequestExecution.CompleteWF(SRNNo)
        GVvrRequestExecution.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "lgEMailIDs".ToLower Then
      Try
        SRNNo = GVvrRequestExecution.DataKeys(e.CommandArgument).Values("SRNNo")
        ShowPopup = True
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Private Sub GF_vrRequestExecution_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    If HttpContext.Current.Session("LoginID") = "0340" Then
      divPOList.Visible = True
    Else
      divPOList.Visible = False
    End If
    If ConfigurationManager.AppSettings("NewLogicSanctionCheck") Then
      GVvrRequestExecution.Columns(7).Visible = True
      GVvrRequestExecution.Columns(6).Visible = False
      GVvrRequestExecution.Columns(9).Visible = False
    Else
      GVvrRequestExecution.Columns(7).Visible = False
      GVvrRequestExecution.Columns(6).Visible = True
      GVvrRequestExecution.Columns(9).Visible = True
    End If

    If ShowPopup Then
      Dim RE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
      Dim Supplier As SIS.VR.vrTransporters = RE.FK_VR_RequestExecution_TransporterID
      L_PrimaryKey.Text = Supplier.TransporterID
      HeaderText.Text = Supplier.TransporterName
      F_EMailIDs.Text = Supplier.EMailID
      mPopup.Show()
    End If
  End Sub

  Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
    Dim SupplierID As String = L_PrimaryKey.Text
    If SupplierID <> "" Then
      Dim EMailIDs As String = F_EMailIDs.Text
      If EMailIDs <> "" Then
        Dim BP As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(SupplierID)
        BP.EMailID = EMailIDs
        SIS.VR.vrTransporters.UpdateData(BP)
      End If
    End If
  End Sub
  Protected Sub GVvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrRequestExecution.Init
    DataClassName = "GvrRequestExecution"
    SetGridView = GVvrRequestExecution
  End Sub
  Protected Sub TBLvrRequestExecution_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrRequestExecution.Init
    SetToolBar = TBLvrRequestExecution
  End Sub
  Protected Sub F_TransporterID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_TransporterID.TextChanged
    Session("F_TransporterID") = F_TransporterID.Text
    Session("F_TransporterID_Display") = F_TransporterID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_VehicleTypeID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_VehicleTypeID.SelectedIndexChanged
    Session("F_VehicleTypeID") = F_VehicleTypeID.SelectedValue
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_TransporterID_Display.Text = String.Empty
    If Not Session("F_TransporterID_Display") Is Nothing Then
      If Session("F_TransporterID_Display") <> String.Empty Then
        F_TransporterID_Display.Text = Session("F_TransporterID_Display")
      End If
    End If
    F_TransporterID.Text = String.Empty
    If Not Session("F_TransporterID") Is Nothing Then
      If Session("F_TransporterID") <> String.Empty Then
        F_TransporterID.Text = Session("F_TransporterID")
      End If
    End If
    Dim strScriptTransporterID As String = "<script type=""text/javascript""> " &
     "function ACETransporterID_Selected(sender, e) {" &
     "  var F_TransporterID = $get('" & F_TransporterID.ClientID & "');" &
     "  var F_TransporterID_Display = $get('" & F_TransporterID_Display.ClientID & "');" &
     "  var retval = e.get_value();" &
     "  var p = retval.split('|');" &
     "  F_TransporterID.value = p[0];" &
     "  F_TransporterID_Display.innerHTML = e.get_text();" &
     "}" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TransporterID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TransporterID", strScriptTransporterID)
    End If
    Dim strScriptPopulatingTransporterID As String = "<script type=""text/javascript""> " &
     "function ACETransporterID_Populating(o,e) {" &
     "  var p = $get('" & F_TransporterID.ClientID & "');" &
     "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
     "  p.style.backgroundRepeat= 'no-repeat';" &
     "  p.style.backgroundPosition = 'right';" &
     "  o._contextKey = '';" &
     "}" &
     "function ACETransporterID_Populated(o,e) {" &
     "  var p = $get('" & F_TransporterID.ClientID & "');" &
     "  p.style.backgroundImage  = 'none';" &
     "}" &
     "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_TransporterIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_TransporterIDPopulating", strScriptPopulatingTransporterID)
    End If
    F_VehicleTypeID.SelectedValue = String.Empty
    If Not Session("F_VehicleTypeID") Is Nothing Then
      If Session("F_VehicleTypeID") <> String.Empty Then
        F_VehicleTypeID.SelectedValue = Session("F_VehicleTypeID")
      End If
    End If
    Dim validateScriptTransporterID As String = "<script type=""text/javascript"">" &
     "  function validate_TransporterID(o) {" &
     "    validated_FK_VR_RequestExecution_TransporterID_main = true;" &
     "    validate_FK_VR_RequestExecution_TransporterID(o);" &
     "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTransporterID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTransporterID", validateScriptTransporterID)
    End If
    Dim validateScriptFK_VR_RequestExecution_TransporterID As String = "<script type=""text/javascript"">" &
     "  function validate_FK_VR_RequestExecution_TransporterID(o) {" &
     "    var value = o.id;" &
     "    var TransporterID = $get('" & F_TransporterID.ClientID & "');" &
     "    try{" &
     "    if(TransporterID.value==''){" &
     "      if(validated_FK_VR_RequestExecution_TransporterID.main){" &
     "        var o_d = $get(o.id +'_Display');" &
     "        try{o_d.innerHTML = '';}catch(ex){}" &
     "      }" &
     "    }" &
     "    value = value + ',' + TransporterID.value ;" &
     "    }catch(ex){}" &
     "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
     "    o.style.backgroundRepeat= 'no-repeat';" &
     "    o.style.backgroundPosition = 'right';" &
     "    PageMethods.validate_FK_VR_RequestExecution_TransporterID(value, validated_FK_VR_RequestExecution_TransporterID);" &
     "  }" &
     "  validated_FK_VR_RequestExecution_TransporterID_main = false;" &
     "  function validated_FK_VR_RequestExecution_TransporterID(result) {" &
     "    var p = result.split('|');" &
     "    var o = $get(p[1]);" &
     "    var o_d = $get(p[1]+'_Display');" &
     "    try{o_d.innerHTML = p[2];}catch(ex){}" &
     "    o.style.backgroundImage  = 'none';" &
     "    if(p[0]=='1'){" &
     "      o.value='';" &
     "      try{o_d.innerHTML = '';}catch(ex){}" &
     "      __doPostBack(o.id, o.value);" &
     "    }" &
     "    else" &
     "      __doPostBack(o.id, o.value);" &
     "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_RequestExecution_TransporterID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_RequestExecution_TransporterID", validateScriptFK_VR_RequestExecution_TransporterID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_RequestExecution_TransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TransporterID As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function SaveGR(ByVal context As String) As String
    Return SIS.VR.LC_vrGetGR.SaveGR(context)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function GetGRDetails(ByVal context As String) As String
    Dim aVal() As String = context.Split("|".ToCharArray)
    Dim SRNNo As String = aVal(0)
    Return SIS.VR.LC_vrGetGR.GetGRDetails(SRNNo)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function SaveTransShip(ByVal context As String) As String
    Return SIS.VR.LC_vrTransShip.SaveTransShip(context)
  End Function
  <System.Web.Services.WebMethod(EnableSession:=True)>
  Public Shared Function GetTransShip(ByVal context As String) As String
    Dim aVal() As String = context.Split("|".ToCharArray)
    Dim SRNNo As String = aVal(0)
    Return SIS.VR.LC_vrTransShip.GetTransShip(SRNNo)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TransTransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_RequestExecution_TransTransporterID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim TransTransporterID As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrTransporters = SIS.VR.vrTransporters.vrTransportersGetByID(TransTransporterID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function GetLink(ByVal value As String) As String
    Return SIS.VR.LC_LinkExecution.GetLink(value)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function SelectLink(ByVal value As String) As String
    Return SIS.VR.LC_LinkExecution.SelectLink(value)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function RemoveLink(ByVal value As String) As String
    Return SIS.VR.LC_LinkExecution.RemoveLink(value)
  End Function

  Protected Sub cmdPushList_Click(sender As Object, e As EventArgs)
    Dim aList() As String = lstLoadID.Text.Split(",".ToCharArray)
    Dim x As String = ""
    Dim eStr As String = ""
    Try
      For Each x In aList
        Dim Y As Integer = SIS.VR.vrRequestExecution.GetExecutionNoByLoadID(x)
        If Y > 0 Then
          Try
            SIS.VR.vrPendingVehicleRequest.PushPODataByExecution(Y)
          Catch ex As Exception
            eStr &= "LoadID: " & x & " Err: " & ex.Message & "<br/>"
          End Try
        End If
      Next
      If eStr <> "" Then
        Errs.Text = eStr
      End If
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize("LoadID: " & x & " Err: " & ex.Message)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
  End Sub
End Class
