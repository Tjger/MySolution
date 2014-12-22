Public Class Login1
    Inherits System.Web.UI.Page
    Dim sUserName As String = "admin"
    Dim sPassword As String = "3w3ll"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim sName, sPwd As String
        sName = txtUserName.Text
        sPwd = txtPwd.Text
        Try
            If sName.Equals(sUserName) And sPwd.Equals(sPassword) Then
                Session("isLogin") = txtUserName.Text
                Response.Redirect("Admin.aspx")
            Else
                Session("isLogin") = String.Empty
                Response.Redirect("Login.aspx")

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class