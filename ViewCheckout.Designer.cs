namespace HotelReservationBilling
{
    partial class ViewCheckout
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
            this.checkoutHistoryTable = new System.Windows.Forms.DataGridView();
            this.guestName = new System.Windows.Forms.TextBox();
            this.guestRoom = new System.Windows.Forms.TextBox();
            this.guestStartDate = new System.Windows.Forms.TextBox();
            this.guestType = new System.Windows.Forms.TextBox();
            this.guestEndDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.otherDetailSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.checkoutHistoryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // checkoutHistoryTable
            // 
            this.checkoutHistoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkoutHistoryTable.Location = new System.Drawing.Point(42, 156);
            this.checkoutHistoryTable.Name = "checkoutHistoryTable";
            this.checkoutHistoryTable.Size = new System.Drawing.Size(805, 305);
            this.checkoutHistoryTable.TabIndex = 0;
            // 
            // guestName
            // 
            this.guestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestName.Location = new System.Drawing.Point(180, 19);
            this.guestName.Name = "guestName";
            this.guestName.Size = new System.Drawing.Size(122, 24);
            this.guestName.TabIndex = 1;
            this.guestName.TextChanged += new System.EventHandler(this.guestName_TextChanged);
            // 
            // guestRoom
            // 
            this.guestRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestRoom.Location = new System.Drawing.Point(324, 63);
            this.guestRoom.Name = "guestRoom";
            this.guestRoom.Size = new System.Drawing.Size(110, 24);
            this.guestRoom.TabIndex = 2;
            this.guestRoom.TextChanged += new System.EventHandler(this.guestRoom_TextChanged);
            // 
            // guestStartDate
            // 
            this.guestStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestStartDate.Location = new System.Drawing.Point(429, 19);
            this.guestStartDate.Name = "guestStartDate";
            this.guestStartDate.Size = new System.Drawing.Size(122, 24);
            this.guestStartDate.TabIndex = 3;
            this.guestStartDate.TextChanged += new System.EventHandler(this.guestStartDate_TextChanged);
            // 
            // guestType
            // 
            this.guestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestType.Location = new System.Drawing.Point(559, 63);
            this.guestType.Name = "guestType";
            this.guestType.Size = new System.Drawing.Size(126, 24);
            this.guestType.TabIndex = 4;
            this.guestType.TextChanged += new System.EventHandler(this.guestType_TextChanged);
            // 
            // guestEndDate
            // 
            this.guestEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestEndDate.Location = new System.Drawing.Point(676, 19);
            this.guestEndDate.Name = "guestEndDate";
            this.guestEndDate.Size = new System.Drawing.Size(129, 24);
            this.guestEndDate.TabIndex = 5;
            this.guestEndDate.TextChanged += new System.EventHandler(this.guestEndDate_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Guest name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Guest room number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Start rent date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(571, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "End rent date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(470, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Guest type:";
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(327, 476);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 29);
            this.backButton.TabIndex = 25;
            this.backButton.Text = "Back to Menu";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // otherDetailSearch
            // 
            this.otherDetailSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherDetailSearch.Location = new System.Drawing.Point(420, 109);
            this.otherDetailSearch.Name = "otherDetailSearch";
            this.otherDetailSearch.Size = new System.Drawing.Size(217, 24);
            this.otherDetailSearch.TabIndex = 26;
            this.otherDetailSearch.TextChanged += new System.EventHandler(this.otherDetailSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(225, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Enter other detail to search:";
            // 
            // ViewCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(890, 517);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.otherDetailSearch);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guestEndDate);
            this.Controls.Add(this.guestType);
            this.Controls.Add(this.guestStartDate);
            this.Controls.Add(this.guestRoom);
            this.Controls.Add(this.guestName);
            this.Controls.Add(this.checkoutHistoryTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ViewCheckout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check out history";
            ((System.ComponentModel.ISupportInitialize)(this.checkoutHistoryTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView checkoutHistoryTable;
        private System.Windows.Forms.TextBox guestName;
        private System.Windows.Forms.TextBox guestRoom;
        private System.Windows.Forms.TextBox guestStartDate;
        private System.Windows.Forms.TextBox guestType;
        private System.Windows.Forms.TextBox guestEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox otherDetailSearch;
        private System.Windows.Forms.Label label6;
    }
}