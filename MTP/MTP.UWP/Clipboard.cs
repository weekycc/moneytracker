using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Interfaces;
using Windows.ApplicationModel.DataTransfer;

namespace MTP.UWP
{
    public class Clipboard : IClipboard
    {

        public Clipboard()
        {
        }
        public void Copy(string text)
        {
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(text);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }
    }
}
