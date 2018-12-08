Imports System.Data.Odbc
Public Class ModificacionContrato
    Dim rsd As OdbcDataReader
    Dim c As Integer = 0
    Dim b2 As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim d As Integer
    Dim cont As Integer = 1
    Dim fe As String
    Dim mon As Integer
    Dim añi As Integer
    Dim cooo As Integer = 1
    Dim rsss As OdbcDataReader

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Contrato.Show()
        Me.Hide()
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""

       
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""



        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If RadioButton2.Checked = True Then

            sql = "update contratofirma set borrado=true where idcontrato=" & TextBox1.Text & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()


            sql = "update contrato set borrado=true where idcontra=" & TextBox1.Text & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
        ElseIf RadioButton1.Checked = True Then

            If TextBox2.Text <> "" Then

                sql = "select count(*),idres from responsables where dni=" & TextBox2.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then

                    If rs(0) = 0 Then

                        d = MsgBox("El responsable ingresado como firmante uno, no existe, ¿desea registrarlo?", MsgBoxStyle.YesNo, "ADVERTENCIA")
                        If d = 6 Then
                            queeeeeee = True

                            Responsable.Show()
                            Me.Hide()


                        End If

                    Else

                        sql = "select count(*) from alumno a, (select idcur from contrato where idcontra=" & TextBox1.Text & ") xx where a.idcurso=xx.idcur and idrespon=" & rs(1) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsd = cmd.ExecuteReader
                        cmd.Dispose()
                        If rsd.Read = True Then

                            If rsd(0) = 1 Then

                                sql = "select idres from responsables where dni=" & TextBox4.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsd = cmd.ExecuteReader
                                cmd.Dispose()


                                If rsd.Read = True Then

                                    c = 1

                                    sql = "update contratofirma set idrespon=" & rs(1) & " where idrespon=" & rsd(0) & ""
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rsd = cmd.ExecuteReader
                                    cmd.Dispose()

                                End If


                            Else
                                d = MsgBox("El responsable ingresado como firmante uno, no esta registrado para el curso del contrato, es necesario modificar el responsable de un alumno del curso por el responsable ingresado si quiere utilizarlo.¿Desea ir a cambio de responsable?", MsgBoxStyle.YesNo,"ADVERTENCIA")
                                If d = 6 Then
                                    CambioResponsable.Show()
                                    Me.Hide()
                                    queeeeeee = True


                                End If

                            End If

                        End If


                    End If

                End If
            End If


            If TextBox3.Text <> "" Then

                sql = "select count(*),idres from responsables where dni=" & TextBox3.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then

                    If rs(0) = 0 Then

                        d = MsgBox("El responsable ingresado como firmante dos, no existe, ¿desea registrarlo?", MsgBoxStyle.YesNo, "ADVERTENCIA")
                        If d = 6 Then

                            Responsable.Show()
                            Me.Hide()
                            queeeeeee = True

                        End If
                    Else

                        sql = "select count(a.*) from alumno, (select idcur from contrato where idcontra=" & TextBox1.Text & ") xx where a.idcurso=xx.idcur and idrespon=" & rs(1) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsd = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs.Read = True Then

                            If rsd(0) = 1 Then



                                sql = "select idres from responsables where dni=" & TextBox5.Text & ""
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsd = cmd.ExecuteReader
                                cmd.Dispose()


                                If rsd.Read = True Then
                                    c = 1


                                    sql = "update contratofirma set idrespon=" & rs(1) & " where idrespon=" & rsd(0) & ""
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rsd = cmd.ExecuteReader
                                    cmd.Dispose()

                                End If


                            Else
                                d = MsgBox("El responsable ingresado como firmante dos, no esta registrado para el curso del contrato, es necesario modificar el responsable de un alumno del curso por el responsable ingresado si quiere utilizarlo.¿Desea ir a cambio de responsable?", MsgBoxStyle.YesNo, "ADVERTENCIA")
                                If d = 6 Then
                                    CambioResponsable.Show()
                                    Me.Hide()


                                End If
                            End If

                        End If


                    End If

                End If
            End If

            If ComboBox1.Text <> "" Then

                sql = "update contrato set estado='" & ComboBox1.Text & "' where idcontra=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsd = cmd.ExecuteReader
                cmd.Dispose()
                c = 1


                If ComboBox1.Text = "Firmado" Then


                   



                    sql = "select a.idrespon from alumno a,(select idcur from contrato where idcontra=" & TextBox1.Text & ") x where x.idcur=a.idcurso and a.liberado=false"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsd = cmd.ExecuteReader
                    cmd.Dispose()


                    While rsd.Read = True
                        fe = Today.Date
                        mon = Month(fe)
                        añi = Year(fe)

                        While cont < 13

                            mon = mon + 1

                            If mon > 12 Then
                                mon = 1
                                añi = añi + 1
                                sql = "insert into cuotas values(''," & cont & ",null,'disponible'," & rsd(0) & ",'" & añi & "/" & mon & "/20' ,false)"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                            Else
                                sql = "insert into cuotas values(''," & cont & ",null,'disponible'," & rsd(0) & ",'" & añi & "/" & mon & "/20' ,false)"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()

                            End If
                            cont = cont + 1
                        End While

                        cont = 1


                    End While
                    sql = "select idviaje from viaje where idcontrato=" & TextBox1.Text & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()




                    If rs.Read = True Then


                        sql = "select a.idrespon from alumno a,(select idcur from contrato where idcontra=" & TextBox1.Text & ") x, responsables r where x.idcur=a.idcurso and r.acompañante=true and a.idrespon=r.idres"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsd = cmd.ExecuteReader
                        cmd.Dispose()

                        While rsd.Read = True

                            If cooo < 3 Then
                                sql = "insert into acompañanteviaje values(''," & rsd(0) & "," & rs(0) & ",false)"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rsss = cmd.ExecuteReader
                                cmd.Dispose()

                                cooo = cooo + 1

                            End If

                        End While


                    End If
                  
                  

                    sql = "insert into viaje values(''," & var1Viaje & "," & var2Viaje & ",'" & var3Viaje & " " & var4Viaje & "','Pendiente',false)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    sql = "insert into almanaque values(''," & var1Alma & ",'" & var2Alma & "','" & var3Alma & "',false)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    

                Else
                    sql = "update contratofirma set borrado=true where idcontrato=" & TextBox1.Text & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsd = cmd.ExecuteReader
                    cmd.Dispose()
                End If

            End If

            If c = 0 Then
                MsgBox("Por favor complete algun campo que desea cambiar", MsgBoxStyle.OkOnly, "ADVERTENCIA")


            End If

        ElseIf RadioButton1.Checked = False And RadioButton2.Checked = False Then

            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")


        End If
        If c = 1 Then

            MsgBox("Los cambios fueron realizados con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
            Contrato.Show()
            Me.Hide()
            Contrato.DataGridView1.DataSource.clear()
            If b2 = False Then
                b2 = True
                sql = "select * from contrato where borrado=False"
                ds.Tables.Add("contrato")
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("contrato"))
                Contrato.DataGridView1.DataSource = ds.Tables("contrato")


            Else
                Contrato.DataGridView1.DataSource.clear()
                sql = "select * from contrato where borrado=false "
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("contrato"))
                Contrato.DataGridView1.DataSource = ds.Tables("contrato")


            End If
        End If
    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click

    End Sub
End Class