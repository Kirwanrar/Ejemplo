Imports System.Data.Odbc
Module Module1
    Public sql As String
    Public rs As OdbcDataReader
    Public cnn As OdbcConnection
    Public cmd As OdbcCommand
    Public ssss As Boolean = False
    Public fecha As String
    Public mes As Integer
    Public año As Integer
    Public rsSolo As OdbcDataReader
    Public rsbaja As OdbcDataReader
    Public mes1 As Integer
    Public menos As Integer
    Public cont As Integer = 1
    Public asd As Boolean = False
    Public ads As Boolean = False
    Public aps As Boolean = False
    Public asp As Boolean = False
    Public queeeeeee As Boolean = False
    Public año1 As Integer
    Public cuuuuuuu As Integer
    Public dia As Integer
    Public dia1 As Integer
    Public xd As Integer
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Public app As Integer
    Public add As Integer
    Public var1Contrato As Integer
    Public var2Contrato As Integer
    Public var3Contrato As Integer
    Public var1trans As Integer
    Public var1Viaje As Integer
    Public var2Viaje As Integer
    Public var3Viaje As String
    Public var4Viaje As String
    Public var1Alma As Integer
    Public var2Alma As String
    Public var3Alma As String
    Public var1Firmaone As Integer
    Public var2Firmaone As Integer
    Public var1Firmatwo As Integer
    Public var2Firmatwo As Integer


    Public solofloat As Single
    Public DDDEEE As Boolean = False



    Public ooooooooo As Boolean = False





    Public Sub conexion()



        Try
            cnn = New OdbcConnection("DSN=egresados")
            cnn.Open()

        Catch ex As Exception

        End Try




    End Sub

 
    Public Sub cada_mes()


        fecha = Today.Date
        mes = Month(fecha)
        año = Year(fecha)

        If fecha = "31/1/" & año & "" Or fecha = "28/2/" & año & "" Or fecha = "31/3/" & año & "" Or fecha = "30/4/" & año & "" Or fecha = "31/5/" & año & "" Or fecha = "30/6/" & año & "" Or fecha = "31/7/" & año & "" Or fecha = "31/8/" & año & "" Or fecha = "30/9/" & año & "" Or fecha = "31/10/" & año & "" Or fecha = "30/11/" & año & "" Or fecha = "31/12/" & año & "" Then


            sql = "select sum(monto) from recibo where month(fecha)=" & mes & " and year(fecha)=" & año & " and concepto<>'devolucion'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then
                solofloat = rs(0)

                sql = "insert into ganancias values('','" & mes & "','" & año & "','" & solofloat & "')"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()


            End If

            sql = "select idcurso,cantiintegr from curso"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            While rs.Read = True

                sql = "select count(*) from alumno where idcurso=" & rs(0) & " "
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsSolo = cmd.ExecuteReader
                cmd.Dispose()


                If rsSolo.Read = True Then

                    If rs(1) > rsSolo(0) Then
                        sql = "select idalum from alumno where liberado=true and idcurso=" & rs(0) & " limit 1"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs.Read = True Then
                            sql = "update alumno set liberado=false where idalum=" & rs(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsbaja = cmd.ExecuteReader
                            cmd.Dispose()

                            sql = "select nombre,apellido,idcurso,idrespon from alumno where idalum=" & rs(0) & ""
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsbaja = cmd.ExecuteReader
                            cmd.Dispose()

                            If rsbaja.Read = True Then

                                MsgBox("se le dio de baja al alumno:" & rsbaja(0) & " " & rsbaja(1) & " porque el curso al que proviene disminuyo la cantidad de liberados disponibles. Se le generaron las cuotas a pagar")

                                sql = "select a.fechadeinicio from almanaque a,(select idcontra from contrato where idcur=" & rsbaja(2) & ") xx, viaje v where v.idviaje=a.idviaje and v.idcontrato=xx.idcontra "
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()

                                If rs.Read = True Then

                                    mes1 = Month(rs(0))
                                    cuuuuuuu = mes1 - mes

                                    If cuuuuuuu < 0 Then


                                        mes1 = mes1 - 1

                                        menos = mes



                                        While menos <> mes1

                                            menos = menos + 1

                                            If menos > 12 Then
                                                menos = 1
                                                año = año + 1

                                                sql = "insert into cuotas value(''," & cont & ",null,'disponible'," & rsbaja(3) & ",'24/" & menos & "/" & año & "',false)"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader
                                                cmd.Dispose()

                                            Else
                                                sql = "insert into cuotas value(''," & cont & ",null,'disponible'," & rsbaja(3) & ",'24/" & menos & "/" & año & "',false)"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader
                                                cmd.Dispose()

                                            End If



                                            cont = cont + 1

                                        End While
                                    Else




                                        While mes <= mes1

                                            mes = mes + 1

                                            If menos > 12 Then
                                                mes = 1
                                                año = año + 1

                                                sql = "insert into cuotas value(''," & cont & ",null,'disponible'," & rsbaja(3) & ",'24/" & mes & "/" & año & "',false)"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader
                                                cmd.Dispose()

                                            Else
                                                sql = "insert into cuotas value(''," & cont & ",null,'disponible'," & rsbaja(3) & ",'24/" & mes & "/" & año & "',false)"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader
                                                cmd.Dispose()

                                            End If



                                            cont = cont + 1

                                        End While






                                    End If





                                End If



                            End If
                        End If

                    End If

                End If






            End While

        End If



    End Sub



    Public Sub eleccion()


        fecha = Today.Date
        dia = Microsoft.VisualBasic.DateAndTime.Day(fecha)
        mes = Month(fecha)


        sql = "select v.idcontrato,day(a.fechadeinicio),month(a.fechadeinicio), v.idviaje from viaje v, almanaque a where v.idviaje=a.idviaje"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        While rs.Read = True

            dia1 = rs(1)


            sql = "select count(*) from viajecoor where idviaje=" & rs(3) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsSolo = cmd.ExecuteReader
            cmd.Dispose()

            sql = "select count(t.idconduc) from transchofer t, (select idtranscho from viaje where idviaje=" & rs(3) & ") xx where t.idtranscho=xx.idtranscho"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsbaja = cmd.ExecuteReader
            cmd.Dispose()

            If rsSolo.Read = True And rsbaja.Read = True Then
                If rsSolo(0) = 0 And rsbaja(0) = 0 Then
                    mes1 = rs(2)

                    cuuuuuuu = dia1 - dia
                    menos = mes1 - mes

                    If menos = 0 And cuuuuuuu = 3 Then
                        xd = 1

                        elegircoorychofer.Show()
                        elegircoorychofer.TextBox7.Text = rs(0)


                        sql = "select dni from conductor where borrado=false "
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        While rs.Read = True

                            elegircoorychofer.ComboBox1.Items.Add(rs(0))

                        End While

                        sql = "select dni from coordinador where borrado=false"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        While rs.Read = True

                            elegircoorychofer.ComboBox2.Items.Add(rs(0))



                        End While
                    End If
                End If

            End If




        End While


    End Sub
    Public Sub Viaje()

        fecha = Format(Today.Date, "yyyy/MM/dd")
        sql = "select idviaje from almanaque where fechadeinicio='" & fecha & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        If rs.Read = True Then


            sql = "select c.idcur from contrato c,(Select idcontrato from viaje where idviaje='" & rs(0) & "') s where c.idcontra=s.idcontrato"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If ooooooooo = False Then
                    ooooooooo = True
                    sql = "select nombre,apellido,dni,menuespecial from alumno where idcurso='" & rs(0) & "'"
                    ds.Tables.Add("listado")
                    adp = New OdbcDataAdapter(sql, cnn)
                    adp.Fill(ds.Tables("listado"))
                    Form2.DataGridView1.DataSource = ds.Tables("listado")
                End If



                Form2.Show()




            End If
            sql = "update viaje set estado='En Curso' where idviaje=" & rs(0) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
        End If




        sql = "select idviaje from almanaque where fechadellegada='" & fecha & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        If rs.Read = True Then
            sql = "update viaje set estado='Finalizado' where idviaje=" & rs(0) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsbaja = cmd.ExecuteReader

            sql = "select idcur,idcontra from contrato c,(select idcontrato from viaje where idviaje='" & rs(0) & "') s where c.idcontra=s.idcontrato"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            If rs.Read = True Then

                sql = "update curso set borrado=true where idcurso='" & rs(0) & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsbaja = cmd.ExecuteReader

                sql = "update alumno set borrado=true where idcurso='" & rs(0) & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsbaja = cmd.ExecuteReader

                sql = "update contrato set borrado=true where idcur='" & rs(0) & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsbaja = cmd.ExecuteReader



                sql = "select idtranscho from viaje where idcontrato='" & rs(1) & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsbaja = cmd.ExecuteReader

                If rsbaja.Read = True Then
                    sql = "select idtrans from transchofer where idtranscho='" & rsbaja(0) & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsbaja = cmd.ExecuteReader

                    If rsbaja.Read = True Then

                        sql = "update transporte set disponible=true where idtran='" & rsbaja(0) & "'"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsbaja = cmd.ExecuteReader




                    End If


                End If
            End If
        End If



    End Sub


End Module
