Imports System.Data
Imports System.Data.SqlClient
Public Class CreditCard
    Dim id As String
    Dim type As String
    Dim bank As String
    Dim card As String
    Dim conStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VB\ProjectBank\ProjectBank\DataBanks.mdf"
    Dim conn As New SqlConnection(conStr)
    Public Sub New(mode As String, id As String, bank As String)
        InitializeComponent()
        Me.id = id
        searchCusDetailForCard(id)
        cbxBank.SelectedItem = bank
        but.Text = mode
    End Sub
    Public Sub New(id As String, type As String, bank As String, mode As String, card As String)
        InitializeComponent()
        Me.type = type
        Me.bank = bank
        but.Text = mode
        Me.id = id
        Me.card = card
        searchCusDetailForCard(id)
        searchWitlim()
        cbxBank.SelectedItem = bank
        cbxType.SelectedItem = type
    End Sub
    Private Sub searchWitlim()
        conn.Open()
        Dim sql As String = "SELECT wit_limit " &
            "FROM customer_card where cardnumber = '" & card & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read 'Check the data in command
            If Not IsDBNull(reader("wit_limit")) Then
                txtLimit.Text = reader("wit_limit")
            End If
        End While
        conn.Close()
    End Sub

    Private Sub searchCusDetailForCard(billing_id As String)
        conn.Open()
        Dim sql As String = "SELECT cus_id " &
            "FROM billing_account where billing_id = '" & billing_id & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        While reader.Read 'Check the data in command
            txtID.Text = reader("cus_id")
        End While
        conn.Close()
    End Sub
    Dim creditCardIDDigit(14) As Integer
    Dim calCreditId As Integer
    Dim creditCardId As String

    Private Sub CreateCreditID()
        Dim rnd As New Random()
        creditCardId = ""
        Dim sum As Integer = 0
        For i = 0 To creditCardIDDigit.Length - 1
            creditCardIDDigit(i) = rnd.Next(1, 10)
            If i Mod 2 = 0 Then
                calCreditId = creditCardIDDigit(i) * 2
                If calCreditId > 9 Then
                    calCreditId -= 9
                End If
            Else
                calCreditId = creditCardIDDigit(i)
            End If
            sum += calCreditId
            creditCardId &= creditCardIDDigit(i)
        Next
        creditCardId &= sum Mod 10
        If CheckCreditInDB() Then
            CreateCreditID()
        End If
    End Sub

    Private Function CheckCreditInDB()
        conn.Open()
        Dim sql As String = "SELECT * FROM Customer_Card where Cardnumber = '" &
            creditCardId & "'"
        Dim cmd As New SqlCommand(sql, conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader

        Dim cre = ""
        While reader.Read 'Check the data in command
            cre = reader(0)
        End While
        conn.Close()
        If cre = "" Then
            Return False
        End If
        Return True
    End Function
    Private Function AddNewCard(cusid As String, cardType As String, billid As String, witlimit As String, pass As String)
        CreateCreditID()
        Dim cwitlim As DBNull
        Dim cwitlim2 = 0
        If Not witlimit.Equals("") Then
            If IsNumeric(witlimit) Then
                cwitlim2 = CInt(witlimit)
            Else
                MessageBox.Show("Witlimit isn't number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
            Dim ctid = getCardTypeID(cardType)
        Dim cbillid = billid
        Dim cbillid2 As DBNull

        conn.Open()
        Dim sql = "insert into customer_card values(@card_id,@pass,@billing,@cardtype,@witlim,@cusid)"
        If ctid = 1 Or ctid = 2 Then
            If cwitlim2 > 0 Then
                sql = "insert into customer_card (cardnumber,password,card_type,wit_limit,cus_id) " &
                    "values(@card_id,@pass,@cardtype,@witlim,@cusid)"
            Else
                sql = "insert into customer_card (cardnumber,password,card_type,cus_id)  values(@card_id,@pass,@cardtype,@cusid)"
            End If

        Else
            If cwitlim2 > 0 Then
                sql = "insert into customer_card values(@card_id,@pass,@billing,@cardtype,@witlim,@cusid)"
            Else
                sql = "insert into customer_card (cardnumber,password,billing_id,card_type,cus_id) values(@card_id,@pass,@billing,@cardtype,@cusid)"
            End If
        End If
        Dim cmd As New SqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("card_id", creditCardId)
        cmd.Parameters.AddWithValue("pass", pass)
        If sql.Contains("@billing") Then
            cmd.Parameters.AddWithValue("billing", cbillid)
        End If
        cmd.Parameters.AddWithValue("cardtype", CInt(ctid))
        If sql.Contains("@witlim") Then
            cmd.Parameters.AddWithValue("witlim", cwitlim2)
        End If
        cmd.Parameters.AddWithValue("cusid", cusid)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Function
    Public Sub Clear()
        txtLimit.Text = ""
        txtPass.Text = ""
        txtConfirm.Text = ""
    End Sub
    Private Sub but_Click(sender As Object, e As EventArgs) Handles but.Click
        If but.Text = "Create Card" Then
            If txtPass.Text = txtConfirm.Text Then
                'Try
                If IsNumeric(txtPass.Text) And IsNumeric(txtConfirm.Text) Then
                    If txtPass.Text.Length = 6 And txtConfirm.Text.Length = 6 Then
                        Dim a = CInt(txtPass.Text)
                        AddNewCard(txtID.Text, cbxType.SelectedItem, id, txtLimit.Text, txtPass.Text)
                        'Catch ex As Exception
                        '    Console.WriteLine(ex.StackTrace)
                        '    MessageBox.Show("Password or Wit Limit must be number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        'End Try
                        MessageBox.Show("Create Card Sucessful", "Sucessful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    Else
                        MessageBox.Show("Password and Confirm Password Length equal 6 !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Password and Confirm Password isn't number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Else
                MessageBox.Show("Password and Confirm Password not match !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Else
            If txtPass.Text = txtConfirm.Text Then
                If IsNumeric(txtPass.Text) And IsNumeric(txtConfirm.Text) Then
                    If txtPass.Text.Length = 6 And txtConfirm.Text.Length = 6 Then
                        UpdateData()
                    Else
                        MessageBox.Show("Password and Confirm Password Length equal 6 !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Password and Confirm Password isn't number !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                    MessageBox.Show("Password and Confirm Password not match !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub CreditCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If but.Text = "Edit Card" Then
            txtID.Enabled = False
            cbxBank.Enabled = False
            cbxType.Enabled = False
        End If
    End Sub


    Public Sub UpdateData()
        conn.Open()
        Dim sql As String = "update Customer_Card set " &
                    "wit_limit = @limit, " &
                    "password = @pass " &
                    "where cardnumber = '" & card & "'"
        Dim cmd As New SqlCommand(sql, conn)

        cmd.Parameters.AddWithValue("limit", txtLimit.Text)
        cmd.Parameters.AddWithValue("pass", txtPass.Text)
        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update Sucessful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        conn.Close()
    End Sub

    Private Function getCardTypeID(card_des As String)
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM Card_type where card_decription = '" & card_des & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim cid = ""
        While reader.Read 'Check the data in command
            cid = reader("card_type_id")
        End While
        conn.Close()
        Return cid

    End Function

    Private Sub butReset_Click(sender As Object, e As EventArgs) Handles butReset.Click
        If but.Text = "Create Card" Then
            cbxType.SelectedIndex = -1
            Clear()
        Else
            Clear()
        End If
    End Sub
End Class