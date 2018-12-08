Imports System.Data.Odbc
Public Class ModificacionHotel
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim rsh As OdbcDataReader
    Dim id As Integer





    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" Then

            sql = "select  count(*) from hotel where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "' and borrado=0"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            If rs.Read = True Then
                If rs(0) = 1 Then
                    MsgBox("El hotel es valido", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True
                    sql = "select idhotel from hotel where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "' and borrado=0"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsh = cmd.ExecuteReader
                    cmd.Dispose()
                    If rsh.Read = True Then
                        id = rsh(0)
                    End If
                Else
                    MsgBox("El hotel ingresado no es valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            End If
        Else
            MsgBox("Por favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If

    End Sub

    Private Sub ModificacionHotel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then

            TextBox8.Enabled = True
            TextBox9.Enabled = True
            TextBox3.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox4.Enabled = True
            TextBox7.Enabled = True
            NumericUpDown1.Enabled = True
            ComboBox1.Enabled = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        TextBox3.Enabled = False
        TextBox9.Enabled = False
        TextBox8.Enabled = False
        TextBox5.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        NumericUpDown1.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then


            sql = "update hotel set borrado=true where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            TextBox3.Text = ""
            TextBox9.Text = ""
            TextBox8.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox3.Enabled = False
            TextBox5.Enabled = False
            TextBox8.Enabled = False
            TextBox9.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox4.Enabled = False
            TextBox1.Text = ""
            TextBox2.Text = ""
            NumericUpDown1.Enabled = False
            ComboBox1.Enabled = False

            MsgBox("EL borrado se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = True

        ElseIf RadioButton1.Checked = True Then

            If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And NumericUpDown1.Value <> 0 And ComboBox1.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" Then
                sql = "update hotel set telefono='" & TextBox3.Text & "' where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "update hotel set precio_persona='" & TextBox4.Text & "' where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "update hotel set estrellas='" & NumericUpDown1.Value & "' where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsh = cmd.ExecuteReader
                cmd.Dispose()
                If rsh.Read = True Then

                    sql = "update hotel set iddesti ='" & rsh(0) & "' where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()


                    sql = "update habitacion set tipocamas ='" & TextBox5.Text & "' where idhotel = " & id & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    sql = "update habitacion set cantiperson ='" & TextBox6.Text & "' where idhotel = " & id & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    sql = "update habitacion set canticamas ='" & TextBox7.Text & "' where idhotel = " & id & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    sql = "update hotel set nombre='" & TextBox9.Text & "' where nombre ='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    sql = "update hotel set direccion='" & TextBox8.Text & "' where nombre ='" & TextBox9.Text & "' and direccion='" & TextBox2.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox3.Text = ""
                    TextBox5.Text = ""
                    TextBox6.Text = ""
                    TextBox8.Text = ""
                    TextBox9.Text = ""
                    TextBox7.Text = ""
                    TextBox4.Text = ""
                    TextBox3.Enabled = False
                    TextBox5.Enabled = False
                    TextBox8.Enabled = False
                    TextBox9.Enabled = False
                    TextBox4.Enabled = False
                    TextBox6.Enabled = False
                    TextBox7.Enabled = False
                    ComboBox1.Text = 0
                    NumericUpDown1.Value = 0
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    NumericUpDown1.Enabled = False
                    ComboBox1.Enabled = False
                    RadioButton1.Checked = False
                    RadioButton2.Checked = False
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False

                    TextBox1.Enabled = True
                    TextBox2.Enabled = True
                End If
            End If
        End If


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        NumericUpDown1.Value = 0
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        Me.Hide()
        OpcionHotel.Show()


    End Sub

    Private Sub Label10_Click(sender As System.Object, e As System.EventArgs) Handles Label10.Click

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox9_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
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

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
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

    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class