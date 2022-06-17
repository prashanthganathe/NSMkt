using System.Text.Json.Serialization;

namespace NSMktAPI.Responses
{
    public class DeleteTaskResponse : BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TaskId { get; set; }
    }
}
