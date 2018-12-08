Imports System.Data.Odbc
Public Class Chofer
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim rs1 As OdbcDataReader
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b1 As Boolean = False


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        OpcionChofer.Show()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""




    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select count(*) from conductor where dni='" & TextBox2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            If rs(0) = 0 Then
                If TextBox1.Text <> "" And TextBox3.Text <> "" And TextBox2.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then

                    sql = "insert into conductor values('','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "',false)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs1 = cmd.ExecuteReader
                    cmd.Dispose()

                    MsgBox("Se ingreso correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Text = ""
                    TextBox3.Text = ""
                    TextBox2.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""

                Else
                    MsgBox("Por Favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")



                End If
            Else
                MsgBox("El chofer ya existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox2.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""

            End If
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