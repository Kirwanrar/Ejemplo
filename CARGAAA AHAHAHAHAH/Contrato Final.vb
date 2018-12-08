Imports System.Data.Odbc
Public Class CF
    Dim b2 As Boolean = False
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim adp As OdbcDataAdapter
    Dim ds As New DataSet


    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintForm2.Print()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If b2 = False Then
            b2 = True
            sql = "select idcontra as Nro_Contrato,idpack as Nro_Paquete, montoTotal,idcur as Nro_Curso, estado from contrato where borrado=False"
            ds.Tables.Add("contrato")
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("contrato"))
            Contrato.DataGridView1.DataSource = ds.Tables("contrato")


        Else
            Contrato.DataGridView1.DataSource.clear()
            sql = "select idcontra as Nro_Contrato,idpack as Nro_Paquete, montoTotal,idcur as Nro_Curso, estado from contrato where borrado=False"
            adp = New OdbcDataAdapter(sql, cnn)
            adp.Fill(ds.Tables("contrato"))
            Contrato.DataGridView1.DataSource = ds.Tables("contrato")


        End If
        Me.Hide()
        Contrato.Show()
    End Sub
End Class