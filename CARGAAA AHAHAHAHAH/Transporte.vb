Imports System.Data.Odbc
Public Class Transporte
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then


            sql = "insert into transporte values('','nuevo'," & TextBox1.Text & ",'" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "'," & TextBox5.Text & ",true,false)"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            TextBox1.Text = ""
            TextBox5.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            MsgBox("Todo ok", MsgBoxStyle.OkOnly, "COMPLETADO")


        Else
            MsgBox("Por favor ingrese los datos faltantes", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If



    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If asp = True Then

            CC.Show()
            Me.Hide()
            asp = False
        Else


            OpcionTransporte.Show()
            Me.Hide()
           
        End If
        TextBox1.Text = ""
        TextBox5.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

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

    Private Sub TextBox5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
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

    
End Class