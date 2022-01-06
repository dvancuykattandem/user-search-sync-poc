using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Document = Microsoft.Azure.Documents.Document;

namespace UserChangeFeedListener
{
    public static class USerSearchProcessor
    {
        [FunctionName("USerSearchProcessor")]
        public static async Task RunAsync([CosmosDBTrigger(
                databaseName: "MockSearchDatabase",
                collectionName: "Users",
                ConnectionStringSetting = "DbConnection",
                LeaseCollectionName = "leases",
                CreateLeaseCollectionIfNotExists = true)]
            IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        }
    }
}