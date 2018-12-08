Imports System.Data.Odbc
Public Class inicio
    Dim b As Boolean = False
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b2 As Boolean = False
    Dim b3 As Boolean = False
    Dim b4 As Boolean = False




    Private Sub btnEscu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEscu.Click
        VisualizacionEscuela.Show()
        Me.Hide()

        VisualizacionEscuela.ComboBox1.Items.Clear()


        sql = "select nombre from escuelas where borrado=false"
        cmd = New OdbcCommand(sql, cnn)
        cmd.CommandType = CommandType.Text
        rs = cmd.ExecuteReader
        cmd.Dispose()
        Do While rs.Read = True
            VisualizacionEscuela.ComboBox1.Items.Add(rs(0))

        Loop

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()


        Call Viaje()

        Call cada_mes()

        Call eleccion()



    End Sub


    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        OpcionUser.Show()
        Me.Hide()

    End Sub

    Private Sub btnExcurs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcurs.Click


        If b = False Then
            b = True
            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false"
            ds.Tables.Add("paquete")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            visualizacionPaquete.DataGridView1.DataSource = ds.Tables("paquete")


        Else
            visualizacionPaquete.DataGridView1.DataSource.clear()
            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false "
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            visualizacionPaquete.DataGridView1.DataSource = ds.Tables("paquete")


        End If


        Me.Hide()
        visualizacionPaquete.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpcionPago.Show()
        Me.Hide()



    End Sub

    Private Sub btnChofer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChofer.Click
       
        EleccionPersonal.Show()
        Me.Hide()


       

    End Sub

    Private Sub btnTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrans.Click
        If b2 = False Then
            b2 = True
            sql = "select c.idcontra as Nro_Contrato,c.idpack as Nro_Paquete, c.montoTotal,c.estado,cu.nombre as Nombre_Curso,es.nombre as Nombre_Escuela from contrato c,curso cu, escuelas es,(select c.idesc as numero from curso c ,(select idcur from contrato where borrado=False) s where c.idcurso=s.idcur and c.borrado=false) x where cu.idcurso=c.idcur and es.idesc=x.numero and c.borrado=false group by c.idcontra"
            ds.Tables.Add("contrato")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("contrato"))
            Contrato.DataGridView1.DataSource = ds.Tables("contrato")


        Else
            Contrato.DataGridView1.DataSource.clear()
            sql = "select c.idcontra as Nro_Contrato,c.idpack as Nro_Paquete, c.montoTotal,c.estado,cu.nombre as Nombre_Curso,es.nombre as Nombre_Escuela from contrato c,curso cu, escuelas es,(select c.idesc as numero from curso c ,(select idcur from contrato where borrado=False) s where c.idcurso=s.idcur and c.borrado=false) x where cu.idcurso=c.idcur and es.idesc=x.numero and c.borrado=false group by c.idcontra"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("contrato"))
            Contrato.DataGridView1.DataSource = ds.Tables("contrato")


        End If
        Me.Hide()
        Contrato.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        VentanaUser.Show()
        Me.Hide()
        VentanaUser.txt1.Text = ""
        VentanaUser.txt2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        VisualizacionViaje.Show()
        Me.Hide()


        If b3 = False Then
            b3 = True
            sql = "select idviaje as Nro_Viaje,idcontrato as Nro_Contrato, idtranscho as Nro_Transporte, duracion, estado from viaje where cancelado=False"
            ds.Tables.Add("viaje")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("viaje"))
            VisualizacionViaje.DataGridView1.DataSource = ds.Tables("viaje")


        Else
            VisualizacionViaje.DataGridView1.DataSource.clear()
            sql = "select idviaje as Nro_Viaje,idcontrato as Nro_Contrato, idtranscho as Nro_Transporte, duracion, estado from viaje where cancelado=False "
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("viaje"))
            VisualizacionViaje.DataGridView1.DataSource = ds.Tables("viaje")


        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        VisualizacionGanancias.Show()
        Me.Hide()





        If b4 = False Then
            b4 = True
            sql = "select mes,año,monto from ganancias"
            ds.Tables.Add("ganancias")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("ganancias"))
            VisualizacionGanancias.DataGridView1.DataSource = ds.Tables("ganancias")


        Else
            VisualizacionGanancias.DataGridView1.DataSource.clear()
            sql = "select mes,año,monto from ganancias"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("ganancias"))
            VisualizacionGanancias.DataGridView1.DataSource = ds.Tables("ganancias")


        End If




    End Sub
End Class
