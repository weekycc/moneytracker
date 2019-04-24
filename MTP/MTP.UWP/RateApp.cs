using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using Windows.ApplicationModel;

namespace MTP.UWP
{
    public class RateApp : IRateApp
    {
        public bool Rate()
        {
            Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:REVIEW?PFN=" + Package.Current.Id.FamilyName));
            return true;
        }
    }
}
