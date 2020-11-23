namespace LoginPage01
{
    partial class AccountManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagement));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SBC = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableResult = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerBookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.externalProviderToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.createBusToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBusDriverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditDriverDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.createMaintenanceRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91F));
            this.tableLayoutPanel2.Controls.Add(this.SBC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 62);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // SBC
            // 
            this.SBC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SBC.AutoSize = true;
            this.SBC.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SBC.Location = new System.Drawing.Point(74, 18);
            this.SBC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SBC.Name = "SBC";
            this.SBC.Size = new System.Drawing.Size(182, 26);
            this.SBC.TabIndex = 5;
            this.SBC.Text = "Shuttle Bus Central";
            this.SBC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableResult
            // 
            this.tableResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableResult.Location = new System.Drawing.Point(13, 180);
            this.tableResult.Margin = new System.Windows.Forms.Padding(4);
            this.tableResult.Name = "tableResult";
            this.tableResult.RowHeadersWidth = 51;
            this.tableResult.Size = new System.Drawing.Size(727, 238);
            this.tableResult.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 29);
            this.label1.TabIndex = 31;
            this.label1.Text = "Account Management";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Username";
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(75, 147);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(100, 20);
            this.usernameInput.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(384, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // manageCustomerBookingToolStripMenuItem
            // 
            this.manageCustomerBookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBookingsToolStripMenuItem,
            this.viewEditBookingsToolStripMenuItem});
            this.manageCustomerBookingToolStripMenuItem.Name = "manageCustomerBookingToolStripMenuItem";
            this.manageCustomerBookingToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.manageCustomerBookingToolStripMenuItem.Text = "Customer Booking";
            // 
            // createBookingsToolStripMenuItem
            // 
            this.createBookingsToolStripMenuItem.Name = "createBookingsToolStripMenuItem";
            this.createBookingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.createBookingsToolStripMenuItem.Text = "Create Booking";
            this.createBookingsToolStripMenuItem.Click += new System.EventHandler(this.createBookingsToolStripMenuItem_Click);
            // 
            // viewEditBookingsToolStripMenuItem
            // 
            this.viewEditBookingsToolStripMenuItem.Name = "viewEditBookingsToolStripMenuItem";
            this.viewEditBookingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewEditBookingsToolStripMenuItem.Text = "View/Edit Booking";
            this.viewEditBookingsToolStripMenuItem.Click += new System.EventHandler(this.viewEditBookingsToolStripMenuItem_Click);
            // 
            // externalProviderToolStrip
            // 
            this.externalProviderToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBusToolStripMenuItem1,
            this.viewEditBusToolStripMenuItem});
            this.externalProviderToolStrip.Name = "externalProviderToolStrip";
            this.externalProviderToolStrip.Size = new System.Drawing.Size(121, 20);
            this.externalProviderToolStrip.Text = "External Bus Owner";
            // 
            // createBusToolStripMenuItem1
            // 
            this.createBusToolStripMenuItem1.Name = "createBusToolStripMenuItem1";
            this.createBusToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.createBusToolStripMenuItem1.Text = "Register External Bus Owner";
            this.createBusToolStripMenuItem1.Click += new System.EventHandler(this.createBusToolStripMenuItem1_Click);
            // 
            // viewEditBusToolStripMenuItem
            // 
            this.viewEditBusToolStripMenuItem.Name = "viewEditBusToolStripMenuItem";
            this.viewEditBusToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.viewEditBusToolStripMenuItem.Text = "View External Bus Owner";
            this.viewEditBusToolStripMenuItem.Click += new System.EventHandler(this.viewEditBusToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.toolStripMenuItem1.Text = "Driver";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem2.Text = "Create Driver";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem3.Text = "View/Edit Driver";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // manageDriverToolStripMenuItem
            // 
            this.manageDriverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createBusDriverToolStripMenuItem,
            this.viewEditDriverDetailsToolStripMenuItem,
            this.createMaintenanceRecordToolStripMenuItem,
            this.maintenanceRecordToolStripMenuItem});
            this.manageDriverToolStripMenuItem.Name = "manageDriverToolStripMenuItem";
            this.manageDriverToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.manageDriverToolStripMenuItem.Text = "Bus";
            // 
            // createBusDriverToolStripMenuItem
            // 
            this.createBusDriverToolStripMenuItem.Name = "createBusDriverToolStripMenuItem";
            this.createBusDriverToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.createBusDriverToolStripMenuItem.Text = "Create Bus";
            this.createBusDriverToolStripMenuItem.Click += new System.EventHandler(this.createBusDriverToolStripMenuItem_Click);
            // 
            // viewEditDriverDetailsToolStripMenuItem
            // 
            this.viewEditDriverDetailsToolStripMenuItem.Name = "viewEditDriverDetailsToolStripMenuItem";
            this.viewEditDriverDetailsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.viewEditDriverDetailsToolStripMenuItem.Text = "View/Edit Bus";
            this.viewEditDriverDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewEditDriverDetailsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.manageCustomerBookingToolStripMenuItem,
            this.externalProviderToolStrip,
            this.toolStripMenuItem1,
            this.manageDriverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createMaintenanceRecordToolStripMenuItem
            // 
            this.createMaintenanceRecordToolStripMenuItem.Name = "createMaintenanceRecordToolStripMenuItem";
            this.createMaintenanceRecordToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.createMaintenanceRecordToolStripMenuItem.Text = "Mileage Record";
            this.createMaintenanceRecordToolStripMenuItem.Click += new System.EventHandler(this.createMaintenanceRecordToolStripMenuItem_Click);
            // 
            // maintenanceRecordToolStripMenuItem
            // 
            this.maintenanceRecordToolStripMenuItem.Name = "maintenanceRecordToolStripMenuItem";
            this.maintenanceRecordToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.maintenanceRecordToolStripMenuItem.Text = "Maintenance Record";
            this.maintenanceRecordToolStripMenuItem.Click += new System.EventHandler(this.maintenanceRecordToolStripMenuItem_Click);
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableResult);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AccountManagement";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountManagement_FormClosed);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableResult)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label SBC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView tableResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomerBookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem externalProviderToolStrip;
        private System.Windows.Forms.ToolStripMenuItem createBusToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewEditBusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem manageDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBusDriverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditDriverDetailsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createMaintenanceRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceRecordToolStripMenuItem;
    }
}