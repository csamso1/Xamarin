using System;
using System.Collections.Generic;
using System.Text;
using AnytimeABS.Services;
using Xamarin.Forms;
using AnytimeABS.iOS.Classes;
using AnytimeABS.iOS.Services;

[assembly: Dependency(typeof(AudioService))]
namespace AnytimeABS.iOS.Services
{
    public class AudioService : IAudio
    {
        AudioManager player;

        public void PlayMp3File(string filename)
        {
            player = new AudioManager();
            player.PlaySound("ding.mp3");
        }
    }
}
