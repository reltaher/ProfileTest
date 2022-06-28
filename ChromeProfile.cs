using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ProfileTest
{
    public class ChromeProfile : BaseProfile
    {
        public string Full_Name { get; set; }
        public string Given_Name { get; set; }
        public string Email { get; set; }
        public string last_downloaded_image_url_with_size { get; set; }
        public ChromeProfile()
        {
            Path = Environment.ExpandEnvironmentVariables(@$"%LOCALAPPDATA%\Google\Chrome\User Data\{GetLastUsedProfile()}\Preferences");
        }

        public static string GetLastUsedProfile()
        {
            string localStatePath = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\Google\Chrome\User Data\Local State");
            string localStateJSON = File.ReadAllText(localStatePath);
            JObject obj = JObject.Parse(localStateJSON);
            JObject profiles = JObject.Parse(obj.GetValue("profile").ToString());
            return profiles.GetValue("last_used").ToString();
        }
    }
}
