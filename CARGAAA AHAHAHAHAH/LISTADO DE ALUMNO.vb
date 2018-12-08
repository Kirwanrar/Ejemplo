Public Class Form2

   

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PrintForm1.Print()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        inicio.Show()
        Me.Hide()

    End Sub
End Class