Imports System.Data.Odbc
Public Class Excursiones
    Dim rs As OdbcDataReader
    Dim sql As String
    Dim rs2 As OdbcDataReader
    Dim comprobacion As Integer = 0



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Items.Clear()
        Me.Hide()
        OpcionExcursiones.Show()
        TextBox1.Text = ""

        TextBox3.Text = ""
        TextBox4.Text = ""

        MaskedTextBox1.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox3.Text <> "" And TextBox4.Text <> "" And MaskedTextBox1.Text <> "" And ComboBox1.Text <> "" And TextBox1.Text Then

            If comprobacion = 0 Then



                sql = "select iddestino from destino where nombre='" & ComboBox1.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then


                    sql = "select count(*) from excursiones where iddesti=" & rs(0) & " and actividad='" & TextBox4.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs2 = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs2.Read = True Then
                        If rs2(0) <> 0 Then

                            MsgBox("Ya esta registrada esa excursion", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            MaskedTextBox1.Text = ""
                            ComboBox1.Text = ""
                            TextBox1.Text = ""

                        Else
                            sql = "insert into excursiones values('','" & TextBox3.Text & "','" & MaskedTextBox1.Text & "','" & TextBox4.Text & "'," & rs(0) & "," & TextBox1.Text & ",false)"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs2 = cmd.ExecuteReader
                            cmd.Dispose()
                            TextBox1.Text = ""

                            TextBox3.Text = ""
                            TextBox4.Text = ""

                            MaskedTextBox1.Text = ""
                            ComboBox1.Text = ""

                            MsgBox("Su seleccion fue agregada correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")



                        End If
                    End If


                End If
            Else

                MsgBox("POR FAVOR INGRESE UNA HORA DEL DIA VALIDA!!!", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            End If

        Else
            MsgBox("Ingrese los datos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If

    End Sub

    Private Sub Excursiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

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

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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



    Private Sub MaskedTextBox1_TypeValidationCompleted(sender As Object, e As System.Windows.Forms.TypeValidationEventArgs) Handles MaskedTextBox1.TypeValidationCompleted
        If MaskedTextBox1.Text <= "23:59" Then
            comprobacion = 0
        Else
            comprobacion = 1

            MsgBox("Por favor ingrese una hora del dia valida", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub
End Class