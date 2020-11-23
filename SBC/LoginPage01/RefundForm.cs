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
    public partial class RefundForm : Form
    {
        public RefundForm(string bookingID)
        {
            InitializeComponent();
            calculateRefund(bookingID);
        }

        private void calculateRefund(string bookingID)
        {
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
                    int refundAmount;
                    if (bookedDate.AddDays(-3) > currDate)
                    {
                        //Full refund
                        refundAmount = 200;
                    }else if (bookedDate.AddDays(-2) > currDate)
                    {
                        //half refund
                        refundAmount = 200 / 2;
                    }
                    else
                    {
                        //no refund allowed
                        refundAmount = 0;
                    }

                    //populate input box
                    bookingIDInput.Text = bookingID;
                    dateInput.Text = bookingDate;
                    refundInput.Text = refundAmount.ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(refundInput.Text.ToString()) == 0)
            {
                MessageBox.Show("Refund not entitled!");
            }else if (int.Parse(refundInput.Text.ToString()) == 100)
            {
                MessageBox.Show("RM100 Refunded!");
            }
            else
            {
                MessageBox.Show("RM200 Refunded!");
            }
            this.Close();
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
