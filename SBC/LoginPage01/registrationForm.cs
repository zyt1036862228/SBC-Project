using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginPage01
{
    public partial class registrationForm : Form
    {
        public registrationForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //get customer registration info and write to database
            string custName = nameInputBox.Text;
            string telephoneNo = telInputBox.Text;
            string ic = ICInputBox.Text;
            string email = emailInputBox.Text;

            if (custName.Equals("") || telephoneNo.Equals("") || ic.Equals("") || email.Equals(""))
            {
                MessageBox.Show("Input must not be empty!");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(ICInputBox.Text, @"^\d{12}$").Success)
            {
                MessageBox.Show("Please input  IC correctly.");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(telInputBox.Text, @"^\d{10}$").Success)
            {
                MessageBox.Show("Please input Phone Number correctly.");
            }
            else
            {




                //connection to database
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

                //insert customer data into database
                string Query = "INSERT INTO customer (PhoneNo, Name, ic, email) " +
                    "VALUES ('" + telephoneNo + "', '" + custName + "', '" + ic + "', '" + email + "');";
                /*string insertLog = "INSERT INTO Log ('EmpID', 'Message') VALUES ('" + Program.admin.getEmpID() + "', 'Added a new customer record');"; */

                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);

                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = cmd.ExecuteReader();


                Customer customer = new Customer(telephoneNo, custName, email, ic);


                //Write to log tables here
                ///*********************//
                MyReader.Close();
                cmd.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Added a new customer record');";
                cmd.ExecuteNonQuery();
                MyConn.Close();

                MessageBox.Show("Customer Created!");


                //send customer telephone to bookings2 to identify customer
                createBookings2 bookings2 = new createBookings2(customer);
                bookings2.Show();
                this.Hide();
            }

        }






        private void homeToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        private void createBookingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            createBookings1 bookingForm1 = new createBookings1();
            bookingForm1.ShowDialog();
        }

        private void viewEditBookingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ViewOwner searchOwner = new ViewOwner();
            searchOwner.ShowDialog();
        }

        private void createBusToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CreateExternalProvider externalProvider = new CreateExternalProvider();
            externalProvider.ShowDialog();
        }

        private void viewEditBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOwner searchOwner = new ViewOwner();
            searchOwner.ShowDialog();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CreateDriver bookingForm1 = new CreateDriver();
            bookingForm1.ShowDialog();
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ViewDriver viewDriverForm = new ViewDriver();
            viewDriverForm.ShowDialog();
        }

        private void createBusDriverToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CreateBus createBusForm = new CreateBus();
            createBusForm.ShowDialog();
        }

        private void viewEditDriverDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ViewBus viewForm2 = new ViewBus();
            viewForm2.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        private void registrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void createMaintenanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateMileage mileage = new CreateMileage();
            mileage.ShowDialog();
        }

        private void maintenanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceRecord maintenance = new MaintenanceRecord();
            maintenance.ShowDialog();
        }
    }
}
