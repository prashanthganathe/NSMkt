namespace NSMkt.Services.Interface
{
    public interface INSEOCService
    {
        Task<List<OCIndexData>> GetOCDataAsyncFiltered(List<string> script,int neighbours, bool? nextmonth = false);


    }
}
