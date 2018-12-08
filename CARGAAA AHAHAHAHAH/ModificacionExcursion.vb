Imports System.Data.Odbc
Public Class ModificacionExcursion
    Dim c As Integer = 0
    Dim dee As Integer
    Dim comprobacion As Integer = 0

    Private Sub ModificacionExcursion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "' and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then
                dee = rs(0)

                sql = "select count(*) from excursiones where iddesti=" & rs(0) & " and borrado=false and actividad='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                If rs.Read = True Then

                    If rs(0) = 1 Then
                        MsgBox("La excursion es valida", MsgBoxStyle.OkOnly, "COMPLETADO")
                        TextBox1.Enabled = False
                        RadioButton1.Enabled = True
                        RadioButton2.Enabled = True
                        ComboBox1.Enabled = False

                    Else
                        MsgBox("La excursion no es valida", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If



                End If




            End If
        Else
            MsgBox("Por favor ingrese una excursion valida", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Enabled = True Then

            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            ComboBox2.Enabled = True
            MaskedTextBox1.Enabled = True



        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Enabled = True Then


            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox2.Enabled = False
            MaskedTextBox1.Enabled = False

            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            MaskedTextBox1.Text = ""
            ComboBox2.Text = ""


        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            MaskedTextBox1.Text = ""
            ComboBox2.Text = ""
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox2.Enabled = False
            MaskedTextBox1.Enabled = False
            ComboBox1.Text = ""



            sql = "update excursiones set borrado=true where actividad='" & TextBox1.Text & "' and iddesti=" & dee & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()



                TextBox1.Text = ""
            ComboBox1.Enabled = True

                TextBox1.Enabled = True
            MsgBox("El proceso se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                RadioButton1.Enabled = False
                RadioButton2.Checked = False
                RadioButton2.Enabled = False

        ElseIf RadioButton1.Checked = True Then





            If MaskedTextBox1.Text <> "  :" Then
                If comprobacion = 0 Then
                    c = 1
                    sql = "update excursiones set horadeldia='" & MaskedTextBox1.Text & "' where actividad='" & TextBox1.Text & "' and iddesti=" & dee & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                Else
                    MsgBox("Para poder modificar la hora, por favor INGRESE UNA HORA VALIDA!!", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    MaskedTextBox1.Text = "  :"

                End If

            End If

            If TextBox4.Text <> "" Then
                c = 1
                sql = "update excursiones set precio_persona='" & TextBox4.Text & "' where actividad='" & TextBox1.Text & "' and iddesti=" & dee & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

            End If

            If TextBox2.Text <> "" Then
                c = 1
                sql = "update excursiones set lugar='" & TextBox2.Text & "' where actividad='" & TextBox1.Text & "' and iddesti=" & dee & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox3.Text <> "" Then
                c = 1
                sql = "update excursiones set actividad='" & TextBox3.Text & "' where actividad='" & TextBox3.Text & "' and iddesti=" & dee & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If



            If ComboBox2.Text <> "" And TextBox3.Text <> "" Then
                c = 1

                sql = "select iddestino from destino where nombre='" & ComboBox2.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then
                    sql = "update excursiones set iddesti='" & rs(0) & "' where actividad='" & TextBox3.Text & "' and iddesti=" & dee & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                End If
            End If


            If ComboBox2.Text <> "" And TextBox3.Text = "" Then
                c = 1

                sql = "select iddestino from destino where nombre='" & ComboBox2.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then
                    sql = "update excursiones set iddesti='" & rs(0) & "' where actividad='" & TextBox1.Text & "' and iddesti=" & dee & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                End If
            End If


            If c = 1 Then


                MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                TextBox1.Text = ""
                TextBox4.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                MaskedTextBox1.Text = ""


                TextBox4.Enabled = False
                TextBox3.Enabled = False
                TextBox2.Enabled = False
                TextBox1.Enabled = True
                RadioButton1.Enabled = False
                RadioButton1.Checked = False
                RadioButton2.Enabled = False
                ComboBox1.Enabled = True
                MaskedTextBox1.Enabled = False
                ComboBox2.Enabled = False




            Else
                MsgBox("Por favor ingrese datos en algun campo para modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")


            End If

            ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor verifique los datos de la excursion", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            Else
            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")



            End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        OpcionExcursiones.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

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

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub


    Private Sub MaskedTextBox1_TypeValidationCompleted(sender As Object, e As System.Windows.Forms.TypeValidationEventArgs) Handles MaskedTextBox1.TypeValidationCompleted
        If MaskedTextBox1.Text <= "23:59" Then
            comprobacion = 0
        Else
            comprobacion = 1

            MsgBox("Por favor ingrese una hora del dia valida")
        End If
    End Sub
End Class