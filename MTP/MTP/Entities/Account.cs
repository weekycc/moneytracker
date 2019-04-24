using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MTP.Entities
{
    public class Account : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [JsonProperty("title")]
        private string _Title { get; set; }
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                NotifyPropertyChanged();
            }
        }

        //[JsonProperty("id")]
        //public int Id { get; set; }
        [JsonProperty("accountId")]
        [Key]
        public Guid AccountId { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        [JsonProperty("profileId")]
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        private float _Income { get; set; }
        [JsonProperty("income")]
        [NotMapped]
        public float Income
        {
            get
            {
                return _Income;
            }
            set
            {
                _Income = value;
                Balance = _Income - _Expense;
                NotifyPropertyChanged();
            }
        }
        private float _Expense { get; set; }
        [JsonProperty("expense")]
        [NotMapped]
        public float Expense
        {
            get
            {
                return _Expense;
            }
            set
            {
                _Expense = value;
                Balance = _Income - _Expense;
                NotifyPropertyChanged();
            }
        }
        private float _Balance { get; set; }
        [JsonProperty("balance")]
        [NotMapped]
        public float Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                _Balance = value;
                NotifyPropertyChanged();
            }
        }

        public void UpdateBalance()
        {
            Income = Transactions.Where(s => s.IsIncome).Sum(s => s.AdjustedAmount);
            Expense = Transactions.Where(s => !s.IsIncome).Sum(s => s.AdjustedAmount);
            //Income = Transactions.Where(s => s.Type > 0).Sum(s => s.Amount);
            //Expense = Transactions.Where(s => s.Type < 0).Sum(s => s.Amount);
        }
    }
}
