using MTP.Entities;
using MTP.Events;
using MTP.Storage;
using MTP.Views;
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
	public class TransactionDetailPageViewModel : ViewModelBase
    {
        AppClientData _clientdata;
        IEventAggregator _eventAggregator;
        IPageDialogService _dialogService;
        MoneyTrackerDataContext dbcontext;
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand SelectCategoryCommand { get; set; }
        public DelegateCommand SelectTitleCommand { get; set; }
        //public DelegateCommand<object> TxTypeChangedCommand { get; set; }
        private Transaction _CurrentTransaction;
        public Transaction CurrentTransaction
        {
            get { return _CurrentTransaction; }
            set
            {
                if (_CurrentTransaction != value)
                {
                    SetProperty(ref _CurrentTransaction, value);
                }
            }
        }
        private List<KeyValuePair<int, string>> _TransactionTypes;
        public List<KeyValuePair<int, string>> TransactionTypes
        {
            get
            {
                return _TransactionTypes;
            }
            set
            {
                SetProperty(ref _TransactionTypes, value);
            }
        }

        public TransactionDetailPageViewModel(INavigationService navigationService
            , MoneyTrackerDataContext db,IEventAggregator eventAggregator, IPageDialogService dialogService
            , AppClientData clientdata)
            : base(navigationService)
        {
            _dialogService = dialogService;
            CancelCommand = new DelegateCommand(Cancel);
            SaveCommand = new DelegateCommand(Save);
            SelectCategoryCommand = new DelegateCommand(SelectCategory);
            SelectTitleCommand = new DelegateCommand(SelectTitle);
            //TxTypeChangedCommand = new DelegateCommand<object>(TxTypeChanged);
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TransactionUpdatingEvent>().Subscribe(UpdateTransaction);
            dbcontext = db;
            _clientdata = clientdata;
            //Categories = dbcontext.Transactions.Select(s => s.Category).Distinct().OrderBy(s => s.ToLower()).ToArray();
            _clientdata.Titles = dbcontext.Transactions.Select(s => s.Title).Distinct().OrderBy(s => s.ToLower()).ToArray();
            TransactionTypes = _clientdata.TransactionTypes;
        }

        //private void TxTypeChanged(object obj)
        //{
        //    CurrentTransaction.Type = Convert.ToInt32(obj);
        //}

        private async void SelectTitle()
        {
            var result = await _dialogService.DisplayActionSheetAsync("Select Title", "Cancel", "", _clientdata.Titles);
            if (result != "Cancel" && result != "")
            {
                CurrentTransaction.Title = result;
            }
        }

        private async void SelectCategory()
        {
            var result = await _dialogService.DisplayActionSheetAsync("Select Category", "Cancel", "", _clientdata.Categories.Except(new string[] { "All" }).ToArray());
            if(result != "Cancel" && result != "")
            {
                CurrentTransaction.Category = result;
            }
        }

        private async void Save()
        {
            try
            {
                if (String.IsNullOrEmpty(CurrentTransaction.Category))
                    CurrentTransaction.Category = "Other";
                if (String.IsNullOrEmpty(CurrentTransaction.Title))
                    CurrentTransaction.Title = CurrentTransaction.Category;
                if (CurrentTransaction.TransactionId == new Guid())
                {
                    CurrentTransaction.TransactionId = Guid.NewGuid();
                    dbcontext.Add(CurrentTransaction);
                    dbcontext.SaveChanges();
                    TableStorage.Log($"New Transaction {CurrentTransaction.Title}");
                }
                else
                {
                    dbcontext.Update(CurrentTransaction);
                    dbcontext.SaveChanges();
                }

                if (!_clientdata.Categories.Contains(CurrentTransaction.Category))
                {
                    _clientdata.LoadCategories(dbcontext);
                    _eventAggregator.GetEvent<CategoryUpdatedEvent>().Publish(CurrentTransaction.Category);
                    //TableStorage.Log($"New Category {CurrentTransaction.Category}");
                }
                if (!_clientdata.Titles.Contains(CurrentTransaction.Title))
                {
                    _clientdata.LoadTitles(dbcontext);
                }

                _eventAggregator.GetEvent<TransactionUpdatedEvent>().Publish(CurrentTransaction);
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                dbcontext.UndoChanges();
                await _dialogService.DisplayAlertAsync("Error", ex.Message, "OK");
            }
        }

        private void UpdateTransaction(Transaction obj)
        {
            CurrentTransaction = obj;
        }

        private async void Cancel()
        {
            dbcontext.UndoChanges();
            await NavigationService.GoBackAsync();
        }
    }
}
