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
    public class Device : IDevice
    {
        string _Model;
        public string GetModel()
        {
            if(String.IsNullOrEmpty(_Model))
            {
                _Model = $"{Build.Manufacturer} {Build.Model}";
            }
            return _Model;
        }
    }
}