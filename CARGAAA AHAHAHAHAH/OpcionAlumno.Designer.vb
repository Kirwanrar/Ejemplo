<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcionAlumno
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(47, 85)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(110, 50)
        Me.Button6.TabIndex = 10
        Me.Button6.Text = "Modificar/borrar Alumno"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(47, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(110, 50)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Agregar Alumno"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(47, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 50)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'OpcionAlumno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 221)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button3)
        Me.Name = "OpcionAlumno"
        Me.Text = "OPCION ALUMNO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
