Imports System.Data.Odbc
Public Class BorradoPaquete
    Dim b As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim s As Integer
    Dim ho As Integer


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

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()


        If rs.Read = True Then
            s = rs(0)

            sql = "select nombre from hotel where iddesti=" & rs(0) & " and borrado=false"
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


       



    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" Then
            sql = "select idpack from paquete where iddesti=" & s & " and idhotel=" & ho & " and borrado=False"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then


                sql = "update paquexcu set borrado=true where idpack=" & rs(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()


                sql = "update paquete set borrado=true where iddesti=" & s & " and idhotel=" & ho & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                MsgBox("La eliminacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                OpcionPaquete.Show()
                Me.Hide()

            Else
                MsgBox("El paquete no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If
        Else
            MsgBox("Por favor complete los campos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")

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

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        sql = "select idhotel from hotel where nombre='" & ComboBox2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        If rs.Read = True Then
            ho = rs(0)

        End If
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" Then

            sql = "select idpack from paquete where iddesti=" & s & " and idhotel=" & ho & " and borrado=False"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then
                If b = False Then

                    b = True
                    DDDEEE = True

                    sql = "select e.lugar,e.horadeldia,e.actividad,e.precio_persona from excursiones e,(Select idexc from paquexcu where idpack=" & rs(0) & " and borrado=false) s where e.borrado=false and e.idexcur=s.idexc"
                    ds.Tables.Add("excursiones")
                    adp = New OdbcDataAdapter(sql, cnn)
                    adp.Fill(ds.Tables("excursiones"))
                    Me.DataGridView1.DataSource = ds.Tables("excursiones")
                Else
                    DataGridView1.DataSource.clear()
                    sql = "select e.lugar,e.horadeldia,e.actividad,e.precio_persona from excursiones e,(Select idexc from paquexcu where idpack=" & rs(0) & " and borrado=false) s where e.borrado=false and e.idexcur=s.idexc"
                    adp = New OdbcDataAdapter(sql, cnn)
                    adp.Fill(ds.Tables("excursiones"))
                    Me.DataGridView1.DataSource = ds.Tables("excursiones")

                End If
            Else
                If b = True Then
                    DataGridView1.DataSource.clear()
                End If
            End If

        End If
    End Sub





End Class