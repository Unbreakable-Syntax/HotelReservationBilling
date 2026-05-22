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
using System.Xml.Linq;

namespace HotelReservationBilling
{
    public partial class ManageOccupant : Form
    {
        public ManageOccupant()
        {
            InitializeComponent();
            FillData();
        }

        public void FillData()
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("select person_name as 'Name', person_age as 'Age', person_gender as 'Gender', person_birthdate as 'Birthdate', person_national as 'Nationality', person_religion as 'Religion', person_contact_number as 'Contact Number', person_down_pay as 'Paid Balance (PHP)', person_remain_bal as 'Remaining Balance (PHP)', person_total_bal as 'Total Balance (PHP)', person_change as 'Change (PHP)', person_orig_rate as 'Original Room Rate', person_discount_rate as 'Discounted Room Rate', parking_rate as 'Parking Rate (PHP)', room_number_occupied as 'Occupied Room Number', room_type as 'Room Type', number_of_nights as 'Number of Nights', number_of_additional_guests as 'Number of Additional Guests', guest_charge as 'Additional Guest Charge (PHP)', start_rent as 'Start Rent Date', end_rent as 'End Rent Date' from occupantdata order by person_name", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); occupantDataTable.DataSource = table;
            occupantDataTable.AllowUserToAddRows = false;
            occupantDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        public void SearchData(string searchVal)
        {
            if (searchVal.Contains("\\") || searchVal.Contains("/")) { searchVal = "%"; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select person_name as 'Name', person_age as 'Age', person_gender as 'Gender', person_birthdate as 'Birthdate', person_national as 'Nationality', person_religion as 'Religion', person_contact_number as 'Contact Number', person_down_pay as 'Paid Balance (PHP)', person_remain_bal as 'Remaining Balance (PHP)', person_total_bal as 'Total Balance (PHP)', person_change as 'Change (PHP)', person_orig_rate as 'Original Room Rate', person_discount_rate as 'Discounted Room Rate', parking_rate as 'Parking Rate', room_number_occupied as 'Occupied Room Number', room_type as 'Room Type', number_of_nights as 'Number of Nights', number_of_additional_guests as 'Number of Additional Guests', guest_charge as 'Additional Guest Charge (PHP)', start_rent as 'Start Rent Date', end_rent as 'End Rent Date' from occupantdata where concat(person_name, person_age, person_gender, person_birthdate, person_national, person_religion, person_contact_number, person_total_bal, person_remain_bal, person_change, person_down_pay, person_orig_rate, person_discount_rate, parking_rate, room_number_occupied, room_type, number_of_nights, number_of_additional_guests, guest_charge, start_rent, end_rent) like '%{searchVal}%' order by person_name", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table); occupantDataTable.DataSource = table;
            occupantDataTable.AllowUserToAddRows = false;
            occupantDataTable.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.None;
        }

        private void ManageOccupant_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate();
        }

        private void backButton1_Click(object sender, EventArgs e)
        { this.Close(); }

        private void occupantSearchBox_TextChanged(object sender, EventArgs e)
        { SearchData(occupantSearchBox.Text); }

