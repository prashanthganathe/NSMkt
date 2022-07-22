namespace NSMkt.Models
{

    public class SampleLine
    {
        [JsonProperty("x")]
        public int x;

        [JsonProperty("y")]
        public int y;
    }

    public class LineSample
    {
        [JsonProperty("data")]
        public List<SampleLine> Data;
    }


}
