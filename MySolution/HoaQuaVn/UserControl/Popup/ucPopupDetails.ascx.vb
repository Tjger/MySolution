﻿Imports Common

Public Class ucPopupDetails
    Inherits System.Web.UI.UserControl
    Public Event UC_btnOkClick()

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Core.InitAppSettingForDBA()
    '    Var.DBAMain = New Common.DBA(False)
    'End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            Dim sBodyMess As String = " Ten Khach Hang : " & txtGuestName.Text & vbCrLf
            sBodyMess &= " So Dien Thoai Khach Hang : " & txtGuestMobile.Text & vbCrLf
            sBodyMess &= " Dia Chi Email Khach Hang : " & txtGuestMail.Text & vbCrLf
            sBodyMess &= " Message Cua Khach Hang : " & txtGuestMes.Value & vbCrLf
            clsEmail.SendEmail("Toi Muon Dat Hang", "ns.tung86@gmail.com", sBodyMess)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = String.Empty
    End Sub
End Class