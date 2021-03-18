Imports System.Data
Imports System.Data.SqlClient
Public Class Manager
    Dim conStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VB\ProjectBank\ProjectBank\DataBanks.mdf"
    Dim conn As New SqlConnection(conStr)
    Dim id As String
    Dim amount As Double
    Public Sub New(mode As String, id As String, name As String)
        InitializeComponent()
        but.Text = mode
        Me.id = id
        Me.Name = name
        txtCus_id.Text = id
        txtFullname.Text = name
        txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub
    Public Sub New(mode As String, id As String, amount As Double, name As String)
        InitializeComponent()
        but.Text = mode
        Me.id = id
        Me.Name = name
        Me.amount = amount
        txtCus_id.Text = id
        txtFullname.Text = name

        txtlimit_Dep.Text = getAccLimit(id)
        If txtlimit_Dep.Text = 0 Then
            txtlimit_Dep.Text = ""
        End If
        txtDateTime.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub AddDeposit(billid As String, Dep_amount As Double)
        Dim accamount = getAccAmount(billid)
        If Dep_amount < 100 Then
            MessageBox.Show("You can't deposit money less than 100 Baht.")
        Else
            DoDeposit(billid, Dep_amount)
            Dim cardnum = getCardbyBill(billid)
            conn.Open()
            Dim sql = "Insert into deposit values(@dep_datetime,@dep_total,@dep_amount,@dep_detail,@cardnumber,@billing_id)"
            If cardnum.Equals("") Then
                sql = "Insert into deposit (dep_datetime,dep_total,dep_amount,dep_detail,billing_id) values(@dep_datetime,@dep_total,@dep_amount,@dep_detail,@billing_id)"
            End If
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("dep_datetime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("dep_total", Dep_amount + accamount)
            cmd.Parameters.AddWithValue("dep_amount", Dep_amount)
            If Not cardnum.Equals("") Then
                cmd.Parameters.AddWithValue("cardnumber", cardnum)
            End If
            cmd.Parameters.AddWithValue("dep_detail", String.Format("{0:00}", DateTime.Now.Hour()) &
                                            String.Format("{0:00}", DateTime.Now.Minute()) &
                                            String.Format("{0:00}", DateTime.Now.Second()))
            cmd.Parameters.AddWithValue("billing_id", billid)
            cmd.ExecuteNonQuery()
            conn.Close()
        End If
    End Sub

    Private Sub DoDeposit(billid As String, dep_amount As Double)
        conn.Open()
        Dim Sql = "update billing_account set " &
                    "billing_amount = billing_amount + @dep_amount " &
                    "where billing_id = @bill_id"
        Dim cmd As New SqlCommand(Sql, conn)
        cmd.Parameters.AddWithValue("dep_amount", dep_amount)
        cmd.Parameters.AddWithValue("bill_id", billid)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub AddWithdraw(billid As String, wit_amount As Double)
        Dim accamount = getAccAmount(billid)
        Dim acclimit = getAccLimit(billid)

        If accamount < wit_amount Then
            MessageBox.Show("You account doesn't have enough money")
        ElseIf acclimit < wit_amount Then
            If acclimit = 0 Then
                DoWithDraw(billid, wit_amount)
                Dim cardnum = getCardbyBill(billid)
                conn.Open()
                Dim sql = "Insert into withdraw (wit_datetime,wit_total,wit_detail,cardnumber,billing_id,total) values(@wit_datetime,@wit_total,@wit_detail,@cardnumber,@billing_id,@total)"
                If cardnum.Equals("") Then
                    sql = "Insert into withdraw (wit_datetime,wit_total,wit_detail,billing_id,total) values(@wit_datetime,@wit_total,@wit_detail,@billing_id,@total)"
                End If
                Dim cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("wit_datetime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                cmd.Parameters.AddWithValue("wit_total", wit_amount)
                If Not cardnum.Equals("") Then
                    cmd.Parameters.AddWithValue("cardnumber", cardnum)
                End If
                cmd.Parameters.AddWithValue("wit_detail", String.Format("{0:00}", DateTime.Now.Hour()) &
                                            String.Format("{0:00}", DateTime.Now.Minute()) &
                                            String.Format("{0:00}", DateTime.Now.Second()))
                cmd.Parameters.AddWithValue("billing_id", billid)
                cmd.Parameters.AddWithValue("total", accamount - wit_amount)
                cmd.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("Withdraw Sucessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("You can't withdraw money more than the limit")
            End If
        Else
            DoWithDraw(billid, wit_amount)
            Dim cardnum = getCardbyBill(billid)
            conn.Open()
            Dim sql = "Insert into withdraw values(@wit_datetime,@wit_total,@wit_limit,@wit_detail,@cardnumber,@billing_id,@total)"
            If cardnum.Equals("") Then
                sql = "Insert into withdraw (wit_datetime,wit_total,wit_limit,wit_detail,billing_id,total) values(@wit_datetime,@wit_total,@wit_limit,@wit_detail,@billing_id,@total)"
            End If
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("wit_datetime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("wit_total", wit_amount)
            cmd.Parameters.AddWithValue("wit_limit", acclimit)
            If Not cardnum.Equals("") Then
                cmd.Parameters.AddWithValue("cardnumber", cardnum)
            End If
            cmd.Parameters.AddWithValue("wit_detail", String.Format("{0:00}", DateTime.Now.Hour()) &
                                            String.Format("{0:00}", DateTime.Now.Minute()) &
                                            String.Format("{0:00}", DateTime.Now.Second()))
            cmd.Parameters.AddWithValue("billing_id", billid)
            cmd.Parameters.AddWithValue("total", accamount - wit_amount)
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Withdraw Sucessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Function getCardbyBill(billid As String)
        conn.Open()
        Dim card = ""
        Dim sql As String = "SELECT cardnumber " &
            "FROM customer_card where billing_id = '" & billid & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read 'Check the data in command
            card = reader("cardnumber")
        End While
        conn.Close()
        Return card
    End Function

    Private Sub DoWithDraw(billid As String, wit_amount As Double)
        conn.Open()
        Dim Sql = "update billing_account set " &
                    "billing_amount = billing_amount - @wit_amount " &
                    "where billing_id = @bill_id"
        Dim cmd As New SqlCommand(Sql, conn)
        cmd.Parameters.AddWithValue("wit_amount", wit_amount)
        cmd.Parameters.AddWithValue("bill_id", billid)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Function getAccAmount(billid As String)
        conn.Open()
        Dim accamount = 0
        Dim sql As String = "SELECT billing_amount " &
            "FROM billing_account where billing_id = '" & billid & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read 'Check the data in command
            accamount = reader("billing_amount")
        End While
        conn.Close()
        Return accamount
    End Function

    Private Function getAccLimit(billid As String)
        conn.Open()
        Dim acclimit = 0
        Dim sql As String = "SELECT wit_limit " &
            "FROM Customer_card where billing_id = '" & billid & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read 'Check the data in command
            If Not IsDBNull(reader("wit_limit")) Then
                acclimit = reader("wit_limit")
            End If
        End While
        conn.Close()
        Return acclimit
    End Function
    Private Sub Manager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If but.Text = "Witdraw" Then
            txtAmount.Show()
            Label2.Show()
            Label6.Show()
            Label7.Hide()
            Label5.Text = "WitLimit : "
            Label1.Text = "Withdraw Account"
        ElseIf but.Text = "Deposit" Then
            txtAmount.Hide()
            Label2.Hide()
            Label7.Show()
            Label1.Text = "Deposit Account"
            txtlimit_Dep.Enabled = True
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub but_Click(sender As Object, e As EventArgs) Handles but.Click
        If but.Text = "Witdraw" Then
            If IsNumeric(txtAmount.Text) Then
                AddWithdraw(txtCus_id.Text, txtAmount.Text)

            Else
                MessageBox.Show("Amount isn't number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If IsNumeric(txtlimit_Dep.Text) Then
                AddDeposit(txtCus_id.Text, txtlimit_Dep.Text)
                MessageBox.Show("Deposit Sucessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Amount isn't number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class