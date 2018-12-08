Public Class OpcionResponsable

    Private Sub SeleccionResponsable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Responsable.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        CambioResponsable.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        PantallaEleccion.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ModificacionResponsable.Show()
        Me.Hide()
        ModificacionResponsable.TextBox1.Text = ""
        ModificacionResponsable.TextBox4.Text = ""
        ModificacionResponsable.TextBox5.Text = ""
        ModificacionResponsable.TextBox6.Text = ""
        ModificacionResponsable.TextBox2.Text = ""
        ModificacionResponsable.TextBox3.Text = ""

        ModificacionResponsable.TextBox1.Enabled = True

        ModificacionResponsable.TextBox4.Enabled = False
        ModificacionResponsable.TextBox5.Enabled = False
        ModificacionResponsable.TextBox6.Enabled = False
        ModificacionResponsable.TextBox2.Enabled = False
        ModificacionResponsable.TextBox3.Enabled = False
        ModificacionResponsable.RadioButton1.Checked = False
        ModificacionResponsable.RadioButton2.Checked = False
        ModificacionResponsable.RadioButton1.Enabled = False
        ModificacionResponsable.RadioButton2.Enabled = False
    End Sub
End Class