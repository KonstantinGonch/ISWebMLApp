using ISWebMLApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISWebMLApp.Controllers
{
    [ApiController]
    [Route("api/measurement")]
    public class MesurementController
    {
        [HttpPost]
        [Route("saveMeasurement")]
        public async Task AcceptMeasurement(MonitorMeasurement monitorMeasurement)
        {
            monitorMeasurement.Date = DateTime.Now;
            using (var dbContext = new AppDataContext())
            {
                dbContext.Measurements.Add(monitorMeasurement);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
