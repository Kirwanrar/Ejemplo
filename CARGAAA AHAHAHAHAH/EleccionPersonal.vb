Imports System.Data.Odbc
Public Class EleccionPersonal
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b1 As Boolean = False
    Dim b2 As Boolean = False
    Dim b3 As Boolean = False

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If b1 = False Then
            b1 = True
            sql = "select idconduc as Nro_Conductor,nombre,apellido,dni,direccion,telefono from conductor where borrado=false"
            ds.Tables.Add("conductor")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("conductor"))
            VisualizacionChofer.DataGridView1.DataSource = ds.Tables("conductor")


        Else
            VisualizacionChofer.DataGridView1.DataSource.clear()
            sql = "select idconduc as Nro_Conductor,nombre,apellido,dni,direccion,telefono from conductor where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("conductor"))
            VisualizacionChofer.DataGridView1.DataSource = ds.Tables("conductor")


        End If

        VisualizacionChofer.Show()
        Me.Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        inicio.Show()
        Me.Hide()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If b2 = False Then
            b2 = True
            sql = "select idtran as Nro_Transporte,estado,cantias as Cantidad_Asientos, matricula,marca,precio_persona,disponible,descripcion from transporte where borrado=false"
            ds.Tables.Add("transporte")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("transporte"))
            VisualizacionTransporte.DataGridView1.DataSource = ds.Tables("transporte")


        Else
            VisualizacionTransporte.DataGridView1.DataSource.clear()
            sql = "select idtran as Nro_Transporte,estado,cantias as Cantidad_Asientos, matricula,marca,precio_persona,disponible,descripcion from transporte where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("transporte"))
            VisualizacionTransporte.DataGridView1.DataSource = ds.Tables("transporte")


        End If

        VisualizacionTransporte.Show()
        Me.Hide()


    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If b3 = False Then
            b3 = True
            sql = "select idcoor as Nro_Coordinador,nombre,apellido,dni,direccion,telefono from coordinador where borrado=false"
            ds.Tables.Add("coordinador")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("coordinador"))
            VisualizacionCoordinador.DataGridView1.DataSource = ds.Tables("coordinador")


        Else
            VisualizacionCoordinador.DataGridView1.DataSource.clear()
            sql = "select idcoor as Nro_Coordinador,nombre,apellido,dni,direccion,telefono from coordinador where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("coordinador"))
            VisualizacionCoordinador.DataGridView1.DataSource = ds.Tables("coordinador")


        End If

        VisualizacionCoordinador.Show()
        Me.Hide()

    End Sub
End Class