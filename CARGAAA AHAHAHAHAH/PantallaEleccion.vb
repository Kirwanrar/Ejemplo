Imports System.Data.Odbc
Public Class PantallaEleccion

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpcionAlumno.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        OpcionEscuela.Show()
        Me.Hide()




    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        VisualizacionEscuela.Show()
        Me.Hide()

        VisualizacionEscuela.ComboBox1.Items.Clear()


        sql = "select nombre from escuelas where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read = True
            VisualizacionEscuela.ComboBox1.Items.Add(rs(0))

        Loop


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        opcionCurso.Show()
        Me.Hide()

    End Sub




    Private Sub PantallaEleccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpcionResponsable.Show()
        Me.Hide()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ModificacionAlum.ComboBox1.Items.Clear()
        sql = "select nombre from escuelas"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read
            ModificacionAlum.ComboBox1.Items.Add(rs(0))
        Loop

        ModificacionAlum.Show()
        Me.Hide()
        ModificacionAlum.TextBox1.Text = ""
        ModificacionAlum.TextBox4.Text = ""
        ModificacionAlum.TextBox5.Text = ""
        ModificacionAlum.TextBox6.Text = ""

        ModificacionAlum.ComboBox1.Text = ""
        ModificacionAlum.ComboBox2.Text = ""
        ModificacionAlum.TextBox1.Enabled = True

        ModificacionAlum.ComboBox1.Enabled = False
        ModificacionAlum.ComboBox2.Enabled = False
        ModificacionAlum.TextBox4.Enabled = False
        ModificacionAlum.TextBox5.Enabled = False
        ModificacionAlum.TextBox6.Enabled = False









    End Sub

    Private Sub Button6_Click_1(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        VisualizacionFichas.Show()
        Me.Hide()

        sql = "select nombre from alumno where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        VisualizacionFichas.ComboBox1.Items.Clear()

        Do While rs.Read
            VisualizacionFichas.ComboBox1.Items.Add(rs(0))
        Loop

        VisualizacionFichas.ComboBox1.Text = ""
        VisualizacionFichas.ComboBox2.Text = ""


    End Sub
End Class