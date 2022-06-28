using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace ProfileTest
{
    public class BrowserProfileParser
    {
        public static void ParseProfile(WaveProfile waveProfile)
        {
            string waveJsonString = File.ReadAllText(waveProfile.Path);
            JObject waveJson = JObject.Parse(waveJsonString);
            JObject profile = JObject.Parse(waveJson.GetValue("profile").ToString());
            JObject infoCache = JObject.Parse(profile.GetValue("info_cache").ToString());
            JObject defaultProfile = JObject.Parse(infoCache.GetValue("Default").ToString());
            waveProfile.Gaia_Name = defaultProfile.GetValue("gaia_name").ToString();
            waveProfile.Gaia_Given_Name = defaultProfile.GetValue("gaia_given_name").ToString();
            waveProfile.Avatar_Icon = defaultProfile.GetValue("avatar_icon").ToString();
            if (defaultProfile["last_downloaded_gaia_picture_url_with_size"] != null)
            {
                waveProfile.last_downloaded_gaia_picture_url_with_size = defaultProfile.GetValue("last_downloaded_gaia_picture_url_with_size").ToString();
            }
            
        }

        public static void ParseProfile(ChromeProfile chromeProfile)
        {
            string chromeJsonString = File.ReadAllText(chromeProfile.Path);
            JObject chromeJson = JObject.Parse(chromeJsonString);
            JArray accountInfo = (JArray)chromeJson["account_info"];
            IList<ChromeProfile> profile = accountInfo.ToObject<IList<ChromeProfile>>();
            chromeProfile.Full_Name = profile[0].Full_Name;
            chromeProfile.Given_Name = profile[0].Given_Name;
            chromeProfile.Email = profile[0].Email;
            chromeProfile.last_downloaded_image_url_with_size = profile[0].last_downloaded_image_url_with_size;
        }

        public static void ParseProfile(EdgeProfile edgeProfile)
        {
            string edgeJsonString = File.ReadAllText(edgeProfile.Path);
            JObject edgeJson = JObject.Parse(edgeJsonString);
            JObject profile = JObject.Parse(edgeJson.GetValue("profile").ToString());
            JObject infoCache = JObject.Parse(profile.GetValue("info_cache").ToString());
            JObject profileData = JObject.Parse(infoCache.GetValue(EdgeProfile.GetLastUsedProfile()).ToString());
            edgeProfile.Gaia_Name = profileData.GetValue("gaia_name").ToString();
            edgeProfile.Name = profileData.GetValue("name").ToString();
            if (profileData["last_downloaded_gaia_picture_url_with_size"] != null)
            {
                edgeProfile.last_downloaded_gaia_picture_url_with_size = profileData.GetValue("last_downloaded_gaia_picture_url_with_size").ToString();
            }
        }
    }
}
