Imports Common
Imports System.Reflection
Imports Common.Var
Imports System.IO
Imports System.Windows.Forms
Imports System.Text
Imports System.Security.Cryptography

Imports System.Text.RegularExpressions
Imports System.IO.Ports

Imports System
Imports System.Runtime.InteropServices

Public Class Core

    Public Shared Name = "Core"

    Public Structure ObjInfo
        Public ObjID As Var.ObjectType
        Public sTable As String
        Public sColID As String
        Public sColName As String
        Public GroupObjID As Var.ObjectType
        Public sColGroupID As String
        Public bRev As Boolean
        Public bJoinTable As Boolean
    End Structure

#Region "Log"

    Public Shared Function WhoCalledMe() As String
        Dim st As StackTrace = New StackTrace()
        Dim sf As StackFrame = st.GetFrame(1)
        Dim mb As MethodBase = sf.GetMethod()
        Return mb.Name
    End Function

#End Region

#Region "Casting"

    Public Shared Function SQLStr(ByVal str As String, Optional ByVal sFlag As String = "'") As String
        Dim sTemp As String = ""
        Try
            If str Is Nothing Then str = ""
            sTemp = str
            If sFlag = "" Then
                Return sTemp
            Else
                Return sFlag & sTemp.Replace(sFlag, sFlag & sFlag) & sFlag
            End If
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return sFlag & sFlag
        End Try
    End Function

    Public Shared Sub ShowForm(frm As Form)
        frm.Show()
    End Sub

    Public Shared Function SQLStr(ByVal obj() As Object, Optional ByVal sFlag As String = "'") As String
        If obj Is Nothing Then Return sFlag & sFlag

        Dim s As Object
        Dim sTemp As String = ""
        Try
            For Each s In obj
                If sTemp <> "" Then
                    sTemp &= ","
                End If
                sTemp &= SQLStr(s.ToString, sFlag)
            Next
            Return sTemp
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return sFlag & sFlag
        End Try
    End Function

    Public Shared Function SQLDate(ByRef dt As Date, Optional ByVal sCustomFmt As String = "", Optional ByVal sFlag As String = "'") As String
        Dim sDate As String
        If sCustomFmt <> "" Then
            sDate = dt.ToString(sCustomFmt)
        Else
            sDate = dt.ToString(sSQLDateTimeFmt)
        End If

        Return sDate
    End Function

    'Pending For Language Class
    Public Shared Function EnumToDataTable(ByVal EnumObject As Type, _
    ByVal sKeyField As String, ByVal sValueField As String) As DataTable

        Dim dt As DataTable = Nothing
        Dim dr As DataRow = Nothing
        Dim col As DataColumn = Nothing
        Dim text As String = ""
        Try
            '-------------------------------------------------------------
            ' Sanity check
            If sKeyField.Trim() = String.Empty Then
                sKeyField = "KEY"
            End If

            If sValueField.Trim() = String.Empty Then
                sValueField = "VALUE"
            End If
            '-------------------------------------------------------------

            '-------------------------------------------------------------
            ' Create the DataTable
            dt = New DataTable

            col = New DataColumn(sKeyField, GetType(System.String))
            dt.Columns.Add(col)

            col = New DataColumn(sValueField, GetType(System.String))
            dt.Columns.Add(col)
            '-------------------------------------------------------------

            '-------------------------------------------------------------
            ' Add the enum items to the datatable
            For Each iEnumItem As Object In [Enum].GetValues(EnumObject)
                dr = dt.NewRow()

                dr(sKeyField) = CType(iEnumItem, String)
                'text = Lang.Trans(StrConv(Replace(iEnumItem.ToString(), "__", " & "), _
                'VbStrConv.ProperCase))
                'dr(sValueField) = LanguageCls.FreeText(StrConv(Replace(text, "_", " "), _
                '      VbStrConv.ProperCase))

                'text = StrConv(Replace(iEnumItem.ToString(), "__", " & "), _
                '                      VbStrConv.ProperCase)
                dr(sValueField) = StrConv(Replace(text, "_", " "), _
                      VbStrConv.ProperCase)

                dt.Rows.Add(dr)
            Next
            '-------------------------------------------------------------

            dt.AcceptChanges()
            Return dt
        Catch ex As Exception

            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function BoolToStr(ByVal b As Boolean) As String
        If b Then
            Return "1"
        Else
            Return "0"
        End If
    End Function

    Public Shared Function StrToBool(ByVal str As String) As Boolean
        If str = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function ByteToImage(ByVal Obj As Object, Optional ByRef ms As System.IO.MemoryStream = Nothing) As System.Drawing.Image
        Dim file() As Byte

        Try
            If Obj Is Nothing Then Return Nothing
            If IsDBNull(Obj) Then Return Nothing

            If ms Is Nothing = False Then
                ms.Close()
                ms.Dispose()
            End If
            ms = New System.IO.MemoryStream
            file = Obj
            ms.Write(file, 0, file.Length)
            Return System.Drawing.Image.FromStream(ms)
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return Nothing
        End Try
    End Function
