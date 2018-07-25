using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Machine
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string machineName { get; set; }
        public string machineIp { get; set; }
        public string machineUpTime { get; set; }
        public List<Stats> machineStats { get; set; }
    }
}