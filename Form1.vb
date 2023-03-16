Public Class frmCalendario
#Region "Atributos"
    'Manejo de Fecha y Hora->Fecha
    Private _año As Integer     'Cuando alguien cambie el año o mes se cambia al otro control
    Private _mes As Integer
    Public Property dia As Integer 'Va a ser introducido por el control Month/Calendar
    Public indiceSalida As Integer  'Me devuelve el indice anterior a un Aceptar/Aplicar
    'Ya esta validado,por usar dicho control

    'Manejo Zona Horaria
    Dim diferenciaMinutosGMT() As Double = {
                                        -720, -660, -600, -540, -480, -420, -420, -360, -360, -360,
                                        -300, -300, -300, -240, -240, -210, -180, -180, -120, -60,
                                        +0, +0, +60, +60, +60, +120, +120, +120, +120, +120, +180,
                                        +180, +180, +240, +270, +300, +330, +360, +420, +480, +480,
                                        +540, +570, +570, +600, +600, +600, +660, +720, +720}
    Dim hasSavingsTime(49) As Boolean
    Private _indice As Integer
    Private _zonaHoraria As String
    Private _minutosGMT As Double
    Private _ajuste As Boolean

    'Manejo de Fehca y Hora->Hora
    Private _horas As Integer
    Private _minutos As Integer
    Private _segundos As Integer

    'Manejo de Movimiento del mapa
    Private zona As Rectangle
    'Ancho y alto de la imagen. Tienen que ser las mismas
    Private ancho As Integer = 568
    Private alto As Integer = 226 '158
    'Offsets estan en 0 para que empieze a dibujar en 0. + derecha/abajo  - izquierda/arriba
    Private offsetX As Integer = 0  'Cuanto quiero desplazarme en x
    Private offsetY As Integer = 0  'Cuanto quiero desplazarme e y

    Public Property Año As Integer
        Get
            Return _año
        End Get
        Set(value As Integer)
            If value <> _año Then
                _año = value
                'No se si el valor fue cambiado por el num o calendario por lo que se tiene que tener el control de eso
                If _año <> nudAño.Value Then    'Si es diferente fue cambiado por el calendario
                    nudAño.Value = _año         'Se requiere modificar el nud para que todo se vea lo mismo
                End If
                'Si el año es diferente a nuestro calendario, se guarda un rango. Es suficiente con poner el inicio
                If _año <> calendario.SelectionStart.Year And _mes > 0 And dia > 0 Then 'Si el año que tengo es diferente al del calendario es que fue modificado por el nud y rquiero modificar el calendario.Se tiene que construir una fecha
                    calendario.SelectionStart = New Date(_año, _mes, dia)
                End If
            End If
        End Set
    End Property

    Public Property Mes As Integer
        Get
            Return _mes
        End Get
        Set(value As Integer)
            If value <> _mes Then
                _mes = value
                'Veo de donde hice el cambio
                If _mes <> cmbMes.SelectedIndex + 1 Then    '+1 porque empieza en cero
                    cmbMes.SelectedIndex = _mes - 1
                End If
                If _mes <> calendario.SelectionStart.Month And _año > 0 And dia > 0 Then
                    calendario.SelectionStart = New Date(_año, _mes, dia)
                End If
            End If
        End Set
    End Property

    'No se validan valores,pues el ComboBox en DDL trabajar con rangos de valores válidos
    Public Property Indice As Integer
        Set(value As Integer)
            If value <> _indice Then                'Validar que haya algun cambio en el valor
                _indice = value
                btnAplicar.Enabled = True           'Habilito el boton de aplicar
                chkVerano.Checked = False           'Si en alguna otra opcion se checkeo, se limpia para que se vuelva a checkear
            End If
        End Set
        Get
            Return _indice
        End Get
    End Property

    Public Property ZonaHoraria As String
        Set(value As String)
            If value <> _zonaHoraria Then           'Validar que haya algun cambio en el valor
                _zonaHoraria = value
            End If
        End Set
        Get
            Return _zonaHoraria
        End Get
    End Property

    Public Property MinutosGMT As Double
        Set(value As Double)
            If value <> _minutosGMT Then               'Validar que haya algun cambio en el valor
                _minutosGMT = value
            End If
        End Set
        Get
            Return _minutosGMT
        End Get
    End Property

    Public Property Ajuste As Boolean
        Set(value As Boolean)
            If value <> _ajuste Then            'Validar que haya algun cambio en el valor
                _ajuste = value
            End If
        End Set
        Get
            Return _ajuste
        End Get
    End Property

    Public Property Horas As Integer
        Set(value As Integer)
            If value <> _horas Then
                _horas = value
            End If
        End Set
        Get
            Return _horas
        End Get
    End Property

    Public Property Minutos As Integer
        Set(value As Integer)
            If value <> _minutos Then
                _minutos = value
            End If
        End Set
        Get
            Return _minutos
        End Get
    End Property

    Public Property Segundos As Integer
        Set(value As Integer)
            If value <> _segundos Then
                _segundos = value
            End If
        End Set
        Get
            Return _segundos
        End Get
    End Property

