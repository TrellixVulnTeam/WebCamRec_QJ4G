Public Class ImgStreamer
    Public OutputWindows As List(Of PictureBox)
    Public Running As Boolean = False
    Public FrameCapture As Bitmap
    Public Sub RelayToOutputWindows()
        For Each Window As PictureBox In Me.OutputWindows
            If Not IsNothing(Window.Image) Then
                Window.Image.Dispose()
            End If

            Window.Image = Me.FrameCapture.Clone

        Next
    End Sub
    Public Sub AddOutputWindow(OutputWindow As PictureBox)
        Me.OutputWindows.Add(OutputWindow)
    End Sub
    Public Sub RemoveOutputWindow(OutputWindow As PictureBox)
        Me.OutputWindows.Remove(OutputWindow)
    End Sub
End Class
