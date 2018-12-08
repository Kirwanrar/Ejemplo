Imports System.Data.Odbc
Public Class ModificacionEscuela
    Dim c As Integer = 0
    Dim rsss As OdbcDataReader

    Private Sub ModificacionEscuela_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*) from escuelas where nombre='" & TextBox1.Text & "' and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    MsgBox("El nombre es valido", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True

                Else

                    MsgBox("El nombre no es valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")


                End If

            End If
        Else
            MsgBox("Por favor ingrese un nombre valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox7.Enabled = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox7.Enabled = False

            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton2.Checked = True Then
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox7.Text = ""
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox7.Enabled = False



            sql = "update escuelas set borrado=true where nombre='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            sql = "select idesc from escuelas where nombre='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                sql = "select count(*) from curso where idesc=" & rs(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsss = cmd.ExecuteReader
                cmd.Dispose()


                If rsss.Read = True Then
                    If rsss(0) = 1 Then
                        sql = "update curso set borrado=true where idesc=" & rs(0) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsss = cmd.ExecuteReader
                        cmd.Dispose()

                        sql = "select idcurso from curso where idesc=" & rs(0) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        If rs.Read = True Then

                            sql = "select count(*) from alumno where idcurso=" & rs(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsss = cmd.ExecuteReader
                            cmd.Dispose()

                            If rs(0) = 1 Then


                                sql = "update alumno set borrado=true where idcurso=" & rs(0) & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsss = cmd.ExecuteReader
                                cmd.Dispose()



                            End If

                        End If
                    End If


                End If
                TextBox1.Text = ""

                TextBox1.Enabled = True
                MsgBox("El proceso se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                RadioButton1.Enabled = False
                RadioButton2.Checked = False
                RadioButton2.Enabled = False
            End If
        ElseIf RadioButton1.Checked = True Then





            If TextBox3.Text <> "" Then
                c = 1
                sql = "update escuelas set canticur=" & TextBox3.Text & " where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox4.Text <> "" Then
                c = 1
                sql = "update escuelas set direccion='" & TextBox4.Text & "' where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If



            If TextBox6.Text <> "" Then
                c = 1
                sql = "update escuelas set localidad='" & TextBox6.Text & "' where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox7.Text <> "" Then

                c = 1
                sql = "update escuelas set provincia='" & TextBox7.Text & "' where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox5.Text <> "" Then
                c = 1
                sql = "update escuelas set codpost=" & TextBox5.Text & " where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox2.Text <> "" Then
                c = 1
                sql = "update escuelas set nombre='" & TextBox2.Text & "' where nombre='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

            End If


            If c = 1 Then


                MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                TextBox1.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                TextBox7.Text = ""


                TextBox7.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                TextBox3.Enabled = False
                TextBox2.Enabled = False
                TextBox1.Enabled = True
                RadioButton1.Enabled = False
                RadioButton1.Checked = False
                RadioButton2.Enabled = False

            Else
                MsgBox("Por favor ingrese datos en algun campo para modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")


            End If

        ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor verifique los datos del nombre de la escuela", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        Else
            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")



        End If

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

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        OpcionEscuela.Show()
        Me.Hide()

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
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

    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
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

    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
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