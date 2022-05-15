using System;
using System.Collections.Specialized;
using System.Net;

namespace GeeserAuth
{
    internal class discordlog
    {
        public static void DiscordLog(string url, string username, string content)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.UploadValues(url, new NameValueCollection
            {
                    {
                        "content", content
                    },
                    {
                        "username", username
                    }
            });
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}