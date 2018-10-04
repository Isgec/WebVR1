Partial Class AF_vrPaymentProcess
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPaymentProcess.Init
    DataClassName = "AvrPaymentProcess"
    SetFormView = FVvrPaymentProcess
  End Sub
  Protected Sub TBLvrPaymentProcess_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrPaymentProcess.Init
    SetToolBar = TBLvrPaymentProcess
  End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProcessedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub FVvrPaymentProcess_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrPaymentProcess.PreRender
		Dim mStr As String = "<script type=""text/javascript""> "
		mStr = mStr & vbCrLf & " var script_vrPaymentProcess = {"
    Dim oF_ProcessedBy_Display As Label  = FVvrPaymentProcess.FindControl("F_ProcessedBy_Display")
    Dim oF_ProcessedBy As TextBox  = FVvrPaymentProcess.FindControl("F_ProcessedBy")
		mStr = mStr & vbCrLf &	"ACEProcessedBy_Selected: function(o, e) {"
		mStr = mStr & vbCrLf &	"  var F_ProcessedBy = $get('" & oF_ProcessedBy.ClientID & "');"
		mStr = mStr & vbCrLf &	"  var F_ProcessedBy_Display = $get('" & oF_ProcessedBy_Display.ClientID & "');"
		mStr = mStr & vbCrLf &	"  var retval = e.get_value();"
		mStr = mStr & vbCrLf &	"  var p = retval.split('|');"
		mStr = mStr & vbCrLf &	"  F_ProcessedBy_Display.innerHTML = e.get_text();"
		mStr = mStr & vbCrLf &	"},"
		mStr = mStr & vbCrLf &	"ACEProcessedBy_Populating: function(o,e) {"
		mStr = mStr & vbCrLf &	"  var p = o.get_element();"
		mStr = mStr & vbCrLf &	"  p.style.backgroundImage = 'url(../../images/loader.gif)';"
		mStr = mStr & vbCrLf &	"  p.style.backgroundRepeat = 'no-repeat';"
		mStr = mStr & vbCrLf &	"  p.style.backgroundPosition = 'right';"
		mStr = mStr & vbCrLf &	"  o._contextKey = '';"
		mStr = mStr & vbCrLf &	"},"
		mStr = mStr & vbCrLf &	"ACEProcessedBy_Populated: function(o,e) {"
		mStr = mStr & vbCrLf &	"  var p = o.get_element();"
		mStr = mStr & vbCrLf &	"  p.style.backgroundImage  = 'none';"
		mStr = mStr & vbCrLf &	"},"
    Dim oF_RequestStatusID As LC_vrRequestStates = FVvrPaymentProcess.FindControl("F_RequestStatusID")
    oF_RequestStatusID.Enabled = True
    oF_RequestStatusID.SelectedValue = String.Empty
    If Not Session("F_RequestStatusID") Is Nothing Then
      If Session("F_RequestStatusID") <> String.Empty Then
        oF_RequestStatusID.SelectedValue = Session("F_RequestStatusID")
      End If
    End If
		mStr = mStr & vbCrLf &	"validate_ProcessedBy: function(o) {"
		mStr = mStr & vbCrLf &	"    this.validated_FK_VR_PaymentProcess_ProcessedBy_main = true;"
		mStr = mStr & vbCrLf &	"    this.validate_FK_VR_PaymentProcess_ProcessedBy(o);"
		mStr = mStr & vbCrLf &	"  },"
		Dim FK_VR_PaymentProcess_ProcessedByProcessedBy As TextBox = FVvrPaymentProcess.FindControl("F_ProcessedBy")
		mStr = mStr & vbCrLf &	"validate_FK_VR_PaymentProcess_ProcessedBy: function(o) {"
		mStr = mStr & vbCrLf &	"  var value = o.id;"
		mStr = mStr & vbCrLf &	"  var ProcessedBy = $get('" & FK_VR_PaymentProcess_ProcessedByProcessedBy.ClientID & "');"
		mStr = mStr & vbCrLf &	"  if(ProcessedBy.value==''){"
		mStr = mStr & vbCrLf &	"    if(this.validated_FK_VR_PaymentProcess_ProcessedBy_main){"
		mStr = mStr & vbCrLf &	"      var o_d = $get(o.id +'_Display');"
		mStr = mStr & vbCrLf &	"      try{o_d.innerHTML = '';}catch(ex){}"
		mStr = mStr & vbCrLf &	"    }"
		mStr = mStr & vbCrLf &	"    return true;"
		mStr = mStr & vbCrLf &	"  }"
		mStr = mStr & vbCrLf &	"  value = value + ',' + ProcessedBy.value ;"
		mStr = mStr & vbCrLf &	"  o.style.backgroundImage  = 'url(../../images/pkloader.gif)';"
		mStr = mStr & vbCrLf &	"  o.style.backgroundRepeat= 'no-repeat';"
		mStr = mStr & vbCrLf &	"  o.style.backgroundPosition = 'right';"
		mStr = mStr & vbCrLf &	"  PageMethods.validate_FK_VR_PaymentProcess_ProcessedBy(value, this.validated_FK_VR_PaymentProcess_ProcessedBy);"
		mStr = mStr & vbCrLf &	"},"
		mStr = mStr & vbCrLf &	"validated_FK_VR_PaymentProcess_ProcessedBy_main: false,"
		mStr = mStr & vbCrLf &	"validated_FK_VR_PaymentProcess_ProcessedBy: function(result) {"
		mStr = mStr & vbCrLf &	"  var p = result.split('|');"
		mStr = mStr & vbCrLf &	"  var o = $get(p[1]);"
		mStr = mStr & vbCrLf &	"  if(script_vrPaymentProcess.validated_FK_VR_PaymentProcess_ProcessedBy_main){"
		mStr = mStr & vbCrLf &	"    var o_d = $get(p[1]+'_Display');"
		mStr = mStr & vbCrLf &	"    try{o_d.innerHTML = p[2];}catch(ex){}"
		mStr = mStr & vbCrLf &	"  }"
		mStr = mStr & vbCrLf &	"  o.style.backgroundImage  = 'none';"
		mStr = mStr & vbCrLf &	"  if(p[0]=='1'){"
		mStr = mStr & vbCrLf &	"    o.value='';"
		mStr = mStr & vbCrLf &	"    o.focus();"
		mStr = mStr & vbCrLf &	"  }"
		mStr = mStr & vbCrLf &	"},"
		mStr = mStr & vbCrLf &	"temp: function() {"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"}"
		mStr = mStr & vbCrLf &	"</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrPaymentProcess") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrPaymentProcess", mStr)
		End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVvrPaymentProcess.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVvrPaymentProcess.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_PaymentProcess_ProcessedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProcessedBy As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(ProcessedBy)
    If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|Record not found." 
    Else
			mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
