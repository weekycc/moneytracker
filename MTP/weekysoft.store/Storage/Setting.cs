using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using weekysoft.store.Serializer;

namespace weekysoft.store.Storage
{
    public class Setting : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (propertyName != "")
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //private ApplicationData data;
        //private static ApplicationDataContainer _settings;
        //bool _AlwaysUseDefault = false;
        public bool IsInitialized;
        private static int DefaultMaxAssistPerShift;
        private static int DefaultBreakDurationSeconds;
        ILocalSetting _LocalSetting;
        //static ApplicationDataContainer _LocalSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public Setting(ILocalSetting setting)
        {
            //data = ApplicationData.Current;
            //_AlwaysUseDefault = alwaysUseDefault;
            _LocalSetting = setting;
            IsInitialized = false;
            DefaultMaxAssistPerShift = 100;
            DefaultBreakDurationSeconds = 7200;
            //Current = this;
        }

        public void Initialize()
        {
            //IsSpeechEnabled = false;
            IsSpeechEnabled = _LocalSetting == null? false : _LocalSetting.GetValue(false, nameof(IsSpeechEnabled));
            IsAssistantEnabled = _LocalSetting == null ? false : _LocalSetting.GetValue(false, nameof(IsAssistantEnabled));
            DailyAssistCount = _LocalSetting == null ? 0 : _LocalSetting.GetValue(0, nameof(DailyAssistCount));
            MaxAssistPerShift = DefaultMaxAssistPerShift;
            LastDateTime = _LocalSetting == null ? DateTime.Now : _LocalSetting.GetValue(DateTime.Now, nameof(LastDateTime));
            BreakDurationSeconds = DefaultBreakDurationSeconds;
            LifetimeAssistCount = _LocalSetting == null ? 0 : _LocalSetting.GetValue(0, nameof(LifetimeAssistCount));

            TryResetCounter();

            IsDebugMode = false;
            HasDelay = true;

#if DEBUG
            MaxAssistPerShift = 5;
            BreakDurationSeconds = 200;
#endif
            IsInitialized = true;
        }

        public void TryResetCounter()
        {
            if (GetBreakSecondsRemaining() <= 0)
            {
                LastDateTime = DateTime.Now;
                DailyAssistCount = 0;
            }
        }

        public bool MaxAssistReached()
        {
            TryResetCounter();
            return DailyAssistCount >= MaxAssistPerShift;
        }

        public int GetBreakSecondsRemaining()
        {
            return Math.Max(0, BreakDurationSeconds - (int)DateTime.Now.Subtract(LastDateTime).TotalSeconds);
        }

        public void Save()
        {
            _LocalSetting?.SetValue(IsSpeechEnabled, nameof(IsSpeechEnabled));
            _LocalSetting?.SetValue(IsAssistantEnabled, nameof(IsAssistantEnabled));
            _LocalSetting?.SetValue(DailyAssistCount, nameof(DailyAssistCount));
            //SetValue(MaxAssistPerDay, nameof(MaxAssistPerDay));
            _LocalSetting?.SetValue(LastDateTime, nameof(LastDateTime));
        }

        public void ResetToDefault()
        {
            //_AlwaysUseDefault = true;
            Initialize();
            //_AlwaysUseDefault = false;
        }

        public static Setting Current { get; set; }
        private bool _IsSpeechEnabled;
        public bool IsSpeechEnabled
        {
            get
            {
                return _IsSpeechEnabled;
            }
            set
            {
                _IsSpeechEnabled = value;
                NotifyPropertyChanged("TTSBgColor");
                //NotifyPropertyChanged("SpeechToggleImage");
            }
        }

        private bool _IsAssistantEnabled;
        public bool IsAssistantEnabled
        {
            get
            {
                return _IsAssistantEnabled;
            }
            set
            {
                _IsAssistantEnabled = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("AssistantBgColor");
            }
        }
        private int _DailyAssistCount;
        public int DailyAssistCount
        {
            get
            {
                return _DailyAssistCount;
            }
            set
            {
                if(value > _DailyAssistCount)
                {
                    LifetimeAssistCount++;
                }
                _DailyAssistCount = value;
                if(value >= MaxAssistPerShift)
                {
                    LastDateTime = DateTime.Now > LastDateTime ? DateTime.Now : LastDateTime;
                }
            }
        }
        public int MaxAssistPerShift { get; set; }
        public DateTime LastDateTime { get; set; }
        public int BreakDurationSeconds { get; set; }
        public string TTSBgColor
        {
            get
            {
                if (IsSpeechEnabled)
                    return "#CC8329";
                else
                    return "#333333";
            }
        }
        public string AssistantBgColor
        {
            get
            {
                if (IsAssistantEnabled)
                    return "#CC8329";
                else
                    return "#333333";
            }
        }
        public string AssistantToggleImage
        {
            get
            {
                if (IsAssistantEnabled)
                    return "AssistantEnabled.png";
                else
                    return "AssistantDisabled.png";
            }
        }

        public string SpeechToggleImage
        {
            get
            {
                if (IsSpeechEnabled)
                    return "SpeechEnabled.png";
                else
                    return "SpeechDisabled.png";
            }
        }

        public string[] Ports = new string[] { "22111" };//, "47050"

        public string SendingPort
        {
            get
            {
                return "22112";
            }
        }
        public string ReceivingPort
        {
            get
            {
                return "22111";
            }
        }
        public string FacebookAppId
        {
            get
            {
                return "990907747636818";
            }
        }
        public bool IsEncrypted
        {
            get
            {
                return true;
            }
        }
        public bool HasAd
        {
            get
            {
                return true;
            }
        }


        public string BroadcastAddress
        {
            get
            {
                return "255.255.255.255";
            }
        }

        public int MessageDelayMiliseconds
        {
            get
            {
                return 45;
            }
        }
        public int ListViewScrollDelayMiliseconds
        {
            get
            {
                return 500;
            }
        }

        public bool IsDebugMode { get; set; }
        public bool HasDelay { get; set; }
        public int LifetimeAssistCount { get; private set; }

        public readonly string EnableDebugMode = "#debug#";
        public readonly string DisableDelay = "#nodelay#";



        //private TextWrapping _ChatBubbleMinWidth;
        //public TextWrapping ChatBubbleMinWidth
        //{
        //    get
        //    {
        //        if (_ChatBubbleMinWidth == null)
        //        {
        //            _ChatBubbleMinWidth = GetValue(new Thickness(1));
        //        }
        //        return _ChatBubbleMinWidth;
        //    }
        //    set
        //    {
        //        _ChatBubbleMinWidth = value;
        //        SetValue(_ChatBubbleMinWidth);
        //    }
        //}        
        //public LocalSetting<int> UseCount { get; set; }
        //private static T GetLocalValue<T>(string name, T defValue = default(T))
        //{
        //    return _LocalSettings.Values[name] == null ? defValue : (T)_LocalSettings.Values[name];
        //}
        //private static void SetLocalValue<T>(string name, T value)
        //{
        //    _LocalSettings.Values[name] = value;
        //}
        public string GetLifeTimeUseCountRange(int lifetimeCount)
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

        public int LifetimeUseCount
        {
            get
            {
                return _LocalSetting.GetValue<int>();
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
                return _LocalSetting.GetValue<int>();
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
                return _LocalSetting.GetValue<bool>();
            }
            set
            {
                _LocalSetting.GetValue<bool>();
            }
        }

    }
}
