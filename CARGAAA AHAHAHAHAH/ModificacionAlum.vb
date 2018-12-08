Imports System.Data.Odbc
Public Class ModificacionAlum
    Dim c As Boolean = False
    Dim rsExistencia1 As OdbcDataReader
    Dim rs11 As OdbcDataReader
    Dim id As Integer
    Dim s As Boolean = False
    Dim validacion2 As Integer




    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

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
        If TextBox1.Text <> "" Then
            sql = "select count(*) from alumno where dni=" & TextBox1.Text & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    MsgBox("El DNI es valido", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True

                Else

                    MsgBox("El DNI no es valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")


                End If

            End If
        Else
            MsgBox("Por favor ingrese un dni valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpcionAlumno.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then

            If ComboBox1.Text <> "" Then

                If ComboBox2.Text <> "" Then

                    sql = "select c.idcurso from curso c, (select idesc from escuela where nombre='" & ComboBox1.Text & "')x where nombre='" & ComboBox2.Text & "' and c.idesc=x.idesc"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs.Read = True Then


                        sql = "update alumno set idcurso=" & rs(0) & " where dni=" & TextBox1.Text & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        c = True


                    End If
                Else
                    MsgBox("Ingrese un curso", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            End If

            If TextBox4.Text <> "" Then

                sql = "update alumno set nombre='" & TextBox4.Text & "' where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                c = True
            End If

            If TextBox5.Text <> "" Then

                sql = "update alumno set apellido='" & TextBox5.Text & "' where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                c = True
            End If

            If TextBox6.Text <> "" Then

                sql = "update alumno set dni=" & TextBox6.Text & " where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                c = True
            End If





            If c = True Then


                MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                TextBox1.Text = ""
                ComboBox1.Text = ""
                ComboBox2.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                ComboBox1.Enabled = False
                ComboBox2.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                TextBox1.Enabled = True
                RadioButton1.Checked = False
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False


            Else
                MsgBox("Por favor ingrese datos en algun campo para modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            End If
        ElseIf RadioButton2.Checked = True Then
            sql = "select count(*) from contratofirma c, alumno a where a.idrespon=c.idrespon and a.dni=" & TextBox6.Text & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsExistencia1 = cmd.ExecuteReader
            cmd.Dispose()


            If rsExistencia1.Read = True Then

                If rsExistencia1(0) = 0 Then

                    sql = "select count(*) from acompañanteviaje c, alumno a where a.idrespon=c.idrespon and a.dni=" & TextBox6.Text & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsExistencia1 = cmd.ExecuteReader
                    cmd.Dispose()


                    If rsExistencia1.Read = True Then

                        If rsExistencia1(0) = 0 Then

                            ComboBox1.Text = ""
                            ComboBox2.Text = ""
                            TextBox4.Text = ""
                            TextBox5.Text = ""
                            TextBox6.Text = ""
                            ComboBox1.Enabled = False
                            ComboBox2.Enabled = False
                            TextBox4.Enabled = False
                            TextBox5.Enabled = False
                            TextBox6.Enabled = False
                            TextBox1.Enabled = True
                            RadioButton2.Checked = False
                            RadioButton2.Enabled = False
                            RadioButton1.Enabled = False

                            sql = "update alumno set borrado=true where dni=" & TextBox1.Text & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()
                            TextBox1.Text = ""
                            MsgBox("El proceso se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                        ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

                            MsgBox("Por favor verifique los datos del dni del alumno", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        Else
                            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        End If
                    Else



                    End If
                Else
                    MsgBox("No se puede realizar el cambio de responsable porque el responsable actual es un padre firmante del viaje", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    validacion2 = MsgBox("Desea cambiar al responsable que figura como firmante del contrato", MsgBoxStyle.YesNo, "CAMBIO")
                    If validacion2 = 6 Then
                        sql = "select idcontrato from contratofirma c, responsables r where c.idrespon=r.idres and r.dni=" & TextBox1.Text & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs.Read = True Then
                            id = rs(0)
                        End If
                        ModificacionContrato.TextBox1.Text = id


                        sql = "select r.dni,r.nombre,r.apellido,r.idres from responsables r,(select idrespon from contratofirma where idcontrato=" & id & ") xx where r.idres=xx.idrespon"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        While rs.Read = True

                            If s = False Then


                                s = True

                                ModificacionContrato.TextBox4.Text = rs(0)
                                ModificacionContrato.TextBox6.Text = rs(1)
                                ModificacionContrato.TextBox7.Text = rs(2)
                                sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs11 = cmd.ExecuteReader
                                cmd.Dispose()
                                If rs11.Read = True Then
                                    ModificacionContrato.TextBox9.Text = rs11(0)
                                    ModificacionContrato.TextBox8.Text = rs11(1)




                                End If

                            Else

                                ModificacionContrato.TextBox5.Text = rs(0)
                                ModificacionContrato.TextBox13.Text = rs(1)
                                ModificacionContrato.TextBox12.Text = rs(2)

                                sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs11 = cmd.ExecuteReader
                                cmd.Dispose()
                                If rs11.Read = True Then
                                    ModificacionContrato.TextBox11.Text = rs11(0)
                                    ModificacionContrato.TextBox10.Text = rs11(1)


                                End If


                            End If


                        End While
                        add = True
                        If ModificacionContrato.TextBox4.Text = TextBox1.Text Then
                            ModificacionContrato.TextBox2.Text = TextBox4.Text
                            ModificacionContrato.TextBox2.Enabled = False
                        Else
                            ModificacionContrato.TextBox3.Text = TextBox4.Text
                            ModificacionContrato.TextBox3.Enabled = False
                        End If
                        app = True
                        ModificacionContrato.Show()
                        Me.Hide()
                    End If

                End If
            End If
        End If




    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

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

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress

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

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then

            ComboBox1.Text = ""
            ComboBox2.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""




            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False



        End If

    End Sub

End Class