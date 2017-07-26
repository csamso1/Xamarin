﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void TimePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var amtOfTime = TimePicker.Items[TimePicker.SelectedIndex] + 1;
        }

        private void Button_Clicked_StartTimer(object sender, EventArgs e)
        {
            //ToDo start timer with specified value from TimePicker
        }
    }
}