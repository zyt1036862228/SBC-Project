using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginPage01
{
    public partial class createBookings1 : Form
    {
        Admin admin;
        public createBookings1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string custNo="";

            //get customer value from input box
            try
            {
                custNo = phoneNoInputBox.Text;

                //validate if all character is an integer
                char[] validate = custNo.ToCharArray();
                
                foreach (char tempChar in validate)
                {
                    int.Parse(tempChar.ToString());
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid format, please enter a valid phone number");
                return;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //Select statement to find bus drivers available (phoneNo is unique in the table)
            string Query = "SELECT * FROM customer WHERE PhoneNo = '" + custNo + "'";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand cmd = new MySqlCommand(Query, MyConn);

            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = cmd.ExecuteReader();

            


            if (MyReader.Read())
            {
                //getting the customer name and phone number
                string customerNumber = MyReader.GetString("PhoneNo");
                string name = MyReader.GetString("Name");
                string email = MyReader.GetString("email");
                string ic = MyReader.GetString("IC");

                Customer customer = new Customer(customerNumber, name, email, ic);

                createBookings2 bookings2 = new createBookings2(customer);
                this.Hide();
                bookings2.ShowDialog();
            }else
            {
                //customer not found in database
                MessageBox.Show("Customer not found, please register");

                this.Hide();
                registrationForm register = new registrationForm();
                register.Show();


            }

            MyConn.Close();
        }

        private void phoneNoInputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm viewForm1 = new AdminForm();
            this.Hide();
            viewForm1.ShowDialog();
        }


        private void manageCustomerBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }












        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {


            
        }

        private void createBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createBookings1 bookingForm1 = new createBookings1();
            this.Hide();
            bookingForm1.ShowDialog();

        }

        private void viewEditBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBookings viewForm1 = new ViewBookings();
            this.Hide();
            viewForm1.ShowDialog();
        }

        private void manageDriverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void createBusToolStripMenuItem1_Click(object sender, EventArgs e)
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
            ViewBus viewForm2 = new ViewBus();
            this.Hide();
            viewForm2.ShowDialog();

        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
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
