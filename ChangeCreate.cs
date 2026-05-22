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
    public partial class ChangeCreate : Form
    {
        public ChangeCreate()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Close();
        }

        private void showPassword2_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword2.Checked == true) { newCreate.UseSystemPasswordChar = false; }
            else { newCreate.UseSystemPasswordChar = true; }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (oldCreate.Text != Login.returnCreate())
            {
                Login.applyCreate(newCreate.Text); Login.SaveCreate();
                string title2 = "Wrong old account creation password";
                string message2 = "Please ensure that the old account creation password is valid.";
                MessageBoxButtons button2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, button2);
                oldCreate.Clear(); newCreate.Clear();
            }
            else
            {
                string title1 = "Change Account Creation Password Confirmation";
                string message1 = "Are you sure you want to change the account creation password?";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                if (result1 == DialogResult.Yes)
                {
                    Login.applyCreate(newCreate.Text); Login.SaveCreate();
                    string title2 = "Account creation password changed";
                    string message2 = "The account creation password has been successfully changed.";
                    MessageBoxButtons button2 = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message2, title2, button2);
                    this.Close();
                }
            }
        }

        private void ChangeCreate_Activated(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void ChangeCreate_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Focus(); this.Activate();
        }

        private void showPassword1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassword1.Checked == true) { oldCreate.UseSystemPasswordChar = false; }
            else { oldCreate.UseSystemPasswordChar = true; }
        }
    }
}
