Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Partial Class GF_vrLorryReceipts
  Inherits SIS.SYS.GridBase
  Protected Sub GVvrLorryReceipts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceipts.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceipts.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceipts.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim RedirectUrl As String = TBLvrLorryReceipts.EditUrl & "?ProjectID=" & ProjectID & "&MRNNo=" & MRNNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceipts.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceipts.DataKeys(e.CommandArgument).Values("MRNNo")
        SIS.VR.vrLorryReceipts.InitiateWF(ProjectID, MRNNo)
        GVvrLorryReceipts.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub GVvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceipts.Init
    DataClassName = "GvrLorryReceipts"
    SetGridView = GVvrLorryReceipts
  End Sub
  Protected Sub TBLvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceipts.Init
    SetToolBar = TBLvrLorryReceipts
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
  Protected Sub F_LRStatusID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_LRStatusID.SelectedIndexChanged
    Session("F_LRStatusID") = F_LRStatusID.SelectedValue
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
    F_LRStatusID.SelectedValue = String.Empty
    If Not Session("F_LRStatusID") Is Nothing Then
      If Session("F_LRStatusID") <> String.Empty Then
        F_LRStatusID.SelectedValue = Session("F_LRStatusID")
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
  '  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
  '    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
  '    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
  '    Dim CardNo As String = ""
  '    Dim PrjID As String = ""
  '    Try
  '      With F_FileUpload
  '        If .HasFile Then
  '          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
  '          Dim tmpName As String = IO.Path.GetRandomFileName()
  '          Dim tmpFile As String = tmpPath & "\\" & tmpName
  '          .SaveAs(tmpFile)
  '          Dim fi As FileInfo = New FileInfo(tmpFile)
  '          Using xlP As ExcelPackage = New ExcelPackage(fi)
  '            Dim wsD As ExcelWorksheet = Nothing
  '            Dim wsG As ExcelWorksheet = Nothing
  '            Try
  '              wsD = xlP.Workbook.Worksheets("MRN")
  '              wsG = xlP.Workbook.Worksheets("GRDetails")
  '            Catch ex As Exception
  '              wsD = Nothing
  '              wsG = Nothing
  '            End Try
  '            '1. Process Document
  '            If wsD Is Nothing Then
  '              errMsg.Text = "XL File does not have MRN, Invalid MS-EXCEL file."
  '              xlP.Dispose()
  '              Exit Sub
  '              '*******
  '            End If
  '            Dim MrnNo As String = ""
  '            Dim tMrnNo As String = ""
  '            For I As Integer = 3 To 9000
  '              PrjID = wsD.Cells(I, 1).Text
  '              If PrjID = String.Empty Then Exit For
  '              tMrnNo = wsD.Cells(I, 2).Text
  '              MrnNo = wsD.Cells(I, 3).Text
  '              Dim Found As Boolean = False
  '              Dim Mrn As SIS.VR.vrLorryReceipts = Nothing
  '              If MrnNo <> String.Empty Then
  '                Mrn = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(PrjID, MrnNo)
  '                If Mrn IsNot Nothing Then
  '                  Found = True
  '                End If
  '              End If
  '              If Not Found Then
  '                Mrn = New SIS.VR.vrLorryReceipts
  '              End If
  '              With Mrn
  '                Try
  '                  .ProjectID = wsD.Cells(I, 1).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .MRNNo = wsD.Cells(I, 3).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  Dim aTmp() As String = wsD.Cells(I, 4).Text.Split("|".ToCharArray)
  '                  .MRNDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
  '                Catch ex As Exception
  '                End Try
  '                'Try
  '                '  .CustomerID = wsD.Cells(I, 5).Text
  '                'Catch ex As Exception
  '                'End Try
  '                Try
  '                  Dim aTmp() As String = wsD.Cells(I, 5).Text.Split("|".ToCharArray)
  '                  .VehicleInDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2) & " " & aTmp(3) & ":00:00"
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  Dim aTmp() As String = wsD.Cells(I, 6).Text.Split("|".ToCharArray)
  '                  .VehicleOutDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2) & " " & aTmp(3) & ":00:00"
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .TransporterID = wsD.Cells(I, 7).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .TransporterName = wsD.Cells(I, 8).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .VehicleRegistrationNo = wsD.Cells(I, 9).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .WayBillFormNo = wsD.Cells(I, 10).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .PaymentMadeAtSite = IIf(wsD.Cells(I, 11).Text.ToLower = "yes", True, False)
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .AmountPaid = wsD.Cells(I, 12).Text
  '                Catch ex As Exception
  '                  .AmountPaid = 0
  '                End Try
  '                Try
  '                  .VehicleTypeID = wsD.Cells(I, 13).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .VehicleType = wsD.Cells(I, 14).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .VehicleLengthInFt = IIf(wsD.Cells(I, 15).Text = String.Empty, 0, wsD.Cells(I, 15).Text)
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .VechicleWidthInFt = IIf(wsD.Cells(I, 16).Text = String.Empty, 0, wsD.Cells(I, 16).Text)
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .VehicleHeightInFt = IIf(wsD.Cells(I, 17).Text = String.Empty, 0, wsD.Cells(I, 17).Text)
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .OverDimensionConsignment = wsD.Cells(I, 18).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .DetentionAtSite = wsD.Cells(I, 19).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .ReasonForDetention = wsD.Cells(I, 20).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .MaterialStateID = wsD.Cells(I, 21).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .RemarksForDamageOrShortage = wsD.Cells(I, 22).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .DriverNameAndContactNo = wsD.Cells(I, 23).Text
  '                Catch ex As Exception
  '                End Try
  '                Try
  '                  .OtherRemarks = wsD.Cells(I, 24).Text
  '                Catch ex As Exception
  '                End Try
  '                .CreatedBy = HttpContext.Current.Session("LoginID")
  '                .CreatedOn = Now
  '                .LRStatusID = 2
  '                .RequestExecutionNo = ""
  '              End With
  '              Try
  '                If Found Then
  '                  SIS.VR.vrLorryReceipts.UpdateData(Mrn)
  '                  wsD.Cells(I, 25).Value = "updated"
  '                Else
  '                  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
  '                    Using Cmd As SqlCommand = Con.CreateCommand()
  '                      Cmd.CommandType = CommandType.Text
  '                      Cmd.CommandText = "select isnull(max(mrnno),0) from vr_lorryreceipts where projectid = '" & Mrn.ProjectID & "'"
  '                      Con.Open()
  '                      MrnNo = Cmd.ExecuteScalar()
  '                      MrnNo = MrnNo + 1
  '                    End Using
  '                  End Using
  '                  Mrn.MRNNo = MrnNo
  '                  Mrn = SIS.VR.vrLorryReceipts.InsertData(Mrn)
  '                  wsD.Cells(I, 3).Value = Mrn.MRNNo
  '                  wsD.Cells(I, 25).Value = "Inserted"
  '                  MrnNo = Mrn.MRNNo
  '                End If
  '              Catch ex As Exception
  '                wsD.Cells(I, 25).Value = ex.Message.ToString
  '              End Try
  '              'GR Entry of MRN
  '              Dim mrnFound As Boolean = False
  '              For J As Integer = 1 To 90000
  '                If wsG.Cells(J, 1).Text = String.Empty Then
  '                  Exit For
  '                End If
  '                If wsG.Cells(J, 1).Text = PrjID And wsG.Cells(J, 2).Text = tMrnNo Then
  '                  mrnFound = True
  '                  Dim NewGR As Boolean = False
  '                  Dim SerialNo As String = wsG.Cells(J, 4).Text
  '                  Dim oGR As SIS.VR.vrLorryReceiptDetails = Nothing
  '                  If wsG.Cells(J, 3).Text <> String.Empty Then
  '                    oGR = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetByID(PrjID, MrnNo, SerialNo)
  '                  Else
  '                    'Not inserted earlier
  '                    oGR = New SIS.VR.vrLorryReceiptDetails
  '                    NewGR = True
  '                  End If
  '                  oGR.ProjectID = PrjID
  '                  oGR.MRNNo = MrnNo
  '                  'Serial No will be auto available
  '                  Try
  '                    oGR.GRorLRNo = wsG.Cells(J, 5).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    Dim aTmp() As String = wsG.Cells(J, 6).Text.Split("|".ToCharArray)
  '                    oGR.GRorLRDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.SupplierID = wsG.Cells(J, 7).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.SupplierName = wsG.Cells(J, 8).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.SupplierInvoiceNo = wsG.Cells(J, 9).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    Dim aTmp() As String = wsG.Cells(J, 10).Text.Split("|".ToCharArray)
  '                    oGR.SupplierInvoiceDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.WeightAsPerInvoiceInKG = wsG.Cells(J, 11).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.WeightReceived = wsG.Cells(J, 12).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.MaterialForm = wsG.Cells(J, 13).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.NoOfPackagesAsPerInvoice = wsG.Cells(J, 14).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.NoOfPackagesReceived = wsG.Cells(J, 15).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.CenvatInvoiceReceived = wsG.Cells(J, 16).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    oGR.Remarks = wsG.Cells(J, 17).Text
  '                  Catch ex As Exception
  '                  End Try
  '                  Try
  '                    If NewGR Then
  '                      oGR = SIS.VR.vrLorryReceiptDetails.InsertData(oGR)
  '                      wsG.Cells(J, 3).Value = MrnNo
  '                      wsG.Cells(J, 4).Value = oGR.SerialNo
  '                      wsG.Cells(J, 18).Value = "Inserted"
  '                    Else
  '                      oGR = SIS.VR.vrLorryReceiptDetails.UpdateData(oGR)
  '                      wsG.Cells(J, 18).Value = "Updated"
  '                    End If
  '                  Catch ex As Exception
  '                    wsG.Cells(J, 18).Value = ex.Message.ToString
  '                  End Try
  '                Else
  '                  If mrnFound Then
  '                    Exit For
  '                  End If
  '                End If
  '              Next
  '              'End of GR Entry 
  '            Next 'Item Line
  '            '====================
  '            'check missing mrn MRN in Excel and Insert at Bottom
  '            '6 MRN Header & MRN Details
  '            Dim TemplateName As String = "MRN_Template.xlsm"
  '            Dim tmpF As String = Server.MapPath("~/App_Templates/" & TemplateName)
  '            Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
  '            IO.File.Copy(tmpF, FileName)
  '            Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
  '            Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

  '            Dim r As Integer
  '            Dim c As Integer
  '            Dim aFld() As String
  '            Dim aFldd() As String
  '            Dim xlWSd As ExcelWorksheet = xlPk.Workbook.Worksheets("GRDetails")
  '            Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("MRN")
  '            r = 3
  '            c = 1
  '            ReDim aFld(0)
  '            Do While xlWS.Cells(r, c).Text <> String.Empty
  '              ReDim Preserve aFld(c - 1)
  '              aFld(c - 1) = xlWS.Cells(r, c).Text
  '              xlWS.Cells(r, c).Value = ""
  '              c += 1
  '            Loop
  '            Dim rd As Integer = 3
  '            c = 1
  '            ReDim aFldd(0)
  '            Do While xlWSd.Cells(rd, c).Text <> String.Empty
  '              ReDim Preserve aFldd(c - 1)
  '              aFldd(c - 1) = xlWSd.Cells(rd, c).Text
  '              xlWSd.Cells(rd, c).Value = ""
  '              c += 1
  '            Loop
  '            xlWSd.Dispose()
  '            xlWS.Dispose()
  '            xlPk.Dispose()
  '            'Initialize Last Row of GR Sheet
  '            For rd = 3 To 99000
  '              If wsG.Cells(rd, 1).Text = String.Empty Then Exit For
  '            Next
  '            'End RD
  '            Dim oMrns As List(Of SIS.VR.vrLorryReceipts) = SIS.VR.vrLorryReceipts.GetByProjectID(PrjID, "MRNNo")
  '            For Each doc As SIS.VR.vrLorryReceipts In oMrns
  '              'find MRN in
  '              Dim Found As Boolean = False
  '              Dim I As Integer = 3
  '              For I = 3 To 99000
  '                If wsD.Cells(I, 1).Text = String.Empty Then Exit For
  '                If doc.MRNNo = wsD.Cells(I, 3).Text Then
  '                  Found = True
  '                  Exit For
  '                End If
  '              Next
  '              If Not Found Then
  '                r = I
  '                With wsD
  '                  For c = 0 To aFld.Length
  '                    Dim aTmp() As String = aFld(c).Split(".".ToCharArray)
  '                    If aTmp.Length > 1 Then
  '                      Dim oBj As Object = CallByName(doc, aTmp(0), CallType.Get)
  '                      .Cells(r, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
  '                    Else
  '                      .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
  '                    End If
  '                  Next
  '                End With
  '                Dim oMrnds As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "SerialNo", False, "", doc.ProjectID, doc.MRNNo)
  '                With wsG
  '                  For Each docd As SIS.VR.vrLorryReceiptDetails In oMrnds
  '                    For c = 0 To aFldd.Length
  '                      Dim aTmp() As String = aFldd(c).Split(".".ToCharArray)
  '                      If aTmp.Length > 1 Then
  '                        Dim oBj As Object = CallByName(docd, aTmp(0), CallType.Get)
  '                        .Cells(rd, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
  '                      Else
  '                        .Cells(rd, c + 1).Value = CallByName(docd, aFldd(c), CallType.Get)
  '                      End If
  '                    Next
  '                    rd += 1
  '                  Next
  '                End With
  '              End If
  '            Next
  '            'End of check and Insert
  '            '======================
  '            xlP.Save()
  '            wsD.Dispose()
  '            wsG.Dispose()
  '            xlP.Dispose()
  '          End Using
  '          Dim FileNameForUser As String = F_FileUpload.FileName
  '          If IO.File.Exists(tmpFile) Then
  '            '===============
  '            'Reverse Update
  '            Dim FileInfo As IO.FileInfo = New IO.FileInfo(tmpFile)
  '            Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

  '            '1.
  '            Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("SUP")
  '            Dim oBPs As List(Of lgBP) = lgBP.GetDataFromBaaN("SUP")
  '            Dim r As Integer = 1
  '            Dim c As Integer = 1
  '            Dim cnt As Integer = 1
  '            With xlWS
  '              .Cells.Clear()
  '              .Cells(r, 2).Value = ""
  '              .Cells(r, 1).Value = "---NOT IN LIST---"
  '              r += 1
  '              For Each bp As lgBP In oBPs
  '                .Cells(r, 2).Value = bp.t_bpid
  '                .Cells(r, 1).Value = bp.t_nama
  '                r += 1
  '              Next
  '            End With
  '            xlWS = xlPk.Workbook.Worksheets("VType")
  '            Dim oVTyps As List(Of SIS.VR.vrVehicleTypes) = SIS.VR.vrVehicleTypes.vrVehicleTypesSelectList("")
  '            r = 1
  '            c = 1
  '            With xlWS
  '              .Cells.Clear()
  '              .Cells(r, 2).Value = ""
  '              .Cells(r, 1).Value = "---NOT IN LIST---"
  '              .Cells(r, 3).Value = 0
  '              .Cells(r, 4).Value = 0
  '              .Cells(r, 5).Value = 0
  '              r += 1
  '              For Each vt As SIS.VR.vrVehicleTypes In oVTyps
  '                .Cells(r, 1).Value = vt.cmba
  '                .Cells(r, 2).Value = vt.VehicleTypeID
  '                .Cells(r, 3).Value = vt.LengthInFt
  '                .Cells(r, 4).Value = vt.WidthInFt
  '                .Cells(r, 5).Value = vt.HeightInFt
  '                r += 1
  '              Next
  '            End With
  '            xlPk.Save()
  '            xlWS.Dispose()
  '            xlPk.Dispose()
  '            'end of reverse update
  '            '======================
  '            Response.Clear()
  '            Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser )
  '            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
  '            Response.WriteFile(tmpFile)
  '            HttpContext.Current.Server.ScriptTimeout = st
  '            Response.End()
  '          End If
  '        End If
  '      End With
  '    Catch ex As Exception
  '      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString() & " : " & CardNo)
  '      Dim script As String = String.Format("alert({0});", message)
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
  '    End Try
  'over:
  '  End Sub
  Private Function DuplicateMRN(ByVal Mrn As SIS.VR.vrLorryReceipts) As Boolean
    Dim mRet As Boolean = False
    Dim cnt As Integer = 0
    Dim Sql As String = ""
    Sql &= " select isnull(count(*),0) from vr_lorryreceipts where "
    Sql &= " ProjectID = '" & Mrn.ProjectID & "'"
    Sql &= " and MRNDate = Convert(DateTime,'" & Mrn.MRNDate & "',103)"
    Sql &= " and VehicleInDate = Convert(DateTime,'" & Mrn.VehicleInDate & "',103)"
    Sql &= " and VehicleOutDate = Convert(DateTime,'" & Mrn.VehicleOutDate & "',103)"
    If Mrn.TransporterID <> "" Then
      Sql &= " and TransporterID = '" & Mrn.TransporterID & "'"
    End If
    Sql &= " and VehicleRegistrationNo = '" & Mrn.VehicleRegistrationNo & "'"
    If Mrn.WayBillFormNo <> "" Then
      Sql &= " and WayBillFormNo = '" & Mrn.WayBillFormNo & "'"
    End If
    Sql &= " and LRStatusID = '" & Mrn.LRStatusID & "'"
    Sql &= " and VehicleTypeID = '" & Mrn.VehicleTypeID & "'"
    Sql &= " and OverDimensionConsignment = '" & Mrn.OverDimensionConsignment & "'"
    Sql &= " and DetentionAtSite = '" & Mrn.DetentionAtSite & "'"
    Sql &= " and MaterialStateID = '" & Mrn.MaterialStateID & "'"
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Con.Open()
        cnt = Cmd.ExecuteScalar()
      End Using
    End Using
    If cnt > 0 Then
      mRet = True
    End If
    Return mRet
  End Function
  Protected Sub cmdFileUpload_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles cmdFileUpload.Command
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim CardNo As String = ""
    Dim PrjID As String = ""
    Try
      With F_FileUpload
        If .HasFile Then
          Dim tmpPath As String = Server.MapPath("~/../App_Temp")
          Dim tmpName As String = IO.Path.GetRandomFileName()
          Dim tmpFile As String = tmpPath & "\\" & tmpName
          .SaveAs(tmpFile)
          Dim fi As FileInfo = New FileInfo(tmpFile)
          Using xlP As ExcelPackage = New ExcelPackage(fi)
            Dim wsD As ExcelWorksheet = Nothing
            Dim wsG As ExcelWorksheet = Nothing
            Try
              wsD = xlP.Workbook.Worksheets("MRN")
              wsG = xlP.Workbook.Worksheets("GRDetails")
            Catch ex As Exception
              wsD = Nothing
              wsG = Nothing
            End Try
            '1. Process Document
            If wsD Is Nothing Then
              errMsg.Text = "XL File does not have MRN, Invalid MS-EXCEL file."
              xlP.Dispose()
              Exit Sub
              '*******
            End If
            Dim MrnNo As String = ""
            Dim tMrnNo As String = ""
            For I As Integer = 3 To 9000
              PrjID = wsD.Cells(I, 1).Text
              If PrjID = String.Empty Then Exit For
              MrnNo = wsD.Cells(I, 3).Text
              If MrnNo <> String.Empty Then Continue For
              tMrnNo = wsD.Cells(I, 2).Text
              Dim Found As Boolean = False
              Dim Mrn As New SIS.VR.vrLorryReceipts
              With Mrn
                Try
                  .ProjectID = wsD.Cells(I, 1).Text
                Catch ex As Exception
                End Try
                Try
                  .MRNNo = wsD.Cells(I, 3).Text
                Catch ex As Exception
                End Try
                Try
                  Dim aTmp() As String = wsD.Cells(I, 4).Text.Split("|".ToCharArray)
                  .MRNDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
                Catch ex As Exception
                End Try
                Try
                  Dim aTmp() As String = wsD.Cells(I, 5).Text.Split("|".ToCharArray)
                  .VehicleInDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2) & " " & aTmp(3) & ":00:00"
                Catch ex As Exception
                End Try
                Try
                  Dim aTmp() As String = wsD.Cells(I, 6).Text.Split("|".ToCharArray)
                  .VehicleOutDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2) & " " & aTmp(3) & ":00:00"
                Catch ex As Exception
                End Try
                Try
                  .TransporterID = wsD.Cells(I, 7).Text
                Catch ex As Exception
                End Try
                Try
                  .TransporterName = wsD.Cells(I, 8).Text
                Catch ex As Exception
                End Try
                Try
                  .VehicleRegistrationNo = wsD.Cells(I, 9).Text
                Catch ex As Exception
                End Try
                Try
                  .WayBillFormNo = wsD.Cells(I, 10).Text
                Catch ex As Exception
                End Try
                Try
                  .PaymentMadeAtSite = IIf(wsD.Cells(I, 11).Text.ToLower = "yes", True, False)
                Catch ex As Exception
                End Try
                Try
                  .AmountPaid = wsD.Cells(I, 12).Text
                Catch ex As Exception
                  .AmountPaid = 0
                End Try
                Try
                  .VehicleTypeID = wsD.Cells(I, 13).Text
                Catch ex As Exception
                End Try
                Try
                  .VehicleType = wsD.Cells(I, 14).Text
                Catch ex As Exception
                End Try
                Try
                  .VehicleLengthInFt = IIf(wsD.Cells(I, 15).Text = String.Empty, 0, wsD.Cells(I, 15).Text)
                Catch ex As Exception
                End Try
                Try
                  .VechicleWidthInFt = IIf(wsD.Cells(I, 16).Text = String.Empty, 0, wsD.Cells(I, 16).Text)
                Catch ex As Exception
                End Try
                Try
                  .VehicleHeightInFt = IIf(wsD.Cells(I, 17).Text = String.Empty, 0, wsD.Cells(I, 17).Text)
                Catch ex As Exception
                End Try
                Try
                  .OverDimensionConsignment = wsD.Cells(I, 18).Text
                Catch ex As Exception
                End Try
                Try
                  .DetentionAtSite = wsD.Cells(I, 19).Text
                Catch ex As Exception
                End Try
                Try
                  .ReasonForDetention = wsD.Cells(I, 20).Text
                Catch ex As Exception
                End Try
                Try
                  .MaterialStateID = wsD.Cells(I, 21).Text
                Catch ex As Exception
                End Try
                Try
                  .RemarksForDamageOrShortage = wsD.Cells(I, 22).Text
                Catch ex As Exception
                End Try
                Try
                  .DriverNameAndContactNo = wsD.Cells(I, 23).Text
                Catch ex As Exception
                End Try
                Try
                  .OtherRemarks = wsD.Cells(I, 24).Text
                Catch ex As Exception
                End Try
                .CreatedBy = HttpContext.Current.Session("LoginID")
                .CreatedOn = Now
                .LRStatusID = 2
                .RequestExecutionNo = ""
              End With
              '====================================
              If Convert.ToDateTime(Mrn.MRNDate).Date > Now.Date Then
                wsD.Cells(I, 25).Value = "Future Date MRN can NOT be uploaded."
                Continue For
              End If
              If Convert.ToDateTime(Mrn.MRNDate).Date < Convert.ToDateTime(Mrn.VehicleInDate).Date Then
                wsD.Cells(I, 25).Value = "MRN Date can NOT be less than Vehicle In date."
                Continue For
              End If
              If Convert.ToDateTime(Mrn.VehicleOutDate) < Convert.ToDateTime(Mrn.VehicleInDate) Then
                wsD.Cells(I, 25).Value = "Vehicle Out Date can NOT be less than Vehicle In date."
                Continue For
              End If
              'Check Mrn Header for Duplicate Entry
              If DuplicateMRN(Mrn) Then
                wsD.Cells(I, 25).Value = "Already Exists.[Pl. download latest template for Project.]"
                Continue For
              Else
                Try
                  Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
                    Using Cmd As SqlCommand = Con.CreateCommand()
                      Cmd.CommandType = CommandType.Text
                      Cmd.CommandText = "select isnull(max(mrnno),0) from vr_lorryreceipts where projectid = '" & Mrn.ProjectID & "'"
                      Con.Open()
                      MrnNo = Cmd.ExecuteScalar()
                      MrnNo = MrnNo + 1
                    End Using
                  End Using
                  Mrn.MRNNo = MrnNo
                  Mrn = SIS.VR.vrLorryReceipts.InsertData(Mrn)
                  wsD.Cells(I, 3).Value = Mrn.MRNNo
                  wsD.Cells(I, 25).Value = "Inserted"
                  MrnNo = Mrn.MRNNo
                Catch ex As Exception
                  wsD.Cells(I, 25).Value = ex.Message.ToString
                  MrnNo = ""
                End Try

              End If
              '====================================
              'GR Entry of MRN
              If MrnNo = "" Then Continue For
              Dim mrnFound As Boolean = False
              For J As Integer = 1 To 90000
                If wsG.Cells(J, 1).Text = String.Empty Then
                  Exit For
                End If
                If wsG.Cells(J, 1).Text = PrjID And wsG.Cells(J, 2).Text = tMrnNo And wsG.Cells(J, 3).Text = "" Then
                  mrnFound = True
                  Dim SerialNo As String = wsG.Cells(J, 4).Text
                  Dim oGR As New SIS.VR.vrLorryReceiptDetails
                  oGR.ProjectID = PrjID
                  oGR.MRNNo = MrnNo
                  'Serial No will be auto available
                  Try
                    oGR.GRorLRNo = wsG.Cells(J, 5).Text
                  Catch ex As Exception
                  End Try
                  Try
                    Dim aTmp() As String = wsG.Cells(J, 6).Text.Split("|".ToCharArray)
                    oGR.GRorLRDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.SupplierID = wsG.Cells(J, 7).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.SupplierName = wsG.Cells(J, 8).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.SupplierInvoiceNo = wsG.Cells(J, 9).Text
                  Catch ex As Exception
                  End Try
                  Try
                    Dim aTmp() As String = wsG.Cells(J, 10).Text.Split("|".ToCharArray)
                    oGR.SupplierInvoiceDate = aTmp(0) & "/" & aTmp(1) & "/" & aTmp(2)
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.WeightAsPerInvoiceInKG = wsG.Cells(J, 11).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.WeightReceived = wsG.Cells(J, 12).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.MaterialForm = wsG.Cells(J, 13).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.NoOfPackagesAsPerInvoice = wsG.Cells(J, 14).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.NoOfPackagesReceived = wsG.Cells(J, 15).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.CenvatInvoiceReceived = wsG.Cells(J, 16).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR.Remarks = wsG.Cells(J, 17).Text
                  Catch ex As Exception
                  End Try
                  Try
                    oGR = SIS.VR.vrLorryReceiptDetails.InsertData(oGR)
                    wsG.Cells(J, 3).Value = MrnNo
                    wsG.Cells(J, 4).Value = oGR.SerialNo
                    wsG.Cells(J, 18).Value = "Inserted"
                  Catch ex As Exception
                    wsG.Cells(J, 18).Value = ex.Message.ToString
                  End Try
                Else
                  If mrnFound Then
                    Exit For
                  End If
                End If
              Next
              'End of GR Entry 
            Next 'Item Line
            '====================
            'check missing mrn MRN in Excel and Insert at Bottom
            '6 MRN Header & MRN Details
            Dim TemplateName As String = "MRN_Template.xlsm"
            Dim tmpF As String = Server.MapPath("~/App_Templates/" & TemplateName)
            Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
            IO.File.Copy(tmpF, FileName)
            Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
            Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

            Dim r As Integer
            Dim c As Integer
            Dim aFld() As String
            Dim aFldd() As String
            Dim xlWSd As ExcelWorksheet = xlPk.Workbook.Worksheets("GRDetails")
            Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("MRN")
            r = 3
            c = 1
            ReDim aFld(0)
            Do While xlWS.Cells(r, c).Text <> String.Empty
              ReDim Preserve aFld(c - 1)
              aFld(c - 1) = xlWS.Cells(r, c).Text
              xlWS.Cells(r, c).Value = ""
              c += 1
            Loop
            Dim rd As Integer = 3
            c = 1
            ReDim aFldd(0)
            Do While xlWSd.Cells(rd, c).Text <> String.Empty
              ReDim Preserve aFldd(c - 1)
              aFldd(c - 1) = xlWSd.Cells(rd, c).Text
              xlWSd.Cells(rd, c).Value = ""
              c += 1
            Loop
            xlWSd.Dispose()
            xlWS.Dispose()
            xlPk.Dispose()
            'Initialize Last Row of GR Sheet
            For rd = 3 To 99000
              If wsG.Cells(rd, 1).Text = String.Empty Then Exit For
            Next
            'End RD
            Dim oMrns As List(Of SIS.VR.vrLorryReceipts) = SIS.VR.vrLorryReceipts.GetByProjectID(PrjID, "MRNNo")
            For Each doc As SIS.VR.vrLorryReceipts In oMrns
              'find MRN in
              Dim Found As Boolean = False
              Dim I As Integer = 3
              For I = 3 To 99000
                If wsD.Cells(I, 1).Text = String.Empty Then Exit For
                If doc.MRNNo = wsD.Cells(I, 3).Text Then
                  Found = True
                  Exit For
                End If
              Next
              If Not Found Then
                r = I
                With wsD
                  For c = 0 To aFld.Length
                    Dim aTmp() As String = aFld(c).Split(".".ToCharArray)
                    If aTmp.Length > 1 Then
                      Dim oBj As Object = CallByName(doc, aTmp(0), CallType.Get)
                      .Cells(r, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
                    Else
                      .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
                    End If
                  Next
                End With
                Dim oMrnds As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "SerialNo", False, "", doc.ProjectID, doc.MRNNo)
                With wsG
                  For Each docd As SIS.VR.vrLorryReceiptDetails In oMrnds
                    For c = 0 To aFldd.Length
                      Dim aTmp() As String = aFldd(c).Split(".".ToCharArray)
                      If aTmp.Length > 1 Then
                        Dim oBj As Object = CallByName(docd, aTmp(0), CallType.Get)
                        .Cells(rd, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
                      Else
                        .Cells(rd, c + 1).Value = CallByName(docd, aFldd(c), CallType.Get)
                      End If
                    Next
                    rd += 1
                  Next
                End With
              End If
            Next
            'End of check and Insert
            '======================
            xlP.Save()
            wsD.Dispose()
            wsG.Dispose()
            xlP.Dispose()
          End Using
          Dim FileNameForUser As String = F_FileUpload.FileName
          If IO.File.Exists(tmpFile) Then
            '===============
            'Reverse Update
            Dim FileInfo As IO.FileInfo = New IO.FileInfo(tmpFile)
            Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

            '1.
            Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("SUP")
            Dim oBPs As List(Of lgBP) = lgBP.GetDataFromBaaN("SUP")
            Dim r As Integer = 1
            Dim c As Integer = 1
            Dim cnt As Integer = 1
            With xlWS
              .Cells.Clear()
              .Cells(r, 2).Value = ""
              .Cells(r, 1).Value = "---NOT IN LIST---"
              r += 1
              For Each bp As lgBP In oBPs
                .Cells(r, 2).Value = bp.t_bpid
                .Cells(r, 1).Value = bp.t_nama
                r += 1
              Next
            End With
            xlWS = xlPk.Workbook.Worksheets("VType")
            Dim oVTyps As List(Of SIS.VR.vrVehicleTypes) = SIS.VR.vrVehicleTypes.vrVehicleTypesSelectList("")
            r = 1
            c = 1
            With xlWS
              .Cells.Clear()
              .Cells(r, 2).Value = ""
              .Cells(r, 1).Value = "---NOT IN LIST---"
              .Cells(r, 3).Value = 0
              .Cells(r, 4).Value = 0
              .Cells(r, 5).Value = 0
              r += 1
              For Each vt As SIS.VR.vrVehicleTypes In oVTyps
                .Cells(r, 1).Value = vt.cmba
                .Cells(r, 2).Value = vt.VehicleTypeID
                .Cells(r, 3).Value = vt.LengthInFt
                .Cells(r, 4).Value = vt.WidthInFt
                .Cells(r, 5).Value = vt.HeightInFt
                r += 1
              Next
            End With
            xlPk.Save()
            xlWS.Dispose()
            xlPk.Dispose()
            'end of reverse update
            '======================
            Response.Clear()
            Response.AppendHeader("content-disposition", "attachment; filename=" & FileNameForUser)
            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileNameForUser)
            Response.WriteFile(tmpFile)
            HttpContext.Current.Server.ScriptTimeout = st
            Response.End()
          End If
        End If
      End With
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString() & " : " & CardNo)
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
over:
  End Sub

  Protected Sub cmdDownload_Click(sender As Object, e As System.EventArgs) Handles cmdDownload.Click
    Dim st As Long = HttpContext.Current.Server.ScriptTimeout
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    'Creating Some change for GIT

    Dim ProjectID As String = F_DownloadPrjID.Text.ToUpper
    If ProjectID = String.Empty Then
      Dim message As String = New JavaScriptSerializer().Serialize("Project ID is required for Template download.")
      Dim script As String = String.Format("alert({0});", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Exit Sub
    End If
    Dim TemplateName As String = "MRN_Template.xlsm"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    If IO.File.Exists(tmpFile) Then
      Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
      IO.File.Copy(tmpFile, FileName)
      Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
      Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

      '1.
      Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("SUP")
      Dim oBPs As List(Of lgBP) = lgBP.GetDataFromBaaN("SUP")
      Dim r As Integer = 1
      Dim c As Integer = 1
      Dim cnt As Integer = 1
      With xlWS
        .Cells.Clear()
        .Cells(r, 2).Value = ""
        .Cells(r, 1).Value = "---NOT IN LIST---"
        r += 1
        For Each bp As lgBP In oBPs
          On Error Resume Next
          .Cells(r, 2).Value = bp.t_bpid
          .Cells(r, 1).Value = bp.t_nama
          r += 1
        Next
      End With

      '3. Only one Project and Customer
      xlWS = xlPk.Workbook.Worksheets("PRJ")
      oBPs = lgBP.GetDataFromBaaN("PRJ", ProjectID)
      r = 1
      c = 1
      With xlWS
        .Cells.Clear()
        For Each bp As lgBP In oBPs
          On Error Resume Next
          .Cells(r, 2).Value = bp.t_bpid
          .Cells(r, 1).Value = bp.t_nama
          .Cells(r, 3).Value = bp.CustomerName
          .Cells(r, 4).Value = bp.CustomerID
          r += 1
        Next
      End With
      '4.
      xlWS = xlPk.Workbook.Worksheets("VType")
      Dim oVTyps As List(Of SIS.VR.vrVehicleTypes) = SIS.VR.vrVehicleTypes.vrVehicleTypesSelectList("")
      r = 1
      c = 1
      With xlWS
        .Cells.Clear()
        .Cells(r, 2).Value = ""
        .Cells(r, 1).Value = "---NOT IN LIST---"
        .Cells(r, 3).Value = 0
        .Cells(r, 4).Value = 0
        .Cells(r, 5).Value = 0
        r = r + 1
        For Each vt As SIS.VR.vrVehicleTypes In oVTyps
          On Error Resume Next
          .Cells(r, 1).Value = vt.cmba
          .Cells(r, 2).Value = vt.VehicleTypeID
          .Cells(r, 3).Value = vt.LengthInFt
          .Cells(r, 4).Value = vt.WidthInFt
          .Cells(r, 5).Value = vt.HeightInFt
          r += 1
        Next
      End With
      '5.
      xlWS = xlPk.Workbook.Worksheets("MatState")
      Dim omSts As List(Of SIS.VR.vrMaterialStates) = SIS.VR.vrMaterialStates.vrMaterialStatesSelectList("")
      r = 1
      c = 1
      With xlWS
        .Cells.Clear()
        For Each mt As SIS.VR.vrMaterialStates In omSts
          On Error Resume Next
          .Cells(r, 1).Value = mt.Description
          .Cells(r, 2).Value = mt.MaterialStateID
          r += 1
        Next
      End With
      '6 MRN Header & MRN Details
      Dim aFld() As String
      Dim aFldd() As String
      Dim xlWSd As ExcelWorksheet = xlPk.Workbook.Worksheets("GRDetails")
      xlWS = xlPk.Workbook.Worksheets("MRN")
      r = 3
      c = 1
      ReDim aFld(0)
      Do While xlWS.Cells(r, c).Text <> String.Empty
        ReDim Preserve aFld(c - 1)
        aFld(c - 1) = xlWS.Cells(r, c).Text
        xlWS.Cells(r, c).Value = ""
        c += 1
      Loop
      Dim rd As Integer = 3
      c = 1
      ReDim aFldd(0)
      Do While xlWSd.Cells(rd, c).Text <> String.Empty
        ReDim Preserve aFldd(c - 1)
        aFldd(c - 1) = xlWSd.Cells(rd, c).Text
        xlWSd.Cells(rd, c).Value = ""
        c += 1
      Loop
      Dim oMrns As List(Of SIS.VR.vrLorryReceipts) = SIS.VR.vrLorryReceipts.GetByProjectID(ProjectID, "MRNNo")
      With xlWS
        On Error Resume Next
        For Each doc As SIS.VR.vrLorryReceipts In oMrns
          If r > 3 Then xlWS.InsertRow(r, 1, r + 1)
          For c = 0 To aFld.Length
            Dim aTmp() As String = aFld(c).Split(".".ToCharArray)
            If aTmp.Length > 1 Then
              Dim oBj As Object = CallByName(doc, aTmp(0), CallType.Get)
              .Cells(r, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
            Else
              .Cells(r, c + 1).Value = CallByName(doc, aFld(c), CallType.Get)
            End If
          Next
          Dim oMrnds As List(Of SIS.VR.vrLorryReceiptDetails) = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsSelectList(0, 999, "SerialNo", False, "", doc.ProjectID, doc.MRNNo)
          With xlWSd
            For Each docd As SIS.VR.vrLorryReceiptDetails In oMrnds
              If rd > 3 Then xlWSd.InsertRow(rd, 1, rd + 1)
              For c = 0 To aFldd.Length
                Dim aTmp() As String = aFldd(c).Split(".".ToCharArray)
                If aTmp.Length > 1 Then
                  Dim oBj As Object = CallByName(docd, aTmp(0), CallType.Get)
                  .Cells(rd, c + 1).Value = CallByName(oBj, aTmp(1), CallType.Get)
                Else
                  .Cells(rd, c + 1).Value = CallByName(docd, aFldd(c), CallType.Get)
                End If
              Next
              rd += 1
            Next
          End With
          r += 1
        Next
      End With
      xlPk.Save()
      xlPk.Dispose()

      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & ProjectID & "_Template.xlsm")
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(TemplateName)
      Response.WriteFile(FileName)
      HttpContext.Current.Server.ScriptTimeout = st
      Response.End()
    End If

  End Sub
End Class
Public Class lgBP
  Public Property t_bpid As String = ""
  Public Property t_nama As String = ""
  Public Property CustomerID As String = ""
  Public Property CustomerName As String = ""
  Public Shared Function GetDataFromBaaN(ByVal Typ As String, Optional ByVal ProjectID As String = "") As List(Of lgBP)
    Dim Results As List(Of lgBP) = Nothing
    Dim Sql As String = ""
    If Typ <> "PRJ" Then
      Sql = Sql & "select t_bpid,t_nama from ttccom100200 where ltrim(t_nama)<>'' and t_prst=2 and substring(t_bpid,1,3) = '" & Typ & "' order by t_nama"
    Else
      Sql = Sql & "select aa.t_cprj as t_bpid, aa.t_dsca as t_nama, bb.t_ofbp as CustomerID, cc.t_nama as CustomerName from ttcmcs052200 aa inner join ttppdm740200 bb on aa.t_cprj = bb.t_cprj inner join ttccom100200 as cc on bb.t_ofbp = cc.t_bpid where aa.t_cprj='" & ProjectID & "'"
    End If
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Results = New List(Of lgBP)()
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          Results.Add(New lgBP(Reader))
        End While
        Reader.Close()
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
