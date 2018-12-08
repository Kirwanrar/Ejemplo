Imports System.Data.Odbc
Public Class ModificacionResponsable
    Dim c As Integer = 0
    Dim rsss As OdbcDataReader
    Dim validacion As Integer
    Dim validacion2 As Integer
    Dim id As Integer
    Dim id2 As Integer
    Dim rs11 As OdbcDataReader
    Dim s As Boolean = False

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*) from responsables where dni=" & TextBox1.Text & " and borrado=false"
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

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then

            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox2.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton2.Checked = True Then
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox2.Text = ""

            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False


            sql = "select count(*) from contratofirma c,(select idres from responsables where dni =" & TextBox1.Text & ") xx where c.idrespon=xx.idres"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsss = cmd.ExecuteReader
            cmd.Dispose()
            If rsss.Read = True Then
                MsgBox(rs(0))
                If rsss(0) = 0 Then
                    sql = "select count(*) from acompañanteviaje c,(select idres from responsables where dni =" & TextBox1.Text & ") xx where c.idrespon=xx.idres"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsss = cmd.ExecuteReader
                    cmd.Dispose()

                    If rsss.Read = True Then
                        MsgBox(rs(0))
                        If rsss(0) = 0 Then
                            sql = "update responsables set borrado=true where dni=" & TextBox1.Text & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            sql = "select idres from responsables where dni =" & TextBox1.Text & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            If rs.Read = True Then

                                sql = "select count(*) from alumno where idrespon=" & rs(0) & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsss = cmd.ExecuteReader
                                cmd.Dispose()


                                If rsss.Read = True Then
                                    If rsss(0) = 1 Then
                                        sql = "update alumno set borrado=true where idrespon=" & rs(0) & ""
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rs = cmd.ExecuteReader
                                        cmd.Dispose()

                                    End If


                                End If
                                TextBox1.Text = ""

                                TextBox1.Enabled = True
                                MsgBox("El proceso se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                                RadioButton1.Enabled = False
                                RadioButton2.Checked = False
                                RadioButton2.Enabled = False


                            End If
                        Else
                            MsgBox("No se puede realizar el borrado del responsable porque forma parte de un viaje como acompañante", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                            validacion = MsgBox("Desea cambiar al responsable que figura como acompañante", MsgBoxStyle.YesNo, "CAMBIO")
                            If validacion = 6 Then
                                app = True
                                ModificacionContrato.Show()
                                Me.Hide()



                            End If

                        End If



                    End If
                Else
                    MsgBox("No se puede realizar el borrado del responsable porque forma parte de un viaje como firmante", MsgBoxStyle.OkOnly, "ADVERTENCIA")
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



        ElseIf RadioButton1.Checked = True Then

            sql = "select count(*) from contratofirma c,(select idres from responsables where dni =" & TextBox1.Text & ") xx where c.idrespon=xx.idres"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsss = cmd.ExecuteReader
            cmd.Dispose()
            If rsss.Read = True Then
                If rsss(0) = 0 Then
                    sql = "select count(*) from acompañanteviaje c,(select idres from responsables where dni =" & TextBox1.Text & ") xx where c.idrespon=xx.idres"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsss = cmd.ExecuteReader
                    cmd.Dispose()

                    If rsss.Read = True Then
                        If rsss(0) = 0 Then

                            If TextBox2.Text <> "" Then
                                c = 1
                                sql = "update responsables set nombre='" & TextBox2.Text & "' where dni=" & TextBox1.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                            End If



                            If TextBox3.Text <> "" Then
                                c = 1
                                sql = "update responsables set apellido='" & TextBox3.Text & "' where dni=" & TextBox1.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                            End If


                            If TextBox5.Text <> "" Then
                                c = 1
                                sql = "update responsables set direccion='" & TextBox5.Text & "' where dni=" & TextBox1.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()

                            End If

                            If TextBox6.Text <> "" Then
                                c = 1
                                sql = "update responsables set telefono=" & TextBox6.Text & " where dni=" & TextBox1.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                            End If

                            If TextBox4.Text <> "" Then
                                c = 1
                                sql = "update responsables set dni=" & TextBox4.Text & " where dni='" & TextBox1.Text & "'"
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

                            MsgBox("Por favor verifique los datos del dni del responsable", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        Else
                            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")



                        End If
                    Else
                        MsgBox("No se puede realizar el borrado del responsable porque forma parte de un viaje como acompañante", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        validacion = MsgBox("Desea cambiar al responsable que figura como acompañante", MsgBoxStyle.YesNo, "CAMBIO")
                        If validacion = 6 Then
                            app = True
                            ModificacionViaje.Show()
                            Me.Hide()
                        End If
                    End If
                Else
                    MsgBox("No se puede realizar el borrado del responsable porque forma parte de un viaje como firmante", MsgBoxStyle.OkOnly, "ADVERTENCIA")
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

                        ModificacionContrato.Show()
                        Me.Hide()

                    End If
                End If

            End If
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpcionResponsable.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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


    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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

End Class