#End Region

#Region "Validation"
    Public Shared Function ValidateEmail(ByVal sEmail As String) As Boolean
        Dim sExp As String = "^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"

        Return System.Text.RegularExpressions.Regex.IsMatch(sEmail, sExp)
    End Function

    Public Shared Function FileExist(ByVal sFileName As String) As Boolean
        Dim bFlag As Boolean = False
        Try

            bFlag = File.Exists(sFileName)

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
        End Try
        Return bFlag
    End Function

    Public Shared Function CheckSQLIsEmpty(ByVal sSQL As String) As Boolean
        Try
            Return Var.DBAMain.Execute(sSQL)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function CheckDataTableIsEmpty(ByVal DataTable As DataTable) As Boolean
        Try
            If DataTable.Rows.Count <= 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

#End Region


#Region "Automated Complete"

    'Public Shared Function FillComboBox(ByRef cbo As Janus.Windows.EditControls.UIComboBox, ByVal sSQL As String, ByVal sDataMember As String, ByVal sValueMember As String, Optional ByVal sDefaultData As String = "", Optional ByVal sDefaultValue As Object = Nothing) As DataTable
    '    Dim ds As DataSet = Nothing
    '    Try
    '        Var.DBAMain.FillDataset(sSQL, ds)
    '        FillComboBox(cbo, ds.Tables(0), sDataMember, sValueMember, sDefaultData, sDefaultValue)
    '        Return ds.Tables(0)
    '    Catch ex As Exception
    '        'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
    '        Return Nothing
    '    End Try

    'End Function

    'Public Shared Function FillComboBox(ByRef cbo As Janus.Windows.EditControls.UIComboBox, ByVal sEnum As Type, Optional ByVal sDataMember As String = "Name", Optional ByVal sValueMember As String = "ID", Optional ByVal sDefaultData As String = "", Optional ByVal sDefaultValue As Object = Nothing) As DataTable
    '    Dim dt As DataTable
    '    Try
    '        dt = Core.EnumToDataTable(sEnum, sValueMember, sDataMember)
    '        FillComboBox(cbo, dt, sDataMember, sValueMember, sDefaultData, sDefaultValue)
    '        Return dt
    '    Catch ex As Exception
    '        'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
    '        Return Nothing
    '    End Try
    'End Function

    'Public Shared Sub FillComboBox(ByRef cbo As Janus.Windows.EditControls.UIComboBox, ByRef dt As DataTable, Optional ByVal sDataMember As String = "Name", Optional ByVal sValueMember As String = "ID", Optional ByVal sDefaultData As String = "", Optional ByVal sDefaultValue As Object = Nothing)
    '    Try

    '        If sDefaultData = "" Then
    '            cbo.Items.Clear()
    '            Dim dr As DataRow
    '            For Each dr In dt.Rows
    '                cbo.Items.Add(dr(sDataMember) & "", dr(sValueMember) & "")
    '            Next
    '        Else

    '            cbo.Items.Clear()
    '            cbo.Items.Add(sDefaultData, sDefaultValue)
    '            Dim dr As DataRow
    '            For Each dr In dt.Rows
    '                cbo.Items.Add(dr(sDataMember) & "", dr(sValueMember) & "")
    '            Next
    '        End If

    '    Catch ex As Exception
    '        'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
    '    End Try
    'End Sub

    
