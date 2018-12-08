Imports System.Data.Odbc
Public Class ModificacionViaje
    Dim rsbusqueda As OdbcDataReader
    Dim rsacom As OdbcDataReader
    Dim c As Boolean = False

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


    Private Sub ModificacionViaje_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        VisualizacionViaje.Show()
        Me.Hide()
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox4.Text <> "" Then
            sql = "select count(*), idres from responsables where dni=" & TextBox4.Text & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 0 Then

                    MsgBox("El dni del responsable como acompañante 1 no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                Else

                    sql = "select count(*) from alumno a,(select c.idcur curso from contrato c, (select idcontrato from viaje where idviaje=" & TextBox1.Text & ") x where c.idcontra=x.idcontrato) s where a.idcurso=s.curso and a.idrespon=" & rs(1) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsbusqueda = cmd.ExecuteReader
                    cmd.Dispose()

                    If rsbusqueda.Read = True Then

                        If rsbusqueda(0) = 0 Then

                            MsgBox("El dni del responsable como acompañante 1 no esta registrado para el curso del viaje", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                        Else
                            sql = "select  idres from responsables where dni=" & TextBox2.Text & " and borrado=false"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsacom = cmd.ExecuteReader
                            cmd.Dispose()
                            If rsacom.Read = True Then

                                sql = "update acompañanteviaje set idrespon=" & rs(1) & " where idrespon=" & rsacom(0) & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsacom = cmd.ExecuteReader
                                cmd.Dispose()
                                c = True
                                TextBox4.Text = ""


                            End If

                        End If




                    End If
                End If




            End If
        End If

        If TextBox5.Text <> "" Then

            sql = "select count(*), idres from responsables where dni=" & TextBox5.Text & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 0 Then

                    MsgBox("El dni del responsable como acompañante 1 no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                Else

                    sql = "select count(*) from alumno a,(select c.idcur curso from contrato c, (select idcontrato from viaje where idviaje=" & TextBox1.Text & ") x where c.idcontra=x.idcontrato) s where a.idcurso=s.curso and a.idrespon=" & rs(1) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsbusqueda = cmd.ExecuteReader
                    cmd.Dispose()

                    If rsbusqueda.Read = True Then

                        If rsbusqueda(0) = 0 Then

                            MsgBox("El dni del responsable como acompañante 1 no esta registrado para el curso del viaje")

                        Else
                            sql = "select  idres from responsables where dni=" & TextBox3.Text & " and borrado=false"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsacom = cmd.ExecuteReader
                            cmd.Dispose()
                            If rsacom.Read = True Then

                                sql = "update acompañanteviaje set idrespon=" & rs(1) & " where idrespon=" & rsacom(0) & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsacom = cmd.ExecuteReader
                                cmd.Dispose()

                                c = True
                                TextBox5.Text = ""

                            End If

                        End If




                    End If
                End If




            End If
        End If

        If c = False Then

            MsgBox("Por favor complete el casillero que desea modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If


        If c = True Then

            MsgBox("Las modificacion se realizaron con exito", MsgBoxStyle.OkOnly, "COMPLETADO")


        End If
    End Sub
End Class