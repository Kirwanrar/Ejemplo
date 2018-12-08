Public Class OpcionEscuela

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PantallaEleccion.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Escuela.Show()
        Me.Hide()

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        ModificacionEscuela.TextBox1.Text = ""
        ModificacionEscuela.TextBox4.Text = ""
        ModificacionEscuela.TextBox5.Text = ""
        ModificacionEscuela.TextBox6.Text = ""
        ModificacionEscuela.TextBox2.Text = ""
        ModificacionEscuela.TextBox3.Text = ""
        ModificacionEscuela.TextBox7.Text = ""

        ModificacionEscuela.TextBox1.Enabled = True

        ModificacionEscuela.TextBox4.Enabled = False
        ModificacionEscuela.TextBox5.Enabled = False
        ModificacionEscuela.TextBox6.Enabled = False
        ModificacionEscuela.TextBox2.Enabled = False
        ModificacionEscuela.TextBox3.Enabled = False
        ModificacionEscuela.TextBox7.Enabled = False
        ModificacionEscuela.RadioButton1.Checked = False
        ModificacionEscuela.RadioButton2.Checked = False
        ModificacionEscuela.RadioButton1.Enabled = False
        ModificacionEscuela.RadioButton2.Enabled = False
        ModificacionEscuela.Show()
        Me.Hide()

    End Sub
End Class