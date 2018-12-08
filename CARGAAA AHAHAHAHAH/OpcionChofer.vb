Imports System.Data.Odbc
Public Class OpcionChofer
    Dim b1 As Boolean = False
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        VisualizacionChofer.DataGridView1.DataSource.clear()


        If b1 = False Then
            b1 = True
            sql = "select * from conductor where borrado=false"
            ds.Tables.Add("conductor")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("conductor"))
            VisualizacionChofer.DataGridView1.DataSource = ds.Tables("conductor")


        Else
            VisualizacionChofer.DataGridView1.DataSource.clear()
            sql = "select * from conductor where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("conductor"))
            visualizacionPaquete.DataGridView1.DataSource = ds.Tables("conductor")

          
        End If
        VisualizacionChofer.Show()
        Me.Hide()
    End Sub

    Private Sub OpcionChofer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Chofer.Show()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ModificacionChofer.Show()
        Me.Hide()
        ModificacionChofer.TextBox1.Enabled = True
        ModificacionChofer.TextBox2.Enabled = False
        ModificacionChofer.TextBox3.Enabled = False
        ModificacionChofer.TextBox4.Enabled = False
        ModificacionChofer.TextBox5.Enabled = False
        ModificacionChofer.TextBox6.Enabled = False
        ModificacionChofer.RadioButton1.Enabled = False
        ModificacionChofer.RadioButton2.Enabled = False
    End Sub
End Class