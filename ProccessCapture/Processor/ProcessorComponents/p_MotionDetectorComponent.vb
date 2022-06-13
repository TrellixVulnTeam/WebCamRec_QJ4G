Public Class p_MotionDetectorComponent
    Inherits ProcessorComponent
    Private StepValue As Integer
    Private PrecisionValue As Integer
    Private BufferCreated As Boolean
    Private Buffer As Bitmap
    Private DetectedPoints As List(Of Point)
    Sub New(StepValue As Integer, PrecisionValue As Integer)
        Me.StepValue = StepValue
        Me.PrecisionValue = PrecisionValue
        Me.DetectedPoints = New List(Of Point)
    End Sub
    Public Overrides Sub OnProcess(ImageIn As Bitmap)
        Me.DetectedPoints.Clear()
        If Me.BufferCreated = False Then
            Me.BufferCreated = True
            Me.Buffer = ImageIn.Clone
        Else
            '==MAIN==
            For i = Me.StepValue To ImageIn.Width - Me.StepValue Step Me.StepValue
                For j = Me.StepValue To ImageIn.Height - Me.StepValue Step Me.StepValue

                    Dim ImageColor As Color = ImageIn.GetPixel(i, j)
                    Dim BufferColor As Color = Me.Buffer.GetPixel(i, j)

                    Dim ImageRGBAvr As Byte = (CInt(ImageColor.R) + CInt(ImageColor.G) + CInt(ImageColor.B)) / 3
                    Dim BufferRGBAvr As Byte = (CInt(BufferColor.R) + CInt(BufferColor.G) + CInt(BufferColor.B)) / 3

                    Dim Difference As Integer = Math.PositiveDifference(ImageRGBAvr, BufferRGBAvr)
                    If Difference > Me.PrecisionValue Then
                        Me.DetectedPoints.Add(New Point(i, j))
                    End If
                Next
            Next
            Me.Buffer.Dispose()
            Me.Buffer = ImageIn.Clone
        End If
    End Sub
    Public Overrides Sub Draw(ByRef ImageIn As Bitmap)
        Using g As Graphics = Graphics.FromImage(ImageIn)
            For Each P As Point In Me.DetectedPoints
                DrawCircle(g, P.X, P.Y, Me.StepValue / 4)
            Next

            g.DrawString("Motion Points Detected: " & Me.DetectedPoints.Count,
                         New Font("Arial", Constants.DataComponentTextSize), Brushes.Purple, New Point(10, Constants.DataComponentTextSize * 5))
        End Using
    End Sub
    Private Sub DrawCircle(ByRef g As Graphics, x As Integer, y As Integer, r As Integer)
        g.FillEllipse(Brushes.Purple, x - r, y - r, r * 2, r * 2)
    End Sub
    '=============================================

End Class
