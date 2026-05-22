using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationBilling
{
    public partial class FirstCreation : Form
    {
        public FirstCreation()
        {
            InitializeComponent();
        }

        private void showPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword1.Checked == true) { adminPass.UseSystemPasswordChar = false; }
            else { adminPass.UseSystemPasswordChar = true; }
        }

        private void showPassword2_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword2.Checked == true) { firstCreate.UseSystemPasswordChar = false; }
            else { firstCreate.UseSystemPasswordChar = true; }
        }

        private void FirstCreation_Load(object sender, EventArgs e)
        {

        }

        private void FirstCreation_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void FirstCreation_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Focus(); this.Activate();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string username = adminUsername.Text;
            string password = adminPass.Text;
            string creation = firstCreate.Text;
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(creation))
            {
                string title1 = "Add account unsuccessful";
                string message1 = "Your new username, password, or account creation password is empty!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                adminUsername.Clear(); adminPass.Clear(); firstCreate.Clear();
            }
            else
            {
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                MySqlCommand command = new MySqlCommand($"insert into admindata values(\"{username}\", \"{password}\")");
                command.Connection = connect; command.ExecuteNonQuery();
                Login.applyCreate(creation); Login.SaveCreate();
                string title1 = "Add account successful";
                string message1 = "This administrator account can now be used to log into the system." +
                    "\nAt this point, account creation now requires an administrator account to be logged in" +
                    "\nPlease ensure to not forget the new account creation password" +
                    "\nAs this prevents account creation if the inputted creation password is wrong."; 
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                this.Close();
            }
        }
    }
}
