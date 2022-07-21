namespace NSMkt.Models
{

    public class SampleLine
    {
        [JsonProperty("x")]
        public int X;

        [JsonProperty("y")]
        public int Y;
    }

    public class LineSample
    {
        [JsonProperty("data")]
        public List<SampleLine> Data;
    }


}