#End Region

#Region "Metodos"
    ''' <summary>
    ''' Se cambia el Mes y Año al momento de modificar los valores por medio de los controles asociados a la fecha
    ''' </summary>
    ''' <param name="fechas"></param>
    Public Sub cambiarFecha(ByVal fechas As Date)
        'dia = fechas.Day
        Mes = fechas.Month
        Año = fechas.Year
        'lblFecha.Text = fechas.ToString("dd/MMM/yyyy")
    End Sub

    ''' <summary>
    ''' Inicializa las banderas del horario de verano
    ''' </summary>
    Private Sub asignarHorarioVerano()
        For i = 0 To 49
            hasSavingsTime(i) = True
        Next i
        hasSavingsTime(0) = False ' (GMT -12:00) Eniwetok, Kwajalein 
        hasSavingsTime(1) = False ' (GMT -11:00) Midway Island, Samoa 
        hasSavingsTime(2) = False ' (GMT -10:00) Hawaii 
        hasSavingsTime(5) = False ' (GMT -07:00) Arizona 
        hasSavingsTime(8) = False ' (GMT -06:00) Mexico City, Tegucigalpa 
        hasSavingsTime(9) = False ' (GMT -06:00) Saskatchewan 
        hasSavingsTime(10) = False ' (GMT -05:00) Bogota, Lima 
        hasSavingsTime(12) = False ' (GMT -05:00) Indiana (East) 
        hasSavingsTime(14) = False ' (GMT -04:00) Caracas, La Paz 
        hasSavingsTime(17) = False ' (GMT -03:00) Buenos Aires, Georgetown 
        hasSavingsTime(21) = False ' (GMT +00:00) Monrovia, Casablanca 
        hasSavingsTime(28) = False ' (GMT +02:00) Harare, Pretoria 
        hasSavingsTime(30) = False ' (GMT +03:00) Baghdad, Kuwait, Nairobi, Riyadh 
        hasSavingsTime(33) = False ' (GMT +04:00) Abu Dhabi, Muscat, Tbilisi 
        hasSavingsTime(34) = False ' (GMT +04:30) Kabul 
        hasSavingsTime(35) = False ' (GMT +05:00) Islamabad, Karachi, Ekaterinburg, Tashkent 
        hasSavingsTime(36) = False ' (GMT +05:30) Bombay, Calcutta, Madras, New Delhi, Colombo 
        hasSavingsTime(37) = False ' (GMT +06:00) Almaty, Dhaka 
        hasSavingsTime(38) = False ' (GMT +07:00) Bangkok, Jakarta, Hanoi 
        hasSavingsTime(40) = False ' (GMT +08:00) Hong Kong, Perth, Singapore, Taipei 
        hasSavingsTime(41) = False ' (GMT +09:00) Tokyo, Osaka, Sapporo, Seoul, Yakutsk 
        hasSavingsTime(43) = False ' (GMT +09:30) Darwin 
        hasSavingsTime(45) = False ' (GMT +10:00) Guam, Port Moresby, Vladivostok 
        hasSavingsTime(47) = False ' (GMT +11:00) Magadan, Solomon Is., New Caledonia 
        hasSavingsTime(48) = False ' (GMT +12:00) Fiji, Kamchatka, Marshall Is. 
    End Sub

    ''' <summary>
    ''' Habilita/Deshabilita el checkbox en base a si tiene horario de verano
    ''' </summary>
    ''' <param name="value"></param>
    Private Sub tieneHorarioVerano(ByVal value As Integer)
        Select Case hasSavingsTime(value)
            Case True
                chkVerano.Enabled = True
            Case False
                chkVerano.Enabled = False
        End Select
    End Sub


    ''' <summary>
    ''' Despliega un MessageBox en donde se reportan los valores
    ''' </summary>
    ''' <param name="miAño"></param>
    ''' <param name="miMes"></param>
    ''' <param name="miDia"></param>
    ''' <param name="miHora"></param>
    ''' <param name="miMinuto"></param>
    ''' <param name="miSegundo"></param>
    ''' <param name="miZonaHoraria"></param>
    ''' <param name="miIndice"></param>
    ''' <param name="miAhorro"></param>
    ''' <param name="miComportamiento"></param>
    Private Sub salidaMensaje(ByVal miAño As Integer, ByVal miMes As Integer, ByVal miDia As Integer, ByVal miHora As Integer,
                              ByVal miMinuto As Integer, ByVal miSegundo As Integer, ByVal miZonaHoraria As String,
                              ByVal miIndice As Integer, ByVal miAhorro As Boolean, ByVal miComportamiento As Boolean)
        Dim mensaje, estilo, titulo, estadoEsp, mensajeComportamiento, mensajeComportamiento2 As String
        Dim respuesta As Integer = 0
        If miAhorro = True Then                   'Sirve para mostrar el mensaje de ajuste en Español
            estadoEsp = "Verdadero"
        Else
            estadoEsp = "Falso"
        End If

        If miComportamiento = True Then             'Modifica el encabezado y fin del mensaje en base a si se selecciono Cancelar u otro botón
            mensajeComportamiento = "Tiempo establecido a..."
            mensajeComportamiento2 = ""
        Else
            mensajeComportamiento = "Cancelado..."
            mensajeComportamiento2 = "(Hora no guardada)"
        End If


        titulo = "Fecha_y_Hora"
        estilo = vbOKOnly
        mensaje = mensajeComportamiento + Environment.NewLine +
                  "==========================================" + Environment.NewLine +
                  "Año = " + miAño.ToString + Environment.NewLine +
                  "Mes = " + miMes.ToString + Environment.NewLine +
                  "Dia = " + miDia.ToString + Environment.NewLine +
                  "Hora = " + miHora.ToString + Environment.NewLine +
                  "Minuto = " + miMinuto.ToString + Environment.NewLine +
                  "Segundo = " + miSegundo.ToString + Environment.NewLine +
                  "Zona horaria = " + miZonaHoraria + "(#" + miIndice.ToString + ")" + Environment.NewLine +
                  "Ajuste automático para horario de verano = " + estadoEsp + Environment.NewLine +
                  "==========================================" + Environment.NewLine +
                  mensajeComportamiento2
        respuesta = MsgBox(mensaje, estilo, titulo)
    End Sub


    ''' <summary>
    ''' Inicializa los valores al cargar el Form
    ''' </summary>
    Private Sub inicializarValores()
        cambiarFecha(Date.Now)
        dia = Date.Now.Day 'Se inicializa fuera de metodo para que no se cambie constantemente
        cmbZonas.SelectedIndex = 0                                      'Valores iniciales
        nudHoras.Value = Integer.Parse(DateTime.Now.ToString("hh"))     'Muestra el formato en 12 horas
        nudMinutos.Value = Integer.Parse(DateTime.Now.ToString("mm"))
        nudSegundos.Value = Integer.Parse(DateTime.Now.ToString("ss"))
        Indice = cmbZonas.SelectedIndex
        indiceSalida = Indice
        ZonaHoraria = cmbZonas.Text
        MinutosGMT = diferenciaMinutosGMT(Indice)
        Ajuste = chkVerano.Checked
        Horas = Integer.Parse(DateTime.Now.ToString("HH"))
        Minutos = nudMinutos.Value
        Segundos = nudMinutos.Value
        labZonaHoraria.Text = "Zona Horaria Actual:" + cmbZonas.Text
        asignarHorarioVerano()

        If Integer.Parse(DateTime.Now.ToString("HH")) <= 12 Then      'Determino si es AM/PM al usar condicion con formato 24 hrs
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        Else
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        End If
        btnAplicar.Enabled = False
    End Sub

    ''' <summary>
    ''' Actualiza los valores para reflejar algun cambio al momento de seleccionar Ok o Aplicar
    ''' </summary>
    Private Sub actualizarValores()
        If RadioButton2.Checked = True Then
            Horas = nudHoras.Value + 12
        Else
            Horas = nudHoras.Value
        End If
        Minutos = nudMinutos.Value
        Segundos = nudSegundos.Value
        Indice = cmbZonas.SelectedIndex
        ZonaHoraria = cmbZonas.Text
        MinutosGMT = diferenciaMinutosGMT(Indice)
        Ajuste = chkVerano.Checked
        Año = nudAño.Value
        Mes = cmbMes.SelectedIndex + 1
        dia = calendario.SelectionStart.Day             'Se actualiza en este punto para que muestre el cambio en Día
        indiceSalida = Indice                           'Muestra el último indice actualizado, de su zona correspondiente
    End Sub
    ''' <summary>
    ''' Mueve el mapa de Zona Horaria en pixeles hacia izquierda/derecha
    ''' </summary>
    ''' <param name="valorMovimiento"></param>
    Private Sub moverMapa(ByVal desplazamiento As Integer)
        'Se determian diferencias para saber que tanto mover en pixeles
        Debug.WriteLine("Posicion Anterior:" + offsetX.ToString)
        If offsetX < desplazamiento Then                                            'Derecha
            Debug.WriteLine("Diferencia:" + (Indice - offsetX).ToString)
            offsetX += Indice - offsetX 'Diferencia entre indice y valor actual
            Debug.WriteLine("Derecha:" + offsetX.ToString)
        Else                                                                        'Izquierda
            Debug.WriteLine("Diferencia:" + (offsetX - Indice).ToString)
            offsetX -= offsetX - Indice 'Diferencia entre valor actual e indice
            Debug.WriteLine("Izquierda:" + offsetX.ToString)
        End If
        Debug.WriteLine("Posicion Nueva:" + offsetX.ToString)
        Debug.WriteLine(Environment.NewLine)
        picMapa.Refresh()
    End Sub
