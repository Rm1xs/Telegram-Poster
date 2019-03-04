using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using TLSharp.Core;
using TeleSharp.TL.Messages;
using TeleSharp.TL;
using Telegram_Poster.Properties;
using System.Diagnostics;
using HtmlAgilityPack;

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
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
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
            Settings.Default.Save();
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
    }
}
