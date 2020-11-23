using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace LoginPage01
{

    
    public partial class createBookings2 : Form
    {
        Customer customer;
        Boolean checkBusExists = false;
        public createBookings2(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateInputBox.Text = datepicker.Value.ToString("dd/MM/yyyy");
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void searchButton_Click(object sender, EventArgs e)
        {


            string date = datepicker.Value.ToString("dd/MM/yyyy");

            //connection to database
              string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //Retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;


                string Query = "SELECT NumberPlate, Category, Specification, busowner.name FROM bus" +
                    " JOIN busowner ON bus.OwnerIC = busowner.IC" +
                    " WHERE NumberPlate NOT IN(SELECT BusNumberPlate FROM drivershift WHERE Date = '"+ date + "')" +
                    " AND bus.status = 'Available'" +
                    " ORDER BY FIELD(name, 'SBC') DESC;";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                tableResult.DataSource = dTable;
                MyConn.Close();

                //if no records are found, redirect back to mainpage
                if (dTable.Rows.Count < 1)
                {
                    MessageBox.Show("No Buses are available for this day!");
                    checkBusExists = false;
                    return;
                }
                else
                    checkBusExists = true;


                
                //check if sbc exists
                if (!checkSBC_Exists(dTable))
                {
                    DialogResult dr = MessageBox.Show("Internal SBC bookings are not available, do you want to outsource to external provider?",
                      "No SBC Buses Found", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            Booking emptyBooking = new Booking(datepicker.Value.ToString("dd/MM/yyyy"));
                            this.Hide();
                            createBookings3 book3 = new createBookings3(customer, emptyBooking);
                            book3.ShowDialog();

                            /*MessageBox.Show("Yes");*/
                            break;
                        case DialogResult.No:
                            MessageBox.Show("No");
                            this.Hide();
                            AdminForm adminPage = new AdminForm();
                            adminPage.ShowDialog();
                            break;
                    }
                }


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
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

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        //Getting the values of the row selected
        private void Button1_Click(object sender, EventArgs e)
        {


            if (checkBusExists == true)
            {
                String[] temp = new string[4];
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        var value = tableResult.SelectedRows[0].Cells[i].Value;

                        temp[i] = value.ToString();
                    }catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show("Highlight and select the whole row before clicking submit");
                        return;
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                Booking booking = new Booking(temp[0], temp[1], temp[2], datepicker.Value.ToString("dd/MM/yyyy"), temp[3]);
                
                this.Hide();
                createBookings3 book3 = new createBookings3(customer, booking);
                book3.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Buses are available for today!");
                return;
            }
        }

        private void createBookings2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private bool checkSBC_Exists(DataTable table)
        {
            bool exists = false;
            foreach (DataRow row in table.Rows)
            {
                if (row["name"].ToString().Equals("SBC"))
                {
                    exists = true;
                    break;
                }
            }
            return exists;



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
