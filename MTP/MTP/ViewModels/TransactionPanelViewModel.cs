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
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using weekysoft.store.Binding;

namespace MTP.ViewModels
{
	public class TransactionPanelViewModel : ViewModelBase
    {
        IEventAggregator _eventAggregator;
        IPageDialogService _dialogService;
        MoneyTrackerDataContext dbcontext;
        AppClientData _clientdata;
        private IEnumerable<Transaction> _Transactions;
        public IEnumerable<Transaction> Transactions
        {
            get { return _Transactions; }
            set { SetProperty(ref _Transactions, value); }
        }
        private ObservableCollection<Grouping<GroupHeader, Transaction>> _GroupedTransactions;
        public ObservableCollection<Grouping<GroupHeader, Transaction>> GroupedTransactions
        {
            get { return _GroupedTransactions; }
            set { SetProperty(ref _GroupedTransactions, value); }
        }
        private Transaction _SelectedTransaction;
        public Transaction SelectedTransaction
        {
            get { return _SelectedTransaction; }
            set
            {
                if (_SelectedTransaction != value)
                {
                    SetProperty(ref _SelectedTransaction, value);
                }
            }
        }
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
        private List<string> _Years;
        public List<string> Years
        {
            get { return _Years; }
            set
            {
                if (_Years != value)
                {
                    SetProperty(ref _Years, value);
                }
            }
        }
        private List<string> _Months;
        public List<string> Months
        {
            get { return _Months; }
            set
            {
                if (_Months != value)
                {
                    SetProperty(ref _Months, value);
                }
            }
        }
        private ObservableCollection<string> _Categories;
        public ObservableCollection<string> Categories
        {
            get { return _Categories; }
            set
            {
                if (_Categories != value)
                {
                    SetProperty(ref _Categories, value);
                }
            }
        }

        private string _SelectedYear;
        public string SelectedYear
        {
            get
            {
                if(string.IsNullOrEmpty(_SelectedYear))
                {
                    _SelectedYear = CurrentProfile.FilterYear;
                }
                return _SelectedYear;
            }
            set
            {
                if (_SelectedYear != value)
                {
                    SetProperty(ref _SelectedYear, value);
                    CurrentProfile.FilterYear = value;
                    FilterTransactions();
                }
            }
        }

