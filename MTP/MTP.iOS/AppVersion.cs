using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weekysoft.store.Interfaces;

namespace MTP.iOS
{
    public class AppVersion : IVersion
    {
        string _Version;
        public string Version
        {
            get
            {
                if (String.IsNullOrEmpty(_Version))
                {
                    _Version = GetVersion();
                }
                return _Version;
            }
        }

        public string GetVersion()
        {
            return NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();
        }
    }
}