using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using AudioToolbox;
using AnytimeABS.iOS;
using AnytimeABS.iOS.Classes;
using AnytimeABS.iOS.Services;
using AnytimeABS.Messages;
using Xamarin.Forms;

namespace AnytimeABS.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        #region Computed Properties
        public override UIWindow Window { get; set; }
        public AudioManager player { get; set; }
        #endregion

        StartTimerTaskService timerTask;
        void WireUpStartTimerTask()
        {
            MessagingCenter.Subscribe<StartTimerTaskMessage>(this, "StartTimerTaskMessage", async message => {
                timerTask = new StartTimerTaskService();
                await timerTask.Start();
            });

            MessagingCenter.Subscribe<StopTimerTaskMessage>(this, "StopTimerTaskMessage", async message =>
            {
                timerTask.Stop();
            });
        }


        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            AudioManager player = new AudioManager();
            WireUpStartTimerTask();
            return base.FinishedLaunching(app, options);
        }
    }
}
