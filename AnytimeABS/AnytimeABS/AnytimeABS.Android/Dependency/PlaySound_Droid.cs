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
using Xamarin.Forms;
using AnytimeABS.Dependency;
using AnytimeABS.Droid.Dependency;
using Android.Media;
//This whole file needs to be removed
namespace AnytimeABS.Droid.Dependency
{
    [Activity(Label = "PlaySound", MainLauncher = true)]
    public class PlaySound_Droid : Activity, IPlaySound
    {
        MediaPlayer player;

        public void Play_Sound()
        {
            player = MediaPlayer.Create(this, Resource.Raw.ding);
            player.Start();
        }
    }
}