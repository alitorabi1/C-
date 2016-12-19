'
<ValueConversion(GetType(String), GetType(Boolean))> Public Class IsAllRecordsConverter
    Implements IValueConverter

    Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert

        If value Is Nothing OrElse String.IsNullOrEmpty(value.ToString) Then
            Return False
        End If

        If value.ToString = Application.STR_ALLRECORDS Then
            Return True

        Else
            Return False
        End If

    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
        Throw New NotSupportedException
    End Function

End Class
