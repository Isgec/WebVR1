Namespace SIS.VR
	Partial Class LC_LinkExecution
		Inherits System.Web.UI.UserControl
		Public Shared Function SelectLink(ByVal value As String) As String
			Dim aVal() As String = value.Split(",".ToCharArray)
			Dim mExe As Integer = aVal(0)
			Dim tExe As Integer = aVal(1)
			'Linked Execution
			Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(tExe)
			With oRE
				.Linked = True
				.LinkID = mExe
			End With
			SIS.VR.vrRequestExecution.UpdateData(oRE)
			'Main Execution
			Dim mRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(mExe)
			With mRE
				.Linked = True
				.LinkID = mExe
			End With
			SIS.VR.vrRequestExecution.UpdateData(mRE)

			Return GetLink(mExe)
		End Function
		Public Shared Function RemoveLink(ByVal value As String) As String
			Dim aVal() As String = value.split(",".ToCharArray)
			Dim mExe As Integer = aVal(0)
			Dim tExe As Integer = aVal(1)
			'Linked Execution
			Dim oRE As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(tExe)
			With oRE
				.Linked = False
				.LinkID = ""
			End With
			SIS.VR.vrRequestExecution.UpdateData(oRE)
			'Check to Delink Main Execution
			'Incorporated in GetHTML
			'End Of Checking
			Return GetLink(mExe)
		End Function
		Public Shared Function GetLink(ByVal mExe As Integer) As String
			Return mExe & "▒" & GetHTML(mExe)
		End Function
		Public Shared Function GetHTML(ByVal SRNNo As Integer) As String
			Dim oExe As SIS.VR.vrRequestExecution = Nothing
			Dim tExe As SIS.VR.vrRequestExecution = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
			If tExe.Linked Then
				SRNNo = tExe.LinkID
				oExe = SIS.VR.vrRequestExecution.vrRequestExecutionGetByID(SRNNo)
			Else
				oExe = tExe
			End If
			Dim oTbl As New Table

			oTbl.GridLines = GridLines.Both
			oTbl.Width = 580
			oTbl.Style.Add("text-align", "left")
			oTbl.Style.Add("font", "Tahoma")
			oTbl.Style.Add("border", "solid 1pt black")
			oTbl.GridLines = GridLines.Both

			Dim oCol As TableCell = Nothing
			Dim oRow As TableRow = Nothing
			Dim oImg As Image = Nothing

			oRow = New TableRow
			oCol = New TableCell
			oCol.ColumnSpan = "5"
			oCol.BackColor = Drawing.Color.LightGray
			oCol.Text = "LINKED EXECUTION"
			oCol.Style.Add("text-align", "LEFT")
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oTbl.Rows.Add(oRow)

			oRow = New TableRow
			oRow.BackColor = Drawing.Color.Plum
			oCol = New TableCell
			oCol.Text = "EXE.NO"
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oCol = New TableCell
			oCol.Text = "TRANSPORTER"
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oCol = New TableCell
			oCol.Text = "VEHICLE TYPE"
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oCol = New TableCell
			oCol.Text = ". . . ."
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oCol = New TableCell
			oCol.Text = "LINK/DELINK"
			oCol.Font.Bold = True
			oRow.Cells.Add(oCol)
			oTbl.Rows.Add(oRow)

			Dim oLEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.UZ_vrLinkedExecution(SRNNo)
			If oLEs.Count = 0 Then
				oLEs.Add(oExe)
			ElseIf oLEs.Count = 1 Then
				oLEs(0).Linked = False
				oLEs(0).LinkID = ""
				SIS.VR.vrRequestExecution.UpdateData(oLEs(0))
			End If
			For Each le As SIS.VR.vrRequestExecution In oLEs
				oRow = New TableRow
				oRow.CssClass = "gvr_silver"
				oCol = New TableCell
				oCol.Text = le.SRNNo
				oRow.Cells.Add(oCol)
				oCol = New TableCell
				oCol.Text = le.VR_Transporters10_TransporterName
				oCol.ToolTip = le.TransporterID
				oRow.Cells.Add(oCol)
				oCol = New TableCell
				oCol.Text = le.VR_VehicleTypes13_cmba
				oRow.Cells.Add(oCol)
				oCol = New TableCell
				oCol.Text = ". . . ."
				oRow.Cells.Add(oCol)
				oCol = New TableCell
				oCol.HorizontalAlign = HorizontalAlign.Center
				oImg = New Image
				If oExe.RequestStatusID = RequestStates.RequestLinked Then
					If le.SRNNo <> oExe.SRNNo Then
						With oImg
							.AlternateText = le.SRNNo
							.ImageUrl = "../../App_Themes/Default/Images/docreject.png"
							.Attributes.Add("onclick", "return lc_getLink.removeLink('" & oExe.SRNNo & "," & le.SRNNo & "');")
							.ToolTip = "Click to link."
						End With
						oCol.Controls.Add(oImg)
					Else
						oRow.BackColor = Drawing.Color.LightPink
						oCol.Text = "Main"
					End If
				Else
					oRow.BackColor = Drawing.Color.LightPink
					oCol.Text = "Main"
				End If
				oRow.Cells.Add(oCol)
				oTbl.Rows.Add(oRow)
			Next

			If oExe.RequestStatusID = RequestStates.RequestLinked Then
				oRow = New TableRow
				oCol = New TableCell
				oCol.ColumnSpan = "5"
				oCol.BackColor = Drawing.Color.LightGray
				oCol.Text = "UNLINKED EXECUTION"
				oCol.Style.Add("text-align", "LEFT")
				oCol.Font.Bold = True
				oRow.Cells.Add(oCol)
				oTbl.Rows.Add(oRow)

				Dim oULEs As List(Of SIS.VR.vrRequestExecution) = SIS.VR.vrRequestExecution.UZ_vrUnLinkedExecution(SRNNo)
				If oULEs.Count <= 0 Then
					oRow = New TableRow
					oCol = New TableCell
					oCol.ColumnSpan = "5"
					oCol.HorizontalAlign = HorizontalAlign.Center
					oCol.Text = "***NO RECORD FOUND***"
					oCol.ForeColor = Drawing.Color.Red
					oRow.Cells.Add(oCol)
					oTbl.Rows.Add(oRow)
				Else
					For Each le As SIS.VR.vrRequestExecution In oULEs
						oRow = New TableRow
						oRow.CssClass = "gvr_silver"
						oCol = New TableCell
						oCol.Text = le.SRNNo
						oRow.Cells.Add(oCol)
						oCol = New TableCell
						oCol.Text = le.VR_Transporters10_TransporterName
						oCol.ToolTip = le.TransporterID
						oRow.Cells.Add(oCol)
						oCol = New TableCell
						oCol.Text = le.VR_VehicleTypes13_cmba
						oRow.Cells.Add(oCol)
						oCol = New TableCell
						oCol.Text = ". . . ."
						oRow.Cells.Add(oCol)
						oCol = New TableCell
						oCol.HorizontalAlign = HorizontalAlign.Center
						oImg = New Image
						With oImg
							.AlternateText = le.SRNNo
							.ImageUrl = "../../App_Themes/Default/Images/ok.png"
							.Attributes.Add("onclick", "return lc_getLink.selectLink('" & oExe.SRNNo & "," & le.SRNNo & "');")
							.ToolTip = "Click to remove."
						End With
						oCol.Controls.Add(oImg)
						oRow.Cells.Add(oCol)
						oTbl.Rows.Add(oRow)
					Next
				End If
			End If
			Dim sb As StringBuilder = New StringBuilder()
			Dim sw As IO.StringWriter = New IO.StringWriter(sb)
			Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
			Try
				oTbl.RenderControl(writer)
			Catch ex As Exception

			End Try
			Return sb.ToString
		End Function
	End Class
End Namespace
