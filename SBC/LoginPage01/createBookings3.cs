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

namespace LoginPage01
{
    public partial class createBookings3 : Form
    {
        string name, phone, origin, destination, passengers, shuttleType, remarks, date;
        Booking booking;

        private void createBookings3_FormClosed(object sender, FormClosedEventArgs e)
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm mainForm = new AdminForm();
            mainForm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public createBookings3(Customer customer, Booking booking)
        {
            InitializeComponent();

            //initialize default fields
            initFields(customer, booking);
            this.booking = booking;

            //initialize driver name into combo box
            if (booking.getAsignedTo().Equals("SBC"))
            {
                String Query = "SELECT Name FROM driver WHERE RegisteredOwnerIC IN(SELECT IC FROM busowner WHERE Name = '"
                    + booking.getOwnerName() + "') AND IC NOT IN(SELECT driverIC FROM drivershift WHERE DATE = '" + booking.getDate() + "')";

                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyComd.ExecuteReader();

                //for each return result of busowner name,  add into combo box
                while (MyReader.Read())
                {
                    this.driverNameCombo.Items.AddRange(new object[] {
            MyReader.GetString("Name")
            });
                }


                MyConn.Close();
            }
            else
            {
                //hide bus driver fields
                label10.Visible = false;
                driverNameCombo.Visible = false;
            }




        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string bookingID="";
            name = nameInput.Text;
            phone = phoneInput.Text;
            destination = destinationInput.Text;
            origin = originInput.Text;
            passengers = passengerInput.Text;
            shuttleType = shuttleTypeInput.Text;
            remarks = remarksInput.Text;
            date = dateInput.Text;

            //connect db
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            //Retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlDataReader MyReader;


                try
                {
                    string Query = "SELECT BookingID FROM booking ORDER BY BookingID desc LIMIT 1;";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);

                    MyConn.Open();
                    MyReader = MyComd.ExecuteReader();

                    //if data exists, get latest booking ID and increment by 1
                    if (MyReader.Read())
                    {
                        bookingID = MyReader.GetString("BookingID");
                        string bookingNumber = bookingID.Substring(1);

                        char[] strBooking = bookingNumber.ToCharArray();
                        int[] intBooking = Array.ConvertAll(strBooking, s => int.Parse(s.ToString()));


                        recursive(intBooking, intBooking.Length - 1);
                        bookingID = "B";

                        for (int i = 0; i < intBooking.Length; i++)
                        {
                            bookingID += intBooking[i];
                        }
                    }
                    else
                    {
                        //if no records in booking table
                        bookingID = "B0001";
                    }

                MyReader.Close();
                if (booking.getAsignedTo().Equals("SBC"))
                {
                    //sql to create bookings record
                    Query = "INSERT INTO booking VALUES ('" + bookingID + "', '" + phone + "', '" + date + "', '" + origin
                            + "', '" + destination + "', '" + Program.admin.getEmpID() + "', '" + "Booked but not paid" + "', '" + int.Parse(passengers) + "', '"
                            + remarks + "', " + 0 + ");";

                    //get driverIC 
                    string driverIC = DBgetDriverIC();


                    //insert record into drivershift table
                    Query += "INSERT INTO drivershift VALUES('" + bookingID + "', '" + driverIC + "', '" + date + "', '" + booking.getNumberPlate() + "');";

                    //write logs 
                    Query += "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Assigned a bus & driver to " +
                        bookingID + "');";

                    MyComd.CommandText = Query;
                    MyComd.ExecuteNonQuery();
                    MyConn.Close();
                }
                else
                {
                    //sql to create bookings record but no drivers confirmed
                    Query = "INSERT INTO booking VALUES ('" + bookingID + "', '" + phone + "', '" + date + "', '" + origin
                            + "', '" + destination + "', '" + Program.admin.getEmpID() + "', '" + "Requested" + "', '" + int.Parse(passengers) + "', '"
                            + remarks + "', " + 0 +");";
                    MyComd.CommandText = Query;
                    MyComd.ExecuteNonQuery();



                    //write logs 
                    MyReader.Close();
                    MyComd.CommandText = "INSERT INTO Log (EmpID, Message) VALUES ('" + Program.admin.getEmpID() + "', 'Created request for external" +
                        "provider');";
                    MyComd.ExecuteNonQuery();
                    MyConn.Close();

                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                return;
                }




            MessageBox.Show("Booking record is successful!");
            AdminForm mainPage = new AdminForm();
            this.Hide();
            mainPage.ShowDialog();
        }

        private void initFields(Customer customer, Booking booking)
        {
            nameInput.Text = customer.getName();
            phoneInput.Text = customer.getPhoneNo();
            shuttleTypeInput.Text = booking.getCategory();

            if (booking.getAsignedTo().Equals("External"))
            {
                this.shuttleTypeInput.Items.AddRange(new object[] {
            "Factory Bus",
            "School Bus",
            "Express Bus",
            "Mini Bus",
            "Coach",
            "Passenger Van",
            "MPV"
            });
            }
            else
            {
                this.shuttleTypeInput.Items.AddRange(new object[] {
            booking.getCategory()
        });
            }
            dateInput.Text = booking.getDate();
            }


        //adds 1 to the last int array, recursively call if value is 9
        private int[] recursive(int [] arr, int pointer)
        {
            int temp = arr[pointer];

            if (temp == 9)
            {
                arr[pointer] = 0;
                recursive(arr, pointer - 1);
            }
            else
            {
                temp++;
                arr[pointer] = temp;
            }
            return arr;
        }

        private String DBgetDriverIC()
        {
            //get driver IC from the name
            string driverIC;

            String Query = "SELECT IC from driver WHERE registeredOwnerIC = (SELECT IC FROM busowner WHERE Name='" + booking.getOwnerName() + "');";
                
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader;
            MyConn.Open();
            MyReader = MyComd.ExecuteReader();


            MyReader.Read();
            driverIC = MyReader.GetString("IC");

            MyConn.Close();


            return driverIC;
        }
    }
}
