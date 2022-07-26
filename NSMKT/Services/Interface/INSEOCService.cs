namespace NSMkt.Services.Interface
{
    public interface INSEOCService
    {
        Task<List<OCIndexData>> GetOCDataAsyncFiltered(List<string> scripts, int neighbours, bool? nextmonth = false);


        Task StocksOC();


    }
}
