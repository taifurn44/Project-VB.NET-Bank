Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim empID As String = ""
    Dim empname As String = ""
    Dim conStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\VB\ProjectBank\ProjectBank\DataBanks.mdf"
    Dim conn As New SqlConnection(conStr)
    Private Function CheckLogin(emp_ID As String, pass As String)
        conn.Open()
        Dim sql As String = "SELECT emp_id,emp_fname,emp_lname FROM employees where emp_id = '" &
            emp_ID & "' and emp_pass = '" & pass & "'"
        Dim cmd As New SqlCommand(sql, conn)

        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read 'Check the data in command
            empID = reader("emp_id")
            empname = reader("emp_fname") & " " & reader("emp_lname")
        End While
        conn.Close()
        If empID = "" Then
            Return False
        End If
        Return True
    End Function



    Private Sub butLogin_Click(sender As Object, e As EventArgs) Handles butLogin.Click
        Dim main As New Main
        If CheckLogin(txtUser.Text, txtPass.Text) = True Then
            MessageBox.Show("Welcome " + empname + ".", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
            main.Show()
            Me.Hide()
            txtUser.Text = ""
            txtPass.Text = ""
        ElseIf txtUser.Text = "" Or txtPass.Text = "" Then
            MessageBox.Show("Please Fill Username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUser.Text = ""
            txtPass.Text = ""
        Else
            txtUser.Text = ""
            txtPass.Text = ""
            MessageBox.Show("Username or password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class
