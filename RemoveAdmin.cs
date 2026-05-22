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
    public partial class RemoveAdmin : Form
    {
        public RemoveAdmin()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Close();
        }

        private void RemoveAdmin_Load(object sender, EventArgs e)
        {

        }
        private void showPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword1.Checked == true) { adminPass.UseSystemPasswordChar = false; }
            else { adminPass.UseSystemPasswordChar = true; }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string username = adminUsername.Text;
            string password = adminPass.Text;
            while (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(username))
            {
                string title1 = "Removal Unsuccessful";
                string message1 = "Your username or password is blank!";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                if (result1 == DialogResult.OK) { break; }
            }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"DELETE from admindata WHERE adminUsername = '{username}' AND adminPassword = '{password}'", connect);
            command.Connection = connect;
            int result2 = command.ExecuteNonQuery();
            if (result2 >= 1)
            {
                Login loginForm = new Login();
                string title1 = "Remove Successful";
                string message1 = "The administrator account has been successfully removed.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                this.Close();
            }
            else if (result2 == 0)
            {
                string title1 = "Removal Unsuccessful";
                string message1 = "Removal failed, make sure that the credentials are valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                adminUsername.Clear(); adminPass.Clear();
            }
        }

        private void RemoveAdmin_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate(); this.Focus();
        }
    }
}
