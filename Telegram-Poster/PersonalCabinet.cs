using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using TLSharp.Core;
using TeleSharp.TL.Messages;
using TeleSharp.TL;
using Telegram_Poster.Properties;

namespace Telegram_Poster
{
    public partial class PersonalCabinet : UserControl
    {
        public PersonalCabinet()
        {
            InitializeComponent();
            GetChennals();
            label6.Text = Properties.Settings.Default.Name;
            label4.Text = "+380" + Properties.Settings.Default.PhoneNumber.ToString();
            bunifuCheckbox1.Checked = Properties.Settings.Default.AutoParse;
            bunifuCheckbox2.Checked = Properties.Settings.Default.Hesh;
        }

        public async System.Threading.Tasks.Task GetChennals()
        {
            var store = new FileSessionStore();
            var apiId = 434408;
            var apiHash = "0bdea67547ee00f2e164a5522174d7dc";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            foreach (var element in dialogs.Chats)
            {
                if (element is TLChannel)
                {
                    TLChannel chat = element as TLChannel;
                    metroComboBox1.Items.Add(chat.Title);
                }
            }

            for (int a = 0; a < metroComboBox1.Items.Count; a++)
            {
                if (metroComboBox1.Items[a].ToString() == Settings.Default.ChanelTo)
                {
                    metroComboBox1.SelectedIndex = a;
                }
            }
            bunifuMaterialTextbox1.Text = Properties.Settings.Default.BitlyAPI;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text != null)
            {
                Settings.Default.BitlyAPI = bunifuMaterialTextbox1.Text.ToString();
            }
            if (metroComboBox1.SelectedIndex > -1)
            {
                Settings.Default.ChanelTo = metroComboBox1.SelectedItem.ToString();
            }

            if (bunifuCheckbox1.Checked == true)
            {
                Settings.Default.AutoParse = true;
            }
            else
            {
                Settings.Default.AutoParse = false;
            }
            if (bunifuCheckbox2.Checked == true)
            {
                Settings.Default.Hesh = true;
            }
            else
            {
                Settings.Default.Hesh = false;
            }
            if (bunifuCheckbox3.Checked == true)
            {
                Properties.Settings.Default.BitlyCheck = true;
                Properties.Settings.Default.BitlyAPI = bunifuMaterialTextbox1.Text;
            }
            Settings.Default.Save();
            MessageBox.Show("Сохранено!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bunifuGauge1.Value = (int)(performanceCounter1.NextValue());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked == false)
            {
                bunifuCheckbox1.Checked = true;
            }
            else
            {
                bunifuCheckbox1.Checked = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked == false)
            {
                bunifuCheckbox2.Checked = true;
            }
            else
            {
                bunifuCheckbox2.Checked = false;
            }
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Visible = true;
        }

        private void bunifuCheckbox1_MouseHover(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Visible = true;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Visible = false;
        }

        private void bunifuCheckbox1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Visible = false;
        }

        private void bunifuCircleProgressbar1_MouseHover(object sender, EventArgs e)
        {
            bunifuCustomLabel8.Visible = true;
        }

        private void bunifuCircleProgressbar1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel8.Visible = false;
        }

        private void bunifuCheckbox3_Click(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked == true)
            {
                bunifuCustomLabel5.Visible = false;
                bunifuMaterialTextbox1.Visible = true;
                bunifuCustomLabel9.Visible = true;
                linkLabel1.Visible = true;
            }
        }
    }
}
