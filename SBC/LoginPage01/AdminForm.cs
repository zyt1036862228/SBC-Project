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
    public partial class AdminForm : Form
    {
        
        public AdminForm()
        {
            InitializeComponent();
            welcomeMsg.Text = "Hello " + Program.admin.getName() + ", welcome to SBC Booking System";

            //check if user is a master admin
            checkMasterAdmin();

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void manageCustomerBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*ViewBus bookingForm1 = new ViewBus();
            this.Hide();
            bookingForm1.ShowDialog();*/
            /*
            Do nothing because it will redirect to current page again
            
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
            this.Hide();*/
        }

        private void createBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            createBookings1 bookingForm1 = new createBookings1();
            bookingForm1.ShowDialog();

        }

        private void viewEditBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBookings viewForm1 = new ViewBookings();
            viewForm1.ShowDialog();
        }

        private void manageDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewEditDriverDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBus viewForm2 = new ViewBus();
            viewForm2.ShowDialog();
        }

        private void createBusDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBus createBusForm = new CreateBus();
            createBusForm.ShowDialog();
        }

        private void createBusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateExternalProvider externalProvider = new CreateExternalProvider();
            this.Hide();
            externalProvider.ShowDialog();
        }

        private void viewEditBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewOwner searchOwner = new ViewOwner();
            searchOwner.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateDriver bookingForm1 = new CreateDriver();
            bookingForm1.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewDriver viewDriverForm = new ViewDriver();
            viewDriverForm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void welcomeMsg_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountManagement accMng = new AccountManagement();
            this.Hide();
            accMng.Show();
        }

        private void checkMasterAdmin()
        {
            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MyConn.Open();
            MySqlDataReader MyReader;

            //get owner IC from database given the owner name from form
            string findMaster = "SELECT Master FROM admin WHERE EmpID = '" + Program.admin.getEmpID() + "';";
            MySqlCommand selectComm = new MySqlCommand(findMaster, MyConn);
            MyReader = selectComm.ExecuteReader();

            MyReader.Read();

            bool isMaster = MyReader.GetBoolean("Master");
            MyConn.Close();

            if (!isMaster)
            {

                //hide buttons if admin is not master
                //account management
                accMngButton.Visible = false;
                accMngLabel.Visible = false;

                //logs
                logButton.Visible = false;
                logLabel.Visible = false;

            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewLogs log = new ViewLogs();
            log.ShowDialog();
        }

        private void createMaintenanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateMileage maintenance = new CreateMileage();
            maintenance.Show();
        }

        private void maintenanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MaintenanceRecord maint = new MaintenanceRecord();
            maint.ShowDialog();
        }
    }
}
