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

        public async Task<List<OCIndexData>> GetOCDataAsyncFiltered(string script, string? expiry = null)
        {
            try
            {
                var OCResponse = await GetOCDataAsync(script);
                if (OCResponse!=null)
                {
                    List<OCIndexData> result = new List<OCIndexData>();
                    if (expiry!=null)
                        result=OCResponse.Records.Data.Where(x => x.ExpiryDate==expiry).ToList();
                    return result;
                }
                return null;
            }
            catch (Exception ex)
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
