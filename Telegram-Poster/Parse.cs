using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using AngleSharp.Html.Parser;
using xNet;
using System.Net.Http;
using TLSharp.Core;
using TeleSharp.TL.Messages;
using TeleSharp.TL;
using TLSharp.Core.Utils;
using System.Xml;
using System.Web;

namespace Telegram_Poster
{
    public partial class Parse : UserControl
    {

        public Parse()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            string connectionString = Properties.Settings.Default.ParsedInfoConnectionString;
            string sql = "SELECT * FROM Info";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
        public static string shortUrl = string.Empty;
        public static void Shorten(string inp)
        {
            if (Properties.Settings.Default.BitlyAPI != null)
            {
                string statusCode = string.Empty;
                string statusText = string.Empty;
                string longUrl = string.Empty;
                string urlToShorten = inp;
                XmlDocument xmlDoc = new XmlDocument();

                WebRequest request = WebRequest.Create("http://api.bitly.com/v3/shorten");
                byte[] data = Encoding.UTF8.GetBytes(string.Format("login={0}&apiKey={1}&longUrl={2}&format={3}", "rmixs", Properties.Settings.Default.BitlyAPI, HttpUtility.UrlEncode(urlToShorten), "xml"));

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                using (Stream ds = request.GetRequestStream())
                {
                    ds.Write(data, 0, data.Length);
                }
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        xmlDoc.LoadXml(sr.ReadToEnd());
                    }
                }

