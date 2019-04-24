using MTP.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MTP.WebApi
{
    public class TableStorage
    {
        static string AppId = "MT";
        public static async Task<string> Log(string message, string logtype="Info", string stacktrace="", [CallerMemberName]string callingmethod="")
        {
            string res = string.Empty;
            //#if !DEBUG
            string platform = AppSetting.Current.Platform;
            var model = AppSetting.Current.PlatformFeature.DeviceInfo?.GetModel();
            stacktrace = stacktrace.Substring(0, Math.Min(stacktrace.Length, 1000));
            try
            {
                string url = $"Utility/InsertLog?p={AppId}&r={DateTime.Now.Ticks}&m={message}&s={WebUtility.UrlEncode(stacktrace)}&i={AppClientData.Current.CurrentProfile.ProfileId.ToString()}&c={callingmethod}&pv={1}&l={logtype}&v={AppSetting.Current.PlatformFeature.AppVersion?.Version}&pf={platform}&d={model}";
                res = await AppClientData.Current.WebUtitlity.GetResult(url);

            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
//#endif
            return res;
        }
    }
}
