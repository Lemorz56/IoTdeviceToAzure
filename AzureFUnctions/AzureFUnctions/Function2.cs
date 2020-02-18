//SAVE TO COSMOS DB
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFUnctions
{
    public static class Function2
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("Function2")]
        public static void Run(
            [IoTHubTrigger("messages/events", Connection = "iotHubConnection", ConsumerGroup = "cosmosdb")]EventData message,
            [CosmosDB(databaseName: "msbrgcos", collectionName: "CosmosDBConnection", ConnectionStringSetting = "CosmosDBConnection" ,CreateIfNotExists = true)] out dynamic outputCosmosDb,
             ILogger log)
        {
            var obj = JsonConvert.DeserializeObject<DeviceMessageModel>(Encoding.UTF8.GetString(message.Body));

            obj.tempALERT = message.Properties["temperatureAlert"].ToString();
            obj.ownerName = message.Properties["MyName"].ToString();
            obj.propKlass = message.Properties["KlassCode"].ToString();
            obj.propSchool = message.Properties["School"].ToString();

            //obj.latitude = obj.location.latitude.ToString();
            //obj.longitude = obj.location.longitude.ToString();

            log.LogInformation("Temperature Alert: " + obj.tempALERT.ToString());

            //owner was here
            var json = JsonConvert.SerializeObject(obj);

            log.LogInformation($"Saving to COSMOS DB:  {Encoding.UTF8.GetString(message.Body.Array)}");
            outputCosmosDb = json;
        }
    }
} 