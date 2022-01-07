using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollectSystemAPI.ViewModels
{
    public class ContainerModel
    {
        public string ContainerName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int VehicleID { get; set; }
    }
}
