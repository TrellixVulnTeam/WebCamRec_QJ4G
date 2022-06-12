Public Class Math
    Public Shared Function PositiveDifference(ByVal num1 As Double, ByVal num2 As Double) As Double
        Dim difference As Double
        difference = num1 - num2
        If difference < 0 Then
            difference = difference * -1
        End If
        Return difference
    End Function

End Class
