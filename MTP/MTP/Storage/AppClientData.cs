using MTP.Entities;
using MTP.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using weekysoft.store.Util;

namespace MTP.Storage
{
    public class AppClientData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public AppClientData()
        {
            //CurrentProfile = new Profile("Default Profile", "");
            //CurrentProfile.Groups.Add(new Group() { GroupId = "0", GroupName = "Default", Description = "" });
            //CurrentGroup = CurrentProfile.Groups.FirstOrDefault();
        }

        //public void LoadProfile()
        //{
        //    CurrentProfile = new Profile("Default Profile", "");
        //    CurrentProfile.Groups.Add(new Group() { GroupId="0", GroupName = "Default", Description = "" });
        //    CurrentGroup = CurrentProfile.Groups.FirstOrDefault();
        //}
        //public async void LoadProfile()
        //{
        //    if(!CurrentProfile.IsReady())
        //    {
        //        CurrentProfile = await AppSetting.Current.GetProfile();
        //    }
        //}


        private static AppClientData _Current;
        public static AppClientData Current
        {
            get
            {
                if(_Current == null)
                {
                    _Current = new AppClientData();
                    _Current.Settings = new LocalSetting(false);
                }
                return _Current;
            }
        }

        public LocalSetting Settings { get; set; }

        public string Secret
        {
            get
            {
                 return "Pa$$_w0rd0n3_s3cr3t";
            }
        }
        private WebUtil _WebUtitlity { get; set; }
        public WebUtil WebUtitlity
        {
            get
            {
                if(_WebUtitlity == null)
                {
                    _WebUtitlity = new WebUtil("http://weekysoftwebapi.azurewebsites.net/", 30000);
                }
                return _WebUtitlity;
            }
        }

        public bool LoggedIn { get; set; }

        public List<string> Years { get; set; }
        public List<string> Months { get; set; }
        public List<string> Categories { get; set; }
        public string[] Titles { get; set; }
        public List<KeyValuePair<int,string>> TransactionTypes { get; set; }
        public Profile CurrentProfile { get; private set; }

        public void LoadData(MoneyTrackerDataContext context)
        {
            LoadYears(context);
            LoadMonths(context);
            LoadCategories(context);
            LoadTitles(context);
            LoadTransactionTypes();
            CurrentProfile = context.Profiles.FirstOrDefault();
        }

        private void LoadTransactionTypes()
        {
            TransactionTypes = new List<KeyValuePair<int, string>>();

            foreach (var en in Enum.GetNames(typeof(TransactionType)))
            {
                var _en = (TransactionType)Enum.Parse(typeof(TransactionType),en);
                TransactionTypes.Add(new KeyValuePair<int, string>((int)_en, _en.ToString()));
            }
        }

        public void LoadTitles(MoneyTrackerDataContext context)
        {
            Titles = context.Transactions.Select(s => s.Title).Distinct().OrderBy(s => s.ToLower()).ToArray();
        }

        public void LoadCategories(MoneyTrackerDataContext context)
        {
            Categories = new List<string>();
            Categories.Add("All");
            if(context.Transactions.Count() != 0)
                Categories.AddRange(context.Transactions.Select(s => s.Category).Distinct().OrderBy(s => s.ToLower()));
        }

        public void LoadMonths(MoneyTrackerDataContext context)
        {
            Months = new List<string>();
            Months.Add("All");
            Months.Add("Current");
            Months.Add("January");
            Months.Add("February");
            Months.Add("March");
            Months.Add("April");
            Months.Add("May");
            Months.Add("June");
            Months.Add("July");
            Months.Add("August");
            Months.Add("September");
            Months.Add("October");
            Months.Add("November");
            Months.Add("December");
        }

        public void LoadYears(MoneyTrackerDataContext context)
        {
            var minDate = context.Transactions.Count()==0? DateTime.Now:context.Transactions.Min(s => s.TransactionDate);
            var maxDate = context.Transactions.Count() == 0 ? DateTime.Now : context.Transactions.Max(s => s.TransactionDate);
            Years = new List<string>();
            Years.Add("All");
            Years.Add("Current");
            for (int i = maxDate.Year; i >= minDate.Year; i--)
            {
                Years.Add(i.ToString());
            }
        }

        public int AppearingCount { get; internal set; }
    }
}
