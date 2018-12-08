Imports System.Data.Odbc
Public Class OpcionPaquete

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        sql = "select nombre from destino where borrado=False"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True


            Paquete.ComboBox1.Items.Add(rs(0))



        End While

        Me.Hide()
        Paquete.Show()
    End Sub

    Private Sub OpcionPaquete_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        sql = "select nombre from destino where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        BorradoPaquete.ComboBox1.Items.Clear()
        While rs.Read = True


            BorradoPaquete.ComboBox1.Items.Add(rs(0))



        End While
        BorradoPaquete.ComboBox2.Items.Clear()
        BorradoPaquete.ComboBox1.Text = ""
        BorradoPaquete.ComboBox2.Text = ""

        BorradoPaquete.Show()
        Me.Hide()
        If DDDEEE = True Then
            BorradoPaquete.DataGridView1.DataSource.clear()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Seleccion.Show()
        Me.Hide()

    End Sub
End Class