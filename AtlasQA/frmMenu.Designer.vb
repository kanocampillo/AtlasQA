<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChBNodefinidos = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBFolder = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'ChBNodefinidos
        '
        Me.ChBNodefinidos.AutoSize = True
        Me.ChBNodefinidos.Location = New System.Drawing.Point(124, 66)
        Me.ChBNodefinidos.Margin = New System.Windows.Forms.Padding(2)
        Me.ChBNodefinidos.Name = "ChBNodefinidos"
        Me.ChBNodefinidos.Size = New System.Drawing.Size(129, 17)
        Me.ChBNodefinidos.TabIndex = 10
        Me.ChBNodefinidos.Text = "Reportar no Definidos"
        Me.ChBNodefinidos.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(318, 78)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 39)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Validar Mxd"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 41)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Directorio del Reporte"
        '
        'TBFolder
        '
        Me.TBFolder.Location = New System.Drawing.Point(124, 37)
        Me.TBFolder.Margin = New System.Windows.Forms.Padding(2)
        Me.TBFolder.Name = "TBFolder"
        Me.TBFolder.Size = New System.Drawing.Size(221, 20)
        Me.TBFolder.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(348, 33)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 30)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Examinar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 130)
        Me.Controls.Add(Me.ChBNodefinidos)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TBFolder)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmMenu"
        Me.Text = "Control de Calidad Mapas de Mercado de Tierras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChBNodefinidos As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBFolder As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
End Class
