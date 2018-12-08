<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PantallaEleccion
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(44, 53)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 69)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Alumno"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(44, 165)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 69)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = " Curso"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(227, 167)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 69)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = " Escuela"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(383, 169)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(110, 67)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Volver"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(228, 53)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(110, 69)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Responsable"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(383, 55)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(110, 67)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Ficha medica"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'PantallaEleccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(505, 276)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "PantallaEleccion"
        Me.Text = "PANTALLA DE ELECCION"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
End Class
