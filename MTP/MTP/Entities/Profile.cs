using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace MTP.Entities
{
    public class Profile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [JsonProperty("profileId")]
        [Key]
        public Guid ProfileId { get; set; }
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

        [JsonProperty("pin")]
        private string _PIN { get; set; }
        public string PIN
        {
            get
            {
                return _PIN;
            }
            set
            {
                _PIN = value;
                NotifyPropertyChanged();
            }
        }

        [JsonProperty("filterYear")]
        private string _FilterYear { get; set; }
        public string FilterYear
        {
            get
            {
                return _FilterYear;
            }
            set
            {
                _FilterYear = value;
                NotifyPropertyChanged();
            }
        }

        [JsonProperty("filterMonth")]
        private string _FilterMonth { get; set; }
        public string FilterMonth
        {
            get
            {
                return _FilterMonth;
            }
            set
            {
                _FilterMonth = value;
                NotifyPropertyChanged();
            }
        }

        [JsonProperty("filterCategory")]
        private string _FilterCategory { get; set; }
        public string FilterCategory
        {
            get
            {
                return _FilterCategory;
            }
            set
            {
                _FilterCategory = value;
                NotifyPropertyChanged();
            }
        }

        public virtual ICollection<Account> Accounts { get; set; }
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
            Balance = Accounts.Sum(s => s.Balance);
        }
    }
}
