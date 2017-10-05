using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AnytimeABS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            /*var MainPage = new NavigationPage
            {
                Title = "Anytime Abs"
            };
            MainPage.PushAsync(new NavigationPage(new HomePage()));
            MainPage.BarBackgroundColor = Color.Black;*/

            MainPage = new NavigationPage(new HomePage()) {
                BarTextColor = Color.Red };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
