using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using weekysoft.store.Interfaces;

namespace MTP.iOS
{
    public class Clipboard : IClipboard
    {
        public void Copy(string text)
        {
            UIPasteboard clipboard = UIPasteboard.General;
            clipboard.String = text;
        }
    }
}