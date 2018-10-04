Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
	Partial Public Class vrTransporterBill
		Private _PaymentDetails As String = ""
		Public Function GetColor() As System.Drawing.Color
			Dim mRet As System.Drawing.Color = Drawing.Color.Black
			Select Case BillStatusID
				Case BillStatus.ExecutionLinked
					mRet = Drawing.Color.OrangeRed
				Case BillStatus.ForwardedToCentralAccount
					mRet = Drawing.Color.Green
				Case BillStatus.ReturnedByCentralAccount
					mRet = Drawing.Color.Red
				Case BillStatus.AcceptedByCentralAccount
					mRet = Drawing.Color.Olive
				Case BillStatus.PaidByCentralAccount
					mRet = Drawing.Color.DarkViolet
			End Select
			Return mRet
		End Function
		Public Function GetVisible() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public Function GetEnable() As Boolean
			Dim mRet As Boolean = True
			Return mRet
		End Function
		Public ReadOnly Property InitiateWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _BillStatusID = BillStatus.ExecutionLinked _
					Or _BillStatusID = BillStatus.ReturnedByCentralAccount Then
						mRet = True
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property InitiateWFEnable() As Boolean
			Get
				Dim mRet As Boolean = True
				Try
					mRet = GetEnable()
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public ReadOnly Property PaymentDetails() As String
			Get
				If _BillStatusID = BillStatus.PaidByCentralAccount Then
					_PaymentDetails = "PAYMENT DETAILS: "
					_PaymentDetails &= " <b> Chq.No:</b> " & FK_VR_TransporterBill_SerialNo.ChequeNo
					_PaymentDetails &= " <b> Chq.Dt:</b> " & FK_VR_TransporterBill_SerialNo.ChequeDate
					_PaymentDetails &= " <b> Chq.Amt:</b> " & FK_VR_TransporterBill_SerialNo.ChequeAmount
				End If
				Return _PaymentDetails
			End Get
		End Property
		Public ReadOnly Property CompleteWFVisible() As Boolean
			Get
				Dim mRet As Boolean = False
				Try
					If _BillStatusID = BillStatus.AcceptedByCentralAccount _
					 Or _BillStatusID = BillStatusID = BillStatus.PaidByCentralAccount Then
						mRet = True
						If _BillStatusID = BillStatusID = BillStatus.PaidByCentralAccount Then
							If FK_VR_TransporterBill_SerialNo.Freezed Then
								mRet = False
							End If
						End If
					End If
				Catch ex As Exception
				End Try
				Return mRet
			End Get
		End Property
		Public Shared Function CompleteWF(ByVal IRNo As Int32) As SIS.VR.vrTransporterBill
			Dim oIR As SIS.VR.vrTransporterBill = vrTransporterBillGetByID(IRNo)
			oIR = SIS.VR.vrTransporterBill.UpdatePaymentDetailsFromBaan(oIR)
			Return oIR
		End Function
		Public Shared Function InitiateWF(ByVal IRNo As Int32) As SIS.VR.vrTransporterBill
			Dim oIR As SIS.VR.vrTransporterBill = vrTransporterBillGetByID(IRNo)
			With oIR
				.DiscripantBill = False
				.BillReturnRemarks = ""
				.BillReturneddBy = ""
				.BillReturnedOn = ""
				.ForwardedBy = HttpContext.Current.Session("LoginID")
				.ForwardedOn = Now
				.ForwardedToAccount = True
				.BillStatusID = BillStatus.ForwardedToCentralAccount
			End With
			oIR = SIS.VR.vrTransporterBill.UpdateData(oIR)
			Return oIR
		End Function
		Public Shared Function UZ_vrTransporterBillSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal TransporterID As String, ByVal BillReceiverDivisionID As String, ByVal BillStatusID As Int32) As List(Of SIS.VR.vrTransporterBill)
			Dim Results As List(Of SIS.VR.vrTransporterBill) = Nothing
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.StoredProcedure
					If SearchState Then
						Cmd.CommandText = "spvr_LG_TransporterBillSelectListSearch"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
					Else
						Cmd.CommandText = "spvr_LG_TransporterBillSelectListFilteres"
						Cmd.CommandText = "spvrTransporterBillSelectListFilteres"
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillReceiverDivisionID", SqlDbType.NVarChar, 6, IIf(BillReceiverDivisionID Is Nothing, String.Empty, BillReceiverDivisionID))
						SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_BillStatusID", SqlDbType.Int, 10, IIf(BillStatusID = Nothing, 0, BillStatusID))
					End If
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
					SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
					Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
					Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
					_RecordCount = -1
					Results = New List(Of SIS.VR.vrTransporterBill)()
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					While (Reader.Read())
						Results.Add(New SIS.VR.vrTransporterBill(Reader))
					End While
					Reader.Close()
					_RecordCount = Cmd.Parameters("@RecordCount").Value
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UZ_vrTransporterBillInsert(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
			Record = GetIRFromBaaN(Record.IRNo)
			Dim _Result As SIS.VR.vrTransporterBill = vrTransporterBillInsert(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrTransporterBillUpdate(ByVal Record As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
			Dim _Result As SIS.VR.vrTransporterBill = vrTransporterBillUpdate(Record)
			Return _Result
		End Function
		Public Shared Function UZ_vrTransporterBillDelete(ByVal Record As SIS.VR.vrTransporterBill) As Integer
			Dim _Result As Integer = vrTransporterBillDelete(Record)
			Return _Result
		End Function
		Public Shared Function UZ_validatePK_vrTransporterBill(ByVal value As String) As String
			Dim aVal() As String = value.Split(",".ToCharArray)
			Dim mRet As String = "0|" & aVal(0)
			Dim IRNo As Int32 = CType(aVal(1).Replace("_", ""), Int32)
			Dim oVar As SIS.VR.vrTransporterBill = SIS.VR.vrTransporterBill.vrTransporterBillGetByID(IRNo)
			If Not oVar Is Nothing Then
				mRet = "1|" & aVal(0) & "|IR allready exists."
			Else
				oVar = SIS.VR.vrTransporterBill.GetIRFromBaaN(IRNo)
				If oVar Is Nothing Then
					mRet = "1|" & aVal(0) & "|IR NOT Found In ERP-LN."
				Else
					mRet = mRet & "|"
					mRet = mRet & "<table>"
					mRet = mRet & "<tr><td><b>IR No:</b></td><td>" & oVar.IRNo & "</td></tr>"
					mRet = mRet & "<tr><td><b>TRANSPORTER:</b></td><td>" & oVar.TransporterID & " " & oVar.VR_Transporters9_TransporterName & "</td></tr>"
					mRet = mRet & "<tr><td><b>BILL NO:</b></td><td>" & oVar.TransporterBillNo & "</td></tr>"
					mRet = mRet & "<tr><td><b>BILL DATE:</b></td><td>" & oVar.TransporterBillDate & "</td></tr>"
					mRet = mRet & "<tr><td><b>BILL AMOUNT:</b></td><td>" & oVar.BillAmount & "</td></tr>"
					mRet = mRet & "<tr><td><b>PO NO.</b></td><td>" & oVar.ISGECPONumber & "</td></tr>"
					mRet = mRet & "</table>"
				End If
			End If
			Return mRet
		End Function
		Public Shared Function GetIRFromBaaN(ByVal IRNo As Int32) As SIS.VR.vrTransporterBill
			Dim Results As SIS.VR.vrTransporterBill = Nothing
			Dim Sql As String = ""
			Sql = Sql & "select "
			Sql = Sql & "t_ninv as IRNo,"
			Sql = Sql & "t_refr as IRDescription,"
			Sql = Sql & "t_cdf_pono as ISGECPONumber,"
			Sql = Sql & "t_cdf_irdt as ISGECPODate,"
			Sql = Sql & "t_cdf_cprj as ProjectID,"
			Sql = Sql & "t_amti as ISGECPOAmount,"
			Sql = Sql & "t_ifbp as TransporterID,"
			Sql = Sql & "t_isup as TransporterBillNo,"
			Sql = Sql & "t_invd as TransporterBillDate,"
			Sql = Sql & "t_amti as BillAmount "
			Sql = Sql & "from ttfacp100200 "
			Sql = Sql & "where t_ninv = " & IRNo
			Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
				Using Cmd As SqlCommand = Con.CreateCommand()
					Cmd.CommandType = CommandType.Text
					Cmd.CommandText = Sql
					Con.Open()
					Dim Reader As SqlDataReader = Cmd.ExecuteReader()
					If Reader.Read() Then
						Results = New SIS.VR.vrTransporterBill(Reader)
					End If
					Reader.Close()
				End Using
			End Using
			Return Results
		End Function
		Public Shared Function UpdatePaymentDetailsFromBaan(ByVal oIR As SIS.VR.vrTransporterBill) As SIS.VR.vrTransporterBill
			'Delete By Serial No and also By IRNo, if multiple PTR against IR
			If oIR.SerialNo <> String.Empty Then
				Dim tEP As SIS.VR.vrPaymentProcess = SIS.VR.vrPaymentProcess.vrPaymentProcessGetByID(oIR.SerialNo)
				If tEP IsNot Nothing Then
					SIS.VR.vrPaymentProcess.vrPaymentProcessDelete(tEP)
				End If
			End If
			'End of delete only by serial no
			Dim oEPs As List(Of SIS.VR.vrPaymentProcess) = SIS.VR.vrPaymentProcess.PaymentInBaaNByIRNo(oIR.IRNo)
			For Each ep As SIS.VR.vrPaymentProcess In oEPs
				'expected to get only one record
				ep = SIS.VR.vrPaymentProcess.InsertData(ep)
				oIR.SerialNo = ep.SerialNo
				oIR.BillStatusID = BillStatus.PaidByCentralAccount
			Next
			SIS.VR.vrTransporterBill.UpdateData(oIR)
			Return oIR
		End Function
	End Class
End Namespace
