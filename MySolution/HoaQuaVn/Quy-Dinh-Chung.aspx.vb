Imports Common
Public Class Quy_Dinh_Chung
    Inherits System.Web.UI.Page
    Private ClsName = "Quy_Dinh_Chung"
    Public sID As String = String.Empty
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA()
                If Request.QueryString.Count > 0 Then
                    sID = Request.QueryString("MyTitleId")
                End If
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
            Dim sKeys As String = ""
            Dim sName As String = ""
            Select Case sID
                Case 1
                    sKeys = "TraHang"
                    sName = "Chính Sách Đổi Trả Hàng"
                Case 2
                    sKeys = "MuaHang"
                    sName = "Hướng Dẫn Mua Hàng"
                Case 3
                    sKeys = "ThanhToan"
                    sName = "Phương Thức Thanh Toán"
                Case 4
                    sKeys = "VanChuyen"
                    sName = "Phương Thức Vận Chuyển"
                Case 5
                    sKeys = "BaoMat"
                    sName = "Chính Sách Bảo Mật Thông Tin"
                Case 6
                    sKeys = "BaoHanh"
                    sName = "Chính Sách Bảo Hành"
            End Select
            lblNewTitle.Text = sName
            sSql = "SELECT * FROM SysPara WHERE ComboID= " & Core.SQLStr(sKeys)
            Var.DBAMain.FillDataset(sSql, ds, "LoadItemInfo")
            If Core.IsDBNullOrStringEmpty(ds.Tables("LoadItemInfo")) = False Then
                For Each row As DataRow In ds.Tables("LoadItemInfo").Rows
                    If Not Core.IsDBNullOrStringEmpty(row("ComboID")) Then
                        lblContents.Text = row("ItemID")

                    End If


                Next

            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadItemInfo", ex.Message)
        End Try

    End Sub

End Class