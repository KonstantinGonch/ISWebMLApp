using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISWebMLApp.Models
{
    public class MonitorMeasurement
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long Uptime { get; set; }
        public int CpuUsage { get; set; }
        public int RamUsage { get; set; }
        public long MonitorUserId { get; set; }
        public bool ThreatFlag { get; set; }
    }
}