        private string _SelectedMonth;
        public string SelectedMonth
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectedMonth))
                {
                    _SelectedMonth = CurrentProfile.FilterMonth;
                }
                return _SelectedMonth;
            }
            set
            {
                if (_SelectedMonth != value)
                {
                    SetProperty(ref _SelectedMonth, value);
                    CurrentProfile.FilterMonth = value;
                    FilterTransactions();
                }
            }
        }
        private string _SelectedCategory;
        public string SelectedCategory
        {
            get
            {
                if (string.IsNullOrEmpty(_SelectedCategory))
                {
                    _SelectedCategory = CurrentProfile.FilterCategory;
                }
                return _SelectedCategory;
            }
            set
            {
                if (_SelectedCategory != value)
                {
                    SetProperty(ref _SelectedCategory, value);
                    CurrentProfile.FilterCategory = value;
                    FilterTransactions();
                }
            }
        }

        private float _Total;
        public float Total
        {
            get { return _Total; }
            set { SetProperty(ref _Total, value); }
        }
        public DelegateCommand<Transaction> DeleteCommand { get; set; }
        public DelegateCommand<Transaction> EditCommand { get; set; }
        public DelegateCommand AddTransactionCommand { get; set; }
        public DelegateCommand<Transaction> ProcessedCommand { get; set; }
        public TransactionPanelViewModel(INavigationService navigationService, MoneyTrackerDataContext db
            , IEventAggregator eventAggregator, AppClientData clientdata, IPageDialogService dialogService)
            : base(navigationService)
        {
            _dialogService = dialogService;
            _clientdata = clientdata;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AccountSelectedEvent>().Subscribe(AccountSelected);
            _eventAggregator.GetEvent<TransactionUpdatedEvent>().Subscribe(TransactionUpdated);
            _eventAggregator.GetEvent<CategoryUpdatedEvent>().Subscribe(CategoryUpdated);
            dbcontext = db;
            //need to query here, otherwise they won't show up in navigation property
            if (dbcontext.Profiles.Count() > 0)
            {
                CurrentProfile = dbcontext.Profiles.First();
            }
            if (dbcontext.Accounts.Count() > 0)
            {
                CurrentAccount = dbcontext.Accounts.First();
                //Transactions = new ObservableCollection<Transaction>(CurrentAccount.Transactions);
                FilterTransactions();
                //CalculateTotal();
            }
            EditCommand = new DelegateCommand<Transaction>(EditTransaction);
            DeleteCommand = new DelegateCommand<Transaction>(DeleteTransaction);
            AddTransactionCommand = new DelegateCommand(AddTransaction);
            ProcessedCommand = new DelegateCommand<Transaction>(ProcessedChanged);

            Years = _clientdata.Years;
            Months = _clientdata.Months;
            Categories = new ObservableCollection<string>(_clientdata.Categories);
            //SetFilters();
        }

        public void ProcessedChanged(Transaction obj)
        {
            obj.Processed = !obj.Processed;
            dbcontext.Update(obj);
            dbcontext.SaveChanges();
            //CalculateTotal();
            _eventAggregator.GetEvent<TransactionUpdatedEvent>().Publish(obj);
        }

        private void CategoryUpdated(string obj)
        {
            Categories.Add(obj);
        }

        private async void DeleteTransaction(Transaction obj)
        {
            var ok = await _dialogService.DisplayAlertAsync("Delete Transaction", "Are you sure you want to delete this transaction?", "Ok", "Cancel");
            if(ok)
            {
                dbcontext.Remove(obj);
                dbcontext.SaveChanges();
                _eventAggregator.GetEvent<TransactionUpdatedEvent>().Publish(obj);
            }
        }

        private void FilterTransactions()
        {
            //var t = dbcontext.Transactions;
            if (CurrentAccount.Transactions == null)
                CurrentAccount.Transactions = new List<Transaction>();
            Transactions = CurrentAccount.Transactions.Where(
                    s => (CurrentProfile.FilterYear == "All" || s.TransactionDate.Year == (CurrentProfile.FilterYear == "Current" ? DateTime.Now.Year : Convert.ToInt32(CurrentProfile.FilterYear)))
                    && (CurrentProfile.FilterMonth == "All" || s.TransactionDate.Month == (CurrentProfile.FilterMonth == "Current" ? DateTime.Now.Month : GetMonthInt(CurrentProfile.FilterMonth)))
                    && (CurrentProfile.FilterCategory == "All" || s.Category == CurrentProfile.FilterCategory)
                    );
            CalculateTotal();
            CreateGroups();
            SelectedTransaction = null;
            ShowRateApp();

        }
        private async Task ShowRateApp()
        {
            AppClientData.Current.AppearingCount++;
            if (!AppSetting.Current.Rated && AppSetting.Current.CurrentUseCount >= 5 && AppClientData.Current.AppearingCount >= 2)
            {
                var ok = await _dialogService.DisplayAlertAsync("Rate App", "Limited Time Offer : Submit a 5 star review today to unlock unlimited accounts.", "Rate App", "Later");
                if (ok)
                {
                    TableStorage.Log("Rate App");
                    var rated = AppSetting.Current.PlatformFeature.RateApp?.Rate();
                    AppSetting.Current.Rated = rated ?? false;
                }
                else
                {
                    TableStorage.Log("Rate Later");
                    AppSetting.Current.CurrentUseCount = 0;
                }
            }
        }

        private void CreateGroups()
        {
            var sorted = from tran in Transactions.OrderByDescending(s=>s.TransactionDate)
                         group tran by tran.TransactionDate.ToString("MM/dd/yyyy") into tranGroup
                         select new Grouping<GroupHeader, Transaction>(new GroupHeader() { HeaderName = tranGroup.Key, Total = tranGroup.Sum(s => s.AdjustedAmount * (s.IsIncome? 1 : -1)) } , tranGroup);
            //select new Grouping<GroupHeader, Transaction>(new GroupHeader() { HeaderName = tranGroup.Key, Total = tranGroup.Sum(s => s.Amount * (s.Type)) }, tranGroup);

            GroupedTransactions = new ObservableCollection<Grouping<GroupHeader, Transaction>>(sorted);
        }

        private int GetMonthInt(string filterMonth)
        {
            switch(filterMonth)
            {
                case "January": return 1;
                case "February": return 2;
                case "March": return 3;
                case "April": return 4;
                case "May": return 5;
                case "June": return 6;
                case "July": return 7;
                case "August": return 8;
                case "September": return 9;
                case "October": return 10;
                case "November": return 11;
                case "December": return 12;
                default: return 0;
            }
        }

        private void SetFilters()
        {
            //var minDate = dbcontext.Transactions.Min(s => s.TransactionDate);
            //var maxDate = dbcontext.Transactions.Max(s => s.TransactionDate);
            //Years = new List<string>();
            //Years.Add("All");
            //Years.Add("Current");
            //for (int i = maxDate.Year; i >= minDate.Year; i--)
            //{
            //    Years.Add(i.ToString());
            //}

            //Months = new List<string>();
            //Months.Add("All");
            //Months.Add("Current");
            //Months.Add("January");
            //Months.Add("February");
            //Months.Add("March");
            //Months.Add("April");
            //Months.Add("May");
            //Months.Add("June");
            //Months.Add("July");
            //Months.Add("August");
            //Months.Add("September");
            //Months.Add("October");
            //Months.Add("November");
            //Months.Add("December");

            //Categories = new List<string>();
            //Categories.Add("All");
            //Categories.AddRange(dbcontext.Transactions.Select(s => s.Category).Distinct().OrderBy(s=>s.ToLower()));
        }

        private void CalculateTotal()
        {
            Total = Transactions.Sum(s => s.AdjustedAmount * (s.IsIncome? 1 : -1));
            //Total = Transactions.Sum(s => s.Amount * (s.Type));
        }

        private void AddTransaction()
        {
            NavigationService.NavigateAsync(typeof(TransactionDetailPage).Name);
            _eventAggregator.GetEvent<TransactionUpdatingEvent>().Publish(new Transaction() { TransactionId = new Guid(), Account = CurrentAccount, TransactionDate=DateTime.Now, Processed=true });
        }
        private void TransactionUpdated(Transaction transaction)
        {
            FilterTransactions();
            //var existing = Transactions.FirstOrDefault(s => s.TransactionId == transaction.TransactionId);
            //if(existing == null)
            //    Transactions.Add(transaction);
            //else
            //{
            //    var index = Transactions.IndexOf(existing);
            //    Transactions.Remove(existing);
            //    Transactions.Insert(index, transaction);
            //}
            //CalculateTotal();
        }
        private async void AccountSelected(Account obj)
        {
            CurrentAccount = obj;
            FilterTransactions();
            //Transactions = CurrentAccount.Transactions==null?
            //    new ObservableCollection<Transaction>(): new ObservableCollection<Transaction>(obj.Transactions);
            //CalculateTotal();
        }

        private void EditTransaction(Transaction transaction)
        {
            NavigationService.NavigateAsync(typeof(TransactionDetailPage).Name);
            _eventAggregator.GetEvent<TransactionUpdatingEvent>().Publish(transaction);
        }
    }
}
