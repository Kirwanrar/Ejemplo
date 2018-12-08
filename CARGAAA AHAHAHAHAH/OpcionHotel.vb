Imports System.Data.Odbc
Public Class OpcionHotel
    Dim rs As OdbcDataReader
    Dim sql As String

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Hotel.Show()

        sql = "select nombre from destino"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True
            Hotel.ComboBox1.Items.Add(rs(0))
        End While

    End Sub

    Private Sub OpcionHotel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        ModificacionHotel.Show()

        sql = "select nombre from destino"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True
            ModificacionHotel.ComboBox1.Items.Add(rs(0))
        End While
        ModificacionHotel.TextBox1.Enabled = True
        ModificacionHotel.TextBox2.Enabled = True
        ModificacionHotel.TextBox3.Enabled = False
        ModificacionHotel.TextBox4.Enabled = False
        ModificacionHotel.TextBox5.Enabled = False
        ModificacionHotel.TextBox6.Enabled = False
        ModificacionHotel.TextBox7.Enabled = False
        ModificacionHotel.NumericUpDown1.Enabled = False
        ModificacionHotel.ComboBox1.Enabled = False
        ModificacionHotel.RadioButton1.Enabled = False
        ModificacionHotel.RadioButton2.Enabled = False

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Seleccion.Show()

    End Sub
End Class