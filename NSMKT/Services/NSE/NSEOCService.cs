using NSMkt.Models.NSEModels;

namespace NSMkt.Services.NSE
{
    public class NSEOCService : INSEOCService
    {
        public const string OCIndexUrl = "https://www.nseindia.com/api/option-chain-indices?symbol=#index";//NIFTY

        private readonly ApplicationDbContext _cnxt;
        private readonly INSEMarketService _mktService;
        public NSEOCService(ApplicationDbContext cnxt, INSEMarketService mktService)
        {
            _cnxt = cnxt;
            _mktService = mktService;
        }


        public async Task<List<OCIndexData>> GetOCDataAsyncFiltered(List<string> scripts, int neighbours, bool? nextmonth = false)
        {
            List<OCIndexData> resultSet = new List<OCIndexData>();
            //foreach (var script in scripts)
            Parallel.ForEach(scripts, async script =>
            {
                try
                {
                    resultSet.AddRange(await GetOCFilteredDetails(script, neighbours, nextmonth));
                }
                catch (Exception ex)
                {
                }
            }
            );
            return resultSet;

          
        }


        public async Task<List<OCIndexData>> GetOCFilteredDetails(string script, int neighbours, bool? nextmonth = false)
        {
            List<OCIndexData> result = new List<OCIndexData>();
            var OCResponse = await GetOCDataAsync(script);
            List<string> expiries = new List<string>();
            if (script=="BANKNFITY" || script=="NIFTY")
            {
                expiries.Add(_mktService.GetWeeklyExpiryText(_mktService.GetCurrentISTTime()));
            }
            expiries.Add(_mktService.GetMonthlyExpiryText(_mktService.GetCurrentISTTime()));
            if(nextmonth.Value)
                expiries.Add(_mktService.GetMonthlyExpiryText(_mktService.GetCurrentISTTime().AddMonths(1)));
            if (OCResponse!=null)
            {
                //expiry filter
                result=OCResponse.Records.Data.Where(x => expiries.Contains(x.ExpiryDate)).ToList();

                //neighbour filter
                if(result.Count>1 && neighbours>0)
                {                   
                    var splist = result.OrderByDescending(x => x.StrikePrice).Select(x=>x.StrikePrice).ToList();
                    var iteration = splist[0]-splist[1];
                    var atm = (Math.Round(Convert.ToDecimal(result[0].CE.UnderlyingValue )/ iteration, 0) * iteration);
                    result= result.Where(x => x.StrikePrice>=(atm-10*(iteration/2)) && x.StrikePrice<=(atm+10*(iteration/2))).ToList();
                }
                return result;
            }
            return null;
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
