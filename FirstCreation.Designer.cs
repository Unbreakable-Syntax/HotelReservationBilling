namespace HotelReservationBilling
{
    partial class FirstCreation
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
            this.addButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.showPassword1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adminUsername = new System.Windows.Forms.TextBox();
            this.adminPass = new System.Windows.Forms.TextBox();
            this.firstCreate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showPassword2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(465, 243);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 31);
            this.addButton.TabIndex = 34;
            this.addButton.Text = "Add account";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(265, 243);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(53, 31);
            this.backButton.TabIndex = 33;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // showPassword1
            // 
            this.showPassword1.AutoSize = true;
            this.showPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword1.Location = new System.Drawing.Point(592, 128);
            this.showPassword1.Name = "showPassword1";
            this.showPassword1.Size = new System.Drawing.Size(126, 21);
            this.showPassword1.TabIndex = 32;
            this.showPassword1.Text = "Show Password";
            this.showPassword1.UseVisualStyleBackColor = true;
            this.showPassword1.CheckedChanged += new System.EventHandler(this.showPassword1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(160, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "New username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "New password:";
            // 
            // adminUsername
            // 
            this.adminUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminUsername.Location = new System.Drawing.Point(297, 63);
            this.adminUsername.Name = "adminUsername";
            this.adminUsername.Size = new System.Drawing.Size(277, 26);
            this.adminUsername.TabIndex = 29;
            // 
            // adminPass
            // 
            this.adminPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPass.Location = new System.Drawing.Point(297, 123);
            this.adminPass.Name = "adminPass";
            this.adminPass.Size = new System.Drawing.Size(277, 26);
            this.adminPass.TabIndex = 28;
            this.adminPass.UseSystemPasswordChar = true;
            // 
            // firstCreate
            // 
            this.firstCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstCreate.Location = new System.Drawing.Point(297, 183);
            this.firstCreate.Name = "firstCreate";
            this.firstCreate.Size = new System.Drawing.Size(277, 26);
            this.firstCreate.TabIndex = 35;
            this.firstCreate.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "New account creation password:";
            // 
            // showPassword2
            // 
            this.showPassword2.AutoSize = true;
            this.showPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword2.Location = new System.Drawing.Point(592, 188);
            this.showPassword2.Name = "showPassword2";
            this.showPassword2.Size = new System.Drawing.Size(126, 21);
            this.showPassword2.TabIndex = 37;
            this.showPassword2.Text = "Show Password";
            this.showPassword2.UseVisualStyleBackColor = true;
            this.showPassword2.CheckedChanged += new System.EventHandler(this.showPassword2_CheckedChanged);
            // 
            // FirstCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(800, 319);
            this.Controls.Add(this.showPassword2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.firstCreate);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.showPassword1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.adminUsername);
            this.Controls.Add(this.adminPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FirstCreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "First Administrator Account Creation";
            this.Activated += new System.EventHandler(this.FirstCreation_Activated);
            this.Load += new System.EventHandler(this.FirstCreation_Activated);
            this.Shown += new System.EventHandler(this.FirstCreation_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.CheckBox showPassword1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adminUsername;
        private System.Windows.Forms.TextBox adminPass;
        private System.Windows.Forms.TextBox firstCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showPassword2;
    }
}