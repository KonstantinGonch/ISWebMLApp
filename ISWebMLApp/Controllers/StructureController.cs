using ISWebMLApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISWebMLApp.Controllers
{
    [ApiController]
    [Route("api/structure")]
    public class StructureController
    {
        [HttpPost]
        [Route("save")]
        public async void Save(Structure structure)
        {
            using (var dbContext = new AppDataContext())
            {
                dbContext.Structures.Add(structure);
                await dbContext.SaveChangesAsync();
            }
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<Structure> Get()
        {
            using (var dbContext = new AppDataContext())
            {
                return dbContext.Structures.ToList();
            }
        }
    }
}
