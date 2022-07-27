namespace NSMkt.Services.Interface
{
    public interface IJobs
    {
        Task<List<OCIndexData>> OCIndexAsync(List<string> scripts, int neighbours, bool? nextmonth = false);
        Task<List<OCIndexData>> OCStockAsync();
    }
}
