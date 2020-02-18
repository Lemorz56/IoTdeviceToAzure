
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFUnctions
{
    public class DeviceMessageModel
    {
        public string deviceId { get; set; }
        public int messageId { get; set; }
        //public Location location { get; set; }
        //public Data data { get; set; }
        //public bool temperatureAlert { get; set; }
        
        //Put whatever is in Location in the floats below
        public string latitude { get; set; }
        public string longitude { get; set; }

        //Temperature Data
        public float temperature { get; set; }
        public float humidity { get; set; }

        //Properties
        public string tempALERT { get; set; }
        public string ownerName { get; set; }
        public string propKlass { get; set; }
        public string propSchool { get; set; }
        public string ts { get; set; }

    }
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
    
    //public class Data
    //{
    //    public string tag { get; set; }
    //    public bool Connection { get; set; }
    //    public Inside inside { get; set; }
    //    //public Outisde outisde { get; set; }
    //}

    //public class Inside
    //{
    //    public float temperature { get; set; }
    //    public float humidity { get; set; }
    //}
    /*
    public class Outisde
    {
        public float temperature { get; set; }
        //public float humidity { get; set; }
    }
    */
}
