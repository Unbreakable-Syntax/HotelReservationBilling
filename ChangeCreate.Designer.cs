namespace HotelReservationBilling
{
    partial class ChangeCreate
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
            this.newCreate = new System.Windows.Forms.TextBox();
            this.changeButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.showPassword1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oldCreate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // showPassword2
            // 
            this.showPassword2.AutoSize = true;
            this.showPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword2.Location = new System.Drawing.Point(600, 98);
            this.showPassword2.Name = "showPassword2";
            this.showPassword2.Size = new System.Drawing.Size(126, 21);
            this.showPassword2.TabIndex = 42;
            this.showPassword2.Text = "Show Password";
            this.showPassword2.UseVisualStyleBackColor = true;
            this.showPassword2.CheckedChanged += new System.EventHandler(this.showPassword2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "New account creation password:";
            // 
            // newCreate
            // 
            this.newCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCreate.Location = new System.Drawing.Point(305, 93);
            this.newCreate.Name = "newCreate";
            this.newCreate.Size = new System.Drawing.Size(277, 26);
            this.newCreate.TabIndex = 40;
            this.newCreate.UseSystemPasswordChar = true;
            // 
            // changeButton
            // 
            this.changeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeButton.Location = new System.Drawing.Point(350, 158);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(255, 31);
            this.changeButton.TabIndex = 39;
            this.changeButton.Text = "Change account creation password";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(202, 158);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(53, 31);
            this.backButton.TabIndex = 38;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // showPassword1
            // 
            this.showPassword1.AutoSize = true;
            this.showPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword1.Location = new System.Drawing.Point(600, 47);
            this.showPassword1.Name = "showPassword1";
            this.showPassword1.Size = new System.Drawing.Size(126, 21);
            this.showPassword1.TabIndex = 45;
            this.showPassword1.Text = "Show Password";
            this.showPassword1.UseVisualStyleBackColor = true;
            this.showPassword1.CheckedChanged += new System.EventHandler(this.showPassword1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "Old account creation password:";
            // 
            // oldCreate
            // 
            this.oldCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.oldCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldCreate.Location = new System.Drawing.Point(305, 42);
            this.oldCreate.Name = "oldCreate";
            this.oldCreate.Size = new System.Drawing.Size(277, 26);
            this.oldCreate.TabIndex = 43;
            this.oldCreate.UseSystemPasswordChar = true;
            // 
            // ChangeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(794, 213);
            this.Controls.Add(this.showPassword1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldCreate);
            this.Controls.Add(this.showPassword2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newCreate);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChangeCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change administrator account creation password";
            this.Activated += new System.EventHandler(this.ChangeCreate_Activated);
            this.Shown += new System.EventHandler(this.ChangeCreate_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showPassword2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newCreate;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.CheckBox showPassword1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oldCreate;
    }
}