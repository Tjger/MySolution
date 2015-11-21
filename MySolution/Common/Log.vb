Imports Common
Public Class Log
    Public Enum eLogClass
        Profile = 1
        Membership = 2

    End Enum
    Public Enum eLogCategory
        Membership_Transfer = 2000
        Membership_Status = 2001
        Credit_Limit = 2002
    End Enum

    Public Shared sAppPath As String
    Public Shared sModuleName As String
    Public Shared Name As String = "Log"

    Public Shared Sub Log(ByVal sMsg As String)
        Try

            Dim sFile As String

            'If sAppPath = "" Then
            sAppPath = My.Application.Info.DirectoryPath & "\LOG"
            'End If
            'If sModuleName = "" Then
            sModuleName = "MyProject"
            'End If

            If My.Computer.FileSystem.DirectoryExists(sAppPath) = False Then
                My.Computer.FileSystem.CreateDirectory(sAppPath)
            End If

            If Var.bLogFileNoRecycle = False Then
                sFile = sAppPath & "\" & sModuleName & Now.Day & ".txt"
            Else
                sFile = sAppPath & "\" & sModuleName & Now.ToString("yyyy-MM-dd") & ".txt"
            End If

            If My.Computer.FileSystem.FileExists(sFile) = False Then
                My.Computer.FileSystem.WriteAllText(sFile, String.Empty, False)
            Else
                Dim fileData As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(sFile)
                If fileData.CreationTime.Month <> Now.Month Then
                    'My.Computer.FileSystem.WriteAllText(sFile, String.Empty, False)
                    'My.Computer.FileSystem.DeleteFile(sFile)
                    fileData.CreationTime = Now
                    My.Computer.FileSystem.WriteAllText(sFile, String.Empty, False)
                End If
            End If

            Dim sIP As String = Core.GetIPAddress

            sMsg = "[" & sIP & "]" & Now.ToString("HH:mm:ss") & ":" & Now.Millisecond & " " & Var.sCurrentEmpName & " - WSID = " & Var.sWorkstationID & " --> " & sMsg & Environment.NewLine

            My.Computer.FileSystem.WriteAllText(sFile, sMsg, True)


        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub LogError(ByVal ClassName As String, ByVal FuncName As String, ByVal sErrMsg As String)
        Try
            Dim sMsg As String

            sMsg = "Error In " & ClassName & "<" & FuncName & ">" & sErrMsg
            Log(sMsg)
            'If Var.bPromptErr Then
            '    ' Windows.Forms.MessageBox.Show(sMsg, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            'End If


        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub Trace(ByVal msg As String)
        'Exit Sub
        Debug.WriteLine(Now.ToString("HH:mm:ss") & ":" & Now.Millisecond & " - " & msg)
        Log(msg)
    End Sub

End Class
