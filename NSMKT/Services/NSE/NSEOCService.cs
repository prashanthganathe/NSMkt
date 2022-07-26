using NSMkt.Models.NSEModels;

namespace NSMkt.Services.NSE
{
    public class NSEOCService:INSEOCService
    {
        public const string OCIndexUrl = "https://www.nseindia.com/api/option-chain-indices?symbol=#index";//NIFTY

        private readonly ApplicationDbContext _cnxt;
        private readonly INSEMarketService _mktService;
        public NSEOCService(ApplicationDbContext cnxt, INSEMarketService mktService)
        {
            _cnxt = cnxt;
            _mktService = mktService;
        }

        
        public async Task<List<OCIndexData>> GetOCDataAsyncFiltered(List<string> scripts,int neighbours,bool? nextmonth=false)
        {
            try
            {               
                List<OCIndexData> resultset = new List<OCIndexData>();
                foreach (var script in scripts)
                {
                    resultset.AddRange(await GetOCList(script,neighbours, nextmonth));
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<OCIndexData>> GetOCList(string script, int neighbours, bool? nextmonth)
        {
            List<string> expiries = new List<string>();
            List<OCIndexData> result = new List<OCIndexData>();
            try
            {
                expiries.Add(_mktService.GetMonthlyExpiryText(_mktService.GetCurrentISTTime()));

                if (script=="BANKNFITY" || script=="NIFTY")
                    expiries.Add(_mktService.GetWeeklyExpiryText(_mktService.GetCurrentISTTime()));
                if (nextmonth==true)
                    expiries.Add(_mktService.GetWeeklyExpiryText(_mktService.GetCurrentISTTime().AddDays(30)));

                var OCResponse = await GetOCDataAsync(script, expiries, neighbours,nextmonth);
                if (OCResponse!=null)
                {
                    result=OCResponse.Records.Data.Where(x => expiries.Contains(x.ExpiryDate)).ToList();
                    return result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }




        #region APICalls
        public async Task<IndexOptionChainResponse> GetOCDataAsync(string script)
        {           
            try
            {
                var url = OCIndexUrl.Replace("#index", script);
                var http = await _mktService.GetNSEHttpClient();                
                var dt = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                var weeklyexpiry = _mktService.GetWeeklyExpiryText(dt);
                var monthlyexpiry = _mktService.GetMonthlyExpiryText(dt);
                CancellationTokenSource cancellationToken = new CancellationTokenSource();             
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var response = await http.SendAsync(request, cancellationToken.Token))
                {
                    IndexOptionChainResponse resp = new IndexOptionChainResponse();
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    resp = JsonConvert.DeserializeObject<IndexOptionChainResponse>(content);
                    return resp;
                }
                return null;       
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion 

    }
}
