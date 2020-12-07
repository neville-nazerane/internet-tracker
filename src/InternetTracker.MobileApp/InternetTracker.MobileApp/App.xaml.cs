using InternetTracker.MobileApp.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Essentials;
using Xamarin.FluentInjector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InternetTracker.MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            ExperimentalFeatures.Enable("Shapes_Experimental", "SwipeView_Experimental");

            AppCenter.Start(Config.AppCenter, typeof(Crashes), typeof(Analytics));

            InitializeComponent();

            this.StartInjecting()
                .AddHttpClient<BerryClient>(c => {
                    c.BaseAddress = new Uri(Config.Endpoint);
                })
                .Build();
        }
    }
}
