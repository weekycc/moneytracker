using MTP.Entities;
using MTP.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTP.Views
{
    public partial class MainPage : TabbedPage
    {
        IEventAggregator _eventAggregator;
        public MainPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AccountSelectedEvent>().Subscribe(AccountSelected);
        }

        private void AccountSelected(Account obj)
        {
            this.CurrentPage = piTransactions;
        }
    }
}