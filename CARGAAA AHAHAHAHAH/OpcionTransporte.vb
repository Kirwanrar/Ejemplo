Imports System.Data.Odbc
Public Class OpcionTransporte
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim b2 As Boolean = False




    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        VisualizacionTransporte.Show()
        Me.Hide()
        VisualizacionTransporte.DataGridView1.DataSource.clear()
        If b2 = False Then
            b2 = True
            sql = "select * from transporte where borrado=false"
            ds.Tables.Add("transporte")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("transporte"))
            VisualizacionTransporte.DataGridView1.DataSource = ds.Tables("transporte")


        Else
            VisualizacionTransporte.DataGridView1.DataSource.clear()
            sql = "select * from transporte where borrado=false"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("transporte"))
            VisualizacionTransporte.DataGridView1.DataSource = ds.Tables("transporte")


        End If



    End Sub

    Private Sub OpcionTransporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ModificacionTransporte.Show()
        Me.Hide()
        ModificacionTransporte.TextBox1.Text = ""
        ModificacionTransporte.TextBox4.Text = ""
        ModificacionTransporte.TextBox5.Text = ""
        ModificacionTransporte.TextBox6.Text = ""
        ModificacionTransporte.TextBox2.Text = ""
        ModificacionTransporte.TextBox3.Text = ""
        ModificacionTransporte.TextBox7.Text = ""

        ModificacionTransporte.TextBox1.Enabled = True
        ModificacionTransporte.TextBox7.Enabled = False
        ModificacionTransporte.TextBox4.Enabled = False
        ModificacionTransporte.TextBox5.Enabled = False
        ModificacionTransporte.TextBox6.Enabled = False
        ModificacionTransporte.TextBox2.Enabled = False
        ModificacionTransporte.TextBox3.Enabled = False
        ModificacionTransporte.RadioButton1.Checked = False
        ModificacionTransporte.RadioButton2.Checked = False
        ModificacionTransporte.RadioButton1.Enabled = False
        ModificacionTransporte.RadioButton2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Transporte.Show()
        Me.Hide()

    End Sub
End Class