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
    public partial class AdditionalGuest : Form
    {
        static int carpark = 0;
        static int motorpark = 0;
        static int bikepark = 0;
        public AdditionalGuest()
        {
            InitializeComponent();
        }

        private void AdditionalGuest_Shown(object sender, EventArgs e)
        { this.BringToFront(); this.Activate(); }

        private void addGuest_Click(object sender, EventArgs e)
        {
            string primaryGuestName = mainGuestName.Text;
            string name = guestName.Text;
            string gender = guestGender.Text;
            string national = guestNational.Text;
            string religion = guestReligion.Text;
            string contact = guestContact.Text;
            string birthdate = guestBirthdate.Text;
            string guestRoom = guestRoomNumber.Text;
            int roomNumber = 0;
            DateTime primaryGuestBirthdate = new DateTime();
            int primaryGuestAge = 0;
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(guestRoom) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(national) || string.IsNullOrWhiteSpace(religion) || string.IsNullOrWhiteSpace(contact))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that there are no missing details.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result15 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (primaryGuestName.Length < 1)
            {
                string title1 = "Invalid primary guest name";
                string message1 = "Please check if the primary guest name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (name.Length < 1)
            {
                string title1 = "Invalid name";
                string message1 = "Please check if the name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(guestRoom, out roomNumber))
            {
                string title1 = "Invalid room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (gender.Length <= 3)
            {
                string title1 = "Invalid gender";
                string message1 = "Please check if the gender is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (national.Length <= 2)
            {
                string title1 = "Invalid nationality";
                string message1 = "Please check if the nationality is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (religion.Length <= 2)
            {
                string title1 = "Invalid religion";
                string message1 = "Please check if the religion is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (contact.Length <= 12)
            {
                string title1 = "Invalid contact number";
                string message1 = "Please check if the contact number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!DateTime.TryParse(birthdate, out primaryGuestBirthdate))
            {
                string title1 = "Invalid birthdate";
                string message1 = "Please check if the birthdate is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            string finalRoom = "Room " + roomNumber;
            MySqlCommand checkExist2 = new MySqlCommand($"SELECT COUNT(*) from occupantdata where INSTR(person_name, TRIM('{primaryGuestName}')) and room_number_occupied = '{finalRoom}'", connect);
            int result2 = Convert.ToInt32(checkExist2.ExecuteScalar());
            if (result2 == 0)
            {
                string title1 = "Nonexistent room number and/or primary guest";
                string message1 = "Please ensure that the room number is already occupied by a proper primary guest, or if the primary guest name already exists in the system.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            double guestCharge = 0;
            string tempcharge = "";
            string start_date = "";
            string end_date = "";
            string nightNumText = "";
            double finalcharge = 0;
            int nightNum = 0;
            MySqlCommand extract = new MySqlCommand($"select person_discount_rate, start_rent, end_rent, number_of_nights from occupantdata where person_name = TRIM('{primaryGuestName}') and room_number_occupied = '{finalRoom}'", connect);
            extract.ExecuteNonQuery();
            extract.Connection = connect;
            MySqlDataAdapter adapter = new MySqlDataAdapter(extract);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                tempcharge = table.Rows[0][0].ToString();
                start_date = table.Rows[0][1].ToString();
                start_date = DateTime.Parse(start_date).ToString("yyyy-MM-dd");
                end_date = table.Rows[0][2].ToString();
                end_date = DateTime.Parse(end_date).ToString("yyyy-MM-dd");
                nightNumText = table.Rows[0][3].ToString();
            }
            char[] targetTrim = { 'n', 'i', 'g', 'h', 't', 's', ' ' };
            nightNumText = nightNumText.Trim(targetTrim);
            if (!int.TryParse(nightNumText, out nightNum)) { return; }
            if (!double.TryParse(tempcharge, out finalcharge)) { return; }
            start_date = start_date.Replace('/', '-');
            end_date = end_date.Replace('/', '-');
            finalcharge = (finalcharge * 10) / 100; guestCharge = finalcharge * nightNum;
            DateTime birth_date = DateTime.Parse(birthdate);
            DateTime current_date = DateTime.Now;
            DateTime temp_date = birth_date; int years = -1;
            while (temp_date < current_date) { ++years; temp_date = temp_date.AddYears(1); }
            primaryGuestAge = years; string tempage;
            if (primaryGuestAge <= 0) { tempage = " year old"; }
            else { tempage = " years old"; }
            string finalage = primaryGuestAge + tempage;
            double totalparking = (carpark + motorpark + bikepark) * nightNum;
            MySqlCommand extracttype = new MySqlCommand($"select room_type from hotelroom where room_number = '{finalRoom}'", connect);
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
            MySqlCommand addguest = new MySqlCommand($"insert into additionalguest values (TRIM('{name}'), '{gender}', '{finalage}', '{birthdate}', '{national}', '{religion}', '{contact}', '{primaryGuestName}', '{finalRoom}', '{roomtype}', '{start_date}', '{end_date}', {guestCharge}, {totalparking})", connect);
            addguest.ExecuteNonQuery();
            string title5 = "Additional guest added";
            string message5 = "Please continue adding more additional guests as indicated by the primary guest.";
            MessageBoxButtons button5 = MessageBoxButtons.OK;
            DialogResult result5 = MessageBox.Show(message5, title5, button5);
            this.FormClosing -= AdditionalGuest_FormClosing; this.Close();
        }

        private void carParked_CheckedChanged(object sender, EventArgs e)
        {
            if (carParked.Checked == true) { carpark = 75; }
            if (carParked.Checked == false) { carpark = 0; }
            mainGuestName_TextChanged(sender, e);
        }

        private void motorbikeParked_CheckedChanged(object sender, EventArgs e)
        {
            if (motorbikeParked.Checked == true) { motorpark = 50; }
            if (motorbikeParked.Checked == false) { motorpark = 0; }
            mainGuestName_TextChanged(sender, e);
        }

        private void bikeParked_CheckedChanged(object sender, EventArgs e)
        {
            if (bikeParked.Checked == true) { bikepark = 25; }
            if (bikeParked.Checked == false) { bikepark = 0; }
            mainGuestName_TextChanged(sender, e);
        }

        private void AdditionalGuest_FormClosing(object sender, FormClosingEventArgs e)
        {
            string title1 = "Skipping additional guest registration";
            string message1 = "Are you sure to skip providing details for the additional guests?" +
                "\nThis could lead to safety and security risks.";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result1 = MessageBox.Show(message1, title1, button);
            if (result1 == DialogResult.Yes) { }
            else if (result1 == DialogResult.No) { e.Cancel = true; }
        }

        private void fillPreviousData_Click(object sender, EventArgs e)
        {
            string guestname = guestName.Text;
            if (string.IsNullOrWhiteSpace(guestname))
            {
                string title1 = "Blank guest name";
                string message1 = "The guest name is empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand fillcheckout = new MySqlCommand($"select guest_gender, guest_birthdate, guest_national, guest_religion, guest_contact_number from checkouthistory where guest_name = '{guestname}' order by guest_end_date desc", connect);
            fillcheckout.ExecuteNonQuery();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(fillcheckout);
            DataTable table2 = new DataTable(); adapter2.Fill(table2);
            if (table2.Rows.Count != 0)
            {
                guestGender.Text = table2.Rows[0][0].ToString();
                string birthdate = DateTime.Parse(table2.Rows[0][1].ToString()).ToString("yyyy-MM-dd");
                guestBirthdate.Text = birthdate;
                guestNational.Text = table2.Rows[0][2].ToString();
                guestReligion.Text = table2.Rows[0][3].ToString();
                guestContact.Text = table2.Rows[0][4].ToString();
                return;
            }

            MySqlCommand fillcancel = new MySqlCommand($"select guest_gender, guest_birthdate, guest_national, guest_religion, guest_contact_number from cancelhistory where guest_name = '{guestname}' order by guest_end_date desc", connect);
            fillcancel.ExecuteNonQuery();
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(fillcancel);
            DataTable table3 = new DataTable(); adapter3.Fill(table3);
            if (table3.Rows.Count != 0)
            {
                guestGender.Text = table3.Rows[0][0].ToString();
                string birthdate = DateTime.Parse(table3.Rows[0][1].ToString()).ToString("yyyy-MM-dd");
                guestBirthdate.Text = birthdate;
                guestNational.Text = table3.Rows[0][2].ToString();
                guestReligion.Text = table3.Rows[0][3].ToString();
                guestContact.Text = table3.Rows[0][4].ToString();
                return;
            }
            string title60 = "Nonexistent guest name";
            string message60 = "The guest name does not exist in any previous records.";
            MessageBoxButtons button60 = MessageBoxButtons.OK;
            DialogResult result60 = MessageBox.Show(message60, title60, button60);
            return;
        }

        private void mainGuestName_TextChanged(object sender, EventArgs e)
        {
            int roomNumber = 0;
            string primaryGuestName = mainGuestName.Text;
            string guestRoom = guestRoomNumber.Text;
            if (guestRoom.Contains("\\") || guestRoom.Contains("/")) { return; }
            if (primaryGuestName.Contains("\\") || primaryGuestName.Contains("/")) { return; }
            if (!string.IsNullOrWhiteSpace(primaryGuestName) && primaryGuestName.Length < 1) { return; }
            if (!string.IsNullOrWhiteSpace(guestRoom) && !int.TryParse(guestRoom, out roomNumber)) { return; }
            if (string.IsNullOrWhiteSpace(guestRoom) || string.IsNullOrWhiteSpace(primaryGuestName)) { return; }
            string finalRoom = "Room " + roomNumber;
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            double guestCharge = 0;
            string tempcharge = "";
            string nightNumText = "";
            double finalcharge = 0;
            int nightNum = 0;
            MySqlCommand extract = new MySqlCommand($"select person_discount_rate, start_rent, end_rent, number_of_nights from occupantdata where person_name = TRIM('{primaryGuestName}') and room_number_occupied = '{finalRoom}'", connect);
            extract.ExecuteNonQuery();
            extract.Connection = connect;
            MySqlDataAdapter adapter = new MySqlDataAdapter(extract);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                tempcharge = table.Rows[0][0].ToString();
                nightNumText = table.Rows[0][3].ToString();
            }
            char[] targetTrim = { 'n', 'i', 'g', 'h', 't', 's', ' ' };
            nightNumText = nightNumText.Trim(targetTrim);
            if (!int.TryParse(nightNumText, out nightNum)) { return; }
            if (!double.TryParse(tempcharge, out finalcharge)) { return; }
            finalcharge = (finalcharge * 10) / 100; guestCharge = finalcharge * nightNum;
            double totalparking = (carpark + motorpark + bikepark) * nightNum;
            chargeLabel.Text = "PHP " + guestCharge;
            paymentLabel.Text = "PHP " + totalparking;
        }
    }
}
