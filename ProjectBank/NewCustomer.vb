Imports System.Data
Imports System.Data.SqlClient
Public Class NewCustomer
    Dim id As String
    Dim phone As String
    Dim money As String
    Dim type As String
    Dim bank As String
    Dim conStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VB\ProjectBank\ProjectBank\DataBanks.mdf"
    Dim conn As New SqlConnection(conStr)

    Public Sub New(mode As String)
        InitializeComponent()
        but.Text = mode
    End Sub
    Public Sub New(id As String, phone As String, money As String, type As String, bank As String, mode As String)
        InitializeComponent()
        but.Text = mode
        Me.id = id
        Me.phone = phone
        Me.money = money
        Me.type = type
        Me.bank = bank
        searchCusDetail(phone)
        txtPhone.Text = phone
        cbxBank.SelectedItem = bank
        cbxType.SelectedItem = type
        txtAmount.Text = money
    End Sub

    Public Sub Clear()
        txtFname.Text = ""
        txtLname.Text = ""
        txtAddress.Text = ""
        txtPhone.Text = ""
        cbxType.SelectedIndex = -1
        cbxBank.SelectedIndex = -1
        txtEmail.Text = ""
        txtAmount.Text = ""
    End Sub


    Private Sub butReset_Click(sender As Object, e As EventArgs) Handles butReset.Click
        Clear()
    End Sub

    Private Sub NewCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If but.Text = "Edit Customer" Then
            cbxBank.Enabled = False
            cbxType.Enabled = False
            txtAmount.Enabled = False
            butReset.Enabled = False
        End If
    End Sub
    Private Sub searchCusDetail(cus_phone As String)
        conn.Open()
        Dim sql As String = "SELECT cus_id,cus_fname,cus_lname,cus_address,cus_email " &
            "FROM Customers where cus_phone = '" & cus_phone & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read 'Check the data in command
            txtFname.Text = reader("cus_fname")
            txtLname.Text = reader("cus_lname")
            txtAddress.Text = reader("cus_address")
            txtEmail.Text = reader("cus_email")
            Me.id = reader("cus_id")
        End While
        conn.Close()
    End Sub
    Private Function AddNewCus(name As String, lname As String, address As String, phone As String, email As String, acctype As Integer,
                          bankid As String, accamount As Integer)
        Dim bid = getBankID(bankid)
        Dim ncusid = getNewCusID()
        If checkCus(name, lname, phone) Then
            conn.Open()

            Dim sql = "insert into Customers values(@cusid,@name,@lname,@address,@phone,@email,'ON')"
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("cusid", ncusid)
            cmd.Parameters.AddWithValue("name", name)
            cmd.Parameters.AddWithValue("lname", lname)
            cmd.Parameters.AddWithValue("address", address)
            cmd.Parameters.AddWithValue("phone", phone)
            cmd.Parameters.AddWithValue("email", email)
            cmd.ExecuteNonQuery()
            conn.Close()
            AddNewAccount(ncusid, accamount, acctype, bid)
            Return True
        Else
            Dim cus_id = getCusID(name, lname, phone)
            conn.Open()
            Dim sql = "update Customers set status='ON' where cus_id = '" & cus_id & "'"
            Dim cmd As New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
            AddNewAccount(cus_id, accamount, acctype, bid)
            Return True
        End If
        Return False
    End Function

    Private Function getNewCusID()
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM Customers"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim count = 1
        While reader.Read 'Check the data in command
            count += 1
        End While
        conn.Close()
        Dim cusstr = "C" & String.Format("{0:000}", count)
        Return cusstr
    End Function

    Private Function getCusID(name As String, lname As String, phone As String)
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM Customers where (cus_fname = '" & name & "' and cus_lname='" & lname & "') and cus_phone = '" & phone & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim cid = ""
        While reader.Read 'Check the data in command
            cid = reader("cus_id")
        End While
        conn.Close()
        Return cid
    End Function
    Private Function checkCus(name As String, lname As String, phone As String)
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM Customers where (cus_fname = '" & name & "' and cus_lname='" & lname & "') and cus_phone = '" & phone & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim count = 0
        While reader.Read 'Check the data in command
            count += 1
        End While
        conn.Close()
        If count > 0 Then
            Return False
        End If
        Return True
    End Function

    Private Function AddNewAccount(cusid As String, accamount As Integer, acctype As Integer, bankid As String)
        CreateBillingID()
        conn.Open()
        Dim sql = "insert into billing_account values(@billing_id,@amount,@cusid,@acctype,@bankid)"
        Dim cmd As New SqlCommand(sql, conn)
        cmd.Parameters.AddWithValue("billing_id", billingID)
        cmd.Parameters.AddWithValue("amount", accamount)
        cmd.Parameters.AddWithValue("cusid", cusid)
        cmd.Parameters.AddWithValue("acctype", acctype)
        cmd.Parameters.AddWithValue("bankid", bankid)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Function

    Private Function getBankID(bank_des As String)
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM banks where bank_name = '" & bank_des & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim Bid = ""
        While reader.Read 'Check the data in command
            Bid = reader("bank_id")
        End While
        conn.Close()
        Return Bid

    End Function
    Dim billingID As String = ""
    Dim creditCardId As String = ""
    Private Sub CreateBillingID()
        Dim rnd As New Random()
        For i = 0 To 9
            billingID &= rnd.Next(1, 10)
        Next
        If CheckBillingInDB() Then
            CreateBillingID()
        End If
    End Sub

    Private Function CheckBillingInDB()
        conn.Open()
        Dim sql As String = "SELECT * FROM billing_account where billing_id = '" &
            billingID & "'"
        Dim cmd As New SqlCommand(sql, conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader

        Dim bil = ""
        While reader.Read 'Check the data in command
            bil = reader(0)
        End While
        conn.Close()
        If bil = "" Then
            Return False
        End If
        Return True
    End Function
    Public Sub UpdateData()
        conn.Open()
        Dim sql As String = "update Customers set " &
                    "cus_fname = @fname, " &
                    "cus_lname = @lname, " &
                    "cus_address = @address, " &
                    "cus_phone = @phone, " &
                    "cus_email = @email " &
                    "where Cus_id = '" & id & "'"
        Dim cmd As New SqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("fname", txtFname.Text)
        cmd.Parameters.AddWithValue("lname", txtLname.Text)
        cmd.Parameters.AddWithValue("address", txtAddress.Text)
        cmd.Parameters.AddWithValue("phone", txtPhone.Text)
        cmd.Parameters.AddWithValue("email", txtEmail.Text)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update Sucessful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        conn.Close()
    End Sub
    Private Sub but_Click(sender As Object, e As EventArgs) Handles but.Click
        If txtFname.Text = "" Or txtLname.Text = "" Or txtAddress.Text = "" Or txtPhone.Text = "" Or txtEmail.Text = "" Or cbxBank.SelectedIndex = -1 Or cbxType.SelectedIndex = -1 Or txtAmount.Text = "" Then
            MessageBox.Show("Plese fill the blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If IsNumeric(txtPhone.Text) And txtPhone.Text.StartsWith("0") And txtPhone.Text.Length = 10 Then

                If txtEmail.Text.EndsWith("@gmail.com") Or txtEmail.Text.EndsWith("@hotmail.com") Then
                    If but.Text = "Create Customer" Then
                        If IsNumeric(txtAmount.Text) Then
                            If txtAmount.Text < 500 Then
                                MessageBox.Show("Amount than more 500 B.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                If AddNewCus(txtFname.Text, txtLname.Text, txtAddress.Text, txtPhone.Text, txtEmail.Text, cbxType.SelectedIndex + 1, cbxBank.SelectedItem, txtAmount.Text) Then
                                    MessageBox.Show("Insert New Customer ", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.Close()
                                Else
                                    MessageBox.Show("Error Insert value ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                            End If
                        Else
                            MessageBox.Show("Amount isn't number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        UpdateData()
                    End If
                Else
                    MessageBox.Show("Email is not correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Phone is not correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If


        End If
    End Sub

    Private Sub NewCustomer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Main.ShowAllCus()
    End Sub
End Class