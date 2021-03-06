Imports System.Web.Script.Serialization
Partial Class EF_vrLorryReceiptDetails
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Public Property ProjectID() As String
    Get
      If ViewState("ProjectID") IsNot Nothing Then
        Return CType(ViewState("ProjectID"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("ProjectID", value)
    End Set
  End Property

  Protected Sub ODSvrLorryReceiptDetails_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceiptDetails.Selected
    Dim tmp As SIS.VR.vrLorryReceiptDetails = CType(e.ReturnValue, SIS.VR.vrLorryReceiptDetails)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
    ProjectID = tmp.ProjectID
  End Sub
  Protected Sub FVvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetails.Init
    DataClassName = "EvrLorryReceiptDetails"
    SetFormView = FVvrLorryReceiptDetails
  End Sub
  Protected Sub TBLvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetails.Init
    SetToolBar = TBLvrLorryReceiptDetails
  End Sub
  Protected Sub FVvrLorryReceiptDetails_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptDetails.PreRender
    TBLvrLorryReceiptDetails.EnableSave = Editable
    TBLvrLorryReceiptDetails.EnableDelete = Deleteable
    CType(FVvrLorryReceiptDetails.FindControl("RFVPONumber"), RequiredFieldValidator).Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings("IRNLinking"))
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLorryReceiptDetails.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptDetails") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptDetails", mStr)
    End If
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_VR_LorryReceiptDetails_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim SupplierID As String = CType(aVal(1), String)
    Dim oVar As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(SupplierID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  Protected Sub cmdShowIRN_Click(sender As Object, e As EventArgs)
    Dim PONumber As String = CType(FVvrLorryReceiptDetails.FindControl("F_PONumber"), TextBox).Text
    If PONumber = "" Then
      Dim message As String = New JavaScriptSerializer().Serialize("Please enter PO Number.")
      Dim script As String = String.Format("alert({0});$get('F_PONumber').focus();", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Exit Sub
    End If
    Dim SupplierID As String = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierID"), TextBox).Text
    Dim BillNo As String = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierInvoiceNo"), TextBox).Text
    Dim BillDate As String = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierInvoiceDate"), TextBox).Text
    Dim MrnNo As String = CType(FVvrLorryReceiptDetails.FindControl("F_MRNNo"), TextBox).Text
    Dim oMrn As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID, MrnNo)
    test.Show(ProjectID, PONumber, SupplierID, oMrn.TransporterID, "", "")
  End Sub
  Private Sub test_Execute(IRNo As String, ProjectID As String) Handles test.Execute
    If IRNo = "" Then Exit Sub
    CType(FVvrLorryReceiptDetails.FindControl("F_IRNO"), TextBox).Text = IRNo
    Dim oIR As SIS.VR.irnList = SIS.VR.irnList.GetByID(IRNo, ProjectID)
    If oIR IsNot Nothing Then
      Dim BillNo As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierInvoiceNo"), TextBox)
      Dim BillDate As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierInvoiceDate"), TextBox)
      Dim GrNo As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_GRorLRNo"), TextBox)
      Dim GrDate As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_GRorLRDate"), TextBox)
      If BillNo.Text = "" Then BillNo.Text = oIR.BillNo
      If BillDate.Text = "" Then BillDate.Text = oIR.BillDate
      If GrNo.Text = "" Then GrNo.Text = oIR.GRNo
      If GrDate.Text = "" Then GrDate.Text = oIR.GRDate
    End If
  End Sub
  Protected Sub F_PONumber_TextChanged(s As Object, e As EventArgs)
    Dim oF_ProjectID As TextBox = FVvrLorryReceiptDetails.FindControl("F_ProjectID")
    Dim ProjectID As String = oF_ProjectID.Text
    Dim oPONumber As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_PONumber"), TextBox)
    Dim PONumber As String = oPONumber.Text
    If PONumber = "" Then Exit Sub
    Dim oSupplierID As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierID"), TextBox)
    Dim oSupplierIDDisplay As Label = CType(FVvrLorryReceiptDetails.FindControl("F_SupplierID_Display"), Label)
    Dim oIRNO As TextBox = CType(FVvrLorryReceiptDetails.FindControl("F_IRNO"), TextBox)
    oSupplierID.Text = ""
    oSupplierIDDisplay.Text = ""
    oIRNO.Text = ""
    Dim oPO As SIS.PAK.pakPO = Nothing
    Try
      oPO = SIS.PAK.erpData.erpPO.ImportFromERP(PONumber)
      'Dim MrnNo As String = CType(FVvrLorryReceiptDetails.FindControl("F_MRNNo"), TextBox).Text
      'Dim oMrn As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID, MrnNo)
      If oPO.ProjectID <> ProjectID Then
        Dim message As String = New JavaScriptSerializer().Serialize("Purchase Order belongs to Project: " & oPO.ProjectID)
        Dim script As String = String.Format("alert({0});$get('F_PONumber').value='';$get('F_PONumber').focus();", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
        Exit Sub
      End If
      Dim oSup As SIS.VR.vrBusinessPartner = SIS.VR.vrBusinessPartner.vrBusinessPartnerGetByID(oPO.SupplierID)
      If oSup Is Nothing Then
        oSup = SIS.PAK.erpData.erpSupplier.GetFromERP(oPO.SupplierID)
        SIS.VR.vrBusinessPartner.InsertData(oSup)
      End If
      oSupplierID.Text = oPO.SupplierID
      oSupplierIDDisplay.Text = oSup.BPName
    Catch ex As Exception
      Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
      Dim script As String = String.Format("alert({0});$get('F_PONumber').value='';$get('F_PONumber').focus();", message)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
    End Try
  End Sub
End Class
