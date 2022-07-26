namespace NSMkt.Models.NSEModels
{
    public class NSEFOModel
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("advance")]
        public Advance Advance;

        [JsonProperty("timestamp")]
        public string Timestamp;

        [JsonProperty("data")]
        public List<Datum> Data;

        [JsonProperty("metadata")]
        public Metadata Metadata;

        [JsonProperty("marketStatus")]
        public MarketStatus1 MarketStatus;

        [JsonProperty("date30dAgo")]
        public string Date30dAgo;

        [JsonProperty("date365dAgo")]
        public string Date365dAgo;
    }

    public class Advance
    {
        [JsonProperty("advances")]
        public int Advances;

        [JsonProperty("declines")]
        public int Declines;

        [JsonProperty("unchanged")]
        public int Unchanged;
    }

    public class Meta
    {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("companyName")]
        public string CompanyName;

        [JsonProperty("industry")]
        public string Industry;

        [JsonProperty("activeSeries")]
        public List<string> ActiveSeries;

        [JsonProperty("debtSeries")]
        public List<object> DebtSeries;

        [JsonProperty("tempSuspendedSeries")]
        public List<string> TempSuspendedSeries;

        [JsonProperty("isFNOSec")]
        public bool IsFNOSec;

        [JsonProperty("isCASec")]
        public bool IsCASec;

        [JsonProperty("isSLBSec")]
        public bool IsSLBSec;

        [JsonProperty("isDebtSec")]
        public bool IsDebtSec;

        [JsonProperty("isSuspended")]
        public bool IsSuspended;

        [JsonProperty("isETFSec")]
        public bool IsETFSec;

        [JsonProperty("isDelisted")]
        public bool IsDelisted;

        [JsonProperty("isin")]
        public string Isin;
    }

    public class Datum
    {
        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("identifier")]
        public string Identifier;

        [JsonProperty("series")]
        public string Series;

        [JsonProperty("open")]
        public string Open;

        [JsonProperty("dayHigh")]
        public string DayHigh;

        [JsonProperty("dayLow")]
        public string DayLow;

        [JsonProperty("lastPrice")]
        public string LastPrice;

        [JsonProperty("previousClose")]
        public string PreviousClose;

        [JsonProperty("change")]
        public string Change;

        [JsonProperty("pChange")]
        public string PChange;

        [JsonProperty("totalTradedVolume")]
        public int TotalTradedVolume;

        [JsonProperty("totalTradedValue")]
        public string TotalTradedValue;

        [JsonProperty("lastUpdateTime")]
        public string LastUpdateTime;

        [JsonProperty("yearHigh")]
        public string YearHigh;

        [JsonProperty("yearLow")]
        public string YearLow;

        [JsonProperty("nearWKH")]
        public string NearWKH;

        [JsonProperty("nearWKL")]
        public string NearWKL;

        [JsonProperty("perChange365d")]
        public string PerChange365d;

        [JsonProperty("date365dAgo")]
        public string Date365dAgo;

        [JsonProperty("chart365dPath")]
        public string Chart365dPath;

        [JsonProperty("date30dAgo")]
        public string Date30dAgo;

        [JsonProperty("perChange30d")]
        public string PerChange30d;

        [JsonProperty("chart30dPath")]
        public string Chart30dPath;

        [JsonProperty("chartTodayPath")]
        public string ChartTodayPath;

        [JsonProperty("meta")]
        public Meta Meta;
    }

    public class Metadata
    {
        [JsonProperty("timeVal")]
        public string TimeVal;

        [JsonProperty("ffmc_sum")]
        public object FfmcSum;
    }

    public class MarketStatus1
    {
        [JsonProperty("market")]
        public string Market;

        [JsonProperty("marketStatus")]
        public string MarketStatus;

        [JsonProperty("tradeDate")]
        public string TradeDate;

        [JsonProperty("index")]
        public string Index;

        [JsonProperty("last")]
        public string Last;

        [JsonProperty("variation")]
        public string Variation;

        [JsonProperty("percentChange")]
        public string PercentChange;

        [JsonProperty("marketStatusMessage")]
        public string MarketStatusMessage;
    }
}
