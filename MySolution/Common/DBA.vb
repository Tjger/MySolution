
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data.Odbc
'Imports Janus.Windows.EditControls

Public Class DBA

#Region "Enum"

    Public Enum eConnectionType
        MSSQL = 1
        MSAccess = 2
        OLEDB = 3
        ODBC = 4
    End Enum

#End Region
    Private Name = "DBA"
    Private oConnectionType As eConnectionType = eConnectionType.MSSQL
    Private sConnectionString As String = ""
    Private sServer As String = ""
    Private sDatabase As String = ""
    Private sUser As String = ""
    Private sPwd As String = ""
    Private sDSN As String = ""

    Private con As IDbConnection = Nothing
    Private sSQLDateFlag As String = "'"

    Private sErrMsg As String = ""
    Private bAlwaysOpen As Boolean = False

#Region "Property"

    Public Property ConnectionType() As eConnectionType
        Get
            Return oConnectionType
        End Get
        Set(ByVal value As eConnectionType)
            oConnectionType = value
            SetSQLDateFlag()
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return sConnectionString
        End Get
        Set(ByVal value As String)
            sConnectionString = value
        End Set
    End Property

    Public Property Server() As String
        Get
            Return sServer
        End Get
        Set(ByVal value As String)
            sServer = value
        End Set
    End Property

    Public Property Database() As String
        Get
            Return sDatabase
        End Get
        Set(ByVal value As String)
            sDatabase = value
        End Set
    End Property

    Public Property User() As String
        Get
            Return sUser
        End Get
        Set(ByVal value As String)
            sUser = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return sPwd
        End Get
        Set(ByVal value As String)
            sPwd = value
        End Set
    End Property

    Public Property DSN() As String
        Get
            Return sDSN
        End Get
        Set(ByVal value As String)
            sDSN = value
        End Set
    End Property

    Public Property SQLDateFlag() As String
        Get
            Return sSQLDateFlag
        End Get
        Set(ByVal value As String)
            sSQLDateFlag = value
        End Set
    End Property

    Public Property AlwaysOpen() As Boolean
        Get
            Return bAlwaysOpen
        End Get
        Set(ByVal value As Boolean)
            bAlwaysOpen = value
        End Set
    End Property

    Public Property Connection() As IDbConnection
        Get
            Return con
        End Get
        Set(ByVal value As IDbConnection)
            con = value
        End Set
    End Property

    Public ReadOnly Property State() As ConnectionState
        Get
            If con Is Nothing Then
                Return ConnectionState.Closed
            Else
                Return con.State
            End If
        End Get
    End Property

    Public ReadOnly Property ErrMsg() As String
        Get
            Return sErrMsg
        End Get
    End Property
#End Region

#Region "Constructor"

    Public Sub New(Optional ByVal bConnect As Boolean = True)
        Try
            Me.ConnectionType = Var.oConType
            Select Case oConnectionType
                Case eConnectionType.MSSQL

                    Me.sServer = Var.sDBServer
                    Me.sDatabase = Var.sDatabase
                    Me.sUser = Var.sDBUser
                    Me.sPwd = Var.sPassword

                Case eConnectionType.ODBC, eConnectionType.OLEDB
                    Me.sDSN = Var.sDBDNS
            End Select

            If bConnect Then
                Connect()
            End If

        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
        End Try

    End Sub

#End Region

#Region "Private Method"

#Region "Database Independent Method"

    Public Function GetConnection() As IDbConnection
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                Return New SqlConnection
            Case eConnectionType.OLEDB, eConnectionType.MSAccess
                Return New OleDbConnection
            Case eConnectionType.ODBC
                Return New OdbcConnection
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GetCommand() As IDbCommand
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                Return New SqlCommand
            Case eConnectionType.OLEDB, eConnectionType.MSAccess
                Return New OleDbCommand
            Case eConnectionType.ODBC
                Return New OdbcCommand
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GetDataAdapter() As IDbDataAdapter
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                Return New SqlDataAdapter
            Case eConnectionType.OLEDB, eConnectionType.MSAccess
                Return New OleDbDataAdapter
            Case eConnectionType.ODBC
                Return New OdbcDataAdapter
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GetParameter() As IDbDataParameter
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                Return New SqlParameter
            Case eConnectionType.OLEDB, eConnectionType.MSAccess
                Return New OleDbParameter
            Case eConnectionType.ODBC
                Return New OdbcParameter
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GetCommandBuilder() As Object
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                Return New SqlCommandBuilder
            Case eConnectionType.OLEDB, eConnectionType.MSAccess
                Return New OleDbCommandBuilder
            Case eConnectionType.ODBC
                Return New OdbcCommandBuilder
            Case Else
                Return Nothing
        End Select
    End Function

