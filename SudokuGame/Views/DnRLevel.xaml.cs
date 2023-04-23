using SudokuGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SudokuGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DnRLevel : ContentPage
    {
        DateTime startTime;
        Timer timer = new Timer();
        public DnRLevel()
        {
            InitializeComponent();
            BindingContext = this;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Tick;
        }
        char letChoice;
        int rowChoice;
        int columnChoice;
        int countError = 0;
        int countCorrect = 0;
        bool valid;
        bool wonGame = false;
        void NumSelected1(object sender, EventArgs e)
        {
            letChoice = 'D';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;

        }
        void NumSelected2(object sender, EventArgs e)
        {
            letChoice = 'N';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected3(object sender, EventArgs e)
        {
            letChoice = 'R';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected4(object sender, EventArgs e)
        {
            letChoice = 'S';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected5(object sender, EventArgs e)
        {
            letChoice = 'T';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected6(object sender, EventArgs e)
        {
            letChoice = 'U';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected7(object sender, EventArgs e)
        {
            letChoice = 'D';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected8(object sender, EventArgs e)
        {
            letChoice = 'I';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }
        void NumSelected9(object sender, EventArgs e)
        {
            letChoice = 'O';
            Console.WriteLine(letChoice);
            NumSelectDNR.Text = "Letter selected: " + letChoice;
        }

        public ICommand ButtonCommand => new Command<string>(CommandButtonClick);



        public void CommandButtonClick(string a)//Command
        {
            char r = a[0];
            char c = a[1];
            rowChoice = (int)Char.GetNumericValue(r);
            columnChoice = (int)Char.GetNumericValue(c);
            char ans = solution[rowChoice][columnChoice];
            if (ans == letChoice) { valid = true; countCorrect++; Console.WriteLine(countCorrect); }
            else { valid = false; ErrorCounterDNR.Text = "Errors: " + ++countError; }
        }//end of Command

        async void isValid(object sender, EventArgs e)//isValid function
        {
            if (valid == true)
            {
                (sender as Button).Text = letChoice.ToString();
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

            if (countCorrect == 56)
            {
                wonGame = true;
                Console.WriteLine(wonGame);
                await Navigation.PushAsync(new WinnerPage());
            }

        }//end of isValid

        //board solution
        string[] solution = new string[9] {"DNRUDIOST",
                                           "TISNRODUD",
                                           "OUDDSTRNI",
                                           "RDNSUDTIO",
                                           "UODTIRNDS",
                                           "STIDONUDR",
                                           "IRUONSDTD",
                                           "NDOITDSRU",
                                           "DSTRDUION"
                                           };


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
                TimerCounterDNR.Text = elapsed.ToString(@"hh\:mm\:ss");
            });
        }
    }
}