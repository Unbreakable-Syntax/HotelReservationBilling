using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationBilling
{
    public partial class MainMenu : Form
    {
        public string LoginToken = "";     
        public MainMenu()
        {
            InitializeComponent();
            LoginToken = Login.returnToken();
            if (LoginToken == "Guest")
            {
                manageRoomButton.Visible = false;
                manageOccupantButton.Visible = false;
                additionalGuest.Visible = false;
                manageHotelReserveButton.Location = new Point(329, 162);
                cancelHistory.Location = new Point(329, 200);
                checkoutHistory.Location = new Point(329, 238);
                loginMenuButton.Location = new Point(345, 276);
                exitProgramButton.Location = new Point(370, 313);
            }
            else if (LoginToken == "Admin")
            {
                manageRoomButton.Visible = true;
                manageOccupantButton.Visible = true;
                additionalGuest.Visible = true;
                manageHotelReserveButton.Location = new Point(329, 106);
                checkoutHistory.Location = new Point(329, 179);
                cancelHistory.Location = new Point(329, 217);
                loginMenuButton.Location = new Point(345, 331);
                exitProgramButton.Location = new Point(370, 368);
            }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            var command = new MySqlCommand();
            command.Connection = connect;
            command.CommandText = @"CREATE TABLE IF NOT EXISTS hotelroom (room_number VARCHAR(15) NOT NULL, room_type VARCHAR(30) NOT NULL, room_floor VARCHAR(30) NOT NULL, room_price DOUBLE UNSIGNED DEFAULT 0.0 NOT NULL, PRIMARY KEY (room_number))";
            command.ExecuteNonQuery();
            MySqlCommand command4 = new MySqlCommand("create table if not exists occupantdata (person_name VARCHAR (80) NOT NULL, person_gender VARCHAR (20) NOT NULL, person_age VARCHAR(20) NOT NULL, person_birthdate DATE NOT NULL, person_national VARCHAR (30) NOT NULL, person_religion VARCHAR (30) NOT NULL, person_contact_number VARCHAR (14) NOT NULL, person_down_pay DOUBLE UNSIGNED DEFAULT 0.0, person_remain_bal DOUBLE UNSIGNED DEFAULT 0.0, person_change DOUBLE UNSIGNED DEFAULT 0.0, person_total_bal DOUBLE UNSIGNED DEFAULT 0.0, person_orig_rate INT UNSIGNED DEFAULT 0, person_discount_rate INT UNSIGNED DEFAULT 0, parking_rate DOUBLE UNSIGNED DEFAULT 0.0, room_number_occupied VARCHAR(15) DEFAULT 'Room 0', room_type VARCHAR (40) NOT NULL, number_of_nights VARCHAR (15) DEFAULT '0 night', number_of_additional_guests VARCHAR (15) DEFAULT '0 guest', guest_charge DOUBLE UNSIGNED DEFAULT 0.0, start_rent DATE DEFAULT '1950-01-01', end_rent DATE DEFAULT '1950-01-02', PRIMARY KEY (person_name), FOREIGN KEY (room_number_occupied) REFERENCES hotelroom(room_number))", connect);
            command4.Connection = connect;
            command4.ExecuteNonQuery();
            MySqlCommand command5 = new MySqlCommand("create table if not exists additionalguest (guest_name VARCHAR (80) NOT NULL, guest_gender VARCHAR (30) NOT NULL, guest_age VARCHAR (30) NOT NULL, guest_birthdate DATE NOT NULL, guest_national VARCHAR (30) NOT NULL, guest_religion VARCHAR (30) NOT NULL, guest_contact_number VARCHAR (14) NOT NULL, guest_primary_booker VARCHAR (80) NOT NULL, guest_room_occupied VARCHAR (15) NOT NULL DEFAULT 'Room 0', room_type VARCHAR (40) NOT NULL, guest_start_date DATE DEFAULT '1950-01-01', guest_end_date DATE DEFAULT '1950-01-02', guest_additional_charge DOUBLE NOT NULL DEFAULT 0, guest_parking_fee DOUBLE DEFAULT 0, foreign key (guest_primary_booker) references occupantdata(person_name), foreign key (guest_room_occupied) references hotelroom(room_number))", connect);
            command5.Connection = connect;
            command5.ExecuteNonQuery();
            MySqlCommand command6 = new MySqlCommand("create table if not exists checkouthistory (guest_name VARCHAR (80) NOT NULL, guest_gender VARCHAR (30) NOT NULL, guest_age VARCHAR (30) NOT NULL, guest_birthdate DATE NOT NULL, guest_national VARCHAR (30) NOT NULL, guest_religion VARCHAR (30) NOT NULL, guest_contact_number VARCHAR (14) NOT NULL, guest_room_occupied VARCHAR (15) NOT NULL DEFAULT 'Room 0', room_type VARCHAR (40) NOT NULL, guest_start_date DATE DEFAULT '1950-01-01', guest_end_date DATE DEFAULT '1950-01-02', guest_totalcharge DOUBLE NOT NULL DEFAULT 0, guest_remaincharge DOUBLE NOT NULL DEFAULT 0, guest_payment DOUBLE NOT NULL DEFAULT 0, guest_change DOUBLE NOT NULL DEFAULT 0, guest_type VARCHAR (30) NOT NULL)", connect);
            command6.Connection = connect;
            command6.ExecuteNonQuery();
            MySqlCommand command7 = new MySqlCommand("create table if not exists cancelhistory (guest_name VARCHAR (80) NOT NULL, guest_gender VARCHAR (30) NOT NULL, guest_age VARCHAR (30) NOT NULL, guest_birthdate DATE NOT NULL, guest_national VARCHAR (30) NOT NULL, guest_religion VARCHAR (30) NOT NULL, guest_contact_number VARCHAR (14) NOT NULL, guest_room_occupied VARCHAR (15) NOT NULL DEFAULT 'Room 0', room_type VARCHAR (40) NOT NULL, guest_start_date DATE DEFAULT '1950-01-01', guest_end_date DATE DEFAULT '1950-01-02', cancellation_date DATE NOT NULL, guest_totalcharge DOUBLE NOT NULL DEFAULT 0, guest_remaincharge DOUBLE NOT NULL DEFAULT 0, guest_payment DOUBLE NOT NULL DEFAULT 0, guest_change DOUBLE NOT NULL DEFAULT 0, guest_type VARCHAR (30) NOT NULL)", connect);
            command7.Connection = connect;
            command7.ExecuteNonQuery();
            Login loginForm = new Login();
            this.SendToBack(); loginForm.ShowDialog();
        }

        private void manageOccupantButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from occupantdata", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No occupants available";
                string message1 = "There are no occupants to manage.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            else
            {
                ManageOccupant occupantForm = new ManageOccupant();
                occupantForm.Show();
            }
        }

        private void manageRoomButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from hotelroom", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No rooms available";
                string message1 = "There are no rooms to manage.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            else
            {
                ManageRoom manageRoom = new ManageRoom();
                manageRoom.Show();
            }
        }

        private void loginMenuButton_Click(object sender, EventArgs e) 
        {
            Login loginForm = new Login();
            this.SendToBack(); loginForm.ShowDialog();
        }

        private void exitProgramButton_Click(object sender, EventArgs e)
        { Application.Exit(); }

        private void manageHotelReserveButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from hotelroom", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No rooms available";
                string message1 = "There are no rooms to view.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            else 
            {
                ManageHotelReserve reserveForm = new ManageHotelReserve();
                reserveForm.Show();
            }
        }

        private void additionalGuest_Click(object sender, EventArgs e)
        {
            ManageAdditional additionalForm = new ManageAdditional();
            additionalForm.Show();
        }

        private void checkoutHistory_Click(object sender, EventArgs e)
        {
            ViewCheckout checkoutForm = new ViewCheckout();
            checkoutForm.Show();
        }

        private void cancelHistory_Click(object sender, EventArgs e)
        {
            CancelHistory cancelForm = new CancelHistory();
            cancelForm.Show();
        }

        private void MainMenu_Shown(object sender, EventArgs e)
        {
            LoginToken = Login.returnToken(); this.Activate();
            if (LoginToken == "Guest")
            {
                manageRoomButton.Visible = false;
                manageOccupantButton.Visible = false;
                additionalGuest.Visible = false;
                manageHotelReserveButton.Location = new Point(329, 162);
                cancelHistory.Location = new Point(329, 200);
                checkoutHistory.Location = new Point(329, 238);
                loginMenuButton.Location = new Point(345, 276);
                exitProgramButton.Location = new Point(370, 313);
            }
            else if (LoginToken == "Admin")
            {
                manageRoomButton.Visible = true;
                manageOccupantButton.Visible = true;
                additionalGuest.Visible = true;
                manageHotelReserveButton.Location = new Point(329, 106);
                checkoutHistory.Location = new Point(329, 179);
                cancelHistory.Location = new Point(329, 217);
                loginMenuButton.Location = new Point(345, 331);
                exitProgramButton.Location = new Point(370, 368);
            }
        }
    }
}
