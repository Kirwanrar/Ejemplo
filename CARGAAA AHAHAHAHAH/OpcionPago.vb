Imports System.Data.Odbc
Public Class OpcionPago
    Dim b As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter



    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        VisualizacionCuotas.Show()
        Me.Hide()

        VisualizacionCuotas.ComboBox1.Items.Clear()


        sql = "select nombre from alumno where borrado=false group by nombre"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read = True
            VisualizacionCuotas.ComboBox1.Items.Add(rs(0))

        Loop


    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        visualizacionrecibos.Show()
        Me.Hide()

        If b = False Then
            b = True
            sql = "select fecha,concepto,monto,s.nombre,s.apellido,idcuota as Nro_Cuota from recibo r, responsables s where s.idres=r.idrespon"
            ds.Tables.Add("recibos")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("recibos"))
            visualizacionrecibos.DataGridView1.DataSource = ds.Tables("recibos")


        Else
            visualizacionrecibos.DataGridView1.DataSource.clear()
            sql = "select fecha,concepto,monto,s.nombre,s.apellido,idcuota as Nro_Cuota from recibo r, responsables s where s.idres=r.idrespon"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("recibos"))
            visualizacionrecibos.DataGridView1.DataSource = ds.Tables("recibos")


        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        inicio.Show()
        Me.Hide()

    End Sub
End Class