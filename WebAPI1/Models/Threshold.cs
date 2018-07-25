using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Threshold
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public long[] upTimeLimit;
        public long[] cpuLimit;
        public long[] ramLimit;
        public long[] freeLimit; // Drive Space Free
        public long[] percentLimit; // Drive % Free
    }
}