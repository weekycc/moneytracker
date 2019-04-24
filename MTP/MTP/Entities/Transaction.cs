using MTP.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace MTP.Entities
{
    public class Transaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [JsonProperty("transactionId")]
        [Key]
        public Guid TransactionId { get; set; }

        [JsonProperty("transactionDate")]
        private DateTime _TransactionDate { get; set; }
        public DateTime TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                _TransactionDate = value;
                NotifyPropertyChanged();
            }
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

        [JsonProperty("note")]
        private string _Note { get; set; }
        public string Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
                NotifyPropertyChanged();
            }
        }
        [JsonProperty("amount")]
        private float _Amount { get; set; }
        public float Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                NotifyPropertyChanged();
            }
        }

        public float AdjustedAmount
        {
            get
            {
                return Processed ? Amount : 0;
            }
        }
        //[JsonProperty("rate")]
        //private float _Rate { get; set; }
        //public float Rate
        //{
        //    get
        //    {
        //        return _Rate;
        //    }
        //    set
        //    {
        //        _Rate = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        //[JsonProperty("acquiredSymbol")]
        //private float _AcquiredSymbol { get; set; }
        //public float AcquiredSymbol
        //{
        //    get
        //    {
        //        return _AcquiredSymbol;
        //    }
        //    set
        //    {
        //        _AcquiredSymbol = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        //[JsonProperty("acquiredAmount")]
        //private float _AcquiredAmount { get; set; }
        //public float AcquiredAmount
        //{
        //    get
        //    {
        //        return _AcquiredAmount;
        //    }
        //    set
        //    {
        //        _AcquiredAmount = value;
        //        NotifyPropertyChanged();
        //    }
        //}
        //[JsonProperty("acquiredRate")]
        //private float _AcquiredRate { get; set; }
        //public float AcquiredRate
        //{
        //    get
        //    {
        //        return _AcquiredRate;
        //    }
        //    set
        //    {
        //        _AcquiredRate = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        [ForeignKey("AccountId")]
        [JsonProperty("accountId")]
        private Guid _AccountId { get; set; }
        public Guid AccountId
        {
            get
            {
                return _AccountId;
            }
            set
            {
                _AccountId = value;
                NotifyPropertyChanged();
            }
        }

        public virtual Account Account { get; set; }

        private string _Category;
        //[ForeignKey("Category")]
        [JsonProperty("category")]
        public string Category
        {
            get
            {
                return _Category;
            }
            set
            {
                _Category = value;
                NotifyPropertyChanged();
            }
        }
        //public virtual Category Category { get; set; }

        [JsonProperty("isIncome")]
        public bool _IsIncome { get; set; }
        public bool IsIncome
        {
            get
            {
                return _IsIncome;
            }
            set
            {
                _IsIncome = value;
                NotifyPropertyChanged();
            }
        }

        //[JsonProperty("type")]
        //public int _Type { get; set; }
        //public int Type
        //{
        //    get
        //    {
        //        return _Type;
        //    }
        //    set
        //    {
        //        _Type = value;
        //        NotifyPropertyChanged();
        //    }
        //}


        [JsonProperty("processed")]
        public bool _Processed { get; set; }
        public bool Processed
        {
            get
            {
                return _Processed;
            }
            set
            {
                _Processed = value;
                NotifyPropertyChanged();
            }
        }
    }
}
