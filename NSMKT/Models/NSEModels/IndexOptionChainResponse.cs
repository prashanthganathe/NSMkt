

namespace NSMkt.Models.NSEModels
{

    public class IndexOptionChainResponse
    {
        [JsonProperty("records")]
        public OCIndexRecords Records{get;set;}

        [JsonProperty("filtered")]
        public OCIndexFiltered Filtered{get;set;}
    }


    public class OCIndexCE
    {
        [JsonProperty("strikePrice")]
        public decimal StrikePrice{get;set;}

        [JsonProperty("expiryDate")]
        public string ExpiryDate{get;set;}

        [JsonProperty("underlying")]
        public string Underlying{get;set;}

        [JsonProperty("identifier")]
        public string Identifier{get;set;}

        [JsonProperty("opendecimalerest")]
        public decimal Opendecimalerest{get;set;}

        [JsonProperty("changeinOpendecimalerest")]
        public decimal ChangeinOpendecimalerest{get;set;}

        [JsonProperty("pchangeinOpendecimalerest")]
        public double PchangeinOpendecimalerest{get;set;}

        [JsonProperty("totalTradedVolume")]
        public decimal TotalTradedVolume{get;set;}

        [JsonProperty("impliedVolatility")]
        public double ImpliedVolatility{get;set;}

        [JsonProperty("lastPrice")]
        public double LastPrice{get;set;}

        [JsonProperty("change")]
        public double Change{get;set;}

        [JsonProperty("pChange")]
        public double PChange{get;set;}

        [JsonProperty("totalBuyQuantity")]
        public decimal TotalBuyQuantity{get;set;}

        [JsonProperty("totalSellQuantity")]
        public decimal TotalSellQuantity{get;set;}

        [JsonProperty("bidQty")]
        public decimal BidQty{get;set;}

        [JsonProperty("bidprice")]
        public double Bidprice{get;set;}

        [JsonProperty("askQty")]
        public decimal AskQty{get;set;}

        [JsonProperty("askPrice")]
        public double AskPrice{get;set;}

        [JsonProperty("underlyingValue")]
        public double UnderlyingValue{get;set;}

        [JsonProperty("totOI")]
        public decimal TotOI{get;set;}

        [JsonProperty("totVol")]
        public decimal TotVol{get;set;}
    }

    public class OCIndexData
    {
        [JsonProperty("strikePrice")]
        public decimal StrikePrice{get;set;}

        [JsonProperty("expiryDate")]
        public string ExpiryDate{get;set;}

        [JsonProperty("PE")]
        public OCIndexPE PE{get;set;}

        [JsonProperty("CE")]
        public OCIndexCE CE{get;set;}
    }

    public class OCIndexFiltered
    {
        [JsonProperty("data")]
        public List<OCIndexData> Data{get;set;}

        [JsonProperty("CE")]
        public OCIndexCE CE{get;set;}

        [JsonProperty("PE")]
        public OCIndexPE PE{get;set;}
    }

    public class Index1
    {
        [JsonProperty("key")]
        public string Key{get;set;}

        [JsonProperty("index")]
        public string Index{get;set;}

        [JsonProperty("indexSymbol")]
        public string IndexSymbol{get;set;}

        [JsonProperty("last")]
        public double Last{get;set;}

        [JsonProperty("variation")]
        public double Variation{get;set;}

        [JsonProperty("percentChange")]
        public double PercentChange{get;set;}

        [JsonProperty("open")]
        public double Open{get;set;}

        [JsonProperty("high")]
        public double High{get;set;}

        [JsonProperty("low")]
        public double Low{get;set;}

        [JsonProperty("previousClose")]
        public double PreviousClose{get;set;}

        [JsonProperty("yearHigh")]
        public double YearHigh{get;set;}

        [JsonProperty("yearLow")]
        public double YearLow{get;set;}

        [JsonProperty("pe")]
        public string Pe{get;set;}

        [JsonProperty("pb")]
        public string Pb{get;set;}

        [JsonProperty("dy")]
        public string Dy{get;set;}

        [JsonProperty("declines")]
        public string Declines{get;set;}

        [JsonProperty("advances")]
        public string Advances{get;set;}

        [JsonProperty("unchanged")]
        public string Unchanged{get;set;}
    }

    public class OCIndexPE
    {
        [JsonProperty("strikePrice")]
        public decimal StrikePrice{get;set;}

        [JsonProperty("expiryDate")]
        public string ExpiryDate{get;set;}

        [JsonProperty("underlying")]
        public string Underlying{get;set;}

        [JsonProperty("identifier")]
        public string Identifier{get;set;}

        [JsonProperty("opendecimalerest")]
        public decimal Opendecimalerest{get;set;}

        [JsonProperty("changeinOpendecimalerest")]
        public decimal ChangeinOpendecimalerest{get;set;}

        [JsonProperty("pchangeinOpendecimalerest")]
        public double PchangeinOpendecimalerest{get;set;}

        [JsonProperty("totalTradedVolume")]
        public decimal TotalTradedVolume{get;set;}

        [JsonProperty("impliedVolatility")]
        public double ImpliedVolatility{get;set;}

        [JsonProperty("lastPrice")]
        public double LastPrice{get;set;}

        [JsonProperty("change")]
        public double Change{get;set;}

        [JsonProperty("pChange")]
        public double PChange{get;set;}

        [JsonProperty("totalBuyQuantity")]
        public decimal TotalBuyQuantity{get;set;}

        [JsonProperty("totalSellQuantity")]
        public decimal TotalSellQuantity{get;set;}

        [JsonProperty("bidQty")]
        public decimal BidQty{get;set;}

        [JsonProperty("bidprice")]
        public double Bidprice{get;set;}

        [JsonProperty("askQty")]
        public decimal AskQty{get;set;}

        [JsonProperty("askPrice")]
        public double AskPrice{get;set;}

        [JsonProperty("underlyingValue")]
        public double UnderlyingValue{get;set;}

        [JsonProperty("totOI")]
        public decimal TotOI{get;set;}

        [JsonProperty("totVol")]
        public decimal TotVol{get;set;}
    }

    public class OCIndexRecords
    {
        [JsonProperty("expiryDates")]
        public List<string> ExpiryDates{get;set;}

        [JsonProperty("data")]
        public List<OCIndexData> Data{get;set;}

        [JsonProperty("timestamp")]
        public string Timestamp{get;set;}

        [JsonProperty("underlyingValue")]
        public double UnderlyingValue{get;set;}

        [JsonProperty("strikePrices")]
        public List<decimal> StrikePrices{get;set;}

        [JsonProperty("index")]
        public Index1 Index{get;set;}
    }




}
