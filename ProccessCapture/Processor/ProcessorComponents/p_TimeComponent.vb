Public Class p_TimeComponent
    Inherits ProcessorComponent
    Public Overrides Sub OnProcess(ImageIn As Bitmap)
    End Sub
    Public Overrides Sub Draw(ByRef ImageIn As Bitmap)
        Using g As Graphics = Graphics.FromImage(ImageIn)
            g.DrawString("Time: " & DateTime.Now, New Font("Arial", Constants.DataComponentTextSize),
                        Brushes.Pink, New Point(10, Constants.DataComponentTextSize * 1))
        End Using
    End Sub
End Class