                statusCode = xmlDoc.GetElementsByTagName("status_code")[0].InnerText;
                statusText = xmlDoc.GetElementsByTagName("status_txt")[0].InnerText;
                shortUrl = xmlDoc.GetElementsByTagName("url")[0].InnerText;
                longUrl = xmlDoc.GetElementsByTagName("long_url")[0].InnerText;
            }
            else
            {
                MessageBox.Show("Добавте Bitly API Key");
            }
        }

        public async Task ImgParse()
        {
            var temp = "";
            int i = 1;
            DirectoryInfo di = Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\images");
            var http = new HttpClient();
            string html = await http.GetStringAsync("http://www.androeed.ru/files/vzlomannie_igri_na_android.html");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            foreach (HtmlNode imgNode in htmlDoc.DocumentNode.SelectNodes("//div[@class='ico c']//img[@data-src]"))
            {
                if (imgNode.GetAttributeValue("data-src", null) != temp)
                {
                    new WebClient().DownloadFile(imgNode.GetAttributeValue("data-src", null), AppDomain.CurrentDomain.BaseDirectory + "\\images\\img" + i + ".jpg");
                    i++;
                }
                temp = imgNode.GetAttributeValue("data-src", null);
            }
        }

        private SqlConnection connect = null;
        //-------------------------------------------------------------------------------------------------------------------
        HtmlParser HtmlParser = new HtmlParser();
        public struct Aps
        {
            private string url;
            public string Url { get => url; set => url = value; }
        }
        //-------------------------------------------------------------------------------------------------------------------
        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\images") == false)
            {
                ImgParse();
            }
            else
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\images", true);
                ImgParse();
            }

            const string host = "http://www.androeed.ru";
            const string hosthack = "https://www.androeed.ru/files/vzlomannie_igri_na_android.html";
            List<string> aps;
            List<string> links;
            List<string> downloadlinks;
            List<Aps> newAps = new List<Aps>();
            using (var reqs = new xNet.HttpRequest() { Cookies = new CookieDictionary(), UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:62.0) Gecko/20100101 Firefox/62.0" })
            {
                var htm = reqs.Get(hosthack).ToString();
                var doc = HtmlParser.ParseDocument(htm);
                aps = doc.GetElementsByClassName("bgnone").Select(x => x.GetAttribute("href").Split('\'')[0]).ToList();
                for (int i = 0; i < aps.Count; i++)
                {
                    if (i <= 25)
                    {
                        htm = reqs.Get(host + aps[i]).ToString();
                        doc = HtmlParser.ParseDocument(htm);
                        links = doc.GetElementsByClassName("google_play round5").Select(x => x.GetAttribute("href").Split('\'')[0]).ToList();
                        for (int b = 0; b < links.Count; b++)
                        {
                            htm = reqs.Get(host + links[b]).ToString();
                            doc = HtmlParser.ParseDocument(htm);
                            downloadlinks = doc.GetElementsByClassName("download_button shad round30").Select(x => x.GetAttribute("href").Split('\'')[0]).ToList();
                            for (int v = 0; v < downloadlinks.Count; v++)
                            {
                                var a = new Aps()
                                {
                                    Url = downloadlinks[v]
                                };
                                newAps.Add(a);
                            }
                        }
                    }
                }
            }

            //----------------------------------------------------------------------
            string url = "http://www.androeed.ru/files/vzlomannie_igri_na_android.html";
            List<Game> games = new List<Game>();
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("windows-1251"));
                string answer = sr.ReadToEnd();
                string[] items = answer.Substrings("<div class=\"item_holder", "class='os small_text'>");
                foreach (string s in items)
                {
                    games.Add(new Game()
                    {
                        Name = s.Substring("<div class=\"title_in\">", "</div>"),
                        Description = s.Substring("<div class=\"stitle\">", "</div>"),
                        Demands = s.Substring("<div class=\"version_in\">", "</div>")
                    });
                }
                int i = 1;
                int countindex = 0;
                foreach (var output in games)
                {
                    if (output.Name != null && output.Description != null && output.Demands != null)
                    {
                        connect = new SqlConnection(Properties.Settings.Default.ParsedInfoConnectionString);
                        connect.Open();
                        string sql = string.Format("Insert Into Info" +
                               "(Name, Description, Demands, Image, Url) Values(@Name, @Description, @Demands, @Image, @Url)");

                        using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@Name", output.Name);
                            cmd.Parameters.AddWithValue("@Description", output.Description);
                            cmd.Parameters.AddWithValue("@Demands", output.Demands);
                            cmd.Parameters.AddWithValue("@Image", AppDomain.CurrentDomain.BaseDirectory + "\\images\\img" + i + ".jpg");
                            for (int x = 0; x <= newAps.Count; x++)
                            {
                                if (countindex == x)
                                {
                                    cmd.Parameters.AddWithValue("@Url", newAps[x].Url);
                                }
                            }
                            countindex++;
                            i++;
                            cmd.ExecuteNonQuery();
                            connect.Close();
                        }
                    }
                }
            }
        }

        string name = "";
        string description = "";
        string version = "";
        string img = "";
        string summ = "";
        string url = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string value = dataGridView1.CurrentCell.Value.ToString();
                using (SqlConnection connect = new SqlConnection(Properties.Settings.Default.ParsedInfoConnectionString))
                {
                    string sqltake = "SELECT * FROM dbo.Info WHERE Name = @value";
                    string sqlcheck ="SELECT * FROM dbo.History WHERE Name = @value";
                    SqlCommand oCmd = new SqlCommand(sqltake, connect);
                    oCmd.Parameters.AddWithValue("@value", value);
                    connect.Open();
                    using (SqlDataReader oReader = oCmd.ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            name = oReader["Name"].ToString();
                            description = oReader["Description "].ToString();
                            version = oReader["Demands"].ToString();
                            img = oReader["Image"].ToString();
                            url = oReader["Url"].ToString();
                            if (Properties.Settings.Default.BitlyCheck == true)
                            {
                                Shorten(url);
                                summ = name + Environment.NewLine + description + Environment.NewLine + version + Environment.NewLine + shortUrl;
                            }
                            else
                            {
                                summ = name + Environment.NewLine + description + Environment.NewLine + version + Environment.NewLine + url;
                            }                           
                        }
                        connect.Close();
                    }
                }
                SendAsync();
                PersonalCabinet personalCabinet = new PersonalCabinet();
                personalCabinet.bunifuCircleProgressbar1.Value += 1;
                connect = new SqlConnection(Properties.Settings.Default.ParsedInfoConnectionString);
                connect.Open();

                string sql = string.Format("Insert Into History" +
                       "(Name, Description, Demands, Image, Url) Values(@Name, @Description, @Demands, @Image, @Url)");

                using (SqlCommand cmd = new SqlCommand(sql, this.connect))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Demands", version);
                    cmd.Parameters.AddWithValue("@Image", img);
                    cmd.Parameters.AddWithValue("@Url", url);

                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }
        public async Task SendAsync()
        {
            var apiId = 434408;
            var apiHash = "0bdea67547ee00f2e164a5522174d7dc";
            var client = new TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var result = await client.GetContactsAsync();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            var chat = dialogs.Chats
                .OfType<TLChannel>()
                .FirstOrDefault(c => c.Title == Properties.Settings.Default.ChanelTo);
            var fileResult = (TLInputFile)await client.UploadFile("img.jpg", new StreamReader(img));
            await client.SendUploadedPhoto(new TLInputPeerChannel() { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, fileResult, summ);
            MessageBox.Show("Отправлено");
        }
    }

    //--------------------------------------------------Class Game and StrExt---------------------------------//

    public class Game
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string Demands { get; set; }
        public string Url { get; set; }
    }

    public static class StrExt
    {
        #region Статические методы (открытые)

        /// <summary>
        /// Инвертирует все симолы в строке.
        /// </summary>
        /// <param name="str">Строка, в которой будут инвертированы все символы.</param>
        /// <returns>Строка с инвертированными символами.</returns>
        public static string Reverse(this string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
            {
                return string.Empty;
            }

            var strBuilder = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; --i)
            {
                strBuilder.Append(str[i]);
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// Извлекает подстроку из строки. Подстрока начинается с конца позиции подстроки <paramref name="left"/> и до конца строки. Поиск начинается с заданной позиции.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="startIndex">Позиция, с которой начинается поиск подстроки. Отсчёт от 0.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> является пустой строкой.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Значение параметра <paramref name="startIndex"/> меньше 0.
        /// -или-
        /// Значение параметра <paramref name="startIndex"/> равно или больше длины строки <paramref name="str"/>.
        /// </exception>
        public static string Substring(this string str, string left,
            int startIndex, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            #region Проверка параметров

            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (left.Length == 0)
            {
                throw new ArgumentNullException("left");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            #endregion

            // Ищем начало позиции левой подстроки.
            int leftPosBegin = str.IndexOf(left, startIndex, comparsion);

            if (leftPosBegin == -1)
            {
                return string.Empty;
            }

            // Вычисляем конец позиции левой подстроки.
            int leftPosEnd = leftPosBegin + left.Length;

            // Вычисляем длину найденной подстроки.
            int length = str.Length - leftPosEnd;

            return str.Substring(leftPosEnd, length);
        }

        /// <summary>
        /// Извлекает подстроку из строки. Подстрока начинается с конца позиции подстроки <paramref name="left"/> и до конца строки.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> является пустой строкой.</exception>
        public static string Substring(this string str,
            string left, StringComparison comparsion = StringComparison.Ordinal)
        {
            return Substring(str, left, 0, comparsion);
        }

        /// <summary>
        /// Извлекает подстроку из строки. Подстрока ищется между двумя заданными строками, начиная с заданной позиции.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="startIndex">Позиция, с которой начинается поиск подстроки. Отсчёт от 0.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Значение параметра <paramref name="startIndex"/> меньше 0.
        /// -или-
        /// Значение параметра <paramref name="startIndex"/> равно или больше длины строки <paramref name="str"/>.
        /// </exception>
        public static string Substring(this string str, string left, string right,
            int startIndex, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            #region Проверка параметров

            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (left.Length == 0)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (right.Length == 0)
            {
                throw new ArgumentNullException("right");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            #endregion

            // Ищем начало позиции левой подстроки.
            int leftPosBegin = str.IndexOf(left, startIndex, comparsion);

            if (leftPosBegin == -1)
            {
                return string.Empty;
            }

            // Вычисляем конец позиции левой подстроки.
            int leftPosEnd = leftPosBegin + left.Length;

            // Ищем начало позиции правой подстроки.
            int rightPos = str.IndexOf(right, leftPosEnd, comparsion);

            if (rightPos == -1)
            {
                return string.Empty;
            }

            // Вычисляем длину найденной подстроки.
            int length = rightPos - leftPosEnd;

            return str.Substring(leftPosEnd, length);
        }

        /// <summary>
        /// Извлекает подстроку из строки. Подстрока ищется между двумя заданными строками.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        public static string Substring(this string str, string left, string right,
            StringComparison comparsion = StringComparison.Ordinal)
        {
            return str.Substring(left, right, 0, comparsion);
        }

        /// <summary>
        /// Извлекает последнею подстроку из строки. Подстрока начинается с конца позиции подстроки <paramref name="left"/> и до конца строки. Поиск начинается с заданной позиции.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск последней подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="startIndex">Позиция, с которой начинается поиск подстроки. Отсчёт от 0.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> является пустой строкой.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Значение параметра <paramref name="startIndex"/> меньше 0.
        /// -или-
        /// Значение параметра <paramref name="startIndex"/> равно или больше длины строки <paramref name="str"/>.
        /// </exception>
        public static string LastSubstring(this string str, string left,
            int startIndex, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            #region Проверка параметров

            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (left.Length == 0)
            {
                throw new ArgumentNullException("left");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            #endregion

            // Ищем начало позиции левой подстроки.
            int leftPosBegin = str.LastIndexOf(left, startIndex, comparsion);

            if (leftPosBegin == -1)
            {
                return string.Empty;
            }

            // Вычисляем конец позиции левой подстроки.
            int leftPosEnd = leftPosBegin + left.Length;

            // Вычисляем длину найденной подстроки.
            int length = str.Length - leftPosEnd;

            return str.Substring(leftPosEnd, length);
        }

        /// <summary>
        /// Извлекает последнею подстроку из строки. Подстрока начинается с конца позиции подстроки <paramref name="left"/> и до конца строки.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск последней подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> является пустой строкой.</exception>
        public static string LastSubstring(this string str,
            string left, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return LastSubstring(str, left, str.Length - 1, comparsion);
        }

        /// <summary>
        /// Извлекает последнею подстроку из строки. Подстрока ищется между двумя заданными строками, начиная с заданной позиции.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск последней подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="startIndex">Позиция, с которой начинается поиск подстроки. Отсчёт от 0.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Значение параметра <paramref name="startIndex"/> меньше 0.
        /// -или-
        /// Значение параметра <paramref name="startIndex"/> равно или больше длины строки <paramref name="str"/>.
        /// </exception>
        public static string LastSubstring(this string str, string left, string right,
            int startIndex, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            #region Проверка параметров

            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (left.Length == 0)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (right.Length == 0)
            {
                throw new ArgumentNullException("right");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            #endregion

            // Ищем начало позиции левой подстроки.
            int leftPosBegin = str.LastIndexOf(left, startIndex, comparsion);

            if (leftPosBegin == -1)
            {
                return string.Empty;
            }

            // Вычисляем конец позиции левой подстроки.
            int leftPosEnd = leftPosBegin + left.Length;

            // Ищем начало позиции правой подстроки.
            int rightPos = str.IndexOf(right, leftPosEnd, comparsion);

            if (rightPos == -1)
            {
                if (leftPosBegin == 0)
                {
                    return string.Empty;
                }
                else
                {
                    return LastSubstring(str, left, right, leftPosBegin - 1, comparsion);
                }
            }

            // Вычисляем длину найденной подстроки.
            int length = rightPos - leftPosEnd;

            return str.Substring(leftPosEnd, length);
        }

        /// <summary>
        /// Извлекает последнею подстроку из строки. Подстрока ищется между двумя заданными строками.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск последней подстроки.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденая подстрока, иначе пустая строка.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        public static string LastSubstring(this string str, string left, string right,
            StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return str.LastSubstring(left, right, str.Length - 1, comparsion);
        }

        /// <summary>
        /// Извлекает подстроки из строки. Подстрока ищется между двумя заданными строками, начиная с заданной позиции.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстрок.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="startIndex">Позиция, с которой начинается поиск подстрок. Отсчёт от 0.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденые подстроки, иначе пустой массив строк.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Значение параметра <paramref name="startIndex"/> меньше 0.
        /// -или-
        /// Значение параметра <paramref name="startIndex"/> равно или больше длины строки <paramref name="str"/>.
        /// </exception>
        public static string[] Substrings(this string str, string left, string right,
            int startIndex, StringComparison comparsion = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new string[0];
            }

            #region Проверка параметров

            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (left.Length == 0)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            if (right.Length == 0)
            {
                throw new ArgumentNullException("right");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            if (startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }

            #endregion

            int currentStartIndex = startIndex;
            List<string> strings = new List<string>();

            while (true)
            {
                // Ищем начало позиции левой подстроки.
                int leftPosBegin = str.IndexOf(left, currentStartIndex, comparsion);

                if (leftPosBegin == -1)
                {
                    break;
                }

                // Вычисляем конец позиции левой подстроки.
                int leftPosEnd = leftPosBegin + left.Length;

                // Ищем начало позиции правой строки.
                int rightPos = str.IndexOf(right, leftPosEnd, comparsion);

                if (rightPos == -1)
                {
                    break;
                }

                // Вычисляем длину найденной подстроки.
                int length = rightPos - leftPosEnd;

                strings.Add(str.Substring(leftPosEnd, length));

                // Вычисляем конец позиции правой подстроки.
                currentStartIndex = rightPos + right.Length;
            }

            return strings.ToArray();
        }

        /// <summary>
        /// Извлекает подстроки из строки. Подстрока ищется между двумя заданными строками.
        /// </summary>
        /// <param name="str">Строка, в которой будет поиск подстрок.</param>
        /// <param name="left">Строка, которая находится слева от искомой подстроки.</param>
        /// <param name="right">Строка, которая находится справа от искомой подстроки.</param>
        /// <param name="comparsion">Одно из значений перечисления, определяющее правила поиска.</param>
        /// <returns>Найденые подстроки, иначе пустой массив строк.</returns>
        /// <exception cref="System.ArgumentNullException">Значение параметра <paramref name="left"/> или <paramref name="right"/> равно <see langword="null"/>.</exception>
        /// <exception cref="System.ArgumentException">Значение параметра <paramref name="left"/> или <paramref name="right"/> является пустой строкой.</exception>
        public static string[] Substrings(this string str, string left, string right,
            StringComparison comparsion = StringComparison.Ordinal)
        {
            return str.Substrings(left, right, 0, comparsion);
        }

        #endregion
    }
}


