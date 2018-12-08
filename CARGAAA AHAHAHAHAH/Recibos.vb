Public Class Recibo


    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

   Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        inicio.Show()
        Me.Hide()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PrintForm1.Print()

    End Sub
End Class