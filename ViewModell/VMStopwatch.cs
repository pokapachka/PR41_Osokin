using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Threading;
using ПР41_Осокин.Modell;

namespace ПР41_Осокин.ViewModell
{
    public class VMStopwatch : INotifyPropertyChanged
    {
        public Stopwatch StopWatch { get; set; }

        private DispatcherTimer Timer = new DispatcherTimer()
        {
            Interval = new System.TimeSpan(0, 0, 1)
        };

        public VMStopwatch()
        {
            StopWatch = new Stopwatch() { Work = false, Time = 0 };
            Timer.Tick += Timer_Tick;
            Timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (StopWatch.Work) StopWatch.Time++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
