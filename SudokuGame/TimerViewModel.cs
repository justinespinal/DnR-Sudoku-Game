/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Timers;
using Xamarin.Forms;

namespace SudokuGame
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        Stopwatch Stopwatch = new Stopwatch();
        

        private string _stopWatchHours;
        public string StopWatchHours
        {
            get { return _stopWatchHours; }
            set { 
                _stopWatchHours = value;
                OnPropertyChanged("StopWatchHours");
            }
        }

        private string _stopWatchMinutes;
        public string StopWatchMinutes
        {
            get { return _stopWatchMinutes;  }
            set
            {
                _stopWatchMinutes = value;
                OnPropertyChanged("StopWatchMinutes");
            }
        }

        private string _stopWatchSeconds;
        public string StopWatchSeconds
        {
            get { return _stopWatchSeconds;  }
            set
            {
                _stopWatchSeconds = value;
                OnPropertyChanged("StopWatchSeconds");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if(changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public TimerViewModel()
        {
            Stopwatch.Start();
            StopWatchHours = Stopwatch.Elapsed.Hours.ToString();
            StopWatchMinutes = Stopwatch.Elapsed.Minutes.ToString();
            StopWatchSeconds = Stopwatch.Elapsed.Seconds.ToString();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                StopWatchHours = Stopwatch.Elapsed.Hours.ToString();
                StopWatchMinutes = Stopwatch.Elapsed.Minutes.ToString();
                StopWatchSeconds = Stopwatch.Elapsed.Seconds.ToString();

                return true;
            });
        }
    }
}
*/