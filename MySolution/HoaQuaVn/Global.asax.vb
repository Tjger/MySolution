
Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        AuthConfig.RegisterOpenAuth()
        RouteConfig.RegisterRoutes(RouteTable.Routes)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim CurrentURL_Path = Request.Path.ToLower()

        If CurrentURL_Path.StartsWith("/news/") Then
            CurrentURL_Path = CurrentURL_Path.Trim("/")
            Dim NewsID As String = CurrentURL_Path.Substring(CurrentURL_Path.IndexOf("/"))
            Dim MyContext As HttpContext
            MyContext = HttpContext.Current
            MyContext.RewritePath("/news.aspx?id=" + NewsID)
        End If

       
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
End Class