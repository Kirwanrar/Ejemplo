Imports System.Data.Odbc
Public Class VisualizacionEscuela
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim rsExistencia As OdbcDataReader
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b As Boolean = False



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()


    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If Char.IsLetter(e.KeyChar) And Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        sql = "select idesc from escuelas where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rsExistencia = cmd.ExecuteReader
        cmd.Dispose()

        If rsExistencia.Read = True Then

            sql = "select nombre from curso where idesc=" & rsExistencia(0) & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            ComboBox2.Text = " "



            ComboBox2.Items.Clear()
            While rs.Read = True


                ComboBox2.Items.Add(rs(0))



            End While


        End If







    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        PantallaEleccion.Show()
        Me.Hide()




    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        inicio.Show()
        Me.Hide()


    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
        If Char.IsLetter(e.KeyChar) And Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged



        If b = False Then
            b = True
            sql = "select a.nombre,a.apellido, a.dni,a.estado from alumno a,curso c,escuelas e where c.idcurso=a.idcurso and c.nombre = '" & ComboBox2.Text & "' and c.idesc=e.idesc and e.nombre='" & ComboBox1.Text & "'and a.borrado=false"
            ds.Tables.Add("alumno")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("alumno"))
            Me.DataGridView1.DataSource = ds.Tables("alumno")
            
        Else
            DataGridView1.DataSource.clear()
            sql = "select a.nombre,a.apellido, a.dni,a.estado from alumno a,curso c,escuelas e where c.idcurso=a.idcurso and c.nombre = '" & ComboBox2.Text & "' and c.idesc=e.idesc and e.nombre='" & ComboBox1.Text & "'and a.borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("alumno"))
            Me.DataGridView1.DataSource = ds.Tables("alumno")

        End If



    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class