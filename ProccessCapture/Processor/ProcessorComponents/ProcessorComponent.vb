Public MustInherit Class ProcessorComponent
    ' Base Class for all Processor Components
    Public Event OnProcessEnd()
    Public MustOverride Sub OnProcess(ByVal ImageIn As Bitmap)
    Public MustOverride Sub Draw(ByRef ImageIn As Bitmap)
    Public Sub AddProcessEndHandler(CameraLink As XCamera)
        AddHandler CameraLink.OnFrameEnd, AddressOf Me.Process
    End Sub
    Public Sub RemoveProcessEndHandler(CameraLink As XCamera)
        RemoveHandler CameraLink.OnFrameEnd, AddressOf Me.Process
    End Sub
    Public Sub Process(ByRef ImageIn As Bitmap)
        Me.OnProcess(ImageIn)
        Me.Draw(ImageIn)
        RaiseEvent OnProcessEnd()
    End Sub
End Class
