using Prism;
using Prism.Ioc;
using MTP.ViewModels;
using MTP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MTP.Entities;
using Unity.Resolution;
using Microsoft.EntityFrameworkCore;
using MTP.Storage;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using weekysoft.store.Interfaces;
using MTP.WebApi;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MTP
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public static MoneyTrackerDataContext dbcontext { get; private set; }
        public App() : this(null, null) { }

        public App(IPlatformInitializer initializer, IPlatformFeature feature) : base(initializer)
        {
            AppSetting.Current.PlatformFeature = feature;
            var ltc = AppSetting.Current.LifeTimeUseCount++;
            AppSetting.Current.CurrentUseCount++;
            var ltcStr = AppSetting.GetLifeTimeUseCountRange(ltc);
            if (ltcStr != "0")
            {
                TableStorage.Log($"Life Time Use {ltcStr}");
            }
            NavigationService.NavigateAsync(typeof(MainPage).Name);
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //await NavigationService.NavigateAsync(typeof(MainPage).Name);
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>();
            containerRegistry.RegisterForNavigation<AccountPanel, AccountPanelViewModel>();
            //MoneyTrackerDataContext context = new MoneyTrackerDataContext();
            //context.Database.EnsureCreated();
            //context.Database.Migrate();
            //containerRegistry.RegisterInstance(context);
            var databaseName = Path.Combine(AppSetting.Current.LocalFolder, "database.db");

            containerRegistry.RegisterSingleton<MoneyTrackerDataContext>();
            containerRegistry.RegisterInstance(new MoneyTrackerDataContext(databaseName));

            containerRegistry.RegisterSingleton<AppClientData>();
            containerRegistry.RegisterInstance(AppClientData.Current);

            containerRegistry.RegisterSingleton<AppSetting>();
            containerRegistry.RegisterInstance(AppSetting.Current);

            containerRegistry.RegisterForNavigation<TransactionPanel, TransactionPanelViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePanel, ProfilePanelViewModel>();
            containerRegistry.RegisterForNavigation<TransactionDetailPage, TransactionDetailPageViewModel>();
            dbcontext = Container.Resolve<MoneyTrackerDataContext>();

            LoadData();
            containerRegistry.RegisterForNavigation<AccountDetailPage, AccountDetailPageViewModel>();
        }

        private void LoadData()
        {
            var clientdata = Container.Resolve<AppClientData>();
            clientdata.LoadData(dbcontext);
        }

        protected override void OnSleep()
        {
            dbcontext.Update(dbcontext.Profiles.First());
            dbcontext.SaveChanges();
            base.OnSleep();
        }

    }
}
