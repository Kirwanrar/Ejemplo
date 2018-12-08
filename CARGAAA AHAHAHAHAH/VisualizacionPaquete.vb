Imports System.Data.Odbc
Public Class visualizacionPaquete
    Dim ac As String
    Dim b As Boolean = False
    Dim sql As String
    Dim rs As OdbcDataReader
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Paquete.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If b = True Then
            DataGridView2.DataSource.clear()
        End If

        Me.Hide()
        inicio.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ac >= 0 And ac <> "" Then
            If b = False Then
                b = True
                sql = "select e.lugar,e.HoraDelDia,e.actividad,pe.fecha from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & ""
                ds.Tables.Add("excursiones")
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                DataGridView2.DataSource = ds.Tables("excursiones")


            Else

                DataGridView2.DataSource.clear()
                sql = "select e.lugar,e.HoraDelDia,e.actividad,pe.fecha from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & ""
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                DataGridView2.DataSource = ds.Tables("excursiones")


            End If
        Else
            MsgBox("seleccione un paquete por favor", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        End If

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            ac = (DataGridView1.Rows(e.RowIndex).Cells("Paquete").Value.ToString())
        End If

    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Seleccion.Show()
        Me.Hide()


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class