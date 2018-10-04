Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrLorryReceiptDetails
    Public ReadOnly Property TransporterID As String
      Get
        Return FK_VR_LorryReceiptDetails_MRNNo.TransporterID
      End Get
    End Property
    Public ReadOnly Property xl_GRorLRDate As String
      Get
        Dim mRet As String = ""
        Try
          Dim dt As DateTime = Convert.ToDateTime(_GRorLRDate)
          mRet = dt.Day.ToString.PadLeft(2, "0") & "|" & dt.Month.ToString.PadLeft(2, "0") & "|" & dt.Year
        Catch ex As Exception

        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property xl_SupplierInvoiceDate As String
      Get
        Dim mRet As String = ""
        Try
          Dim dt As DateTime = Convert.ToDateTime(_SupplierInvoiceDate)
          mRet = dt.Day.ToString.PadLeft(2, "0") & "|" & dt.Month.ToString.PadLeft(2, "0") & "|" & dt.Year
        Catch ex As Exception

        End Try
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
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
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case FK_VR_LorryReceiptDetails_MRNNo.LRStatusID
          Case 1
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case FK_VR_LorryReceiptDetails_MRNNo.LRStatusID
          Case 1
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_MRNNo"), TextBox).Text = ""
          CType(.FindControl("F_MRNNo_Display"), Label).Text = ""
          CType(.FindControl("F_SerialNo"), TextBox).Text = ""
          CType(.FindControl("F_GRorLRNo"), TextBox).Text = ""
          CType(.FindControl("F_GRorLRDate"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID"), TextBox).Text = ""
          CType(.FindControl("F_SupplierID_Display"), Label).Text = ""
          CType(.FindControl("F_SupplierInvoiceNo"), TextBox).Text = ""
          CType(.FindControl("F_SupplierInvoiceDate"), TextBox).Text = ""
          CType(.FindControl("F_WeightAsPerInvoiceInKG"), TextBox).Text = 0
          CType(.FindControl("F_WeightReceived"), TextBox).Text = 0
          CType(.FindControl("F_NoOfPackagesAsPerInvoice"), TextBox).Text = 0
          CType(.FindControl("F_NoOfPackagesReceived"), TextBox).Text = 0
          CType(.FindControl("F_CenvatInvoiceReceived"), TextBox).Text = ""
          CType(.FindControl("F_Remarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
