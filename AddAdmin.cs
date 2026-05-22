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
    public partial class AddAdmin : Form
    {
        public AddAdmin()
        {
            InitializeComponent();
        }

        private void AddAdmin_Shown(object sender, EventArgs e)
        {
             this.Activate(); this.Focus(); this.BringToFront();
        }

        private void AddAdmin_Activated(object sender, EventArgs e)
        {
             this.WindowState = FormWindowState.Normal; 
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
                if (creation != Login.returnCreate())
                {
                    string title1 = "Add account unsuccessful";
                    string message1 = "Please make sure that your account creation password is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    adminUsername.Clear(); adminPass.Clear(); firstCreate.Clear();
                }
                else if (creation == Login.returnCreate())
                {
                    string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                    var connect = new MySqlConnection(cs); connect.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from admindata WHERE adminUsername = '{username}'", connect);
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    command.Connection = connect;
                    if (result != 0)
                    {
                        string title1 = "Add account unsuccessful";
                        string message1 = "This username is unavailable.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        adminUsername.Clear(); adminPass.Clear(); firstCreate.Clear();
                    }
                    else if (result == 0)
                    {
                        MySqlCommand command1 = new MySqlCommand($"insert into admindata values(\"{username}\", \"{password}\")", connect);
                        command1.Connection = connect; command1.ExecuteNonQuery();
                        string title1 = "Add account successful";
                        string message1 = "This administrator account can now be used to log into the system.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        this.Close();
                    }
                }
            }

        }
    }
}
