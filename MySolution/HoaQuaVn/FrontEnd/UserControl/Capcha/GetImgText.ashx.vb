Imports System.Web
Imports System.Web.Services
Imports System.Drawing
Public Class GetImgText
    Implements System.Web.IHttpHandler


    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "image/jpeg"
        Dim CaptchaText = SecurityHelper.DecryptString(Convert.FromBase64String(context.Request.QueryString("CaptchaText")))
        If CaptchaText IsNot Nothing Then
            Dim letter As New List(Of Letter)()
            Dim TotalWidth As Integer = 0
            Dim MaxHeight As Integer = 0
            For Each c As Char In CaptchaText
                Dim ltr = New Letter(c)
                letter.Add(ltr)
                Dim space As Integer = (New Random()).[Next](5) + 1
                ltr.space = space
                System.Threading.Thread.Sleep(1)
                TotalWidth += ltr.LetterSize.Width + space
                If MaxHeight < ltr.LetterSize.Height Then
                    MaxHeight = ltr.LetterSize.Height
                End If
                System.Threading.Thread.Sleep(1)
            Next
            Const HMargin As Integer = 5
            Const VMargin As Integer = 3

            Dim bmp As New Bitmap(TotalWidth + HMargin, MaxHeight + VMargin)
            Dim Grph = Graphics.FromImage(bmp)
            Grph.FillRectangle(New SolidBrush(Color.Lavender), 0, 0, bmp.Width, bmp.Height)
            Pixelate(bmp)
            Grph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            Grph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            Dim xPos As Integer = HMargin
            For Each ltr As Letter In letter
                Grph.DrawString(ltr.letter.ToString(), ltr.font, New SolidBrush(Color.Navy), xPos, VMargin)
                xPos += ltr.LetterSize.Width + ltr.space
            Next

            bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If
    End Sub

    '=======================================================
    'Service provided by Telerik (www.telerik.com)
    'Conversion powered by NRefactory.
    'Twitter: @telerik
    'Facebook: facebook.com/telerik
    '=======================================================


    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Sub Pixelate(ByRef bmp As Bitmap)
        Dim Colors As Color() = {Color.Gray, Color.Red, Color.Blue, Color.Olive}
        For i As Integer = 0 To 199
            Dim rnd = New Random(DateTime.Now.Millisecond)
            Dim grp = Graphics.FromImage(bmp)
            Dim background As Image = Image.FromFile(HttpContext.Current.Server.MapPath("~/FrontEnd/image/captcha/captcha3.jpg"))
            grp.DrawImage(background, New Rectangle(0, 0, bmp.Width, bmp.Height))
        Next
    End Sub


End Class