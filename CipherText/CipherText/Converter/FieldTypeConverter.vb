'
<ValueConversion(GetType(FieldType), GetType(Visibility))> Public Class FieldTypeConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert

        If value Is Nothing OrElse Not TypeOf value Is FieldType Then
            Return Visibility.Collapsed
        End If

        If DirectCast(value, FieldType) = FieldType.PasswordPrimary Then
            Return Visibility.Visible

        Else
            Return Visibility.Collapsed
        End If

    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Throw New NotSupportedException
    End Function

End Class
