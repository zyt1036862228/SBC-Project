using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace LoginPage01
{
    public partial class CreateExternalProvider : Form
    {

        //Owner info
        string ownerIc;
        string ownerName;
        string ownerAddress;
        string ownerEmail;
        string ownerPhone;
        string username;
        string password;

        //Driver info
        string driverName;
        string driverIc;
        string driverLicense;
        string driverPhoneNo;

        //Bus info
        string busNumberPlate;
        string busCategory;
        string busSpecification;
        string busPassengerPermit;
        string busPermitValidity;
        string status;


        public CreateExternalProvider()
        {

            InitializeComponent();
            this.busCat.Items.AddRange(new object[] {
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void SBC_Click(object sender, EventArgs e)
        {

        }

        private void datepicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void busPermitFromInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void busPermitToInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void datepickerTo_ValueChanged(object sender, EventArgs e)
        {
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            //extract data from owner form
            ownerIc = ownerIcInput.Text;
            ownerName = ownerNameInput.Text;
            ownerAddress = ownerAddresInput.Text;
            ownerEmail = ownerEmailInput.Text;
            ownerPhone = ownerPhoneInput.Text;
            username = usernameInput.Text;

            password = pwInput.Text;
            //Perform hashing for password
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(password);
                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                // Convert hash byte array to string
                password = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower() ; ;
            }

            //extract data from driver form
            driverName = driverNameInput.Text;
            driverIc = driverIcInput.Text;
            driverLicense = driverLicenseInput.Text;
            driverPhoneNo = driverPhoneInput.Text;


            //extract data from bus form
            busNumberPlate = busNumberPlateInput.Text;
            busCategory = busCat.Text;
            busSpecification = busSpecificationInput.Text;
            busPassengerPermit = busPassengerPermitInput.Text;
            status = statusInput.Text;


            if (ownerIc.Equals("") || ownerName.Equals("") || ownerName.Equals("") || ownerAddress.Equals("") || ownerEmail.Equals("") || ownerPhone.Equals("") || driverName.Equals("") || driverIc.Equals("") || driverLicense.Equals("") || driverPhoneNo.Equals("") || busNumberPlate.Equals("") || busCategory.Equals("") || busSpecification.Equals("") || busPassengerPermit.Equals(""))
            {
                MessageBox.Show("Input must not be empty!");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(ownerPhoneInput.Text, @"^\d{10}$").Success)
            {
                MessageBox.Show("Please input Owner Phone Number correctly.");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(driverPhoneInput.Text, @"^\d{10}$").Success)
            {
                MessageBox.Show("Please input Driver Phone Number correctly.");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(driverIcInput.Text, @"^\d{12}$").Success)
            {
                MessageBox.Show("Please input Driver IC correctly.");
            }
            else
            {



                //Checking for permit data validity to ensure the permit date is valid
                Boolean checkValid = validateDate(datepickerFrom.Value.ToString("dd/MM/yyyy"), datepickerTo.Value.ToString("dd/MM/yyyy"));
                if (checkValid)
                {
                    busPermitValidity = datepickerTo.Value.ToString("dd/MM/yyyy") + "-" + datepickerTo.Value.ToString("dd/MM/yyyy");



                    //connection to database
                    string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

                    //sql to create bus, owner and driver record
                    string multiSql = "INSERT INTO busowner (IC, Name, Address, PhoneNumber, Email, username, hash) " +
                        "VALUES ('" + ownerIc + "', '" + ownerName + "', '" + ownerAddress + "', '" + ownerPhone + "', '" + ownerEmail + "', '" + username + "', '" + password + "');";

                    multiSql += "INSERT INTO driver (Name, IC, License, PhoneNo, RegisteredOwnerIC) " +
                        "VALUES ('" + driverName + "', '" + driverIc + "', '" + driverLicense + "', '" + driverPhoneNo + "', '" + ownerIc + "');";

                    multiSql += "INSERT INTO bus (NumberPlate, Category, Specification, PassengerPermit, PermitValidity, OwnerIC, status) " +
                        "VALUES ('" + busNumberPlate + "', '" + busCategory + "', '" + busSpecification + "', '" + busPassengerPermit + "', '" + busPermitValidity + "', '" + ownerIc + "', '" + status + "');";

                    //execute sql command
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MySqlCommand sqlComm = new MySqlCommand(multiSql, MyConn);

                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = sqlComm.ExecuteReader();

                    //write logs 
                    MyReader.Close();
                    sqlComm.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'External provider added!');" +
                        "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Driver added!');" +
                        "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Bus added!!');";
                    sqlComm.ExecuteNonQuery();
                    MyConn.Close();

                    MessageBox.Show("External provided added!");
                    clearText();

                }
                else
                    MessageBox.Show("Bus Permit validity is incorrect!");
            }

        }

        private void clearText()
        {
            ownerNameInput.Text = "";
            ownerIcInput.Text = "";
            ownerAddresInput.Text = "";
            ownerPhoneInput.Text = "";
            ownerEmailInput.Text = "";
            usernameInput.Text = "";
            pwInput.Text = "";

            driverNameInput.Text = "";
            driverIcInput.Text = "";
            driverLicenseInput.Text = "";
            driverPhoneInput.Text = "";

            busNumberPlateInput.Text = "";
            busCat.Text = "";
            busSpecificationInput.Text = "";
            busPassengerPermitInput.Text = "";
        }

        private void ownerNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }





        private void homeToolStripMenuItem1_Click_1(object sender, EventArgs e)
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

        private void viewEditBusToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private static Boolean validateDate(string from, string to)
        {

            //split the from date (returns array of size 3)
            string[] tempFrom = from.Split('/');
            int fromMonth = int.Parse(tempFrom[1]);  //getting the from Month
            int fromDay = int.Parse(tempFrom[0]); //getting the from Day
            int fromYear = int.Parse(tempFrom[2]); //getting the from year

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

        private void busCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CreateExternalProvider_FormClosed(object sender, FormClosedEventArgs e)
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

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
