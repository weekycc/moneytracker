using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using Windows.ApplicationModel;

namespace MTP.UWP
{
    public class AppVersion : IVersion
    {
        string _Version;
        public string Version
        {
            get
            {
                if(String.IsNullOrEmpty(_Version))
                {
                    _Version = GetVersion();
                }
                return _Version;
            }
        }

        public string GetVersion()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}
