using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using weekysoft.store.Serializer;
using weekysoft.store.Storage;
using Xamarin.Forms;

namespace MTP.Storage
{
    public class AppSetting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private static AppSetting _Current { get; set; }

        public static AppSetting Current
        {
            get
            {
                if(_Current == null)
                {
                    _Current = new AppSetting(new LocalSetting(false));
                }
                return _Current;
            }
        }
        public bool IsInitialized;
        ILocalSetting _LocalSetting;
        //static ApplicationDataContainer _LocalSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public AppSetting(ILocalSetting setting)
        {
            //data = ApplicationData.Current;
            //_AlwaysUseDefault = alwaysUseDefault;
            _LocalSetting = setting;
            IsInitialized = false;
            //Current = this;
        }

        public static bool saving = false;

        public IPlatformFeature PlatformFeature { get; set; }

        public int Timeout
        {
            get
            {
                return _LocalSetting.GetValue<int>(30);
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }
        public int LifeTimeUseCount
        {
            get
            {
                return _LocalSetting.GetValue<int>(0);
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }
        public int CurrentUseCount
        {
            get
            {
                return _LocalSetting.GetValue<int>(0);
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }
        public bool Rated
        {
            get
            {
                return _LocalSetting.GetValue<bool>(false);
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }

        private FileStorage _LocalFileSystem { get; set; }
        public FileStorage LocalFileSystem
        {
            get
            {
                if(_LocalFileSystem == null)
                {
                    _LocalFileSystem = new FileStorage("Profiles");
                }
                return _LocalFileSystem;
            }
        }
        private string _Platform { get; set; }
        public string Platform
        {
            get
            {
                if (_Platform == null)
                {
                    Device.OnPlatform(WinPhone: () => _Platform="UWP",
                    Android: () => _Platform = "Android",
                    iOS: () => _Platform = "iOS");
                }
                return _Platform;
            }
        }

        public string LocalFolder
        {
            get
            {
                string folder = "";
                if (Device.RuntimePlatform == Device.Android)
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                else if (Device.RuntimePlatform == Device.iOS)
                {
                    SQLitePCL.Batteries_V2.Init();
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                else
                {
                    folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                }
                return folder;
            }
        }
        //public string PincryptedKey
        //{
        //    get
        //    {
        //        return _LocalSetting.GetValue<string>(string.Empty);
        //    }
        //    set
        //    {
        //        _LocalSetting.SetValue(value);
        //    }
        //}

        public DateTime ProfileBackupDate
        {
            get
            {
                return _LocalSetting.GetValue<DateTime>(DateTime.Now);
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }
        public string DeviceId
        {
            get
            {
                return _LocalSetting.GetValue<string>(Guid.NewGuid().ToString());
            }
            set
            {
                _LocalSetting.SetValue(value);
            }
        }
        public string ButtonColor
        {
            get
            {
                return "#D6D7D7";
            }
        }

        public static int ReceivePort
        {
            get
            {
                return 12303;
            }
        }
        public static int SendPort
        {
            get
            {
                return 12304;
            }
        }


        public void SetButtonColor(Button b)
        {
            Device.OnPlatform(WinPhone: () => b.BackgroundColor = Color.FromHex("D6D7D7"));
        }
        public void SetListViewColor(ListView b)
        {
            Device.OnPlatform(WinPhone: () => b.BackgroundColor = Color.FromHex("E4E4E4"));
        }
        //public int PinFailedCount
        //{
        //    get
        //    {
        //        return _LocalSetting.GetValue(0);
        //    }
        //    set
        //    {
        //        _LocalSetting.SetValue(value);
        //    }
        //}

        public void Load()
        {
        }
        public void Save()
        {
        }
        public static string GetLifeTimeUseCountRange(int lifetimeCount)
        {
            switch (lifetimeCount)
            {
                case 10000:
                case 5000:
                case 2000:
                case 1000:
                case 500:
                case 200:
                case 100:
                case 50:
                case 20:
                case 10:
                    return lifetimeCount.ToString();
                default: return "0";
            }
        }
    }
}