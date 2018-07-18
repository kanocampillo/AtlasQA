
Public Class CapaDummy
    Public nombre As String
    Public activo As Boolean
    Public transparencia As Double
    Public colorRelleno As String
    Public colorBorde As String
    Public grosorBorde As Double
    Public labelVisible As Boolean
    Public fuenteLabel As String
    Public tamanioLabel As Double
    Public tieneHalo As Boolean
    Public negrilla As String
    Public tamanioPunto As Double
    Public colorPunto As String

    Public Sub cambiaNombre(nuevo_nombre As String)
        nombre = nuevo_nombre
    End Sub
    Public Sub cambiaLabel(value As Boolean)
        labelVisible = value
    End Sub


End Class
