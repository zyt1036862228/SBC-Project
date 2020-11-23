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
    public partial class MaintenanceRecord : Form
    {
        public MaintenanceRecord()
        {
            InitializeComponent();
            initNumberPlate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numberPlateInput.Text.Trim().Equals("") ||
                statusInput.Text.Equals("") ||
                remarksInput.Text.Trim().Equals(""))
            {
                MessageBox.Show("Input should not be empty!");
                return;
            }

            string numberPlate = numberPlateInput.Text;
            string status = statusInput.Text;
            string maintenanceStartDate = maintenanceStart.Value.ToString("dd/MM/yyyy");
            string maintenanceEndDate = maintenanceEnd.Value.ToString("dd/MM/yyyy");
            string remarks = remarksInput.Text;

            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();

                string insertQuery = "INSERT INTO maintenance (BusNumberPlate, status, maintenanceStartDate, maintenanceEndDate, remarks)" +
                    "VALUES('" + numberPlate + "', '" + status + "', '" + maintenanceStartDate + "', '" + maintenanceEndDate + "', '" + remarks + "');";

                MySqlCommand cmd = new MySqlCommand(insertQuery, MyConn);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE bus SET status='" + status + "' WHERE NumberPlate='" + numberPlate + "';";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Maintenance recorded added");
                
                MyConn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            this.Hide();
            AdminForm admin = new AdminForm();
            admin.ShowDialog();
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

        private void MaintenanceRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void initNumberPlate()
        {
            string numberPlate;

            this.statusInput.Items.AddRange(new object[] {
            "In workshop",
            "Available"
            });


            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MySqlDataReader MyReader;

                //getting only SBC owned buses
                string Query = "SELECT NumberPlate FROM BUS JOIN busowner ON bus.OwnerIC = busowner.IC WHERE busowner.Name='SBC';";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

                MyConn.Open();
                MyReader = cmd.ExecuteReader();

                //if data exists, get numberPlate
                while (MyReader.Read())
                {
                    numberPlate = MyReader.GetString("NumberPlate");
                    this.numberPlateInput.Items.Add(numberPlate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void createBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            createBookings1 newBooking = new createBookings1();
            newBooking.ShowDialog();
        }

        private void viewEditBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBookings booking = new ViewBookings();
            booking.ShowDialog();
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
            ViewOwner owner = new ViewOwner();
            owner.ShowDialog();
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm form = new AdminForm();
            form.ShowDialog();
        }
    }
}
