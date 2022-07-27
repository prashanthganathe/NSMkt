namespace NSMkt.Services.Interface
{
    public interface INSEAPI
    {
        Task<IndexOptionChainResponse> GetIndexOCDataAsyncAPI(string script);
        Task<List<OptionChainStockSummary>> FAndOSecuritiesAPI();
        Task<List<NSENifty50>> Nifty50ListAPI();
    }
}
