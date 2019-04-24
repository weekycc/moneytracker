using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using weekysoft.store.Interfaces;
using Android.Content.PM;

namespace MTP.Droid
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
            return Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, PackageInfoFlags.MatchAll).VersionName;
        }
    }
}