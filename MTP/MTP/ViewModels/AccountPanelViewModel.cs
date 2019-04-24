using MTP.Entities;
using MTP.Events;
using MTP.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MTP.ViewModels
{
	public class AccountPanelViewModel : ViewModelBase
    {
        IEventAggregator _eventAggregator;
        IPageDialogService _dialogService;
        MoneyTrackerDataContext dbcontext;
        private ObservableCollection<Account> _Accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _Accounts; }
            set { SetProperty(ref _Accounts, value); }
        }

        private Account _CurrentAccount;
        public Account CurrentAccount
        {
            get { return _CurrentAccount; }
            set
            {
                if(_CurrentAccount != value)
                {
                    SetProperty(ref _CurrentAccount, value);
                    SelectAccount(_CurrentAccount);
                }
            }
        }
        private float _ProfileBalance;
        public float ProfileBalance
        {
            get { return _ProfileBalance; }
            set
            {
                if (_ProfileBalance != value)
                {
                    SetProperty(ref _ProfileBalance, value);
                }
            }
        }
        private Profile _CurrentProfile;
        public Profile CurrentProfile
        {
            get { return _CurrentProfile; }
            set
            {
                if (_CurrentProfile != value)
                {
                    SetProperty(ref _CurrentProfile, value);
                }
            }
        }

        //public DelegateCommand<Account> DeleteCommand { get; set; }
        public DelegateCommand AddAccountCommand { get; set; }
        public DelegateCommand<Account> EditAccountCommand { get; set; }
        //public DelegateCommand<Account> SelectAccountCommand { get; set; }
        public AccountPanelViewModel(INavigationService navigationService, MoneyTrackerDataContext db
            , IEventAggregator eventAggregator, IPageDialogService dialogService)
            : base(navigationService)
        {
            _eventAggregator = eventAggregator;
            dbcontext = db;
            CurrentProfile = dbcontext.Profiles.First();
            Accounts = new ObservableCollection<Account>(dbcontext.Accounts);
            UpdateBalance();
            EditAccountCommand = new DelegateCommand<Account>(EditAccount);
            AddAccountCommand = new DelegateCommand(AddAccount);
            _eventAggregator.GetEvent<TransactionUpdatedEvent>().Subscribe(TransactionUpdated);
            _eventAggregator.GetEvent<AccountUpdatedEvent>().Subscribe(AccountUpdated);
            //DeleteCommand = new DelegateCommand<Account>(DeleteAccount);
            //SelectAccountCommand = new DelegateCommand<Account>(SelectAccount);
        }

        private void AccountUpdated(Account obj)
        {
            Accounts = new ObservableCollection<Account>(dbcontext.Accounts);
            ProfileBalance = dbcontext.Profiles.FirstOrDefault()?.Balance ?? 0;
        }

        private void AddAccount()
        {
            NavigationService.NavigateAsync(typeof(AccountDetailPage).Name);
            _eventAggregator.GetEvent<AccountUpdatingEvent>().Publish(new Account() { AccountId = new Guid(), Profile = CurrentProfile });
        }

        private void TransactionUpdated(Transaction obj)
        {
            var account = Accounts.FirstOrDefault(s=>s.AccountId == obj.AccountId);
            if(account != null)
            {
                account.UpdateBalance();
                account.Profile.UpdateBalance();
                ProfileBalance = account.Profile.Balance;
            }
        }

        private void UpdateBalance()
        {
            foreach (var account in Accounts)
            {
                account.UpdateBalance();
            }
            dbcontext.Profiles.FirstOrDefault()?.UpdateBalance();
            ProfileBalance = dbcontext.Profiles.FirstOrDefault()?.Balance??0;
        }

        private async void DeleteAccount(Account obj)
        {
            var ok = await _dialogService.DisplayAlertAsync("Delete Account", "Are you sure you want to delete this transaction?", "Ok", "Cancel");
            if (ok)
            {
                dbcontext.Remove(obj);
                dbcontext.SaveChanges();
            }
        }

        private void SelectAccount(Account account)
        {
            _eventAggregator.GetEvent<AccountSelectedEvent>().Publish(account);
        }

        private void EditAccount(Account account)
        {
            NavigationService.NavigateAsync(typeof(AccountDetailPage).Name);
            _eventAggregator.GetEvent<AccountUpdatingEvent>().Publish(account);
        }
    }
}
