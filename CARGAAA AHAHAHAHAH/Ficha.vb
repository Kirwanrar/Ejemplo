Imports System.Data.Odbc

Public Class Ficha
    Dim sql As String
    Dim rsa As OdbcDataReader
    Dim rs As OdbcDataReader
    Dim enf As String
    Dim op As Boolean
    Dim ale As String
    Dim trat As String


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox6.Text <> "" Then
            If TextBox5.Text <> "" Then
                If CheckBox1.Checked = True And TextBox1.Text <> "" Or CheckBox4.Checked = True Then
                    If CheckBox8.Checked = True Or CheckBox7.Checked = True Then
                        If CheckBox2.Checked = True And TextBox2.Text <> "" Or CheckBox5.Checked = True Then
                            If CheckBox3.Checked = True And TextBox3.Text <> "" Or CheckBox6.Checked = True Then
                                If TextBox4.Text <> "" Then
                                    sql = "select count(*),idalum from alumno where dni=" & TextBox6.Text & " and borrado=false"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rsa = cmd.ExecuteReader
                                    cmd.Dispose()
                                    If rsa.Read = True Then
                                        If rsa(0) = 1 Then
                                            If CheckBox1.Checked = True Then
                                                enf = TextBox1.Text
                                            End If

                                            If CheckBox2.Checked = True Then
                                                ale = TextBox2.Text
                                            End If

                                            If CheckBox3.Checked = True Then
                                                trat = TextBox3.Text
                                            End If

                                            sql = "insert into historialmedico values(''," & rsa(1) & ",'" & TextBox5.Text & "','" & enf & "'," & op & ",'" & ale & "','" & trat & "','" & TextBox4.Text & "',false)"
                                            cmd = New OdbcCommand(sql, cnn)
                                            cmd.CommandType = CommandType.Text
                                            rs = cmd.ExecuteReader
                                            cmd.Dispose()
                                            TextBox1.Text = ""
                                            TextBox2.Text = ""
                                            TextBox3.Text = ""
                                            TextBox4.Text = ""
                                            TextBox5.Text = ""
                                            TextBox6.Text = ""
                                            CheckBox1.Checked = False
                                            CheckBox2.Checked = False
                                            CheckBox3.Checked = False
                                            CheckBox4.Checked = False
                                            CheckBox5.Checked = False
                                            CheckBox6.Checked = False
                                            CheckBox7.Checked = False
                                            CheckBox8.Checked = False

                                            MsgBox("La ficha fue agregada con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                                        Else
                                            MsgBox("El dni egresado no corresponde con el de ningun alumno registrado", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                        End If
                                    Else
                                        MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                    End If
                                Else
                                    MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                End If
                            Else
                                MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                            End If
                        Else
                            MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                        End If
                    Else
                        MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If
                Else
                    MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
            Else
                MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
            End If
        Else
            MsgBox("Por Favor complete los datos que faltan", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If

    End Sub

    Private Sub Ficha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As System.EventArgs) Handles CheckBox1.Click
        CheckBox4.Checked = False
        TextBox1.Enabled = True
        CheckBox1.Checked = True
    End Sub

    Private Sub CheckBox4_Click(sender As Object, e As System.EventArgs) Handles CheckBox4.Click
        CheckBox1.Checked = False
        TextBox1.Enabled = False
        TextBox1.Text = ""

        enf = "Ninguna"
        CheckBox4.Checked = True
    End Sub

    Private Sub CheckBox8_Click(sender As Object, e As System.EventArgs) Handles CheckBox8.Click
        CheckBox7.Checked = False
        op = True
        CheckBox8.Checked = True
    End Sub

    Private Sub CheckBox7_Click(sender As Object, e As System.EventArgs) Handles CheckBox7.Click
        CheckBox8.Checked = False
        op = False
        CheckBox7.Checked = True
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As System.EventArgs) Handles CheckBox2.Click
        CheckBox5.Checked = False
        CheckBox2.Checked = True
        TextBox2.Enabled = True
    End Sub

    Private Sub CheckBox5_Click(sender As Object, e As System.EventArgs) Handles CheckBox5.Click
        CheckBox2.Checked = False
        TextBox2.Enabled = False
        CheckBox5.Checked = True
        ale = "Ninguna"
    End Sub

    Private Sub CheckBox3_Click(sender As Object, e As System.EventArgs) Handles CheckBox3.Click
        CheckBox6.Checked = False
        TextBox3.Enabled = True
        CheckBox3.Checked = True
    End Sub

    Private Sub CheckBox6_Click(sender As Object, e As System.EventArgs) Handles CheckBox6.Click
        CheckBox3.Checked = False
        TextBox3.Enabled = False
        CheckBox6.Checked = True
        trat = "Ninguno"
    End Sub


    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        OpcionFicha.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
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


End Class