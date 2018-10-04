Partial Class AF_vrVehicleRequest
  Inherits SIS.SYS.InsertBase
  Protected Sub FVvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleRequest.Init
    DataClassName = "AvrVehicleRequest"
    SetFormView = FVvrVehicleRequest
  End Sub
  Protected Sub TBLvrVehicleRequest_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLvrVehicleRequest.Init
    SetToolBar = TBLvrVehicleRequest
  End Sub
	Protected Sub ODSvrVehicleRequest_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSvrVehicleRequest.Inserted
		If e.Exception Is Nothing Then
			Dim oDC As SIS.VR.vrVehicleRequest = CType(e.ReturnValue, SIS.VR.vrVehicleRequest)
			Dim tmpURL As String = "?tmp=1"
			tmpURL &= "&RequestNo=" & oDC.RequestNo
			TBLvrVehicleRequest.AfterInsertURL &= tmpURL
		End If
	End Sub
	Protected Sub FVvrVehicleRequest_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVvrVehicleRequest.PreRender
		Dim oF_SupplierID_Display As Label = FVvrVehicleRequest.FindControl("F_SupplierID_Display")
		oF_SupplierID_Display.Text = String.Empty
		If Not Session("F_SupplierID_Display") Is Nothing Then
			If Session("F_SupplierID_Display") <> String.Empty Then
				oF_SupplierID_Display.Text = Session("F_SupplierID_Display")
			End If
		End If
		Dim oF_SupplierID As TextBox = FVvrVehicleRequest.FindControl("F_SupplierID")
		oF_SupplierID.Enabled = True
		oF_SupplierID.Text = String.Empty
		If Not Session("F_SupplierID") Is Nothing Then
			If Session("F_SupplierID") <> String.Empty Then
				oF_SupplierID.Text = Session("F_SupplierID")
			End If
		End If
		Dim oF_ProjectID_Display As Label = FVvrVehicleRequest.FindControl("F_ProjectID_Display")
		oF_ProjectID_Display.Text = String.Empty
		If Not Session("F_ProjectID_Display") Is Nothing Then
			If Session("F_ProjectID_Display") <> String.Empty Then
				oF_ProjectID_Display.Text = Session("F_ProjectID_Display")
			End If
		End If
		Dim oF_ProjectID As TextBox = FVvrVehicleRequest.FindControl("F_ProjectID")
		oF_ProjectID.Enabled = True
		oF_ProjectID.Text = String.Empty
		If Not Session("F_ProjectID") Is Nothing Then
			If Session("F_ProjectID") <> String.Empty Then
				oF_ProjectID.Text = Session("F_ProjectID")
			End If
		End If
		Dim mStr As String = ""
		Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/VR_Main/App_Create") & "/AF_vrVehicleRequest.js")
		mStr = oTR.ReadToEnd
		oTR.Close()
		oTR.Dispose()
		If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptvrVehicleRequest") Then
			Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptvrVehicleRequest", mStr)
		End If
		If Request.QueryString("RequestNo") IsNot Nothing Then
			CType(FVvrVehicleRequest.FindControl("F_RequestNo"), TextBox).Text = Request.QueryString("RequestNo")
			CType(FVvrVehicleRequest.FindControl("F_RequestNo"), TextBox).Enabled = False
		End If
	End Sub
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function SupplierIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmVendors.SelectqcmVendorsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ProjectIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmProjects.SelectqcmProjectsAutoCompleteList(prefixText, count, contextKey)
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_ProjectID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim ProjectID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.qcmProjectsGetByID(ProjectID)
    If oVar Is Nothing Then
      oVar = SIS.QCM.qcmProjects.GetProjectFromERP(ProjectID)
      If oVar Is Nothing Then
        mRet = "1|" & aVal(0) & "|Record not found IN ERP."
      Else
        mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
      End If
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_VR_VehicleRequest_SupplierID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
		Dim SupplierID As String = CType(aVal(1),String)
		Dim oVar As SIS.QCM.qcmVendors = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
    If oVar Is Nothing Then
      SIS.QCM.qcmVendors.GetBPFromERP(SupplierID)
      oVar = SIS.QCM.qcmVendors.qcmVendorsGetByID(SupplierID)
      If oVar Is Nothing Then
        mRet = "1|" & aVal(0) & "|Record not found IN ERP."
      Else
        mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
      End If
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & oVar.Address1.Trim & " " & oVar.Address2 & " " & oVar.Address3 & " " & oVar.Address4
    End If
    Return mRet
  End Function
	<System.Web.Services.WebMethod()> _
	 Public Shared Function validate_ERPPONumber(ByVal value As String) As String
		Dim aVal() As String = value.Split(",".ToCharArray)
		Dim mRet As String = "0|" & aVal(0)
		Dim ERPPoNumber As String = CType(aVal(1), String)
		Dim oVar As SIS.VR.vrERPPo = SIS.VR.vrERPPo.vrERPPoGetByID(ERPPoNumber)
		If oVar Is Nothing Then
			mRet = "1|" & aVal(0) & "|PO Number NOT found in ERP LN."
		Else
			mRet = "0|" & aVal(0) & "|" & oVar.BuyerID & "|" & oVar.BuyerName
		End If
		Return mRet
	End Function

End Class
