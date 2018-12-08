Imports System.Data.Odbc
Public Class OpcionCoordinador
    Dim b1 As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
      
        VisualizacionCoordinador.DataGridView1.DataSource.clear()


        If b1 = False Then
            b1 = True
            sql = "select * from coordinador where borrado=false"
            ds.Tables.Add("coordinador")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("coordinador"))
            VisualizacionCoordinador.DataGridView1.DataSource = ds.Tables("coordinador")

        Else
            VisualizacionCoordinador.DataGridView1.DataSource.clear()
            sql = "select * from coordinador where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("coordinador"))
            VisualizacionCoordinador.DataGridView1.DataSource = ds.Tables("coordinador")


        End If

        VisualizacionCoordinador.Show()
        Me.Hide()

    End Sub

    Private Sub OpcionCoordinador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Coordinadores.Show()
        Me.Hide()
        Coordinadores.TextBox1.Text = ""
        Coordinadores.TextBox2.Text = ""
        Coordinadores.TextBox3.Text = ""
        Coordinadores.TextBox4.Text = ""
        Coordinadores.TextBox5.Text = ""

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        ModificacionCoordinador.Show()

        ModificacionCoordinador.TextBox2.Enabled = False
        ModificacionCoordinador.TextBox3.Enabled = False
        ModificacionCoordinador.TextBox4.Enabled = False
        ModificacionCoordinador.TextBox5.Enabled = False
        ModificacionCoordinador.TextBox6.Enabled = False
        ModificacionCoordinador.RadioButton1.Enabled = False
        ModificacionCoordinador.RadioButton2.Enabled = False



    End Sub
End Class