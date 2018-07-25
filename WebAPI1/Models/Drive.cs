using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Drive
    {
        public string driveName { get; set; }
        public long driveTotal { get; set; }
        public long driveFree { get; set; }
        public float drivePercent { get; set; }
    }
}