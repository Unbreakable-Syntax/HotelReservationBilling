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
    public partial class CancelHistory : Form
    {
        public CancelHistory()
        {
            InitializeComponent(); FillCancel();
        }

        public void FillCancel()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', cancellation_date as 'Cancellation Date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from cancelhistory order by guest_start_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); cancelHistoryTable.DataSource = table;
            cancelHistoryTable.AllowUserToAddRows = false;
        }

        public void SearchCancel(string name, string room, string type, string startdate, string enddate, string canceldate)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains("\\") || name.Contains("/")) { name = "%"; }
            if (string.IsNullOrWhiteSpace(room) || room.Contains("\\") || room.Contains("/")) { room = "%"; }
            if (string.IsNullOrWhiteSpace(type) || type.Contains("\\") || type.Contains("/")) { type = "%"; }
            if (string.IsNullOrWhiteSpace(startdate) || startdate.Contains("\\") || startdate.Contains("/")) { startdate = "%"; }
            if (string.IsNullOrWhiteSpace(enddate) || enddate.Contains("\\") || enddate.Contains("/")) { enddate = "%"; }
            if (string.IsNullOrWhiteSpace(canceldate) || canceldate.Contains("\\") || canceldate.Contains("/")) { canceldate = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', cancellation_date as 'Cancellation Date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from cancelhistory where guest_name LIKE '{name}' and guest_room_occupied LIKE '{room}' and guest_type LIKE '{type}' and guest_start_date LIKE '{startdate}' and guest_end_date LIKE '{enddate}' and cancellation_date LIKE '{canceldate}' order by cancellation_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); cancelHistoryTable.DataSource = table;
            cancelHistoryTable.AllowUserToAddRows = false;      
        }

        public void SearchCancel2(string searchVal)
        {
            if (searchVal.Contains("\\") || searchVal.Contains("/")) { searchVal = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', cancellation_date as 'Cancellation date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from cancelhistory where concat(guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, cancellation_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) LIKE '%{searchVal}%' order by guest_start_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); cancelHistoryTable.DataSource = table;
            cancelHistoryTable.AllowUserToAddRows = false;
        }

        private void guestName_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string cancel = cancelDate.Text;
            SearchCancel(guestName.Text, room, type, startdate, enddate, cancel);
        }

        private void guestStartDate_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string name = guestName.Text;
            string enddate = guestEndDate.Text;
            string cancel = cancelDate.Text;
            SearchCancel(name, room, type, guestStartDate.Text, enddate, cancel);
        }

        private void guestEndDate_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string name = guestName.Text;
            string cancel = cancelDate.Text;
            SearchCancel(name, room, type, startdate, guestEndDate.Text, cancel);
        }

        private void guestRoom_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string name = guestName.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string cancel = cancelDate.Text;
            SearchCancel(name, guestRoom.Text, type, startdate, enddate, cancel);
        }

        private void guestType_TextChanged(object sender, EventArgs e)
        {
            string name = guestName.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string cancel = cancelDate.Text;
            SearchCancel(name, room, guestType.Text, startdate, enddate, cancel);
        }

        private void cancelDate_TextChanged(object sender, EventArgs e)
        {
            string name = guestName.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string type = guestType.Text;
            SearchCancel(name, room, type, startdate, enddate, cancelDate.Text);
        }

        private void backButton_Click(object sender, EventArgs e) { this.Close(); }

        private void otherDetailSearch_TextChanged(object sender, EventArgs e) { SearchCancel2(otherDetailSearch.Text); }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
