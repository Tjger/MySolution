Imports Common
Public Class ucTopseller
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucTopseller"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            LoadCombo()
        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
            sSQL = "SELECT * FROM Item WHERE Active='1' AND Hot = '1' ORDER BY CreatedDate DESC "
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                dtlHotItemList.DataSource = ds.Tables("LoadCombo")
                dtlHotItemList.DataBind()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

    Public Shared Function GenerateURL(Title As Object) As String
        Dim strTitle As String = Title.ToString()


        strTitle = strTitle.Trim()


        strTitle = strTitle.Trim("-"c)

        strTitle = strTitle.ToLower()
        Dim chars As Char() = "$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray()
        strTitle = strTitle.Replace("c#", "C-Sharp")
        strTitle = strTitle.Replace("vb.net", "VB-Net")
        strTitle = strTitle.Replace("asp.net", "Asp-Net")


        strTitle = strTitle.Replace(".", "-")

        For i As Integer = 0 To chars.Length - 1
            Dim strChar As String = chars.GetValue(i).ToString()
            If strTitle.Contains(strChar) Then
                strTitle = strTitle.Replace(strChar, String.Empty)
            End If
        Next


        strTitle = strTitle.Replace(" ", "-")


        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("-----", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("--", "-")


        strTitle = strTitle.Trim()


        strTitle = strTitle.Trim("-"c)

        strTitle = (Convert.ToString("/San-Pham/") & strTitle) & ".aspx"

        Return strTitle
    End Function
End Class