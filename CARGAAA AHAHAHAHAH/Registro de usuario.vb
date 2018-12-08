Imports System.Data.Odbc
Public Class RegistroUser

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        If txt1.Text <> "" Then

            If txt2.Text <> "" Then
                If ComboBox1.Text <> "" Then

                    sql = "insert into usuario values('','" & txt1.Text & "','" & txt2.Text & "','" & ComboBox1.Text & "')"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    MsgBox("Registro completado", MsgBoxStyle.OkOnly, "COMPLETADO")
                    txt1.Text = ""
                    txt2.Text = ""
                    ComboBox1.Text = ""

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpcionUser.Show()
        Me.Hide()
        txt1.Text = ""
        txt2.Text = ""
        ComboBox1.Text = ""

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
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

End Class