#End Region

    Public Shared Function GetFieldByCondition(ByVal sTable As String, ByVal sRetriveField As String, ByVal sConditionField As String, ByVal sConditionValue As String, Optional ByVal sRevID As String = "") As String

        Dim sSQL As String
        Dim sRetrieveValue As String = ""

        Try
            sSQL = "SELECT " & sRetriveField & " FROM " & sTable & " WHERE " & sConditionField & " = '" & sConditionValue & "' "

            If sRevID <> "" Then
                sSQL = sSQL & "AND RevID ='" & sRevID & "'"
            End If

            sRetrieveValue = DBAMain.ExecuteScalar(sSQL).ToString

            Return sRetrieveValue

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return ""
        End Try
    End Function

#Region "System Setting"
    '==========Get Regional Date Format================================
    Private Declare Function GetLocaleInfo Lib "kernel32" _
Alias "GetLocaleInfoA" (ByVal Locale As Integer, _
ByVal LCType As Integer, ByVal lpLCData As String, _
ByVal cchData As Integer) As Integer
    Private Declare Function GetUserDefaultLCID% Lib "kernel32" ()
    Private Const LOCALE_SSHORTDATE As Integer = &H1F

    Public Shared Function GetRegionalDateFormat() As String
        Dim Symbol As String
        Dim iRet As Long
        Dim lpLCDataVar As String = ""
        Dim Locale As Long
        Dim dateLength As Integer
        Dim sShortDate As String
        sShortDate = New Date(2001, 1, 1)
        dateLength = sShortDate.Length
        Locale = GetUserDefaultLCID()
        iRet = GetLocaleInfo(Locale, LOCALE_SSHORTDATE, lpLCDataVar, 0)
        Symbol = New String(Chr(iRet), dateLength)
        GetLocaleInfo(Locale, LOCALE_SSHORTDATE, Symbol, iRet)
        Return Symbol
    End Function
    '============================================================
#End Region

#Region "Form Setting"
    <DllImport("user32.dll")> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Int32) As Short
    End Function
    'Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Long) As Integer

    Private Shared OldPos As Drawing.Point = Nothing
    Public Shared LastActiveTime As Date = Nothing
    Public Shared frmLogin As Object = Nothing
    Public Shared ValidLogin As Boolean = True

    Public Shared Function IsValidApplication() As Boolean
        Dim ret As Boolean = False
        Try

            If System.Windows.Forms.Form.ActiveForm Is Nothing Then Exit Try
            Select Case System.Windows.Forms.Form.ActiveForm.CompanyName.ToUpper
                Case "PARADIGM SHIFT JAPAN KK"
                    ret = True
                Case Else
                    ret = False
            End Select

        Catch ex As Exception
            'Log.LogError("core", Core.WhoCalledMe, ex.Message)
        End Try
        Return ret
    End Function

    Private Shared Sub frmActivated(ByVal sender As Object, ByVal e As System.EventArgs)
        sender.Visible = True
        sender.logouttimer.start()
        'If IsFormAllowVisible(sender.name) Then sender.logouttimer.start()
    End Sub

    Private Shared Function IsFormAllowVisible(ByVal formName As String) As Boolean
        'Select Case formName
        '    Case "frmProfileSearch", "frmProfile", "frmApptAdd", "frmEmpSchedule", "frmStockSearch", "frmApptSchedule", "frmPackageItemSelection", "frmActSchedule"
        Return True
        '    Case Else
        'Return False
        'End Select
    End Function

    Private Shared Sub frmDeactivate(ByVal sender As Object, ByVal e As System.EventArgs)
        'Debug.WriteLine(Now.ToShortTimeString & ">>>>>" & sender.name)
        Try

            If IsValidApplication() Then
                If IsFormAllowVisible(sender.name) = False Then
                    sender.Visible = False
                Else
                    sender.logouttimer.stop()
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function SplitWords(ByVal s As String) As String()
        Return Regex.Split(s, "\W+")
    End Function

#End Region

