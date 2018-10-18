Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

Namespace SIS.PAK
  Partial Public Class pakPO
    Public Shared Function GetTotalWeight(ByVal Qty As String, ByVal UnitWt As String, ByVal UOMqty As String, ByVal UOMWt As String) As Decimal
      Dim mRet As Decimal = 0
      Dim mc As SIS.PAK.UnitMultiplicationFactor = Nothing
      Try
        Dim tmpUnit As SIS.PAK.pakUnits = SIS.PAK.pakUnits.pakUnitsGetByID(UOMqty)
        If tmpUnit.UnitSetID = 3 Then '3=>Weight Unit Set
          Try
            mc = New SIS.PAK.UnitMultiplicationFactor
            mc.Unit = tmpUnit
            mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
            mRet = Qty * mc.MF
          Catch ex As Exception
          End Try
        Else
          Try
            mc = New SIS.PAK.UnitMultiplicationFactor
            mc.Unit = SIS.PAK.pakUnits.pakUnitsGetByID(UOMWt)
            mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
            mRet = Qty * UnitWt * mc.MF
          Catch ex As Exception
          End Try
        End If
      Catch ex As Exception
        Try
          mc = New SIS.PAK.UnitMultiplicationFactor
          mc.Unit = SIS.PAK.pakUnits.pakUnitsGetByID(UOMWt)
          mc = SIS.PAK.UnitMultiplicationFactor.GetMultiplicationFactorToBaseUnit(mc)
          mRet = Qty * UnitWt * mc.MF
        Catch ex1 As Exception
        End Try
      End Try
      Return mRet
    End Function
    Public Shared Function pakPOGetByPONo(ByVal PONo As String) As SIS.PAK.pakPO
      Dim Results As SIS.PAK.pakPO = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "sppak_LG_POSelectByPONo"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@PONo", SqlDbType.NVarChar, PONo.Length, PONo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.PAK.pakPO(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
End Namespace
