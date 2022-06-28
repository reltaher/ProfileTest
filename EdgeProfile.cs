using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ProfileTest
{
    public class EdgeProfile : BaseProfile
    {
        public string Gaia_Name { get; set; }
        public string last_downloaded_gaia_picture_url_with_size { get; set; }

        public EdgeProfile()
        {
            Path = Environment.ExpandEnvironmentVariables(@$"%LOCALAPPDATA%\Microsoft\Edge\User Data\Local State");
        }

        public static string GetLastUsedProfile()
        {
            string localStatePath = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\Microsoft\Edge\User Data\Local State");
            string localStateJSON = File.ReadAllText(localStatePath);
            JObject obj = JObject.Parse(localStateJSON);
            JObject profiles = JObject.Parse(obj.GetValue("profile").ToString());
            return profiles.GetValue("last_used").ToString();
        }
    }
}
