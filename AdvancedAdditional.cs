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
    public partial class AdvancedAdditional : Form
    {
        public AdvancedAdditional()
        {
            InitializeComponent();
        }

        private void AdvancedAdditional_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate();
        }

        private void backButton5_Click(object sender, EventArgs e) { this.Close(); }

        private void fillGuestData_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            string name = guestName.Text;
            string room = roomNumber.Text;
            string primaryname = primaryGuestName.Text;
            MySqlCommand checktable = new MySqlCommand($"SELECT COUNT(*) from additionalguest", connect);
            int result5 = Convert.ToInt32(checktable.ExecuteScalar());
            checktable.Connection = connect;
            if (result5 == 0)
            {
                string title1 = "No guests available";
                string message1 = "There are no guest to extract data from.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(room) || string.IsNullOrWhiteSpace(primaryname) || !room.Contains("Room"))
            {
                string title1 = "Missing details";
                string message1 = "Please ensure that the 3 details (guest name, primary guest name, and room number) are complete.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand extractdata = new MySqlCommand($"select * from additionalguest where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
            extractdata.ExecuteNonQuery(); MySqlDataAdapter adapter = new MySqlDataAdapter(extractdata);
            DataTable table = new DataTable(); adapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                string title1 = "No data found";
                string message1 = "The additional guest based on the 3 provided details do not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                newPrimaryGuestName.Text = table.Rows[0][7].ToString();
                newRoomNumber.Text = table.Rows[0][8].ToString();
                string startdate = table.Rows[0][10].ToString();
                startdate = DateTime.Parse(startdate).ToString("yyyy-MM-dd");
                newGuestStartDate.Text = startdate;
                string enddate = table.Rows[0][11].ToString();
                enddate = DateTime.Parse(enddate).ToString("yyyy-MM-dd");
                newGuestEndDate.Text = enddate;
                newGuestCharge.Text = table.Rows[0][12].ToString();
                newGuestParking.Text = table.Rows[0][13].ToString();
            }
        }

        private void updateButton2_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            string name = guestName.Text;
            string room = roomNumber.Text;
            string primaryname = primaryGuestName.Text;
            MySqlCommand checktable = new MySqlCommand($"SELECT COUNT(*) from additionalguest", connect);
            int result5 = Convert.ToInt32(checktable.ExecuteScalar());
            checktable.Connection = connect;
            if (result5 == 0)
            {
                string title1 = "No guests available";
                string message1 = "There are no guest to update.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(room) || string.IsNullOrWhiteSpace(primaryname) || !room.Contains("Room"))
            {
                string title1 = "Missing details";
                string message1 = "Please ensure that the 3 details (guest name, primary guest name, and room number) are complete.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string newstart = newGuestStartDate.Text;
            string newend = newGuestEndDate.Text;
            string newfee = newGuestCharge.Text;
            string newparking = newGuestParking.Text;
            string newprimary = newPrimaryGuestName.Text;
            string newroomnumber = newRoomNumber.Text;
            double new_charge = 0, new_parking = 0;
            int check_room = 0;
            DateTime checkDate = new DateTime();
            if (!string.IsNullOrWhiteSpace(newprimary) && !string.IsNullOrWhiteSpace(newroomnumber) && !string.IsNullOrWhiteSpace(newstart) && !string.IsNullOrWhiteSpace(newend) && !string.IsNullOrWhiteSpace(newfee) && !string.IsNullOrWhiteSpace(newparking))
            {
                if (!DateTime.TryParse(newstart, out checkDate))
                {
                    string title1 = "Invalid start date";
                    string message1 = "Please check if the start date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(newroomnumber, out check_room) || check_room < 0)
                {
                    string title1 = "Invalid room number";
                    string message1 = "Please check if the room number is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;

                }
                if (newprimary.Length <= 1)
                {
                    string title1 = "Invalid primary guest name";
                    string message1 = "Please check if the primary guest name is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!DateTime.TryParse(newend, out checkDate))
                {
                    string title1 = "Invalid end date";
                    string message1 = "Please check if the end date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(newfee, out new_charge) || new_charge < 0)
                {
                    string title1 = "Invalid guest charge";
                    string message1 = "Please check if the guest charge is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(newparking, out new_parking) || new_parking < 0)
                {
                    string title1 = "Invalid guest parking fee";
                    string message1 = "Please check if the guest parking fee is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(newroomnumber) && !int.TryParse(newroomnumber, out check_room) || check_room < 0)
                {
                    string title1 = "Invalid room number";
                    string message1 = "Please check if the room number is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;

                }
                if (!string.IsNullOrWhiteSpace(newprimary) && newprimary.Length <= 1)
                {
                    string title1 = "Invalid primary guest name";
                    string message1 = "Please check if the primary guest name is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newstart) && !DateTime.TryParse(newstart, out checkDate))
                {
                    string title1 = "Invalid start date";
                    string message1 = "Please check if the start date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newend) && !DateTime.TryParse(newend, out checkDate))
                {
                    string title1 = "Invalid end date";
                    string message1 = "Please check if the end date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newfee) && !double.TryParse(newfee, out new_charge) || new_charge < 0)
                {
                    string title1 = "Invalid guest charge";
                    string message1 = "Please check if the guest charge is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newparking) && !double.TryParse(newparking, out new_parking) || new_parking < 0)
                {
                    string title1 = "Invalid guest parking fee";
                    string message1 = "Please check if the guest parking fee is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(newstart) && string.IsNullOrWhiteSpace(newroomnumber) && string.IsNullOrWhiteSpace(newprimary) && string.IsNullOrWhiteSpace(newend) && string.IsNullOrWhiteSpace(newfee) && string.IsNullOrWhiteSpace(newparking))
            {
                string title1 = "Empty details";
                string message1 = "Please ensure that at least 1 detail is not empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string finalnewroom = "Room " + check_room;
            MySqlCommand extracttype = new MySqlCommand($"select room_type from hotelroom where room_number = '{finalnewroom}'", connect);
            extracttype.ExecuteNonQuery();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(extracttype);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            string roomtype;
            if (table2.Rows.Count <= 0)
            {
                string title1 = "No data found";
                string message1 = "The room number does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            else { roomtype = table2.Rows[0][0].ToString(); }
            MySqlCommand checkexist = new MySqlCommand($"SELECT COUNT(*) from additionalguest where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
            int result8 = Convert.ToInt32(checkexist.ExecuteScalar());
            checkexist.Connection = connect;
            if (!string.IsNullOrWhiteSpace(newprimary))
            {
                MySqlCommand checkexist1 = new MySqlCommand($"SELECT COUNT(*) from occupantdata where person_name = TRIM('{newprimary}')", connect);
                int result9 = Convert.ToInt32(checkexist1.ExecuteScalar());
                checkexist1.Connection = connect;
                if (result9 == 0)
                {
                    string title1 = "Guest update unsuccessful";
                    string message1 = "The primary guest name does not exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(newroomnumber))
            {
                MySqlCommand checkexist2 = new MySqlCommand($"SELECT COUNT(*) from hotelroom where room_number = '{finalnewroom}'", connect);
                int result10 = Convert.ToInt32(checkexist2.ExecuteScalar());
                checkexist2.Connection = connect;
                if (result10 == 0)
                {
                    string title1 = "Guest update unsuccessful";
                    string message1 = "The hotel room number does not exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (result8 == 0)
            {
                string title1 = "Guest update unsuccessful";
                string message1 = "The additional guest based on the 3 provided details do not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(newstart) && !string.IsNullOrWhiteSpace(newroomnumber) && !string.IsNullOrWhiteSpace(newprimary) && !string.IsNullOrWhiteSpace(newend) && !string.IsNullOrWhiteSpace(newfee) && !string.IsNullOrWhiteSpace(newparking))
                {
                    string title1 = "Warning!";
                    string message1 = "Editing the primary guest name and room number could lead to confusion and inaccuracy.\nAre you sure you want to continue editing these 2 details?";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    if (result1 == DialogResult.No) { return; }
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand command1 = new MySqlCommand($"update additionalguest set guest_primary_booker = TRIM('{newprimary}'), guest_room_occupied = '{finalnewroom}', room_type = '{roomtype}', guest_start_date = '{newstart}', guest_end_date = '{newend}', guest_additional_charge = {new_charge}, guest_parking_fee = {new_parking} where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                    command1.Connection = connect; command1.ExecuteNonQuery();
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title50 = "Guest update successful";
                    string message50 = "The details of the additional guest has been updated.";
                    MessageBoxButtons button50 = MessageBoxButtons.OK;
                    DialogResult result50 = MessageBox.Show(message50, title50, button50);
                    guestName.Clear(); newGuestStartDate.Clear(); newRoomNumber.Clear();
                    newGuestEndDate.Clear(); newGuestCharge.Clear(); newGuestParking.Clear();
                    primaryGuestName.Clear(); roomNumber.Clear(); newPrimaryGuestName.Clear();
                    return;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(newprimary))
                    {
                        string title20 = "Warning!";
                        string message20 = "Editing the primary guest name could lead to confusion and inaccuracy.\nAre you sure you want to continue editing the primary guest name?";
                        MessageBoxButtons button20 = MessageBoxButtons.YesNo;
                        DialogResult result20 = MessageBox.Show(message20, title20, button20);
                        if (result20 == DialogResult.No) { return; }
                        MySqlCommand command14 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                        command14.Connection = connect; command14.ExecuteNonQuery();
                        MySqlCommand command1 = new MySqlCommand($"update additionalguest set guest_primary_booker = TRIM('{newprimary}') where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                        command1.Connection = connect; command1.ExecuteNonQuery();
                        MySqlCommand command15 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                        command15.Connection = connect; command15.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(newroomnumber))
                    {
                        string title21 = "Warning!";
                        string message21 = "Editing the occupied room number could lead to confusion and inaccuracy.\nAre you sure you want to continue editing the occupied room number?";
                        MessageBoxButtons button21 = MessageBoxButtons.YesNo;
                        DialogResult result21 = MessageBox.Show(message21, title21, button21);
                        if (result21 == DialogResult.No) { return; }
                        MySqlCommand command16 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                        command16.Connection = connect; command16.ExecuteNonQuery();
                        MySqlCommand command1 = new MySqlCommand($"update additionalguest set guest_room_occupied = '{finalnewroom}', room_type = '{roomtype}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                        command1.Connection = connect; command1.ExecuteNonQuery();
                        MySqlCommand command17 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                        command17.Connection = connect; command17.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(newstart))
                    {
                        MySqlCommand command2 = new MySqlCommand($"update additionalguest set guest_start_date = '{newstart}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                        command2.Connection = connect; command2.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(newend))
                    {
                        MySqlCommand command3 = new MySqlCommand($"update additionalguest set guest_end_date = '{newend}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                        command3.Connection = connect; command3.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(newfee))
                    {
                        MySqlCommand command4 = new MySqlCommand($"update additionalguest set guest_additional_charge = {new_charge} where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                        command4.Connection = connect; command4.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(newparking))
                    {
                        MySqlCommand command5 = new MySqlCommand($"update additionalguest set guest_parking_fee = {new_parking} where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                        command5.Connection = connect; command5.ExecuteNonQuery();
                    }
                    guestName.Clear(); newGuestStartDate.Clear(); newRoomNumber.Clear();
                    newGuestEndDate.Clear(); newGuestCharge.Clear(); newGuestParking.Clear();
                    primaryGuestName.Clear(); roomNumber.Clear(); newPrimaryGuestName.Clear();
                    string title1 = "Guest update successful";
                    string message1 = "The details of the additional guest has been updated.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
        }
    }
}
