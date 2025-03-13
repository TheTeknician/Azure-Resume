using Newtonsoft.Json;

namespace MyFunctionApp
{
    public class Counter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}