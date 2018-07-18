Public Class CreaCapas
    Public lista_Dummys As New List(Of CapaDummy)
    Public Sub New()
        Dim CapaDrenaje1MAnno As New CapaDummy
        CapaDrenaje1MAnno.nombre = "Drenaje_1MAnno"
        CapaDrenaje1MAnno.activo = True
        CapaDrenaje1MAnno.transparencia = 0
        CapaDrenaje1MAnno.colorRelleno = "nd"
        CapaDrenaje1MAnno.colorBorde = "nd"
        CapaDrenaje1MAnno.grosorBorde = 0
        CapaDrenaje1MAnno.labelVisible = True
        CapaDrenaje1MAnno.fuenteLabel = "Arial"
        CapaDrenaje1MAnno.tamanioLabel = 6
        CapaDrenaje1MAnno.negrilla = "False"
        CapaDrenaje1MAnno.tieneHalo = False
        CapaDrenaje1MAnno.tamanioPunto = 0
        CapaDrenaje1MAnno.colorPunto = "nd"
        lista_Dummys.Add(CapaDrenaje1MAnno)

        Dim CapaDrenaje1250k As New CapaDummy
        CapaDrenaje1250k.nombre = "Drenaje_1250KAnno"
        CapaDrenaje1250k.activo = True
        CapaDrenaje1250k.transparencia = 0
        CapaDrenaje1250k.colorRelleno = "nd"
        CapaDrenaje1250k.colorBorde = "nd"
        CapaDrenaje1250k.grosorBorde = 0
        CapaDrenaje1250k.labelVisible = True
        CapaDrenaje1250k.fuenteLabel = "Arial"
        CapaDrenaje1250k.tamanioLabel = 6
        CapaDrenaje1250k.negrilla = "False"
        CapaDrenaje1250k.tieneHalo = False
        CapaDrenaje1250k.tamanioPunto = 0
        CapaDrenaje1250k.colorPunto = "nd"
        lista_Dummys.Add(CapaDrenaje1250k)

        Dim CapaDrenaje1M As New CapaDummy
        CapaDrenaje1M.nombre = "Drenaje_1M"
        CapaDrenaje1M.activo = True
        CapaDrenaje1M.transparencia = 0
        CapaDrenaje1M.colorRelleno = "nd"
        CapaDrenaje1M.colorBorde = "RGB_0_92_230"
        CapaDrenaje1M.grosorBorde = 0.6
        CapaDrenaje1M.labelVisible = False
        CapaDrenaje1M.fuenteLabel = "Arial"
        CapaDrenaje1M.tamanioLabel = 8
        CapaDrenaje1M.negrilla = "False"
        CapaDrenaje1M.tieneHalo = False
        CapaDrenaje1M.tamanioPunto = 0
        CapaDrenaje1M.colorPunto = "nd"
        lista_Dummys.Add(CapaDrenaje1M)

        Dim Capital As New CapaDummy
        Capital.nombre = "Capital"
        Capital.activo = True
        Capital.transparencia = 0
        Capital.colorRelleno = "nd"
        Capital.colorBorde = "nd"
        Capital.grosorBorde = 0
        Capital.labelVisible = True
        Capital.fuenteLabel = "Century Gothic"
        Capital.tamanioLabel = 12
        Capital.negrilla = "False"
        Capital.tieneHalo = False
        Capital.tamanioPunto = 8
        Capital.colorPunto = "RGB_0_0_0"
        lista_Dummys.Add(Capital)

        Dim LimiteCoste As New CapaDummy
        LimiteCoste.nombre = "Limite costero"
        LimiteCoste.activo = True
        LimiteCoste.transparencia = 0
        LimiteCoste.colorRelleno = "nd"
        LimiteCoste.colorBorde = "RGB_99_173_207"
        LimiteCoste.grosorBorde = 0.04
        LimiteCoste.labelVisible = False
        LimiteCoste.fuenteLabel = "Arial"
        LimiteCoste.tamanioLabel = 8
        LimiteCoste.negrilla = "False"
        LimiteCoste.tieneHalo = False
        LimiteCoste.tamanioPunto = 0
        LimiteCoste.colorPunto = "nd"
        lista_Dummys.Add(LimiteCoste)

        Dim ViaAtlas As New CapaDummy
        ViaAtlas.nombre = "Via Atlas"
        ViaAtlas.activo = True
        ViaAtlas.transparencia = 0
        ViaAtlas.colorRelleno = "nd"
        ViaAtlas.colorBorde = "RGB_250_52_17"
        ViaAtlas.grosorBorde = 0.6
        ViaAtlas.labelVisible = False
        ViaAtlas.fuenteLabel = "Arial"
        ViaAtlas.tamanioLabel = 8
        ViaAtlas.negrilla = "False"
        ViaAtlas.tieneHalo = False
        ViaAtlas.tamanioPunto = 0
        ViaAtlas.colorPunto = "nd"
        lista_Dummys.Add(ViaAtlas)

        Dim LimiteNacional As New CapaDummy
        LimiteNacional.nombre = "Limite Nacional"
        LimiteNacional.activo = True
        LimiteNacional.transparencia = 0
        LimiteNacional.colorRelleno = "nd"
        LimiteNacional.colorBorde = "RGB_250_52_17"
        LimiteNacional.grosorBorde = 0.6
        LimiteNacional.labelVisible = False
        LimiteNacional.fuenteLabel = "Arial"
        LimiteNacional.tamanioLabel = 8
        LimiteNacional.negrilla = "False"
        LimiteNacional.tieneHalo = False
        LimiteNacional.tamanioPunto = 0
        LimiteNacional.colorPunto = "nd"
        lista_Dummys.Add(LimiteNacional)

        Dim DeptoTitular As New CapaDummy
        DeptoTitular.nombre = "Departamento titular"
        DeptoTitular.activo = True
        DeptoTitular.transparencia = 0
        DeptoTitular.colorRelleno = "nd"
        DeptoTitular.colorBorde = "RGB_0_0_0"
        DeptoTitular.grosorBorde = 1.2
        DeptoTitular.labelVisible = False
        DeptoTitular.fuenteLabel = "Arial"
        DeptoTitular.tamanioLabel = 16
        DeptoTitular.negrilla = "False"
        DeptoTitular.tieneHalo = False
        DeptoTitular.tamanioPunto = 0
        DeptoTitular.colorPunto = "nd"
        lista_Dummys.Add(DeptoTitular)

        Dim Deptos As New CapaDummy
        Deptos.nombre = "DEPARTAMENTOS_AREA_OFICIAL"
        Deptos.activo = True
        Deptos.transparencia = 30
        Deptos.colorRelleno = "RGB_255_255_255"
        Deptos.colorBorde = "RGB_130_130_130"
        Deptos.grosorBorde = 1.2
        Deptos.labelVisible = False
        Deptos.fuenteLabel = "Century Gothic"
        Deptos.tamanioLabel = 10
        Deptos.negrilla = "False"
        Deptos.tieneHalo = False
        Deptos.tamanioPunto = 0
        Deptos.colorPunto = "nd"
        lista_Dummys.Add(Deptos)

        Dim Municipio As New CapaDummy
        Municipio.nombre = "Municipio_Nuevo"
        Municipio.activo = True
        Municipio.transparencia = 0
        Municipio.colorRelleno = "nd"
        Municipio.colorBorde = "RGB_0_0_0"
        Municipio.grosorBorde = 0.8
        Municipio.labelVisible = False
        Municipio.fuenteLabel = "Century Gothic"
        Municipio.tamanioLabel = 5
        Municipio.negrilla = "False"
        Municipio.tieneHalo = False
        Municipio.tamanioPunto = 0
        Municipio.colorPunto = "nd"
        lista_Dummys.Add(Municipio)

        Dim CEmbalse As New CapaDummy
        CEmbalse.nombre = "Embalse"
        CEmbalse.activo = True
        CEmbalse.transparencia = 0
        CEmbalse.colorRelleno = "RGB_87_182_255"
        CEmbalse.colorBorde = "nd"
        CEmbalse.grosorBorde = 0
        CEmbalse.labelVisible = False
        CEmbalse.fuenteLabel = "Arial"
        CEmbalse.tamanioLabel = 8
        CEmbalse.negrilla = "False"
        CEmbalse.tieneHalo = False
        CEmbalse.tamanioPunto = 0
        CEmbalse.colorPunto = "nd"
        lista_Dummys.Add(CEmbalse)

        Dim CLaguna As New CapaDummy
        CLaguna.nombre = "Laguna"
        CLaguna.activo = True
        CLaguna.transparencia = 0
        CLaguna.colorRelleno = "RGB_87_182_255"
        CLaguna.colorBorde = "nd"
        CLaguna.grosorBorde = 0
        CLaguna.labelVisible = False
        CLaguna.fuenteLabel = "Arial"
        CLaguna.tamanioLabel = 8
        CLaguna.negrilla = "False"
        CLaguna.tieneHalo = False
        CLaguna.tamanioPunto = 0
        CLaguna.colorPunto = "nd"
        lista_Dummys.Add(CLaguna)

        Dim CCienaga As New CapaDummy
        CCienaga.nombre = "Cienaga"
        CCienaga.activo = True
        CCienaga.transparencia = 0
        CCienaga.colorRelleno = "RGB_87_182_255"
        CCienaga.colorBorde = "nd"
        CCienaga.grosorBorde = 0
        CCienaga.labelVisible = False
        CCienaga.fuenteLabel = "Arial"
        CCienaga.tamanioLabel = 8
        CCienaga.negrilla = "False"
        CCienaga.tieneHalo = False
        CCienaga.tamanioPunto = 0
        CCienaga.colorPunto = "nd"
        lista_Dummys.Add(CCienaga)

        Dim Condicionados As New CapaDummy
        Condicionados.nombre = "Tipologias_Mercado_Tierras_V7_Mpio_Generalizada---Condicionados"
        Condicionados.activo = True
        Condicionados.transparencia = 0
        Condicionados.colorRelleno = "RGB_255_255_255"
        Condicionados.colorBorde = "RGB_255_255_255"
        Condicionados.grosorBorde = 1
        Condicionados.labelVisible = False
        Condicionados.fuenteLabel = "Arial"
        Condicionados.tamanioLabel = 8
        Condicionados.negrilla = "False"
        Condicionados.tieneHalo = False
        Condicionados.tamanioPunto = 0
        Condicionados.colorPunto = "nd"
        lista_Dummys.Add(Condicionados)

        Dim Incluidos As New CapaDummy
        Incluidos.nombre = "Tipologias_Mercado_Tierras_V7_Mpio_Generalizada---Incluidos"
        Incluidos.activo = True
        Incluidos.transparencia = 0
        Incluidos.colorRelleno = "RGB_255_255_255"
        Incluidos.colorBorde = "RGB_255_255_255"
        Incluidos.grosorBorde = 1
        Incluidos.labelVisible = False
        Incluidos.fuenteLabel = "Arial"
        Incluidos.tamanioLabel = 8
        Incluidos.negrilla = "False"
        Incluidos.tieneHalo = False
        Incluidos.tamanioPunto = 0
        Incluidos.colorPunto = "nd"
        lista_Dummys.Add(Incluidos)

        Dim CExcluidos As New CapaDummy
        CExcluidos.nombre = "Tipologias_Mercado_Tierras_V7_Mpio_Generalizada---Excluidos"
        CExcluidos.activo = True
        CExcluidos.transparencia = 0
        CExcluidos.colorRelleno = "RGB_225_225_225"
        CExcluidos.colorBorde = "RGB_255_255_255"
        CExcluidos.grosorBorde = 1
        CExcluidos.labelVisible = False
        CExcluidos.fuenteLabel = "Arial"
        CExcluidos.tamanioLabel = 8
        CExcluidos.negrilla = "False"
        CExcluidos.tieneHalo = False
        CExcluidos.tamanioPunto = 0
        CExcluidos.colorPunto = "nd"
        lista_Dummys.Add(CExcluidos)

    End Sub

End Class
