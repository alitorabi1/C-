Imports System.Collections.ObjectModel
Imports System.Media
'
Partial Public Class LoginDialog

#Region " Declarations "

    Private _intLoginAttempts As Integer
    Private _objDataBase As DataBase = Nothing

#End Region

#Region " Properties "

    Public ReadOnly Property DataBase() As DataBase
        Get
            Return _objDataBase
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True
        Me.DialogResult = False
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        e.Handled = True

        'TODO developers you can add more securty stuff here as required
        If Me.txtInitialPassword.Text.Length > 0 Then
            Application.Password = Me.txtInitialPassword.Text

        Else
            Application.Password = Me.txtPassword.Password
        End If

        If Load() Then
            Me.DialogResult = True

        Else
            _intLoginAttempts += 1

            If _intLoginAttempts = 3 Then
                My.Application.Shutdown()
            End If

            Me.txtPassword.Password = String.Empty
            My.Computer.Audio.PlaySystemSound(SystemSounds.Exclamation)
        End If

    End Sub

    Private Sub BuildDefaultDataBase()
        'TODO developers you can add, remove or modify card types here
        _objDataBase = New DataBase

        Dim ct As CardType
        '
        ct = New CardType(Application.STR_ALLRECORDS, "..\Resources\Images\allRecords.png")
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Appliance", "..\Resources\Images\hardware.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 10, .FieldTag = "Admin User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = True, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Admin Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = True, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 30, .FieldTag = "URL", .FieldType = FieldType.URLPrimary, .IsRequired = True, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 40, .FieldTag = "IP Address", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 50, .FieldTag = "Primary DNS", .FieldType = FieldType.IP, .IsRequired = False, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 60, .FieldTag = "Secondary DNS", .FieldType = FieldType.IP, .IsRequired = False, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 70, .FieldTag = "Domain", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 80, .FieldTag = "Model Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 90, .FieldTag = "Serial Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 100, .FieldTag = "Manufacturer", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 110, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 120, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 130, .FieldTag = "Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 140, .FieldTag = "Support Web Site", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 150, .FieldTag = "User Name", .FieldType = FieldType.UserNameSecondary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 160, .FieldTag = "Password", .FieldType = FieldType.PasswordSecondary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 170, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Bank Account", "..\Resources\Images\bank.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 10, .FieldTag = "Name on Account", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Account Number", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "Routing Number", .FieldType = FieldType.RoutingNumber, .IsRequired = False, .MaximumLength = 9})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 40, .FieldTag = "PIN Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 20})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 50, .FieldTag = "Bank Name", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 60, .FieldTag = "Address", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 70, .FieldTag = "City State Zip", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 80, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 90, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 100, .FieldTag = "Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 110, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 120, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 130, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Credit Card", "..\Resources\Images\creditCards.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 10, .FieldTag = "Name On Card", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Card Number", .FieldType = FieldType.CreditCardNumber, .IsRequired = True, .MaximumLength = 20})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "Expiration Date", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 10})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 40, .FieldTag = "CV2 Number", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 4})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 50, .FieldTag = "PIN Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 20})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 60, .FieldTag = "Issued By", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 70, .FieldTag = "Address", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 70, .FieldTag = "City State Zip", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 80, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 90, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 100, .FieldTag = "Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 110, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 120, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 130, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Email Account", "..\Resources\Images\email.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 10, .FieldTag = "Email", .FieldType = FieldType.Email, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Password", .FieldType = FieldType.PasswordSecondary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 30, .FieldTag = "Incoming Server", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 40, .FieldTag = "Outgoing Server", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 50, .FieldTag = "Web Access URL", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 60, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 70, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 80, .FieldTag = "Provider Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 90, .FieldTag = "Web Site User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 100, .FieldTag = "Web Site Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 110, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Firewall", "..\Resources\Images\firewall.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 10, .FieldTag = "Admin User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = True, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Admin Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = True, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "Internal IP Address", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 40, .FieldTag = "Internal URL", .FieldType = FieldType.URLPrimary, .IsRequired = True, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 50, .FieldTag = "External IP Address", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 60, .FieldTag = "External URL", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 70, .FieldTag = "Domain", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 80, .FieldTag = "Shared Secret", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 90, .FieldTag = "Model Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 100, .FieldTag = "Serial Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 110, .FieldTag = "Manufacturer", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 120, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 130, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 140, .FieldTag = "Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 150, .FieldTag = "Support Web Site", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 160, .FieldTag = "User Name", .FieldType = FieldType.UserNameSecondary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 170, .FieldTag = "Password", .FieldType = FieldType.PasswordSecondary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 180, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("License", "..\Resources\Images\softwareLicense.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 10, .FieldTag = "Product Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Registration Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "License Key", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 40, .FieldTag = "Activation Key", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 50, .FieldTag = "Registered To", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 60, .FieldTag = "Version", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 20})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 70, .FieldTag = "Reference Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 80, .FieldTag = "Order Number", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 90, .FieldTag = "Date Purchased", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 100, .FieldTag = "Download URL", .FieldType = FieldType.URLSecondary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 110, .FieldTag = "Vendor", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 120, .FieldTag = "Address", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Proper, .FieldSortOrder = 130, .FieldTag = "City State Zip", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 140, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 150, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 160, .FieldTag = "Web Site", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 170, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 180, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 190, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Server", "..\Resources\Images\server.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 10, .FieldTag = "Server Name", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Domain Name", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "IP Address", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 40, .FieldTag = "O/S", .FieldType = FieldType.Plain, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 50, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 60, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = True, .MaximumLength = 50})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("VPN", "..\Resources\Images\vpn.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 10, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "IP Address", .FieldType = FieldType.IP, .IsRequired = True, .MaximumLength = 15})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 40, .FieldTag = "URL", .FieldType = FieldType.URLPrimary, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 50, .FieldTag = "Domain", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 60, .FieldTag = "Shared Secret", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 70, .FieldTag = "VPN Type", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        _objDataBase.CardTypes.Add(ct)
        '
        ct = New CardType("Web Site", "..\Resources\Images\webSite.png")
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 10, .FieldTag = "URL", .FieldType = FieldType.URLPrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 20, .FieldTag = "User Name", .FieldType = FieldType.UserNamePrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 30, .FieldTag = "Password", .FieldType = FieldType.PasswordPrimary, .IsRequired = True, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 40, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.OutlookPhoneProper, .FieldSortOrder = 50, .FieldTag = "Phone", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 50})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.Lower, .FieldSortOrder = 60, .FieldTag = "Support Email", .FieldType = FieldType.Email, .IsRequired = False, .MaximumLength = 30})
        ct.CardFields.Add(New CardField With {.FieldCase = FieldCase.None, .FieldSortOrder = 70, .FieldTag = "Security Q & A", .FieldType = FieldType.Plain, .IsRequired = False, .MaximumLength = 100})
        _objDataBase.CardTypes.Add(ct)
        '
        '
        '
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck("Po Box", "PO Box"))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck("C/o ", "c/o "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck("C/O ", "c/o "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck("Vpn ", "VPN "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck("Xp ", "XP "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Or ", " or "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" And ", " and "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Nw ", " NW "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Ne ", " NE "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Sw ", " SW "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Se ", " SE "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Llc. ", " LLC. "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Llc ", " LLC "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Lc ", " LC "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Lc. ", " LC. "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Lt ", " LT "))
        _objDataBase.CharacterCasingChecks.Add(New CharacterCasingCheck(" Lt. ", " LT. "))
    End Sub

    Public Function Load() As Boolean

        If DataBase.Exists Then
            _objDataBase = DataBase.Load
            Return _objDataBase IsNot Nothing

        Else
            BuildDefaultDataBase()
        End If

        Return True
    End Function

    Private Sub Login_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        If Not DataBase.Exists Then
            Me.txtInitialPassword.Visibility = Windows.Visibility.Visible
            Me.tbPasswordTag.Text = "Initial Use - Enter Password"
            Me.txtInitialPassword.Focus()

        Else
            Me.txtPassword.Focus()
        End If

    End Sub

#End Region

End Class
