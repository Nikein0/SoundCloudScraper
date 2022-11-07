using System;
using System.IO;
using System.Diagnostics;
using SoundCloudExplode;
using Guna.UI2.WinForms;
using System.Threading.Tasks;

namespace SoundCloudScraper
{
    class SoundCloud
    {
        public SoundCloudClient soundcloud = new SoundCloudClient();
    }
    class Downloader : SoundCloud
    {
        public async void Download(string SClink)   //@$"c:\Downloads\{trackname}.mp3"
        {
            var stopwatch = new Stopwatch();
            var track = await soundcloud.Tracks.GetAsync(SClink);
            Console.WriteLine("Downloading, stand by...");
            stopwatch.Start();
            var trackname = $@"{track.User.Username} - {track.Title}";
            await soundcloud.DownloadAsync(track, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +$@"\Downloads\{trackname}.mp3");
            stopwatch.Stop();
            TimeSpan timespan = stopwatch.Elapsed;
            Console.WriteLine("Downloading complete - " + "{0}h {1}m {2}s {3}ms", timespan.Hours, timespan.Minutes,timespan.Seconds, timespan.Milliseconds);
            Console.WriteLine($@"Download location - \Downloads\{trackname}.mp3");
        }
    }
    class SongInfo : SoundCloud
    {
        public string GetName(string songname, string username)
        {
            string fullname = $@"{username} - {songname}";
            return fullname;
        }

        

        

        public string GetDuration(long? length)
        {
            long? seconds = length /1000;
            long? minutes = seconds /60;
            long? hours = minutes /60;
            seconds = seconds % 60;
            minutes = minutes % 60;
            if (hours <= 0)
            {
                string full = $@"{minutes}:{seconds}";
                return full;
            }
            else
            {
                string full = $@"{hours}:{minutes}:{seconds}";
                return full;
            }
        }
    
    }
}
        
    
