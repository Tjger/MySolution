'Imports System
'Imports System.Data
'Imports System.Configuration
'Imports System.Linq
'Imports System.Web
'Imports System.Web.Security
'Imports System.Web.UI
'Imports System.Web.UI.HtmlControls
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.WebControls.WebParts
'Imports System.Xml.Linq
Imports System.Drawing

Public Class Letter
    Private ValidFonts As String() = {"Segoe Script", "Century", "Eccentric Std", "Freestyle Script", "Viner Hand ITC"}
    Public Sub New(c As Char)
        Dim rnd As New Random()
        font = New Font(ValidFonts(rnd.[Next](ValidFonts.Count() - 1)), rnd.[Next](20) + 20, GraphicsUnit.Pixel)
        letter = c
    End Sub
    Public Property font() As Font
        Get
            Return m_font
        End Get
        Private Set(value As Font)
            m_font = Value
        End Set
    End Property
    Private m_font As Font
    Public ReadOnly Property LetterSize() As Size
        Get
            Dim Bmp = New Bitmap(1, 1)
            Dim Grph = Graphics.FromImage(Bmp)
            Return Grph.MeasureString(letter.ToString(), font).ToSize()
        End Get
    End Property
    Public Property letter() As Char
        Get
            Return m_letter
        End Get
        Private Set(value As Char)
            m_letter = Value
        End Set
    End Property
    Private m_letter As Char
    Public Property space() As Integer
        Get
            Return m_space
        End Get
        Set(value As Integer)
            m_space = Value
        End Set
    End Property
    Private m_space As Integer

End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
