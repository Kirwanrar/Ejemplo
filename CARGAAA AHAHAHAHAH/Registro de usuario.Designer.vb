<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistroUser
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 29)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "REGISTRO DE USUARIOS"
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(180, 135)
        Me.txt2.MaxLength = 50
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(100, 20)
        Me.txt2.TabIndex = 9
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(180, 83)
        Me.txt1.MaxLength = 40
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(100, 20)
        Me.txt1.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "CONTRASEÑA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "USUARIO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(51, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "TIPO DE USUARIO"
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(54, 267)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(94, 45)
        Me.btn1.TabIndex = 12
        Me.btn1.Text = "Ingresar"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(212, 267)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 45)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(180, 197)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.TabIndex = 14
        '
        'RegistroUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(331, 324)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.txt1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RegistroUser"
        Me.Text = "REGISTRO DE USUARIO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
