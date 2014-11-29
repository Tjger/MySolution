Imports System.Windows.Forms
'Create on 1 Jul 2007
'This class is to store all the common use variable
Public Class Var
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
    Public Shared bName1Reverse As Boolean = False
    Public Shared bName2Reverse As Boolean = False
    Public Shared sSQLDateFmt As String = "yyyy-MM-dd"
    Public Shared sSQLDateTimeFmt As String = "yyyy-MM-dd HH:mm:ss"
    Public Shared sDateFmt As String = "MM/dd/yyyy"
    Public Shared sLocalDateFmt As String = "d"
    Public Shared sNameDelimeter As String = ""
    Public Shared sDateFmtTelrik As String = "{0:MM/dd/yyyy}" ' for telerik


    Public Shared DBAMain As DBA
    Public Shared sRevID As String = ""
    Public Shared sSiteID As String
    Public Shared sCurrentEmpID As String = ""
    Public Shared sCurrentEmpName As String = ""
    Public Shared dtCurrentEmpLoginTime As Date = Now
    Public Shared sSecureProfileID As String = ""
    Public Shared sWorkstationID As String = ""
    Public Shared sLicenseTo As String = ""

    Public Shared bLogFileNoRecycle As Boolean = False
    'Appointment

    Public Shared eFormatCalendarDatetime As String = "ddd, dd-MMM-yyyy"
    Public Shared eFormatCalendarDatetimeNew As String = "yyyy/MM/dd (ddd)"

    Public Shared FormatDateTime As String = "dd/MM/yyyy HH:mm"
    Public Shared FormatDate As String = "dd/MM/yyyy"

    Public Shared sCreditCardMask As String = "0000-xxxx-xxxx-xxxx"


    'POS variable
    Public Shared sPriceFormat As String = "#0.00"
    Public Shared sPriceFormatTelerik As String = "{0:#0.00}"
    Public Shared sTaxCountry As String = "Malaysia"
    Public Shared nRoundMethod As eRoundMethod = eRoundMethod.RoundNearest
    Public Shared nRoundSmallest As Double = 0.01

    'Multi Language Localisation Variable
    Public Shared bLangEnable As Boolean
    Public Shared nLangFontSize As Integer
    Public Shared sLangFontName As String
    Public Shared nLangUse As Integer
    Public Shared sLangFolder As String = My.Application.Info.DirectoryPath & "\Localization"
    Public Shared sAppMode As String = My.Application.Info.DirectoryPath & "\AppMode"

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

    Public Structure ConfigKey
        Public WSID As String
        Public TillID As String
        Public LanguageEnable As String
        Public LanguageUse As String
        Public LanguageFontName As String
        Public LanguageFontSizeAdjust As String
        Public RevID As String
        Public ReceiptPreview As String
    End Structure

    Public Shared KeyWSID As String = "WSID"
    Public Shared KeyTillID As String = "TillID"
    Public Shared KeyLanguageEnable As String = "LanguageEnable"
    Public Shared KeyLanguageUse As String = "LanguageUse"
    Public Shared KeyLanguageFontName As String = "LanguageFontName"
    Public Shared KeyLanguageFontSizeAdjust As String = "LanguageFontSizeAdjust"
    Public Shared KeyRevID As String = "RevID"
    Public Shared KeyReceiptPreview As String = "ReceiptPreview"

    Public Enum EmailType
        HTML
        Text
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

    Public Enum ApptType
        ACTIVITY
        SPA
        GOLF
        FACILITY
    End Enum



    Public Enum BatchInputType
        Adjustment = 1
        Delivery = 2
        Manual = 3
        Transfer = 4
    End Enum

    Public Enum BatchStatus
        Active = 1
        Suspended = 2
        Returned = 3
        InActive = 4
        Cancelled = 5
    End Enum

    Public Enum BatchType
        Batch_No = 1
        Barcode = 2
        FIFO = 3
        NA = 4
    End Enum

    Public Enum SystemStatus
        Active = 1
        Deactive = 0
    End Enum
    Public Enum ReportType

        ReceiptOpen = 1
        CloseReceipt = 2
        Kitchen = 3
        ReceiptJournal = 4
        ClockInOut = 5
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

    Public Enum RevType
        Normal = 1
        FrontDesk = 2
        Membership = 3
    End Enum

    Public Enum WebRevType
        ACTIVITY
        SPA
        GOLF
    End Enum

    Public Enum eFormAction
        AddNew = 1
        Edit = 2
        ViewOnly = 3
    End Enum

    Public Enum eFormState
        Initialize = 1
        Ready = 2
    End Enum

    Public Enum VisitControlFrequency
        Daily = 1
        Weekly = 2
        Monthly = 3
        Quarter = 4
        Half_Year = 5
        Yearly = 6
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

    '==================================================================

    Public Class SysPara
        Private Shared ClassName As String = "Var.SysPara"

        Public Shared dtRev As DataTable = Nothing
        '=====================================================================================================================
        'Put All the System Parameter keyword here
        '=====================================================================================================================
        'MOdule Base
        'Public Const ModuleMembershipEnable As String = "ModuleMembershipEnable"
        'Public Const ModuleFrontDeskEnable As String = "ModuleFrontDeskEnable"
        Public Const LogFileNoRecycle As String = "LogFileNoRecycle"

        Public Const DefaultStayPeriodColor As String = "DefaultStayPeriodColor"
        'Spa Section
        Public Const ApptReserveColor As String = "ReserveColor"

        Public Const ApptReserveColorF As String = "ReserveColorF"
        Public Const ApptReserveColorM As String = "ReserveColorM"
        Public Const ApptConfirmColor As String = "ConfirmColor"
        Public Const ApptConfirmColorF As String = "ConfirmColorF"
        Public Const ApptConfirmColorM As String = "ConfirmColorM"
        Public Const ApptCheckInColor As String = "CheckInColor"
        Public Const ApptCheckOutColor As String = "CheckOutColor"
        Public Const ApptArrivalColor As String = "ArrivalColor"
        Public Const ApptUtilizedColor As String = "UtilizedColor"
        Public Const ApptActivityReserveColor As String = "ActivityReserveColor"
        Public Const ApptActivityCheckInColor As String = "ActivityCheckInColor"
        Public Const ApptActivityCheckOutColor As String = "ActivityCheckOutColor"
        Public Const UseGradientColor As String = "UseGradientColor"
        Public Const PackageIndication As String = "PackageIndication"
        Public Const SkipFindNextAvailableTime As String = "SkipFindNextAvailableTime"
        Public Const SpaSkipPOS As String = "SpaSkipPOS"
        Public Const GolfSkipPOS As String = "GolfSkipPOS"
        Public Const GolfMorePlayers As String = "GolfMorePlayers"
        Public Const GolfCrossOverBeforeBlock As String = "GolfCrossOverBeforeBlock"
        Public Const AllowGreenFeeBreakDown As String = "AllowGreenFeeBreakDown"
        Public Const AllowMultiApptInterval As String = "AllowMultiApptInterval"
        Public Const GolfCaddyAssinment As String = "GolfCaddyAssinment"
        Public Const GolfCaddyCompulsory As String = "GolfCaddyCompulsory"
        Public Const GolfAllowMoreCaddy As String = "GolfAllowMoreCaddy"
        Public Const GolfDefaultCaddyCategory As String = "GolfDefaultCaddyCategory"
        Public Const d9HBookingInterval As String = "9HBookingInterval"
        Public Const d18HBookingInterval As String = "18HBookingInterval"
        Public Const d27HBookingInterval As String = "27HBookingInterval"
        Public Const d36HBookingInterval As String = "36HBookingInterval"
        Public Const dTurnAroundTime As String = "TurnAroundTime"

        Public Const s9H As String = "Gate9Hole"
        Public Const s18H As String = "Gate18Hole"
        Public Const s9X As String = "Gate9xHole"

        Public Const ApptHskpColor As String = "TurnAroundColor"
        Public Const ApptEmpSort As String = "EmployeeSorting"
        Public Const ApptRoomSort As String = "RoomSorting"
        Public Const ApptSvcHourMethod As String = "SvcHourMethod"
        Public Const ApptMacro As String = "ApptMacro"
        Public Const FacilityMacro As String = "FacilityMacro"
        Public Const FacilityForcePaxPerSot As String = "FacilityForcePaxPerSot"
        Public Const ApptTurnAroundMacro As String = "TurnAroundMacro"
        Public Const ApptBlockMacro As String = "BlockMacro"
        Public Const ApptPackageOnSpot As String = "PackageOnSpot"
        Public Const ApptPackageUpgrade As String = "PackageUpgrade"
        Public Const ApptInterval As String = "ApptInterval"
        Public Const ApptSource As String = "ApptSource"
        Public Const ApptMarketSegment As String = "ApptMarketSegment"
        Public Const ApptSchTimeFmt As String = "ScheduleTimeFmt"
        Public Const ApptSchView As String = "ScheduleView"
        Public Const ApptMaxEmp As String = "MaxEmp"
        Public Const ApptMaxRoom As String = "MaxRoom"
        Public Const ApptBackWard As String = "BackWard"
        Public Const ApptPromptNotes As String = "PromptNotes"
        Public Const ApptEnableHskpAfterOffTime As String = "EnableHskpAfterOffTime"
        Public Const ApptPromptErr As String = "PromptError"
        Public Const PackageItemInSequence As String = "PackageItemInSequence"
        Public Const SchRefreshInterval As String = "SchRefreshInterval"

        Public Const ApptCancelCharge As String = "ApptCancelCharge"
        Public Const PackageCancelCharge As String = "PackageCancelCharge"
        Public Const ActivityCancelCharge As String = "ActivityCancelCharge"

        Public Const FutureRefund As String = "FutureRefund"
        Public Const PastRefund As String = "PastRefund"

        Public Const DefaultTreatmentGroupID As String = "DefaultTreatmentGroupID"
        Public Const DefaultSourceGroupID As String = "DefaultSourceGroupID"
        Public Const ERestPostDefaultSourceGroupID As String = "ERestPostDefaultSourceGroupID"
        Public Const LoginAttempt As String = "LoginAttempt"
        Public Const LoginBlock As String = "LoginBlock"
        Public Const eActivity_Schedule As String = "eActivitySchedule"

        'Activity Section
        Public Const ActivityEmpBlock As String = "ActivityEmpBlock"
        Public Const ActivityRoomBlock As String = "ActivityRoomBlock"

        'POS Section
        Public Const POSPriceFormat As String = "PriceFormat"
        Public Const POSTaxCountry As String = "TaxCountry"
        Public Const POSRooundingMethod As String = "RoundingMethod"
        Public Const POSRoundSmallest As String = "RoundToSmallest"


        Public Const POSDefaultPaymentTypeID As String = "DefaultPaymentTypeID"
        Public Const POSDefaultGuestID As String = "DefaultGuestID"
        Public Const POSDefaultPayGuestID As String = "DefaultPayGuestID"
        Public Const POSDefaultZeroPaymentTypeID As String = "DefaultZeroPaymentTypeID"

        Public Const POSExemptTaxID As String = "ExemptTaxID"
        Public Const POSSvcTaxLvl As String = "SvcTaxLevel"

        Public Const POSCentralBillRevID As String = "CentralBillingRevID"
        Public Const POSCentralBillPaymentTypeID As String = "CentralBillPaymentTypeID"
        Public Const POSCentralBillDefaultTillID As String = "CentralBillTillID"
        Public Const POSARPaymentTypeID As String = "MembershipARPaymentTypeID"
        Public Const POSVoucherPaymentTypeID As String = "VoucherPaymentTypeID"
        Public Const POSPrepaymentPaymentTypeID As String = "PrepaymentPaymentTypeID"
        Public Const POSLoyaltyPointPaymentTypeID As String = "LoyaltyPointPaymentTypeID"

        Public Const POSReverseCurrency As String = "ReverseCurrency"
        Public Const POSAllowReassignTax As String = "AllowReassignTax"
        Public Const POSPriceReferCurrency As String = "PriceReferCurrency"
        Public Const POSTreatmentPriceUseCurrency As String = "TreatmentPriceUseCurrency"
        Public Const POSStockPriceUseCurrency As String = "StockPriceUseCurrency"
        Public Const POSOthersPriceUseCurrency As String = "OthersPriceUseCurrency"
        Public Const POSPackagePriceUseCurrency As String = "PackagePriceUseCurrency"
        Public Const POSActivityPriceUseCurrency As String = "ActivityPriceUseCurrency"
        Public Const POSGolfPriceUseCurrency As String = "GolfPriceUseCurrency"
        Public Const POSMenbershipPriceUseCurrency As String = "MenbershipPriceUseCurrency"
        Public Const POSRentalPriceUseCurrency As String = "RentalPriceUseCurrency"
        Public Const POSEntranceFeePriceUseCurrency As String = "EntranceFeePriceUseCurrency"

        Public Const NoTransAfterEOD As String = "NoTransactionAllowedAfterEOD"
        Public Const EnableExpressPOS As String = "EnableExpressPOS"
        Public Const NewPrintReceiptMethod As String = "NewPrintReceiptMethod"
        Public Const OffVourcherPrepaymentMessage As String = "OffVourcherPrepaymentMessage"
        Public Const ExpressPOSDefaultPaymentTypeID1 As String = "ExpressPOSDefaultPaymentTypeID1"
        Public Const ExpressPOSDefaultPaymentTypeID2 As String = "ExpressPOSDefaultPaymentTypeID2"
        Public Const ExpressPOSDefaultPaymentTypeID3 As String = "ExpressPOSDefaultPaymentTypeID3"
        Public Const ExpressPOSDefaultPaymentTypeID4 As String = "ExpressPOSDefaultPaymentTypeID4"

        Public Const RestPOSDefaultPaymentTypeID As String = "RestPOSDefaultPaymentTypeID"
        Public Const RestPOSDefaultPaymentTypeID1 As String = "RestPOSDefaultPaymentTypeID1"
        Public Const RestPOSDefaultPaymentTypeID2 As String = "RestPOSDefaultPaymentTypeID2"
        Public Const RestPOSDefaultPaymentTypeID3 As String = "RestPOSDefaultPaymentTypeID3"
        Public Const RestPOSDefaultPaymentTypeID4 As String = "RestPOSDefaultPaymentTypeID4"
        Public Const DefaultTableNo As String = "DefaultTableNo"
        Public Const TimeDisplayWarningMsg As String = "TimeDisplayWarningMsg"

        Public Const POSDefaultCurrencySign As String = "DefaultCurrencySign"
        Public Const POSFirstLinePoleMessage As String = "FirstLinePoleMessage"
        Public Const POSSecondLinePoleMessage As String = "SecondLinePoleMessage"
        Public Const POSPoleWelcomeMessage As String = "PoleWelcomeMessage"

        Public Const DisplayMenuPrice As String = "DisplayMenuPrice"

        Public Const POSVoucherPostItemID As String = "VoucherPostItem"
        Public Const POSPrepaymentPostItemID As String = "PrepaymentPostItem"

        Public Const POSTipsIncomeCenterID As String = "TipsIncomeCenterID"
        Public Const POSTipsTaxID As String = "TipsTaxID"
        Public Const POSAllowTipsinPool As String = "AllowTipsinPool"
        Public Const POSObsorbTurnoverTax As String = "ObsorbTurnoverTax"
        Public Const POSReceiptShowPrepaymentBalance As String = "ReceiptShowPrepaymentBalance"
        Public Const POSReceiptShowVoucherBalance As String = "ReceiptShowVoucherBalance"

        Public Const POSSvcBeforeDiscount As String = "SvcBeforeDiscount"
        Public Const POSTaxBeforeDiscount As String = "TaxBeforeDiscount"
        Public Const POSOneSalesPersonPerItem As String = "OneSalesPersonPerItem"
        'Public Const POSScalaExportFolder As String = "ScalaExportFolder"
        Public Const AllowEditStockQty As String = "AllowEditStockQty"

        Public Const OpenCashDrawerAfterPayment As String = "OpenCashDrawerAfterPayment"
        Public Const POSMarketSegmentOnStock As String = "MarketSegmentCompoundsaryOnStock"
        Public Const POSDisplayPaymentDetail As String = "DisplayPaymentDetailInEndOfShift"
        Public Const UseStandardUnitSystem As String = "UseStandardUnitSystem"
        Public Const POSSalesPersonCompulsory As String = "POSSalesPersonCompulsory"

        'Therapist handling
        Public Const UsedTherapistSorting As String = "UsedTherapistSorting"
        Public Const TherapistSortingSequence1 As String = "TherapistSortingSequence1"
        Public Const TherapistSortingSequence2 As String = "TherapistSortingSequence2"
        Public Const TherapistSortingSequence3 As String = "TherapistSortingSequence3"
        Public Const TherapistSortingSequence4 As String = "TherapistSortingSequence4"
        Public Const TherapistHadlingMethodFirstDayOfWeek As String = "TherapistHadlingMethodFirstDayOfWeek"
        Public Const UsedAdvanceTherapistHandling As String = "UsedAdvanceTherapistHandling"
        Public Const TherapistHandlingMethod As String = "TherapistHandlingMethod"

        'CRM section
        Public Const CRMJapanAddress As String = "JapanAddress"
        Public Const CRMNameDelimeter As String = "NameDelimeter"
        Public Const CRMName1Reverse As String = "Name1Reverse"
        Public Const CRMName2Reverse As String = "Name2Reverse"
        Public Const CRMBuildingInAddress As String = "BuildingInAddress"
        Public Const CRMGuestTitle As String = "GuestTitle"
        Public Const CRMGuestGender As String = "GuestGender"
        Public Const CRMGuestType As String = "GuestType"
        Public Const CRMGuestSubType As String = "GuestSubType"
        Public Const CRMGuestNationality As String = "GuestNationality"
        Public Const CRMGuestSource As String = "GuestSource"
        Public Const CRMGuestDOBColor As String = "GuestDOBColor"
        Public Const CRMGuestDOBMonthColor As String = "GuestDOBMonthColor"
        Public Const CRMPasswordLength As String = "PasswordLength"
        Public Const OtherInterfacePwd As String = "PasswordCycle"
        Public Const CRMPassWordDefaultPeriod As String = "PasswordDefaultPeriod"
        Public Const CRMCreditCardMask As String = "CreditCardMask"
        Public Const CRMMaskCVV As String = "MaskCVV"
        Public Const CRMCVVDisable As String = "CVVDisable"
        Public Const CRMAnyGender As String = "AnyGender"
        Public Const CRMArchivedHistory As String = "ArchivedHistory"
        Public Const CRMBuilding As String = "GuestBuilding"
        Public Const CRMAddressCompulsory As String = "AddressCompulsory"
        Public Const CRMShowContactInGuestSummary As String = "ShowContactInGuestSummary"
        Public Const CRMDefaultMailingAddressCategory As String = "DefaultMailingAddressCategory"
        Public Const CRMDefaultWebPortalAddressCategory As String = "DefaultWebPortalAddressCategory"
        Public Const CRMVIPReservation As String = "VIPReservation"
        Public Const CRMWebGuestSubType As String = "WebGuestSubTypeID"
        Public Const CRMWebGuestType As String = "WebGuestTypeID"
        Public Const CRMWebGuestSourceID As String = "WebGuestSourceID"
        Public Const CRMWebGuestMarketSegmentID As String = "WebGuestMarketSegmentID"
        Public Const CRMWebGuestID As String = "WebGuestID"
        Public Const CRMActionOnBirthday As String = "ActionOnBirthday"
        Public Const CRMBirthdayMsg As String = "BirthdayMessage"
        Public Const CRMActionOnBirthdayMonth As String = "ActionOnBirthdayMonth"
        Public Const CRMBirthdayMonthMsg As String = "BirthdayMonthMessage"
        Public Const CRMDisplayMembership As String = "DisplayMembershipSupplementaryAndPrincipleProfile"
        Public Const CRMDisplayClientLink As String = "DisplayClientLink"

        Public Const DefaultPageSize As String = "DefaultPageSize"

        Public Const LockerDefaultStatus As String = "LockerDefaultStatus"

        'Front Desk Section
        Public Const FDMemberGuestSubTypeID As String = "MemberGuestSubTypeID"
        Public Const FDPaidedIntranceFeeCatetoryID As String = "PaidedEntranceFeeCatetoryID"
        Public Const FDFirstDayOfWeek As String = "FirstDayOfWeek"
        Public Const FDMyDefaultLocation As String = "MyDefaultLocation"
        Public Const FDMinAge As String = "MinAge"
        Public Const FDDefaultStayPeriod = "DefaultStayPeriod"
        Public Const FDScalaCLExportFolder As String = "ScalaCLExportFolder"
        Public Const FDScalaRVExportFolder As String = "ScalaRVExportFolder"
        Public Const FDScalaSTExportFolder As String = "ScalaSTExportFolder"
        Public Const FDDefaultStatus As String = "FDDefaultStatus"
        Public Const FDSkipAutoRefresh As String = "FDSkipAutoRefresh"
        ' This is for 1 Report 110016, 110017
        Public Const IncludeVisitFromOtherRev As String = "IncludeVisitFromOtherRev"
        Public Const FDVoidDoubleCharging As String = "FDVoidDoubleCharging"
        Public Const FDWelcomeText As String = "FDWelcomeText"
        Public Const AutoPostEntranceFee As String = "AutoPostEntranceFee"
        Public Const AutoPostEntranceFeeCR As String = "AutoPostEntranceFeeConfirmationRequired"

        'Locker Management section
        Public Const LockerOnlyAllowCheckInGuest As String = "LockerOnlyAllowCheckInGuest"
        Public Const LockerSingleLockerAssign As String = "LockerSingleLockerAssign"
        Public Const LockerExpiredWarnDays As String = "LockerExpiredWarnDays"
        Public Const LockerPerCol As String = "LockerPerCol"
        Public Const LockerPerRow As String = "LockerPerRow"
        Public Const LockerShowApptGuest As String = "LockerShowApptGuest"
        Public Const LockerShowActivityGuest As String = "LockerShowActivityGuest"
        Public Const LockerPromptApptCheckOut As String = "LockerPromptApptCheckOut"
        Public Const LockerPromptActivityCheckOut As String = "LockerPromptActivityCheckOut"
        Public Const DisplayAllGuest As String = "DisplayAllGuest"

        'Payment Gateway
        Public Const PGURL As String = "PGURL"
        Public Const PGTransCurrency As String = "TransCurrency"
        Public Const PGEncrypt As String = "PGEncrypt"
        Public Const PGEncoding As String = "PGEncoding"
        Public Const PGSSL As String = "PGSSL"
        Public Const PGImportCCard As String = "PGImportCCard"

        'Loyalty Point
        Public Const PtsRooundingMethod As String = "PtsRoundingMethod"
        Public Const PtsAwardToKey As String = "PtsAwardTo"
        Public Const PtsRoundSmallest As String = "PtsRoundToSmallest"
        Public Const PtsAward As String = "PtsAward"
        Public Const PtsFormat As String = "PtsFormat"
        Public Const PtsPartialRedeem As String = "PtsPartialRedeem"
        Public Const PtsAwardUponRedeem As String = "PtsAwardUponRedeem"

        'Misc Section
        '===Employee===
        'Public Const MiscWorkingHoursType As String = "MiscWorkingHoursType"
        Public Const MiscPoolCommissionPercent As String = "MiscPoolCommissionPercent"

        'Golf Section
        Public Const GolfApptInterval As String = "GolfApptInterval"
        Public Const GolfToolTipsWidth As String = "GolfToolTipsWidth"
        Public Const GolfTempBlockID As String = "GolfTempBlockID"
        Public Const GolfNotJointBlockID As String = "GolfNotJointBlockID"
        Public Const GolfDefaultGuestPortalBlockID As String = "GolfDefaultGuestPortalBlockID"
        Public Const GolfPayUponCheckIn As String = "GolfPayUponCheckIn"
        Public Const Golf1stTeeOnly As String = "Golf1stTeeOnly"
        Public Const GolfDefaultMarketSegmentID As String = "GolfDefaultMarketSegmentID"
        Public Const GolfBackWard As String = "GolfBackWard"

        Public Const GolfReserveColor As String = "GolfReserveColor"
        Public Const GolfConfirmColor As String = "GolfConfirmColor"
        Public Const GolfCheckInColor As String = "GolfCheckInColor"
        Public Const GolfCheckOutColor As String = "GolfCheckOutColor"
        Public Const GolfOccupancy25 As String = "GolfOccupancy25"
        Public Const GolfOccupancy50 As String = "GolfOccupancy50"
        Public Const GolfOccupancy75 As String = "GolfOccupancy75"
        Public Const GolfOccupancy100 As String = "GolfOccupancy100"
        Public Const GolfBreakTimeColor As String = "GolfBreakTimeColor"
        Public Const GolfGroupBookingColor As String = "GolfGroupBookingColor"
        Public Const GolfApptCancelCharge As String = "GolfApptCancelCharge"
        Public Const BarCodeTemplate As String = "BarCodeTemplate"
        Public Const GolfAllotmentCancelCode As String = "AllotmentCancelCode"
        Public Const GolfApptMacroID As String = "GolfApptMacroID"
        Public Const GolfBlockMacroID As String = "GolfBlockMacroID"
        Public Const GolfCheckOutUponCheckIn As String = "GolfCheckOutUponCheckIn"
        Public Const GolfReturnBuggyUponCheckOut As String = "GolfReturnBuggyUponCheckOut"
        Public Const GolfDefaultGuestID As String = "GolfDefaultGuestID"
        Public Const GolfDefaultSourceID As String = "GolfDefaultSourceID"
        Public Const GolfDefaultWebPortalSourceID As String = "GolfDefaultWebPortalSourceID"
        Public Const GolfSummaryApptText As String = "GolfSummaryApptText"
        Public Const GolfSummaryBlockText As String = "GolfSummaryBlockText"
        Public Const GolfPromptNotes As String = "GolfPromptNotes"
        Public Const GolfCPRequestBy As String = "GolfCPRequestBy"
        Public Const GolfCPContactNo As String = "GolfCPContactNo"
        Public Const GolfCPRefNo As String = "GolfCPRefNo"
        Public Const GolfCPMarketSegment As String = "GolfCPMarketSegment"
        Public Const GolfCPSalesPerson As String = "GolfCPSalesPerson"
        Public Const GolfControlMaxBuggy As String = "ControlMaxBuggy"
        Public Const GolfCrossOverColor As String = "GolfCrossOverColor"

        Public Const AutoLogOff As String = "AutoLogOffDuration"

        'e-RestPOS
        Public Const FnbOpenModifierID As String = ""
        Public Const GUIGSTInclusive As String = "GUIGSTInclusive"
        Public Const GUIGSTExclusive As String = "GUIGSTExclusive"
        Public Const GUIZeroRated As String = "ZeroRated"
        Public Const FNBDefaultModifier As String = "FNBDefaultModifier"
        Public Const FNBDefaultPrinter As String = "FNBDefaultPrinter"
        Public Const SourceDefault As String = "SourceDefault"
        Public Const DefaultTableLayOut As String = "DefaultTableLayOut"

        Public Const FNBSeatedMinutesWaning As String = "SeatedMinutesWaning"
        Public Const FNBDefaultCoverNumber As String = "DefaultCoverNumber"
        Public Const FnbMaxSplitReceipt As String = "FnbMaxSplitReceipt"
        Public Const FNBAllowDefaultTable As String = "AllowDefaultTable"
        Public Const FNBAllowDefaultCovers As String = "AllowDefaultCovers"
        Public Const FnbQuickService As String = "FnbQuickService"
        Public Const FNBBackColor As String = "FNBBackColor"
        Public Const FNBHeaderFooterBackColor As String = "FNBHeaderFooterBackColor"
        Public Const FnbFontType As String = "FnbFontType"
        Public Const FnbFontColor As String = "FnbFontColor"
        Public Const FNBTrainningBackColor As String = "FNBTrainningBackColor"
        Public Const FNBTrainningHeaderFooterBackColor As String = "FNBTrainningHeaderFooterBackColor"
        Public Const FnbTrainningFontType As String = "FnbTrainningFontType"
        Public Const FnbTrainningFontColor As String = "FnbTrainningFontColor"
        Public Const FnbAutoShowVirtualKeyboard As String = "FnbAutoShowVirtualKeyboard"

        'PD-DSS
        Public Const EnforcePasswordSecuriry As String = "EnforcePasswordSecuriry"

        'Attendance Status
        Public Const AttendanceStatusTest As String = "AttendanceStatusTest"
        Public Const AttendanceStatusSuspend As String = "AttendanceStatusSuspend"
        Public Const AttendanceStatusAttend As String = "AttendanceStatusAttend"
        Public Const AttendanceStatusCheckin As String = "AttendanceStatusCheckin"
        Public Const AttendanceStatusCheckout As String = "AttendanceStatusCheckout"

        'e-Ngage
        Public Const SMSSpaPackageCheck As String = "SMSSpaPackageCheck"
        Public Const SMSSpaPackageNewCheck As String = "SMSSpaPackageNewCheck"
        Public Const SMSSpaPackageEditCheck As String = "SMSSpaPackageEditCheck"
        Public Const SMSSpaPackageCancelCheck As String = "SMSSpaPackageCancelCheck"
        Public Const SMSSpaPackageReminderCheck As String = "SMSSpaPackageReminderCheck"

        Public Const SMSSpaPackageNewTemplate As String = "SMSSpaPackageNewTemplate"
        Public Const SMSSpaPackageEditTemplate As String = "SMSSpaPackageEditTemplate"
        Public Const SMSSpaPackageCancelTemplate As String = "SMSSpaPackageCancelTemplate"
        Public Const SMSSpaPackageReminderTemplate As String = "SMSSpaPackageReminderTemplate"

        Public Const SMSSpaPackageReminderTrigger As String = "SMSSpaPackageReminderTrigger"

        Public Const SMSActivityCheck As String = "SMSActivityCheck"
        Public Const SMSActivityNewCheck As String = "SMSActivityNewCheck"
        Public Const SMSActivityEditCheck As String = "SMSActivityEditCheck"
        Public Const SMSActivityCancelCheck As String = "SMSActivityCancelCheck"
        Public Const SMSActivityReminderCheck As String = "SMSActivityReminderCheck"

        Public Const SMSActivityNewTemplate As String = "SMSActivityNewTemplate"
        Public Const SMSActivityEditTemplate As String = "SMSActivityEditTemplate"
        Public Const SMSActivityCancelTemplate As String = "SMSActivityCancelTemplate"
        Public Const SMSActivityReminderTemplate As String = "SMSActivityReminderTemplate"

        Public Const SMSActivityReminderTrigger As String = "SMSActivityReminderTrigger"

        Public Const SMSGolfCheck As String = "SMSGolfCheck"
        Public Const SMSGolfNewCheck As String = "SMSGolfNewCheck"
        Public Const SMSGolfEditCheck As String = "SMSGolfEditCheck"
        Public Const SMSGolfCancelCheck As String = "SMSGolfCancelCheck"
        Public Const SMSGolfReminderCheck As String = "SMSGolfReminderCheck"

        Public Const SMSGolfNewTemplate As String = "SMSGolfNewTemplate"
        Public Const SMSGolfEditTemplate As String = "SMSGolfEditTemplate"
        Public Const SMSGolfCancelTemplate As String = "SMSGolfCancelTemplate"
        Public Const SMSGolfReminderTemplate As String = "SMSGolfReminderTemplate"

        Public Const SMSGolfReminderTrigger As String = "SMSGolfReminderTrigger"

        Public Const AlertPackageCheck As String = "AlertPackageCheck"
        Public Const AlertPackageOutstandingCheck As String = "AlertPackageOutstandingCheck"
        Public Const AlertPackageExpiredSoonCheck As String = "AlertPackageExpiredSoonCheck"
        Public Const AlertPackageExpiredCheck As String = "AlertPackageExpiredCheck"
        Public Const AlertPackageBalanceCheck As String = "AlertPackageBalanceCheck"

        Public Const AlertPackageOutstandingTemplate As String = "AlertPackageOutstandingTemplate"
        Public Const AlertPackageExpiredSoonTemplate As String = "AlertPackageExpiredSoonTemplate"
        Public Const AlertPackageExpiredTemplate As String = "AlertPackageExpiredTemplate"
        Public Const AlertPackageBalanceTemplate As String = "AlertPackageBalanceTemplate"

        Public Const AlertPackageOutstandingAmount As String = "AlertPackageOutstandingAmount"
        Public Const AlertPackageExpiredSoonDay As String = "AlertPackageExpiredSoonDay"

        Public Const AlertPackageOutstandingTrigger As String = "AlertPackageOutstandingTrigger"
        Public Const AlertPackageExpiredSoonTrigger As String = "AlertPackageExpiredSoonTrigger"


        Public Const AlertVoucherCheck As String = "AlertVoucherCheck"
        Public Const AlertVoucherOutstandingCheck As String = "AlertVoucherOutstandingCheck"
        Public Const AlertVoucherExpiredSoonCheck As String = "AlertVoucherExpiredSoonCheck"
        Public Const AlertVoucherExpiredCheck As String = "AlertVoucherExpiredCheck"
        Public Const AlertVoucherBalanceCheck As String = "AlertVoucherBalanceCheck"

        Public Const AlertVoucherOutstandingTemplate As String = "AlertVoucherOutstandingTemplate"
        Public Const AlertVoucherExpiredSoonTemplate As String = "AlertVoucherExpiredSoonTemplate"
        Public Const AlertVoucherExpiredTemplate As String = "AlertVoucherExpiredTemplate"
        Public Const AlertVoucherBalanceTemplate As String = "AlertVoucherBalanceTemplate"

        Public Const AlertVoucherOutstandingAmount As String = "AlertVoucherOutstandingAmount"
        Public Const AlertVoucherExpiredSoonDay As String = "AlertVoucherExpiredSoonDay"
        Public Const AlertVoucherOutstandingTrigger As String = "AlertVoucherOutstandingTrigger"
        Public Const AlertVoucherExpiredSoonTrigger As String = "AlertVoucherExpiredSoonTrigger"

        Public Const AlertPrepaymentCheck As String = "AlertPrepaymentCheck"
        Public Const AlertPrepaymentOutstandingCheck As String = "AlertPrepaymentOutstandingCheck"
        Public Const AlertPrepaymentExpiredSoonCheck As String = "AlertPrepaymentExpiredSoonCheck"
        Public Const AlertPrepaymentExpiredCheck As String = "AlertPrepaymentExpiredCheck"
        Public Const AlertPrepaymentBalanceCheck As String = "AlertPrepaymentBalanceCheck"

        Public Const AlertPrepaymentOutstandingTemplate As String = "AlertPrepaymentOutstandingTemplate"
        Public Const AlertPrepaymentExpiredSoonTemplate As String = "AlertPrepaymentExpiredSoonTemplate"
        Public Const AlertPrepaymentExpiredTemplate As String = "AlertPrepaymentExpiredTemplate"
        Public Const AlertPrepaymentBalanceTemplate As String = "AlertPrepaymentBalanceTemplate"

        Public Const AlertPrepaymentOutstandingAmount As String = "AlertPrepaymentOutstandingAmount"
        Public Const AlertPrepaymentExpiredSoonDay As String = "AlertPrepaymentExpiredSoonDay"

        Public Const AlertPrepaymentOutstandingTrigger As String = "AlertPrepaymentOutstandingTrigger"
        Public Const AlertPrepaymentExpiredSoonTrigger As String = "AlertPrepaymentExpiredSoonTrigger"

        Public Const SmsUsePackageName As String = "SMSUsePackageName"
        Public Const SmsAllowEngageModlue As String = "SMSAllowEngageModlue"
        Public Const EngageSendManual As String = "EngageSendManual"
        Public Const StartSendBy As String = "StartSendBy"
        Public Const SendTimes As String = "SendTimes"
        Public Const MessageMaxLength As String = "MessageMaxLength"

        Public Const TrainningModeServer As String = "TrainningModeServer"
        Public Const TrainningModeDB As String = "TrainningModeDB"
        Public Const TrainningModeDBDNS As String = "TrainningModeDBDNS"
        Public Const TrainningModeUser As String = "TrainningModeUser"
        Public Const TrainningModePassword As String = "TrainningModePassword"
        '=====================================================================================================================
        'End System parameter keyword
        '=====================================================================================================================

        Private Shared Sub GetRevSettings()
            Dim sSQL As String
            Dim ds As New DataSet

            Try
                sSQL = "SELECT * FROM Rev"
                Var.DBAMain.FillDataset(sSQL, ds)

                dtRev = ds.Tables(0).Copy

            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)
            Finally
                ds.Dispose()
                ds = Nothing
            End Try
        End Sub


        Private Shared Sub GetSysParaTable()
            Dim sSQL As String
            Dim ds As New DataSet

            Try
                sSQL = "SELECT * FROM SysPara"
                Var.DBAMain.FillDataset(sSQL, ds)

                ' dtSysParaTable = ds.Tables(0).Copy

            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)
            Finally
                ds.Dispose()
                ds = Nothing
            End Try
        End Sub

        Public Shared Sub ReadSysPara()
      
            Try

                '=============================================================================================================
                'Module Section
                '=============================================================================================================
                'bModuleMembershipEnable = Core.StrToBool(Key(SystemModule.Module_Base, Var.LicenseInfo.ModuleMembershipEnable, , Var.sSiteID, "1"))
                'bModuleFrontDeskEnable = Core.StrToBool(Key(SystemModule.Module_Base, Var.LicenseInfo.ModuleFrontDeskEnable, , Var.sSiteID, "1"))


                GetRevSettings()
                '=============================================================================================================
                'Appointment Section
                '=============================================================================================================



                GetSysParaTable()



                bLogFileNoRecycle = Val(Key(SystemModule.Module_Base, LogFileNoRecycle, , Var.sSiteID, "0"))

            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)
            End Try
        End Sub

        Public Shared Sub UpdateSysPara()
            Try
                '=============================================================================================================
                'Global Section
                '=============================================================================================================
                UpdateKey(SystemModule.Module_Base, LogFileNoRecycle, , Var.sSiteID, IIf(bLogFileNoRecycle, "1", "0"))

                '=============================================================================================================
                'POS Section
                '=============================================================================================================
                UpdateKey(SystemModule.POS, POSPriceFormat, Var.sRevID, , sPriceFormat)
                UpdateKey(SystemModule.POS, POSTaxCountry, Var.sRevID, , sTaxCountry)
                UpdateKey(SystemModule.POS, POSRooundingMethod, Var.sRevID, , nRoundMethod)
                UpdateKey(SystemModule.POS, POSRoundSmallest, Var.sRevID, , nRoundSmallest)


            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)
            End Try
        End Sub

        Public Shared Function Key(ByVal sModule As SystemModule, ByVal sKey As String, Optional ByVal sRevID As String = "", Optional ByVal sSiteID As String = "", Optional ByVal sDefaultValue As String = "") As String
            Dim db As New DBA(False)
            Try
                Dim sValue As String = ""
                Dim ds As New DataSet

                Dim sSelect As String = ""



                'If sRevID = "" And sSiteID = "" Then Return ""

                If sRevID <> "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID)
                ElseIf sSiteID <> "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND SiteID = " & Core.SQLStr(sSiteID)
                ElseIf sRevID <> "" And sSiteID = "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID) & " AND SiteID = " & Core.SQLStr(sSiteID)
                ElseIf sRevID = "" And sSiteID = "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey)
                End If


                'If dtSysParaTable Is Nothing = False Then
                '    foundRows = dtSysParaTable.Select(sSelect)
                '    If foundRows.Count > 0 Then
                '        sValue = foundRows(0)("Value").ToString()
                '    Else
                '        sSQL = "INSERT INTO SysPara (Module,Field,Value,RevID,SiteID) VALUES (" & Core.SQLStr(CInt(sModule)) & "," & Core.SQLStr(sKey) & "," & Core.SQLStr(sDefaultValue) & "," & Core.SQLStr(sRevID) & "," & Core.SQLStr(sSiteID) & ")"
                '        db.Execute(sSQL)
                '        Return sDefaultValue
                '    End If
                'Else
                '    sSQL = "SELECT * FROM SysPara WHERE " & sSelect
                '    db.FillDataset(sSQL, ds, "SysPara")

                '    If ds.Tables("SysPara").Rows.Count > 0 Then
                '        dr = ds.Tables("SysPara").Rows(0)
                '        sValue = dr("Value")
                '    Else
                '        sSQL = "INSERT INTO SysPara (Module,Field,Value,RevID,SiteID) VALUES (" & Core.SQLStr(CInt(sModule)) & "," & Core.SQLStr(sKey) & "," & Core.SQLStr(sDefaultValue) & "," & Core.SQLStr(sRevID) & "," & Core.SQLStr(sSiteID) & ")"
                '        db.Execute(sSQL)
                '        Return sDefaultValue
                '    End If
                'End If



                Return sValue
            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)
                Return ""
            Finally
                db.Dispose()
            End Try
        End Function

        Public Shared Sub UpdateKey(ByVal sModule As SystemModule, ByVal sKey As String, Optional ByVal sRevID As String = "", Optional ByVal sSiteID As String = "", Optional ByVal sValue As String = "")
            Try
                Dim ds As New DataSet
                Dim sSelect As String
                Dim sSQL As String

                'If sRevID = "" And sSiteID = "" Then Exit Sub

                If sRevID <> "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID)
                    sSQL = "UPDATE SysPara SET Value = " & Core.SQLStr(sValue) & " WHERE Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID)
                    Var.DBAMain.Execute(sSQL)
                ElseIf sSiteID <> "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND SiteID = " & Core.SQLStr(sSiteID)
                    sSQL = "UPDATE SysPara SET Value = " & Core.SQLStr(sValue) & " WHERE Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND SiteID = " & Core.SQLStr(sSiteID)
                    Var.DBAMain.Execute(sSQL)
                ElseIf sRevID <> "" And sSiteID = "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID) & " AND SiteID = " & Core.SQLStr(sSiteID)
                    sSQL = "UPDATE SysPara SET Value = " & Core.SQLStr(sValue) & " WHERE Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey) & " AND RevID = " & Core.SQLStr(sRevID)
                    Var.DBAMain.Execute(sSQL)
                ElseIf sRevID = "" And sSiteID = "" Then
                    sSelect = "Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey)
                    sSQL = "UPDATE SysPara SET Value = " & Core.SQLStr(sValue) & " WHERE Module = " & Core.SQLStr(sModule) & " AND Field = " & Core.SQLStr(sKey)
                    Var.DBAMain.Execute(sSQL)
                End If


            Catch ex As Exception
                'Log.LogError(ClassName, Core.WhoCalledMe, ex.Message)

            End Try
        End Sub

    End Class

    Public Class LicenseInfo
        Private Shared ClassName As String = "Var.LicenseInfo"

        'Module Base
        Public Shared bValidLicenseKey As Boolean = False
        Public Shared bValidWebEngineLicenseKey As Boolean = False
        Public Shared bModuleMembershipEnable As Boolean = False
        Public Shared bModuleFrontDeskEnable As Boolean = False
        Public Shared bModuleSpaEnable As Boolean = False
        Public Shared bModulePOSEnable As Boolean = False
        Public Shared bModuleLoyaltyEnable As Boolean = False
        Public Shared bModuleGolfEnable As Boolean = False
        Public Shared bModuleFnbEnable As Boolean = False

        Public Shared dtExpiredDate As Date = New Date(1900, 1, 1)
        Public Shared dtWebEngineExpiredDate As Date = New Date(1900, 1, 1)
        Public Shared nWSLimit As Integer = 99
        Public Shared nRevLimit As Integer = 1








        Public Class ModuleLicense
            Public Shared bInterfaceFIAS As Boolean = False
            Public Shared bInterfaceGalaxy As Boolean = False
            Public Shared bInterfaceFujitsu As Boolean = False
            Public Shared bInterfaceNEC As Boolean = False
            Public Shared bInterfaceScala As Boolean = False
            Public Shared bInterfaceMPG As Boolean = False 'micros payment gateway
            Public Shared bInterfaceOnQ As Boolean = False
            Public Shared bInterfaceHTNG As Boolean = False
            Public Shared bInterfaceFMT As Boolean = False
            Public Shared bInterfaceNanoTech As Boolean = False
            Public Shared bInterfaceNECPMS As Boolean = False





        End Class

    End Class
    Public Class Attends
        Public Const CheckIn As String = "Check In"
        Public Const CheckedOut As String = "Checked Out"
        Public Const WaitListed As String = "Wait Listed"
        Public Const OnHold As String = "On Hold"

    End Class
    Public Class QuestionType
        Public Const PreDefinedAWithComment As String = "1"
        Public Const PreDefinedAnswers As String = "2"
        Public Const FreeText As String = "3"
    End Class
    Public Class TemplateLanguage
        Public Const English As String = "1"
        Public Const Japnese As String = "2"

    End Class


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
