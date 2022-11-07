using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SoundCloudExplode;
using SoundCloudScraper;

namespace SoundCloudScraperV1._4
{
    public partial class Form1 : Form
    {
        private SoundCloudClient soundcloud = new SoundCloudClient();
        private string linktext = "https://soundcloud.com/";
        public Form1()
        {
            InitializeComponent();
            guna2PictureBox1.Visible = false;
            guna2ProgressBar1.Visible = false;
            guna2TextBox2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            SongInfo songinfo = new SongInfo();
            var stopwatch = new Stopwatch();
            if (TxtURL.Text.Contains(linktext) == true)
            {
                var track = await soundcloud.Tracks.GetAsync(TxtURL.Text);
                guna2TextBox2.Visible = true;
                guna2TextBox2.Text = $@"{songinfo.GetName(track.Title, track.User.Username)}   {songinfo.GetDuration(track.Duration)}   ";
                guna2PictureBox1.Visible = true;
                guna2PictureBox1.Load(track.ArtworkUrl.ToString());
                stopwatch.Start();
                await soundcloud.DownloadAsync(track, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $@"\Downloads\{track.User.Username} - {track.Title}.mp3");
                stopwatch.Stop();
                TimeSpan timespan = stopwatch.Elapsed;
                guna2TextBox2.Text += $@"{timespan.Minutes}:{timespan.Seconds}:{timespan.Milliseconds}";
                
            }
            else
            {
                guna2TextBox2.Text = "Invalid link";
            }


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bgWorkerGetSong_DoWork(object sender, DoWorkEventArgs e)
        {
                
        }

        private async void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
