using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AnytimeABS.Services;

namespace AnytimeABS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            TimePicker.Items.Add("1 minute");
            TimePicker.Items.Add("2 minutes");
            TimePicker.Items.Add("3 minutes");
            TimePicker.Items.Add("4 minutes");
            TimePicker.Items.Add("5 minutes");
            TimePicker.Items.Add("6 minutes");
            TimePicker.Items.Add("7 minutes");
            TimePicker.Items.Add("8 minutes");
            TimePicker.Items.Add("9 minutes");
            TimePicker.Items.Add("10 minutes");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Instructions());
        }

        public void TimePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var TimePicker_Index = TimePicker.Items[TimePicker.SelectedIndex] + 1;
        }

        private void Button_Clicked_StartTimer(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Timer(TimePicker.SelectedIndex));
        }

        private void Test_Sound_Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAudio>().PlayMp3File("ding.mp3");
        }
    }
}