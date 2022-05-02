using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISWebMLApp.Models
{
    public class Machine
    {
        public long Id { get; set; }
        public string HostName { get; set; }
        public string Description { get; set; }
        public string IP { get; set; }
        public long StructureId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
