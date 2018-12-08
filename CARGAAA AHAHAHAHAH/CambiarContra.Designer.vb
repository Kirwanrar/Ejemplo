<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambiarContra
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
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt1 = New System.Windows.Forms.TextBox()
        Me.txt2 = New System.Windows.Forms.TextBox()
        Me.txt3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(56, 276)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(82, 28)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "ACEPTAR"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(82, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "USUARIO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "CONTRASEÑA NUEVA"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CONTRASEÑA VIEJA"
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(269, 73)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(100, 20)
        Me.txt1.TabIndex = 4
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(269, 133)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(100, 20)
        Me.txt2.TabIndex = 5
        '
        'txt3
        '
        Me.txt3.Location = New System.Drawing.Point(269, 199)
        Me.txt3.Name = "txt3"
        Me.txt3.Size = New System.Drawing.Size(100, 20)
        Me.txt3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(51, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(318, 29)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CAMBIO DE CONTRASEÑA"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(269, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 28)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CambiarContra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(405, 343)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt3)
        Me.Controls.Add(Me.txt2)
        Me.Controls.Add(Me.txt1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn1)
        Me.Name = "CambiarContra"
        Me.Text = "CAMBIAR CONTRASEÑA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt1 As System.Windows.Forms.TextBox
    Friend WithEvents txt2 As System.Windows.Forms.TextBox
    Friend WithEvents txt3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
