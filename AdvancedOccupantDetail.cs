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
    public partial class AdvancedOccupantDetail : Form
    {
        public AdvancedOccupantDetail()
        {
            InitializeComponent();
        }

        private void AdvancedOccupantDetail_Shown(object sender, EventArgs e)
        {
            this.BringToFront(); this.Activate();
        }

        private void backButton1_Click(object sender, EventArgs e)
        { this.Close(); }

        private void updateAdvancedOccupantButton_Click(object sender, EventArgs e)
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
            string totalbal = occupantTotalBalance.Text;
            string remainbal = occupantRemainBalance.Text;
            string payment = occupantPayment.Text;
            string origrent = occupantOriginalRent.Text;
            string discountrent = occupantDiscountRent.Text;
            string roomnumber = occupantRoomNumber.Text;
            string startdate = occupantStartDate.Text;
            string enddate = occupantEndDate.Text;
            string parking = occupantParkingRate.Text;
            string guests = occupantGuests.Text;
            string nights = occupantNights.Text;
            string change = changeAmount.Text;
            string guestAmount = guestCharge.Text;
            string currentroom = roomNumber.Text;
            int guestCost = 0, changeTotal = 0, current_room_number = 0;
            double remain_balance = 0, total_balance = 0, pay_balance = 0, parking_rate = 0;
            int original_rent = 0, discount_rent = 0, room_number = 0, guestNum = 0, nightNum = 0;
            DateTime start_date = new DateTime(), end_date = new DateTime();
            bool completeDetail = false, canContinue = true;
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 1)
            {
                string title1 = "Invalid occupant name";
                string message1 = "Please check if the occupant name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(currentroom))
            {
                string title1 = "Blank room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(currentroom, out current_room_number))
            {
                string title1 = "Invalid room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else { currentroom = "Room " + current_room_number; }
            if (!string.IsNullOrWhiteSpace(totalbal) && !string.IsNullOrWhiteSpace(change) && !string.IsNullOrWhiteSpace(guestAmount) && !string.IsNullOrWhiteSpace(guests) && !string.IsNullOrWhiteSpace(nights) && !string.IsNullOrWhiteSpace(parking) && !string.IsNullOrWhiteSpace(remainbal) && !string.IsNullOrWhiteSpace(payment) && !string.IsNullOrWhiteSpace(origrent) && !string.IsNullOrWhiteSpace(discountrent) && !string.IsNullOrWhiteSpace(roomnumber) && !string.IsNullOrWhiteSpace(startdate) && !string.IsNullOrWhiteSpace(enddate))
            {
                completeDetail = true;
                if (!double.TryParse(totalbal, out total_balance) || total_balance < 0)
                {
                    string title1 = "Invalid occupant total balance";
                    string message1 = "Please check if the occupant total balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(guests, out guestNum) || guestNum < 0)
                {
                    string title1 = "Invalid occupant number of additional guests";
                    string message1 = "Please check if the occupant number of additional guests is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(change, out changeTotal) || changeTotal < 0)
                {
                    string title1 = "Invalid occupant change amount";
                    string message1 = "Please check if the occupant change amount is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(guestAmount, out guestCost) || guestCost < 0)
                {
                    string title1 = "Invalid occupant additional guest cost";
                    string message1 = "Please check if the occupant additional guest cost is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(nights, out nightNum) || nightNum < 0)
                {
                    string title1 = "Invalid occupant number of nights";
                    string message1 = "Please check if the occupant number of nights is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(remainbal, out remain_balance) || remain_balance < 0)
                {
                    string title1 = "Invalid occupant remaining balance";
                    string message1 = "Please check if the occupant remaining balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(parking, out parking_rate) || parking_rate < 0)
                {
                    string title1 = "Invalid occupant parking rate";
                    string message1 = "Please check if the occupant parking rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!double.TryParse(payment, out pay_balance) || pay_balance < 0)
                {
                    string title1 = "Invalid occupant payment balance";
                    string message1 = "Please check if the occupant payment balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(origrent, out original_rent) || original_rent < 0)
                {
                    string title1 = "Invalid occupant original rent rate";
                    string message1 = "Please check if the occupant original rent rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(discountrent, out discount_rent) || discount_rent < 0)
                {
                    string title1 = "Invalid occupant discounted rent rate";
                    string message1 = "Please check if the occupant discounted rent rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!int.TryParse(roomnumber, out room_number) || room_number < 0)
                {
                    string title1 = "Invalid occupant room number";
                    string message1 = "Please check if the occupant room number is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!DateTime.TryParse(startdate, out start_date))
                {
                    string title1 = "Invalid occupant rent start date";
                    string message1 = "Please check if the occupant rent start date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!DateTime.TryParse(enddate, out end_date))
                {
                    string title1 = "Invalid occupant rent end date";
                    string message1 = "Please check if the occupant rent end date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (completeDetail == false)
            {
                if (!string.IsNullOrWhiteSpace(totalbal) && !double.TryParse(totalbal, out total_balance) || total_balance < 0)
                {
                    string title1 = "Invalid occupant total balance";
                    string message1 = "Please check if the occupant total balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(guests) && !int.TryParse(guests, out guestNum) || guestNum < 0)
                {
                    string title1 = "Invalid occupant number of additional guests";
                    string message1 = "Please check if the occupant number of additional guests is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(change) && !int.TryParse(change, out changeTotal) || changeTotal < 0)
                {
                    string title1 = "Invalid occupant change amount";
                    string message1 = "Please check if the occupant change amount is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(guestAmount) && !int.TryParse(guestAmount, out guestCost) || guestCost < 0)
                {
                    string title1 = "Invalid occupant additional guest cost";
                    string message1 = "Please check if the occupant additional guest cost is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(nights) && !int.TryParse(nights, out nightNum) || nightNum < 0)
                {
                    string title1 = "Invalid occupant number of nights";
                    string message1 = "Please check if the occupant number of nights is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(remainbal) && !double.TryParse(remainbal, out remain_balance) || remain_balance < 0)
                {
                    string title1 = "Invalid occupant remaining balance";
                    string message1 = "Please check if the occupant remaining balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(parking) && !double.TryParse(parking, out parking_rate) || parking_rate < 0)
                {
                    string title1 = "Invalid occupant parking rate";
                    string message1 = "Please check if the occupant parking rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(payment) && !double.TryParse(payment, out pay_balance) || pay_balance < 0)
                {
                    string title1 = "Invalid occupant payment balance";
                    string message1 = "Please check if the occupant payment balance is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(origrent) && !int.TryParse(origrent, out original_rent) || original_rent < 0)
                {
                    string title1 = "Invalid occupant original rent rate";
                    string message1 = "Please check if the occupant original rent rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(discountrent) && !int.TryParse(discountrent, out discount_rent) || discount_rent < 0)
                {
                    string title1 = "Invalid occupant discounted rent rate";
                    string message1 = "Please check if the occupant discounted rent rate is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(roomnumber) && !int.TryParse(roomnumber, out room_number) || room_number < 0)
                {
                    string title1 = "Invalid occupant room number";
                    string message1 = "Please check if the occupant room number is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(startdate) && !DateTime.TryParse(startdate, out start_date))
                {
                    string title1 = "Invalid occupant rent start date";
                    string message1 = "Please check if the occupant rent start date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(enddate) && !DateTime.TryParse(enddate, out end_date))
                {
                    string title1 = "Invalid occupant rent end date";
                    string message1 = "Please check if the occupant rent end date is valid.";
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    DialogResult result1 = MessageBox.Show(message1, title1, button);
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(currentroom) && string.IsNullOrWhiteSpace(guests) && string.IsNullOrWhiteSpace(nights) && string.IsNullOrWhiteSpace(parking) && string.IsNullOrWhiteSpace(totalbal) && string.IsNullOrWhiteSpace(remainbal) && string.IsNullOrWhiteSpace(payment) && string.IsNullOrWhiteSpace(origrent) && string.IsNullOrWhiteSpace(discountrent) && string.IsNullOrWhiteSpace(roomnumber) && string.IsNullOrWhiteSpace(startdate) && string.IsNullOrWhiteSpace(enddate))
            {
                string title1 = "Details are empty";
                string message1 = "Please ensure that at least 1 detail is not empty.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            MySqlCommand command1 = new MySqlCommand($"SELECT COUNT(*) from occupantdata WHERE person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
            int result8 = Convert.ToInt32(command1.ExecuteScalar());
            command1.Connection = connect;
            if (result8 == 0)
            {
                canContinue = false;
                string title1 = "Occupant update unsuccessful";
                string message1 = "The indicated occupant does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                occupantName.Clear();
            }
            string tempnight = "", tempguest = "";
            if (nightNum <= 1) { tempnight = " night"; } else { tempnight = " nights"; }
            if (guestNum <= 1) { tempguest = " guest"; } else { tempguest = " guests"; }
            string finalroom = "Room " + room_number;
            string finalguest = guestNum + tempguest;
            string finalnight = nightNum + tempnight;
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
            MySqlCommand command2 = new MySqlCommand($"SELECT COUNT(*) from hotelroom WHERE room_number = '{finalroom}'", connect);
            int result9 = Convert.ToInt32(command2.ExecuteScalar());
            command2.Connection = connect;
            if (result9 == 0)
            {
                canContinue = false;
                string title1 = "Occupant update unsuccessful";
                string message1 = "The indicated room number does not exist.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                occupantRoomNumber.Clear();
            }
            if (canContinue == true)
            {
                if (completeDetail == true)
                {
                    MySqlCommand commandzero = new MySqlCommand($"update occupantdata set person_total_bal = {total_balance}, person_change = {changeTotal}, person_remain_bal = {remain_balance}, person_down_pay = {pay_balance}, parking_rate = {parking_rate}, person_orig_rate = {original_rent}, person_discount_rate = {discount_rent}, room_number_occupied = '{finalroom}', room_type = '{roomtype}', number_of_nights = '{finalnight}', number_of_additional_guests = '{finalguest}', guest_charge = {guestCost}, start_rent = '{startdate}', end_rent = '{enddate}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                    commandzero.Connection = connect; commandzero.ExecuteNonQuery();
                }
                else if (completeDetail == false)
                {
                    if (!string.IsNullOrWhiteSpace(totalbal))
                    {
                        MySqlCommand commandone = new MySqlCommand($"update occupantdata set person_total_bal = {total_balance} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandone.Connection = connect; commandone.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(change))
                    {
                        MySqlCommand commandthirteen = new MySqlCommand($"update occupantdata set person_change = {changeTotal} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandthirteen.Connection = connect; commandthirteen.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(guestAmount))
                    {
                        MySqlCommand commandtwelve = new MySqlCommand($"update occupantdata set guest_charge = {guestCost} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandtwelve.Connection = connect; commandtwelve.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(remainbal))
                    {
                        MySqlCommand commandtwo = new MySqlCommand($"update occupantdata set person_remain_bal = {remain_balance} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandtwo.Connection = connect; commandtwo.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(payment))
                    {
                        MySqlCommand commandnine = new MySqlCommand($"update occupantdata set person_down_pay = {pay_balance} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandnine.Connection = connect; commandnine.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(guests))
                    {
                        MySqlCommand commandten = new MySqlCommand($"update occupantdata set number_of_additional_guests = '{finalguest}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandten.Connection = connect; commandten.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(nights))
                    {
                        MySqlCommand commandeleven = new MySqlCommand($"update occupantdata set number_of_nights = '{finalnight}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandeleven.Connection = connect; commandeleven.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(parking))
                    {
                        MySqlCommand commandthree = new MySqlCommand($"update occupantdata set parking_rate = {parking_rate} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandthree.Connection = connect; commandthree.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(origrent))
                    {
                        MySqlCommand commandfour = new MySqlCommand($"update occupantdata set person_orig_rate = {original_rent} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandfour.Connection = connect; commandfour.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(discountrent))
                    {
                        MySqlCommand commandfive = new MySqlCommand($"update occupantdata set person_discount_rate = {discount_rent} where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandfive.Connection = connect; commandfive.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(roomnumber))
                    {
                        MySqlCommand commandsix = new MySqlCommand($"update occupantdata set room_number_occupied = '{finalroom}', room_type = '{roomtype}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandsix.Connection = connect; commandsix.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(startdate))
                    {
                        MySqlCommand commandseven = new MySqlCommand($"update occupantdata set start_rent = '{startdate}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandseven.Connection = connect; commandseven.ExecuteNonQuery();
                    }
                    if (!string.IsNullOrWhiteSpace(enddate))
                    {
                        MySqlCommand commandeight = new MySqlCommand($"update occupantdata set end_rent = '{enddate}' where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
                        commandeight.Connection = connect; commandeight.ExecuteNonQuery();
                    }
                }
                string title1 = "Occupant update successful";
                string message1 = "The details of the occupant has been updated successfully.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                occupantName.Clear(); roomNumber.Clear();
                occupantGuests.Clear();
                occupantNights.Clear();
                occupantTotalBalance.Clear();
                occupantRemainBalance.Clear();
                occupantPayment.Clear();
                guestCharge.Clear(); changeAmount.Clear();
                occupantOriginalRent.Clear();
                occupantDiscountRent.Clear();
                occupantRoomNumber.Clear();
                occupantGuests.Clear();
                occupantNights.Clear();
                occupantParkingRate.Clear();
            }
        }

        private void findData_Click(object sender, EventArgs e)
        {
            string name = occupantName.Text, currentroom = roomNumber.Text;
            int current_room_number = 0;
            if (string.IsNullOrWhiteSpace(name) || name.Length <= 1)
            {
                string title1 = "Invalid occupant name";
                string message1 = "Please check if the occupant name is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (string.IsNullOrWhiteSpace(currentroom))
            {
                string title1 = "Blank room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            if (!int.TryParse(currentroom, out current_room_number))
            {
                string title1 = "Invalid room number";
                string message1 = "Please check if the room number is valid.";
                MessageBoxButtons button = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, button);
                return;
            }
            else { currentroom = "Room " + current_room_number; }
            string cs = @"server=localhost;userid=root;password=;database=hoteldata;convert zero datetime=True";
            var connect = new MySqlConnection(cs); connect.Open();
            MySqlCommand command = new MySqlCommand($"select * from occupantdata where person_name = '{name}' and room_number_occupied = '{currentroom}'", connect);
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
                occupantPayment.Text = table.Rows[0][7].ToString();
                occupantRemainBalance.Text = table.Rows[0][8].ToString();
                occupantTotalBalance.Text = table.Rows[0][9].ToString();
                changeAmount.Text = table.Rows[0][10].ToString();
                occupantOriginalRent.Text = table.Rows[0][11].ToString();
                occupantDiscountRent.Text = table.Rows[0][12].ToString();
                occupantParkingRate.Text = table.Rows[0][13].ToString();
                occupantRoomNumber.Text = table.Rows[0][14].ToString();
                occupantNights.Text = table.Rows[0][16].ToString();
                occupantGuests.Text = table.Rows[0][17].ToString();
                guestCharge.Text = table.Rows[0][18].ToString();
                string start_date = table.Rows[0][19].ToString();
                start_date = DateTime.Parse(start_date).ToString("yyyy-MM-dd");
                occupantStartDate.Text = start_date;
                string end_date = table.Rows[0][20].ToString();
                end_date = DateTime.Parse(end_date).ToString("yyyy-MM-dd");
                occupantEndDate.Text = end_date;
            }
        }

        private void AdvancedOccupantDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
