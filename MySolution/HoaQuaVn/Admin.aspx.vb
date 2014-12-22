Imports Common
Imports System.Web.UI.WebControls
Public Class index
    Inherits System.Web.UI.Page
    Private Enum ModuleType
        GroupManagement = 1
        ItemManagement = 2
        ComboManagement = 3
        SEOManagement = 4
        ClearSession = 5
    End Enum

    Private sModule As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If String.IsNullOrEmpty(Session("isLogin")) Then
                Response.Redirect("Login.aspx")
            Else
                Dim sModule As String = String.Empty
                If Request.QueryString.Keys.Count > 0 Then
                    sModule = Request.QueryString("module").ToString()
                    Select Case Convert.ToInt32(sModule)
                        Case ModuleType.GroupManagement
                            Dim uc As UserControl = LoadControl("~/BackEnd/UserControl/GroupManagement/ucGroup.ascx")
                            Panel1.Controls.Add(uc)
                        Case ModuleType.ItemManagement
                            Dim uc As UserControl = LoadControl("~/BackEnd/UserControl/ItemManagement/ucItem.ascx")
                            Panel1.Controls.Add(uc)
                        Case ModuleType.ComboManagement

                        Case ModuleType.SEOManagement
                        Case ModuleType.ClearSession
                            Session.Abandon()
                            Response.Redirect("Admin.aspx")
                    End Select
                Else
                    Dim uc As UserControl = LoadControl("~/BackEnd/UserControl/ReceiptManagement/ucReceipt.ascx")
                    Panel1.Controls.Add(uc)
                End If
            End If
           

        Catch ex As Exception
            Dim sMsg As String = String.Empty
            sMsg = "Login Error !"
        End Try
       
    End Sub

End Class