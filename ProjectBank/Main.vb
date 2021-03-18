Imports System.Data
Imports System.Data.SqlClient
Public Class Main
    Dim empID As String = ""
    Dim empname As String = ""
    Dim conStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VB\ProjectBank\ProjectBank\DataBanks.mdf"
    Dim conn As New SqlConnection(conStr)
    Dim Curr = "cus"
    Dim button_curr = ""

    Private Sub linkLoginout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkLoginout.LinkClicked
        Dim login As New Form1
        Dim logout As DialogResult = MessageBox.Show("Are you sure.", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If logout = DialogResult.Yes Then
            login.Show()
            Me.Close()
        End If
    End Sub

    Dim billid As Object
    Dim Enbillid As Object
    Dim fullname As Object
    Dim phone As Object
    Dim address As Object
    Dim bank As Object
    Dim cardnum As Object
    Private Sub SaveSlip(type As String, cus_id As String, id As String)
        Dim strPrint As String
        GetCusDetail(cus_id, id)
        strPrint = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & vbCrLf 'DateTimeToday
        strPrint = strPrint & "---------------------------------------------" & vbCrLf
        strPrint = strPrint & "Type of Slip : " & type & vbCrLf 'สถาณะธุรกรรม
        strPrint = strPrint & "Bank Name    : " & bank & vbCrLf 'ธนาคาร
        strPrint = strPrint & "Address      : " & address & vbCrLf 'สถานที
        strPrint = strPrint & "Name         : " & fullname & vbCrLf 'ชื่อนามสกุล
        strPrint = strPrint & "Acc. ID      : " & Enbillid & vbCrLf 'ชื่อนามสกุล
        strPrint = strPrint & "---------------------------------------------" & vbCrLf
        Dim liststr = createList(type)
        For Each Str As String In liststr
            strPrint &= Str
        Next
        'strPrint &= createList(type)
        Printer.Print(strPrint)
    End Sub

    Private Function createList(type As String)
        Dim listofstr As New ArrayList
        Dim strdet = ""
        If type.ToLower().Equals("wit") Then
            conn.Open()
            Dim sql As String = "SELECT wit_detail,wit_datetime,wit_total,total " &
                "FROM withdraw where " &
                " billing_id = '" & billid & "'" 'ชื่อนามสกุล

            sql &= " order by wit_id asc"
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read 'Check the data in command
                strdet = ""

                strdet &= "" & vbCrLf
                strdet &= "Detail No.      : " & reader(0) & vbCrLf
                strdet &= "Date            : " & reader(1) & vbCrLf 'เลขที่อ้สงอิง
                strdet &= "Withdraw Amount : " & reader(2) & vbCrLf
                strdet &= "Account Amount  : " & reader(3) & vbCrLf 'จำนวนเงิน
                strdet &= "-----------------------------------------------" & vbCrLf

                listofstr.Add(strdet)
            End While
            conn.Close()

        Else
            conn.Open()
            Dim sql As String = "SELECT dep_detail,dep_datetime,dep_amount,dep_total " &
                "FROM deposit where "
            sql &= " billing_id = '" & billid & "'" 'ชื่อนามสกุล

            sql &= " order by dep_id asc"
            Dim cmd As New SqlCommand(sql, conn)
            Dim reader As SqlDataReader = cmd.ExecuteReader
            While reader.Read 'Check the data in command
                strdet = ""
                strdet &= "" & vbCrLf
                strdet &= "Detail No.      : " & reader(0) & vbCrLf
                strdet &= " Date           : " & reader(1) & vbCrLf 'เลขที่อ้สงอิง
                strdet &= "Deposit Amount  : " & reader(2) & vbCrLf
                strdet &= " Account Amount : " & reader(3) & vbCrLf 'จำนวนเงิน
                strdet &= "-----------------------------------------------" & vbCrLf
                listofstr.Add(strdet)

            End While
            conn.Close()
        End If
        Return listofstr
    End Function
    Private Sub GetCusDetail(cus_id As String, id As String)
        conn.Open()
        Dim sql = "select b.billing_id,SUBSTRING(b.billing_id,1,6),cus_fname + ' ' + cus_lname As 'Full Name',SUBSTRING(cus_phone,1,6),cus_address,bank_name " &
                "from customers c,billing_account b,banks bk " &
                "where c.cus_id = b.cus_id and bk.bank_id = b.bank_id and c.cus_id = '" & cus_id & "' and " &
                "b.billing_id='" & id & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read 'Check the data in command
            billid = reader(0)
            Enbillid = reader(1) & "XXXX"
            fullname = reader(2)
            phone = reader(3) & "XXXX"
            address = reader(4)
            bank = reader(5)
        End While
        conn.Close()

    End Sub
    Public Sub ShowAllCus()
        conn.Open()

        Dim sql As String = "SELECT ba.billing_id As 'Billing ID' ,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',cu.cus_phone As 'Phone'," &
            "ba.billing_amount as 'Amount',bt.Billing_decription as 'Decription',bk.bank_name as 'Bank' " &
            "FROM Billing_account ba,Customers cu,billing_type bt,banks bk where ba.cus_id = cu.cus_id and " &
            "ba.billing_type_id = bt.billing_type_id and bk.bank_id = ba.bank_id"
        Dim cmd As New SqlCommand(sql, conn)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Billing")

        conn.Close()
        DataGridView1.DataSource = data.Tables("Billing")
    End Sub
    Private Sub ShowAllCards()
        conn.Open()
        DataGridView1.DataSource = New DataSet()
        Dim sql As String = "SELECT cc.cardnumber,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',ba.billing_id," &
            "bt.Billing_decription,bk.bank_name,ct.Card_decription " &
            "FROM Billing_account ba " &
            "Left Join customer_card cc on cc.billing_id = ba.billing_id  " &
            "left Join card_type ct on cc.card_type = ct.card_type_id " &
            "Inner join billing_type bt on ba.billing_type_id = bt.billing_type_id " &
            "Inner join banks bk on bk.bank_id = ba.bank_id " &
            "Inner Join Customers cu on cu.cus_id = ba.cus_id "




        Dim cmd As New SqlCommand(sql, conn)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "card")
        conn.Close()
        DataGridView1.DataSource = data.Tables("card")
    End Sub
    Private Sub but_Cus_Click(sender As Object, e As EventArgs) Handles but_Cus.Click
        Curr = "Cus"
        but_EditCus.Show()
        but_CreateCus.BringToFront()
        but_EditCus.BringToFront()
        Search(Curr, "")

    End Sub

    Private Sub but_Card_Click(sender As Object, e As EventArgs) Handles but_Card.Click
        Curr = "Card"
        but_EditCard.Show()
        but_CreateCard.BringToFront()
        but_EditCard.BringToFront()
        'Search(Curr, "")
        ShowAllCards()
    End Sub

    Private Sub but_Wit_Click(sender As Object, e As EventArgs) Handles but_Wit.Click
        Curr = "Wit"
        but_Print_Wit.Show()
        but_Print_Wit.BringToFront()
        but_Witdraw.BringToFront()
        Search(Curr, "")
    End Sub

    Private Sub but_Dep_Click(sender As Object, e As EventArgs) Handles but_Dep.Click
        Curr = "Dep"
        but_Print_Dep.Show()
        but_Deposit.BringToFront()
        but_Print_Dep.BringToFront()
        Search(Curr, "")
    End Sub

    Private Sub but_Close_Click(sender As Object, e As EventArgs) Handles but_Close.Click
        Curr = "Close"
        but_Close_Delete.BringToFront()

        but_Print_Wit.Hide()
        but_Print_Dep.Hide()
        but_EditCus.Hide()
        but_EditCard.Hide()
        Search(Curr, "")

    End Sub


    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Timer1.Start()
        ShowAllCus()
        but_CreateCus.BringToFront()
        but_EditCus.BringToFront()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    Private Sub but_CreateCus_Click(sender As Object, e As EventArgs) Handles but_CreateCus.Click
        Dim text As String = "Create Customer"
        Dim cus As New NewCustomer(text)
        cus.ShowDialog()
        ShowAllCus()
    End Sub
    Private Sub Search(type As String, word As String)
        'cus,card,wit,dep,close
        conn.Open()
        DataGridView1.DataSource = New DataSet()
        Dim sql As String
        If type.ToLower().Equals("cus") Then
            sql = "SELECT ba.billing_id As 'Billing ID' ,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',cu.cus_phone As 'Phone'," &
            "ba.billing_amount as 'Amount',bt.Billing_decription as 'Decription',bk.bank_name as 'Bank' " &
            "FROM Billing_account ba,Customers cu,billing_type bt,banks bk where ba.cus_id = cu.cus_id and " &
            "ba.billing_type_id = bt.billing_type_id and bk.bank_id = ba.bank_id "
        ElseIf type.ToLower().Equals("card") Then
            sql = "SELECT cc.cardnumber,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',ba.billing_id," &
            "bt.Billing_decription,bk.bank_name,ct.Card_decription " &
            "FROM Billing_account ba " &
            "Left Join customer_card cc on cc.billing_id = ba.billing_id  " &
            "left Join card_type ct on cc.card_type = ct.card_type_id " &
            "Inner join billing_type bt on ba.billing_type_id = bt.billing_type_id " &
            "Inner join banks bk on bk.bank_id = ba.bank_id " &
            "Inner Join Customers cu on cu.cus_id = ba.cus_id "
        ElseIf type.ToLower().Equals("wit") Then
            sql = "SELECT ba.billing_id,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',cu.cus_phone," &
            "ba.billing_amount,bt.Billing_decription,bk.bank_name " &
            "FROM Billing_account ba,Customers cu,billing_type bt,banks bk where ba.cus_id = cu.cus_id and " &
            "ba.billing_type_id = bt.billing_type_id and bk.bank_id = ba.bank_id "
        ElseIf type.ToLower().Equals("dep") Then
            sql = "SELECT ba.billing_id,cu.cus_fname + ' ' + cu.cus_lname As 'Full Name',cu.cus_phone," &
            "ba.billing_amount,bt.Billing_decription,bk.bank_name " &
            "FROM Billing_account ba,Customers cu,billing_type bt,banks bk where ba.cus_id = cu.cus_id and " &
            "ba.billing_type_id = bt.billing_type_id and bk.bank_id = ba.bank_id "
        Else
            sql = "select cus_id,cus_fname + ' ' + cus_lname As 'Full Name',cus_phone,status " &
                "from customers "
        End If
        If type.ToLower().Equals("card") Or type.ToLower().Equals("close") Then
            sql &= "where (cus_fname like '%" & word & "%' or cus_lname like '%" & word & "%' or cus_phone like '%" & word & "%')"
        Else
            sql &= "and (cus_fname like '%" & word & "%' or cus_lname like '%" & word & "%' or cus_phone like '%" & word & "%')"

        End If


        Dim cmd As New SqlCommand(sql, conn)

        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "search")

        conn.Close()
        DataGridView1.DataSource = data.Tables("search")
    End Sub
    Private Sub butSearch_Click(sender As Object, e As EventArgs) Handles butSearch.Click
        Search(Curr, txtSearch.Text)
    End Sub

    Private Sub DeleteCard(cardnum As String)
        Dim result As DialogResult = MessageBox.Show("Do you sure Close Card Account ?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            conn.Open()
            Dim Sql = "delete from customer_card where cardnumber = '" & cardnum & "'"
            Dim cmd As New SqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()
        End If
    End Sub
    Private Sub but_Close_Delete_Click(sender As Object, e As EventArgs) Handles but_Close_Delete.Click
        Dim cus_id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        DeleteCardAndBilling(cus_id)
    End Sub

    Private Sub but_Deposit_Click(sender As Object, e As EventArgs) Handles but_Deposit.Click
        Dim text As String = "Deposit"
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Dim name As String = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        Dim dep As New Manager(text, id, name)
        dep.ShowDialog()
        Search("dep", "")
    End Sub

    Private Sub but_EditCus_Click(sender As Object, e As EventArgs) Handles but_EditCus.Click
        button_curr = ""
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Dim phone As String = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        Dim money As String = DataGridView1.SelectedRows.Item(0).Cells(3).Value
        Dim type As String = DataGridView1.SelectedRows.Item(0).Cells(4).Value
        Dim bank As String = DataGridView1.SelectedRows.Item(0).Cells(5).Value
        Dim text As String = "Edit Customer"
        Dim cus As New NewCustomer(id, phone, money, type, bank, text)
        cus.ShowDialog()
        ShowAllCus()

    End Sub

    Private Sub but_Print_Dep_Click(sender As Object, e As EventArgs) Handles but_Print_Dep.Click
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Dim cusid = getCusIdbyBillid(id)
        SaveSlip("Dep", cusid, id)
    End Sub


    Private Sub but_CreateCard_Click(sender As Object, e As EventArgs) Handles but_CreateCard.Click
        Dim text As String = "Create Card"
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(2).Value
        Dim bank As String = DataGridView1.SelectedRows.Item(0).Cells(4).Value
        Dim card As New CreditCard(text, id, bank)
        card.ShowDialog()
        ShowAllCards()
    End Sub

    Private Sub but_EditCard_Click(sender As Object, e As EventArgs) Handles but_EditCard.Click
        If IsDBNull(DataGridView1.SelectedRows.Item(0).Cells(0).Value) Then
            MessageBox.Show("This account don't have Cardnumber !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim cardid As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
            Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(2).Value
            Dim type As String = DataGridView1.SelectedRows.Item(0).Cells(5).Value
            Dim bank As String = DataGridView1.SelectedRows.Item(0).Cells(4).Value
            Dim text As String = "Edit Card"
            Dim card As New CreditCard(id, type, bank, text, cardid)
            card.ShowDialog()
            ShowAllCards()
        End If

    End Sub

    Private Function getCusIdbyBillid(billing_id As String)
        conn.Open()
        Dim sql As String = "SELECT * " &
            "FROM billing_account where billing_id = '" & billing_id & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader
        Dim cid = ""
        While reader.Read 'Check the data in command
            cid = reader("cus_id")
        End While
        conn.Close()
        Return cid

    End Function

    Private Sub but_Print_Wit_Click(sender As Object, e As EventArgs) Handles but_Print_Wit.Click
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Dim cusid = getCusIdbyBillid(id)
        'MessageBox.Show(id & "  " & cusid)
        SaveSlip("Wit", cusid, id)
    End Sub

    Private Sub but_Witdraw_Click(sender As Object, e As EventArgs) Handles but_Witdraw.Click
        Dim text As String = "Witdraw"
        Dim id As String = DataGridView1.SelectedRows.Item(0).Cells(0).Value
        Dim name As String = DataGridView1.SelectedRows.Item(0).Cells(1).Value
        Dim amount As Double = DataGridView1.SelectedRows.Item(0).Cells(3).Value
        Dim wit As New Manager(text, id, amount, name)
        wit.ShowDialog()
        Search("Wit", "")
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = False
        Form1.Close()
    End Sub

    Private Sub DeleteCardAndBilling(cus_id As String)
        Dim result As DialogResult = MessageBox.Show("Do you want Close this Account", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result = DialogResult.Yes Then
            conn.Open()

            Dim sql = "delete from customer_card where cus_id = '" & cus_id & "'"
            Dim cmd As New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()

            sql = "delete from billing_account where cus_id = '" & cus_id & "'"
            cmd = New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()

            sql = "update customers set " &
                        "status = @status " &
                        "where cus_id = @cus_id"
            cmd = New SqlCommand(sql, conn)

            cmd.Parameters.AddWithValue("status", "OFF")
            cmd.Parameters.AddWithValue("cus_id", cus_id)

            cmd.ExecuteNonQuery()
            conn.Close()
            Search("Close", "")
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class