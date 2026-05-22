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
    public partial class ManageRoom : Form
    {
        public ManageRoom()
        {
            InitializeComponent();
            FillData();
        }

        public void FillData()
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

        private void addRoomButton_Click(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox.Text;
            string roomprice = roomPriceBox.Text;
            string roomtype = roomTypeBox.Text;
            string roomfloor = roomFloorBox.Text;
            double room_price = 0;
            int room_floor = 0, room_number = 0;
            bool canContinue = true;
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            if (string.IsNullOrWhiteSpace(roomnumber) || string.IsNullOrWhiteSpace(roomprice) || string.IsNullOrWhiteSpace(roomfloor) || string.IsNullOrWhiteSpace(roomtype))
            {
                canContinue = false;
                string title1 = "Details cannot be left blank";
                string message1 = "Please ensure that all boxes have data in them, blank details are not allowed.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(roomnumber, out room_number) || room_number < 0)
            {
                canContinue = false;
                string title1 = "Invalid room number";
                string message1 = "Please ensure that the room number is correct, only numbers are accepted.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(roomfloor, out room_floor) || room_floor < 1)
            {
                canContinue = false;
                string title1 = "Invalid room floor";
                string message1 = "Please ensure that the room floor is correct, only numbers are accepted.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!double.TryParse(roomprice, out room_price) || room_price < 0)
            {
                canContinue = false;
                string title1 = "Invalid room price";
                string message1 = "Please ensure that the room price is correct, only numbers are accepted.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (roomtype != "Minimalist" && roomtype != "Standard" && roomtype != "Room Only" && roomtype != "Junior Suite" && roomtype != "Standard Suite" && roomtype != "Studio" && roomtype != "Deluxe" && roomtype != "Presidential Suite" && roomtype != "Royal Suite")
            {
                canContinue = false;
                string title1 = "Invalid room type";
                string message1 = "Please ensure that the indicated room type is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            string finalroom = "Room " + room_number;
            MySqlCommand command1 = new MySqlCommand($"SELECT COUNT(*) from hotelroom WHERE room_number = '{finalroom}'", connect);
            int result = Convert.ToInt32(command1.ExecuteScalar());
            command1.Connection = connect;
            if (result != 0)
            {
                canContinue = false;
                string title1 = "Room add unsuccessful";
                string message1 = "This room number is unavailable.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                roomNumberBox.Clear();
            }
            if (canContinue == true)
            {
                string finalfloor = "Floor " + room_floor;
                MySqlCommand command = new MySqlCommand($"insert into hotelroom values ('{finalroom}', '{roomtype}', '{finalfloor}', {room_price})", connect);
                command.Connection = connect; command.ExecuteNonQuery();
                string title1 = "Room add successful";
                string message1 = "This room has been successfully registered.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                FillData();
            }
        }

        private void removeRoomButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from hotelroom", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No rooms available";
                string message1 = "There are no rooms to remove.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string roomnumber = roomNumberBox.Text;
            int room_number = 0;
            if (!int.TryParse(roomnumber, out room_number))
            {
                string title1 = "Invalid room number";
                string message1 = "Please ensure that the indicated room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                string finalroom = "Room " + room_number;
                MySqlCommand command5 = new MySqlCommand($"SELECT COUNT(*) from hotelroom where room_number = '{finalroom}'", connect);
                int result9 = Convert.ToInt32(command5.ExecuteScalar());
                command5.Connection = connect;
                if (result9 == 0)
                {
                    string title1 = "Remove room failed";
                    string message1 = "The indicated room number does not exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                }
                else
                {
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand command2 = new MySqlCommand($"delete from hotelroom where room_number = '{finalroom}'", connect);
                    command2.ExecuteNonQuery();
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title1 = "Room removal successful";
                    string message1 = "This room has been successfully removed from the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    FillData();
                }
            }
        }

        private void ManageRoom_Shown(object sender, EventArgs e)
        { this.BringToFront(); this.Activate(); }

        private void updateRoomButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from hotelroom", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No rooms available";
                string message1 = "There are no rooms to update.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string newnumber = newRoomNumber.Text;
            string roomnumber = roomNumberBox.Text;
            string roomprice = roomPriceBox.Text;
            string roomtype = roomTypeBox.Text;
            string roomfloor = roomFloorBox.Text;
            double room_price = 0;
            int room_floor = 0, room_number = 0, new_room_number = 0;
            bool completeDetail = false;
            bool canContinue = true;
            if (!int.TryParse(roomnumber, out room_number) || room_number < 0)
            {
                canContinue = false;
                string title1 = "Invalid room number";
                string message1 = "Please ensure that the room number is correct, only numbers are accepted.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!string.IsNullOrWhiteSpace(newnumber) && !string.IsNullOrWhiteSpace(roomprice) && !string.IsNullOrWhiteSpace(roomfloor) && !string.IsNullOrWhiteSpace(roomtype))
            {
                completeDetail = true;
                if (!int.TryParse(roomfloor, out room_floor) || room_floor < 1)
                {
                    canContinue = false;
                    string title1 = "Invalid room floor";
                    string message1 = "Please ensure that the room floor is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(newnumber, out new_room_number) || room_number < 0)
                {
                    canContinue = false;
                    string title1 = "Invalid new room number";
                    string message1 = "Please ensure that the new room number is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(roomprice, out room_price) || room_price < 0)
                {
                    canContinue = false;
                    string title1 = "Invalid room price";
                    string message1 = "Please ensure that the room price is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (roomtype != "Minimalist" && roomtype != "Standard" && roomtype != "Room Only" && roomtype != "Junior Suite" && roomtype != "Standard Suite" && roomtype != "Studio" && roomtype != "Deluxe" && roomtype != "Presidential Suite" && roomtype != "Royal Suite")
                {
                    canContinue = false;
                    string title1 = "Invalid room type";
                    string message1 = "Please ensure that the indicated room type is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (completeDetail == false)
            {
                if (!string.IsNullOrWhiteSpace(roomprice))
                {
                    if (!double.TryParse(roomprice, out room_price) || room_price < 0)
                    {
                        canContinue = false;
                        string title1 = "Invalid room price";
                        string message1 = "Please ensure that the room price is correct, only numbers are accepted.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(newnumber))
                {
                    if (!int.TryParse(newnumber, out new_room_number) || room_number < 0)
                    {
                        canContinue = false;
                        string title1 = "Invalid new room number";
                        string message1 = "Please ensure that the new room number is correct, only numbers are accepted.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(roomfloor))
                {
                    if (!int.TryParse(roomfloor, out room_floor) || room_floor < 1)
                    {
                        canContinue = false;
                        string title1 = "Invalid room floor";
                        string message1 = "Please ensure that the room floor is correct, only numbers are accepted.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                }
                if (!string.IsNullOrWhiteSpace(roomtype))
                {
                    if (roomtype != "Minimalist" && roomtype != "Standard" && roomtype != "Room Only" && roomtype != "Junior Suite" && roomtype != "Standard Suite" && roomtype != "Studio" && roomtype != "Deluxe" && roomtype != "Presidential Suite" && roomtype != "Royal Suite")
                    {
                        canContinue = false;
                        string title1 = "Invalid room type";
                        string message1 = "Please ensure that the indicated room type is valid.";
                        MessageBoxButtons button = MessageBoxButtons.OK;
                        DialogResult result1 = MessageBox.Show(message1, title1, button);
                        return;
                    }
                }
            }
            string finalroom = "Room " + room_number;
            string finalnewroom = "Room " + new_room_number;
            MySqlCommand command10 = new MySqlCommand($"SELECT COUNT(*) from hotelroom WHERE room_number = '{finalroom}'", connect);
            int result8 = Convert.ToInt32(command10.ExecuteScalar());
            command10.Connection = connect;
            if (result8 == 0 || finalroom == "Room 0")
            {
                canContinue = false;
                string title1 = "Room update unsuccessful";
                string message1 = "This room number is unavailable.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                roomNumberBox.Clear();
            }
            MySqlCommand command11 = new MySqlCommand($"SELECT COUNT(*) from hotelroom WHERE room_number = '{finalnewroom}'", connect);
            int result9 = Convert.ToInt32(command11.ExecuteScalar());
            command11.Connection = connect;
            if (result9 != 0 || finalnewroom == "Room 0")
            {
                canContinue = false;
                string title1 = "Room update unsuccessful";
                string message1 = "This room number already exists.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                roomNumberBox.Clear();
            }
            if (!string.IsNullOrWhiteSpace(roomnumber) && string.IsNullOrWhiteSpace(newnumber) && string.IsNullOrWhiteSpace(roomprice) && string.IsNullOrWhiteSpace(roomfloor) && string.IsNullOrWhiteSpace(roomtype))
            {
                canContinue = false;
                string title1 = "Details are missing";
                string message1 = "Please ensure that at least 1 detail is not empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
            }
            if (canContinue == true)
            {
                MySqlCommand command7 = new MySqlCommand();
                MySqlCommand command2 = new MySqlCommand();
                MySqlCommand command3 = new MySqlCommand();
                MySqlCommand command4 = new MySqlCommand();
                if (completeDetail == true) 
                {
                    string title21 = "Warning!";
                    string message21 = "Please ensure first that no one is currently occupying this room!\nAre you sure you want to continue editing the room number?";
                    MessageBoxButtons button21 = MessageBoxButtons.YesNo;
                    DialogResult result21 = MessageBox.Show(message21, title21, button21);
                    if (result21 == DialogResult.No) { return; }
                    string finalfloor = "Floor " + room_floor;
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    command7 = new MySqlCommand($"update hotelroom set room_number = '{finalnewroom}', room_type = '{roomtype}', room_floor = '{finalfloor}', room_price = {room_price} where room_number = '{finalroom}'", connect);
                    command7.Connection = connect; command7.ExecuteNonQuery();
                    MySqlCommand command14 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command14.Connection = connect; command14.ExecuteNonQuery();
                    roomNumberBox.Clear(); roomPriceBox.Clear(); roomFloorBox.Clear(); roomTypeBox.Clear();
                }
                else if (completeDetail == false)
                {
                    if (!string.IsNullOrWhiteSpace(newnumber))
                    {
                        string title20 = "Warning!";
                        string message20 = "Please ensure first that no one is currently occupying this room!\nAre you sure you want to continue editing the room number?";
                        MessageBoxButtons button20 = MessageBoxButtons.YesNo;
                        DialogResult result20 = MessageBox.Show(message20, title20, button20);
                        if (result20 == DialogResult.No) { return; }
                        MySqlCommand command9 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                        command9.Connection = connect; command9.ExecuteNonQuery();
                        MySqlCommand command8 = new MySqlCommand($"update hotelroom set room_number = '{finalnewroom}' where room_number = '{finalroom}'", connect);
                        command8.Connection = connect; command8.ExecuteNonQuery();
                        MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                        command12.Connection = connect; command12.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(roomprice)) 
                    {
                        command2 = new MySqlCommand($"update hotelroom set room_price = {room_price} where room_number = '{finalroom}'", connect);
                        command2.Connection = connect; command2.ExecuteNonQuery(); roomPriceBox.Clear();
                    }
                    if (!string.IsNullOrWhiteSpace(roomtype)) 
                    {
                        command3 = new MySqlCommand($"update hotelroom set room_type = '{roomtype}' where room_number = '{finalroom}'", connect);
                        command3.Connection = connect; command3.ExecuteNonQuery(); roomTypeBox.Clear();
                    }
                    if (!string.IsNullOrWhiteSpace(roomfloor)) 
                    {
                        string finalfloor = "Floor " + room_floor;
                        command4 = new MySqlCommand($"update hotelroom set room_floor = '{finalfloor}' where room_number = '{finalroom}'", connect);
                        command4.Connection = connect; command4.ExecuteNonQuery(); roomFloorBox.Clear();
                    }
                }
                string title1 = "Room update successful";
                string message1 = "This room has been successfully updated.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                FillData();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        { this.Close(); }

        public void SearchData(string searchVal)
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

        private void searchBox_TextChanged(object sender, EventArgs e)
        { SearchData(searchBox.Text); }

        private void findData_Click(object sender, EventArgs e)
        {
            string roomnumber = roomNumberBox.Text;
            int room_number = 0;
            if (!int.TryParse(roomnumber, out room_number) || room_number < 0)
            {
                string title1 = "Invalid room number";
                string message1 = "Please ensure that the room number is correct, only numbers are accepted.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string final_room = "Room " + room_number;
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select * from hotelroom where room_number = '{final_room}'", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                string title1 = "No data found";
                string message1 = "The room number does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                newRoomNumber.Text = table.Rows[0][0].ToString();
                roomFloorBox.Text = table.Rows[0][1].ToString();
                roomTypeBox.Text = table.Rows[0][2].ToString();
                roomPriceBox.Text = table.Rows[0][3].ToString();
            }
        }
    }
}
