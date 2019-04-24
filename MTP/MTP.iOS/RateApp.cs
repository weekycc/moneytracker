using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using weekysoft.store.Interfaces;

namespace MTP.iOS
{
    public class RateApp : IRateApp
    {
        public bool Rate()
        {
            try
            {
                String url;
                Version iOSVersion = new Version(UIDevice.CurrentDevice.SystemVersion);

                if (iOSVersion.CompareTo(new Version("7.0")) >= 0 && iOSVersion.CompareTo(new Version("7.1")) < 0)
                {
                    url = "itms-apps://itunes.apple.com/app/id1210146155";
                }
                else
                {
                    url = "itms-apps://itunes.apple.com/WebObjects/MZStore.woa/wa/viewContentsUserReviews?type=Purple+Software&id=1210146155";
                }
                UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}