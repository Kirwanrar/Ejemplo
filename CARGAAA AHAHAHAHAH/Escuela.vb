Imports System.Data.Odbc

Public Class Escuela


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click



        If asd = True Then

            CC.Show()
            Me.Hide()
            asd = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()

        Else


            OpcionEscuela.Show()
            Me.Hide()

            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
        End If





    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then

                If TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" Then

                    sql = "insert into escuelas values('','" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "',false)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()


                    MsgBox("La escuela fue agregada al sistema", MsgBoxStyle.OkOnly, "COMPLETADO")

                Else
                    MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")


                End If

            Else
                MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")

            End If

        Else
            MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")






        End If








    End Sub

    Private Sub Escuela_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

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

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
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

End Class