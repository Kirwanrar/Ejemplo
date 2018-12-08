Imports System.Data.Odbc
Public Class Responsable
    Dim c As Boolean = False



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ssss = False And aps = False And queeeeeee = False Then

            OpcionResponsable.Show()
            Me.Hide()

        ElseIf aps = True Then
            CC.Show()
            Me.Hide()

            aps = False
        ElseIf queeeeeee = True Then
            queeeeeee = False
            ModificacionContrato.Show()
            Me.Hide()

        Else

            Alumno.Show()
            Me.Hide()
            ssss = False

        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then

            If TextBox2.Text <> "" Then

                If TextBox3.Text <> "" Then


                    If TextBox4.Text <> "" Then

                        If TextBox5.Text <> "" Then

                            If CheckBox1.Checked = True Then
                                c = True

                            End If

                            sql = "insert into responsables values('','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "'," & TextBox5.Text & ",false," & c & ")"
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox5.Text = ""

                            MsgBox("El responsable fue agregado con exito", MsgBoxStyle.OkOnly, "COMPLETADO")

                        End If

                    Else
                        MsgBox("COMPLETE LOS CAMPOS QUE FALTAN ", MsgBoxStyle.OkOnly, "ADVERTENCIA")

                    End If

                Else
                    MsgBox("COMPLETE LOS CAMPOS QUE FALTAN ", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            Else
                MsgBox("COMPLETE LOS CAMPOS QUE FALTAN ", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If
        Else
            MsgBox("COMPLETE LOS CAMPOS QUE FALTAN ", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If
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
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub


    Private Sub Responsable_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub
End Class