#End Region

    Private Sub SetSQLDateFlag()
        Select Case oConnectionType
            Case eConnectionType.MSSQL, eConnectionType.ODBC, eConnectionType.OLEDB
                sSQLDateFlag = "'"
            Case eConnectionType.MSAccess
                sSQLDateFlag = "#"
        End Select
    End Sub

    Private Sub BuildConnectionString()
        Select Case oConnectionType
            Case eConnectionType.MSSQL
                If Var.WinAuth Then
                    sConnectionString = "Data Source=" & sServer & ";Initial Catalog=" & sDatabase & ";Integrated Security=True" & ";MultipleActiveResultSets=True;Packet Size = 4096;"
                Else
                    sConnectionString = "server=" & sServer & ";user=" & sUser & ";pwd=" & sPwd & ";initial catalog=" & sDatabase & ";MultipleActiveResultSets=True;Packet Size = 4096;"
                    'sConnectionString = "server=" & sServer & ";user=" & sUser & ";pwd=" & sPwd & ";initial catalog=" & sDatabase & ";MultipleActiveResultSets=True;"
                End If
            Case eConnectionType.ODBC
                sConnectionString = "Dsn=" & sDSN
            Case eConnectionType.OLEDB
                sConnectionString = "Data Source=" & sDSN
        End Select
    End Sub

    Private Sub AttachParameters(ByVal cmd As IDbCommand, ByVal param() As IDbDataParameter)
        If (cmd Is Nothing) Then Throw New ArgumentNullException("cmd")
        If (Not param Is Nothing) Then
            Dim p As SqlParameter
            For Each p In param
                If (Not p Is Nothing) Then
                    ' Check for derived output value with no value assigned
                    If (p.Direction = ParameterDirection.InputOutput OrElse p.Direction = ParameterDirection.Input) AndAlso p.Value Is Nothing Then
                        p.Value = DBNull.Value
                    End If
                    cmd.Parameters.Add(p)
                End If
            Next p
        End If
    End Sub

#End Region

