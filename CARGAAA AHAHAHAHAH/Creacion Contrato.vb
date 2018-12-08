Imports System.Data.Odbc
Public Class CC
    Dim rs As OdbcDataReader
    Dim sql As String
    Dim ac As Integer
    Dim b As Integer
    Dim ds As New DataSet
    Dim adp As OdbcDataAdapter
    Dim pr As Integer
    Dim tot As Integer
    Dim cuot As Integer
    Dim rst As OdbcDataReader
    Dim rsh As OdbcDataReader
    Dim rsc As OdbcDataReader
    Dim rscont As OdbcDataReader
    Dim qq As Boolean = False
    Dim comprobaacion As OdbcDataReader


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conexion()

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If qq = True Then
            Me.Hide()
            CF.Show()

            CF.TextBox1.Text = TextBox1.Text
            CF.TextBox2.Text = TextBox2.Text
            CF.TextBox3.Text = MaskedTextBox3.Text
            CF.TextBox4.Text = TextBox4.Text
            CF.TextBox5.Text = TextBox5.Text
            CF.TextBox6.Text = TextBox6.Text
            CF.TextBox8.Text = TextBox8.Text
            CF.TextBox9.Text = TextBox9.Text
            CF.TextBox10.Text = TextBox10.Text
            CF.TextBox31.Text = TextBox28.Text
            CF.TextBox11.Text = TextBox11.Text


            CF.TextBox16.Text = TextBox16.Text
            CF.TextBox15.Text = TextBox15.Text
            CF.TextBox13.Text = TextBox13.Text
            CF.TextBox14.Text = MaskedTextBox1.Text
            CF.TextBox26.Text = MaskedTextBox2.Text
            CF.TextBox27.Text = TextBox27.Text



            sql = "select sum(precio_persona) from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & " and e.borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            If rs.Read = True Then
                sql = "select precio_persona from transporte where matricula= '" & TextBox28.Text & "' and borrado=false"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rst = cmd.ExecuteReader
                cmd.Dispose()
                If rst.Read = True Then
                    sql = "select h.precio_persona from hotel h,paquete p where h.idhotel=p.idhotel and p.idpack='" & ac & "'and h.borrado=false"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsh = cmd.ExecuteReader
                    cmd.Dispose()
                    If rsh.Read = True Then
                        pr = rs(0) + rst(0) + rsh(0)
                        tot = pr + (pr * 0.2)
                        cuot = tot / 12
                        CF.TextBox28.Text = tot
                        CF.TextBox7.Text = cuot
                    End If
                End If
            End If
            CF.TextBox15.Text = TextBox12.Text
            CF.TextBox14.Text = MaskedTextBox1.Text
            CF.TextBox13.Text = TextBox13.Text
            CF.TextBox16.Text = TextBox15.Text
            CF.TextBox26.Text = MaskedTextBox2.Text
            CF.TextBox27.Text = TextBox27.Text

            CF.TextBox17.Text = TextBox17.Text
            CF.TextBox19.Text = TextBox18.Text
            CF.TextBox20.Text = TextBox19.Text
            CF.TextBox25.Text = TextBox16.Text
            CF.TextBox30.Text = TextBox20.Text

            CF.TextBox21.Text = TextBox21.Text
            CF.TextBox23.Text = TextBox23.Text
            CF.TextBox24.Text = TextBox24.Text
            CF.TextBox29.Text = TextBox22.Text
            CF.TextBox32.Text = TextBox25.Text

            sql = "select nombre from hotel h,paquete p where h.idhotel=p.idhotel and p.idpack='" & ac & "' and h.borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            If rs.Read = True Then
                CF.TextBox18.Text = rs(0)

                sql = "select e.lugar, e.horadeldia,e.actividad from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & " and e.borrado=false"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()
                While rs.Read = True
                    CF.ListBox1.Items.Add(rs(0) & " " & rs(2))
                End While
            End If

            sql = "select idcurso from curso where nombre='" & TextBox6.Text & "' and borrado=false"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rst = cmd.ExecuteReader
            cmd.Dispose()
            If rst.Read = True Then

                var1Contrato = ac
                var2Contrato = tot
                var3Contrato = rst(0)

                sql = "insert into contrato values(''," & var1Contrato & "," & var2Contrato & "," & var3Contrato & ",'Pendiente',false)"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rs = cmd.ExecuteReader
                cmd.Dispose()

                sql = "select idtran from transporte where matricula='" & TextBox28.Text & "' and borrado=False"
                cmd = New OdbcCommand(sql, cnn)
                cmd.CommandType = CommandType.Text
                rsh = cmd.ExecuteReader
                cmd.Dispose()
                If rsh.Read = True Then

                    sql = "update transporte set disponible=False where matricula='" & TextBox28.Text & "'"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    comprobaacion = cmd.ExecuteReader
                    cmd.Dispose()


                    sql = "select max(idcontra) from contrato "
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rsc = cmd.ExecuteReader
                    cmd.Dispose()
                    If rsc.Read = True Then

                        var1trans = rsh(0)

                        sql = "insert into transchofer values(''," & var1trans & ",null)"
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        sql = "select max(idtranscho) from transchofer "
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rsh = cmd.ExecuteReader
                        cmd.Dispose()
                        If rsh.Read = True Then


                            var1Viaje = rsc(0)
                            var2Viaje = rsh(0)
                            var3Viaje = TextBox12.Text

                            var4Viaje = TextBox13.Text



                            sql = "select max(idviaje)+1 from viaje "
                            cmd = New OdbcCommand(sql, cnn)
                            cmd.CommandType = CommandType.Text
                            rsh = cmd.ExecuteReader
                            cmd.Dispose()

                            If rsh.Read = True Then
                                var1Alma = rsh(0)
                                var2Alma = MaskedTextBox1.Text
                                var3Alma = MaskedTextBox2.Text


                              

                                sql = "select idres from responsables where dni='" & TextBox19.Text & "' and borrado=false "
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()

                                If rs.Read = True Then


                                    var1Firmaone = rsc(0)
                                    var2Firmaone = rs(0)


                                    sql = "insert into contratofirma values(''," & var1Firmaone & "," & var2Firmaone & ",false)"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                 
                                    sql = "select idres from responsables where dni='" & TextBox24.Text & "'and borrado=false"
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()

                                    If rs.Read = True Then

                                        var1Firmatwo = rsc(0)
                                        var2Firmatwo = rs(0)
                                        sql = "insert into contratofirma values(''," & var1Firmatwo & "," & var2Firmatwo & ",false)"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rs = cmd.ExecuteReader
                                        cmd.Dispose()

                                       
                                        CF.Label36.Text = TextBox7.Text

                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Else
            MsgBox("Por favor verifique los datos")
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If TextBox1.Text <> "" And TextBox7.Text <> "" And MaskedTextBox3.Text <> "" And TextBox28.Text <> "" And TextBox4.Text <> "" And TextBox6.Text <> "" And TextBox12.Text <> "" And TextBox13.Text <> "" And MaskedTextBox1.Text <> "" And MaskedTextBox2.Text <> "" And TextBox27.Text <> "" And TextBox19.Text <> "" And TextBox24.Text <> "" And ac <> 0 Then

            sql = "select count(*) from escuelas where '" & TextBox4.Text & "'=nombre"
            cmd = New OdbcCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            rs = cmd.ExecuteReader
            cmd.Dispose()
            If rs.Read = True Then
                If rs(0) = 0 Then
                    MsgBox("La escuela Ingresada no existe, por favor registrela junto con los datos correspondientes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    Me.Hide()
                    Escuela.Show()
                    asd = True
                Else

                    sql = "select direccion,localidad,codpost,provincia from escuelas where '" & TextBox4.Text & "'=nombre"
                    cmd = New OdbcCommand(sql, cnn)
                    cmd.CommandType = CommandType.Text
                    rs = cmd.ExecuteReader
                    cmd.Dispose()

                    If rs.Read = True Then
                        TextBox2.Text = rs(1)
                        TextBox8.Text = rs(0)
                        TextBox9.Text = rs(2)
                        TextBox10.Text = rs(1)
                        TextBox11.Text = rs(3)

                        sql = "select count(*) from curso c, escuelas e where '" & TextBox6.Text & "'=c.nombre and c.idesc=e.idesc and '" & TextBox4.Text & "'=e.nombre "
                        cmd = New OdbcCommand(sql, cnn)
                        cmd.CommandType = CommandType.Text
                        rs = cmd.ExecuteReader
                        cmd.Dispose()

                        If rs.Read = True Then
                            If rs(0) = 0 Then
                                MsgBox("El curso Ingresado no existe, por favor registrelo junto con los datos correspondientes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                Me.Hide()
                                Cursos.Show()
                                ads = True
                            Else
                                sql = "select cantiIntegr from curso c, escuelas e where '" & TextBox6.Text & "'=c.nombre and c.idesc=e.idesc and '" & TextBox4.Text & "'=e.nombre "
                                cmd = New OdbcCommand(sql, cnn)
                                cmd.CommandType = CommandType.Text
                                rs = cmd.ExecuteReader
                                cmd.Dispose()
                                If rs.Read = True Then
                                    TextBox5.Text = rs(0)


                                    sql = "select nombre from destino d,paquete p where d.iddestino=p.iddesti and p.idpack=" & ac & ""
                                    cmd = New OdbcCommand(sql, cnn)
                                    cmd.CommandType = CommandType.Text
                                    rs = cmd.ExecuteReader
                                    cmd.Dispose()
                                    If rs.Read = True Then
                                        TextBox15.Text = rs(0)


                                        sql = "select count(*) from responsables r,alumno a,curso c,escuelas e where r.dni='" & TextBox19.Text & "' and r.idres=a.idrespon and a.idcurso=c.idcurso and c.nombre='" & TextBox6.Text & "' and c.idesc=e.idesc and e.nombre='" & TextBox4.Text & "'"
                                        cmd = New OdbcCommand(sql, cnn)
                                        cmd.CommandType = CommandType.Text
                                        rscont = cmd.ExecuteReader
                                        cmd.Dispose()
                                        If rscont.Read = True Then
                                            If rscont(0) = 0 Then
                                                MsgBox("El responsable Ingresado no existe, por favor registrelo junto con los datos correspondientes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                                Me.Hide()
                                                Responsable.Show()
                                                aps = True
                                            Else
                                                sql = "select r.nombre,r.apellido,r.direccion,r.telefono from responsables r,alumno a,curso c,escuelas e where r.dni='" & TextBox19.Text & "' and r.idres=a.idrespon and a.idcurso=c.idcurso and c.nombre='" & TextBox6.Text & "' and c.idesc=e.idesc and e.nombre='" & TextBox4.Text & "' "

                                                cmd = New OdbcCommand(sql, cnn)
                                                cmd.CommandType = CommandType.Text
                                                rs = cmd.ExecuteReader
                                                cmd.Dispose()
                                                If rs.Read = True Then

                                                    TextBox20.Text = rs(0)
                                                    TextBox16.Text = rs(1)
                                                    TextBox18.Text = rs(2)
                                                    TextBox17.Text = rs(3)

                                                    sql = "select count(*) from responsables r,alumno a,curso c,escuelas e where r.dni='" & TextBox24.Text & "' and r.idres=a.idrespon and a.idcurso=c.idcurso and c.nombre='" & TextBox6.Text & "' and c.idesc=e.idesc and e.nombre='" & TextBox4.Text & "' "
                                                    cmd = New OdbcCommand(sql, cnn)
                                                    cmd.CommandType = CommandType.Text
                                                    rs = cmd.ExecuteReader
                                                    cmd.Dispose()
                                                    If rs.Read = True Then
                                                        If rs(0) = 0 Then
                                                            MsgBox("El responsable Ingresado no existe, por favor registrelo junto con los datos correspondientes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                                            Me.Hide()
                                                            Responsable.Show()
                                                            aps = True
                                                        Else
                                                            sql = "select r.nombre,r.apellido,r.direccion,r.telefono from responsables r,alumno a,curso c,escuelas e where r.dni='" & TextBox24.Text & "' and r.idres=a.idrespon and a.idcurso=c.idcurso and c.nombre='" & TextBox6.Text & "' and c.idesc=e.idesc and e.nombre='" & TextBox4.Text & "' "
                                                            cmd = New OdbcCommand(sql, cnn)
                                                            cmd.CommandType = CommandType.Text
                                                            rs = cmd.ExecuteReader
                                                            cmd.Dispose()
                                                            If rs.Read Then
                                                                TextBox25.Text = rs(0)
                                                                TextBox22.Text = rs(1)
                                                                TextBox23.Text = rs(2)
                                                                TextBox21.Text = rs(3)

                                                                sql = "select nombre from destino d, paquete p where d.iddestino=p.iddesti and idpack=" & ac & " "
                                                                cmd = New OdbcCommand(sql, cnn)
                                                                cmd.CommandType = CommandType.Text
                                                                rs = cmd.ExecuteReader
                                                                cmd.Dispose()
                                                                If rs.Read = True Then
                                                                    TextBox15.Text = rs(0)
                                                                    sql = "select count(*) from transporte where matricula='" & TextBox28.Text & "'"
                                                                    cmd = New OdbcCommand(sql, cnn)
                                                                    cmd.CommandType = CommandType.Text
                                                                    rs = cmd.ExecuteReader
                                                                    cmd.Dispose()
                                                                    If rs.Read = True Then
                                                                        If rs(0) = 0 Then
                                                                            MsgBox("El transporte Ingresado no existe, por favor registrelo junto con los datos correspondientes", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                                                            Me.Hide()
                                                                            Transporte.Show()
                                                                            asp = True
                                                                        Else

                                                                            sql = "select count(*) from transporte where matricula='" & TextBox28.Text & "' and disponible=true"
                                                                            cmd = New OdbcCommand(sql, cnn)
                                                                            cmd.CommandType = CommandType.Text
                                                                            rs = cmd.ExecuteReader
                                                                            cmd.Dispose()
                                                                            If rs.Read = True Then
                                                                                If rs(0) = 0 Then
                                                                                    MsgBox("El transporte ingresado no esta disponible para su uso, por favor ingrese otro", MsgBoxStyle.OkOnly, "ADVERTENCIA")
                                                                                Else
                                                                                    qq = True
                                                                                End If

                                                                            End If
                                                                        End If

                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        ElseIf ac <> 0 Then
            MsgBox("Por favor complete todos los campos", MsgBoxStyle.OkOnly, "ADVERTENCIA")
        Else
            MsgBox("Por favor seleccione un paquete", MsgBoxStyle.OkOnly, "ADVERTENCIA")


        End If

    End Sub


    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        If e.RowIndex >= 0 Then
            ac = (DataGridView1.Rows(e.RowIndex).Cells("Paquete").Value.ToString())
            If b = False Then
                b = True
                sql = "select e.idexcur as Nro_Excursion,e.lugar,e.HoraDelDia,e.actividad,e.precio_persona from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & ""
                ds.Tables.Add("excursiones")
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                DataGridView2.DataSource = ds.Tables("excursiones")


            Else

                DataGridView2.DataSource.clear()
                sql = "select e.idexcur as Nro_Excursion,e.lugar,e.HoraDelDia,e.actividad,e.precio_persona from excursiones e,paquexcu pe,paquete p where e.idexcur=pe.idexc and pe.idpack=p.idpack and p.idpack= " & ac & ""
                adp = New OdbcDataAdapter(sql, cnn)
                adp.Fill(ds.Tables("excursiones"))
                DataGridView2.DataSource = ds.Tables("excursiones")


            End If
        End If

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Contrato.Show()
        Me.Hide()
        TextBox1.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox2.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox25.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        MaskedTextBox1.Text = ""
        MaskedTextBox2.Text = ""
        MaskedTextBox3.Text = ""


    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub MaskedTextBox3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox3.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox1.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub MaskedTextBox2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles MaskedTextBox2.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox27_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox27.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox19_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox24_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox24.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

End Class
