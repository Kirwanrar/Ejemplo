Imports System.Data.Odbc
Public Class OpcionAlumno

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Alumno.ComboBox1.Items.Clear()
        sql = "select nombre from escuelas where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read
            Alumno.ComboBox1.Items.Add(rs(0))
        Loop
        Alumno.Show()
        Alumno.Button2.Hide()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ModificacionAlum.ComboBox1.Items.Clear()
        sql = "select nombre from escuelas where borrado=false"
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
        ModificacionAlum.RadioButton1.Checked = False
        ModificacionAlum.RadioButton2.Checked = False
        ModificacionAlum.RadioButton1.Enabled = False
        ModificacionAlum.RadioButton2.Enabled = False

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PantallaEleccion.Show()
        Me.Hide()

    End Sub
End Class