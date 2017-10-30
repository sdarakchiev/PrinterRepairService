using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrinterRepairService.Models
{
    public class Technician
    {
        public Technician()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IList<Order> Orders {get; set;}

    }
}
