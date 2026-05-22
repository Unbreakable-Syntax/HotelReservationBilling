using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Drawing.SystemFonts;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelReservationBilling
{
    public partial class Login : Form
    {
        public Size formSize;

        public static string LoginToken = "Guest";
        
        public static string createPassword = "1234";
        public Login()
        {
            InitializeComponent();
            try
            {
                FileStream createFile;
                BinaryFormatter createBinary = new BinaryFormatter();
                createFile = File.OpenRead("file.dat");
                createPassword = (string)createBinary.Deserialize(createFile);
                createFile.Close();
            }
            catch (FileNotFoundException) { }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            var command = new MySqlCommand();
            command.Connection = connect;
            command.CommandText = @"CREATE TABLE IF NOT EXISTS admindata (adminUsername VARCHAR(80) NOT NULL,
            adminPassword VARCHAR(80) NOT NULL, PRIMARY KEY (adminUsername))"; command.ExecuteNonQuery();
            MySqlCommand command2 = new MySqlCommand($"SELECT COUNT(*) from admindata", connect);
            int result3 = Convert.ToInt32(command2.ExecuteScalar());
            command2.Connection = connect;
            command2.ExecuteNonQuery();
            if (result3 == 0) { Login.applyToken("Guest"); }
            if (LoginToken == "Guest")
            {
                addAdminButton.Visible = false;
                removeAdminButton.Visible = false;
                changeCreateButton.Visible = false;
                loginAdminButton.Location = new Point(326, 142);
                proceedMenuButton.Location = new Point(326, 182);
                loginUserButton.Location = new Point(325, 225);
                exitButton.Location = new Point(355, 268);
            }
            else if (LoginToken == "Admin")
            {
                addAdminButton.Visible = true;
                removeAdminButton.Visible = true;
                changeCreateButton.Visible = true;
                loginAdminButton.Location = new Point(333, 87);
                proceedMenuButton.Location = new Point(333, 127);
                loginUserButton.Location = new Point(332, 170);
                exitButton.Location = new Point(359, 357);
            }
        }
        public static void SaveCreate()
        {
            FileStream createFile = File.Create("file.dat");
            BinaryFormatter createBinary = new BinaryFormatter();
            createBinary.Serialize(createFile, createPassword);
            createFile.Close();
        }
        public static string returnCreate() { return createPassword; }
        public static void applyCreate(string create) { createPassword = create; SaveCreate(); }
        public static string returnToken() { return LoginToken; }
        public static void applyToken(string token) { LoginToken = token; }

        private void loginUserButton_Click(object sender, EventArgs e)
        {
            if (LoginToken == "Guest")
            {
                string title1 = "Guest mode activated";
                string message1 = "You are already logged in as a regular user.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            else if (LoginToken == "Admin")
            {
                string message = "Are you sure you want to login as a receptionist?";
                string title = "Login as Receptionist";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    LoginToken = "Guest";
                    string title1 = "Operation Success";
                    string message1 = "You have now logged in as a receptionist.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                }
                if (LoginToken == "Guest")
                {
                    addAdminButton.Visible = false;
                    removeAdminButton.Visible = false;
                    changeCreateButton.Visible = false;
                    loginAdminButton.Location = new Point(326, 142);
                    proceedMenuButton.Location = new Point(326, 182);
                    loginUserButton.Location = new Point(325, 225);
                    exitButton.Location = new Point(355, 268);
                }
            }
        }

        private void loginAdminButton_Click(object sender, EventArgs e)
        {
            if (LoginToken == "Admin")
            {
                string title1 = "Administrator mode enabled";
                string message1 = "An administrator is already logged in.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            else if (LoginToken == "Guest")
            {
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from admindata", connect);
                int result = Convert.ToInt32(command.ExecuteScalar());
                command.Connection = connect;
                command.ExecuteNonQuery();
                if (result == 0 && createPassword != "1234") { createPassword = "1234"; }
                if (result == 0 && createPassword == "1234")
                {
                    FirstCreation firstAccount = new FirstCreation();
                    this.SendToBack(); firstAccount.ShowDialog();
                }
                else
                {
                    LoginAdmin loginAdmin = new LoginAdmin();
                    this.SendToBack(); loginAdmin.ShowDialog();
                }
            }               
        }

        private void exitButton_Click(object sender, EventArgs e) { Application.Exit(); }

        private void changeCreateButton_Click(object sender, EventArgs e)
        {
            ChangeCreate changeForm = new ChangeCreate();
            changeForm.Activate(); this.SendToBack(); changeForm.ShowDialog();
        }

        private void removeAdminButton_Click(object sender, EventArgs e)
        {
            RemoveAdmin removeForm = new RemoveAdmin();
            removeForm.Activate(); this.SendToBack(); removeForm.ShowDialog();         
        }

        private void addAdminButton_Click(object sender, EventArgs e)
        {
            AddAdmin addForm = new AddAdmin();
            addForm.Activate(); this.SendToBack(); addForm.ShowDialog();
        }

        private void proceedMenuButton_Click(object sender, EventArgs e) { this.Close(); }

        private void Login_Activated(object sender, EventArgs e)
        {
            if (LoginToken == "Guest")
            {
                addAdminButton.Visible = false;
                removeAdminButton.Visible = false;
                changeCreateButton.Visible = false;
                loginAdminButton.Location = new Point(326, 142);
                proceedMenuButton.Location = new Point(326, 182);
                loginUserButton.Location = new Point(325, 225);
                exitButton.Location = new Point(355, 268);
            }
            else if (LoginToken == "Admin")
            {
                addAdminButton.Visible = true;
                removeAdminButton.Visible = true;
                changeCreateButton.Visible = true;
                loginAdminButton.Location = new Point(333, 87);
                proceedMenuButton.Location = new Point(333, 127);
                loginUserButton.Location = new Point(332, 170);
                exitButton.Location = new Point(359, 357);
            }
        }
    }
}
