using InternetTracker.MobileApp.Services;
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

            InitializeComponent();

            this.StartInjecting()
                .AddHttpClient<BerryClient>(c => {
                    c.BaseAddress = new Uri("");
                })
                .Build();
        }
    }
}
