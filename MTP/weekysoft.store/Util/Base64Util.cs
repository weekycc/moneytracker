using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Util
{
    public class Base64Util
    {
        static int _Counter = 0;
        static int Counter
        {
            get
            {
                if (_Counter > 9999)
                {
                    _Counter = 0;
                }
                return _Counter;
            }

            set
            {
                _Counter = value;
            }
        }
        public static string GenerateUniqueId(string ipAddress)
        {
            var ipParts = ipAddress.Split('.');
            int ipInt = Convert.ToInt32(ipParts[2]) * 256 + Convert.ToInt32(ipParts[3]);//ignore first two segments since it is not pratical to handle large subnets
            var ticks = Convert.ToUInt32(DateTime.Now.Ticks / 10000000 * 10000 % 4000000000 + Counter++);

            var ipByte = BitConverter.GetBytes(Convert.ToUInt16(ipInt)).AsEnumerable();
            var secByte = BitConverter.GetBytes(ticks).AsEnumerable();
            var finalByte = ipByte.Concat(secByte);
            var messageId = Convert.ToBase64String(finalByte.ToArray());
            return messageId;
        }

        public static string ToBase64String(string text)
        {
            byte[] byt = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(byt);
        }
        public static string FromBase64String(string base64)
        {
            var reverseBytes = Convert.FromBase64String(base64);
            var reversestring = BitConverter.ToString(reverseBytes, 0);
            return reversestring;
        }
        private static string RemoveInvalidCharacters(string json)
        {
            return json.Replace("\0", "").Replace("\f", "").Replace("\v", "").Replace("\a", "");
        }
        public static string UrlSafe(string base64)
        {
            return base64.Replace('+', '-').Replace('/', '_');
        }

        public static string GenerateErrorUniqueId()
        {
            //var minutes = Convert.ToUInt16(DateTime.Now.Hour * 60 + DateTime.Now.Minute);

            //var messageId = Convert.ToBase64String(BitConverter.GetBytes(minutes));
            return GenerateUniqueId(60);
        }

        public static string GenerateUniqueId(int frequencyInSeconds)
        {
            var totalSeconds = Convert.ToUInt16(((DateTime.Now.Hour % 12) * 60 * 60 + DateTime.Now.Minute * 60 + DateTime.Now.Second) / frequencyInSeconds);
            Debug.WriteLine(totalSeconds);
            var messageId = Convert.ToBase64String(BitConverter.GetBytes(totalSeconds));
            return messageId;
        }
        public static string GenerateUniqueIdPerTick()
        {
            var bytes = System.BitConverter.GetBytes(DateTime.UtcNow.Ticks);
            var base64 = System.Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
