Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Partial Class GF_vrLorryReceiptsReturn
  Inherits SIS.SYS.GridBase
  Protected Sub GVvrLorryReceiptsD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceiptsD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptsD.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceiptsD.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim RedirectUrl As String = TBLvrLorryReceiptsD.EditUrl & "?ProjectID=" & ProjectID & "&MRNNo=" & MRNNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "RejectWF".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptsD.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceiptsD.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim ReturnRemarks As String = CType(GVvrLorryReceiptsD.Rows(e.CommandArgument).FindControl("F_ReturnRemarks"), TextBox).Text
        Dim tmp As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID, MRNNo)
        If tmp IsNot Nothing Then
          Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
            Using Cmd As SqlCommand = Con.CreateCommand()
              Cmd.CommandType = CommandType.Text
              Cmd.CommandText = "insert vr_lorryReceiptReturns (ProjectID,MRNNo,Remarks,ReturnedBy,ReturnedOn) values ('" & tmp.ProjectID & "'," & tmp.MRNNo & ",'" & ReturnRemarks & "','" & HttpContext.Current.Session("LoginID") & "',convert(datetime,'" & Now.ToString("dd/MM/yyyy HH:mm") & "',103))"
              Con.Open()
              Cmd.ExecuteNonQuery()
            End Using
          End Using
          tmp.LRStatusID = 1
          SIS.VR.vrLorryReceipts.UpdateData(tmp)
          GVvrLorryReceiptsD.DataBind()
        End If
      Catch ex As Exception
      End Try
    End If
  End Sub
  Protected Sub GVvrLorryReceiptsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceiptsD.Init
    DataClassName = "GvrLorryReceiptsD"
    SetGridView = GVvrLorryReceiptsD
  End Sub
  Protected Sub TBLvrLorryReceiptsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptsD.Init
    SetToolBar = TBLvrLorryReceiptsD
  End Sub
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
  Protected Sub F_CustomerID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CustomerID.TextChanged
    Session("F_CustomerID") = F_CustomerID.Text
    Session("F_CustomerID_Display") = F_CustomerID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CustomerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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
    F_CustomerID_Display.Text = String.Empty
    If Not Session("F_CustomerID_Display") Is Nothing Then
      If Session("F_CustomerID_Display") <> String.Empty Then
        F_CustomerID_Display.Text = Session("F_CustomerID_Display")
      End If
    End If
    F_CustomerID.Text = String.Empty
    If Not Session("F_CustomerID") Is Nothing Then
      If Session("F_CustomerID") <> String.Empty Then
        F_CustomerID.Text = Session("F_CustomerID")
      End If
    End If
    Dim strScriptCustomerID As String = "<script type=""text/javascript""> " &
      "function ACECustomerID_Selected(sender, e) {" &
      "  var F_CustomerID = $get('" & F_CustomerID.ClientID & "');" &
      "  var F_CustomerID_Display = $get('" & F_CustomerID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_CustomerID.value = p[0];" &
      "  F_CustomerID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CustomerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CustomerID", strScriptCustomerID)
    End If
    Dim strScriptPopulatingCustomerID As String = "<script type=""text/javascript""> " &
      "function ACECustomerID_Populating(o,e) {" &
      "  var p = $get('" & F_CustomerID.ClientID & "');" &
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" &
      "  p.style.backgroundRepeat= 'no-repeat';" &
      "  p.style.backgroundPosition = 'right';" &
      "  o._contextKey = '';" &
      "}" &
      "function ACECustomerID_Populated(o,e) {" &
      "  var p = $get('" & F_CustomerID.ClientID & "');" &
      "  p.style.backgroundImage  = 'none';" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CustomerIDPopulating") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CustomerIDPopulating", strScriptPopulatingCustomerID)
    End If
    Dim validateScriptProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_ProjectID(o) {" &
      "    validated_FK_VR_LorryReceipts_ProjectID_main = true;" &
      "    validate_FK_VR_LorryReceipts_ProjectID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateProjectID", validateScriptProjectID)
    End If
    Dim validateScriptTransporterID As String = "<script type=""text/javascript"">" &
      "  function validate_TransporterID(o) {" &
      "    validated_FK_VR_LorryReceipts_TransporterID_main = true;" &
      "    validate_FK_VR_LorryReceipts_TransporterID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateTransporterID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateTransporterID", validateScriptTransporterID)
    End If
    Dim validateScriptCustomerID As String = "<script type=""text/javascript"">" &
      "  function validate_CustomerID(o) {" &
      "    validated_FK_VR_LorryReceipts_CustomerID_main = true;" &
      "    validate_FK_VR_LorryReceipts_CustomerID(o);" &
      "  }" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCustomerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCustomerID", validateScriptCustomerID)
    End If
    Dim validateScriptFK_VR_LorryReceipts_ProjectID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_LorryReceipts_ProjectID(o) {" &
      "    var value = o.id;" &
      "    var ProjectID = $get('" & F_ProjectID.ClientID & "');" &
      "    try{" &
      "    if(ProjectID.value==''){" &
      "      if(validated_FK_VR_LorryReceipts_ProjectID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + ProjectID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_LorryReceipts_ProjectID(value, validated_FK_VR_LorryReceipts_ProjectID);" &
      "  }" &
      "  validated_FK_VR_LorryReceipts_ProjectID_main = false;" &
      "  function validated_FK_VR_LorryReceipts_ProjectID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LorryReceipts_ProjectID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LorryReceipts_ProjectID", validateScriptFK_VR_LorryReceipts_ProjectID)
    End If
    Dim validateScriptFK_VR_LorryReceipts_CustomerID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_LorryReceipts_CustomerID(o) {" &
      "    var value = o.id;" &
      "    var CustomerID = $get('" & F_CustomerID.ClientID & "');" &
      "    try{" &
      "    if(CustomerID.value==''){" &
      "      if(validated_FK_VR_LorryReceipts_CustomerID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + CustomerID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_LorryReceipts_CustomerID(value, validated_FK_VR_LorryReceipts_CustomerID);" &
      "  }" &
      "  validated_FK_VR_LorryReceipts_CustomerID_main = false;" &
      "  function validated_FK_VR_LorryReceipts_CustomerID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LorryReceipts_CustomerID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LorryReceipts_CustomerID", validateScriptFK_VR_LorryReceipts_CustomerID)
    End If
    Dim validateScriptFK_VR_LorryReceipts_TransporterID As String = "<script type=""text/javascript"">" &
      "  function validate_FK_VR_LorryReceipts_TransporterID(o) {" &
      "    var value = o.id;" &
      "    var TransporterID = $get('" & F_TransporterID.ClientID & "');" &
      "    try{" &
      "    if(TransporterID.value==''){" &
      "      if(validated_FK_VR_LorryReceipts_TransporterID.main){" &
      "        var o_d = $get(o.id +'_Display');" &
      "        try{o_d.innerHTML = '';}catch(ex){}" &
      "      }" &
      "    }" &
      "    value = value + ',' + TransporterID.value ;" &
      "    }catch(ex){}" &
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" &
      "    o.style.backgroundRepeat= 'no-repeat';" &
      "    o.style.backgroundPosition = 'right';" &
      "    PageMethods.validate_FK_VR_LorryReceipts_TransporterID(value, validated_FK_VR_LorryReceipts_TransporterID);" &
      "  }" &
      "  validated_FK_VR_LorryReceipts_TransporterID_main = false;" &
      "  function validated_FK_VR_LorryReceipts_TransporterID(result) {" &
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_VR_LorryReceipts_TransporterID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_VR_LorryReceipts_TransporterID", validateScriptFK_VR_LorryReceipts_TransporterID)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_LorryReceipts_ProjectID(ByVal value As String) As String
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
  Public Shared Function validate_FK_VR_LorryReceipts_CustomerID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim CustomerID As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(CustomerID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_LorryReceipts_TransporterID(ByVal value As String) As String
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
End Class
