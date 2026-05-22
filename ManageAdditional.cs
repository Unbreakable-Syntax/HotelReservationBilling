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
    public partial class ManageAdditional : Form
    {
        public ManageAdditional()
        {
            InitializeComponent(); FillAdditional();
        }

        public void FillAdditional()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select guest_name as 'Guest Name', guest_age as 'Guest Age', guest_gender as 'Guest Gender', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number', guest_primary_booker as 'Primary Booker', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_additional_charge as 'Additional Guest Charge (PHP)', guest_parking_fee as 'Guest Parking Fee', guest_start_date as 'Start Rent Date', guest_end_date as 'End Rent Date' from additionalguest order by guest_start_date, guest_end_date", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); additionalGuestTable.DataSource = table;
            additionalGuestTable.AllowUserToAddRows = false;
            additionalGuestTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        public void SearchAdditional(string searchVal)
        {
            if (searchVal.Contains("\\") || searchVal.Contains("/")) { searchVal = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select guest_name as 'Guest Name', guest_age as 'Guest Age', guest_gender as 'Guest Gender', guest_birthdate as 'Guest Birthdate', guest_national as 'Guest Nationality', guest_religion as 'Guest Religion', guest_contact_number as 'Guest Contact Number', guest_primary_booker as 'Primary Booker', guest_room_occupied as 'Occupied Room Number', room_type as 'Room Type', guest_additional_charge as 'Additional Guest Charge (PHP)', guest_parking_fee as 'Guest Parking Fee', guest_start_date as 'Start Rent Date', guest_end_date as 'End Rent Date' from additionalguest where concat(guest_name, guest_gender, guest_age, guest_birthdate, guest_national, guest_religion, guest_contact_number, guest_primary_booker, guest_room_occupied, guest_start_date, guest_end_date, guest_additional_charge, guest_parking_fee) LIKE '{searchVal}' order by guest_name", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); additionalGuestTable.DataSource = table;
            additionalGuestTable.AllowUserToAddRows = false;
            additionalGuestTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        private void searchBox1_TextChanged(object sender, EventArgs e)
        { SearchAdditional(searchBox1.Text); }

        private void removeButton1_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            string name = guestName.Text;
            string room = roomNumber.Text;
            string primaryname = primaryGuestName.Text;
            MySqlCommand command5 = new MySqlCommand($"SELECT COUNT(*) from additionalguest", connect);
            int result5 = Convert.ToInt32(command5.ExecuteScalar());
            command5.Connection = connect;
            if (result5 == 0)
            {
                string title1 = "No guests available";
                string message1 = "There are no guest to remove.";
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
            else
            {
                MySqlCommand command4 = new MySqlCommand($"SELECT COUNT(*) from additionalguest where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                int result3 = Convert.ToInt32(command4.ExecuteScalar());
                command4.Connection = connect;
                if (result3 == 0)
                {
                    string title1 = "Guest removal failed";
                    string message1 = "The indicated guest does not exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                else
                {
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand command2 = new MySqlCommand($"delete from additionalguest where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                    command2.ExecuteNonQuery();
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title1 = "Guest removal successful";
                    string message1 = "The indicated guest has been successfully removed from the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    FillAdditional(); guestName.Clear(); roomNumber.Clear(); primaryGuestName.Clear();
                }
            }
        }

        private void updateButton1_Click(object sender, EventArgs e)
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
            string newname = newGuestName.Text;
            string newage = newGuestAge.Text;
            string newgender = newGuestGender.Text;
            string newreligion = newGuestReligion.Text;
            string newnational = newGuestNationality.Text;
            string newbirthdate = newGuestBirthdate.Text;
            string newcontact = newGuestContactNumber.Text;
            int new_age = 0;
            DateTime testDate = new DateTime();
            if (!string.IsNullOrWhiteSpace(newname) && !string.IsNullOrWhiteSpace(newage) && !string.IsNullOrWhiteSpace(newgender) && !string.IsNullOrWhiteSpace(newreligion) && !string.IsNullOrWhiteSpace(newnational) && !string.IsNullOrWhiteSpace(newcontact) && !string.IsNullOrWhiteSpace(newbirthdate))
            {
                if (newname.Length <= 1)
                {
                    string title1 = "Invalid name";
                    string message1 = "Please ensure that the provided name is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (newgender.Length <= 3)
                {
                    string title1 = "Invalid gender";
                    string message1 = "Please ensure that the provided gender is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(newage, out new_age) || new_age < 0)
                {
                    string title1 = "Invalid age";
                    string message1 = "Please ensure that the provided age is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (newreligion.Length <= 2)
                {
                    string title1 = "Invalid religion";
                    string message1 = "Please ensure that the provided religion is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (newnational.Length <= 2)
                {
                    string title1 = "Invalid nationality";
                    string message1 = "Please ensure that the provided nationality is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (newcontact.Length <= 12)
                {
                    string title1 = "Invalid contact number";
                    string message1 = "Please ensure that the provided contact number is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!DateTime.TryParse(newbirthdate, out testDate))
                {
                    string title1 = "Invalid birthdate";
                    string message1 = "Please ensure that the provided birthdate is correct (YYYY-MM-DD).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(newname) && newname.Length <= 1)
                {
                    string title1 = "Invalid name";
                    string message1 = "Please ensure that the provided name is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newgender) && newgender.Length <= 3)
                {
                    string title1 = "Invalid gender";
                    string message1 = "Please ensure that the provided gender is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newage) && !int.TryParse(newage, out new_age) || new_age < 0)
                {
                    string title1 = "Invalid age";
                    string message1 = "Please ensure that the provided age is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newreligion) && newreligion.Length <= 2)
                {
                    string title1 = "Invalid religion";
                    string message1 = "Please ensure that the provided religion is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newnational) && newnational.Length <= 2)
                {
                    string title1 = "Invalid nationality";
                    string message1 = "Please ensure that the provided nationality is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newcontact) && newcontact.Length <= 12)
                {
                    string title1 = "Invalid contact number";
                    string message1 = "Please ensure that the provided contact number is correct.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newbirthdate) && !DateTime.TryParse(newbirthdate, out testDate))
                {
                    string title1 = "Invalid birthdate";
                    string message1 = "Please ensure that the provided birthdate is correct (YYYY-MM-DD).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(newname) && string.IsNullOrWhiteSpace(newage) && string.IsNullOrWhiteSpace(newgender) && string.IsNullOrWhiteSpace(newreligion) && string.IsNullOrWhiteSpace(newnational) && string.IsNullOrWhiteSpace(newcontact) && string.IsNullOrWhiteSpace(newbirthdate))
            {
                string title1 = "Blank details";
                string message1 = "Please ensure that at least 1 detail is not empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand checkexist = new MySqlCommand($"SELECT COUNT(*) from additionalguest where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
            int result8 = Convert.ToInt32(checkexist.ExecuteScalar());
            checkexist.Connection = connect;
            if (result8 == 0)
            {
                string title1 = "Guest update unsuccessful";
                string message1 = "The additional guest based on the 3 provided details do not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string tempage = "";
            if (new_age <= 1) { tempage = " year old"; }
            else if (new_age > 1) { tempage = " years old"; }
            string finalage = new_age + tempage;
            if (!string.IsNullOrWhiteSpace(newname) && !string.IsNullOrWhiteSpace(newage) && !string.IsNullOrWhiteSpace(newgender) && !string.IsNullOrWhiteSpace(newreligion) && !string.IsNullOrWhiteSpace(newnational) && !string.IsNullOrWhiteSpace(newcontact) && !string.IsNullOrWhiteSpace(newbirthdate))
            {
                MySqlCommand command1 = new MySqlCommand($"update additionalguest set guest_name = TRIM('{newname}'), guest_gender = '{newgender}', guest_age = '{finalage}', guest_birthdate = '{newbirthdate}', guest_national = '{newnational}', guest_religion = '{newreligion}', guest_contact_number = '{newcontact}' where guest_name = TRIM('{name}') and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                command1.Connection = connect; command1.ExecuteNonQuery();
                string title1 = "Guest update successful";
                string message1 = "The basic details for the additional guest has been updated.";
                MessageBoxButtons button = MessageBoxButtons.OK; FillAdditional();
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                newGuestName.Clear(); newGuestGender.Clear();
                newGuestAge.Clear(); newGuestBirthdate.Clear();
                newGuestNationality.Clear(); newGuestReligion.Clear();
                newGuestContactNumber.Clear(); guestName.Clear();
                primaryGuestName.Clear(); roomNumber.Clear();
                return;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(newname))
                {
                    MySqlCommand command2 = new MySqlCommand($"update additionalguest set guest_name = TRIM('{newname}') where guest_name = '{name}' and guest_primary_booker = TRIM('{primaryname}') and guest_room_occupied = '{room}'", connect);
                    command2.Connection = connect; command2.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newgender))
                {
                    MySqlCommand command3 = new MySqlCommand($"update additionalguest set guest_gender = '{newgender}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command3.Connection = connect; command3.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newage))
                {
                    MySqlCommand command4 = new MySqlCommand($"update additionalguest set guest_age = '{finalage}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command4.Connection = connect; command4.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newreligion))
                {
                    MySqlCommand command5 = new MySqlCommand($"update additionalguest set guest_religion = '{newreligion}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command5.Connection = connect; command5.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newnational))
                {
                    MySqlCommand command6 = new MySqlCommand($"update additionalguest set guest_national = '{newnational}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command6.Connection = connect; command6.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newcontact))
                {
                    MySqlCommand command7 = new MySqlCommand($"update additionalguest set guest_contact_number = '{newcontact}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command7.Connection = connect; command7.ExecuteNonQuery();
                }
                if (!string.IsNullOrWhiteSpace(newbirthdate))
                {
                    MySqlCommand command8 = new MySqlCommand($"update additionalguest set guest_birthdate = '{newbirthdate}' where guest_name = '{name}' and guest_primary_booker = '{primaryname}' and guest_room_occupied = '{room}'", connect);
                    command8.Connection = connect; command8.ExecuteNonQuery();
                }
                newGuestName.Clear(); newGuestGender.Clear();
                newGuestAge.Clear(); newGuestBirthdate.Clear();
                newGuestNationality.Clear(); newGuestReligion.Clear();
                newGuestContactNumber.Clear(); guestName.Clear();
                primaryGuestName.Clear(); roomNumber.Clear();
                string title1 = "Guest update successful";
                string message1 = "The basic details for the additional guest has been updated.";
                MessageBoxButtons button = MessageBoxButtons.OK; FillAdditional();
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
        }

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
                newGuestName.Text = table.Rows[0][0].ToString();
                newGuestGender.Text = table.Rows[0][1].ToString();
                newGuestAge.Text = table.Rows[0][2].ToString();
                string birthdate = table.Rows[0][3].ToString();
                birthdate = DateTime.Parse(birthdate).ToString("yyyy-MM-dd");
                newGuestBirthdate.Text = birthdate;
                newGuestNationality.Text = table.Rows[0][4].ToString();
                newGuestReligion.Text = table.Rows[0][5].ToString();
                newGuestContactNumber.Text = table.Rows[0][6].ToString();
            }
        }

        private void updateButton2_Click(object sender, EventArgs e)
        {
            string title20 = "Warning!";
            string message20 = "Editing details in this section could lead to inaccuracy and confusion.\nAre you sure you want to proceed and edit these details?";
            MessageBoxButtons button20 = MessageBoxButtons.YesNo;
            DialogResult result20 = MessageBox.Show(message20, title20, button20);
            if (result20 == DialogResult.No) { return; }
            AdvancedAdditional updateAdvanced = new AdvancedAdditional();
            updateAdvanced.Show();
        }

        private void ManageAdditional_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate(); FillAdditional();
        }

        private void ManageAdditional_Activated(object sender, EventArgs e) { FillAdditional(); }

        private void backButton5_Click(object sender, EventArgs e) { this.Close(); }
    }
}
