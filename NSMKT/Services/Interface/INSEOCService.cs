namespace NSMkt.Services.Interface
{
    public interface INSEOCService
    {
        Task<List<OCIndexData>> GetOCDataAsyncFiltered(string script, bool? nextmonth = false);


    }
}
