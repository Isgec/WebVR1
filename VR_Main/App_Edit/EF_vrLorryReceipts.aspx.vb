Imports System.Web.Script.Serialization
Partial Class EF_vrLorryReceipts
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
  Protected Sub ODSvrLorryReceipts_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceipts.Selected
    Dim tmp As SIS.VR.vrLorryReceipts = CType(e.ReturnValue, SIS.VR.vrLorryReceipts)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceipts.Init
    DataClassName = "EvrLorryReceipts"
    SetFormView = FVvrLorryReceipts
  End Sub
  Protected Sub TBLvrLorryReceipts_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceipts.Init
    SetToolBar = TBLvrLorryReceipts
  End Sub
  Protected Sub FVvrLorryReceipts_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceipts.PreRender
    TBLvrLorryReceipts.EnableSave = Editable
    TBLvrLorryReceipts.EnableDelete = Deleteable
    TBLvrLorryReceiptDetails.EnableAdd = Editable
    TBLvrLorryReceipts.PrintUrl &= Request.QueryString("ProjectID") & "|"
    TBLvrLorryReceipts.PrintUrl &= Request.QueryString("MRNNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLorryReceipts.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceipts") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceipts", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvvrLorryReceiptDetailsCC As New gvBase
  Protected Sub GVvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceiptDetails.Init
    gvvrLorryReceiptDetailsCC.DataClassName = "GvrLorryReceiptDetails"
    gvvrLorryReceiptDetailsCC.SetGridView = GVvrLorryReceiptDetails
  End Sub
  Protected Sub TBLvrLorryReceiptDetails_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetails.Init
    gvvrLorryReceiptDetailsCC.SetToolBar = TBLvrLorryReceiptDetails
  End Sub
  Protected Sub GVvrLorryReceiptDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceiptDetails.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim SerialNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim RedirectUrl As String = TBLvrLorryReceiptDetails.EditUrl & "?ProjectID=" & ProjectID & "&MRNNo=" & MRNNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "lgLinkIR".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim SerialNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim oGR As SIS.VR.vrLorryReceiptDetails = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetByID(ProjectID, MRNNo, SerialNo)
        Dim oMrn As SIS.VR.vrLorryReceipts = SIS.VR.vrLorryReceipts.vrLorryReceiptsGetByID(ProjectID, MRNNo)
        Dim mStr As String = "<table style='width:100%;'>"
        mStr &= "<tr><td>Supplier: </td><td>" & oGR.VR_BusinessPartner2_BPName & "</td><td>" & "Bill No: </td><td>" & oGR.SupplierInvoiceNo & "</td><td>" & "Bill Date: </td><td>" & oGR.SupplierInvoiceDate & "</td></tr>"
        mStr &= "<tr><td>Transporter: </td><td>" & oMrn.VR_BusinessPartner3_BPName & "</td><td>" & "GR No: </td><td>" & oGR.GRorLRNo & "</td><td>" & "GR Date: </td><td>" & oGR.GRorLRDate & "</td></tr>"
        mStr &= "</table>"
        test.GRInfoToLink = mStr
        test.MRNNo = MRNNo
        test.SerialNo = SerialNo
        test.Show(ProjectID, oGR.SupplierID, oMrn.TransporterID, "", "")
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
    If e.CommandName.ToLower = "lgDeLinkIR".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("ProjectID")
        Dim MRNNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("MRNNo")
        Dim SerialNo As Int32 = GVvrLorryReceiptDetails.DataKeys(e.CommandArgument).Values("SerialNo")
        Dim oGR As SIS.VR.vrLorryReceiptDetails = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetByID(ProjectID, MRNNo, SerialNo)
        oGR.IRNO = ""
        SIS.VR.vrLorryReceiptDetails.UpdateData(oGR)
        GVvrLorryReceiptDetails.DataBind()
      Catch ex As Exception
        Dim message As String = New JavaScriptSerializer().Serialize(ex.Message.ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End Try
    End If
  End Sub
  Protected Sub TBLvrLorryReceiptDetails_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLvrLorryReceiptDetails.AddClicked
    Dim ProjectID As String = CType(FVvrLorryReceipts.FindControl("F_ProjectID"), TextBox).Text
    Dim MRNNo As Int32 = CType(FVvrLorryReceipts.FindControl("F_MRNNo"), TextBox).Text
    TBLvrLorryReceiptDetails.AddUrl &= "?ProjectID=" & ProjectID
    TBLvrLorryReceiptDetails.AddUrl &= "&MRNNo=" & MRNNo
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function RequestExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function TransporterIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrTransporters.SelectvrTransportersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function CustomerIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrBusinessPartner.SelectvrBusinessPartnerAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_VR_LorryReceipts_ExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim RequestExecutionNo As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(RequestExecutionNo)
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


  Private Sub test_Selected(IRNo As String, ProjectID As String, MRNNo As String, SerialNo As String) Handles test.Selected
    If IRNo = "" Then Exit Sub
    Dim oIR As SIS.VR.irnList = SIS.VR.irnList.GetByID(IRNo, ProjectID)
    Dim oGR As SIS.VR.vrLorryReceiptDetails = SIS.VR.vrLorryReceiptDetails.vrLorryReceiptDetailsGetByID(ProjectID, MRNNo, SerialNo)
    If oIR IsNot Nothing AndAlso oGR IsNot Nothing Then
      oGR.IRNO = IRNo
      SIS.VR.vrLorryReceiptDetails.UpdateData(oGR)
      Dim MisMatch As Boolean = False
      If oGR.SupplierInvoiceNo <> oIR.BillNo Then MisMatch = True
      If oGR.SupplierInvoiceDate <> oIR.BillDate Then MisMatch = True
      If oGR.GRorLRNo <> oIR.GRNo Then MisMatch = True
      If oGR.GRorLRDate <> oIR.GRDate Then MisMatch = True
      If oGR.SupplierID <> "" Then If oGR.SupplierID <> oIR.SupplierID Then MisMatch = True
      GVvrLorryReceiptDetails.DataBind()
      If MisMatch Then
        Dim message As String = New JavaScriptSerializer().Serialize("IRN Linked with MRN." & vbCrLf & "Warning: Selected IRN values are NOT matching with MRN.".ToString())
        Dim script As String = String.Format("alert({0});", message)
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      End If
    End If
  End Sub
End Class
