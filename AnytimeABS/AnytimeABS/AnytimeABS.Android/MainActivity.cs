using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AnytimeABS.Messages;
using Xamarin.Forms;
using AnytimeABS.Droid.Services;

namespace AnytimeABS.Droid
{
    [Activity(Label = "AnytimeABS", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            WireUpStartTimerTask();
        }

        void WireUpStartTimerTask()
        {
            MessagingCenter.Subscribe<StartTimerTaskMessage>(this, "StartTimerTaskMessage", message =>
           {
               var intent = new Intent(this, typeof(StartTimerTaskService));
               StartService(intent);
           });

            MessagingCenter.Subscribe<StopTimerTaskMessage>(this, "StopTimerTaskMessage", message =>
            {
                var intent = new Intent(this, typeof(StartTimerTaskService));
                StartService(intent);
            });
        }
    }
}

