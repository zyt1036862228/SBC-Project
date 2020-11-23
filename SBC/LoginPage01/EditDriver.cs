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
    public partial class EditDriver : Form
    {
        public EditDriver(string driverIC)
        {
            InitializeComponent();
            init(driverIC);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);

            //update database with field values
            String updatesql = "UPDATE driver SET Name='" + nameInput.Text + "', " +
                "License='" + licenseInput.Text + "', " +
                "PhoneNo='" + phoneInput.Text + "' " +
                "WHERE IC='" + ICInput.Text + "';";

            MySqlCommand MyComd = new MySqlCommand(updatesql, MyConn);

            MyConn.Open();
            MyComd.ExecuteNonQuery();


            //write logs 
            MyComd.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Driver IC " +
                ICInput.Text + " info updated');";
            MyComd.ExecuteNonQuery();
            MyConn.Close();

            MessageBox.Show("Driver info changed!");

            this.Close();
        }

        private void init(string driverIC)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";



            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                String Query = "SELECT * FROM driver where IC ='" + driverIC + "';";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyReader = cmd.ExecuteReader();

                if (MyReader.Read())
                {
                    //populate data
                    ICInput.Text = MyReader.GetString("IC");
                    nameInput.Text = MyReader.GetString("Name");
                    licenseInput.Text = MyReader.GetString("License");
                    phoneInput.Text = MyReader.GetString("PhoneNo");
                    ownerICInput.Text = MyReader.GetString("RegisteredOwnerIC");

                    MyReader.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm admin = new AdminForm();
            admin.ShowDialog();
        }

        private void createBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            createBookings1 booking1 = new createBookings1();
            booking1.ShowDialog();
        }

        private void viewEditBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBookings viewBook = new ViewBookings();
            viewBook.Hide();
        }

        private void createBusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateExternalProvider extProvider = new CreateExternalProvider();
            extProvider.ShowDialog();
        }

        private void viewEditBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOwner viewOwner = new ViewOwner();
            viewOwner.ShowDialog();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateDriver driver = new CreateDriver();
            driver.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewDriver viewDriver = new ViewDriver();
            viewDriver.ShowDialog();

        }

        private void createBusDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBus createBus = new CreateBus();
            createBus.ShowDialog();
        }

        private void viewEditDriverDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBus viewBus = new ViewBus();
            viewBus.ShowDialog();
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
