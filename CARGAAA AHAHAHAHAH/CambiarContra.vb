Imports System.Data.Odbc
Public Class CambiarContra

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        If txt1.Text <> "" Then

            If txt2.Text <> "" Then

                If txt3.Text <> "" Then

                    sql = "select count(*) from usuario where contraseña='" & txt2.Text & "' and nombre='" & txt1.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs.Read = True Then

                        If rs(0) = 1 Then

                            sql = "update usuario set contraseña='" & txt3.Text & "' where nombre='" & txt1.Text & "' and contraseña='" & txt2.Text & "'"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            MsgBox("Actualziacion completada", MsgBoxStyle.OkOnly, "COMPLETADO")
                            txt1.Text = ""
                            txt2.Text = ""
                            txt3.Text = ""
                        Else
                            MsgBox("La contraseña vieja ingresada no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        End If

                    End If


                Else
                    MsgBox("por favor complete los campos restantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            Else
                MsgBox("por favor complete los campos restantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            End If
        Else
            MsgBox("por favor complete los campos restantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpcionUser.Show()
        Me.Hide()
        txt1.Text = ""
        txt2.Text = ""
        txt3.Text = ""
    End Sub
End Class