Imports System.Data.Odbc
Public Class ModificacionDestino
    Dim rs As OdbcDataReader
    Dim sql As String



    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then

            sql = "select count(*) from destino where nombre='" & TextBox1.Text & "' and provincia='" & TextBox2.Text & "' and borrado=0"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            If rs.Read = True Then
                If rs(0) = 1 Then
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True
                    Button4.Enabled = True
                Else
                    MsgBox("El destino ingresado es invalido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If
            End If
        Else
            MsgBox("Por favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub ModificacionDestino_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox3.Enabled = True
        TextBox4.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Me.Hide()
        OpcionDestino.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If RadioButton2.Checked = True Then

            sql = "update destino set borrado=true where nombre='" & TextBox1.Text & "' and provincia='" & TextBox2.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            MsgBox("EL borrado se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
            TextBox1.Text = ""
            TextBox2.Text = ""
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            Button4.Enabled = False


        ElseIf RadioButton1.Checked = True Then
            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then
                sql = "update destino set nombre='" & TextBox3.Text & "' where nombre='" & TextBox1.Text & "' and provincia='" & TextBox2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "update destino set provincia='" & TextBox4.Text & "' where nombre='" & TextBox3.Text & "' and provincia='" & TextBox2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                TextBox1.Text = ""
                TextBox2.Text = ""
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                Button4.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox3.Text = ""
                TextBox4.Text = ""






            End If
        Else
            MsgBox("Por favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


End Class