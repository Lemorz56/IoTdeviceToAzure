using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFUnctions
{
    public class TableStorageModel : DeviceMessageModel
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        //public string temptest { get; set; } //ADDED BY MYSELF
        //public string humtest { get; set; } //
        //public string latitude { get; set; } //
        //public string longitude { get; set; } //
    }
}
