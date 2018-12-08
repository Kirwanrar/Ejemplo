Imports System.Data.Odbc
Public Class ModificacionTransporte
    Dim c As Integer = 0
    Dim rsss As OdbcDataReader
    Private Sub ModificacionTransporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*) from transporte where matricula='" & TextBox1.Text & "' and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    MsgBox("La matricula es valido", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True

                Else

                    MsgBox("La matricula no es valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")


                End If

            End If
        Else
            MsgBox("Por favor ingrese una matricula valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
            TextBox7.Enabled = True
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox7.Enabled = False
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox2.Text = ""
            TextBox7.Text = ""
        End If

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If RadioButton2.Checked = True Then
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox3.Text = ""
            TextBox2.Text = ""
            TextBox7.Text = ""

            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox7.Enabled = False


            sql = "update transporte set borrado=true where matricula='" & TextBox1.Text & "'"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

           
            TextBox1.Text = ""

            TextBox1.Enabled = True
            MsgBox("El proceso se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
            RadioButton1.Enabled = False
            RadioButton2.Checked = False
            RadioButton2.Enabled = False





        ElseIf RadioButton1.Checked = True Then


            If TextBox2.Text <> "" Then
                c = 1
                sql = "update transporte set estado='" & TextBox2.Text & "' where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

            End If


            If TextBox3.Text <> "" Then
                c = 1
                sql = "update transporte set cantias=" & TextBox3.Text & " where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If


            If TextBox5.Text <> "" Then
                c = 1
                sql = "update transporte set marca='" & TextBox5.Text & "' where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox6.Text <> "" Then
                c = 1
                sql = "update transporte set precio_persona=" & TextBox6.Text & " where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox7.Text <> "" Then
                c = 1
                sql = "update transporte set descripcion='" & TextBox4.Text & "' where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox4.Text <> "" Then
                c = 1
                sql = "update transporte set matricula='" & TextBox4.Text & "' where matricula='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If


            If c = 1 Then


                MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
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
                TextBox7.Enabled = False

                RadioButton1.Enabled = False
                RadioButton1.Checked = False
                RadioButton2.Enabled = False

            Else
                MsgBox("Por favor ingrese datos en algun campo para modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")


            End If

            ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor verifique los datos de la matricula", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            Else
            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress

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

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress

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

    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress

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

    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        OpcionTransporte.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
    End Sub
End Class