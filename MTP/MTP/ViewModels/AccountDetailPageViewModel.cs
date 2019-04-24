using MTP.Entities;
using MTP.Events;
using MTP.Storage;
using MTP.WebApi;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MTP.ViewModels
{
	public class AccountDetailPageViewModel : ViewModelBase
    {
        AppClientData _clientdata;
        IEventAggregator _eventAggregator;
        IPageDialogService _dialogService;
        MoneyTrackerDataContext dbcontext;
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        private Account _CurrentAccount;
        public Account CurrentAccount
        {
            get { return _CurrentAccount; }
            set
            {
                if (_CurrentAccount != value)
                {
                    SetProperty(ref _CurrentAccount, value);
                }
            }
        }
        public AccountDetailPageViewModel(INavigationService navigationService
            , MoneyTrackerDataContext db, IEventAggregator eventAggregator, IPageDialogService dialogService
            , AppClientData clientdata) : base(navigationService)
        {
            _dialogService = dialogService;
            CancelCommand = new DelegateCommand(Cancel);
            SaveCommand = new DelegateCommand(Save);
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AccountUpdatingEvent>().Subscribe(UpdateAccount);
            dbcontext = db;
            _clientdata = clientdata;
        }

        private void UpdateAccount(Account obj)
        {
            CurrentAccount = obj;
        }

        private async void Save()
        {
            try
            {
                if (CurrentAccount.AccountId == new Guid())
                {
                    CurrentAccount.AccountId = Guid.NewGuid();
                    dbcontext.Add(CurrentAccount);
                    dbcontext.SaveChanges();
                    TableStorage.Log($"New Account {CurrentAccount.Title}");
                }
                else
                {
                    dbcontext.Update(CurrentAccount);
                    dbcontext.SaveChanges();
                }

                _eventAggregator.GetEvent<AccountUpdatedEvent>().Publish(CurrentAccount);
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                dbcontext.UndoChanges();
                await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }

        private async void Cancel()
        {
            dbcontext.UndoChanges();
            await NavigationService.GoBackAsync();
        }
    }
}
