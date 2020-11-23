using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginPage01
{
    public partial class CreateMileage : Form
    {
        public CreateMileage()
        {
            InitializeComponent();
            initNumberPlate();
        }

        private void mileage_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            string numberPlate = numberPlateInput.Text;

            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                string Query = "SELECT * FROM bus WHERE NumberPlate='" + numberPlate + "';";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyReader = cmd.ExecuteReader();
                MyReader.Read();

                categoryInput.Text = MyReader.GetString("Category");
                passengerPermitInput.Text = MyReader.GetString("PassengerPermit");



            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }

        public void initNumberPlate()
        {
            string numberPlate;

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

        

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm admin = new AdminForm();
            admin.Show();
        }

        private void createBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            createBookings1 book = new createBookings1();
            book.ShowDialog();
        }

        private void viewEditBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBookings viewBook = new ViewBookings();
            viewBook.ShowDialog();
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
            ViewDriver showDriver = new ViewDriver();
            showDriver.ShowDialog();
        }

        private void createBusDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateBus bus = new CreateBus();
            bus.ShowDialog();
        }

        private void viewEditDriverDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBus bus = new ViewBus();
            bus.ShowDialog();
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

        private void CreateMileage_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numberPlateInput.Text.Trim().Equals("") ||
                categoryInput.Text.Trim().Equals("") ||
                passengerPermitInput.Text.Trim().Equals("") ||
                mileageInput.Text.Trim().Equals("") ||
                remarksInput.Text.Trim().Equals(""))
            {
                MessageBox.Show("Input should not be empty!");
                return;
            }

            changeMileage(int.Parse(mileageInput.Text));


            this.Hide();
            AdminForm admin = new AdminForm();
            admin.ShowDialog();
        }

        public void changeMileage(int addedMileage)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand MyComd;
            MyConn.Open();

            int mileage = addedMileage;
            string remarks = remarksInput.Text;
            string busNumberPlate = numberPlateInput.Text;
            int currentMileage = 0;
            int nextMileage;

            //retrieve latest record on mileage for selected bus
            //if no record found, current mileage starts from 0
            try
            {
                //get the latest record mileage
                string selectSql = "SELECT currentMileage, nextMileage FROM mileage WHERE busNumberPlate='" +
                    busNumberPlate + "' ORDER BY ID DESC;";

                MyComd = new MySqlCommand(selectSql, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();
                if (MyReader.Read())
                {
                    currentMileage = MyReader.GetInt32("currentMileage");
                    nextMileage = MyReader.GetInt32("nextMileage");
                }
                else
                {
                    //if no records are found, mileage starts from 0
                    currentMileage = 0;
                    nextMileage = 7000;
                }
                MyReader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }

            int newMileage = currentMileage + mileage;

            //insert maintenance record into database
            try
            {

                //update database with field values
                String updatesql = "INSERT INTO mileage (currentMileage, nextMileage, remarks, busNumberPlate)" +
                    "VALUES('" + newMileage + "', '" + nextMileage + "', '" + remarks + "', '" + busNumberPlate + "');";

                MyComd = new MySqlCommand(updatesql, MyConn);
                MyComd.ExecuteNonQuery();

                MessageBox.Show("Bus mileage record updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //close connection
            MyConn.Close();

            compareMileageLimit(newMileage, nextMileage);
            
        }

        public bool compareMileageLimit(int currentMileage, int servieMileage)
        {
            bool alert = false;
            //warn the user for maintenance if mileage exceeds the allowed number
            if (currentMileage > servieMileage)
            {
                MessageBox.Show("The vehicle needs to be serviced!");
                alert = true;
            }
            return alert;
        }
    }
}
