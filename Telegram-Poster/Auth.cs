using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Telegram_Poster.Properties;
using TeleSharp.TL;
using TeleSharp.TL.Upload;
using TLSharp.Core;

namespace Telegram_Poster
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        public async System.Threading.Tasks.Task AuthAsync()
        {
            var store = new FileSessionStore();
            var apiId = 434408;
            var apiHash = "0bdea67547ee00f2e164a5522174d7dc";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            if (client.IsUserAuthorized() == false)
            {
                var phone = metroComboBox1.Text + metroTextBox1.Text;
                var hash = await client.SendCodeRequestAsync(phone);
                var code = Microsoft.VisualBasic.Interaction.InputBox("Введите код полученый в СМС:");
                var user = await client.MakeAuthAsync(phone, hash, code);

                var photo = ((TLUserProfilePhoto)user.Photo);
                var photoLocation = (TLFileLocation)photo.PhotoBig;
                TLFile file = await client.GetFile(new TLInputFileLocation()
                {
                    LocalId = photoLocation.LocalId,
                    Secret = photoLocation.Secret,
                    VolumeId = photoLocation.VolumeId
                }, 1024 * 256);

                using (var m = new MemoryStream(file.Bytes))
                {
                    var img = Image.FromStream(m);
                    img.Save("profileimg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                var rq = new TeleSharp.TL.Users.TLRequestGetFullUser { Id = new TLInputUserSelf() };
                TLUserFull rUserSelf = await client.SendRequestAsync<TeleSharp.TL.TLUserFull>(rq);
                TLUser userSelf = (TLUser)rUserSelf.User;
                Properties.Settings.Default.Name = userSelf.Username;
                Properties.Settings.Default.Save();

                this.Hide();
                Main main = new Main();
                main.ShowDialog();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AuthAsync();
            var numb = metroTextBox1.Text;
            var convert = Convert.ToInt64(numb);
            Settings.Default.PhoneNumber = convert;
            Settings.Default.Save();
        }
    }
}
