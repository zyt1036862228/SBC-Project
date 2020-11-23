using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace LoginPage01
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String empId =usernameInput.Text;
            String userPwd = passwordInput.Text;
            String computedHash;
            

            if (empId.Trim() == "" || userPwd.Trim() == "")
            {
                MessageBox.Show("Username or Password field should not be blank!");
            }

            //Perform hashing for password
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(userPwd);
                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                // Convert hash byte array to string
                computedHash = BitConverter.ToString(hashBytes).Replace("-", string.Empty); ;
            }

            try
            {
                //Connection to database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sbc; sslMode=none";
                string Query = "SELECT * FROM admin WHERE EmpID ='" + empId + "';";

                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyComd.ExecuteReader();

                if (MyReader.Read())
                {
                    string dbEmpId = MyReader.GetString("EmpID");
                    string dbName = MyReader.GetString("Name");
                    Boolean dbMaster = MyReader.GetBoolean("Master");
                    Program.admin = new Admin(dbEmpId, dbName, dbMaster);

                    string hash = MyReader.GetString("hash");

                    if (computedHash.ToLower() == hash.ToLower())
                    {
                        //login successful
                        this.Hide();
                        AdminForm adminForm = new AdminForm();
                        PermitExpiryReminder();
                        adminForm.ShowDialog();
                        

                    }
                    else
                    {
                        //show error message box
                        MessageBox.Show("Password incorrect");
                    }
                }
                //check permit validity

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }



        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void PermitExpiryReminder()
        {
            //connection to database
            string Conn = "datasource=localhost;port=3306;username=root;password=;database=sbc;sslMode=none";

            //retrieve records from database
            MySqlConnection MyConn = new MySqlConnection(Conn);
            try
            {
                MyConn.Open();
                MySqlDataReader MyReader;

                String Query = "SELECT NumberPlate, PermitValidity FROM bus WHERE OwnerIC = (SELECT IC FROM busowner WHERE Name='SBC');";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyReader = cmd.ExecuteReader();

                while (MyReader.Read())
                {
                    //expiry date for permit
                    string permitValidity = MyReader.GetString("PermitValidity");
                    string busPlate = MyReader.GetString("NumberPlate");

                    permitValidity = permitValidity.Substring(11);

                    //getting current date
                    DateTime timestamp = DateTime.Now;
                    string currentDate = timestamp.ToString("dd/MM/yyyy");

                    bool checkTrigger = compareDate(currentDate, permitValidity);

                    if (checkTrigger)
                    {
                        MessageBox.Show("The permit for vehicle number " + busPlate + " is expiring soon," +
                            " please schedule for renewal with PUSPAKOM!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static Boolean compareDate(string currentDate, string expiryDate)
        {

            //split the from date (returns array of size 3)
            string[] tempCurrDate = currentDate.Split('/');
            int currMonth = int.Parse(tempCurrDate[1]);  //getting the from Month
            int currDay = int.Parse(tempCurrDate[0]); //getting the from Day
            int currYear = int.Parse(tempCurrDate[2]); //getting the from year

            string[] tempExpDate = expiryDate.Split('/');
            int expMonth = int.Parse(tempExpDate[1]);  //getting the to Month
            int expDay = int.Parse(tempExpDate[0]); //getting the to Day
            int expYear = int.Parse(tempExpDate[2]); //getting the to year

            DateTime triggerDate = new DateTime(currYear, currMonth, currDay);
            DateTime expDate = new DateTime(expYear, expMonth, expDay);

            //deduct current date by 7 days
            expDate = expDate.AddDays(-7);

            int compare = DateTime.Compare(triggerDate, expDate);
            /*
             *  DateTime.Compare() returns 0 if date is same 
             *  >0 means t1 is greater than t2
             */
            

            if (compare > 0)
            //trigger alert
                return true;
            else
                return false;

        }
    }
}
