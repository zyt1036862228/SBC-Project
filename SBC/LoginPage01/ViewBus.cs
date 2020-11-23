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
    public partial class ViewBus : Form
    {
        public ViewBus()
        {
            InitializeComponent();

/*            this.busCategory.Items.AddRange(new object[] {
            "Factory Bus",
            "School Bus",
            "Express Bus",
            "Mini Bus",
            "Coach",
            "Passenver Van",
            "MPV"
            });*/

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



        private void button1_Click(object sender, EventArgs e)
        {
            string numberPlate;
            numberPlate = busNumberPlateInput.Text;
            string ownerName;
            ownerName = busOwnerNameInput.Text;


            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //Retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;


                string Query = "SELECT * FROM bus WHERE NumberPlate LIKE '%" + numberPlate + "%' AND OwnerIC IN " +
                    "(SELECT IC FROM busowner WHERE Name LIKE '%"+ ownerName + "%')";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                tableResult.DataSource = dTable;
                MyConn.Close();
            }
            catch(Exception err)
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

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        private void ViewBus_FormClosed(object sender, FormClosedEventArgs e)
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

        private void edit_Click(object sender, EventArgs e)
        {
            string numberPlate;

            try
            {
                numberPlate = tableResult.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Highlight and select the whole row before clicking submit");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            EditBus edit = new EditBus(numberPlate);
            edit.ShowDialog();
        }
    }
}
