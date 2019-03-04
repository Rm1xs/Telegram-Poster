namespace Telegram_Poster
{
    partial class Auth
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.metroLabel1.Location = new System.Drawing.Point(84, 9);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(148, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Telegram authentication";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            this.metroLabel1.UseStyleColors = true;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(254, 2);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(84, 74);
            this.metroTextBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(282, 30);
            this.metroTextBox1.TabIndex = 1;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(291, 165);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(74, 22);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Log In";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(12, 165);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(74, 22);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Exit";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "+380"});
            this.metroComboBox1.Location = new System.Drawing.Point(12, 74);
            this.metroComboBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(66, 29);
            this.metroComboBox1.TabIndex = 6;
            this.metroComboBox1.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Telegram_Poster.Properties.Resources.faq;
            this.pictureBox1.Location = new System.Drawing.Point(359, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(259, 118);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(80, 16);
            this.bunifuCustomLabel1.TabIndex = 8;
            this.bunifuCustomLabel1.Text = "Запомнить";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.metroLabel2.Location = new System.Drawing.Point(12, 57);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(85, 15);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Phone number:";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = true;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(345, 118);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 9;
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(203, 165);
            this.metroButton3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(74, 22);
            this.metroButton3.TabIndex = 10;
            this.metroButton3.Text = "Session.dat";
            this.metroButton3.UseSelectable = true;
            // 
            // Auth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(377, 200);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.bunifuCheckbox1);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "Auth";
            this.Text = "Auth";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Auth_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private MetroFramework.Controls.MetroButton metroButton3;
    }
}