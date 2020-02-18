using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace AzureFUnctions
{
    public static class Function1
    {
        private static HttpClient client = new HttpClient();
        
        [FunctionName("Function1")]
        [return: Table("messagesIoTpublished", Connection = "TableStorageConnection")]
        public static TableStorageModel Run([IoTHubTrigger("messages/events", Connection = "iotHubConnection", ConsumerGroup = "tablestorage")]EventData message, ILogger log)
        {
            var json = Encoding.UTF8.GetString(message.Body);

            var tableStorageModel = JsonConvert.DeserializeObject<TableStorageModel>(json);

            tableStorageModel.PartitionKey = "IOT";
            tableStorageModel.RowKey = Guid.NewGuid().ToString();

            var device = JsonConvert.DeserializeObject<DeviceMessageModel>(Encoding.UTF8.GetString(message.Body.Array));
            //First store the values in seperate "columns".
            tableStorageModel.tempALERT = message.Properties["temperatureAlert"].ToString();
            tableStorageModel.ownerName = message.Properties["MyName"].ToString();
            tableStorageModel.propKlass = message.Properties["KlassCode"].ToString();
            tableStorageModel.propSchool = message.Properties["School"].ToString();

            //device.latitude = tableStorageModel.location.latitude.ToString();
            //device.longitude = tableStorageModel.location.longitude.ToString();


            log.LogInformation($"Saving data to Table Storage. Data is: {Encoding.UTF8.GetString(message.Body.Array)}");

            return tableStorageModel;
        }
    }
}