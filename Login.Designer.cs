namespace HotelReservationBilling
{
    partial class Login
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
            this.proceedMenuButton = new System.Windows.Forms.Button();
            this.loginAdminButton = new System.Windows.Forms.Button();
            this.loginUserButton = new System.Windows.Forms.Button();
            this.removeAdminButton = new System.Windows.Forms.Button();
            this.changeCreateButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.addAdminButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // proceedMenuButton
            // 
            this.proceedMenuButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.proceedMenuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.proceedMenuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.proceedMenuButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proceedMenuButton.Location = new System.Drawing.Point(332, 127);
            this.proceedMenuButton.Name = "proceedMenuButton";
            this.proceedMenuButton.Size = new System.Drawing.Size(183, 37);
            this.proceedMenuButton.TabIndex = 2;
            this.proceedMenuButton.Text = "Proceed to Main Menu";
            this.proceedMenuButton.UseVisualStyleBackColor = false;
            this.proceedMenuButton.Click += new System.EventHandler(this.proceedMenuButton_Click);
            // 
            // loginAdminButton
            // 
            this.loginAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loginAdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginAdminButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginAdminButton.Location = new System.Drawing.Point(332, 87);
            this.loginAdminButton.Name = "loginAdminButton";
            this.loginAdminButton.Size = new System.Drawing.Size(183, 34);
            this.loginAdminButton.TabIndex = 3;
            this.loginAdminButton.Text = "Login as Administrator";
            this.loginAdminButton.UseVisualStyleBackColor = false;
            this.loginAdminButton.Click += new System.EventHandler(this.loginAdminButton_Click);
            // 
            // loginUserButton
            // 
            this.loginUserButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.loginUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loginUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginUserButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUserButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.loginUserButton.Location = new System.Drawing.Point(332, 170);
            this.loginUserButton.Name = "loginUserButton";
            this.loginUserButton.Size = new System.Drawing.Size(183, 37);
            this.loginUserButton.TabIndex = 4;
            this.loginUserButton.Text = "Login as Receptionist";
            this.loginUserButton.UseVisualStyleBackColor = false;
            this.loginUserButton.Click += new System.EventHandler(this.loginUserButton_Click);
            // 
            // removeAdminButton
            // 
            this.removeAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.removeAdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeAdminButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAdminButton.Location = new System.Drawing.Point(306, 250);
            this.removeAdminButton.Name = "removeAdminButton";
            this.removeAdminButton.Size = new System.Drawing.Size(234, 38);
            this.removeAdminButton.TabIndex = 5;
            this.removeAdminButton.Text = "Remove administrator account";
            this.removeAdminButton.UseVisualStyleBackColor = false;
            this.removeAdminButton.Click += new System.EventHandler(this.removeAdminButton_Click);
            // 
            // changeCreateButton
            // 
            this.changeCreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.changeCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeCreateButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeCreateButton.Location = new System.Drawing.Point(306, 294);
            this.changeCreateButton.Name = "changeCreateButton";
            this.changeCreateButton.Size = new System.Drawing.Size(234, 56);
            this.changeCreateButton.TabIndex = 6;
            this.changeCreateButton.Text = "Change administrator account creation password";
            this.changeCreateButton.UseVisualStyleBackColor = false;
            this.changeCreateButton.Click += new System.EventHandler(this.changeCreateButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(364, 356);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(122, 37);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "Exit program";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addAdminButton
            // 
            this.addAdminButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.addAdminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAdminButton.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAdminButton.Location = new System.Drawing.Point(306, 213);
            this.addAdminButton.Name = "addAdminButton";
            this.addAdminButton.Size = new System.Drawing.Size(234, 31);
            this.addAdminButton.TabIndex = 8;
            this.addAdminButton.Text = "Add administrator account";
            this.addAdminButton.UseVisualStyleBackColor = false;
            this.addAdminButton.Click += new System.EventHandler(this.addAdminButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 491);
            this.Controls.Add(this.addAdminButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.changeCreateButton);
            this.Controls.Add(this.removeAdminButton);
            this.Controls.Add(this.loginUserButton);
            this.Controls.Add(this.loginAdminButton);
            this.Controls.Add(this.proceedMenuButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to the Hotel!";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Login_Activated);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button proceedMenuButton;
        private System.Windows.Forms.Button loginAdminButton;
        private System.Windows.Forms.Button loginUserButton;
        private System.Windows.Forms.Button removeAdminButton;
        private System.Windows.Forms.Button changeCreateButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button addAdminButton;
    }
}

