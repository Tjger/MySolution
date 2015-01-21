
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Web
Imports System.Security.Cryptography
Imports System.IO
'Imports System.Text


Public NotInheritable Class SecurityHelper
    Private Sub New()
    End Sub
    Private Shared ReadOnly Property SymmetricKey() As Byte()
        Get
            Return Encoding.UTF8.GetBytes("1B2c3D4e5F6g7H81")
        End Get
    End Property
    Public Shared Function EncryptString(data As String) As Byte()
        Dim ClearData As Byte() = Encoding.UTF8.GetBytes(data)
        Dim Algorithm As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Algorithm.Key = SymmetricKey

        Dim Target As New MemoryStream()
        Algorithm.GenerateIV()
        Target.Write(Algorithm.IV, 0, Algorithm.IV.Length)
        Dim cs As New CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write)
        cs.Write(ClearData, 0, ClearData.Length)
        cs.FlushFinalBlock()
        Return Target.ToArray()
    End Function
    Public Shared Function DecryptString(data As Byte()) As String
        Dim Algorithm As SymmetricAlgorithm = SymmetricAlgorithm.Create()
        Algorithm.Key = SymmetricKey
        Dim Target As New MemoryStream()
        Dim ReadPos As Integer = 0
        Dim IV As Byte() = New Byte(Algorithm.IV.Length - 1) {}
        Array.Copy(data, IV, IV.Length)
        Algorithm.IV = IV
        ReadPos += Algorithm.IV.Length
        Dim cs As New CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write)
        cs.Write(data, ReadPos, data.Length - ReadPos)
        cs.FlushFinalBlock()
        Return Encoding.UTF8.GetString(Target.ToArray())
    End Function
End Class

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
