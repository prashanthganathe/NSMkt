namespace NSMkt.Models
{

    public class SampleLine
    {
        [JsonProperty("price")]
        public decimal price;

        [JsonProperty("coi")]
        public decimal coi;

        [JsonProperty("dt")]
        public string dt;
    }

    public class LineSample
    {
        [JsonProperty("data")]
        public List<SampleLine> Data;
    }


}
