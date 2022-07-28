namespace NSMkt.Services.Interface
{
    public interface INSEIndexOCService
    {
        Task<List<OCIndexData>> GetOCIndexDataAsyncFiltered(List<string> scripts, int neighbours, bool? nextmonth = false);
     

        Task<string> GetIndexBodyHTML();
        Task<string> GetIndexSubject();

    }
}
