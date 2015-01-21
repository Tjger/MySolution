
Public Class ucCapCha
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucCapCha"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If GeneratedText Is Nothing Then
                TryNew()
            End If
        End If
    End Sub

    Public Sub TryNew()
        Dim Valichars As Char() = {"1"c, "2"c, "3"c, "4"c, "5"c, "6"c, _
            "7"c, "8"c, "9"c, "0"c, "a"c, "b"c, _
            "c"c, "d"c, "e"c, "f"c, "g"c, "h"c, _
            "i"c, "j"c, "k"c, "l"c, "m"c, "n"c, _
            "o"c, "p"c, "q"c, "r"c, "s"c, "t"c, _
            "u"c, "v"c, "w"c, "x"c, "y"c, "z"c}
        Dim Captcha As String = ""
        Dim LetterCount As Integer = If(MaxLetterCount > 5, MaxLetterCount, 5)
        For i As Integer = 0 To LetterCount - 1
            Dim newChar As Char = "0"
            Do
                newChar = [Char].ToUpper(Valichars(New Random(DateTime.Now.Millisecond).[Next](Valichars.Count() - 1)))
            Loop While Captcha.Contains(newChar)
            Captcha += newChar
        Next
        GeneratedText = Captcha

        ImgCaptcha.ImageUrl = "GetImgText.ashx?CaptchaText=" + Server.UrlEncode(Convert.ToBase64String(SecurityHelper.EncryptString(Captcha)))
    End Sub
    Public Property MaxLetterCount() As Integer
        Get
            Return m_MaxLetterCount
        End Get
        Set(value As Integer)
            m_MaxLetterCount = Value
        End Set
    End Property
    Private m_MaxLetterCount As Integer

    Private Property GeneratedText() As String
        Get
            Return If(ViewState(Me.ClientID + "text") IsNot Nothing, ViewState(Me.ClientID + "text").ToString(), Nothing)
        End Get
        Set(value As String)
            ' Encrypt the value before storing it in viewstate.
            ViewState(Me.ClientID + "text") = value
        End Set
    End Property
    Public ReadOnly Property IsValid() As Boolean
        Get
            Dim result As Boolean = GeneratedText.ToUpper() = TxtCpatcha.Text.Trim().ToUpper()
            If Not result Then
                TryNew()
            End If
            Return result
        End Get
    End Property

    Protected Sub btnTryNewWords_Click(sender As Object, e As EventArgs) Handles btnTryNewWords.Click
        TryNew()
    End Sub

   
End Class