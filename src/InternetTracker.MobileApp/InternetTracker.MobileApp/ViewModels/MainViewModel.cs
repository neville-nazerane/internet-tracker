using InternetTracker.Core;
using InternetTracker.MobileApp.Controls;
using InternetTracker.MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InternetTracker.MobileApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly BerryClient _berryClient;
        private DateTime _start;
        private DateTime _end;
        private IEnumerable<FailedLog> _logs;

        public DateTime Start { get => _start; set => SetProperty(ref _start, value); }
        public DateTime End { get => _end; set => SetProperty(ref _end, value); }

        public ICommand SubmitCmd { get; set; }

        public LoadControl LoadControl { get; set; }

        public int Count => Logs?.Count() ?? 0;

        public IEnumerable<FailedLog> Logs
        {
            get => _logs; 
            set
            {
                SetProperty(ref _logs, value);
                OnPropertyChanged(nameof(Count));
            }
        }

        public MainViewModel(BerryClient berryClient)
        {
            _berryClient = berryClient;

            Start = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            End = DateTime.Now;
            LoadControl = new LoadControl();
            SubmitCmd = new Command(async () => await SubmitAsync());
        }

        private Task SubmitAsync() => LoadControl.ExecuteAsync(async () => Logs = await _berryClient.GetLogsAsync(Start, End));

    }
}
