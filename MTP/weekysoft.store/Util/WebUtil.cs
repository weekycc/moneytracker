using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace weekysoft.store.Util
{
    public class WebUtil
    {
        string _BaseUrl { get; set; }
        int _Timeout { get; set; }
        public WebUtil(string baseurl, int timeout)
        {
            _BaseUrl = baseurl;
            _Timeout = timeout;
        }

        public async Task<string> GetResult(string query)
        {
            string result = string.Empty;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, _Timeout / 1000);
                    var response = await client.GetAsync(_BaseUrl + query);
                    var responseString = await response.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
    }
}
