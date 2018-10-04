Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Mail
Imports System.Net.Mail
Namespace SIS.VR
  Partial Public Class vrExecutionApproval
    Public Shadows ReadOnly Property ApproveWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property ApproveWFEnable() As Boolean
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
        Dim mRet As Boolean = True
        Try
					mRet = GetVisible()
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
		Public Shared Shadows Function ApproveWF(ByVal SRNNo As Int32, ByVal ApprovalRemarks As String) As SIS.VR.vrExecutionApproval
			Dim oRE As SIS.VR.vrExecutionApproval = vrExecutionApprovalGetByID(SRNNo)
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
			If oRE.RequestStatusID = 28 Then 'Under Sanction Approval
				If oRE.Linked Then
					For Each le As SIS.VR.vrRequestExecution In oLEs
						With le
							.SanctionExceededApproved = True
							.RequestStatusID = 29	'Sanction Approved
							.SanctionApprovalRemarks = ApprovalRemarks
							.SanctionApprovedBy = HttpContext.Current.Session("LoginID")
							.SanctionApprovedOn = Now
							SIS.VR.vrRequestExecution.UpdateData(le)
						End With
					Next
				Else
					With oRE
						.SanctionExceededApproved = True
						.RequestStatusID = 29	'Sanction Approved
						.SanctionApprovalRemarks = ApprovalRemarks
						.SanctionApprovedBy = HttpContext.Current.Session("LoginID")
						.SanctionApprovedOn = Now
						SIS.VR.vrRequestExecution.UpdateData(oRE)
					End With
				End If
				Return oRE
			End If
			If oRE.Linked Then
				For Each le As SIS.VR.vrRequestExecution In oLEs
					With le
						If .RequestStatusID = RequestStates.ODCUnderApproval Then
							.RequestStatusID = RequestStates.ODCApproved
						ElseIf .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval Then
							.RequestStatusID = RequestStates.VehicleNotPlacedApproved
						ElseIf .RequestStatusID = RequestStates.DelayedPlacementUnderApproval Then
							.RequestStatusID = RequestStates.DelayedPlacementApproved
						ElseIf .RequestStatusID = RequestStates.EmptyReturnRUnderApproval Then
							.RequestStatusID = RequestStates.EmptyReturnApproved
						ElseIf .RequestStatusID = RequestStates.DetentionUnderApproval Then
							.RequestStatusID = RequestStates.DetentionApproved
						ElseIf .RequestStatusID = RequestStates.UnderSelfApproval Then
							.RequestStatusID = RequestStates.SelfApproved
						End If
						.ApprovalRemarks = ApprovalRemarks
						.ApprovedBy = HttpContext.Current.Session("LoginID")
						.ApprovedOn = Now
						le = SIS.VR.vrExecutionApproval.UpdateData(le)
					End With
				Next
			Else
				With oRE
					If .RequestStatusID = RequestStates.ODCUnderApproval Then
						.RequestStatusID = RequestStates.ODCApproved
					ElseIf .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval Then
						.RequestStatusID = RequestStates.VehicleNotPlacedApproved
					ElseIf .RequestStatusID = RequestStates.DelayedPlacementUnderApproval Then
						.RequestStatusID = RequestStates.DelayedPlacementApproved
					ElseIf .RequestStatusID = RequestStates.EmptyReturnRUnderApproval Then
						.RequestStatusID = RequestStates.EmptyReturnApproved
					ElseIf .RequestStatusID = RequestStates.DetentionUnderApproval Then
						.RequestStatusID = RequestStates.DetentionApproved
					ElseIf .RequestStatusID = RequestStates.UnderSelfApproval Then
						.RequestStatusID = RequestStates.SelfApproved
					End If
					.ApprovalRemarks = ApprovalRemarks
					.ApprovedBy = HttpContext.Current.Session("LoginID")
					.ApprovedOn = Now
				End With
				oRE = SIS.VR.vrExecutionApproval.UpdateData(oRE)
			End If
			SendEMail(oRE)
			Return oRE
		End Function
		Public Shared Function RejectWF(ByVal SRNNo As Int32, ByVal ApprovalRemarks As String) As SIS.VR.vrExecutionApproval
			Dim oRE As SIS.VR.vrExecutionApproval = vrExecutionApprovalGetByID(SRNNo)
			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.GetByLinkID(oRE.SRNNo, "")
			If oRE.RequestStatusID = 28 Then 'Under Sanction Approval
				If oRE.Linked Then
					For Each le As SIS.VR.vrRequestExecution In oLEs
						With le
							.RequestStatusID = 27
							.SanctionApprovalRemarks = ApprovalRemarks
							.SanctionApprovedBy = HttpContext.Current.Session("LoginID")
							.SanctionApprovedOn = Now
							SIS.VR.vrRequestExecution.UpdateData(le)
						End With
					Next
				Else
					With oRE
						.RequestStatusID = 27
						.SanctionApprovalRemarks = ApprovalRemarks
						.SanctionApprovedBy = HttpContext.Current.Session("LoginID")
						.SanctionApprovedOn = Now
						SIS.VR.vrRequestExecution.UpdateData(oRE)
					End With
				End If
				Return oRE
			Else
				If oRE.Linked Then
					For Each le As SIS.VR.vrRequestExecution In oLEs
						With le
							If .RequestStatusID = RequestStates.ODCUnderApproval Then
								.RequestStatusID = RequestStates.ODCRejected
							ElseIf .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval Then
								.RequestStatusID = RequestStates.VehicleNotPlacedRejected
							ElseIf .RequestStatusID = RequestStates.DelayedPlacementUnderApproval Then
								.RequestStatusID = RequestStates.DelayedPlacementRejected
							ElseIf .RequestStatusID = RequestStates.EmptyReturnRUnderApproval Then
								.RequestStatusID = RequestStates.EmptyReturnRejected
							ElseIf .RequestStatusID = RequestStates.DetentionUnderApproval Then
								.RequestStatusID = RequestStates.DetentionRejected
							ElseIf .RequestStatusID = RequestStates.UnderSelfApproval Then
								.RequestStatusID = RequestStates.SelfRejected
							End If
							.ApprovalRemarks = ApprovalRemarks
							.ApprovedBy = HttpContext.Current.Session("LoginID")
							.ApprovedOn = Now
						End With
						le = SIS.VR.vrExecutionApproval.UpdateData(le)
					Next
				Else
					With oRE
						If .RequestStatusID = RequestStates.ODCUnderApproval Then
							.RequestStatusID = RequestStates.ODCRejected
						ElseIf .RequestStatusID = RequestStates.VehicleNotPlacedUnderApproval Then
							.RequestStatusID = RequestStates.VehicleNotPlacedRejected
						ElseIf .RequestStatusID = RequestStates.DelayedPlacementUnderApproval Then
							.RequestStatusID = RequestStates.DelayedPlacementRejected
						ElseIf .RequestStatusID = RequestStates.EmptyReturnRUnderApproval Then
							.RequestStatusID = RequestStates.EmptyReturnRejected
						ElseIf .RequestStatusID = RequestStates.DetentionUnderApproval Then
							.RequestStatusID = RequestStates.DetentionRejected
						ElseIf .RequestStatusID = RequestStates.UnderSelfApproval Then
							.RequestStatusID = RequestStates.SelfRejected
						End If
						.ApprovalRemarks = ApprovalRemarks
						.ApprovedBy = HttpContext.Current.Session("LoginID")
						.ApprovedOn = Now
					End With
					oRE = SIS.VR.vrExecutionApproval.UpdateData(oRE)
				End If
			End If
			SendEMail(oRE, True)
			Return oRE
		End Function
		Public Shared Function UZ_vrSanctionExecutionApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrExecutionApproval)
			Dim Results As List(Of SIS.VR.vrExecutionApproval) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_SanctionExecutionApprovalSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_SanctionExecutionApprovalSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatusID", SqlDbType.Int, 10, 6)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					RecordCount = -1
					Results = New List(Of SIS.VR.vrExecutionApproval)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrExecutionApproval(Reader))
					End While
					Reader.Close()
					RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UZ_vrExecutionApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal VehicleTypeID As Int32) As List(Of SIS.VR.vrExecutionApproval)
			Dim Results As List(Of SIS.VR.vrExecutionApproval) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_ExecutionApprovalSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_ExecutionApprovalSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequestStatusID", SqlDbType.Int, 10, 6)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					RecordCount = -1
					Results = New List(Of SIS.VR.vrExecutionApproval)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrExecutionApproval(Reader))
					End While
					Reader.Close()
					RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Shadows Function SendEMail(ByVal oRE As SIS.VR.vrExecutionApproval, Optional ByVal Rejected As Boolean = False) As String
			Dim mRet As String = ""
			Dim mRecipients As New StringBuilder
			Dim maySend As Boolean = False
			Dim oEmp As SIS.QCM.qcmUsers = oRE.FK_VR_RequestExecution_ApprovedBy
			Dim oVRs As List(Of SIS.VR.vrVehicleRequest) = SIS.VR.vrVehicleRequest.GetBySRNNo(oRE.SRNNo, "")
			For Each oVR As SIS.VR.vrVehicleRequest In oVRs
				If oVR.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
					maySend = True
					mRecipients.AppendLine(oVR.FK_VR_VehicleRequest_RequestedBy.EMailID & " [" & oVR.FK_VR_VehicleRequest_RequestedBy.UserFullName & "]")
				End If
			Next
			If oEmp.EMailID <> String.Empty And maySend Then
				Try
					Dim oClient As SmtpClient = New SmtpClient()

					Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
					With oMsg
						.From = New MailAddress(oEmp.EMailID, oEmp.UserFullName)
						.To.Add(New MailAddress(oRE.FK_VR_RequestExecution_ArrangedBy.EMailID, oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName))
						.To.Add(New MailAddress(oRE.FK_VR_RequestExecution_TransporterID.EMailID, oRE.FK_VR_RequestExecution_TransporterID.TransporterName))
						For Each oVR As SIS.VR.vrVehicleRequest In oVRs
							If oVR.FK_VR_VehicleRequest_RequestedBy.EMailID <> String.Empty Then
								Dim oAD As MailAddress = New MailAddress(oVR.FK_VR_VehicleRequest_RequestedBy.EMailID, oVR.FK_VR_VehicleRequest_RequestedBy.UserFullName)
								If Not .CC.Contains(oAD) Then
									.CC.Add(oAD)
								End If
							End If
						Next
						.CC.Add(New MailAddress(oEmp.EMailID, oEmp.UserFullName))
						.IsBodyHtml = True
						If Rejected Then
							.Subject = "Rejected: Vehicle Execution No.: " & oRE.SRNNo & ", Transporter: " & oRE.FK_VR_RequestExecution_TransporterID.TransporterName
						Else
							.Subject = "Approved: Vehicle Execution No.: " & oRE.SRNNo & ", Transporter: " & oRE.FK_VR_RequestExecution_TransporterID.TransporterName
						End If
						Dim sb As New StringBuilder
						With sb
							If Rejected Then
								.AppendLine("<br/><b>Vehicle Execution is Reject with following remarks.</b>")
								.AppendLine("<br/>" & oRE.ApprovalRemarks)
								.AppendLine("<br/>-------------------------------------------------------")
							End If
							.AppendLine("<br/><b>Vehicle Execution</b>")
							.AppendLine("<br/><b>Transporter: </b>" & oRE.FK_VR_RequestExecution_TransporterID.TransporterName)
							.AppendLine("<br/><b>Vehicle Type: </b>" & IIf(oRE.VR_VehicleTypes13_cmba = String.Empty, "***NOT SPECIFIED***", oRE.VR_VehicleTypes13_cmba))
							.AppendLine("<br/><b>Vehicle No.: </b>" & IIf(oRE.VehicleNo = String.Empty, "***NOT SPECIFIED***", oRE.VehicleNo))
							.AppendLine("<br/><b>Vehicle Placed At Supplier On: </b>" & oRE.VehiclePlacedOn)
							.AppendLine("<br/><b>Vehicle Moved From Supplier On: </b>" & oRE.LoadedOn)
							.AppendLine("<br/><b>GR No.: </b>" & oRE.GRNo)
							.AppendLine("<br/><b>GR Date: </b>" & oRE.GRDate)
							.AppendLine("<br/><b>ODC While Loaded At Supplier Works: </b>" & IIf(oRE.OverDimentionConsignement, "YES", "NO"))
							.AppendLine("<br/><b>Dimension (L x W x H) Unit: </b>" & oRE.Length & " x " & oRE.Width & " x " & oRE.Height & " " & oRE.FK_VR_RequestExecution_SizeUnit.Description)
							.AppendLine("<br/><b>Weight -Unit: </b>" & oRE.MaterialWeight & " -" & oRE.FK_VR_RequestExecution_WeightUnit.Description)
							.AppendLine("<br/><b>Name of Executer: </b>" & oRE.FK_VR_RequestExecution_ArrangedBy.UserFullName & " [" & oRE.ArrangedBy & "]")
						End With
						.Body = sb.ToString
						'Dim oAtchs As List(Of SIS.QCM.qcmRequestFiles) = SIS.QCM.qcmRequestFiles.qcmRequestFilesSelectList(0, 99, "", False, "", oRE.RequestID)
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
