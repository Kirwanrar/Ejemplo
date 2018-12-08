Public Class VisualizacionCoordinador

    Private Sub VisualizacionCoordinador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        EleccionPersonal.Show()
        Me.Hide()

        DataGridView1.DataSource.clear()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpcionCoordinador.Show()
        Me.Hide()

    End Sub
End Class