Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geodatabase
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem
Imports System.IO
Imports System.Diagnostics
Public Class AnotacionReal
    Public simbolo As ITextSymbol
    Public tipo As String
    Public texto As String
    Public fuenteLabel As String
    Public tamanioLabel As Double
    Public tieneHalo As Boolean
    Public negrilla As String

    Public Sub New(symbolo_text As ITextSymbol)
        simbolo = symbolo_text

        texto = symbolo_text.Text ' texto
        'MsgBox(texto)
        Dim fuente_text As stdole.IFontDisp = symbolo_text.Font
        fuenteLabel = fuente_text.Name.ToString() ' fuente 
        tamanioLabel = fuente_text.Size ' tamaño label
        Dim halo As IMask = symbolo_text
        tamanioLabel = symbolo_text.Size.ToString() ' tamanioLabel
        Dim myfont As stdole.IFontDisp = symbolo_text.Font
        negrilla = symbolo_text.Font.Bold.ToString() ' negrilla
        fuenteLabel = myfont.Name.ToString() ' fuente label
        If halo.MaskStyle.ToString() = "esriMSNone" Then ' tieneHalo
            tieneHalo = False
        Else
            tieneHalo = True
        End If


    End Sub
End Class
