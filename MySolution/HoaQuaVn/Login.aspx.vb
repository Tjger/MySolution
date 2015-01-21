Imports Common
Public Class Login1
    Inherits System.Web.UI.Page
    Private ClsName = "Login1"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Core.InitAppSettingForDBA()
                Var.DBAMain = New Common.DBA(False)
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "Page_Load", ex.Message)
        End Try
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim sName, sPwd As String
        Try

            If txtUserName.Text.ToUpper.Equals(Var.sSuperAdminUser.ToUpper) And txtPwd.Text.ToUpper.Equals(Var.sSuperAdminPass.ToUpper) Then
                Session("isLogin") = "SuperAdmin"
                Response.Redirect("Admin.aspx")
            Else
                sName = txtUserName.Text.ToUpper
                sPwd = Core.LoadEmpInfo(sName)
                If sPwd.Equals(txtPwd.Text) Then
                    Session("isLogin") = txtUserName.Text
                    Response.Redirect("Admin.aspx")
                Else
                    Session("isLogin") = String.Empty
                    Response.Redirect("Login.aspx")

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class