using System.ComponentModel.DataAnnotations;

namespace PrinterRepairService.Models
{
    public class Order
    {
        public Order()
        {
        }

        public int Id { get; set; }

        [Required]
        public virtual Printer Printer {get; set;}

        [Required]
        public int PrinterId { get; set; }

        [Required]
        public virtual int TechnicianId { get; set; }

        public virtual Technician Technician { get; set; }
    }
}
