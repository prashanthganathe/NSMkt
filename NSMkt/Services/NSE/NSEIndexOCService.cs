using NSMkt.Models.NSEModels;

namespace NSMkt.Services.NSE
{
    public class NSEIndexOCService : INSEIndexOCService
    {
       

        private readonly ApplicationDbContext _cnxt;
        private readonly INSEMarketService _mktService;
        private readonly INSEAPI _nseAPI;
        public NSEIndexOCService(ApplicationDbContext cnxt, INSEMarketService mktService, INSEAPI nseAPI)
        {
            _cnxt = cnxt;
            _mktService = mktService;
            _nseAPI = nseAPI;
        }

       public async Task<string> GetIndexBodyHTML()
        {
            return "";
        }
        public async Task<string> GetIndexSubject()
        {
            return "";
        }







        public async Task<List<OCIndexData>> GetOCIndexDataAsyncFiltered(List<string> scripts, int neighbours, bool? nextmonth = false)
        {
            List<OCIndexData> resultSet = new List<OCIndexData>();           
            Parallel.ForEach(scripts, async script =>
            {
                try
                {
                    resultSet.AddRange(await GetOCIndexFilteredDetails(script, neighbours, nextmonth));                   
                }
                catch (Exception ex)
                {
                }
            }
            );

            return resultSet;
        }




        public async Task<List<OCIndexData>> GetOCIndexFilteredDetails(string script, int neighbours, bool? nextmonth = false)
        {
            List<OCIndexData> result = new List<OCIndexData>();
            var OCResponse = await _nseAPI.GetIndexOCDataAsyncAPI(script);
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



   

    }
}
