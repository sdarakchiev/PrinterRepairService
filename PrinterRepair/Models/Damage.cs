using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrinterRepairService.Models
{
    public class Damage
    {
        public Damage()
        {
        }

        [Key]
        public int Id { get; set; }

        public string DamageType { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Printer> Printers { get; set; }
    }
}
