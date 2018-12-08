Imports System.Data.Odbc
Public Class VisualizacionViaje
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim ac As String
    Dim cont As Boolean = False
    Dim rss As OdbcDataReader
    Dim suma As Integer = 0
    Dim s As Integer
    Dim rsalum As OdbcDataReader
    Dim rsres As OdbcDataReader
    Dim booliano As Boolean = False
    Dim ab As String
    Dim rs11 As OdbcDataReader



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        inicio.Show()
        Me.Hide()




    End Sub

    Private Sub VisualizacionViaje_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ac <> 0 Then
            If ab <> "Finalizado" And ab <> "En Curso" Then

                sql = "select idrespon from alumno a,(select c.idcur curso from contrato c, (select idcontrato from viaje where idviaje=" & ac & ") x where c.idcontra=x.idcontrato) s where a.idcurso=s.curso and a.borrado=False"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()


                While rs.Read = True
                    s = rs(0)

                    sql = "select sum(monto) from recibo where idrespon=" & rs(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rss = cmd.ExecuteReader
                    cmd.Dispose()

                    If rss.Read = True Then
                        If suma > 0 Then
                            booliano = True

                            suma = suma + rss(0)
                        End If


                    End If

                End While
                If booliano = True Then
                    suma = suma * 0.3


                    sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','devolucion'," & suma & "," & s & ", null)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rss = cmd.ExecuteReader
                    cmd.Dispose()
                End If

                sql = "update viaje set cancelado=true where idviaje=" & ac & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "select idcontrato from viaje where idviaje=" & ac & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rss = cmd.ExecuteReader
                cmd.Dispose()

                If rss.Read = True Then

                    sql = "select a.idalum from alumno a ,(select idcur from contrato where idcontra=" & rss(0) & ") xx where a.idcurso=xx.idcur"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsalum = cmd.ExecuteReader
                    cmd.Dispose()

                    While rsalum.Read = True

                        sql = "select idrespon from alumno where idalum=" & rsalum(0) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsres = cmd.ExecuteReader
                        cmd.Dispose()

                        While rsres.Read = True



                            sql = "update alumno set borrado=true where idalum=" & rsalum(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            sql = "select count(*) from acompañanteviaje where idrespon=" & rsres(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()
                            If rs.Read = True Then
                                If rs(0) = 1 Then

                                    sql = "update acompañanteviaje set borrado=true where idviaje=" & ac & ""
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                End If



                            End If

                            sql = "select count(*) from contratofirma where idcontrato=" & rss(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            If rs.Read = True Then
                                If rs(0) = 1 Then

                                    sql = "update contratofirma set borrado=true where idcontrato=" & rss(0) & ""
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                End If



                            End If

                            sql = "update responsables set borrado=true where idres=" & rsres(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()


                            sql = "update almanaque set disponible=false where idviaje=" & ac & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                        End While



                    End While


                    sql = "update contrato set estado='Cancelado' where idcontra=" & rss(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()




                End If
                MsgBox("Ok", MsgBoxStyle.OkOnly, "COMPLETADO")

            Else
                MsgBox("Por favor seleccione un viaje que no este finalizado ni en curso", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If



        Else
            MsgBox("Seleccione un viaje", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then


            ac = (DataGridView1.Rows(e.RowIndex).Cells("Nro_Viaje").Value.ToString())
            ab = (DataGridView1.Rows(e.RowIndex).Cells("estado").Value.ToString())
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ac <> 0 Then
            cont = False
            If ab <> "Finalizado" And ab <> "En Curso" Then
                ModificacionViaje.Show()
                Me.Hide()
                ModificacionViaje.TextBox1.Text = ac

                sql = "select r.dni,r.nombre,r.apellido,r.idres from responsables r,(select idrespon from acompañanteviaje where idviaje=" & ac & ") xx where xx.idrespon=r.idres"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                While rs.Read = True

                    If cont = False Then
                        cont = True

                        ModificacionViaje.TextBox2.Text = rs(0)
                        ModificacionViaje.TextBox6.Text = rs(1)
                        ModificacionViaje.TextBox7.Text = rs(2)
                        sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs11 = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs11.Read = True Then
                            ModificacionViaje.TextBox9.Text = rs11(0)
                            ModificacionViaje.TextBox8.Text = rs11(1)




                        End If



                    Else
                        ModificacionViaje.TextBox3.Text = rs(0)
                        ModificacionViaje.TextBox13.Text = rs(1)
                        ModificacionViaje.TextBox12.Text = rs(2)

                        sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs11 = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs11.Read = True Then
                            ModificacionViaje.TextBox11.Text = rs11(0)
                            ModificacionViaje.TextBox10.Text = rs11(1)


                        End If

                    End If






                End While
            Else
                MsgBox("Por favor seleccione un viaje que no este finalizado ni en curso", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If


        Else
            MsgBox("Seleccione un viaje", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub
End Class