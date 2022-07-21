namespace NSMkt.Models
{
    public class SampleChart
    {
        [JsonProperty("monthDataSeries1")]
        public MonthDataSeries1 MonthDataSeries1;

        [JsonProperty("monthDataSeries2")]
        public MonthDataSeries2 MonthDataSeries2;

        [JsonProperty("monthDataSeries3")]
        public MonthDataSeries3 MonthDataSeries3;
    }

    public class MonthDataSeries1
    {
        [JsonProperty("prices")]
        public List<decimal> Prices;

        [JsonProperty("dates")]
        public List<string> Dates;
    }

    public class MonthDataSeries2
    {
        [JsonProperty("prices")]
        public List<decimal> Prices;

        [JsonProperty("dates")]
        public List<string> Dates;
    }

    public class MonthDataSeries3
    {
        [JsonProperty("prices")]
        public List<decimal> Prices;

        [JsonProperty("dates")]
        public List<string> Dates;
    }
}
