Public Class p_LatencyComponent
    Inherits ProcessorComponent
    Private Ticker As Stopwatch
    Sub New()
        Me.Ticker = New Stopwatch
        Me.Ticker.Start()
    End Sub
    Public Overrides Sub OnProcess(ImageIn As Bitmap)
        Me.Ticker.Restart()
    End Sub
    Public Overrides Sub Draw(ByRef ImageIn As Bitmap)
        Using g As Graphics = Graphics.FromImage(ImageIn)
            g.DrawString("Latency: " & Me.Ticker.Elapsed.TotalMilliseconds.ToString & " m/s",
                         New Font("Arial", Constants.DataComponentTextSize), Brushes.Pink, New Point(10, Constants.DataComponentTextSize * 3))
        End Using
    End Sub
End Class
