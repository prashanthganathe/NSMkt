namespace NSMkt.Services.Interface
{
    public interface INSEOCService
    {
        Task<List<OCIndexData>> GetOCIndexDataAsyncFiltered(List<string> scripts, int neighbours, bool? nextmonth = false);


        Task StocksOC();


    }
}
