Imports System.Data.Odbc
Public Class ModificacionChofer
    Dim c As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sql = "select count(*) from conductor where dni=" & TextBox1.Text & " and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            If rs.Read = True Then

                If rs(0) = 1 Then

                    MsgBox("El DNI es valido", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True

                Else

                    MsgBox("El DNI no es valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")


                End If

            End If
        Else
            MsgBox("Por favor ingrese un dni valido", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub ModificacionChofer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then

            TextBox4.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False

            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpcionChofer.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False

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


            sql = "update conductor set borrado=true where dni=" & TextBox1.Text & ""
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
                sql = "update conductor set nombre='" & TextBox2.Text & "' where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If



            If TextBox3.Text <> "" Then
                c = 1
                sql = "update conductor set apellido='" & TextBox3.Text & "' where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If


            If TextBox5.Text <> "" Then
                c = 1
                sql = "update conductor set direccion='" & TextBox5.Text & "' where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox6.Text <> "" Then
                c = 1
                sql = "update conductor set telefono=" & TextBox6.Text & " where dni=" & TextBox1.Text & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If

            If TextBox4.Text <> "" Then
                c = 1
                sql = "update conductor set dni=" & TextBox4.Text & " where dni='" & TextBox1.Text & "'"
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
                RadioButton1.Enabled = False
                RadioButton1.Checked = False
                RadioButton2.Enabled = False

            Else
                MsgBox("Por favor ingrese datos en algun campo para modificar", MsgBoxStyle.OkOnly, "ADVERTENCIA")


            End If

        ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor verifique los datos del dni del chofer", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        Else
            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If

    End Sub
End Class