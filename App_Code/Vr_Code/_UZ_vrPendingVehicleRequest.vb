Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.Mail
Namespace SIS.VR
	Partial Public Class vrPendingVehicleRequest
		Public Shadows ReadOnly Property ForeColor() As System.Drawing.Color
			Get
				Return GetColor()
			End Get
		End Property
		Public Shadows Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Black
			Return mRet
		End Function
		Public ReadOnly Property EnableInput() As Boolean
			Get
				Dim mRet As Boolean = False
				If RequestStatus = RequestStates.UnderExecution Then
					mRet = True
				End If
				Return mRet
			End Get
		End Property
		Public Shadows ReadOnly Property InitiateWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If Me.RequestStatus = RequestStates.RequestLinked Then
						mRet = True
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public Shadows ReadOnly Property InitiateWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property ApproveWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If Me.RequestStatus = RequestStates.UnderExecution Or Me.RequestStatus = RequestStates.RequestLinked Then
						mRet = True
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property ApproveWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property RejectWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If Me.RequestStatus = RequestStates.UnderExecution Then
						mRet = True
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property RejectWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public Shared Function RejectWF(ByVal RequestNo As Int32, ByVal ReturnRemarks As String) As SIS.VR.vrPendingVehicleRequest
			Dim Results As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestGetByID(RequestNo)
			With Results
				.RequestStatus = RequestStates.Returned
				.ReturnRemarks = ReturnRemarks
				.ReturnedBy = HttpContext.Current.Session("LoginID")
				.ReturnedOn = Now
				'To Delete
				'If .SRNNo <> String.Empty Then
				'  Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.UZ_vrRequestExecutionGetByID(.SRNNo)
				'  With oRE
				'    .RequestStatusID = RequestStates.UnderExecution
				'    .ArrangedBy = HttpContext.Current.Session("LoginID")
				'    .ArrangedOn = Now
				'  End With
				'  SIS.VR.vrRequestExecution.UpdateData(oRE)
				'  .SRNNo = ""
				'End If
				'End to delete
			End With
			Results = SIS.VR.vrPendingVehicleRequest.UpdateData(Results)
			SendEMail(Results)
			Return Results
		End Function
		Public Shared Function UZ_vrPendingVehicleRequestSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal SupplierID As String, ByVal ProjectID As String, ByVal RequestedBy As String) As List(Of SIS.VR.vrPendingVehicleRequest)
			Dim Results As List(Of SIS.VR.vrPendingVehicleRequest) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_PendingVehicleRequestSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_PendingVehicleRequestSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_SupplierID", SqlDbType.NVarChar, 9, IIf(SupplierID Is Nothing, String.Empty, SupplierID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_RequestedBy", SqlDbType.NVarChar, 8, IIf(RequestedBy Is Nothing, String.Empty, RequestedBy))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatus", SqlDbType.Int, 10, RequestStates.UnderExecution)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					RecordCount = -1
					Results = New List(Of SIS.VR.vrPendingVehicleRequest)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrPendingVehicleRequest(Reader))
					End While
					Reader.Close()
					RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UZ_vrPendingVehicleRequestUpdate(ByVal Record As SIS.VR.vrPendingVehicleRequest) As SIS.VR.vrPendingVehicleRequest
			Dim _Result As SIS.VR.vrPendingVehicleRequest = vrPendingVehicleRequestUpdate(Record)
			Return _Result
		End Function
		Public Shared Shadows Function SendEMail(ByVal oRq As SIS.VR.vrPendingVehicleRequest) As String
			Dim mRet As String = ""
			'Get Requester
			Dim oEmp As SIS.QCM.qcmEmployees = SIS.QCM.qcmEmployees.qcmEmployeesGetByID(oRq.ReturnedBy)
			Dim oUG As List(Of SIS.VR.vrUserGroup) = SIS.VR.vrUserGroup.GetUserGroupByUserID(oRq.RequestedBy)
			'Get TO Executers
			Dim oExec As List(Of SIS.VR.vrUserGroup)
			If oRq.OutOfContract Then
				oExec = SIS.VR.vrUserGroup.GetOutOfContractByRoleID("Executer")
			Else
				oExec = SIS.VR.vrUserGroup.GetUsersByGroupIDRoleID(oUG(0).GroupID, "Executer")
			End If
			If oEmp.EMailID <> String.Empty And oExec.Count > 0 Then
				Try
					Dim oClient As SmtpClient = New SmtpClient()

					Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
					With oMsg
						Try
							.From = New MailAddress(oEmp.EMailID, oEmp.EmployeeName)
							.To.Add(New MailAddress(oRq.FK_VR_VehicleRequest_RequestedBy.EMailID, oRq.FK_VR_VehicleRequest_RequestedBy.UserFullName))
						Catch ex As Exception
						End Try
						For Each _ug As SIS.VR.vrUserGroup In oExec
							Try
								Dim oAD As MailAddress = New MailAddress(_ug.FK_VR_UserGroup_UserID.EMailID, _ug.FK_VR_UserGroup_UserID.UserFullName)
								If Not .CC.Contains(oAD) Then
									.CC.Add(oAD)
								End If
							Catch ex As Exception

							End Try
						Next
						.IsBodyHtml = True
						.Subject = "Returned: Vehicle Required On: " & oRq.VehicleRequiredOn & " @ Vendor: " & oRq.IDM_Vendors5_Description & " Project: " & oRq.IDM_Projects4_Description
						Dim sb As New StringBuilder
						With sb
							.AppendLine("<br/><b>Request is returned with following reason.</b>")
							.AppendLine("<br/>" & oRq.ReturnRemarks)
							.AppendLine("<br/>-------------------------------------------------------")
							.AppendLine("<br/>You are requested to arrange the vehicle as per following details.")
							.AppendLine("<br/><br/> ")
							.AppendLine("<br/><b>Supplier: </b>" & oRq.IDM_Vendors5_Description)
							.AppendLine("<br/>         " & oRq.SupplierLocation)
							.AppendLine("<br/><b>Project: </b>[" & oRq.ProjectID & "] " & oRq.IDM_Projects4_Description)
							.AppendLine("<br/><b>Delivery at: </b>" & oRq.DeliveryLocation)
							.AppendLine("<br/><br/> ")
							.AppendLine("<br/><b>Vehicle Type: </b>" & IIf(oRq.VR_VehicleTypes9_cmba = String.Empty, "***NOT SPECIFIED***", oRq.VR_VehicleTypes9_cmba))
							.AppendLine("<br/><b>Item Description: </b>" & oRq.ItemDescription)
						End With
						.Body = sb.ToString
						'Dim oAtchs As List(Of SIS.QCM.qcmRequestFiles) = SIS.QCM.qcmRequestFiles.qcmRequestFilesSelectList(0, 99, "", False, "", oRq.RequestID)
						'For Each atch As SIS.QCM.qcmRequestFiles In oAtchs
						'  IO.File.Copy(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings("RequestDir")) & "/" & atch.DiskFIleName, HttpContext.Current.Server.MapPath("~/App_Data/" & atch.FileName), True)
						'  .Attachments.Add(New System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath("~/App_Data/" & atch.FileName)))
						'Next
					End With
					oClient.Send(oMsg)
				Catch ex As Exception
					mRet = ex.Message
				End Try
			End If
			Return mRet
		End Function
	End Class
End Namespace
