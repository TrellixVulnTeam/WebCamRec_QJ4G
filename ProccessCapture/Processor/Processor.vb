Public Class Processor
    Public Camera As XCamera
    Private Components As List(Of ProcessorComponent)
    Private Filters As List(Of ProcessorFilter) 'TBD
    Private ComponentProcessedCount As Integer
    Sub New()
        Me.Camera = New XCamera
        Me.Components = New List(Of ProcessorComponent)
    End Sub
    Private Sub ComponentProcessEnd()
        Me.ComponentProcessedCount += 1
        If Me.ComponentProcessedCount = Me.Components.Count Then
            Me.ComponentProcessedCount = 0
            Me.UpdateEnd()
        End If
    End Sub
    Private Sub UpdateEnd()
        Me.Camera.RelayToOutputWindows()
    End Sub

    '==================================================
    Public Sub AddComponent(Component As ProcessorComponent)
        Me.Components.Add(Component)
        Component.AddProcessEndHandler(Me.Camera)
        AddHandler Component.OnProcessEnd, AddressOf ComponentProcessEnd
    End Sub
    Public Sub RemoveComponent(Component As ProcessorComponent)
        Me.Components.Remove(Component)
        Component.RemoveProcessEndHandler(Me.Camera)
        RemoveHandler Component.OnProcessEnd, AddressOf ComponentProcessEnd
    End Sub
    Public Sub RemoveComponentAt(index As Integer)
        Dim Component As ProcessorComponent = Me.Components(index)
        Me.Components.RemoveAt(index)
    End Sub
End Class
