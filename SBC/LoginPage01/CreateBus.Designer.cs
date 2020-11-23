namespace LoginPage01
{
    partial class CreateBus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateBus));
            this.busNumberPlateInput = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.passengerPermitLabel = new System.Windows.Forms.Label();
            this.busPassengerPermitInput = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.datepickerTo = new System.Windows.Forms.DateTimePicker();
            this.datepickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.busCategory = new System.Windows.Forms.ComboBox();
            this.busSpecificationInput = new System.Windows.Forms.RichTextBox();
            this.specLabel = new System.Windows.Forms.Label();
            this.busOwnerName = new System.Windows.Forms.Label();
            this.busOwnerNameInput = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.createMaintenanceRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SBC = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusInput = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // busNumberPlateInput
            // 
            this.busNumberPlateInput.Location = new System.Drawing.Point(119, 140);
            this.busNumberPlateInput.Name = "busNumberPlateInput";
            this.busNumberPlateInput.Size = new System.Drawing.Size(100, 20);
            this.busNumberPlateInput.TabIndex = 69;
            this.busNumberPlateInput.TextChanged += new System.EventHandler(this.dateInputBox_TextChanged);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.numberLabel.Location = new System.Drawing.Point(5, 140);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(71, 13);
            this.numberLabel.TabIndex = 68;
            this.numberLabel.Text = "Number Plate";
            this.numberLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 67;
            this.label1.Text = "Create Bus ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.categoryLabel.Location = new System.Drawing.Point(6, 173);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 80;
            this.categoryLabel.Text = "Category";
            this.categoryLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // passengerPermitLabel
            // 
            this.passengerPermitLabel.AutoSize = true;
            this.passengerPermitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.passengerPermitLabel.Location = new System.Drawing.Point(3, 203);
            this.passengerPermitLabel.Name = "passengerPermitLabel";
            this.passengerPermitLabel.Size = new System.Drawing.Size(89, 13);
            this.passengerPermitLabel.TabIndex = 78;
            this.passengerPermitLabel.Text = "Passenger Permit";
            this.passengerPermitLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // busPassengerPermitInput
            // 
            this.busPassengerPermitInput.Location = new System.Drawing.Point(119, 200);
            this.busPassengerPermitInput.Name = "busPassengerPermitInput";
            this.busPassengerPermitInput.Size = new System.Drawing.Size(100, 20);
            this.busPassengerPermitInput.TabIndex = 74;
            this.busPassengerPermitInput.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(300, 331);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(92, 19);
            this.submitButton.TabIndex = 83;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // datepickerTo
            // 
            this.datepickerTo.CustomFormat = "";
            this.datepickerTo.Location = new System.Drawing.Point(410, 229);
            this.datepickerTo.Name = "datepickerTo";
            this.datepickerTo.Size = new System.Drawing.Size(200, 20);
            this.datepickerTo.TabIndex = 102;
            // 
            // datepickerFrom
            // 
            this.datepickerFrom.CustomFormat = "";
            this.datepickerFrom.Location = new System.Drawing.Point(410, 200);
            this.datepickerFrom.Name = "datepickerFrom";
            this.datepickerFrom.Size = new System.Drawing.Size(200, 20);
            this.datepickerFrom.TabIndex = 100;
            this.datepickerFrom.ValueChanged += new System.EventHandler(this.datepickerFrom_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.Location = new System.Drawing.Point(320, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 103;
            this.label15.Text = "Permit Validity";
            // 
            // busCategory
            // 
            this.busCategory.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.busCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busCategory.FormattingEnabled = true;
            this.busCategory.Location = new System.Drawing.Point(119, 170);
            this.busCategory.Name = "busCategory";
            this.busCategory.Size = new System.Drawing.Size(100, 21);
            this.busCategory.TabIndex = 106;
            this.busCategory.SelectedIndexChanged += new System.EventHandler(this.buseCategory_SelectedIndexChanged);
            // 
            // busSpecificationInput
            // 
            this.busSpecificationInput.Location = new System.Drawing.Point(119, 259);
            this.busSpecificationInput.Name = "busSpecificationInput";
            this.busSpecificationInput.Size = new System.Drawing.Size(491, 58);
            this.busSpecificationInput.TabIndex = 108;
            this.busSpecificationInput.Text = "";
            // 
            // specLabel
            // 
            this.specLabel.AutoSize = true;
            this.specLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.specLabel.Location = new System.Drawing.Point(8, 259);
            this.specLabel.Name = "specLabel";
            this.specLabel.Size = new System.Drawing.Size(68, 13);
            this.specLabel.TabIndex = 107;
            this.specLabel.Text = "Specification";
            // 
            // busOwnerName
            // 
            this.busOwnerName.AutoSize = true;
            this.busOwnerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.busOwnerName.Location = new System.Drawing.Point(5, 231);
            this.busOwnerName.Name = "busOwnerName";
            this.busOwnerName.Size = new System.Drawing.Size(69, 13);
            this.busOwnerName.TabIndex = 109;
            this.busOwnerName.Text = "Owner Name";
            // 
            // busOwnerNameInput
            // 
            this.busOwnerNameInput.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.busOwnerNameInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.busOwnerNameInput.FormattingEnabled = true;
            this.busOwnerNameInput.Location = new System.Drawing.Point(119, 226);
            this.busOwnerNameInput.Name = "busOwnerNameInput";
            this.busOwnerNameInput.Size = new System.Drawing.Size(100, 21);
            this.busOwnerNameInput.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(362, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(372, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "To";
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
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 115;
            this.menuStrip1.Text = "menuStrip1";
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
            this.createBookingsToolStripMenuItem.Click += new System.EventHandler(this.createBookingsToolStripMenuItem_Click_1);
            // 
            // viewEditBookingsToolStripMenuItem
            // 
            this.viewEditBookingsToolStripMenuItem.Name = "viewEditBookingsToolStripMenuItem";
            this.viewEditBookingsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.viewEditBookingsToolStripMenuItem.Text = "View/Edit Booking";
            this.viewEditBookingsToolStripMenuItem.Click += new System.EventHandler(this.viewEditBookingsToolStripMenuItem_Click_1);
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
            this.createBusToolStripMenuItem1.Click += new System.EventHandler(this.createBusToolStripMenuItem1_Click_1);
            // 
            // viewEditBusToolStripMenuItem
            // 
            this.viewEditBusToolStripMenuItem.Name = "viewEditBusToolStripMenuItem";
            this.viewEditBusToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.viewEditBusToolStripMenuItem.Text = "View External Bus Owner";
            this.viewEditBusToolStripMenuItem.Click += new System.EventHandler(this.viewEditBusToolStripMenuItem_Click_1);
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
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click_1);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem3.Text = "View/Edit Driver";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click_1);
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
            this.createBusDriverToolStripMenuItem.Click += new System.EventHandler(this.createBusDriverToolStripMenuItem_Click_1);
            // 
            // viewEditDriverDetailsToolStripMenuItem
            // 
            this.viewEditDriverDetailsToolStripMenuItem.Name = "viewEditDriverDetailsToolStripMenuItem";
            this.viewEditDriverDetailsToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.viewEditDriverDetailsToolStripMenuItem.Text = "View/Edit Bus";
            this.viewEditDriverDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewEditDriverDetailsToolStripMenuItem_Click_1);
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(648, 62);
            this.tableLayoutPanel2.TabIndex = 116;
            // 
            // SBC
            // 
            this.SBC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SBC.AutoSize = true;
            this.SBC.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SBC.Location = new System.Drawing.Point(60, 18);
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
            this.pictureBox1.Size = new System.Drawing.Size(52, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(355, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Status";
            // 
            // statusInput
            // 
            this.statusInput.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.statusInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusInput.FormattingEnabled = true;
            this.statusInput.Location = new System.Drawing.Point(410, 137);
            this.statusInput.Name = "statusInput";
            this.statusInput.Size = new System.Drawing.Size(200, 21);
            this.statusInput.TabIndex = 119;
            // 
            // CreateBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 372);
            this.Controls.Add(this.statusInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.busOwnerNameInput);
            this.Controls.Add(this.busOwnerName);
            this.Controls.Add(this.busSpecificationInput);
            this.Controls.Add(this.specLabel);
            this.Controls.Add(this.busCategory);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.datepickerTo);
            this.Controls.Add(this.datepickerFrom);
            this.Controls.Add(this.busNumberPlateInput);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.passengerPermitLabel);
            this.Controls.Add(this.busPassengerPermitInput);
            this.Controls.Add(this.submitButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CreateBus";
            this.Text = "Create Bus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateBus_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox busNumberPlateInput;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label passengerPermitLabel;
        private System.Windows.Forms.TextBox busPassengerPermitInput;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.DateTimePicker datepickerTo;
        private System.Windows.Forms.DateTimePicker datepickerFrom;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox busCategory;
        private System.Windows.Forms.RichTextBox busSpecificationInput;
        private System.Windows.Forms.Label specLabel;
        private System.Windows.Forms.Label busOwnerName;
        private System.Windows.Forms.ComboBox busOwnerNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Label SBC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem createMaintenanceRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceRecordToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox statusInput;
    }
}