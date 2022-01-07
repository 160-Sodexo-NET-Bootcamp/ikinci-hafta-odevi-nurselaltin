using Entity.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Vehicle: IEntity
    {
        [Key]
        [Column(TypeName = "int")]
        public int VehicleID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string  VehicleName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VehiclePlate { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
