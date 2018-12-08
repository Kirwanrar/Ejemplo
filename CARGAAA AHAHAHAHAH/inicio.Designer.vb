<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inicio
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
        Me.btnExcurs = New System.Windows.Forms.Button()
        Me.btnEscu = New System.Windows.Forms.Button()
        Me.btnChofer = New System.Windows.Forms.Button()
        Me.btnTrans = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExcurs
        '
        Me.btnExcurs.Location = New System.Drawing.Point(351, 160)
        Me.btnExcurs.Name = "btnExcurs"
        Me.btnExcurs.Size = New System.Drawing.Size(103, 65)
        Me.btnExcurs.TabIndex = 0
        Me.btnExcurs.Text = "Paquete"
        Me.btnExcurs.UseVisualStyleBackColor = True
        '
        'btnEscu
        '
        Me.btnEscu.Location = New System.Drawing.Point(194, 160)
        Me.btnEscu.Name = "btnEscu"
        Me.btnEscu.Size = New System.Drawing.Size(103, 65)
        Me.btnEscu.TabIndex = 1
        Me.btnEscu.Text = "Escuelas"
        Me.btnEscu.UseVisualStyleBackColor = True
        '
        'btnChofer
        '
        Me.btnChofer.Location = New System.Drawing.Point(36, 160)
        Me.btnChofer.Name = "btnChofer"
        Me.btnChofer.Size = New System.Drawing.Size(103, 65)
        Me.btnChofer.TabIndex = 2
        Me.btnChofer.Text = "Personal"
        Me.btnChofer.UseVisualStyleBackColor = True
        '
        'btnTrans
        '
        Me.btnTrans.Location = New System.Drawing.Point(36, 283)
        Me.btnTrans.Name = "btnTrans"
        Me.btnTrans.Size = New System.Drawing.Size(103, 63)
        Me.btnTrans.TabIndex = 3
        Me.btnTrans.Text = "Contrato"
        Me.btnTrans.UseVisualStyleBackColor = True
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(351, 283)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(103, 63)
        Me.btn1.TabIndex = 4
        Me.btn1.Text = " Usuarios"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(194, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 63)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Pagos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(103, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 42)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "MENU DE INICIO"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(351, 394)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 63)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cerrar sesion"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(36, 394)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(103, 63)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Viajes"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(194, 394)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(103, 63)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Ganancias"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(514, 469)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.btnTrans)
        Me.Controls.Add(Me.btnChofer)
        Me.Controls.Add(Me.btnEscu)
        Me.Controls.Add(Me.btnExcurs)
        Me.Name = "inicio"
        Me.Text = "PANTALLAINICIO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExcurs As System.Windows.Forms.Button
    Friend WithEvents btnEscu As System.Windows.Forms.Button
    Friend WithEvents btnChofer As System.Windows.Forms.Button
    Friend WithEvents btnTrans As System.Windows.Forms.Button
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

End Class
