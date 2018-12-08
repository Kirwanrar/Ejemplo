<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcionEscuela
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
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(82, 119)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(110, 39)
        Me.Button8.TabIndex = 12
        Me.Button8.Text = "Modificar/borrar Escuela"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(81, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 39)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Agregar Escuela"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(82, 196)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 39)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Volver"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpcionEscuela
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button1)
        Me.Name = "OpcionEscuela"
        Me.Text = "OPCION ESCUELA"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
