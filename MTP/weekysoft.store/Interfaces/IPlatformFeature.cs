using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Interfaces
{
    public interface IPlatformFeature
    {
        IRateApp RateApp { get; set; }

        IClipboard Clipboard { get; set; }
        IVersion AppVersion { get; set; }
        IDevice DeviceInfo { get; set; }
    }
}
