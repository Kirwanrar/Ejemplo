Imports System.Data.Odbc
Public Class Hotel
    Dim rs1 As OdbcDataReader
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        sql = "select count(*) from hotel where nombre='" & TextBox1.Text & "' and direccion='" & TextBox2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            If rs(0) = 0 Then
                If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And ComboBox1.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox4.Text <> "" Then

                    sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs.Read = True Then
                        sql = "insert into hotel values('','" & TextBox1.Text & "','" & TextBox2.Text & "'," & TextBox3.Text & "," & NumericUpDown1.Value & "," & rs(0) & "," & TextBox4.Text & ",false)"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs1 = cmd.ExecuteReader
                        cmd.Dispose()



                        sql = "select idhotel from hotel where nombre='" & TextBox1.Text & "'"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs1 = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs1.Read = True Then



                            sql = "insert into habitacion values('','" & TextBox5.Text & "'," & TextBox6.Text & "," & TextBox7.Text & "," & rs1(0) & ")"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs1 = cmd.ExecuteReader
                            cmd.Dispose()



                            MsgBox("Se ingreso correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")
                            TextBox1.Text = ""
                            TextBox3.Text = ""
                            TextBox2.Text = ""
                            NumericUpDown1.Text = 0
                            TextBox5.Text = ""
                            TextBox6.Text = ""
                            TextBox7.Text = ""
                            ComboBox1.Text = ""
                            TextBox4.Text = ""

                        End If
                    End If

                Else
                    MsgBox("Por Favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                End If
            Else
                MsgBox("El hotel ya existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                NumericUpDown1.Text = 0
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                ComboBox1.Text = ""
                TextBox4.Text = ""

            End If
        End If



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Items.Clear()
        Seleccion.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        NumericUpDown1.Text = 0
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
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

    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


End Class