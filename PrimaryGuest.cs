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
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Remoting.Contexts;

namespace HotelReservationBilling
{
    public partial class PrimaryGuest : Form
    {
        static int bikeparking = 0;
        static int carparking = 0;
        static int motorparking = 0;
        public PrimaryGuest()
        {
            InitializeComponent();
        }
        private void carParked_CheckedChanged(object sender, EventArgs e)
        {
            if (carParked.Checked == true) { carparking += 75; }
            if (carParked.Checked == false) { carparking -= 75; }
            CalculatePrice(sender, e);
        }

        private void motorbikeParked_CheckedChanged(object sender, EventArgs e)
        {
            if (motorbikeParked.Checked == true) { motorparking += 50; }
            if (motorbikeParked.Checked == false) { motorparking -= 50; }
            CalculatePrice(sender, e);
        }

        private void bikeParked_CheckedChanged(object sender, EventArgs e)
        {
            if (bikeParked.Checked == true) { bikeparking += 25; }
            if (bikeParked.Checked == false) { bikeparking -= 25; }
            CalculatePrice(sender, e);
        }

        private void PrimaryGuest_Shown(object sender, EventArgs e)
        { this.BringToFront(); this.Activate(); }

        private void addGuest_Click(object sender, EventArgs e)
        {
            string name = guestName.Text;
            string gender = guestGender.Text;
            string national = guestNational.Text;
            string religion = guestReligion.Text;
            string contact = guestContact.Text;
            string birthdate = guestBirthdate.Text;
            string roomnum = guestRoom.Text;
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string pay = guestPayment.Text;
            DateTime start_date = new DateTime();
            DateTime end_date = new DateTime();
            double payment = 0;
            DateTime primaryGuestBirthdate = new DateTime();
            int nightNum = 0, roomnumber = 0, primaryGuestAge = 0;
            int linearDiscountNumber = 0;
            int percentDiscountNumber = 0;
            int pwdDiscountNumber = 0;
            string guestNum = additionalGuestNumber.Text;
            string linearText = linearDiscount.Text;
            string percentText = percentDiscount.Text;
            string pwdText = pwdDiscount.Text;
            int additionalNum = 0;
            if (!string.IsNullOrWhiteSpace(guestNum) && !string.IsNullOrWhiteSpace(linearText) && !string.IsNullOrWhiteSpace(percentText) && string.IsNullOrWhiteSpace(pwdText))
            {
                if (!int.TryParse(guestNum, out additionalNum) || additionalNum < 0)
                {
                    string title1 = "Invalid additional guest number";
                    string message1 = "Please check if your additional guest number is a valid number.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result20 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(linearText, out linearDiscountNumber) || linearDiscountNumber < 0)
                {
                    string title1 = "Invalid linear discount";
                    string message1 = "Please ensure that the linear discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result21 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(percentText, out percentDiscountNumber) || percentDiscountNumber < 0)
                {
                    string title1 = "Invalid percent discount";
                    string message1 = "Please ensure that the percent discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result22 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(pwdText, out pwdDiscountNumber) || pwdDiscountNumber < 0)
                {
                    string title1 = "Invalid PWD/Senior discount";
                    string message1 = "Please ensure that the PWD/Senior discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result23 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(guestNum) && !int.TryParse(guestNum, out additionalNum) || additionalNum < 0)
                {
                    string title1 = "Invalid additional guest number";
                    string message1 = "Please check if your additional guest number is a valid number.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result20 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(linearText) && !int.TryParse(linearText, out linearDiscountNumber) || linearDiscountNumber < 0)
                {
                    string title1 = "Invalid linear discount";
                    string message1 = "Please ensure that the linear discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result21 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(percentText) && !int.TryParse(percentText, out percentDiscountNumber) || percentDiscountNumber < 0 || percentDiscountNumber > 100)
                {
                    string title1 = "Invalid percent discount";
                    string message1 = "Please ensure that the percent discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result22 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(pwdText) && !int.TryParse(pwdText, out pwdDiscountNumber) || pwdDiscountNumber < 0 || pwdDiscountNumber > 100)
                {
                    string title1 = "Invalid PWD/Senior discount";
                    string message1 = "Please ensure that the PWD/Senior discount is correct, only numbers are accepted.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result23 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(national) || string.IsNullOrWhiteSpace(religion) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(birthdate) || string.IsNullOrWhiteSpace(roomnum) || string.IsNullOrWhiteSpace(startdate) || string.IsNullOrWhiteSpace(enddate))
            {
                string title1 = "Missing detail";
                string message1 = "Please ensure that there are no missing details.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result15 = MessageBox.Show(message1, title1, button);
                return;
            }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata";
            var connect = new MySqlConnection(cs); connect.Open();
            if (name.Length < 1)
            {
                string title1 = "Invalid name";
                string message1 = "Please check if the name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result3 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(pay)) { payment = 0; }
            else if (!string.IsNullOrWhiteSpace(pay) && !double.TryParse(pay, out payment) || payment < 0)
            {
                string title1 = "Invalid payment amount";
                string message1 = "Please check if the payment amount is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result4 = MessageBox.Show(message1, title1, button);
                return;
            }      
            if (gender.Length <= 3)
            {
                string title1 = "Invalid gender";
                string message1 = "Please check if the gender is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result5 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (national.Length <= 2)
            {
                string title1 = "Invalid nationality";
                string message1 = "Please check if the nationality is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result6 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (religion.Length <= 2)
            {
                string title1 = "Invalid religion";
                string message1 = "Please check if the religion is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result7 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (contact.Length <= 12)
            {
                string title1 = "Invalid contact number";
                string message1 = "Please check if the contact number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result8 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!DateTime.TryParse(birthdate, out primaryGuestBirthdate))
            {
                string title1 = "Invalid birthdate";
                string message1 = "Please check if the birthdate is valid (YYYY-MM-DD).";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result9 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(roomnum, out roomnumber) || roomnumber <= 0)
            {
                string title1 = "Invalid room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!DateTime.TryParse(startdate, out start_date))
            {
                string title1 = "Invalid start date";
                string message1 = "Please check if the start date is valid (YYYY-MM-DD).";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result11 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!DateTime.TryParse(enddate, out end_date))
            {
                string title1 = "Invalid end date";
                string message1 = "Please check if the end date is valid (YYYY-MM-DD).";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result12 = MessageBox.Show(message1, title1, button);
                return;
            }
            string finalroom = "Room " + roomnumber;
            MySqlCommand checkOccupy = new MySqlCommand($"SELECT COUNT(*) from occupantdata where INSTR(person_name, TRIM('{name}')) and room_number_occupied = '{finalroom}'", connect);
            int result = Convert.ToInt32(checkOccupy.ExecuteScalar());
            checkOccupy.Connection = connect;
            if (result != 0)
            {
                string title1 = "Duplicate occupancy";
                string message1 = "This primary guest already occupies the specified room.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand checkName = new MySqlCommand($"SELECT COUNT(*) from occupantdata where INSTR(person_name, TRIM('{name}'))", connect);
            checkName.Connection = connect; int result60 = Convert.ToInt32(checkName.ExecuteScalar());
            if (result60 != 0)
            {
                string title1 = "Duplicate primary guest name";
                string message1 = "This primary guest already exists in the system" +
                    "\nIf this primary guest will occupy a different room" +
                    "\nAdd a number next to the name of the primary guest" +
                    "\nExample: Juan Dela Cruz 2" +
                    "\nTo indicate that this is a reservation for the same primary guest" +
                    "\nBut on a different room instead, to help avoid confusion";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand checkRoom = new MySqlCommand($"SELECT COUNT(*) from hotelroom where room_number = '{finalroom}'", connect);
            int result1 = Convert.ToInt32(checkRoom.ExecuteScalar());
            checkRoom.Connection = connect;
            if (result1 == 0)
            {
                string title1 = "Room number does not exist";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result14 = MessageBox.Show(message1, title1, button);
                return;
            }
            TimeSpan span = end_date.Subtract(start_date);
            int days = span.Days; nightNum = days;
            if (days < 0)
            {
                string title1 = "Invalid date range";
                string message1 = "It seems your start date and end date are reversed.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result14 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (days == 0) { nightNum = 1; }
            MySqlCommand extracttype = new MySqlCommand($"select room_type from hotelroom where room_number = '{finalroom}'", connect);
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
            string tempguest, tempnight;
            if (additionalNum <= 1) { tempguest = " guest"; }
            else { tempguest = " guests"; }
            if (nightNum <= 1) { tempnight = " night"; }
            else { tempnight = " nights"; }
            string finalguest = additionalNum + tempguest;
            string finalnight = nightNum + tempnight;
            bool invalidcapacity = false;
            if (roomtype == "Room Only" && additionalNum > 2) { invalidcapacity = true; }
            else if (roomtype == "Minimalist" && additionalNum > 1) { invalidcapacity = true; }
            else if (roomtype == "Standard" && additionalNum > 4) { invalidcapacity = true; }
            else if (roomtype == "Junior Suite" && additionalNum > 3) { invalidcapacity = true; }
            else if (roomtype == "Standard Suite" && additionalNum > 5) { invalidcapacity = true; }
            else if (roomtype == "Studio" && additionalNum > 4) { invalidcapacity = true; }
            else if (roomtype == "Deluxe" && additionalNum > 6) { invalidcapacity = true; }
            else if (roomtype == "Presidential Suite" && additionalNum > 7) { invalidcapacity = true; }
            else if (roomtype == "Royal Suite" && additionalNum > 7) { invalidcapacity = true; }
            if (invalidcapacity == true)
            {
                string title1 = "Exceeding capacity";
                string message1 = "Please ensure that the number of guests do not exceed the maximum limit of this room.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand extractdetail = new MySqlCommand($"select * from hotelroom where room_number = '{finalroom}'", connect);
            extractdetail.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(extractdetail);
            DataTable table = new DataTable(); adapter.Fill(table);
            int finalLinearDiscount = linearDiscountNumber;
            int finalPercentDiscount = percentDiscountNumber;
            int finalPWDDiscount = pwdDiscountNumber;
            double totalpark = (carparking + bikeparking + motorparking) * nightNum;
            double baserent = (double)table.Rows[0][3], discountedRent = 0, totalbalance;
            double remainingbal;
            double percentTemp = 0, seniorTemp = 0;
            if (finalPercentDiscount != 0) { percentTemp = (baserent * finalPercentDiscount) / 100; }
            if (finalPWDDiscount != 0) { seniorTemp = (baserent * finalPWDDiscount) / 100; }
            if (finalLinearDiscount > ((baserent - seniorTemp) - percentTemp)) { discountedRent = 0; }
            else { discountedRent = ((baserent - seniorTemp) - percentTemp) - finalLinearDiscount; }
            totalbalance = (discountedRent * nightNum) + totalpark;
            double additionalGuestCharge = 0, guestCharge = 0;
            if (additionalNum != 0)
            {
                guestCharge = (discountedRent * 10) / 100;
                additionalGuestCharge = (guestCharge * additionalNum) * nightNum;
                totalbalance += additionalGuestCharge;
            }
            double change = 0;
            if (totalbalance - payment <= 0)
            {
                remainingbal = 0;
                change = payment - totalbalance;
            }
            remainingbal = totalbalance - payment;
            DateTime birth_date = DateTime.Parse(birthdate);
            DateTime current_date = DateTime.Now;
            if (birth_date > current_date)
            {
                string title1 = "Invalid birthdate";
                string message1 = "Please ensure that the birthdate is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            DateTime temp_date = birth_date; int years = -1;
            while (temp_date < current_date) { ++years; temp_date = temp_date.AddYears(1); }
            primaryGuestAge = years; string tempage = "";
            if (primaryGuestAge <= 1) { tempage = " year old"; }
            else { tempage = " years old"; }
            string finalage = primaryGuestAge + tempage;
            bool illegaldate = false;
            DateTime start_rent_date = DateTime.Parse(startdate);
            DateTime end_rent_date = DateTime.Parse(enddate);
            MySqlCommand checkequal = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and start_rent = '{startdate}' and end_rent = '{enddate}'", connect);
            int result30 = Convert.ToInt32(checkequal.ExecuteScalar()); checkequal.Connection = connect;
            if (result30 != 0) { illegaldate = true; }
            if (start_rent_date < current_date || end_rent_date < current_date) { illegaldate = true; }
            MySqlCommand checksmaller = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{startdate}' > start_rent and '{enddate}' < end_rent", connect);
            int result31 = Convert.ToInt32(checksmaller.ExecuteScalar()); checksmaller.Connection = connect;
            if (result31 != 0) { illegaldate = true; }
            MySqlCommand checklarger = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{startdate}' < start_rent and '{enddate}' > end_rent", connect);
            int result32 = Convert.ToInt32(checklarger.ExecuteScalar()); checklarger.Connection = connect;
            if (result32 != 0) { illegaldate = true; }
            MySqlCommand checkstartoverlap = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{startdate}' > start_rent and '{startdate}' < end_rent", connect);
            int result33 = Convert.ToInt32(checkstartoverlap.ExecuteScalar()); checkstartoverlap.Connection = connect;
            if (result33 != 0) { illegaldate = true; }
            MySqlCommand checkendoverlap = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{enddate}' > start_rent and '{enddate}' < end_rent", connect);
            int result34 = Convert.ToInt32(checkendoverlap.ExecuteScalar()); checkendoverlap.Connection = connect;
            if (result34 != 0) { illegaldate = true; }
            MySqlCommand checklessstart = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{startdate}' <= start_rent and '{enddate}' = end_rent", connect);
            int result35 = Convert.ToInt32(checklessstart.ExecuteScalar()); checklessstart.Connection = connect;
            if (result35 != 0) { illegaldate = true; }
            MySqlCommand checkgreatend = new MySqlCommand($"SELECT COUNT(*) from occupantdata where room_number_occupied = '{finalroom}' and '{startdate}' = start_rent and '{enddate}' >= end_rent", connect);
            int result36 = Convert.ToInt32(checkgreatend.ExecuteScalar()); checkgreatend.Connection = connect;
            if (result36 != 0) { illegaldate = true; }
            if (illegaldate == true)
            {
                string title1 = "Illegal date";
                string message1 = "Please ensure that the dates provided are not already occupied or valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand insertguest = new MySqlCommand($"insert into occupantdata values (TRIM('{name}'), '{gender}', '{finalage}', '{birthdate}', '{national}', '{religion}', '{contact}', {payment}, {remainingbal}, {change}, {totalbalance}, {baserent}, {discountedRent}, {totalpark}, '{finalroom}', '{roomtype}', '{finalnight}', '{finalguest}', {additionalGuestCharge}, '{startdate}', '{enddate}')", connect);
            insertguest.Connection = connect; insertguest.ExecuteNonQuery();
            CheckinReceipt(finalroom, roomtype, (int)baserent, name, finalnight, finalguest, (int)totalpark, startdate, enddate, finalLinearDiscount, finalPercentDiscount, (int)percentTemp, finalPWDDiscount, (int)seniorTemp, (int)totalbalance, (int)remainingbal, (int)payment, (int)change, (int)additionalGuestCharge);
            string title5 = "Primary guest has been successfully added";
            string message5 = "This primary guest has been now added into the system.\nPlease give the receipt before the guest leaves the desk.";
            MessageBoxButtons button5 = MessageBoxButtons.OK;
            DialogResult result16 = MessageBox.Show(message5, title5, button5);
            for (int repeat = 0; repeat < additionalNum; ++repeat)
            {
                AdditionalGuest newAdditional = new AdditionalGuest();
                newAdditional.ShowDialog(); this.Close();
            }
        }

        private void CalculatePrice(object sender, EventArgs e)
        {
            string startdate = guestStartDate.Text;
            string enddate = guestEndDate.Text;
            string pay = guestPayment.Text;
            string guestNum = additionalGuestNumber.Text;
            string linearText = linearDiscount.Text;
            string percentText = percentDiscount.Text;
            string pwdText = pwdDiscount.Text;
            string roomnum = guestRoom.Text;
            DateTime start_date;
            DateTime end_date;
            double payment = 0;
            int nightNum = 0, roomnumber = 0;
            int linearDiscountNumber = 0;
            int percentDiscountNumber = 0;
            int pwdDiscountNumber = 0;
            int additionalNum = 0;
            bool canCalculate = true;
            if (roomnum.Contains("\\") || roomnum.Contains("/")) { return; }
            if (!int.TryParse(guestNum, out additionalNum) || additionalNum < 0) { additionalNum = 0; }
            if (!int.TryParse(linearText, out linearDiscountNumber) || linearDiscountNumber < 0) { linearDiscountNumber = 0; }
            if (!int.TryParse(percentText, out percentDiscountNumber) || percentDiscountNumber < 0 || percentDiscountNumber > 100) { percentDiscountNumber = 0; }
            if (!int.TryParse(pwdText, out pwdDiscountNumber) || pwdDiscountNumber < 0 || pwdDiscountNumber > 100) { pwdDiscountNumber = 0; }
            if (!double.TryParse(pay, out payment) || payment < 0) { payment = 0; }
            if (!DateTime.TryParse(startdate, out start_date)) { canCalculate = false; }
            if (!DateTime.TryParse(enddate, out end_date)) { canCalculate = false; }
            if (!int.TryParse(roomnum, out roomnumber) || roomnumber <= 0) { canCalculate = false; }
            if (canCalculate == true)
            {
                TimeSpan span = end_date.Subtract(start_date);
                int days = span.Days; nightNum = days;
                if (days < 0) { return; }
                if (days == 0) { nightNum = 1; }
                string cs = @"server=localhost;userid=root;password=;database=hoteldata";
                var connect = new MySqlConnection(cs); connect.Open();
                string finalroom = "Room " + roomnumber;
                MySqlCommand checkRoom = new MySqlCommand($"SELECT COUNT(*) from hotelroom where room_number = '{finalroom}'", connect);
                int result1 = Convert.ToInt32(checkRoom.ExecuteScalar());
                checkRoom.Connection = connect;
                if (result1 == 0) { return; }
                MySqlCommand extractdetail = new MySqlCommand($"select * from hotelroom where room_number = '{finalroom}'", connect);
                extractdetail.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(extractdetail);
                DataTable table = new DataTable(); adapter.Fill(table);
                int finalLinearDiscount = linearDiscountNumber;
                int finalPercentDiscount = percentDiscountNumber;
                int finalPWDDiscount = pwdDiscountNumber;
                double totalpark = (carparking + bikeparking + motorparking) * nightNum;
                double baserent = (double)table.Rows[0][3], discountedRent, totalbalance;
                double remainingbal;
                double percentTemp = 0, seniorTemp = 0;
                if (finalPercentDiscount != 0) { percentTemp = (baserent * finalPercentDiscount) / 100; }
                if (finalPWDDiscount != 0) { seniorTemp = (baserent * finalPWDDiscount) / 100; }
                if (finalLinearDiscount > ((baserent - seniorTemp) - percentTemp)) { discountedRent = 0; }
                else { discountedRent = ((baserent - seniorTemp) - percentTemp) - finalLinearDiscount; }
                totalbalance = (discountedRent * nightNum) + totalpark;
                double additionalGuestCharge = 0, guestCharge;
                if (additionalNum != 0)
                {
                    guestCharge = (discountedRent * 10) / 100;
                    additionalGuestCharge = (guestCharge * additionalNum) * nightNum;
                    totalbalance += additionalGuestCharge;
                }
                if (totalbalance - payment <= 0) { remainingbal = 0; }
                remainingbal = totalbalance - payment;
                priceLabel.Text = "PHP " + remainingbal;
                additionalCharge.Text = "PHP " + additionalGuestCharge;
            }
        }

        public static void CheckinReceipt(string roomnumber, string roomtype, int roomprice, string guestname, string guestnights, string guestadditional, int guestparkingfee, string startdate, string enddate, int linear, int percent, int percentamount, int senior, int senioramount, int totalamount, int remainbalance, int payment, int change, int guestcharge)
        {
            string room_pricestring = roomprice.ToString();
            string guestparkingstring = guestparkingfee.ToString();
            string linearstring = linear.ToString();
            string percentstring = percent.ToString();
            string percentamountstring = percentamount.ToString();
            string seniorstring = senior.ToString();
            string senioramountstring = senioramount.ToString();

            string totalstring = totalamount.ToString();
            string paymentstring = payment.ToString();
            string remainstring = remainbalance.ToString();
            string changestring = change.ToString();
            string additionalguestcharge = guestcharge.ToString();

            string roomspace = "", roomtypespace = "", roompricespace = "", guestchargespace = "";
            string guestnamespace = "", guestnightspace = "", guestnumberspace = "";
            string guestparkingspace = "", linearspace = "", percentspace = "";
            string percentamountspace = "", seniorspace = "", senioramountspace = "";
            string totalspace = "", paymentspace = "", remainspace = "", changespace = "";

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
            switch (linearstring.Length)
            {
                case 9: linearspace = ""; break;
                case 8: linearspace = " "; break;
                case 7: linearspace = "  "; break;
                case 6: linearspace = "   "; break;
                case 5: linearspace = "    "; break;
                case 4: linearspace = "     "; break;
                case 3: linearspace = "      "; break;
                case 2: linearspace = "       "; break;
                case 1: linearspace = "        "; break;
            }
            switch (percentstring.Length)
            {
                case 3: percentspace = ""; break;
                case 2: percentspace = " "; break;
                case 1: percentspace = "  "; break;
            }
            switch (percentamountstring.Length)
            {
                case 9: percentamountspace = ""; break;
                case 8: percentamountspace = " "; break;
                case 7: percentamountspace = "  "; break;
                case 6: percentamountspace = "   "; break;
                case 5: percentamountspace = "    "; break;
                case 4: percentamountspace = "     "; break;
                case 3: percentamountspace = "      "; break;
                case 2: percentamountspace = "       "; break;
                case 1: percentamountspace = "        "; break;
            }
            switch (seniorstring.Length)
            {
                case 3: seniorspace = ""; break;
                case 2: seniorspace = " "; break;
                case 1: seniorspace = "  "; break;
            }
            switch (senioramountstring.Length)
            {
                case 9: senioramountspace = ""; break;
                case 8: senioramountspace = " "; break;
                case 7: senioramountspace = "  "; break;
                case 6: senioramountspace = "   "; break;
                case 5: senioramountspace = "    "; break;
                case 4: senioramountspace = "     "; break;
                case 3: senioramountspace = "      "; break;
                case 2: senioramountspace = "       "; break;
                case 1: senioramountspace = "        "; break;
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
            switch (remainstring.Length)
            {
                case 9: remainspace = ""; break;
                case 8: remainspace = " "; break;
                case 7: remainspace = "  "; break;
                case 6: remainspace = "   "; break;
                case 5: remainspace = "    "; break;
                case 4: remainspace = "     "; break;
                case 3: remainspace = "      "; break;
                case 2: remainspace = "       "; break;
                case 1: remainspace = "        "; break;
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
            tempformat = string.Format($"\n| Total Amount:                              {totalspace}PHP {totalamount} |");
            receiptformat += tempformat;
            tempformat = string.Format($"\n| Payment:                                   {paymentspace}PHP {payment} |");
            receiptformat += tempformat;
            if (remainbalance > 0)
            {
                tempformat = string.Format($"\n| Remaining Balance:                         {remainspace}PHP {remainbalance} |");
                receiptformat += tempformat;
            }
            if (change > 0)
            {
                tempformat = string.Format($"\n| Change:                                    {changespace}PHP {change} |");
                receiptformat += tempformat;
            }
            tempformat = "\n+----------------------------------------------------------+";
            receiptformat += tempformat;
            if (linear != 0 || percent != 0 || senior != 0)
            {
                if (linear != 0)
                {
                    tempformat = string.Format($"\n| Linear discount:                           {linearspace}PHP {linear} |");
                    receiptformat += tempformat;
                }
                if (percent != 0)
                {
                    tempformat = string.Format($"\n| Percent discount:                   {percentamountspace}{percentspace}{percent}% (PHP {percentamount}) |");
                    receiptformat += tempformat;
                }
                if (senior != 0)
                {
                    tempformat = string.Format($"\n| PWD/Senior discount:                {senioramountspace}{seniorspace}{senior}% (PHP {senioramount}) |");
                    receiptformat += tempformat;
                }
                tempformat = "\n+----------------------------------------------------------+";
                receiptformat += tempformat;
            }
            if (remainbalance > 0)
            {
                tempformat = "\n|  Please settle your balances before or on your end date  |";
                receiptformat += tempformat;
                tempformat = "\n+----------------------------------------------------------+";
                receiptformat += tempformat;
            }
            ReceiptPrint(receiptformat);
            return;
        }

        static void ReceiptPrint(string receipt)
        {
            string receiptname = DateTime.Now.ToString("C\\heckinReceip\\t_yyyyMMdd_HHmmss");
            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            string fileName = string.Format("{0}.xml", receiptname);
            XmlSerializer processReceipt = new XmlSerializer(typeof(string));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter receiptFile = XmlWriter.Create(fileName, settings);
            processReceipt.Serialize(receiptFile, receipt, emptyNamespaces);
            receiptFile.Close(); return;
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
            if (table2.Rows.Count <= 0) { }
            else if (table2.Rows.Count != 0)
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
            if (table3.Rows.Count <= 0) { }
            else if (table3.Rows.Count != 0)
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
    }
}
