namespace NSMkt.Services.Interface
{
    public interface INSEMarketService
    {
        DateTime GetCurrentISTTime();
        Task<HttpClient> GetNSEHttpClient();
        Task<DateTime> GetMktTime(string mkt = "NSE");
        string GetWeeklyExpiryText(DateTime date);
        string GetMonthlyExpiryText(DateTime date);

        
    }
}
