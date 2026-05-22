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
    public partial class LoginAdmin : Form
    {
        public LoginAdmin() 
        { 
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Close();
        }

        private void showPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword1.Checked == true) { adminPass.UseSystemPasswordChar = false; }
            else { adminPass.UseSystemPasswordChar = true; }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = adminUsername.Text;
            string password = adminPass.Text;
            while (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(username))
            {
                string title1 = "Login Unsuccessful";
                string message1 = "Your username or password is blank!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                if (result1 == DialogResult.OK) { break; }
            }
            if (Login.returnToken() == "Guest")
            {
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from admindata WHERE adminUsername = '{username}' AND adminPassword = '{password}'", connect);
                int result = Convert.ToInt32(command.ExecuteScalar());
                command.Connection = connect;
                command.ExecuteNonQuery();
                if (result != 0)
                {
                    Login.applyToken("Admin");
                    string title1 = "Login Successful";
                    string message1 = "You have successfully logged in as an administrator.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    Login loginForm = new Login();
                    this.Close();
                }
                else
                {
                    string title1 = "Login Unsuccessful";
                    string message1 = "Login failed, make sure that the credentials are valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    adminUsername.Clear(); adminPass.Clear();
                }
            }
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {

        }

        private void LoginAdmin_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate(); this.Focus();
        }

        private void LoginAdmin_Activated(object sender, EventArgs e) { this.Focus(); }
    }
}
