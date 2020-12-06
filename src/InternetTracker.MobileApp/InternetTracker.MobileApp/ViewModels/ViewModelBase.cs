using InternetTracker.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetTracker.MobileApp.ViewModels
{
    public abstract class ViewModelBase : BindableModel
    {
        private bool _isLoading;

        public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }

        protected void Startup()
        {
            Task.Run(() =>
            {
                IsLoading = true;
                InitAsync().ContinueWith(t => IsLoading = false);
            });
        }

        public virtual Task InitAsync() => Task.CompletedTask;


    }
}
