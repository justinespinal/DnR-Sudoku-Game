using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SudokuGame.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WinnerPage : ContentPage
	{
		public WinnerPage ()
		{ 
			InitializeComponent ();
		}
        protected override bool OnBackButtonPressed()
        {
            // navigate back to the main page instead of the previous page (LevelPage)
            Navigation.PopToRootAsync();

            // return true to indicate that the back button press was handled
            return true;
        }

        async void returnHome(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}