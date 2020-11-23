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
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            string username = usernameInput.Text;

            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                string Query = "SELECT EmpID, Name, Master FROM admin WHERE EmpID LIKE '%" + username + "%';";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                tableResult.DataSource = dTable;
                MyConn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String[] temp = new string[3];
            for (int i = 0; i < 3; i++)
            {
                var value = tableResult.SelectedRows[0].Cells[i].Value;

                temp[i] = value.ToString();

            }
            Admin admin = new Admin(temp[0], temp[1], bool.Parse(temp[2]));
            EditAccount editAccount = new EditAccount(admin);

            editAccount.ShowDialog();
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

        private void AccountManagement_FormClosed(object sender, FormClosedEventArgs e)
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
