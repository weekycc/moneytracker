using MTP.Entities;
using MTP.Storage;
using MTP.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTP.ViewModels
{
	public class LoginViewModel : ViewModelBase
    {
        private int _UseCount;
        public int UseCount
        {
            get { return _UseCount; }
            set { SetProperty(ref _UseCount, value); }
        }
        public DelegateCommand LoginCommand { get; set; }
        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {

            LoginCommand = new DelegateCommand(Login);
            UseCount = AppSetting.Current.CurrentUseCount++;
            //AppClientData.Current.Settings.SetValue("Login", "Title");
            //Title = AppClientData.Current.Settings.GetValue("test", "Title");

        }

        private void Login()
        {
            //AppClientData.Current.LoggedIn = true;
            NavigationService.NavigateAsync(typeof(MainPage).Name);
        }
    }
}
