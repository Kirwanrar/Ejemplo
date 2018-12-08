Imports System.Data.Odbc

Public Class Contrato
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim b As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim ac As String
    Dim s As Boolean = False
    Dim ad As String
    Dim rs11 As OdbcDataReader


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        inicio.Show()

    End Sub

    Private Sub Contrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If b = False Then
            b = True
            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false"
            ds.Tables.Add("paquete")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            CC.DataGridView1.DataSource = ds.Tables("paquete")


        Else
            CC.DataGridView1.DataSource.clear()
            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            CC.DataGridView1.DataSource = ds.Tables("paquete")


        End If
        CC.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If ac <> 0 And ad <> "Cancelado" Then
            ModificacionContrato.Show()
            Me.Hide()
            ModificacionContrato.TextBox1.Text = ac


            sql = "select r.dni,r.nombre,r.apellido,r.idres from responsables r,(select idrespon from contratofirma where idcontrato=" & ac & ") xx where r.idres=xx.idrespon"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()

            While rs.Read = True

                If s = False Then


                    s = True

                    ModificacionContrato.TextBox4.Text = rs(0)
                    ModificacionContrato.TextBox6.Text = rs(1)
                    ModificacionContrato.TextBox7.Text = rs(2)
                    sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs11 = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs11.Read = True Then
                        ModificacionContrato.TextBox9.Text = rs11(0)
                        ModificacionContrato.TextBox8.Text = rs11(1)




                    End If

                Else

                    ModificacionContrato.TextBox5.Text = rs(0)
                    ModificacionContrato.TextBox13.Text = rs(1)
                    ModificacionContrato.TextBox12.Text = rs(2)

                    sql = "select nombre,apellido from alumno where idrespon='" & rs(3) & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs11 = cmd.ExecuteReader
                    cmd.Dispose()
                    If rs11.Read = True Then
                        ModificacionContrato.TextBox11.Text = rs11(0)
                        ModificacionContrato.TextBox10.Text = rs11(1)


                    End If


                End If


            End While

        Else
            MsgBox("Por favor seleccione un contrato y que no tenga de estado cancelado", MsgBoxStyle.OkOnly, "ADVERTENCIA")

        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            ac = (DataGridView1.Rows(e.RowIndex).Cells("Nro_Contrato").Value.ToString())
            ad = (DataGridView1.Rows(e.RowIndex).Cells("estado").Value.ToString())
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class