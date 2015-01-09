Imports Common
Public Class ucProductProperties
    Inherits System.Web.UI.UserControl
    Private ClsName = "ucProductProperties"
    Public pagingDataList As New PagedDataSource()
    Public iCount As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lbPrev.Visible = False
            Core.InitAppSettingForDBA()
            Var.DBAMain = New Common.DBA(False)
            LoadCombo()
        End If
    End Sub

    Sub LoadCombo()
        Dim sSQL As String = String.Empty
        Dim ds As New DataSet
        Try
            sSQL = "SELECT * FROM Item WHERE Active='1' "
            Var.DBAMain.FillDataset(sSQL, ds, "LoadCombo")
           
            If ds.Tables("LoadCombo").Rows.Count > 0 Then
                pagingDataList.DataSource = ds.Tables("LoadCombo").DefaultView()
                pagingDataList.AllowPaging = True
                pagingDataList.PageSize = 12
                pagingDataList.CurrentPageIndex = CurrentPage
                lblShow.Text = "Trang số: " & (CurrentPage + 1).ToString() & " của " & pagingDataList.PageCount.ToString()
                ViewState("iCount") = pagingDataList.PageCount.ToString()
                dtlItemList.DataSource = pagingDataList
                dtlItemList.DataBind()

            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub
    Public Property CurrentPage() As Integer
        Get
            Dim s1 As Object = Me.ViewState("CurrentPage")
            If s1 Is Nothing Then
                Return 0
            Else
                Return CInt(s1)
            End If
        End Get
        Set(ByVal value As Integer)
            Me.ViewState("CurrentPage") = value
        End Set
    End Property

    Protected Sub lbPrev_Click(sender As Object, e As EventArgs)
        Try
            CurrentPage -= 1
            If CurrentPage = 0 Then
                lbPrev.Visible = False
                lbNext.Visible = True
                LoadCombo()

            Else

                LoadCombo()
            End If


        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try
    End Sub

    Protected Sub lbNext_Click(sender As Object, e As EventArgs)
        Try
            CurrentPage += 1

            If CurrentPage = Int32.Parse(ViewState("iCount").ToString() - 1) Then
                lbNext.Visible = False
                lbPrev.Visible = True
                LoadCombo()
            Else
                LoadCombo()
            End If

        Catch ex As Exception
            Log.LogError(ClsName, "LoadCombo", ex.Message)
        End Try

    End Sub
End Class