using Hangfire;
using Hangfire.Storage;

namespace NSMkt.Services
{
    public static class CookieClass
    {
        public static string nsecookie { get; set; }
    }

    public class GlobalVariableService : IGlobalVariableService
    {
        public string NSECookie = null;
        public GlobalVariableService()
        {

        }
        public async Task RunHangFireServices()
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            List<string> indexScript = new List<string>();
            indexScript.Add("BANKNIFTY");
            indexScript.Add("NIFTY");
            RecurringJob.AddOrUpdate<IGlobalVariableService>("SetCookieBG", x => x.SetNSECookie(), "0/5 * * * 1,2,3,4,5", INDIAN_ZONE);
            RecurringJob.AddOrUpdate<IJobs>("Index09", x => x.OCDetailAsync(indexScript, 10), "0/3 9,10,11,12,13,14,15 * * 1,2,3,4,5", INDIAN_ZONE);


            //RecurringJob.AddOrUpdate<IOptimizedOCService>("IndexNight", x => x.SaveOptionChainIndexAsync(indexScript, IndexOCNeighbours), "0/45 3,8 * * 1,2,3,4,5", INDIAN_ZONE);

        }


        public async Task SetNSECookie()
        {
            NSECookie =await GetNSEIndiaCookieValue();
            CookieClass.nsecookie= NSECookie;
        }


        public async Task<string> GetNSEIndiaCookieValue()
        {
            Semaphore spCookie = new Semaphore(1, 1, "cookieSemaphore");
            spCookie.WaitOne();
            try
            {
                var url = "https://nseindia.com/";
                var cookieContainer = new CookieContainer();
                var uri = new Uri(url);
                Tuple<string, string> temp = null;
                using (var httpClientHandler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer
                })
                {
                 
                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                        httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                        httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36");
                        httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                        httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site", "none");
                        httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                        httpClient.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                        httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
                        httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                        httpClient.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                        httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-GB,en;q=0.9");
                        var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
                        if (response.StatusCode != HttpStatusCode.Forbidden)
                        {
                            IEnumerable<string> cookiesinHeader = response.Headers.SingleOrDefault(header => header.Key == "Set-Cookie").Value;
                            if (cookiesinHeader != null)
                            {
                                Dictionary<string, string> cookies = new Dictionary<string, string>();
                                foreach (var c in cookiesinHeader)
                                {
                                    //var t = GetCookie(c);
                                    temp = GetCookie(c);
                                    cookies.Add(temp.Item1, temp.Item2);
                                }
                                //foreach (var c in cookies)
                                //{
                                //    cookies[c.Key] = cookieContainer.GetCookies(uri).Cast<Cookie>().FirstOrDefault(x => x.Name == c.Key).ToString();
                                //}
                                string cookieStr = "";
                                foreach (var c in cookies)
                                {
                                    if (c.Key == "nsit" || c.Key == "nseappid")
                                        cookieStr += c.Key.ToString() + "=" + c.Value.ToString() + ";";
                                }
                                return cookieStr;
                            }
                        }
                        else
                        {
                            return await GetNSEIndiaCookieValue();
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                spCookie.Release();
                spCookie.Dispose();
            }
        }

        public Tuple<string, string> GetCookie(string setCookie)
        {

            var setCookieString = setCookie;
            var cookieTokens = setCookieString.Split(';');
            var firstCookie = cookieTokens.FirstOrDefault();
            var keyValueTokens = firstCookie.Split('=');
            var valueString = keyValueTokens[1];
            var cookieValue = HttpUtility.UrlDecode(valueString);
            return new Tuple<string, string>(keyValueTokens[0], cookieValue);
        }


        public async Task CleanHangFireJobs()
        {
            try
            {

                using (var connection = JobStorage.Current.GetConnection())
                {
                    foreach (var recurringJob in StorageConnectionExtensions.GetRecurringJobs(connection))
                    {
                        RecurringJob.RemoveIfExists(recurringJob.Id);
                    }
                    BackgroundJob.Enqueue<GlobalVariableService>(x => x.SetNSECookie());
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
