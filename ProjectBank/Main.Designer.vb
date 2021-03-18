<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.but_Cus = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.but_Close = New System.Windows.Forms.Button()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.but_Dep = New System.Windows.Forms.Button()
        Me.but_Wit = New System.Windows.Forms.Button()
        Me.but_Card = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.linkLoginout = New System.Windows.Forms.LinkLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.butSearch = New System.Windows.Forms.Button()
        Me.but_CreateCus = New System.Windows.Forms.Button()
        Me.but_EditCus = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.but_EditCard = New System.Windows.Forms.Button()
        Me.but_CreateCard = New System.Windows.Forms.Button()
        Me.but_Witdraw = New System.Windows.Forms.Button()
        Me.but_Print_Wit = New System.Windows.Forms.Button()
        Me.but_Deposit = New System.Windows.Forms.Button()
        Me.but_Close_Delete = New System.Windows.Forms.Button()
        Me.but_Print_Dep = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 71)
        Me.Panel2.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = Global.ProjectBank.My.Resources.Resources.dollar
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel3.Location = New System.Drawing.Point(167, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(33, 24)
        Me.Panel3.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "BankManager"
        '
        'but_Cus
        '
        Me.but_Cus.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.but_Cus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Cus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.but_Cus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Cus.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.but_Cus.Location = New System.Drawing.Point(0, 103)
        Me.but_Cus.Name = "but_Cus"
        Me.but_Cus.Size = New System.Drawing.Size(200, 54)
        Me.but_Cus.TabIndex = 1
        Me.but_Cus.Text = "CUSTOMER"
        Me.but_Cus.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel10)
        Me.Panel1.Controls.Add(Me.but_Close)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.but_Dep)
        Me.Panel1.Controls.Add(Me.but_Wit)
        Me.Panel1.Controls.Add(Me.but_Card)
        Me.Panel1.Controls.Add(Me.but_Cus)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 530)
        Me.Panel1.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel10.BackgroundImage = Global.ProjectBank.My.Resources.Resources.trash
        Me.Panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel10.Location = New System.Drawing.Point(15, 336)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(29, 17)
        Me.Panel10.TabIndex = 9
        '
        'but_Close
        '
        Me.but_Close.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.but_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Close.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.but_Close.Location = New System.Drawing.Point(0, 319)
        Me.but_Close.Name = "but_Close"
        Me.but_Close.Size = New System.Drawing.Size(200, 54)
        Me.but_Close.TabIndex = 8
        Me.but_Close.Text = "CLOSE ACCOUNT"
        Me.but_Close.UseVisualStyleBackColor = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel9.BackgroundImage = Global.ProjectBank.My.Resources.Resources.deposit
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel9.Location = New System.Drawing.Point(15, 282)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(29, 17)
        Me.Panel9.TabIndex = 7
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel8.BackgroundImage = Global.ProjectBank.My.Resources.Resources.money
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel8.Location = New System.Drawing.Point(15, 231)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(29, 17)
        Me.Panel8.TabIndex = 7
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel7.BackgroundImage = Global.ProjectBank.My.Resources.Resources.credit_card
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel7.Location = New System.Drawing.Point(15, 177)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(29, 17)
        Me.Panel7.TabIndex = 7
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel6.BackgroundImage = Global.ProjectBank.My.Resources.Resources.search
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel6.Location = New System.Drawing.Point(15, 121)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(29, 17)
        Me.Panel6.TabIndex = 6
        '
        'but_Dep
        '
        Me.but_Dep.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.but_Dep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.but_Dep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Dep.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.but_Dep.Location = New System.Drawing.Point(0, 265)
        Me.but_Dep.Name = "but_Dep"
        Me.but_Dep.Size = New System.Drawing.Size(200, 54)
        Me.but_Dep.TabIndex = 4
        Me.but_Dep.Text = "DEPOSIT"
        Me.but_Dep.UseVisualStyleBackColor = False
        '
        'but_Wit
        '
        Me.but_Wit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.but_Wit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Wit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.but_Wit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Wit.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.but_Wit.Location = New System.Drawing.Point(0, 211)
        Me.but_Wit.Name = "but_Wit"
        Me.but_Wit.Size = New System.Drawing.Size(200, 54)
        Me.but_Wit.TabIndex = 3
        Me.but_Wit.Text = "WITHDRAW"
        Me.but_Wit.UseVisualStyleBackColor = False
        '
        'but_Card
        '
        Me.but_Card.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.but_Card.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Card.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.but_Card.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Card.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.but_Card.Location = New System.Drawing.Point(0, 157)
        Me.but_Card.Name = "but_Card"
        Me.but_Card.Size = New System.Drawing.Size(200, 54)
        Me.but_Card.TabIndex = 2
        Me.but_Card.Text = "CREDIT CARD"
        Me.but_Card.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.linkLoginout)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(200, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(677, 71)
        Me.Panel4.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(409, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "DateTime ToDay"
        '
        'linkLoginout
        '
        Me.linkLoginout.AutoSize = True
        Me.linkLoginout.Location = New System.Drawing.Point(602, 30)
        Me.linkLoginout.Name = "linkLoginout"
        Me.linkLoginout.Size = New System.Drawing.Size(52, 13)
        Me.linkLoginout.TabIndex = 4
        Me.linkLoginout.TabStop = True
        Me.linkLoginout.Text = "LOGOUT"
        '
        'Panel5
        '
        Me.Panel5.BackgroundImage = Global.ProjectBank.My.Resources.Resources.user
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel5.Location = New System.Drawing.Point(561, 20)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(35, 32)
        Me.Panel5.TabIndex = 3
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(218, 177)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(638, 347)
        Me.DataGridView1.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(218, 81)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(305, 27)
        Me.txtSearch.TabIndex = 3
        '
        'butSearch
        '
        Me.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSearch.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.butSearch.Location = New System.Drawing.Point(533, 81)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(98, 27)
        Me.butSearch.TabIndex = 4
        Me.butSearch.Text = "Search"
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'but_CreateCus
        '
        Me.but_CreateCus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_CreateCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_CreateCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_CreateCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_CreateCus.ForeColor = System.Drawing.Color.Silver
        Me.but_CreateCus.Location = New System.Drawing.Point(714, 121)
        Me.but_CreateCus.Name = "but_CreateCus"
        Me.but_CreateCus.Size = New System.Drawing.Size(142, 36)
        Me.but_CreateCus.TabIndex = 5
        Me.but_CreateCus.Text = "CREATE CUSTOMER"
        Me.but_CreateCus.UseVisualStyleBackColor = False
        '
        'but_EditCus
        '
        Me.but_EditCus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_EditCus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_EditCus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_EditCus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_EditCus.ForeColor = System.Drawing.Color.Silver
        Me.but_EditCus.Location = New System.Drawing.Point(554, 121)
        Me.but_EditCus.Name = "but_EditCus"
        Me.but_EditCus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_EditCus.Size = New System.Drawing.Size(142, 36)
        Me.but_EditCus.TabIndex = 6
        Me.but_EditCus.Text = "EDIT CUSTOMER"
        Me.but_EditCus.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'but_EditCard
        '
        Me.but_EditCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_EditCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_EditCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_EditCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_EditCard.ForeColor = System.Drawing.Color.Silver
        Me.but_EditCard.Location = New System.Drawing.Point(554, 121)
        Me.but_EditCard.Name = "but_EditCard"
        Me.but_EditCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_EditCard.Size = New System.Drawing.Size(142, 36)
        Me.but_EditCard.TabIndex = 8
        Me.but_EditCard.Text = "EDIT CARD"
        Me.but_EditCard.UseVisualStyleBackColor = False
        '
        'but_CreateCard
        '
        Me.but_CreateCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_CreateCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_CreateCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_CreateCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_CreateCard.ForeColor = System.Drawing.Color.Silver
        Me.but_CreateCard.Location = New System.Drawing.Point(714, 121)
        Me.but_CreateCard.Name = "but_CreateCard"
        Me.but_CreateCard.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_CreateCard.Size = New System.Drawing.Size(142, 36)
        Me.but_CreateCard.TabIndex = 9
        Me.but_CreateCard.Text = "CREATE CARD"
        Me.but_CreateCard.UseVisualStyleBackColor = False
        '
        'but_Witdraw
        '
        Me.but_Witdraw.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_Witdraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Witdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_Witdraw.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Witdraw.ForeColor = System.Drawing.Color.Silver
        Me.but_Witdraw.Location = New System.Drawing.Point(714, 121)
        Me.but_Witdraw.Name = "but_Witdraw"
        Me.but_Witdraw.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_Witdraw.Size = New System.Drawing.Size(142, 36)
        Me.but_Witdraw.TabIndex = 11
        Me.but_Witdraw.Text = "WITHDRAW"
        Me.but_Witdraw.UseVisualStyleBackColor = False
        '
        'but_Print_Wit
        '
        Me.but_Print_Wit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_Print_Wit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Print_Wit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_Print_Wit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Print_Wit.ForeColor = System.Drawing.Color.Silver
        Me.but_Print_Wit.Location = New System.Drawing.Point(554, 121)
        Me.but_Print_Wit.Name = "but_Print_Wit"
        Me.but_Print_Wit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_Print_Wit.Size = New System.Drawing.Size(142, 36)
        Me.but_Print_Wit.TabIndex = 10
        Me.but_Print_Wit.Text = "PRINT"
        Me.but_Print_Wit.UseVisualStyleBackColor = False
        '
        'but_Deposit
        '
        Me.but_Deposit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_Deposit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Deposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_Deposit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Deposit.ForeColor = System.Drawing.Color.Silver
        Me.but_Deposit.Location = New System.Drawing.Point(714, 121)
        Me.but_Deposit.Name = "but_Deposit"
        Me.but_Deposit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_Deposit.Size = New System.Drawing.Size(142, 36)
        Me.but_Deposit.TabIndex = 12
        Me.but_Deposit.Text = "DEPOSIT"
        Me.but_Deposit.UseVisualStyleBackColor = False
        '
        'but_Close_Delete
        '
        Me.but_Close_Delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_Close_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Close_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_Close_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Close_Delete.ForeColor = System.Drawing.Color.Silver
        Me.but_Close_Delete.Location = New System.Drawing.Point(714, 121)
        Me.but_Close_Delete.Name = "but_Close_Delete"
        Me.but_Close_Delete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_Close_Delete.Size = New System.Drawing.Size(142, 36)
        Me.but_Close_Delete.TabIndex = 13
        Me.but_Close_Delete.Text = "CLOSE"
        Me.but_Close_Delete.UseVisualStyleBackColor = False
        '
        'but_Print_Dep
        '
        Me.but_Print_Dep.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.but_Print_Dep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.but_Print_Dep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.but_Print_Dep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.but_Print_Dep.ForeColor = System.Drawing.Color.Silver
        Me.but_Print_Dep.Location = New System.Drawing.Point(554, 121)
        Me.but_Print_Dep.Name = "but_Print_Dep"
        Me.but_Print_Dep.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.but_Print_Dep.Size = New System.Drawing.Size(142, 36)
        Me.but_Print_Dep.TabIndex = 14
        Me.but_Print_Dep.Text = "PRINT"
        Me.but_Print_Dep.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(877, 530)
        Me.Controls.Add(Me.but_Print_Dep)
        Me.Controls.Add(Me.but_Close_Delete)
        Me.Controls.Add(Me.but_Deposit)
        Me.Controls.Add(Me.but_Witdraw)
        Me.Controls.Add(Me.but_Print_Wit)
        Me.Controls.Add(Me.but_CreateCard)
        Me.Controls.Add(Me.but_EditCard)
        Me.Controls.Add(Me.but_EditCus)
        Me.Controls.Add(Me.but_CreateCus)
        Me.Controls.Add(Me.butSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = " "
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents but_Cus As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents but_Dep As Button
    Friend WithEvents but_Wit As Button
    Friend WithEvents but_Card As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents linkLoginout As LinkLabel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents butSearch As Button
    Friend WithEvents but_CreateCus As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents but_Close As Button
    Friend WithEvents but_EditCus As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents but_EditCard As Button
    Friend WithEvents but_CreateCard As Button
    Friend WithEvents but_Witdraw As Button
    Friend WithEvents but_Print_Wit As Button
    Friend WithEvents but_Deposit As Button
    Friend WithEvents but_Close_Delete As Button
    Friend WithEvents but_Print_Dep As Button
End Class
