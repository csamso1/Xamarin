using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using Xamarin.Forms;
using AnytimeABS.Droid;
using AnytimeABS.Services;

[assembly: Dependency(typeof(AudioService))]

namespace AnytimeABS.Droid
{
    public class AudioService : IAudio
    {
        public AudioService() { }

        private MediaPlayer _mediaPlayer;

        public void PlayMp3File(string fileName)
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.ding);
            _mediaPlayer.Start();
        }
    }
}