Imports System.Web.Script.Serialization
Partial Class GF_vrPendingVehicleRequest
  Inherits SIS.SYS.GridBase
  Protected Sub cmdTest_Click(sender As Object, e As EventArgs)
    Try
      Dim str As String = SIS.VR.vrPendingVehicleRequest.CreateTestSPRequest(0)
      myData.Controls.Add(New LiteralControl(str))
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", New JavaScriptSerializer().Serialize(ex.Message)), True)
    End Try
  End Sub

  Protected Sub GVvrPendingVehicleRequest_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrPendingVehicleRequest.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim RequestNo As Int32 = GVvrPendingVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
        Dim RedirectUrl As String = TBLvrPendingVehicleRequest.EditUrl & "?RequestNo=" & RequestNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim RequestNo As Int32 = GVvrPendingVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
        SIS.VR.vrPendingVehicleRequest.InitiateWF(RequestNo)
        GVvrPendingVehicleRequest.DataBind()
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "sprequest".ToLower Then
      Try
        Dim RequestNo As Int32 = GVvrPendingVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
        Dim str As String = SIS.VR.vrPendingVehicleRequest.CreateSPRequest(RequestNo)
        myData.Controls.Add(New LiteralControl(str))
        GVvrPendingVehicleRequest.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", New JavaScriptSerializer().Serialize(ex.Message)), True)
      End Try
    End If
    If e.CommandName.ToLower = "spexecution".ToLower Then
      Dim str As String = ""
      Try
        Dim RequestNo As Int32 = GVvrPendingVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
        SIS.VR.vrPendingVehicleRequest.GetSPExecution(RequestNo, str)
        GVvrPendingVehicleRequest.DataBind()
        '-------Temp Testing 
        'Dim isgE As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.vrRequestExecutionGetByRequestNo(RequestNo, "")
        'For Each x As SIS.VR.vrRequestExecution In isgE
        '  SIS.VR.vrRequestExecution.CloseSPExecution(x)
        'Next
        '=====------------
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", String.Format("alert({0});", New JavaScriptSerializer().Serialize(ex.Message)), True)
      End Try
      myData.Controls.Add(New LiteralControl(str))
    End If
    If e.CommandName.ToLower = "rejectwf".ToLower Then
      Try
        Dim ReturnRemarks As String = CType(GVvrPendingVehicleRequest.Rows(e.CommandArgument).FindControl("F_ReturnRemarks"), TextBox).Text
        Dim RequestNo As Int32 = GVvrPendingVehicleRequest.DataKeys(e.CommandArgument).Values("RequestNo")
        SIS.VR.vrPendingVehicleRequest.RejectWF(RequestNo, ReturnRemarks)
        GVvrPendingVehicleRequest.DataBind()
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVvrPendingVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrPendingVehicleRequest.Init
    DataClassName = "GvrPendingVehicleRequest"
    SetGridView = GVvrPendingVehicleRequest
  End Sub
  Protected Sub TBLvrPendingVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPendingVehicleRequest.Init
    SetToolBar = TBLvrPendingVehicleRequest
  End Sub
  Protected Sub F_SupplierID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_SupplierID.TextChanged
    Session("F_SupplierID") = F_SupplierID.Text
    Session("F_SupplierID_Display") = F_SupplierID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmVendors.SelectqcmVendorsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ProjectID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ProjectID.TextChanged
    Session("F_ProjectID") = F_ProjectID.Text
    Session("F_ProjectID_Display") = F_ProjectID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_RequestedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_RequestedBy.TextChanged
    Session("F_RequestedBy") = F_RequestedBy.Text
    Session("F_RequestedBy_Display") = F_RequestedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function RequestedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_SupplierID_Display.Text = String.Empty
    If Not Session("F_SupplierID_Display") Is Nothing Then
      If Session("F_SupplierID_Display") <> String.Empty Then
        F_SupplierID_Display.Text = Session("F_SupplierID_Display")
      End If
    End If
    F_SupplierID.Text = String.Empty
    If Not Session("F_SupplierID") Is Nothing Then
      If Session("F_SupplierID") <> String.Empty Then
        F_SupplierID.Text = Session("F_SupplierID")
      End If
    End If
    Dim strScriptSupplierID As String = "<script type=""text/javascript""> " &
      "function ACESupplierID_Selected(sender, e) {" &
      "  var F_SupplierID = $get('" & F_SupplierID.ClientID & "');" &
      "  var F_SupplierID_Display = $get('" & F_SupplierID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_SupplierID.value = p[0];" &
      "  F_SupplierID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierID", strScriptSupplierID)
    End If
    Dim strScriptPopulatingSupplierID As String = "<script type=""text/javascript""> " &
      "function ACESupplierID_Populating(o,e) {" &
      "  var p = $get('" & F_SupplierID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACESupplierID_Populated(o,e) {" &
      "  var p = $get('" & F_SupplierID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_SupplierIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_SupplierIDPopulating", strScriptPopulatingSupplierID)
    End If
    F_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        F_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    F_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        F_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim strScriptProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Selected(sender, e) {" &
      "  var F_ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "  var F_ProjectID_Display = $get('" & F_ProjectID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_ProjectID.value = p[0];" &
      "  F_ProjectID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectID", strScriptProjectID)
    End If
    Dim strScriptPopulatingProjectID As String = "<script type=""text/javascript""> " &
      "function ACEProjectID_Populating(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACEProjectID_Populated(o,e) {" &
      "  var p = $get('" & F_ProjectID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ProjectIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ProjectIDPopulating", strScriptPopulatingProjectID)
    End If
    F_RequestedBy_Display.Text = String.Empty
    If Not Session("F_RequestedBy_Display") Is Nothing Then
      If Session("F_RequestedBy_Display") <> String.Empty Then
        F_RequestedBy_Display.Text = Session("F_RequestedBy_Display")
      End If
    End If
    F_RequestedBy.Text = String.Empty
    If Not Session("F_RequestedBy") Is Nothing Then
      If Session("F_RequestedBy") <> String.Empty Then
        F_RequestedBy.Text = Session("F_RequestedBy")
      End If
    End If
    Dim strScriptRequestedBy As String = "<script type=""text/javascript""> " &
      "function ACERequestedBy_Selected(sender, e) {" &
      "  var F_RequestedBy = $get('" & F_RequestedBy.ClientID & "');" &
      "  var F_RequestedBy_Display = $get('" & F_RequestedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_RequestedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedBy", strScriptRequestedBy)
    End If
    Dim strScriptPopulatingRequestedBy As String = "<script type=""text/javascript""> " &
      "function ACERequestedBy_Populating(o,e) {" &
      "  var p = $get('" & F_RequestedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACERequestedBy_Populated(o,e) {" &
      "  var p = $get('" & F_RequestedBy.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_RequestedByPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_RequestedByPopulating", strScriptPopulatingRequestedBy)
    End If
    Dim validateScriptSupplierID As String = "<script type=""text/javascript"">" &
      "  function validate_SupplierID(o) {" &
      "    validated_FK_VR_VehicleRequest_SupplierID_main = true;" &
      "    validate_FK_VR_VehicleRequest_SupplierID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateSupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateSupplierID", validateScriptSupplierID)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_VR_VehicleRequest_ProjectID_main = true;" &
      "    validate_FK_VR_VehicleRequest_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptRequestedBy As String = "<script type=""text/javascript"">" &
      "  function validate_RequestedBy(o) {" &
      "    validated_FK_VR_VehicleRequest_RequestedBy_main = true;" &
      "    validate_FK_VR_VehicleRequest_RequestedBy(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateRequestedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateRequestedBy", validateScriptRequestedBy)
    End If
    Dim validateScriptFK_VR_VehicleRequest_RequestedBy As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_VehicleRequest_RequestedBy(o) {" &
      "    var value = o.id;" &
      "    var RequestedBy = $get('" & F_RequestedBy.ClientID & "');" &
      "    try{" &
      "    if(RequestedBy.value==''){" &
      "      if(validated_FK_VR_VehicleRequest_RequestedBy.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + RequestedBy.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_VehicleRequest_RequestedBy(value, validated_FK_VR_VehicleRequest_RequestedBy);" &
      "  }" &
      "  validated_FK_VR_VehicleRequest_RequestedBy_main = false;" &
      "  function validated_FK_VR_VehicleRequest_RequestedBy(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_RequestedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_RequestedBy", validateScriptFK_VR_VehicleRequest_RequestedBy)
    End If
    Dim validateScriptFK_VR_VehicleRequest_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_VehicleRequest_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_VR_VehicleRequest_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_VehicleRequest_ProjectID(value, validated_FK_VR_VehicleRequest_ProjectID);" &
      "  }" &
      "  validated_FK_VR_VehicleRequest_ProjectID_main = false;" &
      "  function validated_FK_VR_VehicleRequest_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_ProjectID", validateScriptFK_VR_VehicleRequest_ProjectID)
    End If
    Dim validateScriptFK_VR_VehicleRequest_SupplierID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_VehicleRequest_SupplierID(o) {" &
      "    var value = o.id;" &
      "    var SupplierID = $get('" & F_SupplierID.ClientID & "');" &
      "    try{" &
      "    if(SupplierID.value==''){" &
      "      if(validated_FK_VR_VehicleRequest_SupplierID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + SupplierID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_VehicleRequest_SupplierID(value, validated_FK_VR_VehicleRequest_SupplierID);" &
      "  }" &
      "  validated_FK_VR_VehicleRequest_SupplierID_main = false;" &
      "  function validated_FK_VR_VehicleRequest_SupplierID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_VehicleRequest_SupplierID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_VehicleRequest_SupplierID", validateScriptFK_VR_VehicleRequest_SupplierID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_VehicleRequest_RequestedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim RequestedBy As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(RequestedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_VehicleRequest_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_VehicleRequest_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_VehicleRequest_SRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SRNNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(SRNNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
