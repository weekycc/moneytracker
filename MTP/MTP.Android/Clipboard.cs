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
    public class Clipboard : IClipboard
    {
        public void Copy(string text)
        {
            ((ClipboardManager)Application.Context.GetSystemService(LauncherActivity.ClipboardService)).Text = text;
        }
    }
}