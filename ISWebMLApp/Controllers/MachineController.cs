using ISWebMLApp.Models;
using ISWebMLApp.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISWebMLApp.Controllers
{
    [ApiController]
    [Route("api/machine")]
    public class MachineController
    {
        [HttpPost]
        [Route("save")]
        public async Task<Machine> Save(Machine machine)
        {
            using (var dbContext = new AppDataContext())
            {
                machine.Login = Converter.ConvertToLatin(machine.HostName);
                machine.Password = Converter.RandomString(10);
                dbContext.Machines.Add(machine);
                await dbContext.SaveChangesAsync();
                return machine;
            }
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<Machine> Get(long structureId)
        {
            using (var dbContext = new AppDataContext())
            {
                return dbContext.Machines.Where(m => m.StructureId == structureId).ToList();
            }
        }
    }
}
