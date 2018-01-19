using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hue
{
    /// <summary>
    /// Send Async REST Json Requests
    /// </summary>
    internal static class HttpRestHelper
    {
        public static string Post(string url, string body)
        {
            var result = (new HttpClient()).PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            var stringResult = result.Content.ReadAsStringAsync();
            return stringResult.Result;
        }

        public static string Put(string url, string body)
        {
            var result = (new HttpClient()).PutAsync(url, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            if (result.IsSuccessStatusCode)
            {
                var r = result.Content.ReadAsStringAsync().Result;
                if (r.Contains("error"))
                    System.Diagnostics.Trace.Write(r);
                return r;
            }
            return "";
        }
    }
}