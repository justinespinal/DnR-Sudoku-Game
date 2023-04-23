using MediaManager;
using SudokuGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SudokuGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hard : ContentPage
    {
        DateTime startTime;
        Timer timer = new Timer();
        public Hard()
        {
            InitializeComponent();
            BindingContext = this;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
        }

        char numChoice;
        int rowChoice;
        int columnChoice;
        int countError = 0;
        int countCorrect = 0;
        bool valid;
        bool wonGame = false;


        //board solution
        string[] solution = new string[9] {"126437958",
                                           "895621473",
                                           "374985126",
                                           "457193862",
                                           "983246517",
                                           "612578394",
                                           "269314785",
                                           "548769231",
                                           "731852649"
                                           };

        void NumSelected1(object sender, EventArgs e)
        {
            numChoice = '1';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;

        }
        void NumSelected2(object sender, EventArgs e)
        {
            numChoice = '2';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected3(object sender, EventArgs e)
        {
            numChoice = '3';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected4(object sender, EventArgs e)
        {
            numChoice = '4';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected5(object sender, EventArgs e)
        {
            numChoice = '5';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected6(object sender, EventArgs e)
        {
            numChoice = '6';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected7(object sender, EventArgs e)
        {
            numChoice = '7';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected8(object sender, EventArgs e)
        {
            numChoice = '8';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }
        void NumSelected9(object sender, EventArgs e)
        {
            numChoice = '9';
            Console.WriteLine(numChoice);
            NumSelectHard.Text = "Num selected: " + numChoice;
        }

        public ICommand ButtonCommand => new Command<string>(CommandButtonClick);



        public void CommandButtonClick(string a)//Command
        {
            char r = a[0];
            char c = a[1];
            rowChoice = (int)Char.GetNumericValue(r);
            columnChoice = (int)Char.GetNumericValue(c);
            char ans = solution[rowChoice][columnChoice];
            if (ans == numChoice) { valid = true; countCorrect++; Console.WriteLine(countCorrect); }
            else { valid = false; ErrorCounterHard.Text = "Errors: " + ++countError; }
        }//end of Command

        async void isValid(object sender, EventArgs e)//isValid function
        {
            if (valid == true)
            {
                (sender as Button).Text = numChoice.ToString();
                Button clickedButton = (Button)sender;
                clickedButton.IsEnabled = false;
                switch (countCorrect % 6)
                {
                    case 0:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- Good Job.mp3");
                        break;
                    case 1:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- You're a Winner.mp3");
                        break;
                    case 2:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- WINNER WINNER.mp3");
                        break;
                    case 3:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- Great Job.mp3");
                        break;
                    case 4:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- Yay You Got It Right.mp3");
                        break;
                    case 5:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- Chicken Dinner.mp3");
                        break;

                    default:
                        break;
                }
            }
            if (valid == false)
            {
                (sender as Button).Text = "";
                switch (countError % 7)
                {
                    case 0:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- Try Again.mp3");
                        break;
                    case 1:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- Oh That was terrible.mp3");
                        break;
                    case 2:
                        DependencyService.Get<IAudio>().PlayAudioFile("D- whoops.mp3");
                        break;
                    case 3:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- You Suck.mp3");
                        break;
                    case 4:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- Uh oh.mp3");
                        break;
                    case 5:
                        DependencyService.Get<IAudio>().PlayAudioFile("R- Loser.mp3");
                        break;
                    case 6:
                        DependencyService.Get<IAudio>().PlayAudioFile("Derek_FU_Asshole.mp3");
                        break;

                    default:
                        break;
                }

            }

            if (countCorrect == 62)
            {
                wonGame = true;
                Console.WriteLine(wonGame);
                await Navigation.PushAsync(new WinnerPage());
            }


        }//end of isValid

        //adding a timer here
        protected override void OnAppearing()
        {
            base.OnAppearing();
            startTime = DateTime.Now;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            Device.BeginInvokeOnMainThread(() =>
            {
                TimerCounterHard.Text = elapsed.ToString(@"hh\:mm\:ss");
            });
        }
    }
}