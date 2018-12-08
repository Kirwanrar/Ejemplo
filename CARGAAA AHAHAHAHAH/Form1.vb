
Imports System.Data.Odbc
Public Class ModificacionResponsable
    Dim c As Integer = 0
    Dim rsss As OdbcDataReader

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*) from responsables where dni='" & TextBox1.Text & "' and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    MsgBox("El DNI es valido")
                    TextBox1.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True

                Else

                    MsgBox("El DNI no es valido")


                End If

            End If
        Else
            MsgBox("Por favor ingrese un dni valido")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
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


            sql = "update responsables set borrado=true where dni='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            sql = "select idres from responsables where dni ='" & TextBox1.Text & "'"
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
                MsgBox("El proceso se realizo con exito")
                RadioButton1.Enabled = False
                RadioButton2.Checked = False
                RadioButton2.Enabled = False
            End If




        ElseIf RadioButton1.Checked = True Then


            If TextBox2.Text <> "" Then
                c = 1
                sql = "update responsable set nombre=" & TextBox2.Text & " where dni='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()



            ElseIf TextBox3.Text <> "" Then
                c = 1
                sql = "update responsable set apellido=" & TextBox3.Text & " where dni='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()


            ElseIf TextBox5.Text <> "" Then
                c = 1
                sql = "update responsable set direccion=" & TextBox5.Text & " where dni='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            ElseIf TextBox6.Text <> "" Then
                c = 1
                sql = "update responsable set telefono=" & TextBox6.Text & " where dni='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            ElseIf TextBox4.Text <> "" Then
                c = 1
                sql = "update responsable set dni=" & TextBox4.Text & " where dni='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If


            If c = 1 Then


                MsgBox("La modificacion se realizo con exito")
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
                MsgBox("Por favor ingrese datos en algun campo para modificar")


            End If

        ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor verifique los datos del dni del alumno")
        Else
            MsgBox("Por favor seleccione una opcion")

        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpcionResponsable.Show()
        Me.Hide()

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

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class
End Class