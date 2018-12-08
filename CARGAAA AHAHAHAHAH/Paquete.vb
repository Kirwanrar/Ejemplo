Imports System.Data.Odbc
Public Class Paquete
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b As Boolean = False
    Dim ac As Integer
    Dim rss As OdbcDataReader


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpcionPaquete.Show()
        Me.Hide()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        If b = True Then
            DataGridView1.DataSource.clear()
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


        sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()


        If rs.Read = True Then

            sql = "select nombre from hotel where iddesti=" & rs(0) & " and borrado=False"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            ComboBox2.Text = ""



            ComboBox2.Items.Clear()
            While rs.Read = True


                ComboBox2.Items.Add(rs(0))



            End While


        End If


        sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then

            If b = False Then

                b = True

                sql = "select idexcur as Nro_Excursion,lugar,horadeldia,actividad,precio_persona from excursiones where iddesti=" & rs(0) & " and borrado=False"
                ds.Tables.Add("excursiones")
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                Me.DataGridView1.DataSource = ds.Tables("excursiones")
            Else
                DataGridView1.DataSource.clear()
                sql = "select idexcur as Nro_Excursion,lugar,horadeldia,actividad,precio_persona from excursiones where iddesti=" & rs(0) & " and borrado=False"
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                Me.DataGridView1.DataSource = ds.Tables("excursiones")

            End If





        End If





    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" Then


            sql = "select count(*),p.idpack from paquete p, (select iddestino from destino where nombre='" & ComboBox1.Text & "') x, (select idhotel from hotel where nombre='" & ComboBox2.Text & "') s where p.iddesti=x.iddestino and p.idhotel=s.idhotel and p.borrado=False"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    If ac >= 0 Then

                        sql = "select count(*) from paquexcu where idpack=" & rs(1) & " and idexc=" & ac & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rss = cmd.ExecuteReader
                        cmd.Dispose()

                        If rss.Read = True Then

                            If rss(0) = 0 Then




                                sql = "insert into paquexcu values(''," & rs(1) & "," & ac & ",'" & Format(DateTimePicker1.Value.Date, "yyyy/MM/dd") & "',false)"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                                MsgBox("Su seleccion fue agregada correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")

                            Else

                                MsgBox("Esta excursion ya esta registrada para este paquete, por favor elija otra")
                            End If

                        End If
                    Else
                        MsgBox("Por favor seleccione una excursion", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If

                Else
                    sql = "select h.idhotel, x.desti from hotel h, (select iddestino desti from destino where nombre='" & ComboBox1.Text & "') x where h.nombre='" & ComboBox2.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    If rs.Read = True Then




                        sql = "insert into paquete values(''," & rs(1) & "," & rs(0) & ",false)"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        sql = "select count(*),p.idpack from paquete p, (select iddestino from destino where nombre='" & ComboBox1.Text & "') x, (select idhotel from hotel where nombre='" & ComboBox2.Text & "') s where p.iddesti=x.iddestino and p.idhotel=s.idhotel and p.borrado=false"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        If rs.Read = True Then

                            If rs(0) = 1 Then



                                sql = "insert into paquexcu values(''," & rs(1) & "," & ac & ",'" & Format(DateTimePicker1.Value.Date, "yyyy/MM/dd") & "',false)"
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                                MsgBox("Su seleccion fue agregada correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")




                            End If



                        End If


                    End If
                End If

            End If
        Else
            MsgBox("Por favor complete los campos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If



    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            ac = (DataGridView1.Rows(e.RowIndex).Cells("Nro_Excursion").Value.ToString())

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

End Class