Public Class OpcionDestino

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Seleccion.Show()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Destino.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ModificacionDestino.Show()
        Me.Hide()
        ModificacionDestino.RadioButton1.Enabled = False
        ModificacionDestino.RadioButton2.Enabled = False
        ModificacionDestino.TextBox3.Enabled = False
        ModificacionDestino.TextBox4.Enabled = False
        ModificacionDestino.Button4.Enabled = False

    End Sub

End Class