        private void removeOccupantButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"SELECT COUNT(*) from occupantdata", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            command.Connection = connect;
            if (result == 0)
            {
                string title1 = "No occupants available";
                string message1 = "There are no occupants to remove.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string occupantname = occupantName.Text;
            if (string.IsNullOrWhiteSpace(occupantname))
            {
                string title1 = "Invalid occupant name";
                string message1 = "Please ensure that the indicated occupant name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                MySqlCommand command4 = new MySqlCommand($"SELECT COUNT(*) from occupantdata where person_name = TRIM('{occupantname}')", connect);
                int result3 = Convert.ToInt32(command4.ExecuteScalar());
                command4.Connection = connect;
                if (result3 == 0)
                {
                    string title1 = "Occupant removal failed";
                    string message1 = "The indicated occupant does not exist in the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                }
                else
                {
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand command2 = new MySqlCommand($"delete from occupantdata where person_name = TRIM('{occupantname}')", connect);
                    command2.ExecuteNonQuery();
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                    string title1 = "Occupant removal successful";
                    string message1 = "The indicated occupant has been successfully removed from the system.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    FillData();
                }
            }
        }

        private void updateOccupantButton_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) from occupantdata", connect);
            int result = Convert.ToInt32(command.ExecuteScalar());
            if (result == 0)
            {
                string title1 = "No occupants available";
                string message1 = "There are no occupants to update.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string name = occupantName.Text;
            string age = occupantAge.Text;
            string gender = occupantGender.Text;
            string birthdate = occupantBirthdate.Text;
            string national = occupantNational.Text;
            string religion = occupantReligion.Text;
            string contact = occupantContact.Text;
            string newname = newOccupantName.Text;
            string room = roomNumber.Text;
            int valid_age = 0, room_number = 0;
            DateTime birth_date = new DateTime();
            bool completeDetail = false, canContinue = true;
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 1)
            {
                string title1 = "Invalid occupant name";
                string message1 = "Please check if the occupant name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(room))
            {
                string title1 = "Blank room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(room, out room_number))
            {
                string title1 = "Invalid room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else { room = "Room " + room_number; }
            if (!string.IsNullOrWhiteSpace(newname) && !string.IsNullOrWhiteSpace(age) && !string.IsNullOrWhiteSpace(contact) && !string.IsNullOrWhiteSpace(gender) && !string.IsNullOrWhiteSpace(birthdate) && !string.IsNullOrWhiteSpace(national) && !string.IsNullOrWhiteSpace(religion))
            {
                completeDetail = true;
                if (!int.TryParse(age, out valid_age))
                {
                    string title1 = "Invalid occupant age";
                    string message1 = "Please check if the occupant age is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (contact.Length <= 12)
                {
                    string title1 = "Invalid occupant contact number";
                    string message1 = "Please double check if the contact number is valid (+639).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (newname.Length <= 1)
                {
                    string title1 = "Invalid new occupant name";
                    string message1 = "Please check if the new occupant name is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (gender.Length <= 3)
                {
                    string title1 = "Invalid occupant gender";
                    string message1 = "Valid entry is Male or Female only.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!DateTime.TryParse(birthdate, out birth_date))
                {
                    string title1 = "Invalid occupant birthdate";
                    string message1 = "Please check if the birthdate is following a proper format (YYYY-MM-DD).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (national.Length <= 1)
                {
                    string title1 = "Invalid occupant nationality";
                    string message1 = "Please check if the nationality is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (religion.Length <= 1)
                {
                    string title1 = "Invalid occupant religion";
                    string message1 = "Please check if the religion is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (completeDetail == false)
            {
                if (!string.IsNullOrWhiteSpace(age) && !int.TryParse(age, out valid_age))
                {
                    string title1 = "Invalid occupant age";
                    string message1 = "Please check if the occupant age is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(newname) && newname.Length <= 1)
                {
                    string title1 = "Invalid occupant new name";
                    string message1 = "Please check if the occupant new name is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(contact) && contact.Length <= 12)
                {
                    string title1 = "Invalid occupant contact number";
                    string message1 = "Please double check if the contact number is valid (+639).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(gender) && gender.Length <= 3)
                {
                    string title1 = "Invalid occupant gender";
                    string message1 = "Valid entry is Male or Female only.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(birthdate) && !DateTime.TryParse(birthdate, out birth_date))
                {
                    string title1 = "Invalid occupant birthdate";
                    string message1 = "Please check if the birthdate is following a proper format (YYYY-MM-DD).";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(national) && national.Length <= 1)
                {
                    string title1 = "Invalid occupant nationality";
                    string message1 = "Please check if the nationality is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(religion) && religion.Length <= 1)
                {
                    string title1 = "Invalid occupant religion";
                    string message1 = "Please check if the religion is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(room) && string.IsNullOrWhiteSpace(newname) && string.IsNullOrWhiteSpace(contact) && string.IsNullOrWhiteSpace(age) && string.IsNullOrWhiteSpace(gender) && string.IsNullOrWhiteSpace(birthdate) && string.IsNullOrWhiteSpace(national) && string.IsNullOrWhiteSpace(religion))
            {
                string title1 = "Details are empty";
                string message1 = "Please ensure that at least 1 detail is not empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand command1 = new MySqlCommand($"SELECT COUNT(*) from occupantdata WHERE person_name = TRIM('{name}') and room_number_occupied = '{room}'", connect);
            int result8 = Convert.ToInt32(command1.ExecuteScalar());
            command1.Connection = connect;
            if (result8 == 0)
            {
                canContinue = false;
                string title1 = "Occupant update unsuccessful";
                string message1 = "The indicated occupant name does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                occupantName.Clear();
            }
            MySqlCommand command2 = new MySqlCommand($"SELECT COUNT(*) from occupantdata WHERE person_name = TRIM('{newname}') and room_number_occupied = '{room}'", connect);
            int result9 = Convert.ToInt32(command2.ExecuteScalar());
            command2.Connection = connect;
            if (result9 != 0)
            {
                canContinue = false;
                string title1 = "Occupant update unsuccessful";
                string message1 = "The indicated new occupant name already exists.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                occupantName.Clear();
            }
            if (canContinue == true)
            {
                if (completeDetail == true)
                {
                    string tempWord = "";
                    if (valid_age <= 1) { tempWord = "year"; }
                    else if (valid_age > 1) { tempWord = "years"; }
                    string finalAge = valid_age + " " + tempWord + " old";
                    string title20 = "Warning!";
                    string message20 = "Editing the main occupant name is only for emergency purposes!\nAre you sure you want to continue editing the occupant name?";
                    MessageBoxButtons button20 = MessageBoxButtons.YesNo;
                    DialogResult result20 = MessageBox.Show(message20, title20, button20);
                    if (result20 == DialogResult.No) { return; }
                    MySqlCommand command12 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                    command12.Connection = connect; command12.ExecuteNonQuery();
                    MySqlCommand commandone = new MySqlCommand($"update occupantdata set person_name = TRIM('{newname}'), person_age = '{finalAge}', person_gender = '{gender}', person_birthdate = '{birthdate}', person_national = '{national}', person_religion = '{religion}', person_contact_number = '{contact}' where person_name = TRIM('{name}') and room_number_occupied = '{room}'", connect);
                    commandone.Connection = connect; commandone.ExecuteNonQuery();
                    MySqlCommand command13 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                    command13.Connection = connect; command13.ExecuteNonQuery();
                }
                else if (completeDetail == false)
                {
                    if (!string.IsNullOrWhiteSpace(newname))
                    {
                        string title20 = "Warning!";
                        string message20 = "Editing the main occupant name is only for emergency purposes!\nAre you sure you want to continue editing the occupant name?";
                        MessageBoxButtons button20 = MessageBoxButtons.YesNo;
                        DialogResult result20 = MessageBox.Show(message20, title20, button20);
                        if (result20 == DialogResult.No) { return; }
                        MySqlCommand command14 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0");
                        command14.Connection = connect; command14.ExecuteNonQuery();
                        MySqlCommand commandtwo = new MySqlCommand($"update occupantdata set person_name = TRIM('{newname}') where person_name = TRIM('{name}') and room_number_occupied = '{room}'", connect);
                        commandtwo.Connection = connect; commandtwo.ExecuteNonQuery();
                        MySqlCommand command15 = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1");
                        command15.Connection = connect; command15.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(age))
                    {
                        string tempWord = "";
                        if (valid_age <= 1) { tempWord = "year"; }
                        else if (valid_age > 1) { tempWord = "years"; }
                        string finalAge = valid_age + " " + tempWord + " old";
                        MySqlCommand commandtwo = new MySqlCommand($"update occupantdata set person_age = '{finalAge}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandtwo.Connection = connect; commandtwo.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(contact))
                    {
                        MySqlCommand commandseven = new MySqlCommand($"update occupantdata set person_contact_number = '{contact}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandseven.Connection = connect; commandseven.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(gender))
                    {
                        MySqlCommand commandthree = new MySqlCommand($"update occupantdata set person_gender = '{gender}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandthree.Connection = connect; commandthree.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(birthdate))
                    {
                        MySqlCommand commandfour = new MySqlCommand($"update occupantdata set person_birthdate = '{birthdate}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandfour.Connection = connect; commandfour.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(national))
                    {
                        MySqlCommand commandfive = new MySqlCommand($"update occupantdata set person_national = '{national}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandfive.Connection = connect; commandfive.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(religion))
                    {
                        MySqlCommand commandsix = new MySqlCommand($"update occupantdata set person_religion = '{religion}' where person_name = '{name}' and room_number_occupied = '{room}'", connect);
                        commandsix.Connection = connect; commandsix.ExecuteNonQuery();
                    }
                }
                string title1 = "Occupant update successful";
                string message1 = "The details of the occupant has been updated successfully.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                FillData();
            }
        }

        private void updateAdvancedOccupantButton_Click(object sender, EventArgs e)
        {
            string title1 = "Warning!";
            string message1 = "This function is only intended for emergency situations." +
                "\nIf this function is used incorrectly, it could lead to data loss." +
                "\nAre you sure you want to continue?";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result1 = MessageBox.Show(message1, title1, button);
            if (result1 == DialogResult.Yes)
            {
                AdvancedOccupantDetail advancedEdit = new AdvancedOccupantDetail();
                advancedEdit.Show();
            }
        }

        private void ManageOccupant_Activated(object sender, EventArgs e)
        { FillData(); }

        private void findData_Click(object sender, EventArgs e)
        {
            string name = occupantName.Text, room = roomNumber.Text;
            int room_number = 0;
            if (!int.TryParse(room, out room_number))
            {
                string title1 = "Invalid room number";
                string message1 = "The occupant does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else { room = "Room " + room_number; }
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 1)
            {
                string title1 = "Invalid occupant name";
                string message1 = "Please check if the occupant name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select * from occupantdata where person_name = '{name}' and room_number_occupied = '{room}'", connect);
            command.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count <= 0)
            {
                string title1 = "No data found";
                string message1 = "The occupant does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else
            {
                newOccupantName.Text = table.Rows[0][0].ToString();
                occupantAge.Text = table.Rows[0][2].ToString();
                occupantGender.Text = table.Rows[0][1].ToString();
                string birthdate = table.Rows[0][3].ToString();
                birthdate = DateTime.Parse(birthdate).ToString("yyyy-MM-dd");
                occupantBirthdate.Text = birthdate;
                occupantNational.Text = table.Rows[0][4].ToString();
                occupantReligion.Text = table.Rows[0][5].ToString();
                occupantContact.Text = table.Rows[0][6].ToString();
            }
        }
    }
}
