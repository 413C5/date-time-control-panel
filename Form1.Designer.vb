<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCalendario
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.calendario = New System.Windows.Forms.MonthCalendar()
        Me.nudAño = New System.Windows.Forms.NumericUpDown()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.labZonaHoraria = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.picReloj = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.nudSegundos = New System.Windows.Forms.NumericUpDown()
        Me.nudMinutos = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.nudHoras = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.chkVerano = New System.Windows.Forms.CheckBox()
        Me.picMapa = New System.Windows.Forms.PictureBox()
        Me.cmbZonas = New System.Windows.Forms.ComboBox()
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picReloj, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.nudSegundos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinutos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.picMapa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'calendario
        '
        Me.calendario.BackColor = System.Drawing.Color.White
        Me.calendario.Location = New System.Drawing.Point(10, 69)
        Me.calendario.MaxSelectionCount = 1
        Me.calendario.Name = "calendario"
        Me.calendario.ShowToday = False
        Me.calendario.TabIndex = 2
        '
        'nudAño
        '
        Me.nudAño.Location = New System.Drawing.Point(188, 30)
        Me.nudAño.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.nudAño.Minimum = New Decimal(New Integer() {1950, 0, 0, 0})
        Me.nudAño.Name = "nudAño"
        Me.nudAño.Size = New System.Drawing.Size(84, 27)
        Me.nudAño.TabIndex = 1
        Me.nudAño.Value = New Decimal(New Integer() {1950, 0, 0, 0})
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(10, 31)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(151, 28)
        Me.cmbMes.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(694, 403)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.labZonaHoraria)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(686, 370)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fecha y Hora"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'labZonaHoraria
        '
        Me.labZonaHoraria.Location = New System.Drawing.Point(20, 328)
        Me.labZonaHoraria.Name = "labZonaHoraria"
        Me.labZonaHoraria.Size = New System.Drawing.Size(612, 25)
        Me.labZonaHoraria.TabIndex = 0
        Me.labZonaHoraria.Text = "Label1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.picReloj)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.nudSegundos)
        Me.GroupBox2.Controls.Add(Me.nudMinutos)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox2.Controls.Add(Me.nudHoras)
        Me.GroupBox2.Location = New System.Drawing.Point(352, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(338, 285)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "&Tiempo"
        '
        'picReloj
        '
        Me.picReloj.Location = New System.Drawing.Point(29, 31)
        Me.picReloj.Name = "picReloj"
        Me.picReloj.Size = New System.Drawing.Size(281, 155)
        Me.picReloj.TabIndex = 7
        Me.picReloj.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Location = New System.Drawing.Point(250, 201)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(66, 77)
        Me.Panel1.TabIndex = 3
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(9, 7)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(53, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "AM"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(9, 45)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(51, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "PM"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'nudSegundos
        '
        Me.nudSegundos.Location = New System.Drawing.Point(185, 221)
        Me.nudSegundos.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudSegundos.Name = "nudSegundos"
        Me.nudSegundos.Size = New System.Drawing.Size(63, 27)
        Me.nudSegundos.TabIndex = 2
        '
        'nudMinutos
        '
        Me.nudMinutos.Location = New System.Drawing.Point(107, 221)
        Me.nudMinutos.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudMinutos.Name = "nudMinutos"
        Me.nudMinutos.Size = New System.Drawing.Size(63, 27)
        Me.nudMinutos.TabIndex = 1
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.Location = New System.Drawing.Point(318, 206)
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(0, 27)
        Me.NumericUpDown2.TabIndex = 1
        '
        'nudHoras
        '
        Me.nudHoras.Location = New System.Drawing.Point(29, 221)
        Me.nudHoras.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudHoras.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHoras.Name = "nudHoras"
        Me.nudHoras.Size = New System.Drawing.Size(63, 27)
        Me.nudHoras.TabIndex = 0
        Me.nudHoras.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.calendario)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.nudAño)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 285)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "&Fecha"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.chkVerano)
        Me.TabPage2.Controls.Add(Me.picMapa)
        Me.TabPage2.Controls.Add(Me.cmbZonas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(703, 370)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Zona Horaria"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'chkVerano
        '
        Me.chkVerano.AutoSize = True
        Me.chkVerano.Location = New System.Drawing.Point(44, 307)
        Me.chkVerano.Name = "chkVerano"
        Me.chkVerano.Size = New System.Drawing.Size(508, 24)
        Me.chkVerano.TabIndex = 1
        Me.chkVerano.Text = "Ajustar automáticamente el reloj para los cambios de horario de verano"
        Me.chkVerano.UseVisualStyleBackColor = True
        '
        'picMapa
        '
        Me.picMapa.Image = Global.appCalendario_Practica6.My.Resources.Resources.mapaCompleto2
        Me.picMapa.Location = New System.Drawing.Point(96, 75)
        Me.picMapa.Name = "picMapa"
        Me.picMapa.Size = New System.Drawing.Size(526, 226)
        Me.picMapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMapa.TabIndex = 3
        Me.picMapa.TabStop = False
        '
        'cmbZonas
        '
        Me.cmbZonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonas.FormattingEnabled = True
        Me.cmbZonas.Items.AddRange(New Object() {"(GMT -12:00) Eniwetok, Kwajalein ", "(GMT -11:00) Midway Island, Samoa ", "(GMT -10:00) Hawaii ", "(GMT -09:00) Alaska ", "(GMT -08:00) Pacific Time (US and Canada); Tijuana ", "(GMT -07:00) Arizona ", "(GMT -07:00) Mountain Time (US and Canada) ", "(GMT -06:00) Central Time (US and Canada) ", "(GMT -06:00) Mexico City, Tegucigalpa ", "(GMT -06:00) Saskatchewan ", "(GMT -05:00) Bogota, Lima ", "(GMT -05:00) Eastern Time (US and Canada) ", "(GMT -05:00) Indiana (East) ", "(GMT -04:00) Atlantic Time (Canada) ", "(GMT -04:00) Caracas, La Paz ", "(GMT -03:30) Newfoundland ", "(GMT -03:00) Brasilia ", "(GMT -03:00) Buenos Aires, Georgetown ", "(GMT -02:00) Mid-Atlantic ", "(GMT -01:00) Azores, Cape Verde Is. ", "(GMT +00:00) Greenwich Mean Time; Dublin, Edinburgh, London, Lisbon ", "(GMT +00:00) Monrovia, Casablanca ", "(GMT +01:00) Berlin, Stockhold, Rome, Bern, Brussels, Vienna ", "(GMT +01:00) Paris, Madrid, Amsterdam ", "(GMT +01:00) Prage, Warsaw, Budapest ", "(GMT +02:00) Athens, Helsinki, Istanbul ", "(GMT +02:00) Cairo ", "(GMT +02:00) Eastern Europe ", "(GMT +02:00) Harare, Pretoria ", "(GMT +02:00) Israel ", "(GMT +03:00) Baghdad, Kuwait, Nairobi, Riyadh ", "(GMT +03:00) Moscow, St. Petersburgh, Kazan, Volgograd ", "(GMT +03:00) Tehran ", "(GMT +04:00) Abu Dhabi, Muscat, Tbilisi ", "(GMT +04:30) Kabul ", "(GMT +05:00) Islamabad, Karachi, Ekaterinburg, Tashkent ", "(GMT +05:30) Bombay, Calcutta, Madras, New Delhi, Colombo ", "(GMT +06:00) Almaty, Dhaka ", "(GMT +07:00) Bangkok, Jakarta, Hanoi ", "(GMT +08:00) Beijing, Chongqing, Urumqi ", "(GMT +08:00) Hong Kong, Perth, Singapore, Taipei ", "(GMT +09:00) Tokyo, Osaka, Sapporo, Seoul, Yakutsk ", "(GMT +09:30) Adelaide ", "(GMT +09:30) Darwin ", "(GMT +10:00) Brisbane, Melbourne, Sydney ", "(GMT +10:00) Guam, Port Moresby, Vladivostok ", "(GMT +10:00) Hobart ", "(GMT +11:00) Magadan, Solomon Is., New Caledonia ", "(GMT +12:00) Fiji, Kamchatka, Marshall Is. ", "(GMT +12:00) Wellington, Auckland "})
        Me.cmbZonas.Location = New System.Drawing.Point(44, 25)
        Me.cmbZonas.Name = "cmbZonas"
        Me.cmbZonas.Size = New System.Drawing.Size(620, 28)
        Me.cmbZonas.TabIndex = 0
        '
        'btnAplicar
        '
        Me.btnAplicar.Enabled = False
        Me.btnAplicar.Location = New System.Drawing.Point(552, 418)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(94, 29)
        Me.btnAplicar.TabIndex = 0
        Me.btnAplicar.Text = "&Aplicar"
        Me.btnAplicar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(452, 418)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(94, 29)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(352, 418)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(94, 29)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmCalendario
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(718, 467)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCalendario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha/Hora"
        CType(Me.nudAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.picReloj, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudSegundos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinutos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.picMapa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents calendario As MonthCalendar
    Friend WithEvents nudAño As NumericUpDown
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents nudSegundos As NumericUpDown
    Friend WithEvents nudMinutos As NumericUpDown
    Friend WithEvents NumericUpDown2 As NumericUpDown
    Friend WithEvents nudHoras As NumericUpDown
    Friend WithEvents chkVerano As CheckBox
    Friend WithEvents picMapa As PictureBox
    Friend WithEvents cmbZonas As ComboBox
    Friend WithEvents btnAplicar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents labZonaHoraria As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents picReloj As PictureBox
End Class
