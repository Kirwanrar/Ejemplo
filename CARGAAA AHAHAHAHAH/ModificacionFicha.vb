Imports System.Data.Odbc
Public Class ModificacionFicha
    Dim rs As OdbcDataReader
    Dim sql As String
    Dim rsa As OdbcDataReader
    Dim rsi As OdbcDataReader
    Dim enf As String
    Dim op As Boolean
    Dim ale As String
    Dim trat As String
    Dim id As Integer


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub modificacionFicha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call conexion()

    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As System.EventArgs) Handles CheckBox1.Click
        CheckBox4.Checked = False
        CheckBox1.Checked = True
        TextBox6.Enabled = True
    End Sub

    Private Sub CheckBox4_Click(sender As Object, e As System.EventArgs) Handles CheckBox4.Click
        CheckBox1.Checked = False
        enf = "Ninguna"
        CheckBox4.Checked = True
        TextBox6.Enabled = False
    End Sub

    Private Sub CheckBox8_Click(sender As Object, e As System.EventArgs) Handles CheckBox8.Click
        CheckBox7.Checked = False
        op = True
        CheckBox8.Checked = True
    End Sub

    Private Sub CheckBox7_Click(sender As Object, e As System.EventArgs) Handles CheckBox7.Click
        CheckBox8.Checked = False
        op = False
        CheckBox7.Checked = True
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As System.EventArgs) Handles CheckBox2.Click
        CheckBox5.Checked = False
        CheckBox2.Checked = True
        TextBox2.Enabled = True
    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As System.EventArgs) Handles CheckBox5.Click
        CheckBox2.Checked = False
        TextBox2.Enabled = False
        CheckBox5.Checked = True
        ale = "Ninguna"
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As System.EventArgs) Handles CheckBox3.Click
        CheckBox3.Checked = True
        CheckBox6.Checked = False
        TextBox3.Enabled = True
    End Sub

    Private Sub CheckBox6_Click(sender As Object, e As System.EventArgs) Handles CheckBox6.Click
        CheckBox6.Checked = True
        CheckBox3.Checked = False
        TextBox3.Enabled = False
        trat = "Ninguno"
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*),idalum from alumno where dni=" & TextBox1.Text & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsi = cmd.ExecuteReader
            cmd.Dispose()
            If rsi.Read = True Then
                If rsi(0) = 1 Then
                    id = rsi(1)
                    sql = "select count(*) from historialmedico where idalum=" & rsi(1) & " and borrado=false"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs.Read = True Then
                        If rs(0) = 1 Then

                            TextBox6.Enabled = False
                            RadioButton1.Enabled = True
                            RadioButton2.Enabled = True
                        Else
                            MsgBox("El Dni ingresado no tiene una ficha medica registrada", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        End If
                    End If
                Else
                    MsgBox("El dni ingresado no corresponde con el de un alumno registrado", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            End If
        Else
            MsgBox("Por favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox4.Text = ""
        TextBox7.Text = ""
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox5.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        CheckBox4.Enabled = False
        CheckBox5.Enabled = False
        CheckBox6.Enabled = False
        CheckBox7.Enabled = False
        CheckBox8.Enabled = False
    End Sub

    Private Sub RadioButton1_Click(sender As System.Object, e As System.EventArgs) Handles RadioButton1.Click
        TextBox5.Enabled = True
        TextBox4.Enabled = True
        TextBox7.Enabled = True
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
        CheckBox5.Enabled = True
        CheckBox6.Enabled = True
        CheckBox7.Enabled = True
        CheckBox8.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        OpcionFicha.Show()
        TextBox1.Text = ""
        TextBox6.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If RadioButton2.Checked = True Then
            sql = "update historialmedico set borrado=true where idalum =" & rsi(1) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()


            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            TextBox4.Enabled = False
            TextBox1.Text = ""
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox5.Enabled = False
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            MsgBox("EL borrado se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            TextBox1.Enabled = True

        ElseIf RadioButton1.Checked = True Then
            If TextBox1.Text <> "" Then
                If TextBox5.Text <> "" Then
                    If CheckBox1.Checked = True And TextBox6.Text <> "" Or CheckBox4.Checked = True Then
                        If CheckBox8.Checked = True Or CheckBox7.Checked = True Then
                            If CheckBox2.Checked = True And TextBox2.Text <> "" Or CheckBox5.Checked = True Then
                                If CheckBox3.Checked = True And TextBox3.Text <> "" Or CheckBox6.Checked = True Then
                                    If TextBox4.Text <> "" Then
                                        If TextBox7.Text <> "" Then
                                            If CheckBox1.Checked = True Then
                                                enf = TextBox6.Text
                                            End If

                                            If CheckBox2.Checked = True Then
                                                ale = TextBox2.Text
                                            End If

                                            If CheckBox3.Checked = True Then
                                                trat = TextBox3.Text
                                            End If
                                            sql = "select count(*),idalum from alumno where dni=" & TextBox7.Text & " and borrado=false"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rsi = cmd.ExecuteReader
                                            cmd.Dispose()
                                            If rsi.Read = True Then
                                                If rsi(0) = 1 Then

                                                    sql = "update historialmedico set gruposangui='" & TextBox5.Text & "' where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set enfermedad='" & enf & "' where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set operado=" & op & " where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set alergias='" & ale & "' where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set tratamiento='" & trat & "' where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set obrasocial='" & TextBox4.Text & "' where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    sql = "update historialmedico set idalum=" & rsi(1) & " where idalum=" & id & ""
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()

                                                    TextBox2.Text = ""
                                                    TextBox3.Text = ""
                                                    TextBox4.Text = ""
                                                    TextBox5.Text = ""
                                                    TextBox6.Text = ""
                                                    TextBox7.Text = ""
                                                    TextBox2.Enabled = False
                                                    TextBox3.Enabled = False
                                                    TextBox5.Enabled = False
                                                    TextBox6.Enabled = False
                                                    TextBox7.Enabled = False
                                                    TextBox4.Enabled = False
                                                    TextBox1.Text = ""
                                                    CheckBox1.Enabled = False
                                                    CheckBox2.Enabled = False
                                                    CheckBox3.Enabled = False
                                                    CheckBox4.Enabled = False
                                                    CheckBox5.Enabled = False
                                                    CheckBox6.Enabled = False
                                                    CheckBox7.Enabled = False
                                                    CheckBox8.Enabled = False
                                                    MsgBox("La modificacion se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                                                    RadioButton1.Checked = False
                                                    RadioButton2.Checked = False
                                                    RadioButton1.Enabled = False
                                                    RadioButton2.Enabled = False
                                                    TextBox1.Enabled = True
                                                Else
                                                    MsgBox("El dni ingresado no corresponde con el de un alumno registrado", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                                End If
                                            Else
                                                MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                            End If
                                        Else
                                            MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                        End If
                                    Else
                                        MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                    End If
                                Else
                                    MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                End If
                            Else
                                MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                            End If
                        Else
                            MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        End If
                    Else
                        MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If
                Else
                    MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            Else
                MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

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


    Private Sub TextBox6_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
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


    Private Sub TextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
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


    Private Sub TextBox4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
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

    Private Sub ModificacionFicha_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class