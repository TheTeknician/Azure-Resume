using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MyFunctionApp
{
    public class VisitorCounter
    {
        private readonly ILogger _logger;

        public VisitorCounter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<VisitorCounter>();
        }

        [Function("VisitorCounter")]
        public async Task<MultiResponse> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            [CosmosDBInput("AzureResume", "counter", ConnectionStringSetting = "CosmosDbConnectionString", Id = "1", PartitionKey = "1")] Counter? counter = null)
        {
            _logger.LogInformation("Someone visited the page!");

            // If no counter exists, start at 0
            if (counter == null)
            {
                counter = new Counter { Id = "1", PartitionKey = "1", Count = 0 };
            }

            // Add 1 to the visitor count
            counter.Count += 1;

            // Send the new count back to the website
            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new { count = counter.Count });

            // Return both the HTTP response and the updated counter for Cosmos DB
            return new MultiResponse
            {
                HttpResponse = response,
                UpdatedCounter = counter
            };
        }
    }

    public class MultiResponse
    {
        [CosmosDBOutput("AzureResume", "counter", ConnectionStringSetting = "CosmosDbConnectionString")]
        public Counter UpdatedCounter { get; set; }

        public HttpResponseData HttpResponse { get; set; }
    }
}