Imports System.Data.Odbc
Public Class Cursos
    Dim sql As String
    Dim rsc As OdbcDataReader
    Dim l As Double
    Dim parte As Long




    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If ads = True Then

            CC.Show()
            Me.Hide()
            cbE.Items.Clear()
            TextBox1.Text = ""
            TextBox2.Text = ""
            ads = False


        Else

            Me.Hide()
            opcionCurso.Show()
            cbE.Items.Clear()
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then

                sql = "select idesc from escuelas where nombre='" & cbE.Text & "'"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsc = cmd.ExecuteReader
                cmd.Dispose()

                If rsc.Read = True Then
                    l = TextBox2.Text / 7
                    parte = Int(l)






                    sql = "insert into curso values('','" & TextBox1.Text & "'," & CInt(TextBox2.Text) & "," & rsc(0) & ",false," & parte & ")"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                   
                    TextBox1.Clear()
                    TextBox2.Clear()



                    MsgBox("El curso fue agregado al sistema", MsgBoxStyle.OkOnly, "COMPLETADO")
                    cbE.Items.Clear()
                    Me.Hide()
                    PantallaEleccion.Show()


                End If

            Else
                MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")



            End If

        Else
            MsgBox("COMPLETE LOS CAMPOS QUE FALTAN PLEASE", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If
       

    End Sub

    Private Sub Cursos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub cbE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbE.KeyPress
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