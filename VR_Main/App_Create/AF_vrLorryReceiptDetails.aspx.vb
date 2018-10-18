Partial Class AF_vrLorryReceiptDetails
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetails.Init
    DataClassName = "AvrLorryReceiptDetails"
    SetFormView = FVvrLorryReceiptDetails
  End Sub
  Protected Sub TBLvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetails.Init
    SetToolBar = TBLvrLorryReceiptDetails
  End Sub
  Protected Sub FVvrLorryReceiptDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetails.DataBound
    SIS.VR.vrLorryReceiptDetails.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVvrLorryReceiptDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetails.PreRender
    Dim oF_ProjectID_Display As Label  = FVvrLorryReceiptDetails.FindControl("F_ProjectID_Display")
    oF_ProjectID_Display.Text = String.Empty
    If Not Session("F_ProjectID_Display") Is Nothing Then
      If Session("F_ProjectID_Display") <> String.Empty Then
        oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
      End If
    End If
    Dim oF_ProjectID As TextBox  = FVvrLorryReceiptDetails.FindControl("F_ProjectID")
    oF_ProjectID.Enabled = True
    oF_ProjectID.Text = String.Empty
    If Not Session("F_ProjectID") Is Nothing Then
      If Session("F_ProjectID") <> String.Empty Then
        oF_ProjectID.Text = Session("F_ProjectID")
      End If
    End If
    Dim oF_MRNNo_Display As Label  = FVvrLorryReceiptDetails.FindControl("F_MRNNo_Display")
    oF_MRNNo_Display.Text = String.Empty
    If Not Session("F_MRNNo_Display") Is Nothing Then
      If Session("F_MRNNo_Display") <> String.Empty Then
        oF_MRNNo_Display.Text = Session("F_MRNNo_Display")
      End If
    End If
    Dim oF_MRNNo As TextBox  = FVvrLorryReceiptDetails.FindControl("F_MRNNo")
    oF_MRNNo.Enabled = True
    oF_MRNNo.Text = String.Empty
    If Not Session("F_MRNNo") Is Nothing Then
      If Session("F_MRNNo") <> String.Empty Then
        oF_MRNNo.Text = Session("F_MRNNo")
      End If
    End If
    Dim oF_SupplierID_Display As Label  = FVvrLorryReceiptDetails.FindControl("F_SupplierID_Display")
    Dim oF_SupplierID As TextBox  = FVvrLorryReceiptDetails.FindControl("F_SupplierID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrLorryReceiptDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptDetails", mStr)
    End If
    If Request.QueryString("ProjectID") IsNot Nothing Then
      CType(FVvrLorryReceiptDetails.FindControl("F_ProjectID"), TextBox).Text = Request.QueryString("ProjectID")
      CType(FVvrLorryReceiptDetails.FindControl("F_ProjectID"), TextBox).Enabled = False
    End If
    If Request.QueryString("MRNNo") IsNot Nothing Then
      CType(FVvrLorryReceiptDetails.FindControl("F_MRNNo"), TextBox).Text = Request.QueryString("MRNNo")
      CType(FVvrLorryReceiptDetails.FindControl("F_MRNNo"), TextBox).Enabled = False
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVvrLorryReceiptDetails.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVvrLorryReceiptDetails.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function MRNNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrLorryReceipts.SelectvrLorryReceiptsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceiptDetails_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceiptDetails_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1),String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceiptDetails_MRNNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ProjectID As String = CType(aVal(1),String)
    Dim MRNNo As Int32 = CType(aVal(2),Int32)
    Dim oVar As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID,MRNNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
