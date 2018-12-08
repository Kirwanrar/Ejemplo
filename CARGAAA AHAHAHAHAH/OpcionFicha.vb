Public Class OpcionFicha

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Ficha.Show()
        Ficha.TextBox1.Enabled = False
        Ficha.TextBox2.Enabled = False
        Ficha.TextBox3.Enabled = False

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Me.Hide()
        ModificacionFicha.Show()
        ModificacionFicha.TextBox1.Enabled = True
        ModificacionFicha.TextBox2.Enabled = False
        ModificacionFicha.TextBox3.Enabled = False
        ModificacionFicha.TextBox4.Enabled = False
        ModificacionFicha.TextBox5.Enabled = False
        ModificacionFicha.TextBox6.Enabled = False
        ModificacionFicha.TextBox7.Enabled = False
        ModificacionFicha.CheckBox1.Enabled = False
        ModificacionFicha.CheckBox2.Enabled = False
        ModificacionFicha.CheckBox3.Enabled = False
        ModificacionFicha.CheckBox4.Enabled = False
        ModificacionFicha.CheckBox5.Enabled = False
        ModificacionFicha.CheckBox6.Enabled = False
        ModificacionFicha.CheckBox7.Enabled = False
        ModificacionFicha.CheckBox8.Enabled = False
        ModificacionFicha.RadioButton1.Enabled = False
        ModificacionFicha.RadioButton2.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        VisualizacionFichas.Show()
        VisualizacionFichas.ComboBox1.Text = ""
        VisualizacionFichas.ComboBox2.Text = ""


    End Sub
End Class