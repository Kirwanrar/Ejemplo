Imports System.Data.Odbc
Public Class Seleccion
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim b As Boolean = False
    Dim adp As OdbcDataAdapter
    Dim ds As New DataSet


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        visualizacionPaquete.Show()
        visualizacionPaquete.DataGridView1.DataSource.clear()


        If visualizacionPaquete.DataGridView2.Rows.Count() > 0 Then



            visualizacionPaquete.DataGridView2.DataSource.clear()
        End If

        If b = False Then
            b = True
            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false"
            ds.Tables.Add("paquete")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            visualizacionPaquete.DataGridView1.DataSource = ds.Tables("paquete")


        Else

            sql = "select p.idpack as Paquete,d.nombre as Destino,h.nombre as Hotel from paquete p,destino d, hotel h where p.iddesti=d.iddestino and p.idhotel=h.idhotel and p.borrado=false "
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("paquete"))
            visualizacionPaquete.DataGridView1.DataSource = ds.Tables("paquete")


        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        OpcionPaquete.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click



        Me.Hide()
        OpcionExcursiones.Show()


    End Sub

    Private Sub Seleccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpcionDestino.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OpcionHotel.Show()
        Me.Hide()

    End Sub
End Class