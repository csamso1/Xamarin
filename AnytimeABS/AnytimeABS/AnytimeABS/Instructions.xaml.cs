using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnytimeABS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Instructions : ContentPage
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Back(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}