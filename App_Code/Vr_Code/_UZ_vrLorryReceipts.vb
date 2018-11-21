Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.VR
  Partial Public Class vrLorryReceipts
    Public ReadOnly Property xl_MrnDate As String
      Get
        Dim mRet As String = ""
        Try
          Dim dt As DateTime = Convert.ToDateTime(_MRNDate)
          mRet = dt.Day.ToString.PadLeft(2, "0") & "|" & dt.Month.ToString.PadLeft(2, "0") & "|" & dt.Year
        Catch ex As Exception

        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property xl_VehicleInDate As String
      Get
        Dim mRet As String = ""
        Try
          Dim dt As DateTime = Convert.ToDateTime(_VehicleInDate)
          mRet = dt.Day.ToString.PadLeft(2, "0") & "|" & dt.Month.ToString.PadLeft(2, "0") & "|" & dt.Year & "|" & dt.Hour().ToString.PadLeft(2, "0")
        Catch ex As Exception

        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property xl_VehicleOutDate As String
      Get
        Dim mRet As String = ""
        Try
          Dim dt As DateTime = Convert.ToDateTime(_VehicleOutDate)
          mRet = dt.Day.ToString.PadLeft(2, "0") & "|" & dt.Month.ToString.PadLeft(2, "0") & "|" & dt.Year & "|" & dt.Hour().ToString.PadLeft(2, "0")
        Catch ex As Exception

        End Try
        Return mRet
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Black
      Select Case _LRStatusID
        Case 2
          mRet = Drawing.Color.Green
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
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case _LRStatusID
          Case 1
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case _LRStatusID
          Case 1
            mRet = True
        End Select
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Select Case _LRStatusID
          Case 1
            mRet = True
        End Select
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
    Public Shared Function InitiateWF(ByVal ProjectID As String, ByVal MRNNo As Int32) As SIS.VR.vrLorryReceipts
      Dim Results As SIS.VR.vrLorryReceipts = vrLorryReceiptsGetByID(ProjectID, MRNNo)
      'Validate MRN Dates
      If Convert.ToDateTime(Results.MRNDate).Date > Now.Date Then
        Throw New Exception("MRN can not be created for FUTURE Date.")
      End If
      If Convert.ToDateTime(Results.MRNDate).Date < Convert.ToDateTime(Results.VehicleInDate).Date Then
        Throw New Exception("MRN Date can NOT be less than Vehicle In Date.")
      End If
      If Convert.ToDateTime(Results.VehicleOutDate) < Convert.ToDateTime(Results.VehicleInDate) Then
        Throw New Exception("Vehicle Out Date can not be less than vehicle in Date.")
      End If
      With Results
        .LRStatusID = 2
        .CreatedBy = HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Results = SIS.VR.vrLorryReceipts.UpdateData(Results)
      Return Results
    End Function
    Public Shared Function UZ_vrLorryReceiptsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal ProjectID As String, ByVal TransporterID As String, ByVal CustomerID As String, ByVal VehicleTypeID As Int32, ByVal LRStatusID As Int32) As List(Of SIS.VR.vrLorryReceipts)
      Dim Results As List(Of SIS.VR.vrLorryReceipts) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spvr_LG_LorryReceiptsSelectListSearch"
            Cmd.CommandText = "spvrLorryReceiptsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spvr_LG_LorryReceiptsSelectListFilteres"
            Cmd.CommandText = "spvrLorryReceiptsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ProjectID", SqlDbType.NVarChar, 6, IIf(ProjectID Is Nothing, String.Empty, ProjectID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_TransporterID", SqlDbType.NVarChar, 9, IIf(TransporterID Is Nothing, String.Empty, TransporterID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CustomerID", SqlDbType.NVarChar, 9, IIf(CustomerID Is Nothing, String.Empty, CustomerID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_VehicleTypeID", SqlDbType.Int, 10, IIf(VehicleTypeID = Nothing, 0, VehicleTypeID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_LRStatusID", SqlDbType.Int, 10, IIf(LRStatusID = Nothing, 0, LRStatusID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.VR.vrLorryReceipts)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.VR.vrLorryReceipts(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_vrLorryReceiptsInsert(ByVal Record As SIS.VR.vrLorryReceipts) As SIS.VR.vrLorryReceipts
      Dim MRNNo As Integer = 1
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select isnull(max(mrnno),0) from vr_lorryreceipts where projectid = '" & Record.ProjectID & "'"
          Con.Open()
          MRNNo = Cmd.ExecuteScalar()
          MRNNo += 1
        End Using
      End Using
      With Record
        .MRNNo = MRNNo
        .CreatedOn = Now
        .RequestExecutionNo = Record.RequestExecutionNo
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .LRStatusID = 1
      End With
      Dim _Result As SIS.VR.vrLorryReceipts = InsertData(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrLorryReceiptsUpdate(ByVal Record As SIS.VR.vrLorryReceipts) As SIS.VR.vrLorryReceipts
      Dim _Result As SIS.VR.vrLorryReceipts = vrLorryReceiptsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_vrLorryReceiptsDelete(ByVal Record As SIS.VR.vrLorryReceipts) As Integer
      Dim _Result As Integer = vrLorryReceiptsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_VehicleType"), TextBox).Text = ""
          CType(.FindControl("F_MaterialStateID"), Object).SelectedValue = ""
          CType(.FindControl("F_ProjectID"), TextBox).Text = ""
          CType(.FindControl("F_ProjectID_Display"), Label).Text = ""
          CType(.FindControl("F_RequestExecutionNo"), TextBox).Text = ""
          CType(.FindControl("F_RequestExecutionNo_Display"), Label).Text = ""
          CType(.FindControl("F_MRNNo"), TextBox).Text = "0"
          CType(.FindControl("F_MRNDate"), TextBox).Text = ""
          CType(.FindControl("F_TransporterID"), TextBox).Text = ""
          CType(.FindControl("F_TransporterID_Display"), Label).Text = ""
          CType(.FindControl("F_CustomerID"), TextBox).Text = ""
          CType(.FindControl("F_CustomerID_Display"), Label).Text = ""
          CType(.FindControl("F_VehicleRegistrationNo"), TextBox).Text = ""
          CType(.FindControl("F_WayBillFormNo"), TextBox).Text = ""
          CType(.FindControl("F_PaymentMadeAtSite"), CheckBox).Checked = False
          CType(.FindControl("F_AmountPaid"), TextBox).Text = 0
          CType(.FindControl("F_VehicleInDate"), TextBox).Text = ""
          CType(.FindControl("F_VehicleOutDate"), TextBox).Text = ""
          CType(.FindControl("F_DetentionAtSite"), CheckBox).Checked = False
          CType(.FindControl("F_ReasonForDetention"), TextBox).Text = ""
          CType(.FindControl("F_OverDimensionConsignment"), CheckBox).Checked = False
          CType(.FindControl("F_VehicleTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_VehicleLengthInFt"), TextBox).Text = 0.00
          CType(.FindControl("F_VechicleWidthInFt"), TextBox).Text = 0.00
          CType(.FindControl("F_VehicleHeightInFt"), TextBox).Text = 0.00
          CType(.FindControl("F_RemarksForDamageOrShortage"), TextBox).Text = ""
          CType(.FindControl("F_OtherRemarks"), TextBox).Text = ""
          CType(.FindControl("F_DriverNameAndContactNo"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
