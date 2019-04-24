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

namespace MTP.Droid
{
    public class PlatformFeature : IPlatformFeature
    {
        public IClipboard Clipboard { get; set; }

        public IRateApp RateApp { get; set; }
        public IVersion AppVersion { get; set; }
        public IDevice DeviceInfo { get; set; }
    }
}