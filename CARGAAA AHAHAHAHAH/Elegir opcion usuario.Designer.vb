<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcionUser
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
        Me.btn2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(84, 98)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(131, 23)
        Me.btn1.TabIndex = 0
        Me.btn1.Text = "Agregar Usuarios"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(84, 35)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(131, 23)
        Me.btn2.TabIndex = 1
        Me.btn2.Text = "Cambiar contraseña"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(84, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 24)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpcionUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(307, 204)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Name = "OpcionUser"
        Me.Text = "OPCIONES DE USUARIO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
