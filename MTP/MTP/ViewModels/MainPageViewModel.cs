using MTP.Entities;
using MTP.Storage;
using MTP.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MTP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            //if(!AppClientData.Current.LoggedIn)
            //    NavigationService.NavigateAsync(typeof(Login).Name);
        }
    }
}
