Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class DeepCopy
    Public Shared Function Make(Of T)(ByVal objToClone As Object) As T
        Using ms As New MemoryStream

            Dim bf As New BinaryFormatter
            bf.Serialize(ms, objToClone)
            ms.Position = 0
            Return CType(bf.Deserialize(ms), T)
        End Using
    End Function

End Class
