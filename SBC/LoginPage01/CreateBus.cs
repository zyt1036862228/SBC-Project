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
    public partial class CreateBus : Form
    {

        string numberPlate;
        string category;
        string passengerPermit;
        string permitValidity;
        string specification;
        string ownerName;
        string status;

        public CreateBus()
        {
            InitializeComponent();

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
                this.busOwnerNameInput.Items.AddRange(new object[] {
            MyReader.GetString("Name")
            });
            }

            MyConn.Close();

            


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (busNumberPlateInput.Text.Trim().Equals("") || busCategory.Text.Trim().Equals("") || busPassengerPermitInput.Text.Trim().Equals("")
                || busOwnerNameInput.Text.Trim().Equals("") || busSpecificationInput.Text.Trim().Equals(""))
            {
                MessageBox.Show("Input is empty!");
                return;
            }


            //getting input values
            numberPlate = busNumberPlateInput.Text;
            category = busCategory.Text;
            passengerPermit = busPassengerPermitInput.Text;
            
            specification = busSpecificationInput.Text;
            ownerName = busOwnerNameInput.Text;
            status = statusInput.Text;

            //Checking for permit data validity to ensure the permit date is valid
            Boolean checkValid = validateDate(datepickerFrom.Value.ToString("dd/MM/yyyy"), datepickerTo.Value.ToString("dd/MM/yyyy"));
            if (checkValid)
            {
                permitValidity = datepickerTo.Value.ToString("dd/MM/yyyy") + "-" + datepickerTo.Value.ToString("dd/MM/yyyy");

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
                createBus(numberPlate, category, specification, passengerPermit, permitValidity, ownerIc, status);
                MyConn.Close();
            }
            else
            {
                MessageBox.Show("Permit validity is incorrect!");
            }
        }

        public bool createBus(string numPlate, string category, string spec, string permit, string validDate, string ownerIc, string status)
        {
            try
            {


                //connection to database
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                //sql to create bus, owner and driver record and logs
                string insertSql = "INSERT INTO bus (NumberPlate, Category, Specification, PassengerPermit, PermitValidity, OwnerIC, status) " +
                    "VALUES ('" + numPlate + "', '" + category + "', '" + spec + "', '" + permit + "', '" + validDate + "', '" + ownerIc + "', '"
                    + status + "');"+
                "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Created a bus record');";
                MySqlCommand insertComm = new MySqlCommand(insertSql, MyConn);
                insertComm.ExecuteNonQuery();

                MessageBox.Show("Bus has been added!");
                MyConn.Close();
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        

        private void busPermitFromInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void datepickerFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void buseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

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

        private static Boolean validateDate(string from, string to)
        {
            //split the from date (returns array of size 3)
            string[] tempFrom = from.Split('/');
            int fromMonth = int.Parse(tempFrom[1]);  //getting the from Month
            int fromDay = int.Parse(tempFrom[0]); //getting the from Day
            int fromYear = int.Parse(tempFrom[2]); //gettubg the from year

            string[] tempTo = to.Split('/');
            int toMonth = int.Parse(tempTo[1]);  //getting the to Month
            int toDay = int.Parse(tempTo[0]); //getting the to Day
            int toYear = int.Parse(tempTo[2]); //getting the to year

            DateTime fromDate = new DateTime(fromYear, fromMonth, fromDay);
            DateTime toDate = new DateTime(toYear, toMonth, toDay);

            int compare = DateTime.Compare(fromDate, toDate);

            if (compare < 0)
                return true;
            else        //false occurs when both dates fall one same day or when the expiry date is before the 
                return false;

        }

        private void CreateBus_FormClosed(object sender, FormClosedEventArgs e)
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