#Region "Public Method"

    Public Function Connect() As Boolean
        Try

            If sConnectionString.Length = 0 Then
                BuildConnectionString()
            End If

            If con Is Nothing Then
                con = GetConnection()
            End If

            If con.State = ConnectionState.Open Then
                Return True
            Else
                con.ConnectionString = sConnectionString
                con.Open()
                Return True
            End If
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Sub Disconnect()
        Try
            If con Is Nothing Then
                Exit Sub
            End If

            If con.State <> ConnectionState.Closed Then
                con.Close()
            End If
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
        End Try

    End Sub

    Public Sub Dispose()
        Disconnect()
        If con Is Nothing = False Then
            con.Dispose()
        End If
        con = Nothing
    End Sub

    Public Function Execute(ByVal sSQL As String, Optional ByRef nRecordAffected As Integer = -1, Optional ByVal bClose As Boolean = False, Optional ByRef Trans As IDbTransaction = Nothing, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing, Optional ByVal bLogError As Boolean = True, Optional ByVal nTimeOut As Integer = 180) As Boolean

        Dim cmdRun As IDbCommand
        Try
            If Connect() = False Then Return False
            cmdRun = GetCommand()
            cmdRun.Transaction = Trans
            cmdRun.Connection = con
            cmdRun.CommandText = sSQL
            cmdRun.CommandType = cmdType

            If nTimeOut <> -1 Then
                cmdRun.CommandTimeout = nTimeOut
            End If

            If Not (param Is Nothing) Then
                AttachParameters(cmdRun, param)
            End If

            nRecordAffected = cmdRun.ExecuteNonQuery
            cmdRun.Parameters.Clear()

            Return True
        Catch ex As Exception
            If bLogError = True Then
                'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            End If
            Return False
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
    End Function

    Public Function GetDatatable(ByVal sSQL As String, Optional ByVal sTableName As String = "", Optional ByVal bClose As Boolean = True, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing) As DataTable
        Dim ds As New DataSet
        If FillDataset(sSQL, ds, sTableName, bClose, cmdType, param) Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    

    Public Function FillDataset(ByVal sSQL As String, ByRef ds As DataSet, Optional ByVal sTableName As String = "", Optional ByVal bClose As Boolean = True, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing) As Boolean
        Dim da As IDbDataAdapter
        Dim cmd As IDbCommand
        Dim dt As DataTable
        Dim nIndex As Integer = -1
        Dim i As Integer
        Dim sDefaultTableName As String = "Table"
        Dim sCompareTableName As String
        Dim nAffected As Integer
        Dim bFlag As Boolean = False
        Try
            sErrMsg = ""

            If Connect() = False Then Return False

            If ds Is Nothing Then
                ds = New DataSet
            End If

            If ds.Tables.Count = 0 Then
                nIndex = 0
            End If


            If ds.Tables.Count > 0 Then
                If sTableName = "" Then
                    sCompareTableName = sDefaultTableName
                Else
                    sCompareTableName = sTableName
                End If

                i = 0
                For Each dt In ds.Tables
                    If dt.TableName = sCompareTableName Then
                        nIndex = i

                        'ds.Tables(nIndex).Clear()
                        dt.Clear()
                        dt.TableName = sDefaultTableName

                        Exit For
                    End If
                    i += 1
                Next
                If nIndex = -1 Then
                    nIndex = ds.Tables.Count
                End If
            End If

            cmd = GetCommand()
            cmd.Connection = Connection
            cmd.CommandText = sSQL

            'Stored Proc
            cmd.CommandType = cmdType
            If Not (param Is Nothing) Then
                AttachParameters(cmd, param)
            End If

            da = GetDataAdapter()
            da.SelectCommand = cmd
            da.SelectCommand.CommandTimeout = 300
            nAffected = da.Fill(ds)
            cmd.Parameters.Clear()

            If sTableName <> "" Then
                If ds.Tables.Count < nIndex Then Exit Try
                ds.Tables(nIndex).TableName = sTableName
            End If

            'If nAffected = 0 Then
            '    Return False
            'Else
            bFlag = True
            'End If

        Catch ex As Exception
            'MsgBox(sSQL)
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message & " SQL=[" & sSQL & "]")
            sErrMsg = ex.Message
            bFlag = False
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
        Return bFlag
    End Function

    Public Function QueryRow(ByVal sSQL As String, Optional ByVal bClose As Boolean = True, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing) As DataRow
        Try

            Dim ds As New DataSet
            FillDataset(sSQL, ds, "", True, cmdType, param)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message & " SQL=[" & sSQL & "]")
            Return Nothing
        End Try
    End Function

    Public Function FillForUpdate(ByVal sSQL As String, ByRef ds As DataSet, ByVal sTableName As String, ByRef da As IDbDataAdapter, Optional ByVal bClose As Boolean = True, Optional ByRef Trans As IDbTransaction = Nothing, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing)
        Dim cb As Object
        Dim cmd As IDbCommand
        Dim dt As DataTable
        Dim nIndex As Integer = -1
        Dim i As Integer
        Dim sDefaultTableName As String = "Table"
        Dim sCompareTableName As String
        Dim nAffected As Integer
        Try

            sErrMsg = ""

            If Connect() = False Then Return False


            If ds Is Nothing Then
                ds = New DataSet
            End If

            If ds.Tables.Count = 0 Then
                nIndex = 0
            End If


            If ds.Tables.Count > 0 Then
                If sTableName = "" Then
                    sCompareTableName = sDefaultTableName
                Else
                    sCompareTableName = sTableName
                End If

                i = 0
                For Each dt In ds.Tables
                    If dt.TableName = sCompareTableName Then
                        nIndex = i

                        'ds.Tables(nIndex).Clear()
                        dt.Clear()
                        dt.TableName = sDefaultTableName

                        Exit For
                    End If
                    i += 1
                Next
                If nIndex = -1 Then
                    nIndex = ds.Tables.Count
                End If
            End If

            cmd = GetCommand()
            cmd.Connection = Connection
            cmd.CommandText = sSQL
            cmd.Transaction = Trans

            'Stored Proc
            cmd.CommandType = cmdType
            If Not (param Is Nothing) Then
                AttachParameters(cmd, param)
            End If

            da = GetDataAdapter()
            da.SelectCommand = cmd


            cb = GetCommandBuilder()
            cb.DataAdapter = da
            da.InsertCommand = cb.GetInsertCommand
            da.InsertCommand.Transaction = Trans
            da.UpdateCommand = cb.GetUpdateCommand
            da.UpdateCommand.Transaction = Trans
            da.DeleteCommand = cb.GetDeleteCommand
            da.DeleteCommand.Transaction = Trans
            nAffected = da.Fill(ds)
            cmd.Parameters.Clear()
            If sTableName <> "" Then
                ds.Tables(nIndex).TableName = sTableName
            End If

            'If nAffected = 0 Then
            '    Return False
            'Else
            Return True
            'End If

        Catch ex As InvalidOperationException
            Return False
        Catch ex As Exception
            'MsgBox(ex.ToString)
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message & " SQL=[" & sSQL & "]")
            sErrMsg = ex.Message
            Return False
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
    End Function

    Public Function Update(ByRef dt As DataTable, ByRef da As IDbDataAdapter, Optional ByVal bClose As Boolean = True) As Boolean
        Dim obj As Object
        Try
            sErrMsg = ""

            If dt Is Nothing Then Return False
            If da Is Nothing Then Return False

            Select Case oConnectionType
                Case eConnectionType.MSSQL
                    obj = CType(da, SqlDataAdapter)
                Case eConnectionType.MSAccess, eConnectionType.OLEDB
                    obj = CType(da, OleDbDataAdapter)
                Case eConnectionType.ODBC
                    obj = CType(da, OdbcDataAdapter)
                Case Else
                    Return False
            End Select

            If State <> ConnectionState.Open Then
                If Connect() = False Then Return False
            End If

            obj.Update(dt)
            'dt.AcceptChanges()

            Return True
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            sErrMsg = ex.Message
            Return False
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
    End Function

    Public Function Update(ByRef dr As DataRow, ByRef da As IDbDataAdapter, Optional ByVal bClose As Boolean = True) As Boolean
        Dim drCol(0) As DataRow
        drCol(0) = dr
        Return Update(drCol, da, bClose)
    End Function

    Public Function Update(ByRef dr() As DataRow, ByRef da As IDbDataAdapter, Optional ByVal bClose As Boolean = True) As Boolean
        Dim obj As Object
        'Dim r As DataRow
        Try
            sErrMsg = ""
            If dr Is Nothing Then Return False
            If da Is Nothing Then Return False

            Select Case oConnectionType
                Case eConnectionType.MSSQL
                    obj = CType(da, SqlDataAdapter)
                Case eConnectionType.MSAccess, eConnectionType.OLEDB
                    obj = CType(da, OleDbDataAdapter)
                Case eConnectionType.ODBC
                    obj = CType(da, OdbcDataAdapter)
                Case Else
                    Return False
            End Select

            If State <> ConnectionState.Open Then
                If Connect() = False Then Return False
            End If

            obj.Update(dr)
            'For Each r In dr
            'If r.RowState <> DataRowState.Detached Then
            'r.AcceptChanges()
            'End If
            'Next

            Return True
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            sErrMsg = ex.Message
            Return False
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
    End Function

    Public Function ExecuteScalar(ByVal sSQL As String, Optional ByVal bClose As Boolean = True, Optional ByRef Trans As IDbTransaction = Nothing, Optional ByVal cmdType As CommandType = CommandType.Text, Optional ByRef param() As IDbDataParameter = Nothing) As Object
        Dim cmdRun As IDbCommand
        Dim ret As Object = Nothing
        Try
            sErrMsg = ""
            If Connect() = False Then Return False
            cmdRun = GetCommand()
            cmdRun.Connection = con
            cmdRun.Transaction = Trans
            cmdRun.CommandText = sSQL
            'Stored Proc
            cmdRun.CommandType = cmdType
            If Not (param Is Nothing) Then
                AttachParameters(cmdRun, param)
            End If
            ret = cmdRun.ExecuteScalar
            cmdRun.Parameters.Clear()

            If ret Is Nothing Then
                Return ""
            ElseIf ret Is DBNull.Value Then
                Return ""
            Else
                Return ret
            End If

        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message & " SQL=[" & sSQL & "]")
            sErrMsg = ex.Message
            Return ""
        Finally
            If bAlwaysOpen = False Then
                If bClose Then Disconnect()
            End If
        End Try
    End Function

    Public Function GetBeginTrans(ByRef Trans As IDbTransaction) As Boolean
        Try
            If Connect() = False Then Return False
            Trans = con.BeginTransaction
            Return True
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            Return False
        End Try
    End Function

    Public Function GetParameter(ByVal spName As String, ByVal DbType As System.Data.SqlDbType, ByVal nSize As Integer, ByVal Direction As System.Data.ParameterDirection, ByVal value As Object) As IDbDataParameter
        Dim p As IDbDataParameter = Nothing
        Try
            Select Case oConnectionType
                Case eConnectionType.MSSQL
                    p = New SqlParameter(spName, DbType, nSize)

                Case eConnectionType.OLEDB, eConnectionType.MSAccess
                    p = New OleDbParameter(spName, DbType, nSize)

                Case eConnectionType.ODBC
                    p = New OdbcParameter(spName, DbType, nSize)

                Case Else
                    Return p
            End Select

            p.Direction = Direction
            If p.Direction = ParameterDirection.Input OrElse p.Direction = ParameterDirection.InputOutput Then
                p.Value = value
            End If
            Return p
        Catch ex As Exception
            'Log.LogError(Me.Name, Core.WhoCalledMe, ex.Message)
            Return p
        End Try
    End Function
#End Region

End Class
