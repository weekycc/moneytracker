using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weekysoft.store.Interfaces;

namespace MTP.iOS
{
    public class PlatformFeature : IPlatformFeature
    {
        public IClipboard Clipboard { get; set; }

        public IRateApp RateApp { get; set; }

        public IVersion AppVersion { get; set; }
    }
}