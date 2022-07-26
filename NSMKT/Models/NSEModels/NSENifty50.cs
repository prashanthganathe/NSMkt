namespace NSMkt.Models.NSEModels
{


    public class NSENifty50
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("advance")]
        public N50Advance Advance;

        [JsonProperty("timestamp")]
        public string Timestamp;

        [JsonProperty("data")]
        public List<N50Datum> Data;

        [JsonProperty("metadata")]
        public N50Metadata Metadata;

        [JsonProperty("marketStatus")]
        public N50MarketStatus MarketStatus;

        [JsonProperty("date30dAgo")]
        public string Date30dAgo;

        [JsonProperty("date365dAgo")]
        public string Date365dAgo;
    }
    public class N50Advance
    {
        [JsonProperty("declines")]
        public string Declines;

        [JsonProperty("advances")]
        public string Advances;

        [JsonProperty("unchanged")]
        public string Unchanged;
    }

    public class N50Datum
    {
        [JsonProperty("priority")]
        public int Priority;

        [JsonProperty("symbol")]
        public string Symbol;

        [JsonProperty("identifier")]
        public string Identifier;

        [JsonProperty("open")]
        public double Open;

        [JsonProperty("dayHigh")]
        public double DayHigh;

        [JsonProperty("dayLow")]
        public double DayLow;

        [JsonProperty("lastPrice")]
        public double LastPrice;

        [JsonProperty("previousClose")]
        public double PreviousClose;

        [JsonProperty("change")]
        public double Change;

        [JsonProperty("pChange")]
        public double PChange;

        [JsonProperty("ffmc")]
        public double Ffmc;

        [JsonProperty("yearHigh")]
        public double YearHigh;

        [JsonProperty("yearLow")]
        public double YearLow;

        [JsonProperty("totalTradedVolume")]
        public int TotalTradedVolume;

        [JsonProperty("totalTradedValue")]
        public double TotalTradedValue;

        [JsonProperty("lastUpdateTime")]
        public string LastUpdateTime;

        [JsonProperty("nearWKH")]
        public double NearWKH;

        [JsonProperty("nearWKL")]
        public double NearWKL;

        [JsonProperty("perChange365d")]
        public double PerChange365d;

        [JsonProperty("date365dAgo")]
        public string Date365dAgo;

        [JsonProperty("chart365dPath")]
        public string Chart365dPath;

        [JsonProperty("date30dAgo")]
        public string Date30dAgo;

        [JsonProperty("perChange30d")]
        public double PerChange30d;

        [JsonProperty("chart30dPath")]
        public string Chart30dPath;

        [JsonProperty("chartTodayPath")]
        public string ChartTodayPath;

        [JsonProperty("series")]
        public string Series;

        [JsonProperty("meta")]
        public Meta Meta;
    }

    public class N50MarketStatus
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
        public double Last;

        [JsonProperty("variation")]
        public double Variation;

        [JsonProperty("percentChange")]
        public double PercentChange;

        [JsonProperty("marketStatusMessage")]
        public string MarketStatusMessage;
    }

    public class N50Meta
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
        public List<string> DebtSeries;

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

    public class N50Metadata
    {
        [JsonProperty("indexName")]
        public string IndexName;

        [JsonProperty("open")]
        public double Open;

        [JsonProperty("high")]
        public double High;

        [JsonProperty("low")]
        public double Low;

        [JsonProperty("previousClose")]
        public int PreviousClose;

        [JsonProperty("last")]
        public double Last;

        [JsonProperty("percChange")]
        public double PercChange;

        [JsonProperty("change")]
        public double Change;

        [JsonProperty("timeVal")]
        public string TimeVal;

        [JsonProperty("yearHigh")]
        public double YearHigh;

        [JsonProperty("yearLow")]
        public double YearLow;

        [JsonProperty("totalTradedVolume")]
        public int TotalTradedVolume;

        [JsonProperty("totalTradedValue")]
        public double TotalTradedValue;

        [JsonProperty("ffmc_sum")]
        public double FfmcSum;
    }




}
