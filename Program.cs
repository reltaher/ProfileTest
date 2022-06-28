using System;

namespace ProfileTest
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            WaveProfile waveProfile = new WaveProfile();
            BrowserProfileParser.ParseProfile(waveProfile);

            ChromeProfile chromeProfile = new ChromeProfile();
            BrowserProfileParser.ParseProfile(chromeProfile);

            EdgeProfile edgeProfile = new EdgeProfile();
            BrowserProfileParser.ParseProfile(edgeProfile);

            Console.WriteLine(edgeProfile.Name);
            Console.WriteLine(waveProfile.Gaia_Name);

            Console.WriteLine(waveProfile.Equals(edgeProfile));

        }
    }
}
