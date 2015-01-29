Imports Common
Public Class ucRole
    Inherits System.Web.UI.UserControl

    Private ClsName = "ucRole"
    Private Shared sMode As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
                LoadItemInfo()
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Private Sub LoadItemInfo()
        Try
            Dim sSql As String = ""
            Dim ds As New DataSet
            sSql = "SELECT * FROM SysPara "
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            For Each row As DataRow In ds.Tables("LoadItemInfo").Rows
                If Not Core.IsDBNullOrStringEmpty(row("ComboID")) Then
                    Select Case row("ComboID")
                        Case "TraHang"
                            txtTraHang.Text = row("ItemID")
                        Case "MuaHang"
                            txtMuaHang.Text = row("ItemID")
                        Case "ThanhToan"
                            txtThanhToan.Text = row("ItemID")
                        Case "VanChuyen"
                            txtVanChuyen.Text = row("ItemID")
                        Case "BaoMat"
                            txtBaoMat.Text = row("ItemID")
                        Case "BaoHanh"
                            txtBaoHanh.Text = row("ItemID")
                      

                    End Select

                End If
            Next

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            SaveDB("TraHang", txtTraHang.Text)
            SaveDB("MuaHang", txtMuaHang.Text)
            SaveDB("ThanhToan", txtThanhToan.Text)
            SaveDB("VanChuyen", txtVanChuyen.Text)
            SaveDB("BaoMat", txtBaoMat.Text)
            SaveDB("BaoHanh", txtBaoHanh.Text)
            Response.Redirect("Admin.aspx")
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try

    End Sub

    Private Function SaveDB(ByVal sKey As String, ByVal sValue As String)
        Dim bFlag As Boolean = False
        Try
            Dim ds As New DataSet
            Dim sSql As String = String.Format("SELECT * FROM SysPara WHERE ComboID={0}", Core.SQLStr(sKey))
            Var.DBAMain.FillDataset(sSql, ds, "SaveDB")
            If ds.Tables("SaveDB").Rows.Count > 0 Then
                sSql = String.Format("UPDATE SysPara SET ItemID =N{0} WHERE ComboID={1}", Core.SQLStr(sValue), Core.SQLStr(sKey))
            Else
                sSql = String.Format("INSERT INTO SysPara (ComboID, ItemID) VALUES(N{0}, N{1})", Core.SQLStr(sKey), Core.SQLStr(sValue))
            End If
            bFlag = Var.DBAMain.Execute(sSql)
        Catch ex As Exception
            Log.LogError(ClsName, "SaveDB", ex.Message)
        End Try
        Return bFlag
    End Function

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx")
    End Sub


End Class