Imports System.Data.Odbc
Public Class Destino
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim rs1 As OdbcDataReader


    Private Sub Destino_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call conexion()
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Seleccion.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select count(*) from destino where nombre='" & TextBox1.Text & "' and provincia='" & TextBox2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            If rs(0) = 0 Then
                If TextBox1.Text <> "" And TextBox2.Text <> "" Then
                    sql = "Insert into destino values('','" & TextBox1.Text & "','" & TextBox2.Text & "',false)"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs1 = cmd.ExecuteReader
                    cmd.Dispose()

                    MsgBox("Se ingreso correctamente", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                Else
                    MsgBox("Por Favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                

                End If
            Else
                MsgBox("El destino ya existe", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                TextBox1.Text = ""
                TextBox2.Text = ""
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


    Private Sub Destino_Load_1(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub
End Class