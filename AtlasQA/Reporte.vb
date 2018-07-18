Imports System.IO

Public Class Reporte
    Public ruta As String
    Public Sub New(folder As String)
        Dim strFile As String = folder & "\Reporte_atlas" & Date.Now.ToString().Replace(" ", "_").Replace("/", "").Replace(".", "").Replace(":", "_")
        ruta = strFile & ".txt"
    End Sub

    Public Sub escribir(mensaje As String)
        Using sw As New StreamWriter(File.Open(ruta, FileMode.OpenOrCreate))
            sw.WriteLine(mensaje)
        End Using
    End Sub


End Class
