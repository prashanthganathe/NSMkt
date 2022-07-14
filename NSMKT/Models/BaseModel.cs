namespace NSMkt.Models
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

        //public string LastModifiedBy { get; set; }

        //public DateTime? LastModified { get; set; }
    }
}
