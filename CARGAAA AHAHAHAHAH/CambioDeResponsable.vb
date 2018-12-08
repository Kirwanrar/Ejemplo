Imports System.Data.Odbc
Public Class CambioResponsable
    Dim rsExistencia As OdbcDataReader
    Dim rsExistencia1 As OdbcDataReader
    Dim rsExistencia2 As OdbcDataReader
    Dim validacion2 As Integer
    Dim validacion As Integer
    Dim s As Boolean = False
    Dim rs11 As OdbcDataReader
    Dim id As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" Then


            sql = "select count(*),idres from responsables where dni='" & TextBox4.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsExistencia = cmd.ExecuteReader
            cmd.Dispose()

            If rsExistencia.Read = True Then

                If rsExistencia(0) = 1 Then

                    sql = "select count(*) from contratofirma where idrespon='" & rsExistencia(1) & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsExistencia1 = cmd.ExecuteReader
                    cmd.Dispose()


                    If rsExistencia1.Read = True Then

                        If rsExistencia1(0) = 0 Then

                            sql = "select count(*) from acompañanteviaje where idrespon='" & rsExistencia1(1) & "'"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsExistencia1 = cmd.ExecuteReader
                            cmd.Dispose()


                            If rsExistencia1.Read = True Then

                                If rsExistencia1(0) = 0 Then



                                    sql = "select count(*),idres from responsables where dni='" & TextBox1.Text & "'"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rsExistencia1 = cmd.ExecuteReader
                                    cmd.Dispose()

                                    If rsExistencia1.Read = True Then
                                        If rsExistencia1(0) = 1 Then

                                            sql = "select count(*),idalum from alumno where dni='" & TextBox3.Text & "'"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rsExistencia2 = cmd.ExecuteReader
                                            cmd.Dispose()
                                            If rsExistencia2.Read = True Then
                                                If rsExistencia2(0) = 1 Then


                                                    sql = "update alumno set idrespon=" & rsExistencia1(1) & " where idalum=" & rsExistencia2(1) & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update cuotas set idrespon=" & rsExistencia1(1) & " where idrespon=" & rsExistencia(1) & " and estado='disponible'"
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    MsgBox("La accion fue realizada con exito", MsgBoxStyle.OkOnly, "COMPLETADO")

                                                    TextBox1.Text = ""
                                                    TextBox3.Text = ""
                                                    TextBox4.Text = ""



                                                Else
                                                    MsgBox("El dni del alumno no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")



                                                End If

                                            End If


                                        Else
                                            MsgBox("El dni del responsable nuevo no existe, por favor vuelva con el boton 'volver' y registrelo", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                                        End If

                                    End If

                                Else
                                    MsgBox("No se puede realizar el cambio de responsable porque el responsable actual es un padre acompañante del viaje", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                End If

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


                    Else
                        MsgBox("El dni del responsable actual no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If

                End If


            Else
                MsgBox("Por favor complete los campos restantes")

            End If
        End If


    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If queeeeeee = True Then

            ModificacionContrato.Show()
            Me.Hide()
            queeeeeee = False

        Else


            Me.Hide()
            OpcionResponsable.Show()
            TextBox1.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Responsable.Show()
        ssss = True

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

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

End Class