#Region "Utility"

    Public Shared Function InsertDataRow(ByRef dt As DataTable, ByRef dr As DataRow) As Boolean
        Dim newdr As DataRow
        Dim col As DataColumn
        Try
            newdr = dt.NewRow
            For Each col In dt.Columns
                If col.AutoIncrement = False Then
                    newdr(col.ColumnName) = dr(col.ColumnName)
                End If
            Next
            dt.Rows.Add(newdr)
            Return True
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CloneDataRow(ByRef dr As DataRow) As DataRow
        Dim col As DataColumn
        Dim clonedr As DataRow
        Try
            clonedr = dr.Table.NewRow
            For Each col In dr.Table.Columns
                If col.AutoIncrement = False Then
                    clonedr(col.ColumnName) = dr(col.ColumnName)
                End If
            Next
            Return clonedr
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return Nothing
        End Try

    End Function

    Public Shared Function SelectDT(ByVal sFilter As String, ByRef dt As DataTable, Optional ByRef drCol() As DataRow = Nothing) As Boolean
        Try
            If dt Is Nothing Then Return False

            drCol = dt.Select(sFilter)

            If drCol Is Nothing OrElse drCol.Length = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CloneTable(ByVal sSQLSource As String, ByVal sSQLDes As String, ByRef dt As DataTable, ByRef da As IDbDataAdapter) As Boolean
        Dim ds As DataSet = Nothing
        Try
            If Var.DBAMain.FillDataset(sSQLSource, ds, "Source") = False Then
                Return False
            End If

            If Var.DBAMain.FillForUpdate(sSQLDes, ds, "Destination", da) = False Then
                Return False
            End If

            If CloneTable(ds.Tables("Source"), ds.Tables("Destination")) = False Then Return False

            dt = ds.Tables("Destination")
            Return True
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function CloneTable(ByRef dtSource As DataTable, ByRef dtDes As DataTable) As Boolean
        Dim dr As DataRow
        Try

            For Each dr In dtSource.Rows
                If Core.InsertDataRow(dtDes, dr) = False Then
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function SetColumnData(ByRef dt As DataTable, ByVal sColumnName As String, ByVal Data As Object) As Boolean
        Dim dr As DataRow
        Try
            For Each dr In dt.Rows
                dr(sColumnName) = Data
            Next
            Return True
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try

    End Function

    

    



    
#End Region

#Region "Encoding"
    ' Hash an input string and return the hash as
    ' a 32 character hexadecimal string.
    Public Shared Function GetMd5Hash(ByVal input As String) As String
        ' Create a new instance of the MD5 object.
        Dim md5Hasher As MD5 = MD5.Create()

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i


        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function

    ' Verify a hash against a string.
    Public Shared Function VerifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(input)

        ' Create a StringComparer an comare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function CheckPwdsCycle(ByVal sCycle As Integer, ByVal sEncPwd As String, ByVal dr As DataRow) As Boolean
        Dim result As Boolean = False
        Try
            Dim msg As String = String.Empty
            If sCycle = 5 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 6 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 7 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 8 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 9 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 10 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 11 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" OrElse sEncPwd = dr("ExPwd11") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 12 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" OrElse sEncPwd = dr("ExPwd11") & "" OrElse sEncPwd = dr("ExPwd12") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 13 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" OrElse sEncPwd = dr("ExPwd11") & "" OrElse sEncPwd = dr("ExPwd12") & "" OrElse sEncPwd = dr("ExPwd13") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 14 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" OrElse sEncPwd = dr("ExPwd11") & "" OrElse sEncPwd = dr("ExPwd12") & "" OrElse sEncPwd = dr("ExPwd13") & "" OrElse sEncPwd = dr("ExPwd14") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
            If sCycle = 15 Then
                If sEncPwd = dr("Pwd") & "" OrElse sEncPwd = dr("ExPwd1") & "" OrElse sEncPwd = dr("ExPwd2") & "" OrElse sEncPwd = dr("ExPwd3") & "" OrElse sEncPwd = dr("ExPwd4") & "" OrElse sEncPwd = dr("ExPwd5") & "" OrElse sEncPwd = dr("ExPwd6") & "" OrElse sEncPwd = dr("ExPwd7") & "" OrElse sEncPwd = dr("ExPwd8") & "" OrElse sEncPwd = dr("ExPwd9") & "" OrElse sEncPwd = dr("ExPwd10") & "" OrElse sEncPwd = dr("ExPwd11") & "" OrElse sEncPwd = dr("ExPwd12") & "" OrElse sEncPwd = dr("ExPwd13") & "" OrElse sEncPwd = dr("ExPwd14") & "" OrElse sEncPwd = dr("ExPwd15") & "" Then
                    msg += " This password was used previously and has not met the recycling criteria, please use another password." + vbCrLf

                    result = True
                End If
            End If
        Catch ex As Exception

        End Try
        Return result
    End Function
