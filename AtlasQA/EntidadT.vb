Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI

Public Class EntidadT

    Public capa As ILayer

    Private capitales As Dictionary(Of String, String) = New Dictionary(Of String, String) From
    {{"Amazonas", "Leticia"}, {"Antioquia", "Medellín"}, {"Arauca", "Arauca"}, {"Atlántico", "Barranquilla"},
     {"Bogotá", "Bogotá"}, {"Bolívar", "Cartagena de Indias"}, {"Boyacá", "Tunja"}, {"Caldas", "Manizales"},
     {"Caquetá", "Florencia"}, {"Casanare", "Yopal"}, {"Cauca", "Popayán"}, {"Cesar", "Valledupar"},
     {"Chocó", "Quibdó"}, {"Córdoba", "Montería"}, {"Cundinamarca", "Bogotá"}, {"Guainía", "Inírida"},
     {"Guaviare", "San José del Guaviare"}, {"Huila", "Neiva"}, {"La Guajira", "Riohacha"},
     {"Magdalena", "Santa Marta"}, {"Meta", "Villavicencio"}, {"Nariño", "Pasto"}, {"Norte de Santander", "San José de Cúcuta"},
     {"Putumayo", "Mocoa"}, {"Quindío", "Armenia"}, {"Risaralda", "Pereira"}, {"San Andrés y Providencia", "San Andrés"},
     {"Santander", "Bucaramanga"}, {"Sucre", "Sincelejo"}, {"Tolima", "Ibagué"}, {"Valle del Cauca", "Cali"}, {"Vaupés", "Mitú"},
     {"Vichada", "Puerto Carreño"}}

    Private deptos As New List(Of String) From {"Antioquia", "Norte de Santander", "Meta", "Chocó", "Huila", "Bolívar", "Cundinamarca",
                                             "Cesar", "Santander", "Caldas", "Casanare", "Nariño", "Caquetá", "La Guajira", "Valle del Cauca",
                                             "Magdalena", "Cauca", "Boyacá", "Tolima", "Risaralda", "Arauca", "Quindío", "Córdoba", "Atlántico",
                                             "Guainía", "Bogotá D.C.", "Sucre", "Guaviare", "Vaupés", "Putumayo", "Vichada", "Amazonas",
                                             "Archipiélago de San Andrés, Providencia y Santa Catalina"}

    Private mupios As New List(Of String) From {"Abejorral", "Abrego", "Abriaquí", "Acacias", "Acandí", "Acevedo", "Achí", "Agrado", "Agua de Dios",
                                            "Aguachica", "Aguada", "Aguadas", "Aguazul", "Agustín Codazzi", "Aipe", "Albán", "Albania", "Alcalá",
                                            "Aldana", "Alejandría", "Algarrobo", "Algeciras", "Almaguer", "Almeida", "Alpujarra", "Altamira",
                                            "Alto Baudo", "Altos del Rosario", "Alvarado", "Amagá", "Amalfi", "Ambalema", "Anapoima", "Ancuyá",
                                            "Andalucía", "Andes", "Angelópolis", "Angostura", "Anolaima", "Anorí", "Anserma", "Ansermanuevo",
                                            "Anza", "Anzoátegui", "Apartadó", "Apía", "Apulo", "Aquitania", "Aracataca", "Aranzazu", "Aratoca",
                                            "Arauca", "Arauquita", "Arbeláez", "Arboleda", "Arboledas", "Arboletes", "Arcabuco", "Arenal",
                                            "Argelia", "Ariguaní", "Arjona", "Armenia", "Armero", "Arroyohondo", "Astrea", "Ataco", "Atrato",
                                            "Ayapel", "Bagadó", "Bahía Solano", "Bajo Baudó", "Balboa", "Baranoa", "Baraya", "Barbacoas", "Barbosa" _
                                           , "Barichara", "Barranca de Upía", "Barrancabermeja", "Barrancas", "Barranco de Loba", "Barranco Minas" _
                                           , "Barranquilla", "Becerril", "Belalcázar", "Belén", "Belén de Bajira", "Belén de Los Andaquies" _
                                           , "Belén de Umbría", "Bello", "Belmira", "Beltrán", "Berbeo", "Betania", "Betéitiva", "Betulia" _
                                           , "Bituima", "Boavita", "Bochalema", "Bogotá D.C.", "Bojacá", "Bojaya", "Bolívar", "Bosconia" _
                                           , "Boyacá", "Briceño", "Bucaramanga", "Bucarasica", "Buena Vista", "Buenaventura", "Buenavista" _
                                           , "Buenos Aires", "Buesaco", "Bugalagrande", "Buriticá", "Busbanzá", "Cabrera", "Cabuyaro", "Cacahual",
                                            "Cáceres", "Cachipay", "Cachirá", "Cácota", "Caicedo", "Caicedonia", "Caimito", "Cajamarca", "Cajibío",
                                            "Cajicá", "Calamar", "Calarcá", "Caldas", "Caldono", "Cali", "California", "Calima", "Caloto", "Campamento",
                                            "Campo de La Cruz", "Campoalegre", "Campohermoso", "Canalete", "Candelaria", "Cantagallo", "Cañasgordas",
                                            "Caparrapí", "Capitanejo", "Caqueza", "Caracolí", "Caramanta", "Carcasí", "Carepa", "Carmen de Apicala",
                                            "Carmen de Carupa", "Carmen del Darien", "Carolina", "Cartagena", "Cartagena del Chairá", "Cartago",
                                            "Caruru", "Casabianca", "Castilla la Nueva", "Caucasia", "Cepitá", "Cereté", "Cerinza", "Cerrito",
                                            "Cerro San Antonio", "Cértegui", "Chachagüí", "Chaguaní", "Chalán", "Chámeza", "Chaparral", "Charalá",
                                            "Charta", "Chía", "Chigorodó", "Chimá", "Chimichagua", "Chinácota", "Chinavita", "Chinchiná", "Chinú",
                                            "Chipaque", "Chipatá", "Chiquinquirá", "Chíquiza", "Chiriguaná", "Chiscas", "Chita", "Chitagá", "Chitaraque",
                                            "Chivatá", "Chivolo", "Chivor", "Choachí", "Chocontá", "Cicuco", "Ciénaga", "Ciénaga de Oro", "Ciénega",
                                            "Cimitarra", "Circasia", "Cisneros", "Ciudad Bolívar", "Clemencia", "Cocorná", "Coello", "Cogua",
                                            "Colombia", "Colón", "Coloso", "Cómbita", "Concepción", "Concordia", "Condoto", "Confines", "Consaca",
                                            "Contadero", "Contratación", "Convención", "Copacabana", "Coper", "Córdoba", "Corinto", "Coromoro",
                                            "Corozal", "Corrales", "Cota", "Cotorra", "Covarachía", "Coveñas", "Coyaima", "Cravo Norte", "Cuaspud",
                                            "Cubará", "Cubarral", "Cucaita", "Cucunubá", "Cúcuta", "Cucutilla", "Cuítiva", "Cumaral", "Cumaribo",
                                            "Cumbal", "Cumbitara", "Cunday", "Curillo", "Curití", "Curumaní", "Dabeiba", "Dagua", "Dibula", "Distracción",
                                            "Dolores", "Don Matías", "Dosquebradas", "Duitama", "Durania", "Ebéjico", "El Águila", "El Bagre", "El Banco",
                                            "El Cairo", "El Calvario", "El Cantón del San Pablo", "El Carmen", "El Carmen de Atrato",
                                            "El Carmen de Bolívar", "El Carmen de Chucurí", "El Carmen de Viboral", "El Castillo", "El Cerrito",
                                            "El Charco", "El Cocuy", "El Colegio", "El Copey", "El Doncello", "El Dorado", "El Dovio", "El Encanto",
                                            "El Espino", "El Guacamayo", "El Guamo", "El Litoral del San Juan", "El Molino", "El Paso", "El Paujil",
                                            "El Peñol", "El Peñón", "El Piñon", "El Playón", "El Retén", "El Retorno", "El Roble", "El Rosal", "El Rosario",
                                            "El Santuario", "El Tablón de Gómez", "El Tambo", "El Tarra", "El Zulia", "Elías", "Encino", "Enciso", "Entrerrios",
                                            "Envigado", "Espinal", "Facatativá", "Falan", "Filadelfia", "Filandia", "Firavitoba", "Flandes", "Florencia",
                                            "Floresta", "Florián", "Florida", "Floridablanca", "Fomeque", "Fonseca", "Fortul", "Fosca", "Francisco Pizarro",
                                            "Fredonia", "Fresno", "Frontino", "Fuente de Oro", "Fundación", "Funes", "Funza", "Fúquene", "Fusagasugá",
                                            "Gachala", "Gachancipá", "Gachantivá", "Gachetá", "Galán", "Galapa", "Galeras", "Gama", "Gamarra", "Gambita",
                                            "Gameza", "Garagoa", "Garzón", "Génova", "Gigante", "Ginebra", "Giraldo", "Girardot", "Girardota", "Girón",
                                            "Gómez Plata", "González", "Gramalote", "Granada", "Guaca", "Guacamayas", "Guacarí", "Guachené", "Guachetá",
                                            "Guachucal", "Guadalajara de Buga", "Guadalupe", "Guaduas", "Guaitarilla", "Gualmatán", "Guamal", "Guamo",
                                            "Guapi", "Guapotá", "Guaranda", "Guarne", "Guasca", "Guatapé", "Guataquí", "Guatavita", "Guateque", "Guática",
                                            "Guavatá", "Guayabal de Siquima", "Guayabetal", "Guayatá", "Güepsa", "Güicán", "Gutiérrez", "Hacarí",
                                            "Hatillo de Loba", "Hato", "Hato Corozal", "Hatonuevo", "Heliconia", "Herrán", "Herveo", "Hispania", "Hobo",
                                            "Honda", "Ibagué", "Icononzo", "Iles", "Imués", "Inírida", "Inzá", "Ipiales", "Iquira", "Isnos", "Istmina",
                                            "Itagui", "Ituango", "Iza", "Jambaló", "Jamundí", "Jardín", "Jenesano", "Jericó", "Jerusalén", "Jesús María",
                                            "Jordán", "Juan de Acosta", "Junín", "Juradó", "La Apartada", "La Argentina", "La Belleza", "La Calera",
                                            "La Capilla", "La Ceja", "La Celia", "La Chorrera", "La Cruz", "La Cumbre", "La Dorada", "La Esperanza",
                                            "La Estrella", "La Florida", "La Gloria", "La Guadalupe", "La Jagua de Ibirico", "La Jagua del Pilar",
                                            "La Llanada", "La Macarena", "La Merced", "La Mesa", "La Montañita", "La Palma", "La Paz", "La Pedrera",
                                            "La Peña", "La Pintada", "La Plata", "La Playa", "La Primavera", "La Salina", "La Sierra", "La Tebaida",
                                            "La Tola", "La Unión", "La Uvita", "La Vega", "La Victoria", "La Virginia", "Labateca", "Labranzagrande",
                                            "Landázuri", "Lebríja", "Leguízamo", "Leiva", "Lejanías", "Lenguazaque", "Lérida", "Leticia", "Líbano",
                                            "Liborina", "Linares", "Lloró", "López", "Lorica", "Los Andes", "Los Córdobas", "Los Palmitos", "Los Patios",
                                            "Los Santos", "Lourdes", "Luruaco", "Macanal", "Macaravita", "Maceo", "Macheta", "Madrid", "Magangué", "Magüí",
                                            "Mahates", "Maicao", "Majagual", "Málaga", "Malambo", "Mallama", "Manatí", "Manaure", "Maní", "Manizales",
                                            "Manta", "Manzanares", "Mapiripán", "Mapiripana", "Margarita", "María la Baja", "Marinilla", "Maripí",
                                            "Mariquita", "Marmato", "Marquetalia", "Marsella", "Marulanda", "Matanza", "Medellín", "Medina",
                                            "Medio Atrato", "Medio Baudó", "Medio San Juan", "Melgar", "Mercaderes", "Mesetas", "Milán", "Miraflores",
                                            "Miranda", "Miriti Paraná", "Mistrató", "Mitú", "Mocoa", "Mogotes", "Molagavita", "Momil", "Mompós",
                                            "Mongua", "Monguí", "Moniquirá", "Montebello", "Montecristo", "Montelíbano", "Montenegro", "Montería",
                                            "Monterrey", "Moñitos", "Morales", "Morelia", "Morichal", "Morroa", "Mosquera", "Motavita", "Murillo", "Murindó",
                                            "Mutatá", "Mutiscua", "Muzo", "Nariño", "Nátaga", "Natagaima", "Nechí", "Necoclí", "Neira", "Neiva", "Nemocón",
                                            "Nilo", "Nimaima", "Nobsa", "Nocaima", "Norcasia", "Norosí", "Nóvita", "Nueva Granada", "Nuevo Colón", "Nunchía",
                                            "Nuquí", "Obando", "Ocamonte", "Ocaña", "Oiba", "Oicatá", "Olaya", "Olaya Herrera", "Onzaga", "Oporapa", "Orito",
                                            "Orocué", "Ortega", "Ospina", "Otanche", "Ovejas", "Pachavita", "Pacho", "Pacoa", "Pácora", "Padilla", "Páez", "Paicol",
                                            "Pailitas", "Paime", "Paipa", "Pajarito", "Palermo", "Palestina", "Palmar", "Palmar de Varela", "Palmas del Socorro",
                                            "Palmira", "Palmito", "Palocabildo", "Pamplona", "Pamplonita", "Pana Pana", "Pandi", "Panqueba", "Papunaua", "Páramo",
                                            "Paratebueno", "Pasca", "Pasto", "Patía", "Pauna", "Paya", "Paz de Ariporo", "Paz de Río", "Pedraza", "Pelaya",
                                            "Pensilvania", "Peñol", "Peque", "Pereira", "Pesca", "Piamonte", "Piedecuesta", "Piedras", "Piendamó", "Pijao",
                                            "Pijiño del Carmen", "Pinchote", "Pinillos", "Piojó", "Pisba", "Pital", "Pitalito", "Pivijay", "Planadas",
                                            "Planeta Rica", "Plato", "Policarpa", "Polonuevo", "Ponedera", "Popayán", "Pore", "Potosí", "Pradera",
                                            "Prado", "Providencia", "Pueblo Bello", "Pueblo Nuevo", "Pueblo Rico", "Pueblo Viejo", "Pueblorrico",
                                            "Puente Nacional", "Puerres", "Puerto Alegría", "Puerto Arica", "Puerto Asís", "Puerto Berrío",
                                            "Puerto Boyacá", "Puerto Caicedo", "Puerto Carreño", "Puerto Colombia", "Puerto Concordia",
                                            "Puerto Escondido", "Puerto Gaitán", "Puerto Guzmán", "Puerto Libertador", "Puerto Lleras",
                                            "Puerto López", "Puerto Nare", "Puerto Nariño", "Puerto Parra", "Puerto Rico", "Puerto Rondón",
                                            "Puerto Salgar", "Puerto Santander", "Puerto Tejada", "Puerto Triunfo", "Puerto Wilches", "Pulí",
                                            "Pupiales", "Puracé", "Purificación", "Purísima", "Quebradanegra", "Quetame", "Quibdó", "Quimbaya",
                                            "Quinchía", "Quípama", "Quipile", "Ragonvalia", "Ramiriquí", "Ráquira", "Recetor", "Regidor", "Remedios",
                                            "Remolino", "Repelón", "Restrepo", "Retiro", "Ricaurte", "Rio Blanco", "Río de Oro", "Río Iro", "Río Quito",
                                            "Río Viejo", "Riofrío", "Riohacha", "Rionegro", "Riosucio", "Risaralda", "Rivera", "Roberto Payán",
                                            "Roldanillo", "Roncesvalles", "Rondón", "Rosas", "Rovira", "Sabana de Torres", "Sabanagrande", "Sabanalarga",
                                            "Sabanas de San Angel", "Sabaneta", "Saboyá", "Sácama", "Sáchica", "Sahagún", "Saladoblanco", "Salamina",
                                            "Salazar", "Saldaña", "Salento", "Salgar", "Samacá", "Samaná", "Samaniego", "Sampués", "San Agustín",
                                            "San Alberto", "San Andrés", "San Andrés de Cuerquía", "San Andrés de Tumaco", "San Andrés Sotavento",
                                            "San Antero", "San Antonio", "San Antonio del Tequendama", "San Benito", "San Benito Abad", "San Bernardo",
                                            "San Bernardo del Viento", "San Calixto", "San Carlos", "San Carlos de Guaroa", "San Cayetano",
                                            "San Cristóbal", "San Diego", "San Eduardo", "San Estanislao", "San Felipe", "San Fernando",
                                            "San Francisco", "San Gil", "San Jacinto", "San Jacinto del Cauca", "San Jerónimo", "San Joaquín",
                                            "San José", "San José de La Montaña", "San José de Miranda", "San José de Pare",
                                            "San José de Uré", "San José del Fragua", "San José del Guaviare", "San José del Palmar",
                                            "San Juan de Arama", "San Juan de Betulia", "San Juan de Río Seco", "San Juan de Urabá",
                                            "San Juan del Cesar", "San Juan Nepomuceno", "San Juanito", "San Lorenzo", "San Luis",
                                            "San Luis de Gaceno", "San Luis de Sincé", "San Marcos", "San Martín", "San Martín de Loba",
                                            "San Mateo", "San Miguel", "San Miguel de Sema", "San Onofre", "San Pablo", "San Pablo de Borbur",
                                            "San Pedro", "San Pedro de Cartago", "San Pedro de Uraba", "San Pelayo", "San Rafael",
                                            "San Roque", "San Sebastián", "San Sebastián de Buenavista", "San Vicente", "San Vicente de Chucurí",
                                            "San Vicente del Caguán", "San Zenón", "Sandoná", "Santa Ana", "Santa Bárbara", "Santa Bárbara de Pinto",
                                            "Santa Catalina", "Socha", "Santa Helena del Opón", "Santa Isabel", "Santa Lucía", "Santa María",
                                            "Santa Marta", "Santa Rosa", "Santa Rosa de Cabal", "Santa Rosa de Osos", "Santa Rosa de Viterbo",
                                            "Santa Rosa del Sur", "Santa Rosalía", "Santa Sofía", "Santacruz", "Santafé de Antioquia", "Santana",
                                            "Santander de Quilichao", "Santiago", "Santiago de Tolú", "Santo Domingo", "Santo Tomás", "Santuario",
                                            "Sapuyes", "Saravena", "Sardinata", "Sasaima", "Sativanorte", "Sativasur", "Segovia", "Sesquilé", "Sevilla",
                                            "Siachoque", "Sibaté", "Sibundoy", "Silos", "Silvania", "Silvia", "Simacota", "Simijaca", "Simití",
                                            "Sincelejo", "Sipí", "Sitionuevo", "Soacha", "Soatá", "Socorro", "Socotá", "Sogamoso", "Solano",
                                            "Soledad", "Solita", "Somondoco", "Sonsón", "Sopetrán", "Soplaviento", "Sopó", "Sora", "Soracá",
                                            "Sotaquirá", "Sotara", "Suaita", "Suan", "Suárez", "Suaza", "Subachoque", "Sucre", "Suesca", "Supatá",
                                            "Supía", "Suratá", "Susa", "Susacón", "Sutamarchán", "Sutatausa", "Sutatenza", "Tabio", "Tadó",
                                            "Talaigua Nuevo", "Tamalameque", "Támara", "Tame", "Támesis", "Taminango", "Tangua", "Taraira",
                                            "Tarapacá", "Tarazá", "Tarqui", "Tarso", "Tasco", "Tauramena", "Tausa", "Tello", "Tena", "Tenerife",
                                            "Tenjo", "Tenza", "Teorama", "Teruel", "Tesalia", "Tibacuy", "Tibaná", "Tibasosa", "Tibirita",
                                            "Tibú", "Tierralta", "Timaná", "Timbío", "Timbiquí", "Tinjacá", "Tipacoque", "Tiquisio", "Titiribí",
                                            "Toca", "Tocaima", "Tocancipá", "Togüí", "Toledo", "Tolú Viejo", "Tona", "Tópaga", "Topaipí",
                                            "Toribio", "Toro", "Tota", "Totoró", "Trinidad", "Trujillo", "Tubará", "Tuchín", "Tuluá", "Tunja",
                                            "Tununguá", "Túquerres", "Turbaco", "Turbaná", "Turbo", "Turmequé", "Tuta", "Tutazá", "Ubalá",
                                            "Ubaque", "Ulloa", "Umbita", "Une", "Unguía", "Unión Panamericana", "Uramita", "Uribe", "Uribia",
                                            "Urrao", "Urumita", "Usiacurí", "Útica", "Valdivia", "Valencia", "Valle de Guamez",
                                            "Valle de San José", "Valle de San Juan", "Valledupar", "Valparaíso", "Vegachí", "Vélez",
                                            "Venadillo", "Venecia", "Ventaquemada", "Vergara", "Versalles", "Vetas", "Vianí", "Victoria",
                                            "Vigía del Fuerte", "Vijes", "Villa Caro", "Villa de Leyva", "Villa de San Diego de Ubate",
                                            "Villa del Rosario", "Villa Rica", "Villagarzón", "Villagómez", "Villahermosa", "Villamaría",
                                            "Villanueva", "Villapinzón", "Villarrica", "Villavicencio", "Villavieja", "Villeta", "Viotá",
                                            "Viracachá", "Vista Hermosa", "Viterbo", "Yacopí", "Yacuanquer", "Yaguará", "Yalí", "Yarumal",
                                            "Yavaraté", "Yolombó", "Yondó", "Yopal", "Yotoco", "Yumbo", "Zambrano", "Zapatoca", "Zapayán",
                                            "Zaragoza", "Zarzal", "Zetaquira", "Zipacón", "Zipaquirá", "Zona Bananera"}

    Public Function listaDeptos() As List(Of String)
        Return deptos
    End Function

    Public Function listaMupios() As List(Of String)
        Return mupios
    End Function

    Public Function dictCapitales() As Dictionary(Of String, String)
        Return capitales
    End Function


End Class