#End Region

#Region "Eventos"
    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        'Año = nudAño.Value                     'Se comenta para mostrar año correctamente
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub cmbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMes.SelectedIndexChanged
        'Mes = cmbMes.SelectedIndex + 1         'Se comenta para mostrar mes correctamente
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub calendario_DateChanged(sender As Object, e As DateRangeEventArgs) Handles calendario.DateChanged
        cambiarFecha(calendario.SelectionStart)
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub frmCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializarValores()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        actualizarValores()
        salidaMensaje(Año, Mes, dia, Horas, Minutos, Segundos, ZonaHoraria, indiceSalida, Ajuste, True)
        End
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        salidaMensaje(Año, Mes, dia, Horas, Minutos, Segundos, ZonaHoraria, indiceSalida, Ajuste, False)
        End
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        actualizarValores()
        salidaMensaje(Año, Mes, dia, Horas, Minutos, Segundos, ZonaHoraria, indiceSalida, Ajuste, True)
        btnAplicar.Enabled = False
    End Sub

    Private Sub cmbZonas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbZonas.SelectedIndexChanged
        Indice = cmbZonas.SelectedIndex         'Habilita Aplicar y no hace uncheck si se selecciona la misma opcion 2 veces
        labZonaHoraria.Text = "Zona Horaria Actual:" + cmbZonas.Text
        tieneHorarioVerano(Indice)              'Determino si mi zona cuenta con horario de verano, para habilitar el checkbox
        moverMapa(Indice)
    End Sub

    Private Sub chkVerano_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerano.CheckedChanged
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub nudHoras_ValueChanged(sender As Object, e As EventArgs) Handles nudHoras.ValueChanged
        'Horas = nudHoras.Value                 'Se comenta para mostrar hora correctamente
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub nudMinutos_ValueChanged(sender As Object, e As EventArgs) Handles nudMinutos.ValueChanged
        'Minutos = nudMinutos.Value             'Se comenta para minutos año correctamente
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub nudSegundos_ValueChanged(sender As Object, e As EventArgs) Handles nudSegundos.ValueChanged
        'Segundos = nudSegundos.Value           'Se comenta para segundos año correctamente
        btnAplicar.Enabled = True               'Si se coloca esta modificacion en propiedad Ajuste,cancel ya no muestra conf. previa
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        btnAplicar.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        btnAplicar.Enabled = True
    End Sub

    'Refrescar el pictureBox en cada metodo conlleva a que se mueva la imagen
    Private Sub picMapa_Paint(sender As Object, e As PaintEventArgs) Handles picMapa.Paint
        Dim unidades As GraphicsUnit = GraphicsUnit.Pixel
        'Controlo el desplazamiento, se cambia el rectangulo que se va dibujando
        zona = New Rectangle(offsetX, offsetY, ancho + offsetX, alto + offsetY)
        e.Graphics.DrawImage(picMapa.Image, 0.0F, 0.0F, zona, unidades)
    End Sub
#End Region
End Class
