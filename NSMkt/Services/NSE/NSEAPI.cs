namespace NSMkt.Services.NSE
{
    public class NSEAPI:INSEAPI
    {

        public const string OCIndexUrl = "https://www.nseindia.com/api/option-chain-indices?symbol=#index";//NIFTY
        public const string OCStockUrl = "https://www.nseindia.com/api/option-chain-indices?symbol=#index";

        private readonly ApplicationDbContext _cnxt;
        private readonly INSEMarketService _mktService;
        public NSEAPI(ApplicationDbContext cnxt, INSEMarketService mktService)
        {
            _cnxt = cnxt;
            _mktService = mktService;
        }


        #region APICalls

        #region Index
        public async Task<IndexOptionChainResponse> GetIndexOCDataAsyncAPI(string script)
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




 



        public async Task<List<NSENifty50>> Nifty50ListAPI()
        {
            try
            {
                var url = "hhttps://www.nseindia.com/json/equity-stockIndices.json";
                if (_mktService.IsMarketTime())
                {
                    HttpClient http = await _mktService.GetNSEHttpClient();
                    List<OptionChainStockSummary> foList = new List<OptionChainStockSummary>();
                    List<NSENifty50> resp = null;
                    CancellationTokenSource cancellationToken = new CancellationTokenSource();
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    using (var response = await http.SendAsync(request, cancellationToken.Token))
                    {
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        resp = JsonConvert.DeserializeObject<List<NSENifty50>>(content);
                        return resp;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region Stocks

        public async Task StocksOC()
        {
            var stkOCs = await FAndOSecuritiesAPI();
            if (stkOCs != null)
            {
                //
            }
        }

        public async Task<List<OptionChainStockSummary>> FAndOSecuritiesAPI()
        {
            try
            {
                var url = "https://www.nseindia.com/api/equity-stockIndices?index=SECURITIES%20IN%20F%26O";
                if (_mktService.IsMarketTime())
                {
                    HttpClient http = await _mktService.GetNSEHttpClient();
                    List<OptionChainStockSummary> foList = new List<OptionChainStockSummary>();
                    NSEFOModel resp = null;
                    CancellationTokenSource cancellationToken = new CancellationTokenSource();
                    using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                    using (var response = await http.SendAsync(request, cancellationToken.Token))
                    {
                        response.EnsureSuccessStatusCode();
                        var content = await response.Content.ReadAsStringAsync();
                        resp = JsonConvert.DeserializeObject<NSEFOModel>(content);
                    }
                    if (resp != null)
                    {
                        OptionChainStockSummary temp = null;
                        foreach (var stk in resp.Data)
                        {
                            try
                            {
                                temp = new OptionChainStockSummary();
                                temp.script = stk.Symbol;
                                temp.expiry = _mktService.GetMonthlyExpiryText(DateTime.Now);
                                temp.ltp = Convert.ToDecimal(stk.LastPrice);
                                temp.High = Convert.ToDecimal(stk.DayHigh);
                                temp.Low = Convert.ToDecimal(stk.DayLow);
                                temp.Open = Convert.ToDecimal(stk.Open);
                                temp.yearHigh = Convert.ToDecimal(stk.YearHigh);
                                temp.yearLow = Convert.ToDecimal(stk.YearLow);
                                temp.prevClose = Convert.ToDecimal(stk.PreviousClose);
                                temp.TurnOver = Math.Round(Convert.ToDecimal(stk.TotalTradedValue) / 10000000, 0);
                                foList.Add(temp);
                            }
                            catch (Exception ex) { }
                        }
                        var n50 = await Nifty50ListAPI();
                        var n50Scripts = n50.SelectMany(x => x.Data.Select(x => x.Symbol.ToUpper())).ToList();
                        foList.Where(y => n50Scripts.Contains(y.script.ToUpper())).ToList().ForEach(x => x.IsTop50 = true);

                        if (foList.Count > 0)
                        {
                            return foList;
                        }
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        #endregion


        #endregion
    }
}
