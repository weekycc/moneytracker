using MTP.Entities;
using MTP.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MTP.ViewModels
{
	public class ProfilePanelViewModel : ViewModelBase
    {
        AppClientData _clientdata;
        MoneyTrackerDataContext dbcontext;
        AppSetting _settings;
        //private ObservableCollection<Account> _Accounts;
        //public ObservableCollection<Account> Accounts
        //{
        //    get { return _Accounts; }
        //    set { SetProperty(ref _Accounts, value); }
        //}
        public DelegateCommand MoreAppsCommand { get; set; }

        private Profile _CurrentProfile;
        public Profile CurrentProfile
        {
            get { return _CurrentProfile; }
            set { SetProperty(ref _CurrentProfile, value); }
        }

        public string Version
        {
            get;set;
        }

        public ProfilePanelViewModel(INavigationService navigationService, MoneyTrackerDataContext db, AppClientData clientdata, AppSetting settings)
            : base(navigationService)
        {
            dbcontext = db;
            _clientdata = clientdata;
            _settings = settings;
            Version = _settings.PlatformFeature.AppVersion.Version;
            CurrentProfile = dbcontext.Profiles.First();
            MoreAppsCommand = new DelegateCommand(MoreApps);
        }

        private void MoreApps()
        {
            Device.OpenUri(new Uri("http://weekysoft.com"));
        }
    }
}
