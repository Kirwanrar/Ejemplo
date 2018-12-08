Imports System.Data.Odbc
Public Class elegircoorychofer
    Dim condu As Integer
    Dim coor1 As Integer
    Dim coor2 As Integer


    Private Sub elegircoorychofer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" And ComboBox3.Text <> "" Then



            sql = "select idtranscho from viaje where idcontrato=" & TextBox7.Text & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then



                sql = "update transchofer set idconduc=" & condu & " where idtranscho=" & rs(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

            End If


           



            sql = "insert into viajecoor values(''," & TextBox7.Text & "," & coor1 & ")"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            sql = "insert into viajecoor values(''," & TextBox7.Text & "," & coor2 & ")"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            MsgBox("Muchas gracias, sera redirigido al menu de inicio", MsgBoxStyle.OkOnly, "COMPLETADO")
            inicio.Show()
            Me.Hide()



        Else
            MsgBox("Por favor complete los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")

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


        sql = "select dni from coordinador where dni<>" & ComboBox2.Text & ""
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        ComboBox3.Items.Clear()
        ComboBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""


        While rs.Read = True


            ComboBox3.Items.Add(rs(0))


        End While



        sql = "select idcoor,nombre,apellido from coordinador where dni=" & ComboBox2.Text & ""
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            coor1 = rs(0)

            TextBox3.Text = rs(1)
            TextBox4.Text = rs(2)
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

       



        sql = "select idconduc,nombre,apellido from conductor where dni=" & ComboBox1.Text & ""
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            condu = rs(0)
            TextBox1.Text = rs(1)
            TextBox2.Text = rs(2)



        End If

    End Sub

    Private Sub ComboBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox3.KeyPress
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

    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        sql = "select idcoor,nombre,apellido from coordinador where dni=" & ComboBox3.Text & ""
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then

            coor2 = rs(0)

            TextBox5.Text = rs(1)
            TextBox6.Text = rs(2)
        End If

    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click

    End Sub
End Class