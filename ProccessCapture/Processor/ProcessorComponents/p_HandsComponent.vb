Imports Mediapipe.Net.Calculators
Imports Mediapipe.Net.Framework.Format
Imports Mediapipe.Net.Framework.Protobuf
Public Class p_HandsComponent
    Inherits ProcessorComponent
    Private Calculator As HandCpuCalculator
    Private Landmarks As NormalizedLandmarkList
    Private Converter As ImageConverter
    Sub New()
        Me.Calculator = New HandCpuCalculator
        Me.Converter = New ImageConverter
        Me.Landmarks = New NormalizedLandmarkList
        AddHandler Me.Calculator.OnResult, AddressOf Me.ObtainLandmarks
        Me.Calculator.Run()
    End Sub
    Public Overrides Sub OnProcess(ImageIn As Bitmap)        
        Me.Landmarks.Landmark.Clear()

        '20 = precisionnumber

        'UNRESOLVED !!!

        Dim Frame As New ImageFrame(ImageFormat.Srgb, ImageIn.Width, ImageIn.Height, 20, ImgToByteArr(ImageIn))
        Me.Calculator.Send(Frame)
    End Sub
    Public Overrides Sub Draw(ByRef ImageIn As Bitmap)
        Using g As Graphics = Graphics.FromImage(ImageIn)
            If Me.Landmarks.Landmark.Count > 0 Then
                For i As Integer = 0 To Landmarks.Landmark.Count - 1
                    Dim Landmark As NormalizedLandmark = Landmarks.Landmark(i)
                    DrawCircle(g, Landmark.X, Landmark.Y, 10)
                Next
            End If
        End Using
    End Sub
    Private Sub ObtainLandmarks(sender As Object, landmarks As NormalizedLandmarkList)
        Me.Landmarks = landmarks
    End Sub
    Private Sub DrawCircle(ByRef g As Graphics, x As Integer, y As Integer, r As Integer)
        g.FillEllipse(Brushes.Purple, x - r, y - r, r * 2, r * 2)
    End Sub
    Private Function ImgToByteArr(ImageIn As Bitmap) As Byte()
        Return DirectCast(Me.Converter.ConvertTo(ImageIn, GetType(Byte())), Byte())
    End Function

End Class
