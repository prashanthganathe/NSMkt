namespace NSMkt.Services.Interface
{
    public interface INSEAPI
    {
        #region Index
        Task<IndexOptionChainResponse> GetIndexOCDataAsyncAPI(string script);
       
        Task<List<NSENifty50>> Nifty50ListAPI();
        #endregion

        #region Stocks
        Task StocksOC();
        Task<List<OptionChainStockSummary>> FAndOSecuritiesAPI();
        #endregion
    }
}
