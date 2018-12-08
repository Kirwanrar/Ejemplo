<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class opcionCurso
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
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(84, 127)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(110, 48)
        Me.Button7.TabIndex = 11
        Me.Button7.Text = "Modificar/Borrar Curso"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(84, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(110, 48)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = " Agregar Curso"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(84, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 48)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Volver"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'opcionCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button2)
        Me.Name = "opcionCurso"
        Me.Text = "OPCION CURSO"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
