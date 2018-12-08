Imports System.Data.Odbc
Public Class ModificacionCurso
    Dim rsescuela As OdbcDataReader
    Dim rsbus As OdbcDataReader
    Dim l As Integer
    Dim parte As Long
    Dim c As Integer



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        opcionCurso.Show()
        Me.Hide()
        cbE.Items.Clear()
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()


    End Sub

    Private Sub ModificacionCurso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
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


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged


        sql = "select idesc from escuelas where nombre='" & ComboBox1.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()

        If rs.Read = True Then

            sql = "select nombre from curso where idesc=" & rs(0) & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            ComboBox2.Text = ""



            ComboBox2.Items.Clear()
            While rs.Read = True


                ComboBox2.Items.Add(rs(0))



            End While


        End If







    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.Text <> "" And ComboBox2.Text <> "" Then

            ComboBox1.Enabled = False
            ComboBox2.Enabled = False

            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
        Else
            MsgBox("Por favor complete los campos de escuela y curso y luego presione denuevo el boton", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If






    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            cbE.Enabled = True
        End If


    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            cbE.Enabled = False

            TextBox1.Text = ""
            TextBox2.Text = ""
            cbE.Text = ""

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

       

        If RadioButton1.Enabled = True Then
            sql = "select c.id,c.idesc from curso c,(select id from escuelas where nombre='" & ComboBox1.Text & "') x where c.nombre='" & ComboBox2.Text & "' and c.idesc=x.id"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsbus = cmd.ExecuteReader
            cmd.Dispose()

            If rsbus.Read = True Then
                If TextBox1.Text <> "" Then
                    c = 1
                    sql = "update curso set nombre='" & TextBox1.Text & "' where idcurso=" & rsbus(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                End If

                If TextBox2.Text <> "" Then

                    sql = "update curso set cantiintegr=" & TextBox2.Text & " where idcurso=" & rsbus(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    l = TextBox2.Text / 7
                    parte = Int(l)
                    c = 1
                    sql = "update curso set cantiliberados=" & parte & " where idcurso=" & rsbus(0) & ""
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                End If


                If cbE.Text <> "" Then

                    sql = "select id from escuelas where nombre='" & cbE.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsescuela = cmd.ExecuteReader
                    cmd.Dispose()
                    If rsescuela.Read = True Then
                        c = 1
                        sql = "update curso set idesc=" & rsescuela(0) & " where idesc=" & rsbus(1) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                    End If
                End If

                If c = 0 Then
                    MsgBox("Por favor complete algun campo", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                Else
                    MsgBox("Ok", MsgBoxStyle.OkOnly, "COMPLETADO")
                    TextBox1.Enabled = False
                    TextBox2.Enabled = False
                    cbE.Enabled = False

                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    cbE.Text = ""

                End If

            End If



        ElseIf RadioButton2.Enabled = True Then

            sql = "select c.id,c.idesc from curso c,(select id from escuelas where nombre='" & ComboBox1.Text & "') x where c.nombre='" & ComboBox2.Text & "' and c.idesc=x.id"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsbus = cmd.ExecuteReader
            cmd.Dispose()

            If rsbus.Read = True Then
                sql = "update curso set borrado=true"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "update alumno set borrado=true where idcurso=" & rsbus(0) & ""
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
            End If



        ElseIf RadioButton1.Enabled = False And RadioButton2.Enabled = False Then

            MsgBox("Por favor presione el boton de activar las opciones de modificar y borrar", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        Else
            MsgBox("Por favor seleccione una opcion", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If


    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox2.KeyPress
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

    Private Sub TextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
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

    Private Sub cbE_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbE.KeyPress
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