Imports System.Data.Odbc
Public Class VisualizacionCuotas
    Dim ac As String
    Dim b As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim idres As Integer
    Dim validacion As Integer
    Dim rsExistencia As OdbcDataReader
    Dim rsasd As OdbcDataReader
    Dim rspaagado As OdbcDataReader
    Dim cuenta As Integer
    Dim cuentaT As Integer
    Dim ab As String
    Dim rscontarnopagadas As OdbcDataReader
    Dim rscontarsipagadas As OdbcDataReader
    Dim cuot As Integer





    Private Sub VisualizacionCuotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click

        If b = True Then
            DataGridView1.DataSource.clear()
        End If
        OpcionPago.Show()
        Me.Hide()
        ComboBox1.Text = ""
        ComboBox2.Text = ""

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







        sql = "select idrespon from alumno where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            idres = rs(0)


            If b = False Then
                b = True
                sql = "select NroCuota,fechapago,estado,fechavenci from cuotas where idrespon=" & rs(0) & ""
                ds.Tables.Add("cuotas")
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("cuotas"))
                DataGridView1.DataSource = ds.Tables("cuotas")


            Else
                DataGridView1.DataSource.clear()
                sql = "select Nrocuota,fechapago,estado,fechavenci from cuotas where idrespon=" & rs(0) & ""
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("cuotas"))
                DataGridView1.DataSource = ds.Tables("cuotas")


            End If
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

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Text = ""
        sql = "select apellido from alumno where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read = True
            ComboBox2.Items.Add(rs(0))

        Loop
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" And ac <> 0 And ab <> "no disponible" Then

            sql = "select count(*) from cuotas where nrocuota=" & ac & " and estado='pagado' and idrespon='" & idres & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 0 Then
                    sql = "select count(*) from cuotas where idrespon=" & idres & " and fechavenci<'" & Format(Today.Date, "yyyy/MM/dd") & "' and estado<>'disponible' and estado<>'no disponible'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    If rs.Read = True Then



                        If rs(0) = 3 Then
                            MsgBox("Para pagar la cuota, debera pagar un interes de 2000 pesos por adeudar 3 cuotas", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                            PagoCuotas.txt1.Text = ComboBox1.Text
                            PagoCuotas.txt2.Text = ComboBox2.Text
                            PagoCuotas.txt3.Text = 2000
                            PagoCuotas.TextBox1.Text = ""
                            PagoCuotas.Show()
                            Me.Hide()
                            cuot = 1


                        ElseIf rs(0) >= 4 Then

                            sql = "select count(*) from cuotas where idrespon='" & idres & "' and estado='no disponible'"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsExistencia = cmd.ExecuteReader
                            cmd.Dispose()

                            If rsExistencia.Read = True Then
                                If rsExistencia(0) = 0 Then
                                    validacion = MsgBox("Tiene una deuda de 4 o mas cuotas sin pagar, elija una de las dos opciones. Si(lo enviamos a deudores y paga todo el año que viene) No(cancela el viaje)", MsgBoxStyle.YesNo, "Tramite")

                                    If validacion = 6 Then



                                        sql = "update cuotas set estado='no disponible' where idrespon=" & idres & " and estado<>'pagado'"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rsExistencia = cmd.ExecuteReader
                                        cmd.Dispose()

                                        sql = "select a.idcurso from alumno a, (Select idres from responsables where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where a.idrespon=xx.idres"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rsasd = cmd.ExecuteReader
                                        cmd.Dispose()
                                        If rsasd.Read = True Then

                                            sql = "select idcontra,montototal from contrato where idcur=" & rsasd(0) & ""
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rsExistencia = cmd.ExecuteReader

                                            If rsExistencia.Read = True Then

                                                sql = "select a.fechadeinicio from almanaque a,(select idviaje from viaje where idcontrato='" & rsExistencia(0) & "') s where a.idviaje=s.idviaje"
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rsasd = cmd.ExecuteReader

                                                If rsasd.Read = True Then


                                                    sql = "select count(*) from cuotas where idrespon='" & idres & "' and estado<>'pagado'"
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rscontarnopagadas = cmd.ExecuteReader
                                                    sql = "select count(*) from cuotas where idrespon='" & idres & "' and estado='pagado'"
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rscontarsipagadas = cmd.ExecuteReader

                                                    If rscontarnopagadas.Read = True And rscontarsipagadas.Read = True Then



                                                        cuenta = rsExistencia(1) / (rscontarnopagadas(0) + rscontarsipagadas(0))
                                                        cuentaT = cuenta * rscontarnopagadas(0)
                                                        fecha = Format(rsasd(0), "yyyy/MM/dd")


                                                        fecha = DateAdd("m", -1, fecha)
                                                        sql = "insert into cuotas values(''," & rscontarnopagadas(0) + rscontarsipagadas(0) + 1 & ",null,'disponible','" & idres & "','" & fecha & "',false)"
                                                        cmd = New OdbcCommand(sql, cnn)
                                                        cmd.CommandType = CommandType.Text
                                                        rsasd = cmd.ExecuteReader

                                                        MsgBox("Opcion procesada", MsgBoxStyle.OkOnly, "COMPLETADO")
                                                        OpcionPago.Show()
                                                        Me.Hide()



                                                    End If


                                                End If
                                            End If

                                        End If




                                    Else

                                        sql = "select count(*) from cuotas where idrespon=" & idres & " and estado='pagado'"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rspaagado = cmd.ExecuteReader
                                        cmd.Dispose()
                                        If rs.Read = True Then


                                            sql = "select a.idcurso from alumno a, (Select idres from responsables where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where a.idrespon=xx.idres"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rs = cmd.ExecuteReader
                                            cmd.Dispose()
                                            If rs.Read = True Then

                                                sql = "select montototal from contrato where idcur=" & rs(0) & ""
                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader

                                                If rs.Read = True Then


                                                    cuenta = rs(0) / 12
                                                    cuentaT = (rspaagado(0) * cuenta) * 0.3

                                                    MsgBox("Tiene una devolucion de " & cuentaT & " pesos", MsgBoxStyle.OkOnly, "completado")
                                                    If cuentaT > 0 Then
                                                        sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','devolucion'," & cuentaT & "," & idres & ",null)"
                                                        cmd = New OdbcCommand(sql, cnn)
                                                        cmd.CommandType = CommandType.Text
                                                        rs = cmd.ExecuteReader
                                                        cmd.Dispose()
                                                    End If

                                                    sql = "update cuotas set estado='no disponible' where idrespon=" & idres & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()
                                                    MsgBox("Opcion procesada")
                                                    MsgBox("Se lo volvera al menu de inicio")
                                                    sql = "update alumno set estado='no viaja' where idrespon=" & idres & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()
                                                    Recibo.Show()
                                                    Me.Hide()
                                                    Recibo.Label1.Text = "Cloud 3™"
                                                    Recibo.Label5.Text = "Viajes de egresados"
                                                    Recibo.Label3.Text = cuentaT
                                                    Recibo.Label4.Text = cuentaT
                                                    Recibo.Label2.Text = "Devolucion de dinero por cancelacion de viaje al señor" & ComboBox1.Text & "" & ComboBox2.Text & ""
                                                    Me.Close()
                                                    inicio.Show()

                                                End If

                                            End If


                                        End If

                                    End If

                                End If

                            End If

                        Else
                            PagoCuotas.txt1.Text = ComboBox1.Text
                            PagoCuotas.txt2.Text = ComboBox2.Text


                            sql = "select count(*) from cuotas where idrespon=" & idres & "  and estado='no disponible'"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsExistencia = cmd.ExecuteReader
                            cmd.Dispose()

                            If rsExistencia.Read = True Then
                                If rsExistencia(0) = 0 Then
                                    sql = "select idcurso from alumno  where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "'"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                    If rs.Read = True Then

                                        sql = "select montototal from contrato where idcur=" & rs(0) & ""
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rs = cmd.ExecuteReader

                                        If rs.Read = True Then

                                            sql = "select count(*) from cuotas where idrespon='" & idres & "'"

                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rsasd = cmd.ExecuteReader
                                            If rsasd.Read = True Then
                                                PagoCuotas.txt3.Text = rs(0) / rsasd(0)
                                                PagoCuotas.TextBox1.Text = ac
                                                PagoCuotas.Show()
                                                Me.Hide()
                                            End If

                                        End If

                                    End If
                                Else
                                    sql = "select a.idcurso from alumno a, (Select idres from responsables where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where a.idrespon=xx.idres"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                    If rs.Read = True Then

                                        sql = "select montototal from contrato where idcur=" & rs(0) & ""
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rs = cmd.ExecuteReader

                                        If rs.Read = True Then
                                            sql = "select count(*) from cuotas where idrespon='" & idres & "' and estado<>'pagado'"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rscontarnopagadas = cmd.ExecuteReader
                                            sql = "select count(*) from cuotas where idrespon='" & idres & "' and estado='pagado'"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rscontarsipagadas = cmd.ExecuteReader

                                            If rscontarnopagadas.Read = True And rscontarsipagadas.Read = True Then



                                                cuenta = rs(0) / (rscontarnopagadas(0) + rscontarsipagadas(0) - 1)
                                                cuentaT = cuenta * rscontarnopagadas(0)
                                                PagoCuotas.TextBox1.Text = ac
                                                PagoCuotas.txt3.Text = cuentaT

                                                PagoCuotas.Show()
                                                Me.Hide()
                                            End If

                                        End If

                                    End If

                                End If

                            End If




                        End If



                    End If
                Else
                    MsgBox("La cuota seleccionada ya esta pagada", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If

            End If


        ElseIf ComboBox1.Text = "" Or ComboBox2.Text = "" Then

            MsgBox("Por favor complete los campos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        ElseIf ac = 0 Then

            MsgBox("Por favor seleccione la cuota que desea pagar", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        ElseIf ab = "no disponible" Then

            MsgBox("Por favor seleccione la cuota que este disponible", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If








    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            ac = (DataGridView1.Rows(e.RowIndex).Cells("NroCuota").Value.ToString())
            ab = (DataGridView1.Rows(e.RowIndex).Cells("estado").Value.ToString())
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
            sql = "select count(*) from cuotas where idrespon=" & idres & " and estado='pagado'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rspaagado = cmd.ExecuteReader
            cmd.Dispose()
            If rspaagado.Read = True Then


                sql = "select a.idcurso from alumno a, (Select idres from responsables where nombre='" & ComboBox1.Text & "' and apellido='" & ComboBox2.Text & "') xx where a.idrespon=xx.idres"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                If rs.Read = True Then

                    sql = "select montototal from contrato where idcur=" & rs(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader

                    If rs.Read = True Then


                        cuenta = rs(0) / 12
                        cuentaT = (rspaagado(0) * cuenta) * 0.3


                        If cuentaT > 0 Then
                            sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','devolucion'," & cuentaT & "," & idres & ",null)"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()
                        End If

                        sql = "update cuotas set estado='no disponible' where idrespon=" & idres & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        sql = "update cuotas set fechavenci='0000/00/00' where idrespon=" & idres & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        MsgBox("Opcion procesada")
                        MsgBox("Se lo volvera al menu de inicio")
                        sql = "update alumno set estado='no viaja' where idrespon=" & idres & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        sql = "update alumno set borrado=true where idrespon=" & idres & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        sql = "update responsables set borrado=true where idres=" & idres & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        Recibo.Show()
                        Me.Hide()
                        Recibo.Label1.Text = "Cloud 3™"
                        Recibo.Label5.Text = "Viajes de egresados"
                        Recibo.Label3.Text = cuentaT
                        Recibo.Label4.Text = cuentaT
                        Recibo.Label2.Text = "Devolucion de dinero por cancelacion de viaje al señor" & ComboBox1.Text & "" & ComboBox2.Text & ""


                        Me.Close()
                        inicio.Show()

                    End If

                End If


            End If
        Else

            MsgBox("Por favor complete los campos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If






    End Sub

End Class