using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using AnytimeABS.Services;
using AVFoundation;

namespace AnytimeABS.iOS.Classes
{
    public class AudioManager : UIViewController
    {
        private AVAudioPlayer soundEffect;

        public AudioManager()
        {
            ActivateAudioSession();
        }

        public void ActivateAudioSession()
        {
            //Initialize Audio
            var session = AVAudioSession.SharedInstance();
            session.SetCategory(AVAudioSessionCategory.Playback);
            session.SetActive(true);
        }

        public bool PlaySound(string filename)
        {
            NSUrl songURL;
            songURL = new NSUrl("Sounds/" + filename);
            NSError err;
            soundEffect = new AVAudioPlayer(songURL, "wav", out err);
            soundEffect.Volume = 1.0f;
            soundEffect.FinishedPlaying += delegate {
                soundEffect = null;
            };
            soundEffect.NumberOfLoops = 0;
            soundEffect.Play();
            return true;
        }
    }
}