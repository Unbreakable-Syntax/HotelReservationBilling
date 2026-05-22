namespace HotelReservationBilling
{
    partial class AddAdmin
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
            this.showPassword2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.firstCreate = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.showPassword1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.adminUsername = new System.Windows.Forms.TextBox();
            this.adminPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // showPassword2
            // 
            this.showPassword2.AutoSize = true;
            this.showPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword2.Location = new System.Drawing.Point(579, 197);
            this.showPassword2.Name = "showPassword2";
            this.showPassword2.Size = new System.Drawing.Size(126, 21);
            this.showPassword2.TabIndex = 47;
            this.showPassword2.Text = "Show Password";
            this.showPassword2.UseVisualStyleBackColor = true;
            this.showPassword2.CheckedChanged += new System.EventHandler(this.showPassword2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 20);
            this.label1.TabIndex = 46;
            this.label1.Text = "Account creation password:";
            // 
            // firstCreate
            // 
            this.firstCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstCreate.Location = new System.Drawing.Point(284, 192);
            this.firstCreate.Name = "firstCreate";
            this.firstCreate.Size = new System.Drawing.Size(277, 26);
            this.firstCreate.TabIndex = 45;
            this.firstCreate.UseSystemPasswordChar = true;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(452, 252);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 31);
            this.addButton.TabIndex = 44;
            this.addButton.Text = "Add account";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(252, 252);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(53, 31);
            this.backButton.TabIndex = 43;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // showPassword1
            // 
            this.showPassword1.AutoSize = true;
            this.showPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword1.Location = new System.Drawing.Point(579, 137);
            this.showPassword1.Name = "showPassword1";
            this.showPassword1.Size = new System.Drawing.Size(126, 21);
            this.showPassword1.TabIndex = 42;
            this.showPassword1.Text = "Show Password";
            this.showPassword1.UseVisualStyleBackColor = true;
            this.showPassword1.CheckedChanged += new System.EventHandler(this.showPassword1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "New username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "New password:";
            // 
            // adminUsername
            // 
            this.adminUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminUsername.Location = new System.Drawing.Point(284, 72);
            this.adminUsername.Name = "adminUsername";
            this.adminUsername.Size = new System.Drawing.Size(277, 26);
            this.adminUsername.TabIndex = 39;
            // 
            // adminPass
            // 
            this.adminPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminPass.Location = new System.Drawing.Point(284, 132);
            this.adminPass.Name = "adminPass";
            this.adminPass.Size = new System.Drawing.Size(277, 26);
            this.adminPass.TabIndex = 38;
            this.adminPass.UseSystemPasswordChar = true;
            // 
            // AddAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(790, 347);
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
            this.Name = "AddAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add administrator account";
            this.Activated += new System.EventHandler(this.AddAdmin_Activated);
            this.Shown += new System.EventHandler(this.AddAdmin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showPassword2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstCreate;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.CheckBox showPassword1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox adminUsername;
        private System.Windows.Forms.TextBox adminPass;
    }
}