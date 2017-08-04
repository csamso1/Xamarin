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
	public partial class Timer : ContentPage
	{
		public Timer ()
		{
			InitializeComponent ();
		}

        private void Timer_Button_Clicked(object sender, EventArgs e)
        {
            //ToDo
        }
    }
}