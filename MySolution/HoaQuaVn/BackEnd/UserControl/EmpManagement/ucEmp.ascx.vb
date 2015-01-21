Imports Common
Public Class ucEmp
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucEmp"
    Private Shared sID As String = String.Empty
    Private Shared sMode As String = String.Empty

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

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            lblErrMes.Text = ""
            Dim sSql As String = ""
            Dim sOldPas As String = String.Empty

            sOldPas = Core.LoadEmpInfo("Admin")
            If txtOldPas.Text.Trim = sOldPas Then
                If txtNewPas.Text.Trim = txtRenewPas.Text.Trim Then
                    sSql = String.Format("UPDATE Emp SET Pass=N{0} WHERE LoginID='Admin'" _
                                       , Core.SQLStr(txtNewPas.Text))
                    If Var.DBAMain.Execute(sSql) Then
                        lblErrMes.Text = "Change password success!"
                    End If
                Else
                    lblErrMes.Text = "Retype new password not correct!"
                End If
            Else
                lblErrMes.Text = "Old password not correct!"
            End If
        Catch ex As Exception
            Log.LogError(ClsName, "btnSave_Click", ex.Message)
        End Try

    End Sub


    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("Admin.aspx")
    End Sub



    Protected Sub btnCreatEmp_Click(sender As Object, e As EventArgs) Handles btnCreatEmp.Click
        Try
            If txtSuperAdminPassword.Text.ToUpper.Equals(Var.sSuperAdminPass.ToUpper) Then
                Dim sSql As String = String.Format("INSERT INTO Emp (LoginID, Pass) VALUES({0}, {1})", Core.SQLStr(txtEmpLoginName.Text), Core.SQLStr(txtEmpLoginpass.Text))
                If Var.DBAMain.Execute(sSql) Then
                    lblErrMes.Text = "Create emp success!"
                Else
                    lblErrMes.Text = "Error!"
                End If
            Else
                lblErrMes.Text = "Super admin password not correct"

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class