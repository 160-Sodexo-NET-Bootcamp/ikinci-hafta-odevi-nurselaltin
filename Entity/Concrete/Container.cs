using Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Container: IEntity 
    {
        public int ContainerID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ContainerName { get; set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(10,6)")]
        public decimal Longitude { get; set; }
        
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
