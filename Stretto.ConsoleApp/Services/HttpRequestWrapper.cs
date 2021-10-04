using System.IO;
using System.Net;

namespace Stretto.ConsoleApp.Services
{
    public abstract class HttpRequestWrapper
    {
        protected string MakeHttpRequest(string url, string method = "GET", int timeoutInMiliseconds = 30000)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = method;
                request.Timeout = timeoutInMiliseconds;
                request.AllowWriteStreamBuffering = false;

                using var response = (HttpWebResponse)request.GetResponse();
                using var stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
            catch (System.Net.WebException)
            {
                throw;
            }
        }
    }
}