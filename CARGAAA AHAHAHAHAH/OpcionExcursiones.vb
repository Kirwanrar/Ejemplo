Imports System.Data.Odbc
Public Class OpcionExcursiones

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Seleccion.Show()
        Me.Hide()

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Excursiones.Show()
        Me.Hide()
        sql = "select nombre from destino"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True
            Excursiones.ComboBox1.Items.Add(rs(0))
        End While
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sql = "select nombre from destino"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True
            ModificacionExcursion.ComboBox1.Items.Add(rs(0))
            ModificacionExcursion.ComboBox2.Items.Add(rs(0))
        End While
        ModificacionExcursion.Show()
        Me.Hide()


        ModificacionExcursion.TextBox2.Enabled = False
        ModificacionExcursion.TextBox3.Enabled = False
        ModificacionExcursion.TextBox4.Enabled = False
        ModificacionExcursion.ComboBox2.Enabled = False
        ModificacionExcursion.MaskedTextBox1.Enabled = False
        ModificacionExcursion.RadioButton1.Enabled = False
        ModificacionExcursion.RadioButton2.Enabled = False
    End Sub
End Class