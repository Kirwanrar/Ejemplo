Imports System.Data.Odbc
Imports System.Globalization

Public Class PagoCuotas
    Dim cuenta As Integer
    Dim rsexistencia As OdbcDataReader
    Dim rs1 As OdbcDataReader
    Dim total As New Globalization.CultureInfo("es-ES")
    Dim kkk As Single
    Dim rees As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        VisualizacionCuotas.Show()
        Me.Hide()
        txt4.Text = ""

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        total.NumberFormat.NumberDecimalSeparator = (".")
        System.Threading.Thread.CurrentThread.CurrentCulture = total
        kkk = txt3.Text



        sql = "select idrespon from alumno where nombre='" & txt1.Text & "' and apellido='" & txt2.Text & "'"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        If rs.Read = True Then
            rees = rs(0)

            sql = "select idcuotas, count(*),fechavenci from cuotas where idrespon=" & rs(0) & " and nrocuota=" & TextBox1.Text & ""
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rsexistencia = cmd.ExecuteReader
            cmd.Dispose()
            If rsexistencia.Read = True Then

                If rsexistencia(1) = 1 Then
                    If CInt(txt4.Text) >= CInt(txt3.Text) Then
                        cuenta = txt4.Text - txt3.Text

                        sql = "update cuotas set fechapago='" & Format(Today.Date, "yyyy/MM/dd") & "'where idcuotas=" & rsexistencia(0) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs1 = cmd.ExecuteReader
                        cmd.Dispose()
                        sql = "update cuotas set estado='pagado' where idcuotas=" & rsexistencia(0) & ""
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs1 = cmd.ExecuteReader
                        cmd.Dispose()


                        If rsexistencia(2) = Format(Today.Date, "yyyy/MM/dd") Then


                            sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','pago en fecha de la cuota','" & kkk & "','" & rs(0) & "','" & TextBox1.Text & "')"

                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            MsgBox("El pago se realizo con exito", MsgBoxStyle.OkOnly, "completado")


                        ElseIf rsexistencia(2) > Format(Today.Date, "yyyy/MM/dd") Then


                            sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','pago adelantado de la cuota','" & kkk & "','" & rs(0) & "','" & TextBox1.Text & "')"

                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()

                            MsgBox("El pago se realizo con exito", MsgBoxStyle.OkOnly, "COMPLETADO")
                        Else
                            sql = "insert into recibo values('', curdate(), 'pago atrasado de la cuota', '" & kkk & "' , " & rs(0) & ", " & TextBox1.Text & ")"


                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rs = cmd.ExecuteReader
                            cmd.Dispose()
                            MsgBox("El pago se realizo con exito", MsgBoxStyle.OkOnly, "completado")


                        End If
                        Recibo.Show()
                        Me.Hide()
                        sql = "select nombre,apellido from responsables where idres='" & rees & "'"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()
                        If rs.Read = True Then
                            Recibo.Label1.Text = rs(0)
                            Recibo.Label5.Text = rs(1)
                            Recibo.Label3.Text = txt3.Text
                            Recibo.Label4.Text = txt4.Text
                            If TextBox1.Text = "13" Then
                                Recibo.Label2.Text = "Pago completo del viaje"
                            Else
                                Recibo.Label2.Text = "Pago de cuota"
                            End If
                        End If


                        VisualizacionCuotas.DataGridView1.DataSource.clear()
                        VisualizacionCuotas.ComboBox1.Text = ""
                        VisualizacionCuotas.ComboBox2.Text = ""
                    Else
                        MsgBox("El pago es insuficiente", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    End If
                Else
                    cuenta = txt4.Text - txt3.Text


                    sql = "insert into recibo values('','" & Format(Today.Date, "yyyy/MM/dd") & "','pago de interes','" & kkk & "','" & rs(0) & "',null)"

                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()
                    MsgBox("El pago se realizo con exito", MsgBoxStyle.OkOnly, "completado")
                    Recibo.Show()
                    Me.Hide()
                    Recibo.Label1.Text = txt1.Text
                    Recibo.Label5.Text = txt2.Text
                    Recibo.Label3.Text = txt3.Text
                    Recibo.Label4.Text = txt4.Text
                    Recibo.Label2.Text = "Pago de interes por atraso en pago de cuotas"



                End If

            End If

        End If
    End Sub

    Private Sub txt4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt4.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

End Class