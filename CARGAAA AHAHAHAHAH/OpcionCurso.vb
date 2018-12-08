Imports System.Data.Odbc
Public Class opcionCurso

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Cursos.Show()
        Me.Hide()
        Cursos.cbE.Text = " "


        sql = "select nombre from escuelas where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read
            Cursos.cbE.Items.Add(rs(0))
        Loop
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PantallaEleccion.Show()
        Me.Hide()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ModificacionCurso.Show()
        Me.Hide()
        ModificacionCurso.cbE.Text = ""
        ModificacionCurso.ComboBox1.Text = ""


        sql = "select nombre from escuelas where borrado=false "
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read
            ModificacionCurso.ComboBox1.Items.Add(rs(0))
            ModificacionCurso.cbE.Items.Add(rs(0))
        Loop

        ModificacionCurso.ComboBox1.Text = ""
        ModificacionCurso.cbE.Text = ""
        ModificacionCurso.TextBox1.Text = ""
        ModificacionCurso.TextBox2.Text = ""
        ModificacionCurso.ComboBox2.Text = ""
        ModificacionCurso.ComboBox2.Enabled = True
        ModificacionCurso.ComboBox1.Enabled = True


        ModificacionCurso.cbE.Enabled = False
        ModificacionCurso.TextBox1.Enabled = False
        ModificacionCurso.TextBox2.Enabled = False

        ModificacionCurso.RadioButton1.Checked = False
        ModificacionCurso.RadioButton2.Checked = False


        ModificacionCurso.RadioButton1.Enabled = False
        ModificacionCurso.RadioButton2.Enabled = False


    End Sub
End Class