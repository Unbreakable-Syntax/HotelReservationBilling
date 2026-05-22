namespace HotelReservationBilling
{
    partial class PrimaryGuest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guestBirthdate = new System.Windows.Forms.TextBox();
            this.guestContact = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.guestRoom = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.guestEndDate = new System.Windows.Forms.TextBox();
            this.guestStartDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guestReligion = new System.Windows.Forms.TextBox();
            this.guestNational = new System.Windows.Forms.TextBox();
            this.guestPayment = new System.Windows.Forms.TextBox();
            this.guestGender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guestName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.carParked = new System.Windows.Forms.CheckBox();
            this.motorbikeParked = new System.Windows.Forms.CheckBox();
            this.bikeParked = new System.Windows.Forms.CheckBox();
            this.addGuest = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pwdDiscount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.percentDiscount = new System.Windows.Forms.TextBox();
            this.linearDiscount = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.additionalGuestNumber = new System.Windows.Forms.TextBox();
            this.fillPreviousData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.additionalCharge = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guestBirthdate
            // 
            this.guestBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestBirthdate.Location = new System.Drawing.Point(236, 238);
            this.guestBirthdate.Name = "guestBirthdate";
            this.guestBirthdate.Size = new System.Drawing.Size(177, 24);
            this.guestBirthdate.TabIndex = 86;
            // 
            // guestContact
            // 
            this.guestContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestContact.Location = new System.Drawing.Point(236, 198);
            this.guestContact.Name = "guestContact";
            this.guestContact.Size = new System.Drawing.Size(177, 24);
            this.guestContact.TabIndex = 85;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(102, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 18);
            this.label11.TabIndex = 84;
            this.label11.Text = "Guest birthdate:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(59, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 18);
            this.label12.TabIndex = 83;
            this.label12.Text = "Guest contact number:";
            // 
            // guestRoom
            // 
            this.guestRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestRoom.Location = new System.Drawing.Point(236, 277);
            this.guestRoom.Name = "guestRoom";
            this.guestRoom.Size = new System.Drawing.Size(177, 24);
            this.guestRoom.TabIndex = 82;
            this.guestRoom.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(110, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 18);
            this.label10.TabIndex = 81;
            this.label10.Text = "Room number:";
            // 
            // guestEndDate
            // 
            this.guestEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestEndDate.Location = new System.Drawing.Point(236, 358);
            this.guestEndDate.Name = "guestEndDate";
            this.guestEndDate.Size = new System.Drawing.Size(177, 24);
            this.guestEndDate.TabIndex = 80;
            this.guestEndDate.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // guestStartDate
            // 
            this.guestStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestStartDate.Location = new System.Drawing.Point(236, 317);
            this.guestStartDate.Name = "guestStartDate";
            this.guestStartDate.Size = new System.Drawing.Size(177, 24);
            this.guestStartDate.TabIndex = 78;
            this.guestStartDate.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(120, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 18);
            this.label8.TabIndex = 76;
            this.label8.Text = "End rent date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(115, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 18);
            this.label9.TabIndex = 75;
            this.label9.Text = "Start rent date:";
            // 
            // guestReligion
            // 
            this.guestReligion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestReligion.Location = new System.Drawing.Point(236, 158);
            this.guestReligion.Name = "guestReligion";
            this.guestReligion.Size = new System.Drawing.Size(177, 24);
            this.guestReligion.TabIndex = 74;
            // 
            // guestNational
            // 
            this.guestNational.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNational.Location = new System.Drawing.Point(236, 116);
            this.guestNational.Name = "guestNational";
            this.guestNational.Size = new System.Drawing.Size(177, 24);
            this.guestNational.TabIndex = 73;
            // 
            // guestPayment
            // 
            this.guestPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestPayment.Location = new System.Drawing.Point(236, 397);
            this.guestPayment.Name = "guestPayment";
            this.guestPayment.Size = new System.Drawing.Size(177, 24);
            this.guestPayment.TabIndex = 72;
            this.guestPayment.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // guestGender
            // 
            this.guestGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestGender.Location = new System.Drawing.Point(236, 77);
            this.guestGender.Name = "guestGender";
            this.guestGender.Size = new System.Drawing.Size(177, 24);
            this.guestGender.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 69;
            this.label6.Text = "Guest religion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 18);
            this.label5.TabIndex = 68;
            this.label5.Text = "Guest nationality:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 18);
            this.label4.TabIndex = 67;
            this.label4.Text = "Guest payment amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Guest gender:";
            // 
            // guestName
            // 
            this.guestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestName.Location = new System.Drawing.Point(236, 38);
            this.guestName.Name = "guestName";
            this.guestName.Size = new System.Drawing.Size(177, 24);
            this.guestName.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Guest name:";
            // 
            // carParked
            // 
            this.carParked.AutoSize = true;
            this.carParked.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carParked.Location = new System.Drawing.Point(539, 101);
            this.carParked.Name = "carParked";
            this.carParked.Size = new System.Drawing.Size(99, 22);
            this.carParked.TabIndex = 87;
            this.carParked.Text = "Parked car";
            this.carParked.UseVisualStyleBackColor = true;
            this.carParked.CheckedChanged += new System.EventHandler(this.carParked_CheckedChanged);
            // 
            // motorbikeParked
            // 
            this.motorbikeParked.AutoSize = true;
            this.motorbikeParked.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motorbikeParked.Location = new System.Drawing.Point(539, 128);
            this.motorbikeParked.Name = "motorbikeParked";
            this.motorbikeParked.Size = new System.Drawing.Size(145, 22);
            this.motorbikeParked.TabIndex = 88;
            this.motorbikeParked.Text = "Parked motorbike";
            this.motorbikeParked.UseVisualStyleBackColor = true;
            this.motorbikeParked.CheckedChanged += new System.EventHandler(this.motorbikeParked_CheckedChanged);
            // 
            // bikeParked
            // 
            this.bikeParked.AutoSize = true;
            this.bikeParked.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bikeParked.Location = new System.Drawing.Point(539, 156);
            this.bikeParked.Name = "bikeParked";
            this.bikeParked.Size = new System.Drawing.Size(105, 22);
            this.bikeParked.TabIndex = 89;
            this.bikeParked.Text = "Parked bike";
            this.bikeParked.UseVisualStyleBackColor = true;
            this.bikeParked.CheckedChanged += new System.EventHandler(this.bikeParked_CheckedChanged);
            // 
            // addGuest
            // 
            this.addGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGuest.Location = new System.Drawing.Point(334, 454);
            this.addGuest.Name = "addGuest";
            this.addGuest.Size = new System.Drawing.Size(134, 32);
            this.addGuest.TabIndex = 90;
            this.addGuest.Text = "Add primary guest";
            this.addGuest.UseVisualStyleBackColor = true;
            this.addGuest.Click += new System.EventHandler(this.addGuest_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label13.Location = new System.Drawing.Point(465, 362);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(158, 18);
            this.label13.TabIndex = 96;
            this.label13.Text = "PWD/Senior Discount:";
            // 
            // pwdDiscount
            // 
            this.pwdDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.pwdDiscount.Location = new System.Drawing.Point(629, 365);
            this.pwdDiscount.Name = "pwdDiscount";
            this.pwdDiscount.Size = new System.Drawing.Size(106, 24);
            this.pwdDiscount.TabIndex = 95;
            this.pwdDiscount.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label14.Location = new System.Drawing.Point(511, 302);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 18);
            this.label14.TabIndex = 93;
            this.label14.Text = "Linear discount:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label15.Location = new System.Drawing.Point(497, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 18);
            this.label15.TabIndex = 94;
            this.label15.Text = "Percent discount: ";
            // 
            // percentDiscount
            // 
            this.percentDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.percentDiscount.Location = new System.Drawing.Point(629, 335);
            this.percentDiscount.Name = "percentDiscount";
            this.percentDiscount.Size = new System.Drawing.Size(106, 24);
            this.percentDiscount.TabIndex = 92;
            this.percentDiscount.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // linearDiscount
            // 
            this.linearDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.linearDiscount.Location = new System.Drawing.Point(629, 303);
            this.linearDiscount.Name = "linearDiscount";
            this.linearDiscount.Size = new System.Drawing.Size(106, 24);
            this.linearDiscount.TabIndex = 91;
            this.linearDiscount.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label16.Location = new System.Drawing.Point(466, 202);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(174, 18);
            this.label16.TabIndex = 99;
            this.label16.Text = "(Excluding primary guest)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label17.Location = new System.Drawing.Point(454, 229);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(196, 18);
            this.label17.TabIndex = 98;
            this.label17.Text = "Number of additional guests:";
            // 
            // additionalGuestNumber
            // 
            this.additionalGuestNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.additionalGuestNumber.Location = new System.Drawing.Point(656, 226);
            this.additionalGuestNumber.Name = "additionalGuestNumber";
            this.additionalGuestNumber.Size = new System.Drawing.Size(106, 24);
            this.additionalGuestNumber.TabIndex = 97;
            this.additionalGuestNumber.TextChanged += new System.EventHandler(this.CalculatePrice);
            // 
            // fillPreviousData
            // 
            this.fillPreviousData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fillPreviousData.Location = new System.Drawing.Point(539, 38);
            this.fillPreviousData.Name = "fillPreviousData";
            this.fillPreviousData.Size = new System.Drawing.Size(176, 48);
            this.fillPreviousData.TabIndex = 100;
            this.fillPreviousData.Text = "Fill personal details from previous booking";
            this.fillPreviousData.UseVisualStyleBackColor = true;
            this.fillPreviousData.Click += new System.EventHandler(this.fillPreviousData_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(484, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "Amount to Pay:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(593, 401);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(0, 20);
            this.priceLabel.TabIndex = 102;
            // 
            // additionalCharge
            // 
            this.additionalCharge.AutoSize = true;
            this.additionalCharge.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.additionalCharge.Location = new System.Drawing.Point(629, 259);
            this.additionalCharge.Name = "additionalCharge";
            this.additionalCharge.Size = new System.Drawing.Size(0, 20);
            this.additionalCharge.TabIndex = 104;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(455, 259);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(174, 20);
            this.label18.TabIndex = 103;
            this.label18.Text = "Additional Guest Charge:";
            // 
            // PrimaryGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(805, 507);
            this.Controls.Add(this.additionalCharge);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fillPreviousData);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.additionalGuestNumber);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pwdDiscount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.percentDiscount);
            this.Controls.Add(this.linearDiscount);
            this.Controls.Add(this.addGuest);
            this.Controls.Add(this.bikeParked);
            this.Controls.Add(this.motorbikeParked);
            this.Controls.Add(this.carParked);
            this.Controls.Add(this.guestBirthdate);
            this.Controls.Add(this.guestContact);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.guestRoom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.guestEndDate);
            this.Controls.Add(this.guestStartDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guestReligion);
            this.Controls.Add(this.guestNational);
            this.Controls.Add(this.guestPayment);
            this.Controls.Add(this.guestGender);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guestName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrimaryGuest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter details of primary guest";
            this.Shown += new System.EventHandler(this.PrimaryGuest_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox guestBirthdate;
        private System.Windows.Forms.TextBox guestContact;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox guestRoom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox guestEndDate;
        private System.Windows.Forms.TextBox guestStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox guestReligion;
        private System.Windows.Forms.TextBox guestNational;
        private System.Windows.Forms.TextBox guestPayment;
        private System.Windows.Forms.TextBox guestGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox guestName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox carParked;
        private System.Windows.Forms.CheckBox motorbikeParked;
        private System.Windows.Forms.CheckBox bikeParked;
        private System.Windows.Forms.Button addGuest;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox pwdDiscount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox percentDiscount;
        private System.Windows.Forms.TextBox linearDiscount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox additionalGuestNumber;
        private System.Windows.Forms.Button fillPreviousData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label additionalCharge;
        private System.Windows.Forms.Label label18;
    }
}