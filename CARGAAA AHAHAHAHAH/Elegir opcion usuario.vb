Public Class OpcionUser


    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        RegistroUser.Show()
        Me.Hide()
        RegistroUser.ComboBox1.Items.Clear()

        RegistroUser.ComboBox1.Items.Add("administrador")
        RegistroUser.ComboBox1.Items.Add("comun")



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        inicio.Show()
        Me.Hide()

    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        CambiarContra.Show()
        Me.Hide()

    End Sub

    Private Sub OpcionUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class