Public Class AnotacionDummy
    Public tipo As String
    Public fuenteLabel As String
    Public tamanioLabel As Double
    Public tieneHalo As Boolean
    Public negrilla As String

    Public Sub New(tipotest As String)

        If tipotest = "Titular" Then
            tipo = tipotest
            fuenteLabel = "Arial"
            tamanioLabel = 16
            tieneHalo = False
            negrilla = True

        ElseIf tipotest = "General_depto" Then
            tipo = tipotest
            fuenteLabel = "Century Gothic"
            tamanioLabel = 10
            tieneHalo = False
            negrilla = False

        ElseIf tipotest = "General_mupio" Then
            tipo = tipotest
            fuenteLabel = "Century Gothic"
            tamanioLabel = 5
            tieneHalo = False
            negrilla = False

        ElseIf tipotest = "Capital" Then
            tipo = tipotest
            fuenteLabel = "Century Gothic"
            tamanioLabel = 12
            tieneHalo = False
            negrilla = False

        ElseIf tipotest = "Drenaje" Then
            tipo = "tipotest"
            fuenteLabel = "Arial"
            tamanioLabel = 6
            tieneHalo = False
            negrilla = False
        End If
    End Sub

End Class
