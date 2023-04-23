using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SudokuGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


        }
        async void OnDisplayActionSheetButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Choose Difficulty:", "Nevermind", null, "Easy", "Medium", "Hard", "DnR Level");
            Console.WriteLine("Action: " + action);
            if(action=="Easy")
            {
                //Open easy game
                await Navigation.PushAsync(new Easy());
            }
            if (action == "Medium")
            {
                //Open medium game
                await Navigation.PushAsync(new Medium());
            }
            if (action == "Hard")
            {
                //Open hard game
                await Navigation.PushAsync(new Hard());
            }
            if (action == "DnR Level")
            {
                //Open DnR Level game
                await Navigation.PushAsync(new DnRLevel());
            }
        }
        async void OnDisplayAlertQuestionButtonClicked(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Save?", "Would you like to save your data?", "Yes", "No");
            Console.WriteLine("Save data: " + response);
        }

        private async void OnMainButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Easy());
        }
        
    }

}
