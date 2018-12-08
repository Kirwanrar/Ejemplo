Imports System.Data.Odbc
Public Class VentanaUser

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click

        VisualizacionEscuela.Button1.Hide()

        inicio.btn1.Hide()
        OpcionPago.Button2.Hide()
        Seleccion.Button1.Hide()
        inicio.Button4.Hide()

        If txt1.Text <> "" Then
            If txt2.Text <> "" Then

                sql = "select count(*),permiso from usuario where nombre='" & txt1.Text & "' and contraseña='" & txt2.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                If rs.Read = True Then

                    If rs(0) = 1 Then
                        If rs(1) = "administrador" Then
                            inicio.btn1.Show()
                            VisualizacionEscuela.Button1.Show()

                            OpcionPago.Button2.Show()
                            inicio.btn1.Show()
                            Seleccion.Button1.Show()
                            inicio.Button4.Show()
                            inicio.Show()
                            Me.Hide()

                        Else
                            inicio.Show()
                            Me.Hide()
                        End If

                        If xd = 1 Then
                            inicio.Hide()
                            Me.Hide()

                        End If

                    Else
                        MsgBox("Usuario/contraseña incorrecto o no existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        txt1.Text = ""
                        txt2.Text = ""


                    End If





                    End If




                Else
                    MsgBox("Por favor complete los campos faltantes")

                End If
            Else
                MsgBox("Por favor complete los campos faltantes")

            End If



    End Sub


End Class