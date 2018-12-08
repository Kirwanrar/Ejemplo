Public Class visualizacionrecibos


    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpcionPago.Show()
        Me.Hide()

    End Sub
End Class