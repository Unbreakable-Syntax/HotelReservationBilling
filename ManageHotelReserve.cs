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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using MySqlX.XDevAPI.Relational;
using System.Runtime.Remoting.Contexts;

namespace HotelReservationBilling
{
    public partial class ManageHotelReserve : Form
    {
        public ManageHotelReserve()
        {
            InitializeComponent();
            FillRoom(); FillOccupant(); DefaultSearch(); FillAdditional();
        }
        public void FillRoom()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select room_number as 'Room Number', room_type as 'Room Type', room_floor as 'Room Floor', room_price as 'Room Price (PHP)' from hotelroom where room_number != 'Room 0' order by room_number", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); roomDataTable.DataSource = table;
            roomDataTable.AllowUserToAddRows = false;
            roomDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }

        public void FillOccupant()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select person_name as 'Name', person_age as 'Age', person_gender as 'Gender', person_birthdate as 'Birthdate', person_national as 'Nationality', person_religion as 'Religion', person_contact_number as 'Contact Number', person_down_pay as 'Paid Balance (PHP)', person_remain_bal as 'Remaining Balance (PHP)', person_total_bal as 'Total Balance (PHP)', person_change as 'Change (PHP)', person_orig_rate as 'Original Room Rate', person_discount_rate as 'Discounted Room Rate', parking_rate as 'Parking Rate (PHP)', room_number_occupied as 'Occupied Room Number', room_type as 'Room Type', number_of_nights as 'Number of Nights', number_of_additional_guests as 'Number of Additional Guests', guest_charge as 'Additional Guest Charge (PHP)', start_rent as 'Start Rent Date', end_rent as 'End Rent Date' from occupantdata where start_rent != '1950-01-01' and end_rent != '1950-01-02' order by start_rent, end_rent", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); occupantDataTable.DataSource = table;
            occupantDataTable.AllowUserToAddRows = false;
            occupantDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        public void FillAdditional()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select guest_name as 'Guest Name', guest_age as 'Guest Age', guest_gender as 'Guest Gender', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number', guest_primary_booker as 'Primary Booker', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_additional_charge as 'Additional Guest Charge (PHP)', guest_parking_fee as 'Guest Parking Fee', guest_start_date as 'Start Rent Date', guest_end_date as 'End Rent Date' from additionalguest order by guest_start_date, guest_end_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); addGuestDataTable.DataSource = table;
            addGuestDataTable.AllowUserToAddRows = false;
            addGuestDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        public void SearchRoom(string searchVal)
        {
            if (searchVal.Contains("\\") || searchVal.Contains("/")) { searchVal = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select room_number as 'Room Number', room_type as 'Room Type', room_floor as 'Room Floor', room_price as 'Room Price (PHP)' from hotelroom where concat(room_number, room_floor, room_price, room_type) like '%{searchVal}%' and room_number != 'Room 0' order by room_number", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); roomDataTable.DataSource = table;
            roomDataTable.AllowUserToAddRows = false;
            roomDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }

        public void SearchOccupant(string name, string room, string start_date, string end_date)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains("\\") || name.Contains("/")) { name = "%"; }
            if (string.IsNullOrWhiteSpace(start_date) || start_date.Contains("\\") || start_date.Contains("/")) { start_date = "%"; }
            if (string.IsNullOrWhiteSpace(end_date) || end_date.Contains("\\") || end_date.Contains("/")) { end_date = "%"; }
            if (string.IsNullOrWhiteSpace(room) || room.Contains("\\") || room.Contains("/")) { room = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select person_name as 'Name', person_age as 'Age', person_gender as 'Gender', person_birthdate as 'Birthdate', person_national as 'Nationality', person_religion as 'Religion', person_contact_number as 'Contact Number', person_down_pay as 'Paid Balance (PHP)', person_remain_bal as 'Remaining Balance (PHP)', person_total_bal as 'Total Balance (PHP)', person_change as 'Change (PHP)', person_orig_rate as 'Original Room Rate', person_discount_rate as 'Discounted Room Rate', parking_rate as 'Parking Rate', room_number_occupied as 'Occupied Room Number', room_type as 'Room Type', number_of_nights as 'Number of Nights', number_of_additional_guests as 'Number of Additional Guests', guest_charge as 'Additional Guest Charge (PHP)', start_rent as 'Start Rent Date', end_rent as 'End Rent Date' from occupantdata where person_name LIKE '{name}' and start_rent LIKE '{start_date}' and end_rent LIKE '{end_date}' and room_number_occupied LIKE '{room}' order by person_name", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); occupantDataTable.DataSource = table;
            occupantDataTable.AllowUserToAddRows = false;
            occupantDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        public void SearchAdditional(string guestname, string primaryname, string room, string start_date, string end_date)
        {
            if (string.IsNullOrWhiteSpace(guestname) || guestname.Contains("\\") || guestname.Contains("/")) { guestname = "%"; }
            if (string.IsNullOrWhiteSpace(primaryname) || primaryname.Contains("\\") || primaryname.Contains("/")) { primaryname = "%"; }
            if (string.IsNullOrWhiteSpace(start_date) || start_date.Contains("\\") || start_date.Contains("/")) { start_date = "%"; }
            if (string.IsNullOrWhiteSpace(end_date) || end_date.Contains("\\") || end_date.Contains("/")) { end_date = "%"; }
            if (string.IsNullOrWhiteSpace(room) || room.Contains("\\") || room.Contains("/")) { room = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_age as 'Guest Age', guest_gender as 'Guest Gender', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number', guest_primary_booker as 'Primary Booker', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_additional_charge as 'Additional Guest Charge (PHP)', guest_parking_fee as 'Guest Parking Fee', guest_start_date as 'Start Rent Date', guest_end_date as 'End Rent Date' from additionalguest where guest_name LIKE '{guestname}' and guest_primary_booker LIKE '{primaryname}' and guest_room_occupied LIKE '{room}' and guest_start_date LIKE '{start_date}' and guest_end_date LIKE '{end_date}' order by guest_name", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); addGuestDataTable.DataSource = table;
            addGuestDataTable.AllowUserToAddRows = false;
            addGuestDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        private void ManageHotelReserve_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate(); FillRoom(); FillOccupant(); FillAdditional();
        }

        private void roomSearch_TextChanged(object sender, EventArgs e)
        { SearchRoom(roomSearch.Text); }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            string startDate = startDateBox.Text;
            string endDate = endDateBox1.Text;
            string roomNumber = roomBox.Text;
            SearchOccupant(nameBox.Text, roomNumber, startDate, endDate); 
        }

        private void roomBox_TextChanged(object sender, EventArgs e)
        {
            string startDate = startDateBox.Text;
            string endDate = endDateBox1.Text;
            string name = nameBox.Text;
            SearchOccupant(name, roomBox.Text, startDate, endDate);
        }

        private void startDateBox_TextChanged(object sender, EventArgs e)
        {
            string roomNumber = roomBox.Text;
            string endDate = endDateBox1.Text;
            string name = nameBox.Text;
            SearchOccupant(name, roomNumber, startDateBox.Text, endDate);
        }

        private void endDateBox_TextChanged(object sender, EventArgs e)
        {
            string roomNumber = roomBox.Text;
            string startDate = startDateBox.Text;
            string name = nameBox.Text;
            SearchOccupant(name, roomNumber, startDate, endDateBox.Text);
        }

        private void primaryNameBox1_TextChanged(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox1.Text;
            string addname = addGuestName.Text;
            string start_date = startDateBox1.Text;
            string end_date = endDateBox1.Text;
            SearchAdditional(addname, primaryNameBox1.Text, roomnumber, start_date, end_date);
        }

        private void roomNumberBox1_TextChanged(object sender, EventArgs e)
        {
            string primaryname = primaryNameBox1.Text;
            string addname = addGuestName.Text;
            string start_date = startDateBox1.Text;
            string end_date = endDateBox1.Text;
            SearchAdditional(addname, primaryname, roomNumberBox1.Text, start_date, end_date);
        }

        private void addGuestName_TextChanged(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox1.Text;
            string primaryname = primaryNameBox1.Text;
            string start_date = startDateBox1.Text;
            string end_date = endDateBox1.Text;
            SearchAdditional(addGuestName.Text, primaryname, roomnumber, start_date, end_date);
        }

        private void startDateBox1_TextChanged(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox1.Text;
            string addname = addGuestName.Text;
            string primaryname = primaryNameBox1.Text;
            string end_date = endDateBox1.Text;
            SearchAdditional(addname, primaryname, roomnumber, startDateBox1.Text, end_date);
        }

        private void endDateBox1_TextChanged(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox1.Text;
            string addname = addGuestName.Text;
            string start_date = startDateBox1.Text;
            string primaryname = primaryNameBox1.Text;
            SearchAdditional(addname, primaryname, roomnumber, start_date, endDateBox1.Text);
        }

        private void searchOccupantMode_Click(object sender, EventArgs e)
        {
            roomDataTable.Visible = false;
            roomSearch.Visible = false;
            roomSearchLabel.Visible = false;
            occupantDataTable.Visible = true;
            roomLabel.Visible = true;
            roomBox.Visible = true;
            startLabel.Visible = true;
            startDateBox.Visible = true;
            endLabel.Visible = true;
            nameLabel.Visible = true;
            nameBox.Visible = true;
            endDateBox.Visible = true;

            primaryNameLabel1.Visible = false;
            roomNameLabel1.Visible = false;
            addNameLabel.Visible = false;
            startDateLabel1.Visible = false;
            endDateLabel1.Visible = false;
            primaryNameBox1.Visible = false;
            roomNumberBox1.Visible = false;
            addGuestName.Visible = false;
            startDateBox1.Visible = false;
            endDateBox1.Visible = false;
            addGuestDataTable.Visible = false;
        }

        private void DefaultSearch()
        {
            roomDataTable.Visible = false;
            roomSearch.Visible = false;
            roomSearchLabel.Visible = false;
            occupantDataTable.Visible = true;
            roomLabel.Visible = true;
            roomBox.Visible = true;
            startLabel.Visible = true;
            startDateBox.Visible = true;
            endLabel.Visible = true;
            nameLabel.Visible = true;
            nameBox.Visible = true;
            endDateBox.Visible = true;

            primaryNameLabel1.Visible = false;
            roomNameLabel1.Visible = false;
            addNameLabel.Visible = false;
            startDateLabel1.Visible = false;
            endDateLabel1.Visible = false;
            primaryNameBox1.Visible = false;
            roomNumberBox1.Visible = false;
            addGuestName.Visible = false;
            startDateBox1.Visible = false;
            endDateBox1.Visible = false;
            addGuestDataTable.Visible = false;
        }

        private void searchRoomMode_Click(object sender, EventArgs e)
        {
            roomDataTable.Visible = true;
            roomSearch.Visible = true;
            roomSearchLabel.Visible = true;
            occupantDataTable.Visible = false;
            roomLabel.Visible = false;
            roomBox.Visible = false;
            startLabel.Visible = false;
            startDateBox.Visible = false;
            endLabel.Visible = false;
            nameLabel.Visible = false;
            nameBox.Visible = false;
            endDateBox.Visible = false;

            primaryNameLabel1.Visible = false;
            roomNameLabel1.Visible = false;
            addNameLabel.Visible = false;
            startDateLabel1.Visible = false;
            endDateLabel1.Visible = false;
            primaryNameBox1.Visible = false;
            roomNumberBox1.Visible = false;
            addGuestName.Visible = false;
            startDateBox1.Visible = false;
            endDateBox1.Visible = false;
            addGuestDataTable.Visible = false;
        }

        private void ManageHotelReserve_Load(object sender, EventArgs e)
        {

        }

        private void checkoutOccupant_Click(object sender, EventArgs e)
        {
            string payment = paymentBox.Text;
            string name = occupantName.Text;
            string room = roomNumber.Text;
            int room_check = 0;
            double pay_amount = 0;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(room))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that the details are not empty";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(room))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that the details are not empty";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!string.IsNullOrWhiteSpace(payment) && !double.TryParse(payment, out pay_amount) || pay_amount < 0)
            {
                string title1 = "Invalid payment";
                string message1 = "Please ensure that the payment amount is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                if (!int.TryParse(room, out room_check))
                {
                    string title1 = "Invalid room number";
                    string message1 = "Please check if the room number is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message1, title1, button);
                    return;
                }
                else { room = "Room " + room_check; }
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                MySqlCommand checkName = new MySqlCommand($"SELECT COUNT(*) from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                int result = Convert.ToInt32(checkName.ExecuteScalar());
                checkName.Connection = connect;
                if (result == 0)
                {
                    string title1 = "Nonexistent room number and primary guest name";
                    string message1 = "Please check if the provided details exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message1, title1, button);
                    return;
                }
                else
                {
                    MySqlCommand extract = new MySqlCommand($"select person_total_bal, person_remain_bal from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    extract.ExecuteNonQuery();
                    extract.Connection = connect;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(extract);
                    DataTable table = new DataTable(); string tempremain = "", temptotal = "";
                    adapter.Fill(table); double remainbal = 0, change = 0, totalbal = 0, newremain = 0; ;
                    if (table.Rows.Count > 0)
                    {
                        temptotal = table.Rows[0][1].ToString();
                        tempremain = table.Rows[0][1].ToString(); 
                    }
                    if (!double.TryParse(temptotal, out totalbal)) { return; }
                    if (!double.TryParse(tempremain, out remainbal)) { return; }
                    if (remainbal != 0 && pay_amount <= 0)
                    {
                        string title1 = "Remaining balance not settled";
                        string message1 = "Please pay the remaining balance first before checking out.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result2 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                    if (remainbal == 0 && pay_amount > 0)
                    {
                        string title1 = "Remaining balance already settled";
                        string message1 = "Payment is not required for this guest.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result2 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                    if (remainbal != 0 && pay_amount > 0)
                    {
                        if (remainbal - pay_amount > 0) 
                        {
                            string title1 = "Payment not enough";
                            string message1 = "Please ensure that the payment is enough to settle the balance.";
                            MessageBoxButtons button = MessageBoxButtons.OK;
                            DialogResult result2 = MessageBox.Show(message1, title1, button);
                            return;
                        }
                        if (remainbal - pay_amount == 0) { newremain = remainbal - pay_amount; }
                        if (remainbal - pay_amount < 0) { change = pay_amount - remainbal; }
                    }
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand updatebalance = new MySqlCommand($"update occupantdata set person_down_pay = person_down_pay + {pay_amount}, person_remain_bal = {newremain}, person_change = person_change + {change} where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    updatebalance.ExecuteNonQuery(); CheckoutReceipt(name, room);
                    MySqlCommand checkAdditional = new MySqlCommand($"SELECT COUNT(*) from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                    int result10 = Convert.ToInt32(checkAdditional.ExecuteScalar());
                    checkAdditional.Connection = connect;
                    if (result10 != 0)
                    {
                        MySqlCommand copydata2 = new MySqlCommand($"insert into checkouthistory (guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) select guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, guest_additional_charge + guest_parking_fee, {remainbal}, {pay_amount}, {change}, 'Additional' from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                        copydata2.ExecuteNonQuery();
                        copydata2.Connection = connect;
                        MySqlCommand deletedata2 = new MySqlCommand($"delete from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                        deletedata2.ExecuteNonQuery();
                        deletedata2.Connection = connect;
                    }
                    MySqlCommand copydata = new MySqlCommand($"insert into checkouthistory (guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) select person_name, person_gender, person_age, person_birthdate, person_national, person_religion, person_contact_number, room_number_occupied, room_type, start_rent, end_rent, person_total_bal, {remainbal}, {pay_amount}, {change}, 'Primary' from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    copydata.ExecuteNonQuery();
                    copydata.Connection = connect;
                    MySqlCommand deletedata = new MySqlCommand($"delete from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    deletedata.ExecuteNonQuery();
                    deletedata.Connection = connect;
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title34 = "Check out successful";
                    string message34 = "Guest has successfully checked out of the hotel.\nPlease give the receipt before the guest leaves the desk.";
                    MessageBoxButtons button34 = MessageBoxButtons.OK;
                    DialogResult result34 = MessageBox.Show(message34, title34, button34);
                    roomNumber.Clear(); occupantName.Clear(); paymentBox.Clear();
                    return;
                }
            }      
        }

        private void backButton_Click(object sender, EventArgs e)
        { this.Close(); }

        private void addAdditional_Click(object sender, EventArgs e)
        {
            AdditionalGuest newAdditional = new AdditionalGuest();
            newAdditional.Show();
        }

        private void searchAdditional_Click(object sender, EventArgs e)
        {
            primaryNameLabel1.Visible = true;
            roomNameLabel1.Visible = true;
            addNameLabel.Visible = true;
            startDateLabel1.Visible = true;
            endDateLabel1.Visible = true;
            primaryNameBox1.Visible = true;
            roomNumberBox1.Visible = true;
            addGuestName.Visible = true;
            startDateBox1.Visible = true;
            endDateBox1.Visible = true;
            addGuestDataTable.Visible = true;

            roomDataTable.Visible = false;
            roomSearch.Visible = false;
            roomSearchLabel.Visible = false;
            occupantDataTable.Visible = false;
            roomLabel.Visible = false;
            roomBox.Visible = false;
            startLabel.Visible = false;
            startDateBox.Visible = false;
            endLabel.Visible = false;
            nameLabel.Visible = false;
            nameBox.Visible = false;
            endDateBox.Visible = false;
        }

        private void reserveRoomButton_Click(object sender, EventArgs e)
        {
            PrimaryGuest newPrimary = new PrimaryGuest();
            newPrimary.Show(); this.SendToBack();
        }

        private void cancelReserve_Click(object sender, EventArgs e)
        {
            string name = occupantName.Text;
            string room = roomNumber.Text;
            if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(room))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that the details are not empty";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(room))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that the details are not empty";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                MySqlCommand checkName = new MySqlCommand($"SELECT COUNT(*) from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                int result = Convert.ToInt32(checkName.ExecuteScalar());
                checkName.Connection = connect;
                if (result == 0)
                {
                    string title1 = "Nonexistent room number and primary guest name";
                    string message1 = "Please check if the provided details exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message1, title1, button);
                    return;
                }
                else
                {
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand checkAdditional = new MySqlCommand($"SELECT COUNT(*) from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                    int result10 = Convert.ToInt32(checkAdditional.ExecuteScalar());
                    checkAdditional.Connection = connect;
                    if (result10 != 0)
                    {
                        MySqlCommand copydata2 = new MySqlCommand($"insert into cancelhistory (guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, cancellation_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) select guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, curdate(), guest_additional_charge + guest_parking_fee, guest_additional_charge + guest_parking_fee, 0, 0, 'Additional' from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                        copydata2.ExecuteNonQuery();
                        copydata2.Connection = connect;
                        MySqlCommand deletedata2 = new MySqlCommand($"delete from additionalguest where guest_primary_booker = '{name}' and guest_room_occupied = '{room}'", connect);
                        deletedata2.ExecuteNonQuery();
                        deletedata2.Connection = connect;
                    }
                    MySqlCommand copydata = new MySqlCommand($"insert into cancelhistory (guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_room_occupied, room_type, guest_start_date, guest_end_date, cancellation_date, guest_totalcharge, guest_remaincharge, guest_payment, guest_change, guest_type) select person_name, person_gender, person_age, person_birthdate, person_national, person_religion, person_contact_number, room_number_occupied, room_type, start_rent, end_rent, curdate(), person_total_bal, person_remain_bal, person_down_pay, person_change, 'Primary' from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    copydata.ExecuteNonQuery();
                    copydata.Connection = connect;
                    MySqlCommand deletedata = new MySqlCommand($"delete from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                    deletedata.ExecuteNonQuery();
                    deletedata.Connection = connect;
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title34 = "Reservation cancel successful";
                    string message34 = "The reservation for this guest has been successfully cancelled.";
                    MessageBoxButtons button34 = MessageBoxButtons.OK;
                    DialogResult result34 = MessageBox.Show(message34, title34, button34);
                    roomNumber.Clear(); occupantName.Clear();
                    return;
                }
            }
        }

        public static void CheckoutReceipt(string occupantname, string roomnumber)
        {
            string roomtype, guestname = occupantname, guestadditional;
            int roomprice, discountrate, guestparkingfee, totalamount;
            string guestnights, startdate, enddate;
            int payment, change, guestcharge;
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand extractdetails = new MySqlCommand($"select person_down_pay, person_change, person_total_bal, person_orig_rate, person_discount_rate, parking_rate, room_type, number_of_nights, number_of_additional_guests, guest_charge, start_rent, end_rent from occupantdata where person_name = '{occupantname}' and room_number_occupied = '{roomnumber}'", connect);
            extractdetails.ExecuteNonQuery();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(extractdetails);
            DataTable table3 = new DataTable(); adapter3.Fill(table3);
            if (table3.Rows.Count <= 0)
            {
                string title1 = "No data found";
                string message1 = "The occupant does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                payment = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][0].ToString()));
                change = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][1].ToString()));
                totalamount = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][2].ToString()));
                roomprice = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][3].ToString()));
                discountrate = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][4].ToString()));
                guestparkingfee = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][5].ToString()));
                roomtype = table3.Rows[0][6].ToString();
                guestnights = table3.Rows[0][7].ToString();
                guestadditional = table3.Rows[0][8].ToString();             
                guestcharge = Convert.ToInt32(Convert.ToDouble(table3.Rows[0][9].ToString()));
                startdate = table3.Rows[0][10].ToString();
                startdate = DateTime.Parse(startdate).ToString("yyyy-MM-dd");
                enddate = table3.Rows[0][11].ToString();
                enddate = DateTime.Parse(enddate).ToString("yyyy-MM-dd");
            }
            string room_pricestring = roomprice.ToString();
            string guestparkingstring = guestparkingfee.ToString();
            string discountratestring = discountrate.ToString();
            string totalstring = totalamount.ToString();
            string paymentstring = payment.ToString();
            string changestring = change.ToString();
            string additionalguestcharge = guestcharge.ToString();
            string roomspace = "", roomtypespace = "", roompricespace = "", guestchargespace = "";
            string guestnamespace = "", guestnightspace = "", guestnumberspace = "";
            string guestparkingspace = "", discountratespace = "";
            string totalspace = "", paymentspace = "", changespace = "";
            switch (additionalguestcharge.Length)
            {
                case 9: guestchargespace = ""; break;
                case 8: guestchargespace = " "; break;
                case 7: guestchargespace = "  "; break;
                case 6: guestchargespace = "   "; break;
                case 5: guestchargespace = "    "; break;
                case 4: guestchargespace = "     "; break;
                case 3: guestchargespace = "      "; break;
                case 2: guestchargespace = "       "; break;
                case 1: guestchargespace = "        "; break;
            }
            switch (roomnumber.Length)
            {
                case 12: roomspace = ""; break;
                case 11: roomspace = " "; break;
                case 10: roomspace = "  "; break;
                case 9: roomspace = "   "; break;
                case 8: roomspace = "    "; break;
                case 7: roomspace = "     "; break;
                case 6: roomspace = "      "; break;
                case 5: roomspace = "       "; break;
                case 4: roomspace = "        "; break;
                case 3: roomspace = "         "; break;
                case 2: roomspace = "          "; break;
                case 1: roomspace = "           "; break;
            }
            switch (roomtype.Length)
            {
                case 37: roomtypespace = ""; break;
                case 36: roomtypespace = " "; break;
                case 35: roomtypespace = "  "; break;
                case 34: roomtypespace = "   "; break;
                case 33: roomtypespace = "    "; break;
                case 32: roomtypespace = "     "; break;
                case 31: roomtypespace = "      "; break;
                case 30: roomtypespace = "       "; break;
                case 29: roomtypespace = "        "; break;
                case 28: roomtypespace = "         "; break;
                case 27: roomtypespace = "          "; break;
                case 26: roomtypespace = "           "; break;
                case 25: roomtypespace = "            "; break;
                case 24: roomtypespace = "             "; break;
                case 23: roomtypespace = "              "; break;
                case 22: roomtypespace = "               "; break;
                case 21: roomtypespace = "                "; break;
                case 20: roomtypespace = "                 "; break;
                case 19: roomtypespace = "                  "; break;
                case 18: roomtypespace = "                   "; break;
                case 17: roomtypespace = "                    "; break;
                case 16: roomtypespace = "                     "; break;
                case 15: roomtypespace = "                      "; break;
                case 14: roomtypespace = "                       "; break;
                case 13: roomtypespace = "                        "; break;
                case 12: roomtypespace = "                         "; break;
                case 11: roomtypespace = "                          "; break;
                case 10: roomtypespace = "                           "; break;
                case 9: roomtypespace = "                            "; break;
                case 8: roomtypespace = "                             "; break;
                case 7: roomtypespace = "                              "; break;
                case 6: roomtypespace = "                               "; break;
                case 5: roomtypespace = "                                "; break;
                case 4: roomtypespace = "                                 "; break;
                case 3: roomtypespace = "                                  "; break;
                case 2: roomtypespace = "                                   "; break;
                case 1: roomtypespace = "                                    "; break;
            }
            switch (room_pricestring.Length)
            {
                case 9: roompricespace = ""; break;
                case 8: roompricespace = " "; break;
                case 7: roompricespace = "  "; break;
                case 6: roompricespace = "   "; break;
                case 5: roompricespace = "    "; break;
                case 4: roompricespace = "     "; break;
                case 3: roompricespace = "      "; break;
                case 2: roompricespace = "       "; break;
                case 1: roompricespace = "        "; break;
            }
            switch (guestname.Length)
            {
                case 37: guestnamespace = ""; break;
                case 36: guestnamespace = " "; break;
                case 35: guestnamespace = "  "; break;
                case 34: guestnamespace = "   "; break;
                case 33: guestnamespace = "    "; break;
                case 32: guestnamespace = "     "; break;
                case 31: guestnamespace = "      "; break;
                case 30: guestnamespace = "       "; break;
                case 29: guestnamespace = "        "; break;
                case 28: guestnamespace = "         "; break;
                case 27: guestnamespace = "          "; break;
                case 26: guestnamespace = "           "; break;
                case 25: guestnamespace = "            "; break;
                case 24: guestnamespace = "             "; break;
                case 23: guestnamespace = "              "; break;
                case 22: guestnamespace = "               "; break;
                case 21: guestnamespace = "                "; break;
                case 20: guestnamespace = "                 "; break;
                case 19: guestnamespace = "                  "; break;
                case 18: guestnamespace = "                   "; break;
                case 17: guestnamespace = "                    "; break;
                case 16: guestnamespace = "                     "; break;
                case 15: guestnamespace = "                      "; break;
                case 14: guestnamespace = "                       "; break;
                case 13: guestnamespace = "                        "; break;
                case 12: guestnamespace = "                         "; break;
                case 11: guestnamespace = "                          "; break;
                case 10: guestnamespace = "                           "; break;
                case 9: guestnamespace = "                            "; break;
                case 8: guestnamespace = "                             "; break;
                case 7: guestnamespace = "                              "; break;
                case 6: guestnamespace = "                               "; break;
                case 5: guestnamespace = "                                "; break;
                case 4: guestnamespace = "                                 "; break;
                case 3: guestnamespace = "                                  "; break;
                case 2: guestnamespace = "                                   "; break;
                case 1: guestnamespace = "                                    "; break;
            }
            switch (guestnights.Length)
            {
                case 16: guestnightspace = ""; break;
                case 15: guestnightspace = " "; break;
                case 14: guestnightspace = "  "; break;
                case 13: guestnightspace = "   "; break;
                case 12: guestnightspace = "    "; break;
                case 11: guestnightspace = "     "; break;
                case 10: guestnightspace = "      "; break;
                case 9: guestnightspace = "       "; break;
                case 8: guestnightspace = "        "; break;
                case 7: guestnightspace = "         "; break;
                case 6: guestnightspace = "          "; break;
                case 5: guestnightspace = "           "; break;
                case 4: guestnightspace = "            "; break;
                case 3: guestnightspace = "             "; break;
                case 2: guestnightspace = "              "; break;
                case 1: guestnightspace = "               "; break;
            }
            switch (guestadditional.Length)
            {
                case 16: guestnumberspace = ""; break;
                case 15: guestnumberspace = " "; break;
                case 14: guestnumberspace = "  "; break;
                case 13: guestnumberspace = "   "; break;
                case 12: guestnumberspace = "    "; break;
                case 11: guestnumberspace = "     "; break;
                case 10: guestnumberspace = "      "; break;
                case 9: guestnumberspace = "       "; break;
                case 8: guestnumberspace = "        "; break;
                case 7: guestnumberspace = "         "; break;
                case 6: guestnumberspace = "          "; break;
                case 5: guestnumberspace = "           "; break;
                case 4: guestnumberspace = "            "; break;
                case 3: guestnumberspace = "             "; break;
                case 2: guestnumberspace = "              "; break;
                case 1: guestnumberspace = "               "; break;
            }
            switch (guestparkingstring.Length)
            {
                case 9: guestparkingspace = ""; break;
                case 8: guestparkingspace = " "; break;
                case 7: guestparkingspace = "  "; break;
                case 6: guestparkingspace = "   "; break;
                case 5: guestparkingspace = "    "; break;
                case 4: guestparkingspace = "     "; break;
                case 3: guestparkingspace = "      "; break;
                case 2: guestparkingspace = "       "; break;
                case 1: guestparkingspace = "        "; break;
            }
            switch (discountratestring.Length)
            {
                case 9: discountratespace = ""; break;
                case 8: discountratespace = " "; break;
                case 7: discountratespace = "  "; break;
                case 6: discountratespace = "   "; break;
                case 5: discountratespace = "    "; break;
                case 4: discountratespace = "     "; break;
                case 3: discountratespace = "      "; break;
                case 2: discountratespace = "       "; break;
                case 1: discountratespace = "        "; break;
            }
            switch (totalstring.Length)
            {
                case 9: totalspace = ""; break;
                case 8: totalspace = " "; break;
                case 7: totalspace = "  "; break;
                case 6: totalspace = "   "; break;
                case 5: totalspace = "    "; break;
                case 4: totalspace = "     "; break;
                case 3: totalspace = "      "; break;
                case 2: totalspace = "       "; break;
                case 1: totalspace = "        "; break;
            }
            switch (paymentstring.Length)
            {
                case 9: paymentspace = ""; break;
                case 8: paymentspace = " "; break;
                case 7: paymentspace = "  "; break;
                case 6: paymentspace = "   "; break;
                case 5: paymentspace = "    "; break;
                case 4: paymentspace = "     "; break;
                case 3: paymentspace = "      "; break;
                case 2: paymentspace = "       "; break;
                case 1: paymentspace = "        "; break;
            }
            switch (changestring.Length)
            {
                case 9: changespace = ""; break;
                case 8: changespace = " "; break;
                case 7: changespace = "  "; break;
                case 6: changespace = "   "; break;
                case 5: changespace = "    "; break;
                case 4: changespace = "     "; break;
                case 3: changespace = "      "; break;
                case 2: changespace = "       "; break;
                case 1: changespace = "        "; break;
            }
            string receiptformat = "", tempformat;
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            tempformat = "\n|                Hotel Reservation Receipt                 |";
            receiptformat += tempformat;
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Room:                                       {roomspace}{roomnumber} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Room Type:         {roomtypespace}{roomtype} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Room Price:                                {roompricespace}PHP {roomprice} |");
            receiptformat += tempformat;
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Name:              {guestnamespace}{guestname} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Number of nights:                       {guestnightspace}{guestnights} |");
            receiptformat += tempformat;
            if (guestadditional != "0 guest")
            {
                tempformat = string.Format($"\n| Additional guests:                      {guestnumberspace}{guestadditional} |");
                receiptformat += tempformat;
            }
            tempformat = string.Format($"\n| Parking fee:                               {guestparkingspace}PHP {guestparkingfee} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Start date:                                   {startdate} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| End date:                                     {enddate} |");
            receiptformat += tempformat;
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            if (guestcharge > 0)
            {
                tempformat = string.Format($"\n| Additional guest charge:                   {guestchargespace}PHP {guestcharge} |");
                receiptformat += tempformat;
            }
            if (discountrate != roomprice)
            {
                tempformat = string.Format($"\n| Discounted rent rate:                      {discountratespace}PHP {discountrate} |");
                receiptformat += tempformat;
            }
            tempformat = string.Format($"\n| Total Amount:                              {totalspace}PHP {totalamount} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Payment:                                   {paymentspace}PHP {payment} |");
            receiptformat += tempformat;
            if (change > 0)
            {
                tempformat = string.Format($"\n| Change:                                    {changespace}PHP {change} |");
                receiptformat += tempformat;
            }
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            ReceiptPrint(receiptformat);
            return;
        }

        static void ReceiptPrint(string receipt)
        {
            string receiptname = DateTime.Now.ToString("C\\heckou\\tReceip\\t_yyyyMMdd_HHmmss");
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            string fileName = string.Format("{0}.xml", receiptname);
            XmlSerializer processReceipt = new XmlSerializer(typeof(string));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter receiptFile = XmlWriter.Create(fileName, settings);
            processReceipt.Serialize(receiptFile, receipt, emptyNamespaces);
            receiptFile.Close(); return;
        }

        private void ManageHotelReserve_Enter(object sender, EventArgs e) { FillRoom(); FillOccupant(); FillAdditional(); }

        private void ManageHotelReserve_Activated(object sender, EventArgs e) { FillRoom(); FillOccupant(); FillAdditional(); }
    }
}
