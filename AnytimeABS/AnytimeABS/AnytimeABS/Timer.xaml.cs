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

        private void Stop_Timer_Button_Clicked(object sender, EventArgs e)
        {
            //ToDo: Kill the timer & notification process
        }

        public async Task start_timer()
        {
            await Navigation.PushAsync(new Testing_Timer_Action());
        }
    }
}