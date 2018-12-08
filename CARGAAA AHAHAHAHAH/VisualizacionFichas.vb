Imports System.Data.Odbc

Public Class VisualizacionFichas
    Dim b As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        PantallaEleccion.Show()
        Me.Hide()

    End Sub

    Private Sub VisualizacionFichas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        sql = "select apellido from alumno where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        ComboBox2.Items.Clear()

        If rs.Read = True Then
            ComboBox2.Items.Add(rs(0))
        End If

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If b = False Then
            b = True
            sql = "select f.gruposangui,f.enfermedad,f.operado,f.alergias,f.tratamiento,f.obrasocial from historialmedico f,(select idalum from alumno where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where xx.idalum=f.idalum and f.borrado=False"
            ds.Tables.Add("alumno")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("alumno"))
            Me.DataGridView1.DataSource = ds.Tables("alumno")

        Else
            DataGridView1.DataSource.clear()
            sql = "select f.gruposangui,f.enfermedad,f.operado,f.alergias,f.tratamiento,f.obrasocial from historialmedico f,(select idalum from alumno where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where xx.idalum=f.idalum and f.borrado=False"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("alumno"))
            Me.DataGridView1.DataSource = ds.Tables("alumno")

        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpcionFicha.Show()
        Me.Hide()

    End Sub
End Class