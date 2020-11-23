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
    public partial class CreateDriver : Form
    {
        public CreateDriver()
        {
            InitializeComponent();

            //database connection
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //get driver names from database and populate to combo box
            string Query = "SELECT Name FROM busowner;";

            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = MyComd.ExecuteReader();

            //for each return result of busowner name,  add into combo box

            while (MyReader.Read())
            {
                this.driverOwnerCombo.Items.AddRange(new object[] {
            MyReader.GetString("Name")
            });
            }

            MyConn.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(driverNameInput.Text.Trim().Equals("") || driverIcInput.Text.Trim().Equals("") || driverPhoneInput.Text.Trim().Equals("")
                || driverLicenseInput.Text.Trim().Equals("") || driverOwnerCombo.Text.Trim().Equals(""))
            {
                MessageBox.Show("Input is empty!");
                return;
            }

            string name = driverNameInput.Text;
            string ic = driverIcInput.Text;
            string phone = driverPhoneInput.Text;
            string license = driverLicenseInput.Text;
            string ownerName = driverOwnerCombo.Text;

            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MyConn.Open();
            MySqlDataReader MyReader;
            
            //get owner IC from database given the owner name from form
            string selectOwnerIc = "SELECT IC FROM busowner WHERE Name = '" + ownerName + "';";
            MySqlCommand selectComm = new MySqlCommand(selectOwnerIc, MyConn);
            MyReader = selectComm.ExecuteReader();

            string ownerIc;
            //get IC from database
            MyReader.Read();
            ownerIc = MyReader.GetString("IC");
            MyReader.Close();



            //sql to create bus, owner and driver record
            string insertSql = "INSERT INTO driver (Name, IC, License, PhoneNo, RegisteredOwnerIC) " +
            "VALUES ('" + name + "', '" + ic + "', '" + license + "', '" + phone + "', '" + ownerIc + "' );";

            //write logs 
            MySqlCommand insertComm = new MySqlCommand(insertSql, MyConn);
            insertComm.ExecuteNonQuery();
            insertComm.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Created a driver record');";
            insertComm.ExecuteNonQuery();
            MyReader.Close();

            MessageBox.Show("Driver has been added!");
            MyConn.Close();
        }




        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void viewEditBusToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void createBusDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBus createBusForm = new CreateBus();
            createBusForm.ShowDialog();
        }

        private void viewEditDriverDetailsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void CreateDriver_FormClosed(object sender, FormClosedEventArgs e)
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
