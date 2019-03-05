using System;
using System.Drawing;
using System.Windows.Forms;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace Telegram_Poster
{
    public partial class Main : Form
    {
        //Save and Load session
        public interface ISessionStore
        {
            void Save(Session session);
            Session Load();
        }
        //Redirect to LogIn
        public Main()
        {
            InitializeComponent();
            var store = new FileSessionStore();
            var apiId = 434408;
            var apiHash = "0bdea67547ee00f2e164a5522174d7dc";
            var client = new TelegramClient(apiId, apiHash);
            if (client.IsUserAuthorized() == false)
            {
                Auth auth = new Auth();
                auth.ShowDialog();
            }
            if (client.IsUserAuthorized() == true)
            {
                GetUnReadMassages();
                if (System.IO.File.Exists(@".\profileimg"))
                {
                    Bitmap image = new Bitmap(@".\profileimg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = image;
                    label2.Text = Properties.Settings.Default.Name;
                }
                else
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    label2.Text = Properties.Settings.Default.Name;
                }
            }
        }

        public async System.Threading.Tasks.Task GetUnReadMassages()
        {
            var store = new FileSessionStore();
            var apiId = 434408;
            var apiHash = "0bdea67547ee00f2e164a5522174d7dc";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            foreach (var element in dialogs.Dialogs)
            {
                if (element is TLDialog)
                {
                    TLDialog chat = element as TLDialog;
                    label3.Text = chat.UnreadCount.ToString();
                }
            }
        }

        bool DrawerOpen = true;
        private void btnToggleDrawer_Click(object sender, EventArgs e)
        {
            DrawerOpen = !DrawerOpen;
            pnlDrawer.Visible = false;

            if (DrawerOpen)
            {
                //animated Drawer Open
                pnlDrawer.Width = 233;
                bunifuTransition1.ShowSync(pnlDrawer);
            }
            else
            {
                //Aminated Drawer close
                pnlDrawer.Width = 56;
                bunifuTransition1.ShowSync(pnlDrawer);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            new PersonalCabinet() { Parent = panel1 };
        }

        public void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Parse parse = new Parse();
            parse.bunifuFlatButton1_Click(null, null);
            panel1.Controls.Clear();
            new Parse() { Parent = panel1 };
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            new History() { Parent = panel1 };
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersonalCabinet personalCabinet = new PersonalCabinet();
            Properties.Settings.Default.PostsCount = personalCabinet.bunifuCircleProgressbar1.Value;
        }
    }
}
