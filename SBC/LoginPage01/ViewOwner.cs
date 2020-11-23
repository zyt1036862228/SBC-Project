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
    public partial class ViewOwner : Form
    {
        public ViewOwner()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string name;
            string ic;

            name = ownerNameInput.Text;
            ic = ownerIcInput.Text;

/*            if (name.Equals("") || ic.Equals(""))
            {
                MessageBox.Show("Input must not be empty!");
            }
            else if (!System.Text.RegularExpressions.Regex.Match(ownerIcInput.Text, @"^\d{12}$").Success)
            {
                MessageBox.Show("Please input IC correctly.");
            }

            else
            {*/


                //connection to database
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();
                MySqlDataReader MyReader;

                //Select statement to find bus drivers available
                string Query = "SELECT IC, Name, Address, PhoneNumber AS 'Phone', Email FROM busowner " +
                    "WHERE IC LIKE '%" + ic + "%' AND Name LIKE '%" + name + "%';";

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);

                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                tableResult.DataSource = dTable;
                MyConn.Close();
  /*          }*/
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
            ViewBookings booking = new ViewBookings();
            booking.ShowDialog();
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

        private void ViewOwner_FormClosed(object sender, FormClosedEventArgs e)
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

        private void editButton_Click(object sender, EventArgs e)
        {
            string ownerIC;

            try
            {
                ownerIC = tableResult.SelectedRows[0].Cells[0].Value.ToString();

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



            EditOwner editOwner = new EditOwner(ownerIC);
            editOwner.ShowDialog();
        }
    }
}
