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
    public class RateApp : IRateApp
    {
        public bool Rate()
        {
            Android.Net.Uri uri = Android.Net.Uri.Parse($"market://details?id={Application.Context.PackageName}");
            Intent goToMarket = new Intent(Intent.ActionView, uri);
            // To count with Play market backstack, After pressing back button, 
            // to taken back to our application, we need to add following flags to intent. 
            goToMarket.AddFlags(ActivityFlags.NoHistory |
                            ActivityFlags.NewDocument |
                            ActivityFlags.MultipleTask | ActivityFlags.NewTask);
            try
            {
                Application.Context.StartActivity(goToMarket);
                return true;
            }
            catch (ActivityNotFoundException e)
            {
                return false;
                //Application.Context.StartActivity(new Intent(Intent.ActionView,
                //        Android.Net.Uri.Parse("http://play.google.com/store/apps/details?id=com.weekysoft.android.netchat")));
            }
        }
    }
}