#End Region

    Public Shared Function GetID(ByVal sIdFieldName As String, ByVal sTableName As String) As Object
        Dim sReturn As Object
        Try
            Dim ds As New DataSet
            Dim sSql As String = " SELECT Max(" & sIdFieldName & ") FROM " & sTableName
            sReturn = Var.DBAMain.ExecuteScalar(sSql)
            Dim bReturn As Boolean = True
            If Core.IsDBNullOrStringEmpty(sReturn) = False Then
                sReturn = sReturn + 1
            Else
                sReturn = 1
            End If
            'While bReturn
            '    sSql = "SELECT * FROM " & sTableName & " WHERE " & sIdFieldName & " = " & sReturn
            '    Var.DBAMain.FillDataset(sSql, ds, "GetID")
            '    If ds.Tables("GetID").Rows.Count > 0 Then
            '        sReturn = sReturn + 1
            '    Else
            '        bReturn = False
            '    End If
            'End While
           

            

        Catch ex As Exception

        End Try
        Return sReturn
    End Function

    Public Shared Function ReadFile(ByVal sPath As String) As String
        Dim sTemp As String
        Try
            If File.Exists(sPath) = False Then Return ""

            sTemp = My.Computer.FileSystem.ReadAllText(sPath, Encoding.UTF8)

            Return sTemp
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return ""
        End Try
    End Function

    Public Shared Function GetAssemblyType(ByRef objAssembly As System.Reflection.Assembly, ByVal sClassName As String, ByRef objType As Type) As Boolean
        If objAssembly Is Nothing Then
            Return False
        End If
        Try

            objType = objAssembly.GetType(sClassName)
            If objType Is Nothing Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function GetAssemblyInstance(ByRef objAssembly As System.Reflection.Assembly, ByVal sClassName As String, ByRef objInstance As Object) As Boolean
        If objAssembly Is Nothing Then
            Return False
        End If
        Try

            objInstance = objAssembly.CreateInstance(sClassName)
            If objInstance Is Nothing Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Shared Function GetCodePropery(ByRef objType As Type, ByRef objInstance As Object, ByVal sPropertyName As String, ByRef sPropertyValue As Object) As Boolean
        Dim rslt As Object

        Try
            If objType Is Nothing OrElse objInstance Is Nothing Then
                Return False
            End If


            rslt = objType.InvokeMember(sPropertyName, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.GetProperty Or _
                System.Reflection.BindingFlags.Instance, _
                Nothing, objInstance, Nothing)


            If Not rslt Is Nothing Then
                sPropertyValue = rslt
            End If
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Shared Function CallAssemblyMethod(ByRef objType As Type, ByVal sMethodName As String, ByRef args() As Object, ByRef ReturnValue As Object) As Boolean
        Dim rslt As Object

        Try
            If objType Is Nothing Then
                Return False
            End If

            rslt = objType.InvokeMember(sMethodName, _
               System.Reflection.BindingFlags.InvokeMethod Or _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.Static, _
                Nothing, Nothing, args)

            If Not rslt Is Nothing Then
                ReturnValue = rslt
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Shared Function CallAssemblyMethod(ByRef objType As Type, ByRef objInstance As Object, ByVal sMethodName As String, ByRef args() As Object, ByRef ReturnValue As Object) As Boolean
        Dim rslt As Object

        Try
            If objType Is Nothing Then
                Return False
            End If

            rslt = objType.InvokeMember(sMethodName, _
                System.Reflection.BindingFlags.Public Or _
                System.Reflection.BindingFlags.InvokeMethod Or _
                System.Reflection.BindingFlags.Instance, _
                Nothing, objInstance, args)

            If Not rslt Is Nothing Then
                ReturnValue = rslt
            End If

            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return False
        End Try
    End Function

    Public Shared Sub CompareDatatable(ByRef dt1 As DataTable, ByRef dt2 As DataTable, ByVal sIDColumn As String, ByVal sNameColumn As String, ByRef sNew As String, ByRef sDel As String)
        Dim sFilter As String
        Dim rows() As DataRow
        Dim dr As DataRow

        Try
            For Each dr In dt1.Rows
                If dr.RowState <> DataRowState.Deleted Then
                    sFilter = sIDColumn & " = " & SQLStr(dr(sIDColumn))
                    rows = dt2.Select(sFilter)
                    If rows Is Nothing OrElse rows.Length = 0 Then
                        If sDel <> "" Then sDel &= ","
                        sDel &= dr(sNameColumn)
                    End If
                End If

            Next

            For Each dr In dt2.Rows
                If dr.RowState <> DataRowState.Deleted Then
                    sFilter = sIDColumn & " = " & SQLStr(dr(sIDColumn))
                    rows = dt1.Select(sFilter)
                    If rows Is Nothing OrElse rows.Length = 0 Then
                        If sNew <> "" Then sNew &= ","
                        sNew &= dr(sNameColumn)
                    End If
                End If

            Next

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
        End Try
    End Sub

    Public Shared Function GetIPAddress() As String
        Try
            'Dim strHostName As String
            'Dim strIPAddress As String
            'strHostName = System.Net.Dns.GetHostName()
            'strIPAddress = System.Net.Dns.GetHostEntry(strHostName).AddressList(0).ToString

            'return strIPAddress

            Dim IPv4Address = String.Empty
            Dim strHostName As String = System.Net.Dns.GetHostName()
            Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

            For Each ipheal As System.Net.IPAddress In iphe.AddressList
                If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    IPv4Address = ipheal.ToString()
                End If
            Next

            Return IPv4Address

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
            Return ""
        End Try

    End Function

    Public Shared Sub DisplayToPole(ByVal FirstLine As String, ByVal SecondLine As String, ByVal sPort As String)
        Try
            If Not String.IsNullOrEmpty(sPort) Then
                Dim sp As New SerialPort()

                sp.PortName = sPort
                sp.BaudRate = 9600
                sp.Parity = Parity.None
                sp.DataBits = 8
                sp.StopBits = StopBits.One
                sp.Open()

                Dim bytesToSend As Byte() = New Byte(0) {&HC}
                sp.Write(bytesToSend, 0, 1)
                sp.WriteLine(FirstLine.Trim & Chr(13))
                sp.WriteLine(SecondLine.Trim())


                sp.Close()
                sp.Dispose()
                sp = Nothing
            End If
        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
        End Try

    End Sub

    Public Shared Function IsDBNullOrStringEmpty(ByVal sObj As Object) As Boolean
        Dim bFlag As Boolean = True
        Try
            If Not IsNothing(sObj) Then
                If Not IsDBNull(sObj) Then
                    If TypeOf sObj Is String Then
                        If Not String.IsNullOrEmpty(sObj) Then
                            bFlag = False
                        End If
                    Else
                        bFlag = False
                    End If
                End If
            End If

        Catch ex As Exception
            'Log.LogError(Name, Core.WhoCalledMe, ex.Message)
        End Try
        Return bFlag
    End Function

    Public Shared Sub InitAppSettingForDBA()
        Try
            Var.sDBServer = System.Configuration.ConfigurationManager.AppSettings("DBServer")
            Var.sDatabase = System.Configuration.ConfigurationManager.AppSettings("Database")
            Var.sDBDNS = System.Configuration.ConfigurationManager.AppSettings("DBDNS")
            Var.sDBUser = System.Configuration.ConfigurationManager.AppSettings("DBUser")
            Var.sPassword = System.Configuration.ConfigurationManager.AppSettings("DBPassword")

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function LoadEmpInfo(ByVal sID As String) As String
        Dim sReturn As String = ""
        Try
            Dim sSql As String = String.Format("SELECT Pass FROM Emp WHERE LoginID = {0}", Core.SQLStr(sID))
            sReturn = Var.DBAMain.ExecuteScalar(sSql)
        Catch ex As Exception
            Log.LogError("Core", "LoadItemInfo", ex.Message)
        End Try
        Return sReturn
    End Function
End Class
