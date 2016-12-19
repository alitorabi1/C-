Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Runtime.Serialization.Formatters.Binary
'
<Serializable()> Public Class DataBase
    Inherits CardBase

#Region " Declarations "

    Private _objCards As New Cards
    Private _objCardTypes As New List(Of CardType)
    Private _objCharacterCasingChecks As New List(Of CharacterCasingCheck)
    Private _strCardTypeName As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property Cards() As Cards
        Get
            Return _objCards
        End Get
    End Property

    Public Property CardTypes() As List(Of CardType)
        Get
            Return _objCardTypes
        End Get
        Set(ByVal Value As List(Of CardType))
            _objCardTypes = Value
        End Set
    End Property

    Public Property CharacterCasingChecks() As List(Of CharacterCasingCheck)
        Get
            Return _objCharacterCasingChecks
        End Get
        Set(ByVal Value As List(Of CharacterCasingCheck))
            _objCharacterCasingChecks = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()
    End Sub

#End Region

#Region " Methods "

    Private Function Contains(ByVal obj As CardType) As Boolean
        Return String.Compare(obj.CardTypeName, _strCardTypeName) = 0
    End Function

    Private Shared Function CreateTripleDESTransform(ByVal Mode As CryptoStreamMode) As ICryptoTransform

        Dim key As Byte() = Nothing
        Dim salt As Byte() = Nothing
        Dim iv As Byte() = Nothing
        Dim rc2 As RC2CryptoServiceProvider = Nothing

        Try
            salt = New Byte() {0, 1, 2, 3, 4, 5, 6, 7}

            Dim pwdGen As New Rfc2898DeriveBytes(Application.Password, salt, 1000)
            key = pwdGen.GetBytes(16)
            iv = pwdGen.GetBytes(8)
            rc2 = New RC2CryptoServiceProvider()
            rc2.Key = key
            rc2.IV = iv

            Select Case Mode

                Case CryptoStreamMode.Read
                    Return TripleDES.Create().CreateDecryptor(key, iv)

                Case CryptoStreamMode.Write
                    Return TripleDES.Create().CreateEncryptor(key, iv)

                Case Else
                    Return Nothing
            End Select

        Catch e As Exception
            Throw e

        Finally

            If key IsNot Nothing Then
                Array.Clear(key, 0, key.Length)
            End If

            If salt IsNot Nothing Then
                Array.Clear(salt, 0, salt.Length)
            End If

            If iv IsNot Nothing Then
                Array.Clear(iv, 0, iv.Length)
            End If

        End Try

    End Function

    Private Shared Function DecryptFile() As DataBase

        Try
            Using fs As FileStream = File.Open(Application.DataFileName, FileMode.OpenOrCreate, FileAccess.Read)
                Using objCryptoStream As New CryptoStream(fs, CreateTripleDESTransform(CryptoStreamMode.Read), CryptoStreamMode.Read)

                    Dim bf As New BinaryFormatter
                    Return CType(bf.Deserialize(objCryptoStream), DataBase)
                End Using
            End Using

        Catch e As CryptographicException

            '
            'this block of code only runs for debug builds.
            'if the password is not correct, an exception will be throw and swallowed
#If DEBUG Then
            Application.NotificationMessageBox("Cryptographic Error", String.Format("A Cryptographic error occurred: {0}", e.Message))
#End If

        Catch e As UnauthorizedAccessException

#If DEBUG Then
            Application.NotificationMessageBox("File Error", String.Format("A File error occurred: {0}", e.Message))
#End If

        Catch e As Exception

#If DEBUG Then
            Application.NotificationMessageBox("Error", String.Format("A error occurred: {0}", e.Message))
#End If

        End Try

        Return Nothing
    End Function

    Private Shared Function EncryptToFile(ByVal objDataBase As DataBase) As Boolean

        Dim bolExceptionOccurred As Boolean = False

        Try
            Using fs As FileStream = File.Open(Application.DataFileName & "temp", FileMode.OpenOrCreate, FileAccess.Write)
                Using objCryptoStream As New CryptoStream(fs, CreateTripleDESTransform(CryptoStreamMode.Write), CryptoStreamMode.Write)
                    Using ms As New MemoryStream

                        Dim bf As New BinaryFormatter
                        bf.Serialize(ms, objDataBase)
                        ms.Position = 0

                        Dim msBytes() As Byte = ms.ToArray
                        objCryptoStream.Write(msBytes, 0, msBytes.Length)
                        'insurance policy
                        fs.Flush()
                    End Using
                End Using
            End Using

            If File.Exists(Application.DataFileName) Then
                File.Delete(Application.DataFileName)
            End If

            File.Move(Application.DataFileName & "temp", Application.DataFileName)

        Catch e As CryptographicException
            bolExceptionOccurred = True
            Application.NotificationMessageBox("Cryptographic Error", String.Format("A Cryptographic error occurred: {0}", e.Message))

        Catch e As UnauthorizedAccessException
            bolExceptionOccurred = True
            Application.NotificationMessageBox("File Error", String.Format("A File error occurred: {0}", e.Message))

        Catch e As Exception
            bolExceptionOccurred = True
            Application.NotificationMessageBox("Error", String.Format("A error occurred: {0}", e.Message))
        End Try

        Return Not bolExceptionOccurred
    End Function

    Public Shared Function Exists() As Boolean
        Return System.IO.File.Exists(Application.DataFileName)
    End Function

    Public Function GetCardType(ByVal strCardTypeName As String) As CardType
        _strCardTypeName = strCardTypeName
        Return CardTypes.Find(New Predicate(Of CardType)(AddressOf Contains))
    End Function

    Public Shared Function Load() As DataBase
        Return DecryptFile()
    End Function

    Public Function Save() As Boolean
        Return EncryptToFile(Me)
    End Function

#End Region

End Class
