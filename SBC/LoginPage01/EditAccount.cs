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
using System.Security.Cryptography;

namespace LoginPage01
{
    public partial class EditAccount : Form
    {
        Admin admin;
        public EditAccount(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            initField(admin);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //hash plaintext password into md5
            string computedHash;
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(passwordInput.Text);
                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                // Convert hash byte array to string
                computedHash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); ;
            }
            changePassword(computedHash, nameInput.Text);
            
            this.Close();
        }

        public bool changePassword(string pwdHash, string name)
        {
            bool success = false;
            try
            {
                //connect db
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);

                //update database with field values
                String updatesql = "UPDATE admin SET Hash ='" + pwdHash.ToLower() + "', " +
                    "Name ='" + name + "' " +
                    "WHERE EmpID='" + admin.getEmpID() + "';";

                MySqlCommand MyComd = new MySqlCommand(updatesql, MyConn);

                MyConn.Open();
                MyComd.ExecuteNonQuery();
                success = true;

                //close connection
                MyConn.Close();
                MessageBox.Show("Account information is changed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return success;
        }

        private void initField(Admin admin)
        {
            //populate data into input box
            empIDInput.Text = admin.getEmpID();
            nameInput.Text = admin.getName();

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
