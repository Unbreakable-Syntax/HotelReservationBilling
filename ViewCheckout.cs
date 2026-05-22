using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelReservationBilling
{
    public partial class ViewCheckout : Form
    {
        public ViewCheckout()
        {
            InitializeComponent(); FillCheckout();
        }

        public void FillCheckout()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from checkouthistory order by guest_start_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); checkoutHistoryTable.DataSource = table;
            checkoutHistoryTable.AllowUserToAddRows = false;
        }

        public void SearchCheckout(string name, string room, string type, string startdate, string enddate)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains("\\") || name.Contains("/")) { name = "%"; }
            if (string.IsNullOrWhiteSpace(room) || room.Contains("\\") || room.Contains("/")) { room = "%"; }
            if (string.IsNullOrWhiteSpace(type) || type.Contains("\\") || type.Contains("/")) { type = "%"; }
            if (string.IsNullOrWhiteSpace(startdate) || startdate.Contains("\\") || startdate.Contains("/")) { startdate = "%"; }
            if (string.IsNullOrWhiteSpace(enddate) || enddate.Contains("\\") || enddate.Contains("/")) { enddate = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from checkouthistory where guest_name LIKE '{name}' and guest_room_occupied LIKE '{room}' and guest_type LIKE '{type}' and guest_start_date LIKE '{startdate}' and guest_end_date LIKE '{enddate}' order by guest_start_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); checkoutHistoryTable.DataSource = table;
            checkoutHistoryTable.AllowUserToAddRows = false;
        }

        public void SearchCheckout2(string searchVal)
        {
            if (searchVal.Contains("\\") || searchVal.Contains("/")) { searchVal = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_gender as 'Guest Gender', guest_age as 'Guest Age', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number (Mobile)', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_start_date as 'Guest Start Rent Date', guest_end_date as 'Guest End Rent Date', guest_totalcharge as 'Guest Total Additional Charge (PHP)', guest_remaincharge as 'Guest Remaining Balance (PHP)', guest_payment as 'Guest Payment Amount (PHP)', guest_change as 'Guest Change Amount (PHP)', guest_type as 'Guest Type' from checkouthistory where concat(guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) LIKE '%{searchVal}%' order by guest_start_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); checkoutHistoryTable.DataSource = table;
            checkoutHistoryTable.AllowUserToAddRows = false;
        }
        private void guestName_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            SearchCheckout(guestName.Text, room, type, startdate, enddate);
        }

        private void guestStartDate_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string name = guestName.Text;
            string enddate = guestEndDate.Text;
            SearchCheckout(name, room, type, guestStartDate.Text, enddate);
        }

        private void guestEndDate_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string name = guestName.Text;
            SearchCheckout(name, room, type, startdate, guestEndDate.Text);
        }

        private void guestRoom_TextChanged(object sender, EventArgs e)
        {
            string type = guestType.Text;
            string name = guestName.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            SearchCheckout(name, guestRoom.Text, type, startdate, enddate);
        }

        private void guestType_TextChanged(object sender, EventArgs e)
        {
            string name = guestName.Text;
            string room = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            SearchCheckout(name, room, guestType.Text, startdate, enddate);
        }

        private void backButton_Click(object sender, EventArgs e) { this.Close(); }

        private void otherDetailSearch_TextChanged(object sender, EventArgs e) { SearchCheckout2(otherDetailSearch.Text); }
    }
}
