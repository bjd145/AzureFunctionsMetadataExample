using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Metadata.Example
{
    public static class MetadataExample
    {
        [FunctionName("MetadataExample")]
        public static void Run([TimerTrigger("0 */2 * * * *")]TimerInfo myTimer, 
            [CosmosDB(
                databaseName: "%COSMOS_DATABASENAME%",
                collectionName: "%JOBDEFINITION_COLLECTIONNAME%",
                ConnectionStringSetting = "COSMOS_CONNECTIONSTRING",
                PartitionKey = "%COSMOS_PARTITIONKEY%",
                SqlQuery = "SELECT * FROM c")]
                IEnumerable<MyTask> task,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }

    public class MyTask { 
        public string id { get; set;}
        public string TaskName { get; set; }
        public string PartitionKey { get; set; }
    }
}
