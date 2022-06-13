Public Class Form1

    Private ImageProcessor As Processor

    Private OutputWindow As PictureBox

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Hide()

        Me.ImageProcessor = New Processor

        'Filters - N/A
        'Statistics - Pink
        'Sub Components - Purple
        'Main Components - Red + Green

        'Order of Computation:

        '1. Main Components

        '2. Sub Components

        '3. Filter Calculations

        '4. Statistics

        '5. Filter Output

        Me.ImageProcessor.AddComponent(New p_FaceMeshComponent)
        Me.ImageProcessor.AddComponent(New p_HandsComponent)

        Me.ImageProcessor.AddComponent(New p_MotionDetectorComponent(20, 20))

        Me.ImageProcessor.AddComponent(New p_TimeComponent)
        Me.ImageProcessor.AddComponent(New p_LatencyComponent)

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
