Imports System.Windows.Forms
'Create on 1 Jul 2007
'This class is to store all the common use variable
Public Class Var
    Public Shared sSuperAdminUser As String = "TienTung"
    Public Shared sSuperAdminPass As String = "TungTien"
    Public Shared sSchTimeFmt As Integer = 12
    Public Shared sAppConfigMode As String
    Public Shared sAppConfigMethod As String
    Public Shared sDBServer As String
    Public Shared sDatabase As String
    Public Shared sReportDBServer As String
    Public Shared sReportDatabase As String
    Public Shared sDBUser As String
    Public Shared sPassword As String
    Public Shared sDBDNS As String
    Public Shared oConType As DBA.eConnectionType = DBA.eConnectionType.MSSQL
    Public Shared WinAuth As Boolean
    Public Shared sSQLDateFmt As String = "yyyy-MM-dd"
    Public Shared sSQLDateTimeFmt As String = "yyyy-MM-dd HH:mm:ss"
    Public Shared sDateFmt As String = "MM/dd/yyyy"
    Public Shared sLocalDateFmt As String = "d"
    Public Shared sNameDelimeter As String = ""
    Public Shared sDateFmtTelrik As String = "{0:MM/dd/yyyy}" ' for telerik

    Public Shared bArchivedAuditLog As Boolean = False
    Public Shared iArchivedPeriod As Integer = 30
    Public Shared DBAMain As DBA

    Public Shared dtCurrentEmpLoginTime As Date = Now
    Public Shared bLogFileNoRecycle As Boolean = False
    Public Shared sSecureProfileID As String = ""
    Public Shared sWorkstationID As String = ""
    Public Shared sLicenseTo As String = ""
    Public Shared sRevID As String = ""
    Public Shared sSiteID As String
    Public Shared sCurrentEmpID As String = ""
    Public Shared sCurrentEmpName As String = ""
    'Appointment

    Public Shared eFormatCalendarDatetime As String = "ddd, dd-MMM-yyyy"
    Public Shared eFormatCalendarDatetimeNew As String = "yyyy/MM/dd (ddd)"

    Public Shared FormatDateTime As String = "dd/MM/yyyy HH:mm"
    Public Shared FormatDate As String = "dd/MM/yyyy"

    Public Shared sCreditCardMask As String = "0000-xxxx-xxxx-xxxx"


    'POS variable
    Public Shared sPriceFormat As String = "#0.00"
    Public Shared sPriceFormatTelerik As String = "{0:#0.00}"
    Public Shared nRoundMethod As eRoundMethod = eRoundMethod.RoundNearest
    Public Shared nRoundSmallest As Double = 0.01

    'SMTP SETTING
    Public Shared SMTPEmailAddress As String = "nstung@paradigmsft.com"
    Public Shared SMTPEmailSenderName As String = "Tj"
    Public Shared SMTPEmailPassword As String = "nst2161986"
    Public Shared SMTPHost As String = "smtp.gmail.com"
    Public Shared SMTPPort As Integer = 587
    Public Shared SMTPEnableSSL As Boolean = True

    Public Enum eEmailStatus
        Sent
        Failed
        NotSent
    End Enum

    Public Enum EmailType
        HTML
        Text
    End Enum

    Public Enum FruiltReceiptStatus As Integer
        [News] = 1
        Close =2
        Spam = 3
    End Enum

    Public Enum AmortizingDateType
        Weekly = 1
        Monthly = 2
        Yearly = 3
    End Enum

    Public Enum HTNGCommand
        CREATEACTIVITY
        UPDATEACTIVITY
        CANCELACTIVITY
    End Enum

    Public Enum SystemStatus
        Active = 1
        Deactive = 0
    End Enum

    Public Enum SystemModule
        Module_Base = 0
        Appointment_Engine = 1
        POS = 2
        Membership = 3
        Front_Desk = 4
        Activity_Scheduler = 5
        Report = 6
        Configuration = 7
        CRM = 8
        Locker_Management = 9
        [Interface] = 10
        Package = 11
        Voucher = 12
        Prepayment = 13
        Inventory = 14
        FD_Location = 15
        Payment_Gateway = 16
        Loyalty_Point = 17
        Golf = 18
        FnB = 20
        EasyAccess = 21
        ActionTask = 22
        eActivity = 23
        eRestPOS = 24
        FacilityReservation = 25
        TherapistHandling = 26
        TempPricingModule = 27
        eNgage = 28
        Spa = 29
    End Enum

    Public Enum ObjectType As Integer
        All = 0
        Treatment_Group = 1
        Treatment = 2
        User_Block = 3

        Activity_Group = 4
        Activity = 5


        Employee_Category = 6

        Shift = 7
        Absence = 8

        Stock_Brand = 10
        Stock_Category = 11
        Stock_Sub_Category = 12
        Stock = 13
        StockSub = 14

        Rental_Category = 15
        Rental_Sub_Category = 16
        Rental = 17

        Others_Category = 20
        Others_Sub_Category = 23
        Others = 21
        Package_Group = 30
        Package = 31

        Membership_Fee_Group = 40
        Membership_Fee = 41
        Deposit = 42
        Deposit_Group = 43

        Aging_Interest = 47
        Membership_Payment = 48


        Voucher = 50
        Prepayment = 51

        Entrance_Fee_Group = 60
        Entrance_Fee = 61

        Income_Center = 70

        Golf_Appointment = 80
        Golf_User_Block = 81
        Golf_Course = 82
        Green_Fee = 83
        Green_Fee_Group = 84
        Green_Fee_Sub_Group = 85
        Golf_Cross_Over = 86
        Golf_Caddy_Block = 87
        Golf_Caddy_Emp = 88


        FnB_Category = 100
        FnB_Group = 101
        FnB_SubGroup = 102
        FnB_Item = 103
        FnB_Ticket = 104
        FnB_Modifier = 110

        Tips = 98
        Receipt_Whole = 99

        Micros_Receipt = 200

        eActivity = 202

        Facility = 203
        Spa = 204
        Golf = 205
        Marketing = 206
        FrontDesk = 207
    End Enum

    Public Enum GenderType
        Any = 1
        Male = 2
        Female = 3
        None = 4
    End Enum

    Public Enum OrderType
        ASC = 1
        DESC = 2
    End Enum

    Public Enum eRoundMethod
        RoundNearest = 1
        RoundDown = 2
        RoundUp = 3
    End Enum

    Public Enum WeekDay
        Sunday = 0
        Monday = 1
        Tuesday = 2
        Wednesday = 3
        Thursday = 4
        Friday = 5
        Saturday = 6
    End Enum

End Class
