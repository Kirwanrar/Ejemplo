Imports System.Data.Odbc
Public Class Alumno
    Dim rsex As OdbcDataReader
    Dim c As Integer = 0
    Dim rsinsert As OdbcDataReader
    Dim cont As Integer = 1
    Dim a As Date
    Dim rscont As OdbcDataReader
    Dim rscont1 As OdbcDataReader
    Dim d As Integer = 0
    Dim cuent1 As Integer



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

        Button2.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpcionAlumno.Show()
        Me.Hide()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Responsable.Show()
        Me.Hide()
        ssss = True


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
        rs = cmd.ExecuteReader
        cmd.Dispose()

        If rs.Read = True Then

            sql = "select nombre from curso where idesc=" & rs(0) & ""
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
        If ComboBox1.Text <> "" Then
            If ComboBox2.Text <> "" Then

                If TextBox1.Text <> "" Then

                    If TextBox2.Text <> "" Then

                        If TextBox3.Text <> "" Then


                            If TextBox4.Text <> "" Then



                                sql = "select count(*),idres from responsables where dni='" & TextBox4.Text & "'"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                                If rs.Read = True Then

                                    If rs(0) = 1 Then
                                        sql = "select idesc from escuelas where nombre='" & ComboBox1.Text & "'"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rsex = cmd.ExecuteReader
                                        cmd.Dispose()
                                        If rsex.Read = True Then

                                            sql = "select idcurso from curso where nombre='" & ComboBox2.Text & "' and idesc=" & rsex(0) & ""
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rsex = cmd.ExecuteReader
                                            cmd.Dispose()




                                           
                                            If rsex.Read = True Then

                                               


                                                If CheckBox1.Checked = True And CheckBox1.Enabled = True Then
                                                    c = 1



                                                End If
                                                If CheckBox2.Checked = True And CheckBox2.Enabled = True Then
                                                    d = 1



                                                End If
                                                sql = "insert into alumno values('','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "'," & rsex(0) & "," & rs(1) & "," & c & ",'viaja',false," & d & ")"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rsinsert = cmd.ExecuteReader
                                                cmd.Dispose()

                                                MsgBox("Agregado", MsgBoxStyle.OkOnly, "Completado")



                                                ComboBox1.Text = ""
                                                ComboBox2.Text = ""
                                                TextBox1.Text = ""
                                                TextBox2.Text = ""
                                                TextBox3.Text = ""
                                                TextBox4.Text = ""
                                                CheckBox1.Checked = False
                                                CheckBox2.Checked = False
                                                CheckBox1.Enabled = False






                                            End If


                                        End If

                                    Else
                                        MsgBox("El responsable ingresado no se encuentra registrado en el sistema , por favor ingreselo en el siguiente boton", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                        Button2.Show()
                                        TextBox4.Text = ""
                                        CheckBox1.Checked = False

                                    End If


                                End If
                            Else
                                MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                            End If
                        Else

                            MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                        End If
                    Else

                        MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                    End If
                Else

                    MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE")

                End If
            Else

                MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE")
            End If
        Else

            MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE")

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

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged


        sql = "select idesc from escuelas where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rsex = cmd.ExecuteReader
        cmd.Dispose()
        If rsex.Read = True Then

            sql = "select idcurso from curso where nombre='" & ComboBox2.Text & "' and idesc=" & rsex(0) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsex = cmd.ExecuteReader
            cmd.Dispose()





            If rsex.Read = True Then



                sql = "select count(*) from alumno where liberado=true and idcurso=" & rsex(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rscont = cmd.ExecuteReader
                cmd.Dispose()

                sql = "select cantiliberados from curso where idcurso=" & rsex(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rscont1 = cmd.ExecuteReader
                cmd.Dispose()
                If rscont.Read = True And rscont1.Read = True Then
                    cuent1 = rscont1(0) - rscont(0)
                    If cuent1 > 0 Then

                        CheckBox1.Enabled = True
                        Label9.Text = "Quedan" & cuent1 & " de liberados disponibles para utilizar"

                    Else
                        CheckBox1.Enabled = False

                        Label9.Text = "Quedan 0 de liberados disponibles para utilizar"
                    End If
                End If
            End If

        End If
    End Sub
End Class