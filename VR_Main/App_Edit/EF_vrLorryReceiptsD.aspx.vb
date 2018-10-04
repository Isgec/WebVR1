Partial Class EF_vrLorryReceiptsD
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
  Protected Sub ODSvrLorryReceiptsD_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrLorryReceiptsD.Selected
    Dim tmp As SIS.VR.vrLorryReceiptsD = CType(e.ReturnValue, SIS.VR.vrLorryReceiptsD)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVvrLorryReceiptsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptsD.Init
    DataClassName = "EvrLorryReceiptsD"
    SetFormView = FVvrLorryReceiptsD
  End Sub
  Protected Sub TBLvrLorryReceiptsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptsD.Init
    SetToolBar = TBLvrLorryReceiptsD
  End Sub
  Protected Sub FVvrLorryReceiptsD_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrLorryReceiptsD.PreRender
    TBLvrLorryReceiptsD.EnableSave = Editable
    TBLvrLorryReceiptsD.EnableDelete = Deleteable
    TBLvrLorryReceiptsD.PrintUrl &= Request.QueryString("ProjectID") & "|"
    TBLvrLorryReceiptsD.PrintUrl &= Request.QueryString("MRNNo") & "|"
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Edit") & "/EF_vrLorryReceiptsD.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrLorryReceiptsD") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrLorryReceiptsD", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvvrLorryReceiptDetailsDCC As New gvBase
  Protected Sub GVvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVvrLorryReceiptDetailsD.Init
    gvvrLorryReceiptDetailsDCC.DataClassName = "GvrLorryReceiptDetailsD"
    gvvrLorryReceiptDetailsDCC.SetGridView = GVvrLorryReceiptDetailsD
  End Sub
  Protected Sub TBLvrLorryReceiptDetailsD_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrLorryReceiptDetailsD.Init
    gvvrLorryReceiptDetailsDCC.SetToolBar = TBLvrLorryReceiptDetailsD
  End Sub
  Protected Sub GVvrLorryReceiptDetailsD_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVvrLorryReceiptDetailsD.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ProjectID As String = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("ProjectID")  
        Dim MRNNo As Int32 = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("MRNNo")  
        Dim SerialNo As Int32 = GVvrLorryReceiptDetailsD.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLvrLorryReceiptDetailsD.EditUrl & "?ProjectID=" & ProjectID & "&MRNNo=" & MRNNo & "&SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
      End Try
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function RequestExecutionNoCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.VR.vrRequestExecution.SelectvrRequestExecutionAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_LorryReceipts_ExecutionNo(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim RequestExecutionNo As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(RequestExecutionNo)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
