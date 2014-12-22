Public Class AdminPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lblSignOut_Click(sender As Object, e As EventArgs)
        Try
            Session.Abandon()
            Response.Redirect("Login.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class