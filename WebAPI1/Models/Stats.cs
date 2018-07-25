using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Stats
    {
        public DateTime currentTime { get; set; }
        public float cpuPercent { get; set; }
        public float ramPercent { get; set; }
        public Drive[] machineDrives { get; set; }
    }
}