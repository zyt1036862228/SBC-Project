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
using Microsoft.VisualBasic;

namespace LoginPage01
{
    public partial class EditBooking : Form
    {

        public EditBooking(String bookingID)
        {
            InitializeComponent();
            initField(bookingID);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);

            //update database with field values
            String updatesql = "UPDATE booking SET BookingDate='" + dateInput.Value.ToString("dd/MM/yyyy") + "', " +
                "DepartLocation='" + departureInput.Text + "', " +
                "ArrivalLocation='" + arrivalInput.Text + "', " +
                "status='" + statusCombo.Text + "', " +
                "passengerNumber='" + passengerNoInput.Text + "', " +
                "remarks='" + remarksInput.Text + "', " +
                "modified=1 " +
                "WHERE bookingID = '" + bookingIDInput.Text + "';";

            MySqlCommand MyComd = new MySqlCommand(updatesql, MyConn);

            MyConn.Open();
            MyComd.ExecuteNonQuery();


            //write logs 
            MyComd.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', '" +
                bookingIDInput.Text + " booking info updated');";
            MyComd.ExecuteNonQuery();
            MyConn.Close();

            MessageBox.Show("Booking info changed!");

            /*checkStatusCancelled();*/

            //if status is cancelled
            if (statusCombo.Text.Equals("Cancelled"))
            {
                string refundAmt = calculateRefund(bookingIDInput.Text);

                bool triggerRefund = true;
                if (int.Parse(refundAmt.ToString()) == 0)
                {
                    triggerRefund = false;
                    MessageBox.Show("Refund not entitled!");
                }

                //if refund amount is not 0
                if (triggerRefund)
                {
                    string accNo = Interaction.InputBox("Enter Bank Account Number", "Refund");

                    //display refund information
                    MessageBox.Show("Booking ID: " + bookingIDInput.Text +
                    "\nBooking Date: " + dateInput.Value.ToString("dd/MM/yyyy") +
                    "\nRefund Amount: " + refundAmt +
                    "\nBank Account: " +accNo +
                    "\n\nRefund process will take 14 working days.");
                }
            }
            this.Close();

        }


        public string calculateRefund(string bookingID)
        {
            int refundAmount = 0;
            try
            {
                //Connection to database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sbc; sslMode=none";
                string Query = "SELECT * FROM booking WHERE BookingID ='" + bookingID + "';";

                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyComd.ExecuteReader();

                if (MyReader.Read())
                {
                    string bookingDate = MyReader.GetString("BookingDate");

                    string[] tempDate = bookingDate.Split('/');
                    int expMonth = int.Parse(tempDate[1]);  //getting the to Month
                    int expDay = int.Parse(tempDate[0]); //getting the to Day
                    int expYear = int.Parse(tempDate[2]); //getting the to year

                    DateTime bookedDate = new DateTime(expYear, expMonth, expDay);

                    DateTime currDate = DateTime.Now;
                    
                    if (bookedDate.AddDays(-3) > currDate)
                    {
                        //Full refund
                        refundAmount = 200;
                    }
                    else if (bookedDate.AddDays(-2) > currDate)
                    {
                        //half refund
                        refundAmount = 200 / 2;
                    }
                    else
                    {
                        //no refund allowed
                        refundAmount = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return refundAmount.ToString();
        }

/*        public void checkStatusCancelled()
        {

        }*/



        private void initField(String bookingID)
        {
            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";



            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                String Query = "SELECT * FROM booking where BookingID ='" + bookingID + "';";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyReader = cmd.ExecuteReader();

                if (MyReader.Read())
                {
                    //populate data
                    bookingIDInput.Text = MyReader.GetString("BookingID");
                    customerNameInput.Text = MyReader.GetString("customerPhoneNo");

                    //initialize timedate
                    string currentDate = MyReader.GetString("BookingDate");
                    string[] tempCurrDate = currentDate.Split('/');
                    int currMonth = int.Parse(tempCurrDate[1]);  //getting the from Month
                    int currDay = int.Parse(tempCurrDate[0]); //getting the from Day
                    int currYear = int.Parse(tempCurrDate[2]); //getting the from year
                    DateTime dateNow = new DateTime(currYear, currMonth, currDay);
                    dateInput.Value = dateNow;

                    departureInput.Text = MyReader.GetString("DepartLocation");
                    arrivalInput.Text = MyReader.GetString("ArrivalLocation");

                    //status combo box
                    this.statusCombo.Items.AddRange(new object[] {
                    "Booked",
                    "Booked but not paid",
                    "Cancelled"
                    });

                    passengerNoInput.Text = MyReader.GetString("passengerNumber");
                    remarksInput.Text = MyReader.GetString("remarks");
                    statusCombo.Text = MyReader.GetString("status");

                    MyReader.Close();



                    

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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
