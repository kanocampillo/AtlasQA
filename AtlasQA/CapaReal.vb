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

Public Class CapaReal
    Public capa As ILayer
    Public nombre As String
    Public transparencia As Double
    Public colorRelleno As String
    Public colorBorde As String
    Public grosorBorde As Double
    Public labelVisible As Boolean
    Public fuenteLabel As String
    Public tamanioLabel As Double
    Public tieneHalo As Boolean
    Public negrilla As String
    Public activo As Boolean
    Public tamanioPunto As Double
    Public colorPunto As String
    Public Sub New(nuevaCapa As ILayer, name As String, indiceRender As Integer)
        capa = nuevaCapa
        nombre = name ' nombre
        'MsgBox(nombre)
        Dim layereffects As ILayerEffects = capa
        transparencia = layereffects.Transparency.ToString() ' transparencia
        If TypeOf capa Is IGeoFeatureLayer Then
            Dim capaFea As IGeoFeatureLayer = capa
            Dim renderTest As IFeatureRenderer = capaFea.Renderer
            Dim renderer As IFeatureRenderer

            If TypeOf renderTest Is ISimpleRenderer Then
                renderer = capaFea.Renderer
                Dim renderer1 As New SimpleRenderer()
                renderer1 = renderer
                llenaAtributosVector(renderer1.Symbol, capaFea, capa)

            ElseIf TypeOf renderTest Is IUniqueValueRenderer Then
                renderer = capaFea.Renderer
                Dim renderer2 As New UniqueValueRenderer()
                renderer2 = renderer
                llenaAtributosVector(renderer2.Symbol(renderer2.Value(indiceRender)), capaFea, capa) ' obtiene el indice de el primer elemento del unique value
            End If

        ElseIf TypeOf capa Is IAnnotationLayer Then ' esto es si la capa es del tipo anotación
            llenaAtaributosAnotacion(capa)
        End If
    End Sub

    Private Sub llenaAtributosVector(psimbolo As ISymbol, capaFea As IGeoFeatureLayer, capa As ILayer)
        If TypeOf psimbolo Is IFillSymbol Then ' si la capa es de tipo poligono ##############
            'MsgBox("entro")
            Dim colRgb As IRgbColor = New RgbColorClass()

            Dim simbolo As IFillSymbol = psimbolo
            If TypeOf simbolo.Color Is IRgbColor Then
                Dim colRelleno As IRgbColor = simbolo.Color
                If Not colRelleno.NullColor Then
                    colorRelleno = "RGB_" & colRelleno.Red.ToString() & "_" & colRelleno.Green.ToString() & "_" & colRelleno.Blue.ToString() ' color borde rgb
                Else
                    colorRelleno = "nd"
                End If

            ElseIf TypeOf simbolo.Color Is IHsvColor Then
                Dim colRelleno As IHsvColor = simbolo.Color
                If Not colRelleno.NullColor Then
                    colRgb.RGB = colRelleno.RGB
                    colorRelleno = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                Else
                    colorRelleno = "nd"
                End If

            ElseIf TypeOf simbolo.Color Is ICmykColor Then
                Dim colRelleno As ICmykColor = simbolo.Color
                If Not colRelleno.NullColor Then
                    colRgb.RGB = colRelleno.RGB
                    colorRelleno = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                Else
                    colorRelleno = "nd"
                End If
            End If

            Dim outline As ILineSymbol = simbolo.Outline
            grosorBorde = outline.Width.ToString() ' grosor borde
            colorPunto = "nd" 'color punto
            tamanioPunto = 0 ' tamaño punto

            If TypeOf outline.Color Is IRgbColor Then
                Dim colBorde As IRgbColor = outline.Color
                If Not colBorde.NullColor Then
                    colorBorde = "RGB_" & colBorde.Red.ToString() & "_" & colBorde.Green.ToString() & "_" & colBorde.Blue.ToString() ' color borde rgb
                    grosorBorde = outline.Width.ToString() ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            ElseIf TypeOf outline.Color Is IHsvColor Then
                Dim colBorde As IHsvColor = outline.Color
                If Not colBorde.NullColor Then
                    colRgb.RGB = colBorde.RGB
                    colorBorde = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                    grosorBorde = outline.Width.ToString() ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            ElseIf TypeOf outline.Color Is ICmykColor Then
                Dim colBorde As ICmykColor = outline.Color
                If Not colBorde.NullColor Then
                    colRgb.RGB = colBorde.RGB
                    colorBorde = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                    grosorBorde = outline.Width.ToString() ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            End If


        ElseIf TypeOf psimbolo Is ILineSymbol Then ' si la capa es de tipo linea ##############
            Dim simbololinea As ILineSymbol = psimbolo
            Dim colRgb As IRgbColor = New RgbColorClass()

            If TypeOf simbololinea.Color Is IRgbColor Then
                Dim colBorde As IRgbColor = simbololinea.Color
                If Not colBorde.NullColor Then
                    colorBorde = "RGB_" & colBorde.Red.ToString() & "_" & colBorde.Green.ToString() & "_" & colBorde.Blue.ToString() ' color borde rgb
                    grosorBorde = simbololinea.Width ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            ElseIf TypeOf simbololinea.Color Is IHsvColor Then
                Dim colBorde As IHsvColor = simbololinea.Color
                If Not colBorde.NullColor Then
                    colRgb.RGB = colBorde.RGB
                    colorBorde = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                    grosorBorde = simbololinea.Width ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            ElseIf TypeOf simbololinea.Color Is ICmykColor Then
                Dim colBorde As ICmykColor = simbololinea.Color
                If Not colBorde.NullColor Then
                    colRgb.RGB = colBorde.RGB
                    colorBorde = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb
                    grosorBorde = simbololinea.Width ' grosor borde
                Else
                    colorBorde = "nd"
                    grosorBorde = 0
                End If
            End If

            colorPunto = "nd" 'color punto
            tamanioPunto = 0 ' tamaño punto
            colorRelleno = "nd" ' color relleno



        ElseIf TypeOf psimbolo Is IMarkerSymbol Then ' si la capa es de tipo punto  ##############
            Dim simboloPunto As IMarkerSymbol = psimbolo
            Dim colRgb As IRgbColor = New RgbColorClass()

            If TypeOf simboloPunto.Color Is IRgbColor Then
                Dim colBorde As IRgbColor = simboloPunto.Color
                colorPunto = "RGB_" & colBorde.Red.ToString() & "_" & colBorde.Green.ToString() & "_" & colBorde.Blue.ToString() ' color punto rgb
            ElseIf TypeOf simboloPunto.Color Is IHsvColor Then
                Dim colBorde As IHsvColor = simboloPunto.Color
                colRgb.RGB = colBorde.RGB
                colorPunto = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb

            ElseIf TypeOf simboloPunto.Color Is ICmykColor Then
                Dim colBorde As ICmykColor = simboloPunto.Color
                colRgb.RGB = colBorde.RGB
                colorPunto = "RGB_" & colRgb.Red.ToString() & "_" & colRgb.Green.ToString() & "_" & colRgb.Blue.ToString() ' color borde rgb

            End If

            tamanioPunto = simboloPunto.Size ' tamaño punto
            colorRelleno = "nd" ' color relleno
            grosorBorde = 0 ' grosor borde
            colorBorde = "nd" ' color borde

        End If
        Dim pAnnotateLayerPropertiesCollection As IAnnotateLayerPropertiesCollection2
        pAnnotateLayerPropertiesCollection = capaFea.AnnotationProperties

        Dim pAnnotateLayerProperties As IAnnotateLayerProperties
        Dim id As Long
        pAnnotateLayerPropertiesCollection.QueryItem(0, pAnnotateLayerProperties, id)
        labelVisible = capaFea.DisplayAnnotation 'visibilidad del label
        Dim labelen2 As ILabelEngineLayerProperties2 = pAnnotateLayerProperties
        Dim sim As ITextSymbol = labelen2.Symbol
        Dim halo As IMask = labelen2.Symbol
        tamanioLabel = sim.Size.ToString() ' tamanioLabel
        Dim myfont As stdole.IFontDisp = sim.Font
        negrilla = sim.Font.Bold.ToString() ' negrilla
        fuenteLabel = myfont.Name.ToString() ' fuente label
        If halo.MaskStyle.ToString() = "esriMSNone" Then
            tieneHalo = False
        Else
            tieneHalo = True
        End If
        activo = capa.Visible ' Visible

    End Sub

    Private Sub llenaAtaributosAnotacion(capa As ILayer)
        activo = capa.Visible ' Visible
        colorRelleno = "nd" ' color de relleno
        colorBorde = "nd" ' color de borde
        grosorBorde = 0 ' grosor de borde 
        colorPunto = "nd" 'color punto
        tamanioPunto = 0 ' tamaño punto
        Dim player As IFeatureLayer = capa
        Dim annotaclassext As IAnnotationClassExtension = player.FeatureClass.Extension
        Dim pAnnotateLayerPropertiesCollection As IAnnotateLayerPropertiesCollection2 = annotaclassext.AnnoProperties
        Dim pAnnotateLayerProperties As IAnnotateLayerProperties
        Dim id As Long
        pAnnotateLayerPropertiesCollection.QueryItem(0, pAnnotateLayerProperties, id)
        labelVisible = activo 'visibilidad del label
        Dim labelen2 As ILabelEngineLayerProperties2 = pAnnotateLayerProperties
        Dim sim As ITextSymbol = labelen2.Symbol
        Dim halo As IMask = labelen2.Symbol
        tamanioLabel = sim.Size.ToString() ' tamanioLabel
        Dim myfont As stdole.IFontDisp = sim.Font
        fuenteLabel = myfont.Name.ToString() ' fuente label
        negrilla = sim.Font.Bold.ToString() ' negrilla
        If halo.MaskStyle.ToString() = "esriMSNone" Then
            tieneHalo = False
        Else
            tieneHalo = True
        End If

    End Sub

    Public Function imprAtributos() As String
        Dim atributos As String
        atributos = "Nombre: " & nombre.ToString() & " " &
            "Está activa: " & activo.ToString() & " " &
            "Tiene negrilla: " & tieneHalo.ToString() & " " &
            "Transparencia: " & transparencia.ToString() & " " &
            "Color relleno: " & colorRelleno.ToString() & " " &
            "Color borde: " & colorBorde.ToString() & " " &
            "Label activo: " & labelVisible.ToString() & " " &
            "Grosor borde: " & grosorBorde.ToString() & " " &
            "Fuente label: " & fuenteLabel.ToString() & " " &
            "Tamaño label: " & tamanioLabel.ToString() & " " &
            "Tiene Halo: " & tieneHalo.ToString() & " " &
            "Tiene negrilla: " & tieneHalo.ToString()

        Return atributos
    End Function

End Class
