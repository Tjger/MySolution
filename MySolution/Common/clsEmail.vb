Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System
Imports Common

Public Class clsEmail
    Public Shared Function SendEmail(ByVal sEmailSubject As String, ByVal EmailAddress As String, ByVal sBodyMes As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim eMail As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage
        Dim IsBodyHTML As Boolean = False
        Dim ret As Boolean = False
        Try

            InitialEmailSettings(EmailAddress, sEmailSubject, IsBodyHTML, eMail)
            eMail.Body = sBodyMes
            ret = SendMail(eMail, sErrMsg)

        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
            sErrMsg = ex.Message
        End Try
        Return ret
    End Function

    Private Shared Sub InitialEmailSettings(ByVal sEmail As String, ByVal sEmailSubject As String, ByVal IsBodyHTML As Boolean, ByRef eMail As System.Net.Mail.MailMessage)
        Try
            eMail.To.Add(sEmail)
            eMail.From = New MailAddress(Var.SmtpEmailAddress, Var.SmtpEmailSenderName, System.Text.Encoding.UTF8)
            eMail.Subject = sEmailSubject
            eMail.SubjectEncoding = System.Text.Encoding.UTF8
            eMail.Body = ""
            eMail.BodyEncoding = System.Text.Encoding.UTF8
            eMail.IsBodyHtml = IsBodyHTML
            eMail.Priority = MailPriority.Normal
        Catch ex As Exception
            'LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
    End Sub

    Private Shared Function SendMail(ByVal eMail As System.Net.Mail.MailMessage, ByRef ErrMsg As String) As Boolean
        Try
            Dim SmtpClient As SmtpClient = New SmtpClient
            SmtpClient.Credentials = New System.Net.NetworkCredential(Var.SMTPEmailAddress, Var.SMTPEmailPassword)
            SmtpClient.Port = Var.SMTPPort
            SmtpClient.Host = Var.SMTPHost
            SmtpClient.EnableSsl = Var.SMTPEnableSSL
            SmtpClient.Send(eMail)
            Return True
        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
            ErrMsg = ex.Message
            Return False
        End Try
    End Function

    Private Shared Sub SetMailBodyByHtml(ByVal Uri As Uri, ByVal sPath As String, ByVal sHtmlBody As String, ByRef eMail As System.Net.Mail.MailMessage)
        Dim sModifiedBody As String = ""
        Dim FoundResources As List(Of LinkedResource)
        Dim MStream As MemoryStream
        Dim Bytes As Byte()
        Dim altView As AlternateView

        Try
            FoundResources = New List(Of LinkedResource)
            ExtractLinkedResources(Uri, sPath, sHtmlBody, sModifiedBody, FoundResources)

            MStream = New MemoryStream
            Bytes = System.Text.Encoding.UTF8.GetBytes(sModifiedBody)
            MStream.Write(Bytes, 0, Bytes.Length)
            MStream.Position = 0

            eMail.Body = ""
            altView = New AlternateView(MStream, System.Net.Mime.MediaTypeNames.Text.Html)

            For Each LinkedResource As LinkedResource In FoundResources
                altView.LinkedResources.Add(LinkedResource)
            Next

            eMail.AlternateViews.Add(altView)
        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
    End Sub

    Private Shared Sub ExtractLinkedResources(ByVal Uri As Uri, ByVal sPath As String, ByVal sHtmlBody As String, ByRef sModifiedBody As String, ByRef linkedResources As List(Of LinkedResource))
        sModifiedBody = sHtmlBody

        Dim sImageNames As List(Of String) = ExtractImageNames(sHtmlBody)
        Dim sImageID As String = 1

        For Each sImageName As String In sImageNames
            Try
                Dim sWorkaroundImageName As String = sImageName.Replace("&amp;", "&")
                Dim imageUri As Uri = New Uri(Uri, sWorkaroundImageName)
                Dim sContentType As String = ""
                Dim imageStream As Stream = GetImageStream(imageUri, sPath, sContentType)
                Dim data As LinkedResource = New LinkedResource(imageStream)
                Dim sGeneratedName As String = Nothing

                If (sContentType.ToLower().IndexOf("image/gif") >= 0) Then
                    data.ContentType.MediaType = System.Net.Mime.MediaTypeNames.Image.Gif
                    sGeneratedName = "image" + sImageID.ToString() + ".gif"
                ElseIf (sContentType.ToLower().IndexOf("image/jpeg") >= 0) Then
                    data.ContentType.MediaType = System.Net.Mime.MediaTypeNames.Image.Jpeg
                    sGeneratedName = "image" + sImageID.ToString() + ".jpeg"
                ElseIf (sContentType.ToLower().IndexOf("image/jpg") >= 0) Then
                    data.ContentType.MediaType = System.Net.Mime.MediaTypeNames.Image.Jpeg
                    sGeneratedName = "image" + sImageID.ToString() + ".jpg"
                End If

                If (sGeneratedName = Nothing) Then
                    Exit Try
                End If

                Dim sGeneratedSrc As String = "cid:" + sGeneratedName
                data.ContentType.Name = sGeneratedName
                data.ContentId = sGeneratedName
                data.ContentLink = New Uri(sGeneratedSrc)
                linkedResources.Add(data)

                sModifiedBody = sModifiedBody.Replace(sImageName, sGeneratedSrc)

            Catch ex As Exception
                sModifiedBody = sModifiedBody.Replace(sImageName, "#")
            End Try
            sImageID += 1
        Next
    End Sub

    Private Shared Function ExtractImageNames(ByVal sHtml As String) As List(Of String)

        Dim sImageNames As List(Of String) = New List(Of String)
        Dim sImageAttributes As String() = New String() {"src=", "background="}

        Try
            For Each sImageAttribute As String In sImageAttributes
                Dim nPosition As Integer = 0

                While (nPosition < sHtml.Length)
                    Dim nFoundIndex As Integer = sHtml.ToLower().IndexOf(sImageAttribute, nPosition)
                    If (nFoundIndex < 0) Then
                        nPosition = sHtml.Length
                    Else
                        Dim nValueStartIndex As Integer = nFoundIndex + sImageAttribute.Length + 1
                        Dim nFoundIndexEnd As Integer = sHtml.IndexOfAny(New Char() {"\""", " ", "\'", ">"}, nValueStartIndex)
                        If (nFoundIndexEnd < 0) Then
                            nPosition = sHtml.Length
                        Else
                            Dim sRelativeImageName As String = sHtml.Substring(nValueStartIndex, nFoundIndexEnd - nValueStartIndex - 1)
                            sRelativeImageName = sRelativeImageName.Trim(New Char() {"\""", " ", "\'", ">"})

                            If (Not sImageNames.Contains(sRelativeImageName)) Then
                                Dim sAll As String = sRelativeImageName
                                Dim sArrAll() As String = sAll.Split(".")

                                For i As Integer = 0 To sArrAll.Length - 1
                                    If i = sArrAll.Length - 1 Then
                                        Dim sExtension As String
                                        sExtension = sArrAll(i)

                                        Select Case sExtension.ToLower
                                            Case "gif", "jpeg", "jpg"
                                                sImageNames.Add(sRelativeImageName)
                                            Case Else

                                        End Select
                                    End If
                                Next
                            End If
                            nPosition = nFoundIndexEnd
                        End If
                    End If
                End While
            Next
        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
        Return sImageNames
    End Function

    Private Shared Function GetImageStream(ByVal uri As Uri, ByVal sPath As String, ByRef sContentType As String) As Stream
        Dim _Stream As IO.Stream = New IO.FileStream(uri.AbsolutePath, IO.FileMode.Open, IO.FileAccess.Read)
        sContentType = GetContentType(uri.AbsolutePath)

        Return _Stream
    End Function

    Private Shared Function GetContentType(ByVal filename As String) As String
        Dim contentType As String = "application/octetstream"

        Dim ext As String = System.IO.Path.GetExtension(filename).ToLower()

        Dim registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext)

        If (registryKey IsNot Nothing AndAlso registryKey.GetValue("Content Type") IsNot Nothing) Then
            contentType = registryKey.GetValue("Content Type").ToString()
        End If

        Return contentType
    End Function

    Public Shared Function GetEmailStatus(ByRef EmailCount As Integer, ByVal RevID As String, Optional ByVal ApptID As String = "", Optional ByVal GolfApptID As String = "", Optional ByVal ActivityApptID As String = "") As Var.eEmailStatus
        Dim ret As Var.eEmailStatus = Var.eEmailStatus.NotSent
        Dim sSQL As String = ""
        Dim temp As String
        Try
            If ApptID <> "" Then
                sSQL = "select count(*) from EmailHistory where ',' +ApptID +',' like " & Core.SQLStr("%" & ApptID & "%") & " and RevID =" & Core.SQLStr(RevID)
                temp = Var.DBAMain.ExecuteScalar(sSQL)
                If temp = "" Then
                    EmailCount = 0
                Else
                    EmailCount = Val(temp)
                End If

                sSQL = "select top 1 Status from EmailHistory where ',' +ApptID +',' like " & Core.SQLStr("%" & ApptID & "%") & " and RevID =" & Core.SQLStr(RevID) & " order by SentDate desc"
                Select Case Var.DBAMain.ExecuteScalar(sSQL)
                    Case "1"
                        ret = Var.eEmailStatus.Sent
                    Case "0"
                        ret = Var.eEmailStatus.Failed
                    Case Else
                        ret = Var.eEmailStatus.NotSent
                End Select
            ElseIf GolfApptID <> "" Then
                sSQL = "select count(*) from EmailHistory where ',' +GolfApptID +',' like " & Core.SQLStr("%" & GolfApptID & "%") & " and RevID =" & Core.SQLStr(RevID)
                temp = Var.DBAMain.ExecuteScalar(sSQL)
                If temp = "" Then
                    EmailCount = 0
                Else
                    EmailCount = Val(temp)
                End If

                sSQL = "select top 1 Status from EmailHistory where ',' +GolfApptID +',' like " & Core.SQLStr("%" & GolfApptID & "%") & " and RevID =" & Core.SQLStr(RevID) & " order by SentDate desc"
                Select Case Var.DBAMain.ExecuteScalar(sSQL)
                    Case "1"
                        ret = Var.eEmailStatus.Sent
                    Case "0"
                        ret = Var.eEmailStatus.Failed
                    Case Else
                        ret = Var.eEmailStatus.NotSent
                End Select
            ElseIf ActivityApptID <> "" Then
                sSQL = "select count(*) from EmailHistory where ',' +ActivityApptID +',' like " & Core.SQLStr("%" & ActivityApptID & "%")
                temp = Var.DBAMain.ExecuteScalar(sSQL)
                If temp = "" Then
                    EmailCount = 0
                Else
                    EmailCount = Val(temp)
                End If

                sSQL = "select top 1 Status from EmailHistory where ',' +ActivityApptID +',' like " & Core.SQLStr("%" & ActivityApptID & "%") & " order by SentDate desc"
                Select Case Var.DBAMain.ExecuteScalar(sSQL)
                    Case "1"
                        ret = Var.eEmailStatus.Sent
                    Case "0"
                        ret = Var.eEmailStatus.Failed
                    Case Else
                        ret = Var.eEmailStatus.NotSent
                End Select
            End If
        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
        Return ret
    End Function

    Public Shared Sub UpdateEmailStatus(ByVal GuestID As String, ByVal EmailAddress As String, ByVal EmailBody As String, ByVal Status As Boolean, ByVal ErrMsg As String, Optional ByVal ApptID As String = "", Optional ByVal GolfApptID As String = "", Optional ByVal ActivityApptID As String = "")
        Dim sql As String
        Try

            If Status Then
                sql = "Update Guest set LastEmailSentDate =" & Core.SQLStr(Now.ToString(Var.sSQLDateTimeFmt)) & " where GuestID =" & Core.SQLStr(GuestID)
                Var.DBAMain.Execute(sql)

                sql = "insert into EmailHistory(GuestID,SentDate,EmailAddress,Msg,Status,ErrMsg,ApptID,GolfApptID,ActivityApptID,RevID) "
                sql &= "values(" & Core.SQLStr(GuestID)
                sql &= "," & Core.SQLStr(Now.ToString(Var.sSQLDateTimeFmt))
                sql &= "," & Core.SQLStr(EmailAddress)
                sql &= "," & Core.SQLStr(EmailBody)
                sql &= "," & Core.SQLStr("1")
                sql &= ", ''"
                sql &= "," & Core.SQLStr(ApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(GolfApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(ActivityApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(Var.sRevID) & ")"
                Var.DBAMain.Execute(sql)
            Else
                sql = "insert into EmailHistory(GuestID,SentDate,EmailAddress,Msg,Status,ErrMsg,ApptID,GolfApptID,ActivityApptID,RevID) "
                sql &= "values(" & Core.SQLStr(GuestID)
                sql &= "," & Core.SQLStr(Now.ToString(Var.sSQLDateTimeFmt))
                sql &= "," & Core.SQLStr(EmailAddress)
                sql &= "," & Core.SQLStr(EmailBody)
                sql &= "," & Core.SQLStr("0")
                sql &= "," & Core.SQLStr(ErrMsg)
                sql &= "," & Core.SQLStr(ApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(GolfApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(ActivityApptID.Replace("'", ""))
                sql &= "," & Core.SQLStr(Var.sRevID) & ")"
                Var.DBAMain.Execute(sql)
            End If

        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
    End Sub

    Public Shared Function GetEmailAddress(ByVal GuestID As String) As String
        Dim email As String = ""
        Dim r As DataRow = Nothing
        Try

            r = Var.DBAMain.QueryRow("select top 1 * from Guest where GuestID =" & Core.SQLStr(GuestID))
            If r Is Nothing Then Exit Try

            If IsDBNull(r("Email")) = False AndAlso r("Email") <> "" Then
                email = r("Email")
            ElseIf IsDBNull(r("Email2")) = False AndAlso r("Email2") <> "" Then
                email = r("Email2")
            ElseIf IsDBNull(r("CompEmail")) = False AndAlso r("CompEmail") <> "" Then
                email = r("CompEmail")
            End If


        Catch ex As Exception
            'Log.LogError("clsEmail", Core.WhoCalledMe, ex.Message)
        End Try
        Return email
    End Function

End Class
