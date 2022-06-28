using System;

namespace ProfileTest
{
    public class WaveProfile : BaseProfile
    {
        public string Gaia_Given_Name { get; set; }
        public string Gaia_Name { get; set; }
        public string last_downloaded_gaia_picture_url_with_size { get; set; }

        public string Avatar_Icon { get; set; }

        public WaveProfile()
        {
            Path = Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\WaveBrowser\User Data\Local State");
        }

        public bool Equals(ChromeProfile chromeProfile)
        {
            return this.Gaia_Name.Equals(chromeProfile.Full_Name) && this.last_downloaded_gaia_picture_url_with_size.Equals(chromeProfile.last_downloaded_image_url_with_size);
        }

        public bool Equals(EdgeProfile edgeProfile)
        {
            if (this.last_downloaded_gaia_picture_url_with_size != null)
            {
                return this.Gaia_Name.Equals(edgeProfile.Name) && this.last_downloaded_gaia_picture_url_with_size.Equals(edgeProfile.last_downloaded_gaia_picture_url_with_size);
            } else
            {
                return this.Gaia_Name.Equals(edgeProfile.Name) && this.Avatar_Icon.Equals("chrome://theme/IDR_PROFILE_AVATAR_0");
            }
            
        }
    }
}
