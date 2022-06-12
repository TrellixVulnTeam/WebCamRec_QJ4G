Public Class Form1

    Private ImageProcessor As Processor

    Private OutputWindow As PictureBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Hide()

        Me.ImageProcessor = New Processor

        'Statistics - Pink
        'Sub Components - Purple
        'Main Components - Red + Green

        Me.ImageProcessor.AddComponent(New p_MotionDetectorComponent(20, 20))
        Me.ImageProcessor.AddComponent(New p_TimeComponent)
        Me.ImageProcessor.AddComponent(New p_LatencyComponent)

        Me.ImageProcessor.AddComponent(New p_FaceMeshComponent)

        Me.OutputWindow = New PictureBox
        Me.OutputWindow.Size = Me.ClientSize
        Me.OutputWindow.BorderStyle = BorderStyle.FixedSingle
        Me.OutputWindow.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Controls.Add(Me.OutputWindow)
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.ImageProcessor.Camera.AddOutputWindow(Me.OutputWindow)

        Me.ImageProcessor.Camera.StartFeed()

        Me.Show()

    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.ImageProcessor.Camera.EndFeed()
        Application.Exit()
    End Sub
End Class
