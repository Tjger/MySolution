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

    Public Structure AuditLogInfo

        Public sModule As Var.SystemModule
        Public LogType As eLogType
        Public sGuestID As String
        Public sMembershipID As String
        Public sRevID As String
        Public sDescription As String
        Public sTerminationCode As String
        Public sTerminationCodeName As String
        Public sRemarks As String
        Public sSysNotes As String
        Public sCreditCardID As String
        Public sCommentID As String
        Public sAttachmentID As String
        Public sArchivedLinkID As String
        Public sClientLinkID As String
        Public sAddressID As String
        Public sRecurringID As String
        Public sSchedulerID As String
        Public sTransID As String
        Public sStatementNo As String
        Public sReceiptNo As String
        Public sApptID As String
        Public sGolfApptID As String
        Public sPayGuestID As String
        Public sPayMembershipID As String
        Public sGUINo As String
        Public sWsID As String
        Public sIPAddress As String

    End Structure

    Public Enum eLogType

        New_Profile = 8001
        Update_Profile = 8002

        Upload_Photo = 8003
        Clear_Photo = 8004

        New_Attachment = 8005
        Update_Attachment = 8006
        Remove_Attachment = 8007
        Export_Attachment = 8008

        New_Client_Link = 8009
        Update_Client_Link = 8010
        Remove_Client_Link = 8011

        New_Comment = 8012
        Update_Comment = 8013
        Remove_Comment = 8014

        New_Archived_Profile = 8015
        Update_Archived_Profile = 8016
        Remove_Archived_Profile = 8017

        New_Credit_Card = 8018
        Update_Credit_Card = 8019
        Remove_Credit_Card = 8020

        New_Address = 8021
        Update_Address = 8022
        Remove_Address = 8023

        Update_Receipt_Template = 8024
        Update_PreReceipt_Template = 8025

        Upload_Signature = 8026
        Clear_Signature = 8027

        Merge_Profile = 8028

        Enroll_FingerPrint = 8029
        Clear_FingerPrint = 8030

        Subscribe_Membership = 3001
        Update_Membership_Info = 3002

        Change_Membership_No = 3003
        Change_Membership_Type = 3004
        Change_Membership_Status = 3005

        Update_Billing_Method = 3006

        New_Scheduler = 3008
        Update_Scheduler = 3009
        Remove_Scheduler = 3010

        New_Recurring = 3011
        Update_Recurring = 3012
        Remove_Recurring = 3013

        Update_Account_Setting = 3014

        New_Transaction = 3015
        Route_Transaction = 3016
        Redirect_Transaction = 3018
        Void_Transaction = 3019
        Refund_Deposit = 3020
        Update_Transaction = 3021


        New_Statement = 3022
        Update_Statement = 3023

        Print_Current_Account = 3024
        Print_Statement = 3025

        New_Supplementary = 3026
        Promote = 3027

        New_Routing = 3028
        Remove_Routing = 3029

        Cancel_Statement = 3030

        'POS
        Receipt_Activity = 2001
        GUI = 2002



        'Spa Appointment
        Appointment_Activity = 1001
        Employee_Schedule = 1002
        Advance_Schedule = 1003
        User_Block_Appointment = 1004

        'configuration
        Absence_Code = 4001
        Adjustment_Reason = 4002
        Discount_Code = 4003
        Foreign_Currency = 4004
        Interface_Folio = 4005
        Locker_Category = 4006
        Locker = 4007
        Locker_Block_Code = 4008
        Market_Segment = 4009
        Modification_Code = 4010
        Over_Time_Code = 4011
        Negative_Posting_Code = 4012
        Source_Group = 4013
        Source_of_Business = 4014
        Turn_Away_Code = 4015
        Void_Code = 4016

        Activity_Group = 4017
        Activity = 4018
        Activity_Absence = 4019
        Activity_Suspend = 4020
        Activity_On_Hold = 4021

        Cancellation_Code = 4022

        Package_Group = 4023
        Package = 4024

        Room_Category = 4025
        Room = 4026

        Treatment_Group = 4027
        Treatment = 4028

        Membership_Fee_Group = 4029
        Member_Fee = 4030
        Membership_Group = 4031
        Membership_Sub_Group = 4032
        Membership_Type = 4033
        Bank_Account_Type = 4034
        Bank = 4035
        Termination_Code = 4036
        AR_Statement_Status = 4037
        Custom_List = 4038

        Employee_Category = 4039
        Employee = 4040
        Employee_Revenue_Center = 4041
        Password_Authority = 4042

        Shift = 4050
        OT = 4051

        Entrance_Fee_Category = 4052
        Entrance_Fee = 4053
        Location = 4054
        Rental_Category = 4055
        Rental = 4056

        Vendor = 4057
        Brand = 4058
        Stock_Category = 4059
        Stock_Sub_Category = 4060
        Stock_Store = 4061
        Stock = 4062
        Batch = 4063

        Others_Category = 4064
        Others_Sub_Category = 4065
        Others = 4066

        Loyalty_Point = 4067
        Loyalty_Point_Adjustment_Reason = 4068

        Income_Center_Group = 4069

        Payment_Group = 4070
        Till = 4071

        Address_Category = 4072
        Building = 4073

        Comment_Group = 4074
        Comment_Section = 4075
        Comment_Status = 4076

        Guest_Title = 4077
        Guest_Type = 4078
        Guest_Sub_Type = 4079
        Guest_Medical = 4080
        Guest_Interest = 4081
        Guest_Area = 4082
        Relationship = 4083
        State = 4084
        Guest_Preference = 4085

        eSecure = 4090
        Appointment_Tooltip = 4091
        Email_Template = 4092

        Voucher = 4100
        System_Parameter = 4200
        Commission = 4201
        Revenue_Center = 4202
        Site = 4203
        Tax_Profile = 4204
        User_Block = 4205
        View_Section = 4206
        Prepayment = 4207
        Income_Center = 4208
        Payment_Type = 4209
        Work_Station = 4210
        Interface_Property = 4211

        Dining_Room_Cateogry = 4212
        Dining_Room = 4213
        Dining_Table_Category = 4214
        Dining_Table = 4215
        FNB_Shift = 4216
        FNB_Category = 4217
        FNB_Group = 4218
        FNB_SubGroup = 4219
        FNB_Item = 4220

        Micros_Interface_Sales_Mapping = 4221

        FNB_Remove_Reason = 4222
        FNB_Add_Memo = 4223
        FNB_Change = 4224
        FNB_Discount = 4225

        Modifier_Category = 4300
        Modifier = 4301
        Modifier_Relation = 4302

        Pool_Commission = 4303
        HTNG_Property = 4304

        New_Default_Routing = 4305
        Remove_Default_Routing = 4306

        Installment_Group = 4307
        Installment = 4308

        Price_Priority_Setup = 4309
        Price_Level_Setup = 4310
        Price_Setup = 4311
        Seasonal_Price_Setup = 4312
        Holiday_Price_Setup = 4313
        Guest_Type_Price_Setup = 4314
        Discount_Priority_Setup = 4315
        Guest_Type_Discount_Priority_Setup = 4316
        Source_Of_Reservation_Discount_Setup = 4317
        Market_Segment_Discount_Setup = 4318
        Time_Discount_Setup = 4319

        Remove_Activity_Booking = 4320

        ' F&B range from 19000 to 19999

        Login = 1

        ' e-Activity Module
        Enrollment = 4321
        e_Activity_Skill_Level = 4322
        e_Activity_Schedule = 4323
        e_Activity_Assessment_History = 4324
        e_Activity_Guest_Course_Appt = 4325
        e_Activity_Question_History = 4326
        e_Activity_Billing = 4327
        e_Activity_Billing_Information = 4328
        e_Activity_Guest_School = 4329
        e_Activity_Batch_Processing_Transaction = 4330
        e_Activity_Assessment = 4331
        e_Activity_Question = 4332
        e_Activity_Answer = 4333

        ' Facility Reservation
        Facility_Reservation = 4334
        ' Health Care Module
        HealthCareModule = 4335
        'Caddy
        Caddy_Block = 4336
        New_Caddy_Appoinment = 4337
        Edit_Caddy_Appoinment = 4338
        Delete_Caddy_Appoinment = 4339
        Change_Caddy = 4340
        Cancel_Caddy_Booking = 4341

        '
        GolfDelete = 4342
        GolfAdd = 4343

        'Price Change Scheduler
        Delete_Price_Change_SchedulerNew = 4344
        Add_New_Price_Change_SchedulerNew = 4345
        Edit_Price_Change_SchedulerNew = 4346

        'Fitness
        Add_New_Fitness = 4347
        Edit_Fitness = 4348
        Delete_Fitness = 4349

        'eNgage
        Add_New_Message = 4350

        'Entitlements
        EntitlementsAdd = 4351
        EntitlementsUpdate = 4352
        EntitlementsDelete = 4353
        'Unit
        UnitAdd = 4354
        UnitUpdate = 4355
        UnitDelete = 4356
        'Unit Related
        UnitRelatedAdd = 4357
        UnitRelatedDelete = 4358
        Add_log = 4359
        Del_Log = 4360
    End Enum

    Public Shared sAppPath As String
    Public Shared sModuleName As String
    Public Shared Name As String = "Log"

    Public Shared Sub AuditLog(ByRef AuditLogInfo As AuditLogInfo, Optional ByVal nDetailLevel As Integer = 1)
        Dim sSQL As String

        Try

            With AuditLogInfo
                sSQL = "DECLARE @Now as DATETIME" & vbCrLf
                sSQL &= "SELECT @Now = GETDATE() " & vbCrLf

                sSQL &= "INSERT INTO AuditLog("
                sSQL &= "Module,LogType,RevID,GuestID,MembershipID,LogDate,LogBy,Description,Remarks,SysNotes,TerminationCode,TerminationCodeName,CreditCardID,CommentID,ArchivedLinkID,AttachmentID,ClientLinkID,AddressID,RecurringID,SchedulerID,TransID,StatementNo,ReceiptNo,ApptID,GolfApptID,PayGuestID,PayMembershipID,DetailLevel,WsID,IPAddress"
                sSQL &= ") VALUES("
                sSQL &= Core.SQLStr(CInt(.sModule)) & ","
                sSQL &= Core.SQLStr(CInt(.LogType)) & ","
                sSQL &= Core.SQLStr(.sRevID) & ","
                sSQL &= Core.SQLStr(.sGuestID) & ","
                sSQL &= Core.SQLStr(.sMembershipID) & ","
                sSQL &= "@Now," 'Common.Core.SQLStr(Now.ToString(Var.sSQLDateTimeFmt)) & ","
                sSQL &= Core.SQLStr(Var.sCurrentEmpID) & ","
                sSQL &= Core.SQLStr(.sDescription) & ","
                sSQL &= Core.SQLStr(.sRemarks) & ","
                sSQL &= Core.SQLStr(.sSysNotes) & ","
                sSQL &= Core.SQLStr(.sTerminationCode) & ","
                sSQL &= Core.SQLStr(.sTerminationCodeName) & ","
                sSQL &= Core.SQLStr(.sCreditCardID) & ","
                sSQL &= Core.SQLStr(.sCommentID) & ","
                sSQL &= Core.SQLStr(.sArchivedLinkID) & ","
                sSQL &= Core.SQLStr(.sAttachmentID) & ","
                sSQL &= Core.SQLStr(.sClientLinkID) & ","
                sSQL &= Core.SQLStr(.sAddressID) & ","
                sSQL &= Core.SQLStr(.sRecurringID) & ","
                sSQL &= Core.SQLStr(.sSchedulerID) & ","
                sSQL &= Core.SQLStr(.sTransID) & ","
                sSQL &= Core.SQLStr(.sStatementNo) & ","
                sSQL &= Core.SQLStr(.sReceiptNo) & ","
                sSQL &= Core.SQLStr(.sApptID) & ","
                sSQL &= Core.SQLStr(.sGolfApptID) & ","
                sSQL &= Core.SQLStr(.sPayGuestID) & ","
                sSQL &= Core.SQLStr(.sPayMembershipID) & ","
                sSQL &= (nDetailLevel) & ","
                sSQL &= Core.SQLStr(.sWsID) & ","
                sSQL &= Core.SQLStr(.sIPAddress)
                sSQL &= ")"
            End With


            Var.DBAMain.Execute(sSQL)

        Catch ex As Exception
            LogError(Name, Core.WhoCalledMe, ex.Message)
        Finally
            Var.DBAMain.Disconnect()
        End Try

    End Sub

    Public Shared Sub ArchivedAuditLog()
        Try
            If Var.bArchivedAuditLog Then
                Dim dtEnd As Date = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day)
                Dim dtStart As Date = dtEnd.AddDays(-Var.iArchivedPeriod)

                Dim sSQL As String = "INSERT INTO ArchivedAuditLog SELECT [RevID] ,[LogDate] ,[LogBy] ,[TerminationCode] ,[Module] ,[LogType] ,[GuestID] ,[MembershipID] ,[TerminationCodeName] "
                sSQL &= ",[AttachmentID] ,[ClientLinkID] ,[CommentID] ,[ArchivedLinkID] ,[CreditCardID] ,[AddressID] ,[RecurringID] ,[SchedulerID] ,[TransID] ,[StatementNo] ,[Description] "
                sSQL &= String.Format(",[Remarks] ,[SysNotes] ,[ReceiptNo] ,[PayGuestID] ,[PayMembershipID] ,[ApptID] ,[GolfApptID] ,[DetailLevel] ,[WsID] ,[IPAddress] FROM AuditLog WHERE LogDate BETWEEN '{0}' AND '{1}'", Core.SQLDate(dtStart), Core.SQLDate(dtEnd))
                Dim iRet As Integer = 0
                Var.DBAMain.Execute(sSQL, iRet)
                If iRet > 0 Then
                    iRet = 0
                    sSQL = String.Format("DELETE FROM AuditLog WHERE LogDate BETWEEN '{0}' AND '{1}'", Core.SQLDate(dtStart), Core.SQLDate(dtEnd))
                    Var.DBAMain.Execute(sSQL, iRet)
                    sSQL = String.Format("SELECT * FROM ArchivedAuditLog WHERE LogDate BETWEEN '{0}' AND '{1}'", Core.SQLDate(dtStart), Core.SQLDate(dtEnd))
                    Dim ds As New DataSet
                    Var.DBAMain.FillDataset(sSQL, ds)
                    Dim sDes As String = ""
                    For Each row As DataRow In ds.Tables(0).Rows
                        sDes = "Archived Audit Log"
                        sDes &= "RevID [" & row("RevID") & "]" & vbCrLf
                        sDes &= "LogDate [" & row("LogDate") & "]" & vbCrLf
                        sDes &= "LogBy [" & Var.sCurrentEmpID & "]" & vbCrLf
                        sDes &= "TerminationCode [" & row("TerminationCode") & "]" & vbCrLf
                        sDes &= "Module [" & row("Module") & "]" & vbCrLf
                        sDes &= "LogType [" & row("LogType") & "]" & vbCrLf
                        sDes &= "GuestID [" & row("GuestID") & "]" & vbCrLf
                        sDes &= "MembershipID [" & row("MembershipID") & "]" & vbCrLf
                        sDes &= "TerminationCodeName [" & row("TerminationCodeName") & "]" & vbCrLf
                        sDes &= "AttachmentID [" & row("AttachmentID") & "]" & vbCrLf
                        sDes &= "ClientLinkID [" & row("ClientLinkID") & "]" & vbCrLf
                        sDes &= "CommentID [" & row("CommentID") & "]" & vbCrLf
                        sDes &= "ArchivedLinkID [" & row("ArchivedLinkID") & "]" & vbCrLf
                        sDes &= "CreditCardID [" & row("CreditCardID") & "]" & vbCrLf
                        sDes &= "AddressID [" & row("AddressID") & "]" & vbCrLf
                        sDes &= "RecurringID [" & row("RecurringID") & "]" & vbCrLf
                        sDes &= "SchedulerID [" & row("SchedulerID") & "]" & vbCrLf
                        sDes &= "TransID [" & row("TransID") & "]" & vbCrLf
                        sDes &= "StatementNo [" & row("StatementNo") & "]" & vbCrLf
                        sDes &= "Description [" & row("Description") & "]" & vbCrLf
                        sDes &= "Remarks [" & row("Remarks") & "]" & vbCrLf
                        sDes &= "SysNotes [" & row("SysNotes") & "]" & vbCrLf
                        sDes &= "ReceiptNo [" & row("ReceiptNo") & "]" & vbCrLf
                        sDes &= "PayGuestID [" & row("PayGuestID") & "]" & vbCrLf
                        sDes &= "PayMembershipID [" & row("PayMembershipID") & "]" & vbCrLf
                        sDes &= "ApptID [" & row("ApptID") & "]" & vbCrLf
                        sDes &= "GolfApptID [" & row("GolfApptID") & "]" & vbCrLf
                        sDes &= "DetailLevel [" & row("DetailLevel") & "]" & vbCrLf
                        sDes &= "WsID [" & row("WsID") & "]" & vbCrLf
                        sDes &= "IPAddress [" & row("IPAddress") & "]" & vbCrLf
                        sDes &= String.Format("From Date [{0}] To Date [{1}]", Core.SQLDate(dtStart), Core.SQLDate(dtEnd)) & vbCrLf
                        If sDes <> "" Then Log(Var.SystemModule.POS, eLogType.Add_log, Var.sRevID, sDes)

                        sDes = ("Delete Audit Log")
                        sDes &= "RevID [" & row("RevID") & "]" & vbCrLf
                        sDes &= "LogDate [" & row("LogDate") & "]" & vbCrLf
                        sDes &= "LogBy [" & Var.sCurrentEmpID & "]" & vbCrLf
                        sDes &= "TerminationCode [" & row("TerminationCode") & "]" & vbCrLf
                        sDes &= "Module [" & row("Module") & "]" & vbCrLf
                        sDes &= "LogType [" & row("LogType") & "]" & vbCrLf
                        sDes &= "GuestID [" & row("GuestID") & "]" & vbCrLf
                        sDes &= "MembershipID [" & row("MembershipID") & "]" & vbCrLf
                        sDes &= "TerminationCodeName [" & row("TerminationCodeName") & "]" & vbCrLf
                        sDes &= "AttachmentID [" & row("AttachmentID") & "]" & vbCrLf
                        sDes &= "ClientLinkID [" & row("ClientLinkID") & "]" & vbCrLf
                        sDes &= "CommentID [" & row("CommentID") & "]" & vbCrLf
                        sDes &= "ArchivedLinkID [" & row("ArchivedLinkID") & "]" & vbCrLf
                        sDes &= "CreditCardID [" & row("CreditCardID") & "]" & vbCrLf
                        sDes &= "AddressID [" & row("AddressID") & "]" & vbCrLf
                        sDes &= "RecurringID [" & row("RecurringID") & "]" & vbCrLf
                        sDes &= "SchedulerID [" & row("SchedulerID") & "]" & vbCrLf
                        sDes &= "TransID [" & row("TransID") & "]" & vbCrLf
                        sDes &= "StatementNo [" & row("StatementNo") & "]" & vbCrLf
                        sDes &= "Description [" & row("Description") & "]" & vbCrLf
                        sDes &= "Remarks [" & row("Remarks") & "]" & vbCrLf
                        sDes &= "SysNotes [" & row("SysNotes") & "]" & vbCrLf
                        sDes &= "ReceiptNo [" & row("ReceiptNo") & "]" & vbCrLf
                        sDes &= "PayGuestID [" & row("PayGuestID") & "]" & vbCrLf
                        sDes &= "PayMembershipID [" & row("PayMembershipID") & "]" & vbCrLf
                        sDes &= "ApptID [" & row("ApptID") & "]" & vbCrLf
                        sDes &= "GolfApptID [" & row("GolfApptID") & "]" & vbCrLf
                        sDes &= "DetailLevel [" & row("DetailLevel") & "]" & vbCrLf
                        sDes &= "WsID [" & row("WsID") & "]" & vbCrLf
                        sDes &= "IPAddress [" & row("IPAddress") & "]" & vbCrLf
                        sDes &= String.Format("From Date [{0}] To Date [{1}]", Core.SQLDate(dtStart), Core.SQLDate(dtEnd)) & vbCrLf
                        If sDes <> "" Then Log(Var.SystemModule.POS, eLogType.Del_Log, Var.sRevID, sDes)
                        sDes = ""
                    Next
                End If
            End If

        Catch ex As Exception
            LogError(Name, Core.WhoCalledMe, ex.Message)
        Finally
            Var.DBAMain.Disconnect()
        End Try
    End Sub

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

    Public Shared Sub Log(ByVal MyModule As Var.SystemModule, ByVal LogType As eLogType, ByVal RevID As String, ByVal ModifyNotes As String, Optional ByVal apptid As String = "")
        Try

            Dim ALog As New Log.AuditLogInfo
            ALog.sModule = MyModule
            ALog.LogType = LogType
            ALog.sGuestID = ""
            ALog.sMembershipID = ""
            ALog.sPayGuestID = ""
            ALog.sPayMembershipID = ""
            ALog.sReceiptNo = ""
            ALog.sGolfApptID = ""
            ALog.sApptID = apptid
            ALog.sRevID = RevID
            ALog.sDescription = ModifyNotes
            ALog.sWsID = Var.sWorkstationID
            ALog.sIPAddress = Core.GetIPAddress
            AuditLog(ALog)

        Catch ex As Exception
            LogError(Name, Core.WhoCalledMe, ex.Message)
        Finally
            'db.Dispose()
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
