Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geodatabase
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.esriSystem
Imports System.IO

Public Class frmMenu
    Public entidad_titular As String = ""

    Public Function comparaCapa(capaDummy As CapaDummy, capaReal As CapaReal)
        Dim mensajeError As String = ""

        If capaDummy.activo <> capaReal.activo Then
            mensajeError = mensajeError & "la visibilidad de la capa deberia ser : " & capaDummy.activo.ToString() & " y es : " &
                capaReal.activo.ToString() & vbNewLine
        End If
        If capaDummy.transparencia <> capaReal.transparencia Then
            mensajeError = mensajeError & "la transparencia de la capa deberia ser de : " & capaDummy.transparencia.ToString() & " y es : " &
                capaReal.transparencia.ToString() & vbNewLine
        End If

        If capaDummy.colorRelleno <> capaReal.colorRelleno Then
            mensajeError = mensajeError & "El color de relleno de la capa deberia ser de : " & capaDummy.colorRelleno.ToString() & " y es : " &
                capaReal.colorRelleno.ToString() & vbNewLine
        End If

        If capaDummy.colorBorde <> capaReal.colorBorde Then
            mensajeError = mensajeError & "El color del borde de la capa deberia ser de : " & capaDummy.colorBorde.ToString() & " y es : " &
                capaReal.colorBorde.ToString() & vbNewLine
        End If

        If capaDummy.grosorBorde <> capaReal.grosorBorde Then
            mensajeError = mensajeError & "El grosor del borde de la capa deberia ser de : " & capaDummy.grosorBorde.ToString() & " y es : " &
                capaReal.grosorBorde.ToString() & vbNewLine
        End If

        If capaDummy.labelVisible <> capaReal.labelVisible Then
            mensajeError = mensajeError & "la visibilidad del label de la capa deberia ser : " & capaDummy.labelVisible.ToString() & " y es : " &
                capaReal.labelVisible.ToString() & vbNewLine
        End If

        If capaDummy.fuenteLabel <> capaReal.fuenteLabel And capaDummy.labelVisible Then
            mensajeError = mensajeError & "La fuente del label de la capa deberia ser de : " & capaDummy.fuenteLabel.ToString() & " y es : " &
                capaReal.fuenteLabel.ToString() & vbNewLine
        End If

        If capaDummy.tamanioLabel <> capaReal.tamanioLabel And capaDummy.labelVisible Then
            mensajeError = mensajeError & "El tamaño del label de la capa deberia ser de : " & capaDummy.tamanioLabel.ToString() & " y es : " &
                capaReal.tamanioLabel.ToString() & vbNewLine
        End If

        If capaDummy.tieneHalo <> capaReal.tieneHalo And capaDummy.labelVisible Then
            mensajeError = mensajeError & "La existencia del halo deberia ser : " & capaDummy.tieneHalo.ToString() & " y es : " &
                capaReal.tieneHalo.ToString() & vbNewLine
        End If

        If capaDummy.negrilla <> capaReal.negrilla And capaDummy.labelVisible Then
            mensajeError = mensajeError & "La existencia de negrilla deberia ser : " & capaDummy.negrilla.ToString() & " y es : " &
                capaReal.negrilla.ToString() & vbNewLine
        End If
        If capaDummy.tamanioPunto <> capaReal.tamanioPunto Then
            mensajeError = mensajeError & "El tamaño del punto deberia ser : " & capaDummy.tamanioPunto.ToString() & " y es : " &
                capaReal.tamanioPunto.ToString() & vbNewLine
        End If
        If capaDummy.colorPunto <> capaReal.colorPunto Then
            mensajeError = mensajeError & "El color del punto deberia ser : " & capaDummy.colorPunto.ToString() & " y es : " &
                capaReal.colorPunto.ToString() & vbNewLine
        End If
        If mensajeError = "" Then
            mensajeError = "los atributos de la capa " & capaReal.nombre & " corresponden completamente con los atributos de la capa definida" & vbNewLine
        End If
        Return mensajeError

    End Function

    Public Function comparaAnotacion(AnotDummy As AnotacionDummy, AnotReal As AnotacionReal)
        Dim mensajeError As String = ""

        If AnotDummy.fuenteLabel <> AnotReal.fuenteLabel Then
            mensajeError = mensajeError & "La fuente del label de la capa deberia ser de : " & AnotDummy.fuenteLabel.ToString() & " y es : " &
                AnotReal.fuenteLabel.ToString() & vbNewLine
        End If

        If AnotDummy.tamanioLabel <> AnotReal.tamanioLabel Then
            mensajeError = mensajeError & "El tamaño del label de la capa deberia ser de : " & AnotDummy.tamanioLabel.ToString() & " y es : " &
                AnotReal.tamanioLabel.ToString() & vbNewLine
        End If

        If AnotDummy.tieneHalo <> AnotReal.tieneHalo Then
            mensajeError = mensajeError & "La existencia del halo deberia ser : " & AnotDummy.tieneHalo.ToString() & " y es : " &
                AnotReal.tieneHalo.ToString() & vbNewLine
        End If

        If AnotDummy.negrilla <> AnotReal.negrilla Then
            mensajeError = mensajeError & "La existencia de negrilla deberia ser : " & AnotDummy.negrilla.ToString() & " y es : " &
                AnotReal.negrilla.ToString() & vbNewLine
        End If

        If mensajeError = "" Then
            mensajeError = "los atributos de la anotación " & AnotReal.texto & " corresponden completamente con los atributos de la capa definida" & vbNewLine
        End If
        Return mensajeError

    End Function
    Public Sub ValidaEntidad(capa As ILayer, listaDummys As CreaCapas, listaEntidades As List(Of String))
        If ValidaNombre(capa, listaEntidades) Then
            For i As Integer = 0 To listaDummys.lista_Dummys.Count - 1
                If listaDummys.lista_Dummys(i).nombre = "Departamento titular" Then
                    listaDummys.lista_Dummys(i).cambiaNombre(capa.Name)
                    ValidaLabel(listaDummys.lista_Dummys(i), capa)

                ElseIf listaDummys.lista_Dummys(i).nombre = "Departamento titular" Then

                End If
            Next
        End If
    End Sub

    Public Sub ValidaVisibilidadLabel(capa As ILayer, listaDummys As CreaCapas)
        'MsgBox("ENtré")

        For i As Integer = 0 To listaDummys.lista_Dummys.Count - 1
            If capa.Name = "Capital" Then
                If listaDummys.lista_Dummys(i).nombre = "Capital" Then
                    'MsgBox("Capaital")
                    ValidaLabel(listaDummys.lista_Dummys(i), capa)
                End If

            ElseIf capa.Name = "DEPARTAMENTOS_AREA_OFICIAL" Then
                If listaDummys.lista_Dummys(i).nombre = "DEPARTAMENTOS_AREA_OFICIAL" Then
                    ValidaLabel(listaDummys.lista_Dummys(i), capa)
                    'MsgBox("DEPARTAMENTOS_AREA_OFICIAL")
                End If

            ElseIf capa.Name = "Municipio_Nuevo" Then
                If listaDummys.lista_Dummys(i).nombre = "Municipio_Nuevo" Then
                    'MsgBox("Municipio_Nuevo")
                    ValidaLabel(listaDummys.lista_Dummys(i), capa)
                End If

            End If
        Next
    End Sub

    Public Sub ValidaLabel(capaDummy As CapaDummy, layer As ILayer) 'cambia en la capa dummy la visualización del label para evaluar o label o anotacion
        If TypeOf layer Is IGeoFeatureLayer Then
            Dim capaFea As IGeoFeatureLayer = layer
            If capaFea.DisplayAnnotation Then
                capaDummy.cambiaLabel(True)
            Else
                capaDummy.cambiaLabel(False)
            End If
            'MsgBox(capaDummy.nombre & " # " & capaDummy.labelVisible)
        End If
    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("hola")
        If System.IO.Directory.Exists(Me.TBFolder.Text) Then ' si el directorio seleccionado existe
            Dim mensajeError As String = ""
            Dim pMxdocument As IMxDocument = My.ArcMap.Document
            Dim pMap As IMap = pMxdocument.FocusMap
            Dim reporte As New Reporte(Me.TBFolder.Text)
            Dim listaDummys As New CreaCapas() '########### acá se crean las capas dummy Capas Dummy #########
            Dim listaReales As New List(Of CapaReal)

            Dim mensajes As New List(Of String)
            Dim capasDefinidas As New List(Of String)
            Dim capasNoDefinidas As New List(Of String)
            Dim entidad As New EntidadT()
            Dim listaDeptos As List(Of String) = entidad.listaDeptos()
            Dim listaMupios As List(Of String) = entidad.listaMupios()
            Dim listaEntidades As List(Of String) = listaDeptos
            listaEntidades.AddRange(listaMupios)

            Dim pEnumLayer As IEnumLayer = pMap.Layers
            pEnumLayer.Reset()

            Dim baselayertest As ILayer = pEnumLayer.Next
            Dim list_pivote As New List(Of String)
            list_pivote.Add(baselayertest.Name)


            Do While Not baselayertest Is Nothing And Not list_pivote.Contains("Default")
                If (TypeOf baselayertest Is IFeatureLayer) Then
                    Dim arrPivo As New List(Of String)
                    arrPivo.Add(baselayertest.Name)
                    If entidad_titular <> "" And Not arrPivo.Contains("(") Then
                        entidad_titular = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(baselayertest.Name.ToLower())
                    End If
                    If TypeOf baselayertest Is IGeoFeatureLayer Then
                        Dim capaFeatest As IGeoFeatureLayer = baselayertest
                        Dim renderTesttest As IFeatureRenderer = capaFeatest.Renderer
                        Dim renderertest As IFeatureRenderer
                        If TypeOf renderTesttest Is IUniqueValueRenderer Then
                            renderertest = capaFeatest.Renderer
                            Dim renderer2test As New UniqueValueRenderer()
                            renderer2test = renderertest
                            For q As Integer = 0 To renderer2test.ValueCount - 1
                                Dim nombretemp As String = baselayertest.Name & "---" & renderer2test.Value(q)
                                capasNoDefinidas.Add(nombretemp)
                            Next
                        Else
                            capasNoDefinidas.Add(baselayertest.Name)
                        End If
                    End If
                End If
                baselayertest = pEnumLayer.Next
            Loop

            Dim pEnumLayer1 As IEnumLayer = pMap.Layers
            pEnumLayer.Reset()
            Dim baselayer As ILayer = pEnumLayer1.Next
            Dim list_pivote1 As New List(Of String)
            list_pivote1.Add(baselayer.Name)

            Do While Not baselayer Is Nothing And Not list_pivote1.Contains("Default")
                If (TypeOf baselayer Is IFeatureLayer) Then

                    If TypeOf baselayer Is IGeoFeatureLayer Then
                        Dim capaFea As IGeoFeatureLayer = baselayer
                        Dim renderTest As IFeatureRenderer = capaFea.Renderer
                        Dim renderer As IFeatureRenderer

                        If TypeOf renderTest Is ISimpleRenderer Then
                            ' aqui se crea la capa nueva para cuando es renderer sencillo
                            Dim capa As New CapaReal(baselayer, capaFea.Name, 0)
                            listaReales.Add(capa)

                            ValidaEntidad(baselayer, listaDummys, listaDeptos) 'asigna el departamento por el nombre a la copa dummy de deptos
                            ValidaVisibilidadLabel(baselayer, listaDummys) ' valida si el label está activo para avaluar anotaciones o labels

                            For j As Integer = 0 To listaDummys.lista_Dummys.Count - 1
                                If capa.nombre = listaDummys.lista_Dummys(j).nombre Then
                                    capasDefinidas.Add(capa.nombre)
                                    mensajes.Add(vbNewLine & "########## " & capa.nombre & " ##########" & vbNewLine &
                                    comparaCapa(listaDummys.lista_Dummys(j), capa))
                                End If
                            Next

                        ElseIf TypeOf renderTest Is IUniqueValueRenderer Then
                            renderer = capaFea.Renderer
                            Dim renderer2 As New UniqueValueRenderer()
                            renderer2 = renderer
                            For j As Integer = 0 To renderer2.ValueCount - 1
                                Dim capa As New CapaReal(baselayer, baselayer.Name & "---" & renderer2.Value(j), j)
                                listaReales.Add(capa)
                                ValidaEntidad(baselayer, listaDummys, listaDeptos) 'asigna el departamento por el nombre a la copa dummy de deptos
                                ValidaVisibilidadLabel(baselayer, listaDummys) ' valida si el label está activo para avaluar anotaciones o labels

                                For k As Integer = 0 To listaDummys.lista_Dummys.Count - 1
                                    If capa.nombre = listaDummys.lista_Dummys(k).nombre Then
                                        capasDefinidas.Add(capa.nombre)
                                        mensajes.Add(vbNewLine & "########## " & capa.nombre & " ##########" & vbNewLine &
                                        comparaCapa(listaDummys.lista_Dummys(k), capa))

                                    End If
                                Next

                            Next

                        End If
                    End If
                End If
                baselayer = pEnumLayer.Next
            Loop

            For i As Integer = 0 To listaReales.Count - 1
                Dim baselayer2 As CapaReal = listaReales(i)
                For j As Integer = 0 To capasDefinidas.Count - 1
                    If baselayer2.nombre = capasDefinidas(j) Then
                        capasNoDefinidas.Remove(capasDefinidas(j))
                    End If
                Next
            Next

            If ChBNodefinidos.Checked Then ' reporta los valores no revisados

                For i As Integer = 0 To capasNoDefinidas.Count - 1
                    mensajes.Add(vbNewLine & "########## " & capasNoDefinidas(i) & " ##########" & vbNewLine &
                                        "La capa no fue evaluada por no estar definida" & vbNewLine)
                Next

            End If


            For i As Integer = 0 To listaDummys.lista_Dummys.Count - 1 'almacena la entidad titular para emplearla en las anotaciones
                If listaEntidades.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(listaDummys.lista_Dummys(i).nombre.ToLower())) Then
                    entidad_titular = listaDummys.lista_Dummys(i).nombre
                End If
            Next
            validaAnotaciones(pMxdocument, listaDeptos, listaMupios, mensajes) ' Valida todas las anotaciones

            Dim mensajesUniq As New List(Of String) 'elimina los valores unicos

            For k As Integer = 0 To mensajes.Count - 1
                If Not mensajesUniq.Contains(mensajes(k)) Then
                    mensajesUniq.Add(mensajes(k))
                End If
            Next

            mensajeError = String.Join("", mensajesUniq)
            reporte.escribir(mensajeError)
            MsgBox("¡Reporte generado con éxito!")
            Process.Start(reporte.ruta)
            My.ArcMap.Application.CurrentTool = Nothing
        Else
            MsgBox("¡El directorio seleccionado no existe!")
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            Me.TBFolder.Text = Me.FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Public Function ValidaNombre(capa As ILayer, listado As List(Of String)) As Boolean

        If listado.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(capa.Name.ToLower())) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function ValidaTexto_Anotacion(textoAnotacion As String, listado As List(Of String)) As Boolean

        Dim ArrQuery As String = textoAnotacion
        If listado.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ArrQuery.ToLower())) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub validaAnotaciones(documento As IMxDocument, deptos As List(Of String), mupios As List(Of String), mensajes As List(Of String))
        Dim mensajeErrorAnotaciones As New List(Of String)
        Dim listaMDeptos As List(Of String) = deptos
        listaMDeptos.AddRange(mupios)
        Dim int32_Counter As Int32 = 0

        Dim pMap As IMap = documento.FocusMap
        Dim pGraphicsContainer As IGraphicsContainer = pMap ' este primer contenedor almacena las anotaciones hechas sobre el mapa 
        pGraphicsContainer.Reset()
        Dim element1 As IElement = pGraphicsContainer.Next()
        While Not element1 Is Nothing
            If TypeOf element1 Is ITextElement Then
                int32_Counter = int32_Counter + 1
                Dim textElemnt As ITextElement = element1
                Dim textSymbol As ITextSymbol = textElemnt.Symbol
                Dim anotacionReal As New AnotacionReal(textSymbol)
                Dim lista_pivote As New List(Of String)

                If lista_pivote.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entidad_titular.ToLower()).Replace(vbNewLine, " ")) Then
                    Dim anotacionDummy As New AnotacionDummy("Titular")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower())) _
                    And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular Then
                    Dim anotacionDummy As New AnotacionDummy("General_depto")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf mupios.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " ")) _
                    And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular _
                    And deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower())) <> False Then
                    Dim anotacionDummy As New AnotacionDummy("General_mupio")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf lista_pivote.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Drenaje".ToLower()).Replace(vbNewLine, " ")) Then
                    Dim anotacionDummy As New AnotacionDummy("Drenaje")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                End If
                lista_pivote.Clear()
            End If
            element1 = pGraphicsContainer.Next()

        End While

        Dim activeView As IActiveView = documento.ActivatedView
        Dim gracont As IGraphicsContainer = activeView.GraphicsContainer
        Dim graphicsContainer As IGraphicsContainer = activeView.GraphicsContainer ' este primer contenedor almacena las anotaciones hechas sobre el layout

        graphicsContainer.Reset()
        Dim element As IElement = graphicsContainer.Next()
        While Not element Is Nothing
            If TypeOf element Is ITextElement Then
                int32_Counter = int32_Counter + 1
                Dim textElemnt As ITextElement = element
                Dim textSymbol As ITextSymbol = textElemnt.Symbol
                Dim anotacionReal As New AnotacionReal(textSymbol)
                Dim lista_pivote As New List(Of String)
                lista_pivote.Add(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()))

                If lista_pivote.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entidad_titular.ToLower()).Replace(vbNewLine, " ")) Then
                    Dim anotacionDummy As New AnotacionDummy("Titular")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " ")) _
                    And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular Then
                    Dim anotacionDummy As New AnotacionDummy("General_depto")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf mupios.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " ")) _
                    And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular _
                    And deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower())) <> True Then
                    Dim anotacionDummy As New AnotacionDummy("General_mupio")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                ElseIf lista_pivote.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Drenaje".ToLower()).Replace(vbNewLine, " ")) Then
                    Dim anotacionDummy As New AnotacionDummy("Drenaje")
                    mensajeErrorAnotaciones.Add(vbNewLine & "########## Anotación " & anotacionReal.texto & " ##########" & vbNewLine &
                        comparaAnotacion(anotacionDummy, anotacionReal))
                End If
                lista_pivote.Clear()
            End If
            element = graphicsContainer.Next()

        End While

        '########################## Valida el grupo de anotaciones por capa
        Dim entidad As New EntidadT()
        Dim dictCapitales As Dictionary(Of String, String) = entidad.dictCapitales()

        For i As Integer = 0 To pMap.LayerCount - 1
            Dim baselayer As ILayer = pMap.Layer(i)
            If (TypeOf baselayer Is IFeatureLayer) Then

                If TypeOf baselayer Is IGeoFeatureLayer Then
                    Dim capaFea As IGeoFeatureLayer = baselayer

                    Dim pAnnotateLayerPropertiesCollection As IAnnotateLayerPropertiesCollection2
                    pAnnotateLayerPropertiesCollection = capaFea.AnnotationProperties
                    Dim pAnnotateLayerProperties As ILabelEngineLayerProperties2
                    Dim id As Long
                    pAnnotateLayerPropertiesCollection.QueryItem(0, pAnnotateLayerProperties, id)
                    Dim textsim As ITextSymbol = pAnnotateLayerProperties.Symbol
                    Dim layer_llave = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase((baselayer.Name.ToLower()))
                    Dim entidad_llave = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase((baselayer.Name.ToLower()))
                    Dim capital_llave As String = ""
                    If dictCapitales.ContainsKey(entidad_llave) Then
                        capital_llave = dictCapitales(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase((entidad_titular.ToLower())))
                    End If

                    If Not capaFea.DisplayAnnotation And textsim.Text <> "" Then
                        Dim anotacionReal As New AnotacionReal(textsim) ' anotacion real
                        Dim lista_pivote As New List(Of String)
                        lista_pivote.Add(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " "))
                        If lista_pivote.Contains(entidad_llave) And textsim.Text.ToUpper() = entidad_titular.ToUpper() Then
                            Dim anotacionDummy As New AnotacionDummy("Titular")
                            mensajeErrorAnotaciones.Add(vbNewLine & "########## Para el Grupo de Anotaciones de la Capa " & capaFea.Name & " ##########" & vbNewLine &
                                comparaAnotacion(anotacionDummy, anotacionReal))
                        ElseIf lista_pivote.Contains(capital_llave) Then
                            Dim anotacionDummy As New AnotacionDummy("Capital")
                            mensajeErrorAnotaciones.Add(vbNewLine & "########## Para el Grupo de Anotaciones de la Capa " & capaFea.Name & " ##########" & vbNewLine &
                                comparaAnotacion(anotacionDummy, anotacionReal))
                        ElseIf deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " ")) _
                            And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular Then
                            Dim anotacionDummy As New AnotacionDummy("General_depto")
                            MsgBox(anotacionReal.texto & "_" & "General_depto")
                            mensajeErrorAnotaciones.Add(vbNewLine & "########## Para el Grupo de Anotaciones de la Capa " & capaFea.Name & " ##########" & vbNewLine &
                                comparaAnotacion(anotacionDummy, anotacionReal))
                        ElseIf mupios.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()).Replace(vbNewLine, " ")) _
                     And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> entidad_titular _
                     And Not deptos.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower())) _
                     And Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(anotacionReal.texto.ToLower()) <> capital_llave Then

                            Dim anotacionDummy As New AnotacionDummy("General_mupio")
                            MsgBox(anotacionReal.texto & "_" & "General_mupio")
                            mensajeErrorAnotaciones.Add(vbNewLine & "########## Para el Grupo de Anotaciones de la Capa " & capaFea.Name & " ##########" & vbNewLine &
                                comparaAnotacion(anotacionDummy, anotacionReal))
                        ElseIf lista_pivote.Contains(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase("Drenaje".ToLower()).Replace(vbNewLine, " ")) Then
                            Dim anotacionDummy As New AnotacionDummy("Drenaje")
                            mensajeErrorAnotaciones.Add(vbNewLine & "########## Para el Grupo de Anotaciones de la Capa " & capaFea.Name & " ##########" & vbNewLine &
                                comparaAnotacion(anotacionDummy, anotacionReal))
                        End If

                    End If
                End If
            End If
        Next

        If mensajeErrorAnotaciones.Count >= 1 Then
            mensajes.AddRange(mensajeErrorAnotaciones)
        End If
    End Sub
End Class