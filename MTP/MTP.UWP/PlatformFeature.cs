using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;

namespace MTP.UWP
{
    public class PlatformFeature : IPlatformFeature
    {
        public IVersion AppVersion { get; set; }

        public IClipboard Clipboard { get; set; }

        public IRateApp RateApp { get; set; }

    }
}
