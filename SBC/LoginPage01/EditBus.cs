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
    public partial class EditBus : Form
    {
        public EditBus(string numberPlate)
        {
            InitializeComponent();
            init(numberPlate);
        }

        private void labelLicense_Click(object sender, EventArgs e)
        {

        }

        private void licenseInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);

            //update database with field values
            String updatesql = "UPDATE bus SET Category='" + busCategory.Text + "', " +
                "Specification='" + busSpecificationInput.Text + "', " +
                "PassengerPermit='" + permit.Text + "', " +
                "PermitValidity='" + datepickerFrom.Value.ToString("dd/MM/yyyy") + "-" + datepickerTo.Value.ToString("dd/MM/yyyy") + "', " +
                "status='" + statusInput.Text + "' " +
                "WHERE NumberPlate='" + numPlate.Text + "';";

            MySqlCommand MyComd = new MySqlCommand(updatesql, MyConn);

            MyConn.Open();
            MyComd.ExecuteNonQuery();


            //write logs 
            MyComd.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Bus " +
                numPlate.Text + " info updated');";
            MyComd.ExecuteNonQuery();
            MyConn.Close();

            MessageBox.Show("Bus info changed!");

            this.Close();

            
        }

        private void init(string busNumberPlate)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";



            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                String Query = "SELECT * FROM bus where NumberPlate ='" + busNumberPlate + "';";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyReader = cmd.ExecuteReader();

                if (MyReader.Read())
                {
                    //populate data
                    numPlate.Text = MyReader.GetString("NumberPlate");
                    busCategory.Text = MyReader.GetString("Category");
                    permit.Text = MyReader.GetString("PassengerPermit");
                    busSpecificationInput.Text = MyReader.GetString("Specification");
                    statusInput.Text = MyReader.GetString("status");

                    //get permit date
                    string permitValidity = MyReader.GetString("PermitValidity");

                    //split to 2 dates
                    string[] toFromDate = permitValidity.Split('-');
                    string []tempFromDate = toFromDate[0].Split('/');
                    string []tempToDate = toFromDate[1].Split('/');

                    //change to date format
                    DateTime fromDate = new DateTime(int.Parse(tempFromDate[2]), int.Parse(tempFromDate[1]), int.Parse(tempFromDate[0]));
                    datepickerFrom.Value = fromDate;
                    DateTime toDate = new DateTime(int.Parse(tempToDate[2]), int.Parse(tempToDate[1]), int.Parse(tempToDate[0]));
                    datepickerTo.Value = toDate;
                    MyReader.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            this.busCategory.Items.AddRange(new object[] {
            "Factory Bus",
            "School Bus",
            "Express Bus",
            "Mini Bus",
            "Coach",
            "Passenger Van",
            "MPV"
            });

            this.statusInput.Items.AddRange(new object[] {
            "In workshop",
            "Available"
            });
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
